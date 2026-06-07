using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	[Serializable]
	[VolumeComponentMenu("HauntedPS1/FogVolume")]
	public class FogVolume : VolumeComponent
	{
		[Serializable]
		public enum FogFalloffMode
		{
			Planar = 0,
			Cylindrical = 1,
			Spherical = 2
		}

		[Serializable]
		public sealed class FogFalloffModeParameter : VolumeParameter<FogFalloffMode>
		{
			public FogFalloffModeParameter(FogFalloffMode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public enum FogBlendMode
		{
			Over = 0,
			Additive = 1,
			Subtractive = 2,
			Multiply = 3
		}

		[Serializable]
		public sealed class FogBlendModeParameter : VolumeParameter<FogBlendMode>
		{
			public FogBlendModeParameter(FogBlendMode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public enum FogColorLUTMode
		{
			Disabled = 0,
			Texture2DDistanceAndHeight = 1,
			TextureCube = 2
		}

		[Serializable]
		public sealed class FogColorLUTModeParameter : VolumeParameter<FogColorLUTMode>
		{
			public FogColorLUTModeParameter(FogColorLUTMode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		public BoolParameter isEnabled = new BoolParameter(value: true);

		public FogFalloffModeParameter fogFalloffMode = new FogFalloffModeParameter(FogFalloffMode.Planar);

		public FogBlendModeParameter blendMode = new FogBlendModeParameter(FogBlendMode.Over);

		public ColorParameter color = new ColorParameter(new Color(0.5f, 0.5f, 0.5f, 1f));

		public FloatParameter precisionAlpha = new ClampedFloatParameter(1f, 0f, 1f);

		public TextureParameter precisionAlphaDitherTexture = new TextureParameter(null);

		public ClampedFloatParameter precisionAlphaDither = new ClampedFloatParameter(1f, 0f, 1f);

		public MinFloatParameter distanceMin = new MinFloatParameter(0f, 0f);

		public MinFloatParameter distanceMax = new MinFloatParameter(100f, 1E-05f);

		public ClampedFloatParameter fogFalloffCurve = new ClampedFloatParameter(0f, -1f, 1f);

		public BoolParameter heightFalloffEnabled = new BoolParameter(value: false);

		public BoolParameter heightFalloffMirrored = new BoolParameter(value: false);

		public FloatParameter heightMin = new FloatParameter(0f);

		public FloatParameter heightMax = new FloatParameter(10f);

		public FogColorLUTModeParameter colorLUTMode = new FogColorLUTModeParameter(FogColorLUTMode.Disabled);

		public TextureParameter colorLUTTexture = new TextureParameter(null);

		public Vector3Parameter colorLUTRotationDegrees = new Vector3Parameter(Vector3.zero);

		public ClampedFloatParameter colorLUTWeight = new ClampedFloatParameter(1f, 0f, 1f);

		public ClampedFloatParameter colorLUTWeightLayer1 = new ClampedFloatParameter(0f, 0f, 1f);

		public BoolParameter isAdditionalLayerEnabled = new BoolParameter(value: false);

		public FogFalloffModeParameter fogFalloffModeLayer1 = new FogFalloffModeParameter(FogFalloffMode.Planar);

		public ColorParameter colorLayer1 = new ColorParameter(new Color(0.5f, 0.5f, 0.5f, 1f));

		public MinFloatParameter distanceMinLayer1 = new MinFloatParameter(0f, 0f);

		public MinFloatParameter distanceMaxLayer1 = new MinFloatParameter(100f, 1E-05f);

		public ClampedFloatParameter fogFalloffCurveLayer1 = new ClampedFloatParameter(0f, -1f, 1f);

		public BoolParameter heightFalloffEnabledLayer1 = new BoolParameter(value: false);

		public BoolParameter heightFalloffMirroredLayer1 = new BoolParameter(value: false);

		public FloatParameter heightMinLayer1 = new FloatParameter(0f);

		public FloatParameter heightMaxLayer1 = new FloatParameter(10f);

		private static FogVolume s_Default;

		public static FogVolume @default
		{
			get
			{
				if (s_Default == null)
				{
					s_Default = ScriptableObject.CreateInstance<FogVolume>();
					s_Default.hideFlags = HideFlags.HideAndDontSave;
				}
				return s_Default;
			}
		}
	}
}
