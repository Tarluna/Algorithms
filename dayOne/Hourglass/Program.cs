using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    static int HourglassSum(int[][] arr)
    {
        int maxHourglass = int.MinValue;

        for (int i = 0; i < arr.Length; i++)
        {
            if (IsInbound(arr, i, 2))
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (IsInbound(arr, i, j + 2))
                    {
                        maxHourglass = Math.Max(GetValue(arr, i, j), maxHourglass);

                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }
        return maxHourglass;
    }

    static int GetValue(int[][] arr, int currentRow, int currentColunm)
    {
        return arr[currentRow][currentColunm] +
        arr[currentRow][currentColunm + 1] +
        arr[currentRow][currentColunm + 2] +
        arr[currentRow + 1][currentColunm + 1] +
        arr[currentRow + 2][currentColunm] +
        arr[currentRow + 2][currentColunm + 1] +
        arr[currentRow + 2][currentColunm + 2];
    }

    static bool IsInbound(int[][] arr, int currentRow, int currentColunm)
    {
        return arr.Length - 1 >= currentRow + 2 && arr[currentRow].Length - 1 >= currentColunm;
    }

    static void Main(string[] args)
    {

        int[][] arr = new int[][]
        {
            new int[] { 1, 1, 1, 0, 0, 0},
            new int[] { 0, 1, 0, 0, 0, 0},
            new int[] { 1, 1, 1, 0, 0, 0},
            new int[] { 0, 0, 2, 4, 4, 0},
            new int[] { 0, 0, 0, 2, 0, 0},
            new int[] { 0, 0, 1, 2, 4, 0}
        };

        int result = HourglassSum(arr);
        System.Console.WriteLine(result);
    }
}
