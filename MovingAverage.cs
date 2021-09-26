using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingAverageInDotnet {
   public class MovingAverage {
      private readonly int[] _sequence;
      private int _windowLen;
      private List<double?> _result;

      public MovingAverage(int[] seq, int k ){
         _sequence = seq;
         _windowLen = k;
      }

      public double?[] Calculate() {
         _result = new List<double?>();
         int startIdx = 0;
         int endIdx = _windowLen;
         while(startIdx + _windowLen <= _sequence.Length){
            Range r = startIdx..endIdx;
            var subRange = _sequence[r];
            _result.Add(subRange.Average());
            startIdx +=1;
            endIdx +=1;
         }
         for(int i =0; i< _windowLen-1; i++){ // adjustment
            _result.Insert(0, null);
         }
         return _result.ToArray();
      }

      public (int index, int value, double? average) GettingElement(int idx, bool reverse = false) =>
         reverse ?  (
            _sequence.Length - idx,
            _sequence[^idx],
            _result[^idx]
         )
         : 
         (
            idx,
            _sequence[idx],
            _result[idx]
         );
   }
}