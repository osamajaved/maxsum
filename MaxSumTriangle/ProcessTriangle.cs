using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxSumTriangle
{
    public enum EvenOdd
    {
        Even = 1,
        Odd = 2
    }
    public static class ProcessTriangle
    {

        public static List<int> ProcessInput(List<string[]> inputList)
        {
            var FinalList = new List<int>();
            //var numberPair = new NumberPair();
            var nextIndexStart = 0;
            bool nextTakeIsEven=false;

            var firstRow = 0;


            foreach (var line in inputList)
            {
                if (firstRow == 0)
                {
                    var check = CheckEvenOdd(Convert.ToInt32(line[nextIndexStart]));
                    FinalList.Add(Convert.ToInt32(line[firstRow]));
                    if (check == (int)EvenOdd.Odd)
                        nextTakeIsEven = true;
                    firstRow++;
                    continue;
                }
                var numberPair = new NumberPair();

                var numberWithIndex = new NumberWithIndex();
                numberWithIndex.Number=Convert.ToInt32(line[nextIndexStart]);
                numberWithIndex.Index = nextIndexStart;
                numberPair.FirstNumber = numberWithIndex;
                numberWithIndex = new NumberWithIndex();
                numberWithIndex.Number = Convert.ToInt32(line[nextIndexStart+1]);
                numberWithIndex.Index = nextIndexStart+1;
                numberPair.SecondNumber = numberWithIndex;

                if (nextTakeIsEven)
                {
                    if (BothNumberAreSameType(numberPair))
                    {
                        var choosenNumber = GetGreaterNumber(numberPair);
                        nextIndexStart = choosenNumber.Index;
                        FinalList.Add(choosenNumber.Number);
                    }
                    else
                    {
                        if (CheckEvenOdd(numberPair.FirstNumber.Number) == (int)EvenOdd.Even)
                        {
                            nextIndexStart = numberPair.FirstNumber.Index;
                            FinalList.Add(numberPair.FirstNumber.Number);
                        }
                        else
                        {
                            nextIndexStart = numberPair.SecondNumber.Index;
                            FinalList.Add(numberPair.SecondNumber.Number);
                        }

                    }
                    nextTakeIsEven = false;
                }
                else
                {
                    if (BothNumberAreSameType(numberPair))
                    {
                        var choosenNumber = GetGreaterNumber(numberPair);
                        nextIndexStart = choosenNumber.Index;
                        FinalList.Add(choosenNumber.Number);
                    }
                    else
                    {
                        if (CheckEvenOdd(numberPair.FirstNumber.Number) == (int)EvenOdd.Odd)
                        {
                            nextIndexStart = numberPair.FirstNumber.Index;
                            FinalList.Add(numberPair.FirstNumber.Number);
                        }
                        else
                        {
                            nextIndexStart = numberPair.SecondNumber.Index;
                            FinalList.Add(numberPair.SecondNumber.Number);
                        }

                    }
                    nextTakeIsEven = true;
                }
                


                
            }
            return FinalList;
        }

        public static int CheckEvenOdd(int num)
        {
            if (num % 2 == 0)
                return (int)EvenOdd.Even;
            return (int)EvenOdd.Odd;
        }

        public static bool BothNumberAreSameType(NumberPair pair)
        {
            if (CheckEvenOdd(pair.FirstNumber.Number) == CheckEvenOdd(pair.SecondNumber.Number))
                return true;
            return false;
        }

        public static NumberWithIndex GetGreaterNumber(NumberPair pair)
        {
            if (pair.FirstNumber.Number > pair.SecondNumber.Number)
                return pair.FirstNumber;
            return pair.SecondNumber;
        }

    }



    public class NumberPair
    {
        public NumberWithIndex FirstNumber { get; set; }

        public NumberWithIndex SecondNumber { get; set; }
    }

    public class NumberWithIndex
    {
        public int Number { get; set; }
        public int Index { get; set; }
    }
}
