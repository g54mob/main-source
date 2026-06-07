using UnityEngine;

namespace WaveHarmonic.Crest.Splines
{
	[AddComponentMenu("")]
	public sealed class FoamSplinePointData : SplinePointData
	{
		internal const float k_DefaultAmount = 1f;

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

		internal override Vector4 GetData(Vector4 _)
		{
			return new Vector4(_FoamAmount, 0f, 0f, 0f);
		}
	}
}
