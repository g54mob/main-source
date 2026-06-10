using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(FoxyVoxelEffectsfv_heat_wavePPSRenderer), PostProcessEvent.AfterStack, "FoxyVoxelEffectsfv_heat_wave", true)]
public sealed class HeatWavePPSSettings : PostProcessEffectSettings
{
	[Tooltip("vignette")]
	public TextureParameter _vignette = new TextureParameter();

	[Tooltip("Blur Size")]
	public FloatParameter _BlurSize = new FloatParameter
	{
		value = 0.0005f
	};
}
