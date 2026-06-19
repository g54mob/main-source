using System.Collections.Generic;

public class CookBookIngredientTypeFilterSlot : SlotUIBase
{
	private CookBookIngredientTypeFilterUI cookBookIngredientTypeFilterUI;

	private const string foodTypes = "FoodTypes/";

	public CookBookIngredientTypeFilterUI.IngredientTypeInfo ingredientTypeInfo { get; private set; }

	public override float localScrollPosition => base.transform.localPosition.y + base.transform.parent.localPosition.y;

	private bool showHoverWindow
	{
		get
		{
			if (cookBookIngredientTypeFilterUI != null)
			{
				return cookBookIngredientTypeFilterUI.scrollWindow.IsShowingPosition(localScrollPosition);
			}
			return false;
		}
	}

	public override bool isVisibleOnScreen => showHoverWindow;

	public override UIScrollWindow uiScrollWindow
	{
		get
		{
			if (!(cookBookIngredientTypeFilterUI != null))
			{
				return null;
			}
			return cookBookIngredientTypeFilterUI.scrollWindow;
		}
	}

	public void SetType(CookBookIngredientTypeFilterUI.IngredientTypeInfo _ingredientTypeInfo, CookBookIngredientTypeFilterUI _cookBookIngredientTypeFilterUI)
	{
		ingredientTypeInfo = _ingredientTypeInfo;
		cookBookIngredientTypeFilterUI = _cookBookIngredientTypeFilterUI;
		icon.sprite = ingredientTypeInfo.icon;
	}

	public override void UpdateSlot()
	{
		activeBorder.gameObject.SetActive(cookBookIngredientTypeFilterUI != null && cookBookIngredientTypeFilterUI.currentIngredientTypeFilter == ingredientTypeInfo.ingredientType);
		base.UpdateSlot();
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (showHoverWindow)
		{
			if (cookBookIngredientTypeFilterUI.currentIngredientTypeFilter == ingredientTypeInfo.ingredientType)
			{
				cookBookIngredientTypeFilterUI.TurnOffIngredientFilter();
			}
			else
			{
				cookBookIngredientTypeFilterUI.ActivateIngredientFilter(ingredientTypeInfo.ingredientType);
			}
		}
	}

	public override void OnSelected()
	{
		cookBookIngredientTypeFilterUI.GetScrollWindow().MoveScrollToIncludePosition(localScrollPosition, background.size.y / 2f);
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
		return new TextAndFormatFields
		{
			text = "FoodTypes/" + ingredientTypeInfo.ingredientType
		};
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		return null;
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		return null;
	}

	public override HoverTitleIconType GetHoverTitleIconType()
	{
		return HoverTitleIconType.None;
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
	}
}
