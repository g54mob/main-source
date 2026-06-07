using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditMetaPane : MonoBehaviour
{
	public TMP_InputField titleInputField;

	public TMP_InputField descInputField;

	public Dropdown startDropdown;

	public Dropdown endDropdown;

	private int updateCount;

	private List<string> adaKeys;

	public void OnEnable()
	{
	}

	public void Update()
	{
	}

	private bool AreKeysDifferent(List<string> keys)
	{
		return false;
	}

	private void RefreshDropdowns()
	{
	}

	public void OnApply()
	{
	}
}
