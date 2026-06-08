using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Amazon.Runtime.Internal.Settings
{
	public class SettingsCollection : IEnumerable<SettingsCollection.ObjectSettings>, IEnumerable
	{
		public class ObjectSettings
		{
			private string _uniqueKey;

			private Dictionary<string, string> _values;

			public string UniqueKey => _uniqueKey;

			public string this[string key]
			{
				get
				{
					_values.TryGetValue(key, out var value);
					return value;
				}
				set
				{
					_values[key] = value;
				}
			}

			public bool IsEmpty
			{
				get
				{
					if (_values != null)
					{
						return _values.Count == 0;
					}
					return true;
				}
			}

			public IEnumerable<string> Keys
			{
				get
				{
					string[] array = new string[_values.Keys.Count];
					_values.Keys.CopyTo(array, 0);
					return array;
				}
			}

			internal ObjectSettings(string uniqueKey, Dictionary<string, string> values)
			{
				_uniqueKey = uniqueKey;
				_values = values;
			}

			public string GetValueOrDefault(string key, string defaultValue)
			{
				string text = this[key];
				if (text == null)
				{
					return defaultValue;
				}
				return text;
			}

			public void Remove(string key)
			{
				_values.Remove(key);
			}

			public void Clear()
			{
				_values.Clear();
			}

			internal void WriteToJson(Utf8JsonWriter writer)
			{
				writer.WriteStartObject();
				foreach (KeyValuePair<string, string> value in _values)
				{
					string text = value.Value;
					if (text != null)
					{
						writer.WritePropertyName(value.Key);
						if (PersistenceManager.IsEncrypted(value.Key) || PersistenceManager.IsEncrypted(_uniqueKey))
						{
							text = UserCrypto.Encrypt(text);
						}
						writer.WriteStringValue(text);
					}
				}
				writer.WriteEndObject();
			}
		}

		private Dictionary<string, Dictionary<string, string>> _values;

		public int Count => _values.Count;

		public bool InitializedEmpty { get; private set; }

		public ObjectSettings this[string key]
		{
			get
			{
				if (!_values.TryGetValue(key, out var value))
				{
					return NewObjectSettings(key);
				}
				return new ObjectSettings(key, value);
			}
		}

		public SettingsCollection()
		{
			_values = new Dictionary<string, Dictionary<string, string>>();
			InitializedEmpty = true;
		}

		public SettingsCollection(Dictionary<string, Dictionary<string, string>> values)
		{
			_values = values;
			InitializedEmpty = false;
		}

		internal void Persist(StreamWriter writer)
		{
			JsonWriterOptions options = new JsonWriterOptions
			{
				Indented = true
			};
			using MemoryStream memoryStream = new MemoryStream();
			using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, options);
			utf8JsonWriter.WriteStartObject();
			foreach (string key in _values.Keys)
			{
				ObjectSettings objectSettings = this[key];
				utf8JsonWriter.WritePropertyName(key);
				objectSettings.WriteToJson(utf8JsonWriter);
			}
			utf8JsonWriter.WriteEndObject();
			utf8JsonWriter.Flush();
			string value = Encoding.UTF8.GetString(memoryStream.ToArray());
			writer.Write(value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<ObjectSettings> GetEnumerator()
		{
			foreach (string key in _values.Keys)
			{
				yield return this[key];
			}
		}

		public ObjectSettings NewObjectSettings()
		{
			string uniqueKey = Guid.NewGuid().ToString();
			return NewObjectSettings(uniqueKey);
		}

		public ObjectSettings NewObjectSettings(string uniqueKey)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			ObjectSettings result = new ObjectSettings(uniqueKey, dictionary);
			_values[uniqueKey] = dictionary;
			return result;
		}

		public void Remove(string uniqueKey)
		{
			_values.Remove(uniqueKey);
		}

		public void Clear()
		{
			_values.Clear();
		}
	}
}
