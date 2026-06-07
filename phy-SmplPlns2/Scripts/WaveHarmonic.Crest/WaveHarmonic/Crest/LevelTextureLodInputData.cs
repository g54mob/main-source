using System;
using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(LevelLodInput), LodInputMode.Texture)]
	public sealed class LevelTextureLodInputData : TextureLodInputData
	{
		[Tooltip("Helps with staircase aliasing.")]
		[SerializeField]
		internal bool _UseCatmullRomFiltering;

		private protected override ComputeShader TextureShader => ScriptableSingleton<WaterResources>.Instance.Compute._LevelTexture;
	}
}
