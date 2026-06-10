using System;
using NSEipix.Base;
using NSMedieval.Serialization;
using Raid.Config;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("LastRaidInfo", "")]
	public class LastRaidInfo : IFVSerializable
	{
		public enum RaidVariation
		{
			None = 0,
			Basic = 1,
			Archers = 2,
			HeavyUnits = 3,
			SiegeWeaponRaid = 4,
			Siege = 5
		}

		[SerializeField]
		private RaidVariation variation;

		[SerializeField]
		private bool firstRaid = true;

		[SerializeField]
		private bool isMeleeDamageTaken;

		[SerializeField]
		private bool isDoorDamageTaken;

		[SerializeField]
		private bool isDoorDestroyed;

		[SerializeField]
		private bool hasDoor;

		[SerializeField]
		private bool hasHeavyUnit;

		[SerializeField]
		private int noMeleeDamageInRow;

		[SerializeField]
		private int victoriesInRow;

		public RaidVariation Variation
		{
			get
			{
				return variation;
			}
			set
			{
				variation = value;
			}
		}

		public bool FirstRaid
		{
			get
			{
				return firstRaid;
			}
			set
			{
				firstRaid = value;
			}
		}

		public bool IsMeleeDamageTaken
		{
			get
			{
				return isMeleeDamageTaken;
			}
			set
			{
				isMeleeDamageTaken = value;
			}
		}

		public bool IsDoorDamageTaken
		{
			get
			{
				return isDoorDamageTaken;
			}
			set
			{
				isDoorDamageTaken = value;
			}
		}

		public bool IsDoorDestroyed
		{
			get
			{
				return isDoorDestroyed;
			}
			set
			{
				isDoorDestroyed = value;
			}
		}

		public bool HasDoor
		{
			get
			{
				return hasDoor;
			}
			set
			{
				hasDoor = value;
			}
		}

		public bool HasHeavyUnit
		{
			get
			{
				return hasHeavyUnit;
			}
			set
			{
				hasHeavyUnit = value;
			}
		}

		public int NoMeleeDamageInRow
		{
			get
			{
				return noMeleeDamageInRow;
			}
			set
			{
				noMeleeDamageInRow = value;
			}
		}

		public int VictoriesInRow
		{
			get
			{
				return victoriesInRow;
			}
			set
			{
				victoriesInRow = value;
			}
		}

		public bool ShouldForceSiegeWeaponRaid
		{
			get
			{
				if ((int)GlobalSaveController.CurrentVillageData.GameParametersCurrent.GetById("enemiesHaveTrebuchet") == 1)
				{
					return victoriesInRow >= SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>.I.SiegeVictoriesInRowCount;
				}
				return false;
			}
		}

		public LastRaidInfo()
		{
		}

		public void Reset()
		{
			IsMeleeDamageTaken = false;
			IsDoorDamageTaken = false;
			IsDoorDestroyed = false;
			HasDoor = false;
			HasHeavyUnit = false;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("variation", variation.ToString());
			serializer.Write("firstRaid", firstRaid);
			serializer.Write("isMeleeDamageTaken", isMeleeDamageTaken);
			serializer.Write("isDoorDamageTaken", isDoorDamageTaken);
			serializer.Write("isDoorDestroyed", isDoorDestroyed);
			serializer.Write("hasDoor", hasDoor);
			serializer.Write("hasHeavyUnit", hasHeavyUnit);
			serializer.Write("noMeleeDamageInRow", noMeleeDamageInRow);
		}

		public LastRaidInfo(FVDeserializer deserializer)
		{
			Enum.TryParse<RaidVariation>(deserializer.ReadString("variation"), out variation);
			firstRaid = deserializer.ReadBool("firstRaid");
			isMeleeDamageTaken = deserializer.ReadBool("isMeleeDamageTaken");
			isDoorDamageTaken = deserializer.ReadBool("isDoorDamageTaken");
			isDoorDestroyed = deserializer.ReadBool("isDoorDestroyed");
			hasDoor = deserializer.ReadBool("hasDoor");
			hasHeavyUnit = deserializer.ReadBool("hasHeavyUnit");
			noMeleeDamageInRow = deserializer.ReadInt("noMeleeDamageInRow");
		}
	}
}
