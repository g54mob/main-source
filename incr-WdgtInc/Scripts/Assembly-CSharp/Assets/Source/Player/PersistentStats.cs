using System;
using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using LightJson;

namespace Assets.Source.Player
{
	public class PersistentStats : IJsonSource
	{
		public int PlayTime;

		public BigInteger ItemsProduced;

		public BigInteger ItemsHandcrafted;

		public BigInteger[] ProductionPerItem = new BigInteger[ItemType.Count];

		public int[] Benchmarks = new int[12];

		public int RocketSiloTime;

		public int RocketLaunchedTime;

		public void AddTimePlayed(int seconds)
		{
			PlayTime += seconds;
		}

		public void AddItemCrafted(ItemType type, BigInteger count, bool handCrafted)
		{
			ProductionPerItem[type.Ordinal] += count;
			if (type != ItemType.Power)
			{
				if (handCrafted)
				{
					ItemsHandcrafted += count;
				}
				else
				{
					ItemsProduced += count;
				}
			}
		}

		public void AddTierBenchmark(int tier, int time)
		{
			if (Benchmarks[tier - 1] == 0)
			{
				Benchmarks[tier - 1] = time;
			}
			else
			{
				Benchmarks[tier - 1] = Math.Min(time, Benchmarks[tier - 1]);
			}
		}

		public JsonValue ToJson()
		{
			JsonObject jsonObject = new JsonObject();
			jsonObject["PlayTime"] = PlayTime;
			jsonObject["ItemsProduced"] = ItemsProduced.ToString();
			jsonObject["ItemsHandcrafted"] = ItemsHandcrafted.ToString();
			jsonObject["RocketSiloTime"] = RocketSiloTime;
			jsonObject["RocketLaunchedTime"] = RocketLaunchedTime;
			JsonArray jsonArray = new JsonArray();
			for (int i = 0; i < Benchmarks.Length; i++)
			{
				jsonArray.Add(Benchmarks[i]);
			}
			jsonObject["Benchmarks"] = jsonArray;
			JsonObject jsonObject2 = new JsonObject();
			for (int j = 0; j < ProductionPerItem.Length; j++)
			{
				jsonObject2.Add(ItemType.Get(j), ProductionPerItem[j].ToString());
			}
			jsonObject["ProductionPerItem"] = jsonObject2;
			return jsonObject;
		}

		public void FromJson(JsonObject obj)
		{
			if (obj == null)
			{
				return;
			}
			PlayTime = obj["PlayTime"];
			RocketSiloTime = obj["RocketSiloTime"];
			RocketLaunchedTime = obj["RocketLaunchedTime"];
			ItemsProduced = BigInteger.Parse(obj["ItemsProduced"].AsString ?? "0");
			ItemsHandcrafted = BigInteger.Parse(obj["ItemsHandcrafted"].AsString ?? "0");
			int num = 0;
			foreach (JsonValue item in obj["Benchmarks"].AsJsonArray ?? new JsonArray())
			{
				Benchmarks[num] = item;
				num++;
			}
			foreach (KeyValuePair<string, JsonValue> item2 in obj["ProductionPerItem"].AsJsonObject)
			{
				ProductionPerItem[ItemType.Get(item2.Key).Ordinal] = BigInteger.Parse(item2.Value.AsString ?? "0");
			}
		}
	}
}
