using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	[VolumeComponentMenu("Snapshot Shaders Pro/Underwater")]
	public sealed class UnderwaterSettings : VolumeComponent, IPostProcessComponent
	{
		[Tooltip("Choose where to insert this pass in URP's render loop.")]
		public RenderPassEventParameter renderPassEvent = new RenderPassEventParameter(RenderPassEvent.BeforeRenderingPostProcessing);

		[Tooltip("Displacement texture for surface waves.")]
		public TextureParameter bumpMap = new TextureParameter(null);

		[Range(0f, 10f)]
		[Tooltip("Strength/size of the waves.")]
		public ClampedFloatParameter strength = new ClampedFloatParameter(0f, 0f, 10f);

		[Tooltip("Tint of the underwater fog.")]
		public ColorParameter waterFogColor = new ColorParameter(Color.white);

		[Range(0f, 1f)]
		[Tooltip("Strength of the underwater fog.")]
		public ClampedFloatParameter fogStrength = new ClampedFloatParameter(0f, 0f, 1f);

		[Tooltip("")]
		public BoolParameter useCaustics = new BoolParameter(value: false);

		[Tooltip("")]
		public TextureParameter causticsTexture = new TextureParameter(null);

		public ClampedFloatParameter causticsNoiseSpeed = new ClampedFloatParameter(1f, 0f, 10f);

		public ClampedFloatParameter causticsNoiseScale = new ClampedFloatParameter(1f, 0f, 10f);

		public ClampedFloatParameter causticsNoiseStrength = new ClampedFloatParameter(1f, 0f, 1f);

		public Vector3Parameter causticsScrollVelocity1 = new Vector3Parameter(new Vector3(0.75f, 0.25f, 0f));

		public Vector3Parameter causticsScrollVelocity2 = new Vector3Parameter(new Vector3(0.75f, 0.25f, 0f));

		public Vector2Parameter causticsTiling = new Vector2Parameter(Vector2.one);

		public ColorParameter causticsTint = new ColorParameter(Color.white, hdr: true, showAlpha: true, showEyeDropper: true);

		public UnderwaterSettings()
		{
			base.displayName = "Underwater";
		}

		public bool IsActive()
		{
			if (strength.value > 0f || fogStrength.value > 0f)
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
