using System;

namespace Febucci.UI.Effects
{
	[Serializable]
	public struct TimeMode
	{
		public float startDelay;

		public bool useUniformTime;

		public float waveSize;

		public float timeSpeed;

		private float tempTime;

		public TimeMode(bool useUniformTime)
		{
			this.useUniformTime = useUniformTime;
			waveSize = 0f;
			timeSpeed = 1f;
			startDelay = 0f;
			tempTime = 0f;
		}

		public float GetTime(float animatorTime, float charTime, int charIndex)
		{
			tempTime = ((useUniformTime ? animatorTime : charTime) - startDelay) * timeSpeed - waveSize * (float)charIndex;
			if (tempTime < startDelay)
			{
				return -1f;
			}
			return tempTime;
		}
	}
}
