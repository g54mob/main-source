using System;

namespace Febucci.TextAnimatorCore.Time
{
	[Serializable]
	public struct TimeData
	{
		public float timeSinceStart { get; private set; }

		public float deltaTime { get; private set; }

		public void RestartTime()
		{
			timeSinceStart = 0f;
		}

		internal void IncreaseTime()
		{
			timeSinceStart += deltaTime;
		}

		internal void UpdateDeltaTime(float deltaTime)
		{
			this.deltaTime = deltaTime;
			if (deltaTime < 0f)
			{
				deltaTime = 0f;
			}
		}
	}
}
