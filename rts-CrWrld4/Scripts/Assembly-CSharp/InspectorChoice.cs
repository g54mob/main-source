using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorChoice : MonoBehaviour
{
	public Text propertyNameText;

	public Dropdown propertyDropdown;

	public int propertyValue
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public string propertyStringValue
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string propertyName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Dropdown.OptionData> choices
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void SetChoices(string[] data)
	{
	}
}
