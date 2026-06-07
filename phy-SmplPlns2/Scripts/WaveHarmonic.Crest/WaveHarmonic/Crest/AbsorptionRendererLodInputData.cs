using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(AbsorptionLodInput), LodInputMode.Renderer)]
	public sealed class AbsorptionRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Absorption";
	}
}
