using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(LevelLodInput), LodInputMode.Geometry)]
	public sealed class LevelGeometryLodInputData : GeometryLodInputData
	{
		private protected override Shader GeometryShader => ScriptableSingleton<WaterResources>.Instance.Shaders._LevelGeometry;
	}
}
