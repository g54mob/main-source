using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(ShadowLodInput), LodInputMode.Renderer)]
	public sealed class ShadowRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Shadow";
	}
}
