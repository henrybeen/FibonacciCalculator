using System.Linq;
using System.Threading.Tasks;
using GitHub;

namespace FibonacciCalculator.Experiments
{
    public class ExperimentResultPublisher : IResultPublisher, IExperimentResultsGetter
    {
        public LastResults LastResults { get; private set; }
        public OverallResults OverallResults { get; } = new OverallResults();

        public Task Publish<T, TClean>(Result<T, TClean> result)
        {
            if (result.ExperimentName == "fibonacci-implementation")
            { 
                LastResults = new LastResults(! result.Mismatched, result.Control.Duration, result.Candidates.Single().Duration);
                OverallResults.Accumulate(LastResults);
            }

            return Task.CompletedTask;
        }
    }
}
