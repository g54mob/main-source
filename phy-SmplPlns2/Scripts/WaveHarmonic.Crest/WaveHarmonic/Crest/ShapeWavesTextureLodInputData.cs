using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(ShapeWaves), LodInputMode.Texture)]
	public sealed class ShapeWavesTextureLodInputData : DirectionalTextureLodInputData
	{
		private protected override ComputeShader TextureShader => ScriptableSingleton<WaterResources>.Instance.Compute._ShapeWavesTransfer;
	}
}
