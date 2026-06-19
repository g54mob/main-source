using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable]
[VolumeComponentMenu("Sky/Fog (URP)")]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[HelpURL("https://github.com/jiaozi158/UnityPhysicallyBasedSkyURP/tree/main")]
public class Fog : VolumeComponent, IPostProcessComponent
{
	public enum FogColorMode
	{
		ConstantColor = 0,
		SkyColor = 1
	}

	[Serializable]
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	public sealed class FogColorParameter : VolumeParameter<FogColorMode>
	{
		public FogColorParameter(FogColorMode value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	[Tooltip("Enables the fog.")]
	public BoolParameter enabled = new BoolParameter(value: false, BoolParameter.DisplayType.EnumPopup);

	[Tooltip("Specifies the color mode of the fog.")]
	public FogColorParameter colorMode = new FogColorParameter(FogColorMode.SkyColor);

	[Tooltip("Specifies the constant color of the fog.")]
	public ColorParameter color = new ColorParameter(Color.grey, hdr: true, showAlpha: false, showEyeDropper: true);

	[Tooltip("Specifies the tint of the fog.")]
	public ColorParameter tint = new ColorParameter(Color.white, hdr: true, showAlpha: false, showEyeDropper: true);

	[Tooltip("Sets the maximum fog distance URP uses when it shades the skybox or the Far Clipping Plane of the Camera.")]
	public MinFloatParameter maxFogDistance = new MinFloatParameter(5000f, 0f);

	[AdditionalProperty]
	[Tooltip("Controls the maximum mip map URP uses for mip fog (0 is the lowest mip and 1 is the highest mip).")]
	public ClampedFloatParameter mipFogMaxMip = new ClampedFloatParameter(0.5f, 0f, 1f);

	[AdditionalProperty]
	[Tooltip("Sets the distance at which URP uses the minimum mip image of the blurred sky texture as the fog color.")]
	public MinFloatParameter mipFogNear = new MinFloatParameter(0f, 0f);

	[AdditionalProperty]
	[Tooltip("Sets the distance at which URP uses the maximum mip image of the blurred sky texture as the fog color.")]
	public MinFloatParameter mipFogFar = new MinFloatParameter(1000f, 0f);

	[Tooltip("Enables or disables fog when the camera is underwater.")]
	public BoolParameter underWater = new BoolParameter(value: false);

	[Tooltip("Sets the height at which the water surface is located, used to determine when URP disables fog.")]
	public FloatParameter waterHeight = new FloatParameter(1f);

	[Tooltip("Reference height (e.g. sea level). Sets the height of the boundary between the constant and exponential fog. Units: m.")]
	public FloatParameter baseHeight = new FloatParameter(0f);

	[Tooltip("Max height of the fog layer. Controls the rate of height-based density falloff. Units: m.")]
	public FloatParameter maximumHeight = new FloatParameter(50f);

	[DisplayInfo(name = "Fog Attenuation Distance")]
	[Tooltip("Controls the density at the base level (per color channel). Distance at which fog reduces background light intensity by 63%. Units: m.")]
	public MinFloatParameter meanFreePath = new MinFloatParameter(400f, 1f);

	public bool IsActive()
	{
		if (active)
		{
			return enabled.value;
		}
		return false;
	}
}
