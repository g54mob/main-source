using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeAmbulanceEmergencyConfig : ChallengeConfig
	{
		public enum EmergencySeverityType
		{
			Minor = 0,
			Major = 1
		}

		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Emergency Config")]
		public int MinPatients;

		public int MaxPatients;

		public bool IsTutorial;

		public bool IsRescue;

		public WeightedIllness[] WeightedIllnesses;

		public AmbulanceConfig.Type ValidAmbulanceType;

		public SharedInstance<AmbulanceConfig> DebugAmbulanceNormal;

		public SharedInstance<AmbulanceConfig> DebugAmbulanceSlow;

		public SharedInstance<AmbulanceConfig> DebugAmbulanceFast;

		public SharedInstance<AmbulanceEmergencyLocation> Location;

		public EmergencySeverityType SeverityType;

		public float SeveritySecondsPerDeath;

		public int SeverityDisplayValue;

		public int SeverityTicksBeforeFirstDeath = 1;

		public SirenCharacterComponentConfig SirenCharacterComponentConfig;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeAmbulanceEmergency(this, level);
		}

		public override string GetDescriptionString(Objective objective, IReward[] rewards)
		{
			return "Default Description";
		}
	}
}
