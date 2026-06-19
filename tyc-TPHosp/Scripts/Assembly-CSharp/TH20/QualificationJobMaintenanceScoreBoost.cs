using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class QualificationJobMaintenanceScoreBoost : CharacterModifier
	{
		public JobMaintenance.JobDescription MaintenanceType;

		public float ScoreBoost;
	}
}
