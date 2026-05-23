using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnumSelector : MonoBehaviour
{
	public ThronefallUIElement target;

	public List<string> options = new List<string>();

	private int index;

	public bool delayedApply;

	public GameObject applyButton;

	public ThronefallUIElement.NavigationDirection increase;

	public ThronefallUIElement.NavigationDirection decrease = ThronefallUIElement.NavigationDirection.Left;

	public TextMeshProUGUI display;

	public GameObject buttons;

	public UnityEvent onChange = new UnityEvent();

	public UnityEvent onIncrease = new UnityEvent();

	public UnityEvent onDecrease = new UnityEvent();

	private bool unpropagatedChanges;

	private int bufferIndex;

	public int Index => index;

	private void Start()
	{
		target.onApply.AddListener(PropagateDelayedChange);
		target.onSelectionStateChange.AddListener(OnLinkedTFUINavigate);
	}

	public void UpdateDisplay()
	{
		if (unpropagatedChanges)
		{
			display.text = options[index] + "<style=Settings Warning> *</style>";
			if ((bool)applyButton)
			{
				applyButton.SetActive(value: true);
			}
		}
		else
		{
			display.text = options[index];
			if ((bool)applyButton)
			{
				applyButton.SetActive(value: false);
			}
		}
	}

	public void Navigate(ThronefallUIElement.NavigationDirection direction)
	{
		if (direction == increase)
		{
			onIncrease.Invoke();
			index++;
		}
		else if (direction == decrease)
		{
			index--;
			onDecrease.Invoke();
		}
		if (index > options.Count - 1)
		{
			index = 0;
		}
		if (index < 0)
		{
			index = options.Count - 1;
		}
		if (delayedApply && index != bufferIndex)
		{
			unpropagatedChanges = true;
		}
		else
		{
			unpropagatedChanges = false;
		}
		UpdateDisplay();
		if (!delayedApply)
		{
			ApplyChanges();
		}
	}

	public void Increase()
	{
		Navigate(increase);
	}

	public void Decrease()
	{
		Navigate(decrease);
	}

	public void OnTFUIStateChange()
	{
		if (target.CurrentState != ThronefallUIElement.SelectionState.Default)
		{
			buttons.SetActive(value: true);
		}
		else
		{
			buttons.SetActive(value: false);
		}
	}

	public void SetIndex(int i)
	{
		index = i;
		if (index > options.Count - 1)
		{
			index = 0;
		}
		if (index < 0)
		{
			index = options.Count - 1;
		}
		bufferIndex = index;
		UpdateDisplay();
	}

	public void OnLinkedTFUINavigate()
	{
		CancelChanges();
	}

	public void PropagateDelayedChange()
	{
		if (delayedApply)
		{
			ApplyChanges();
		}
	}

	private void ApplyChanges()
	{
		bufferIndex = index;
		onChange.Invoke();
		unpropagatedChanges = false;
		UpdateDisplay();
	}

	private void CancelChanges()
	{
		index = bufferIndex;
		unpropagatedChanges = false;
		UpdateDisplay();
	}
}
