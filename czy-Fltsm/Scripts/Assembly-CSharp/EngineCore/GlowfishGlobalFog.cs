using System.Collections.Generic;
using UnityEngine;

namespace EngineCore
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public class GlowfishGlobalFog : MonoBehaviour
	{
		public bool DebugDrawFogMask;

		[Header("Shader")]
		public Shader FogShader;

		private Material _fogMaterial;

		[Header("GlobalFog Definition Visualization")]
		public GlobalFogDefinitionScriptableObject FogScriptableObject;

		public bool ForceDrawTargetFogDefinition;

		public bool CopyFogDefinitionToCurrentOnAwake;

		public GlobalFogDefinition CurrentFogDefinition = new GlobalFogDefinition();

		private Camera _cam;

		private Transform _camtr;

		private Rect _frustumCornerRect = new Rect(0f, 0f, 1f, 1f);

		private Vector3[] _frustumCorners = new Vector3[4];

		private Matrix4x4 _frustumCornersArray = Matrix4x4.identity;

		private List<Material> _createdMaterials = new List<Material>();

		private const string cString_FrustumCornersWS = "_FrustumCornersWS";

		private const string cString_CameraWS = "_CameraWS";

		private const string cString_GeneralParams = "_GeneralFogParams";

		private const string cString_SceneFogParams = "_SceneFogParams";

		private const string cString_SceneFogParams2 = "_SceneFogParams2";

		private const string cString_SceneFogMode = "_SceneFogMode";

		private const string cString_SceneFogColor = "_SceneFogColor";

		private const string cString_HeightFogColor = "_HeightFogColor";

		private const string cString_CustomHeightFogColor = "_CustomHeightFogColor";

		private const string cString_DistanceFogParams = "_DistanceFogParams";

		private const string cString_DistanceFogNoiseParams = "_DistanceFogNoiseParams";

		private const string cString_DistanceFogNoiseDirection = "_DistanceFogNoiseDirection";

		private const string cString_HeightParams = "_HeightParams";

		private const string cString_HeightParams2 = "_HeightParams2";

		private const string cString_StandardHeightControlParams = "_StandardHeightControlParams";

		private const string cString_HeightFogNoiseParams = "_HeightFogNoiseParams";

		private const string cString_HeightFogNoiseDirection = "_HeightFogNoiseDirection";

		private const string cString_CustomHeightParams = "_CustomHeightParams";

		private const string cString_CustomHeightParams2 = "_CustomHeightParams2";

		private const string cString_CustomHeightControlParams = "_CustomHeightControlParams";

		private const string cString_CustomHeightFogNoiseParams = "_CustomHeightFogNoiseParams";

		private const string cString_CustomHeightFogNoiseDirection = "_CustomHeightFogNoiseDirection";

		private const string cString_ENABLE_FogDebugDraw = "ENABLE_FogDebugDraw";

		private int _shaderID_FrustumCornersWS;

		private int _shaderID_CameraWS;

		private int _shaderID_GeneralParams;

		private int _shaderID_SceneFogParams;

		private int _shaderID_SceneFogParams2;

		private int _shaderID_SceneFogMode;

		private int _shaderID_SceneFogColor;

		private int _shaderID_HeightFogColor;

		private int _shaderID_CustomHeightFogColor;

		private int _shaderID_DistanceFogParams;

		private int _shaderID_DistanceFogNoiseParams;

		private int _shaderID_DistanceFogNoiseDirection;

		private int _shaderID_HeightParams;

		private int _shaderID_HeightParams2;

		private int _shaderID_StandardHeightControlParams;

		private int _shaderID_HeightFogNoiseParams;

		private int _shaderID_HeightFogNoiseDirection;

		private int _shaderID_CustomHeightParams;

		private int _shaderID_CustomHeightParams2;

		private int _shaderID_CustomHeightControlParams;

		private int _shaderID_CustomHeightFogNoiseParams;

		private int _shaderID_CustomHeightFogNoiseDirection;

		protected GlobalFogDefinition _currentActiveFogDefinition
		{
			get
			{
				if (ForceDrawTargetFogDefinition && FogScriptableObject != null)
				{
					return FogScriptableObject.FogDefinition;
				}
				return CurrentFogDefinition;
			}
		}

		private void Awake()
		{
			_cam = GetComponent<Camera>();
			_camtr = _cam.transform;
			UpdateShaderIDs();
			if (Application.isPlaying && CopyFogDefinitionToCurrentOnAwake && FogScriptableObject != null)
			{
				CurrentFogDefinition.CopyFrom(FogScriptableObject.FogDefinition);
			}
		}

		protected void UpdateShaderIDs()
		{
			_shaderID_FrustumCornersWS = Shader.PropertyToID("_FrustumCornersWS");
			_shaderID_CameraWS = Shader.PropertyToID("_CameraWS");
			_shaderID_GeneralParams = Shader.PropertyToID("_GeneralFogParams");
			_shaderID_SceneFogParams = Shader.PropertyToID("_SceneFogParams");
			_shaderID_SceneFogParams2 = Shader.PropertyToID("_SceneFogParams2");
			_shaderID_SceneFogMode = Shader.PropertyToID("_SceneFogMode");
			_shaderID_SceneFogColor = Shader.PropertyToID("_SceneFogColor");
			_shaderID_HeightFogColor = Shader.PropertyToID("_HeightFogColor");
			_shaderID_CustomHeightFogColor = Shader.PropertyToID("_CustomHeightFogColor");
			_shaderID_DistanceFogParams = Shader.PropertyToID("_DistanceFogParams");
			_shaderID_DistanceFogNoiseParams = Shader.PropertyToID("_DistanceFogNoiseParams");
			_shaderID_DistanceFogNoiseDirection = Shader.PropertyToID("_DistanceFogNoiseDirection");
			_shaderID_HeightParams = Shader.PropertyToID("_HeightParams");
			_shaderID_HeightParams2 = Shader.PropertyToID("_HeightParams2");
			_shaderID_StandardHeightControlParams = Shader.PropertyToID("_StandardHeightControlParams");
			_shaderID_HeightFogNoiseParams = Shader.PropertyToID("_HeightFogNoiseParams");
			_shaderID_HeightFogNoiseDirection = Shader.PropertyToID("_HeightFogNoiseDirection");
			_shaderID_CustomHeightParams = Shader.PropertyToID("_CustomHeightParams");
			_shaderID_CustomHeightParams2 = Shader.PropertyToID("_CustomHeightParams2");
			_shaderID_CustomHeightControlParams = Shader.PropertyToID("_CustomHeightControlParams");
			_shaderID_CustomHeightFogNoiseParams = Shader.PropertyToID("_CustomHeightFogNoiseParams");
			_shaderID_CustomHeightFogNoiseDirection = Shader.PropertyToID("_CustomHeightFogNoiseDirection");
		}

		protected void OnEnable()
		{
			CheckResources();
		}

		public bool CheckResources()
		{
			_fogMaterial = CheckShaderAndCreateMaterial(ref FogShader, _fogMaterial);
			return _fogMaterial != null;
		}

		private void OnDisable()
		{
			RemoveCreatedMaterials();
		}

		private void RemoveCreatedMaterials()
		{
			while (_createdMaterials.Count > 0)
			{
				Material obj = _createdMaterials[0];
				_createdMaterials.RemoveAt(0);
				Object.Destroy(obj);
			}
		}

		protected Material CheckShaderAndCreateMaterial(ref Shader shader, Material m2Create)
		{
			if (!shader)
			{
				shader = Shader.Find("Hidden/SHADER_PP_GlowfishGlobalFog");
				if (!shader)
				{
					Debug.Log("Missing shader in " + ToString());
					base.enabled = false;
					return null;
				}
			}
			if (shader.isSupported && (bool)m2Create && m2Create.shader == shader)
			{
				return m2Create;
			}
			if (!shader.isSupported)
			{
				Debug.Log("The shader " + shader.ToString() + " on effect " + ToString() + " is not supported on this platform!");
				return null;
			}
			m2Create = new Material(shader);
			_createdMaterials.Add(m2Create);
			m2Create.hideFlags = HideFlags.DontSave;
			return m2Create;
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!CheckResources() || (!_currentActiveFogDefinition.DistanceFog && !_currentActiveFogDefinition.HeightFog && !_currentActiveFogDefinition.CustomHeightFog))
			{
				Graphics.Blit(source, destination);
				return;
			}
			_cam.CalculateFrustumCorners(_frustumCornerRect, _cam.farClipPlane, _cam.stereoActiveEye, _frustumCorners);
			Vector3 vector = _camtr.TransformVector(_frustumCorners[0]);
			Vector3 vector2 = _camtr.TransformVector(_frustumCorners[1]);
			Vector3 vector3 = _camtr.TransformVector(_frustumCorners[2]);
			Vector3 vector4 = _camtr.TransformVector(_frustumCorners[3]);
			_frustumCornersArray.SetRow(0, vector);
			_frustumCornersArray.SetRow(1, vector4);
			_frustumCornersArray.SetRow(2, vector2);
			_frustumCornersArray.SetRow(3, vector3);
			Vector3 position = _camtr.position;
			_fogMaterial.SetMatrix(_shaderID_FrustumCornersWS, _frustumCornersArray);
			_fogMaterial.SetVector(_shaderID_CameraWS, position);
			float y = (_currentActiveFogDefinition.ExcludeFarPixels ? 1f : 2f);
			_fogMaterial.SetVector(_shaderID_GeneralParams, new Vector4(0f - Mathf.Max(_currentActiveFogDefinition.StartDistance, 0f), y, _currentActiveFogDefinition.MinFogClamp, _currentActiveFogDefinition.MaxFogClamp));
			_fogMaterial.SetVector(_shaderID_SceneFogParams2, new Vector4(_currentActiveFogDefinition.HDRPunchThrough, _currentActiveFogDefinition.HDRPunchThroughThreshold, _currentActiveFogDefinition.FogColorCompositionPercentage, 0f));
			EFogMode fogMode = _currentActiveFogDefinition.FogMode;
			float fogDensity = _currentActiveFogDefinition.FogDensity;
			float fogStartDistance = _currentActiveFogDefinition.FogStartDistance;
			float fogEndDistance = _currentActiveFogDefinition.FogEndDistance;
			if (_currentActiveFogDefinition.EnableFogColorGammaCorrection)
			{
				_fogMaterial.SetColor(_shaderID_SceneFogColor, _currentActiveFogDefinition.FogColor.linear);
				_fogMaterial.SetColor(_shaderID_HeightFogColor, _currentActiveFogDefinition.HeightFogColor.linear);
				_fogMaterial.SetColor(_shaderID_CustomHeightFogColor, _currentActiveFogDefinition.CustomHeightFogColor.linear);
			}
			else
			{
				_fogMaterial.SetColor(_shaderID_SceneFogColor, _currentActiveFogDefinition.FogColor);
				_fogMaterial.SetColor(_shaderID_HeightFogColor, _currentActiveFogDefinition.HeightFogColor);
				_fogMaterial.SetColor(_shaderID_CustomHeightFogColor, _currentActiveFogDefinition.CustomHeightFogColor);
			}
			bool flag = fogMode == EFogMode.Linear;
			float num = (flag ? (fogEndDistance - fogStartDistance) : 0f);
			float num2 = ((Mathf.Abs(num) > 0.0001f) ? (1f / num) : 0f);
			Vector4 value = default(Vector4);
			value.x = fogDensity * 1.2011224f;
			value.y = fogDensity * 1.442695f;
			value.z = (flag ? (0f - num2) : 0f);
			value.w = (flag ? (fogEndDistance * num2) : 0f);
			_fogMaterial.SetVector(_shaderID_SceneFogParams, value);
			_fogMaterial.SetVector(_shaderID_SceneFogMode, new Vector4((float)fogMode, (float)_currentActiveFogDefinition.DistanceFogCalculationMode, 0f, 0f));
			_fogMaterial.SetVector(_shaderID_DistanceFogParams, new Vector4(_currentActiveFogDefinition.DistanceFogIntensity, 0f, _currentActiveFogDefinition.DistanceFogNoiseInfluence, _currentActiveFogDefinition.PlayerPositionDistanceInfluence));
			_fogMaterial.SetVector(_shaderID_DistanceFogNoiseParams, new Vector4(_currentActiveFogDefinition.DistanceFogNoiseScale, _currentActiveFogDefinition.DistanceFogCenterOffset, _currentActiveFogDefinition.DistanceFogNoisePower, _currentActiveFogDefinition.DistanceFogNoiseOffsetScale));
			_fogMaterial.SetVector(_shaderID_DistanceFogNoiseDirection, new Vector4(_currentActiveFogDefinition.DistanceFogNoiseDirection.x, _currentActiveFogDefinition.DistanceFogNoiseDirection.y, _currentActiveFogDefinition.DistanceFogNoiseDirection.z, _currentActiveFogDefinition.DistanceFogNoiseSpeed));
			float num3 = position.y - _currentActiveFogDefinition.Height;
			float z = ((num3 <= 0f) ? 1f : 0f);
			_fogMaterial.SetVector(_shaderID_HeightParams, new Vector4(_currentActiveFogDefinition.Height, num3, z, _currentActiveFogDefinition.HeightDensity));
			_fogMaterial.SetVector(_shaderID_HeightParams2, new Vector4(_currentActiveFogDefinition.HeightFogIntensity, 0f, 0f, _currentActiveFogDefinition.HeightFogNoiseInfluence));
			_fogMaterial.SetVector(_shaderID_StandardHeightControlParams, new Vector4(_currentActiveFogDefinition.HeightMaskRadius, _currentActiveFogDefinition.HeightMaskLowerClamp, _currentActiveFogDefinition.HeightMaskPower, _currentActiveFogDefinition.PlayerPositionHeightInfluence));
			_fogMaterial.SetVector(_shaderID_HeightFogNoiseParams, new Vector4(_currentActiveFogDefinition.HeightFogNoiseScale, _currentActiveFogDefinition.HeightFogCenterOffset, _currentActiveFogDefinition.HeightFogNoisePower, _currentActiveFogDefinition.HeightFogNoiseOffsetScale));
			_fogMaterial.SetVector(_shaderID_HeightFogNoiseDirection, new Vector4(_currentActiveFogDefinition.HeightFogNoiseDirection.x, _currentActiveFogDefinition.HeightFogNoiseDirection.y, _currentActiveFogDefinition.HeightFogNoiseDirection.z, _currentActiveFogDefinition.HeightFogNoiseSpeed));
			z = ((position.y - _currentActiveFogDefinition.CustomHeightFogBottomHeight <= 0f) ? 1f : 0f);
			_fogMaterial.SetVector(_shaderID_CustomHeightParams, new Vector4(_currentActiveFogDefinition.CustomHeightFogTopHeight, _currentActiveFogDefinition.CustomHeightFogBottomHeight, _currentActiveFogDefinition.CustomHeightFogFallofPower, z));
			_fogMaterial.SetVector(_shaderID_CustomHeightParams2, new Vector4(_currentActiveFogDefinition.CustomHeightFogIntensity, 0f, 0f, _currentActiveFogDefinition.CustomHeightFogNoiseInfluence));
			_fogMaterial.SetVector(_shaderID_CustomHeightControlParams, new Vector4(_currentActiveFogDefinition.CustomHeightMaskRadius, _currentActiveFogDefinition.CustomHeightMaskLowerClamp, _currentActiveFogDefinition.CustomHeightMaskPower, _currentActiveFogDefinition.PlayerPositionCustomHeightInfluence));
			_fogMaterial.SetVector(_shaderID_CustomHeightFogNoiseParams, new Vector4(_currentActiveFogDefinition.CustomHeightFogNoiseScale, _currentActiveFogDefinition.CustomHeightFogCenterOffset, _currentActiveFogDefinition.CustomHeightFogNoisePower, _currentActiveFogDefinition.CustomHeightFogNoiseOffsetScale));
			_fogMaterial.SetVector(_shaderID_CustomHeightFogNoiseDirection, new Vector4(_currentActiveFogDefinition.CustomHeightFogNoiseDirection.x, _currentActiveFogDefinition.CustomHeightFogNoiseDirection.y, _currentActiveFogDefinition.CustomHeightFogNoiseDirection.z, _currentActiveFogDefinition.CustomHeightFogNoiseSpeed));
			if (DebugDrawFogMask)
			{
				_fogMaterial.EnableKeyword("ENABLE_FogDebugDraw");
			}
			else
			{
				_fogMaterial.DisableKeyword("ENABLE_FogDebugDraw");
			}
			int pass = 0;
			if (_currentActiveFogDefinition.DistanceFog && _currentActiveFogDefinition.HeightFog && _currentActiveFogDefinition.CustomHeightFog)
			{
				pass = 0;
			}
			else if (_currentActiveFogDefinition.DistanceFog && _currentActiveFogDefinition.HeightFog)
			{
				pass = 4;
			}
			else if (_currentActiveFogDefinition.DistanceFog && _currentActiveFogDefinition.CustomHeightFog)
			{
				pass = 5;
			}
			else if (_currentActiveFogDefinition.DistanceFog)
			{
				pass = 1;
			}
			else if (_currentActiveFogDefinition.HeightFog && _currentActiveFogDefinition.CustomHeightFog)
			{
				pass = 6;
			}
			else if (_currentActiveFogDefinition.HeightFog)
			{
				pass = 2;
			}
			else if (_currentActiveFogDefinition.CustomHeightFog)
			{
				pass = 3;
			}
			Graphics.Blit(source, destination, _fogMaterial, pass);
		}
	}
}
