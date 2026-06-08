using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class CollectionTools
	{
		public static Dictionary<TValue, TKey> CreateInverseDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict)
		{
			if (dict == null)
			{
				return null;
			}
			Dictionary<TValue, TKey> dictionary = new Dictionary<TValue, TKey>();
			using (Dictionary<TKey, TValue>.Enumerator enumerator = dict.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						KeyValuePair<TKey, TValue> current = enumerator.Current;
						if (dictionary.ContainsKey(current.Value))
						{
							break;
						}
						dictionary.Add(current.Value, current.Key);
						int num = -1713178507;
						while (true)
						{
							switch (num ^ -1713178508)
							{
							case 0:
								num = -1713178506;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0032;
							}
							break;
						}
						continue;
						end_IL_0032:
						break;
					}
				}
				return dictionary;
			}
		}

		public static TReturn GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key)
		{
			bool success;
			return GetDictionaryValueSafe<TReturn>(dictionary, key, out success);
		}

		public static TReturn GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key, out bool success)
		{
			success = false;
			if (dictionary == null)
			{
				goto IL_0006;
			}
			if (!dictionary.TryGetValue(key, out var value))
			{
				return default(TReturn);
			}
			int num;
			if (!(value is TReturn))
			{
				num = -204557047;
				goto IL_000b;
			}
			success = true;
			return (TReturn)value;
			IL_000b:
			TReturn result = default(TReturn);
			while (true)
			{
				switch (num ^ -204557047)
				{
				case 3:
					break;
				case 1:
					return default(TReturn);
				case 0:
					goto IL_0056;
				default:
					return result;
				}
				break;
				IL_0056:
				result = default(TReturn);
				num = -204557045;
			}
			goto IL_0006;
			IL_0006:
			num = -204557048;
			goto IL_000b;
		}

		public static TValue GetDictionaryValueSafe<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key)
		{
			bool success;
			return GetDictionaryValueSafe(dictionary, key, out success);
		}

		public static TValue GetDictionaryValueSafe<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, out bool success)
		{
			success = false;
			if (dictionary == null)
			{
				return default(TValue);
			}
			if (!dictionary.TryGetValue(key, out var value))
			{
				return default(TValue);
			}
			success = true;
			return value;
		}

		public static bool GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key, ref TReturn value)
		{
			if (dictionary == null)
			{
				return false;
			}
			if (!dictionary.TryGetValue(key, out var value2))
			{
				return false;
			}
			if (value2 == null)
			{
				try
				{
					value = (TReturn)value2;
				}
				catch
				{
					return false;
				}
			}
			if (!(value2 is TReturn))
			{
				return false;
			}
			value = (TReturn)value2;
			return true;
		}

		public static bool GetDictionaryValueSafe(Dictionary<string, object> dictionary, string key, Type type, ref object value)
		{
			int num;
			if (dictionary != null)
			{
				if ((object)type == null)
				{
					goto IL_0006;
				}
				if (!dictionary.TryGetValue(key, out var value2))
				{
					return false;
				}
				if (value2 == null)
				{
					value = value2;
					num = -280805555;
				}
				else
				{
					if (ReflectionTools.DoesTypeImplement(value2.GetType(), type))
					{
						value = value2;
						return true;
					}
					num = -280805554;
				}
				goto IL_000b;
			}
			goto IL_0028;
			IL_0006:
			num = -280805556;
			goto IL_000b;
			IL_0028:
			return false;
			IL_000b:
			switch (num ^ -280805555)
			{
			case 2:
				break;
			case 1:
				goto IL_0028;
			case 0:
				return true;
			default:
				return false;
			}
			goto IL_0006;
		}

		public static bool GetDictionaryValueSafe_float(Dictionary<string, object> dictionary, string key, ref float value)
		{
			if (dictionary == null)
			{
				return false;
			}
			if (!dictionary.TryGetValue(key, out var value2))
			{
				return false;
			}
			if (value2 is float)
			{
				value = (float)value2;
				return true;
			}
			if (value2 is int)
			{
				value = (int)value2;
				return true;
			}
			if (value2 is double)
			{
				value = (float)(double)value2;
				return true;
			}
			return false;
		}

		public static bool GetDictionaryValueSafe_int(Dictionary<string, object> dictionary, string key, ref int value)
		{
			if (dictionary == null)
			{
				return false;
			}
			if (!dictionary.TryGetValue(key, out var value2))
			{
				return false;
			}
			if (value2 is float)
			{
				goto IL_001a;
			}
			int num;
			if (value2 is int)
			{
				num = -1127159291;
				goto IL_001f;
			}
			if (value2 is double)
			{
				value = (int)(double)value2;
				return true;
			}
			return false;
			IL_001f:
			while (true)
			{
				switch (num ^ -1127159289)
				{
				case 3:
					break;
				case 1:
					value = (int)(float)value2;
					return true;
				case 2:
					goto IL_0056;
				default:
					return true;
				}
				break;
				IL_0056:
				value = (int)value2;
				num = -1127159289;
			}
			goto IL_001a;
			IL_001a:
			num = -1127159290;
			goto IL_001f;
		}

		public static void AddValueSafe(Dictionary<string, object> data, string key, object value)
		{
			if (data != null)
			{
				if (string.IsNullOrEmpty(key))
				{
					goto IL_000b;
				}
				goto IL_0071;
			}
			return;
			IL_0058:
			if (data.ContainsKey(key))
			{
				data[key] = value;
				return;
			}
			goto IL_008e;
			IL_000b:
			int num = 1582699110;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ 0x5E561267)
				{
				case 6:
					break;
				case 1:
					return;
				case 4:
					return;
				case 3:
					data.Remove(key);
					num = 1582699107;
					continue;
				case 2:
					goto IL_0058;
				case 5:
					goto IL_0071;
				default:
					goto IL_008e;
				}
				break;
			}
			goto IL_000b;
			IL_008e:
			data.Add(key, value);
			return;
			IL_0071:
			if (value == null)
			{
				int num2;
				if (!data.ContainsKey(key))
				{
					num = 1582699107;
					num2 = num;
				}
				else
				{
					num = 1582699108;
					num2 = num;
				}
				goto IL_0010;
			}
			goto IL_0058;
		}

		public static T GetValue<T>(IEnumerable<T> enumerable, int index)
		{
			IEnumerator<T> enumerator = enumerable.GetEnumerator();
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (!enumerator.MoveNext())
				{
					num2 = -1322537263;
					num3 = num2;
				}
				else
				{
					num2 = -1322537262;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1322537261)
					{
					case 3:
						num2 = -1322537262;
						continue;
					case 0:
						break;
					case 4:
						return enumerator.Current;
					case 1:
						if (num != index)
						{
							num++;
							num2 = -1322537261;
						}
						else
						{
							num2 = -1322537257;
						}
						continue;
					default:
						return default(T);
					}
					break;
				}
			}
		}

		public static T GetValue<T>(IEnumerable enumerable, int index)
		{
			IEnumerator enumerator = enumerable.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				while (true)
				{
					if (num == index)
					{
						return (T)enumerator.Current;
					}
					num++;
					int num2 = -1806881869;
					while (true)
					{
						switch (num2 ^ -1806881869)
						{
						case 2:
							num2 = -1806881870;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0029;
						}
						break;
					}
					continue;
					end_IL_0029:
					break;
				}
			}
			return default(T);
		}
	}
}
