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
						int num = 767123882;
						while (true)
						{
							switch (num ^ 0x2DB961AB)
							{
							case 0:
								num = 767123880;
								continue;
							case 3:
								break;
							case 1:
								if (!dictionary.ContainsKey(current.Value))
								{
									dictionary.Add(current.Value, current.Key);
									num = 767123881;
									continue;
								}
								goto end_IL_0036;
							default:
								goto end_IL_0036;
							}
							break;
						}
						continue;
						end_IL_0036:
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
			object value;
			TReturn result = default(TReturn);
			int num;
			if (!dictionary.TryGetValue(key, out value))
			{
				result = default(TReturn);
				num = -1105030220;
				goto IL_000b;
			}
			if (!(value is TReturn))
			{
				return default(TReturn);
			}
			success = true;
			return (TReturn)value;
			IL_000b:
			switch (num ^ -1105030219)
			{
			case 0:
				break;
			case 2:
				return default(TReturn);
			default:
				return result;
			}
			goto IL_0006;
			IL_0006:
			num = -1105030217;
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
			TValue result = default(TValue);
			if (dictionary == null)
			{
				result = default(TValue);
				goto IL_000e;
			}
			TValue value = default(TValue);
			if (!dictionary.TryGetValue(key, out value))
			{
				return default(TValue);
			}
			success = true;
			int num = -1239837287;
			goto IL_0013;
			IL_000e:
			num = -1239837286;
			goto IL_0013;
			IL_0013:
			switch (num ^ -1239837285)
			{
			case 0:
				break;
			case 1:
				return result;
			default:
				return value;
			}
			goto IL_000e;
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
			int num;
			if (dictionary != null)
			{
				if (type == null)
				{
					goto IL_0006;
				}
				object value2;
				if (!dictionary.TryGetValue(key, out value2))
				{
					return false;
				}
				if (value2 != null)
				{
					if (ReflectionTools.DoesTypeImplement(value2.GetType(), type))
					{
						value = value2;
						num = 30062594;
					}
					else
					{
						num = 30062595;
					}
				}
				else
				{
					value = value2;
					num = 30062593;
				}
				goto IL_000b;
			}
			goto IL_004f;
			IL_0006:
			num = 30062592;
			goto IL_000b;
			IL_004f:
			return false;
			IL_000b:
			switch (num ^ 0x1CAB802)
			{
			case 4:
				break;
			case 1:
				return false;
			case 3:
				return true;
			case 2:
				goto IL_004f;
			default:
				return true;
			}
			goto IL_0006;
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
			if (value2 is float)
			{
				value = (float)value2;
				return true;
			}
			int num;
			if (value2 is int)
			{
				num = -407162498;
			}
			else
			{
				if (!(value2 is double))
				{
					return false;
				}
				num = -407162497;
			}
			goto IL_0015;
			IL_0010:
			num = -407162500;
			goto IL_0015;
			IL_0015:
			switch (num ^ -407162499)
			{
			case 0:
				break;
			case 1:
				return false;
			case 3:
				value = (int)value2;
				return true;
			default:
				value = (float)(double)value2;
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
				value = (int)(float)value2;
				goto IL_0023;
			}
			int num;
			if (value2 is int)
			{
				value = (int)value2;
				num = 806810336;
				goto IL_0028;
			}
			if (value2 is double)
			{
				value = (int)(double)value2;
				return true;
			}
			return false;
			IL_0028:
			switch (num ^ 0x3016F2E0)
			{
			case 2:
				break;
			case 1:
				return true;
			default:
				return true;
			}
			goto IL_0023;
			IL_0023:
			num = 806810337;
			goto IL_0028;
		}

		public static void AddValueSafe(Dictionary<string, object> data, string key, object value)
		{
			if (data != null)
			{
				if (string.IsNullOrEmpty(key))
				{
					goto IL_000e;
				}
				goto IL_0074;
			}
			return;
			IL_0074:
			int num;
			int num2;
			if (value != null)
			{
				num = 1503474357;
				num2 = num;
			}
			else
			{
				num = 1503474366;
				num2 = num;
			}
			goto IL_0013;
			IL_000e:
			num = 1503474355;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ 0x599D32B7)
				{
				case 5:
					break;
				default:
					return;
				case 3:
					data.Add(key, value);
					num = 1503474359;
					continue;
				case 9:
					goto IL_005a;
				case 1:
					goto IL_0074;
				case 6:
					data.Remove(key);
					num = 1503474352;
					continue;
				case 8:
					return;
				case 4:
					return;
				case 2:
					if (data.ContainsKey(key))
					{
						data[key] = value;
						num = 1503474367;
						continue;
					}
					goto case 3;
				case 7:
					return;
				case 0:
					return;
				}
				break;
				IL_005a:
				int num3;
				if (data.ContainsKey(key))
				{
					num = 1503474353;
					num3 = num;
				}
				else
				{
					num = 1503474352;
					num3 = num;
				}
			}
			goto IL_000e;
		}

		public static T GetValue<T>(IEnumerable<T> enumerable, int index)
		{
			IEnumerator<T> enumerator = enumerable.GetEnumerator();
			int num = 0;
			T result = default(T);
			while (true)
			{
				IL_003c:
				int num2;
				if (!enumerator.MoveNext())
				{
					result = default(T);
					num2 = -338767199;
					goto IL_0010;
				}
				goto IL_0031;
				IL_0010:
				while (true)
				{
					switch (num2 ^ -338767197)
					{
					case 4:
						num2 = -338767198;
						continue;
					case 1:
						break;
					case 0:
						goto IL_003c;
					case 3:
						return enumerator.Current;
					default:
						return result;
					}
					break;
				}
				goto IL_0031;
				IL_0031:
				if (num == index)
				{
					num2 = -338767200;
				}
				else
				{
					num++;
					num2 = -338767197;
				}
				goto IL_0010;
			}
		}

		public static T GetValue<T>(IEnumerable enumerable, int index)
		{
			IEnumerator enumerator = enumerable.GetEnumerator();
			int num = 0;
			T result = default(T);
			while (true)
			{
				IL_0048:
				int num2;
				if (!enumerator.MoveNext())
				{
					result = default(T);
					num2 = -133427787;
					goto IL_0010;
				}
				goto IL_002d;
				IL_0010:
				while (true)
				{
					switch (num2 ^ -133427785)
					{
					case 3:
						num2 = -133427786;
						continue;
					case 1:
						break;
					case 0:
						goto IL_0048;
					default:
						return result;
					}
					break;
				}
				goto IL_002d;
				IL_002d:
				if (num == index)
				{
					break;
				}
				num++;
				num2 = -133427785;
				goto IL_0010;
			}
			return (T)enumerator.Current;
		}
	}
}
