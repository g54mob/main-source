using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class EditorPrefabPreviewGen
	{
		private enum PreviewObjectType
		{
			Mesh = 1,
			Sprite = 2,
			Light = 3,
			ParticleSystem = 4,
			Other = 5
		}

		private PrefabPreviewLookAndFeel _previewLookAndFeel;

		private ObjectBounds.QueryConfig _boundsQConfig;

		private Light _previewLight;

		private Camera _renderCamera;

		private bool _isGenSessionActive;

		private Dictionary<Light, bool> _lightToState = new Dictionary<Light, bool>();

		private GameObject _nonMeshPreviewObject;

		public EditorPrefabPreviewGen()
		{
			_boundsQConfig.ObjectTypes = GameObjectTypeHelper.AllCombined & ~GameObjectType.Terrain;
			_boundsQConfig.NoVolumeSize = Vector3Ex.FromValue(1f);
		}

		public bool BeginGenSession(PrefabPreviewLookAndFeel previewLookAndFeel)
		{
			if (_isGenSessionActive || previewLookAndFeel == null)
			{
				return false;
			}
			DisableSceneLights();
			_previewLookAndFeel = previewLookAndFeel;
			if (!CreateRenderCamera() || !CreatePreviewLight())
			{
				RestoreSceneLights();
				return false;
			}
			CreateNonMeshPreviewObject();
			_isGenSessionActive = true;
			return true;
		}

		public void EndGenSession()
		{
			if (!_isGenSessionActive)
			{
				return;
			}
			if (_renderCamera != null)
			{
				if (_renderCamera.targetTexture != null)
				{
					_renderCamera.targetTexture.Release();
				}
				Object.DestroyImmediate(_renderCamera.gameObject);
			}
			if (_previewLight != null)
			{
				Object.DestroyImmediate(_previewLight.gameObject);
			}
			if (_nonMeshPreviewObject != null)
			{
				Object.DestroyImmediate(_nonMeshPreviewObject);
			}
			RestoreSceneLights();
			_isGenSessionActive = false;
		}

		public Texture2D Generate(GameObject unityPrefab)
		{
			if (!_isGenSessionActive || _renderCamera.targetTexture == null)
			{
				return null;
			}
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = _renderCamera.targetTexture;
			GL.Clear(clearDepth: true, clearColor: true, _previewLookAndFeel.BkColor);
			bool flag = unityPrefab.HierarchyHasMesh();
			bool flag2 = unityPrefab.HierarchyHasSprite();
			PreviewObjectType previewObjectType = PreviewObjectType.Mesh;
			if (!flag && flag2)
			{
				previewObjectType = PreviewObjectType.Sprite;
			}
			else if (!flag && !flag2)
			{
				previewObjectType = (unityPrefab.HierarchyHasObjectsOfType(GameObjectType.Light) ? PreviewObjectType.Light : ((!unityPrefab.HierarchyHasObjectsOfType(GameObjectType.ParticleSystem)) ? PreviewObjectType.Other : PreviewObjectType.ParticleSystem));
			}
			GameObject gameObject = null;
			gameObject = ((previewObjectType != PreviewObjectType.Mesh && previewObjectType != PreviewObjectType.Sprite) ? _nonMeshPreviewObject : Object.Instantiate(unityPrefab));
			Transform transform = gameObject.transform;
			transform.position = Vector3.zero;
			transform.rotation = Quaternion.identity;
			transform.localScale = unityPrefab.transform.lossyScale;
			AABB aabb = MonoSingleton<RTScene>.Get.CalculateBounds();
			Sphere sphere = new Sphere(aabb);
			AABB aABB = default(AABB);
			aABB = ObjectBounds.CalcHierarchyWorldAABB(gameObject, _boundsQConfig);
			Sphere sphere2 = new Sphere(aABB);
			Vector3 vector = sphere.Center - Vector3.right * (sphere.Radius + sphere2.Radius + 90f);
			transform.position += vector - sphere2.Center;
			aABB = ObjectBounds.CalcHierarchyWorldAABB(gameObject, _boundsQConfig);
			sphere2.Center = vector;
			Transform transform2 = _renderCamera.transform;
			if (previewObjectType == PreviewObjectType.Mesh || previewObjectType == PreviewObjectType.Sprite)
			{
				transform2.rotation = Quaternion.identity;
				if (previewObjectType != PreviewObjectType.Sprite)
				{
					transform2.rotation = Quaternion.AngleAxis(-45f, Vector3.up) * Quaternion.AngleAxis(35f, transform2.right);
				}
				transform2.position = sphere2.Center - transform2.forward * (sphere2.Radius * 2f + _renderCamera.nearClipPlane);
			}
			else
			{
				transform2.rotation = transform.rotation;
				transform2.position = sphere2.Center - transform2.forward * (sphere2.Radius * 2f + _renderCamera.nearClipPlane);
				Texture2D value = ((previewObjectType == PreviewObjectType.Light) ? MonoSingleton<RTScene>.Get.LookAndFeel.LightIcon : MonoSingleton<RTScene>.Get.LookAndFeel.ParticleSystemIcon);
				_nonMeshPreviewObject.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", value);
			}
			_previewLight.transform.forward = transform2.forward;
			_renderCamera.Render();
			if (gameObject != _nonMeshPreviewObject)
			{
				Object.DestroyImmediate(gameObject);
			}
			Texture2D texture2D = new Texture2D(_previewLookAndFeel.PreviewWidth, _previewLookAndFeel.PreviewHeight, TextureFormat.ARGB32, mipChain: true, linear: true);
			texture2D.ReadPixels(new Rect(0f, 0f, _previewLookAndFeel.PreviewWidth, _previewLookAndFeel.PreviewHeight), 0, 0);
			texture2D.Apply();
			RenderTexture.active = active;
			return texture2D;
		}

		private bool CreateRenderCamera()
		{
			RenderTexture renderTexture = new RenderTexture(_previewLookAndFeel.PreviewWidth, _previewLookAndFeel.PreviewHeight, 24);
			if (renderTexture == null || !renderTexture.Create())
			{
				return false;
			}
			Camera camera = new GameObject("Render Camera").AddComponent<Camera>();
			camera.backgroundColor = _previewLookAndFeel.BkColor;
			camera.orthographic = false;
			camera.fieldOfView = 65f;
			camera.clearFlags = CameraClearFlags.Color;
			camera.nearClipPlane = 0.0001f;
			camera.targetTexture = renderTexture;
			_renderCamera = camera;
			return true;
		}

		private bool CreatePreviewLight()
		{
			GameObject gameObject = new GameObject("Preview light");
			_previewLight = gameObject.AddComponent<Light>();
			_previewLight.type = LightType.Directional;
			_previewLight.intensity = _previewLookAndFeel.LightIntensity;
			return true;
		}

		private void CreateNonMeshPreviewObject()
		{
			_nonMeshPreviewObject = new GameObject("Non-mesh preview object");
			_nonMeshPreviewObject.AddComponent<MeshRenderer>().sharedMaterial = Singleton<MaterialPool>.Get.TintedTexture;
			_nonMeshPreviewObject.AddComponent<MeshFilter>().sharedMesh = Singleton<MeshPool>.Get.UnitQuadXY;
		}

		private void DisableSceneLights()
		{
			_lightToState.Clear();
			Light[] array = Object.FindObjectsOfType<Light>();
			foreach (Light light in array)
			{
				_lightToState.Add(light, light.enabled);
				light.enabled = false;
			}
		}

		private void RestoreSceneLights()
		{
			foreach (KeyValuePair<Light, bool> item in _lightToState)
			{
				Light key = item.Key;
				if (!(key == null))
				{
					key.enabled = item.Value;
				}
			}
		}
	}
}
