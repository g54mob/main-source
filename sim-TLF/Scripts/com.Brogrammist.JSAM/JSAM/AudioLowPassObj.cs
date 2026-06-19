using System;

namespace JSAM
{
	[Serializable]
	public struct AudioLowPassObj
	{
		public bool enabled;

		public float cutoffFrequency;

		public float lowpassResonanceQ;
	}
}
