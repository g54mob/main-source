using System;
using System.Collections;
using System.Collections.Generic;
using Restory.Data.GameConfigs;
using Restory.Data.NPCs;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Visits;
using Restory.Gameplay.Common;
using Restory.Gameplay.NPCs;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using Restory.TimeSystems;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Visits
{
	public class CurrentDayVisitsQueueService : MonoBehaviour, ITimeChangeReceiver, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private VisitsScheduleSettings visitsScheduleSettings;

		[SerializeField]
		private CurrentDayVisitsSettings currentDayVisitsSettings;

		private GameCalendar gameCalendar;

		private NpcServiceMain npcService;

		private GameConfig gameConfig;

		private VisitsQueueFiller queueFiller;

		private readonly List<NpcVisit> visitsQueue = new List<NpcVisit>();

		private readonly List<NpcVisit> courierVisitsQueue = new List<NpcVisit>();

		private readonly List<ImmediateStoryNpcVisit> immediateVisits = new List<ImmediateStoryNpcVisit>();

		private readonly NpcVisitInProgress visitCurrentlyInProgress = new NpcVisitInProgress();

		private NpcVisit leftoverPrematurelyStoppedVisit;

		private DateTime earliestTimeToTriggerNextVisit = DateTime.MaxValue;

		private DateTime earliestTimeToTriggerNextVisitAfterCourierVisit = DateTime.MaxValue;

		private readonly ActiveStateSwitcher activeStateSwitcher = new ActiveStateSwitcher(ActiveStateSwitcher.WorkMode.ActiveByDefaultAndRequestersMakeItInactive);

		private Coroutine doCallbackAfterEndOfFrameCoroutine;

		private CurrentDayVisitsQueueServiceSaveData restoredState;

		private MainDayTimes lastTrackedTime;

		private HashSet<IShipmentClaimingVisitRequester> activeFreeSaleVisitsRequesters = new HashSet<IShipmentClaimingVisitRequester>();

		public NpcVisitInProgress VisitCurrentlyInProgress => visitCurrentlyInProgress;

		public IReadOnlyList<NpcVisit> VisitsQueue => visitsQueue;

		public IReadOnlyList<NpcVisit> CourierVisitsQueue => courierVisitsQueue;

		public IEnumerable<ImmediateStoryNpcVisit> ImmediateVisits => immediateVisits;

		public DateTime EarliestTimeToTriggerNextVisit => earliestTimeToTriggerNextVisit;

		public DateTime EarliestTimeToTriggerNextVisitAfterCourierVisit => earliestTimeToTriggerNextVisitAfterCourierVisit;

		public NpcVisit LeftoverPrematurelyStoppedVisit => leftoverPrematurelyStoppedVisit;

		public event Action OnNpcStartedLeavingStoreWindow;

		[Inject]
		private void Construct(GameCalendar gameCalendar, NpcServiceMain npcService, GameConfig gameConfig)
		{
			this.gameConfig = gameConfig;
			this.npcService = npcService;
			this.gameCalendar = gameCalendar;
			queueFiller = new VisitsQueueFiller(visitsScheduleSettings);
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)gameCalendar)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (activeStateSwitcher != null)
			{
				activeStateSwitcher.OnActiveStatusSwitchRequested -= ResolveActiveStatusChanged;
			}
			if (doCallbackAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(doCallbackAfterEndOfFrameCoroutine);
				doCallbackAfterEndOfFrameCoroutine = null;
			}
		}

		private void Init()
		{
			RefreshActiveStatus();
			activeStateSwitcher.OnActiveStatusSwitchRequested += ResolveActiveStatusChanged;
		}

		public void BlockVisits(IActiveStateSwitchRequester blockingSource)
		{
			activeStateSwitcher.AddRequester(blockingSource);
		}

		public void UnblockVisits(IActiveStateSwitchRequester blockingSource)
		{
			activeStateSwitcher.RemoveRequester(blockingSource);
		}

		public void ProcessTimeChanged()
		{
			if (!(gameCalendar.CurrentDateTime < earliestTimeToTriggerNextVisit) && (TryToStartNextCourierVisit() || TryToStartNextImmediateVisit() || TryToStartNextNonImmediateVisit()))
			{
				earliestTimeToTriggerNextVisit = DateTime.MaxValue;
			}
		}

		public void SetCurrentTime(MainDayTimes currentTime)
		{
			lastTrackedTime = currentTime;
		}

		public void AddInitialNpcVisit(StoryNpcInfo firstVisitor)
		{
			AddNewImmediateVisit(firstVisitor, TimeSpan.Zero);
		}

		public void SetFirstVisitTriggerTimeForTheDay()
		{
			MainDayTimes mainDayTimes = lastTrackedTime;
			if (mainDayTimes == MainDayTimes.None || mainDayTimes == MainDayTimes.AfterWork || mainDayTimes == MainDayTimes.StoreClosedTime)
			{
				earliestTimeToTriggerNextVisitAfterCourierVisit = DateTime.MaxValue;
				if (gameCalendar.CurrentDayNumber == 1)
				{
					earliestTimeToTriggerNextVisit = DateTime.MinValue;
					return;
				}
				float num = UnityEngine.Random.Range(currentDayVisitsSettings.MinFirstVisitTimeAfterDayStarts.TotalSeconds, currentDayVisitsSettings.MaxFirstVisitTimeAfterDayStarts.TotalSeconds);
				earliestTimeToTriggerNextVisit = gameCalendar.CurrentDateTime + TimeSpan.FromSeconds(num);
			}
		}

		public void SetUpVisitsForTheDay(IEnumerable<StoryNpcVisit> visitsScheduledForTheDay)
		{
			MainDayTimes mainDayTimes = lastTrackedTime;
			if (mainDayTimes == MainDayTimes.None || mainDayTimes == MainDayTimes.AfterWork || mainDayTimes == MainDayTimes.StoreClosedTime)
			{
				visitCurrentlyInProgress.Clear();
				queueFiller.FillQueueWithMorningAndAnyTimeVisits(visitsScheduledForTheDay, visitsQueue);
				if (gameConfig.RandomNpcVisitsSupportedPlatforms.GetSupportedStatus())
				{
					queueFiller.AddRandomVisitsToQueue(visitsQueue);
				}
			}
		}

		public void SetUpVisitsForEvening(IEnumerable<StoryNpcVisit> visits)
		{
			if (lastTrackedTime != MainDayTimes.Evening)
			{
				queueFiller.FillQueueWithEveningVisits(visits, visitsQueue);
			}
		}

		public void AddOrderClaimingVisitToClosestTimePossible(INpcInfo npc, int workOrderID, string npcTextureID = "")
		{
			if (npc != null)
			{
				AddCourierVisitToQueue(new WorkOrderClaimingNpcVisit
				{
					Npc = npc,
					NpcTextureID = npcTextureID,
					WorkOrderID = workOrderID
				});
			}
		}

		public void AddImmediateOrderClaimingVisit(INpcInfo npc, TimeSpan delayBeforeVisit, int workOrderID, string npcTextureID = "")
		{
			if (npc != null)
			{
				AddNewImmediateVisit(new ImmediateWorkOrderClaimingNpcVisit
				{
					Npc = npc,
					NpcTextureID = npcTextureID,
					WorkOrderID = workOrderID,
					TargetVisitTime = gameCalendar.CurrentDateTime + delayBeforeVisit
				});
			}
		}

		public bool TryToAddFreeSaleClaimingVisitToClosestTimePossible(IShipmentClaimingVisitRequester shipmentClaimingVisitRequester)
		{
			activeFreeSaleVisitsRequesters.Add(shipmentClaimingVisitRequester);
			foreach (NpcVisit item in courierVisitsQueue)
			{
				if (item is FreeSaleClaimingNpcVisit)
				{
					return false;
				}
			}
			AddCourierVisitToQueue(new FreeSaleClaimingNpcVisit
			{
				Npc = currentDayVisitsSettings.DefaultCourierNpc
			});
			return true;
		}

		public bool TryToAddDeliveryVisitToClosestTimePossible()
		{
			return TryToAddDeliveryVisitToClosestTimePossible(currentDayVisitsSettings.DefaultCourierNpc);
		}

		public bool TryToAddDeliveryPaymentVisitToClosestTimePossible(INpcInfo npc, string npcTextureID = "")
		{
			AddCourierVisitToQueue(new DeliveryPaymentNpcVisit
			{
				Npc = npc,
				NpcTextureID = npcTextureID
			});
			return true;
		}

		public bool TryToAddDeliveryVisitToClosestTimePossible(INpcInfo npc, string npcTextureID = "")
		{
			if (npc == null)
			{
				return false;
			}
			foreach (NpcVisit item in courierVisitsQueue)
			{
				if (item is DeliveryNpcVisit)
				{
					return false;
				}
			}
			AddCourierVisitToQueue(new DeliveryNpcVisit
			{
				Npc = npc,
				NpcTextureID = npcTextureID
			});
			return true;
		}

		private void AddCourierVisitToQueue(NpcVisit courierVisit)
		{
			if (courierVisitsQueue.Count == 0)
			{
				earliestTimeToTriggerNextVisitAfterCourierVisit = earliestTimeToTriggerNextVisit;
				earliestTimeToTriggerNextVisit = gameCalendar.CurrentDateTime + TimeSpan.FromSeconds(GetSecondsBeforeCourierVisitStarts());
			}
			courierVisitsQueue.Add(courierVisit);
		}

		public void AddNewImmediateVisit(INpcInfo npc, TimeSpan delayBeforeVisit, string npcTextureId = "", TimeSpan? delayAfterVisit = null)
		{
			if (npc == null)
			{
				Debug.LogError("Failed to add immediate visit, npc is null");
				return;
			}
			AddNewImmediateVisit(new ImmediateStoryNpcVisit
			{
				Npc = npc,
				NpcTextureID = npcTextureId,
				TargetVisitTime = gameCalendar.CurrentDateTime + delayBeforeVisit,
				AfterVisitMandatoryDelay = (delayAfterVisit ?? TimeSpan.MinValue)
			});
		}

		private void AddNewImmediateVisit(ImmediateStoryNpcVisit visit)
		{
			immediateVisits.Add(visit);
		}

		public void RemoveVisitWithAttachedWorkOrder(int workOrderID)
		{
			bool flag = false;
			for (int num = courierVisitsQueue.Count - 1; num >= 0; num--)
			{
				if (courierVisitsQueue[num] is WorkOrderClaimingNpcVisit workOrderClaimingNpcVisit && workOrderClaimingNpcVisit.WorkOrderID == workOrderID)
				{
					courierVisitsQueue.RemoveAt(num);
					flag = true;
				}
			}
			if (flag)
			{
				DetermineEarliestTimeForNextVisit();
			}
		}

		public bool TryToRemoveFreeSaleClaimingVisits(IShipmentClaimingVisitRequester shipmentClaimingVisitRequester)
		{
			activeFreeSaleVisitsRequesters.Remove(shipmentClaimingVisitRequester);
			if (activeFreeSaleVisitsRequesters.Count > 0)
			{
				return false;
			}
			bool flag = false;
			for (int num = courierVisitsQueue.Count - 1; num >= 0; num--)
			{
				if (courierVisitsQueue[num] is FreeSaleClaimingNpcVisit)
				{
					courierVisitsQueue.RemoveAt(num);
					flag = true;
				}
			}
			if (flag)
			{
				DetermineEarliestTimeForNextVisit();
				return true;
			}
			return false;
		}

		public void RemoveDeliveryVisits()
		{
			bool flag = false;
			for (int num = courierVisitsQueue.Count - 1; num >= 0; num--)
			{
				if (courierVisitsQueue[num] is DeliveryNpcVisit)
				{
					courierVisitsQueue.RemoveAt(num);
					flag = true;
				}
			}
			if (flag)
			{
				DetermineEarliestTimeForNextVisit();
			}
		}

		public void ForceStopCurrentVisit()
		{
			if (!visitCurrentlyInProgress.DidInteractionHappen && visitCurrentlyInProgress.Visit != null)
			{
				leftoverPrematurelyStoppedVisit = visitCurrentlyInProgress.Visit;
			}
			visitCurrentlyInProgress.Clear();
			npcService.ForceStopCurrentNpcVisit();
		}

		public void ClearQueueAtTheEndOfDay(List<StoryNpcVisit> leftoverStoryVisitsListToFill, out StoryNpcVisit firstNextMorningUrgentVisit)
		{
			List<NpcVisit> list = CollectionPool<List<NpcVisit>, NpcVisit>.Get();
			leftoverStoryVisitsListToFill.Clear();
			firstNextMorningUrgentVisit = null;
			NpcVisit npcVisit = leftoverPrematurelyStoppedVisit;
			if (npcVisit != null && !(npcVisit is RandomNpcVisit))
			{
				if (!(npcVisit is FreeSaleClaimingNpcVisit) && !(npcVisit is WorkOrderClaimingNpcVisit) && !(npcVisit is DeliveryNpcVisit) && !(npcVisit is DeliveryPaymentNpcVisit))
				{
					if (!(npcVisit is ImmediateStoryNpcVisit immediateStoryNpcVisit))
					{
						if (!(npcVisit is StoryNpcVisit { VisitType: var visitType } storyNpcVisit))
						{
							throw new NotImplementedException();
						}
						switch (visitType)
						{
						case StoryVisitType.Common:
							leftoverStoryVisitsListToFill.Add(storyNpcVisit);
							break;
						case StoryVisitType.Urgent:
							firstNextMorningUrgentVisit = storyNpcVisit;
							break;
						default:
							throw new NotImplementedException();
						}
					}
					else
					{
						immediateVisits.Add(new ImmediateStoryNpcVisit
						{
							TargetVisitTime = immediateStoryNpcVisit.TargetVisitTime,
							Npc = immediateStoryNpcVisit.Npc,
							AfterVisitMandatoryDelay = immediateStoryNpcVisit.AfterVisitMandatoryDelay
						});
					}
				}
				else
				{
					List<NpcVisit> value;
					using (CollectionPool<List<NpcVisit>, NpcVisit>.Get(out value))
					{
						value.Add(leftoverPrematurelyStoppedVisit);
						value.AddRange(courierVisitsQueue);
						courierVisitsQueue.Clear();
						courierVisitsQueue.AddRange(value);
					}
				}
			}
			leftoverPrematurelyStoppedVisit = null;
			foreach (NpcVisit item3 in visitsQueue)
			{
				if (!(item3 is RandomNpcVisit item))
				{
					if (!(item3 is StoryNpcVisit item2))
					{
						throw new NotImplementedException();
					}
					leftoverStoryVisitsListToFill.Add(item2);
					list.Add(item2);
				}
				else
				{
					list.Add(item);
				}
			}
			for (int num = visitsQueue.Count - 1; num >= 0; num--)
			{
				if (list.Contains(visitsQueue[num]))
				{
					visitsQueue.RemoveAt(num);
				}
			}
			CollectionPool<List<NpcVisit>, NpcVisit>.Release(list);
		}

		private void ResolveActiveStatusChanged()
		{
			if (doCallbackAfterEndOfFrameCoroutine == null)
			{
				doCallbackAfterEndOfFrameCoroutine = StartCoroutine(DoCallbackAfterEndOfFrameCoroutine(RefreshActiveStatus));
			}
		}

		private IEnumerator DoCallbackAfterEndOfFrameCoroutine(Action callback)
		{
			yield return new WaitForEndOfFrame();
			doCallbackAfterEndOfFrameCoroutine = null;
			callback?.Invoke();
		}

		private void RefreshActiveStatus()
		{
			if (activeStateSwitcher.ShouldSystemBeActive)
			{
				gameCalendar.AddSubscriber(this);
			}
			else
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		private bool TryToStartNextCourierVisit()
		{
			if (courierVisitsQueue.Count == 0)
			{
				return false;
			}
			NpcVisit npcVisit = courierVisitsQueue[0];
			if (!(npcVisit is FreeSaleClaimingNpcVisit))
			{
				if (!(npcVisit is DeliveryNpcVisit) && !(npcVisit is DeliveryPaymentNpcVisit))
				{
					if (!(npcVisit is WorkOrderClaimingNpcVisit))
					{
						throw new NotImplementedException();
					}
					if (!npcService.TryToStartNpcVisitWithInteraction(npcVisit.Npc, npcVisit.NpcTextureID, ResolveInteractionInsideVisitStarted, ResolveNpcStartedMovingToExit, ResolveVisitCompleted))
					{
						return false;
					}
				}
				else if (!npcService.TryToStartNpcVisitWithoutInteractionSegment(npcVisit.Npc, npcVisit.NpcTextureID, ResolveInteractionInsideVisitStarted, ResolveNpcStartedMovingToExit, ResolveVisitCompleted))
				{
					return false;
				}
			}
			else
			{
				if (!npcService.TryToStartNpcVisitWithoutInteractionSegment(npcVisit.Npc, npcVisit.NpcTextureID, ResolveInteractionInsideVisitStarted, ResolveNpcStartedMovingToExit, ResolveVisitCompleted))
				{
					return false;
				}
				activeFreeSaleVisitsRequesters.Clear();
			}
			visitCurrentlyInProgress.SetNewVisit(npcVisit);
			courierVisitsQueue.RemoveAt(0);
			Debug.Log("Starting visit of type [" + visitCurrentlyInProgress.Visit.GetType().Name + "] by " + visitCurrentlyInProgress.Visit.Npc.ID);
			return true;
		}

		private bool TryToStartNextImmediateVisit()
		{
			ImmediateStoryNpcVisit immediateStoryNpcVisit = null;
			foreach (ImmediateStoryNpcVisit immediateVisit in immediateVisits)
			{
				if (!(immediateVisit.TargetVisitTime > gameCalendar.CurrentDateTime))
				{
					immediateStoryNpcVisit = ((immediateStoryNpcVisit == null) ? immediateVisit : ((immediateStoryNpcVisit.TargetVisitTime < immediateVisit.TargetVisitTime) ? immediateStoryNpcVisit : immediateVisit));
				}
			}
			if (immediateStoryNpcVisit == null)
			{
				return false;
			}
			if (!npcService.TryToStartNpcVisitWithInteraction(immediateStoryNpcVisit.Npc, immediateStoryNpcVisit.NpcTextureID, ResolveInteractionInsideVisitStarted, ResolveNpcStartedMovingToExit, ResolveVisitCompleted))
			{
				return false;
			}
			visitCurrentlyInProgress.SetNewVisit(immediateStoryNpcVisit);
			immediateVisits.Remove(immediateStoryNpcVisit);
			Debug.Log("Starting visit by " + visitCurrentlyInProgress.Visit.Npc.ID);
			return true;
		}

		private bool TryToStartNextNonImmediateVisit()
		{
			if (visitsQueue.Count == 0)
			{
				return false;
			}
			NpcVisit npcVisit = visitsQueue[0];
			if (npcService.TryToStartNpcVisitWithInteraction(npcVisit.Npc, npcVisit.NpcTextureID, ResolveInteractionInsideVisitStarted, ResolveNpcStartedMovingToExit, ResolveVisitCompleted))
			{
				visitCurrentlyInProgress.SetNewVisit(visitsQueue[0]);
				visitsQueue.RemoveAt(0);
				Debug.Log("Starting visit of type [" + visitCurrentlyInProgress.Visit.GetType().Name + "] by " + visitCurrentlyInProgress.Visit.Npc.ID);
				return true;
			}
			return false;
		}

		private void ResolveInteractionInsideVisitStarted()
		{
			visitCurrentlyInProgress.ProcessInteractionBetweenPlayerAndNpc();
		}

		private void ResolveNpcStartedMovingToExit()
		{
			this.OnNpcStartedLeavingStoreWindow?.Invoke();
		}

		private void ResolveVisitCompleted()
		{
			DetermineEarliestTimeForNextVisit();
			visitCurrentlyInProgress.Clear();
		}

		private void DetermineEarliestTimeForNextVisit()
		{
			if (!TryToSetNextVisitTimeFromNextCourierVisit() && !TryToSetNextEarliestVisitTimeAfterCourierVisit() && !TryToSetEarliestNextVisitTimeAfterImmediateVisit())
			{
				SetEarliestNextVisitTimeWithNoSpecialConditions();
			}
		}

		private bool TryToSetNextVisitTimeFromNextCourierVisit()
		{
			if (courierVisitsQueue.Count > 0)
			{
				earliestTimeToTriggerNextVisit = gameCalendar.CurrentDateTime + TimeSpan.FromSeconds(GetSecondsBeforeCourierVisitStarts());
				return true;
			}
			earliestTimeToTriggerNextVisit = DateTime.MaxValue;
			return false;
		}

		private bool TryToSetNextEarliestVisitTimeAfterCourierVisit()
		{
			TimeSpan timeSpan = currentDayVisitsSettings.MinDelayAfterImmediateVisit.InTimeSpan();
			if (earliestTimeToTriggerNextVisitAfterCourierVisit < DateTime.MaxValue)
			{
				earliestTimeToTriggerNextVisit = ((earliestTimeToTriggerNextVisitAfterCourierVisit - gameCalendar.CurrentDateTime > timeSpan) ? earliestTimeToTriggerNextVisitAfterCourierVisit : (gameCalendar.CurrentDateTime + timeSpan));
				earliestTimeToTriggerNextVisitAfterCourierVisit = DateTime.MaxValue;
				return true;
			}
			earliestTimeToTriggerNextVisit = DateTime.MaxValue;
			return false;
		}

		private bool TryToSetEarliestNextVisitTimeAfterImmediateVisit()
		{
			if (!(visitCurrentlyInProgress.Visit is ImmediateStoryNpcVisit immediateStoryNpcVisit))
			{
				earliestTimeToTriggerNextVisit = DateTime.MaxValue;
				return false;
			}
			earliestTimeToTriggerNextVisit = gameCalendar.CurrentDateTime + ((immediateStoryNpcVisit.AfterVisitMandatoryDelay < TimeSpan.Zero) ? currentDayVisitsSettings.MinDelayAfterImmediateVisit.InTimeSpan() : immediateStoryNpcVisit.AfterVisitMandatoryDelay);
			return true;
		}

		private void SetEarliestNextVisitTimeWithNoSpecialConditions()
		{
			earliestTimeToTriggerNextVisit = gameCalendar.CurrentDateTime + currentDayVisitsSettings.MinDelayAfterImmediateVisit.InTimeSpan();
		}

		private float GetSecondsBeforeCourierVisitStarts()
		{
			return currentDayVisitsSettings.DelayBeforeCourierVisit.TotalSeconds;
		}

		public object CaptureState()
		{
			try
			{
				return new CurrentDayVisitsQueueServiceSaveData
				{
					CurrentVisit = visitCurrentlyInProgress.Visit,
					WasCurrentVisitInteracted = visitCurrentlyInProgress.DidInteractionHappen,
					MainVisits = visitsQueue.ToArray(),
					CourierVisits = courierVisitsQueue.ToArray(),
					ImmediateVisits = immediateVisits.ToArray(),
					NextVisitTime = earliestTimeToTriggerNextVisit,
					NextVisitTimeAfterCourierVisit = earliestTimeToTriggerNextVisitAfterCourierVisit,
					SaveTime = lastTrackedTime
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				restoredState = DataMigrationWizard.Migrate<CurrentDayVisitsQueueServiceSaveData>(state, base.gameObject);
				visitCurrentlyInProgress.SetNewVisit(restoredState.CurrentVisit);
				if (restoredState.WasCurrentVisitInteracted)
				{
					visitCurrentlyInProgress.ProcessInteractionBetweenPlayerAndNpc();
				}
				visitsQueue.Clear();
				visitsQueue.AddRange(restoredState.MainVisits);
				courierVisitsQueue.Clear();
				courierVisitsQueue.AddRange(restoredState.CourierVisits);
				immediateVisits.Clear();
				ImmediateStoryNpcVisit[] array = restoredState.ImmediateVisits;
				foreach (ImmediateStoryNpcVisit item in array)
				{
					immediateVisits.Add(item);
				}
				earliestTimeToTriggerNextVisit = restoredState.NextVisitTime;
				earliestTimeToTriggerNextVisitAfterCourierVisit = restoredState.NextVisitTimeAfterCourierVisit;
				lastTrackedTime = restoredState.SaveTime;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
