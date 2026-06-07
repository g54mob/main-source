using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureSalesItemDropdown : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> m_dropdownElements;

	[SerializeField]
	private TMP_Dropdown dropdown;

	[SerializeField]
	private List<FurnitureSO> furnitureSOs;

	[SerializeField]
	private Image m_choosenColorBackground;

	public void CreateDropdown(List<FurnitureSO> furnitureSOs)
	{
	}

	public void SetDropdownElements(GameObject item)
	{
	}

	public void SetChoosenBackground(Color color)
	{
	}
}
