using System;

namespace JSAM
{
	[Serializable]
	public struct AudioChorusObj
	{
		public bool enabled;

		public float dryMix;

		public float wetMix1;

		public float wetMix2;

		public float wetMix3;

		public float delay;

		public float rate;

		public float depth;
	}
}
