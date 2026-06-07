using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(FlowLodInput), LodInputMode.Texture)]
	public sealed class FlowTextureLodInputData : DirectionalTextureLodInputData
	{
		private protected override ComputeShader TextureShader => ScriptableSingleton<WaterResources>.Instance.Compute._FlowTexture;
	}
}
