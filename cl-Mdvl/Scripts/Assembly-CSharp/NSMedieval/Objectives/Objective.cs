using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Model;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Objectives
{
	[Serializable]
	public class Objective : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string gameOverEventImage;

		[SerializeField]
		private ObjectiveTask[] tasks;

		[SerializeField]
		private string[] unlockRoomTypes;

		[SerializeField]
		private string[] unlockGameEvents;

		[SerializeField]
		private string unlockAchievementOnCompleted;

		[SerializeField]
		private string[] turnIntoPermanentlyHostile;

		[SerializeField]
		private string[] turnIntoFullyFriendly;

		[SerializeField]
		private string[] banditCamps;

		[SerializeField]
		private int banditCampsSpawnCount;

		[SerializeField]
		private IntRange banditCampDurationRangeHours;

		[SerializeField]
		private string banditCampPrefabAddress;

		[SerializeField]
		private string startEventOnCompleted;

		[SerializeField]
		private bool hideInScenario;

		[SerializeField]
		private string[] blockGameEvents;

		[SerializeField]
		private bool bypassBlockingEvents;

		[NonSerialized]
		private Dictionary<string, ObjectiveTask> taskByIdCache;

		[NonSerialized]
		private bool taskByIdCacheInit;

		[NonSerialized]
		private HashSet<string> blockGameEventsCache;

		[NonSerialized]
		private bool blockGameEventsCacheInit;

		public string[] UnlockRoomTypes => unlockRoomTypes;

		public string[] UnlockGameEvents => unlockGameEvents;

		public string UnlockAchievementOnCompleted => unlockAchievementOnCompleted;

		public string[] TurnIntoPermanentlyHostile => turnIntoPermanentlyHostile;

		public string[] TurnIntoFullyFriendly => turnIntoFullyFriendly;

		public ObjectiveTask[] Tasks => tasks;

		public string[] BanditCamps => banditCamps;

		public int BanditCampsSpawnCount => banditCampsSpawnCount;

		public string StartEventOnCompleted => startEventOnCompleted;

		public Dictionary<string, ObjectiveTask> TaskById
		{
			get
			{
				if (!taskByIdCacheInit)
				{
					taskByIdCacheInit = true;
					taskByIdCache = new Dictionary<string, ObjectiveTask>();
					ObjectiveTask[] array = tasks;
					foreach (ObjectiveTask objectiveTask in array)
					{
						taskByIdCache.Add(objectiveTask.Id, objectiveTask);
					}
				}
				return taskByIdCache;
			}
		}

		public HashSet<string> BlockGameEvents
		{
			get
			{
				if (!blockGameEventsCacheInit)
				{
					blockGameEventsCache = new HashSet<string>();
					if (blockGameEvents != null)
					{
						blockGameEventsCache.UnionWith(blockGameEvents);
					}
					blockGameEventsCacheInit = true;
				}
				return blockGameEventsCache;
			}
		}

		public bool BypassBlockingEvents => bypassBlockingEvents;

		public IntRange BanditCampDurationRangeHours => banditCampDurationRangeHours;

		public string BanditCampPrefabAddress => banditCampPrefabAddress;

		public bool HideInScenario => hideInScenario;

		public string GameOverEventImage => gameOverEventImage;

		public string GetNameLocalized()
		{
			return LocKeyUtils.GetName(locKeys).ToLocalized();
		}

		public string GetTooltipLocalized()
		{
			return LocKeyUtils.GetDescription(locKeys).ToLocalized();
		}

		public string GetInfoLocalized()
		{
			return LocKeyUtils.GetInfo(locKeys).ToLocalized();
		}

		public override string GetID()
		{
			return id;
		}

		public override string ToString()
		{
			return id;
		}
	}
}
