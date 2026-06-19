using System.Collections.Generic;
using System.Linq;
using QFSW.QC.Utilities;

namespace QFSW.QC
{
	public abstract class BasicCachedQcSuggestor<TItem> : IQcSuggestor
	{
		private readonly Dictionary<TItem, IQcSuggestion> _suggestionCache = new Dictionary<TItem, IQcSuggestion>();

		private OptimalStringAlignmentMultiQueryMatcher _OSAMatcher = new OptimalStringAlignmentMultiQueryMatcher();

		protected abstract bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options);

		protected abstract IQcSuggestion ItemToSuggestion(TItem item);

		protected abstract IEnumerable<TItem> GetItems(SuggestionContext context, SuggestorOptions options);

		protected virtual bool IsMatch(SuggestionContext context, IQcSuggestion suggestion, SuggestorOptions options)
		{
			return SuggestorUtilities.IsCompatible(context.Prompt, suggestion.PrimarySignature, _OSAMatcher, options);
		}

		public IEnumerable<IQcSuggestion> GetSuggestions(SuggestionContext context, SuggestorOptions options)
		{
			if (!CanProvideSuggestions(context, options))
			{
				return Enumerable.Empty<IQcSuggestion>();
			}
			return from suggestion in GetItems(context, options).Select(ItemToSuggestionCached)
				where IsMatch(context, suggestion, options)
				select suggestion;
		}

		private IQcSuggestion ItemToSuggestionCached(TItem item)
		{
			if (_suggestionCache.TryGetValue(item, out var value))
			{
				return value;
			}
			return _suggestionCache[item] = ItemToSuggestion(item);
		}
	}
}
