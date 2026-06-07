using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(ScatteringLodInput), LodInputMode.Renderer)]
	public sealed class ScatteringRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Scattering";
	}
}
