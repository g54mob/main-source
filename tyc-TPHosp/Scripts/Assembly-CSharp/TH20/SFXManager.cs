using System;
using System.Collections.Generic;
using TH20.EventStaffHired;
using UnityEngine;

namespace TH20
{
	public class SFXManager : MustCallDestroy, Interface, IGameEventCallback
	{
		private const string BlueprintBuildRoom_AudioEvent = "BlueprintBuildRoom";

		private const string RoomBuildingModeEnter_AudioEvent = "RoomBuildingModeEnter";

		private const string RoomBuildingModeExit_AudioEvent = "RoomBuildingModeExit";

		private const string DataView_On_AudioEvent = "HeatMapOn:UI";

		private const string DataView_Off_AudioEvent = "HeatMapOff:UI";

		private const string PlaceObject_Small_AudioEvent = "PlaceObject:Small";

		private const string PlaceObject_Medium_AudioEvent = "PlaceObject:Medium";

		private const string PlaceObject_Large_AudioEvent = "PlaceObject:Large";

		private const string PlaceObjectDenied_AudioEvent = "PlaceObjectDenied";

		private const string MoneySpend_Small_AudioEvent = "MoneySpend:Small";

		private const string MoneySpend_Medium_AudioEvent = "MoneySpend:Medium";

		private const string MoneySpend_Large_AudioEvent = "MoneySpend:Large";

		private const string StaffPaid_AudioEvent = "StaffPaid";

		private const string ReceivePayment_Small_AudioEvent = "ReceivePayment:Small";

		private const string ReceivePayment_Medium_AudioEvent = "ReceivePayment:Medium";

		private const string ReceivePayment_Large_AudioEvent = "ReceivePayment:Large";

		private const string PickUpObject_AudioEvent = "PickUpObject";

		private const string DiscardObject_AudioEvent = "DiscardObject";

		private const string DropCharacter_Female_AudioEvent = "DropCharacter:Female";

		private const string DropCharacter_Male_AudioEvent = "DropCharacter:Male";

		private const string PickUpCharacter_Female_AudioEvent = "PickUpCharacter:Female";

		private const string PickUpCharacter_Male_AudioEvent = "PickUpCharacter:Male";

		private const string FireStaff_AudioEvent = "FireStaff";

		private const string BuyHospitalPlot_AudioEvent = "BuyHospitalPlot";

		private const string BuyHospitalEnergyPlot_AudioEvent = "HospitalLightsOn";

		private const string Notification_CompleteObjective_AudioEvent = "Notification:CompleteObjective";

		private const string Notification_FailedObjective_AudioEvent = "DeleteSave:UI";

		private const string Notification_CompleteSubObjective_AudioEvent = "Notification:CompleteSubObjective";

		private const string Notification_ReceiveMessage_AudioEvent = "Notification:ReceiveMessage";

		private const string PatientCured_AudioEvent = "PatientCured";

		private const string IneffectiveTreatment_AudioEvent = "IneffectiveTreatment";

		private const string FatalTreatment_AudioEvent = "FatalTreatment";

		private const string Click_CloseSubButton_AudioEvent = "Click:CloseSubButton";

		private const string Click_SelectSubMenuItem_AudioEvent = "Click:SelectSubMenuItem";

		private const string OpenMessage_AudioEvent = "OpenMessage";

		private const string CloseMessage_AudioEvent = "CloseMessage";

		private const string OpenMessageTab_AudioEvent = "OpenMessageTab";

		private const string SlowDownTime1_AudioEvent = "SlowDownTime1";

		private const string SlowDownTime2_AudioEvent = "SlowDownTime2";

		private const string SlowDownTime3_AudioEvent = "SlowDownTime3";

		private const string SlowDownTime4_AudioEvent = "SlowDownTime4";

		private const string SpeedUpTime1_AudioEvent = "SpeedUpTime1";

		private const string SpeedUpTime2_AudioEvent = "SpeedUpTime2";

		private const string SpeedUpTime3_AudioEvent = "SpeedUpTime3";

		private const string SpeedUpTime4_AudioEvent = "SpeedUpTime4";

		private const string BlueprintRoomStartDrag_AudioEvent = "BlueprintRoomStartDrag";

		private const string BlueprintRoomEndDrag_AudioEvent = "BlueprintRoomEndDrag";

