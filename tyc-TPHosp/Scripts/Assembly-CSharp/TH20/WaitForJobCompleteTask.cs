namespace TH20
{
	public class WaitForJobCompleteTask
	{
		private Job _job;

		private Room _room;

		private Staff _staff;

		public Room Room => _room;

		public Job Job => _job;

		public Staff Staff => _staff;

		public WaitForJobCompleteTask(Staff staff, Job job, Room room)
		{
			_staff = staff;
			_job = job;
			_room = room;
		}

		public bool Update()
		{
			Staff staff = _job.GetStaff();
			if (staff == null || _job.CanLeave())
			{
				if (staff != null)
				{
					_job.MakeAvailable();
					_room.StaffLeaveRoom(staff);
					staff.Idle();
				}
				if (_job.StartFromStaffDrop(_staff))
				{
					_job.AssignStaff(_staff, _room);
				}
				return true;
			}
			return false;
		}

		public void ReplaceStaff(Staff staff)
		{
			if (_staff != staff)
			{
				_room.StaffLeaveRoom(_staff);
				_staff.Idle();
				_staff = staff;
			}
		}
	}
}
