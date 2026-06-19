using System.Collections.Generic;
using System.Linq;
using QFSW.QC.Comparators;
using QFSW.QC.Utilities;

namespace QFSW.QC
{
	public class QuantumSuggestor
	{
		private readonly IQcSuggestor[] _suggestors;

		private readonly IQcSuggestionFilter[] _suggestionFilters;

		private readonly List<IQcSuggestion> _suggestionBuffer = new List<IQcSuggestion>();

		private readonly OptimalStringAlignmentMultiQueryMatcher _OSAMatcher = new OptimalStringAlignmentMultiQueryMatcher();

		public QuantumSuggestor(IEnumerable<IQcSuggestor> suggestors, IEnumerable<IQcSuggestionFilter> suggestionFilters)
		{
			_suggestors = suggestors.ToArray();
			_suggestionFilters = suggestionFilters.ToArray();
		}

		public QuantumSuggestor()
			: this(new InjectionLoader<IQcSuggestor>().GetInjectedInstances(), new InjectionLoader<IQcSuggestionFilter>().GetInjectedInstances())
		{
		}

		public IEnumerable<IQcSuggestion> GetSuggestions(SuggestionContext context, SuggestorOptions options)
		{
			PreprocessContext(ref context);
			IEnumerable<IQcSuggestion> collection = from x in _suggestors.SelectMany((IQcSuggestor x) => x.GetSuggestions(context, options))
				where IsSuggestionPermitted(x, context)
				select x;
			_suggestionBuffer.Clear();
			_suggestionBuffer.AddRange(collection);
			AlphanumComparator comparer = new AlphanumComparator();
			IOrderedEnumerable<IQcSuggestion> orderedEnumerable = _suggestionBuffer.OrderBy((IQcSuggestion x) => x.PrimarySignature.Length).ThenBy((IQcSuggestion x) => x.PrimarySignature, comparer).ThenBy((IQcSuggestion x) => x.SecondarySignature.Length)
				.ThenBy((IQcSuggestion x) => x.SecondarySignature, comparer);
			if (options.Fuzzy)
			{
				orderedEnumerable = orderedEnumerable.OrderBy((IQcSuggestion x) => _OSAMatcher.Match(x.PrimarySignature, context.Prompt, options.CaseSensitive));
			}
			return orderedEnumerable;
		}

		private void PreprocessContext(ref SuggestionContext context)
		{
			TextProcessing.ReduceScopeOptions options = TextProcessing.ReduceScopeOptions.Default;
			options.ReduceIncompleteScope = true;
			context.Prompt = context.Prompt.ReduceScope(options);
		}

		private bool IsSuggestionPermitted(IQcSuggestion suggestion, SuggestionContext context)
		{
			IQcSuggestionFilter[] suggestionFilters = _suggestionFilters;
			for (int i = 0; i < suggestionFilters.Length; i++)
			{
				if (!suggestionFilters[i].IsSuggestionPermitted(suggestion, context))
				{
					return false;
				}
			}
			return true;
		}
	}
}
