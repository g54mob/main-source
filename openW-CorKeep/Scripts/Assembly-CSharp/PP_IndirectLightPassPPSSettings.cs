using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PP_IndirectLightPassPPSRenderer), PostProcessEvent.BeforeStack, "PP_IndirectLightPass", true)]
public sealed class PP_IndirectLightPassPPSSettings : PostProcessEffectSettings
{
	public IntParameter passes = new IntParameter
	{
		value = 10
	};
}
