namespace DistantLands.Cozy
{
	public abstract class CozyDateOverride : CozyModule
	{
		public float yearPercentage;

		public abstract float GetCurrentYearPercentage();

		public abstract float GetCurrentYearPercentage(float inTicks);

		public abstract float DayAndTime();

		public abstract void ChangeDay(int days);

		public abstract int DaysPerYear();
	}
}
