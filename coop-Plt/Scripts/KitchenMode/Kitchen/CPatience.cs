using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CPatience : IComponentData
	{
		public float StartTime;

		public float RemainingTime;

		public bool Active;

		public PatienceReason Reason;

		public DisplayedPatienceFactor Factors;

		public float LastUpdateRate;

		public CPatience(PatienceReason reason, float time, float total_time = -1f)
		{
			if (total_time < 0f)
			{
				total_time = time;
			}
			Active = time > 0f;
			if (Active)
			{
				StartTime = total_time;
				RemainingTime = time;
			}
			else
			{
				StartTime = 1f;
				RemainingTime = 1f;
			}
			Reason = reason;
			LastUpdateRate = 0f;
			Factors = DisplayedPatienceFactor.None;
		}

		public CPatience(PatienceReason reason)
		{
			Reason = reason;
			Active = false;
			StartTime = 1f;
			RemainingTime = 1f;
			LastUpdateRate = 0f;
			Factors = DisplayedPatienceFactor.None;
		}

		public void ResetTime()
		{
			RemainingTime = StartTime;
		}
	}
}
