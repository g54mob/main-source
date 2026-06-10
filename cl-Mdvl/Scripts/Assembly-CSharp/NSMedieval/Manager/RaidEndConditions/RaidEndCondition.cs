using System;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.Village.Map;

namespace NSMedieval.Manager.RaidEndConditions
{
	[FVSerializableKey("RaidEndCondition", "")]
	public abstract class RaidEndCondition : IFVSerializable, IDisposable
	{
		public abstract bool ShouldEnd { get; }

		protected VillageMap Map { get; private set; }

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

		private RaidEndCondition()
		{
		}

		protected RaidEndCondition(ActiveRaidInfo raid)
			: this()
		{
			Map = raid.Map;
		}

		public virtual void InitAfterLoad()
		{
		}

		public virtual void Dispose()
		{
			Map = null;
		}

		public virtual void Serialize(FVSerializer serializer)
		{
		}

		public RaidEndCondition(FVDeserializer deserializer)
			: this()
		{
		}
	}
}
