using System.Threading.Tasks;

namespace FibonacciCalculator.Business
{
    public class RecursiveFibonacciCalculator : IRecursiveFibonacciCalculator
    {
        public Task<int> CalculateAsync(int position)
        {
            return Task.FromResult(InnerCalculate(position));
        }

        private int InnerCalculate(int position)
        {
            if (position < 1)
            {
                return 0;
            }
            if (position == 1)
            {
                return 1;
            }

            return InnerCalculate(position - 1) + InnerCalculate(position - 2);

        }
    }
}