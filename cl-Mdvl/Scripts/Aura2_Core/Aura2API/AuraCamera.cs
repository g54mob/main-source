using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aura2API
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Aura 2/Aura Camera", 0)]
	[ExecuteInEditMode]
	public class AuraCamera : MonoBehaviour
	{
		public FrustumSettings frustumSettings;

		private Shader _postProcessShader;

		private Texture2DArray _blueNoiseTexturesArray;

		public Frustum _frustum;

		private Camera _cameraComponent;

		private Material _postProcessMaterial;

		private static CommonDataManager _commonDataManager;

		private static List<AuraCamera> _registeredAuraCamerasList = new List<AuraCamera>();

		public Camera CameraComponent
		{
			get
			{
				if (_cameraComponent == null)
				{
					_cameraComponent = GetComponent<Camera>();
				}
				return _cameraComponent;
			}
		}

		public static CommonDataManager CommonDataManager
		{
			get
			{
				if (_commonDataManager == null)
				{
					_commonDataManager = new CommonDataManager();
				}
				return _commonDataManager;
			}
		}

		public int FrameId { get; private set; }

		public static float Time => UnityEngine.Time.time;

		public static float DeltaTtime => UnityEngine.Time.deltaTime;

		public bool IsInitialized { get; private set; }

		public static bool HasRegisteredAuraCameras => _registeredAuraCamerasList.Count > 0;

		public static event Action OnRegisteredAuraCamerasListChanged;

		private void OnEnable()
		{
			if (!Aura.IsCompatible)
			{
				base.enabled = false;
			}
			else
			{
				Initialize();
			}
		}

		private void OnDisable()
		{
			try
			{
				Uninitialize();
			}
			catch
			{
			}
		}

		[ImageEffectOpaque]
		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			try
			{
				if (IsInitialized)
				{
					CommonDataManager.UpdateData();
					Shader.SetGlobalInt("_frameID", FrameId);
					_frustum.ComputeData();
					int frameId = FrameId + 1;
					FrameId = frameId;
					Graphics.Blit(src, dest, _postProcessMaterial);
				}
				else
				{
					Graphics.Blit(src, dest);
				}
			}
			catch
			{
				Graphics.Blit(src, dest);
			}
			GL.Flush();
		}

		public void SetFrustumGridResolution(Vector3Int resolution)
		{
			_frustum.SetFrustumGridResolution(resolution);
		}

		public void SetLightProbesProxyGridResolution(Vector3Int resolution)
		{
			throw new NotImplementedException();
		}

		private static void Register(AuraCamera auraCamera)
		{
			_registeredAuraCamerasList.Add(auraCamera);
			FireOnRegisteredAuraCamerasListChanged();
		}

		private static void Unregister(AuraCamera auraCamera)
		{
			_registeredAuraCamerasList.Remove(auraCamera);
			FireOnRegisteredAuraCamerasListChanged();
		}

		public static bool IsFirstRegisteredCamera(Camera camera)
		{
			return camera == _registeredAuraCamerasList[0].CameraComponent;
		}

		private static void FireOnRegisteredAuraCamerasListChanged()
		{
			if (AuraCamera.OnRegisteredAuraCamerasListChanged != null)
			{
				AuraCamera.OnRegisteredAuraCamerasListChanged();
			}
		}

		private void Initialize()
		{
			InitializeResources();
			CameraComponent.depthTextureMode |= DepthTextureMode.Depth;
			if (frustumSettings == null)
			{
				frustumSettings = new FrustumSettings();
			}
			_frustum = new Frustum(frustumSettings, _cameraComponent, this);
			_postProcessMaterial = new Material(_postProcessShader);
			Shader.SetGlobalTexture("_blueNoiseTexturesArray", _blueNoiseTexturesArray);
			Shader.EnableKeyword("AURA");
			Register(this);
			IsInitialized = true;
		}

		private void Uninitialize()
		{
			if (IsInitialized)
			{
				Shader.DisableKeyword("AURA");
				_frustum.Dispose();
				_frustum = null;
				CommonDataManager.Dispose();
				Unregister(this);
				IsInitialized = false;
			}
		}

		private void InitializeResources()
		{
			_postProcessShader = Aura.ResourcesCollection.postProcessShader;
			_blueNoiseTexturesArray = Aura.ResourcesCollection.blueNoiseTextureArray;
		}

		public static GameObject CreateGameObject(string name)
		{
			GameObject obj = new GameObject(name);
			obj.AddComponent<Camera>();
			obj.AddComponent<AuraCamera>();
			return obj;
		}
	}
}
