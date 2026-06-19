using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Loxodon.Framework.Configurations
{
	public class PropertiesConfiguration : ConfigurationBase
	{
		private readonly Dictionary<string, object> dict = new Dictionary<string, object>();

		public override bool IsEmpty => dict.Count == 0;

		public PropertiesConfiguration(string text)
		{
			Load(text);
		}

		protected void Load(string text)
		{
			StringReader stringReader = new StringReader(text);
			string text2 = null;
			while ((text2 = stringReader.ReadLine()) != null)
			{
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2) && !Regex.IsMatch(text2, "^((#)|(//))"))
				{
					int num = text2.IndexOf("=");
					if (num <= 0 || num + 1 >= text2.Length)
					{
						throw new FormatException($"This line is not formatted correctly.line:{text2}");
					}
					string text3 = text2.Substring(0, num).Trim();
					string value = text2.Substring(num + 1).Trim();
					if (string.IsNullOrEmpty(text3))
					{
						throw new FormatException($"The key is null or empty.line:{text2}");
					}
					if (dict.ContainsKey(text3))
					{
						throw new AlreadyExistsException($"This key already exists.line:{text2}");
					}
					dict.Add(text3, value);
				}
			}
		}

		public override bool ContainsKey(string key)
		{
			return dict.ContainsKey(key);
		}

		public override IEnumerator<string> GetKeys()
		{
			return dict.Keys.GetEnumerator();
		}

		public override object GetProperty(string key)
		{
			object value = null;
			dict.TryGetValue(key, out value);
			return value;
		}

		public override void AddProperty(string key, object value)
		{
			if (dict.ContainsKey(key))
			{
				throw new AlreadyExistsException(key);
			}
			dict.Add(key, value);
		}

		public override void SetProperty(string key, object value)
		{
			dict[key] = value;
		}

		public override void RemoveProperty(string key)
		{
			dict.Remove(key);
		}

		public override void Clear()
		{
			dict.Clear();
		}
	}
}
