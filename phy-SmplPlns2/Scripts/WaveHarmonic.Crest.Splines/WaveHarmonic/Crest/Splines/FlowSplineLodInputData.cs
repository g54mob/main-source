using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using WaveHarmonic.Crest.Splines.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest.Splines
{
	[Serializable]
	[MovedFrom(false, "WaveHarmonic.Crest.Spline", "WaveHarmonic.Crest.Spline", null)]
	[ForLodInput(typeof(FlowLodInput), LodInputMode.Spline)]
	public sealed class FlowSplineLodInputData : SplineLodInputData<FlowSplinePointData>
	{
		[Tooltip("Flow velocity (speed of flow in direction of spline). Can be negative to flip direction.")]
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

		private protected override Shader SplineShader => ScriptableSingleton<WaterResources>.Instance.Shaders._FlowSpline;

		private protected override Vector4 DefaultCustomSplineData => new Vector4(_FlowVelocity, 0f, 0f, 0f);
	}
}
