using System;
using CTS.Core;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_StringKey<TObj> : ES3Type where TObj : ScriptableStringKey
	{
		public ES3UserType_StringKey(Type type)
			: base(type)
		{
		}

		public override void Write(object obj, ES3Writer writer)
		{
			writer.WriteProperty("StringKey", ((StringKey<TObj>)obj/*cast due to .constrained prefix*/).ToString());
		}

		public override object Read<T>(ES3Reader reader)
		{
			StringKey<TObj> stringKey = default(StringKey<TObj>);
			while (true)
			{
				string text = reader.ReadPropertyName();
				if (text == null)
				{
					break;
				}
				if (text == "StringKey")
				{
					stringKey = new StringKey<TObj>(reader.Read<string>());
				}
				else
				{
					reader.Skip();
				}
			}
			return stringKey;
		}
	}
	[Preserve]
	[ES3Properties(new string[] { "_stringKey" })]
	public class ES3UserType_StringKey : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_StringKey()
			: base(typeof(StringKey))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			writer.WriteProperty("StringKey", ((StringKey)obj/*cast due to .constrained prefix*/).ToString());
		}

		public override object Read<T>(ES3Reader reader)
		{
			StringKey stringKey = default(StringKey);
			while (true)
			{
				string text = reader.ReadPropertyName();
				if (text == null)
				{
					break;
				}
				if (text == "StringKey")
				{
					stringKey = new StringKey(reader.Read<string>());
				}
				else
				{
					reader.Skip();
				}
			}
			return stringKey;
		}
	}
}
