using UnityEngine;
using UnityEngine.UI;

public class LEClipboardController : ClipboardControllerBase<Transform, CustomLevelObjectsModel>
{
	public LEClipboardController(LEClipboardView view, LEClipboardModel model, ToggleGroup toggleGroup)
		: base((ClipboardViewBase<Transform, CustomLevelObjectsModel>)view, (ClipboardModelBase<CustomLevelObjectsModel>)model, toggleGroup)
	{
	}

	protected override void SaveButtonHandler(CustomLevelObjectsModel itemModel)
	{
		SaveLevelPartState.Instance.ToSaveCustomLevelObjectsModel = itemModel;
		GameManager.Instance.SetSubState(SaveLevelPartState.Instance);
	}
}
