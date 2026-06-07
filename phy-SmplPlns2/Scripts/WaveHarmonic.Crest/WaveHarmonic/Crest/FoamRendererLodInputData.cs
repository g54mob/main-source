using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(FoamLodInput), LodInputMode.Renderer)]
	public sealed class FoamRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Foam";
	}
}
