namespace TH20
{
	public struct TreatmentCalculationBreakdown
	{
		public float MinChanceOfSuccess;

		public float ChanceOfSuccess;

		public float DiagnosisCertainty;

		public float StaffSkill;

		public float RoomModifiers;

		public float MinTreatmentEffectiveness;

		public float MaxTreatmentEffectiveness;

		public float IllnessDifficulty => 100f - MinTreatmentEffectiveness;

		public float StaffSkillPercent => (StaffSkill - GameAlgorithms.Config.TreatmentStaffSkillMin) / (GameAlgorithms.Config.TreatmentStaffSkillMax - GameAlgorithms.Config.TreatmentStaffSkillMin);

		public float RoomModifiersPercent => (RoomModifiers - GameAlgorithms.Config.TreatmentUpgradesFactorMin) / (GameAlgorithms.Config.TreatmentUpgradesFactorMax - GameAlgorithms.Config.TreatmentUpgradesFactorMin);
	}
}
