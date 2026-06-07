using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	[ExecuteAlways]
	public class CityTilemapVisualGroupPreview : MonoBehaviour
	{
		private readonly List<CityTilemapMeshPreview> _meshPreviews = new List<CityTilemapMeshPreview>();

		private readonly IReadOnlyDictionary<MapVisualGroupType, string> _sortingLayers = new Dictionary<MapVisualGroupType, string>
		{
			{
				MapVisualGroupType.Land,
				"Landscape"
			},
			{
				MapVisualGroupType.Mountains,
				"Mountain"
			}
		};

		private readonly IReadOnlyDictionary<MapVisualGroupType, string[]> _themeKeys = new Dictionary<MapVisualGroupType, string[]>
		{
			{
				MapVisualGroupType.Land,
				new string[1] { "Binding_Land" }
			},
			{
				MapVisualGroupType.Mountains,
				new string[4] { "Binding_MountainA", "Binding_MountainB", "Binding_MountainC", "Binding_Shadow" }
			}
		};

		public MapVisualGroup TargetVisualGroup { get; private set; }

		public void SetVisualGroup(MapVisualGroup visualGroup)
		{
			TargetVisualGroup = visualGroup;
		}

		public void Teardown()
		{
			foreach (CityTilemapMeshPreview meshPreview in _meshPreviews)
			{
				Object.DestroyImmediate(meshPreview.gameObject);
			}
			_meshPreviews.Clear();
		}

		public void Rebuild()
		{
			Teardown();
			int num = 0;
			int num2 = ((TargetVisualGroup.groupType == MapVisualGroupType.Mountains) ? 3 : 0);
			MapMeshLayer[] containedLayers = TargetVisualGroup.containedLayers;
			foreach (MapMeshLayer key in containedLayers)
			{
				Mesh previewMesh = TargetVisualGroup.generatedMeshes[key];
				GameObject obj = new GameObject();
				obj.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
				obj.name = "Mesh Preview";
				obj.transform.parent = base.transform;
				CityTilemapMeshPreview cityTilemapMeshPreview = obj.AddComponent<CityTilemapMeshPreview>();
				cityTilemapMeshPreview.SetPreviewMesh(previewMesh);
				List<Material> list = FindAssetsOfType<Material>(_themeKeys[TargetVisualGroup.groupType][num]);
				if (list.Count > 0)
				{
					cityTilemapMeshPreview.SetPreviewMaterial(list[0]);
				}
				cityTilemapMeshPreview.SetSortingLayer(_sortingLayers[TargetVisualGroup.groupType]);
				cityTilemapMeshPreview.SetSortingOrder(num2 + num);
				_meshPreviews.Add(cityTilemapMeshPreview);
				num++;
			}
		}

		public void SetAllPreviewMaterials(Material material)
		{
			foreach (CityTilemapMeshPreview meshPreview in _meshPreviews)
			{
				meshPreview.SetPreviewMaterial(material);
			}
		}

		private static List<T> FindAssetsOfType<T>(string filterString) where T : class
		{
			return new List<T>();
		}
	}
}
