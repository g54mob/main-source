using System;
using System.Collections.Generic;
using System.Globalization;
using CloudOnce.Internal.Utils;
using UnityEngine;

namespace CloudOnce.Internal
{
	public static class DataManager
	{
		public const string DevStringKey = "CloudOnceDevString";

		private static Dictionary<string, IPersistent> s_cloudPrefs;

		private static GameData s_localGameData = new GameData();

		private static bool s_isInitialized;

		public static bool IsLocalDataDirty
		{
			get
			{
				return s_localGameData.IsDirty;
			}
			set
			{
				s_localGameData.IsDirty = value;
			}
		}

		public static Dictionary<string, IPersistent> CloudPrefs => s_cloudPrefs ?? (s_cloudPrefs = new Dictionary<string, IPersistent>());

		public static void InitDataManager()
		{
			if (!s_isInitialized)
			{
				LoadFromDisk();
				s_isInitialized = true;
			}
		}

		public static void SetCurrencyValues(string key, Dictionary<string, CurrencyValue> currencyValues)
		{
			if (!s_localGameData.SyncableCurrencies.ContainsKey(key))
			{
				s_localGameData.SyncableCurrencies.Add(key, new SyncableCurrency(key));
			}
			s_localGameData.SyncableCurrencies[key].DeviceCurrencyValues = currencyValues;
			IsLocalDataDirty = true;
		}

		public static void SetBool(string key, bool value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.Bool, persistenceType);
				SyncableItem value2 = new SyncableItem(value.ToString(), metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.Bool)
			{
				s_localGameData.SyncableItems[key].ValueString = (value ? 1.ToString(CultureInfo.InvariantCulture) : 0.ToString(CultureInfo.InvariantCulture));
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(bool));
		}

