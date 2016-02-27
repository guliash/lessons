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
            Solve (n, a);
            writer.Flush ();
            reader.ReadLine ();
        }


        static void Solve(int n, int m, int[] a, int[] q) {
            int[] p1 = new int[n + 1];
            int[] p2 = new int[n + 1];
            long sum = 0;
            for(int i = 0; i < n; i++) {
                sum += a[i];
            }
            if(sum % 3 != 0) {
                writer.WriteLine(0);
                return;
            }
            long x = sum / 3;
            sum = 0;
            for(int i = 1; i <= n; i++) {
                sum += a[i - 1];
                p1[i] = p1[i - 1] + (sum == x ? 1 : 0);
            }

            sum = 0;
            for(int i = 1; i <= n; i++) {
                sum += a[i - 1];
                p2[i] = p2[i - 1] + (sum == 2 * x ? 1 : 0);
            }
            long ans = 0;
            sum = 0;
            for(int i = 1; i <= n - 2; i++) {
                sum += a[i - 1];
                int cnt = p2[n - 1] - p2[i];
                if(sum == x) {
                    ans += cnt;
                }
            }
            writer.WriteLine(ans);

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
