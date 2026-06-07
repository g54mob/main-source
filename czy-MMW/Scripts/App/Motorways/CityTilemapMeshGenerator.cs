using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways
{
	[ExecuteAlways]
	[RequireComponent(typeof(CityDefinition))]
	public class CityTilemapMeshGenerator : MonoBehaviour
	{
		private class MeshLayerSettings
		{
			public int erosion;

			public int subdivisions = 1;
		}

		private struct MeshSaveOperation
		{
			public string filename;

			public string objectName;

			public Mesh mesh;
		}

		private readonly Vector3 _baseWireframeHSV = new Vector3(0.1f, 0.9f, 0.9f);

		private const float WireframeLayerHueShift = 0.2f;

		private readonly MapVisualGroupType[] _activeVisualGroups = new MapVisualGroupType[2]
		{
			MapVisualGroupType.Land,
			MapVisualGroupType.Mountains
		};

		private readonly Dictionary<MapVisualGroupType, CityTilemapVisualGroupPreview> _visualGroupPreviews = new Dictionary<MapVisualGroupType, CityTilemapVisualGroupPreview>();

		private MapVisualGroup _landMeshVisualGroup;

		private MapVisualGroup _mountainVisualGroup;

		private MapVisualGroup[] _visualGroups = Array.Empty<MapVisualGroup>();

		private readonly IReadOnlyDictionary<MapMeshLayer, MeshLayerSettings> _meshLayerSettings = new Dictionary<MapMeshLayer, MeshLayerSettings>
		{
			{
				MapMeshLayer.Land,
				new MeshLayerSettings()
			},
			{
				MapMeshLayer.MountainA,
				new MeshLayerSettings()
			},
			{
				MapMeshLayer.MountainB,
				new MeshLayerSettings
				{
					erosion = 1
				}
			},
			{
				MapMeshLayer.MountainC,
				new MeshLayerSettings
				{
					erosion = 3,
					subdivisions = 2
				}
			}
		};

		public CityTilemap CityTilemap { get; private set; }

		public void SetMeshPreviewMaterials(Material material)
		{
			foreach (CityTilemapVisualGroupPreview value in _visualGroupPreviews.Values)
			{
				value.SetAllPreviewMaterials(material);
			}
		}

		private void Awake()
		{
			CityTilemap = GetComponent<CityTilemap>();
		}

		private void OnEnable()
		{
			CityTilemapVisualGroupPreview[] componentsInChildren = GetComponentsInChildren<CityTilemapVisualGroupPreview>();
			MapVisualGroupType[] activeVisualGroups = _activeVisualGroups;
			foreach (MapVisualGroupType visualGroupType in activeVisualGroups)
			{
				_visualGroupPreviews[visualGroupType] = componentsInChildren.FirstOrDefault((CityTilemapVisualGroupPreview cityTilemapVisualGroupPreview) => cityTilemapVisualGroupPreview.TargetVisualGroup.groupType == visualGroupType);
				if (_visualGroupPreviews[visualGroupType] == null)
				{
					GameObject obj = new GameObject();
					obj.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
					obj.name = $"{visualGroupType} Mesh Group Preview";
					obj.transform.parent = base.transform;
					GameObject gameObject = obj;
					_visualGroupPreviews[visualGroupType] = gameObject.AddComponent<CityTilemapVisualGroupPreview>();
				}
			}
			if (CityTilemap == null)
			{
				CityTilemap = GetComponent<CityTilemap>();
			}
			_landMeshVisualGroup = new MapVisualGroup
			{
				groupType = MapVisualGroupType.Land,
				sourceTilemap = CityTilemap.bridgeableTilemap,
				containedLayers = new MapMeshLayer[1] { MapMeshLayer.Land }
			};
			_visualGroupPreviews[_landMeshVisualGroup.groupType].SetVisualGroup(_landMeshVisualGroup);
			_mountainVisualGroup = new MapVisualGroup
			{
				groupType = MapVisualGroupType.Mountains,
				sourceTilemap = CityTilemap.mountainTilemap,
				containedLayers = new MapMeshLayer[3]
				{
					MapMeshLayer.MountainA,
					MapMeshLayer.MountainB,
					MapMeshLayer.MountainC
				}
			};
			_visualGroupPreviews[_mountainVisualGroup.groupType].SetVisualGroup(_mountainVisualGroup);
			_visualGroups = new MapVisualGroup[2] { _landMeshVisualGroup, _mountainVisualGroup };
			RegenerateAllMapLayerMeshes();
		}

		private void OnDisable()
		{
			if (!Application.isPlaying)
			{
				CityTilemapVisualGroupPreview[] componentsInChildren = GetComponentsInChildren<CityTilemapVisualGroupPreview>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					UnityEngine.Object.DestroyImmediate(componentsInChildren[i].gameObject);
				}
				_visualGroupPreviews.Clear();
			}
		}

		public void UpdatePreviewMeshVisibility(CityTilemapVisualGroupPreview groupPreview)
		{
			groupPreview.gameObject.SetActive(CityTilemapMeshGeneratorOptions.ShowPreviewMesh);
		}

		public void UpdateAllPreviewMeshVisibility()
		{
			foreach (CityTilemapVisualGroupPreview value in _visualGroupPreviews.Values)
			{
				value.gameObject.SetActive(CityTilemapMeshGeneratorOptions.ShowPreviewMesh);
			}
		}

		public void RegenerateAllMapLayerMeshes()
		{
			Diagnostics.FailAssert("CityTilemapMeshGenerator shouldn't be used at runtime! Remove it from any maps before building.");
		}

		public void RegenerateMapLayerMesh(MapVisualGroup visualGroup)
		{
		}

		public void UpdateMeshShownInPreview(CityTilemapVisualGroupPreview groupPreview)
		{
			groupPreview.Rebuild();
		}

		private void OnDrawGizmos()
		{
			int num = 0;
			foreach (CityTilemapVisualGroupPreview value2 in _visualGroupPreviews.Values)
			{
				if (!CityTilemapMeshGeneratorOptions.ShowWireMeshGizmo)
				{
					continue;
				}
				Vector3 cellCenterWorld = value2.TargetVisualGroup.sourceTilemap.GetCellCenterWorld(Vector3Int.zero);
				MapMeshLayer[] containedLayers = value2.TargetVisualGroup.containedLayers;
				foreach (MapMeshLayer key in containedLayers)
				{
					if (value2.TargetVisualGroup.generatedMeshes.TryGetValue(key, out var value))
					{
						Gizmos.color = Color.HSVToRGB(_baseWireframeHSV.x + (float)num++ * 0.2f, _baseWireframeHSV.y, _baseWireframeHSV.z);
						Gizmos.DrawWireMesh(value, cellCenterWorld, Quaternion.identity, new Vector3(2f, 2f, 2f));
					}
				}
			}
		}

		public void ExportAllMeshesAsFBX()
		{
		}

		public static void ExportMeshAsFBX(string defaultFilename, Mesh mesh)
		{
		}

		private static void ExportBinaryFBX(string filePath, UnityEngine.Object singleObject)
		{
		}
	}
}
