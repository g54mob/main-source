using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class OVROverlayMeshGenerator : MonoBehaviour
{
	private enum CubeFace
	{
		Right = 0,
		Left = 1,
		Top = 2,
		Bottom = 3,
		Front = 4,
		Back = 5,
		COUNT = 6
	}

	private Mesh _Mesh;

	private List<Vector3> _Verts = new List<Vector3>();

	private List<Vector2> _UV = new List<Vector2>();

	private List<int> _Tris = new List<int>();

	private OVROverlay _Overlay;

	private MeshFilter _MeshFilter;

	private MeshCollider _MeshCollider;

	private MeshRenderer _MeshRenderer;

	private Transform _CameraRoot;

	private Transform _Transform;

	private OVROverlay.OverlayShape _LastShape;

	private Vector3 _LastPosition;

	private Quaternion _LastRotation;

	private Vector3 _LastScale;

	private Rect _LastDestRectLeft;

	private Rect _LastDestRectRight;

	private Rect _LastSrcRectLeft;

	private Texture _LastTexture;

	private bool _Awake;

	private static readonly Vector3[] BottomLeft = new Vector3[6]
	{
		new Vector3(-0.5f, -0.5f, -0.5f),
		new Vector3(0.5f, -0.5f, 0.5f),
		new Vector3(0.5f, 0.5f, -0.5f),
		new Vector3(0.5f, -0.5f, 0.5f),
		new Vector3(0.5f, -0.5f, -0.5f),
		new Vector3(-0.5f, -0.5f, 0.5f)
	};

	private static readonly Vector3[] RightVector = new Vector3[6]
	{
		Vector3.forward,
		Vector3.back,
		Vector3.left,
		Vector3.left,
		Vector3.left,
		Vector3.right
	};

	private static readonly Vector3[] UpVector = new Vector3[6]
	{
		Vector3.up,
		Vector3.up,
		Vector3.forward,
		Vector3.back,
		Vector3.up,
		Vector3.up
	};

	protected void Awake()
	{
		_MeshFilter = GetComponent<MeshFilter>();
		_MeshCollider = GetComponent<MeshCollider>();
		_MeshRenderer = GetComponent<MeshRenderer>();
		_Transform = base.transform;
		if ((bool)Camera.main && (bool)Camera.main.transform.parent)
		{
			_CameraRoot = Camera.main.transform.parent;
		}
		_Awake = true;
	}

	public void SetOverlay(OVROverlay overlay)
	{
		_Overlay = overlay;
	}

	private Rect GetBoundingRect(Rect a, Rect b)
	{
		float num = Mathf.Min(a.x, b.x);
		float num2 = Mathf.Max(a.x + a.width, b.x + b.width);
		float num3 = Mathf.Min(a.y, b.y);
		float num4 = Mathf.Max(a.y + a.height, b.y + b.height);
		return new Rect(num, num3, num2 - num, num4 - num3);
	}

	protected void OnEnable()
	{
	}

	protected void OnDisable()
	{
	}

	private void Update()
	{
		if (!Application.isEditor)
		{
			return;
		}
		if (!_Awake)
		{
			Awake();
		}
		if ((bool)_Overlay)
		{
			OVROverlay.OverlayShape currentOverlayShape = _Overlay.currentOverlayShape;
			Vector3 vector = (_CameraRoot ? (_Transform.position - _CameraRoot.position) : _Transform.position);
			Quaternion rotation = _Transform.rotation;
			Vector3 lossyScale = _Transform.lossyScale;
			Rect rect = (_Overlay.overrideTextureRectMatrix ? _Overlay.destRectLeft : new Rect(0f, 0f, 1f, 1f));
			Rect rect2 = (_Overlay.overrideTextureRectMatrix ? _Overlay.destRectRight : new Rect(0f, 0f, 1f, 1f));
			Rect rect3 = (_Overlay.overrideTextureRectMatrix ? _Overlay.srcRectLeft : new Rect(0f, 0f, 1f, 1f));
			Texture texture = _Overlay.textures[0];
			if (_Mesh == null || _LastShape != currentOverlayShape || _LastPosition != vector || _LastRotation != rotation || _LastScale != lossyScale || _LastDestRectLeft != rect || _LastDestRectRight != rect2)
			{
				UpdateMesh(currentOverlayShape, vector, rotation, lossyScale, GetBoundingRect(rect, rect2));
				_LastShape = currentOverlayShape;
				_LastPosition = vector;
				_LastRotation = rotation;
				_LastScale = lossyScale;
				_LastDestRectLeft = rect;
				_LastDestRectRight = rect2;
			}
			if (_MeshRenderer.sharedMaterial == null)
			{
				Material sharedMaterial = new Material(Shader.Find("Unlit/Transparent"));
				_MeshRenderer.sharedMaterial = sharedMaterial;
			}
			if (_MeshRenderer.sharedMaterial.mainTexture != texture && !_Overlay.isExternalSurface)
			{
				_MeshRenderer.sharedMaterial.mainTexture = texture;
			}
			if (_LastSrcRectLeft != rect3)
			{
				_MeshRenderer.sharedMaterial.mainTextureOffset = rect3.position;
				_MeshRenderer.sharedMaterial.mainTextureScale = rect3.size;
				_LastSrcRectLeft = rect3;
			}
		}
	}

	private void UpdateMesh(OVROverlay.OverlayShape shape, Vector3 position, Quaternion rotation, Vector3 scale, Rect rect)
	{
		if ((bool)_MeshFilter)
		{
			if (_Mesh == null)
			{
				_Mesh = new Mesh
				{
					name = "Overlay"
				};
				_Mesh.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
			}
			_Mesh.Clear();
			_Verts.Clear();
			_UV.Clear();
			_Tris.Clear();
			GenerateMesh(_Verts, _UV, _Tris, shape, position, rotation, scale, rect);
			_Mesh.SetVertices(_Verts);
			_Mesh.SetUVs(0, _UV);
			_Mesh.SetTriangles(_Tris, 0);
			_Mesh.UploadMeshData(markNoLongerReadable: false);
			_MeshFilter.sharedMesh = _Mesh;
			if ((bool)_MeshCollider)
			{
				_MeshCollider.sharedMesh = _Mesh;
			}
		}
	}

	public static void GenerateMesh(List<Vector3> verts, List<Vector2> uvs, List<int> tris, OVROverlay.OverlayShape shape, Vector3 position, Quaternion rotation, Vector3 scale, Rect rect)
	{
		switch (shape)
		{
		case OVROverlay.OverlayShape.Equirect:
			BuildSphere(verts, uvs, tris, position, rotation, scale, rect);
			break;
		case OVROverlay.OverlayShape.Cubemap:
		case OVROverlay.OverlayShape.OffcenterCubemap:
			BuildCube(verts, uvs, tris, position, rotation, scale);
			break;
		case OVROverlay.OverlayShape.Quad:
			BuildQuad(verts, uvs, tris, rect);
			break;
		case OVROverlay.OverlayShape.Cylinder:
			BuildHemicylinder(verts, uvs, tris, scale, rect);
			break;
		case (OVROverlay.OverlayShape)3:
			break;
		}
	}

	private static Vector2 GetSphereUV(float theta, float phi, float expand_coef)
	{
		float x = (theta / ((float)Math.PI * 2f) - 0.5f) / expand_coef + 0.5f;
		float y = phi / (float)Math.PI / expand_coef + 0.5f;
		return new Vector2(x, y);
	}

	private static Vector3 GetSphereVert(float theta, float phi)
	{
		return new Vector3((0f - Mathf.Sin(theta)) * Mathf.Cos(phi), Mathf.Sin(phi), (0f - Mathf.Cos(theta)) * Mathf.Cos(phi));
	}

	public static void BuildSphere(List<Vector3> verts, List<Vector2> uv, List<int> triangles, Vector3 position, Quaternion rotation, Vector3 scale, Rect rect, float worldScale = 800f, int latitudes = 128, int longitudes = 128, float expand_coef = 1f)
	{
		position = Quaternion.Inverse(rotation) * position;
		latitudes = Mathf.CeilToInt((float)latitudes * rect.height);
		longitudes = Mathf.CeilToInt((float)longitudes * rect.width);
		float num = (float)Math.PI * 2f * rect.x;
		float num2 = (float)Math.PI * (0.5f - rect.y - rect.height);
		float num3 = (float)Math.PI * 2f * rect.width / (float)longitudes;
		float num4 = (float)Math.PI * rect.height / (float)latitudes;
		for (int i = 0; i < latitudes + 1; i++)
		{
			for (int j = 0; j < longitudes + 1; j++)
			{
				float theta = num + (float)j * num3;
				float phi = num2 + (float)i * num4;
				Vector2 sphereUV = GetSphereUV(theta, phi, expand_coef);
				uv.Add(new Vector2((sphereUV.x - rect.x) / rect.width, (sphereUV.y - rect.y) / rect.height));
				Vector3 sphereVert = GetSphereVert(theta, phi);
				sphereVert.x = (worldScale * sphereVert.x - position.x) / scale.x;
				sphereVert.y = (worldScale * sphereVert.y - position.y) / scale.y;
				sphereVert.z = (worldScale * sphereVert.z - position.z) / scale.z;
				verts.Add(sphereVert);
			}
		}
		for (int k = 0; k < latitudes; k++)
		{
			for (int l = 0; l < longitudes; l++)
			{
				triangles.Add(k * (longitudes + 1) + l);
				triangles.Add((k + 1) * (longitudes + 1) + l);
				triangles.Add((k + 1) * (longitudes + 1) + l + 1);
				triangles.Add((k + 1) * (longitudes + 1) + l + 1);
				triangles.Add(k * (longitudes + 1) + l + 1);
				triangles.Add(k * (longitudes + 1) + l);
			}
		}
	}

	private static Vector2 GetCubeUV(CubeFace face, Vector2 sideUV, float expand_coef)
	{
		sideUV = (sideUV - 0.5f * Vector2.one) / expand_coef + 0.5f * Vector2.one;
		switch (face)
		{
		case CubeFace.Bottom:
			return new Vector2(sideUV.x / 3f, sideUV.y / 2f);
		case CubeFace.Front:
			return new Vector2((1f + sideUV.x) / 3f, sideUV.y / 2f);
		case CubeFace.Back:
			return new Vector2((2f + sideUV.x) / 3f, sideUV.y / 2f);
		case CubeFace.Right:
			return new Vector2(sideUV.x / 3f, (1f + sideUV.y) / 2f);
		case CubeFace.Left:
			return new Vector2((1f + sideUV.x) / 3f, (1f + sideUV.y) / 2f);
		case CubeFace.Top:
			return new Vector2((2f + sideUV.x) / 3f, (1f + sideUV.y) / 2f);
		default:
			return Vector2.zero;
		}
	}

	private static Vector3 GetCubeVert(CubeFace face, Vector2 sideUV, float expand_coef)
	{
		return BottomLeft[(int)face] + sideUV.x * RightVector[(int)face] + sideUV.y * UpVector[(int)face];
	}

	public static void BuildCube(List<Vector3> verts, List<Vector2> uv, List<int> triangles, Vector3 position, Quaternion rotation, Vector3 scale, float worldScale = 800f, int subQuads = 1, float expand_coef = 1.01f)
	{
		position = Quaternion.Inverse(rotation) * position;
		int num = (subQuads + 1) * (subQuads + 1);
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < subQuads + 1; j++)
			{
				for (int k = 0; k < subQuads + 1; k++)
				{
					float x = (float)j / (float)subQuads;
					float y = (float)k / (float)subQuads;
					uv.Add(GetCubeUV((CubeFace)i, new Vector2(x, y), expand_coef));
					Vector3 cubeVert = GetCubeVert((CubeFace)i, new Vector2(x, y), expand_coef);
					cubeVert.x = (worldScale * cubeVert.x - position.x) / scale.x;
					cubeVert.y = (worldScale * cubeVert.y - position.y) / scale.y;
					cubeVert.z = (worldScale * cubeVert.z - position.z) / scale.z;
					verts.Add(cubeVert);
				}
			}
			for (int l = 0; l < subQuads; l++)
			{
				for (int m = 0; m < subQuads; m++)
				{
					triangles.Add(num * i + (l + 1) * (subQuads + 1) + m);
					triangles.Add(num * i + l * (subQuads + 1) + m);
					triangles.Add(num * i + (l + 1) * (subQuads + 1) + m + 1);
					triangles.Add(num * i + (l + 1) * (subQuads + 1) + m + 1);
					triangles.Add(num * i + l * (subQuads + 1) + m);
					triangles.Add(num * i + l * (subQuads + 1) + m + 1);
				}
			}
		}
	}

	public static void BuildQuad(List<Vector3> verts, List<Vector2> uv, List<int> triangles, Rect rect)
	{
		verts.Add(new Vector3(rect.x - 0.5f, 1f - rect.y - rect.height - 0.5f, 0f));
		verts.Add(new Vector3(rect.x - 0.5f, 1f - rect.y - 0.5f, 0f));
		verts.Add(new Vector3(rect.x + rect.width - 0.5f, 1f - rect.y - 0.5f, 0f));
		verts.Add(new Vector3(rect.x + rect.width - 0.5f, 1f - rect.y - rect.height - 0.5f, 0f));
		uv.Add(new Vector2(0f, 0f));
		uv.Add(new Vector2(0f, 1f));
		uv.Add(new Vector2(1f, 1f));
		uv.Add(new Vector2(1f, 0f));
		triangles.Add(0);
		triangles.Add(1);
		triangles.Add(2);
		triangles.Add(2);
		triangles.Add(3);
		triangles.Add(0);
	}

	public static void BuildHemicylinder(List<Vector3> verts, List<Vector2> uv, List<int> triangles, Vector3 scale, Rect rect, int longitudes = 128)
	{
		float num = Mathf.Abs(scale.y) * rect.height;
		float z = scale.z;
		float num2 = scale.x * rect.width;
		float num3 = num2 / z;
		float num4 = scale.x * (-0.5f + rect.x) / z;
		int num5 = Mathf.CeilToInt((float)longitudes * num3 / ((float)Math.PI * 2f));
		float num6 = num2 / (float)num5;
		int num7 = Mathf.CeilToInt(num / num6 / 2f);
		for (int i = 0; i < num7 + 1; i++)
		{
			for (int j = 0; j < num5 + 1; j++)
			{
				uv.Add(new Vector2((float)j / (float)num5, 1f - (float)i / (float)num7));
				Vector3 zero = Vector3.zero;
				zero.x = Mathf.Sin(num4 + (float)j * num3 / (float)num5) * z / scale.x;
				zero.y = 0.5f - rect.y - rect.height + rect.height * (1f - (float)i / (float)num7);
				zero.z = Mathf.Cos(num4 + (float)j * num3 / (float)num5) * z / scale.z;
				verts.Add(zero);
			}
		}
		for (int k = 0; k < num7; k++)
		{
			for (int l = 0; l < num5; l++)
			{
				triangles.Add(k * (num5 + 1) + l);
				triangles.Add((k + 1) * (num5 + 1) + l + 1);
				triangles.Add((k + 1) * (num5 + 1) + l);
				triangles.Add((k + 1) * (num5 + 1) + l + 1);
				triangles.Add(k * (num5 + 1) + l);
				triangles.Add(k * (num5 + 1) + l + 1);
			}
		}
	}
}
