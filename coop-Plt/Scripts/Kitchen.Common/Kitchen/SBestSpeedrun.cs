using Unity.Entities;

namespace Kitchen
{
	public struct SBestSpeedrun : IComponentData
	{
		public int Year;

		public int Week;

		public int DurationMilliseconds;

		public float Percentile;
	}
}
