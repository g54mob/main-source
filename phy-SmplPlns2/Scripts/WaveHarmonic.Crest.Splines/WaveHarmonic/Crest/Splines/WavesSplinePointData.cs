using UnityEngine;

namespace WaveHarmonic.Crest.Splines
{
	[AddComponentMenu("")]
	public sealed class WavesSplinePointData : SplinePointData
	{
		internal const float k_DefaultWeight = 1f;

		[Tooltip("Weight multiplier to scale waves.")]
		[SerializeField]
		private float _Weight = 1f;

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

		internal override Vector4 GetData(Vector4 _)
		{
			return new Vector4(_Weight, 0f, 0f, 0f);
		}
	}
}
