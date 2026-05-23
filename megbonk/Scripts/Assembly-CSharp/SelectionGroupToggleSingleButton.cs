using UnityEngine;

public class SelectionGroupToggleSingleButton : MyButton
{
	public GameObject[] enableOnSelect;

	public GameObject unselectableOverlay;

	public bool canSelect { get; set; }

	public bool isSelected { get; private set; }

	public void Select()
	{
	}

	public void Deselect()
	{
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}

	public void CanSelect(bool b)
	{
	}
}
