using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeRacoonAttackConfig : ChallengeConfig
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Racoon Attack Config")]
		public float AttackPercentage = 0.5f;

		public float MinAttackFrequencyInSeconds = 2f;

		public float MaxAttackFrequencyInSeconds = 6f;

		public GameObject[] RacoonPrefabs;

		public SharedInstance<RoomItemDefinition>[] BinItems;

		public int MinLitterCount;

		public int MaxLitterCount;

		public float LitterSpawnRadius = 4f;

		public SharedInstance<RoomItemDefinition>[] LitterItems;

		public string SFXLoop;

		public ParticleSystem[] EnvironmentEffects;

		public SharedInstance<CharacterStatusEffectDefinition> StatusEffect;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeRacoonAttack(this, level);
		}
	}
}
