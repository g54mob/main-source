using System;
using UnityEngine;

[Serializable]
public class SkyBoxBlender : Blender<Cubemap, BlenableCubeMap>
{
	[SerializeField]
	private ReflectionProbe reflectionProbe;

	[SerializeField]
	private RenderTexture reflectionProbeRT;

	protected override void Blend(Cubemap from, Cubemap to, float blendProgress)
	{
		RenderSettings.skybox.SetTexture("_StartSkybox", from);
		RenderSettings.skybox.SetTexture("_EndSkybox", to);
		RenderSettings.skybox.SetFloat("_Transition", blendProgress);
		if ((bool)reflectionProbe && (bool)reflectionProbeRT)
		{
			ReflectionProbe.BlendCubemap(from, to, Mathf.Clamp01(blendProgress), reflectionProbeRT);
			reflectionProbe.customBakedTexture = reflectionProbeRT;
		}
		else
		{
			Debug.LogException(new ArgumentException("Unable to blend reflection probe! Make sure the field are correctly set in Circadion Visuals prefeb (DayNightCycle)"));
		}
	}
}
