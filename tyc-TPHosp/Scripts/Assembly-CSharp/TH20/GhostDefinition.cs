using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GhostDefinition : CharacterDefinition
	{
		[InspectorDivider]
		[InspectorHeader("Ghost Data")]
		[InspectorMargin(10)]
		[InspectorTooltip("Death behaviour")]
		public float LifeSpan = 30f;

		[InspectorTooltip("Min time to haunt characters")]
		public float HauntTimeMin = 15f;

		[InspectorTooltip("Max time to haunt characters")]
		public float HauntTimeMax = 30f;

		[InspectorTooltip("Room item ghost and janitor interact with when capturing")]
		public readonly SharedInstance<RoomItemDefinition> CaptureItem;

		[InspectorTooltip("Ectoplasm item ghost randomly drops")]
		public readonly SharedInstance<RoomItemDefinition> EctoplasmItem;

		[InspectorTooltip("Min time to drop Ectoplasm")]
		public float EctoplasmTimeMin = 10f;

		[InspectorTooltip("Max time to drop Ectoplasm")]
		public float EctoplasmTimeMax = 20f;

		public float GetEctoplasmDropTime()
		{
			return RandomUtils.GlobalRandomInstance.NextFloat(EctoplasmTimeMin, EctoplasmTimeMax);
		}
	}
}
