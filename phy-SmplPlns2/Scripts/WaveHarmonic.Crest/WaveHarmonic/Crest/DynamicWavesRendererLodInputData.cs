using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(DynamicWavesLodInput), LodInputMode.Renderer)]
	public sealed class DynamicWavesRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Dynamic Waves";
	}
}
