using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class SelectionExtraCropfield : SelectionExtraWindowView
	{
		[SerializeField]
		private TMP_Text cropTitle;

		[SerializeField]
		private TMP_Text resourcesYieldedPerHarvest;

		[SerializeField]
		private LayoutGroupView cropInfosParent;

		[SerializeField]
		private GameObject buttonPrefab;

		[SerializeField]
		private TMP_Text harvestTextLabel;

		[SerializeField]
		private LayoutGroupView harvestPhaseCheckboxParent;

		[SerializeField]
		private TMP_Text cutTextLabel;

		[SerializeField]
		private LayoutGroupView cutPhaseCheckboxParent;

		[SerializeField]
		private Transform horizontalScrollCropPlantSelection;

		[SerializeField]
		private TMP_Dropdown priorityDropdown;

		[SerializeField]
		private CustomToggle doNotSowToggle;

		[SerializeField]
		private RangedSliderItemView sowingDateRangeSlider;

		[SerializeField]
		private RectTransform verticalScrollPhaseCheckboxContent;

		private readonly Dictionary<Cropfield, Dictionary<int, HarvestPhaseItemLayoutItemView>> cutCheckboxesDictionary = new Dictionary<Cropfield, Dictionary<int, HarvestPhaseItemLayoutItemView>>();

		private readonly Dictionary<Cropfield, Dictionary<int, HarvestPhaseItemLayoutItemView>> harvestCheckboxesDictionary = new Dictionary<Cropfield, Dictionary<int, HarvestPhaseItemLayoutItemView>>();

		private readonly Dictionary<Cropfield, Dictionary<string, List<string>>> harvestPhaseYields = new Dictionary<Cropfield, Dictionary<string, List<string>>>();

		private readonly List<ButtonLayoutItemView> selectPlantButtons = new List<ButtonLayoutItemView>();

		private readonly List<FillBarLayoutItemView> cropInfos = new List<FillBarLayoutItemView>();

		private List<FillBarLayoutItemView> yieldResources = new List<FillBarLayoutItemView>();

		private InfoPanelCropfield infoPanelCropfield;

		private bool initialized;

		private WorldDate cachedWorldDate;

		private CropfieldInstance currentCropfield;

		private CropfieldInstance cropfieldPreviousTick;

		private WorldDate DateTime
		{
			get
			{
				if (cachedWorldDate == null)
				{
					cachedWorldDate = GlobalSaveController.CurrentVillageData.DateAndTime;
				}
				return cachedWorldDate;
			}
		}

		public void UpdatePanel(InfoPanelCropfield infoPanelCropfield)
		{
			if (infoPanelCropfield.CropfieldInstance == null || infoPanelCropfield.CropfieldInstance.HasDisposed || !infoPanelCropfield.CropfieldInstance.OwnedByPlayer())
			{
				Hide();
				return;
			}
			currentCropfield = infoPanelCropfield.CropfieldInstance;
			if (currentCropfield == cropfieldPreviousTick)
			{
				return;
			}
			cropfieldPreviousTick = currentCropfield;
			this.infoPanelCropfield = infoPanelCropfield;
			Show();
			SetCropTitle();
			SetCropInfos();
			SetYieldResources();
			LayoutRebuilder.MarkLayoutForRebuild(cropInfosParent.GetComponent<RectTransform>());
			SetupCropPlantSelection();
			HideAllCheckboxes();
			SetupHarvestPhasesCheckboxes();
			CropfieldInstance cropfieldInstance = this.infoPanelCropfield.CropfieldInstance;
			sowingDateRangeSlider.Slider.interactable = !cropfieldInstance.DontSow;
			sowingDateRangeSlider.Slider.SetValueWithoutNotify(cropfieldInstance.MinSowDate, cropfieldInstance.MaxSowDate);
			OnSowingDateRangeSliderDrag(cropfieldInstance.MinSowDate, cropfieldInstance.MaxSowDate);
			priorityDropdown.SetValueWithoutNotify((int)(cropfieldInstance.Priority - 1));
			foreach (ButtonLayoutItemView selectPlantButton in selectPlantButtons)
			{
				selectPlantButton.Select(selectPlantButton.GetId == cropfieldInstance.Blueprint.GetID());
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(verticalScrollPhaseCheckboxContent);
		}

		private void SetCropTitle()
		{
			cropTitle.SetText(BuildingUtils.GetLocalizedName(infoPanelCropfield.CropfieldInstance.Blueprint.GetID()));
		}

		public override void Initialize()
		{
			SetupPriorityDropdown();
			doNotSowToggle.onValueChanged.AddListener(OnDoNotSowToggle);
			sowingDateRangeSlider.gameObject.SetActive(value: true);
			sowingDateRangeSlider.Slider.MinValue = 1f;
			sowingDateRangeSlider.Slider.MaxValue = DateTime.DaysInYear;
			sowingDateRangeSlider.Slider.WholeNumbers = true;
			sowingDateRangeSlider.Slider.OnRangeSliderMouseUp += OnSowingDateRangeSliderMouseUp;
			sowingDateRangeSlider.Slider.OnValueChanged.AddListener(OnSowingDateRangeSliderDrag);
		}

		public override void Hide()
		{
			base.Hide();
			currentCropfield = null;
			cropfieldPreviousTick = null;
		}

		private void OnDoNotSowToggle(bool isOn)
		{
			infoPanelCropfield.CropfieldInstance.SetDontSow(isOn);
			sowingDateRangeSlider.Slider.interactable = !isOn;
		}

		private void SetCropInfos()
		{
			PlantMapResource cultivablePlant = infoPanelCropfield.CropfieldInstance.CultivablePlant;
			float num = ((cultivablePlant.LifeCyclesCount == 0) ? 1 : cultivablePlant.LifeCyclesCount);
			cropInfos.GetAt(cropInfosParent, 0).SetText(ZoneUtils.GetLocalizedRequiredBotanicalSkillLevel(infoPanelCropfield.CropfieldInstance.Blueprint));
			cropInfos.GetAt(cropInfosParent, 1).SetText(string.Format("{0} <color=#ffeca8>~{1} {2}</color>", base.Localize.GetText("crop_grow_life_span"), GetLifeSpan(), base.Localize.GetText("general_days")));
			cropInfos.GetAt(cropInfosParent, 2).SetText(string.Format("{0} <color=#ffeca8>{1}</color>", base.Localize.GetText("number_of_harvests"), num));
			FillBarLayoutItemView at = cropInfos.GetAt(cropInfosParent, 3);
			at.SetText(string.Format("{0} <color=#ffeca8>{1}%</color>", base.Localize.GetText("stunted_yeald_info"), (int)(100f * cultivablePlant.StuntedYieldMultiplier)));
			List<string> list = ListPool<string>.Get();
			list.Add(base.Localize.GetText("plant_stunted_info"));
			if (cultivablePlant.PlantType == PlantType.Tree)
			{
				list.Add(base.Localize.GetText("plant_stunted_tree_info"));
			}
			cropInfos.SetActiveFromIndex(4, active: false);
			at.SetTooltipLines(list);
			ListPool<string>.Return(list);
		}

		private float GetSowTime()
		{
			float num = 0f;
			if (infoPanelCropfield.CropfieldInstance.HarvestPhase < 1)
			{
				return infoPanelCropfield.CropfieldInstance.HarvestPhase;
			}
			PlantMapResource cultivablePlant = infoPanelCropfield.CropfieldInstance.CultivablePlant;
			for (int i = 0; i < cultivablePlant.LifePhases.Count; i++)
			{
				if (i == infoPanelCropfield.CropfieldInstance.HarvestPhase)
				{
					return num;
				}
				num += cultivablePlant.LifePhases[i].DurationDays;
			}
			return num;
		}

		private float GetLifeSpan()
		{
			float num = 0f;
			PlantMapResource cultivablePlant = infoPanelCropfield.CropfieldInstance.CultivablePlant;
			int cycleStarterIndex = cultivablePlant.CycleStarterIndex;
			int num2 = cultivablePlant.LifeCyclesCount;
			for (int i = 0; i < cultivablePlant.LifePhases.Count; i++)
			{
				num += cultivablePlant.LifePhases[i].DurationDays;
				if (cycleStarterIndex > 0 && num2 > 0 && i > cultivablePlant.LifePhases[i].NextPhaseIndex)
				{
					num2--;
					i = cycleStarterIndex;
				}
			}
			return num;
		}

		private float GetCutTime()
		{
			if (infoPanelCropfield.CropfieldInstance.CutPhase < 1)
			{
				return infoPanelCropfield.CropfieldInstance.CutPhase;
			}
			float num = 0f;
			PlantMapResource cultivablePlant = infoPanelCropfield.CropfieldInstance.CultivablePlant;
			for (int i = 0; i < cultivablePlant.LifePhases.Count; i++)
			{
				if (cultivablePlant.LifePhases[i].IsCutPhase)
				{
					if (i == infoPanelCropfield.CropfieldInstance.CutPhase)
					{
						return num;
					}
					num += cultivablePlant.LifePhases[i].DurationDays;
				}
			}
			return num;
		}

		private List<string> GetHarvestPhaseYields(string phase)
		{
			Cropfield blueprint = infoPanelCropfield.CropfieldInstance.Blueprint;
			if (harvestPhaseYields.ContainsKey(blueprint) && harvestPhaseYields[blueprint].ContainsKey(phase))
			{
				return harvestPhaseYields[blueprint][phase];
			}
			harvestPhaseYields[blueprint] = new Dictionary<string, List<string>>();
			foreach (PlantLifePhases lifePhase in infoPanelCropfield.CropfieldInstance.CultivablePlant.LifePhases)
			{
				harvestPhaseYields[blueprint].Add(lifePhase.PhaseName, new List<string>());
				for (int i = 0; i < lifePhase.ResourcesRange.Count; i++)
				{
					harvestPhaseYields[blueprint][lifePhase.PhaseName].Add(lifePhase.ResourcesRange[i].Average().ToString(CultureInfo.CurrentCulture));
				}
			}
			return harvestPhaseYields[blueprint][phase] ?? new List<string>();
		}

		private void SetupCropPlantSelection()
		{
			selectPlantButtons.SetAllActive(active: false);
			foreach (Cropfield cropfield in Repository<CropfieldRepository, Cropfield>.Instance.GetAllItems())
			{
				if ((cropfield.GetID() != infoPanelCropfield.CropfieldInstance.Blueprint.GetID() && !GlobalSaveController.CurrentVillageData.ExistingResources.Contains(cropfield.SeedId)) || !GlobalSaveController.CurrentVillageData.Unlocked(cropfield.GetID()))
				{
					continue;
				}
				ButtonLayoutItemView next = selectPlantButtons.GetNext(buttonPrefab, horizontalScrollCropPlantSelection);
				next.gameObject.SetActive(value: true);
				next.SetButtonData(cropfield.GetID(), BuildingUtils.GetLocalizedName(cropfield.GetID()));
				next.SetImageData(cropfield.GetID(), BuildingUtils.GetIconPath(cropfield.GetID()), BuildingUtils.GetIconColor(cropfield.GetID()));
				if (next.TooltipNew is BuildingButtonTooltipViewNew buildingButtonTooltipViewNew)
				{
					buildingButtonTooltipViewNew.Init(cropfield.GetID());
				}
				next.Button.onClick.RemoveAllListeners();
				next.Button.onClick.AddListener(delegate
				{
					infoPanelCropfield.CropfieldInstance.ChangeCropType(cropfield);
					foreach (ButtonLayoutItemView selectPlantButton in selectPlantButtons)
					{
						selectPlantButton.Select(selectPlantButton.GetId == cropfield.GetID());
					}
					HideAllCheckboxes();
					SetupHarvestPhasesCheckboxes();
					SetCropTitle();
					SetCropInfos();
					SetYieldResources();
				});
			}
		}

		private void SetupHarvestPhasesCheckboxes()
		{
			CropfieldInstance cropfieldInstance = infoPanelCropfield.CropfieldInstance;
			Cropfield blueprint = cropfieldInstance.Blueprint;
			doNotSowToggle.SetIsOnWithoutNotify(cropfieldInstance.DontSow);
			if (harvestCheckboxesDictionary.ContainsKey(blueprint))
			{
				LoadCheckboxes(blueprint);
				TickActiveCheckbox();
				return;
			}
			harvestCheckboxesDictionary.Add(blueprint, new Dictionary<int, HarvestPhaseItemLayoutItemView>());
			cutCheckboxesDictionary.Add(blueprint, new Dictionary<int, HarvestPhaseItemLayoutItemView>());
			List<PlantLifePhases> lifePhases = blueprint.DefaultPlant.LifePhases;
			if (lifePhases.Any((PlantLifePhases x) => x.IsHarvestablePhase))
			{
				HarvestPhaseItemLayoutItemView component = Object.Instantiate(harvestPhaseCheckboxParent.Prefab, harvestPhaseCheckboxParent.transform).GetComponent<HarvestPhaseItemLayoutItemView>();
				harvestCheckboxesDictionary[blueprint].Add(-1, component);
				component.SetData(MonoSingleton<LocalizationController>.Instance.GetText("dont_harvest"), cropfieldInstance.HarvestPhase < 0, new List<string>());
				component.SetId("none");
				SetupHarvestPhaseCheckboxListener(cropfieldInstance, component, -1);
				SetHarvestLabel(active: true);
			}
			else
			{
				SetHarvestLabel(active: false);
			}
			for (int num = 0; num < lifePhases.Count; num++)
			{
				PlantLifePhases plantLifePhases = lifePhases[num];
				if (!plantLifePhases.IsHarvestablePhase)
				{
					continue;
				}
				string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(plantLifePhases.LocKeys));
				HarvestPhaseItemLayoutItemView component2 = Object.Instantiate(harvestPhaseCheckboxParent.Prefab, harvestPhaseCheckboxParent.transform).GetComponent<HarvestPhaseItemLayoutItemView>();
				List<string> list = new List<string> { MonoSingleton<LocalizationController>.Instance.GetText("base_yeald_phase") };
				List<ResourceOrderPair> storableResources = infoPanelCropfield.CropfieldInstance.CultivablePlant.StorableResources;
				for (int num2 = 0; num2 < storableResources.Count; num2++)
				{
					if (storableResources[num2].Orders.HasFlag(OrderType.Harvesting))
					{
						ResourceOrderPair resourceOrderPair = infoPanelCropfield.CropfieldInstance.CultivablePlant.StorableResources[num2];
						list.Add(ResourceUtils.GetTextIcon(resourceOrderPair.ResourceId) + " ~" + GetHarvestPhaseYields(plantLifePhases.PhaseName)[num2] + " " + ResourceUtils.GetLocalizedResourceName(resourceOrderPair.ResourceId) + " ");
					}
				}
				component2.SetData(text, cropfieldInstance.HarvestPhase == num, list);
				component2.SetId(plantLifePhases.PhaseName);
				harvestCheckboxesDictionary[blueprint].Add(num, component2);
				SetupHarvestPhaseCheckboxListener(cropfieldInstance, component2, num);
			}
			if (lifePhases.Any((PlantLifePhases x) => x.IsCutPhase))
			{
				HarvestPhaseItemLayoutItemView component3 = Object.Instantiate(cutPhaseCheckboxParent.Prefab, cutPhaseCheckboxParent.transform).GetComponent<HarvestPhaseItemLayoutItemView>();
				cutCheckboxesDictionary[blueprint].Add(-1, component3);
				component3.SetData(MonoSingleton<LocalizationController>.Instance.GetText("dont_cut"), cropfieldInstance.CutPhase < 0, new List<string>());
				component3.SetId("none");
				SetupCutPhaseCheckboxListener(cropfieldInstance, component3, -1);
				SetCutLabel(active: true);
			}
			else
			{
				SetCutLabel(active: false);
			}
			for (int num3 = 0; num3 < lifePhases.Count; num3++)
			{
				PlantLifePhases plantLifePhases2 = lifePhases[num3];
				if (plantLifePhases2.IsCutPhase)
				{
					string text2 = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(plantLifePhases2.LocKeys));
					HarvestPhaseItemLayoutItemView component4 = Object.Instantiate(cutPhaseCheckboxParent.Prefab, cutPhaseCheckboxParent.transform).GetComponent<HarvestPhaseItemLayoutItemView>();
					List<string> list2 = new List<string> { MonoSingleton<LocalizationController>.Instance.GetText("base_yeald_phase") };
					for (int num4 = 0; num4 < infoPanelCropfield.CropfieldInstance.CultivablePlant.StorableResources.Count; num4++)
					{
						ResourceOrderPair resourceOrderPair2 = infoPanelCropfield.CropfieldInstance.CultivablePlant.StorableResources[num4];
						list2.Add(ResourceUtils.GetTextIcon(resourceOrderPair2.ResourceId) + " ~" + GetHarvestPhaseYields(plantLifePhases2.PhaseName)[num4] + " " + ResourceUtils.GetLocalizedResourceName(resourceOrderPair2.ResourceId) + " ");
					}
					component4.SetData(text2, cropfieldInstance.CutPhase == num3, list2);
					component4.SetId(plantLifePhases2.PhaseName);
					cutCheckboxesDictionary[blueprint].Add(num3, component4);
					SetupCutPhaseCheckboxListener(cropfieldInstance, component4, num3);
				}
			}
		}

		private void SetupHarvestPhaseCheckboxListener(CropfieldInstance cropfieldInstance, HarvestPhaseItemLayoutItemView checkbox, int harvestPhase)
		{
			Cropfield cropfield = cropfieldInstance.Blueprint;
			checkbox.Toggle.onValueChanged.AddListener(delegate(bool value)
			{
				foreach (HarvestPhaseItemLayoutItemView value in harvestCheckboxesDictionary[cropfield].Values)
				{
					if (!(checkbox != value || value))
					{
						harvestCheckboxesDictionary[cropfield][harvestPhase].SetToggleWithoutNotify(value: true);
					}
				}
				cropfieldInstance.SetHarvestPhase(harvestPhase);
				foreach (int key in harvestCheckboxesDictionary[cropfield].Keys)
				{
					if (checkbox.ID != harvestCheckboxesDictionary[cropfield][key].ID)
					{
						harvestCheckboxesDictionary[cropfield][key].SetToggleWithoutNotify(value: false);
					}
				}
				SetHarvestLabel(active: true);
			});
		}

		private void SetHarvestLabel(bool active)
		{
			harvestTextLabel.gameObject.SetActive(active);
			if (active)
			{
				string text = string.Empty;
				float sowTime = GetSowTime();
				if (sowTime >= 0f)
				{
					text = string.Format(" (~{0} {1})", sowTime, base.Localize.GetText("general_days"));
				}
				harvestTextLabel.SetText(MonoSingleton<LocalizationController>.Instance.GetText("general_harvest_phase") + text);
			}
		}

		private void SetCutLabel(bool active)
		{
			cutTextLabel.gameObject.SetActive(active);
			if (active)
			{
				string text = string.Empty;
				float cutTime = GetCutTime();
				if (cutTime >= 0f)
				{
					text = string.Format(" (~{0} {1})", cutTime, base.Localize.GetText("general_days"));
				}
				cutTextLabel.SetText(MonoSingleton<LocalizationController>.Instance.GetText("general_cut_phase") + text);
			}
		}

		private void SetupCutPhaseCheckboxListener(CropfieldInstance cropfieldInstance, HarvestPhaseItemLayoutItemView checkbox, int cutPhase)
		{
			Cropfield cropfield = cropfieldInstance.Blueprint;
			checkbox.Toggle.onValueChanged.AddListener(delegate(bool value)
			{
				foreach (HarvestPhaseItemLayoutItemView value in cutCheckboxesDictionary[cropfield].Values)
				{
					if (!(checkbox != value || value))
					{
						cutCheckboxesDictionary[cropfield][cutPhase].SetToggleWithoutNotify(value: true);
					}
				}
				cropfieldInstance.SetCutPhase(cutPhase);
				foreach (int key in cutCheckboxesDictionary[cropfield].Keys)
				{
					if (checkbox.ID != cutCheckboxesDictionary[cropfield][key].ID)
					{
						cutCheckboxesDictionary[cropfield][key].SetToggleWithoutNotify(value: false);
					}
				}
				SetCutLabel(active: true);
			});
		}

		private void LoadCheckboxes(Cropfield cropfieldBlueprint)
		{
			List<PlantLifePhases> lifePhases = cropfieldBlueprint.DefaultPlant.LifePhases;
			SetHarvestLabel(lifePhases.Any((PlantLifePhases x) => x.IsHarvestablePhase));
			SetCutLabel(lifePhases.Any((PlantLifePhases x) => x.IsCutPhase));
			CropfieldInstance cropfieldInstance = infoPanelCropfield.CropfieldInstance;
			if (harvestCheckboxesDictionary.ContainsKey(cropfieldBlueprint))
			{
				foreach (int key in harvestCheckboxesDictionary[cropfieldBlueprint].Keys)
				{
					harvestCheckboxesDictionary[cropfieldBlueprint][key].gameObject.SetActive(value: true);
					harvestCheckboxesDictionary[cropfieldBlueprint][key].Toggle.onValueChanged.RemoveAllListeners();
					SetupHarvestPhaseCheckboxListener(cropfieldInstance, harvestCheckboxesDictionary[cropfieldBlueprint][key], key);
				}
			}
			if (!cutCheckboxesDictionary.ContainsKey(cropfieldBlueprint))
			{
				return;
			}
			foreach (int key2 in cutCheckboxesDictionary[cropfieldBlueprint].Keys)
			{
				cutCheckboxesDictionary[cropfieldBlueprint][key2].gameObject.SetActive(value: true);
				cutCheckboxesDictionary[cropfieldBlueprint][key2].Toggle.onValueChanged.RemoveAllListeners();
				cutCheckboxesDictionary[cropfieldBlueprint][key2].Toggle.onValueChanged.RemoveAllListeners();
				SetupCutPhaseCheckboxListener(cropfieldInstance, cutCheckboxesDictionary[cropfieldBlueprint][key2], key2);
			}
		}

		private void TickActiveCheckbox()
		{
			CropfieldInstance cropfieldInstance = infoPanelCropfield.CropfieldInstance;
			Dictionary<int, HarvestPhaseItemLayoutItemView> dictionary = harvestCheckboxesDictionary[cropfieldInstance.Blueprint];
			foreach (int key in dictionary.Keys)
			{
				if (key != cropfieldInstance.HarvestPhase)
				{
					dictionary[key].SetToggleWithoutNotify(value: false);
				}
				else
				{
					dictionary[key].SetToggleWithoutNotify(value: true);
				}
			}
			Dictionary<int, HarvestPhaseItemLayoutItemView> dictionary2 = cutCheckboxesDictionary[cropfieldInstance.Blueprint];
			foreach (int key2 in dictionary2.Keys)
			{
				if (key2 != cropfieldInstance.CutPhase)
				{
					dictionary2[key2].SetToggleWithoutNotify(value: false);
				}
				else
				{
					dictionary2[key2].SetToggleWithoutNotify(value: true);
				}
			}
		}

		private void HideAllCheckboxes()
		{
			foreach (Cropfield key in harvestCheckboxesDictionary.Keys)
			{
				foreach (int key2 in harvestCheckboxesDictionary[key].Keys)
				{
					harvestCheckboxesDictionary[key][key2].gameObject.SetActive(value: false);
				}
			}
			foreach (Cropfield key3 in cutCheckboxesDictionary.Keys)
			{
				foreach (int key4 in cutCheckboxesDictionary[key3].Keys)
				{
					cutCheckboxesDictionary[key3][key4].gameObject.SetActive(value: false);
				}
			}
		}

		private void SetupPriorityDropdown()
		{
			List<string> list = new List<string>();
			ZonePriority[] zonePriorities = EnumValues.ZonePriorities;
			for (int i = 0; i < zonePriorities.Length; i++)
			{
				ZonePriority zonePriority = zonePriorities[i];
				if (zonePriority != ZonePriority.None && zonePriority != ZonePriority.Last)
				{
					string text = zonePriority.ToString();
					text = "general_" + char.ToLower(text[0]) + text.Substring(1);
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText(text));
				}
			}
			priorityDropdown.AddOptions(list);
			priorityDropdown.onValueChanged.AddListener(delegate
			{
				OnPriorityChanged();
			});
		}

		private void OnPriorityChanged()
		{
			ZonePriority priority = (ZonePriority)(priorityDropdown.value + 1);
			infoPanelCropfield.CropfieldInstance?.SetPriority(priority);
		}

		private void SetYieldResources()
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("base_yeald_ripe") + "\n\n";
			foreach (ResourceOrderPair storableResource in infoPanelCropfield.CropfieldInstance.CultivablePlant.StorableResources)
			{
				text = text + ResourceUtils.GetTextIcon(storableResource.ResourceId) + " ~" + GetMaxYield().ToString(CultureInfo.InvariantCulture) + " ";
			}
			resourcesYieldedPerHarvest.SetText(text);
		}

		private float GetMaxYield()
		{
			return infoPanelCropfield.CropfieldInstance.CultivablePlant.LifePhases.SelectMany((PlantLifePhases phase) => phase.ResourcesRange).Aggregate(0f, (float current, IntRange item) => (!(current < (float)item.Max)) ? current : ((float)item.Max));
		}

		private void OnSowingDateRangeSliderMouseUp(float low, float high)
		{
			OnSowingDateRangeSliderDrag(low, high);
			OnSliderValueChange();
		}

		private void OnSowingDateRangeSliderDrag(float low, float high)
		{
			string seasonDayLocalized = DateTime.GetSeasonDayLocalized((int)low);
			string seasonDayLocalized2 = DateTime.GetSeasonDayLocalized((int)high);
			string formattedRange = seasonDayLocalized + " - " + seasonDayLocalized2;
			sowingDateRangeSlider.SetSliderData(null, formattedRange);
		}

		private void OnSliderValueChange()
		{
			infoPanelCropfield.CropfieldInstance.SetSowRange((int)sowingDateRangeSlider.Slider.LowValue, (int)sowingDateRangeSlider.Slider.HighValue);
		}
	}
}
