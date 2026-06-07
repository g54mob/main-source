using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace VolFx
{
	[Serializable]
	[VolumeComponentMenu("VolFx/Dither")]
	public sealed class DitherVol : VolumeComponent, IPostProcessComponent
	{
		[Serializable]
		public class NoiseModeParameter : VolumeParameter<DitherPass.Mode>
		{
			public NoiseModeParameter(DitherPass.Mode value, bool overrideState)
				: base(value, overrideState)
			{
			}
		}

		[InspectorName("Weight")]
		[Tooltip("Full effects impact")]
		public ClampedFloatParameter m_Impact = new ClampedFloatParameter(0f, 0f, 1f);

		[Header("Main")]
		[Tooltip("Power of pattern distribution")]
		public ClampedFloatParameter m_Power = new ClampedFloatParameter(0f, 0f, 1f);

		[Tooltip("Image scale for dithering")]
		public ClampedFloatParameter m_Scale = new ClampedFloatParameter(1f, 0f, 1f);

		[Header("Settings")]
		[Tooltip("Pixelate image for dithering")]
		public BoolParameter m_Pixelate = new BoolParameter(value: true);

		[Tooltip("Fps of dither animation")]
		public ClampedIntParameter m_Fps = new ClampedIntParameter(0, 0, 120);

		[Tooltip("Dither palette")]
		public Texture2DParameter m_Palette = new Texture2DParameter(null);

		[Tooltip("Dither pattern")]
		public Texture2DParameter m_Pattern = new Texture2DParameter(null);

		[Tooltip("Dithering method")]
		public NoiseModeParameter m_Mode = new NoiseModeParameter(DitherPass.Mode.Dither, overrideState: false);

		[Header("Noise")]
		[InspectorName("Scale")]
		[Tooltip("Scale of a custom noise texture")]
		public NoInterpClampedFloatParameter m_NoiseScale = new NoInterpClampedFloatParameter(1f, 0f, 7f);

		[Tooltip("Custom noise texture")]
		public Texture2DParameter m_Noise = new Texture2DParameter(null);

		public bool IsActive()
		{
			if (active)
			{
				if (!(m_Scale.value < 1f) && !(m_Power.value > 0f))
				{
					return m_Impact.value > 0f;
				}
				return true;
			}
			return false;
		}

		public bool IsTileCompatible()
		{
			return false;
		}
	}
}
