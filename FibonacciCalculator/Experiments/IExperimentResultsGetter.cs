namespace FibonacciCalculator.Experiments
{
    public interface IExperimentResultsGetter
    {
        LastResults LastResults { get; }
        OverallResults OverallResults { get; }
    }
}