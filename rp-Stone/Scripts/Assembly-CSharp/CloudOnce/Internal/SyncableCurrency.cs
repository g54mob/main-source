using System.Collections.Generic;
using CloudOnce.Internal.Utils;
using UnityEngine;

namespace CloudOnce.Internal
{
	public class SyncableCurrency : IJsonConvertible, IJsonSerializable, IJsonDeserializable
	{
		private const string oldAliasCurrencyID = "cID";

		private const string oldAliasCurrencyData = "cData";

		private const string aliasCurrencyID = "i";

		private const string aliasCurrencyData = "d";

		private Dictionary<string, CurrencyValue> deviceCurrencyValues = new Dictionary<string, CurrencyValue>();

		public string CurrencyID { get; private set; }

		public Dictionary<string, CurrencyValue> DeviceCurrencyValues
		{
			get
			{
				return deviceCurrencyValues;
			}
			set
			{
				deviceCurrencyValues = value;
			}
		}

		public SyncableCurrency(string currencyID)
		{
			CurrencyID = currencyID;
		}

		public SyncableCurrency(JSONObject jsonSerializedCurrency)
		{
			FromJSONObject(jsonSerializedCurrency);
		}

		public JSONObject ToJSONObject()
		{
			Dictionary<string, JSONObject> dictionary = new Dictionary<string, JSONObject>();
			foreach (KeyValuePair<string, CurrencyValue> deviceCurrencyValue in DeviceCurrencyValues)
			{
				dictionary.Add(deviceCurrencyValue.Key, deviceCurrencyValue.Value.ToJSONObject());
			}
			JSONObject obj = new JSONObject(dictionary);
			JSONObject obj2 = JSONObject.CreateStringObject(CurrencyID);
			JSONObject jSONObject = JSONObject.Create(JSONObject.Type.Object);
			jSONObject.AddField("i", obj2);
			jSONObject.AddField("d", obj);
			return jSONObject;
		}

		public void FromJSONObject(JSONObject jsonObject)
		{
			string alias = CloudOnceUtils.GetAlias(typeof(SyncableCurrency).Name, jsonObject, "i", "cID");
			string alias2 = CloudOnceUtils.GetAlias(typeof(SyncableCurrency).Name, jsonObject, "d", "cData");
			CurrencyID = jsonObject[alias].String;
			DeviceCurrencyValues = JsonHelper.Convert<Dictionary<string, CurrencyValue>>(jsonObject[alias2]);
		}

		public bool MergeWith(SyncableCurrency otherData)
		{
			bool result = false;
			if (otherData.CurrencyID != CurrencyID)
			{
				Debug.LogError("Attempted to merge two different currencies, this is not allowed!");
				return false;
			}
			if (DeviceCurrencyValues == null)
			{
				DeviceCurrencyValues = otherData.DeviceCurrencyValues;
				result = true;
			}
			else
			{
				foreach (KeyValuePair<string, CurrencyValue> deviceCurrencyValue in otherData.DeviceCurrencyValues)
				{
					if (DeviceCurrencyValues.TryGetValue(deviceCurrencyValue.Key, out var value))
					{
						if (deviceCurrencyValue.Value.Additions > value.Additions)
						{
							value.Additions = deviceCurrencyValue.Value.Additions;
							result = true;
						}
						if (deviceCurrencyValue.Value.Subtractions < value.Subtractions)
						{
							value.Subtractions = deviceCurrencyValue.Value.Subtractions;
							result = true;
						}
					}
					else
					{
						DeviceCurrencyValues.Add(deviceCurrencyValue.Key, deviceCurrencyValue.Value);
						result = true;
					}
				}
			}
			return result;
		}

		public void ResetCurrency()
		{
			foreach (KeyValuePair<string, CurrencyValue> deviceCurrencyValue in DeviceCurrencyValues)
			{
				deviceCurrencyValue.Value.Additions = 0f;
				deviceCurrencyValue.Value.Subtractions = 0f;
			}
		}
	}
}
