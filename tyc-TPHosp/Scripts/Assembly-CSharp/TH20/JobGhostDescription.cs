using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class JobGhostDescription : JobDescription
	{
		public override Sprite GetIcon()
		{
			return null;
		}

		public override bool IsSuitable(Staff staff)
		{
			if (staff.Definition._type == StaffDefinition.Type.Janitor)
			{
				return staff.HasCompletedQualification(GameAlgorithms.Config.GhostCaptureQualification.Instance);
			}
			return false;
		}

		public override bool MatchesJob(Job job)
		{
			return job is JobGhost;
		}

		public override string ToString()
		{
			return ScriptLocalization.Tooltip.JobDescription_Ghost_CS;
		}

		public override string ToLocalisedString()
		{
			return ScriptLocalization.Tooltip.JobDescription_Ghost_CS;
		}

		public override string RequiredQualificationString()
		{
			if (!GameAlgorithms.Config.GhostCaptureQualification.NotNull())
			{
				return string.Empty;
			}
			return GameAlgorithms.Config.GhostCaptureQualification.Instance.NameLocalised.Translation;
		}

		public override bool Equals(JobDescription desc)
		{
			return desc is JobGhostDescription;
		}
	}
}
