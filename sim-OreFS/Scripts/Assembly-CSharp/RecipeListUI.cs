using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class RecipeListUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private Transform recipeButtonParent;

	[SerializeField]
	private GameObject recipeButtonPrefab;

	private List<RecipeButton> recipeButtons = new List<RecipeButton>();

	private T_Machine currentMachine;

	private MachineUI machineUI;

	public void UpdateRecipeList(T_Machine machine, MachineUI ui)
	{
		currentMachine = machine;
		machineUI = ui;
		if (recipeButtonParent == null || recipeButtonPrefab == null || machine == null)
		{
			return;
		}
		ClearRecipeList();
		for (int i = 0; i < machine.AcceptedRecipes.Count; i++)
		{
			T_ItemSO t_ItemSO = machine.AcceptedRecipes[i];
			if (!(t_ItemSO == null))
			{
				GameObject gameObject = Object.Instantiate(recipeButtonPrefab, recipeButtonParent);
				RecipeButton recipeButton = gameObject.GetComponent<RecipeButton>();
				if (recipeButton == null)
				{
					recipeButton = gameObject.AddComponent<RecipeButton>();
				}
				recipeButton.Initialize(t_ItemSO, i, this, machineUI);
				recipeButtons.Add(recipeButton);
				if (i == machine.SelectedRecipeIndex)
				{
					recipeButton.SetSelected(selected: true);
				}
			}
		}
	}

	private void ClearRecipeList()
	{
		foreach (RecipeButton recipeButton in recipeButtons)
		{
			if (recipeButton != null && recipeButton.gameObject != null)
			{
				Object.Destroy(recipeButton.gameObject);
			}
		}
		recipeButtons.Clear();
	}

	public void OnRecipeSelected(int recipeIndex)
	{
		if (currentMachine != null && currentMachine.IsProducing && (currentMachine.ProductionAmount > 0 || currentMachine.IsInfiniteMode))
		{
			if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
			{
				GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_StopMachineToDoThis"));
			}
			return;
		}
		for (int i = 0; i < recipeButtons.Count; i++)
		{
			if (recipeButtons[i] != null)
			{
				recipeButtons[i].SetSelected(i == recipeIndex);
			}
		}
		if (currentMachine != null)
		{
			currentMachine.SelectRecipe(recipeIndex);
		}
	}

	public void UpdateSelectedRecipe(int selectedIndex)
	{
		for (int i = 0; i < recipeButtons.Count; i++)
		{
			if (recipeButtons[i] != null)
			{
				recipeButtons[i].SetSelected(i == selectedIndex);
			}
		}
	}
}
