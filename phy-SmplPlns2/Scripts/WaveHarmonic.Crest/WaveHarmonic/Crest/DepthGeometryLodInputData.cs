using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(DepthLodInput), LodInputMode.Geometry)]
	public sealed class DepthGeometryLodInputData : GeometryLodInputData
	{
		private protected override Shader GeometryShader => ScriptableSingleton<WaterResources>.Instance.Shaders._DepthGeometry;
	}
}
