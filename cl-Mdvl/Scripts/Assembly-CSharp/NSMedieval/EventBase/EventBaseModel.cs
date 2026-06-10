using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.GameEventSystem;
using NSMedieval.Model;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.EventBase
{
	public class EventBaseModel : NSEipix.Base.Model
	{
		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string className;

		[SerializeField]
		private List<GameEvent.DialogContent> dialogs;

		[SerializeField]
		private float eventDurationHours;

		[SerializeField]
		private float gatheringTimeoutHours;

		[SerializeField]
		protected string id = string.Empty;

		[SerializeField]
		private bool locked;

		public string ClassName => className;

		public float EventDurationHours => eventDurationHours;

		public float GatheringTimeoutHours => gatheringTimeoutHours;

		public List<GameEvent.DialogContent> Dialogs => dialogs ?? (dialogs = new List<GameEvent.DialogContent>());

		public LocKeys[] LocKeys => locKeys;

		public bool Lockable => locked;

		public bool IsLocked()
		{
			if (!locked)
			{
				return false;
			}
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated())
			{
				return true;
			}
			return !MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.UnlockedGameEvents.Contains(id);
		}

		public bool Unlock()
		{
			if (!locked)
			{
				return false;
			}
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated())
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(59, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\EventBase\\EventBaseModel.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to unlock event ");
					messageBuilder.AppendFormatted(GetID());
					messageBuilder.AppendLiteral(" while WorldMap was not instantiated.");
				}
				Log.Error(messageBuilder);
				return false;
			}
			bool num = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.UnlockedGameEvents.Add(GetID());
			if (num)
			{
				MonoSingleton<GameEventSystemController>.Instance.GameEventUnlocked(this);
			}
			return num;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
