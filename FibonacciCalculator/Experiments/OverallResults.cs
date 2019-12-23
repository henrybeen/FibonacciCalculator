namespace FibonacciCalculator.Experiments
{
    public class OverallResults
    {
        public int ExperimentsCount { get; set; }
        public int ExperimentsFailed { get; set; }
        public DurationStatistics RecursiveDurationStatistics { get; }
        public DurationStatistics LineairDurationStatistics { get; }

        public OverallResults()
        {
            ExperimentsCount = 0;
            ExperimentsFailed = 0;
            RecursiveDurationStatistics = new DurationStatistics();
            LineairDurationStatistics = new DurationStatistics();
        }

        public void Accumulate(LastResults lastResults)
        {
            ExperimentsCount++;
            ExperimentsFailed += lastResults.HasErrors ? 0 : 1;
            RecursiveDurationStatistics.Accumulate(lastResults.RecursiveDuration);
            LineairDurationStatistics.Accumulate(lastResults.LineairDuration);
        }
    }
}