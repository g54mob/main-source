using System;

namespace JSAM
{
	[Serializable]
	public struct AudioHighPassObj
	{
		public bool enabled;

		public float cutoffFrequency;

		public float highpassResonanceQ;
	}
}
