using System;

namespace AssetKits.ParticleImage
{
	[Serializable]
	public struct SpeedRange
	{
		public float from;

		public float to;

		public SpeedRange(float from, float to)
		{
			this.from = from;
			this.to = to;
		}
	}
}
