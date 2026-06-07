using UnityEngine;
using UnityEngine.UI;

public class CModUnitDropdown : CModUnitControl
{
	public Text textControl;

	public GameObject dropdownValueText;

	public GameObject dropdownMixedValueText;

	public Dropdown dropdownControl;

	private int _state;

	public override string text
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override string[] options
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override int state
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void OnDisable()
	{
	}

	public void OnChange(int val)
	{
	}
}
