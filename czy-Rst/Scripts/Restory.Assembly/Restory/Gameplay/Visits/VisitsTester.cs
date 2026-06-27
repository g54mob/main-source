using System;
using System.Text;
using JetBrains.Annotations;
using Restory.Data.NPCs;
using Restory.Data.Visits;
using Restory.Gameplay.Common;
using Restory.Gameplay.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Visits
{
	public class VisitsTester : MonoBehaviour, IActiveStateSwitchRequester, IShipmentClaimingVisitRequester
	{
		private CurrentDayVisitsQueueService currentDayVisitsQueueService;

		private VisitsScheduleService visitsScheduleService;

		private GameCalendar gameCalendar;

		private readonly StringBuilder cachedVisitsQueueStringBuilder = new StringBuilder();

		[Inject]
		private void Construct(CurrentDayVisitsQueueService currentDayVisitsQueueService, VisitsScheduleService visitsScheduleService, GameCalendar gameCalendar)
		{
			this.gameCalendar = gameCalendar;
			this.visitsScheduleService = visitsScheduleService;
			this.currentDayVisitsQueueService = currentDayVisitsQueueService;
		}

		private void AddImmediateVisitToCurrentDay(StoryNpcInfo npc, int gameMinutesBeforeVisit, int gameMinutesDelayAfterVisit = -999)
		{
			currentDayVisitsQueueService.AddNewImmediateVisit(npc, TimeSpan.FromMinutes(gameMinutesBeforeVisit), "", (gameMinutesDelayAfterVisit < 0) ? ((TimeSpan?)null) : new TimeSpan?(TimeSpan.FromMinutes(gameMinutesDelayAfterVisit)));
		}

		private void AddFreeSaleClaimingVisitToClosestTimePossible()
		{
			currentDayVisitsQueueService.TryToAddFreeSaleClaimingVisitToClosestTimePossible(this);
		}

		[UsedImplicitly]
		private string GetVisitsInfoAsString()
		{
			if (!currentDayVisitsQueueService)
			{
				return string.Empty;
			}
			cachedVisitsQueueStringBuilder.Clear();
			string text = (gameCalendar ? gameCalendar.CurrentDateTime.ToShortTimeString() : "UNDEFINED");
			cachedVisitsQueueStringBuilder.AppendLine("Time info:");
			cachedVisitsQueueStringBuilder.AppendLine("Current time - " + text);
			cachedVisitsQueueStringBuilder.AppendLine($"Earliest possible time to trigger next visit - {currentDayVisitsQueueService.EarliestTimeToTriggerNextVisit}");
			cachedVisitsQueueStringBuilder.AppendLine();
			cachedVisitsQueueStringBuilder.AppendLine("Current day visits queue:");
			cachedVisitsQueueStringBuilder.AppendLine();
			cachedVisitsQueueStringBuilder.AppendLine("Courier visits:");
			foreach (NpcVisit item in currentDayVisitsQueueService.CourierVisitsQueue)
			{
				cachedVisitsQueueStringBuilder.AppendLine(GetVisitInfo(item));
			}
			cachedVisitsQueueStringBuilder.AppendLine();
			cachedVisitsQueueStringBuilder.AppendLine("Immediate visits:");
			foreach (ImmediateStoryNpcVisit immediateVisit in currentDayVisitsQueueService.ImmediateVisits)
			{
				cachedVisitsQueueStringBuilder.AppendLine(GetVisitInfo(immediateVisit));
			}
			cachedVisitsQueueStringBuilder.AppendLine();
			cachedVisitsQueueStringBuilder.AppendLine("Standard visits (currently not working and should be empty):");
			foreach (NpcVisit item2 in currentDayVisitsQueueService.VisitsQueue)
			{
				cachedVisitsQueueStringBuilder.AppendLine(GetVisitInfo(item2));
			}
			cachedVisitsQueueStringBuilder.AppendLine();
			cachedVisitsQueueStringBuilder.AppendLine("Current visit:");
			NpcVisitInProgress visitCurrentlyInProgress = currentDayVisitsQueueService.VisitCurrentlyInProgress;
			if (visitCurrentlyInProgress != null && visitCurrentlyInProgress.Visit != null)
			{
				NpcVisit visit = currentDayVisitsQueueService.VisitCurrentlyInProgress.Visit;
				cachedVisitsQueueStringBuilder.AppendLine(GetVisitInfo(visit));
				cachedVisitsQueueStringBuilder.AppendLine($"Did interaction already happen? - {currentDayVisitsQueueService.VisitCurrentlyInProgress.DidInteractionHappen}");
			}
			if (currentDayVisitsQueueService.LeftoverPrematurelyStoppedVisit != null)
			{
				cachedVisitsQueueStringBuilder.AppendLine();
				cachedVisitsQueueStringBuilder.AppendLine("Visit interrupted before interaction - will resume the next day:");
				cachedVisitsQueueStringBuilder.AppendLine(GetVisitInfo(currentDayVisitsQueueService.LeftoverPrematurelyStoppedVisit));
			}
			return cachedVisitsQueueStringBuilder.ToString();
		}

		private static string GetVisitInfo(NpcVisit visit)
		{
			if (!(visit is RandomNpcVisit))
			{
				if (!(visit is WorkOrderClaimingNpcVisit))
				{
					if (!(visit is FreeSaleClaimingNpcVisit))
					{
						if (!(visit is DeliveryNpcVisit))
						{
							if (!(visit is DeliveryPaymentNpcVisit))
							{
								if (!(visit is StoryNpcVisit storyNpcVisit))
								{
									if (!(visit is ImmediateWorkOrderClaimingNpcVisit immediateWorkOrderClaimingNpcVisit))
									{
										if (visit is ImmediateStoryNpcVisit immediateStoryNpcVisit)
										{
											string text = ((immediateStoryNpcVisit.AfterVisitMandatoryDelay < TimeSpan.Zero) ? "default" : ((int)immediateStoryNpcVisit.AfterVisitMandatoryDelay.TotalMinutes).ToString());
											return visit.Npc.ID + " : immediate visit - Immediate - " + $"wants to come at {immediateStoryNpcVisit.TargetVisitTime}, " + "has a delay of " + text + " minutes after.";
										}
										return "NOT IMPLEMENTED TYPE!";
									}
									string text2 = ((immediateWorkOrderClaimingNpcVisit.AfterVisitMandatoryDelay < TimeSpan.Zero) ? "default" : ((int)immediateWorkOrderClaimingNpcVisit.AfterVisitMandatoryDelay.TotalMinutes).ToString());
									return visit.Npc.ID + " : immediate visit - ImmediateWorkOrderClaiming - " + $"wants to come at {immediateWorkOrderClaimingNpcVisit.TargetVisitTime}, " + "has a delay of " + text2 + " minutes after.";
								}
								return visit.Npc.ID + " : story visit - " + storyNpcVisit.VisitType;
							}
							return visit.Npc.ID + " : courier visit - DeliveryPayment";
						}
						return visit.Npc.ID + " : courier visit - Delivery";
					}
					return visit.Npc.ID + " : courier visit - FreeSaleClaiming";
				}
				return visit.Npc.ID + " : courier visit - WorkOrderClaiming";
			}
			return "Random";
		}
	}
}
