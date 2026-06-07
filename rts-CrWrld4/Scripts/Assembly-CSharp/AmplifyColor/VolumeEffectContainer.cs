using System;
using System.Collections.Generic;

namespace AmplifyColor
{
	[Serializable]
	public class VolumeEffectContainer
	{
		public List<VolumeEffect> volumes;

		public void AddColorEffect(AmplifyColorBase colorEffect)
		{
		}

		public VolumeEffect AddJustColorEffect(AmplifyColorBase colorEffect)
		{
			return null;
		}

		public VolumeEffect FindVolumeEffect(AmplifyColorBase colorEffect)
		{
			return null;
		}

		public void RemoveVolumeEffect(VolumeEffect volume)
		{
		}

		public AmplifyColorBase[] GetStoredEffects()
		{
			return null;
		}
	}
}
