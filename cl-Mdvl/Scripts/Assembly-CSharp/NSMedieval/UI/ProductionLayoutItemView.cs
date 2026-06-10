using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Models.Production;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Research;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Tutorial;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ProductionLayoutItemView : LayoutGroupItemView
	{
		private int cancelIndex;

		private int progressBarIndex = 1;

		private int productionIconIndex = 2;

		private int priorityUpIndex = 3;

		private int priorityDownIndex = 4;

		private int currentCountIndex = 5;

		private int increaseCountIndex = 6;

		private int decreaseCountIndex = 7;

		private int warningPulseIndex = 8;

		private int dropdownSelectionIndex = 9;

		private int pauseIndex = 10;

		private int editProductionIndex = 11;

		private int nameLabelIndex = 12;

		private int currentlyActiveIndex = 13;

		private int copyButtonIndex = 14;

		private Slider progressBar;

		[SerializeField]
		private TMP_Text statusText;

		[SerializeField]
		private TMP_Text progressBarText;

		[SerializeField]
		private Image fillBarImage;

		[SerializeField]
		private Color fillPaused;

		[SerializeField]
		private Color fillNoSkilledWorker;

		[SerializeField]
		private Color fillCollectResources;

		[SerializeField]
		private Color fillInProgress;

		[SerializeField]
		private Color fillWaitingForWorker;

		private int orderId;

		private int currentValue = -1;

		[NonSerialized]
		private Dictionary<int, SoundButton> buttons = new Dictionary<int, SoundButton>();

		private ProductionMode productionMode;

		[NonSerialized]
		private NSMedieval.Model.Production currentProductionBlueprint;

		[NonSerialized]
		private ProductionInstance production;

		[NonSerialized]
		private Button selectProductionButton;

		[NonSerialized]
		private ProductionComponentInstance productionComponentInstance;

		[NonSerialized]
		private ButtonImageSwitch buttonImageSwitch;

		[NonSerialized]
		private ProductionPauseResumeTooltipView productionPauseResumeTooltipView;

		[NonSerialized]
		private TMP_Text editButtonText;

		[SerializeField]
		private GameObject[] hideIfTutorial;

		private string editedText;

		public ProductionInstance Production => production;

		public Slider GetProgressBar => progressBar = ((progressBar == null) ? base.GroupItems[progressBarIndex].GetComponent<Slider>() : progressBar);

		public TMP_Text StatusText => statusText;

		public TMP_Text ProgressBarText => progressBarText;

		public TMP_Dropdown ModeDropdown => base.GroupItems[dropdownSelectionIndex].GetComponent<TMP_Dropdown>();

		private TMP_InputField CurrentCount => base.GroupItems[currentCountIndex].GetComponent<TMP_InputField>();

		private ProductionMode CurrentProductionMode => EnumValues.ProductionModes[ModeDropdown.value];

		public void SetProductionData(ProductionComponentInstance productionComponentInstance, ProductionInstance productionInstance)
		{
			if (productionComponentInstance == null || productionInstance == null)
			{
				return;
			}
			this.productionComponentInstance = productionComponentInstance;
			production = productionInstance;
			if (productionPauseResumeTooltipView == null)
			{
				productionPauseResumeTooltipView = GetButton(pauseIndex).GetComponent<ProductionPauseResumeTooltipView>();
			}
			productionPauseResumeTooltipView.SetTooltipData(production);
			currentProductionBlueprint = production.Blueprint;
			SoundButton button = GetButton(editProductionIndex);
			editButtonText = button.GetComponentInChildren<TMP_Text>();
			button.gameObject.SetActive(value: true);
			SetTitle();
			SetDropdownData();
			UpdateProductionData();
			RefreshPauseResumeButton();
			RefreshEditButtonText();
			production.ResourceFilter.OnParamsChangedEvent -= RefreshEditButtonText;
			production.ResourceFilter.OnParamsChangedEvent += RefreshEditButtonText;
			if (TutorialManager.IsTutorialActive)
			{
				GameObject[] array = hideIfTutorial;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (production != null && !production.HasDisposed)
			{
				production.ResourceFilter.OnParamsChangedEvent -= RefreshEditButtonText;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent -= OnResourceUpdate;
			}
			productionComponentInstance = null;
		}

		private void SetTitle()
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(production.Blueprint.LocKeys));
			base.GroupItems[nameLabelIndex].GetComponent<TMP_Text>().SetText(text);
		}

		private void RefreshEditButtonText()
		{
			if (editButtonText == null || production == null || production.HasDisposed)
			{
				return;
			}
			IEnumerable<Resource> source = production.Blueprint.AllUsableResources.Where((Resource item) => production.Blueprint.ForbiddenOnStart.Contains(item.GetID()));
			int num = production.Blueprint.AllUsableResources.Count - source.Count();
			bool num2 = production.ResourceFilter.AllowedResourceTypes.Count != num;
			bool flag = production.OwnerCreatureId != 0;
			bool flag2 = false;
			Dictionary<string, IntRange> defaultSkillLevelsForBlueprintId = MonoSingleton<UIController>.Instance.ProductionSettingsPanel.DefaultSkillLevelsForBlueprintId;
			if (defaultSkillLevelsForBlueprintId.ContainsKey(production.BlueprintId))
			{
				flag2 = production.SkillLevelRange != null && !production.SkillLevelRange.IsEquals(defaultSkillLevelsForBlueprintId[production.BlueprintId]);
			}
			bool flag3 = !production.ResourceFilter.HitPointsPercent.IsEquals(new IntRange(0, 100));
			bool flag4 = !production.ResourceFilter.FreshnessPercent.IsEquals(new IntRange(0, 100));
			bool flag5 = !production.ResourceFilter.Quality.IsEquals(ProductionUtils.DefaultQualityRange);
			bool flag6 = num2 || flag || flag2 || flag3 || flag4 || flag5;
			if (!flag6)
			{
				foreach (Resource allowedResourceType in production.ResourceFilter.AllowedResourceTypes)
				{
					if (production.Blueprint.ForbiddenOnStart.Contains(allowedResourceType.GetID()))
					{
						flag6 = true;
						break;
					}
				}
			}
			if (!flag6)
			{
				editButtonText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("general_edit"));
				return;
			}
			if (string.IsNullOrEmpty(editedText))
			{
				editedText = MonoSingleton<LocalizationController>.Instance.GetText("general_edit") + "*";
			}
			editButtonText.SetText(editedText);
		}

		private void RefreshPauseResumeButton()
		{
			if (production != null)
			{
				if (buttonImageSwitch == null)
				{
					buttonImageSwitch = GetButton(pauseIndex).GetComponent<ButtonImageSwitch>();
				}
				if (production.State == ProductionState.Paused)
				{
					buttonImageSwitch.ShowOffGraphics();
				}
				else
				{
					buttonImageSwitch.ShowOnGraphics();
				}
			}
		}

		private void UpdateProductionData()
		{
			int num = productionComponentInstance.ProductionSystemInstance.Productions.IndexOf(production);
			SoundButton button = GetButton(priorityUpIndex);
			button.interactable = false;
			if (num > 0)
			{
				button.interactable = true;
			}
			button = GetButton(priorityDownIndex);
			button.interactable = false;
			if (num < productionComponentInstance.ProductionSystemInstance.Productions.Count - 1)
			{
				button.interactable = true;
			}
			int productTargetCount = production.ProductTargetCount;
			button = GetButton(decreaseCountIndex);
			button.interactable = productTargetCount > 1;
			SetupProgressRefactored(production);
			IconWithBackgroundButton component = base.GroupItems[productionIconIndex].GetComponent<IconWithBackgroundButton>();
			component.SetData(currentProductionBlueprint.IconPath, currentProductionBlueprint.IconBackgroundPath, currentProductionBlueprint.IconColorValue);
			if (component.TooltipNew != null)
			{
				component.TooltipNew.ClearLines();
				currentProductionBlueprint.GenerateCurrentTooltipData(production, component.TooltipNew.AppendLine);
			}
			SetModeTextData();
			NSMedieval.Model.Production blueprint = production.Blueprint;
			if (blueprint.RequiredSkills == null || !blueprint.ProductionSteps.Any((ProductionStep item) => item.Type == ProductionStepType.PassiveProduce || item.Type == ProductionStepType.WorkerProduce))
			{
				GetButton(pauseIndex).gameObject.SetActive(value: false);
			}
			else
			{
				GetButton(pauseIndex).gameObject.SetActive(value: true);
			}
		}

		private bool IgnoreWarning(ProductionInstance productionInstance)
		{
			if (productionInstance.Mode == ProductionMode.Amount && productionInstance.ProductTargetCount == 0)
			{
				return true;
			}
			if (productionInstance.Mode == ProductionMode.Until && productionInstance.IsProductionTargetCountReached())
			{
				return true;
			}
			return false;
		}

		private void SetDropdownData()
		{
			ModeDropdown.ClearOptions();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			ProductionMode[] productionModes = EnumValues.ProductionModes;
			for (int i = 0; i < productionModes.Length; i++)
			{
				ProductionMode item = productionModes[i];
				if (!production.Blueprint.IgnoreProductionModeUI.Contains(item))
				{
					list.Add(new TMP_Dropdown.OptionData(MonoSingleton<LocalizationController>.Instance.GetText("production_" + item.ToString().ToLower())));
				}
			}
			ModeDropdown.AddOptions(list);
			ModeDropdown.SetValueWithoutNotify((int)production.Mode);
			ModeDropdown.onValueChanged.RemoveAllListeners();
			ModeDropdown.onValueChanged.AddListener(OnModeChange);
		}

		private void SetModeTextData()
		{
			if (!CurrentCount.isFocused)
			{
				currentValue = production.ProductTargetCount;
				string textWithoutNotify = string.Empty;
				productionMode = (ProductionMode)ModeDropdown.value;
				switch (productionMode)
				{
				case ProductionMode.Amount:
					currentValue = production.ProductTargetCount;
					textWithoutNotify = production.ProductTargetCount.ToString();
					CurrentCount.interactable = true;
					break;
				case ProductionMode.Until:
				{
					currentValue = production.ProductTargetCount;
					int num = 0;
					num = ((production.Blueprint.JobType != JobType.Research) ? currentProductionBlueprint.GetAllProductsCount() : MonoSingleton<ResearchManager>.Instance.GetAvailableBookCount(production.Blueprint.GetID()));
					textWithoutNotify = $"{num}/{currentValue}";
					CurrentCount.interactable = true;
					production.SetProductTargetCount(production.ProductTargetCount);
					break;
				}
				case ProductionMode.Forever:
					textWithoutNotify = "∞";
					CurrentCount.interactable = false;
					break;
				}
				CurrentCount.SetTextWithoutNotify(textWithoutNotify);
				RefreshPlusMinusButtons(productionMode);
			}
		}

		private SoundButton GetButton(int index)
		{
			if (buttons.Count == 0 || !buttons.ContainsKey(index))
			{
				buttons.Add(index, base.GroupItems[index].GetComponent<SoundButton>());
			}
			return buttons[index];
		}

		private void CancelProduction()
		{
			production.Cancel();
			MonoSingleton<UIController>.Instance.ProductionCanceled(this);
			MonoSingleton<UIController>.Instance.ForceUpdateProductionLayoutItemViews();
		}

		private void SetupProgressRefactored(ProductionInstance current)
		{
			if (current == null)
			{
				base.GroupItems[progressBarIndex].SetActive(value: false);
			}
			else if (current.Blueprint.Recipe.Count == 0 && current.CurrentStep == null)
			{
				base.GroupItems[progressBarIndex].SetActive(value: true);
				SetProgressBarValue();
				if (current.State == ProductionState.NoSkilledWorker)
				{
					SetNoSkilledWorkerText();
				}
				else
				{
					StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("production_idle"));
				}
			}
			else
			{
				GetProgressBar.minValue = 0f;
				SetupBarPhase(current);
				base.GroupItems[progressBarIndex].SetActive(value: true);
			}
		}

		private void OnModeChange(int value)
		{
			productionMode = (ProductionMode)ModeDropdown.value;
			if (productionMode != ProductionMode.Until)
			{
				if (productionMode == ProductionMode.Amount)
				{
					production.SetProductTargetCount(1);
				}
				else
				{
					production.SetProductTargetCount(0);
				}
			}
			else if (production.Blueprint.JobType == JobType.Research)
			{
				production.SetProductTargetCount(MonoSingleton<ResearchManager>.Instance.GetAvailableBookCount(production.Blueprint.GetID()) + 10);
			}
			else
			{
				production.SetProductTargetCount(currentProductionBlueprint.GetAllProductsCount() + 10);
			}
			production.SetMode(productionMode);
			RefreshPlusMinusButtons(productionMode);
			SetModeTextData();
		}

		private void RefreshPlusMinusButtons(ProductionMode productionMode)
		{
			switch (productionMode)
			{
			case ProductionMode.Amount:
			case ProductionMode.Until:
				GetButton(increaseCountIndex).gameObject.SetActive(value: true);
				GetButton(decreaseCountIndex).gameObject.SetActive(value: true);
				break;
			case ProductionMode.Forever:
				GetButton(increaseCountIndex).gameObject.SetActive(value: false);
				GetButton(decreaseCountIndex).gameObject.SetActive(value: false);
				break;
			}
		}

		private void ChangePriority(int direction)
		{
			production.OwnerSystem.ChangePriority(production, direction);
		}

		private void ChangeQuantity(int direction)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				direction *= 100;
			}
			else if (Input.GetKey(KeyCode.LeftControl))
			{
				direction *= 10;
			}
			direction += production.ProductTargetCount;
			if (direction < 0)
			{
				direction = 0;
			}
			production.SetProductTargetCount(direction);
		}

		private void OnTogglePauseProductionButtonPress()
		{
			if (production == null)
			{
				return;
			}
			switch (production.Order)
			{
			case ProductionOrder.Work:
				production.SetOrder(ProductionOrder.Pause);
				break;
			case ProductionOrder.Pause:
				production.SetOrder(ProductionOrder.Work);
				break;
			default:
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ProductionLayoutItemView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Production Order is ");
					messageBuilder.AppendFormatted(production.Order);
					messageBuilder.AppendLiteral(". Defaulting to WORK");
				}
				Log.Error(messageBuilder);
				production.SetOrder(ProductionOrder.Work);
				break;
			}
			}
			if (!(productionPauseResumeTooltipView == null))
			{
				productionPauseResumeTooltipView.RefreshTooltip();
			}
		}

		private void OnCopyProductionButtonPress()
		{
			if (production != null)
			{
				production.OwnerSystem.CopyProduction(production);
			}
		}

		private void OnEditProduction()
		{
			if (GetButton(editProductionIndex).isActiveAndEnabled)
			{
				MonoSingleton<UIController>.Instance.ToggleEditProductionUI(production);
			}
		}

		private void SetupBarPhase(ProductionInstance production)
		{
			if (production == null)
			{
				return;
			}
			SetProgressBarColor();
			SetProgressBarValue();
			if (!production.OwnerProductionComponentInstance.TemperatureAllowsProduction())
			{
				StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("production_stopped_temperature"));
				PulseWarning(setActive: true);
				return;
			}
			if (production.OwnerProductionComponentInstance.OwnerBuilding.UnderWater())
			{
				StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("production_stopped_underwater"));
				PulseWarning(setActive: true);
				return;
			}
			bool flag = production.IsCurrentProduction();
			SetCurrentlyActiveIndicator(flag);
			if (!flag)
			{
				if (production.State == ProductionState.NoSkilledWorker)
				{
					SetNoSkilledWorkerText();
					return;
				}
				if (production.State == ProductionState.WaitingForResources && production.CurrentStep is ProductionStepCollect { ResourcesAllowedAvailable: false })
				{
					SetResourceMissingWarning();
					return;
				}
				PulseWarning(setActive: false);
				StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("production_idle"));
				return;
			}
			switch (production.State)
			{
			case ProductionState.Paused:
				StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("production_paused"));
				PulseWarning(setActive: false);
				break;
			case ProductionState.NoSkilledWorker:
				SetNoSkilledWorkerText();
				break;
			case ProductionState.WaitingForResources:
				SetResourceMissingWarning();
				break;
			case ProductionState.WaitingForWorker:
				if (!(production.CurrentStep is ProductionStepWorker))
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ProductionLayoutItemView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("No Collect step found. This should never happen... ");
						messageBuilder.AppendFormatted(production.BlueprintId);
					}
					Log.Warning(messageBuilder);
				}
				else
				{
					StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("name_prod_worker_request"));
					PulseWarning(setActive: false);
				}
				break;
			case ProductionState.InProgress:
				StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(production.CurrentStep.Blueprint.LocKeys)) ?? "");
				PulseWarning(setActive: false);
				break;
			default:
				StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("production_idle"));
				PulseWarning(setActive: false);
				break;
			}
			void SetResourceMissingWarning()
			{
				if (!(production.CurrentStep is ProductionStepCollect productionStepCollect2))
				{
					bool isEnabled2;
					FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(51, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ProductionLayoutItemView.cs");
					if (isEnabled2)
					{
						messageBuilder2.AppendLiteral("No Collect step found. This should never happen... ");
						messageBuilder2.AppendFormatted(production.BlueprintId);
					}
					Log.Warning(messageBuilder2);
				}
				else if (!productionStepCollect2.ResourcesAllowedAvailable)
				{
					StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("production_no_resources"));
					PulseWarning(setActive: true);
				}
				else
				{
					if (!productionStepCollect2.ResourcesAllowedAvailable)
					{
						List<ResourceSearchFilter> missingResources = productionStepCollect2.MissingResources;
						if (missingResources != null && missingResources.All((ResourceSearchFilter item) => MonoSingleton<ResourcePileTracker>.Instance.SearchForFilterHits(item, ignoreForbidState: true)))
						{
							StatusText.SetText(MonoSingleton<LocalizationController>.Instance.GetText("production_no_allowed_resources"));
							PulseWarning(setActive: true);
							return;
						}
					}
					PulseWarning(setActive: false);
					int valueOrDefault = (production.Storage.GetTotalStoredCount() + production.SecondaryIngredientStorage?.GetTotalStoredCount()).GetValueOrDefault();
					int recipeTotalResourceCount = production.Blueprint.GetRecipeTotalResourceCount();
					StatusText.SetText(string.Format("{0}: {1}/{2}", MonoSingleton<LocalizationController>.Instance.GetText("name_prod_resources"), valueOrDefault, recipeTotalResourceCount));
				}
			}
		}

		private void SetNoSkilledWorkerText()
		{
			List<SkillLevelPair> requiredSkills = production.Blueprint.RequiredSkills;
			StatusText.SetText(string.Format("{0} {1}: {2}", MonoSingleton<LocalizationController>.Instance.GetText("name_prod_worker_skill_request"), base.Localize.GetText($"skill_name_{requiredSkills[0].Key}"), requiredSkills[0].Value));
			PulseWarning(setActive: true);
		}

		private void SetProgressBarValue()
		{
			float value = 0f;
			if (production != null && !production.HasDisposed)
			{
				value = ((production.CurrentStep == null) ? (production.Steps.FirstOrDefault((ProductionStepInstance item) => !item.IsCompleted && item.Progress > 0.001f)?.Progress ?? 0f) : ((!production.CurrentStep.IsCompleted) ? production.CurrentStep.Progress : 0f));
			}
			if (ForceShowMaxPercentage())
			{
				GetProgressBar.value = 1f;
				ProgressBarText.SetText("100%");
			}
			else
			{
				value = Mathf.Clamp(value, 0f, 1f);
				GetProgressBar.value = value;
				ProgressBarText.SetText($"{Mathf.Round(value * 100f)}%");
			}
		}

		private bool ForceShowMaxPercentage()
		{
			if (production == null || production.HasDisposed)
			{
				return false;
			}
			if (production.Blueprint.RequiresNoResources())
			{
				return false;
			}
			bool result = false;
			if (production.CurrentStep != null)
			{
				result = (production.State == ProductionState.WaitingForWorker || production.CurrentStep.Type == ProductionStepType.WorkerProduce) && !production.CurrentStep.IsCompleted && production.CurrentStep.Progress == 0f;
			}
			return result;
		}

		private void SetProgressBarColor()
		{
			if (production != null && !production.HasDisposed)
			{
				switch (production.State)
				{
				case ProductionState.Paused:
				case ProductionState.TargetReached:
					fillBarImage.color = (ForceShowMaxPercentage() ? fillCollectResources : fillPaused);
					break;
				case ProductionState.NoSkilledWorker:
					fillBarImage.color = fillNoSkilledWorker;
					break;
				case ProductionState.WaitingForResources:
					fillBarImage.color = fillCollectResources;
					break;
				case ProductionState.WaitingForWorker:
					fillBarImage.color = fillCollectResources;
					break;
				default:
					fillBarImage.color = fillInProgress;
					break;
				}
			}
		}

		private void SetCurrentlyActiveIndicator(bool isActive)
		{
			if (base.GroupItems[currentlyActiveIndex].activeSelf != isActive)
			{
				base.GroupItems[currentlyActiveIndex].SetActive(isActive);
			}
		}

		private void PulseWarning(bool setActive)
		{
			if (base.GroupItems[warningPulseIndex].activeSelf != setActive && (!setActive || !IgnoreWarning(production)))
			{
				base.GroupItems[warningPulseIndex].SetActive(setActive);
			}
		}

		private void OnEnable()
		{
			base.GroupItems[warningPulseIndex].SetActive(value: false);
		}

		private void Start()
		{
			GetButton(cancelIndex).onClick.AddListener(CancelProduction);
			GetButton(priorityUpIndex).onClick.AddListener(delegate
			{
				ChangePriority(-1);
			});
			GetButton(priorityDownIndex).onClick.AddListener(delegate
			{
				ChangePriority(1);
			});
			GetButton(decreaseCountIndex).onClick.AddListener(delegate
			{
				ChangeQuantity(-1);
			});
			GetButton(increaseCountIndex).onClick.AddListener(delegate
			{
				ChangeQuantity(1);
			});
			GetButton(pauseIndex).onClick.AddListener(OnTogglePauseProductionButtonPress);
			GetButton(editProductionIndex).onClick.AddListener(OnEditProduction);
			GetButton(copyButtonIndex).onClick.AddListener(OnCopyProductionButtonPress);
			CurrentCount.onValueChanged.AddListener(delegate
			{
				MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			});
			CurrentCount.onDeselect.AddListener(Deselect);
			CurrentCount.onEndEdit.AddListener(OnInputSubmit);
			selectProductionButton = GetComponent<Button>();
			if (selectProductionButton != null)
			{
				selectProductionButton.onClick.AddListener(OnEditProduction);
			}
			buttonImageSwitch = GetButton(pauseIndex).GetComponent<ButtonImageSwitch>();
			MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent += OnResourceUpdate;
		}

		private void OnResourceUpdate(Resource resource, ResourcePileCount count)
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				if (!(this == null))
				{
					ResourceUpdate(resource, count.AllowedCount);
				}
			});
		}

		private void ResourceUpdate(Resource resource, int amount)
		{
			if (!(resource == null) && !(currentProductionBlueprint == null) && (resource.GetID().Equals(currentProductionBlueprint.GetID()) || resource.GroupIdentifier.Equals(currentProductionBlueprint.GetID())))
			{
				SetModeTextData();
			}
		}

		private void Deselect(string value)
		{
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			if (!EventSystem.current.alreadySelecting)
			{
				OnInputSubmit(value);
				EventSystem.current.SetSelectedGameObject(null);
			}
		}

		private void OnInputSubmit(string value)
		{
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			int.TryParse(value, out var result);
			int count = production.ProductTargetCount + (result - currentValue);
			production.SetProductTargetCount(count);
		}
	}
}
