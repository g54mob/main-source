using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreElementUI : UIListElement, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private Image lockImage;

	private RectTransform draggedElementTransform;

	private void OnDisable()
	{
		if ((bool)draggedElementTransform)
		{
			Object.Destroy(draggedElementTransform.gameObject);
		}
	}

	public void BuyStoreElement()
	{
		if (((PlayerData.PlayerBuilding)base.Data).IsUnlocked)
		{
			LTFunctionLibrary.GetLTPlayerController().StartBuyingObject(((PlayerData.PlayerBuilding)base.Data).BuildingData);
			LTFunctionLibrary.GetLTPlayerController().LTHUD.ShowBuyModeUI();
		}
	}

	public override void LoadData()
	{
		PlayerData.PlayerBuilding playerBuilding = (PlayerData.PlayerBuilding)base.Data;
		if (playerBuilding.IsUnlocked)
		{
			image.sprite = playerBuilding.BuildingData.Image;
			image.color = Color.white;
			lockImage.gameObject.SetActive(value: false);
		}
		else
		{
			image.sprite = null;
			image.color = new Color(0f, 0f, 0f, 0f);
			lockImage.gameObject.SetActive(value: true);
		}
	}

	private void CreateDragElement(Vector2 position)
	{
		if (((PlayerData.PlayerBuilding)base.Data).IsUnlocked)
		{
			draggedElementTransform = new GameObject("DraggedIcon", typeof(RectTransform)).GetComponent<RectTransform>();
			draggedElementTransform.sizeDelta = Vector2.one * 58f * GameManager.instance.PlayerController.CurrentHUD.GetComponent<Canvas>().scaleFactor;
			draggedElementTransform.position = position;
			draggedElementTransform.SetParent(GetComponentInParent<StoreUI>().transform);
			draggedElementTransform.SetAsLastSibling();
			Image obj = draggedElementTransform.AddComponent<Image>();
			obj.sprite = ((PlayerData.PlayerBuilding)base.Data).BuildingData.HotbarImage;
			obj.raycastTarget = false;
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		CreateDragElement(eventData.position);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if ((bool)draggedElementTransform)
		{
			draggedElementTransform.transform.position = eventData.position;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if ((bool)draggedElementTransform)
		{
			HotbarActionUI hotbarActionUI = FunctionLibrary.TryToGetObjectUnderCursor<HotbarActionUI>(EventSystem.current);
			if ((bool)hotbarActionUI)
			{
				LTFunctionLibrary.GetLTPlayerController().AddHotbarAction(((PlayerData.PlayerBuilding)base.Data).BuildingData, hotbarActionUI.HotbarActionIdx);
			}
			Object.Destroy(draggedElementTransform.gameObject);
		}
	}
}
