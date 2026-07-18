using System;

namespace AssetKits.ParticleImage
{
	[Serializable]
	public class Burst
	{
		public float time;

		public int count = 1;

		public bool used;

		public Burst(float time, int count)
		{
			this.time = time;
			this.count = count;
		}
	}
}
