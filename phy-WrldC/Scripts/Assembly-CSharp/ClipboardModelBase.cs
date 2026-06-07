using UnityEngine;

public abstract class ClipboardModelBase<TItemModel> : BaseModel where TItemModel : class
{
	public const string AddSlotEvent = "ClipboardModelBase.AddSlotEvent";

	public const string FocusSlotEvent = "ClipboardModelBase.FocusSlotEvent";

	public const string UnfocusSlotEvent = "ClipboardModelBase.UnfocusSlotEvent";

	public const string SelectedSlotIndexEvent = "ClipboardModelBase.SelectedSlotIndexEvent";

	private const int queueMaxSize = 6;

	private TItemModel[] itemModels;

	private int selectedSlotIndex;

	public bool IsItemFocused { get; private set; }

	public int SelectedSlotIndex
	{
		get
		{
			return selectedSlotIndex;
		}
		set
		{
			IsItemFocused = true;
			selectedSlotIndex = Mathf.Clamp(value, 0, 5);
			NotifyChange("ClipboardModelBase.SelectedSlotIndexEvent", selectedSlotIndex);
		}
	}

	public ClipboardModelBase()
	{
		itemModels = new TItemModel[6];
		selectedSlotIndex = 0;
		IsItemFocused = false;
	}

	public void AddItemModel(TItemModel itemModel)
	{
		for (int num = itemModels.Length - 1; num >= 1; num--)
		{
			itemModels[num] = itemModels[num - 1];
		}
		itemModels[0] = itemModel;
		NotifyChange("ClipboardModelBase.AddSlotEvent", itemModel);
	}

	public TItemModel GetItemModel()
	{
		return itemModels[selectedSlotIndex];
	}

	public void FocusSlot()
	{
		IsItemFocused = true;
		NotifyChange("ClipboardModelBase.FocusSlotEvent");
	}

	public void UnfocusSlot()
	{
		if (IsItemFocused)
		{
			IsItemFocused = false;
			NotifyChange("ClipboardModelBase.UnfocusSlotEvent");
		}
	}
}
