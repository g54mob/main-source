using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	[Serializable]
	[VolumeComponentMenu("HauntedPS1/CameraVolume")]
	public class CameraVolume : VolumeComponent
	{
		[Serializable]
		public enum CameraAspectMode
		{
			FreeStretch = 0,
			FreeFitPixelPerfect = 1,
			FreeCropPixelPerfect = 2,
			FreeBleedPixelPerfect = 3,
			LockedFitPixelPerfect = 4,
			LockedFit = 5,
			Native = 6
		}

		[Serializable]
		public sealed class CameraAspectModeParameter : VolumeParameter<CameraAspectMode>
		{
			public CameraAspectModeParameter(CameraAspectMode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		public BoolParameter isFrameLimitEnabled = new BoolParameter(value: false);

		public MinIntParameter frameLimit = new MinIntParameter(24, 1);

		public CameraAspectModeParameter aspectMode = new CameraAspectModeParameter(CameraAspectMode.FreeBleedPixelPerfect);

		public ClampedIntParameter targetRasterizationResolutionWidth = new ClampedIntParameter(256, 1, 4096);

		public ClampedIntParameter targetRasterizationResolutionHeight = new ClampedIntParameter(224, 1, 4096);

		public BoolParameter isDepthBufferEnabled = new BoolParameter(value: true);

		public BoolParameter isClearDepthAfterBackgroundEnabled = new BoolParameter(value: true);

		public BoolParameter isClearDepthBeforeUIEnabled = new BoolParameter(value: true);

		private static CameraVolume s_Default;

		public static CameraVolume @default
		{
			get
			{
				if (s_Default == null)
				{
					s_Default = ScriptableObject.CreateInstance<CameraVolume>();
					s_Default.hideFlags = HideFlags.HideAndDontSave;
				}
				return s_Default;
			}
		}
	}
}
