using System;
using UnityEngine;
using UnityEngine.UI;

public class MotorCraftingIngredUI : MonoBehaviour
{
	public Image mainImage;

	[SerializeField]
	private GameObject selectedCheck;

	public int type;

	public MotorIngredientItem item;

	public static event Action<int> OnIngredSelected;

	private void MotorCraftingIngredUI_OnIngredSelected(int obj)
	{
		if (obj == type)
		{
			selectedCheck.SetActive(value: false);
		}
	}

	public void Selected()
	{
		MotorCraftingIngredUI.OnIngredSelected?.Invoke(type);
		selectedCheck.SetActive(value: true);
	}

	private void OnDisable()
	{
		OnIngredSelected -= MotorCraftingIngredUI_OnIngredSelected;
	}

	private void OnEnable()
	{
		OnIngredSelected += MotorCraftingIngredUI_OnIngredSelected;
	}
}
