using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(FoamLodInput), LodInputMode.Texture)]
	public sealed class FoamTextureLodInputData : TextureLodInputData
	{
		private protected override ComputeShader TextureShader => ScriptableSingleton<WaterResources>.Instance.Compute._FoamTexture;
	}
}
