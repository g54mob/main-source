using System;
using TS.ColorPicker;
using UnityEngine;

public class PaintBucket : BrokenHubStation
{
	private ColorPickerPredefined colorPicker;

	protected override bool CanInteract()
	{
		return Train.Instance.currentTrain.trainType == TrainType.Regular;
	}

	protected override void UseStation(Interactor interactor)
	{
		MenuManager.Instance.MenuOpened += HandleMenuOpened;
		MenuManager.Instance.OpenMenu(MenuType.ColorPicker, Train.Instance.Customization.ColorPaint);
	}

	private void HandleMenuOpened(Menu obj)
	{
		if (obj.MenuType == MenuType.ColorPicker && obj is ColorPickerPredefined colorPickerPredefined)
		{
			MenuManager.Instance.MenuClosed += HandleMenuClosed;
			colorPicker = colorPickerPredefined;
			ColorPickerPredefined colorPickerPredefined2 = colorPicker;
			colorPickerPredefined2.OnSubmit = (Action<Color>)Delegate.Combine(colorPickerPredefined2.OnSubmit, new Action<Color>(SetTrainColor));
		}
	}

	private void SetTrainColor(Color color)
	{
		Train.Instance.Customization.ChangeCategoryColor(color, TrainCustomization.ColorCategory.Paint);
	}

	private void HandleMenuClosed(Menu obj)
	{
		if (obj.MenuType == MenuType.ColorPicker && obj is ColorPickerPredefined)
		{
			MenuManager.Instance.MenuOpened -= HandleMenuOpened;
			MenuManager.Instance.MenuClosed -= HandleMenuClosed;
			ColorPickerPredefined colorPickerPredefined = colorPicker;
			colorPickerPredefined.OnSubmit = (Action<Color>)Delegate.Remove(colorPickerPredefined.OnSubmit, new Action<Color>(SetTrainColor));
			colorPicker = null;
		}
	}
}
