using System;

namespace JSAM
{
	[Serializable]
	public struct AudioEchoObj
	{
		public bool enabled;

		public float delay;

		public float decayRatio;

		public float wetMix;

		public float dryMix;
	}
}
