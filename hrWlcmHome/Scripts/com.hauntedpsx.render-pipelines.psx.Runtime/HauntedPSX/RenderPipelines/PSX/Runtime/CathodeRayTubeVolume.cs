using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	[Serializable]
	[VolumeComponentMenu("HauntedPS1/Cathode Ray Tube")]
	public class CathodeRayTubeVolume : VolumeComponent
	{
		[Serializable]
		public enum CRTGrateMaskMode
		{
			CompressedTV = 0,
			ApertureGrill = 1,
			VGA = 2,
			VGAStretched = 3,
			Texture = 4,
			Disabled = 5
		}

		[Serializable]
		public sealed class CRTGrateMaskModeParameter : VolumeParameter<CRTGrateMaskMode>
		{
			public CRTGrateMaskModeParameter(CRTGrateMaskMode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		public BoolParameter isEnabled = new BoolParameter(value: true);

		public ClampedFloatParameter bloom = new ClampedFloatParameter(0.0625f, 0f, 1f);

		public CRTGrateMaskModeParameter grateMaskMode = new CRTGrateMaskModeParameter(CRTGrateMaskMode.CompressedTV);

		public TextureParameter grateMaskTexture = new TextureParameter(null);

		public FloatParameter grateMaskScale = new FloatParameter(1f);

		public ClampedFloatParameter scanlineSharpness = new ClampedFloatParameter(0.5f, 0f, 1f);

		public ClampedFloatParameter imageSharpness = new ClampedFloatParameter(0.5f, 0f, 1f);

		public ClampedFloatParameter bloomSharpnessX = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter bloomSharpnessY = new ClampedFloatParameter(0f, 0f, 1f);

		public ClampedFloatParameter noiseIntensity = new ClampedFloatParameter(0.1f, 0f, 1f);

		public ClampedFloatParameter noiseSaturation = new ClampedFloatParameter(1f, 0f, 1f);

		public ClampedFloatParameter grateMaskIntensityMin = new ClampedFloatParameter(0.25f, 0f, 1f);

		public ClampedFloatParameter grateMaskIntensityMax = new ClampedFloatParameter(0.75f, 0f, 1f);

		public ClampedFloatParameter barrelDistortionX = new ClampedFloatParameter(0.125f, 0f, 1f);

		public ClampedFloatParameter barrelDistortionY = new ClampedFloatParameter(1f / 3f, 0f, 1f);

		public ClampedFloatParameter vignette = new ClampedFloatParameter(0.5f, 0f, 1f);

		private static CathodeRayTubeVolume s_Default;

		public static CathodeRayTubeVolume @default
		{
			get
			{
				if (s_Default == null)
				{
					s_Default = ScriptableObject.CreateInstance<CathodeRayTubeVolume>();
					s_Default.hideFlags = HideFlags.HideAndDontSave;
				}
				return s_Default;
			}
		}
	}
}
