using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(FlowLodInput), LodInputMode.Renderer)]
	public sealed class FlowRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Flow";
	}
}
