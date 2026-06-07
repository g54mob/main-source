using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "EnvSceneSettingData", menuName = "設定檔/場景環境設定資料 (EnvSceneSettingData)", order = 1)]
public class EnvSceneSettingData : ScriptableObject
{
	[SerializeField]
	private Gradient gradient_LightColor;

	[SerializeField]
	private Gradient gradient_LightColor_FirstDay;

	[SerializeField]
	private Gradient gradient_LightColor_FastForward;

	[SerializeField]
	private AnimationCurve curve_LightIntensity;

	[SerializeField]
	private Vector3 lightOrientation_Start;

	[SerializeField]
	private Vector3 lightOrientation_End;

	[SerializeField]
	private AnimationCurve curve_ShadowStrength;

	public Gradient Gradient_LightColor => null;

	public Gradient Gradient_LightColor_FirstDay => null;

	public Gradient Gradient_LightColor_FastForward => null;

	public AnimationCurve Curve_LightIntensity => null;

	public Vector3 LightOrientation_Start => default(Vector3);

	public Vector3 LightOrientation_End => default(Vector3);

	public AnimationCurve Curve_ShadowStrength => null;
}
