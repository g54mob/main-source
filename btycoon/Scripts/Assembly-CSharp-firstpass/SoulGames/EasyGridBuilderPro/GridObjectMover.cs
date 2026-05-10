using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SoulGames.EasyGridBuilderPro
{
	public class GridObjectMover : MonoBehaviour
	{
		public delegate void OnObjectStartMovingDelegate(EasyGridBuilderPro ownSystem, GameObject movingObject);

		public delegate void OnObjectStoppedMovingDelegate(EasyGridBuilderPro ownSystem, GameObject movingObject);

		[SerializeField]
		[ReadOnly]
		public GameObject movingObject;

		[SerializeField]
		private bool resetOnFalsePlace;

		private EasyGridBuilderPro currentActiveSystem;

		private LayerMask mouseColliderLayerMask;

		private bool useMoveModeActivationKey;

		private bool isBuildableMoveActive;

		private Transform parentObject;

		private Vector3 movingObjectPreviousPosition;

		private Vector3 movingObjectPreviousRotation;

		public static event OnObjectStartMovingDelegate OnObjectStartMoving;

		public static event OnObjectStoppedMovingDelegate OnObjectStoppedMoving;

		private void Start()
		{
			if (!(MultiGridManager.Instance.activeGridSystem == null))
			{
				currentActiveSystem = MultiGridManager.Instance.activeGridSystem;
				mouseColliderLayerMask = MultiGridManager.Instance.mouseColliderLayerMask;
			}
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
			if (!(MultiGridManager.Instance.activeGridSystem == null))
			{
				currentActiveSystem = MultiGridManager.Instance.activeGridSystem;
				if ((bool)movingObject && currentActiveSystem.GetGridMode() != GridMode.None && currentActiveSystem.GetGridMode() != GridMode.Moving)
				{
					GridObjectMover.OnObjectStoppedMoving?.Invoke(movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), movingObject);
					movingObject.transform.SetParent(null);
					movingObject.transform.position = movingObjectPreviousPosition;
					movingObject.transform.eulerAngles = movingObjectPreviousRotation;
					movingObject = null;
				}
			}
		}

		private void LateUpdate()
		{
			if (!(MultiGridManager.Instance.activeGridSystem == null) && movingObject != null)
			{
				if (currentActiveSystem.gridAxis == GridAxis.XZ)
				{
					Vector3 mouseWorldSnappedPositionForMoving = currentActiveSystem.GetMouseWorldSnappedPositionForMoving(movingObject.GetComponent<BuildableGridObject>().GetBuildableGridObjectTypeSO());
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(mouseWorldSnappedPositionForMoving.x, currentActiveSystem.GetGridOrigin().y, mouseWorldSnappedPositionForMoving.z), Time.deltaTime * 25f);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, currentActiveSystem.GetPlacedObjectRotationForMoving(movingObject.GetComponent<BuildableGridObject>().GetBuildableGridObjectTypeSO()), Time.deltaTime * 25f);
				}
				else
				{
					Vector3 mouseWorldSnappedPositionForMoving2 = currentActiveSystem.GetMouseWorldSnappedPositionForMoving(movingObject.GetComponent<BuildableGridObject>().GetBuildableGridObjectTypeSO());
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(mouseWorldSnappedPositionForMoving2.x, mouseWorldSnappedPositionForMoving2.y, currentActiveSystem.GetGridOrigin().z), Time.deltaTime * 25f);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, currentActiveSystem.GetPlacedObjectRotationForMoving(movingObject.GetComponent<BuildableGridObject>().GetBuildableGridObjectTypeSO()), Time.deltaTime * 25f);
				}
			}
		}

		public void SetInputGridModeVariables(bool useBuildModeActivationKey, bool useDestructionModeActivationKey, bool useSelectionModeActivationKey)
		{
		}

		public void SetGridModeReset()
		{
			if ((bool)movingObject)
			{
				GridObjectMover.OnObjectStoppedMoving?.Invoke(movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), movingObject);
				movingObject.transform.SetParent(null);
				movingObject.transform.position = movingObjectPreviousPosition;
				movingObject.transform.eulerAngles = movingObjectPreviousRotation;
				movingObject = null;
			}
		}

		public void SetGridModeMoving()
		{
			if (!useMoveModeActivationKey)
			{
				return;
			}
			isBuildableMoveActive = true;
			foreach (EasyGridBuilderPro easyGridBuilderPro in MultiGridManager.Instance.easyGridBuilderProList)
			{
				if (easyGridBuilderPro.GetGridMode() != GridMode.Moving)
				{
					easyGridBuilderPro.SetGridMode(GridMode.Moving);
				}
			}
		}

		public void TriggerBuildableMove()
		{
			if (!useMoveModeActivationKey)
			{
				isBuildableMoveActive = true;
			}
			if (isBuildableMoveActive && !IsPointerOverUI())
			{
				if (currentActiveSystem.GetGridMode() == GridMode.None || currentActiveSystem.GetGridMode() == GridMode.Moving)
				{
					if (currentActiveSystem.gridAxis == GridAxis.XZ)
					{
						HandleBuildingMovingXZ();
					}
					else
					{
						HandleBuildingMovingXY();
					}
				}
				else
				{
					DeselectSelectedObject();
				}
			}
			if (!useMoveModeActivationKey)
			{
				isBuildableMoveActive = false;
			}
		}

		private void HandleBuildingMovingXZ()
		{
			if (currentActiveSystem.GetGridObjectXZ(GetPlacedObjectCalculatedMouseWorldPositionXZ()) != null || currentActiveSystem.GetGridObjectXZ(GetMouseWorldPosition()) != null)
			{
				BuildableGridObject buildableGridObject = ((currentActiveSystem.GetGridObjectXZ(GetPlacedObjectCalculatedMouseWorldPositionXZ()) == null) ? currentActiveSystem.GetGridObjectXZ(GetMouseWorldPosition()).GetPlacedObject() : currentActiveSystem.GetGridObjectXZ(GetPlacedObjectCalculatedMouseWorldPositionXZ()).GetPlacedObject());
				if (buildableGridObject != null)
				{
					if (movingObject != null && movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem() != currentActiveSystem)
					{
						movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem().SetGridMode(GridMode.None);
					}
					movingObject = buildableGridObject.gameObject;
					currentActiveSystem.SetGridMode(GridMode.Moving);
					GridObjectMover.OnObjectStartMoving?.Invoke(movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), movingObject);
					HookMovingObject();
				}
				else
				{
					DeselectSelectedObject();
				}
			}
			else
			{
				DeselectSelectedObject();
			}
		}

		private void HookMovingObject()
		{
			if (movingObject != null)
			{
				movingObjectPreviousPosition = movingObject.transform.position;
				movingObjectPreviousRotation = movingObject.transform.eulerAngles;
				movingObject.transform.parent = base.transform;
				movingObject.transform.localPosition = Vector3.zero;
				movingObject.transform.localEulerAngles = Vector3.zero;
				parentObject = new GameObject(movingObject.GetComponent<BuildableGridObject>().GetBuildableGridObjectTypeSO().name).transform;
				parentObject.parent = base.transform;
				parentObject.localPosition = Vector3.zero;
				parentObject.localEulerAngles = Vector3.zero;
				parentObject.localScale = new Vector3(parentObject.localScale.x + 0.01f, parentObject.localScale.y + 0.01f, parentObject.localScale.z + 0.01f);
				movingObject.transform.parent = parentObject;
				Vector2Int vector2Int = movingObject.GetComponent<BuildableGridObject>().GetBuildableGridObjectTypeSO().CalculatePlacedObjectSize(currentActiveSystem.GetGridCellSize());
				if (currentActiveSystem.gridAxis == GridAxis.XZ)
				{
					parentObject.localPosition = new Vector3((float)vector2Int.x * currentActiveSystem.GetGridCellSize() / 2f, movingObject.transform.localPosition.y, (float)vector2Int.y * currentActiveSystem.GetGridCellSize() / 2f);
				}
				else
				{
					parentObject.localPosition = new Vector3((float)vector2Int.x * currentActiveSystem.GetGridCellSize() / 2f, (float)vector2Int.y * currentActiveSystem.GetGridCellSize() / 2f, movingObject.transform.localPosition.z);
				}
			}
		}

		private void HandleBuildingMovingXY()
		{
			if (currentActiveSystem.GetGridObjectXY(GetMouseWorldPosition()) != null)
			{
				BuildableGridObject placedObject = currentActiveSystem.GetGridObjectXY(GetMouseWorldPosition()).GetPlacedObject();
				if (placedObject != null)
				{
					if (movingObject != null && movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem() != currentActiveSystem)
					{
						movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem().SetGridMode(GridMode.None);
					}
					movingObject = placedObject.gameObject;
					currentActiveSystem.SetGridMode(GridMode.Selected);
					if (currentActiveSystem.showConsoleText && currentActiveSystem.objectSelected)
					{
						Debug.Log("Grid XY <color=green>Object selected :</color> " + placedObject);
					}
					GridObjectMover.OnObjectStartMoving?.Invoke(movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), movingObject);
				}
				else
				{
					DeselectSelectedObject();
				}
			}
			else
			{
				DeselectSelectedObject();
			}
		}

		private void DeselectSelectedObject()
		{
			if (resetOnFalsePlace && (bool)movingObject)
			{
				Debug.Log("Here");
				GridObjectMover.OnObjectStoppedMoving?.Invoke(movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), movingObject);
				movingObject.GetComponent<BuildableGridObject>().GetOwnGridSystem().SetGridMode(GridMode.None);
				movingObject.transform.position = movingObjectPreviousPosition;
				movingObject.transform.eulerAngles = movingObjectPreviousRotation;
				movingObject.transform.SetParent(null);
				movingObject = null;
			}
		}

		private Vector3 GetPlacedObjectCalculatedMouseWorldPositionXZ()
		{
			Vector3 placedObjectMouseWorldPosition = GetPlacedObjectMouseWorldPosition();
			if (Physics.Raycast(new Vector3(placedObjectMouseWorldPosition.x, placedObjectMouseWorldPosition.y + 100f, placedObjectMouseWorldPosition.z), Vector3.down, out var hitInfo, 999f, mouseColliderLayerMask))
			{
				return hitInfo.point;
			}
			return new Vector3(-99999f, -99999f, -99999f);
		}

		public bool IsPointerOverUI()
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			foreach (RaycastResult item in list)
			{
				if (item.gameObject.GetComponent<RectTransform>() != null)
				{
					return true;
				}
			}
			return false;
		}

		private Vector3 GetMouseWorldPosition()
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f, mouseColliderLayerMask))
			{
				return hitInfo.point;
			}
			return new Vector3(-99999f, -99999f, -99999f);
		}

		private Vector3 GetPlacedObjectMouseWorldPosition()
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f))
			{
				if ((bool)hitInfo.collider.transform.root.GetComponent<BuildableGridObject>())
				{
					return hitInfo.collider.transform.root.GetComponent<BuildableGridObject>().transform.position;
				}
				return new Vector3(-99999f, -99999f, -99999f);
			}
			return new Vector3(-99999f, -99999f, -99999f);
		}
	}
}
