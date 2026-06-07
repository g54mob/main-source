using System;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.PlanetStudio;
using ModApi;
using ModApi.Flight.GameView;
using ModApi.Flight.MapView;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	public class WaterReflectionPlaneScript : MonoBehaviour
	{
		private static Vector3[] _tempFrustumCorners = new Vector3[4];

		private ImageEffectsScript _imageEffects;

		[SerializeField]
		private Camera _mainCamera;

		private Transform _mainCameraTransform;

		private IMapViewManager _mapViewManager;

		private IPlanet _planet;

		private IReferenceFrame _referenceFrame;

		[SerializeField]
		private Camera _reflectionCamera;

		[SerializeField]
		private WaterReflectionOptions _reflectionOptions;

		private RenderTexture _reflectionTexture;

		private int _reflectionTextureCurrentSize = 512;

		private Transform _transform;

		private bool _wavesEnabled;

		public WaterReflectionOptions ReflectionOptions
		{
			get
			{
				return _reflectionOptions;
			}
			set
			{
				_reflectionOptions = value;
			}
		}

		public static WaterReflectionPlaneScript Create(Transform parent, Camera mainCamera, IReferenceFrame referenceFrame)
		{
			WaterReflectionPlaneScript waterReflectionPlaneScript = new GameObject("WaterReflectionPlane").AddComponent<WaterReflectionPlaneScript>();
			waterReflectionPlaneScript.transform.SetParent(parent, worldPositionStays: false);
			waterReflectionPlaneScript._referenceFrame = referenceFrame;
			waterReflectionPlaneScript._mainCamera = mainCamera;
			return waterReflectionPlaneScript;
		}

		protected virtual void LateUpdate()
		{
			if (_planet == null)
			{
				return;
			}
			IQuadSphere quadSphere = _planet.QuadSphere;
			if (quadSphere == null || !_planet.QuadSphereEnabled)
			{
				return;
			}
			Vector3 position = quadSphere.Transform.position;
			Vector3 waterPosBelowPoint = _referenceFrame.GetWaterPosBelowPoint(_mainCameraTransform.position, includeWaves: false, null);
			Vector3 normalized = (waterPosBelowPoint - position).normalized;
			if (normalized.x == 0f && normalized.y == 0f && normalized.z == 0f)
			{
				return;
			}
			if (_wavesEnabled)
			{
				waterPosBelowPoint += normalized * _referenceFrame.GetWaterWaveOffset(Game.Instance.FlightScene.ViewManager.GameView.GameCamera.Target.CameraTarget.position, null);
			}
			Vector3 forward = _mainCameraTransform.forward;
			Vector3 vector = Vector3.ProjectOnPlane(forward, normalized);
			if (vector == Vector3.zero)
			{
				vector = Vector3.ProjectOnPlane(forward + new Vector3(0f, 0f, 0.01f), normalized);
				if (vector == Vector3.zero)
				{
					vector = Vector3.ProjectOnPlane(forward + new Vector3(0.001f, 0f, 0.01f), normalized);
				}
			}
			Quaternion rotation = Quaternion.LookRotation(vector, normalized);
			_transform.SetPositionAndRotation(waterPosBelowPoint, rotation);
			UpdateReflections(waterPosBelowPoint, normalized);
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.Water.Changed -= OnWaterQualityChanged;
			if (_reflectionTexture != null)
			{
				UnityEngine.Object.Destroy(_reflectionTexture);
				_reflectionTexture = null;
			}
			if (_mapViewManager != null)
			{
				_mapViewManager.ForegroundStateChanged -= OnMapViewForegroundStateChanged;
			}
			if (_imageEffects?.Underwater != null)
			{
				_imageEffects.Underwater.UnderWaterStateChanged -= OnUnderWaterStateChanged;
			}
		}

		protected virtual void Start()
		{
			_transform = base.transform;
			if (_mainCamera == null)
			{
				_mainCamera = Camera.main;
				Debug.LogWarning("Main camera reference not set on the water reflection plane.");
			}
			_mainCameraTransform = _mainCamera.transform;
			if (Game.InFlightScene)
			{
				_planet = Game.Instance.FlightScene?.ViewManager.GameView.Planet;
				_mapViewManager = Game.Instance.FlightScene.ViewManager.MapViewManager;
				_mapViewManager.ForegroundStateChanged += OnMapViewForegroundStateChanged;
				_imageEffects = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.Transform.GetComponent<ImageEffectsScript>();
				_imageEffects.Underwater.UnderWaterStateChanged += OnUnderWaterStateChanged;
			}
			else
			{
				if (!Game.InPlanetStudioScene)
				{
					throw new NotSupportedException();
				}
				_planet = PlanetStudioScript.Instance.CelestialBodyDesignerScript.CelestialBodyViewer.PlanetScript;
			}
			if (!_planet.PlanetData.HasWater)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			WaterQualitySettings water = Game.Instance.QualitySettings.Water;
			water.Changed += OnWaterQualityChanged;
			ApplyQualitySettings(water.Reflections);
			InitializeReflectionCamera(_mainCamera);
		}

		private static void CalculateObliqueMatrix(ref Matrix4x4 projection, Vector4 clipPlane)
		{
			Vector4 b = projection.inverse * new Vector4(SignExt(clipPlane.x), SignExt(clipPlane.y), 1f, 1f);
			Vector4 vector = clipPlane * (2f / Vector4.Dot(clipPlane, b));
			projection[2] = vector.x - projection[3];
			projection[6] = vector.y - projection[7];
			projection[10] = vector.z - projection[11];
			projection[14] = vector.w - projection[15];
		}

		private static void CalculateReflectionMatrix(ref Matrix4x4 matrix, Vector4 plane)
		{
			matrix.m00 = 1f - 2f * plane[0] * plane[0];
			matrix.m01 = -2f * plane[0] * plane[1];
			matrix.m02 = -2f * plane[0] * plane[2];
			matrix.m03 = -2f * plane[3] * plane[0];
			matrix.m10 = -2f * plane[1] * plane[0];
			matrix.m11 = 1f - 2f * plane[1] * plane[1];
			matrix.m12 = -2f * plane[1] * plane[2];
			matrix.m13 = -2f * plane[3] * plane[1];
			matrix.m20 = -2f * plane[2] * plane[0];
			matrix.m21 = -2f * plane[2] * plane[1];
			matrix.m22 = 1f - 2f * plane[2] * plane[2];
			matrix.m23 = -2f * plane[3] * plane[2];
			matrix.m30 = 0f;
			matrix.m31 = 0f;
			matrix.m32 = 0f;
			matrix.m33 = 1f;
		}

		private static float SignExt(float a)
		{
			if (a > 0f)
			{
				return 1f;
			}
			if (a < 0f)
			{
				return -1f;
			}
			return 0f;
		}

		private void ApplyQualitySettings(WaterQualitySettings.ReflectionQuality quality)
		{
			_wavesEnabled = Game.InFlightScene && Game.Instance.QualitySettings.Water.Waves.Value;
			if (_reflectionOptions == null)
			{
				_reflectionOptions = new WaterReflectionOptions();
			}
			WaterReflectionOptions reflectionOptions = _reflectionOptions;
			switch (quality)
			{
			case WaterQualitySettings.ReflectionQuality.CraftAndTerrain:
				reflectionOptions.Layers = -1543503869;
				reflectionOptions.Resolution = 512;
				break;
			case WaterQualitySettings.ReflectionQuality.CraftOnly:
				reflectionOptions.Layers = -2147483645;
				reflectionOptions.Resolution = 256;
				break;
			}
			if (Game.InFlightScene)
			{
				base.gameObject.SetActive(quality != WaterQualitySettings.ReflectionQuality.None && !_mapViewManager.IsInForeground);
			}
			else
			{
				base.gameObject.SetActive(quality != WaterQualitySettings.ReflectionQuality.None);
			}
		}

		private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
		{
			Vector3 point = pos + normal * _reflectionOptions.ClipPlaneOffset;
			Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
			Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
			Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
			return new Vector4(rhs.x, rhs.y, rhs.z, 0f - Vector3.Dot(lhs, rhs));
		}

		private RenderTexture GetReflectionTexture(int size)
		{
			RenderTexture renderTexture = _reflectionTexture;
			if (renderTexture == null || _reflectionTextureCurrentSize != size)
			{
				if (renderTexture != null)
				{
					UnityEngine.Object.Destroy(renderTexture);
				}
				renderTexture = new RenderTexture(size, size, 16, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
				renderTexture.name = "WaterReflectionTexture_" + GetInstanceID();
				renderTexture.isPowerOfTwo = true;
				renderTexture.hideFlags = HideFlags.DontSave;
				_reflectionTexture = renderTexture;
				_reflectionTextureCurrentSize = size;
			}
			return renderTexture;
		}

		private void InitializeReflectionCamera(Camera main)
		{
			Camera camera = new GameObject("WaterReflectionCamera").AddComponent<Camera>();
			camera.transform.SetParent(base.transform, worldPositionStays: false);
			camera.enabled = false;
			camera.allowDynamicResolution = main.allowDynamicResolution;
			camera.allowHDR = main.allowHDR;
			camera.allowMSAA = main.allowMSAA;
			camera.aspect = main.aspect;
			camera.backgroundColor = main.backgroundColor;
			camera.clearFlags = CameraClearFlags.Skybox;
			camera.depthTextureMode = DepthTextureMode.None;
			camera.fieldOfView = main.fieldOfView;
			camera.renderingPath = main.renderingPath;
			camera.useOcclusionCulling = main.useOcclusionCulling;
			_reflectionCamera = camera;
		}

		private void OnMapViewForegroundStateChanged(bool foreground)
		{
			SetEnabled(!foreground);
		}

		private void OnUnderWaterStateChanged(bool underWater)
		{
			SetEnabled(!underWater);
		}

		private void OnWaterQualityChanged(object sender, SettingsChangedEventArgs<WaterQualitySettings> e)
		{
			ApplyQualitySettings(e.Category.Reflections);
		}

		private void SetEnabled(bool enabled)
		{
			if (enabled)
			{
				ApplyQualitySettings(Game.Instance.QualitySettings.Water.Reflections);
			}
			else
			{
				ApplyQualitySettings(WaterQualitySettings.ReflectionQuality.None);
			}
		}

		private void UpdateReflections(Vector3 position, Vector3 normal)
		{
			WaterReflectionOptions reflectionOptions = _reflectionOptions;
			int pixelLightCount = QualitySettings.pixelLightCount;
			if (!reflectionOptions.PixelLights)
			{
				QualitySettings.pixelLightCount = 0;
			}
			float farClipPlane = _mainCamera.farClipPlane;
			try
			{
				float num = RenderSettings.skybox.GetFloat("_Rotation");
				RenderSettings.skybox.SetFloat("_Rotation", num + (float)(_referenceFrame.RotationAngle * 57.29578));
				Camera reflectionCamera = _reflectionCamera;
				RenderTexture value = (reflectionCamera.targetTexture = GetReflectionTexture(reflectionOptions.Resolution));
				reflectionCamera.cullingMask = reflectionOptions.Layers.value;
				reflectionCamera.fieldOfView = _mainCamera.fieldOfView;
				_mainCamera.farClipPlane = reflectionOptions.FarClipPlane;
				UpdateReflections(position, normal, reflectionCamera);
				Shader.SetGlobalTexture("_WaterReflectionTexture", value);
				RenderSettings.skybox.SetFloat("_Rotation", num);
			}
			finally
			{
				_mainCamera.farClipPlane = farClipPlane;
				if (!reflectionOptions.PixelLights)
				{
					QualitySettings.pixelLightCount = pixelLightCount;
				}
			}
		}

		private void UpdateReflections(Vector3 position, Vector3 normal, Camera cam)
		{
			float w = 0f - Vector3.Dot(normal, position) - _reflectionOptions.ClipPlaneOffset;
			Vector4 plane = new Vector4(normal.x, normal.y, normal.z, w);
			Matrix4x4 matrix = Matrix4x4.zero;
			CalculateReflectionMatrix(ref matrix, plane);
			Vector3 position2 = matrix.MultiplyPoint(_mainCameraTransform.position);
			cam.worldToCameraMatrix = _mainCamera.worldToCameraMatrix * matrix;
			Vector4 clipPlane = CameraSpacePlane(cam, position, normal, 1f);
			Matrix4x4 projection = _mainCamera.projectionMatrix;
			CalculateObliqueMatrix(ref projection, clipPlane);
			cam.projectionMatrix = projection;
			cam.transform.position = position2;
			cam.CalculateFrustumCorners(cam.rect, 0f, Camera.MonoOrStereoscopicEye.Mono, _tempFrustumCorners);
			if (!Utilities.IsNan(_tempFrustumCorners[0]) && !Utilities.IsNan(_tempFrustumCorners[1]) && !Utilities.IsNan(_tempFrustumCorners[2]) && !Utilities.IsNan(_tempFrustumCorners[3]))
			{
				GL.invertCulling = true;
				cam.Render();
				GL.invertCulling = false;
			}
		}
	}
}
