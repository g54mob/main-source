using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PP_LightBlurrPassPPSRenderer), PostProcessEvent.BeforeStack, "PP_LightBlurrPass", true)]
public sealed class PP_LightBlurrPassPPSSettings : PostProcessEffectSettings
{
	public IntParameter passes = new IntParameter
	{
		value = 10
	};
}
