using Restory.Constants;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.Workplace;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementPlacementController
	{
		private readonly float maxRaycastDistance = 0.01f;

		private readonly float halfOfSide = 0.5f;

		private readonly RaycastHit[] raycastHits = new RaycastHit[8];

		private readonly GameCursorDetector cursorDetector;

		private readonly PlacementPositionFinder positionFinder;

		private readonly Vector3 defaultPlacementPosition;

		private readonly LayerMask placementLayerMask;

		private ElementBase element;

		private Transform elementTransform;

		private ElementPlacementPositionData elementPlacementPositionData;

		private Vector3 lastAvailablePosition;

		public RaycastHit LastPlacementHit { get; set; }

		[Inject]
		public ElementPlacementController(GameCursorDetector cursorDetector, PlacementPositionFinder positionFinder, WorkSurface workSurface)
		{
			this.cursorDetector = cursorDetector;
			this.positionFinder = positionFinder;
			defaultPlacementPosition = workSurface.DefaultPlacementPosition;
			placementLayerMask = ProjectConstants.Layers.ElementsMask | ProjectConstants.Layers.DeviceMask | ProjectConstants.Layers.DeviceContainerMask | ProjectConstants.Layers.ObstaclesMask | ProjectConstants.Layers.EquipmentMask;
		}

		public void SetTargetElement(ElementBase element)
		{
			ResetPlacementPosition();
			this.element = element;
			elementTransform = element.transform;
			elementPlacementPositionData = element.PlacementPositionHandler.PlacementPositionData;
		}

		public void SetTargetElement(ElementBase element, Vector3 lastAvailablePosition)
		{
			SetTargetElement(element);
			this.lastAvailablePosition = lastAvailablePosition;
		}

		public bool IsLastPlacementHitPositionAvailable(out RaycastHit collisionHit)
		{
			collisionHit = default(RaycastHit);
			if (!LastPlacementHit.transform)
			{
				return false;
			}
			Vector3 vector = LastPlacementHit.point - elementPlacementPositionData.PlacementPositionOffset;
			Quaternion placementRotation = elementPlacementPositionData.PlacementRotation;
			int num = BoxCastPlacementPosition(vector, placementRotation);
			elementTransform.position = vector;
			if (num == 0)
			{
				lastAvailablePosition = vector;
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				int layer = raycastHits[i].transform.gameObject.layer;
				collisionHit = raycastHits[i];
				if (layer == ProjectConstants.Layers.Equipment || layer == ProjectConstants.Layers.Device || layer == ProjectConstants.Layers.DeviceContainer)
				{
					break;
				}
			}
			if (!collisionHit.transform)
			{
				Debug.LogError("Lost collisionHit transform");
			}
			return false;
		}

		public bool TrySetPlacementPositionAndDropToSurface()
		{
			if (lastAvailablePosition == defaultPlacementPosition && !TryFindAvailablePlacementPosition(Quaternion.identity))
			{
				Debug.LogWarning("No available placement position for element " + elementTransform.name + " found");
				return false;
			}
			SetPlacementPosition();
			element.BehaviorSwitcher.SwitchToPlacedBehavior();
			return true;
		}

		public bool TryFindAvailablePlacementPosition(Quaternion rotationOffset)
		{
			Quaternion placementRotation = elementPlacementPositionData.PlacementRotation * rotationOffset;
			Vector3 initialFindingPosition = ((LastPlacementHit.point == default(Vector3)) ? defaultPlacementPosition : LastPlacementHit.point);
			return TryFindAvailablePlacementPosition(initialFindingPosition, placementRotation);
		}

		public bool TryFindAvailablePlacementPosition(Vector3 initialFindingPosition, out Vector3 availablePosition)
		{
			Quaternion placementRotation = elementPlacementPositionData.PlacementRotation;
			bool result = TryFindAvailablePlacementPosition(initialFindingPosition, placementRotation);
			availablePosition = lastAvailablePosition;
			return result;
		}

		public void SetPlacementPosition()
		{
			elementTransform.rotation = elementPlacementPositionData.PlacementRotation;
			elementTransform.position = lastAvailablePosition;
		}

		public void ResetPlacementPosition()
		{
			LastPlacementHit = default(RaycastHit);
			lastAvailablePosition = defaultPlacementPosition;
		}

		public void Clear()
		{
			element = null;
			elementTransform = null;
			elementPlacementPositionData = null;
		}

		private bool TryFindAvailablePlacementPosition(Vector3 initialFindingPosition, Quaternion placementRotation)
		{
			Physics.SyncTransforms();
			positionFinder.Reset(initialFindingPosition);
			while (positionFinder.CanContinue)
			{
				if (!positionFinder.CanMoveDirection)
				{
					positionFinder.SwitchDirection();
					continue;
				}
				Vector3 position = positionFinder.Position;
				if (!IsPositionInBounds(position))
				{
					positionFinder.BlockDirection();
					continue;
				}
				if (!IsPositionAvailable(position, placementRotation))
				{
					positionFinder.MoveDirection();
					continue;
				}
				lastAvailablePosition = position;
				return true;
			}
			return false;
		}

		private bool IsPositionAvailable(Vector3 targetPosition, Quaternion placementRotation)
		{
			Vector3 placementPosition = targetPosition - elementPlacementPositionData.PlacementPositionOffset;
			bool num = BoxCastPlacementPosition(placementPosition, placementRotation) == 0;
			if (num)
			{
				lastAvailablePosition = targetPosition;
			}
			return num;
		}

		private bool IsPositionInBounds(Vector3 targetPosition)
		{
			int hitCount;
			return cursorDetector.TryToDetectInWorldPosition(targetPosition, ProjectConstants.Layers.PlacementMask, raycastHits, out hitCount);
		}

		private int BoxCastPlacementPosition(Vector3 placementPosition, Quaternion placementRotation)
		{
			return Physics.BoxCastNonAlloc(placementPosition + elementPlacementPositionData.BoxColliderCenter, elementPlacementPositionData.BoxColliderSize * halfOfSide, elementPlacementPositionData.PlacementDirection, raycastHits, placementRotation, maxRaycastDistance, placementLayerMask);
		}
	}
}
