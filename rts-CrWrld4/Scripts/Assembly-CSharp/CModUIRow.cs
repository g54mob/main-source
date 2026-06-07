using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CModUIRow : MonoBehaviour
{
	public TMP_Dropdown typeDropdown;

	public TMP_InputField nameText;

	public TMP_InputField optionsText;

	private CMod.CModUISlot slot;

	public void Init(CMod.CModUISlot slot)
	{
	}

	public void Apply()
	{
	}

	public string GetCommaSeparated(List<string> list)
	{
		return null;
	}

	public List<string> GetList(string commaSeparated)
	{
		return null;
	}
}
