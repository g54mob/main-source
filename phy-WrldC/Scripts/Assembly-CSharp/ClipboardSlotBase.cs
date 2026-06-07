using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class ClipboardSlotBase<TItemView, TItemModel> : MonoBehaviour where TItemView : Component where TItemModel : class
{
	protected GameObject referenceBlockObject;

	private Toggle slotToggle;

	protected Transform itemScalableTransform;

	protected Vector3 itemOriginalScale;

	public GameObject ItemFolder { get; private set; }

	public TItemView ItemView { get; private set; }

	public event Action<bool> OnSlotSelectedEvent;

	protected virtual void Awake()
	{
		ItemFolder = base.transform.FindChildRecursively("ItemFolder").gameObject;
		referenceBlockObject = base.transform.FindChildRecursively("BlockReference").gameObject;
		slotToggle = GetComponent<Toggle>();
		slotToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			this.OnSlotSelectedEvent?.Invoke(isOn);
		});
		referenceBlockObject.SetActive(value: false);
		Util.AddMouseOverUIEvents(base.gameObject, MouseOverHandler);
		itemOriginalScale = Vector3.one;
	}

	public void SetConfiguration(TItemModel itemModel, ToggleGroup toggleGroup)
	{
		if (ItemView != null)
		{
			ActionBeforeRemoveOldItemView();
			ItemFolder.transform.RemoveAllChildren();
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

	public void SetSlotToggleValue(bool isOn)
	{
		if (isOn != slotToggle.isOn)
		{
			slotToggle.SetValue(isOn);
		}
	}

	private void MouseOverHandler(bool isMouseOver)
	{
		if (!(itemScalableTransform == null))
		{
			if (isMouseOver)
			{
				itemScalableTransform.DOScale(itemOriginalScale.x * 1.15f, 0.25f);
			}
			else
			{
				itemScalableTransform.DOScale(itemOriginalScale.x, 0.25f);
			}
		}
	}

	private void OnDisable()
	{
		if (!(itemScalableTransform == null))
		{
			itemScalableTransform.localScale = itemOriginalScale;
		}
	}
}
