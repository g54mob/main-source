using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(ClipLodInput), LodInputMode.Renderer)]
	public sealed class ClipRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Clip";
	}
}
