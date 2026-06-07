using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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
						int num = 1624495119;
						while (true)
						{
							switch (num ^ 0x60D3D40C)
							{
							case 4:
								num = 1624495118;
								continue;
							case 2:
								break;
							case 3:
								goto IL_0049;
							case 1:
								dictionary.Add(current.Value, current.Key);
								num = 1624495116;
								continue;
							default:
								goto end_IL_003a;
							}
							break;
							IL_0049:
							int num2;
							if (dictionary.ContainsKey(current.Value))
							{
								num = 1624495116;
								num2 = num;
							}
							else
							{
								num = 1624495117;
								num2 = num;
							}
						}
						continue;
						end_IL_003a:
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
				return default(TReturn);
			}
			object value;
			if (!dictionary.TryGetValue(key, out value))
			{
				goto IL_001b;
			}
			int num;
			TReturn result = default(TReturn);
			if (value is TReturn)
			{
				success = true;
				num = 1984242337;
			}
			else
			{
				result = default(TReturn);
				num = 1984242340;
			}
			goto IL_0020;
			IL_0020:
			TReturn result2 = default(TReturn);
			while (true)
			{
				switch (num ^ 0x764522A0)
				{
				case 0:
					break;
				case 4:
					return result;
				case 2:
					return result2;
				case 3:
					goto IL_0066;
				default:
					return (TReturn)value;
				}
				break;
				IL_0066:
				result2 = default(TReturn);
				num = 1984242338;
			}
			goto IL_001b;
			IL_001b:
			num = 1984242339;
			goto IL_0020;
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
			TValue value;
			if (!dictionary.TryGetValue(key, out value))
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
			object value2;
			if (!dictionary.TryGetValue(key, out value2))
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
			if (dictionary != null)
			{
				while (true)
				{
					int num = 987735319;
					while (true)
					{
						switch (num ^ 0x3ADFA516)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						case 3:
							goto end_IL_0003;
						default:
							return false;
						}
						break;
						IL_0025:
						if ((object)type == null)
						{
							num = 987735317;
							continue;
						}
						object value2;
						if (!dictionary.TryGetValue(key, out value2))
						{
							return false;
						}
						if (value2 == null)
						{
							value = value2;
							return true;
						}
						if (!ReflectionTools.DoesTypeImplement(value2.GetType(), type))
						{
							num = 987735316;
							continue;
						}
						value = value2;
						return true;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return false;
		}

		public static bool GetDictionaryValueSafe_float(Dictionary<string, object> dictionary, string key, ref float value)
		{
			if (dictionary == null)
			{
				return false;
			}
			object value2;
			if (!dictionary.TryGetValue(key, out value2))
			{
				goto IL_0010;
			}
			int num;
			if (value2 is float)
			{
				num = 1848920067;
			}
			else
			{
				if (!(value2 is int))
				{
					if (value2 is double)
					{
						value = (float)(double)value2;
						return true;
					}
					return false;
				}
				num = 1848920064;
			}
			goto IL_0015;
			IL_0010:
			num = 1848920065;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x6E344800)
			{
			case 2:
				break;
			case 1:
				return false;
			case 3:
				value = (float)value2;
				return true;
			default:
				value = (int)value2;
				return true;
			}
			goto IL_0010;
		}

		public static bool GetDictionaryValueSafe_int(Dictionary<string, object> dictionary, string key, ref int value)
		{
			if (dictionary == null)
			{
				return false;
			}
			object value2;
			if (!dictionary.TryGetValue(key, out value2))
			{
				return false;
			}
			if (value2 is float)
			{
				while (true)
				{
					int num = 868657221;
					while (true)
					{
						switch (num ^ 0x33C6A844)
						{
						case 2:
							break;
						case 1:
							goto IL_0038;
						default:
							return true;
						}
						break;
						IL_0038:
						value = (int)(float)value2;
						num = 868657220;
					}
				}
			}
			if (value2 is int)
			{
				value = (int)value2;
				return true;
			}
			if (value2 is double)
			{
				value = (int)(double)value2;
				return true;
			}
			return false;
		}

		public static void AddValueSafe(Dictionary<string, object> data, string key, object value)
		{
			if (data != null)
			{
				if (string.IsNullOrEmpty(key))
				{
					goto IL_000b;
				}
				goto IL_004e;
			}
			return;
			IL_0079:
			data.Add(key, value);
			return;
			IL_000b:
			int num = -752945560;
			goto IL_0010;
			IL_0010:
			switch (num ^ -752945557)
			{
			case 4:
				break;
			case 5:
				goto IL_0035;
			case 2:
				goto IL_004e;
			case 1:
				return;
			case 3:
				return;
			default:
				goto IL_0079;
			}
			goto IL_000b;
			IL_004e:
			if (value == null)
			{
				if (data.ContainsKey(key))
				{
					data.Remove(key);
					num = -752945558;
					goto IL_0010;
				}
				return;
			}
			goto IL_0035;
			IL_0035:
			if (data.ContainsKey(key))
			{
				data[key] = value;
				return;
			}
			goto IL_0079;
		}

		public static T GetValue<T>(IEnumerable<T> enumerable, int index)
		{
			IEnumerator<T> enumerator = enumerable.GetEnumerator();
			int num = 0;
			T result = default(T);
			while (true)
			{
				int num2 = -484654739;
				while (true)
				{
					switch (num2 ^ -484654743)
					{
					case 0:
						break;
					case 4:
						num2 = -484654741;
						continue;
					case 2:
						if (!enumerator.MoveNext())
						{
							result = default(T);
							num2 = -484654744;
							continue;
						}
						goto case 3;
					case 3:
						if (num == index)
						{
							return enumerator.Current;
						}
						num++;
						num2 = -484654741;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}

		public static T GetValue<T>(IEnumerable enumerable, int index)
		{
			IEnumerator enumerator = enumerable.GetEnumerator();
			int num = 0;
			while (true)
			{
				int num2 = -125829711;
				while (true)
				{
					switch (num2 ^ -125829712)
					{
					case 2:
						break;
					case 1:
						num2 = -125829708;
						continue;
					case 4:
					{
						int num3;
						if (!enumerator.MoveNext())
						{
							num2 = -125829709;
							num3 = num2;
						}
						else
						{
							num2 = -125829712;
							num3 = num2;
						}
						continue;
					}
					case 0:
						if (num == index)
						{
							return (T)enumerator.Current;
						}
						num++;
						num2 = -125829708;
						continue;
					default:
						return default(T);
					}
					break;
				}
			}
		}
	}
}
