using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PixelatePPSRenderer), PostProcessEvent.AfterStack, "Pixelate", true)]
public sealed class PixelatePPSSettings : PostProcessEffectSettings
{
	[Tooltip("Pixel Density")]
	public FloatParameter _PixelDensity;
}
