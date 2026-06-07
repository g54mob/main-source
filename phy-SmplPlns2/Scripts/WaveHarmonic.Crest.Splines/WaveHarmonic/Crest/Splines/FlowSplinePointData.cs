using UnityEngine;

namespace WaveHarmonic.Crest.Splines
{
	[AddComponentMenu("")]
	public sealed class FlowSplinePointData : SplinePointData
	{
		internal const float k_DefaultSpeed = 2f;

		[Tooltip("Flow velocity (speed of flow in direction of spline).\n\nCan be negative to flip direction.")]
		[SerializeField]
		private float _FlowVelocity = 2f;

		public float FlowVelocity
		{
			get
			{
				return _FlowVelocity;
			}
			set
			{
				_FlowVelocity = value;
			}
		}

		internal override Vector4 GetData(Vector4 _)
		{
			return new Vector4(_FlowVelocity, 0f, 0f, 0f);
		}
	}
}
