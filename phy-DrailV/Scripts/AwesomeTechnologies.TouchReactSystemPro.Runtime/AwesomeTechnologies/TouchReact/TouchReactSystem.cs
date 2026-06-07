using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AwesomeTechnologies.TouchReact
{
	[HelpURL("http://www.awesometech.no/index.php/home/vegetation-studio/components/touch-bend-system")]
	[ExecuteInEditMode]
	public class TouchReactSystem : MonoBehaviour
	{
		public Vector3 Rotation;

		public static TouchReactSystem Instance;

		public Camera TouchReactCamera;

		public Camera SelectedCamera;

		public bool AutoselectCamera = true;

		public float CameraYPosition = -1000f;

		private Material _touchReactMaterial;

		private Material _touchreactMaterialInstanced;

		private MaterialPropertyBlock _touchreactMaterialPropertyBlock;

		public TouchReactQuality TouchReactQuality = TouchReactQuality.Normal;

		public int OrthographicSize = 50;

		public float Speed = 2f;

		public bool ShowDebugColliders;

		public bool HideTouchReactCamera = true;

		private Mesh _sphereColliderMesh;

		private Mesh _boxColliderMesh;

		private RenderTexture _currentTouchRenderTexture;

		private RenderTexture _lastFrameTouchRenderTexture;

		private Material _blendBufferMaterial;

		public List<TouchColliderInfo> ColliderList = new List<TouchColliderInfo>();

		public List<MeshFilter> MeshFilterList = new List<MeshFilter>();

		private readonly List<CapsuleColliderInfo> _capsuleColliderMeshList = new List<CapsuleColliderInfo>();

		private Vector2 _uvOffset;

		private static readonly int SpeedID = Shader.PropertyToID("_Speed");

		private static readonly int OffsetVid = Shader.PropertyToID("_offsetV");

		private static readonly int OffsetUid = Shader.PropertyToID("_offsetU");

		private Camera _currentCamera;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			ColliderList.Clear();
			MeshFilterList.Clear();
		}

		private void OnEnable()
		{
			CreateColliderPrimitives();
			Init();
		}

		private void OnDisable()
		{
			if ((bool)TouchReactCamera)
			{
				TouchReactCamera.enabled = false;
			}
			if ((bool)TouchReactCamera)
			{
				TouchReactCamera.targetTexture = null;
				if ((bool)_currentTouchRenderTexture)
				{
					UnityEngine.Object.DestroyImmediate(_currentTouchRenderTexture);
				}
				if ((bool)_lastFrameTouchRenderTexture)
				{
					UnityEngine.Object.DestroyImmediate(_lastFrameTouchRenderTexture);
				}
			}
		}

		private void CreateColliderPrimitives()
		{
			_capsuleColliderMeshList.Clear();
			_sphereColliderMesh = CreateSphereMesh();
			_boxColliderMesh = CreateBoxMesh();
		}

		public int GetTouchReactQualityPixelResolution(TouchReactQuality touchReactQuality)
		{
			switch (touchReactQuality)
			{
			case TouchReactQuality.Low:
				return 512;
			case TouchReactQuality.Normal:
				return 1024;
			case TouchReactQuality.High:
				return 2048;
			default:
				return 1024;
			}
		}

		public void UpdateCamera()
		{
			if ((bool)TouchReactCamera)
			{
				TouchReactCamera.orthographicSize = OrthographicSize;
				int touchReactQualityPixelResolution = GetTouchReactQualityPixelResolution(TouchReactQuality);
				if ((bool)_currentTouchRenderTexture)
				{
					UnityEngine.Object.DestroyImmediate(_currentTouchRenderTexture);
				}
				if ((bool)_lastFrameTouchRenderTexture)
				{
					UnityEngine.Object.DestroyImmediate(_lastFrameTouchRenderTexture);
				}
				_currentTouchRenderTexture = new RenderTexture(touchReactQualityPixelResolution, touchReactQualityPixelResolution, 24, RenderTextureFormat.RGFloat, RenderTextureReadWrite.Linear)
				{
					wrapMode = TextureWrapMode.Clamp,
					filterMode = FilterMode.Point,
					autoGenerateMips = false,
					hideFlags = HideFlags.DontSave
				};
				_lastFrameTouchRenderTexture = new RenderTexture(touchReactQualityPixelResolution, touchReactQualityPixelResolution, 24, RenderTextureFormat.RGFloat, RenderTextureReadWrite.Linear)
				{
					wrapMode = TextureWrapMode.Clamp,
					filterMode = FilterMode.Point,
					autoGenerateMips = false,
					hideFlags = HideFlags.DontSave
				};
				_blendBufferMaterial = (Material)Resources.Load("BlendTouchReactBuffer", typeof(Material));
				TouchReactCamera.targetTexture = _currentTouchRenderTexture;
			}
		}

		private Mesh GetCapsuleColliderMesh(float radius, float height)
		{
			for (int i = 0; i <= _capsuleColliderMeshList.Count - 1; i++)
			{
				if (Math.Abs(_capsuleColliderMeshList[i].Radius - radius) < 0.01f && Math.Abs(_capsuleColliderMeshList[i].Height - height) < 0.01f)
				{
					return _capsuleColliderMeshList[i].CapsuleColliderMesh;
				}
			}
			CapsuleColliderInfo capsuleColliderInfo = new CapsuleColliderInfo
			{
				Radius = radius,
				Height = height,
				CapsuleColliderMesh = CreateCapsuleMesh(radius, height)
			};
			_capsuleColliderMeshList.Add(capsuleColliderInfo);
			return capsuleColliderInfo.CapsuleColliderMesh;
		}

		public static Mesh CreateBoxMesh(float length = 1f, float width = 1f, float height = 1f)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			Vector3 vector = new Vector3((0f - length) * 0.5f, (0f - width) * 0.5f, height * 0.5f);
			Vector3 vector2 = new Vector3(length * 0.5f, (0f - width) * 0.5f, height * 0.5f);
			Vector3 vector3 = new Vector3(length * 0.5f, (0f - width) * 0.5f, (0f - height) * 0.5f);
			Vector3 vector4 = new Vector3((0f - length) * 0.5f, (0f - width) * 0.5f, (0f - height) * 0.5f);
			Vector3 vector5 = new Vector3((0f - length) * 0.5f, width * 0.5f, height * 0.5f);
			Vector3 vector6 = new Vector3(length * 0.5f, width * 0.5f, height * 0.5f);
			Vector3 vector7 = new Vector3(length * 0.5f, width * 0.5f, (0f - height) * 0.5f);
			Vector3 vector8 = new Vector3((0f - length) * 0.5f, width * 0.5f, (0f - height) * 0.5f);
			Vector3[] vertices = new Vector3[24]
			{
				vector, vector2, vector3, vector4, vector8, vector5, vector, vector4, vector5, vector6,
				vector2, vector, vector7, vector8, vector4, vector3, vector6, vector7, vector3, vector2,
				vector8, vector7, vector6, vector5
			};
			Vector3 up = Vector3.up;
			Vector3 down = Vector3.down;
			Vector3 forward = Vector3.forward;
			Vector3 back = Vector3.back;
			Vector3 left = Vector3.left;
			Vector3 right = Vector3.right;
			Vector3[] normals = new Vector3[24]
			{
				down, down, down, down, left, left, left, left, forward, forward,
				forward, forward, back, back, back, back, right, right, right, right,
				up, up, up, up
			};
			Vector2 vector9 = new Vector2(0f, 0f);
			Vector2 vector10 = new Vector2(1f, 0f);
			Vector2 vector11 = new Vector2(0f, 1f);
			Vector2 vector12 = new Vector2(1f, 1f);
			Vector2[] uv = new Vector2[24]
			{
				vector12, vector11, vector9, vector10, vector12, vector11, vector9, vector10, vector12, vector11,
				vector9, vector10, vector12, vector11, vector9, vector10, vector12, vector11, vector9, vector10,
				vector12, vector11, vector9, vector10
			};
			int[] triangles = new int[36]
			{
				3, 1, 0, 3, 2, 1, 7, 5, 4, 7,
				6, 5, 11, 9, 8, 11, 10, 9, 15, 13,
				12, 15, 14, 13, 19, 17, 16, 19, 18, 17,
				23, 21, 20, 23, 22, 21
			};
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.uv = uv;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Mesh CreateCapsuleMesh(float radius, float height)
		{
			int num = 24;
			if (num % 2 != 0)
			{
				num++;
			}
			int num2 = num + 1;
			float[] array = new float[num2];
			float[] array2 = new float[num2];
			float[] array3 = new float[num2];
			float[] array4 = new float[num2];
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < num2; i++)
			{
				array[i] = Mathf.Sin(num3 * ((float)Math.PI / 180f));
				array2[i] = Mathf.Cos(num3 * ((float)Math.PI / 180f));
				array3[i] = Mathf.Cos(num4 * ((float)Math.PI / 180f));
				array4[i] = Mathf.Sin(num4 * ((float)Math.PI / 180f));
				num3 += 360f / (float)num;
				num4 += 180f / (float)num;
			}
			Vector3[] array5 = new Vector3[num2 * (num2 + 1)];
			Vector2[] array6 = new Vector2[array5.Length];
			int num5 = 0;
			float num6 = (height - radius * 2f) * 0.5f;
			if (num6 < 0f)
			{
				num6 = 0f;
			}
			float num7 = 1f / (float)(num2 - 1);
			int num8 = Mathf.CeilToInt((float)num2 * 0.5f);
			for (int j = 0; j < num8; j++)
			{
				for (int k = 0; k < num2; k++)
				{
					array5[num5] = new Vector3(array[k] * array4[j], array3[j], array2[k] * array4[j]) * radius;
					array5[num5].y = num6 + array5[num5].y;
					float x = 1f - num7 * (float)k;
					float y = (array5[num5].y + height * 0.5f) / height;
					array6[num5] = new Vector2(x, y);
					num5++;
				}
			}
			for (int l = Mathf.FloorToInt((float)num2 * 0.5f); l < num2; l++)
			{
				for (int m = 0; m < num2; m++)
				{
					array5[num5] = new Vector3(array[m] * array4[l], array3[l], array2[m] * array4[l]) * radius;
					array5[num5].y = 0f - num6 + array5[num5].y;
					float x = 1f - num7 * (float)m;
					float y = (array5[num5].y + height * 0.5f) / height;
					array6[num5] = new Vector2(x, y);
					num5++;
				}
			}
			int[] array7 = new int[num * (num + 1) * 2 * 3];
			int n = 0;
			int num9 = 0;
			for (; n < num + 1; n++)
			{
				int num10 = 0;
				while (num10 < num)
				{
					array7[num9] = n * (num + 1) + num10;
					array7[num9 + 1] = (n + 1) * (num + 1) + num10;
					array7[num9 + 2] = (n + 1) * (num + 1) + num10 + 1;
					array7[num9 + 3] = n * (num + 1) + num10 + 1;
					array7[num9 + 4] = n * (num + 1) + num10;
					array7[num9 + 5] = (n + 1) * (num + 1) + num10 + 1;
					num10++;
					num9 += 6;
				}
			}
			Mesh mesh = new Mesh();
			mesh.Clear();
			mesh.name = "ProceduralCapsule";
			mesh.vertices = array5;
			mesh.uv = array6;
			mesh.triangles = array7;
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			return mesh;
		}

		public static Mesh CreateSphereMesh(float radius = 1f)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			int num = 24;
			int num2 = 16;
			Vector3[] array = new Vector3[(num + 1) * num2 + 2];
			float num3 = (float)Math.PI;
			float num4 = num3 * 2f;
			array[0] = Vector3.up * radius;
			for (int i = 0; i < num2; i++)
			{
				float f = num3 * (float)(i + 1) / (float)(num2 + 1);
				float num5 = Mathf.Sin(f);
				float y = Mathf.Cos(f);
				for (int j = 0; j <= num; j++)
				{
					float f2 = num4 * (float)((j != num) ? j : 0) / (float)num;
					float num6 = Mathf.Sin(f2);
					float num7 = Mathf.Cos(f2);
					array[j + i * (num + 1) + 1] = new Vector3(num5 * num7, y, num5 * num6) * radius;
				}
			}
			array[array.Length - 1] = Vector3.up * (0f - radius);
			Vector3[] array2 = new Vector3[array.Length];
			for (int k = 0; k < array.Length; k++)
			{
				array2[k] = array[k].normalized;
			}
			Vector2[] array3 = new Vector2[array.Length];
			array3[0] = Vector2.up;
			array3[array3.Length - 1] = Vector2.zero;
			for (int l = 0; l < num2; l++)
			{
				for (int m = 0; m <= num; m++)
				{
					array3[m + l * (num + 1) + 1] = new Vector2((float)m / (float)num, 1f - (float)(l + 1) / (float)(num2 + 1));
				}
			}
			int[] array4 = new int[array.Length * 2 * 3];
			int num8 = 0;
			for (int n = 0; n < num; n++)
			{
				array4[num8++] = n + 2;
				array4[num8++] = n + 1;
				array4[num8++] = 0;
			}
			for (int num9 = 0; num9 < num2 - 1; num9++)
			{
				for (int num10 = 0; num10 < num; num10++)
				{
					int num11 = num10 + num9 * (num + 1) + 1;
					int num12 = num11 + num + 1;
					array4[num8++] = num11;
					array4[num8++] = num11 + 1;
					array4[num8++] = num12 + 1;
					array4[num8++] = num11;
					array4[num8++] = num12 + 1;
					array4[num8++] = num12;
				}
			}
			for (int num13 = 0; num13 < num; num13++)
			{
				array4[num8++] = array.Length - 1;
				array4[num8++] = array.Length - (num13 + 2) - 1;
				array4[num8++] = array.Length - (num13 + 1) - 1;
			}
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.uv = array3;
			mesh.triangles = array4;
			mesh.RecalculateBounds();
			return mesh;
		}

		private void Update()
		{
			if ((bool)TouchReactCamera && (bool)SelectedCamera)
			{
				Vector3 position = TouchReactCamera.transform.position;
				Vector3 cameraPosition = GetCameraPosition();
				cameraPosition.x = SnapToPixel(cameraPosition.x, TouchReactCamera.targetTexture.width, TouchReactCamera.orthographicSize);
				cameraPosition.y = 0f;
				cameraPosition.z = SnapToPixel(cameraPosition.z, TouchReactCamera.targetTexture.height, TouchReactCamera.orthographicSize);
				TouchReactCamera.transform.position = cameraPosition;
				Vector3 vector = cameraPosition - position;
				_uvOffset = new Vector2(vector.x / (float)(OrthographicSize * 2), vector.z / (float)(OrthographicSize * 2));
			}
			PrepareRenderTexture();
			DrawColliders();
			DrawMeshfilters();
			UpdateShaders();
			CompleteRenderTexture();
		}

		private void PrepareRenderTexture()
		{
			RenderTexture lastFrameTouchRenderTexture = _lastFrameTouchRenderTexture;
			_lastFrameTouchRenderTexture = _currentTouchRenderTexture;
			_currentTouchRenderTexture = lastFrameTouchRenderTexture;
			TouchReactCamera.targetTexture = _currentTouchRenderTexture;
			_currentCamera = Camera.current;
			Camera.SetupCurrent(TouchReactCamera);
			Graphics.SetRenderTarget(_currentTouchRenderTexture);
			GL.Viewport(new Rect(0f, 0f, TouchReactCamera.targetTexture.width, TouchReactCamera.targetTexture.height));
			GL.Clear(clearDepth: true, clearColor: true, TouchReactCamera.backgroundColor, 1f);
			if ((bool)_blendBufferMaterial)
			{
				_blendBufferMaterial.SetFloat(OffsetUid, _uvOffset.x);
				_blendBufferMaterial.SetFloat(OffsetVid, 0f - _uvOffset.y);
				_blendBufferMaterial.SetFloat(SpeedID, Speed);
				Graphics.Blit(_lastFrameTouchRenderTexture, _currentTouchRenderTexture, _blendBufferMaterial);
			}
			GL.PushMatrix();
			GL.LoadProjectionMatrix(TouchReactCamera.projectionMatrix);
			GL.PushMatrix();
			_touchReactMaterial.SetPass(0);
		}

		private void CompleteRenderTexture()
		{
			GL.PopMatrix();
			GL.PopMatrix();
			Graphics.ClearRandomWriteTargets();
			Camera.SetupCurrent(_currentCamera);
		}

		private void UpdateShaders()
		{
			Shader.SetGlobalTexture("_TouchReact_Buffer", TouchReactCamera.targetTexture);
			Vector4 value = TouchReactCamera.transform.position;
			value.z = 0f - value.z;
			value.w = TouchReactCamera.orthographicSize * 2f;
			value.x -= TouchReactCamera.orthographicSize;
			value.z -= TouchReactCamera.orthographicSize;
			Shader.SetGlobalVector("_TouchReact_Pos", value);
		}

		private float SnapToPixel(float v, int textureSize, float orthoSize)
		{
			float num = orthoSize * 2f / (float)textureSize;
			v = (int)(v / num);
			v *= num;
			return v;
		}

		private void DrawColliders()
		{
			for (int i = 0; i <= ColliderList.Count - 1; i++)
			{
				Collider collider = ColliderList[i].Collider;
				if (collider is MeshCollider)
				{
					DrawMeshCollider(collider as MeshCollider);
				}
				else if (collider is SphereCollider)
				{
					DrawSphereCollider(collider as SphereCollider, ColliderList[i].Scale);
				}
				else if (collider is BoxCollider)
				{
					DrawBoxCollider(collider as BoxCollider, ColliderList[i].Scale);
				}
				else if (collider is CapsuleCollider)
				{
					DrawCapsuleCollider(collider as CapsuleCollider, ColliderList[i].Scale);
				}
			}
		}

		private void DrawMeshfilters()
		{
			for (int i = 0; i <= MeshFilterList.Count - 1; i++)
			{
				DrawMeshfilter(MeshFilterList[i]);
			}
		}

		private void DrawBoxCollider(BoxCollider boxCollider, float scale)
		{
			Matrix4x4 matrix = Matrix4x4.TRS(s: new Vector3(boxCollider.size.x * boxCollider.transform.lossyScale.x, boxCollider.size.y * boxCollider.transform.lossyScale.y, boxCollider.size.z * boxCollider.transform.lossyScale.z) * scale, pos: boxCollider.bounds.center, q: boxCollider.transform.rotation);
			if (ShowDebugColliders)
			{
				Graphics.DrawMesh(_boxColliderMesh, matrix, _touchReactMaterial, 0, null);
			}
			Graphics.DrawMeshNow(_boxColliderMesh, matrix, 0);
		}

		private void DrawCapsuleCollider(CapsuleCollider capsuleCollider, float scale)
		{
			Mesh capsuleColliderMesh = GetCapsuleColliderMesh(capsuleCollider.radius, capsuleCollider.height);
			Vector3 euler = Vector3.zero;
			if (capsuleCollider.direction == 0)
			{
				euler = new Vector3(0f, 0f, 90f);
			}
			if (capsuleCollider.direction == 2)
			{
				euler = new Vector3(90f, 0f, 0f);
			}
			Matrix4x4 matrix = Matrix4x4.TRS(capsuleCollider.bounds.center, capsuleCollider.transform.rotation * Quaternion.Euler(euler), capsuleCollider.transform.lossyScale * scale);
			if (ShowDebugColliders)
			{
				Graphics.DrawMesh(capsuleColliderMesh, matrix, _touchReactMaterial, 0, null);
			}
			Graphics.DrawMeshNow(capsuleColliderMesh, matrix, 0);
		}

		private void DrawSphereCollider(SphereCollider sphereCollider, float scale)
		{
			float maxValue = GetMaxValue(sphereCollider.transform.lossyScale);
			Matrix4x4 matrix = Matrix4x4.TRS(s: new Vector3(maxValue, maxValue, maxValue) * sphereCollider.radius * scale, pos: sphereCollider.bounds.center, q: sphereCollider.transform.rotation);
			if (ShowDebugColliders)
			{
				Graphics.DrawMesh(_sphereColliderMesh, matrix, _touchReactMaterial, 0, null);
			}
			Graphics.DrawMeshNow(_sphereColliderMesh, matrix, 0);
		}

		private void DrawMeshCollider(MeshCollider meshCollider)
		{
			Matrix4x4 matrix = Matrix4x4.TRS(meshCollider.transform.position, meshCollider.transform.rotation, meshCollider.transform.lossyScale);
			Mesh sharedMesh = meshCollider.sharedMesh;
			if ((bool)sharedMesh)
			{
				if (ShowDebugColliders)
				{
					Graphics.DrawMesh(sharedMesh, matrix, _touchReactMaterial, 0, null);
				}
				Graphics.DrawMeshNow(sharedMesh, matrix, 0);
			}
		}

		private float GetMaxValue(Vector3 vector)
		{
			float num = float.MinValue;
			if (num < vector.x)
			{
				num = vector.x;
			}
			if (num < vector.y)
			{
				num = vector.y;
			}
			if (num < vector.z)
			{
				num = vector.z;
			}
			return num;
		}

		private void DrawMeshfilter(MeshFilter meshfilter)
		{
			Matrix4x4 matrix = Matrix4x4.TRS(meshfilter.transform.position, meshfilter.transform.rotation, meshfilter.transform.lossyScale);
			Mesh sharedMesh = meshfilter.sharedMesh;
			if ((bool)sharedMesh)
			{
				if (ShowDebugColliders)
				{
					Graphics.DrawMesh(sharedMesh, matrix, _touchReactMaterial, 0, null);
				}
				Graphics.DrawMeshNow(sharedMesh, matrix, 0);
			}
		}

		public void Init()
		{
			if ((bool)TouchReactCamera)
			{
				TouchReactCamera.enabled = false;
			}
			if (!TouchReactCamera)
			{
				CreateTouchReactCamera();
			}
			UpdateTouchReactCamera();
			FindCamera();
			SetupMaterial();
			UpdateCamera();
		}

		private void FindCamera()
		{
			if (AutoselectCamera)
			{
				SelectedCamera = Camera.main;
			}
			if (SelectedCamera == TouchReactCamera)
			{
				SelectedCamera = null;
			}
			if (!(SelectedCamera == null))
			{
				return;
			}
			Camera[] array = UnityEngine.Object.FindObjectsOfType<Camera>();
			for (int i = 0; i <= array.Length - 1; i++)
			{
				if (array[i].gameObject.name.Contains("Main Camera") || array[i].gameObject.name.Contains("MainCamera"))
				{
					SelectedCamera = array[i];
					break;
				}
			}
			if (!(SelectedCamera == null))
			{
				return;
			}
			for (int j = 0; j <= array.Length - 1; j++)
			{
				if (array[j] != TouchReactCamera)
				{
					SelectedCamera = array[j];
					break;
				}
			}
		}

		public void UpdateTouchReactCamera()
		{
			if ((bool)TouchReactCamera && HideTouchReactCamera)
			{
				TouchReactCamera.gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			else
			{
				TouchReactCamera.gameObject.hideFlags = HideFlags.None;
			}
		}

		private void SetupMaterial()
		{
			_touchReactMaterial = new Material(Shader.Find("AwesomeTechnologies/TouchReact/RenderTouchBuffer"))
			{
				enableInstancing = true
			};
			_touchreactMaterialInstanced = new Material(Shader.Find("AwesomeTechnologies/TouchReact/RenderTouchBufferInstanced"))
			{
				enableInstancing = true
			};
			_touchreactMaterialPropertyBlock = new MaterialPropertyBlock();
		}

		private void CreateTouchReactCamera()
		{
			Transform transform = base.transform.Find("TouchReactCamera");
			if (!transform)
			{
				GameObject obj = new GameObject("TouchReactCamera");
				obj.transform.SetParent(base.transform, worldPositionStays: false);
				obj.transform.position = Vector3.zero;
				obj.transform.rotation = Quaternion.LookRotation(Vector3.up);
				Camera camera = obj.AddComponent<Camera>();
				camera.farClipPlane = 10000f;
				camera.nearClipPlane = -10000f;
				camera.depth = -100f;
				camera.clearFlags = CameraClearFlags.Color;
				camera.backgroundColor = Color.black;
				camera.renderingPath = RenderingPath.Forward;
				camera.useOcclusionCulling = true;
				camera.orthographic = true;
				camera.orthographicSize = 50f;
				camera.allowMSAA = false;
				camera.allowHDR = false;
				camera.stereoTargetEye = StereoTargetEyeMask.None;
				TouchReactCamera = camera;
			}
			else
			{
				TouchReactCamera = transform.gameObject.GetComponent<Camera>();
			}
			TouchReactCamera.enabled = false;
		}

		public Vector3 GetCameraPosition()
		{
			if (Application.isPlaying)
			{
				if ((bool)SelectedCamera)
				{
					return SelectedCamera.transform.position;
				}
				return Vector3.zero;
			}
			return Vector3.zero;
		}

		public void InstanceAddCollider(TouchColliderInfo touchColliderInfo)
		{
			if (!ColliderList.Contains(touchColliderInfo))
			{
				ColliderList.Add(touchColliderInfo);
			}
		}

		public void InstanceRemoveCollider(TouchColliderInfo touchColliderInfo)
		{
			ColliderList.Remove(touchColliderInfo);
		}

		public void InstanceAddMeshFilter(MeshFilter meshFilter)
		{
			if (!MeshFilterList.Contains(meshFilter))
			{
				MeshFilterList.Add(meshFilter);
			}
		}

		public void InstanceDrawMeshInstanced(Mesh mesh, List<Matrix4x4> instanceList, int subMeshIndex)
		{
			if ((bool)_touchreactMaterialInstanced)
			{
				if (ShowDebugColliders)
				{
					Graphics.DrawMeshInstanced(mesh, subMeshIndex, _touchreactMaterialInstanced, instanceList, _touchreactMaterialPropertyBlock, ShadowCastingMode.Off, receiveShadows: false, 0, null);
				}
				for (int i = 0; i < instanceList.Count; i++)
				{
					Graphics.DrawMeshNow(mesh, instanceList[i], subMeshIndex);
				}
			}
		}

		public void InstanceRemoveMeshFilter(MeshFilter meshFilter)
		{
			MeshFilterList.Remove(meshFilter);
		}

		public static void FindInstance()
		{
			Instance = UnityEngine.Object.FindObjectOfType<TouchReactSystem>();
		}

		public static void AddCollider(TouchColliderInfo touchColliderInfo)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.InstanceAddCollider(touchColliderInfo);
			}
		}

		public static void RemoveCollider(TouchColliderInfo touchColliderInfo)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.InstanceRemoveCollider(touchColliderInfo);
			}
		}

		public static void AddMeshFilter(MeshFilter mesh)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.InstanceAddMeshFilter(mesh);
			}
		}

		public static void RemoveMeshFilter(MeshFilter mesh)
		{
			if (!Instance)
			{
				FindInstance();
			}
			if ((bool)Instance)
			{
				Instance.InstanceRemoveMeshFilter(mesh);
			}
		}

		public static bool TouchReactEnabled()
		{
			if ((bool)Instance && Instance.isActiveAndEnabled)
			{
				return true;
			}
			return false;
		}

		public static void DrawMeshInstanced(Mesh mesh, List<Matrix4x4> instanceList, int subMeshIndex)
		{
			if ((bool)Instance && Instance.isActiveAndEnabled)
			{
				Instance.InstanceDrawMeshInstanced(mesh, instanceList, subMeshIndex);
			}
		}
	}
}
