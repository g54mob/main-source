using UnityEngine;

public class SelectionGroupToggleSingleButton : MyButton
{
	public GameObject[] enableOnSelect;

	public GameObject unselectableOverlay;

	private bool _003CcanSelect_003Ek__BackingField = true;

	private bool _003CisSelected_003Ek__BackingField;

	public bool canSelect
	{
		get
		{
			return _003CcanSelect_003Ek__BackingField;
		}
		set
		{
			_003CcanSelect_003Ek__BackingField = value;
		}
	}

	public bool isSelected
	{
		get
		{
			return _003CisSelected_003Ek__BackingField;
		}
		private set
		{
			_003CisSelected_003Ek__BackingField = value;
		}
	}

	public void Select()
	{
		//IL_0023: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		GameObject[] array = enableOnSelect;
		_003CisSelected_003Ek__BackingField = true;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			array[obj2].SetActive(value: true);
			obj2++;
			obj = obj2;
		}
	}

	public void Deselect()
	{
		//IL_0023: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		GameObject[] array = enableOnSelect;
		_003CisSelected_003Ek__BackingField = false;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			array[obj2].SetActive(value: false);
			obj2++;
			obj = obj2;
		}
	}

	public override void StartHover()
	{
		isHovering = true;
	}

	public override void StopHover()
	{
		isHovering = false;
	}

	protected override void OnClick()
	{
	}

	public void CanSelect(bool b)
	{
		_003CcanSelect_003Ek__BackingField = b;
		if (unselectableOverlay != null)
		{
			bool active = (byte)((b ? 1u : 0u) ^ 1u) != 0;
			unselectableOverlay.SetActive(active);
		}
	}
}
