using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Repository;
using NSMedieval.UI;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	public class PlayerTriggeredEventManager : MonoSingleton<PlayerTriggeredEventManager>
	{
		public PlayerTriggeredEventInstance EventToStart { get; private set; }

		public PlayerTriggeredEventInstance CurrentEvent { get; private set; }

		public event Action EventDiscardedEvent;

		public event Action<PlayerTriggeredEventInstance> EventStartedEvent;

		public event Action<PlayerTriggeredEventInstance> EventEndedEvent;

		public event Action EventViewShownEvent;

		private void Start()
		{
			MonoSingleton<UIController>.Instance.GameStartedEvent += OnGameplayStart;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.GameStartedEvent -= OnGameplayStart;
			}
		}

		public void ShowView()
		{
			if (EventToStart == null)
			{
				Log.Error("PlayerTriggeredEventSystem: Cannot show view because event instance is null.", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				return;
			}
			EventToStart.Initialize();
			MonoSingleton<UIController>.Instance.TriggeredEventView.SetDataAndShow(EventToStart);
			HandleFirstView();
		}

		public bool CanShowView(string eventId, BaseBuildingInstance targetBuilding, bool isSilent = false)
		{
			if (MonoSingleton<UIController>.Instance.TriggeredEventView.IsShowing())
			{
				return false;
			}
			if (IsEventRunning())
			{
				Log.Trace("CanShowView Event is Running", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				return false;
			}
			if (CurrentEvent != null && CurrentEvent.Blueprint.GetID() != eventId)
			{
				Log.Trace("CanShowView CurrentEvent exists", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				CurrentEvent = null;
			}
			bool isEnabled;
			if (EventToStart != null && EventToStart.Blueprint.GetID() != eventId)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(48, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CanShowView EventToStart ");
					messageBuilder.AppendFormatted(EventToStart.Blueprint.GetID());
					messageBuilder.AppendLiteral(" exists. Trying to run ");
					messageBuilder.AppendFormatted(eventId);
				}
				Log.Trace(messageBuilder);
				EventToStart = null;
			}
			if (EventToStart != null && EventToStart.NotStarted() && EventToStart.HostBuilding == targetBuilding)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CanShowView EventToStart ");
					messageBuilder.AppendFormatted(EventToStart.Blueprint.GetID());
					messageBuilder.AppendLiteral(" exists.");
				}
				Log.Trace(messageBuilder);
				return CanShowView(isSilent);
			}
			if (PrepareEvent(eventId, targetBuilding))
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CanShowView Prepared ");
					messageBuilder.AppendFormatted(EventToStart?.Blueprint.GetID());
					messageBuilder.AppendLiteral(" event.");
				}
				Log.Trace(messageBuilder);
				return CanShowView(isSilent);
			}
			return false;
		}

		private bool PrepareEvent(string eventId, BaseBuildingInstance targetBuilding)
		{
			PlayerTriggeredEvent byID = Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetByID(eventId);
			bool isEnabled;
			if (byID == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PlayerTriggeredEventSystem: Could not find event with id ");
					messageBuilder.AppendFormatted(eventId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return false;
			}
			if (byID.IsLocked())
			{
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("PlayerTriggeredEventSystem: Event ");
					messageBuilder2.AppendFormatted(eventId);
					messageBuilder2.AppendLiteral(" is locked, cannot start it.");
				}
				Log.Info(messageBuilder2);
				return false;
			}
			string text = "NSMedieval.PlayerTriggeredEventSystem." + byID.ClassName;
			Type type = Type.GetType(text);
			if (type == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(49, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PlayerTriggeredEventSystem: Could not find type ");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return false;
			}
			EventToStart = (PlayerTriggeredEventInstance)Activator.CreateInstance(type);
			if (EventToStart == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PlayerTriggeredEventSystem: Could not create instance of type ");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return false;
			}
			EventToStart.SetBlueprint(byID);
			EventToStart.SetHostFurniture(targetBuilding);
			return EventToStart != null;
		}

		public void CancelEventPrep()
		{
			if (EventToStart == null)
			{
				Log.Error("PlayerTriggeredEventSystem: Cannot cancel because event instance is already null.", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				return;
			}
			EventToStart = null;
			this.EventDiscardedEvent?.Invoke();
		}

		public void RunEvent()
		{
			if (EventToStart == null)
			{
				Log.Error("PlayerTriggeredEventSystem: Cannot start event because event instance is null.", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				return;
			}
			CurrentEvent = EventToStart;
			EventToStart = null;
			CurrentEvent.Start();
			GlobalSaveController.CurrentVillageData.PlayerTriggeredEventSaveData.AddRunningEvent(CurrentEvent);
			this.EventStartedEvent?.Invoke(CurrentEvent);
		}

		public void EndEvent()
		{
			if (CurrentEvent == null)
			{
				Log.Error("PlayerTriggeredEventSystem: Cannot stop event because event instance is null.", "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				return;
			}
			EventToStart = null;
			GlobalSaveController.CurrentVillageData.PlayerTriggeredEventSaveData.RemoveRunningEvent(CurrentEvent);
			this.EventEndedEvent?.Invoke(CurrentEvent);
			MonoSingleton<AchievementManager>.Instance.UnlockAchievement(CurrentEvent.GetOutcome().UnlockAchievementOnEnd);
		}

		public bool CanEndWithoutPenalty()
		{
			return CurrentEvent.CanEndWithoutPenalty();
		}

		public void OnEndEventClick()
		{
			CurrentEvent.ChangeStateEnd();
		}

		public bool IsInEventRoom(BaseBuildingInstance furnitureInstance)
		{
			if (CurrentEvent != null)
			{
				return CurrentEvent.FurnitureIsInRoom(furnitureInstance);
			}
			return false;
		}

		public bool IsEventRunning()
		{
			if (CurrentEvent != null && !CurrentEvent.Disposed())
			{
				if (!CurrentEvent.Gathering() && !CurrentEvent.Started())
				{
					return CurrentEvent.Ended();
				}
				return true;
			}
			return false;
		}

		public bool IsAnotherEventRunning(string eventId)
		{
			if (CurrentEvent != null && !CurrentEvent.Disposed() && CurrentEvent.Blueprint.GetID() != eventId)
			{
				return true;
			}
			return false;
		}

		private bool CanShowView(bool isSilent)
		{
			bool isEnabled;
			if (EventToStart == null)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CanShowView EventToStart is NULL. Is Silent: ");
					messageBuilder.AppendFormatted(isSilent);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			if (EventToStart.CanShowView())
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("CanShowView EventToStart ");
					messageBuilder.AppendFormatted(EventToStart.Blueprint.GetID());
					messageBuilder.AppendLiteral(" can show view. Is Silent: ");
					messageBuilder.AppendFormatted(isSilent);
				}
				Log.Trace(messageBuilder);
				if (isSilent)
				{
					EventToStart = null;
				}
				return true;
			}
			EventToStart = null;
			return false;
		}

		private void HandleFirstView()
		{
			if (!GlobalSaveController.CurrentVillageData.PlayerTriggeredEventSaveData.IsEventViewShown(EventToStart.Blueprint.GetID()))
			{
				GlobalSaveController.CurrentVillageData.PlayerTriggeredEventSaveData.TrySetViewShown(EventToStart.Blueprint.GetID());
				this.EventViewShownEvent?.Invoke();
			}
		}

		private void OnGameplayStart(bool started)
		{
			if (!started || !GlobalSaveController.CurrentVillageData.PlayerTriggeredEventSaveData.GetRunningEvent(out var playerTriggeredEventInstance))
			{
				return;
			}
			if (playerTriggeredEventInstance.IsCorrupted())
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\PlayerTriggeredEventManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing PTE '");
					messageBuilder.AppendFormatted(playerTriggeredEventInstance.GetType().Name);
					messageBuilder.AppendLiteral("' because it is corrupted");
				}
				Log.Error(messageBuilder);
				GlobalSaveController.CurrentVillageData.PlayerTriggeredEventSaveData.RemoveRunningEvent(playerTriggeredEventInstance);
			}
			else
			{
				EventToStart = playerTriggeredEventInstance;
				EventToStart.InitializeFromSave();
				RunEvent();
			}
		}

		public bool IsAnimalAtEvent(IEventParticipant eventParticipant)
		{
			if (CurrentEvent != null && CurrentEvent.Running())
			{
				return CurrentEvent.HasAnimal(eventParticipant);
			}
			return false;
		}

		public bool IsAtEvent(IEventParticipant eventParticipant)
		{
			if (CurrentEvent != null && CurrentEvent.Running())
			{
				return CurrentEvent.HasParticipant(eventParticipant);
			}
			return false;
		}
	}
}
