using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableButton : MenuButton
{
	[NonSerialized]
	private SingleSelectionManager selectionManager;

	protected GameObject alert;

	public EntityId selectionHandle;

	protected void LoadAlert(Transform alertParent)
	{
		if (null == alert)
		{
			alert = MenuManager.InstantiatedTextAlert(alertParent);
			alert.gameObject.SetActive(value: false);
		}
	}

	public void LoadSelectionManager(SingleSelectionManager ssm)
	{
		if (ssm == null)
		{
			Debug.LogError("Tried to load null selection manager on " + this);
		}
		selectionManager = ssm;
		UpdateBackgroundColor();
	}

	protected void UpdateSelectionState()
	{
		isSelected = selectionManager.singleSelectedElement.Equals(selectionHandle);
	}

	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		base.OnDeselect(eventData);
	}

	public void RemoveSelection()
	{
		isSelected = false;
		OnSelectionStateChanged();
	}

	public void PerformSelection(bool sendEvent = true)
	{
		if (sendEvent)
		{
			base.Select();
		}
		selectionManager?.SetSelectionState(selectionHandle, nextState: true);
		isSelected = true;
		if (sendEvent)
		{
			OnSelectionStateChanged();
		}
		else
		{
			UpdateBackgroundColor();
		}
	}

	protected virtual void OnSelectionStateChanged()
	{
		UpdateBackgroundColor();
	}

	public void Toggle()
	{
		if (isSelected)
		{
			selectionManager?.SetSelectionState(selectionHandle, nextState: false);
		}
		else
		{
			PerformSelection();
		}
	}
}
