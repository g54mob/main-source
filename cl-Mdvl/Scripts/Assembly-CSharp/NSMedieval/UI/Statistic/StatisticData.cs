using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.UI.Statistic
{
	[Serializable]
	[FVSerializableKey("StatisticData", "")]
	public class StatisticData : IFVSerializable
	{
		[SerializeField]
		private TimeSpan? inGameTime;

		[SerializeField]
		private int maxVillagers;

		[SerializeField]
		private int lostVillagers;

		[SerializeField]
		private int raidsWon;

		[SerializeField]
		private int raidsLost;

		[SerializeField]
		private int enemiesKilled;

		public TimeSpan? InGameTime
		{
			get
			{
				return inGameTime;
			}
			set
			{
				inGameTime = value;
			}
		}

		public int MaxVillagers
		{
			get
			{
				return maxVillagers;
			}
			set
			{
				maxVillagers = value;
			}
		}

		public int LostVillagers
		{
			get
			{
				return lostVillagers;
			}
			set
			{
				lostVillagers = value;
			}
		}

		public int RaidsWon
		{
			get
			{
				return raidsWon;
			}
			set
			{
				raidsWon = value;
			}
		}

		public int RaidsLost
		{
			get
			{
				return raidsLost;
			}
			set
			{
				raidsLost = value;
			}
		}

		public int EnemiesKilled
		{
			get
			{
				return enemiesKilled;
			}
			set
			{
				enemiesKilled = value;
			}
		}

		public StatisticData()
		{
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("inGameTime", inGameTime?.Ticks ?? 0);
			serializer.Write("maxVillagers", maxVillagers);
			serializer.Write("lostVillagers", lostVillagers);
			serializer.Write("raidsWon", raidsWon);
			serializer.Write("raidsLost", raidsLost);
			serializer.Write("enemiesKilled", enemiesKilled);
		}

		public StatisticData(FVDeserializer deserializer)
		{
			inGameTime = new TimeSpan(deserializer.ReadLong("inGameTime", 0L));
			maxVillagers = deserializer.ReadInt("maxVillagers");
			lostVillagers = deserializer.ReadInt("lostVillagers");
			raidsWon = deserializer.ReadInt("raidsWon");
			raidsLost = deserializer.ReadInt("raidsLost");
			enemiesKilled = deserializer.ReadInt("enemiesKilled");
		}
	}
}
