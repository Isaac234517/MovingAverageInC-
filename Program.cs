using System;
using Spectre.Console;

namespace MovingAverageInDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seq = GenerateRandomWalkSequence(10);
            var model = new MovingAverage(seq, 2);
            var result = model.Calculate();
            var table = new Table()
                .AddColumns("Index", "Value", "Moving Average");
            for(int i =0; i < seq.Length; i++){
                table.AddRow(i.ToString(), seq[i].ToString(),
                 result[i] == null? "": string.Format("{0:0.00}", result[i]));
            }
            AnsiConsole.Render(table);
            
            Console.WriteLine("Getting arbitrary elements from index");
            table =new Table()
                .AddColumns("Index", "Value", "Moving Average");
            var (idx, v, average ) = model.GettingElement(6);
            table.AddRow(idx.ToString(), v.ToString(), average == null? "": string.Format("{0:0.00}", average));
            (idx, v, average) = model.GettingElement(6, true);
            table.AddRow(idx.ToString(), v.ToString(), average == null? "": string.Format("{0:0.00}", average));
            AnsiConsole.Render(table);
        }

        static int[] GenerateRandomWalkSequence(int len){
            int[] result = new int[len];
            var rand = new Random();
            for(int i=0; i<len; i++){
                int movement = rand.Next(0,2) > 0.5 ? 1:-1;
                if(i == 0)
                    result[i] = movement;
                else
                    result[i] = result[i-1] + movement;
            }
            return result;
        }
    }
}
