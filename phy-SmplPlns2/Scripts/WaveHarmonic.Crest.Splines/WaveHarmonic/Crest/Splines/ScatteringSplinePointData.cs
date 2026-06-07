using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Splines
{
	[AddComponentMenu("")]
	public sealed class ScatteringSplinePointData : SplinePointData
	{
		[Tooltip("Whether to override the scattering color instead of just the weight.")]
		[SerializeField]
		private bool _OverrideScattering;

		[Tooltip("The scattering color.")]
		[SerializeField]
		private Color _Scattering = s_DefaultScattering;

		[Tooltip("The weight of the scattering color.")]
		[SerializeField]
		private float _Weight = 1f;

		internal static readonly Color s_DefaultScattering = ScatteringLod.s_DefaultColor;

		public bool OverrideScattering
		{
			get
			{
				return _OverrideScattering;
			}
			set
			{
				_OverrideScattering = value;
			}
		}

		public Color Scattering
		{
			get
			{
				return _Scattering;
			}
			set
			{
				_Scattering = value;
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
			if (!_OverrideScattering)
			{
				return data;
			}
			return _Scattering.MaybeLinear();
		}
	}
}
