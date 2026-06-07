using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderByPanel : MonoBehaviour
{
	[SerializeField]
	private Toggle ascendingToggle;

	[SerializeField]
	private Toggle descendingToggle;

	[SerializeField]
	private List<Toggle> orderByTypes;

	private bool isAscending;

	public event Action<int, bool> OnOrderByChanged;

	private void Awake()
	{
		isAscending = true;
		for (int i = 0; i < orderByTypes.Count; i++)
		{
			int type = i;
			orderByTypes[i].onValueChanged.AddListener(delegate(bool isOn)
			{
				if (isOn)
				{
					this.OnOrderByChanged?.Invoke(type, isAscending);
				}
			});
		}
		ascendingToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				ChangeSortDirection(isAscending: true);
			}
		});
		descendingToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				ChangeSortDirection(isAscending: false);
			}
		});
		void ChangeSortDirection(bool isAscending)
		{
			this.isAscending = isAscending;
			int arg = orderByTypes.FindIndex((Toggle toggle) => toggle.isOn);
			this.OnOrderByChanged?.Invoke(arg, isAscending);
		}
	}

	public void SelectToggle(int toggleIndex)
	{
		if (toggleIndex < orderByTypes.Count && !orderByTypes[toggleIndex].isOn)
		{
			orderByTypes[toggleIndex].isOn = true;
		}
	}

	public bool GetToggleValue(int toggleIndex)
	{
		if (toggleIndex >= orderByTypes.Count)
		{
			return false;
		}
		return orderByTypes[toggleIndex].isOn;
	}

	public void SetToggleInteractivity(bool isInteractable, int toggleIndex)
	{
		if (toggleIndex < orderByTypes.Count && orderByTypes[toggleIndex].interactable != isInteractable)
		{
			orderByTypes[toggleIndex].interactable = isInteractable;
		}
	}
}
