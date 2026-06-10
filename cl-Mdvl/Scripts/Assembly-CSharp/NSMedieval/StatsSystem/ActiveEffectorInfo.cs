using System;
using FoxyVoxel.Logging;
using NSEipix.Repository;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("ActiveEffectorInfo", "")]
	public struct ActiveEffectorInfo : IFVSerializable
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private long startTime;

		[SerializeField]
		private int stackCount;

		[SerializeField]
		private string category;

		[SerializeField]
		private float duration;

		[SerializeField]
		private float durationModifier;

		[SerializeField]
		private WoundEffectorInfo woundInfo;

		[NonSerialized]
		private StatEffector blueprint;

		public string Name => name;

		public long StartTime => startTime;

		public int StackCount => stackCount;

		public string Category => category;

		public float DurationUnmodified => duration;

		public float DurationModifier => durationModifier;

		public float Duration => duration * durationModifier;

		public float DurationMinutes => Duration * (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;

		public WoundEffectorInfo WoundInfo => woundInfo;

		public StatEffector Blueprint
		{
			get
			{
				blueprint = ((blueprint == null) ? Repository<EffectorRepository, StatEffector>.Instance.GetByID(name) : blueprint);
				return blueprint;
			}
		}

		public ActiveEffectorInfo(StatEffector blueprint, string category, int stackCount = 0, long startTime = 0L, float duration = 0f, float durationModifier = 1f, WoundEffectorInfo woundInfo = null)
		{
			name = blueprint.GetID();
			this.category = category;
			this.startTime = startTime;
			this.stackCount = stackCount;
			this.duration = duration;
			this.blueprint = blueprint;
			this.durationModifier = durationModifier;
			this.woundInfo = null;
			if (woundInfo != null)
			{
				this.woundInfo = woundInfo;
				if (this.woundInfo.Blueprint == null || name == null)
				{
					Log.Error("Wound effector error! If you see this, give me the stack trace", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\ActiveEffectorInfo.cs");
				}
			}
			else if (blueprint is StatEffectorWound statEffectorWound)
			{
				this.woundInfo = new WoundEffectorInfo(statEffectorWound);
				if (this.woundInfo.Blueprint == null || name == null)
				{
					Log.Error("Wound effector error! If you see this, give me the stack trace", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\ActiveEffectorInfo.cs");
				}
			}
		}

		public ActiveEffectorInfo(ActiveEffectorInfo effector, long startTime)
		{
			name = effector.Name;
			category = effector.Category;
			this.startTime = startTime;
			stackCount = effector.StackCount;
			duration = effector.Duration;
			blueprint = effector.Blueprint;
			durationModifier = effector.DurationModifier;
			woundInfo = effector.WoundInfo;
		}

		public float TimeLeft()
		{
			if (Duration <= 0f)
			{
				return -1f;
			}
			return DurationMinutes - (float)(GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal - StartTime);
		}

		public float ExpirationPercentage()
		{
			if (Duration <= 0f)
			{
				return 0f;
			}
			return (float)(GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal - StartTime) / DurationMinutes;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("name", name);
			serializer.Write("startTime", startTime);
			serializer.Write("stackCount", stackCount);
			serializer.Write("category", category);
			serializer.Write("duration", duration);
			serializer.Write("durationModifier", durationModifier);
			serializer.Write("woundInfo", woundInfo);
		}

		public ActiveEffectorInfo(FVDeserializer deserializer)
		{
			name = deserializer.ReadString("name");
			startTime = deserializer.ReadLong("startTime", 0L);
			stackCount = deserializer.ReadInt("stackCount");
			category = deserializer.ReadString("category");
			duration = deserializer.ReadFloat("duration");
			durationModifier = deserializer.ReadFloat("durationModifier");
			woundInfo = deserializer.ReadObject<WoundEffectorInfo>("woundInfo");
			blueprint = null;
		}
	}
}
