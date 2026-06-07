using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Splines
{
	[AddComponentMenu("Crest/Spline/Crest Spline Point")]
	public sealed class SplinePoint : CustomBehaviour
	{
		[Tooltip("Multiplier for spline radius.")]
		[SerializeField]
		internal float _RadiusMultiplier = 1f;

		internal Vector3 _LocalPosition;

		public float RadiusMultiplier
		{
			get
			{
				return _RadiusMultiplier;
			}
			set
			{
				_RadiusMultiplier = value;
			}
		}
	}
}
