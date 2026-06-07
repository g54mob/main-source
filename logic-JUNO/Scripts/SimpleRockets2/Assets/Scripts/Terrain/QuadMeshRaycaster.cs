using System;
using Assets.Scripts.Terrain.Pooling;
using ModApi.Common.DebugUtils;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Terrain
{
	public class QuadMeshRaycaster : MonoBehaviour
	{
		private class QuadMeshRaycast
		{
			public Action<QuadMeshRaycastHit> Callback { get; }

			public AsyncGPUReadbackRequest Request { get; }

			public int StartFrame { get; }

			public QuadMeshRaycast(AsyncGPUReadbackRequest request, Action<QuadMeshRaycastHit> callback)
			{
				Request = request;
				Callback = callback;
				StartFrame = Time.frameCount;
			}
		}

		private QuadMeshRaycast _currentAsyncRaycast;

		private Transform _debugGizmo;

		private bool _debugGizmoEnabled;

		[SerializeField]
		private Camera _farCamera;

		private bool _identifyQuadInResult;

		[SerializeField]
		private Camera _nearCamera;

		[SerializeField]
		private QuadSphereScript _quadSphere;

		private Texture2D _readbackTexture;

		[SerializeField]
		private Camera _renderCamera;

		private bool _renderCameraInitialized;

		[SerializeField]
		private Material _renderMaterial;

		[SerializeField]
		private RenderTexture _renderTexture;

		public bool DebugGizmoEnabled
		{
			get
			{
				return _debugGizmoEnabled;
			}
			set
			{
				_debugGizmoEnabled = value;
				if (!value && _debugGizmo != null)
				{
					UnityEngine.Object.Destroy(_debugGizmo.gameObject);
					_debugGizmo = null;
				}
			}
		}

		public void Initialize(Camera nearCamera, Camera farCamera, bool identifyQuadInResult = true)
		{
			_nearCamera = nearCamera;
			_farCamera = farCamera;
			Material source = Game.Instance.ResourceLoader.LoadMaterial("Planets/Materials/QuadRaycastMaterial");
			_renderMaterial = new Material(source);
			_identifyQuadInResult = identifyQuadInResult;
			if (!identifyQuadInResult)
			{
				_renderMaterial.SetFloat("_QuadId", 1f);
			}
			InitializeCamera();
		}

		public QuadMeshRaycastHit Raycast(Ray ray)
		{
			if (_quadSphere == null)
			{
				return null;
			}
			if (_currentAsyncRaycast != null)
			{
				_currentAsyncRaycast.Request.WaitForCompletion();
			}
			RaycastRender(ray, synchronous: true);
			Vector4 vector = _readbackTexture.GetRawTextureData<Vector4>()[0];
			int quadId = (int)vector.w;
			Vector3 position = new Vector3(vector.x, vector.y, vector.z);
			return CreateRaycastHit(quadId, position);
		}

		public void RaycastAsync(Ray ray, Action<QuadMeshRaycastHit> callback)
		{
			if (_quadSphere == null || _currentAsyncRaycast != null)
			{
				callback?.Invoke(null);
				return;
			}
			RaycastRender(ray, synchronous: false);
			AsyncGPUReadbackRequest request = AsyncGPUReadback.Request(_renderTexture, 0, OnGpuReadbackComplete);
			_currentAsyncRaycast = new QuadMeshRaycast(request, callback);
		}

		public void SetQuadSphere(QuadSphereScript quadSphere)
		{
			_quadSphere = quadSphere;
		}

		protected virtual void OnDestroy()
		{
			UnityEngine.Object.Destroy(_renderCamera);
		}

		private QuadMeshRaycastHit CreateRaycastHit(int quadId, Vector3 position)
		{
			QuadScript quadScript = null;
			if (_identifyQuadInResult && quadId != 0)
			{
				quadScript = QuadSpherePoolManager.Instance.QuadScriptPool.GetById(quadId);
			}
			QuadMeshRaycastHit quadMeshRaycastHit = new QuadMeshRaycastHit(quadId != 0, quadScript, position);
			UpdateDebugGizmo((quadScript == null) ? null : quadMeshRaycastHit);
			return quadMeshRaycastHit;
		}

		private void InitializeCamera()
		{
			if (!_renderCameraInitialized)
			{
				Camera camera = (_renderCamera = new GameObject("QuadMeshRaycastCamera").AddComponent<Camera>());
				camera.transform.SetParent(_nearCamera.transform, worldPositionStays: false);
				camera.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				camera.enabled = false;
				camera.allowDynamicResolution = false;
				camera.allowHDR = false;
				camera.allowMSAA = false;
				camera.backgroundColor = Color.clear;
				camera.clearFlags = CameraClearFlags.Color;
				camera.cullingMask = 603979776;
				camera.depthTextureMode = DepthTextureMode.None;
				camera.useOcclusionCulling = true;
				camera.fieldOfView = 1E-05f;
				camera.orthographic = _nearCamera.orthographic;
				camera.orthographicSize = _nearCamera.orthographicSize;
				if (!_identifyQuadInResult)
				{
					camera.SetReplacementShader(Shader.Find("Jundroo/Terrain Raycast Mask"), null);
				}
				_renderCameraInitialized = true;
			}
		}

		private void OnGpuReadbackComplete(AsyncGPUReadbackRequest request)
		{
			QuadMeshRaycast currentAsyncRaycast = _currentAsyncRaycast;
			_currentAsyncRaycast = null;
			if (request.hasError)
			{
				Debug.LogError("GPU Readback Error");
				currentAsyncRaycast.Callback?.Invoke(null);
				return;
			}
			Vector4 vector = request.GetData<Vector4>()[0];
			int quadId = (int)vector.w;
			Vector3 position = new Vector3(vector.x, vector.y, vector.z);
			QuadMeshRaycastHit obj = CreateRaycastHit(quadId, position);
			currentAsyncRaycast.Callback?.Invoke(obj);
		}

		private void PrepareCamera()
		{
			Camera renderCamera = _renderCamera;
			renderCamera.nearClipPlane = _nearCamera.nearClipPlane;
			renderCamera.farClipPlane = _farCamera.farClipPlane;
		}

		private void PrepareReadbackTexture()
		{
			if (_readbackTexture == null)
			{
				_readbackTexture = new Texture2D(1, 1, TextureFormat.RGBAFloat, mipChain: false, linear: true);
				_readbackTexture.filterMode = FilterMode.Point;
			}
		}

		private void PrepareRenderTexture()
		{
			if (_renderTexture == null || !_renderTexture.IsCreated())
			{
				_renderTexture = new RenderTexture(1, 1, 24, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
				_renderTexture.filterMode = FilterMode.Point;
			}
		}

		private void RaycastRender(Ray ray, bool synchronous)
		{
			PrepareCamera();
			PrepareRenderTexture();
			if (synchronous)
			{
				PrepareReadbackTexture();
			}
			if (_identifyQuadInResult)
			{
				_quadSphere.DrawQuadsForTerrainRaycasting(_renderCamera, _renderMaterial);
			}
			_renderCamera.transform.SetPositionAndRotation(ray.origin, Quaternion.LookRotation(ray.direction));
			_renderCamera.targetTexture = _renderTexture;
			_renderCamera.Render();
			_renderCamera.targetTexture = null;
			if (synchronous)
			{
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = _renderTexture;
				_readbackTexture.ReadPixels(new Rect(0f, 0f, 1f, 1f), 0, 0);
				RenderTexture.active = active;
			}
		}

		private void UpdateDebugGizmo(QuadMeshRaycastHit hit)
		{
			if (!_debugGizmoEnabled)
			{
				return;
			}
			if (hit == null)
			{
				if (_debugGizmo != null)
				{
					_debugGizmo.gameObject.SetActive(value: false);
				}
				return;
			}
			Vector3 framePosition = hit.FramePosition;
			if (_debugGizmo == null)
			{
				_debugGizmo = DebugUtility.CreatePrimitive("QuadMeshRaycastHit", PrimitiveType.Sphere, Color.red, framePosition, null, colliderEnabled: false).transform;
			}
			_debugGizmo.gameObject.SetActive(value: true);
			float num = (framePosition - base.transform.position).magnitude / 100f;
			_debugGizmo.position = framePosition;
			_debugGizmo.localScale = new Vector3(num, num, num);
		}
	}
}
