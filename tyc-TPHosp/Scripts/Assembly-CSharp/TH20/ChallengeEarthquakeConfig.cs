using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeEarthquakeConfig : ChallengeConfig
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Earthquake Config")]
		public int DurationInDays;

		public float DamageOverTime;

		public SharedInstance<CharacterStatusEffectDefinition> StatusEffect;

		public int DebrisCount;

		public float SpawnPositionRange = 0.5f;

		public float SpawnRotationRange = 360f;

		public SharedInstance<RoomItemDefinition>[] DebrisItems;

		public bool CameraShakePosition = true;

		public bool CameraShakeRotation = true;

		public float CameraShakeSpeed = 20f;

		public float CameraShakeMagnitude = 2f;

		public string EarthquakeLoopSFX;

		public ParticleSystem[] EnvironmentEffects;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeEarthquake(this, level);
		}
	}
}
