using System;
using System.Threading.Tasks;

namespace FibonacciCalculator.Business
{
    public class LinearFibonacciCalculator : ILinearFibonacciCalculator
    {
        public Task<int> CalculateAsync(int position)
        {
            var results = new int[position + 1];

            results[0] = 0;
            results[1] = 1;

            for (var i = 2; i <= position; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }

            return Task.FromResult(results[position]);
        }
    }
}