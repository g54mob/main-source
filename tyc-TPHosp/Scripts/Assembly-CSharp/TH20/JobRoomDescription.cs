using UnityEngine;

namespace TH20
{
	public class JobRoomDescription : JobDescription
	{
		public RoomDefinition Room;

		public StaffRequired StaffRequired;

		public override Sprite GetIcon()
		{
			return Room._jobAssignmentIcon;
		}

		public override bool IsSuitable(Staff staff)
		{
			return StaffRequired.IsSuitable(staff);
		}

		public override bool MatchesJob(Job job)
		{
			if (job is JobRoom jobRoom && StaffRequired.Equals(jobRoom.StaffRequired()))
			{
				return jobRoom.Room.Definition == Room;
			}
			return false;
		}

		public override string ToString()
		{
			return Room.ToString();
		}

		public override string ToLocalisedString()
		{
			return Room.ToLocalisedString();
		}

		public override string GetJobAssignmentTooltipString()
		{
			return Room.ToLocalisedString();
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
			if (!(desc is JobRoomDescription jobRoomDescription))
			{
				return false;
			}
			if (Room != jobRoomDescription.Room)
			{
				return false;
			}
			if (StaffRequired.Definition != jobRoomDescription.StaffRequired.Definition)
			{
				return false;
			}
			if (StaffRequired.QualificationInstance != jobRoomDescription.StaffRequired.QualificationInstance)
			{
				return false;
			}
			return true;
		}
	}
}
