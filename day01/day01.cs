using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 1 Solution!");
        var (leftList, rightList) = CreateLeftAndRightList();
        int result = Part1(leftList, rightList);
        Console.WriteLine($"Part1 Result: {result}");
        result = Part2(leftList, rightList);
        Console.WriteLine($"Part2 Result: {result}");
    }

    static (List<int> leftList, List<int> rightList) CreateLeftAndRightList()
    {
        string[] lines = File.ReadAllLines("input.txt");
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                leftList.Add(int.Parse(parts[0]));
                rightList.Add(int.Parse(parts[1]));
            }
        }

        return (leftList, rightList);
    }

    static int Part1(List<int> leftList, List<int> rightList)
    {

        leftList.Sort();
        rightList.Sort();

        int totalDistance = 0;
        for (int i = 0; i < leftList.Count; i++)
        {
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }

        return totalDistance;
    }

    static int Part2(List<int> leftList, List<int> rightList)
    {
        int similarityScore = 0;
        foreach (int num in leftList)
        {
            int count = rightList.FindAll(x => x == num).Count;
            similarityScore += num * count;
        }

        return similarityScore;
    }
}