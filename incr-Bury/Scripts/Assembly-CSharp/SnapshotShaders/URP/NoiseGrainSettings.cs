using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Noise Grain")]
	public sealed class NoiseGrainSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("How strongly the screen colors get lightened by noise.")]
		public FloatParameter strength = new FloatParameter(0f);

		[Tooltip("How fast the noise grain changes values.")]
		public FloatParameter speed = new FloatParameter(1f);

		[Tooltip("The size of the noise texture that gets applied to the screen.")]
		public FloatParameter noiseSize = new FloatParameter(1f);

		[Tooltip("Hermite interpolation is faster, while Quintic interpolation will look very slightly nicer.")]
		public NoiseInterpParameter noiseInterpolation = new NoiseInterpParameter(NoiseInterpolation.Quintic);

		public NoiseGrainSettings()
		{
			base.displayName = "Noise Grain";
		}

		public bool IsActive()
		{
			if (strength.value > 0f)
			{
				return active;
			}
			return false;
		}

		public bool IsTileCompatible()
		{
			return false;
		}
	}
}
