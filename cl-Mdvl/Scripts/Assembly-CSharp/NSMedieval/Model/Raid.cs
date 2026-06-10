using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.GameEventSystem;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("Raid", "")]
	public class Raid : NSEipix.Base.Model, IFVSerializable
	{
		[Serializable]
		[FVSerializableKey("RaidEnemyInfo", "")]
		public class RaidEnemyInfo : IFVSerializable
		{
			[SerializeField]
			private string name;

			public string Name
			{
				get
				{
					return name;
				}
				set
				{
					name = value;
				}
			}

			public RaidEnemyInfo()
			{
			}

			public RaidEnemyInfo(IEnemyPurchaseUnit enemy)
			{
				name = enemy.GetID();
			}

			public void Serialize(FVSerializer serializer)
			{
				serializer.Write("name", name);
			}

			public RaidEnemyInfo(FVDeserializer deserializer)
			{
				name = deserializer.ReadString("name");
			}
		}

		[SerializeField]
		private string id;

		[SerializeField]
		private int raidID;

		[SerializeField]
		private RaidEnemyInfo[] enemies;

		[SerializeField]
		private string equipmentGroup;

		[SerializeField]
		private bool isSiege;

		[SerializeField]
		private float femaleEnemiesPercent;

		[SerializeField]
		private long delayBeforeAttack = 45L;

		[SerializeField]
		private int dontEngageCombatDuration = 200;

		public SiegeWeaponComponentBlueprint[] SiegeWeapons { get; set; }

		public bool IsSiege => isSiege;

		public float FemaleEnemiesPercent
		{
			get
			{
				return femaleEnemiesPercent;
			}
			set
			{
				femaleEnemiesPercent = value;
			}
		}

		public int DontEngageCombatDuration => dontEngageCombatDuration;

		public RaidEnemyInfo[] Enemies
		{
			get
			{
				return enemies;
			}
			set
			{
				enemies = value;
			}
		}

		public string EquipmentGroup
		{
			get
			{
				return equipmentGroup;
			}
			set
			{
				equipmentGroup = value;
			}
		}

		public int RaidID => raidID;

		public long DelayBeforeAttack
		{
			get
			{
				return delayBeforeAttack;
			}
			set
			{
				delayBeforeAttack = value;
			}
		}

		public Raid()
		{
		}

		public Raid(int id, bool isSiege, long delayBeforeAttack, int dontEngageCombatDuration)
		{
			this.id = id.ToString();
			raidID = id;
			this.isSiege = isSiege;
			this.delayBeforeAttack = delayBeforeAttack;
			this.dontEngageCombatDuration = dontEngageCombatDuration;
		}

		public override string GetID()
		{
			return id;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("raidID", raidID);
			serializer.Write("enemies", enemies);
			serializer.Write("equipmentGroup", equipmentGroup);
			serializer.Write("isSiege", isSiege);
			serializer.Write("femaleEnemiesPercent", femaleEnemiesPercent);
			serializer.Write("delayBeforeAttack", delayBeforeAttack);
			serializer.Write("dontEngageCombatDuration", dontEngageCombatDuration);
			serializer.WriteBlueprintIds("siegeWeapons", SiegeWeapons);
		}

		public Raid(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			raidID = deserializer.ReadInt("raidID");
			enemies = deserializer.ReadObjectArray<RaidEnemyInfo>("enemies");
			equipmentGroup = deserializer.ReadString("equipmentGroup");
			isSiege = deserializer.ReadBool("isSiege");
			femaleEnemiesPercent = deserializer.ReadFloat("femaleEnemiesPercent");
			delayBeforeAttack = deserializer.ReadLong("delayBeforeAttack", 0L);
			dontEngageCombatDuration = deserializer.ReadInt("dontEngageCombatDuration");
			SiegeWeapons = deserializer.ReadIdsToBlueprints("siegeWeapons", Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID, new List<SiegeWeaponComponentBlueprint>()).ToArray();
		}
	}
}
