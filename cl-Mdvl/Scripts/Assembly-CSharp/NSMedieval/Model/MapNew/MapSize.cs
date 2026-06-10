using System;
using NSEipix.Base;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	[FVSerializableKey("MapSize", "")]
	public class MapSize : NSEipix.Base.Model, IFVSerializable
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private int width = 128;

		[SerializeField]
		private int height = 16;

		[SerializeField]
		private int length = 128;

		[SerializeField]
		private bool shownInRelease;

		[SerializeField]
		private int raidDelayBeforeAttack;

		[SerializeField]
		private int raidDontEngageCombatDuration;

		[SerializeField]
		private string brushType;

		[SerializeField]
		private float plantSpawnRateMultiplier;

		[SerializeField]
		private int idlePointsCountPerAnimal = 20;

		private Vec3Int size;

		private bool vectorInitialized;

		public int Width => width;

		public int Height => height;

		public int Length => length;

		public bool ShownInRelease => shownInRelease;

		public string BrushType => brushType;

		public float PlantSpawnRateMultiplier
		{
			get
			{
				if (plantSpawnRateMultiplier <= 0f)
				{
					return 1f;
				}
				return plantSpawnRateMultiplier;
			}
		}

		public int RaidDelayBeforeAttack
		{
			get
			{
				if (raidDelayBeforeAttack <= 0)
				{
					return 45;
				}
				return raidDelayBeforeAttack;
			}
		}

		public int RaidDontEngageCombatDuration
		{
			get
			{
				if (raidDontEngageCombatDuration <= 0)
				{
					return 200;
				}
				return raidDontEngageCombatDuration;
			}
		}

		public int IdlePointsCountPerAnimal
		{
			get
			{
				if (idlePointsCountPerAnimal <= 0)
				{
					return 20;
				}
				return idlePointsCountPerAnimal;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public Vec3Int Vec3Int
		{
			get
			{
				if (!vectorInitialized)
				{
					vectorInitialized = true;
					size = new Vec3Int(width, height, length);
				}
				return size;
			}
		}

		public override string GetID()
		{
			return id;
		}

		public override string ToString()
		{
			return $"{width}, {height}, {length} ({id})";
		}

		public MapSize(string id, int width, int height, int length, float plantSpawnRateMultiplier)
		{
			this.id = id;
			this.width = width;
			this.height = height;
			this.length = length;
			this.plantSpawnRateMultiplier = plantSpawnRateMultiplier;
			idlePointsCountPerAnimal = 20;
		}

		public MapSize()
		{
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("locKeys", locKeys);
			serializer.Write("width", width);
			serializer.Write("height", height);
			serializer.Write("length", length);
			serializer.Write("shownInRelease", shownInRelease);
			serializer.Write("raidDelayBeforeAttack", raidDelayBeforeAttack);
			serializer.Write("raidDontEngageCombatDuration", raidDontEngageCombatDuration);
			serializer.Write("brushType", brushType);
			serializer.Write("plantSpawnRateMultiplier", plantSpawnRateMultiplier);
			serializer.Write("idlePointsCountPerAnimal", idlePointsCountPerAnimal);
		}

		public MapSize(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			locKeys = deserializer.ReadObjectArray<LocKeys>("locKeys");
			width = deserializer.ReadInt("width");
			height = deserializer.ReadInt("height");
			length = deserializer.ReadInt("length");
			shownInRelease = deserializer.ReadBool("shownInRelease");
			raidDelayBeforeAttack = deserializer.ReadInt("raidDelayBeforeAttack");
			raidDontEngageCombatDuration = deserializer.ReadInt("raidDontEngageCombatDuration");
			brushType = deserializer.ReadString("brushType");
			plantSpawnRateMultiplier = deserializer.ReadFloat("plantSpawnRateMultiplier");
			idlePointsCountPerAnimal = deserializer.ReadInt("idlePointsCountPerAnimal");
		}
	}
}
