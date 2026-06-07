namespace Gh.Tk
{
	public class StaffWorkHoursExpectation : StaffExpectationBase
	{
		public static float GracePeriodInHours;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _maxWorkHoursOverride;

		public int MaxWorkHoursOverride
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected StaffWorkHoursExpectation()
		{
		}

		public StaffWorkHoursExpectation(Staff owner)
		{
		}

		private void InvalidateDescription()
		{
		}

		public int GetMaxWorkHoursPerDay()
		{
			return 0;
		}

		protected override void UpdateInternal()
		{
		}
	}
}
