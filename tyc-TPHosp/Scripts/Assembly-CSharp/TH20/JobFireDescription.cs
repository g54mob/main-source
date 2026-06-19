using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class JobFireDescription : JobDescription
	{
		public override Sprite GetIcon()
		{
			return null;
		}

		public override bool IsSuitable(Staff staff)
		{
			if (staff.Definition._type == StaffDefinition.Type.Janitor)
			{
				return !staff.Definition.IsUniqueVehicularMechanic;
			}
			return false;
		}

		public override bool MatchesJob(Job job)
		{
			return job is JobFire;
		}

		public override string ToString()
		{
			return ScriptLocalization.Tooltip.JobDescription_Fire_CS;
		}

		public override string ToLocalisedString()
		{
			return ScriptLocalization.Tooltip.JobDescription_Fire_CS;
		}

		public override bool Equals(JobDescription desc)
		{
			return desc is JobFireDescription;
		}
	}
}
