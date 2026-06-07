using System;
using UnityEngine;

[Serializable]
public class EnvironmentSettingData
{
	[Header("燈光顏色")]
	public Gradient gradient_LightColor;

	[Header("燈光強度")]
	public AnimationCurve curve_LightIntensity;

	[Header("影子強度")]
	public AnimationCurve curve_ShadowStrength;

	[Header("燈光方向_開始")]
	public Vector3 lightOrientation_Start;

	[Header("燈光方向_結束")]
	public Vector3 lightOrientation_End;
}
