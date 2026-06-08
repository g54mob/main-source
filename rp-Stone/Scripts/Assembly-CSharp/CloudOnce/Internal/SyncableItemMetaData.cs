using System;
using System.Globalization;
using CloudOnce.Internal.Utils;

namespace CloudOnce.Internal
{
	public class SyncableItemMetaData : IEquatable<SyncableItemMetaData>, IJsonConvertible, IJsonSerializable, IJsonDeserializable
	{
		private const string oldAliasDataType = "dT";

		private const string oldAliasPersistenceType = "pT";

		private const string oldAliasTimestamp = "tS";

		private const string aliasDataType = "d";

		private const string aliasPersistenceType = "p";

		private const string aliasTimestamp = "t";

		public DataType DataType { get; private set; }

		public PersistenceType PersistenceType { get; private set; }

		public DateTime Timestamp { get; private set; }

		public SyncableItemMetaData(DataType dataType, PersistenceType persistenceType)
		{
			DataType = dataType;
			PersistenceType = persistenceType;
			if (persistenceType == PersistenceType.Latest)
			{
				Timestamp = new DateTime(2014, 6, 30);
			}
		}

		public SyncableItemMetaData(JSONObject jsonObject)
		{
			FromJSONObject(jsonObject);
		}

		public void UpdateDateTime()
		{
			Timestamp = DateTime.UtcNow;
		}

		public bool Equals(SyncableItemMetaData other)
		{
			if (other == null)
			{
				return false;
			}
			bool flag = object.Equals(DataType, other.DataType);
			bool flag2 = object.Equals(PersistenceType, other.PersistenceType);
			if (PersistenceType == PersistenceType.Latest)
			{
				return Timestamp.Equals(other.Timestamp) && flag && flag2;
			}
			return flag && flag2;
		}

		public override string ToString()
		{
			if (PersistenceType == PersistenceType.Latest)
			{
				return $"DataType: {DataType}, PersistenceType: {PersistenceType}, TimeStamp: {Timestamp}";
			}
			return $"DataType: {DataType}, PersistenceType: {PersistenceType}";
		}

		public void FromJSONObject(JSONObject jsonObject)
		{
			string alias = CloudOnceUtils.GetAlias(typeof(SyncableItemMetaData).Name, jsonObject, "d", "dT");
			string alias2 = CloudOnceUtils.GetAlias(typeof(SyncableItemMetaData).Name, jsonObject, "p", "pT");
			if (!string.IsNullOrEmpty(jsonObject[alias].String))
			{
				DataType = (DataType)Enum.Parse(typeof(DataType), jsonObject[alias].String);
			}
			else
			{
				DataType = (DataType)jsonObject[alias].F;
			}
			if (!string.IsNullOrEmpty(jsonObject[alias2].String))
			{
				PersistenceType = (PersistenceType)Enum.Parse(typeof(PersistenceType), jsonObject[alias2].String);
			}
			else
			{
				PersistenceType = (PersistenceType)jsonObject[alias2].F;
			}
			if (jsonObject.HasFields("t"))
			{
				Timestamp = DateTime.FromBinary(Convert.ToInt64(jsonObject["t"].String));
			}
			else if (jsonObject.HasFields("tS"))
			{
				Timestamp = DateTime.FromBinary(Convert.ToInt64(jsonObject["tS"].String));
			}
		}

		public JSONObject ToJSONObject()
		{
			JSONObject jSONObject = new JSONObject(JSONObject.Type.Object);
			jSONObject.AddField("d", (float)DataType);
			jSONObject.AddField("p", (float)PersistenceType);
			if (PersistenceType == PersistenceType.Latest)
			{
				jSONObject.AddField("t", Timestamp.ToBinary().ToString(CultureInfo.InvariantCulture));
			}
			return jSONObject;
		}
	}
}
