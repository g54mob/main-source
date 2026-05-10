using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategorySignColorDropdown : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> m_dropdownElements;

	[SerializeField]
	private TMP_Dropdown dropdown;

	[SerializeField]
	private Image m_choosenColorBackground;

	public void CreateDropdown(bool isBackground)
	{
	}

	public void SetDropdownElements(GameObject item)
	{
	}

	public void SetChoosenBackground(Color color, int index)
	{
	}
}
