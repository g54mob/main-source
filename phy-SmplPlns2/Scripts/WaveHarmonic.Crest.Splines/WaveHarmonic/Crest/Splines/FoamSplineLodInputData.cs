using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using WaveHarmonic.Crest.Splines.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest.Splines
{
	[Serializable]
	[MovedFrom(false, "WaveHarmonic.Crest.Spline", "WaveHarmonic.Crest.Spline", null)]
	[ForLodInput(typeof(FoamLodInput), LodInputMode.Spline)]
	public sealed class FoamSplineLodInputData : SplineLodInputData<FoamSplinePointData>
	{
		[Tooltip("Amount of foam emitted.")]
		[SerializeField]
		private float _FoamAmount = 1f;

		public float FoamAmount
		{
			get
			{
				return _FoamAmount;
			}
			set
			{
				_FoamAmount = value;
			}
		}

		private protected override Shader SplineShader => ScriptableSingleton<WaterResources>.Instance.Shaders._FoamSpline;

		private protected override Vector4 DefaultCustomSplineData => new Vector4(_FoamAmount, 0f, 0f, 0f);
	}
}
