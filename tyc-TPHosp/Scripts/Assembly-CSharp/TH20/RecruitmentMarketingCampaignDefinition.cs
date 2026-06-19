using FullInspector;
using UnityEngine;

namespace TH20
{
	public class RecruitmentMarketingCampaignDefinition : MarketingCampaignDefinition
	{
		[SerializeField]
		private StaffDefinition.Type StaffPoolType;

		public float StaffPoolTimeMultiplier;

		public SharedInstance<QualificationDefinition> Qualification;

		public float QualificationWeightMultiplier;

		public override void Apply(float multiplier, MarketingManager marketingManager)
		{
		}

		public StaffDefinition.Type GetStaffType()
		{
			if (Qualification != null && Qualification.Instance != null && Qualification.Instance.StaffType != StaffDefinition.Type.None)
			{
				return Qualification.Instance.StaffType;
			}
			return StaffPoolType;
		}
	}
}
