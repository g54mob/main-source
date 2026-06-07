using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Splines.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest.Splines
{
	[Serializable]
	[ForLodInput(typeof(ScatteringLodInput), LodInputMode.Spline)]
	public sealed class ScatteringSplineLodInputData : SplineLodInputData<ScatteringSplinePointData>
	{
		[Tooltip("The color of the scattering.")]
		[SerializeField]
		private Color _ScatteringColor = ScatteringSplinePointData.s_DefaultScattering;

		public Color ScatteringColor
		{
			get
			{
				return _ScatteringColor;
			}
			set
			{
				_ScatteringColor = value;
			}
		}

		private protected override Shader SplineShader => ScriptableSingleton<WaterResources>.Instance.Shaders._ColorSpline;

		private protected override Vector4 DefaultCustomSplineData => _ScatteringColor.MaybeLinear();
	}
}
