using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils.Libraries.TinyJson
{
	public static class JsonParser
	{
		[CustomObfuscation(rename = false)]
		internal static Stack<List<string>> splitArrayPool = new Stack<List<string>>();

		private static StringBuilder lmUmIUiqeIxajQjGtPmZPfLhrti = new StringBuilder();

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> qIsdjfNUTaMkNdoFvCeoEzYWORs = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> COxHPvYShQwVlvoLrQUKoILVDrf = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		[CompilerGenerated]
		private static Func<FieldInfo, bool> nxRDNsQycmbjNuLzCodsWNAlkcQ;

		[CompilerGenerated]
		private static Func<FieldInfo, string> VqWFQXijanCwPkbVsFhwOEwJgwAF;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> qslXNXRsEYEvqryqNkwNEunhAIO;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> CMgAcJcFMuyEGRbLZxIDYUowyft;

		public static bool TryFromJson<T>(string json, out T value)
		{
			return TryFromJson<T>(json, out value, null);
		}

		[CustomObfuscation(rename = false)]
		internal static bool TryFromJson<T>(string json, out T value, Type preferredAnonymousObjectType)
		{
			bool result = default(bool);
			try
			{
				if (string.IsNullOrEmpty(json))
				{
					goto IL_000b;
				}
				goto IL_00cf;
				IL_000b:
				int num = -1614099800;
				goto IL_0010;
				IL_0010:
				char c = default(char);
				int num2 = default(int);
				while (true)
				{
					switch (num ^ -1614099807)
					{
					case 0:
						break;
					case 8:
						if (!char.IsWhiteSpace(c))
						{
							lmUmIUiqeIxajQjGtPmZPfLhrti.Append(c);
							num = -1614099802;
							continue;
						}
						goto case 7;
					case 4:
						num2 = MoFMIKKAbAFeXkvWCCYMexnkIDdf(true, num2, json);
						num = -1614099801;
						continue;
					case 9:
						value = default(T);
						result = false;
						num = -1614099808;
						continue;
					case 5:
						if (num2 >= json.Length)
						{
							value = (T)moOoTRNnYmLDYrxFBzwAjTOcXEq(typeof(T), lmUmIUiqeIxajQjGtPmZPfLhrti.ToString(), preferredAnonymousObjectType, out var _);
							num = -1614099806;
							continue;
						}
						goto IL_00e6;
					case 7:
						num2++;
						num = -1614099804;
						continue;
					case 10:
						goto IL_00cf;
					case 2:
						goto IL_00e6;
					case 1:
						goto end_IL_0000;
					case 6:
						num = -1614099802;
						continue;
					default:
						result = true;
						goto end_IL_0000;
					}
					break;
					IL_00e6:
					c = json[num2];
					int num3;
					if (c != '"')
					{
						num = -1614099799;
						num3 = num;
					}
					else
					{
						num = -1614099803;
						num3 = num;
					}
				}
				goto IL_000b;
				IL_00cf:
				lmUmIUiqeIxajQjGtPmZPfLhrti.Length = 0;
				num2 = 0;
				num = -1614099804;
				goto IL_0010;
				end_IL_0000:;
			}
			catch
			{
				value = default(T);
				result = false;
			}
			return result;
		}

		public static T FromJson<T>(string json)
		{
			return FromJson<T>(json, null);
		}

		[CustomObfuscation(rename = false)]
		internal static T FromJson<T>(string json, Type preferredAnonymousObjectType)
		{
			if (string.IsNullOrEmpty(json))
			{
				return default(T);
			}
			lmUmIUiqeIxajQjGtPmZPfLhrti.Length = 0;
			int num = 0;
			char c = default(char);
			while (true)
			{
				int num2 = 1295401601;
				while (true)
				{
					switch (num2 ^ 0x4D364282)
					{
					case 8:
						break;
					case 4:
						num++;
						num2 = 1295401607;
						continue;
					case 7:
						if (!char.IsWhiteSpace(c))
						{
							lmUmIUiqeIxajQjGtPmZPfLhrti.Append(c);
							num2 = 1295401606;
							continue;
						}
						goto case 4;
					case 3:
						num2 = 1295401607;
						continue;
					case 0:
						num2 = 1295401606;
						continue;
					case 6:
					{
						int num3;
						if (c != '"')
						{
							num2 = 1295401605;
							num3 = num2;
						}
						else
						{
							num2 = 1295401600;
							num3 = num2;
						}
						continue;
					}
					case 1:
						c = json[num];
						num2 = 1295401604;
						continue;
					case 2:
						num = MoFMIKKAbAFeXkvWCCYMexnkIDdf(true, num, json);
						num2 = 1295401602;
						continue;
					default:
					{
						bool flag;
						if (num >= json.Length)
						{
							return (T)moOoTRNnYmLDYrxFBzwAjTOcXEq(typeof(T), lmUmIUiqeIxajQjGtPmZPfLhrti.ToString(), preferredAnonymousObjectType, out flag);
						}
						goto case 1;
					}
					}
					break;
				}
			}
		}

		public static object FromJson(Type type, string json)
		{
			return FromJson(type, json, null);
		}

		[CustomObfuscation(rename = false)]
		internal static object FromJson(Type type, string json, Type preferredAnonymousObjectType)
		{
			if (string.IsNullOrEmpty(json))
			{
				return null;
			}
			lmUmIUiqeIxajQjGtPmZPfLhrti.Length = 0;
			char c = default(char);
			int num2 = default(int);
			while (true)
			{
				int num = -1440215945;
				while (true)
				{
					switch (num ^ -1440215952)
					{
					case 0:
						break;
					case 1:
						num = -1440215949;
						continue;
					case 8:
					{
						c = json[num2];
						int num4;
						if (c != '"')
						{
							num = -1440215943;
							num4 = num;
						}
						else
						{
							num = -1440215948;
							num4 = num;
						}
						continue;
					}
					case 2:
						num = -1440215947;
						continue;
					case 5:
					{
						int num3;
						if (num2 >= json.Length)
						{
							num = -1440215946;
							num3 = num;
						}
						else
						{
							num = -1440215944;
							num3 = num;
						}
						continue;
					}
					case 4:
						num2 = MoFMIKKAbAFeXkvWCCYMexnkIDdf(true, num2, json);
						num = -1440215951;
						continue;
					case 9:
						if (!char.IsWhiteSpace(c))
						{
							lmUmIUiqeIxajQjGtPmZPfLhrti.Append(c);
							num = -1440215949;
							continue;
						}
						goto case 3;
					case 3:
						num2++;
						num = -1440215947;
						continue;
					case 7:
						num2 = 0;
						num = -1440215950;
						continue;
					default:
					{
						bool flag;
						return moOoTRNnYmLDYrxFBzwAjTOcXEq(type, lmUmIUiqeIxajQjGtPmZPfLhrti.ToString(), preferredAnonymousObjectType, out flag);
					}
					}
					break;
				}
			}
		}

		private static object moOoTRNnYmLDYrxFBzwAjTOcXEq(Type P_0, string P_1, Type P_2, out bool P_3)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_3 = false;
				return null;
			}
			string text = default(string);
			int num;
			object result3 = default(object);
			bool flag3 = default(bool);
			int num6;
			if (object.ReferenceEquals(P_0, typeof(string)))
			{
				if (P_1.Length <= 2)
				{
					goto IL_002b;
				}
				text = P_1.Substring(1, P_1.Length - 2);
				num = 851472928;
			}
			else
			{
				if (object.ReferenceEquals(P_0, typeof(int)))
				{
					P_3 = int.TryParse(P_1, out var result);
					return result;
				}
				if (object.ReferenceEquals(P_0, typeof(float)))
				{
					P_3 = float.TryParse(P_1, NumberStyles.Any, CultureInfo.InvariantCulture, out var result2);
					return result2;
				}
				if (!object.ReferenceEquals(P_0, typeof(double)))
				{
					if (!object.ReferenceEquals(P_0, typeof(bool)))
					{
						if (object.ReferenceEquals(P_0, typeof(Guid)))
						{
							try
							{
								bool flag;
								string g = (string)moOoTRNnYmLDYrxFBzwAjTOcXEq(typeof(string), P_1, P_2, out flag);
								while (true)
								{
									IL_01ab:
									int num2 = 851472930;
									while (true)
									{
										switch (num2 ^ 0x32C07223)
										{
										case 3:
											break;
										case 1:
											if (flag)
											{
												goto IL_01ec;
											}
											P_3 = false;
											result3 = Guid.Empty;
											goto end_IL_01b0;
										case 2:
											goto IL_01ec;
										default:
											result3 = new Guid(g);
											goto end_IL_01b0;
										}
										goto IL_01ab;
										IL_01ec:
										P_3 = true;
										num2 = 851472931;
										continue;
										end_IL_01b0:
										break;
									}
									break;
								}
							}
							catch
							{
								while (true)
								{
									IL_020a:
									int num3 = 851472929;
									while (true)
									{
										switch (num3 ^ 0x32C07223)
										{
										case 0:
											break;
										case 2:
											goto IL_0228;
										default:
											result3 = Guid.Empty;
											goto end_IL_020f;
										}
										goto IL_020a;
										IL_0228:
										P_3 = false;
										num3 = 851472930;
										continue;
										end_IL_020f:
										break;
									}
									break;
								}
							}
							goto IL_0843;
						}
						if (ReflectionTools.IsEnum(P_0))
						{
							Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(P_0);
							object obj2 = moOoTRNnYmLDYrxFBzwAjTOcXEq(underlyingEnumType, P_1, P_2, out var flag2);
							while (true)
							{
								int num4 = 851472930;
								while (true)
								{
									switch (num4 ^ 0x32C07223)
									{
									case 3:
										break;
									case 1:
										goto IL_0285;
									case 0:
										goto IL_0290;
									default:
										return Enum.ToObject(P_0, obj2);
									}
									break;
									IL_0290:
									if (obj2 == null || !ReflectionTools.IsValueType(obj2.GetType()))
									{
										goto end_IL_0263;
									}
									P_3 = true;
									num4 = 851472929;
									continue;
									IL_0285:
									if (!flag2)
									{
										goto end_IL_0263;
									}
									num4 = 851472931;
								}
								continue;
								end_IL_0263:
								break;
							}
							try
							{
								obj2 = moOoTRNnYmLDYrxFBzwAjTOcXEq(typeof(string), P_1, P_2, out flag2);
								while (true)
								{
									IL_02ca:
									int num5 = 851472929;
									while (true)
									{
										switch (num5 ^ 0x32C07223)
										{
										case 3:
											break;
										default:
											goto end_IL_02cf;
										case 2:
											if (flag2 && !string.IsNullOrEmpty((string)obj2))
											{
												obj2 = Enum.Parse(P_0, (string)obj2, ignoreCase: true);
												if (obj2 != null)
												{
													P_3 = true;
													num5 = 851472930;
													continue;
												}
											}
											goto end_IL_02cf;
										case 1:
											result3 = obj2;
											num5 = 851472935;
											continue;
										case 0:
											goto end_IL_02cf;
										case 4:
											goto IL_0843;
										}
										goto IL_02ca;
										continue;
										end_IL_02cf:
										break;
									}
									break;
								}
							}
							catch
							{
							}
						}
						if (P_1 == "null")
						{
							P_3 = true;
							return null;
						}
						if ((object)P_2 != null && ReflectionTools.DoesTypeImplement(P_2, P_0))
						{
							return tVlZMXbSllrUgSiHmAAqviMxsiZ(P_1, P_2, out P_3);
						}
						if (ReflectionTools.IsArray(P_0))
						{
							goto IL_036e;
						}
						flag3 = ReflectionTools.IsGenericType(P_0);
						num6 = 851472931;
						goto IL_0373;
					}
					if (string.Equals(P_1, "true", StringComparison.OrdinalIgnoreCase))
					{
						P_3 = true;
						num = 851472929;
					}
					else
					{
						if (!string.Equals(P_1, "false", StringComparison.OrdinalIgnoreCase))
						{
							P_3 = false;
							return false;
						}
						P_3 = true;
						num = 851472935;
					}
				}
				else
				{
					num = 851472931;
				}
			}
			goto IL_0030;
			IL_0030:
			switch (num ^ 0x32C07223)
			{
			case 5:
				break;
			case 1:
				P_3 = false;
				return string.Empty;
			case 0:
			{
				P_3 = double.TryParse(P_1, NumberStyles.Any, CultureInfo.InvariantCulture, out var result4);
				return result4;
			}
			case 3:
				P_3 = true;
				return text.Replace("\\", string.Empty);
			case 2:
				return true;
			default:
				return false;
			}
			goto IL_002b;
			IL_0843:
			return result3;
			IL_0373:
			Type type2 = default(Type);
			Type[] genericArguments = default(Type[]);
			Type type3 = default(Type);
			List<string> list3 = default(List<string>);
			IList list2 = default(IList);
			Array array = default(Array);
			Type elementType = default(Type);
			List<string> list = default(List<string>);
			int num7 = default(int);
			Type type = default(Type);
			int num8 = default(int);
			while (true)
			{
				switch (num6 ^ 0x32C07223)
				{
				case 19:
					break;
				case 13:
					goto IL_03df;
				case 12:
					type2 = genericArguments[0];
					type3 = genericArguments[1];
					num6 = 851472951;
					continue;
				case 9:
					splitArrayPool.Push(list3);
					P_3 = true;
					return list2;
				case 6:
					goto IL_0454;
				case 22:
					goto IL_047b;
				case 17:
					array = Array.CreateInstance(elementType, list.Count);
					num6 = 851472937;
					continue;
				case 10:
					num7 = 0;
					num6 = 851472928;
					continue;
				case 20:
					goto IL_04c1;
				case 4:
				{
					list2.Add(moOoTRNnYmLDYrxFBzwAjTOcXEq(type, list3[num8], P_2, out var _));
					num8++;
					num6 = 851472934;
					continue;
				}
				case 11:
					goto IL_0507;
				case 0:
					goto IL_0514;
				case 14:
					P_3 = true;
					return array;
				case 15:
					splitArrayPool.Push(list);
					num6 = 851472941;
					continue;
				case 18:
					P_3 = false;
					num6 = 851472929;
					continue;
				case 7:
					P_3 = false;
					return null;
				case 3:
					num6 = 851472942;
					continue;
				case 5:
					goto IL_05c0;
				case 16:
				{
					array.SetValue(moOoTRNnYmLDYrxFBzwAjTOcXEq(elementType, list[num7], P_2, out var _), num7);
					num7++;
					num6 = 851472942;
					continue;
				}
				case 8:
					return null;
				case 21:
					num6 = 851472934;
					continue;
				case 2:
					return null;
				default:
					goto IL_0681;
				}
				break;
				IL_05c0:
				int num9;
				if (num8 < list3.Count)
				{
					num6 = 851472935;
					num9 = num6;
				}
				else
				{
					num6 = 851472938;
					num9 = num6;
				}
				continue;
				IL_047b:
				if (P_1[P_1.Length - 1] != ']')
				{
					num6 = 851472932;
					continue;
				}
				list = rWDWueNWcDGQIvTmeuKBBcWCENk(P_1);
				num6 = 851472946;
				continue;
				IL_0454:
				elementType = P_0.GetElementType();
				int num10;
				if (P_1[0] != '[')
				{
					num6 = 851472932;
					num10 = num6;
				}
				else
				{
					num6 = 851472949;
					num10 = num6;
				}
				continue;
				IL_0514:
				if (!flag3 || (object)P_0.GetGenericTypeDefinition() != typeof(List<>))
				{
					if (flag3 && (object)P_0.GetGenericTypeDefinition() == typeof(Dictionary<, >))
					{
						genericArguments = ReflectionTools.GetGenericArguments(P_0);
						num6 = 851472943;
						continue;
					}
					goto IL_07fa;
				}
				type = ReflectionTools.GetGenericArguments(P_0)[0];
				if (P_1[0] == '[')
				{
					if (P_1[P_1.Length - 1] != ']')
					{
						num6 = 851472936;
						continue;
					}
					list2 = (IList)Factory.CreateInstance(typeof(List<>).MakeGenericType(type));
					list3 = rWDWueNWcDGQIvTmeuKBBcWCENk(P_1);
					num8 = 0;
					num6 = 851472950;
					continue;
				}
				goto IL_0507;
				IL_03df:
				int num11;
				if (num7 >= list.Count)
				{
					num6 = 851472940;
					num11 = num6;
				}
				else
				{
					num6 = 851472947;
					num11 = num6;
				}
				continue;
				IL_0507:
				P_3 = false;
				num6 = 851472939;
				continue;
				IL_04c1:
				if ((object)type2 != typeof(string))
				{
					num6 = 851472945;
					continue;
				}
				if (P_1[0] != '{')
				{
					goto IL_0681;
				}
				if (P_1[P_1.Length - 1] != '}')
				{
					num6 = 851472930;
					continue;
				}
				goto IL_0686;
				IL_0681:
				P_3 = false;
				return null;
			}
			goto IL_036e;
			IL_07fa:
			if (object.ReferenceEquals(P_0, typeof(object)))
			{
				return tVlZMXbSllrUgSiHmAAqviMxsiZ(P_1, P_2, out P_3);
			}
			if (P_1[0] == '{' && P_1[P_1.Length - 1] == '}')
			{
				P_3 = true;
				return gFnqVcHlOUnerYhzMTHCdCQVmAy(P_0, P_1, P_2);
			}
			P_3 = false;
			return null;
			IL_0686:
			List<string> list4 = rWDWueNWcDGQIvTmeuKBBcWCENk(P_1);
			try
			{
				if (list4.Count % 2 != 0)
				{
					P_3 = false;
					result3 = null;
					goto IL_069f;
				}
				goto IL_06f2;
				IL_06f2:
				IDictionary dictionary = (IDictionary)Factory.CreateInstance(typeof(Dictionary<, >).MakeGenericType(type2, type3));
				int num12 = 0;
				int num13 = 851472929;
				goto IL_06a4;
				IL_069f:
				num13 = 851472928;
				goto IL_06a4;
				IL_06a4:
				string key = default(string);
				object value = default(object);
				while (true)
				{
					switch (num13 ^ 0x32C07223)
					{
					case 0:
						break;
					default:
						goto end_IL_068e;
					case 5:
						dictionary.Add(key, value);
						num13 = 851472937;
						continue;
					case 7:
						goto IL_06f2;
					case 9:
					{
						value = moOoTRNnYmLDYrxFBzwAjTOcXEq(type3, list4[num12 + 1], P_2, out var _);
						num13 = 851472934;
						continue;
					}
					case 1:
						P_3 = true;
						num13 = 851472935;
						continue;
					case 10:
						num12 += 2;
						num13 = 851472929;
						continue;
					case 3:
						goto end_IL_068e;
					case 2:
						goto IL_077e;
					case 4:
						result3 = dictionary;
						num13 = 851472939;
						continue;
					case 6:
						if (list4[num12].Length > 2)
						{
							key = list4[num12].Substring(1, list4[num12].Length - 2);
							num13 = 851472938;
							continue;
						}
						goto case 10;
					case 8:
						goto end_IL_068e;
					}
					break;
					IL_077e:
					int num14;
					if (num12 < list4.Count)
					{
						num13 = 851472933;
						num14 = num13;
					}
					else
					{
						num13 = 851472930;
						num14 = num13;
					}
				}
				goto IL_069f;
				end_IL_068e:;
			}
			finally
			{
				if (list4 != null)
				{
					splitArrayPool.Push(list4);
				}
			}
			goto IL_0843;
			IL_036e:
			num6 = 851472933;
			goto IL_0373;
			IL_002b:
			num = 851472930;
			goto IL_0030;
		}

		private static object tVlZMXbSllrUgSiHmAAqviMxsiZ(string P_0, Type P_1, out bool P_2)
		{
			if (P_0.Length == 0)
			{
				P_2 = false;
				return null;
			}
			object result = default(object);
			string text = default(string);
			int num5;
			if (P_0[0] == '{' && P_0[P_0.Length - 1] == '}')
			{
				List<string> list = rWDWueNWcDGQIvTmeuKBBcWCENk(P_0);
				try
				{
					if (list.Count % 2 != 0)
					{
						goto IL_0044;
					}
					goto IL_0191;
					IL_0044:
					int num = -1048894319;
					goto IL_0049;
					IL_0049:
					IAddKeyValue<string, object> addKeyValue = default(IAddKeyValue<string, object>);
					int num2 = default(int);
					Dictionary<string, object> dictionary = default(Dictionary<string, object>);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ -1048894310)
						{
						case 0:
							break;
						default:
							goto end_IL_0037;
						case 10:
						{
							addKeyValue.Add(list[num2].Substring(1, list[num2].Length - 2), tVlZMXbSllrUgSiHmAAqviMxsiZ(list[num2 + 1], P_1, out var _));
							num2 += 2;
							num = -1048894309;
							continue;
						}
						case 2:
							goto end_IL_0037;
						case 8:
							goto IL_00dc;
						case 11:
							P_2 = false;
							num = -1048894311;
							continue;
						case 12:
							num = -1048894317;
							continue;
						case 5:
						{
							dictionary.Add(list[num3].Substring(1, list[num3].Length - 2), tVlZMXbSllrUgSiHmAAqviMxsiZ(list[num3 + 1], P_1, out var _));
							num3 += 2;
							num = -1048894317;
							continue;
						}
						case 9:
							if (num3 >= list.Count)
							{
								P_2 = true;
								result = dictionary;
								num = -1048894306;
								continue;
							}
							goto case 5;
						case 1:
							if (num2 < list.Count)
							{
								goto case 10;
							}
							P_2 = true;
							result = addKeyValue;
							goto end_IL_0037;
						case 6:
							goto IL_0191;
						case 7:
							num = -1048894309;
							continue;
						case 3:
							result = null;
							num = -1048894312;
							continue;
						case 4:
							goto end_IL_0037;
						}
						break;
					}
					goto IL_0044;
					IL_0191:
					if ((object)P_1 != null && ReflectionTools.DoesTypeImplement(P_1, typeof(IAddKeyValue<string, object>)))
					{
						addKeyValue = (IAddKeyValue<string, object>)Factory.CreateInstance(P_1, new object[1] { list.Count / 2 });
						num2 = 0;
						num = -1048894307;
						goto IL_0049;
					}
					goto IL_00dc;
					IL_00dc:
					dictionary = new Dictionary<string, object>(list.Count / 2);
					num3 = 0;
					num = -1048894314;
					goto IL_0049;
					end_IL_0037:;
				}
				finally
				{
					if (list != null)
					{
						while (true)
						{
							IL_01fe:
							int num4 = -1048894312;
							while (true)
							{
								switch (num4 ^ -1048894310)
								{
								case 0:
									break;
								default:
									goto end_IL_0203;
								case 2:
									goto IL_021c;
								case 1:
									goto end_IL_0203;
								}
								goto IL_01fe;
								IL_021c:
								splitArrayPool.Push(list);
								num4 = -1048894309;
								continue;
								end_IL_0203:
								break;
							}
							break;
						}
					}
				}
			}
			else
			{
				if (P_0[0] != '[' || P_0[P_0.Length - 1] != ']')
				{
					if (P_0[0] == '"' && P_0[P_0.Length - 1] == '"')
					{
						text = P_0.Substring(1, P_0.Length - 2);
						P_2 = true;
						goto IL_0418;
					}
					if (!char.IsDigit(P_0[0]))
					{
						if (P_0[0] == '-')
						{
							num5 = -1048894311;
							goto IL_041d;
						}
						if (P_0 == "true")
						{
							P_2 = true;
							return true;
						}
						if (P_0 == "false")
						{
							P_2 = true;
							return false;
						}
						P_2 = true;
						return null;
					}
					goto IL_046c;
				}
				List<string> list2 = rWDWueNWcDGQIvTmeuKBBcWCENk(P_0);
				try
				{
					IAddValue<object> addValue = default(IAddValue<object>);
					int num6 = default(int);
					if ((object)P_1 != null && ReflectionTools.DoesTypeImplement(P_1, typeof(IAddValue<object>)))
					{
						addValue = (IAddValue<object>)Factory.CreateInstance(P_1, new object[1] { list2.Count });
						num6 = 0;
						goto IL_039a;
					}
					goto IL_03b9;
					IL_03b9:
					List<object> list3 = new List<object>(list2.Count);
					int num7 = -1048894318;
					goto IL_02a9;
					IL_02a9:
					int num8 = default(int);
					while (true)
					{
						switch (num7 ^ -1048894310)
						{
						case 2:
							num7 = -1048894311;
							continue;
						case 0:
							num8++;
							num7 = -1048894320;
							continue;
						case 10:
							goto IL_02f6;
						case 3:
						{
							addValue.Add(tVlZMXbSllrUgSiHmAAqviMxsiZ(list2[num6], P_1, out var _));
							num6++;
							num7 = -1048894307;
							continue;
						}
						case 8:
							num8 = 0;
							num7 = -1048894320;
							continue;
						case 11:
							P_2 = true;
							num7 = -1048894308;
							continue;
						case 1:
						{
							list3.Add(tVlZMXbSllrUgSiHmAAqviMxsiZ(list2[num8], P_1, out var _));
							num7 = -1048894310;
							continue;
						}
						case 4:
							P_2 = true;
							result = addValue;
							break;
						case 6:
							result = list3;
							num7 = -1048894305;
							continue;
						case 7:
							goto IL_039a;
						case 9:
							goto IL_03b9;
						case 5:
							break;
						}
						break;
						IL_02f6:
						int num9;
						if (num8 < list2.Count)
						{
							num7 = -1048894309;
							num9 = num7;
						}
						else
						{
							num7 = -1048894319;
							num9 = num7;
						}
					}
					goto end_IL_025a;
					IL_039a:
					int num10;
					if (num6 >= list2.Count)
					{
						num7 = -1048894306;
						num10 = num7;
					}
					else
					{
						num7 = -1048894311;
						num10 = num7;
					}
					goto IL_02a9;
					end_IL_025a:;
				}
				finally
				{
					if (list2 != null)
					{
						splitArrayPool.Push(list2);
					}
				}
			}
			return result;
			IL_041d:
			switch (num5 ^ -1048894310)
			{
			case 0:
				break;
			case 1:
				return text.Replace("\\", string.Empty);
			case 3:
				goto IL_046c;
			default:
			{
				P_2 = double.TryParse(P_0, NumberStyles.Any, CultureInfo.InvariantCulture, out var result2);
				return result2;
			}
			}
			goto IL_0418;
			IL_0418:
			num5 = -1048894309;
			goto IL_041d;
			IL_046c:
			if (P_0.Contains("."))
			{
				num5 = -1048894312;
				goto IL_041d;
			}
			P_2 = int.TryParse(P_0, out var result3);
			return result3;
		}

		private static object gFnqVcHlOUnerYhzMTHCdCQVmAy(Type P_0, string P_1, Type P_2)
		{
			object obj = Factory.CreateInstance(P_0);
			List<string> list = rWDWueNWcDGQIvTmeuKBBcWCENk(P_1);
			object result = default(object);
			try
			{
				if (list.Count % 2 != 0)
				{
					goto IL_001c;
				}
				goto IL_00e2;
				IL_001c:
				int num = 1518254254;
				goto IL_0021;
				IL_0021:
				ISerializationCallbackReceiver serializationCallbackReceiver = default(ISerializationCallbackReceiver);
				Dictionary<string, PropertyInfo> value = default(Dictionary<string, PropertyInfo>);
				string key = default(string);
				string text = default(string);
				Dictionary<string, FieldInfo> value3 = default(Dictionary<string, FieldInfo>);
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x5A7EB8A8)
					{
					case 7:
						break;
					case 0:
						serializationCallbackReceiver = obj as ISerializationCallbackReceiver;
						num = 1518254252;
						continue;
					case 1:
						goto end_IL_000f;
					case 8:
					{
						if (value.TryGetValue(key, out var value2) && value2.CanWrite)
						{
							value2.SetValue(obj, moOoTRNnYmLDYrxFBzwAjTOcXEq(value2.PropertyType, text, P_2, out var _), null);
							num = 1518254242;
							continue;
						}
						goto case 10;
					}
					case 5:
						qIsdjfNUTaMkNdoFvCeoEzYWORs.Add(P_0, value3);
						num = 1518254244;
						continue;
					case 6:
						result = obj;
						num = 1518254249;
						continue;
					case 9:
						goto IL_00e2;
					case 12:
						goto IL_0148;
					case 11:
						if (list[num2].Length > 2)
						{
							key = list[num2].Substring(1, list[num2].Length - 2);
							text = list[num2 + 1];
							if (value3.TryGetValue(key, out var value4))
							{
								value4.SetValue(obj, moOoTRNnYmLDYrxFBzwAjTOcXEq(value4.FieldType, text, P_2, out var _));
								num = 1518254242;
								continue;
							}
							goto case 8;
						}
						goto case 10;
					case 10:
						num2 += 2;
						num = 1518254250;
						continue;
					case 2:
						goto IL_023a;
					case 3:
						goto IL_0258;
					default:
						if (serializationCallbackReceiver != null)
						{
							try
							{
								serializationCallbackReceiver.OnAfterDeserialize();
							}
							catch (Exception ex)
							{
								Logger.LogError(ex.ToString(), requiredThreadSafety: true);
							}
						}
						result = obj;
						goto end_IL_000f;
					}
					break;
					IL_023a:
					int num3;
					if (num2 < list.Count)
					{
						num = 1518254243;
						num3 = num;
					}
					else
					{
						num = 1518254248;
						num3 = num;
					}
				}
				goto IL_001c;
				IL_0258:
				num2 = 0;
				num = 1518254250;
				goto IL_0021;
				IL_0148:
				if (!COxHPvYShQwVlvoLrQUKoILVDrf.TryGetValue(P_0, out value))
				{
					value = (from propertyInfo in ReflectionTools.GetProperties(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
						where propertyInfo.CanWrite && propertyInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !propertyInfo.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
						select propertyInfo).ToDictionary((PropertyInfo propertyInfo) =>
					{
						string name;
						return (propertyInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(propertyInfo.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name : propertyInfo.Name;
					});
					COxHPvYShQwVlvoLrQUKoILVDrf.Add(P_0, value);
					num = 1518254251;
					goto IL_0021;
				}
				goto IL_0258;
				IL_00e2:
				if (!qIsdjfNUTaMkNdoFvCeoEzYWORs.TryGetValue(P_0, out value3))
				{
					value3 = ReflectionTools.GetFields(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(delegate(FieldInfo fieldInfo)
					{
						if (!fieldInfo.IsPublic)
						{
							while (true)
							{
								int num4 = 2089433377;
								while (true)
								{
									switch (num4 ^ 0x7C8A3922)
									{
									case 2:
										break;
									case 3:
										goto IL_002a;
									case 0:
										goto IL_004e;
									default:
										goto end_IL_0008;
									}
									break;
									IL_004e:
									if (fieldInfo.IsDefined(typeof(SerializeField), inherit: true))
									{
										num4 = 2089433379;
										continue;
									}
									goto IL_0090;
									IL_002a:
									int num5;
									if (fieldInfo.IsDefined(typeof(SerializeAttribute), inherit: true))
									{
										num4 = 2089433379;
										num5 = num4;
									}
									else
									{
										num4 = 2089433378;
										num5 = num4;
									}
								}
								continue;
								end_IL_0008:
								break;
							}
						}
						if (!fieldInfo.IsDefined(typeof(NonSerializedAttribute), inherit: true))
						{
							return !fieldInfo.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
						}
						goto IL_0090;
						IL_0090:
						return false;
					}).ToDictionary((FieldInfo fieldInfo) =>
					{
						string name;
						return (fieldInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(fieldInfo.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name : fieldInfo.Name;
					});
					num = 1518254253;
					goto IL_0021;
				}
				goto IL_0148;
				end_IL_000f:;
			}
			finally
			{
				if (list != null)
				{
					splitArrayPool.Push(list);
				}
			}
			return result;
		}

		private static int MoFMIKKAbAFeXkvWCCYMexnkIDdf(bool P_0, int P_1, string P_2)
		{
			lmUmIUiqeIxajQjGtPmZPfLhrti.Append(P_2[P_1]);
			int num = P_1 + 1;
			while (true)
			{
				int num2;
				int num3;
				if (num < P_2.Length)
				{
					num2 = -2117186999;
					num3 = num2;
				}
				else
				{
					num2 = -2117186998;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -2117186998)
					{
					case 2:
						num2 = -2117186999;
						continue;
					case 5:
						num++;
						num2 = -2117186996;
						continue;
					case 6:
						break;
					case 3:
					{
						int num4;
						if (P_2[num] != '\\')
						{
							num2 = -2117186994;
							num4 = num2;
						}
						else
						{
							num2 = -2117186995;
							num4 = num2;
						}
						continue;
					}
					case 1:
						lmUmIUiqeIxajQjGtPmZPfLhrti.Append(P_2[num + 1]);
						num++;
						num2 = -2117186993;
						continue;
					case 4:
						if (P_2[num] == '"')
						{
							lmUmIUiqeIxajQjGtPmZPfLhrti.Append(P_2[num]);
							return num;
						}
						lmUmIUiqeIxajQjGtPmZPfLhrti.Append(P_2[num]);
						num2 = -2117186993;
						continue;
					case 7:
						if (P_0)
						{
							lmUmIUiqeIxajQjGtPmZPfLhrti.Append(P_2[num]);
							num2 = -2117186997;
							continue;
						}
						goto case 1;
					default:
						return P_2.Length - 1;
					}
					break;
				}
			}
		}

		private static List<string> rWDWueNWcDGQIvTmeuKBBcWCENk(string P_0)
		{
			List<string> list = ((splitArrayPool.Count > 0) ? splitArrayPool.Pop() : new List<string>());
			list.Clear();
			char c = default(char);
			int num2 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = 1750078807;
				while (true)
				{
					switch (num ^ 0x68501552)
					{
					case 16:
						break;
					case 3:
						c = P_0[num2];
						num = 1750078787;
						continue;
					case 1:
						num4++;
						num = 1750078800;
						continue;
					case 10:
						num = 1750078810;
						continue;
					case 7:
						num = 1750078811;
						continue;
					case 11:
						num2 = 1;
						num = 1750078808;
						continue;
					case 4:
						list.Add(lmUmIUiqeIxajQjGtPmZPfLhrti.ToString());
						lmUmIUiqeIxajQjGtPmZPfLhrti.Length = 0;
						num = 1750078805;
						continue;
					case 14:
					{
						int num3;
						if (c == ':')
						{
							num = 1750078814;
							num3 = num;
						}
						else
						{
							num = 1750078815;
							num3 = num;
						}
						continue;
					}
					case 0:
						lmUmIUiqeIxajQjGtPmZPfLhrti.Length = 0;
						num = 1750078809;
						continue;
					case 13:
						switch (c)
						{
						case '[':
						case '{':
							break;
						default:
							goto IL_013a;
						case ']':
						case '}':
							goto IL_0144;
						case '\\':
						case '|':
							goto IL_01ae;
						}
						goto case 1;
					case 18:
						goto IL_0144;
					case 2:
						num = 1750078813;
						continue;
					case 6:
						num2 = MoFMIKKAbAFeXkvWCCYMexnkIDdf(true, num2, P_0);
						num = 1750078811;
						continue;
					case 12:
					{
						int num5;
						if (num4 != 0)
						{
							num = 1750078813;
							num5 = num;
						}
						else
						{
							num = 1750078806;
							num5 = num;
						}
						continue;
					}
					case 17:
						if (c > ',')
						{
							goto case 14;
						}
						if (c == '"')
						{
							goto case 6;
						}
						if (c != ',')
						{
							num = 1750078813;
							continue;
						}
						goto case 12;
					case 5:
						num4 = 0;
						num = 1750078802;
						continue;
					case 15:
						goto IL_01ae;
					case 9:
						num2++;
						num = 1750078810;
						continue;
					default:
						{
							if (num2 >= P_0.Length - 1)
							{
								if (lmUmIUiqeIxajQjGtPmZPfLhrti.Length == 0)
								{
									return list;
								}
								list.Add(lmUmIUiqeIxajQjGtPmZPfLhrti.ToString());
								return list;
							}
							goto case 3;
						}
						IL_01ae:
						lmUmIUiqeIxajQjGtPmZPfLhrti.Append(P_0[num2]);
						num = 1750078811;
						continue;
						IL_0144:
						num4--;
						num = 1750078813;
						continue;
						IL_013a:
						num = 1750078813;
						continue;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static bool NHfQSPECqHpnSZGAHDKAftXSZeg(FieldInfo P_0)
		{
			if (!P_0.IsPublic)
			{
				while (true)
				{
					int num = 2089433377;
					while (true)
					{
						switch (num ^ 0x7C8A3922)
						{
						case 2:
							break;
						case 3:
							goto IL_002a;
						case 0:
							goto IL_004e;
						default:
							goto end_IL_0008;
						}
						break;
						IL_004e:
						if (P_0.IsDefined(typeof(SerializeField), inherit: true))
						{
							num = 2089433379;
							continue;
						}
						goto IL_0090;
						IL_002a:
						int num2;
						if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true))
						{
							num = 2089433379;
							num2 = num;
						}
						else
						{
							num = 2089433378;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!P_0.IsDefined(typeof(NonSerializedAttribute), inherit: true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
			}
			goto IL_0090;
			IL_0090:
			return false;
		}

		[CompilerGenerated]
		private static string zCadFLpeYAEktpuvIaNoBqImVLA(FieldInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}

		[CompilerGenerated]
		private static bool LJvIHjLZYTQrhVcxggmZPtyfaTQd(PropertyInfo P_0)
		{
			if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), inherit: true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string RaoytZmktxaigVRoabUTnLBtyDu(PropertyInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}
	}
}
