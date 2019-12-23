using System;
using GitHub;

namespace FibonacciCalculator.Experiments
{
    public class LastResults
    {
        public bool HasErrors { get;}
        public TimeSpan RecursiveDuration { get; }
        public TimeSpan LineairDuration { get; }
        public LastResults(bool hasErrors, in TimeSpan recursiveDuration, in TimeSpan lineairDuration)
        {
            HasErrors = hasErrors;
            RecursiveDuration = recursiveDuration;
            LineairDuration = lineairDuration;
        }
    }
}