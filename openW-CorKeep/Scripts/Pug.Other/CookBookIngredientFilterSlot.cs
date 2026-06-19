using System.Collections.Generic;
using PugMod;
using UnityEngine;

public class CookBookIngredientFilterSlot : SlotUIBase
{
	private CookBookIngredientFilterUI cookBookIngredientFilterUI;

	public ObjectDataCD objectData { get; private set; }

	public override float localScrollPosition => base.transform.localPosition.y + base.transform.parent.localPosition.y;

	private bool showHoverWindow
	{
		get
		{
			if (cookBookIngredientFilterUI == null)
			{
				return false;
			}
			float num = localScrollPosition;
			Bounds localBounds = background.localBounds;
			if (!cookBookIngredientFilterUI.scrollWindow.IsShowingPosition(num + localBounds.min.y))
			{
				return cookBookIngredientFilterUI.scrollWindow.IsShowingPosition(num + localBounds.max.y);
			}
			return true;
		}
	}

	public override bool isVisibleOnScreen => showHoverWindow;

	public override UIScrollWindow uiScrollWindow
	{
		get
		{
			if (!(cookBookIngredientFilterUI != null))
			{
				return null;
			}
			return cookBookIngredientFilterUI.scrollWindow;
		}
	}

	public void SetObjectData(ObjectDataCD _objectData, CookBookIngredientFilterUI _cookBookIngredientFilterUI)
	{
		objectData = _objectData;
		cookBookIngredientFilterUI = _cookBookIngredientFilterUI;
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectData.objectID);
		if (objectInfo.objectID != ObjectID.None)
		{
			icon.sprite = objectInfo.smallIcon;
			icon.transform.localPosition = objectInfo.iconOffset;
			background.color = Manager.ui.GetSlotBorderRarityColor(objectInfo.rarity, useDefaultColorForCommon: false, Color.white);
		}
		else
		{
			SetEmptyIcon();
		}
	}

	public override void UpdateSlot()
	{
		activeBorder.gameObject.SetActive(cookBookIngredientFilterUI != null && cookBookIngredientFilterUI.currentIngredientFilter == objectData.objectID);
		base.UpdateSlot();
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (showHoverWindow)
		{
			if (cookBookIngredientFilterUI.currentIngredientFilter == objectData.objectID)
			{
				cookBookIngredientFilterUI.TurnOffIngredientFilter();
			}
			else
			{
				cookBookIngredientFilterUI.ActivateIngredientFilter(objectData.objectID);
			}
		}
	}

	public override void OnSelected()
	{
		cookBookIngredientFilterUI.GetScrollWindow().MoveScrollToIncludePosition(localScrollPosition, background.size.y / 2f);
		OnSelectSlot();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		if (!showHoverWindow)
		{
			return null;
		}
		TextAndFormatFields objectName = PlayerController.GetObjectName(new ContainedObjectsBuffer
		{
			objectData = objectData
		}, localize: false);
		objectName.color = Manager.text.GetRarityColor(PugDatabase.GetObjectInfo(objectData.objectID).rarity);
		return objectName;
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		if (!showHoverWindow)
		{
			return null;
		}
		if (!API.Authoring.ObjectProperties.TryGetPropertyString(objectData.objectID, "name", out var value))
		{
			value = objectData.objectID.ToString();
		}
		return new List<TextAndFormatFields>
		{
			new TextAndFormatFields
			{
				text = "Items/" + value + "Desc"
			}
		};
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		if (!showHoverWindow)
		{
			return null;
		}
		return GetHoverStats(new ContainedObjectsBuffer
		{
			objectData = objectData
		}, previewReinforced, previewUpgraded: false);
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_SCREEN;
	}
}
