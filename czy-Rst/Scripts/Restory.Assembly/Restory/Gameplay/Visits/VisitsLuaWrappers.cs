using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.NPCs;
using Restory.Data.Visits;
using Zenject;

namespace Restory.Gameplay.Visits
{
	public class VisitsLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string AddVisitToSchedule = "Visits_AddVisitToSchedule";

			public static readonly string AddVisitWithTextureToSchedule = "Visits_AddVisitWithTextureToSchedule";

			public static readonly string AddImmediateVisitToCurrentDay = "Visits_AddImmediateVisitToCurrentDay";

			public static readonly string AddImmediateVisitWithTextureToCurrentDay = "Visits_AddImmediateVisitWithTextureToCurrentDay";

			public static readonly string AddImmediateVisitWithAfterDelayToCurrentDay = "Visits_AddImmediateVisitWithAfterDelayToCurrentDay";

			public static readonly string AddImmediateVisitWithTextureAndAfterDelayToCurrentDay = "Visits_AddImmediateVisitWithTextureAndAfterDelayToCurrentDay";
		}

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		private readonly CurrentDayVisitsQueueService currentDayVisitsQueueService;

		private readonly VisitsScheduleService visitsScheduleService;

		public VisitsLuaWrappers(GameEntityDataBaseProvider gameEntityDataBaseProvider, CurrentDayVisitsQueueService currentDayVisitsQueueService, VisitsScheduleService visitsScheduleService)
		{
			this.visitsScheduleService = visitsScheduleService;
			this.currentDayVisitsQueueService = currentDayVisitsQueueService;
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.AddImmediateVisitToCurrentDay, this, SymbolExtensions.GetMethodInfo(() => AddImmediateVisitToCurrentDay(string.Empty, 0f)));
			Lua.RegisterFunction(LuaNames.AddImmediateVisitWithTextureToCurrentDay, this, SymbolExtensions.GetMethodInfo(() => AddImmediateVisitToCurrentDay(string.Empty, string.Empty, 0f)));
			Lua.RegisterFunction(LuaNames.AddImmediateVisitWithAfterDelayToCurrentDay, this, SymbolExtensions.GetMethodInfo(() => AddImmediateVisitToCurrentDay(string.Empty, 0f, 0f)));
			Lua.RegisterFunction(LuaNames.AddImmediateVisitWithTextureAndAfterDelayToCurrentDay, this, SymbolExtensions.GetMethodInfo(() => AddImmediateVisitToCurrentDay(string.Empty, string.Empty, 0f, 0f)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.AddImmediateVisitToCurrentDay);
			Lua.UnregisterFunction(LuaNames.AddImmediateVisitWithTextureToCurrentDay);
			Lua.UnregisterFunction(LuaNames.AddImmediateVisitWithAfterDelayToCurrentDay);
			Lua.UnregisterFunction(LuaNames.AddImmediateVisitWithTextureAndAfterDelayToCurrentDay);
		}

		private void AddVisitToSchedule(string npcID, string visitTypeName, float intendedDay, string visitTimeIntervalName)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(npcID, out var entityInfo) && TryToGetVisitTypeFromName(visitTypeName, out var visitType) && TryToGetVisitTimeIntervalFromName(visitTimeIntervalName, out var visitTimeInterval))
			{
				visitsScheduleService.AddStoryVisit(entityInfo, visitType, (int)intendedDay, visitTimeInterval, out var _);
			}
		}

		private void AddVisitToSchedule(string npcID, string npcTextureID, string visitTypeName, float intendedDay, string visitTimeIntervalName)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(npcID, out var entityInfo) && TryToGetVisitTypeFromName(visitTypeName, out var visitType) && TryToGetVisitTimeIntervalFromName(visitTimeIntervalName, out var visitTimeInterval))
			{
				visitsScheduleService.AddStoryVisit(entityInfo, visitType, (int)intendedDay, visitTimeInterval, out var _, npcTextureID);
			}
		}

		private void AddImmediateVisitToCurrentDay(string npcID, float delayBeforeVisitInGameMinutes)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(npcID, out var entityInfo))
			{
				currentDayVisitsQueueService.AddNewImmediateVisit(entityInfo, TimeSpan.FromMinutes(delayBeforeVisitInGameMinutes));
			}
		}

		private void AddImmediateVisitToCurrentDay(string npcID, string npcTextureID, float delayBeforeVisitInGameMinutes)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(npcID, out var entityInfo))
			{
				currentDayVisitsQueueService.AddNewImmediateVisit(entityInfo, TimeSpan.FromMinutes(delayBeforeVisitInGameMinutes), npcTextureID);
			}
		}

		private void AddImmediateVisitToCurrentDay(string npcID, float delayBeforeVisitInGameMinutes, float delayAfterVisitInGameMinutes)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(npcID, out var entityInfo))
			{
				currentDayVisitsQueueService.AddNewImmediateVisit(entityInfo, TimeSpan.FromMinutes(delayBeforeVisitInGameMinutes), "", TimeSpan.FromMinutes(delayAfterVisitInGameMinutes));
			}
		}

		private void AddImmediateVisitToCurrentDay(string npcID, string npcTextureID, float delayBeforeVisitInGameMinutes, float delayAfterVisitInGameMinutes)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(npcID, out var entityInfo))
			{
				CurrentDayVisitsQueueService obj = currentDayVisitsQueueService;
				StoryNpcInfo npc = entityInfo;
				TimeSpan delayBeforeVisit = TimeSpan.FromMinutes(delayBeforeVisitInGameMinutes);
				TimeSpan? delayAfterVisit = TimeSpan.FromMinutes(delayAfterVisitInGameMinutes);
				obj.AddNewImmediateVisit(npc, delayBeforeVisit, npcTextureID, delayAfterVisit);
			}
		}

		private bool TryToGetVisitTypeFromName(string visitTypeName, out StoryVisitType visitType)
		{
			switch (visitTypeName.ToLower())
			{
			case "common":
			case "storycommon":
				visitType = StoryVisitType.Common;
				return true;
			case "urgent":
			case "storyurgent":
				visitType = StoryVisitType.Urgent;
				return true;
			default:
				visitType = StoryVisitType.Common;
				return false;
			}
		}

		private bool TryToGetVisitTimeIntervalFromName(string visitTimeIntervalName, out VisitTimeInterval visitTimeInterval)
		{
			switch (visitTimeIntervalName.ToLower())
			{
			case "any":
			case "anytime":
				visitTimeInterval = VisitTimeInterval.AnyTime;
				return true;
			case "morning":
				visitTimeInterval = VisitTimeInterval.Morning;
				return true;
			case "evening":
				visitTimeInterval = VisitTimeInterval.Evening;
				return true;
			default:
				visitTimeInterval = VisitTimeInterval.AnyTime;
				return false;
			}
		}
	}
}
