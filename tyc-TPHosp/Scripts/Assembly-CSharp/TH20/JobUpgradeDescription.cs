using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class JobUpgradeDescription : JobDescription
	{
		public override Sprite GetIcon()
		{
			return null;
		}

		public override bool IsSuitable(Staff staff)
		{
			if (staff.Definition._type == StaffDefinition.Type.Janitor)
			{
				return staff.HasCompletedQualification(GameAlgorithms.Config.UpgradeQualification.Instance);
			}
			return false;
		}

		public override bool MatchesJob(Job job)
		{
			return job is JobUpgrade;
		}

		public override string ToString()
		{
			return ScriptLocalization.Tooltip.JobDescription_Upgrade_CS;
		}

		public override string ToLocalisedString()
		{
			return ScriptLocalization.Tooltip.JobDescription_Upgrade_CS;
		}

		public override string RequiredQualificationString()
		{
			if (!GameAlgorithms.Config.UpgradeQualification.NotNull())
			{
				return string.Empty;
			}
			return GameAlgorithms.Config.UpgradeQualification.Instance.NameLocalised.Translation;
		}

		public override bool Equals(JobDescription desc)
		{
			return desc is JobUpgradeDescription;
		}
	}
}
