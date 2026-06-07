using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LandmarkActionToggle : AnimatedToggle
{
	[Header("Landmark Action Toggle")]
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private InventoryPanelItemSlot _requiredItemSlot;

	[SerializeField]
	private string _lockedParameter = "Locked";

	[Header("Error Handling")]
	[SerializeField]
	private LandmarkPanelProjectButtons _projectSettingsUI;

	[SerializeField]
	private LocalizedString _lockedError;

	private ILandmarkActionToggleable _landmarkActionToggleable;

	private bool IsToggleable
	{
		get
		{
			if (base.Toggleable != null && base.Toggleable.IsInteractable)
			{
				return !base.Toggleable.IsCompleted;
			}
			return false;
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		TooltipPanel.CloseErrorTooltip(this);
	}

	public void Initialize(ILandmarkActionToggleable toggleable)
	{
		Initialize((IToggleable)toggleable);
		_landmarkActionToggleable = toggleable;
		_label.text = toggleable.Label;
		base.gameObject.SetActive(value: true);
		if (toggleable.TryReturnRequiredItemAndCost(out var requiredItem, out var cost))
		{
			_requiredItemSlot.Initialize(requiredItem, cost);
		}
		base.animator?.SetBool(_lockedParameter, toggleable != null && !toggleable.Unlocked);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (IsToggleable)
		{
			ValidateSubmit(base.OnPointerClick, eventData);
		}
		else
		{
			TriggerErrorTooltip();
		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		TooltipPanel.CloseErrorTooltip(this);
	}

	public override void OnSubmit(BaseEventData eventData)
	{
		if (IsToggleable)
		{
			ValidateSubmit(base.OnSubmit, eventData);
		}
		else
		{
			TriggerErrorTooltip();
		}
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		base.OnDeselect(eventData);
		TooltipPanel.CloseErrorTooltip(this);
	}

	protected void TriggerErrorTooltip()
	{
		using ListPool<LocalizedString>.List list = ListPool<LocalizedString>.Get();
		PopulateErrors(list);
		if (0 < list.Count)
		{
			TooltipPanel.DisplayErrorTooltip(this, base.transform.position, list);
		}
	}

	protected virtual void PopulateErrors(List<LocalizedString> errors)
	{
		if (!_landmarkActionToggleable.Unlocked)
		{
			errors.Add(_lockedError);
		}
		if (_projectSettingsUI.TryReturnError(out var error))
		{
			errors.Add(error);
		}
	}

	private void ValidateSubmit<T>(UnityAction<T> baseMethod, T eventData) where T : BaseEventData
	{
		ItemProperties requiredItem;
		int cost;
		List<Item> reservedItems;
		if (_landmarkActionToggleable.Unlocked)
		{
			baseMethod(eventData);
		}
		else if (_landmarkActionToggleable.TryReturnRequiredItemAndCost(out requiredItem, out cost) && Community.PlayerCommunity.Inventory.TryReserveItems(requiredItem, cost, out reservedItems))
		{
			foreach (Item item in reservedItems)
			{
				item.TakeFromInventory();
			}
			StartCoroutine(ValidateSubmitRoutine(baseMethod, eventData));
			_landmarkActionToggleable.Unlock();
			base.animator.SetBool(_lockedParameter, value: false);
		}
		else
		{
			Debug.LogException(new Exception($"Unable to unlock landmark action '{_landmarkActionToggleable}'!"));
			TriggerErrorTooltip();
		}
	}

	private IEnumerator ValidateSubmitRoutine<T>(UnityAction<T> baseMethod, T eventData) where T : BaseEventData
	{
		yield return _landmarkActionToggleable.Unlock();
		base.animator.SetBool(_lockedParameter, value: false);
		if (_landmarkActionToggleable.IsInteractable)
		{
			baseMethod(eventData);
		}
		else
		{
			TriggerErrorTooltip();
		}
	}
}
