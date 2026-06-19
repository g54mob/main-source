using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class MetagameObjectiveDefinition : ObjectiveDefinition
	{
		[InspectorMargin(4)]
		[InspectorDivider]
		[InspectorHeader("Metagame")]
		public bool HideUntilProgressAboveZero;

		public SharedInstance<MetagameObjectiveDefinition>[] Prerequisites;

		public bool TriggerAchievementOnComplete;

		public AchievementId Achievement;

		public bool HideFromUI;
	}
}
