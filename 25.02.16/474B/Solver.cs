using System;
using System.IO;
using System.Collections.Generic;

namespace CF {
    class Solver {
        private static TextReader reader;
        private static TextWriter writer;
        public static void Main (string[] args) {
            reader = new StreamReader (Console.OpenStandardInput ());
            writer = new StreamWriter (Console.OpenStandardOutput ());
            new Solver ().Solve ();
            reader.Close ();
            writer.Close ();
        }

        public void Solve() {
            int n = ReadInt ();
            int[] a = new int[n];
            for(int i = 0; i < n; i++) {
                a[i] = ReadInt();
            }
            int m = ReadInt();
            int[] q = new int[m];
            for (int i = 0; i < m; i++) {
                q [i] = ReadInt ();
            }
            Solve (n, m, a, q);
            writer.Flush ();
            reader.ReadLine ();
        }


        static void Solve(int n, int m, int[] a, int[] q) {
            int[] sum = new int[n + 1];
            for(int i = 1; i <= n; i++) {
                sum[i] = sum[i - 1] + a[i - 1];
            }

            for(int i = 0; i < m; i++) {
                int left, right, mid;
                left = 0; right = n - 1;
                while(left < right) {
                    mid = left + (right - left) / 2;
                    if(sum[mid + 1] < q[i]) {
                        left = mid + 1;
                    } else {
                        right = mid;
                    }
                }
                writer.WriteLine(left + 1);
            }

        }


        private static String[] tokens = new String[0];
        private static int curToken = 0;
        private static void ReadAndSplitLine() {
            tokens = reader.ReadLine ().Split (new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            curToken = 0;
        }

        private static string ReadToken() {
            while (curToken == tokens.Length) {
                ReadAndSplitLine ();
            }
            return tokens [curToken++];
        }

        private static int ReadInt() {
            return int.Parse (ReadToken ());
        }

    }
}
