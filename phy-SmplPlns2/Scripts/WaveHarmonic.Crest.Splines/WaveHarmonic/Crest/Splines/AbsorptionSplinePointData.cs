using UnityEngine;

namespace WaveHarmonic.Crest.Splines
{
	[AddComponentMenu("")]
	public sealed class AbsorptionSplinePointData : SplinePointData
	{
		[Tooltip("Whether to override the scattering color instead of just the weight.")]
		[SerializeField]
		private bool _OverrideAbsorption;

		[Tooltip("The scattering color.")]
		[SerializeField]
		private Color _AbsorptionColor = s_DefaultAbsorption;

		[Tooltip("The weight of the scattering color.")]
		[SerializeField]
		private float _Weight = 1f;

		private Vector4 _Absorption = WaterRenderer.UpdateAbsorptionFromColor(s_DefaultAbsorption);

		internal static readonly Color s_DefaultAbsorption = AbsorptionLod.s_DefaultColor;

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

		public bool OverrideAbsorption
		{
			get
			{
				return _OverrideAbsorption;
			}
			set
			{
				_OverrideAbsorption = value;
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

		internal override Vector4 GetData(Vector4 data)
		{
			data.w = _Weight;
			if (!_OverrideAbsorption)
			{
				return data;
			}
			return _Absorption;
		}

		private void SetAbsorptionColor(Color previous, Color current)
		{
			if (!(previous == current))
			{
				_Absorption = WaterRenderer.UpdateAbsorptionFromColor(current);
			}
		}

		private protected override void Initialize()
		{
			base.Initialize();
			_Absorption = WaterRenderer.UpdateAbsorptionFromColor(_AbsorptionColor);
		}
	}
}
