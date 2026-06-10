using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using NSMedieval.Model;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.Construction
{
	[RequireComponent(typeof(BuildingUsePositionsComponent))]
	public class BaseBuildingPreview : MonoBehaviour
	{
		private GameObject marker;

		private List<GameObject> workPositionsMarkers;

		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		public void SetMarkerTransform(BaseBuildingBlueprint blueprint)
		{
			if (!string.IsNullOrEmpty(blueprint.PreviewMarkerPrefabId))
			{
				marker = GameObjectPool.Get(blueprint.PreviewMarkerPrefabId);
				marker.transform.SetParent(base.transform, worldPositionStays: false);
				blueprint.PreviewMarkerOffset.ApplyToTransform(marker.transform);
			}
		}

		public void SetWorkPositionsMarkersTransforms(BaseBuildingBlueprint blueprint)
		{
			if (blueprint.WorkPositionsArray != null && blueprint.WorkPositionsArray.Length != 0)
			{
				TransformSettings[] workPositionsArray = blueprint.WorkPositionsArray;
				foreach (TransformSettings obj in workPositionsArray)
				{
					GameObject gameObject = GameObjectPool.Get("WorkerPositionMarker");
					gameObject.transform.SetParent(buildingUsePositionsComponent.WorkPositionsParent, worldPositionStays: false);
					obj.ApplyToTransform(gameObject.transform);
					workPositionsMarkers.Add(gameObject);
				}
			}
		}

		private void Awake()
		{
			workPositionsMarkers = new List<GameObject>();
			buildingUsePositionsComponent = GetComponent<BuildingUsePositionsComponent>();
		}

		private void OnDestroy()
		{
			if (marker == null)
			{
				return;
			}
			GameObjectPool.Return(marker);
			if (workPositionsMarkers == null)
			{
				return;
			}
			foreach (GameObject workPositionsMarker in workPositionsMarkers)
			{
				GameObjectPool.Return(workPositionsMarker);
			}
			workPositionsMarkers.Clear();
		}
	}
}