		private const string MachineExplosion_AudioEvent = "MachineExplosions";

		private const string MonoShot_AudioEvent = "MonoShot";

		private const string OpenSatNav_AudioEvent = "SatNav:OpenSatNav";

		private const string AlertSatNav_AudioEvent = "SatNav:Alert";

		private const string OpenSatNavSubMenu_AudioEvent = "SatNav:OpenSubMenu";

		private const string SetPathSatNav_AudioEvent = "SatNav:SetPath";

		private const string CloseSatNavSubMenu_AudioEvent = "SatNav:CloseSubMenu";

		private readonly Level _level;

		private readonly SFXManagerConfig _config;

		public SFXManager(Level level, SFXManagerConfig config)
		{
			_level = level;
			_config = config;
			Level level2 = _level;
			level2.PostConstruct = (System.Action)Delegate.Combine(level2.PostConstruct, (System.Action)delegate
			{
				SubscriveEvents();
				_level.CharacterEvents.OnStaffHired.Add(this);
			});
			GameTime.OnIncreaseTimeScale = (Action<int>)Delegate.Combine(GameTime.OnIncreaseTimeScale, new Action<int>(OnIncreaseTimeScale));
			GameTime.OnDecreaseTimeScale = (Action<int>)Delegate.Combine(GameTime.OnDecreaseTimeScale, new Action<int>(OnDecreaseTimeScale));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			GameTime.OnIncreaseTimeScale = (Action<int>)Delegate.Combine(GameTime.OnIncreaseTimeScale, new Action<int>(OnIncreaseTimeScale));
			GameTime.OnDecreaseTimeScale = (Action<int>)Delegate.Combine(GameTime.OnDecreaseTimeScale, new Action<int>(OnDecreaseTimeScale));
			SubscriveEvents();
		}

