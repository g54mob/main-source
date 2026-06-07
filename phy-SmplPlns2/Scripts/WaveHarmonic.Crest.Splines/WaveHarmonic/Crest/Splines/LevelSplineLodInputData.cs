using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using WaveHarmonic.Crest.Splines.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest.Splines
{
	[Serializable]
	[MovedFrom(false, "WaveHarmonic.Crest.Spline", "WaveHarmonic.Crest.Spline", null)]
	[ForLodInput(typeof(LevelLodInput), LodInputMode.Spline)]
	public sealed class LevelSplineLodInputData : SplineLodInputData<SplinePointData>
	{
		private protected override Shader SplineShader => ScriptableSingleton<WaterResources>.Instance.Shaders._LevelGeometry;

		private protected override Vector4 DefaultCustomSplineData => Vector4.zero;

		public LevelSplineLodInputData()
		{
			_OverrideSubdivisions = true;
			_Subdivisions = 6;
		}
	}
}
