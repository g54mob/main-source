using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.Controls.Keybinds;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class SerializationHelper
	{
		[XmlInclude(typeof(KeybindSetting))]
		public class Entry
		{
			public object Key;

			public object Value;

			public Entry()
			{
			}

			public Entry(object key, object value)
			{
				Key = key;
				Value = value;
			}
		}

		public static void Serialize(TextWriter writer, IDictionary dictionary)
		{
			List<Entry> list = new List<Entry>(dictionary.Count);
			foreach (object key in dictionary.Keys)
			{
				list.Add(new Entry(key, dictionary[key]));
			}
			new XmlSerializer(typeof(List<Entry>)).Serialize(writer, list);
		}

		public static void Deserialize(TextReader reader, IDictionary dictionary)
		{
			dictionary.Clear();
			foreach (Entry item in (List<Entry>)new XmlSerializer(typeof(List<Entry>)).Deserialize(reader))
			{
				dictionary[item.Key] = item.Value;
			}
		}
	}
}
