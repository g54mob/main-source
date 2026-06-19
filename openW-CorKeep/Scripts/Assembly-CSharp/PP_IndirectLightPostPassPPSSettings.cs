using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PP_IndirectLightPostPassPPSRenderer), PostProcessEvent.BeforeStack, "PP_IndirectLightPostPass", true)]
public sealed class PP_IndirectLightPostPassPPSSettings : PostProcessEffectSettings
{
	public FloatParameter strength = new FloatParameter
	{
		value = 0.02f
	};
}
