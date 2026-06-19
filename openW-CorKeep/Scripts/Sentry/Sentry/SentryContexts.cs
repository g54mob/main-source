using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Protocol;

namespace Sentry
{
	public sealed class SentryContexts : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, ISentryJsonSerializable
	{
		private readonly ConcurrentDictionary<string, object> _innerDictionary = new ConcurrentDictionary<string, object>(StringComparer.Ordinal);

		public App App => _innerDictionary.GetOrCreate<App>("app");

		public Browser Browser => _innerDictionary.GetOrCreate<Browser>("browser");

		public Device Device => _innerDictionary.GetOrCreate<Device>("device");

		public Sentry.Protocol.OperatingSystem OperatingSystem => _innerDictionary.GetOrCreate<Sentry.Protocol.OperatingSystem>("os");

		public Response Response => _innerDictionary.GetOrCreate<Response>("response");

		public Runtime Runtime => _innerDictionary.GetOrCreate<Runtime>("runtime");

		public Gpu Gpu => _innerDictionary.GetOrCreate<Gpu>("gpu");

		public Trace Trace => _innerDictionary.GetOrCreate<Trace>("trace");

		public int Count => _innerDictionary.Count;

		public bool IsReadOnly => ((ICollection<KeyValuePair<string, object>>)_innerDictionary).IsReadOnly;

		public object this[string key]
		{
			get
			{
				return _innerDictionary[key];
			}
			set
			{
				_innerDictionary[key] = value;
			}
		}

		public ICollection<string> Keys => _innerDictionary.Keys;

		public ICollection<object> Values => _innerDictionary.Values;

		internal SentryContexts Clone()
		{
			SentryContexts sentryContexts = new SentryContexts();
			CopyTo(sentryContexts);
			return sentryContexts;
		}

		internal void CopyTo(SentryContexts to)
		{
			using IEnumerator<KeyValuePair<string, object>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, object> kv = enumerator.Current;
				to._innerDictionary.AddOrUpdate(kv.Key, (string _) => (!(kv.Value is ICloneable<object> cloneable)) ? kv.Value : cloneable.Clone(), delegate(string _, object existing)
				{
					if (existing is IUpdatable updatable)
					{
						updatable.UpdateFrom(kv.Value);
					}
					else if (kv.Value is IDictionary<string, object> dictionary && existing is IDictionary<string, object> dictionary2)
					{
						foreach (KeyValuePair<string, object> item in dictionary)
						{
							if (!dictionary2.TryGetValue(item.Key, out var value))
							{
								dictionary2.Add(item);
							}
							else if (value == null)
							{
								dictionary2[item.Key] = item.Value;
							}
						}
					}
					return existing;
				});
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			IOrderedEnumerable<KeyValuePair<string, object>> dic = this.OrderBy<KeyValuePair<string, object>, string>((KeyValuePair<string, object> x) => x.Key, StringComparer.Ordinal);
			writer.WriteDictionaryValue(dic, logger, includeNullValues: false);
		}

		public static SentryContexts FromJson(JsonElement json)
		{
			SentryContexts sentryContexts = new SentryContexts();
			foreach (JsonProperty item in json.EnumerateObject())
			{
				item.Deconstruct(out string name, out JsonElement value);
				string text = name;
				JsonElement json2 = value;
				JsonElement? propertyOrNull = json2.GetPropertyOrNull("type");
				object obj;
				if (!propertyOrNull.HasValue)
				{
					obj = null;
				}
				else
				{
					value = propertyOrNull.GetValueOrDefault();
					obj = value.GetString();
				}
				if (obj == null)
				{
					obj = text;
				}
				string a = (string)obj;
				if (string.Equals(a, "app", StringComparison.OrdinalIgnoreCase))
				{
					sentryContexts[text] = Sentry.Protocol.App.FromJson(json2);
					continue;
				}
				if (string.Equals(a, "browser", StringComparison.OrdinalIgnoreCase))
				{
					sentryContexts[text] = Sentry.Protocol.Browser.FromJson(json2);
					continue;
				}
				if (string.Equals(a, "device", StringComparison.OrdinalIgnoreCase))
				{
					sentryContexts[text] = Sentry.Protocol.Device.FromJson(json2);
					continue;
				}
				if (string.Equals(a, "os", StringComparison.OrdinalIgnoreCase))
				{
					sentryContexts[text] = Sentry.Protocol.OperatingSystem.FromJson(json2);
					continue;
				}
				if (string.Equals(a, "response", StringComparison.OrdinalIgnoreCase))
				{
					sentryContexts[text] = Sentry.Protocol.Response.FromJson(json2);
					continue;
				}
				if (string.Equals(a, "runtime", StringComparison.OrdinalIgnoreCase))
				{
					sentryContexts[text] = Sentry.Protocol.Runtime.FromJson(json2);
					continue;
				}
				if (string.Equals(a, "gpu", StringComparison.OrdinalIgnoreCase))
				{
					sentryContexts[text] = Sentry.Protocol.Gpu.FromJson(json2);
					continue;
				}
				if (string.Equals(a, "trace", StringComparison.OrdinalIgnoreCase))
				{
					sentryContexts[text] = Sentry.Protocol.Trace.FromJson(json2);
					continue;
				}
				object dynamicOrNull = json2.GetDynamicOrNull();
				if (dynamicOrNull != null)
				{
					sentryContexts[text] = dynamicOrNull;
				}
			}
			return sentryContexts;
		}

		internal void ReplaceWith(SentryContexts? contexts)
		{
			Clear();
			if (contexts == null)
			{
				return;
			}
			foreach (KeyValuePair<string, object> context in contexts)
			{
				this[context.Key] = context.Value;
			}
		}

		internal SentryContexts? NullIfEmpty()
		{
			if (!_innerDictionary.IsEmpty)
			{
				return this;
			}
			return null;
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return _innerDictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_innerDictionary).GetEnumerator();
		}

		public void Add(KeyValuePair<string, object> item)
		{
			((ICollection<KeyValuePair<string, object>>)_innerDictionary).Add(item);
		}

		public void Clear()
		{
			_innerDictionary.Clear();
		}

		public bool Contains(KeyValuePair<string, object> item)
		{
			return _innerDictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<string, object>>)_innerDictionary).CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<string, object> item)
		{
			return ((ICollection<KeyValuePair<string, object>>)_innerDictionary).Remove(item);
		}

		public void Add(string key, object value)
		{
			_innerDictionary.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return _innerDictionary.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return ((IDictionary<string, object>)_innerDictionary).Remove(key);
		}

		public bool TryGetValue(string key, out object value)
		{
			if (_innerDictionary.TryGetValue(key, out object value2))
			{
				value = value2;
				return true;
			}
			value = null;
			return false;
		}
	}
}
