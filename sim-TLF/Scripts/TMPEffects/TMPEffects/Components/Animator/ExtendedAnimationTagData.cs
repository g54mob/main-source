using TMPEffects.Databases;
using TMPEffects.Parameters;
using TMPEffects.Tags;

namespace TMPEffects.Components.Animator
{
	internal class ExtendedAnimationTagData
	{
		public readonly bool late;

		public readonly bool? overrides;

		public ExtendedAnimationTagData(TMPEffectTag tag, ITMPKeywordDatabase keywordDatabase)
		{
			late = tag.Parameters.ContainsKey("late");
			if (TMPParameterUtility.TryGetBoolParameter(out var value, tag.Parameters, keywordDatabase, "override", "or"))
			{
				overrides = value;
			}
		}
	}
}
