using System;
using System.Collections.Generic;
using UnityEngine;

namespace AmplifyColor
{
	[Serializable]
	public class VolumeEffect
	{
		public AmplifyColorBase gameObject;

		public List<VolumeEffectComponent> components;

		public VolumeEffect(AmplifyColorBase effect)
		{
		}

		public static VolumeEffect BlendValuesToVolumeEffect(VolumeEffectFlags flags, VolumeEffect volume1, VolumeEffect volume2, float blend)
		{
			return null;
		}

		public VolumeEffectComponent AddComponent(Component c, VolumeEffectComponentFlags compFlags)
		{
			return null;
		}

		public void RemoveEffectComponent(VolumeEffectComponent comp)
		{
		}

		public void UpdateVolume()
		{
		}

		public void SetValues(AmplifyColorBase targetColor)
		{
		}

		public void BlendValues(AmplifyColorBase targetColor, VolumeEffect other, float blendAmount)
		{
		}

		public VolumeEffectComponent FindEffectComponent(string compName)
		{
			return null;
		}

		public static Component[] ListAcceptableComponents(AmplifyColorBase go)
		{
			return null;
		}

		public string[] GetComponentNames()
		{
			return null;
		}
	}
}
