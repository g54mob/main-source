using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(ScatteringLodInput), LodInputMode.Texture)]
	public sealed class ScatteringTextureLodInputData : TextureLodInputData
	{
		private protected override ComputeShader TextureShader => ScriptableSingleton<WaterResources>.Instance.Compute._ScatteringTexture;
	}
}
