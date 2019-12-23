using System;

namespace FibonacciCalculator.Experiments
{
    public class DurationStatistics
    {
        public TimeSpan Minimum { get; private set; }
        public TimeSpan Maximum { get; private set; }
        public int Count { get; private set; }
        public TimeSpan Average => _total / Count;
        private TimeSpan _total;

        public DurationStatistics()
        {
            Minimum = TimeSpan.MaxValue;
            Maximum = TimeSpan.Zero;
            Count = 0;
            _total = TimeSpan.Zero;
        }

        public void Accumulate(TimeSpan duration)
        {
            Minimum = duration < Minimum ? duration : Minimum;
            Maximum = duration > Maximum ? duration : Maximum;
            Count++;
            _total += duration;
        }
    }
}