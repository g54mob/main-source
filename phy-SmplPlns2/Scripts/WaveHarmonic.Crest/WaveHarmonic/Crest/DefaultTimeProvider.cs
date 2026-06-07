using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal sealed class DefaultTimeProvider : ITimeProvider
	{
		public float Time => UnityEngine.Time.time;

		public float Delta => UnityEngine.Time.deltaTime;
	}
}
