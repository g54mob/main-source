using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class SelectableUI_processor : SelectableUI
{
	[SerializeField]
	private TextMeshProUGUI processorNameText;

	[Header("Recipes")]
	[SerializeField]
	private RecipeElementUI recipeElementUIPrefab;

	[SerializeField]
	private Transform recipeElementUIContainer;

	private List<RecipeElementUI> recipeElementUIs;

	[Header("Selected recipe")]
	[SerializeField]
	private TextMeshProUGUI selectedRecipeName;

	[SerializeField]
	private ProcessorResourceUI processourResourceUIPrefab;

	[SerializeField]
	private Transform inputContainer;

	[SerializeField]
	private Transform outputContainer;

	[Header("TimeBar")]
	[SerializeField]
	private FillBar timeBarFillBar;

	[SerializeField]
	private TextMeshProUGUI timeBarCurrentProgress;

	[SerializeField]
	private TextMeshProUGUI timeBarTotalTime;

	private Processor processor;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			processor = SelectedObject as Processor;
			processor.onSelectedRecipeChanged += OnSelectedRecipeChanged;
			processor.GetComponent<StatsComponent>().onStatChanged += OnProcessorStatChanged;
			recipeElementUIs = new List<RecipeElementUI>();
			UpdateProcessorInfo();
			LoadAvailableRecipes();
			LoadSelectedRecipe();
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	private void OnDestroy()
	{
		if ((bool)processor)
		{
			processor.onSelectedRecipeChanged -= OnSelectedRecipeChanged;
			processor.GetComponent<StatsComponent>().onStatChanged -= OnProcessorStatChanged;
		}
	}

	private void Update()
	{
		UpdateTimeBar();
	}

	private void UpdateProcessorInfo()
	{
		processorNameText.text = processor.ObjectData.DisplayName;
	}

	private void OnRecipeElementClicked(UIListElement uiListElement)
	{
		processor.ChangeSelectedRecipe(uiListElement.Data as Recipe);
	}

	private void OnSelectedRecipeChanged(Recipe recipe)
	{
		LoadSelectedRecipe();
		foreach (RecipeElementUI recipeElementUI in recipeElementUIs)
		{
			recipeElementUI.MarkSelected((recipeElementUI.Data as Recipe).RecipeId == processor.SelectedRecipe.RecipeId);
		}
	}

	private void LoadAvailableRecipes()
	{
		recipeElementUIContainer.transform.DeleteAllChildren();
		recipeElementUIs.Clear();
		foreach (Recipe recipe in processor.Recipes)
		{
			RecipeElementUI recipeElementUI = UnityEngine.Object.Instantiate(recipeElementUIPrefab, recipeElementUIContainer);
			recipeElementUI.Data = recipe;
			recipeElementUI.onClickElement = (Action<UIListElement>)Delegate.Combine(recipeElementUI.onClickElement, new Action<UIListElement>(OnRecipeElementClicked));
			recipeElementUI.MarkSelected(processor.SelectedRecipe.RecipeId == recipe.RecipeId);
			recipeElementUIs.Add(recipeElementUI);
		}
	}

	private void LoadSelectedRecipe()
	{
		selectedRecipeName.text = processor.SelectedRecipe.Output.Resource.DisplayName;
		inputContainer.DeleteAllChildren();
		for (int i = 0; i < processor.SelectedRecipe.Input.Length; i++)
		{
			UnityEngine.Object.Instantiate(processourResourceUIPrefab, inputContainer).Setup(processor, isOutputResource: false, i);
		}
		outputContainer.DeleteAllChildren();
		UnityEngine.Object.Instantiate(processourResourceUIPrefab, outputContainer).Setup(processor, isOutputResource: true, 0);
		timeBarFillBar.SetBarMaxValue(processor.SelectedRecipe.ProcessingTime);
		timeBarFillBar.SetBarValue(processor.CurrentProcessingRecipeTime);
		timeBarTotalTime.text = FunctionLibrary.RoundToDecimals(processor.SelectedRecipe.ProcessingTime / processor.ProcessingSpeed, 1) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
	}

	private void UpdateTimeBar()
	{
		if (processor.CurrentProcessingRecipeTime < processor.SelectedRecipe.ProcessingTime)
		{
			timeBarFillBar.SetBarValue(processor.CurrentProcessingRecipeTime);
			timeBarCurrentProgress.text = Mathf.RoundToInt(processor.CurrentProcessingRecipeTime / processor.SelectedRecipe.ProcessingTime * 100f) + "%";
		}
		else
		{
			timeBarFillBar.SetBarValue(0f);
			timeBarCurrentProgress.text = "0%";
		}
	}

	private void OnProcessorStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.Speed)
		{
			LoadSelectedRecipe();
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}
}