		public static void SetInt(string key, int value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.Int, persistenceType);
				SyncableItem value2 = new SyncableItem(value.ToString(CultureInfo.InvariantCulture), metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.Int)
			{
				s_localGameData.SyncableItems[key].ValueString = value.ToString(CultureInfo.InvariantCulture);
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(int));
		}

		public static void SetUInt(string key, uint value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.UInt, persistenceType);
				SyncableItem value2 = new SyncableItem(value.ToString(CultureInfo.InvariantCulture), metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.UInt)
			{
				s_localGameData.SyncableItems[key].ValueString = value.ToString(CultureInfo.InvariantCulture);
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(uint));
		}

		public static void SetFloat(string key, float value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.Float, persistenceType);
				SyncableItem value2 = new SyncableItem(value.ToString("R", CultureInfo.InvariantCulture), metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.Float)
			{
				s_localGameData.SyncableItems[key].ValueString = value.ToString("R", CultureInfo.InvariantCulture);
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(float));
		}

		public static void SetDouble(string key, double value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.Double, persistenceType);
				SyncableItem value2 = new SyncableItem(value.ToString("R", CultureInfo.InvariantCulture), metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.Double)
			{
				s_localGameData.SyncableItems[key].ValueString = value.ToString("R", CultureInfo.InvariantCulture);
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(double));
		}

		public static void SetString(string key, string value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.String, persistenceType);
				SyncableItem value2 = new SyncableItem(value, metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.String)
			{
				s_localGameData.SyncableItems[key].ValueString = value;
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(string));
		}

		public static void SetLong(string key, long value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.Long, persistenceType);
				SyncableItem value2 = new SyncableItem(value.ToString(CultureInfo.InvariantCulture), metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.Long)
			{
				s_localGameData.SyncableItems[key].ValueString = value.ToString(CultureInfo.InvariantCulture);
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(long));
		}

		public static void SetDateTime(string key, DateTime value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.Long, persistenceType);
				SyncableItem value2 = new SyncableItem(value.ToBinary().ToString(CultureInfo.InvariantCulture), metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.Long)
			{
				s_localGameData.SyncableItems[key].ValueString = value.ToBinary().ToString(CultureInfo.InvariantCulture);
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(long));
		}

		public static void SetDecimal(string key, decimal value, PersistenceType persistenceType)
		{
			if (!s_localGameData.SyncableItems.ContainsKey(key))
			{
				SyncableItemMetaData metadata = new SyncableItemMetaData(DataType.Decimal, persistenceType);
				SyncableItem value2 = new SyncableItem(value.ToString(CultureInfo.InvariantCulture), metadata);
				s_localGameData.SyncableItems.Add(key, value2);
				IsLocalDataDirty = true;
			}
			if (s_localGameData.SyncableItems[key].Metadata.DataType == DataType.Decimal)
			{
				s_localGameData.SyncableItems[key].ValueString = value.ToString(CultureInfo.InvariantCulture);
				IsLocalDataDirty = true;
				return;
			}
			throw new UnexpectedCollectionElementTypeException(key, typeof(decimal));
		}

		public static Dictionary<string, CurrencyValue> GetCurrencyValues(string key)
		{
			if (!s_localGameData.SyncableCurrencies.TryGetValue(key, out var value))
			{
				return null;
			}
			return value.DeviceCurrencyValues;
		}

		public static bool GetBool(string key, bool defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.Bool)
				{
					if (int.TryParse(value.ValueString, out var result))
					{
						return result == 1;
					}
					return Convert.ToBoolean(value.ValueString, CultureInfo.InvariantCulture);
				}
				throw new UnexpectedCollectionElementTypeException(key, typeof(bool));
			}
			return defaultValue;
		}

		public static int GetInt(string key, int defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.Int)
				{
					return Convert.ToInt32(value.ValueString);
				}
				throw new UnexpectedCollectionElementTypeException(key, typeof(int));
			}
			return defaultValue;
		}

		public static uint GetUInt(string key, uint defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.UInt)
				{
					return Convert.ToUInt32(value.ValueString, CultureInfo.InvariantCulture);
				}
				return 0u;
			}
			return defaultValue;
		}

		public static float GetFloat(string key, float defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.Float)
				{
					return Convert.ToSingle(value.ValueString, CultureInfo.InvariantCulture);
				}
				throw new UnexpectedCollectionElementTypeException(key, typeof(float));
			}
			return defaultValue;
		}

		public static double GetDouble(string key, double defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.Double)
				{
					return Convert.ToDouble(value.ValueString, CultureInfo.InvariantCulture);
				}
				throw new UnexpectedCollectionElementTypeException(key, typeof(double));
			}
			return defaultValue;
		}

		public static string GetString(string key, string defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.String)
				{
					return value.ValueString;
				}
				throw new UnexpectedCollectionElementTypeException(key, typeof(string));
			}
			return defaultValue;
		}

		public static long GetLong(string key, long defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.Long)
				{
					return Convert.ToInt64(value.ValueString, CultureInfo.InvariantCulture);
				}
				throw new UnexpectedCollectionElementTypeException(key, typeof(long));
			}
			return defaultValue;
		}

		public static DateTime GetDateTime(string key, DateTime defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.Long)
				{
					return DateTime.FromBinary(Convert.ToInt64(value.ValueString, CultureInfo.InvariantCulture));
				}
				throw new UnexpectedCollectionElementTypeException(key, typeof(long));
			}
			return defaultValue;
		}

		public static decimal GetDecimal(string key, decimal defaultValue)
		{
			if (s_localGameData.SyncableItems.TryGetValue(key, out var value))
			{
				if (value.Metadata.DataType == DataType.Decimal)
				{
					return Convert.ToDecimal(value.ValueString, CultureInfo.InvariantCulture);
				}
				throw new UnexpectedCollectionElementTypeException(key, typeof(decimal));
			}
			return defaultValue;
		}

		public static void RefreshCloudValues()
		{
			foreach (KeyValuePair<string, IPersistent> cloudPref in CloudPrefs)
			{
				cloudPref.Value.Load();
			}
		}

		public static void ResetSyncableCurrency(string key)
		{
			if (!s_localGameData.SyncableCurrencies.ContainsKey(key))
			{
				s_localGameData.SyncableCurrencies.Add(key, new SyncableCurrency(key));
			}
			else
			{
				s_localGameData.SyncableCurrencies[key].ResetCurrency();
			}
			IsLocalDataDirty = true;
		}

		public static bool ResetCloudPref(string key)
		{
			if (CloudPrefs.ContainsKey(key))
			{
				CloudPrefs[key].Reset();
				return true;
			}
			return false;
		}

		public static bool DeleteCloudPref(string key)
		{
			if (s_localGameData.SyncableItems.ContainsKey(key))
			{
				s_localGameData.SyncableItems.Remove(key);
				return true;
			}
			if (s_localGameData.SyncableCurrencies.ContainsKey(key))
			{
				s_localGameData.SyncableCurrencies.Remove(key);
				return true;
			}
			return false;
		}

		public static string[] ResetAllData()
		{
			foreach (KeyValuePair<string, IPersistent> cloudPref in CloudPrefs)
			{
				cloudPref.Value.Reset();
			}
			return s_localGameData.GetAllKeys();
		}

		public static void DeleteAllCloudVariables()
		{
			DeleteCloudData();
			ClearStowawayVariablesFromGameData();
			foreach (KeyValuePair<string, IPersistent> cloudPref in CloudPrefs)
			{
				cloudPref.Value.Reset();
			}
		}

		public static string[] ClearStowawayVariablesFromGameData()
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, SyncableItem> syncableItem in s_localGameData.SyncableItems)
			{
				if (!s_cloudPrefs.ContainsKey(syncableItem.Key))
				{
					list.Add(syncableItem.Key);
				}
			}
			List<string> list2 = new List<string>();
			foreach (KeyValuePair<string, SyncableCurrency> syncableCurrency in s_localGameData.SyncableCurrencies)
			{
				if (!s_cloudPrefs.ContainsKey(syncableCurrency.Key))
				{
					list2.Add(syncableCurrency.Key);
				}
			}
			foreach (string item in list)
			{
				s_localGameData.SyncableItems.Remove(item);
			}
			foreach (string item2 in list2)
			{
				s_localGameData.SyncableCurrencies.Remove(item2);
				list.Add(item2);
			}
			return list.ToArray();
		}

		public static void SaveToDisk()
		{
			foreach (KeyValuePair<string, IPersistent> cloudPref in CloudPrefs)
			{
				cloudPref.Value.Flush();
			}
			if (IsLocalDataDirty)
			{
				PlayerPrefs.SetString("CloudOnceDevString", SerializeLocalData().ToBase64String());
				PlayerPrefs.Save();
			}
		}

		public static void LoadFromDisk()
		{
			string text = PlayerPrefs.GetString("CloudOnceDevString");
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (!text.IsJson())
			{
				try
				{
					text = text.FromBase64StringToString();
				}
				catch (FormatException)
				{
					Debug.LogWarning("Unable to deserialize local data!");
					return;
				}
			}
			if (!s_isInitialized)
			{
				s_localGameData = new GameData(text);
			}
			else if (MergeLocalDataWith(text).Length != 0)
			{
				RefreshCloudValues();
			}
		}

		public static string SerializeLocalData()
		{
			return s_localGameData.Serialize();
		}

		public static string[] MergeLocalDataWith(string otherData)
		{
			string[] array = s_localGameData.MergeWith(new GameData(otherData));
			if (array.Length != 0)
			{
				RefreshCloudValues();
				SaveToDisk();
			}
			return array;
		}

		public static string[] ReplaceLocalDataWith(string otherData)
		{
			s_localGameData = new GameData(otherData);
			foreach (KeyValuePair<string, IPersistent> cloudPref in CloudPrefs)
			{
				cloudPref.Value.Load(force: true);
			}
			SaveToDisk();
			return s_localGameData.GetAllKeys();
		}

		private static void DeleteCloudData()
		{
			PlayerPrefs.DeleteKey("CloudOnceDevString");
			PlayerPrefs.Save();
		}
	}
}
