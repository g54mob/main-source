using Unity.Entities;

namespace Kitchen
{
	public struct STime : IComponentData
	{
		public float TimeOfDay;

		public float TimeOfDayUnbounded;

		public float SecondsSinceDayBegan;

		public float DayLength;

		public bool ForcePause;
	}
}
