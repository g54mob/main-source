using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.Core;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain
{
	public class NimbatusTerrainChunk : MonoBehaviour
	{
		public bool HasBeenInitialized;

		public bool IsRebuilding;

		public bool NeedsRebuilding;

		public Vector3 WorldPosition;

		private int _size;

		private Mesh _collisionMesh;

		private Mesh _renderMesh;

		private List<Material> _materials;

		private List<int[]> _subIndices;

		private List<Vector3> _colliderVerts;

		private List<int> _colliderTris;

		private List<Vector3> _verts;

		private List<int> _tris;

		private List<Vector2> _uVs;

		private List<Vector3> _norms;

		private Vector3[] _vertsArray;

		private Vector2[] _uVsArray;

		private Vector3[] _normsArray;

		private Vector3[] _colliderVertsArray;

		private int[] _colliderTrisArray;

		private readonly Triangle[] _triangles = new Triangle[4];

		private readonly Outline[] _outlines = new Outline[4];

		private const float IsoValue = 0.5f;

		private Dictionary<Vector2, NimbatusTerrainData> _terrainData;

		private NimbatusTerrainData[,] _terrainDataBuffer;

		private INimbatusTerrain _terrain;

		private bool _isEmpty;

		private bool _isFull;

		private MeshCollider _mcollider;

		private MeshRenderer _mrenderer;

		private MeshFilter _mfilter;

		public void CleanUpMesh()
		{
			if (_renderMesh != null)
			{
				_renderMesh.Clear();
			}
			if (_collisionMesh != null)
			{
				_collisionMesh.Clear();
			}
		}

		public void Init(Vector3 position, int size, INimbatusTerrain terrain)
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				UnityEngine.Object.Destroy(base.transform.GetChild(i).gameObject);
			}
			WorldPosition = position;
			_size = size;
			base.transform.position = WorldPosition;
			_collisionMesh = new Mesh();
			_renderMesh = new Mesh();
			_terrainDataBuffer = new NimbatusTerrainData[_size + 2, _size + 2];
			_terrainData = new Dictionary<Vector2, NimbatusTerrainData>();
			_terrain = terrain;
			_subIndices = new List<int[]>();
			_materials = new List<Material>();
			_colliderVerts = new List<Vector3>();
			_colliderTris = new List<int>();
			_verts = new List<Vector3>();
			_tris = new List<int>();
			_uVs = new List<Vector2>();
			_norms = new List<Vector3>();
			if (base.gameObject.GetComponent<MeshRenderer>() == null)
			{
				_mcollider = base.gameObject.AddComponent<MeshCollider>();
				base.gameObject.isStatic = true;
				_mrenderer = base.gameObject.AddComponent<MeshRenderer>();
				_mfilter = base.gameObject.AddComponent<MeshFilter>();
			}
			HasBeenInitialized = true;
			_isEmpty = false;
			_isFull = false;
		}

		public NimbatusTerrainData? GetData(Vector2 worldPos)
		{
			int num = Mathf.RoundToInt(worldPos.x - WorldPosition.x);
			int num2 = Mathf.RoundToInt(worldPos.y - WorldPosition.y);
			return GetDataLocal(new Vector2(num, num2));
		}

		public void SetData(Vector2 worldPos, NimbatusTerrainData data)
		{
			int num = (int)(worldPos.x - WorldPosition.x);
			int num2 = (int)(worldPos.y - WorldPosition.y);
			SetDataLocal(new Vector2(num, num2), data);
		}

		private NimbatusTerrainData? GetDataLocal(Vector2 pos)
		{
			int num = (int)pos.x;
			int num2 = (int)pos.y;
			if (num >= 0 && num <= _size && num2 >= 0 && num2 <= _size)
			{
				return _terrainDataBuffer[num, num2];
			}
			return null;
		}

		private void SetDataLocal(Vector2 pos, NimbatusTerrainData data)
		{
			int num = (int)pos.x;
			int num2 = (int)pos.y;
			if (num >= 0 && num <= _size && num2 >= 0 && num2 <= _size)
			{
				_terrainDataBuffer[num, num2] = data;
			}
		}

		public void GenerateBackgroundObjects()
		{
			if (_isEmpty || _isFull || !_terrain.IsBackground())
			{
				return;
			}
			NimbatusTerrainClimateZone climateZone = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone;
			List<WorldTerrainObject> backgroundObjects = climateZone.BackgroundObjects;
			System.Random rand = new System.Random((int)(WorldPosition.x * WorldPosition.y + (float)WorldController.Seed));
			if (backgroundObjects.Count <= 0)
			{
				return;
			}
			for (int i = 3; i < _size - 4; i += 3)
			{
				for (int j = 3; j < _size - 4; j += 3)
				{
					if (!(_terrainDataBuffer[i, j].Volume < 0.5f))
					{
						continue;
					}
					Vector3 zero = Vector3.zero;
					int num = 0;
					for (int k = -3; k <= 3; k++)
					{
						for (int l = -3; l <= 3; l++)
						{
							if (_terrainDataBuffer[i + k, j + l].Volume >= 0.5f)
							{
								zero += new Vector3(k, l, 0f);
								num++;
							}
						}
					}
					if (!(zero.magnitude > 20f))
					{
						continue;
					}
					Vector3 vector = -zero / num;
					Vector3 vector2 = WorldPosition + new Vector3(i, j);
					float num2 = Mathf.Atan2(0f - vector.y, 0f - vector.x) * 57.29578f + 90f;
					float target = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f - 90f;
					float angleDiff = Mathf.Abs(Mathf.DeltaAngle(num2, target));
					WorldTerrainObject worldTerrainObject = (from r in backgroundObjects
						where (float)r.AllowedAngle >= angleDiff
						orderby rand.Next(0, r.GetProbability(climateZone.SelectedSettings.FoliageDensity)) descending
						select r).First();
					if (rand.Next(0, 100) > worldTerrainObject.GetProbability(climateZone.SelectedSettings.FoliageDensity))
					{
						continue;
					}
					WorldTerrainObject worldTerrainObject2 = UnityEngine.Object.Instantiate(worldTerrainObject);
					if (rand.Next(0, 100) > 50)
					{
						SpriteRenderer component = worldTerrainObject2.GetComponent<SpriteRenderer>();
						if (component != null)
						{
							component.flipX = !component.flipX;
						}
					}
					worldTerrainObject2.SetParentChunk(this);
					worldTerrainObject2.transform.parent = base.transform;
					ushort materialType = _terrainDataBuffer[i, j].MaterialType;
					float num3 = 0f;
					float num4 = (float)rand.Next(0, 100) * 0.001f;
					switch (worldTerrainObject.Placement)
					{
					case EObjectPlacement.Background_BG:
					case EObjectPlacement.Background_MG:
					case EObjectPlacement.Background_FG:
						num3 = (float)(materialType / 100 + materialType % 100) - num4;
						num3 += GetOffset(worldTerrainObject.Placement);
						break;
					case EObjectPlacement.Foreground_BG:
					case EObjectPlacement.Foreground_MG:
					case EObjectPlacement.Foreground_FG:
						num3 = 0f - num4;
						num3 += GetOffset(worldTerrainObject.Placement);
						break;
					}
					worldTerrainObject2.transform.localPosition = new Vector3(i, j, WorldPosition.z + num3 + 5f) - vector;
					worldTerrainObject2.transform.rotation = Quaternion.AngleAxis(num2, Vector3.forward);
				}
			}
		}

		public static float GetOffset(EObjectPlacement placement)
		{
			switch (placement)
			{
			case EObjectPlacement.Background_BG:
				return 0.3f;
			case EObjectPlacement.Background_MG:
				return 0.2f;
			case EObjectPlacement.Background_FG:
				return 0.1f;
			case EObjectPlacement.Foreground_BG:
				return 0.3f;
			case EObjectPlacement.Foreground_MG:
				return 0.2f;
			case EObjectPlacement.Foreground_FG:
				return 0.1f;
			default:
				return 0f;
			}
		}

		public void BuildTerrainMesh()
		{
			_materials.Clear();
			NimbatusTerrainClimateZone activeClimateZone = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone;
			List<ushort> list = new List<ushort>();
			for (int i = 0; i < _size; i++)
			{
				for (int j = 0; j < _size; j++)
				{
					ushort materialType = _terrainDataBuffer[i, j].MaterialType;
					if (!list.Contains(materialType))
					{
						list.Add(materialType);
					}
				}
			}
			_colliderVerts.Clear();
			_colliderTris.Clear();
			_verts.Clear();
			_tris.Clear();
			_uVs.Clear();
			_norms.Clear();
			_subIndices.Clear();
			Vector2 b = default(Vector2);
			b.x = 1f / (float)_size;
			b.y = 1f / (float)_size;
			int num = 0;
			int num2 = 0;
			_isFull = true;
			bool flag = true;
			SquareCell cell = default(SquareCell);
			Vector3 item = default(Vector3);
			Vector3 item2 = default(Vector3);
			Vector3 item3 = default(Vector3);
			Vector3 item4 = default(Vector3);
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			Vector3 vector3 = default(Vector3);
			foreach (ushort item6 in list)
			{
				for (int k = 0; k < _size; k++)
				{
					for (int l = 0; l < _size; l++)
					{
						cell.Position1.x = k;
						cell.Position1.y = l;
						cell.Position2.x = k + 1;
						cell.Position2.y = l;
						cell.Position3.x = k;
						cell.Position3.y = l + 1;
						cell.Position4.x = k + 1;
						cell.Position4.y = l + 1;
						cell.Data1 = _terrainDataBuffer[(int)cell.Position1.x, (int)cell.Position1.y].Volume;
						cell.Data2 = _terrainDataBuffer[(int)cell.Position2.x, (int)cell.Position2.y].Volume;
						cell.Data3 = _terrainDataBuffer[(int)cell.Position3.x, (int)cell.Position3.y].Volume;
						cell.Data4 = _terrainDataBuffer[(int)cell.Position4.x, (int)cell.Position4.y].Volume;
						if (cell.Data1 < 0.5f || cell.Data2 < 0.5f || cell.Data3 < 0.5f || cell.Data4 < 0.5f)
						{
							_isFull = false;
						}
						cell.Type1 = _terrainDataBuffer[(int)cell.Position1.x, (int)cell.Position1.y].MaterialType;
						cell.Type2 = _terrainDataBuffer[(int)cell.Position2.x, (int)cell.Position2.y].MaterialType;
						cell.Type3 = _terrainDataBuffer[(int)cell.Position3.x, (int)cell.Position3.y].MaterialType;
						cell.Type4 = _terrainDataBuffer[(int)cell.Position4.x, (int)cell.Position4.y].MaterialType;
						if (_terrain.HasCollider() && flag)
						{
							int num3 = TriangulationHelper.PolygonizeOutline(cell, _outlines, 0.5f);
							for (int m = 0; m < num3; m++)
							{
								Outline outline = _outlines[m];
								item.x = outline.A.x;
								item.y = outline.A.y;
								item.z = 10f;
								item2.x = outline.B.x;
								item2.y = outline.B.y;
								item2.z = 10f;
								item3.x = outline.A.x;
								item3.y = outline.A.y;
								item3.z = -10f;
								item4.x = outline.B.x;
								item4.y = outline.B.y;
								item4.z = -10f;
								_colliderVerts.Add(item);
								_colliderVerts.Add(item2);
								_colliderVerts.Add(item3);
								_colliderVerts.Add(item4);
								_colliderTris.Add(num2);
								_colliderTris.Add(num2 + 1);
								_colliderTris.Add(num2 + 2);
								_colliderTris.Add(num2 + 1);
								_colliderTris.Add(num2 + 3);
								_colliderTris.Add(num2 + 2);
								num2 += 4;
							}
						}
						int num4 = TriangulationHelper.Polygonize(cell, _triangles, 0.5f, item6);
						ushort num5 = item6;
						for (int n = 0; n < num4; n++)
						{
							Triangle triangle = _triangles[n];
							vector.x = triangle.Position1.x;
							vector.y = triangle.Position1.y;
							vector.z = WorldPosition.z - (float)(int)num5 * 0.05f;
							vector2.x = triangle.Position2.x;
							vector2.y = triangle.Position2.y;
							vector2.z = WorldPosition.z - (float)(int)num5 * 0.05f;
							vector3.x = triangle.Position3.x;
							vector3.y = triangle.Position3.y;
							vector3.z = WorldPosition.z - (float)(int)num5 * 0.05f;
							_verts.Add(vector);
							_verts.Add(vector2);
							_verts.Add(vector3);
							_tris.Add(num);
							_tris.Add(num + 1);
							_tris.Add(num + 2);
							Vector3 lhs = vector - vector2;
							Vector3 rhs = vector - vector3;
							Vector3 item5 = Vector3.Normalize(Vector3.Cross(lhs, rhs));
							_norms.Add(item5);
							_norms.Add(item5);
							_norms.Add(item5);
							_uVs.Add(Vector2.Scale(vector, b));
							_uVs.Add(Vector2.Scale(vector2, b));
							_uVs.Add(Vector2.Scale(vector3, b));
							num += 3;
						}
					}
				}
				if (_tris.Count > 0)
				{
					_subIndices.Add(_tris.ToArray());
					_materials.Add(activeClimateZone.GetLayer(item6, _terrain.IsBackground()).Material);
				}
				_tris.Clear();
				flag = false;
			}
			if (_terrain.HasCollider())
			{
				_colliderVertsArray = _colliderVerts.ToArray();
				_colliderTrisArray = _colliderTris.ToArray();
			}
			_colliderVerts.Clear();
			_colliderTris.Clear();
			_vertsArray = _verts.ToArray();
			_uVsArray = _uVs.ToArray();
			_normsArray = _norms.ToArray();
			_isEmpty = num <= 0;
		}

		public void GenerateTerrainData()
		{
			Vector2 vector = default(Vector2);
			for (int i = 0; i <= _size; i++)
			{
				for (int j = 0; j <= _size; j++)
				{
					vector.x = i;
					vector.y = j;
					if (_terrainData.ContainsKey(vector))
					{
						_terrainDataBuffer[i, j] = _terrainData[vector];
					}
					else
					{
						_terrainDataBuffer[i, j] = _terrain.GenerateData(vector + (Vector2)WorldPosition);
					}
				}
			}
		}

		public void ApplyTerrainMesh()
		{
			GameObject gameObject;
			try
			{
				gameObject = base.gameObject;
			}
			catch
			{
				return;
			}
			if (gameObject != null)
			{
				_mrenderer.materials = _materials.ToArray();
				_renderMesh.Clear();
				_renderMesh.vertices = _vertsArray;
				_renderMesh.uv = _uVsArray;
				_renderMesh.subMeshCount = _subIndices.Count;
				for (int i = 0; i < _subIndices.Count; i++)
				{
					_renderMesh.SetTriangles(_subIndices[i], i);
				}
				_renderMesh.normals = _normsArray;
				_mfilter.sharedMesh = null;
				_mfilter.sharedMesh = _renderMesh;
				_mrenderer.enabled = true;
				if (_terrain.HasCollider() && _colliderTrisArray.Length != 0)
				{
					_collisionMesh.Clear();
					_collisionMesh.vertices = _colliderVertsArray;
					_collisionMesh.triangles = _colliderTrisArray;
					_mcollider.sharedMesh = null;
					_mcollider.sharedMesh = _collisionMesh;
					_mcollider.enabled = true;
				}
				else
				{
					_mcollider.sharedMesh = null;
					_mcollider.enabled = false;
				}
			}
		}
	}
}
