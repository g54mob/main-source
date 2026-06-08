using Unity.Entities;

namespace Kitchen
{
	public struct SGameTime : IComponentData
	{
		public float DeltaTime;

		public float TotalTime;

		public float RealDeltaTime;

		public float RealTotalTime;

		public float GameSpeed;

		public bool IsPaused;

		public static SGameTime New()
		{
			return new SGameTime
			{
				GameSpeed = 1f
			};
		}
	}
}