		private void SubscriveEvents()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnAcceptRoom = (System.Action)Delegate.Combine(buildEvents2.OnAcceptRoom, new System.Action(OnAcceptRoom));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnCancelRoom = (System.Action)Delegate.Combine(buildEvents3.OnCancelRoom, new System.Action(OnCancelRoom));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents4.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemPlaced));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnRoomItemPlacementDenied = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents5.OnRoomItemPlacementDenied, new Action<RoomItem, FloorPlan>(OnRoomItemPlacementDenied));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnBeginItemEdit = (Action<RoomItem, Room>)Delegate.Combine(buildEvents6.OnBeginItemEdit, new Action<RoomItem, Room>(OnBeginItemEdit));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnBeginItemEditBuildMode = (Action<RoomItem>)Delegate.Combine(buildEvents7.OnBeginItemEditBuildMode, new Action<RoomItem>(OnBeginItemEditBuildMode));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnRoomItemCancel = (Action<RoomItem, bool>)Delegate.Combine(buildEvents8.OnRoomItemCancel, new Action<RoomItem, bool>(OnRoomItemCancel));
			BuildEvents buildEvents9 = _level.BuildEvents;
			buildEvents9.OnMoveRoomStart = (System.Action)Delegate.Combine(buildEvents9.OnMoveRoomStart, new System.Action(OnMoveRoomStart));
			BuildEvents buildEvents10 = _level.BuildEvents;
			buildEvents10.OnMoveRoomEnd = (Action<bool, Vector3>)Delegate.Combine(buildEvents10.OnMoveRoomEnd, new Action<bool, Vector3>(OnMoveRoomEnd));
			BuildEvents buildEvents11 = _level.BuildEvents;
			buildEvents11.OnRoomItemPurchased = (Action<RoomItem>)Delegate.Combine(buildEvents11.OnRoomItemPurchased, new Action<RoomItem>(OnRoomItemPurchased));
			BuildEvents buildEvents12 = _level.BuildEvents;
			buildEvents12.OnRoomItemSold = (Action<RoomItem>)Delegate.Combine(buildEvents12.OnRoomItemSold, new Action<RoomItem>(OnRoomItemPurchased));
			BuildEvents buildEvents13 = _level.BuildEvents;
			buildEvents13.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents13.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			BuildEvents buildEvents14 = _level.BuildEvents;
			buildEvents14.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents14.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
			BuildEvents buildEvents15 = _level.BuildEvents;
			buildEvents15.OnRoomItemRequestUpgrade = (Action<RoomItem>)Delegate.Combine(buildEvents15.OnRoomItemRequestUpgrade, new Action<RoomItem>(OnRoomItemRequestUpgrade));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnRoomPurchased = (Action<Room, int>)Delegate.Combine(financeManager.OnRoomPurchased, new Action<Room, int>(OnRoomPurchased));
			FinanceManager financeManager2 = _level.FinanceManager;
			financeManager2.OnRoomSold = (Action<Room, int>)Delegate.Combine(financeManager2.OnRoomSold, new Action<Room, int>(OnRoomPurchased));
			FinanceManager financeManager3 = _level.FinanceManager;
			financeManager3.OnMonthlyWagesPaid = (Action<int>)Delegate.Combine(financeManager3.OnMonthlyWagesPaid, new Action<int>(OnStaffPaid));
			FinanceManager financeManager4 = _level.FinanceManager;
			financeManager4.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Combine(financeManager4.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarned));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Combine(characterEvents.OnStaffPickup, new Action<Staff, JobApplicant>(OnStaffPickup));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnRequestStaffDrop = (Action<Staff, Room>)Delegate.Combine(characterEvents2.OnRequestStaffDrop, new Action<Staff, Room>(OnRequestStaffDrop));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents3.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents4.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents5.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents6 = _level.CharacterEvents;
			characterEvents6.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents6.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents7 = _level.CharacterEvents;
			characterEvents7.OnStaffCancelPickup = (Action<bool>)Delegate.Combine(characterEvents7.OnStaffCancelPickup, new Action<bool>(OnStaffCancelPickup));
			ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			ObjectiveEvents objectiveEvents2 = _level.ObjectiveEvents;
			objectiveEvents2.OnSubGoalCompleted = (Action<ObjectiveSubGoal>)Delegate.Combine(objectiveEvents2.OnSubGoalCompleted, new Action<ObjectiveSubGoal>(OnSubGoalCompleted));
			Notifications notifications = _level.Notifications;
			notifications.OnNotificationSent = (Action<NotificationMessage>)Delegate.Combine(notifications.OnNotificationSent, new Action<NotificationMessage>(OnNotificationSent));
			Notifications notifications2 = _level.Notifications;
			notifications2.OnMessageOpen = (Action<NotificationMessage>)Delegate.Combine(notifications2.OnMessageOpen, new Action<NotificationMessage>(OnNotificationOpen));
			Notifications notifications3 = _level.Notifications;
			notifications3.OnMessageClose = (Action<NotificationMessage, bool>)Delegate.Combine(notifications3.OnMessageClose, new Action<NotificationMessage, bool>(OnNotificationClose));
			DataViewManager dataViewManager = _level.DataViewManager;
			dataViewManager.OnEnterMode = (Action<DataViewManager.Mode>)Delegate.Combine(dataViewManager.OnEnterMode, new Action<DataViewManager.Mode>(OnEnterMode));
			DataViewManager dataViewManager2 = _level.DataViewManager;
			dataViewManager2.OnOverlayDisabled = (System.Action)Delegate.Combine(dataViewManager2.OnOverlayDisabled, new System.Action(OnOverlayDisabled));
			MonoBeastManager monoBeastManager = _level.MonoBeastManager;
			monoBeastManager.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Combine(monoBeastManager.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
			ChallengeManager challengeManager = _level.ChallengeManager;
			challengeManager.OnOpenSatNav = (Action<bool>)Delegate.Combine(challengeManager.OnOpenSatNav, new Action<bool>(OnOpenSatNav));
			ChallengeManager challengeManager2 = _level.ChallengeManager;
			challengeManager2.OnAlertSatNav = (Action<bool>)Delegate.Combine(challengeManager2.OnAlertSatNav, new Action<bool>(OnAlertSatNav));
			ChallengeManager challengeManager3 = _level.ChallengeManager;
			challengeManager3.OnOpenSatNavSubMenu = (Action<bool>)Delegate.Combine(challengeManager3.OnOpenSatNavSubMenu, new Action<bool>(OnOpenSatNavSubMenu));
			ChallengeManager challengeManager4 = _level.ChallengeManager;
			challengeManager4.OnSetPathSatNav = (Action<bool>)Delegate.Combine(challengeManager4.OnSetPathSatNav, new Action<bool>(OnSetPathSatNav));
			ChallengeManager challengeManager5 = _level.ChallengeManager;
			challengeManager5.OnCloseSatNavSubMenu = (Action<bool>)Delegate.Combine(challengeManager5.OnCloseSatNavSubMenu, new Action<bool>(OnCloseSatNavSubMenu));
		}

		private void OnMonoBeastShot(MonoBeast beast, int killStreak)
		{
			AudioManager.Instance.Play("MonoShot");
		}

		private void OnEnterMode(DataViewManager.Mode obj)
		{
			AudioManager.Instance.Play("HeatMapOn:UI");
		}

		private void OnOverlayDisabled()
		{
			AudioManager.Instance.Play("HeatMapOff:UI");
		}

		private void OnAcceptRoom()
		{
			AudioManager.Instance.Play("BlueprintBuildRoom");
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual visual)
		{
			AudioManager.Instance.Play("RoomBuildingModeEnter");
		}

		private void OnCancelRoom()
		{
			AudioManager.Instance.Play("RoomBuildingModeExit");
		}

		private void OnRoomItemPlacementDenied(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.Definition.PlayPlacmentSFX)
			{
				AudioManager.Instance.Play("PlaceObjectDenied");
			}
		}

		private void OnRoomItemPlaced(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.Definition.PlayPlacmentSFX)
			{
				string audioEventName = roomItem.Definition.ItemSize switch
				{
					RoomItemDefinition.Size.Small => "PlaceObject:Small", 
					RoomItemDefinition.Size.Medium => "PlaceObject:Medium", 
					RoomItemDefinition.Size.Large => "PlaceObject:Large", 
					_ => throw new ArgumentOutOfRangeException(), 
				};
				AudioManager.Instance.Play(audioEventName);
			}
		}

		private void OnRoomItemExploded(RoomItem roomItem, RoomItemFlammableComponent flammableComponent)
		{
			AudioManager.Instance.Play("MachineExplosions", roomItem.Visual.GameObject);
		}

		private void OnRoomItemRequestUpgrade(RoomItem item)
		{
			OnRoomItemPurchased(item);
		}

		private void OnBeginItemEdit(RoomItem roomItem, Room room)
		{
			AudioManager.Instance.Play("PickUpObject");
		}

		private void OnBeginItemEditBuildMode(RoomItem roomItem)
		{
			AudioManager.Instance.Play("PickUpObject");
		}

		private void OnRoomItemCancel(RoomItem roomItem, bool requestedByUser)
		{
			if (requestedByUser)
			{
				AudioManager.Instance.Play("DiscardObject");
			}
		}

		private void OnMoveRoomStart()
		{
			AudioManager.Instance.Play("BlueprintRoomStartDrag");
		}

		private void OnMoveRoomEnd(bool deleted, Vector3 cellOffset)
		{
			AudioManager.Instance.Play("BlueprintRoomEndDrag");
		}

		private void OnRoomItemPurchased(RoomItem roomItem)
		{
			string audioEventName = roomItem.Definition.ItemSize switch
			{
				RoomItemDefinition.Size.Small => "MoneySpend:Small", 
				RoomItemDefinition.Size.Medium => "MoneySpend:Medium", 
				RoomItemDefinition.Size.Large => "MoneySpend:Large", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			AudioManager.Instance.Play(audioEventName);
		}

		private void OnHospitalPlotBought(HospitalPlot plot)
		{
			if (plot.Definition.UseEnergyUI)
			{
				AudioManager.Instance.Play("HospitalLightsOn");
			}
			else
			{
				AudioManager.Instance.Play("BuyHospitalPlot");
			}
		}

		private void OnRoomPurchased(Room room, int cost)
		{
			AudioManager.Instance.Play("MoneySpend:Large");
		}

		private void OnStaffPaid(int wages)
		{
			AudioManager.Instance.Play("StaffPaid");
		}

		private void OnMoneyEarned(int amount, Vector3? inWorldPosition)
		{
			if (!inWorldPosition.HasValue || GeometryUtility.TestPlanesAABB(_level.CameraLogic.FrustumPlanes, new Bounds(inWorldPosition.Value, Vector3.one)))
			{
				if (amount >= _config.MinLargePaymentAmount)
				{
					AudioManager.Instance.Play("ReceivePayment:Large");
				}
				else if (amount >= _config.MinMediumPaymentAmount)
				{
					AudioManager.Instance.Play("ReceivePayment:Medium");
				}
				else if (amount >= _config.MinSmallPaymentAmount)
				{
					AudioManager.Instance.Play("ReceivePayment:Small");
				}
			}
		}

		private void OnStaffPickup(Staff staff, JobApplicant applicant)
		{
			if (staff.Gender == Character.Sex.Male)
			{
				AudioManager.Instance.Play("PickUpCharacter:Male");
			}
			else if (staff.Gender == Character.Sex.Female)
			{
				AudioManager.Instance.Play("PickUpCharacter:Female");
			}
		}

		private void OnRequestStaffDrop(Staff staff, Room room)
		{
			if (staff.Gender == Character.Sex.Male)
			{
				AudioManager.Instance.Play("DropCharacter:Male");
			}
			else if (staff.Gender == Character.Sex.Female)
			{
				AudioManager.Instance.Play("DropCharacter:Female");
			}
		}

		private void OnObjectiveCompleted(Objective Objective, Objective.CompletionType completionType)
		{
			switch (completionType)
			{
			case Objective.CompletionType.Incomplete:
			case Objective.CompletionType.Abandoned:
			case Objective.CompletionType.Failed:
				AudioManager.Instance.Play("DeleteSave:UI");
				break;
			case Objective.CompletionType.Successful:
				AudioManager.Instance.Play("Notification:CompleteObjective");
				break;
			default:
				throw new ArgumentOutOfRangeException("completionType", completionType, null);
			case Objective.CompletionType.Invalid:
				break;
			}
		}

		private void OnSubGoalCompleted(ObjectiveSubGoal ObjectiveSubGoal)
		{
			AudioManager.Instance.Play("Notification:CompleteSubObjective");
		}

		private void OnNotificationSent(NotificationMessage message)
		{
			AudioManager.Instance.Play("Notification:ReceiveMessage");
		}

		private void OnPatientCured(Patient patient, List<Staff> involvedStaff)
		{
			AudioManager.Instance.Play("PatientCured");
		}

		private void OnIneffectiveTreatment(Patient patient, List<Staff> involvedStaff)
		{
			AudioManager.Instance.Play("IneffectiveTreatment");
		}

		private void OnFatalTreatment(Patient patient, List<Staff> involvedStaff)
		{
			AudioManager.Instance.Play("FatalTreatment");
		}

		private void OnStaffFired(Staff staff)
		{
			AudioManager.Instance.Play("FireStaff");
		}

		private void OnStaffCancelPickup(bool requestedByUser)
		{
			if (requestedByUser)
			{
				AudioManager.Instance.Play("DiscardObject");
			}
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			AudioManager.Instance.Play("MoneySpend:Large");
		}

		private void OnNotificationOpen(NotificationMessage message)
		{
			AudioManager.Instance.Play("OpenMessage");
		}

		private void OnNotificationClose(NotificationMessage message, bool isMessageQueuedToOpen)
		{
			if (!isMessageQueuedToOpen)
			{
				AudioManager.Instance.Play("CloseMessage");
			}
		}

		private void OnShowNotificationsList()
		{
			AudioManager.Instance.Play("OpenMessageTab");
		}

		private void OnHideNotificationsList()
		{
			AudioManager.Instance.Play("OpenMessageTab");
		}

		private void OnIncreaseTimeScale(int timeScaleIndex)
		{
			switch (timeScaleIndex)
			{
			case 1:
				AudioManager.Instance.Play("SpeedUpTime1");
				break;
			case 2:
				AudioManager.Instance.Play("SpeedUpTime2");
				break;
			case 3:
				AudioManager.Instance.Play("SpeedUpTime3");
				break;
			case 4:
				AudioManager.Instance.Play("SpeedUpTime4");
				break;
			default:
				AudioManager.Instance.Play("SpeedUpTime4");
				break;
			}
		}

		private void OnDecreaseTimeScale(int timeScaleIndex)
		{
			switch (timeScaleIndex)
			{
			case 0:
				AudioManager.Instance.Play("SlowDownTime4");
				break;
			case 1:
				AudioManager.Instance.Play("SlowDownTime3");
				break;
			case 2:
				AudioManager.Instance.Play("SlowDownTime2");
				break;
			case 3:
				AudioManager.Instance.Play("SlowDownTime1");
				break;
			default:
				AudioManager.Instance.Play("SlowDownTime1");
				break;
			}
		}

		private void OnOpenSatNav(bool active)
		{
			AudioManager.Instance.Play("SatNav:OpenSatNav");
		}

		private void OnAlertSatNav(bool active)
		{
			AudioManager.Instance.Play("SatNav:Alert");
		}

		private void OnOpenSatNavSubMenu(bool active)
		{
			AudioManager.Instance.Play("SatNav:OpenSubMenu");
		}

		private void OnSetPathSatNav(bool active)
		{
			AudioManager.Instance.Play("SatNav:SetPath");
		}

		private void OnCloseSatNavSubMenu(bool active)
		{
			AudioManager.Instance.Play("SatNav:CloseSubMenu");
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnAcceptRoom = (System.Action)Delegate.Remove(buildEvents2.OnAcceptRoom, new System.Action(OnAcceptRoom));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnCancelRoom = (System.Action)Delegate.Remove(buildEvents3.OnCancelRoom, new System.Action(OnCancelRoom));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemPlaced = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents4.OnRoomItemPlaced, new Action<RoomItem, FloorPlan>(OnRoomItemPlaced));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnRoomItemPlacementDenied = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents5.OnRoomItemPlacementDenied, new Action<RoomItem, FloorPlan>(OnRoomItemPlacementDenied));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnBeginItemEdit = (Action<RoomItem, Room>)Delegate.Remove(buildEvents6.OnBeginItemEdit, new Action<RoomItem, Room>(OnBeginItemEdit));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnBeginItemEditBuildMode = (Action<RoomItem>)Delegate.Remove(buildEvents7.OnBeginItemEditBuildMode, new Action<RoomItem>(OnBeginItemEditBuildMode));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnRoomItemCancel = (Action<RoomItem, bool>)Delegate.Remove(buildEvents8.OnRoomItemCancel, new Action<RoomItem, bool>(OnRoomItemCancel));
			BuildEvents buildEvents9 = _level.BuildEvents;
			buildEvents9.OnMoveRoomStart = (System.Action)Delegate.Remove(buildEvents9.OnMoveRoomStart, new System.Action(OnMoveRoomStart));
			BuildEvents buildEvents10 = _level.BuildEvents;
			buildEvents10.OnMoveRoomEnd = (Action<bool, Vector3>)Delegate.Remove(buildEvents10.OnMoveRoomEnd, new Action<bool, Vector3>(OnMoveRoomEnd));
			BuildEvents buildEvents11 = _level.BuildEvents;
			buildEvents11.OnRoomItemPurchased = (Action<RoomItem>)Delegate.Remove(buildEvents11.OnRoomItemPurchased, new Action<RoomItem>(OnRoomItemPurchased));
			BuildEvents buildEvents12 = _level.BuildEvents;
			buildEvents12.OnRoomItemSold = (Action<RoomItem>)Delegate.Remove(buildEvents12.OnRoomItemSold, new Action<RoomItem>(OnRoomItemPurchased));
			BuildEvents buildEvents13 = _level.BuildEvents;
			buildEvents13.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Remove(buildEvents13.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			BuildEvents buildEvents14 = _level.BuildEvents;
			buildEvents14.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Remove(buildEvents14.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
			BuildEvents buildEvents15 = _level.BuildEvents;
			buildEvents15.OnRoomItemRequestUpgrade = (Action<RoomItem>)Delegate.Remove(buildEvents15.OnRoomItemRequestUpgrade, new Action<RoomItem>(OnRoomItemRequestUpgrade));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnRoomPurchased = (Action<Room, int>)Delegate.Remove(financeManager.OnRoomPurchased, new Action<Room, int>(OnRoomPurchased));
			FinanceManager financeManager2 = _level.FinanceManager;
			financeManager2.OnRoomSold = (Action<Room, int>)Delegate.Remove(financeManager2.OnRoomSold, new Action<Room, int>(OnRoomPurchased));
			FinanceManager financeManager3 = _level.FinanceManager;
			financeManager3.OnMonthlyWagesPaid = (Action<int>)Delegate.Remove(financeManager3.OnMonthlyWagesPaid, new Action<int>(OnStaffPaid));
			FinanceManager financeManager4 = _level.FinanceManager;
			financeManager4.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Remove(financeManager4.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarned));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffPickup = (Action<Staff, JobApplicant>)Delegate.Remove(characterEvents.OnStaffPickup, new Action<Staff, JobApplicant>(OnStaffPickup));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnRequestStaffDrop = (Action<Staff, Room>)Delegate.Remove(characterEvents2.OnRequestStaffDrop, new Action<Staff, Room>(OnRequestStaffDrop));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents3.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents4.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents5.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents6 = _level.CharacterEvents;
			characterEvents6.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents6.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents7 = _level.CharacterEvents;
			characterEvents7.OnStaffCancelPickup = (Action<bool>)Delegate.Remove(characterEvents7.OnStaffCancelPickup, new Action<bool>(OnStaffCancelPickup));
			_level.CharacterEvents.OnStaffHired.Remove(this);
			ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			ObjectiveEvents objectiveEvents2 = _level.ObjectiveEvents;
			objectiveEvents2.OnSubGoalCompleted = (Action<ObjectiveSubGoal>)Delegate.Remove(objectiveEvents2.OnSubGoalCompleted, new Action<ObjectiveSubGoal>(OnSubGoalCompleted));
			Notifications notifications = _level.Notifications;
			notifications.OnNotificationSent = (Action<NotificationMessage>)Delegate.Remove(notifications.OnNotificationSent, new Action<NotificationMessage>(OnNotificationSent));
			Notifications notifications2 = _level.Notifications;
			notifications2.OnMessageOpen = (Action<NotificationMessage>)Delegate.Remove(notifications2.OnMessageOpen, new Action<NotificationMessage>(OnNotificationOpen));
			Notifications notifications3 = _level.Notifications;
			notifications3.OnMessageClose = (Action<NotificationMessage, bool>)Delegate.Remove(notifications3.OnMessageClose, new Action<NotificationMessage, bool>(OnNotificationClose));
			DataViewManager dataViewManager = _level.DataViewManager;
			dataViewManager.OnEnterMode = (Action<DataViewManager.Mode>)Delegate.Remove(dataViewManager.OnEnterMode, new Action<DataViewManager.Mode>(OnEnterMode));
			DataViewManager dataViewManager2 = _level.DataViewManager;
			dataViewManager2.OnOverlayDisabled = (System.Action)Delegate.Remove(dataViewManager2.OnOverlayDisabled, new System.Action(OnOverlayDisabled));
			MonoBeastManager monoBeastManager = _level.MonoBeastManager;
			monoBeastManager.OnMonoBeastShot = (Action<MonoBeast, int>)Delegate.Remove(monoBeastManager.OnMonoBeastShot, new Action<MonoBeast, int>(OnMonoBeastShot));
			ChallengeManager challengeManager = _level.ChallengeManager;
			challengeManager.OnOpenSatNav = (Action<bool>)Delegate.Remove(challengeManager.OnOpenSatNav, new Action<bool>(OnOpenSatNav));
			ChallengeManager challengeManager2 = _level.ChallengeManager;
			challengeManager2.OnAlertSatNav = (Action<bool>)Delegate.Remove(challengeManager2.OnAlertSatNav, new Action<bool>(OnAlertSatNav));
			ChallengeManager challengeManager3 = _level.ChallengeManager;
			challengeManager3.OnOpenSatNavSubMenu = (Action<bool>)Delegate.Remove(challengeManager3.OnOpenSatNavSubMenu, new Action<bool>(OnOpenSatNavSubMenu));
			ChallengeManager challengeManager4 = _level.ChallengeManager;
			challengeManager4.OnSetPathSatNav = (Action<bool>)Delegate.Remove(challengeManager4.OnSetPathSatNav, new Action<bool>(OnSetPathSatNav));
			ChallengeManager challengeManager5 = _level.ChallengeManager;
			challengeManager5.OnCloseSatNavSubMenu = (Action<bool>)Delegate.Remove(challengeManager5.OnCloseSatNavSubMenu, new Action<bool>(OnCloseSatNavSubMenu));
			GameTime.OnIncreaseTimeScale = (Action<int>)Delegate.Remove(GameTime.OnIncreaseTimeScale, new Action<int>(OnIncreaseTimeScale));
			GameTime.OnDecreaseTimeScale = (Action<int>)Delegate.Remove(GameTime.OnDecreaseTimeScale, new Action<int>(OnDecreaseTimeScale));
			base.Destroy();
		}
	}
}
