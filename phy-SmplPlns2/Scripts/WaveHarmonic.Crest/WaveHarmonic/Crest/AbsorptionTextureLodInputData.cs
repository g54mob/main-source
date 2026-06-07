using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(AbsorptionLodInput), LodInputMode.Texture)]
	public sealed class AbsorptionTextureLodInputData : TextureLodInputData
	{
		private protected override ComputeShader TextureShader => ScriptableSingleton<WaterResources>.Instance.Compute._AbsorptionTexture;
	}
}
