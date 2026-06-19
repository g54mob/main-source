using UnityEngine;

namespace TH20
{
	public class JobItemDescription : JobDescription
	{
		public IRoomItemDefinition ItemDefinition;

		public StaffRequired StaffRequired;

		public override Sprite GetIcon()
		{
			return ItemDefinition.GetIcon();
		}

		public override Sprite GetJobAssignmentIcon()
		{
			return ItemDefinition.GetJobAssignmentIcon();
		}

		public override bool IsSuitable(Staff staff)
		{
			return StaffRequired.IsSuitable(staff);
		}

		public override bool MatchesJob(Job job)
		{
			if (job is JobService jobService)
			{
				return jobService.RoomItemDefinition == ItemDefinition;
			}
			return false;
		}

		public override string ToLocalisedString()
		{
			return ItemDefinition.GetLocalisedName();
		}

		public override string ToString()
		{
			return ItemDefinition.GetName();
		}

		public override string RequiredQualificationString()
		{
			if (StaffRequired.QualificationInstance == null)
			{
				return string.Empty;
			}
			return StaffRequired.QualificationInstance.NameLocalised.Translation;
		}

		public override bool Equals(JobDescription desc)
		{
			if (!(desc is JobItemDescription jobItemDescription))
			{
				return false;
			}
			if (ItemDefinition != jobItemDescription.ItemDefinition)
			{
				return false;
			}
			if (StaffRequired.Definition != jobItemDescription.StaffRequired.Definition)
			{
				return false;
			}
			if (StaffRequired.QualificationInstance != jobItemDescription.StaffRequired.QualificationInstance)
			{
				return false;
			}
			return true;
		}
	}
}
