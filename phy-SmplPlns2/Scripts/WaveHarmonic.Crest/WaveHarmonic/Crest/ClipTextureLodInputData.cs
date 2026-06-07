using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(ClipLodInput), LodInputMode.Texture)]
	public sealed class ClipTextureLodInputData : TextureLodInputData
	{
		private protected override ComputeShader TextureShader => ScriptableSingleton<WaterResources>.Instance.Compute._ClipTexture;
	}
}
