using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SoulGames.EasyGridBuilderPro
{
	public class GridObjectSelector : MonoBehaviour
	{
		public delegate void OnObjectSelectDelegate(EasyGridBuilderPro ownSystem, GameObject selectedObject);

		public delegate void OnObjectDeselectDelegate(EasyGridBuilderPro ownSystem, GameObject selectedObject);

		[Tooltip("Read Only, Display currently selected object.")]
		[SerializeField]
		[ReadOnly]
		public GameObject selectedObject;

		[Tooltip("If enabled, When clicked on somewhere that is not selectable, the previous selected object will be deselected and the grid mode will reset.")]
		[SerializeField]
		private bool deselectOnFalseSelect = true;

		private LayerMask mouseColliderLayerMask;

		private EasyGridBuilderPro currentActiveSystem;

		private bool useSelectionModeActivationKey;

		private bool isBuildableSelectionActive;

		public static event OnObjectSelectDelegate OnObjectSelect;

		public static event OnObjectDeselectDelegate OnObjectDeselect;

		private void Start()
		{
			if (!(MultiGridManager.Instance.activeGridSystem == null))
			{
				currentActiveSystem = MultiGridManager.Instance.activeGridSystem;
				mouseColliderLayerMask = MultiGridManager.Instance.mouseColliderLayerMask;
			}
		}

		protected void Update()
		{
			if (!(MultiGridManager.Instance.activeGridSystem == null))
			{
				currentActiveSystem = MultiGridManager.Instance.activeGridSystem;
				if ((bool)selectedObject && currentActiveSystem.GetGridMode() != GridMode.None && currentActiveSystem.GetGridMode() != GridMode.Selected)
				{
					GridObjectSelector.OnObjectDeselect?.Invoke(selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), selectedObject);
					selectedObject = null;
				}
			}
		}

		public void SetInputGridModeVariables(bool useBuildModeActivationKey, bool useDestructionModeActivationKey, bool useSelectionModeActivationKey)
		{
			this.useSelectionModeActivationKey = useSelectionModeActivationKey;
		}

		public void SetGridModeReset()
		{
			if ((bool)selectedObject)
			{
				GridObjectSelector.OnObjectDeselect?.Invoke(selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), selectedObject);
				selectedObject = null;
			}
		}

		public void SetGridModeSelection()
		{
			if (!useSelectionModeActivationKey)
			{
				return;
			}
			foreach (EasyGridBuilderPro easyGridBuilderPro in MultiGridManager.Instance.easyGridBuilderProList)
			{
				if (easyGridBuilderPro.GetGridMode() != GridMode.Selected)
				{
					isBuildableSelectionActive = true;
					easyGridBuilderPro.SetGridMode(GridMode.Selected);
				}
				else
				{
					isBuildableSelectionActive = false;
					easyGridBuilderPro.SetGridMode(GridMode.None);
					SetGridModeReset();
				}
			}
		}

		public void TriggerBuildableSelection()
		{
			if (!useSelectionModeActivationKey)
			{
				isBuildableSelectionActive = true;
			}
			if (isBuildableSelectionActive && !IsPointerOverUI())
			{
				if (currentActiveSystem.GetGridMode() == GridMode.None || currentActiveSystem.GetGridMode() == GridMode.Selected)
				{
					if (currentActiveSystem.gridAxis == GridAxis.XZ)
					{
						HandleBuildingSelectionXZ();
					}
					else
					{
						HandleBuildingSelectionXY();
					}
				}
				else
				{
					DeselectSelectedObject();
				}
			}
			if (!useSelectionModeActivationKey)
			{
				isBuildableSelectionActive = false;
			}
		}

		private void HandleBuildingSelectionXZ()
		{
			if (currentActiveSystem.GetGridObjectXZ(GetPlacedObjectCalculatedMouseWorldPositionXZ()) != null || currentActiveSystem.GetGridObjectXZ(GetMouseWorldPosition()) != null)
			{
				BuildableGridObject buildableGridObject = ((currentActiveSystem.GetGridObjectXZ(GetPlacedObjectCalculatedMouseWorldPositionXZ()) == null) ? currentActiveSystem.GetGridObjectXZ(GetMouseWorldPosition()).GetPlacedObject() : currentActiveSystem.GetGridObjectXZ(GetPlacedObjectCalculatedMouseWorldPositionXZ()).GetPlacedObject());
				if (buildableGridObject != null)
				{
					if (selectedObject != null && selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem() != currentActiveSystem)
					{
						selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem().SetGridMode(GridMode.None);
					}
					selectedObject = buildableGridObject.gameObject;
					currentActiveSystem.SetGridMode(GridMode.Selected);
					if (currentActiveSystem.showConsoleText && currentActiveSystem.objectSelected)
					{
						Debug.Log("Grid XZ <color=green>Object selected :</color> " + buildableGridObject);
					}
					GridObjectSelector.OnObjectSelect?.Invoke(selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), selectedObject);
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

		private void HandleBuildingSelectionXY()
		{
			if (currentActiveSystem.GetGridObjectXY(GetMouseWorldPosition()) != null)
			{
				BuildableGridObject placedObject = currentActiveSystem.GetGridObjectXY(GetMouseWorldPosition()).GetPlacedObject();
				if (placedObject != null)
				{
					if (selectedObject != null && selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem() != currentActiveSystem)
					{
						selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem().SetGridMode(GridMode.None);
					}
					selectedObject = placedObject.gameObject;
					currentActiveSystem.SetGridMode(GridMode.Selected);
					if (currentActiveSystem.showConsoleText && currentActiveSystem.objectSelected)
					{
						Debug.Log("Grid XY <color=green>Object selected :</color> " + placedObject);
					}
					GridObjectSelector.OnObjectSelect?.Invoke(selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), selectedObject);
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
			if (deselectOnFalseSelect && (bool)selectedObject)
			{
				GridObjectSelector.OnObjectDeselect?.Invoke(selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem(), selectedObject);
				selectedObject.GetComponent<BuildableGridObject>().GetOwnGridSystem().SetGridMode(GridMode.None);
				selectedObject = null;
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

		protected Vector3 GetMouseWorldPosition()
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
