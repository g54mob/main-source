using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI
{
	public class LootPlaceCaravanPanelView : CaravanPanelView
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

		[NonSerialized]
		private SortMode sortMode;

		[NonSerialized]
		private WorldMapPlace targetPlace;

		[NonSerialized]
		private Storage previousCaravanStorage;

		public void OpenPanel(CaravanInstance caravan, WorldMapPlace targetPlace)
		{
			if (!IsShowing())
			{
				if (caravan == null)
				{
					throw new Exception("Caravan cannot be null");
				}
				base.CaravanInstance = caravan;
				this.targetPlace = targetPlace;
				Show();
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			content.SetActive(value: true);
			maxWorkersCount = 0;
			using PooledList<HumanoidInstance> pooledList = targetPlace.LootableCreatures.WherePooledCast(delegate(HumanoidInstance npc)
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
			pooledList.Sort((HumanoidInstance workerA, HumanoidInstance workerB) => string.Compare(workerA.Info.GetFullName(), workerB.Info.GetFullName(), StringComparison.CurrentCulture));
			foreach (HumanoidInstance item in pooledList)
			{
				CaravanWorkerEntry at = humanoidEntries.GetAt(workersGroup, maxWorkersCount);
				maxWorkersCount++;
				at.gameObject.SetActive(value: true);
				at.SetData(item, OnPrisonerToggle);
			}
			humanoidEntries.SetActiveFromIndex(maxWorkersCount, active: false);
			maxAnimalsCount = 0;
			using PooledList<AnimalInstance> pooledList2 = targetPlace.LootableCreatures.WherePooledCast<CreatureBase, AnimalInstance>();
			foreach (AnimalInstance item2 in pooledList2)
			{
				if (IsAnimalAvailableForCaravanForming(item2))
				{
					animalEntries.GetAt(animalsGroup, maxAnimalsCount).SetData(item2, this);
					maxAnimalsCount++;
				}
			}
			animalEntries.SetActiveFromIndex(maxAnimalsCount, active: false);
			PooledDictionary<string, ResourceInstance> janitor = DictionaryPool<string, ResourceInstance>.GetJanitor();
			try
			{
				foreach (ResourceInstance item3 in base.CaravanInstance.Storage.GetResourcesWithoutLock())
				{
					janitor[item3.BlueprintId] = item3;
				}
				int num = 0;
				foreach (ResourceInstance resource in targetPlace.LootableStorage.Resources)
				{
					int additionalAmount = 0;
					if (janitor.TryGetValue(resource.BlueprintId, out var value))
					{
						additionalAmount = value.Amount;
						janitor.Remove(resource.BlueprintId);
					}
					CreateResourceEntryView(resource, additionalAmount, num);
					num++;
				}
				foreach (ResourceInstance value2 in janitor.Values)
				{
					CreateResourceEntryView(value2, 0, num).AmountInput.SetTradeValue(value2.Amount);
					num++;
				}
				previousCaravanStorage = base.CaravanInstance.Storage;
				base.CaravanInstance.InitCaravanStorage();
				itemEntries.SetActiveFromIndex(num, active: false);
				SortEntries();
				OnAmountChanged(0);
			}
			finally
			{
				((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private CaravanEntryLayoutItemView CreateResourceEntryView(ResourceInstance resourceInstance, int additionalAmount, int i)
		{
			CaravanEntryLayoutItemView at = itemEntries.GetAt(itemsGroup, i);
			int num = resourceInstance.Amount + additionalAmount;
			ResourceInstance resourceInstance2 = resourceInstance.Clone(num);
			at.SetData(resourceInstance2);
			resourceInstance2.Dispose();
			resourceInstance2 = null;
			at.AmountInput.SetTradeValue(num - resourceInstance.Amount);
			at.AmountInput.AmountChangedEvent -= OnAmountChanged;
			at.AmountInput.AmountChangedEvent += OnAmountChanged;
			return at;
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
				else if (!humanoidEntry.Humanoid.CanFormCaravan())
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
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LootPlaceCaravanPanelView.cs");
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
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LootPlaceCaravanPanelView.cs");
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
			if (previousCaravanStorage != null)
			{
				base.CaravanInstance.Storage = previousCaravanStorage;
			}
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
			acceptButton.onClick.AddListener(AcceptLoot);
			acceptButton.onNonInteractableClick.AddListener(CannotAcceptLoot);
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

		private void CannotAcceptLoot()
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

		private void AcceptLoot()
		{
			foreach (CaravanEntryLayoutItemView itemEntry in itemEntries)
			{
				targetPlace.LootableStorage.Consume(itemEntry.Resource, itemEntry.GetTradeValue());
			}
			foreach (CaravanAnimalEntry animalEntry in animalEntries)
			{
				if (base.CaravanInstance.Creatures.Contains(animalEntry.AnimalInstance))
				{
					targetPlace.LootableCreatures.Remove(animalEntry.AnimalInstance);
				}
			}
			foreach (CaravanWorkerEntry humanoidEntry in humanoidEntries)
			{
				if (base.CaravanInstance.Creatures.Contains(humanoidEntry.Humanoid))
				{
					targetPlace.LootableCreatures.Remove(humanoidEntry.Humanoid);
				}
			}
			previousCaravanStorage = null;
			base.CaravanInstance.InitCaravanStorage();
			if (targetPlace is WorldMapMarkerPlace marker && targetPlace.LootableCreatures.Count == 0 && targetPlace.LootableStorage.IsEmpty())
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LootPlaceCaravanPanelView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Marker '");
					messageBuilder.AppendFormatted(targetPlace);
					messageBuilder.AppendLiteral("' has been completely looted, destroying it");
				}
				Log.Info(messageBuilder);
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.MarkerManager.DestroyMarker(marker);
				targetPlace = null;
			}
			Hide();
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
					messageBuilder = new FVLogInfoInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LootPlaceCaravanPanelView.cs");
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
				messageBuilder = new FVLogInfoInterpolationHandler(9, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LootPlaceCaravanPanelView.cs");
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
			foreach (CaravanAnimalEntry animalEntry in animalEntries)
			{
				animalEntry.Reset();
			}
			Log.Info("Reset Caravan: clearing workers.", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Caravan\\LootPlaceCaravanPanelView.cs");
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
			int num = base.CaravanInstance.Workers.Sum((HumanoidInstance worker) => worker.Storage.StorageBase.Capacity);
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
