using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CorgiGodRays
{
	[Serializable]
	public class GodRaysVolume : VolumeComponent, IPostProcessComponent
	{
		public FloatParameter MainLightIntensity;

		public FloatParameter AdditionalLightsIntensity;

		public ClampedFloatParameter MainLightScattering;

		public ClampedFloatParameter AdditionalLightsScattering;

		public ColorParameter Tint;

		public bool IsActive()
		{
			return false;
		}

		public bool IsTileCompatible()
		{
			return false;
		}
	}
}
