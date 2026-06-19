using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class ResearchNodeDefinition
	{
		public Sprite Icon;

		public int CompletionsRequired = 1;

		public ObjectiveDefinition Objective;

		public SharedInstance<LevelConfig>[] RecommendedLevels;
	}
}
