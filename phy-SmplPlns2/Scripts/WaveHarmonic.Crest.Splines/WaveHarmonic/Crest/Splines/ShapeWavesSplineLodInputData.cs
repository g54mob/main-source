using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using WaveHarmonic.Crest.Splines.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest.Splines
{
	[Serializable]
	[MovedFrom(false, "WaveHarmonic.Crest.Spline", "WaveHarmonic.Crest.Spline", null)]
	[ForLodInput(typeof(ShapeWaves), LodInputMode.Spline)]
	public sealed class ShapeWavesSplineLodInputData : SplineLodInputData<WavesSplinePointData>
	{
		private static class ShaderIDs
		{
			public static readonly int s_FeatherWaveStart = Shader.PropertyToID("_Crest_FeatherWaveStart");
		}

		[Tooltip("Weight multiplier to scale waves.")]
		[SerializeField]
		private float _Weight = 1f;

		[Tooltip("Feathers waves across the spline (ie across width). Reverse the spline to swap direction.")]
		[SerializeField]
		private float _FeatherWaveStart = 0.1f;

		public float FeatherWaveStart
		{
			get
			{
				return _FeatherWaveStart;
			}
			set
			{
				_FeatherWaveStart = value;
			}
		}

		public float Weight
		{
			get
			{
				return _Weight;
			}
			set
			{
				_Weight = value;
			}
		}

		private protected override Shader SplineShader => ScriptableSingleton<WaterResources>.Instance.Shaders._WaveSpline;

		private protected override Vector4 DefaultCustomSplineData => new Vector4(_Weight, 0f, 0f, 0f);

		internal override void OnUpdate()
		{
			base.OnUpdate();
			if (!(_Material == null))
			{
				_Material.SetFloat(ShaderIDs.s_FeatherWaveStart, _FeatherWaveStart);
			}
		}
	}
}
