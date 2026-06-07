using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventorySlotBase<TItemView, TItemModel> : MonoBehaviour where TItemView : Component where TItemModel : class
{
	private Toggle slotToggle;

	protected TextMeshProUGUI userIcon;

	protected GameObject referenceBlockObject;

	private InventoryDragHandlerBase<TItemView, TItemModel> slotDragHandler;

	private ToggleStylesApplier toggleStylesApplier;

	public int TabIndex { get; set; }

	public int SlotIndex { get; set; }

	public TItemView ItemView { get; private set; }

	public GameObject ItemFolder { get; private set; }

	public event Action<bool> OnSlotSelectedEvent;

	public event Action OnBeginDragEvent;

	public event Action OnEndDragEvent;

	protected virtual void Awake()
	{
		slotToggle = GetComponent<Toggle>();
		userIcon = base.transform.FindComponent<TextMeshProUGUI>("UserIcon", isRecursively: true);
		ItemFolder = base.transform.FindChildRecursively("ItemFolder").gameObject;
		referenceBlockObject = base.transform.FindChildRecursively("ReferenceBlockObject").gameObject;
		slotDragHandler = GetComponent<InventoryDragHandlerBase<TItemView, TItemModel>>();
		toggleStylesApplier = GetComponent<ToggleStylesApplier>();
		slotToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			this.OnSlotSelectedEvent?.Invoke(isOn);
		});
		slotDragHandler.OnBeginDragEvent += delegate
		{
			this.OnBeginDragEvent?.Invoke();
		};
		slotDragHandler.OnEndDragEvent += delegate
		{
			this.OnEndDragEvent?.Invoke();
		};
	}

	public void SetConfiguration(TItemModel itemModel, ToggleGroup toggleGroup)
	{
		if (ItemView != null)
		{
			ActionBeforeRemoveOldItemView();
			ItemFolder.transform.RemoveAllChildren();
			this.OnSlotSelectedEvent = null;
			this.OnBeginDragEvent = null;
			this.OnEndDragEvent = null;
		}
		slotToggle.group = toggleGroup;
		ItemView = SetConfigurationHandler(itemModel);
		if (ItemView.transform.parent != ItemFolder.transform)
		{
			ItemView.transform.SetParent(ItemFolder.transform, worldPositionStays: true);
		}
	}

	protected abstract void ActionBeforeRemoveOldItemView();

	protected abstract TItemView SetConfigurationHandler(TItemModel itemModel);

	public bool GetToggleValue()
	{
		return slotToggle.isOn;
	}

	public void SetToggleValue(bool isOn)
	{
		if (slotToggle.isOn != isOn)
		{
			slotToggle.SetValue(isOn);
		}
		toggleStylesApplier?.SetToggleStyles(isOn);
	}

	public void ClearToggleGroup()
	{
		slotToggle.group = null;
	}
}
