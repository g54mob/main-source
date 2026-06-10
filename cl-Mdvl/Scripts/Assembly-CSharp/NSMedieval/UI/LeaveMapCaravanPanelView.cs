using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI
{
	public class LeaveMapCaravanPanelView : CaravanPanelView
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
		private BasicLayoutItemView massCarriedLabel;

		[SerializeField]
		private BasicLayoutItemView goodsValueLabel;

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

		[NonSerialized]
		private List<CaravanEntryLayoutItemView> itemEntries;

		[NonSerialized]
		private List<CaravanWorkerEntry> humanoidEntries;

		[NonSerialized]
		private List<CaravanAnimalEntry> animalEntries;

		private int maxWorkersCount;

		private int maxAnimalsCount;

		private bool isMassCarriedOk;

		private bool sortDirection;

		private bool canTakeItems;

		[NonSerialized]
		private SortMode sortMode;

		[NonSerialized]
		private VillageMap map;

		public void OpenPanel(VillageMap map, CaravanInstance caravan)
		{
			if (!IsShowing())
			{
				if (caravan == null)
				{
					throw new Exception("Caravan cannot be null");
				}
				this.map = map;
				base.CaravanInstance = caravan;
				Show();
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			content.SetActive(value: true);
			maxWorkersCount = 0;
			using PooledList<HumanoidInstance> pooledList = GlobalSaveController.CurrentVillageData.Workers.ToPooledListJanitor();
			pooledList.Sort((HumanoidInstance workerA, HumanoidInstance workerB) => string.Compare(workerA.Info.GetFullName(), workerB.Info.GetFullName(), StringComparison.CurrentCulture));
			foreach (HumanoidInstance item in pooledList)
			{
				CaravanWorkerEntry at = humanoidEntries.GetAt(workersGroup, maxWorkersCount);
				maxWorkersCount++;
				at.gameObject.SetActive(value: true);
				at.SetDataNonInteractable(item, item.CanFormCaravan(allowFainted: true));
			}
			using PooledList<HumanoidInstance> pooledList2 = GlobalSaveController.CurrentVillageData.NPCs.WherePooled(delegate(HumanoidInstance npc)
			{
				if (!npc.IsCaptive())
				{
					return false;
				}
				if (npc.HasDisposed || npc.HasFainted)
				{
					return false;
				}
				CaptiveNpcBehaviour captiveNpcBehaviour = npc.CaptiveNpcBehaviour;
				return captiveNpcBehaviour != null && captiveNpcBehaviour.Owner == null;
			});
			pooledList2.Sort((HumanoidInstance workerA, HumanoidInstance workerB) => string.Compare(workerA.Info.GetFullName(), workerB.Info.GetFullName(), StringComparison.CurrentCulture));
			foreach (HumanoidInstance item2 in pooledList2)
			{
				CaravanWorkerEntry at2 = humanoidEntries.GetAt(workersGroup, maxWorkersCount);
				maxWorkersCount++;
				at2.gameObject.SetActive(value: true);
				at2.SetData(item2, OnPrisonerToggle);
				at2.SetToggle(value: true);
			}
			humanoidEntries.SetActiveFromIndex(maxWorkersCount, active: false);
			maxAnimalsCount = 0;
			foreach (AnimalInstance key in MonoSingleton<AnimalManager>.Instance.Animals.Keys)
			{
				if (IsAnimalAvailableForCaravanForming(key))
				{
					CaravanAnimalEntry at3 = animalEntries.GetAt(animalsGroup, maxAnimalsCount);
					at3.SetData(key, this);
					at3.SetClickable(clickable: true, string.Empty, string.Empty);
					at3.SetToggle(value: true);
					maxAnimalsCount++;
				}
			}
			animalEntries.SetActiveFromIndex(maxAnimalsCount, active: false);
			PooledDictionary<string, int> janitor = DictionaryPool<string, int>.GetJanitor();
			try
			{
				foreach (SimpleResourceCount item3 in base.CaravanInstance.ResourcesCaravanCameWith)
				{
					janitor.TryAdd(item3.BlueprintId, 0);
					janitor[item3.BlueprintId] += item3.Amount;
				}
				bool flag = true;
				SecondMapSaveInfo cachedMapInfo = GlobalSaveController.CurrentVillageData.WorldMapPlace.CachedMapInfo;
				if (cachedMapInfo.Type == SecondMapType.LootStash && cachedMapInfo.HasHostiles)
				{
					flag = !MonoSingleton<AnimalManager>.Instance.HasHostileAnimals();
				}
				bool flag2 = !MonoSingleton<NPCManager>.Instance.HasHostileNPCs();
				canTakeItems = flag && flag2;
				SecondMapLeaveOutcome secondMapLeaveOutcome = map.SecondMapLeaveManager.SecondMapLeaveOutcome;
				if ((secondMapLeaveOutcome == SecondMapLeaveOutcome.LeftWithoutEngagingEnemy || secondMapLeaveOutcome == SecondMapLeaveOutcome.BattleTie || secondMapLeaveOutcome == SecondMapLeaveOutcome.BattleVictory) && flag && flag2)
				{
					canTakeItems = true;
				}
				float resourcePercentageLost = map.SecondMapLeaveManager.ResourcePercentageLost;
				using PooledList<Vec3Int> pooledList3 = pooledList.ToPooledListJanitorSelect((HumanoidInstance worker) => worker.GetGridPosition());
				int num = 0;
				foreach (ResourceInstance resource in TradingManager.GetResources(mustBeStored: false, pooledList3))
				{
					int num2 = (int)((float)resource.Amount * resourcePercentageLost);
					int num3 = resource.Amount - num2;
					if (num3 <= 0)
					{
						num++;
						continue;
					}
					ResourceInstance resourceInstance = resource.Clone();
					resourceInstance.Sub(num2);
					CaravanEntryLayoutItemView at4 = itemEntries.GetAt(itemsGroup, num);
					at4.SetData(resourceInstance);
					resourceInstance.Dispose();
					resourceInstance = null;
					if (!canTakeItems)
					{
						if (janitor.TryGetValue(resource.BlueprintId, out var _))
						{
							at4.AmountInput.SetInteractable(interactable: true);
							at4.AmountInput.SetTooltipLines(null);
							at4.AmountInput.AmountChangedEvent -= OnAmountChanged;
							at4.AmountInput.AmountChangedEvent += OnAmountChanged;
							at4.AmountInput.SetTradeValue(num3);
							num++;
						}
						else
						{
							at4.AmountInput.SetTradeValue(0);
							at4.AmountInput.SetInteractable(interactable: false, leaveButtonsVisibleIfDisabled: true);
							at4.AmountInput.SetTooltipLine("cant_take_items_hostiles_on_map".ToLocalized());
							num++;
						}
					}
					else
					{
						at4.AmountInput.SetInteractable(interactable: true);
						at4.AmountInput.SetTooltipLines(null);
						at4.AmountInput.AmountChangedEvent -= OnAmountChanged;
						at4.AmountInput.AmountChangedEvent += OnAmountChanged;
						if (janitor.TryGetValue(resource.BlueprintId, out var value2))
						{
							at4.AmountInput.SetTradeValue(value2);
						}
						num++;
					}
				}
				itemEntries.SetActiveFromIndex(num, active: false);
				base.CaravanInstance.Workers.Clear();
				base.CaravanInstance.Workers.AddRange(from entry in humanoidEntries
					where entry.Humanoid.IsWorker() && entry.isActiveAndEnabled
					select entry.Humanoid);
				SortEntries();
				bool interactable = !map.SecondMapLeaveManager.TimedOut && !map.SecondMapLeaveManager.DisableExitCaravanScreenButton;
				cancelButton.interactable = interactable;
				OnAmountChanged(0);
				MonoSingleton<TravelManager>.Instance.TookItemsFromMap = false;
			}
			finally
			{
				((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
			}
		}

		public override void UpdatedWorkersCount()
		{
			int num = humanoidEntries.Count((CaravanWorkerEntry we) => we.isActiveAndEnabled && we.Humanoid.ActiveBehaviour is WorkerBehaviour);
			int num2 = humanoidEntries.Count((CaravanWorkerEntry we) => we.isActiveAndEnabled && we.IsSelectedForCaravan && we.Humanoid.ActiveBehaviour is WorkerBehaviour);
			bool flag = num - num2 != 1;
			foreach (CaravanWorkerEntry humanoidEntry in humanoidEntries)
			{
				CaptiveNpcBehaviour captiveNpcBehaviour = humanoidEntry.Humanoid.CaptiveNpcBehaviour;
				bool flag2 = captiveNpcBehaviour != null;
				if (flag2 && !captiveNpcBehaviour.Shackled)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText("cant_add_prisoner_caravan");
					humanoidEntry.SetClickable(clickable: false, text, text);
				}
				else if (humanoidEntry.Humanoid.IsFormingCaravan())
				{
					string text2 = MonoSingleton<LocalizationController>.Instance.GetText(flag2 ? "caravan_prisoner_already_forming" : "caravan_worker_already_forming");
					humanoidEntry.SetClickable(clickable: false, text2, text2);
				}
				else if (!humanoidEntry.Humanoid.CanFormCaravan(allowFainted: true))
				{
					string text3 = MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_able");
					humanoidEntry.SetClickable(clickable: false, text3, text3);
				}
				else if (!humanoidEntry.IsSelectedForCaravan)
				{
					bool clickable = flag || !(humanoidEntry.Humanoid.ActiveBehaviour is WorkerBehaviour);
					humanoidEntry.SetClickable(clickable, string.Empty, string.Empty);
				}
			}
			UpdateMassCarried();
			RefreshAcceptButtonInteractable();
		}

		private void OnEnable()
		{
			if (itemEntries == null)
			{
				itemEntries = new List<CaravanEntryLayoutItemView>();
			}
			if (humanoidEntries == null)
			{
				humanoidEntries = new List<CaravanWorkerEntry>();
			}
			if (animalEntries == null)
			{
				animalEntries = new List<CaravanAnimalEntry>();
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

		private void OnPrisonerToggle(bool selected, HumanoidInstance humanoidInstance)
		{
			bool isEnabled;
			if (selected)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LeaveMapCaravanPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding ");
					messageBuilder.AppendFormatted(humanoidInstance.GetFullName());
					messageBuilder.AppendLiteral(" to caravan '");
					messageBuilder.AppendFormatted(base.CaravanInstance.Name);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				base.CaravanInstance.Creatures.Add(humanoidInstance);
			}
			else
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LeaveMapCaravanPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing ");
					messageBuilder.AppendFormatted(humanoidInstance.GetFullName());
					messageBuilder.AppendLiteral(" from caravan '");
					messageBuilder.AppendFormatted(base.CaravanInstance.Name);
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				base.CaravanInstance.Creatures.Remove(humanoidInstance);
			}
			base.CaravanInstance.PrisonersCountChanged();
		}

		protected override void OnHide()
		{
			base.OnHide();
			map.SecondMapLeaveManager.OnBeforeCloseLeaveMenuButton();
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
		}

		private void OnDestroy()
		{
			map = null;
			animalEntries.Clear();
			itemEntries = null;
			humanoidEntries = null;
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
			num = sortMode switch
			{
				SortMode.Health => string.Compare(a.HealthString, b.HealthString, StringComparison.InvariantCulture), 
				SortMode.Amount => a.Amount - b.Amount, 
				SortMode.Name => string.Compare(b.ItemNameString, a.ItemNameString, StringComparison.CurrentCultureIgnoreCase), 
				SortMode.Nutrition => Mathf.RoundToInt((resource.Nutrition - resource2.Nutrition) * 100f), 
				SortMode.Price => Mathf.RoundToInt((resource.WealthPoints - resource2.WealthPoints) * 100f), 
				SortMode.Quality => (resource.HasQuality ? resource.Quality : ProductQuality.None) - (resource2.HasQuality ? resource2.Quality : ProductQuality.None), 
				SortMode.Weight => Mathf.RoundToInt((resource.Weight - resource2.Weight) * 100f), 
				_ => num, 
			};
			if (!sortDirection)
			{
				return -num;
			}
			return num;
		}

		private void OnAmountChanged(int amount)
		{
			MonoSingleton<TravelManager>.Instance.TookItemsFromMap = true;
			base.CaravanInstance.SetResourcesToCarry(GetResourcesToCarry());
			UpdateMassCarried();
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
			if (base.CaravanInstance.Workers.Count > 0 && isMassCarriedOk)
			{
				component.enabled = false;
				return;
			}
			List<string> list = new List<string>();
			if (base.CaravanInstance.Workers.Count == 0)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_one_settler"));
			}
			else if (!isMassCarriedOk)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_mass"));
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
			if (base.CaravanInstance.Workers.Count == 0)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_one_settler"));
			}
		}

		private void AcceptCaravan()
		{
			WorldMapPlace worldMapPlace = GlobalSaveController.CurrentVillageData.WorldMapPlace;
			if (canTakeItems)
			{
				worldMapPlace.LootableStorage.ClearAll(isSilent: true);
				worldMapPlace.LootableCreatures.Clear();
				foreach (CaravanEntryLayoutItemView itemEntry in itemEntries)
				{
					if (itemEntry.AmountInput.MaxTradeValue - itemEntry.GetTradeValue() > 0)
					{
						worldMapPlace.LootableStorage.Add(itemEntry.CreateResourceInstance());
					}
				}
				foreach (CaravanAnimalEntry animalEntry in animalEntries)
				{
					if (!base.CaravanInstance.Creatures.Contains(animalEntry.AnimalInstance))
					{
						worldMapPlace.LootableCreatures.Add(animalEntry.AnimalInstance);
					}
				}
				foreach (CaravanWorkerEntry humanoidEntry in humanoidEntries)
				{
					if (!humanoidEntry.Humanoid.IsWorker() && !base.CaravanInstance.Creatures.Contains(humanoidEntry.Humanoid))
					{
						worldMapPlace.LootableCreatures.Add(humanoidEntry.Humanoid);
					}
				}
			}
			base.CaravanInstance.InitCaravanStorage();
			foreach (HumanoidInstance worker in base.CaravanInstance.Workers)
			{
				worker.GetGoapAgent().Abort();
				worker.CombatAi?.Abort();
				worker.IncognitoDispose();
				worker.ClearCaravanFormingData();
			}
			foreach (CreatureBase creature in base.CaravanInstance.Creatures)
			{
				creature.GetGoapAgent()?.Abort();
				creature.CombatAi?.Abort();
				creature.IncognitoDispose();
				if (creature is AnimalInstance animalInstance)
				{
					animalInstance.ClearCaravanFormingData();
				}
			}
			Hide();
			MonoSingleton<TravelManager>.Instance.LoadOriginalVillage();
		}

		private List<ResourceInstance> GetResourcesToCarry()
		{
			List<ResourceInstance> list = new List<ResourceInstance>();
			foreach (CaravanEntryLayoutItemView itemEntry in itemEntries)
			{
				if (!itemEntry.isActiveAndEnabled)
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
					messageBuilder = new FVLogInfoInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LeaveMapCaravanPanelView.cs");
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
					itemEntry.AddResourceAmount(tradeValue - itemEntry.Amount);
				}
				messageBuilder = new FVLogInfoInterpolationHandler(9, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LeaveMapCaravanPanelView.cs");
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
			MonoSingleton<TravelManager>.Instance.TookItemsFromMap = false;
			foreach (CaravanEntryLayoutItemView itemEntry in itemEntries)
			{
				itemEntry.AmountInput.SetTradeValue(0);
			}
			foreach (CaravanAnimalEntry animalEntry in animalEntries)
			{
				animalEntry.Reset();
			}
			base.CaravanInstance.Workers.RemoveWhere((HumanoidInstance humanoid) => !humanoid.IsWorker());
			base.CaravanInstance.TMPResourcesToCarry.Clear();
			UpdatedWorkersCount();
			UpdateGoodsValue();
		}

		private void UpdateGoodsValue()
		{
			int num = (int)base.CaravanInstance.GetWealth();
			string text = MonoSingleton<LocalizationController>.Instance.GetText("caravan_value");
			goodsValueLabel.SetText($"{text}: {TradeEntryLayoutItemView.ValueSprite} {num}");
		}

		private void UpdateMassCarried()
		{
			int num = base.CaravanInstance.Workers.Sum((HumanoidInstance worker) => worker.GetCaravanCarryWeight());
			num += base.CaravanInstance.Creatures.Sum((CreatureBase creature) => creature.CaravanStorageCapacity);
			string text = MonoSingleton<LocalizationController>.Instance.GetText("caravan_mass");
			string text2 = MonoSingleton<LocalizationController>.Instance.GetText("general_kg");
			isMassCarriedOk = base.CaravanInstance.IsStorageMassOk();
			string text3 = (isMassCarriedOk ? "DefaultGreen" : "DefaultRed");
			float massCarried = base.CaravanInstance.GetMassCarried();
			massCarriedLabel.SetText($"<style=Normal>{text}:</style> <style={text3}>{massCarried:N1} / {num:N1} {text2}</style>");
		}

		private void RefreshAcceptButtonInteractable()
		{
			acceptButton.interactable = isMassCarriedOk;
			PrepareApplyButtonTooltip();
		}
	}
}
