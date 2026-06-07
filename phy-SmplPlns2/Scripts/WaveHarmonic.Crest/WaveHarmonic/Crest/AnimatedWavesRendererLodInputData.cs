using System;

namespace WaveHarmonic.Crest
{
	[Serializable]
	[ForLodInput(typeof(AnimatedWavesLodInput), LodInputMode.Renderer)]
	public sealed class AnimatedWavesRendererLodInputData : RendererLodInputData
	{
		internal override string ShaderPrefix => "Crest/Inputs/Animated Waves";
	}
}
