using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameSceneReferenceHandler : MonoBehaviour
{
	public enum eEnableRule
	{
		[InspectorName("永遠啟用")]
		NO_LIMIT = 0,
		[InspectorName("正常關限定")]
		NORMAL_ONLY = 1,
		[InspectorName("腐化關限定")]
		CORRUPTED_ONLY = 2
	}

	[Serializable]
	public class WeatherEffect
	{
		public GameObject obj_Effect;

		public eEnableRule enableType;

		public int weight;
	}

	[SerializeField]
	private Light directionLight;

	[SerializeField]
	[Header("一般場景")]
	private EnvSceneSettingData envSceneSettingData_Day;

	[FormerlySerializedAs("envSceneSettingData_Night")]
	[Header("腐化場景")]
	[SerializeField]
	private EnvSceneSettingData envSceneSettingData_Corrupted;

	[Header("一般煙霧")]
	[SerializeField]
	private Material mat_RenderFeatureSceneFog;

	[Header("地板MeshRenderer")]
	[SerializeField]
	private List<MeshRenderer> list_GroundRenderers;

	[SerializeField]
	private List<MonsterSpawner> list_MonsterSpawners;

	[SerializeField]
	private Vector3 initialCameraOffset;

	[SerializeField]
	[Header("是否覆寫攝影機的限制範圍")]
	private bool doOverrideCameraLimitRange;

	[SerializeField]
	[Header("攝影機限制範圍")]
	private float cameraLimitRange;

	[Header("是否覆寫攝影機的預設FOV")]
	[SerializeField]
	private bool doOverrideCameraDefaultFOV;

	[SerializeField]
	[Header("攝影機預設FOV")]
	private float cameraDefaultFOV;

	[SerializeField]
	[Header("是否覆寫攝影機的最大FOV")]
	private bool doOverrideCameraMaxFOV;

	[SerializeField]
	[Header("攝影機限制範圍")]
	private float cameraMaxFOV;

	[SerializeField]
	[Header("是否覆寫攝影機的旋轉角度")]
	private bool doOverrideCameraDefaultRotation;

	[Header("攝影機旋轉角度")]
	[SerializeField]
	private Vector3 cameraDefaultRotation;

	[SerializeField]
	private List<WeatherEffect> list_WeatherEffects;

	[SerializeField]
	private Camera photoCamera;

	private Color color_GroundFogColor;

	public Light DirectionLight => null;

	public EnvSceneSettingData EnvSceneSettingData_Day => null;

	public EnvSceneSettingData EnvSceneSettingData_Corrupted => null;

	public Material Mat_RenderFeatureSceneFog => null;

	public List<MeshRenderer> List_GroundRenderers => null;

	public List<MonsterSpawner> List_MonsterSpawners => null;

	public Vector3 InitialCameraOffset => default(Vector3);

	public bool DoOverrideCameraLimitRange => false;

	public float CameraLimitRange => 0f;

	public bool DoOverrideCameraDefaultFOV => false;

	public float CameraDefaultFOV => 0f;

	public bool DoOverrideCameraMaxFOV => false;

	public float CameraMaxFOV => 0f;

	public bool DoOverrideCameraDefaultRotation => false;

	public Vector3 CameraDefaultRotation => default(Vector3);

	public Camera PhotoCamera => null;

	public Color Color_GroundFogColor => default(Color);

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void RollWeatherEffect()
	{
	}

	public void OverrideLight(Light light)
	{
	}

	public void OverrideEnvSceneSettingData(EnvSceneSettingData data, bool isDayTime = true)
	{
	}

	public void OverrideSceneFogMaterial(Material mat)
	{
	}

	public void OverrideTerrainMaterial(Material mat)
	{
	}

	public void RequestUpdateEnvSceneBindings()
	{
	}

	private bool ValidateMeshRendererListNotEmpty(List<MeshRenderer> list)
	{
		return false;
	}

	private bool ValidateMonsterSpawnerListNotEmpty(List<MonsterSpawner> list)
	{
		return false;
	}
}
