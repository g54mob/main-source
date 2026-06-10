using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.State;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("GameEventPhaseBase", "")]
	public abstract class GameEventPhaseBase : IFVSerializable, IPauseGame
	{
		protected static FVLogger Logger => GameEventInstance.Logger;

		protected GameEventInstance EventInstance { get; private set; }

		protected GameEvent Blueprint => EventInstance?.Blueprint;

		protected List<string> WarningTooltipPrefixLines => EventInstance.WarningTooltipPrefixLines;

		protected static WorldDate DateTime
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return null;
				}
				return GlobalSaveController.CurrentVillageData.DateAndTime;
			}
		}

		protected static int MinutesInHour => DateTime.MinutesInHour;

		protected static long CurrentTimeMinutes => DateTime.MinutesTotal;

		protected GameEventPhaseBase()
		{
		}

		public void InitEventInstance(GameEventInstance eventInstance)
		{
			if (EventInstance != null)
			{
				throw new Exception("Tried to set event instance, but it is already set");
			}
			EventInstance = eventInstance;
		}

		public virtual bool OnStart()
		{
			return true;
		}

		public virtual void OnLoaded(bool fromSave)
		{
		}

		public virtual void OnEnd()
		{
		}

		public virtual GameEventPhaseBase Tick()
		{
			return null;
		}

		protected void RefreshWarningTooltip()
		{
			EventInstance.UpdateWarningMessageTooltip();
		}

		protected void VerifyEventImplements<T>()
		{
			if (!(EventInstance is T))
			{
				throw new Exception("Event '" + EventInstance.GetType().Name + "' is incompatible with phase '" + GetType().Name + "'. It needs to implement interface '" + typeof(T).Name + "'.");
			}
		}

		public override string ToString()
		{
			return GetType().Name ?? "";
		}

		public virtual void Dispose()
		{
			EventInstance = null;
		}

		protected static FactionInstance GetFactionInstanceByBlueprintId(string blueprintId)
		{
			return GlobalSaveController.CurrentVillageData.WorldMapData.FactionInstances.FirstOrDefault((FactionInstance f) => f.BlueprintId == blueprintId);
		}

		public virtual void Serialize(FVSerializer serializer)
		{
		}

		public GameEventPhaseBase(FVDeserializer deserializer)
		{
		}
	}
}
