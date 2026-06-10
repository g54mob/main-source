using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(FoxyVoxelEffectsfv_cold_snapPPSRenderer), PostProcessEvent.AfterStack, "FoxyVoxelEffectsfv_cold_snap", true)]
public sealed class ColdSnapPPSSettings : PostProcessEffectSettings
{
	[Tooltip("vignette")]
	public TextureParameter _vignette = new TextureParameter();

	[Tooltip("FrostNormal")]
	public TextureParameter _FrostNormal = new TextureParameter();

	[Tooltip("VignetteScaleOffset")]
	public Vector4Parameter _VignetteScaleOffset = new Vector4Parameter
	{
		value = new Vector4(1f, -1f, 0f, 0f)
	};

	[Tooltip("NormalScale")]
	public FloatParameter _NormalScale = new FloatParameter
	{
		value = 1f
	};

	[Tooltip("SnowColor")]
	public ColorParameter _SnowColor = new ColorParameter
	{
		value = new Color(0.735849f, 0.735849f, 0.735849f, 0f)
	};

	[Tooltip("FrostWhiteScaleOffset")]
	public Vector4Parameter _FrostWhiteScaleOffset = new Vector4Parameter
	{
		value = new Vector4(1f, 0f, 0f, 0f)
	};

	[Tooltip("ShineScaleOffset")]
	public Vector4Parameter _ShineScaleOffset = new Vector4Parameter
	{
		value = new Vector4(1f, 0f, 0f, 0f)
	};
}
