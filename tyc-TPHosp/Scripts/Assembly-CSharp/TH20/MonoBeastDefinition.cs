using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MonoBeastDefinition : EntityDefinition
	{
		public readonly GameObject VisualPrefab;

		public readonly float MovementSpeed = 1f;

		[InspectorTooltip("Max distance to search for a hiding place")]
		public readonly float MaxScamperDistance = 40f;

		[InspectorTooltip("Beast will be destroyed if no hiding place is found within this time")]
		public readonly float NowhereToHideTime = 20f;

		[InspectorHeader("Reactions")]
		public float MinTimeBetweenReactionsInSeconds = 5f;

		public float MaxTimeBetweenReactionsInSeconds = 10f;

		public SharedInstance<CharacterActionDefinition>[] Reactions;

		public float GetRandomReactionTime()
		{
			return RandomUtils.GlobalRandomInstance.NextFloat(MinTimeBetweenReactionsInSeconds, MaxTimeBetweenReactionsInSeconds);
		}

		public CharacterActionDefinition GetRandomReaction()
		{
			if (Reactions == null || Reactions.Length == 0)
			{
				return null;
			}
			return Reactions.RandomItem().Instance;
		}
	}
}
