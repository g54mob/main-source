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
			startDelay = 0f;
			this.useUniformTime = false;
			waveSize = 0f;
			timeSpeed = 0f;
			tempTime = 0f;
		}

		public float GetTime(float animatorTime, float charTime, int charIndex)
		{
			return 0f;
		}
	}
}
