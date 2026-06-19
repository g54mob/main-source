using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PP_DirectLightPassPPSRenderer), PostProcessEvent.BeforeStack, "PP_DirectLightPass", true)]
public sealed class PP_DirectLightPassPPSSettings : PostProcessEffectSettings
{
}
