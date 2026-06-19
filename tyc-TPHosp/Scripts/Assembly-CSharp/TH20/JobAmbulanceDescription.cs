using UnityEngine;

namespace TH20
{
	public class JobAmbulanceDescription : JobDescription
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
			if (job is JobAmbulance jobAmbulance)
			{
				return jobAmbulance.Ambulance.AmbulanceItem.Definition == ItemDefinition;
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
			if (!(desc is JobAmbulanceDescription jobAmbulanceDescription))
			{
				return false;
			}
			if (ItemDefinition != jobAmbulanceDescription.ItemDefinition)
			{
				return false;
			}
			if (StaffRequired.Definition != jobAmbulanceDescription.StaffRequired.Definition)
			{
				return false;
			}
			if (StaffRequired.QualificationInstance != jobAmbulanceDescription.StaffRequired.QualificationInstance)
			{
				return false;
			}
			return true;
		}
	}
}
