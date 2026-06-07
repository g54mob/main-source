using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(ShapeWaves), LodInputMode.Renderer)]
	public sealed class ShapeWavesRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Shape Waves";
	}
}
