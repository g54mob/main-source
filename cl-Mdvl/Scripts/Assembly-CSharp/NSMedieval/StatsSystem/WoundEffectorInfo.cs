using System;
using NSEipix.Repository;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("WoundEffectorInfo", "")]
	public class WoundEffectorInfo : IFVSerializable
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private float minSeverity;

		[SerializeField]
		private float currentSeverity;

		[SerializeField]
		private bool needTend;

		[SerializeField]
		private bool needRest;

		[SerializeField]
		private long lastTendTime = long.MaxValue;

		[SerializeField]
		private float lastTendQuality;

		[SerializeField]
		private long lastTickTime;

		[NonSerialized]
		private StatEffectorWound blueprint;

		public float CurrentSeverity
		{
			get
			{
				return currentSeverity;
			}
			set
			{
				currentSeverity = value;
			}
		}

		public float MinSeverity => minSeverity;

		public bool NeedTend
		{
			get
			{
				return needTend;
			}
			set
			{
				needTend = value;
			}
		}

		public bool NeedRest
		{
			get
			{
				return needRest;
			}
			set
			{
				needRest = value;
			}
		}

		public long LastTickTime
		{
			get
			{
				return lastTickTime;
			}
			set
			{
				lastTickTime = value;
			}
		}

		public long LastTendTime => lastTendTime;

		public float LastTendQuality
		{
			get
			{
				if (!needTend)
				{
					return 1f;
				}
				return lastTendQuality;
			}
		}

		public StatEffectorWound Blueprint
		{
			get
			{
				blueprint = blueprint ?? ((name != null) ? Repository<WoundsRepository, StatEffectorWound>.Instance.GetByID(name) : null);
				return blueprint;
			}
		}

		public WoundEffectorInfo(StatEffectorWound blueprint)
		{
			name = blueprint.GetID();
			minSeverity = blueprint.SeverityMin;
			currentSeverity = blueprint.Severity;
			needTend = blueprint.NeedTend;
			needRest = blueprint.NeedRest;
			this.blueprint = blueprint;
			lastTickTime = 0L;
		}

		public float TimeLeftUntilHealed()
		{
			return 0f;
		}

		public void TendWound(float tendQuality)
		{
			lastTendTime = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
			lastTendQuality = tendQuality;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("name", name);
			serializer.Write("minSeverity", minSeverity);
			serializer.Write("currentSeverity", currentSeverity);
			serializer.Write("needTend", needTend);
			serializer.Write("needRest", needRest);
			serializer.Write("lastTendTime", lastTendTime);
			serializer.Write("lastTendQuality", lastTendQuality);
			serializer.Write("lastTickTime", lastTickTime);
		}

		public WoundEffectorInfo(FVDeserializer deserializer)
		{
			name = deserializer.ReadString("name");
			minSeverity = deserializer.ReadFloat("minSeverity");
			currentSeverity = deserializer.ReadFloat("currentSeverity");
			needTend = deserializer.ReadBool("needTend");
			needRest = deserializer.ReadBool("needRest");
			lastTendTime = deserializer.ReadLong("lastTendTime", 0L);
			lastTendQuality = deserializer.ReadFloat("lastTendQuality");
			lastTickTime = deserializer.ReadLong("lastTickTime", 0L);
		}
	}
}
