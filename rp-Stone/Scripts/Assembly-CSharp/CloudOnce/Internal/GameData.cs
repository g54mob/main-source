using System.Collections.Generic;
using CloudOnce.Internal.Utils;

namespace CloudOnce.Internal
{
	public class GameData
	{
		private const string oldSyncableItemsKey = "SIs";

		private const string oldSyncableCurrenciesKey = "SCs";

		private const string syncableItemsKey = "i";

		private const string syncableCurrenciesKey = "c";

		public Dictionary<string, SyncableItem> SyncableItems { get; set; }

		public Dictionary<string, SyncableCurrency> SyncableCurrencies { get; set; }

		public bool IsDirty { get; set; }

		public GameData()
		{
			SyncableItems = new Dictionary<string, SyncableItem>();
			SyncableCurrencies = new Dictionary<string, SyncableCurrency>();
		}

		public GameData(string serializedData)
		{
			if (string.IsNullOrEmpty(serializedData))
			{
				SyncableItems = new Dictionary<string, SyncableItem>();
				SyncableCurrencies = new Dictionary<string, SyncableCurrency>();
				return;
			}
			JSONObject jSONObject = new JSONObject(serializedData);
			string alias = CloudOnceUtils.GetAlias(typeof(GameData).Name, jSONObject, "i", "SIs");
			string alias2 = CloudOnceUtils.GetAlias(typeof(GameData).Name, jSONObject, "c", "SCs");
			SyncableItems = JsonHelper.Convert<Dictionary<string, SyncableItem>>(jSONObject[alias]);
			SyncableCurrencies = JsonHelper.Convert<Dictionary<string, SyncableCurrency>>(jSONObject[alias2]);
		}

		public string[] GetAllKeys()
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, SyncableItem> syncableItem in SyncableItems)
			{
				list.Add(syncableItem.Key);
			}
			foreach (KeyValuePair<string, SyncableCurrency> syncableCurrency in SyncableCurrencies)
			{
				list.Add(syncableCurrency.Key);
			}
			return list.ToArray();
		}

		public string Serialize()
		{
			JSONObject jSONObject = new JSONObject(JSONObject.Type.Object);
			jSONObject.AddField("i", JsonHelper.ToJsonObject(SyncableItems));
			jSONObject.AddField("c", JsonHelper.ToJsonObject(SyncableCurrencies));
			return jSONObject.ToString();
		}

		public string[] MergeWith(GameData otherData)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, SyncableItem> syncableItem2 in otherData.SyncableItems)
			{
				if (SyncableItems.TryGetValue(syncableItem2.Key, out var value))
				{
					SyncableItem syncableItem = ConflictResolver.ResolveConflict(value, syncableItem2.Value);
					if (!syncableItem.Equals(value))
					{
						SyncableItems[syncableItem2.Key] = syncableItem;
						list.Add(syncableItem2.Key);
					}
				}
				else
				{
					SyncableItems.Add(syncableItem2.Key, syncableItem2.Value);
					list.Add(syncableItem2.Key);
				}
			}
			foreach (KeyValuePair<string, SyncableCurrency> syncableCurrency in otherData.SyncableCurrencies)
			{
				if (SyncableCurrencies.TryGetValue(syncableCurrency.Key, out var value2))
				{
					if (value2.MergeWith(syncableCurrency.Value))
					{
						list.Add(syncableCurrency.Key);
					}
				}
				else
				{
					SyncableCurrencies.Add(syncableCurrency.Key, syncableCurrency.Value);
					list.Add(syncableCurrency.Key);
				}
			}
			return list.ToArray();
		}
	}
}
