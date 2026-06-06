using System.Collections.Generic;

namespace Brewery.Core
{
	public static class AlchemyReactionSystem
	{
		public class ReactionResult
		{
			public BrewTag FinalTags { get; set; }

			public List<string> SynthesisReactions { get; set; }

			public List<string> TransformationReactions { get; set; }

			public List<string> SuppressionReactions { get; set; }

			public List<BrewTag> SynthesizedTags { get; set; }

			public Dictionary<BrewTag, BrewTag> TransformedTags { get; set; }

			public List<BrewTag> SuppressedTags { get; set; }

			public bool HasReactions => false;
		}

		private static readonly Dictionary<(BrewTag, BrewTag), BrewTag> SynthesisRules;

		private static readonly Dictionary<(BrewTag, BrewTag), (BrewTag remove, BrewTag add)> TransformationRules;

		private static readonly Dictionary<BrewTag, List<BrewTag>> SuppressionRules;

		public static ReactionResult ApplyReactions(BrewTag originalTags)
		{
			return null;
		}

		public static BrewTag ApplySuppressions(BrewTag combinedTags, out List<BrewTag> suppressedTags, out List<string> suppressionReasons)
		{
			suppressedTags = null;
			suppressionReasons = null;
			return default(BrewTag);
		}

		private static BrewTag ApplySynthesis(BrewTag tags, ReactionResult result)
		{
			return default(BrewTag);
		}

		private static BrewTag ApplyTransformations(BrewTag tags, ReactionResult result)
		{
			return default(BrewTag);
		}

		private static BrewTag ApplySuppressions(BrewTag tags, ReactionResult result)
		{
			return default(BrewTag);
		}

		public static string GetReactionRulesDescription()
		{
			return null;
		}

		public static bool IsEmergentTag(BrewTag tag)
		{
			return false;
		}

		public static string GetReactionPreview(BrewTag originalTags)
		{
			return null;
		}

		private static string GetTagsString(BrewTag tags)
		{
			return null;
		}
	}
}
