using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(LevelLodInput), LodInputMode.Renderer)]
	public sealed class LevelRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Level";
	}
}
