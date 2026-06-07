using System;
using UnityEngine;
using WaveHarmonic.Crest.Splines.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest.Splines
{
	[Serializable]
	[ForLodInput(typeof(AbsorptionLodInput), LodInputMode.Spline)]
	public sealed class AbsorptionSplineLodInputData : SplineLodInputData<AbsorptionSplinePointData>
	{
		[Tooltip("The color of water due to absorption.")]
		[SerializeField]
		private Color _AbsorptionColor = AbsorptionSplinePointData.s_DefaultAbsorption;

		private Vector4 _Absorption = WaterRenderer.UpdateAbsorptionFromColor(AbsorptionSplinePointData.s_DefaultAbsorption);

		public Color AbsorptionColor
		{
			get
			{
				return _AbsorptionColor;
			}
			set
			{
				SetAbsorptionColor(_AbsorptionColor, _AbsorptionColor = value);
			}
		}

		private protected override Shader SplineShader => ScriptableSingleton<WaterResources>.Instance.Shaders._ColorSpline;

		private protected override Vector4 DefaultCustomSplineData => _Absorption;

		private void SetAbsorptionColor(Color previous, Color current)
		{
			if (!(previous == current))
			{
				_Absorption = WaterRenderer.UpdateAbsorptionFromColor(current);
			}
		}

		internal override void OnEnable()
		{
			_Absorption = WaterRenderer.UpdateAbsorptionFromColor(_AbsorptionColor);
			base.OnEnable();
		}
	}
}
