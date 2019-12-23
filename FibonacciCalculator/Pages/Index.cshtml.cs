using System.Runtime.Serialization;
using System.Threading.Tasks;
using FibonacciCalculator.Business;
using FibonacciCalculator.Experiments;
using GitHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FibonacciCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRecursiveFibonacciCalculator _recursiveFibonacciCalculator;
        private readonly ILinearFibonacciCalculator _linearFibonacciCalculator;
        private readonly IExperimentResultsGetter _experimentResultsGetter;

        public bool HasResult { get; private set; }
        public int Position { get; private set; }
        public int Result { get; private set; }
        public LastResults LastResults { get; private set; }
        public OverallResults OverallResults { get; private set; }

        [BindProperty]
        public FibonacciInput FibonacciInput { get; set; }

        public IndexModel(IRecursiveFibonacciCalculator recursiveFibonacciCalculator, ILinearFibonacciCalculator linearFibonacciCalculator, IExperimentResultsGetter experimentResultsGetter)
        {
            _recursiveFibonacciCalculator = recursiveFibonacciCalculator;
            _linearFibonacciCalculator = linearFibonacciCalculator;
            _experimentResultsGetter = experimentResultsGetter;
        }

        public void OnGet()
        {
            HasResult = false;
        }

        public async Task OnPost()
        {
            HasResult = true;
            Position = FibonacciInput.Position;

            Result = await Scientist.ScienceAsync<int>("fibonacci-implementation", experiment =>
            {
                experiment.Use(async () => await _recursiveFibonacciCalculator.CalculateAsync(Position));
                experiment.Try(async () => await _linearFibonacciCalculator.CalculateAsync(Position));

                experiment.AddContext("Position", Position);
            });

            LastResults = _experimentResultsGetter.LastResults;
            OverallResults = _experimentResultsGetter.OverallResults;
        }
    }
}
