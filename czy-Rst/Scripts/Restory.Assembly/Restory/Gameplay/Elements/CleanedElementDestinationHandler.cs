using Restory.Gameplay.Workplace;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class CleanedElementDestinationHandler
	{
		private readonly WorkSurface workSurface;

		private readonly ElementPlacementController placementController;

		private ElementBase targetElement;

		private Vector3 destinationPosition;

		public ElementBase TargetElement => targetElement;

		[Inject]
		public CleanedElementDestinationHandler(WorkSurface workSurface, ElementPlacementController placementController)
		{
			this.workSurface = workSurface;
			this.placementController = placementController;
		}

		public void SetTargetElement(ElementBase targetElement)
		{
			this.targetElement = targetElement;
			if (!targetElement)
			{
				destinationPosition = Vector3.zero;
				return;
			}
			if (targetElement.PlacementPositionHandler.LastPlacementPosition != Vector3.zero)
			{
				destinationPosition = new Vector3(targetElement.PlacementPositionHandler.LastPlacementPosition.x, workSurface.DefaultPlacementPosition.y, targetElement.PlacementPositionHandler.LastPlacementPosition.z);
				return;
			}
			placementController.SetTargetElement(targetElement);
			if (placementController.TryFindAvailablePlacementPosition(workSurface.CleanedElementPlacementPosition, out var availablePosition))
			{
				destinationPosition = new Vector3(availablePosition.x, workSurface.DefaultPlacementPosition.y, availablePosition.z);
			}
			else
			{
				destinationPosition = workSurface.DefaultPlacementPosition;
			}
		}

		public Vector3 GetCleanedElementDestinationPosition(ElementBase cleanedElement)
		{
			if (cleanedElement == targetElement)
			{
				return destinationPosition;
			}
			Debug.LogError("cleanedElement was not set as the target");
			return workSurface.DefaultPlacementPosition;
		}
	}
}
