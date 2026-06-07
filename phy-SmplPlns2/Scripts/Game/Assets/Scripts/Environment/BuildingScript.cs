using System;
using System.Linq;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Environment
{
	[ExecuteInEditMode]
	public class BuildingScript : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker GenerateBuilding = new ProfilerMarker("BuildingScript.GenerateBuilding");
		}

		[SerializeField]
		private BuildingStyle _buildingStyle;

		[SerializeField]
		private Transform _root;

		[Range(0f, 30f)]
		[SerializeField]
		private int _numFloors = 3;

		[Range(1f, 30f)]
		[SerializeField]
		private int _numColumnsX = 10;

		[Range(1f, 30f)]
		[SerializeField]
		private int _numColumnsZ = 5;

		[Range(0f, 10f)]
		[SerializeField]
		private int _extraColumns;

		[SerializeField]
		private bool _windowsFront = true;

		[SerializeField]
		private bool _windowsRight = true;

		[SerializeField]
		private bool _windowsBack;

		[SerializeField]
		private bool _windowsLeft;

		private MeshFilter _meshFilter;

		private MeshRenderer _meshRenderer;

		private MeshCollider _meshCollider;

		private bool _scheduleRequired;

		[SerializeField]
		private BuildingBatcherScript _batcher;

		[SerializeField]
		private bool _deleteAtRuntime;

		public bool IsBatched => _batcher != null;

		public BuildingStyle BuildingStyle => _buildingStyle;

		public MeshFilter MeshFilter => _meshFilter;

		public MeshRenderer MeshRenderer => _meshRenderer;

		public void OnBatched(BuildingBatcherScript batcher)
		{
			_batcher = batcher;
			_deleteAtRuntime = GetComponentsInChildren<Transform>(includeInactive: true).All((Transform x) => x.TryGetComponent<BuildingScript>(out var _));
			if (_meshCollider != null)
			{
				UnityEngine.Object.DestroyImmediate(_meshCollider);
				_meshCollider = null;
			}
			if (_meshRenderer != null)
			{
				UnityEngine.Object.DestroyImmediate(_meshRenderer);
				_meshRenderer = null;
			}
			if (_meshFilter != null)
			{
				UnityEngine.Object.DestroyImmediate(_meshFilter);
				_meshFilter = null;
			}
		}

		public void OnUnbatched()
		{
			_batcher = null;
			_deleteAtRuntime = false;
			GenerateBuilding();
		}

		protected virtual void OnDestroy()
		{
			Mesh mesh = _meshFilter?.sharedMesh;
			if (mesh != null)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(mesh);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(mesh);
				}
			}
		}

		protected void Start()
		{
			if (Application.isPlaying && _deleteAtRuntime)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else if (!IsBatched)
			{
				GenerateBuilding();
			}
		}

		private void GenerateBuilding()
		{
			using (Profile.GenerateBuilding.Auto())
			{
				if (_buildingStyle == null)
				{
					return;
				}
				_meshFilter = GetComponent<MeshFilter>();
				if (_meshFilter == null)
				{
					_meshFilter = base.gameObject.AddComponent<MeshFilter>();
				}
				_meshRenderer = GetComponent<MeshRenderer>();
				if (_meshRenderer == null)
				{
					_meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
				}
				_meshCollider = GetComponent<MeshCollider>();
				if (_meshCollider == null)
				{
					_meshCollider = base.gameObject.AddComponent<MeshCollider>();
				}
				Vector3[] array = GenerateRectangularPrismVertices(_buildingStyle.StreetLevelHeight);
				int[] triangles = GenerateRectangularPrismTriangles();
				int[] triangles2 = GenerateRectangularPrismTriangles(side: false);
				Vector2[] array2 = GenerateRectangularPrismUVs(1);
				int[] array3 = null;
				int[] array4 = null;
				int num;
				if (_numFloors > 0)
				{
					Vector3[] array5 = GenerateRectangularPrismVertices((float)_numFloors * _buildingStyle.TileHeight, _buildingStyle.StreetLevelHeight);
					Vector2[] array6 = GenerateRectangularPrismUVs(_numFloors);
					num = array.Length;
					Array.Resize(ref array, array.Length + array5.Length);
					Array.Copy(array5, 0, array, num, array5.Length);
					Array.Resize(ref array2, array2.Length + array6.Length);
					Array.Copy(array6, 0, array2, num, array6.Length);
					int[] array7 = GenerateRectangularPrismTriangles();
					int[] array8 = GenerateRectangularPrismTriangles(side: false);
					array3 = new int[array7.Length];
					array4 = new int[array8.Length];
					for (int i = 0; i < array7.Length; i++)
					{
						array3[i] = array7[i] + num;
					}
					for (int j = 0; j < array8.Length; j++)
					{
						array4[j] = array8[j] + num;
					}
				}
				Vector3[] array9 = GenerateRoofVertices();
				Vector2[] array10 = GenerateRoofUVs();
				num = array.Length;
				Array.Resize(ref array, array.Length + array9.Length);
				Array.Copy(array9, 0, array, num, array9.Length);
				Array.Resize(ref array2, array2.Length + array10.Length);
				Array.Copy(array10, 0, array2, num, array10.Length);
				int[] array11 = GenerateRoofTriangles();
				int[] array12 = new int[array11.Length];
				for (int k = 0; k < array11.Length; k++)
				{
					array12[k] = array11[k] + num;
				}
				if (_root == null)
				{
					_root = base.transform;
					while (!_root.name.Contains("Apartments"))
					{
						_root = _root.parent;
						if (_root == null)
						{
							break;
						}
					}
				}
				Vector2[] array13 = new Vector2[array2.Length];
				if (_root != null)
				{
					Vector3 vector = base.transform.position - _root.position;
					Vector2 vector2 = new Vector2(vector.x, vector.z);
					for (int l = 0; l < array2.Length; l++)
					{
						array13[l] = vector2;
					}
				}
				Mesh mesh = new Mesh
				{
					name = "BuildingScript Generated Mesh (" + _buildingStyle.StyleName + ")",
					vertices = array,
					uv = array2,
					uv2 = array13,
					subMeshCount = 6
				};
				mesh.SetTriangles(triangles, 0);
				mesh.SetTriangles(triangles2, 1);
				if (_numFloors > 0)
				{
					mesh.SetTriangles(array3, 2);
					mesh.SetTriangles(array4, 3);
				}
				mesh.SetTriangles(array12[..^6], 4);
				mesh.SetTriangles(array12[^6..^0], 5);
				mesh.RecalculateNormals();
				mesh.RecalculateTangents();
				_meshFilter.sharedMesh = mesh;
				_meshCollider.sharedMesh = mesh;
				_meshRenderer.materials = new Material[6] { _buildingStyle.StreetLevelMaterial, _buildingStyle.SideMaterial, _buildingStyle.FacadeMaterial, _buildingStyle.SideMaterial, _buildingStyle.RoofMaterial, _buildingStyle.RoofTopMaterial };
			}
		}

		private Vector3[] GenerateRoofVertices()
		{
			int num = _buildingStyle.RoofProfile.Length;
			Vector3[] array = new Vector3[num * 8 + 4];
			float num2 = (float)_numColumnsX * 0.5f * _buildingStyle.TileWidth;
			float num3 = num2 + 0.5f * (float)_extraColumns * _buildingStyle.TileWidth;
			float num4 = (float)_numColumnsZ * 0.5f * _buildingStyle.TileWidth;
			float num5 = _buildingStyle.StreetLevelHeight + (float)_numFloors * _buildingStyle.TileHeight;
			float num6 = (float)_extraColumns / (float)_numColumnsZ;
			for (int i = 0; i < num; i++)
			{
				float x = _buildingStyle.RoofProfile[i].x;
				float y = _buildingStyle.RoofProfile[i].y;
				array[i + 4 * num] = (array[i] = new Vector3(x - num2, num5 + y, x - num4));
				array[i + 5 * num] = (array[i + num] = new Vector3(num2 - x, num5 + y, x - num4));
				array[i + 6 * num] = (array[i + 2 * num] = new Vector3(num3 - x - x * num6, num5 + y, num4 - x));
				array[i + 7 * num] = (array[i + 3 * num] = new Vector3(x - num3 + x * num6, num5 + y, num4 - x));
			}
			array[^1] = array[num - 1];
			array[^2] = array[2 * num - 1];
			array[^3] = array[3 * num - 1];
			array[^4] = array[4 * num - 1];
			return array;
		}

		private int[] GenerateRoofTriangles()
		{
			int num = _buildingStyle.RoofProfile.Length;
			int num2 = 2 * num;
			int num3 = 3 * num;
			int num4 = 4 * num;
			int num5 = 5 * num;
			int num6 = 6 * num;
			int num7 = 7 * num;
			int num8 = num * 8 + 4;
			int[] array = new int[(num - 1) * 24 + 6];
			for (int i = 0; i < num - 1; i++)
			{
				int num9 = i * 24;
				array[num9] = i;
				array[num9 + 1] = i + 1;
				array[num9 + 2] = i + num;
				array[num9 + 3] = i + 1;
				array[num9 + 4] = i + num + 1;
				array[num9 + 5] = i + num;
				array[num9 + 6] = i + num5;
				array[num9 + 7] = i + num5 + 1;
				array[num9 + 8] = i + num6 + 1;
				array[num9 + 9] = i + num5;
				array[num9 + 10] = i + num6 + 1;
				array[num9 + 11] = i + num6;
				array[num9 + 12] = i + num2;
				array[num9 + 13] = i + num2 + 1;
				array[num9 + 14] = i + num3;
				array[num9 + 15] = i + num2 + 1;
				array[num9 + 16] = i + num3 + 1;
				array[num9 + 17] = i + num3;
				array[num9 + 18] = i + num7;
				array[num9 + 19] = i + num7 + 1;
				array[num9 + 20] = i + num4;
				array[num9 + 21] = i + num7 + 1;
				array[num9 + 22] = i + num4 + 1;
				array[num9 + 23] = i + num4;
			}
			array[^6] = num8 - 2;
			array[^5] = num8 - 4;
			array[^4] = num8 - 3;
			array[^3] = num8 - 1;
			array[^2] = num8 - 4;
			array[^1] = num8 - 2;
			return array;
		}

		private Vector2[] GenerateRoofUVs()
		{
			int num = _buildingStyle.RoofProfile.Length;
			Vector2[] array = new Vector2[num * 8 + 4];
			float num2 = _numColumnsX;
			float num3 = (float)_numColumnsX + 0.5f * (float)_extraColumns;
			float num4 = _numColumnsZ;
			float num5 = -0.5f * (float)_extraColumns;
			float num6 = (float)_extraColumns / (float)_numColumnsZ;
			float num7;
			for (int i = 0; i < num; i++)
			{
				num7 = _buildingStyle.RoofProfile[i].x / _buildingStyle.TileWidth;
				float y = (float)i / (float)(num - 1);
				array[i] = new Vector2(num7, y);
				array[i + num] = new Vector2(num2 - num7, y);
				array[i + num * 5] = new Vector2(num7, y);
				array[i + num * 6] = new Vector2(num4 - num7, y);
				array[i + num * 2] = new Vector2(num5 + num7 + num7 * num6, y);
				array[i + num * 3] = new Vector2(num3 - num7 - num7 * num6, y);
				array[i + num * 7] = new Vector2(num7, y);
				array[i + num * 4] = new Vector2(num4 - num7, y);
			}
			num7 = _buildingStyle.RoofProfile[^1].x / _buildingStyle.TileWidth;
			array[^1] = new Vector2(num7, num7);
			array[^2] = new Vector2(num2 - num7, num7);
			array[^3] = new Vector2(num3 - num7 - num7 * num6, num4 - num7);
			array[^4] = new Vector2(num5 + num7 + num7 * num6, num4 - num7);
			return array;
		}

		private Vector3[] GenerateRectangularPrismVertices(float heightTop, float heightBottom = 0f)
		{
			float num = (float)_numColumnsX * 0.5f * _buildingStyle.TileWidth;
			float num2 = num + 0.5f * (float)_extraColumns * _buildingStyle.TileWidth;
			float num3 = (float)_numColumnsZ * 0.5f * _buildingStyle.TileWidth;
			heightTop += heightBottom;
			Vector3 vector = new Vector3(0f - num, heightBottom, 0f - num3);
			Vector3 vector2 = new Vector3(num, heightBottom, 0f - num3);
			Vector3 vector3 = new Vector3(num2, heightBottom, num3);
			Vector3 vector4 = new Vector3(0f - num2, heightBottom, num3);
			Vector3 vector5 = new Vector3(0f - num, heightTop, 0f - num3);
			Vector3 vector6 = new Vector3(num, heightTop, 0f - num3);
			Vector3 vector7 = new Vector3(num2, heightTop, num3);
			Vector3 vector8 = new Vector3(0f - num2, heightTop, num3);
			return new Vector3[16]
			{
				vector, vector2, vector6, vector5, vector4, vector3, vector7, vector8, vector, vector4,
				vector8, vector5, vector2, vector3, vector7, vector6
			};
		}

		private int[] GenerateRectangularPrismTriangles(bool side = true)
		{
			int[] array = new int[0];
			if (_windowsFront ^ !side)
			{
				int[] second = new int[6] { 0, 2, 1, 0, 3, 2 };
				array = array.Concat(second).ToArray();
			}
			if (_windowsBack ^ !side)
			{
				int[] second2 = new int[6] { 4, 5, 6, 4, 6, 7 };
				array = array.Concat(second2).ToArray();
			}
			if (_windowsRight ^ !side)
			{
				int[] second3 = new int[6] { 8, 9, 10, 8, 10, 11 };
				array = array.Concat(second3).ToArray();
			}
			if (_windowsLeft ^ !side)
			{
				int[] second4 = new int[6] { 12, 14, 13, 12, 15, 14 };
				array = array.Concat(second4).ToArray();
			}
			return array;
		}

		private Vector2[] GenerateRectangularPrismUVs(int floors)
		{
			int numColumnsX = _numColumnsX;
			int num = _numColumnsX + _extraColumns;
			int numColumnsZ = _numColumnsZ;
			return new Vector2[16]
			{
				new Vector2(0f, 0f),
				new Vector2(numColumnsX, 0f),
				new Vector2(numColumnsX, floors),
				new Vector2(0f, floors),
				new Vector2(numColumnsX, 0f),
				new Vector2(num + numColumnsX, 0f),
				new Vector2(num + numColumnsX, floors),
				new Vector2(numColumnsX, floors),
				new Vector2(num + numColumnsX, 0f),
				new Vector2(numColumnsZ + num + numColumnsX, 0f),
				new Vector2(numColumnsZ + num + numColumnsX, floors),
				new Vector2(num + numColumnsX, floors),
				new Vector2(numColumnsZ + num + numColumnsX, 0f),
				new Vector2(numColumnsZ + numColumnsZ + num + numColumnsX, 0f),
				new Vector2(numColumnsZ + numColumnsZ + num + numColumnsX, floors),
				new Vector2(numColumnsZ + num + numColumnsX, floors)
			};
		}
	}
}
