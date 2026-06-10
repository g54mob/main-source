using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using NSMedieval.WorldMap.Caravan;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorldMapSelectionPanelView : UIView
	{
		private class ButtonDeactivateHelper
		{
			private readonly HashSet<SoundButton> allButtons = new HashSet<SoundButton>();

			private readonly HashSet<SoundButton> buttonsToReset = new HashSet<SoundButton>();

			public void RegisterButton(SoundButton button)
			{
				allButtons.Add(button);
			}

			public void MarkButtonActive(SoundButton button)
			{
				buttonsToReset.Remove(button);
			}

			public void OnFinishedActivatingButtons()
			{
				foreach (SoundButton item in buttonsToReset)
				{
					item.DeactivateClearListeners();
				}
				buttonsToReset.Clear();
				buttonsToReset.AddRange(allButtons);
			}
		}

		[FormerlySerializedAs("villageNameText")]
		[SerializeField]
		private TMP_Text placeNameText;

		[SerializeField]
		private LayoutGroupView statLinesContainer;

		[SerializeField]
		private SoundButton sendCaravanButton;

		[SerializeField]
		private SoundButton caravanSendHomeButton;

		[SerializeField]
		private SoundButton caravanTradeButton;

		[SerializeField]
		private SoundButton caravanEnterMapButton;

		[SerializeField]
		private SoundButton caravanLootPlaceButton;

		[SerializeField]
		private SoundButton caravanEscapeAmbushButton;

		[SerializeField]
		private SoundButton caravanNegotiateAmbushButton;

		[SerializeField]
		private SoundButton caravanFightAmbushButton;

		[SerializeField]
		private GameObject villagePlaceActionButtons;

		[SerializeField]
		private GameObject caravanActionButtons;

		[NonSerialized]
		private WorldMapPlace selectedPlace;

		[NonSerialized]
		private CaravanInstance selectedCaravan;

		[NonSerialized]
		private readonly List<LayoutGroupItemView> infoLines = new List<LayoutGroupItemView>();

		[NonSerialized]
		private readonly ButtonDeactivateHelper buttonDeactivateHelper = new ButtonDeactivateHelper();

		public void Start()
		{
			MonoSingleton<WorldMapController>.Instance.PlaceClickedEvent += OnPlaceClicked;
			MonoSingleton<WorldMapController>.Instance.PlaceDeselectClickedEvent += OnVillagePlaceDeselectClicked;
			MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent += OnWorldMapVisibilitySet;
			MonoSingleton<WorldMapController>.Instance.CaravanClickedEvent += OnCaravanClicked;
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.MarkerManager.MarkerDestroyedEvent += OnMapMarkerDestroyed;
			CaravanController instance = MonoSingleton<CaravanController>.Instance;
			instance.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanCreated));
			CaravanController instance2 = MonoSingleton<CaravanController>.Instance;
			instance2.CaravanFormingStartedEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance2.CaravanFormingStartedEvent, new CaravanController.CaravanDelegate(OnCaravanFormingStarted));
			CaravanController instance3 = MonoSingleton<CaravanController>.Instance;
			instance3.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance3.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanReturnedHome));
			CaravanController instance4 = MonoSingleton<CaravanController>.Instance;
			instance4.CaravanStateChangedEvent = (CaravanController.CaravanStateChangedDelegate)Delegate.Combine(instance4.CaravanStateChangedEvent, new CaravanController.CaravanStateChangedDelegate(OnCaravanStateChanged));
			CaravanController instance5 = MonoSingleton<CaravanController>.Instance;
			instance5.CaravanConsumedFoodEvent = (CaravanController.ResourceWithAmountDelegate)Delegate.Combine(instance5.CaravanConsumedFoodEvent, new CaravanController.ResourceWithAmountDelegate(OnCaravanConsumedFood));
			CaravanController instance6 = MonoSingleton<CaravanController>.Instance;
			instance6.SelectedHumanoidInCaravanEvent = (WorkerController.HumanoidHandler)Delegate.Combine(instance6.SelectedHumanoidInCaravanEvent, new WorkerController.HumanoidHandler(OnSelectedWorkerInCaravan));
			CaravanController instance7 = MonoSingleton<CaravanController>.Instance;
			instance7.SelectedCaravanEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance7.SelectedCaravanEvent, new CaravanController.CaravanDelegate(OnSelectedCaravan));
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			MonoSingleton<TradingManager>.Instance.TradeAppliedEvent += OnTradeApplied;
			Hide();
			buttonDeactivateHelper.RegisterButton(sendCaravanButton);
			buttonDeactivateHelper.RegisterButton(caravanSendHomeButton);
			buttonDeactivateHelper.RegisterButton(caravanTradeButton);
			buttonDeactivateHelper.RegisterButton(caravanEnterMapButton);
			buttonDeactivateHelper.RegisterButton(caravanLootPlaceButton);
			buttonDeactivateHelper.RegisterButton(caravanEscapeAmbushButton);
			buttonDeactivateHelper.RegisterButton(caravanNegotiateAmbushButton);
			buttonDeactivateHelper.RegisterButton(caravanFightAmbushButton);
			buttonDeactivateHelper.OnFinishedActivatingButtons();
		}

		private void OnMapMarkerDestroyed(WorldMapMarkerPlace marker)
		{
			if (selectedPlace == marker)
			{
				OnVillagePlaceDeselectClicked();
			}
		}

		private void OnWorldMapVisibilitySet(bool isenabled)
		{
			if (isenabled)
			{
				Refresh();
			}
		}

		private void Refresh()
		{
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(delegate
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(statLinesContainer.transform as RectTransform);
			});
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.PlaceClickedEvent -= OnPlaceClicked;
				MonoSingleton<WorldMapController>.Instance.PlaceDeselectClickedEvent -= OnVillagePlaceDeselectClicked;
				MonoSingleton<WorldMapController>.Instance.CaravanClickedEvent -= OnCaravanClicked;
				MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent -= OnWorldMapVisibilitySet;
			}
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated())
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.MarkerManager.MarkerDestroyedEvent -= OnMapMarkerDestroyed;
			}
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				CaravanController instance = MonoSingleton<CaravanController>.Instance;
				instance.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanCreated));
				CaravanController instance2 = MonoSingleton<CaravanController>.Instance;
				instance2.CaravanFormingStartedEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance2.CaravanFormingStartedEvent, new CaravanController.CaravanDelegate(OnCaravanFormingStarted));
				CaravanController instance3 = MonoSingleton<CaravanController>.Instance;
				instance3.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance3.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanReturnedHome));
				CaravanController instance4 = MonoSingleton<CaravanController>.Instance;
				instance4.CaravanStateChangedEvent = (CaravanController.CaravanStateChangedDelegate)Delegate.Remove(instance4.CaravanStateChangedEvent, new CaravanController.CaravanStateChangedDelegate(OnCaravanStateChanged));
				CaravanController instance5 = MonoSingleton<CaravanController>.Instance;
				instance5.CaravanConsumedFoodEvent = (CaravanController.ResourceWithAmountDelegate)Delegate.Remove(instance5.CaravanConsumedFoodEvent, new CaravanController.ResourceWithAmountDelegate(OnCaravanConsumedFood));
				CaravanController instance6 = MonoSingleton<CaravanController>.Instance;
				instance6.SelectedHumanoidInCaravanEvent = (WorkerController.HumanoidHandler)Delegate.Remove(instance6.SelectedHumanoidInCaravanEvent, new WorkerController.HumanoidHandler(OnSelectedWorkerInCaravan));
				CaravanController instance7 = MonoSingleton<CaravanController>.Instance;
				instance7.SelectedCaravanEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance7.SelectedCaravanEvent, new CaravanController.CaravanDelegate(OnSelectedCaravan));
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
			}
			if (MonoSingleton<TradingManager>.IsInstantiated())
			{
				MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
			}
		}

		public override void Hide()
		{
			selectedCaravan = null;
			selectedPlace = null;
			MonoSingleton<WorldMapController>.Instance.SetHoveringOverUI(isHoveringOverUI: false);
			base.Hide();
		}

		public void OnPointerEnter()
		{
			MonoSingleton<WorldMapController>.Instance.SetHoveringOverUI(isHoveringOverUI: true);
		}

		public void OnPointerExit()
		{
			MonoSingleton<WorldMapController>.Instance.SetHoveringOverUI(isHoveringOverUI: false);
		}

		private void OnPlaceClicked(WorldMapPlace place)
		{
			selectedPlace = place;
			placeNameText.SetText(place.Name);
			Show();
			SetupUIForPlace();
		}

		private void SetupUIForPlace()
		{
			infoLines.SetAllActive(active: false);
			List<string> list = ListPool<string>.Get();
			selectedPlace.GenerateSelectionPanelText(list);
			foreach (string item in list)
			{
				AddLine(item);
			}
			ListPool<string>.Return(list);
			villagePlaceActionButtons.SetActive(value: true);
			caravanActionButtons.SetActive(value: false);
			if (selectedPlace.MarkerState != MapMarkerState.Disabled)
			{
				ActivateButton(sendCaravanButton, OnSendCaravanClicked);
				LocalizedTextTooltipView component = sendCaravanButton.GetComponent<LocalizedTextTooltipView>();
				bool flag = MonoSingleton<CaravanManager>.Instance.IsAnyCaravanGoingTo(selectedPlace);
				bool flag2 = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravansInPreparation.All((CaravanInstance caravan) => caravan.DestinationPlace != selectedPlace);
				component.TextKeys.Clear();
				sendCaravanButton.interactable = flag2 && !flag;
				if (sendCaravanButton.interactable)
				{
					component.TextKeys.Add("caravan_send_tooltip");
				}
				else
				{
					if (flag)
					{
						component.TextKeys.Add("caravan_is_already_going");
					}
					if (!flag2)
					{
						component.TextKeys.Add("caravan_is_already_forming");
					}
				}
			}
			buttonDeactivateHelper.OnFinishedActivatingButtons();
			Refresh();
		}

		private void OnSendCaravanClicked()
		{
			if (selectedPlace != null)
			{
				MonoSingleton<CaravanManager>.Instance.OpenFormCaravanPanel(selectedPlace);
			}
		}

		private void OnTradeClicked()
		{
			_ = selectedPlace is ITrader;
		}

		private void OnGiftClicked()
		{
			Log.Info("Clicked gift to " + selectedPlace.Name, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\WorldMapSelectionPanelView.cs");
		}

		private void OnCaravanClicked(CaravanInstance caravanInstance)
		{
			if (caravanInstance != null)
			{
				FillCaravanData(caravanInstance);
			}
		}

		private void FillCaravanData(CaravanInstance caravanInstance)
		{
			selectedPlace = null;
			selectedCaravan = caravanInstance;
			Show();
			placeNameText.SetText(caravanInstance.Name);
			infoLines.SetAllActive(active: false);
			string key = "caravan_status_" + caravanInstance.CaravanState.ToString().ToLower();
			if (caravanInstance.DestinationPlace != null)
			{
				AddLine(MonoSingleton<LocalizationController>.Instance.GetText("caravan_destination") + ": " + caravanInstance.DestinationPlace.Name);
			}
			AddLine(MonoSingleton<LocalizationController>.Instance.GetText("caravan_status") + ": " + MonoSingleton<LocalizationController>.Instance.GetText(key));
			if (caravanInstance.CaravanState == CaravanState.Arrived)
			{
				string timeFormatByMinutes = UiUtils.GetTimeFormatByMinutes(caravanInstance.MinutesToReturnHome(), isDuration: true);
				AddLine(MonoSingleton<LocalizationController>.Instance.GetText("caravan_return_home_in") + ":");
				AddLine(timeFormatByMinutes);
				AddLine(string.Empty);
			}
			if (caravanInstance.EventContext is AmbushContext { Faction: var faction } ambushContext)
			{
				if (faction != null)
				{
					AddLine(faction.NameLocalized);
					AddLine(WorldMapUtils.GetFriendlinessText(faction));
					if (faction.GetFriendliness() == FactionFriendliness.Hostile)
					{
						string lineContent = MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_hostile").Replace("<faction_name>", faction.NameLocalized);
						AddLine(lineContent);
					}
				}
				string enemyCountInfoLocalized = ambushContext.EnemyCountInfoLocalized;
				AddLine(enemyCountInfoLocalized);
				AddLine(string.Empty);
				string timeFormatByMinutes2 = UiUtils.GetTimeFormatByMinutes(ambushContext.MinutesToAutoSurrenderAmbush(), isDuration: true);
				AddLine(MonoSingleton<LocalizationController>.Instance.GetText("caravan_ambush_auto_surrender_in") + ": " + timeFormatByMinutes2);
				AddLine(string.Empty);
			}
			if (caravanInstance.CaravanState == CaravanState.Arrived)
			{
				WorldMapPlace destinationPlace = caravanInstance.DestinationPlace;
				if (destinationPlace.MarkerState == MapMarkerState.Enterable)
				{
					FactionInstance factionInstance = destinationPlace.FactionInstance;
					if (factionInstance != null)
					{
						AddLine(factionInstance.NameLocalized);
						AddLine(WorldMapUtils.GetFriendlinessText(factionInstance));
						if (factionInstance.GetFriendliness() == FactionFriendliness.Hostile)
						{
							string lineContent2 = MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_hostile").Replace("<faction_name>", factionInstance.NameLocalized);
							AddLine(lineContent2);
						}
					}
					string preciseEnemyCountInfoLocalized = destinationPlace.PreciseEnemyCountInfoLocalized;
					AddLine(preciseEnemyCountInfoLocalized);
					AddLine(string.Empty);
				}
			}
			AddLine(MonoSingleton<LocalizationController>.Instance.GetText("caravan_workers") + ":");
			foreach (HumanoidInstance worker in selectedCaravan.Workers)
			{
				AddLine(worker.Info.GetFullName());
			}
			AddLine(string.Empty);
			if (selectedCaravan.Creatures != null && selectedCaravan.Creatures.Any())
			{
				foreach (CreatureBase creature in selectedCaravan.Creatures)
				{
					if (creature is AnimalInstance animalInstance)
					{
						AddLine(AnimalUtils.GetTradeName(animalInstance));
					}
					else if (creature is HumanoidInstance human)
					{
						AddLine(HumanoidUtils.GetTradeName(human));
					}
				}
				AddLine(string.Empty);
			}
			Storage storage = selectedCaravan.Storage;
			if (storage.ResourceCount > 0)
			{
				AddLine("caravan_contents".ToLocalized());
				List<string> list = ListPool<string>.Get();
				storage.WriteContentsListing(list);
				foreach (string item in list)
				{
					AddLine(item);
				}
				ListPool<string>.Return(list);
				AddLine(string.Empty);
			}
			SetupUIForCaravan();
		}

		private void ActivateButton(SoundButton button, UnityAction onClick, string tooltipKey = null, bool interactable = true)
		{
			buttonDeactivateHelper.MarkButtonActive(button);
			button.Activate(onClick, tooltipKey, interactable);
		}

		private void SetupUIForCaravan()
		{
			villagePlaceActionButtons.SetActive(value: false);
			caravanActionButtons.SetActive(value: true);
			if (selectedCaravan.EventContext is AmbushContext)
			{
				SetupUICaravanAmbushed();
			}
			else
			{
				switch (selectedCaravan.CaravanState)
				{
				case CaravanState.Travelling:
					SetupUICaravanTravelling();
					break;
				case CaravanState.Arrived:
					SetupUICaravanArrived();
					break;
				}
			}
			buttonDeactivateHelper.OnFinishedActivatingButtons();
			Refresh();
		}

		private void SetupUICaravanArrived()
		{
			ActivateButton(caravanSendHomeButton, CaravanSendHomeClicked, "caravan_send_home_tooltip");
			if (selectedCaravan.DestinationPlace.HasTradeDeal)
			{
				ActivateButton(caravanTradeButton, CaravanTradeDealClicked);
				return;
			}
			WorldMapPlace destinationPlace = selectedCaravan.DestinationPlace;
			bool interactable = destinationPlace is ITrader && !destinationPlace.FactionInstance.IsHostile();
			ActivateButton(caravanTradeButton, CaravanTradeClicked, null, interactable);
			if (destinationPlace.MarkerState == MapMarkerState.Enterable)
			{
				bool interactable2 = destinationPlace.FactionInstance?.IsHostile() ?? (destinationPlace.MapId != null);
				ActivateButton(caravanEnterMapButton, CaravanEnterMapClicked, "enter_map_tooltip", interactable2);
			}
			if (destinationPlace.MarkerState == MapMarkerState.Lootable)
			{
				bool flag = !destinationPlace.HasLoot();
				string tooltipKey = (flag ? "loot_place_empty_tooltip" : "loot_place_tooltip");
				ActivateButton(caravanLootPlaceButton, LootPlaceClicked, tooltipKey, !flag);
			}
		}

		private void CaravanTradeDealClicked()
		{
			if (selectedCaravan != null && selectedCaravan.DestinationPlace != null)
			{
				selectedCaravan.ShowTradeDealDialog();
			}
		}

		private void SetupUICaravanAmbushed()
		{
			ActivateButton(caravanEscapeAmbushButton, EscapeAmbushClicked, "ambush_escape_tooltip");
			ActivateButton(caravanNegotiateAmbushButton, NegotiateAmbushClicked, "ambush_negotiate_tooltip");
			ActivateButton(caravanFightAmbushButton, FightAmbushClicked, "ambush_fight_tooltip");
		}

		private void EscapeAmbushClicked()
		{
			((AmbushContext)selectedCaravan.EventContext).Resolve(AmbushContext.AmbushResolutionType.DefeatEscape);
		}

		private void NegotiateAmbushClicked()
		{
			((AmbushContext)selectedCaravan.EventContext).OpenNegotiationPanel(selectedCaravan);
		}

		private void FightAmbushClicked()
		{
			WorldMapMarkerPlace mapPlace = ((AmbushContext)selectedCaravan.EventContext).MapPlaceReference.Value as WorldMapMarkerPlace;
			MonoSingleton<TravelManager>.Instance.LoadVillage(selectedCaravan, mapPlace, "game_event_ambush");
		}

		private void SetupUICaravanTravelling()
		{
			ActivateButton(caravanSendHomeButton, CaravanSendHomeClicked, "caravan_send_home_tooltip");
			WorldMapPlace destinationPlace = selectedCaravan.DestinationPlace;
			if (destinationPlace.MarkerState != MapMarkerState.Lootable)
			{
				ActivateButton(caravanTradeButton, null, null, interactable: false);
			}
			if (destinationPlace.MarkerState == MapMarkerState.Enterable)
			{
				ActivateButton(caravanEnterMapButton, null, "enter_map_tooltip", interactable: false);
			}
			if (destinationPlace is WorldMapMarkerPlace worldMapMarkerPlace && destinationPlace.MarkerState == MapMarkerState.Lootable)
			{
				string tooltipKey = ((worldMapMarkerPlace.LootableStorage.IsEmpty() && worldMapMarkerPlace.LootableCreatures.Count == 0) ? "loot_place_empty_tooltip" : "loot_place_tooltip");
				ActivateButton(caravanLootPlaceButton, null, tooltipKey, interactable: false);
			}
		}

		private void LootPlaceClicked()
		{
			if (selectedCaravan != null)
			{
				MonoSingleton<CaravanManager>.Instance.OpenLootPlacePanel(selectedCaravan);
			}
		}

		private void CaravanSendHomeClicked()
		{
			if (selectedCaravan != null)
			{
				selectedCaravan.StartTripHome();
			}
		}

		private void CaravanTradeClicked()
		{
			if (selectedCaravan?.DestinationPlace is ITrader otherTrader)
			{
				MonoSingleton<TradingManager>.Instance.OpenTradingMenu(selectedCaravan, otherTrader);
			}
		}

		private void CaravanEnterMapClicked()
		{
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.MarkerManager.TryForceTick();
			if (selectedCaravan?.DestinationPlace?.MapId != null && selectedCaravan.CaravanState != CaravanState.Returning)
			{
				WorldMapPlace destinationPlace = selectedCaravan.DestinationPlace;
				string startEvent = null;
				switch (destinationPlace.SecondMapType)
				{
				case SecondMapType.Attack:
					startEvent = "game_event_attack_camp";
					selectedCaravan.SetEventContext(AttackBanditCampContext.StartNew(selectedCaravan));
					break;
				case SecondMapType.Settlement:
					startEvent = "game_event_attack_camp";
					selectedCaravan.SetEventContext(AttackSettlementContext.StartNew(selectedCaravan));
					break;
				case SecondMapType.LootStash:
					selectedCaravan.SetEventContext(LootStashContext.StartNew(selectedCaravan));
					break;
				}
				MonoSingleton<TravelManager>.Instance.LoadVillage(selectedCaravan, destinationPlace, startEvent);
			}
		}

		private void OnCaravanStateChanged(CaravanInstance caravanInstance, CaravanState caravanState)
		{
			if (selectedCaravan != null && selectedCaravan == caravanInstance && selectedPlace == null)
			{
				FillCaravanData(caravanInstance);
			}
		}

		private void OnSelectedWorkerInCaravan(HumanoidInstance humanoid)
		{
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				if (caravan.Workers.Contains(humanoid))
				{
					MonoSingleton<UIController>.Instance.CloseAllPanels();
					MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetWorldMapVisible(isWorldMapVisible: true);
					MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
					{
						FillCaravanData(caravan);
					});
					break;
				}
			}
		}

		private void OnSelectedCaravan(CaravanInstance caravanInstance)
		{
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					FillCaravanData(caravanInstance);
				});
				return;
			}
			MonoSingleton<UIController>.Instance.CloseAllPanels();
			MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetWorldMapVisible(isWorldMapVisible: true);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				FillCaravanData(caravanInstance);
			});
		}

		private void OnCaravanConsumedFood(CaravanInstance caravanInstance, Resource resource, int amount)
		{
			if (selectedCaravan != null && selectedCaravan == caravanInstance && selectedPlace == null)
			{
				FillCaravanData(caravanInstance);
			}
		}

		private void OnCaravanReturnedHome(CaravanInstance caravanInstance)
		{
			if (selectedPlace == null && selectedCaravan != null)
			{
				selectedCaravan = null;
				Hide();
			}
		}

		private void OnCaravanCreated(CaravanInstance caravanInstance)
		{
			if (selectedCaravan == null)
			{
				FillCaravanData(caravanInstance);
			}
		}

		private void OnCaravanFormingStarted(CaravanInstance caravanInstance)
		{
			if (selectedPlace != null)
			{
				SetupUIForPlace();
			}
		}

		private void OnVillagePlaceDeselectClicked()
		{
			selectedPlace = null;
			selectedCaravan = null;
			Hide();
		}

		private void AddLine(string lineContent)
		{
			LayoutGroupItemView next = infoLines.GetNext(statLinesContainer);
			next.gameObject.SetActive(value: true);
			next.SetText(lineContent);
		}

		private void OnTimeUpdate()
		{
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated() && MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				if (selectedCaravan != null && selectedPlace == null)
				{
					FillCaravanData(selectedCaravan);
				}
				if (selectedCaravan == null && selectedPlace != null)
				{
					SetupUIForPlace();
				}
			}
		}

		private void OnTradeApplied(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly)
		{
			if (selectedCaravan != null && MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible && playerTrader is CaravanInstance caravanInstance && selectedCaravan == caravanInstance)
			{
				FillCaravanData(selectedCaravan);
			}
		}
	}
}
