using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

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
            int n = 10000000;
            
            int[] a = GenRandomArray(n);
            int[] b = new int[n];
            int[] c = new int[n];
            Array.Copy(a, b, n);
            Array.Copy(a, c, n);
            Stopwatch st = new Stopwatch();
            st.Start();
            MergeSort(b, 0, n - 1);
            st.Stop();
            writer.WriteLine(st.ElapsedMilliseconds);
            st.Reset();
            st.Start();
            MergeSort1(c, 0, n - 1);
            st.Stop();
            writer.WriteLine(st.ElapsedMilliseconds);
            /*st.Reset();
            st.Start();
            InsertionSort(c, 0, n - 1);
            st.Stop();
            writer.WriteLine(st.ElapsedMilliseconds);*/
            writer.WriteLine(Assert(b, 0, n - 1));
            writer.WriteLine(Assert(c, 0, n - 1));
            writer.Flush ();
            reader.ReadLine ();
        }

        
        
        static void PrintArray(int[] a, int l, int r) {
            for(int i = l; i <= r; i++) {
                writer.Write(a[i] + " ");
            }
            writer.WriteLine();
        }

        static void Solve(int n, int m, int[] a, int[] q) {
            
        }
        
        static int[] GenRandomArray(int n) {
            int[] a = new int[n];
            Random random = new Random((int) DateTime.Now.Ticks);
            for(int i = 0; i < n; i++) {
                a[i] = random.Next(-100, 100);
            }
            return a;
        }
        
        static bool Assert(int[] a, int l, int r) {
            for(int i = l; i < r; i++) {
                if(a[i] > a[i + 1]) {
                    return false;
                }
            }
            return true;
        }
        
        static void InsertionSort(int[] a, int l, int r) {
            for(int i = l + 1; i <= r; i++) {
                int key = a[i];
                int j = i - 1;
                while(j >= 0 && a[j] > key) {
                    Swap(a, j, j + 1);
                    --j;
                }
                a[j + 1] = key;
            }
        }
        
        static void MergeSort(int[] a, int l, int r) {
            int[] b = new int[a.Length];
            MergeSortRec(a, b, l, r);
        }
        
        static void MergeSort1(int[] a, int l, int r) {
            int[] b = new int[a.Length];
            MergeSortRec1(a, b, l, r);
        }
        
        static int MAGIC_NUMBER = 50;
        
        static void MergeSortRec1(int[] a, int[] b, int l, int r) {
            if(l >= r) {
                return;
            }
            int mid = l + (r - l) / 2;
            MergeSortRec1(a, b, l, mid);
            MergeSortRec1(a, b, mid + 1, r);
            Merge(a, b, l, mid, r);
        }
        
        static void MergeSortRec(int[] a, int[] b, int l, int r) {
            if(l >= r) {
                return;
            }
            int mid = l + (r - l) / 2;
            if(mid - l + 1 <= MAGIC_NUMBER){
                InsertionSort(a, l, mid);
                InsertionSort(a, mid + 1, r);
            } else {
                MergeSortRec(a, b, l, mid);
                MergeSortRec(a, b, mid + 1, r);
            }
            Merge(a, b, l, mid, r);
        }
        
        static void Merge(int[] a, int[] b, int l, int mid, int r) {
            int left, right;
            left = l; right = mid + 1;
            int i = l;
            for(i = l; i <= r && left <= mid && right <= r; i++) {
                if(a[left] <= a[right]) {
                    b[i] = a[left];
                    left++;
                } else {
                    b[i] = a[right];
                    right++;
                }
            }
            while(left <= mid) {
                b[i++] = a[left++];
            }
            while(right <= r) {
                b[i++] = a[right++];
            }
            for(i = l; i <= r; i++) {
                a[i] = b[i];
            }
        }
        
        
        
        static void Swap(int[] a, int l, int r) {
            int temp = a[l];
            a[l] = a[r];
            a[r] = temp;
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
