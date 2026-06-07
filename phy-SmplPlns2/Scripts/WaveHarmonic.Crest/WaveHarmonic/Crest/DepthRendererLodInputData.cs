using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(DepthLodInput), LodInputMode.Renderer)]
	public sealed class DepthRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Depth";
	}
}
