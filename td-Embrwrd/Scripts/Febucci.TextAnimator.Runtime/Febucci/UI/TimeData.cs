using System;

namespace Febucci.UI
{
	[Serializable]
	public struct TimeData
	{
		public float timeSinceStart { get; private set; }

		public float deltaTime { get; private set; }

		public void RestartTime()
		{
		}

		internal void IncreaseTime()
		{
		}

		internal void UpdateDeltaTime(float deltaTime)
		{
		}
	}
}
