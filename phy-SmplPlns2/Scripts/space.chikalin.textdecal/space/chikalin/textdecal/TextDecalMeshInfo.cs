using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace space.chikalin.textdecal
{
	public class TextDecalMeshInfo
	{
		private const int VolumetricVertexCount = 8;

		private const int VolumetricTrianglesCount = 36;

		private readonly int[] _volumetricTriangles = new int[36]
		{
			0, 1, 2, 2, 3, 0, 1, 5, 6, 6,
			2, 1, 3, 2, 6, 6, 7, 3, 4, 5,
			1, 1, 0, 4, 4, 0, 3, 3, 7, 4,
			7, 6, 5, 5, 4, 7
		};

		private Vector3 _depthVector;

		private Vector3[] _vertices;

		private int[] _triangles;

		private Vector3[] _normals;

		private Vector4[] _rotation;

		private Color[] _colors;

		private Vector4[] _uv;

		private Vector4[] _meshData;

		private Vector4[] _uvData;

		private Vector2[] _meshAngle;

		private Mesh _volumetricMesh;

		private MeshFilter _meshFilter;

		public Mesh VolumetricMesh
		{
			get
			{
				if (_volumetricMesh != null)
				{
					return _volumetricMesh;
				}
				_volumetricMesh = new Mesh
				{
					hideFlags = HideFlags.HideAndDontSave
				};
				_volumetricMesh.MarkDynamic();
				return _volumetricMesh;
			}
		}

		public Mesh Mesh
		{
			set
			{
				_meshFilter.mesh = value;
			}
		}

		public void PrepareMeshData(int vertexCount, MeshFilter meshFilter)
		{
			_meshFilter = meshFilter;
			int num = vertexCount / 4;
			int size = num * 8;
			UpdateArray(ref _vertices, size);
			UpdateArray(ref _triangles, num * 36);
			UpdateArray(ref _colors, size);
			UpdateArray(ref _rotation, size);
			UpdateArray(ref _normals, size);
			UpdateArray(ref _uv, size);
			UpdateArray(ref _meshData, size);
			UpdateArray(ref _meshAngle, size);
			UpdateArray(ref _uvData, size);
		}

		private static void UpdateArray<T>(ref T[] array, int size)
		{
			if (array == null)
			{
				array = new T[size];
				return;
			}
			if (array.Length != size)
			{
				Array.Resize(ref array, size);
			}
			Array.Clear(array, 0, array.Length);
		}

		public void AddCharacter(TMP_CharacterInfo charInfo, TMP_MeshInfo meshInfo, TextDecal.TextDecalSettings settings)
		{
			int vertexIndex = charInfo.vertexIndex;
			int num = vertexIndex * 2;
			int num2 = vertexIndex * 9;
			Vector3 vector = meshInfo.vertices[vertexIndex];
			Vector3 vector2 = meshInfo.vertices[vertexIndex + 1];
			Vector3 vector3 = meshInfo.vertices[vertexIndex + 2];
			Vector3 vector4 = meshInfo.vertices[vertexIndex + 3];
			_vertices[num] = vector;
			_vertices[num + 1] = vector2;
			_vertices[num + 2] = vector3;
			_vertices[num + 3] = vector4;
			Vector3 vector5 = math.normalize(math.cross(vector - vector2, vector - vector4));
			_vertices[num + 4] = vector - vector5 * settings.projectionDepth;
			_vertices[num + 5] = vector2 - vector5 * settings.projectionDepth;
			_vertices[num + 6] = vector3 - vector5 * settings.projectionDepth;
			_vertices[num + 7] = vector4 - vector5 * settings.projectionDepth;
			for (int i = 0; i < _volumetricTriangles.Length; i++)
			{
				_triangles[num2 + i] = num + _volumetricTriangles[i];
			}
			_uv[num] = charInfo.vertex_BL.uv;
			_uv[num + 1] = charInfo.vertex_TL.uv;
			_uv[num + 2] = charInfo.vertex_TR.uv;
			_uv[num + 3] = charInfo.vertex_BR.uv;
			_uv[num + 4] = charInfo.vertex_BL.uv;
			_uv[num + 5] = charInfo.vertex_TL.uv;
			_uv[num + 6] = charInfo.vertex_TR.uv;
			_uv[num + 7] = charInfo.vertex_BR.uv;
			Vector4 uv = charInfo.vertex_BL.uv;
			float w = Vector3.Distance(vector4, vector);
			Vector3 vector6 = vector + (vector3 - vector) / 2f;
			Vector4 vector7 = new Vector4(vector6.x, vector6.y, vector6.z, w);
			float num3 = Vector2.Distance(charInfo.vertex_BR.uv, charInfo.vertex_BL.uv);
			float num4 = Vector2.Distance(charInfo.vertex_TR.uv, charInfo.vertex_BR.uv);
			Vector4 vector8 = new Vector4(uv.x, uv.y, num3, num4 / num3);
			Vector3 upwards = vector2 + (vector3 - vector2) / 2f - vector6;
			Quaternion quaternion2 = Quaternion.LookRotation(-vector5, upwards);
			Vector4 vector9 = new Vector4(quaternion2.x, quaternion2.y, quaternion2.z, quaternion2.w);
			for (int j = 0; j < 8; j++)
			{
				_meshData[num + j] = vector7;
				_uvData[num + j] = vector8;
				_colors[num + j] = charInfo.color;
				_normals[num + j] = vector5;
				_rotation[num + j] = vector9;
			}
		}

		public void UpdateMesh(TextDecal.TextDecalSettings settings)
		{
			Mesh volumetricMesh = VolumetricMesh;
			volumetricMesh.Clear();
			volumetricMesh.vertices = _vertices;
			volumetricMesh.triangles = _triangles;
			volumetricMesh.normals = _normals;
			volumetricMesh.colors = _colors;
			volumetricMesh.SetUVs(0, _uv);
			volumetricMesh.SetUVs((int)(settings.useDefaultUV ? TextDecal.TextDecalSettings.vertexDataDefault : settings.vertexData), _meshData);
			volumetricMesh.SetUVs((int)(settings.useDefaultUV ? TextDecal.TextDecalSettings.UVDataDefault : settings.UVData), _uvData);
			volumetricMesh.SetUVs((int)(settings.useDefaultUV ? TextDecal.TextDecalSettings.rotationDataDefault : settings.rotationData), _rotation);
			volumetricMesh.tangents = _rotation;
			if (_meshFilter.sharedMesh != volumetricMesh)
			{
				_meshFilter.sharedMesh = volumetricMesh;
			}
			volumetricMesh.RecalculateBounds();
			volumetricMesh.MarkModified();
		}

		public void Dispose()
		{
			_volumetricMesh = null;
		}
	}
}
