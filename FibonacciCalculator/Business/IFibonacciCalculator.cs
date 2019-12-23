using System.Threading.Tasks;

namespace FibonacciCalculator.Business
{
    public interface IFibonacciCalculator
    {
        Task<int> CalculateAsync(int position);
    }
}