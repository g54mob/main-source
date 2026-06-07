using System;
using UnityEngine;

public class LEQuickInventoryController : QuickInventoryControllerBase<Transform, CustomLevelObjectsModel>
{
	public event Action OnSelectedSlotEvent;

	public LEQuickInventoryController(LEQuickInventoryView view, LEQuickInventoryModel model)
		: base((QuickInventoryViewBase<Transform, CustomLevelObjectsModel>)view, (QuickInventoryModelBase<CustomLevelObjectsModel>)model)
	{
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		base.ModelChangeHandler(eventName, data);
		if (eventName == "QuickInventoryModelBase.SelectedItemIndexEvent")
		{
			this.OnSelectedSlotEvent?.Invoke();
		}
	}

	protected override CustomLevelObjectsModel GetInventorySelectedItemModel()
	{
		return GameManager.Instance.LECategoriesModel.GetSelectedItem();
	}

	protected override void IsBeingDragHandler(bool isBeingDrag)
	{
		LevelEditorInventoryState.Instance.IsExitStateLocked = isBeingDrag;
	}

	protected override void DefaultButtonHandler()
	{
		LEQuickInventoryModel lEQuickInventoryModel = GameManager.Instance.DefaultLEQuickInventoryModel.Clone<LEQuickInventoryModel>();
		GameManager.Instance.LEQuickInventoryModel = lEQuickInventoryModel;
		SetModel(lEQuickInventoryModel);
	}
}
