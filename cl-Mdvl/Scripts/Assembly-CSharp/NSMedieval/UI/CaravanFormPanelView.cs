using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI
{
	public class CaravanFormPanelView : CaravanPanelView
	{
		private enum SortMode
		{
			Name = 0,
			Quality = 1,
			Health = 2,
			Amount = 3,
			Nutrition = 4,
			Weight = 5,
			Price = 6
		}

		[SerializeField]
		private GameObject content;

		[SerializeField]
		private LayoutGroupView workersGroup;

		[SerializeField]
		private LayoutGroupView animalsGroup;

		[SerializeField]
		private LayoutGroupView itemsGroup;

		[SerializeField]
		private BasicLayoutItemView destinationLabel;

		[SerializeField]
		private BasicLayoutItemView destinationSubLabel1;

		[SerializeField]
		private BasicLayoutItemView destinationSubLabel2;

		[SerializeField]
		private BasicLayoutItemView massCarriedLabel;

		[SerializeField]
		private BasicLayoutItemView durationLabel;

		[SerializeField]
		private BasicLayoutItemView goodsValueLabel;

		[SerializeField]
		private BasicLayoutItemView foodSuppliesLabel;

		[SerializeField]
		private BasicLayoutItemView ambushChanceLabel;

		[SerializeField]
		private SoundButton resetButton;

		[SerializeField]
		private SoundButton acceptButton;

		[SerializeField]
		private SoundButton cancelButton;

		[SerializeField]
		private SoundButton[] sortingButtons;

		[SerializeField]
		private SortMode[] sortingButtonModes;

		[SerializeField]
		private SearchFilterView searchFilterView;

		[SerializeField]
		private string[] filterGroups;

		[NonSerialized]
		private List<CaravanEntryLayoutItemView> itemEntries;

		[NonSerialized]
		private List<CaravanWorkerEntry> workerEntries;

		[NonSerialized]
		private List<CaravanAnimalEntry> animalEntries;

		private const int MinWorkersCount = 1;

		private const int FilterOffsetIndex = 1;

		private int maxWorkersCount;

		private int maxAnimalsCount;

		private bool isMassCarriedOk;

		private bool isNutritionOk;

		private bool isMandatoryResourcesOk;

		private bool sortDirection;

		[NonSerialized]
		private SortMode sortMode;

		[NonSerialized]
		private VillageMap map;

		[NonSerialized]
		private readonly HashSet<CreatureBase> creaturesCanGoToEdge = new HashSet<CreatureBase>();

		private bool EnoughWorkersSelected
		{
			get
			{
				if (1 <= maxWorkersCount && base.CaravanInstance.Workers.Count >= 1)
				{
					return base.CaravanInstance.Workers.Count <= maxWorkersCount;
				}
				return false;
			}
		}

		private void GetCreaturesCanGoToMapEdge(IEnumerable<CreatureBase> creaturesList, HashSet<CreatureBase> creaturesCanGoToEdge)
		{
			creaturesCanGoToEdge.Clear();
			using PooledHashSet<uint> pooledHashSet = HashSetPool<uint>.GetJanitor();
			map.RegionAreaManager.GetAreasTouchingEdge(pooledHashSet);
			PathTraversalProvider pathTraversalProvider = Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("animal_leave_map").GenerateTraversalProvider();
			foreach (CreatureBase creatures in creaturesList)
			{
				if (CombatUtils.IsNullOrDisposed(creatures))
				{
					continue;
				}
				uint area = creatures.GetNode().Area;
				PathTraversalProvider traversalProvider = ((creatures is AnimalInstance) ? pathTraversalProvider : ((!(creatures is HumanoidInstance humanoidInstance) || !(humanoidInstance.ActiveBehaviour is PrisonerBehaviour)) ? creatures.PathTraversalProvider : pathTraversalProvider));
				foreach (uint item in pooledHashSet)
				{
					if (PathfinderUtil.IsAreaReachable(traversalProvider, map, item, area))
					{
						creaturesCanGoToEdge.Add(creatures);
						break;
					}
				}
			}
		}

		private static bool IsAnimalAvailableForCaravanForming(AnimalInstance animal)
		{
			if (animal == null || animal.HasDied || animal.HasDisposed)
			{
				return false;
			}
			if (animal.AnimalType != AnimalType.Pet && animal.AnimalType != AnimalType.Domestic)
			{
				return false;
			}
			return true;
		}

		public void OpenPanel(VillageMap map, WorldMapPlace destinationPlace)
		{
			if (!IsShowing())
			{
				this.map = map;
				base.CaravanInstance = new CaravanInstance(destinationPlace);
				Show();
			}
		}

		public override void UpdatedWorkersCount()
		{
			acceptButton.interactable = EnoughWorkersSelected;
			int num = workerEntries.Count((CaravanWorkerEntry we) => we.isActiveAndEnabled && we.Humanoid.ActiveBehaviour is WorkerBehaviour);
			int num2 = workerEntries.Count((CaravanWorkerEntry we) => we.isActiveAndEnabled && we.IsSelectedForCaravan && we.Humanoid.ActiveBehaviour is WorkerBehaviour);
			bool flag = num - num2 != 1;
			foreach (CaravanWorkerEntry workerEntry in workerEntries)
			{
				HumanoidInstance humanoid = workerEntry.Humanoid;
				bool flag2 = humanoid.IsCaptive();
				if (flag2 && !humanoid.CaptiveNpcBehaviour.Shackled)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText("cant_add_prisoner_caravan");
					workerEntry.SetClickable(clickable: false, text, text);
				}
				else if (!creaturesCanGoToEdge.Contains(humanoid))
				{
					string text2 = MonoSingleton<LocalizationController>.Instance.GetText(flag2 ? "caravan_prisoner_stuck" : "caravan_worker_stuck");
					workerEntry.SetClickable(clickable: false, text2, text2);
				}
				else if (humanoid.IsFormingCaravan())
				{
					string text3 = MonoSingleton<LocalizationController>.Instance.GetText(flag2 ? "caravan_prisoner_already_forming" : "caravan_worker_already_forming");
					workerEntry.SetClickable(clickable: false, text3, text3);
				}
				else if (!humanoid.CanFormCaravan())
				{
					string text4 = MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_able");
					workerEntry.SetClickable(clickable: false, text4, text4);
				}
				else if (!workerEntry.IsSelectedForCaravan)
				{
					bool clickable = flag || !(humanoid.ActiveBehaviour is WorkerBehaviour);
					workerEntry.SetClickable(clickable, string.Empty, string.Empty);
				}
			}
			UpdateMassCarried();
			UpdateNutritionAndMandatoryResources();
			RefreshAcceptButtonInteractable();
			UpdateAmbushChance();
		}

		private void OnEnable()
		{
			if (itemEntries == null)
			{
				itemEntries = new List<CaravanEntryLayoutItemView>();
			}
			if (workerEntries == null)
			{
				workerEntries = new List<CaravanWorkerEntry>();
			}
			if (animalEntries == null)
			{
				animalEntries = new List<CaravanAnimalEntry>();
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			content.SetActive(value: true);
			maxWorkersCount = 0;
			using PooledList<CreatureBase> pooledList = ListPool<CreatureBase>.GetJanitor();
			List<HumanoidInstance> list = new List<HumanoidInstance>(GlobalSaveController.CurrentVillageData.Workers);
			list.Sort((HumanoidInstance workerA, HumanoidInstance workerB) => string.Compare(workerA.Info.GetFullName(), workerB.Info.GetFullName(), StringComparison.CurrentCulture));
			foreach (HumanoidInstance item in list)
			{
				CaravanWorkerEntry at = workerEntries.GetAt(workersGroup, maxWorkersCount);
				maxWorkersCount++;
				at.gameObject.SetActive(value: true);
				HumanoidInstance humanoid = item;
				at.SetData(humanoid, OnWorkerToggle);
				pooledList.Add(item);
			}
			List<HumanoidInstance> list2 = new List<HumanoidInstance>();
			foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
			{
				if (nPC != null && !nPC.HasDisposed && !nPC.HasFainted && nPC.IsCaptive() && nPC.CaptiveNpcBehaviour.Owner == null)
				{
					list2.Add(nPC);
				}
			}
			list2.Sort((HumanoidInstance workerA, HumanoidInstance workerB) => string.Compare(workerA.Info.GetFullName(), workerB.Info.GetFullName(), StringComparison.CurrentCulture));
			foreach (HumanoidInstance item2 in list2)
			{
				CaravanWorkerEntry at2 = workerEntries.GetAt(workersGroup, maxWorkersCount);
				maxWorkersCount++;
				at2.gameObject.SetActive(value: true);
				at2.SetData(item2, OnWorkerToggle);
				pooledList.Add(item2);
			}
			workerEntries.SetActiveFromIndex(maxWorkersCount, active: false);
			maxAnimalsCount = 0;
			pooledList.AddRange(MonoSingleton<AnimalManager>.Instance.Animals.Keys);
			GetCreaturesCanGoToMapEdge(pooledList, creaturesCanGoToEdge);
			foreach (AnimalInstance key in MonoSingleton<AnimalManager>.Instance.Animals.Keys)
			{
				if (IsAnimalAvailableForCaravanForming(key))
				{
					CaravanAnimalEntry at3 = animalEntries.GetAt(animalsGroup, maxAnimalsCount);
					at3.SetData(key, this);
					bool flag = key.IsFormingCaravan();
					bool flag2 = creaturesCanGoToEdge.Contains(key);
					string tooltipKey = string.Empty;
					string bbtKey = string.Empty;
					if (flag)
					{
						tooltipKey = "caravan_animal_already_forming";
						bbtKey = "caravan_animal_already_forming";
					}
					else if (!flag2)
					{
						tooltipKey = "caravan_animal_stuck";
						bbtKey = "caravan_animal_stuck";
					}
					at3.SetClickable(flag2 && !flag, tooltipKey, bbtKey);
					maxAnimalsCount++;
				}
			}
			animalEntries.SetActiveFromIndex(maxAnimalsCount, active: false);
			int num = 0;
			foreach (ResourceInstance resource in TradingManager.GetResources())
			{
				CaravanEntryLayoutItemView at4 = itemEntries.GetAt(itemsGroup, num);
				at4.SetData(resource);
				at4.AmountInput.AmountChangedEvent -= OnAmountChanged;
				at4.AmountInput.AmountChangedEvent += OnAmountChanged;
				num++;
			}
			itemEntries.SetActiveFromIndex(num, active: false);
			SortEntries();
			searchFilterView.ResetFilter();
			if (!base.CaravanInstance.DestinationPlace.TryGenerateLootEstimate(out var valueEstimate, out var weightEstimate))
			{
				destinationSubLabel1.gameObject.SetActive(value: false);
				destinationSubLabel2.gameObject.SetActive(value: false);
			}
			else
			{
				destinationSubLabel1.gameObject.SetActive(value: true);
				destinationSubLabel2.gameObject.SetActive(value: true);
				destinationSubLabel1.SetText(string.Format("{0} {1:F1}-{2:F1} {3}", "loot_stash_value".ToLocalized(), valueEstimate.Min, valueEstimate.Max, TradeEntryLayoutItemView.ValueSprite));
				destinationSubLabel2.SetText(string.Format("{0} {1:F1}-{2:F1} {3}", "loot_stash_weight".ToLocalized(), weightEstimate.Min, weightEstimate.Max, "general_kg".ToLocalized()));
			}
			destinationLabel.SetText(MonoSingleton<LocalizationController>.Instance.GetText("caravan_travel_to") + " " + base.CaravanInstance.DestinationPlace.Name);
			UpdatedWorkersCount();
			UpdateGoodsValue();
			UpdateTripDuration();
		}

		private void OnWorkerToggle(bool selected, HumanoidInstance humanoidInstance)
		{
			bool flag = humanoidInstance.IsCaptive();
			bool isEnabled;
			if (selected)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\CaravanFormPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding ");
					messageBuilder.AppendFormatted(humanoidInstance.Info.GetFullName());
					messageBuilder.AppendLiteral(" to caravan '");
					messageBuilder.AppendFormatted(base.CaravanInstance.Name);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				if (flag)
				{
					base.CaravanInstance.Creatures.Add(humanoidInstance);
					base.CaravanInstance.PrisonersCountChanged();
				}
				else
				{
					base.CaravanInstance.Workers.Add(humanoidInstance);
				}
			}
			else
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\CaravanFormPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing ");
					messageBuilder.AppendFormatted(humanoidInstance.Info.GetFullName());
					messageBuilder.AppendLiteral(" from caravan '");
					messageBuilder.AppendFormatted(base.CaravanInstance.Name);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				if (flag)
				{
					base.CaravanInstance.Creatures.Remove(humanoidInstance);
					base.CaravanInstance.PrisonersCountChanged();
				}
				else
				{
					base.CaravanInstance.Workers.Remove(humanoidInstance);
				}
			}
			UpdatedWorkersCount();
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.CaravanInstance = null;
			content.SetActive(value: false);
		}

		private void Start()
		{
			cancelButton.onClick.RemoveAllListeners();
			cancelButton.onClick.AddListener(Hide);
			resetButton.onClick.RemoveAllListeners();
			resetButton.onClick.AddListener(ResetCaravan);
			acceptButton.onClick.RemoveAllListeners();
			acceptButton.onClick.AddListener(AcceptCaravan);
			acceptButton.onNonInteractableClick.AddListener(CannotAcceptCaravan);
			SoundButton[] array = sortingButtons;
			foreach (SoundButton sortingButton in array)
			{
				if (!(sortingButton == null))
				{
					sortingButton.onClick.RemoveAllListeners();
					sortingButton.onClick.AddListener(delegate
					{
						OnSortColumnClicked(sortingButton);
					});
				}
			}
			SetSortArrows(0);
			SetupSearchFilter();
		}

		private void OnDestroy()
		{
			map = null;
			animalEntries.Clear();
			creaturesCanGoToEdge.Clear();
			itemEntries = null;
			workerEntries = null;
			animalEntries = null;
			base.CaravanInstance = null;
		}

		private void OnSortColumnClicked(SoundButton sortButton)
		{
			int num = -1;
			for (int i = 0; i < sortingButtons.Length; i++)
			{
				if (sortingButtons[i] == sortButton)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				SetSortMode(sortingButtonModes[num]);
				SetSortArrows(num);
			}
		}

		private void SetSortMode(SortMode mode)
		{
			if (sortMode == mode)
			{
				sortDirection = !sortDirection;
				SortEntries();
			}
			else
			{
				sortDirection = false;
				sortMode = mode;
				SortEntries();
			}
		}

		private void SetSortArrows(int selectedButtonIndex)
		{
			for (int i = 0; i < sortingButtons.Length; i++)
			{
				TradingSortArrowImages component = sortingButtons[i].GetComponent<TradingSortArrowImages>();
				if (component != null)
				{
					bool upDown = i == selectedButtonIndex && sortDirection;
					component.SetArrows(upDown, i == selectedButtonIndex);
				}
			}
		}

		private void SortEntries()
		{
			itemEntries.Sort(TradeEntrySortComparison);
			int num = 0;
			foreach (CaravanEntryLayoutItemView itemEntry in itemEntries)
			{
				itemEntry.transform.SetSiblingIndex(num++);
			}
		}

		private int TradeEntrySortComparison(CaravanEntryLayoutItemView a, CaravanEntryLayoutItemView b)
		{
			int num = 0;
			Resource resource = a.Resource;
			Resource resource2 = b.Resource;
			switch (sortMode)
			{
			case SortMode.Health:
				num = string.Compare(a.HealthString, b.HealthString, StringComparison.InvariantCulture);
				break;
			case SortMode.Amount:
				num = a.Amount - b.Amount;
				break;
			case SortMode.Name:
				num = string.Compare(b.ItemNameString, a.ItemNameString, StringComparison.CurrentCultureIgnoreCase);
				break;
			case SortMode.Nutrition:
				num = Mathf.RoundToInt((resource.Nutrition - resource2.Nutrition) * 100f);
				break;
			case SortMode.Price:
				num = Mathf.RoundToInt((resource.WealthPoints - resource2.WealthPoints) * 100f);
				break;
			case SortMode.Quality:
				num = (resource.HasQuality ? resource.Quality : ProductQuality.None) - (resource2.HasQuality ? resource2.Quality : ProductQuality.None);
				break;
			case SortMode.Weight:
				num = Mathf.RoundToInt((resource.Weight - resource2.Weight) * 100f);
				break;
			}
			if (!sortDirection)
			{
				return -num;
			}
			return num;
		}

		private void OnFilterApplied(int filterIndex)
		{
			string mainGroupName = null;
			if (filterIndex >= 1)
			{
				mainGroupName = filterGroups[filterIndex - 1];
			}
			foreach (CaravanEntryLayoutItemView itemEntry in itemEntries)
			{
				if (filterIndex == 0)
				{
					itemEntry.SetFiltered(isFiltered: false);
					continue;
				}
				bool filtered = !Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.CheckGroup(itemEntry.Resource.SortingGroup, mainGroupName);
				itemEntry.SetFiltered(filtered);
			}
		}

		private void SetupSearchFilter()
		{
			List<string> list = new List<string>();
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("filter_all_items"));
			string[] array = filterGroups;
			foreach (string text in array)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("resource_group_" + text));
			}
			searchFilterView.SetupFilters(list);
			searchFilterView.OnFilterChanged += OnFilterApplied;
		}

		private void UpdateTripDuration()
		{
			string timeFormatByMinutes = UiUtils.GetTimeFormatByMinutes(base.CaravanInstance.GetTripDurationMinutes(), isDuration: true);
			string text = MonoSingleton<LocalizationController>.Instance.GetText("caravan_trip");
			durationLabel.SetText(text + ": " + timeFormatByMinutes);
		}

		private void OnAmountChanged(int amount)
		{
			base.CaravanInstance.SetResourcesToCarry(GetResourcesToCarry());
			UpdateMassCarried();
			UpdateNutritionAndMandatoryResources();
			UpdateGoodsValue();
			RefreshAcceptButtonInteractable();
		}

		private void PrepareApplyButtonTooltip()
		{
			TooltipViewNew component = acceptButton.GetComponent<TooltipViewNew>();
			if (component == null)
			{
				return;
			}
			if (base.CaravanInstance.Workers.Count > 0 && isNutritionOk && isMassCarriedOk && isMandatoryResourcesOk)
			{
				component.enabled = false;
				return;
			}
			List<string> list = new List<string>();
			if (base.CaravanInstance.Workers.Count == 0)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_one_settler"));
			}
			else
			{
				if (!isNutritionOk)
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_food"));
				}
				if (!isMassCarriedOk)
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_mass"));
				}
				if (!isMandatoryResourcesOk)
				{
					list.Add(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_mandatory_resources"));
				}
			}
			component.SetLines(list);
			component.enabled = true;
		}

		private void CannotAcceptCaravan()
		{
			if (!isMassCarriedOk && base.CaravanInstance.Workers.Count > 0)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_mass"));
			}
			if (!isNutritionOk && base.CaravanInstance.Workers.Count > 0)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_food"));
			}
			if (!isMandatoryResourcesOk && base.CaravanInstance.Workers.Count > 0)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_mandatory_resources"));
			}
			if (base.CaravanInstance.Workers.Count == 0)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_one_settler"));
			}
		}

		private void AcceptCaravan()
		{
			if (base.CaravanInstance.Workers.Count == 0 || base.CaravanInstance.DestinationPlace == null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(42, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\CaravanFormPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot accept caravan to ");
					messageBuilder.AppendFormatted(base.CaravanInstance.DestinationPlace?.Name);
					messageBuilder.AppendLiteral(", workers count: ");
					messageBuilder.AppendFormatted(base.CaravanInstance.Workers.Count);
				}
				Log.Info(messageBuilder);
				Hide();
			}
			else
			{
				MonoSingleton<CaravanFormingManager>.Instance.FormNewCaravan(base.CaravanInstance);
				MonoSingleton<CaravanController>.Instance.CaravanFormingStarted(base.CaravanInstance);
				Hide();
			}
		}

		private List<ResourceInstance> GetResourcesToCarry()
		{
			List<ResourceInstance> list = new List<ResourceInstance>();
			foreach (CaravanEntryLayoutItemView itemEntry in itemEntries)
			{
				if (!itemEntry.isActiveAndEnabled && !itemEntry.IsFiltered)
				{
					continue;
				}
				int tradeValue = itemEntry.GetTradeValue();
				if (tradeValue <= 0)
				{
					continue;
				}
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder;
				if (ResourceUtils.IsItem(itemEntry.Resource))
				{
					messageBuilder = new FVLogInfoInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\CaravanFormPanelView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("ADDED ITEM ");
						messageBuilder.AppendFormatted(itemEntry.Amount);
						messageBuilder.AppendLiteral(" x ");
						messageBuilder.AppendFormatted(itemEntry.Resource);
					}
					Log.Info(messageBuilder);
					list.Add(itemEntry.CreateResourceInstance());
					continue;
				}
				if (tradeValue < itemEntry.Amount)
				{
					itemEntry.SubResourceAmount(itemEntry.Amount - tradeValue);
				}
				else if (tradeValue != itemEntry.Amount)
				{
					itemEntry.AddResourceAmount(itemEntry.Amount - tradeValue);
				}
				messageBuilder = new FVLogInfoInterpolationHandler(9, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\CaravanFormPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ADDED ");
					messageBuilder.AppendFormatted(itemEntry.Amount);
					messageBuilder.AppendLiteral(" x ");
					messageBuilder.AppendFormatted(itemEntry.Resource);
				}
				Log.Info(messageBuilder);
				list.Add(itemEntry.CreateResourceInstance());
			}
			return list;
		}

		private void ResetCaravan()
		{
			foreach (CaravanEntryLayoutItemView itemEntry in itemEntries)
			{
				itemEntry.AmountInput.SetTradeValue(0);
			}
			foreach (CaravanWorkerEntry workerEntry in workerEntries)
			{
				workerEntry.Reset();
			}
			foreach (CaravanAnimalEntry animalEntry in animalEntries)
			{
				animalEntry.Reset();
			}
			Log.Info("Reset Caravan: clearing workers.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\CaravanFormPanelView.cs");
			base.CaravanInstance.Workers.Clear();
			base.CaravanInstance.TMPResourcesToCarry.Clear();
			UpdatedWorkersCount();
			UpdateGoodsValue();
		}

		private void UpdateGoodsValue()
		{
			int num = (int)base.CaravanInstance.GetWealth();
			string text = MonoSingleton<LocalizationController>.Instance.GetText("caravan_value");
			goodsValueLabel.SetText($"{text}: {TradeEntryLayoutItemView.ValueSprite} {num}");
			UpdateAmbushChance();
		}

		private void UpdateMassCarried()
		{
			int num = base.CaravanInstance.Workers.Sum((HumanoidInstance worker) => worker.Storage.StorageBase.Capacity);
			num += base.CaravanInstance.Creatures.Sum((CreatureBase creature) => creature.CaravanStorageCapacity);
			string text = MonoSingleton<LocalizationController>.Instance.GetText("caravan_mass");
			string text2 = MonoSingleton<LocalizationController>.Instance.GetText("general_kg");
			isMassCarriedOk = base.CaravanInstance.IsStorageMassOk();
			string text3 = (isMassCarriedOk ? "DefaultGreen" : "DefaultRed");
			float massCarried = base.CaravanInstance.GetMassCarried();
			massCarriedLabel.SetText($"<style=Normal>{text}:</style> <style={text3}>{massCarried:N1} / {num:N1} {text2}</style>");
		}

		private void UpdateNutritionAndMandatoryResources()
		{
			isNutritionOk = base.CaravanInstance.IsEnoughFood();
			string text = MonoSingleton<LocalizationController>.Instance.GetText("caravan_food");
			string text2 = (isNutritionOk ? "DefaultGreen" : "DefaultRed");
			string text3 = $"<style=Normal>{text}:</style> <style={text2}>{base.CaravanInstance.GetFoodLevel():N1} / {base.CaravanInstance.GetMinimumNutrition():N1}</style>";
			foodSuppliesLabel.SetText(text3 ?? "");
			if (base.CaravanInstance.DestinationPlace.HasTradeDeal)
			{
				isMandatoryResourcesOk = base.CaravanInstance.IsMandatoryResourcesOk();
				string text4 = MonoSingleton<LocalizationController>.Instance.GetText(base.CaravanInstance.DestinationPlace.MandatoryResourcesTextKey);
				string text5 = MonoSingleton<LocalizationController>.Instance.GetText("caravan_mandatory_resources") + " (" + text4 + ")";
				text2 = (isMandatoryResourcesOk ? "DefaultGreen" : "DefaultRed");
				string text6 = $"<style=Normal>{text5}:</style> <style={text2}>{base.CaravanInstance.GetMandatoryResourcesWealth():N1} / {base.CaravanInstance.DestinationPlace.MandatoryResourceWealthPoints:N1}</style>";
				destinationSubLabel2.gameObject.SetActive(value: true);
				destinationSubLabel2.SetText(text6);
			}
			else
			{
				destinationSubLabel2.gameObject.SetActive(value: false);
			}
		}

		private void RefreshAcceptButtonInteractable()
		{
			acceptButton.interactable = isMassCarriedOk && EnoughWorkersSelected && base.CaravanInstance.IsEnoughFood();
			PrepareApplyButtonTooltip();
		}

		private void UpdateAmbushChance()
		{
			int num = (int)(CaravanManager.CalculateAmbushChance(base.CaravanInstance) * 100f);
			ambushChanceLabel.SetText("ambush_chance".ToLocalized() + $": {num}%");
		}
	}
}
