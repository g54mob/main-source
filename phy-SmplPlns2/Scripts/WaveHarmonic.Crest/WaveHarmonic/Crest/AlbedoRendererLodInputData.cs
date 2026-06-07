using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(AlbedoLodInput), LodInputMode.Renderer)]
	public sealed class AlbedoRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Albedo";
	}
}
