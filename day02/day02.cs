using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 2 Solution!");
        var levelList = CreateLevelList();
        int result = Part1(levelList);
        Console.WriteLine($"Part1 Result: {result}");
        result = Part2(levelList);
        Console.WriteLine($"Part2 Result: {result}");
    }

    static List<List<int>> CreateLevelList()
    {
        string[] lines = File.ReadAllLines("input.txt");
        var levelList = new List<List<int>>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> row = new List<int>(Array.ConvertAll(parts, int.Parse));
            levelList.Add(row);
        }

        return levelList;
    }

    static int Part1(List<List<int>> levelList)
    {
        int safeReports = 0;

        for (int i = 0; i < levelList.Count; i++)
        {
            List<int> report = levelList[i];
            
            if (IsSafeReport(report))
            {
                safeReports++;
            }
        }

        return safeReports;
    }

    static int Part2(List<List<int>> levelList)
    {
        int safeReports = 0;

        for (int i = 0; i < levelList.Count; i++)
        {
            List<int> report = levelList[i];
            
            if (IsSafeReport(report) || CanBeSafeReport(report))
            {
                safeReports++;
            }
        }

        return safeReports;

    }

    static bool IsSafeReport(List<int> report)
    {
        bool increasing = true;
        bool decreasing = true;

        for (int i = 0; i < report.Count - 1; i++)
        {
            int diff = Math.Abs(report[i] - report[i + 1]);
            if (diff < 1 || diff > 3)
            {
                return false;
            }
            if (report[i] >= report[i + 1]) increasing = false;
            if (report[i] <= report[i + 1]) decreasing = false;
        }

        return increasing || decreasing;
    }

    static bool CanBeSafeReport(List<int> report)
    {
        for (int i = 0; i < report.Count; i++)
        {
            List<int> safeReportCandidate = new List<int>(report);
            safeReportCandidate.RemoveAt(i);

            if (IsSafeReport(safeReportCandidate))
            {
                return true;
            }
        }

        return false;
    }
}