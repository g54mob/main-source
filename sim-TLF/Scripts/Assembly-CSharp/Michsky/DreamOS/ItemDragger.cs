using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	public class ItemDragger : UIBehaviour, IPointerEnterHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[Header("Resources")]
		public ItemDragContainer dragContainer;

		private RectTransform dragObject;

		[Header("Settings")]
		public bool rememberPosition;

		[SerializeField]
		private string saveKey;

		private Vector2 originalLocalPointerPosition;

		private Vector3 originalPanelLocalPosition;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.System;

		private RectTransform dragAreaInternal
		{
			get
			{
				if (dragContainer != null && dragContainer.dragBorder != null)
				{
					return base.transform.parent as RectTransform;
				}
				if (dragContainer != null)
				{
					return dragContainer.dragBorder;
				}
				return null;
			}
		}

		public new void Start()
		{
			if (dragObject == null)
			{
				dragObject = GetComponent<RectTransform>();
			}
			if (dragContainer == null)
			{
				dragContainer = base.gameObject.GetComponentInParent<ItemDragContainer>();
			}
			if (dragContainer != null)
			{
				dragContainer.items.Add(this);
			}
			if (!(dragContainer == null))
			{
				if (rememberPosition && dragContainer.dragMode == ItemDragContainer.DragMode.Snapped && DreamOSDataManager.ContainsJsonKey(dataCat, string.Format("{0}_{1}{2}", base.gameObject.name, saveKey, "Index")))
				{
					base.transform.SetSiblingIndex(DreamOSDataManager.ReadIntData(dataCat, string.Format("{0}_{1}{2}", base.gameObject.name, saveKey, "Index")));
				}
				else if (rememberPosition && dragContainer.dragMode == ItemDragContainer.DragMode.Free)
				{
					UpdateObject();
				}
			}
		}

		public void OnBeginDrag(PointerEventData data)
		{
			if (!(dragContainer == null) && data.button == PointerEventData.InputButton.Left)
			{
				if (dragContainer.dragMode == ItemDragContainer.DragMode.Snapped)
				{
					dragContainer.objectBeingDragged = base.gameObject;
					return;
				}
				base.transform.SetAsLastSibling();
				originalPanelLocalPosition = dragObject.localPosition;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(dragAreaInternal, data.position, data.pressEventCamera, out originalLocalPointerPosition);
			}
		}

		public void OnDrag(PointerEventData data)
		{
			if (!(dragContainer == null) && data.button == PointerEventData.InputButton.Left && dragContainer.dragMode == ItemDragContainer.DragMode.Free)
			{
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(dragAreaInternal, data.position, data.pressEventCamera, out var localPoint))
				{
					Vector3 vector = localPoint - originalLocalPointerPosition;
					dragObject.localPosition = originalPanelLocalPosition + vector;
				}
				ClampToArea();
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (dragContainer == null)
			{
				return;
			}
			if (dragContainer.dragMode == ItemDragContainer.DragMode.Free && rememberPosition)
			{
				UpdatePositionData();
			}
			else if (dragContainer.dragMode == ItemDragContainer.DragMode.Snapped)
			{
				if (dragContainer.objectBeingDragged == base.gameObject)
				{
					dragContainer.objectBeingDragged = null;
				}
				if (rememberPosition)
				{
					UpdateIndexData();
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!(dragContainer == null) && dragContainer.dragMode == ItemDragContainer.DragMode.Snapped)
			{
				GameObject objectBeingDragged = dragContainer.objectBeingDragged;
				if (objectBeingDragged != null && objectBeingDragged != base.gameObject)
				{
					objectBeingDragged.transform.SetSiblingIndex(base.transform.GetSiblingIndex());
				}
			}
		}

		public void ClampToArea()
		{
			Vector3 localPosition = dragObject.localPosition;
			Vector3 vector = dragAreaInternal.rect.min - dragObject.rect.min;
			Vector3 vector2 = dragAreaInternal.rect.max - dragObject.rect.max;
			localPosition.x = Mathf.Clamp(dragObject.localPosition.x, vector.x, vector2.x);
			localPosition.y = Mathf.Clamp(dragObject.localPosition.y, vector.y, vector2.y);
			dragObject.localPosition = localPosition;
		}

		public void UpdateObject(bool readData = true)
		{
			if (rememberPosition && !(dragContainer == null) && !(dragContainer.gridLayoutGroup == null))
			{
				if (!DreamOSDataManager.ContainsJsonKey(dataCat, string.Format("{0}_{1}{2}", base.gameObject.name, saveKey, "PosX")))
				{
					UpdatePositionData();
				}
				if (readData)
				{
					float x = DreamOSDataManager.ReadFloatData(dataCat, string.Format("{0}_{1}{2}", base.gameObject.name, saveKey, "PosX"));
					float y = DreamOSDataManager.ReadFloatData(dataCat, string.Format("{0}_{1}{2}", base.gameObject.name, saveKey, "PosY"));
					Vector3 position = new Vector3(x, y, 0f);
					base.transform.position = position;
					dragObject.sizeDelta = new Vector2(dragContainer.gridLayoutGroup.cellSize.x, dragContainer.gridLayoutGroup.cellSize.y);
				}
			}
		}

		public void UpdatePositionData()
		{
			DreamOSDataManager.WriteFloatData(dataCat, string.Format("{0}_{1}{2}", base.gameObject.name, saveKey, "PosX"), base.transform.position.x);
			DreamOSDataManager.WriteFloatData(dataCat, string.Format("{0}_{1}{2}", base.gameObject.name, saveKey, "PosY"), base.transform.position.y);
		}

		public void UpdateIndexData(bool updateParent = true)
		{
			if (!updateParent)
			{
				DreamOSDataManager.WriteIntData(dataCat, string.Format("{0}_{1}{2}", base.gameObject.name, saveKey, "Index"), base.transform.GetSiblingIndex());
				return;
			}
			for (int i = 0; i < dragContainer.transform.childCount; i++)
			{
				dragContainer.transform.GetChild(i).GetComponent<ItemDragger>().UpdateIndexData(updateParent: false);
			}
		}
	}
}
