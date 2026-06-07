using System;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class VegetationRenderSettings
	{
		public bool DisableInstancedIndirectWindows;

		public bool DisableInstncedIndirectOsx;

		public bool DisableInstancedIndirectLinux;

		public bool DisableInstancedIndirectIos;

		public bool DisableInstancedIndirectAndroid;

		public bool DisableInstancedIndirectTvOs;

		public bool DisableInstancedIndirectXboxOne;

		public bool DisableInstancedIndirectPs4;

		public bool DisableInstancedIndirectWsa;

		public bool EnableInstancedRenderingLayers = true;

		public bool EnableSinglePassInstancedVR;

		public int RenderingLayerMask = 255;

		public float CrossFadeDistance = 10f;

		public bool ShowLODDebug;

		public bool UseInstancedIndirect()
		{
			if (!Application.isPlaying)
			{
				return false;
			}
			switch (Application.platform)
			{
			case RuntimePlatform.WindowsEditor:
				return !DisableInstancedIndirectWindows;
			case RuntimePlatform.WindowsPlayer:
				return !DisableInstancedIndirectWindows;
			case RuntimePlatform.OSXEditor:
				return !DisableInstncedIndirectOsx;
			case RuntimePlatform.OSXPlayer:
				return !DisableInstncedIndirectOsx;
			case RuntimePlatform.LinuxEditor:
				return !DisableInstancedIndirectLinux;
			case RuntimePlatform.LinuxPlayer:
				return !DisableInstancedIndirectLinux;
			case RuntimePlatform.IPhonePlayer:
				return !DisableInstancedIndirectIos;
			case RuntimePlatform.Android:
				return !DisableInstancedIndirectAndroid;
			case RuntimePlatform.tvOS:
				return !DisableInstancedIndirectTvOs;
			case RuntimePlatform.XboxOne:
				return !DisableInstancedIndirectXboxOne;
			case RuntimePlatform.PS4:
				return !DisableInstancedIndirectPs4;
			case RuntimePlatform.MetroPlayerX64:
				return !DisableInstancedIndirectWsa;
			case RuntimePlatform.MetroPlayerX86:
				return !DisableInstancedIndirectWsa;
			case RuntimePlatform.MetroPlayerARM:
				return !DisableInstancedIndirectWsa;
			default:
				return false;
			}
		}
	}
}
