using System.Collections.Generic;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Workplace;
using UnityEngine;

namespace Restory.Gameplay.Competitions
{
	public class CompetitionElementsPositioner
	{
		private readonly WorkSurface workSurface;

		private readonly ElementPlacementController elementPlacementController;

		private readonly SmallElementBin smallElementsBin;

		private readonly CompetitionElementPositionObjectsPool elementPositionObjectsPool;

		private readonly List<GameObject> placementCalculationObjects = new List<GameObject>();

		public CompetitionElementsPositioner(WorkSurface workSurface, SmallElementBin smallElementsBin, ElementPlacementController elementPlacementController, CompetitionElementPositionObjectsPool elementPositionObjectsPool)
		{
			this.elementPositionObjectsPool = elementPositionObjectsPool;
			this.smallElementsBin = smallElementsBin;
			this.elementPlacementController = elementPlacementController;
			this.workSurface = workSurface;
		}

		public void PlaceElementsForCompetitionInitially(PlacedElements placedElements)
		{
			foreach (ElementTransformRecord item in placedElements.ElementsOnSurface)
			{
				elementPlacementController.SetTargetElement(item.Element);
				if (!elementPlacementController.TryFindAvailablePlacementPosition(workSurface.DefaultPlacementPosition, out var availablePosition))
				{
					Debug.LogError("[CompetitionElementsPositioner] tried to place an element, but no available position was found for element " + item.Element.name + "!");
					continue;
				}
				GameObject gameObject = elementPositionObjectsPool.Get().gameObject;
				if (!gameObject.TryGetComponent<BoxCollider>(out var component))
				{
					Debug.LogError("[CompetitionElementsPositioner] tried to place an element, but a positioning calculation game object spawned from the pool has no box collider attached!");
					return;
				}
				gameObject.transform.position = availablePosition;
				gameObject.transform.rotation = item.Element.PlacementPositionHandler.PlacementPositionData.PlacementRotation;
				gameObject.transform.localScale = item.Element.transform.localScale;
				component.center = item.Element.PlacementPositionHandler.PlacementPositionData.BoxColliderCenter;
				component.size = item.Element.PlacementPositionHandler.PlacementPositionData.BoxColliderSize;
				placementCalculationObjects.Add(gameObject);
			}
			for (int i = 0; i < placedElements.ElementsOnSurface.Count; i++)
			{
				ElementBase element = placedElements.ElementsOnSurface[i].Element;
				Transform transform = element.transform;
				Vector3 position = placementCalculationObjects[i].transform.position;
				Quaternion rotation = placementCalculationObjects[i].transform.rotation;
				transform.SetPositionAndRotation(position, rotation);
				ElementTransformRecord value = new ElementTransformRecord(element, transform.localPosition, transform.localRotation);
				placedElements.ElementsOnSurface[i] = value;
			}
			foreach (GameObject placementCalculationObject in placementCalculationObjects)
			{
				elementPositionObjectsPool.Release(placementCalculationObject);
			}
			placementCalculationObjects.Clear();
			foreach (ElementTransformRecord item2 in placedElements.ElementsOnSurface)
			{
				workSurface.AddElement(item2.Element, silent: true);
				item2.Element.BehaviorSwitcher.SwitchToPlacedBehavior();
			}
			foreach (ElementTransformRecord item3 in placedElements.ElementsInBin)
			{
				workSurface.AddElement(item3.Element, silent: true);
				smallElementsBin.PutElement(item3.Element);
			}
		}
	}
}
