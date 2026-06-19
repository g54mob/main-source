using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class QualificationAmbulanceSpeedBoost : CharacterModifier
	{
		public float ScoreBoost;

		public AmbulanceConfig.Type Type;
	}
}
