using System;
using System.Collections.Generic;
using UnityEngine;

namespace AmplifyColor
{
	[Serializable]
	public class VolumeEffectFlags
	{
		public List<VolumeEffectComponentFlags> components;

		public void AddComponent(Component c)
		{
		}

		public void UpdateFlags(VolumeEffect effectVol)
		{
		}

		public static void UpdateCamFlags(AmplifyColorBase[] effects, AmplifyColorVolumeBase[] volumes)
		{
		}

		public VolumeEffect GenerateEffectData(AmplifyColorBase go)
		{
			return null;
		}

		public VolumeEffectComponentFlags FindComponentFlags(string compName)
		{
			return null;
		}

		public string[] GetComponentNames()
		{
			return null;
		}
	}
}
