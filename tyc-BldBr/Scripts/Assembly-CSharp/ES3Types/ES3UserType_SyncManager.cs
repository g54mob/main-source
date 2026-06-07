using System;
using System.Collections.Generic;
using CTS;
using CTS.Core;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_SyncManager : ES3ComponentType
	{
		[Serializable]
		public struct SyncData
		{
			public Dictionary<StringKey, bool> SyncedBools;

			public Dictionary<StringKey, int> SyncedInts;

			public Dictionary<StringKey, float> SyncedFloats;

			public SyncData(SyncManager.SyncData data)
			{
				SyncedBools = data.SyncedBools.Copy();
				SyncedInts = data.SyncedInts.Copy();
				SyncedFloats = data.SyncedFloats.Copy();
			}
		}

		public static ES3Type Instance;

		public ES3UserType_SyncManager()
			: base(typeof(SyncManager))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			SyncManager obj2 = (SyncManager)obj;
			Dictionary<StringKey, SyncData> dictionary = new Dictionary<StringKey, SyncData>();
			foreach (KeyValuePair<StringKey, SyncManager.SyncData> syncedDatum in obj2.SyncedData)
			{
				syncedDatum.Deconstruct(out var key, out var value);
				StringKey key2 = key;
				SyncManager.SyncData data = value;
				dictionary[key2] = new SyncData(data);
			}
			writer.WriteProperty("SyncData", dictionary);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			SyncManager syncManager = (SyncManager)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "SyncData")
				{
					foreach (KeyValuePair<StringKey, SyncData> item in reader.Read<Dictionary<StringKey, SyncData>>())
					{
						item.Deconstruct(out var key, out var value);
						StringKey cat = key;
						SyncData syncData = value;
						SyncManager.SyncData category = syncManager.GetCategory(cat);
						reader.SetPrivateField("_syncedBools", syncData.SyncedBools, category);
						reader.SetPrivateField("_syncedInts", syncData.SyncedInts, category);
						reader.SetPrivateField("_syncedFloats", syncData.SyncedFloats, category);
					}
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
