using System;

namespace AssetKits.ParticleImage
{
	[Serializable]
	public struct Module
	{
		public bool enabled;

		public Module(bool enabled)
		{
			this.enabled = enabled;
		}
	}
}
