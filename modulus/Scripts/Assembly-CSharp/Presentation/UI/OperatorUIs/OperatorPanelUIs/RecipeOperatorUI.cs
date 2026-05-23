using System;
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Variables.Recipes;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class RecipeOperatorUI : FactoryPanelUIMenu
	{
		[Header("Recipe Operator UI")]
		[SerializeField]
		private RectTransform _chooseRecipeParent;

		[SerializeField]
		private RectTransform _hasRecipeSetParent;

		[Header("Choose recipe refs")]
		[SerializeField]
		private Transform _recipeButtonsParent;

		[SerializeField]
		private RecipeButtonUI _recipeButtonOri;

		[Header("Has recipe set refs")]
		[SerializeField]
		private RectTransform _inputsParent;

		[SerializeField]
		private InputResourceUI _inputResourceUIOri;

		[SerializeField]
		private RectTransform _outputsParent;

		[SerializeField]
		private OutputResourceUI _outputResourceUIOri;

		[SerializeField]
		private Button _changeRecipeButton;

		[SerializeField]
		private Image _fillBar;

		private readonly List<InputResourceUI> _inputResourceUIs = new List<InputResourceUI>();

		private readonly List<OutputResourceUI> _outputResourceUIs = new List<OutputResourceUI>();

		private readonly List<RecipeButtonUI> _recipeButtons = new List<RecipeButtonUI>();

		private RecipeOperatorBehaviour _behaviour;

		protected override void HandleOnAwake()
		{
			_inputResourceUIs.Add(_inputResourceUIOri);
			_outputResourceUIs.Add(_outputResourceUIOri);
			_recipeButtons.Add(_recipeButtonOri);
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as RecipeOperatorBehaviour;
			_behaviour.OnChangedRecipe.RegisterMainThread(ShowHasRecipeMenu);
			_behaviour.OnResourceCountUpdated.RegisterMainThread(UpdateResourceCount);
			_changeRecipeButton.onClick.AddListener(ShowChooseRecipeMenu);
			UpdateOutputSpeedInfo();
			if (_behaviour.HasRecipeSet)
			{
				ShowHasRecipeMenu(_behaviour.CurrentRecipe);
			}
			else
			{
				ShowChooseRecipeMenu();
			}
		}

		public override void HideMenu()
		{
			base.HideMenu();
			_changeRecipeButton.onClick.RemoveListener(ShowChooseRecipeMenu);
			if ((bool)_behaviour)
			{
				_behaviour.OnChangedRecipe.UnRegisterMainThread(ShowHasRecipeMenu);
				_behaviour.OnResourceCountUpdated.UnRegisterMainThread(UpdateResourceCount);
			}
		}

		protected override void SetTexts()
		{
			if (!(_behaviour == null))
			{
				if (_state == AbstractUIMenuData.UIMenuState.ConfigureMode && _chooseRecipeParent.gameObject.activeSelf)
				{
					_titleText.SetText(LocalizationUtility.GetLocalizedText("DataCenter.ChooseRecipe"));
				}
				else
				{
					_titleText.SetText(LocalizationUtility.GetLocalizedText(_factoryObjectUIData.NameLocKey));
				}
			}
		}

		protected override void InitiateWidgets()
		{
			InitiateOperatorState();
			UpdateOutputSpeedInfo();
		}

		private void UpdateOutputSpeedInfo()
		{
			if (_speedInfo == null)
			{
				return;
			}
			int configuredOutputCount = 0;
			if (_behaviour != null && _behaviour.HasRecipeSet)
			{
				foreach (ResourceRecipe.Output output in _behaviour.CurrentRecipe.Outputs)
				{
					configuredOutputCount = output.OutputAmount;
				}
			}
			_speedInfo.SetSpeedsFromConfiguredOperator(_factoryObjectUIData, configuredOutputCount, 0, 0, _factoryObject);
		}

		private void SetRecipe(int recipeIndex)
		{
			_behaviour.ChangeRecipe(recipeIndex);
			UpdateOutputSpeedInfo();
		}

		private void ShowChooseRecipeMenu()
		{
			_hasRecipeSetParent.gameObject.SetActive(value: false);
			_chooseRecipeParent.gameObject.SetActive(value: true);
			_shapesOutput.gameObject.SetActive(value: false);
			SetTexts();
			for (int i = 0; i < _recipeButtons.Count; i++)
			{
				_recipeButtons[i].gameObject.SetActive(value: false);
				RecipeButtonUI recipeButtonUI = _recipeButtons[i];
				recipeButtonUI.OnClickAction = (Action<int>)Delegate.Remove(recipeButtonUI.OnClickAction, new Action<int>(SetRecipe));
			}
			int count = _behaviour.UnlockedRecipes.Count;
			for (int j = 0; j < count; j++)
			{
				NonShapeResourceDataSO nonShapeResourceDataSO = null;
				foreach (ResourceRecipe.Output output in _behaviour.UnlockedRecipes[j].Outputs)
				{
					nonShapeResourceDataSO = output.resourceDataSO as NonShapeResourceDataSO;
					if (nonShapeResourceDataSO != null)
					{
						break;
					}
				}
				RecipeButtonUI recipeButtonUI2;
				if (j >= _recipeButtons.Count)
				{
					recipeButtonUI2 = UnityEngine.Object.Instantiate(_recipeButtonOri, _recipeButtonsParent);
					_recipeButtons.Add(recipeButtonUI2);
				}
				else
				{
					recipeButtonUI2 = _recipeButtons[j];
				}
				RecipeButtonUI recipeButtonUI3 = recipeButtonUI2;
				recipeButtonUI3.OnClickAction = (Action<int>)Delegate.Combine(recipeButtonUI3.OnClickAction, new Action<int>(SetRecipe));
				int recipeIDFromRecipe = _behaviour.GetRecipeIDFromRecipe(_behaviour.UnlockedRecipes[j]);
				recipeButtonUI2.Build(nonShapeResourceDataSO, recipeIDFromRecipe);
				recipeButtonUI2.gameObject.SetActive(value: true);
			}
		}

		private void ShowHasRecipeMenu(ResourceRecipe recipe)
		{
			_hasRecipeSetParent.gameObject.SetActive(value: true);
			_chooseRecipeParent.gameObject.SetActive(value: false);
			SetTexts();
			for (int i = 0; i < _outputResourceUIs.Count; i++)
			{
				_outputResourceUIs[i].gameObject.SetActive(value: false);
			}
			for (int j = 0; j < recipe.Outputs.Count; j++)
			{
				OutputResourceUI outputResourceUI;
				if (j >= _outputResourceUIs.Count)
				{
					outputResourceUI = UnityEngine.Object.Instantiate(_outputResourceUIOri, _outputsParent);
					_outputResourceUIs.Add(outputResourceUI);
				}
				else
				{
					outputResourceUI = _outputResourceUIs[j];
				}
				outputResourceUI.gameObject.SetActive(value: true);
				ResourceRecipe.Output output = recipe.Outputs.ElementAt(j);
				outputResourceUI.SetResource(output.resourceDataSO, output.ShapeData, output.OutputAmount);
			}
			for (int k = 0; k < _inputResourceUIs.Count; k++)
			{
				_inputResourceUIs[k].gameObject.SetActive(value: false);
			}
			for (int l = 0; l < recipe.Inputs.Count; l++)
			{
				KeyValuePair<ResourceDataSO, int> keyValuePair = recipe.Inputs.ElementAt(l);
				NonShapeResourceDataSO resource = keyValuePair.Key as NonShapeResourceDataSO;
				InputResourceUI inputResourceUI;
				if (l >= _inputResourceUIs.Count)
				{
					inputResourceUI = UnityEngine.Object.Instantiate(_inputResourceUIOri, _inputsParent);
					_inputResourceUIs.Add(inputResourceUI);
				}
				else
				{
					inputResourceUI = _inputResourceUIs[l];
				}
				inputResourceUI.gameObject.SetActive(value: true);
				inputResourceUI.SetResource(resource);
				inputResourceUI.SetAmount(_behaviour.CurrentResources[l], $"/{keyValuePair.Value}");
			}
			if (_shapesOutput != null)
			{
				_shapesOutput.SetContent(recipe.Inputs, recipe.Outputs);
			}
			UpdateFillBar();
		}

		private void UpdateFillBar()
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < _behaviour.CurrentRecipe.Inputs.Count; i++)
			{
				num += (float)_behaviour.CurrentRecipe.Inputs.ElementAt(i).Value;
				num2 += (float)_behaviour.CurrentResources[i];
			}
			_fillBar.fillAmount = num2 / num;
		}

		private void UpdateResourceCount()
		{
			if (_behaviour.HasRecipeSet && _hasRecipeSetParent.gameObject.activeSelf)
			{
				for (int i = 0; i < _behaviour.CurrentRecipe.Inputs.Count(); i++)
				{
					KeyValuePair<ResourceDataSO, int> keyValuePair = _behaviour.CurrentRecipe.Inputs.ElementAt(i);
					_inputResourceUIs[i].SetAmount(_behaviour.CurrentResources[i], $"/{keyValuePair.Value}");
				}
				UpdateFillBar();
			}
		}
	}
}
