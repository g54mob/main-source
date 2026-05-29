using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectionGroupToggleSingle : MonoBehaviour
{
	public Action<SelectionGroupToggleSingleButton> A_ButtonSelected;

	public int startIndex;

	public bool canSelectMultiple;

	public bool canSelectNothing;

	public bool selectDefaultOnAwake;

	private SelectionGroupToggleSingleButton lastButton;

	private List<SelectionGroupToggleSingleButton> buttons;

	private HashSet<SelectionGroupToggleSingleButton> registeredButtons;

	public List<SelectionGroupToggleSingleButton> selectedButtons { get; private set; }

	private void Awake()
	{
	}

	private void OnTransformChildrenChanged()
	{
	}

	public void FindButtons()
	{
	}

	private void SelectButton(SelectionGroupToggleSingleButton btn)
	{
	}

	private void DeselectButton(SelectionGroupToggleSingleButton btn)
	{
	}

	public void SetNone()
	{
	}

	private void OnButtonSelect(SelectionGroupToggleSingleButton newBtn)
	{
	}

	public SelectionGroupToggleSingleButton GetButton(int index)
	{
		return null;
	}

	public void ForceSelect(int index)
	{
	}

	public int GetSelectedIndex()
	{
		return 0;
	}
}
