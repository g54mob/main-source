namespace TH20
{
	public class AmbulanceStaffAssignment
	{
		public Staff StaffAssigned;

		public bool IsAboard;

		public JobAmbulance JobAssignment;

		public AmbulanceStaffAssignment(Staff staff, bool isAboard, JobAmbulance jobAssignment)
		{
			StaffAssigned = staff;
			IsAboard = isAboard;
			JobAssignment = jobAssignment;
		}
	}
}
