using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class TileSlotSelector : MonoBehaviour
	{
		private sealed class _003C_003Ec__DisplayClass36_0
		{
			public Vector3 worldRaycastStartPoint;

			internal float _003CPerformSearchIteration_003Eb__0(ISelectable x)
			{
				return Vector3.Distance(x.Transform.position, worldRaycastStartPoint);
			}
		}

		[SerializeField]
		private Vector2 defaultCameraFocus = new Vector2(0.5f, 0.5f);

		[SerializeField]
		private float selectionChangeInterval = 0.3f;

		[SerializeField]
		private AnimationCurve selectionChangeSpeedByInputIntensity;

		[SerializeField]
		private float raycastStepWorldSpace = 0.5f;

		[FormerlySerializedAs("raycastCircleStepWorldSpace")]
		[SerializeField]
		private float searchArcStep = 0.3f;

		[SerializeField]
		private List<SearchIterationData> searchIterations;

		[SerializeField]
		private SearchIterationData stationarySearchIteration;

		[SerializeField]
		private Vector2 offscreenViewportVisibilityTreshold = new Vector2(0.1f, 0.1f);

		[SerializeField]
		private Vector2 deselectionViewportVisibilityTreshold = new Vector2(-0.1f, -0.1f);

		[SerializeField]
		private bool deselectTileSlotIfNoLongerVisible;

		[SerializeField]
		private bool moveCameraTowardsSelectedSlot;

		[SerializeField]
		private Vector2 cameraMovementTreshold = new Vector2(0.25f, 0.25f);

		[SerializeField]
		private float cameraMovementDeselectionThreshold = 2f;

		[SerializeField]
		private GameObject selectedTileSlotPreview;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

		private ISelectable selectedObject;

		private CameraMovement cameraMover;

		private Camera mainCamera;

		private bool waitingForSelectionChangeInterval;

		private float waitingDuration;

		private Vector3 lastSelectedPosition = Vector3.zero;

		private Vector2 currentInputValue;

		private InputManager inputManager;

		private List<ISelectable> foundSelectables = new List<ISelectable>();

		private float manualCameraMovement;

		private TargetSearchType searchType = TargetSearchType.TileSlot;

		private void Start()
		{
			mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
			cameraMover = OverwritingSingleton<IngameUi>.Instance.cameraContainer.GetComponent<CameraMovement>();
			inputManager = Singleton<InputManager>.Instance;
			inputRouter.OnChangeSelectedTileSlot += MoveSelection;
			inputRouter.OnChangeSelectionInputStopped += ResetWatingTimer;
			inputRouter.OnMovePreviewTile += SetSelectedTileSlotFromPreviewMoved;
			inputRouter.OnMoveCameraToSelection += MoveCameraToSelection;
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized += ResetSelectedTileSlotFromTilePlaced;
			cameraMover.OnCameraMoved += CheckIfTargetStillVisible;
			inputRouter.OnToolEnabled += ChangeSearchTypeBasedOnTool;
			ChangeSelected(null);
			InitializeSelection();
		}

		private void MoveSelectionToUndoneTile(Vector3 undoneTileWorldPos)
		{
			lastSelectedPosition = undoneTileWorldPos;
			Debug.Log($"move selection to undone tile at {undoneTileWorldPos}");
			MoveSelection(Vector2.zero);
		}

		private void ChangeSearchTypeBasedOnTool(ToolId toolId, bool toolIsEnabled)
		{
			if (toolIsEnabled && Singleton<InputManager>.Instance.CurrentInputDevice != InputDevice.MouseKeyboard)
			{
				if (toolId != ToolId.None)
				{
					inputRouter.MovePreviewTile(null);
				}
				TargetSearchType targetSearchType = TargetSearchType.Undefined;
				switch (toolId)
				{
				case ToolId.None:
				case ToolId.MatchingTile:
					targetSearchType = TargetSearchType.TileSlot;
					break;
				case ToolId.TileDeletion:
				case ToolId.Pipette:
					targetSearchType = TargetSearchType.Tile;
					break;
				}
				searchType = targetSearchType;
				InitializeSelection();
			}
		}

		private void InitializeSelection()
		{
			ChangeSelected(null);
			waitingDuration = 0f;
			MoveSelection(Vector2.zero);
		}

		private void CheckIfTargetStillVisible(Vector2 cameraMovementVector, bool cameraMovedByPlayer)
		{
			if (selectedObject != null && deselectTileSlotIfNoLongerVisible && !IsVisibleByCamera(selectedObject.Transform))
			{
				ChangeSelected(null);
			}
			if (cameraMovedByPlayer)
			{
				manualCameraMovement += cameraMovementVector.magnitude;
			}
		}

		private void ResetWatingTimer()
		{
			waitingDuration = 0f;
		}

		private void ResetSelectedTileSlotFromTilePlaced(Tile placedTile, bool placedByPlayer)
		{
			if (placedByPlayer)
			{
				ChangeSelected(null);
				waitingDuration = 0f;
			}
		}

		private void SetSelectedTileSlotFromPreviewMoved(TileSlot targetTileSlot)
		{
			if (inputRouter.ActiveTool == ToolId.None || !(targetTileSlot != null))
			{
				selectedTileSlotPreview.gameObject.SetActive(selectedObject is TileSlot tileSlot && tileSlot == targetTileSlot);
				if (selectedObject != null)
				{
					selectedTileSlotPreview.transform.position = selectedObject.Transform.position;
				}
				selectedObject = targetTileSlot;
			}
		}

		private void MoveSelection(Vector2 searchDirection)
		{
			waitingDuration -= Time.deltaTime * selectionChangeSpeedByInputIntensity.Evaluate(searchDirection.magnitude);
			if (waitingDuration > 0f)
			{
				return;
			}
			Vector3 vector = lastSelectedPosition;
			Vector3 normalized = Vector3.ProjectOnPlane(cameraMover.transform.TransformVector(searchDirection), Vector3.up).normalized;
			if (!IsVisibleByCamera(lastSelectedPosition, deselectionViewportVisibilityTreshold) && manualCameraMovement >= cameraMovementDeselectionThreshold && searchDirection.magnitude > 0f)
			{
				Debug.Log($"Move worldRaycastStartPoint to {vector} since camera was moved");
				vector = ScreenToWorldFocus(defaultCameraFocus);
			}
			if (searchDirection.magnitude == 0f)
			{
				normalized = Vector3.ProjectOnPlane(cameraMover.transform.transform.forward, Vector3.up).normalized;
				PerformSearchIteration(vector, normalized, stationarySearchIteration);
				return;
			}
			foreach (SearchIterationData searchIteration in searchIterations)
			{
				if (PerformSearchIteration(vector, normalized, searchIteration))
				{
					break;
				}
			}
		}

		private bool PerformSearchIteration(Vector3 worldRaycastStartPoint, Vector3 worldSearchDirection, SearchIterationData searchIteration)
		{
			_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass36_0();
			CS_0024_003C_003E8__locals8.worldRaycastStartPoint = worldRaycastStartPoint;
			foundSelectables.Clear();
			ISelectable objectToCheck = RaycastForSelectableAtPosition(CS_0024_003C_003E8__locals8.worldRaycastStartPoint);
			AddFoundObjectIfValid(objectToCheck, foundSelectables, searchIteration);
			float num = searchArcStep;
			Vector3 vector = CS_0024_003C_003E8__locals8.worldRaycastStartPoint;
			Vector3 vector2 = CS_0024_003C_003E8__locals8.worldRaycastStartPoint;
			for (; num <= searchIteration.searchDistance; num += raycastStepWorldSpace)
			{
				Vector3 vector3 = worldSearchDirection * num;
				Vector3 worldPos = CS_0024_003C_003E8__locals8.worldRaycastStartPoint + vector3;
				ISelectable objectToCheck2 = RaycastForSelectableAtPosition(worldPos);
				AddFoundObjectIfValid(objectToCheck2, foundSelectables, searchIteration);
				if (foundSelectables.Count > 0)
				{
					break;
				}
				float num2 = (float)Math.PI * 2f * num;
				float num3 = searchArcStep / num2 * 360f;
				float num4 = 0f;
				float num5 = 0f;
				float num6 = searchIteration.maxAngle * searchIteration.coneAngleByRadius.Evaluate(num) / 2f;
				float num7 = searchIteration.maxCircleSegmentLength / 2f;
				Vector3 vector4 = vector;
				Vector3 vector5 = vector2;
				while (foundSelectables.Count == 0 && num4 < num6 && num5 < num7)
				{
					num4 = Mathf.Clamp(num4 + num3, 0f, num6);
					num5 = Mathf.Clamp(num5 + searchArcStep, 0f, num7);
					vector4 = CS_0024_003C_003E8__locals8.worldRaycastStartPoint + Quaternion.AngleAxis(num4, Vector3.up) * vector3;
					objectToCheck2 = RaycastForSelectableAtPosition(vector4);
					AddFoundObjectIfValid(objectToCheck2, foundSelectables, searchIteration);
					Debug.DrawLine(vector4 + Vector3.up, vector4, searchIteration.debugColor, searchIteration.debugDuration);
					vector5 = CS_0024_003C_003E8__locals8.worldRaycastStartPoint + Quaternion.AngleAxis(0f - num4, Vector3.up) * vector3;
					objectToCheck2 = RaycastForSelectableAtPosition(vector5);
					AddFoundObjectIfValid(objectToCheck2, foundSelectables, searchIteration);
					Debug.DrawLine(vector5 + Vector3.up, vector5, searchIteration.debugColor, searchIteration.debugDuration);
				}
				Debug.DrawLine(vector, vector4, searchIteration.debugColor, searchIteration.debugDuration);
				Debug.DrawLine(vector2, vector5, searchIteration.debugColor, searchIteration.debugDuration);
				vector = vector4;
				vector2 = vector5;
				if (foundSelectables.Count > 0)
				{
					break;
				}
			}
			Debug.DrawLine(vector, vector2, searchIteration.debugColor, 3f);
			if (foundSelectables.Count > 0)
			{
				foundSelectables = Enumerable.ToList(Enumerable.OrderByDescending(Enumerable.Distinct(foundSelectables), (ISelectable x) => Vector3.Distance(x.Transform.position, CS_0024_003C_003E8__locals8.worldRaycastStartPoint)));
				ChangeSelected(foundSelectables[0]);
				waitingDuration = selectionChangeInterval;
				manualCameraMovement = 0f;
				return true;
			}
			return false;
		}

		private void ChangeSelected(ISelectable newSelected)
		{
			selectedObject = newSelected;
			if (inputRouter.ActiveTool == ToolId.None)
			{
				inputRouter.MovePreviewTile((TileSlot)selectedObject);
			}
			else
			{
				inputRouter.ShowToolPreview(inputRouter.ActiveTool, selectedObject);
				Debug.Log($"Show preview for {inputRouter.ActiveTool} at {selectedObject}");
			}
			if (selectedObject != null && inputManager.gamepadInputType == GamepadInputType.SearchCone)
			{
				lastSelectedPosition = selectedObject.Transform.position;
				cameraMover.MoveCameraUntilInView(selectedObject.Transform.position, cameraMovementTreshold);
			}
		}

		private void MoveCameraToSelection()
		{
			if (selectedObject != null)
			{
				cameraMover.MoveCameraTowardsPrecisePosition(selectedObject.Transform.position, 2f);
			}
		}

		private void AddFoundObjectIfValid(ISelectable objectToCheck, List<ISelectable> validSelectables, SearchIterationData searchIterationData = null)
		{
			if (objectToCheck != null && objectToCheck != selectedObject && !(objectToCheck is TileSlot { IsValid: false }) && (searchIterationData == null || searchIterationData.searchOffscreen || !(objectToCheck is Component component) || IsVisibleByCamera(component.transform)) && (searchIterationData == null || !searchIterationData.searchOffscreen || !searchIterationData.limitOffscreenSearchDistance || !(objectToCheck is Component component2) || IsVisibleByCamera(component2.transform.position, searchIterationData.maxOffscreenDistance)))
			{
				validSelectables.Add(objectToCheck);
			}
		}

		private bool IsVisibleByCamera(Transform transformToCheck)
		{
			return IsVisibleByCamera(transformToCheck.position, offscreenViewportVisibilityTreshold);
		}

		private bool IsVisibleByCamera(Vector3 checkPosition, Vector2 offscreenVisibilityThreshold)
		{
			return CameraUtility.IsVisibleByCamera(checkPosition, mainCamera, offscreenVisibilityThreshold);
		}

		private ISelectable RaycastForSelectableAtPosition(Vector3 worldPos, SearchIterationData iterationData = null)
		{
			Ray ray = new Ray(worldPos + Vector3.up * 0.5f, Vector3.down);
			int num = ((searchType == TargetSearchType.Tile) ? 10 : 8);
			Physics.Raycast(ray, out var hitInfo, 1f, 1 << num);
			if (hitInfo.collider != null)
			{
				Debug.DrawLine(worldPos + Vector3.up * 0.5f, worldPos + Vector3.down, Color.green);
				return hitInfo.collider.GetComponent<ISelectable>();
			}
			Debug.DrawLine(worldPos + Vector3.up * 0.5f, worldPos + Vector3.down, Color.red);
			return null;
		}

		private Vector3 ScreenToWorldFocus(Vector2 screenFocus)
		{
			Ray ray = mainCamera.ScreenPointToRay(new Vector3(screenFocus.x * (float)Screen.width, screenFocus.y * (float)Screen.height));
			new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter);
			return ray.GetPoint(enter);
		}

		private void OnDestroy()
		{
			inputRouter.OnChangeSelectedTileSlot -= MoveSelection;
			inputRouter.OnChangeSelectionInputStopped -= ResetWatingTimer;
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= ResetSelectedTileSlotFromTilePlaced;
			inputRouter.OnMovePreviewTile -= SetSelectedTileSlotFromPreviewMoved;
			inputRouter.OnMoveCameraToSelection -= MoveCameraToSelection;
			cameraMover.OnCameraMoved -= CheckIfTargetStillVisible;
			inputRouter.OnToolEnabled -= ChangeSearchTypeBasedOnTool;
		}
	}
}
