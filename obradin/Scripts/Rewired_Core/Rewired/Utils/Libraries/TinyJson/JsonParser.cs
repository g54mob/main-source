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

		private static StringBuilder bYOseOqtFMGhZFCmMEBGaAjwmlE = new StringBuilder();

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> qYckNrBSyujMzyehMpRjtDcTIDIi = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> KOvzKrYXYIdzJcnlYhhJBslYfOB = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		[CompilerGenerated]
		private static Func<FieldInfo, bool> nhZhHiEaFeFZfvvFfeUphFgcpoy;

		[CompilerGenerated]
		private static Func<FieldInfo, string> VwQiXDpZbbShTuzxBExijEwCecS;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> sHxxrDBvVUkySmUWucVKhMUkxOo;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> OmcCBAJtesowwyxbanGKlSIvdcL;

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
					value = default(T);
					result = false;
				}
				else
				{
					char c = default(char);
					int num2 = default(int);
					while (true)
					{
						IL_0087:
						bYOseOqtFMGhZFCmMEBGaAjwmlE.Length = 0;
						int num = -151196115;
						while (true)
						{
							switch (num ^ -151196123)
							{
							case 11:
								num = -151196128;
								continue;
							default:
								goto end_IL_001b;
							case 4:
								c = json[num2];
								num = -151196122;
								continue;
							case 8:
								num2 = 0;
								num = -151196116;
								continue;
							case 0:
								result = true;
								num = -151196121;
								continue;
							case 10:
								num2++;
								num = -151196116;
								continue;
							case 5:
								break;
							case 6:
								num = -151196113;
								continue;
							case 1:
								num2 = EkXqrISTUKKOfuOgjhIRIaDbiVB(true, num2, json);
								num = -151196125;
								continue;
							case 3:
							{
								int num3;
								if (c == '"')
								{
									num = -151196124;
									num3 = num;
								}
								else
								{
									num = -151196126;
									num3 = num;
								}
								continue;
							}
							case 9:
								if (num2 >= json.Length)
								{
									bool flag;
									value = (T)sUKdILaZWeDrhasByEWpgSlbzHuE(typeof(T), bYOseOqtFMGhZFCmMEBGaAjwmlE.ToString(), preferredAnonymousObjectType, out flag);
									num = -151196123;
									continue;
								}
								goto case 4;
							case 7:
								if (!char.IsWhiteSpace(c))
								{
									bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(c);
									num = -151196113;
									continue;
								}
								goto case 10;
							case 2:
								goto end_IL_001b;
							}
							goto IL_0087;
							continue;
							end_IL_001b:
							break;
						}
						break;
					}
				}
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
				goto IL_0008;
			}
			bYOseOqtFMGhZFCmMEBGaAjwmlE.Length = 0;
			int num = 0;
			int num2 = 1512146491;
			goto IL_000d;
			IL_000d:
			char c = default(char);
			while (true)
			{
				switch (num2 ^ 0x5A21863E)
				{
				case 0:
					break;
				case 4:
					return default(T);
				case 3:
					if (!char.IsWhiteSpace(c))
					{
						bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(c);
						num2 = 1512146492;
						continue;
					}
					goto case 2;
				case 2:
					num++;
					num2 = 1512146491;
					continue;
				case 1:
					c = json[num];
					if (c == '"')
					{
						num = EkXqrISTUKKOfuOgjhIRIaDbiVB(true, num, json);
						num2 = 1512146492;
						continue;
					}
					goto case 3;
				default:
				{
					bool flag;
					if (num >= json.Length)
					{
						return (T)sUKdILaZWeDrhasByEWpgSlbzHuE(typeof(T), bYOseOqtFMGhZFCmMEBGaAjwmlE.ToString(), preferredAnonymousObjectType, out flag);
					}
					goto case 1;
				}
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1512146490;
			goto IL_000d;
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
				goto IL_0008;
			}
			bYOseOqtFMGhZFCmMEBGaAjwmlE.Length = 0;
			int num = 0;
			int num2 = 1180323438;
			goto IL_000d;
			IL_000d:
			char c = default(char);
			while (true)
			{
				switch (num2 ^ 0x465A4E69)
				{
				case 8:
					break;
				case 6:
					return null;
				case 4:
				{
					int num4;
					if (c == '"')
					{
						num2 = 1180323432;
						num4 = num2;
					}
					else
					{
						num2 = 1180323434;
						num4 = num2;
					}
					continue;
				}
				case 0:
					num2 = 1180323435;
					continue;
				case 1:
					num = EkXqrISTUKKOfuOgjhIRIaDbiVB(true, num, json);
					num2 = 1180323433;
					continue;
				case 7:
				{
					int num3;
					if (num >= json.Length)
					{
						num2 = 1180323424;
						num3 = num2;
					}
					else
					{
						num2 = 1180323436;
						num3 = num2;
					}
					continue;
				}
				case 5:
					c = json[num];
					num2 = 1180323437;
					continue;
				case 3:
					if (!char.IsWhiteSpace(c))
					{
						bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(c);
						num2 = 1180323435;
						continue;
					}
					goto case 2;
				case 2:
					num++;
					num2 = 1180323438;
					continue;
				default:
				{
					bool flag;
					return sUKdILaZWeDrhasByEWpgSlbzHuE(type, bYOseOqtFMGhZFCmMEBGaAjwmlE.ToString(), preferredAnonymousObjectType, out flag);
				}
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = 1180323439;
			goto IL_000d;
		}

		private static object sUKdILaZWeDrhasByEWpgSlbzHuE(Type P_0, string P_1, Type P_2, out bool P_3)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_3 = false;
				goto IL_000b;
			}
			int num;
			double result3 = default(double);
			if (object.ReferenceEquals(P_0, typeof(string)))
			{
				num = 698079099;
			}
			else
			{
				if (object.ReferenceEquals(P_0, typeof(int)))
				{
					int result;
					P_3 = int.TryParse(P_1, out result);
					return result;
				}
				if (object.ReferenceEquals(P_0, typeof(float)))
				{
					float result2;
					P_3 = float.TryParse(P_1, NumberStyles.Any, CultureInfo.InvariantCulture, out result2);
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
								string g = (string)sUKdILaZWeDrhasByEWpgSlbzHuE(typeof(string), P_1, P_2, out flag);
								if (!flag)
								{
									P_3 = false;
									return Guid.Empty;
								}
								P_3 = true;
								return new Guid(g);
							}
							catch
							{
								P_3 = false;
								return Guid.Empty;
							}
						}
						if (ReflectionTools.IsEnum(P_0))
						{
							Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(P_0);
							bool flag2 = default(bool);
							object obj2 = default(object);
							while (true)
							{
								int num2 = 698079100;
								while (true)
								{
									switch (num2 ^ 0x299BD77D)
									{
									case 2:
										break;
									case 0:
										P_3 = true;
										num2 = 698079096;
										continue;
									case 4:
										goto IL_023d;
									case 3:
										goto IL_024c;
									case 1:
										obj2 = sUKdILaZWeDrhasByEWpgSlbzHuE(underlyingEnumType, P_1, P_2, out flag2);
										num2 = 698079097;
										continue;
									default:
										return Enum.ToObject(P_0, obj2);
									}
									break;
									IL_024c:
									if (!ReflectionTools.IsValueType(obj2.GetType()))
									{
										goto end_IL_0209;
									}
									num2 = 698079101;
									continue;
									IL_023d:
									if (!flag2 || obj2 == null)
									{
										goto end_IL_0209;
									}
									num2 = 698079102;
								}
								continue;
								end_IL_0209:
								break;
							}
							try
							{
								obj2 = sUKdILaZWeDrhasByEWpgSlbzHuE(typeof(string), P_1, P_2, out flag2);
								if (flag2)
								{
									while (true)
									{
										IL_0297:
										int num3 = 698079102;
										while (true)
										{
											switch (num3 ^ 0x299BD77D)
											{
											case 2:
												break;
											default:
												goto end_IL_029c;
											case 1:
												P_3 = true;
												return obj2;
											case 0:
											{
												obj2 = Enum.Parse(P_0, (string)obj2, true);
												int num5;
												if (obj2 != null)
												{
													num3 = 698079100;
													num5 = num3;
												}
												else
												{
													num3 = 698079097;
													num5 = num3;
												}
												continue;
											}
											case 3:
											{
												int num4;
												if (string.IsNullOrEmpty((string)obj2))
												{
													num3 = 698079097;
													num4 = num3;
												}
												else
												{
													num3 = 698079101;
													num4 = num3;
												}
												continue;
											}
											case 4:
												goto end_IL_029c;
											}
											goto IL_0297;
											continue;
											end_IL_029c:
											break;
										}
										break;
									}
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
						if (P_2 != null)
						{
							goto IL_0331;
						}
						goto IL_0475;
					}
					if (string.Equals(P_1, "true", StringComparison.OrdinalIgnoreCase))
					{
						P_3 = true;
						return true;
					}
					if (!string.Equals(P_1, "false", StringComparison.OrdinalIgnoreCase))
					{
						P_3 = false;
						return false;
					}
					num = 698079100;
				}
				else
				{
					P_3 = double.TryParse(P_1, NumberStyles.Any, CultureInfo.InvariantCulture, out result3);
					num = 698079103;
				}
			}
			goto IL_0010;
			IL_0010:
			string text = default(string);
			while (true)
			{
				switch (num ^ 0x299BD77D)
				{
				case 3:
					break;
				case 5:
					return null;
				case 6:
					if (P_1.Length <= 2)
					{
						P_3 = false;
						return string.Empty;
					}
					text = P_1.Substring(1, P_1.Length - 2);
					P_3 = true;
					num = 698079097;
					continue;
				case 2:
					return result3;
				case 4:
					return text.Replace("\\", string.Empty);
				case 1:
					P_3 = true;
					num = 698079101;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num = 698079096;
			goto IL_0010;
			IL_0331:
			int num6 = 698079095;
			goto IL_0336;
			IL_0463:
			if (ReflectionTools.DoesTypeImplement(P_2, P_0))
			{
				return flrtfZtMzlaJCcNGRmbncUsgXgdQ(P_1, P_2, out P_3);
			}
			goto IL_0475;
			IL_0408:
			bool flag3 = default(bool);
			Type[] genericArguments = default(Type[]);
			Type type = default(Type);
			if (flag3 && P_0.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				genericArguments = ReflectionTools.GetGenericArguments(P_0);
				type = genericArguments[0];
				num6 = 698079088;
				goto IL_0336;
			}
			if (object.ReferenceEquals(P_0, typeof(object)))
			{
				return flrtfZtMzlaJCcNGRmbncUsgXgdQ(P_1, P_2, out P_3);
			}
			if (P_1[0] == '{' && P_1[P_1.Length - 1] == '}')
			{
				P_3 = true;
				return gHfWWkVHUWjTTHkZnJaLQhsStcS(P_0, P_1, P_2);
			}
			P_3 = false;
			return null;
			IL_0475:
			Type elementType = default(Type);
			if (ReflectionTools.IsArray(P_0))
			{
				elementType = P_0.GetElementType();
				int num7;
				if (P_1[0] != '[')
				{
					num6 = 698079091;
					num7 = num6;
				}
				else
				{
					num6 = 698079097;
					num7 = num6;
				}
			}
			else
			{
				flag3 = ReflectionTools.IsGenericType(P_0);
				if (!flag3)
				{
					goto IL_0408;
				}
				num6 = 698079093;
			}
			goto IL_0336;
			IL_0336:
			int num9 = default(int);
			List<string> list3 = default(List<string>);
			Array array = default(Array);
			List<string> list = default(List<string>);
			int num8 = default(int);
			IList list2 = default(IList);
			Type type2 = default(Type);
			int num12 = default(int);
			string key = default(string);
			while (true)
			{
				switch (num6 ^ 0x299BD77D)
				{
				case 3:
					break;
				case 0:
					if (num9 >= list3.Count)
					{
						splitArrayPool.Push(list3);
						num6 = 698079092;
						continue;
					}
					goto case 15;
				case 1:
				{
					bool flag5;
					array.SetValue(sUKdILaZWeDrhasByEWpgSlbzHuE(elementType, list[num8], P_2, out flag5), num8);
					num6 = 698079089;
					continue;
				}
				case 5:
					array = Array.CreateInstance(elementType, list.Count);
					num8 = 0;
					num6 = 698079085;
					continue;
				case 12:
					num8++;
					num6 = 698079085;
					continue;
				case 9:
					P_3 = true;
					return list2;
				case 16:
					if (num8 >= list.Count)
					{
						splitArrayPool.Push(list);
						P_3 = true;
						num6 = 698079103;
						continue;
					}
					goto case 1;
				case 10:
					goto IL_0463;
				case 17:
					goto IL_04a7;
				case 14:
					P_3 = false;
					num6 = 698079094;
					continue;
				case 6:
					P_3 = false;
					return null;
				case 15:
				{
					bool flag4;
					list2.Add(sUKdILaZWeDrhasByEWpgSlbzHuE(type2, list3[num9], P_2, out flag4));
					num9++;
					num6 = 698079101;
					continue;
				}
				case 2:
					return array;
				case 4:
					goto IL_055d;
				case 11:
					return null;
				case 13:
					goto IL_058d;
				case 8:
					goto IL_05cd;
				default:
					goto IL_060b;
				}
				break;
				IL_05cd:
				if (P_0.GetGenericTypeDefinition() == typeof(List<>))
				{
					type2 = ReflectionTools.GetGenericArguments(P_0)[0];
					int num10;
					if (P_1[0] == '[')
					{
						num6 = 698079084;
						num10 = num6;
					}
					else
					{
						num6 = 698079099;
						num10 = num6;
					}
					continue;
				}
				goto IL_0408;
				IL_055d:
				if (P_1[P_1.Length - 1] != ']')
				{
					num6 = 698079091;
					continue;
				}
				list = xnHRqaTqDTAykuvCThRUiqoFtXYP(P_1);
				num6 = 698079096;
				continue;
				IL_04a7:
				if (P_1[P_1.Length - 1] != ']')
				{
					num6 = 698079099;
					continue;
				}
				list2 = (IList)Factory.CreateInstance(typeof(List<>).MakeGenericType(type2));
				list3 = xnHRqaTqDTAykuvCThRUiqoFtXYP(P_1);
				num9 = 0;
				num6 = 698079101;
				continue;
				IL_060b:
				P_3 = false;
				return null;
				IL_058d:
				Type type3 = genericArguments[1];
				if (type != typeof(string))
				{
					P_3 = false;
					return null;
				}
				if (P_1[0] == '{')
				{
					if (P_1[P_1.Length - 1] != '}')
					{
						num6 = 698079098;
						continue;
					}
					List<string> list4 = xnHRqaTqDTAykuvCThRUiqoFtXYP(P_1);
					try
					{
						if (list4.Count % 2 != 0)
						{
							P_3 = false;
							return null;
						}
						while (true)
						{
							IDictionary dictionary = (IDictionary)Factory.CreateInstance(typeof(Dictionary<, >).MakeGenericType(type, type3));
							int num11 = 698079103;
							while (true)
							{
								switch (num11 ^ 0x299BD77D)
								{
								case 4:
									num11 = 698079100;
									continue;
								case 1:
									break;
								case 5:
								{
									bool flag6;
									object value = sUKdILaZWeDrhasByEWpgSlbzHuE(type3, list4[num12 + 1], P_2, out flag6);
									dictionary.Add(key, value);
									num11 = 698079098;
									continue;
								}
								case 2:
									num12 = 0;
									num11 = 698079102;
									continue;
								case 0:
									key = list4[num12].Substring(1, list4[num12].Length - 2);
									num11 = 698079096;
									continue;
								case 6:
								{
									int num13;
									if (list4[num12].Length <= 2)
									{
										num11 = 698079098;
										num13 = num11;
									}
									else
									{
										num11 = 698079101;
										num13 = num11;
									}
									continue;
								}
								case 3:
									if (num12 >= list4.Count)
									{
										P_3 = true;
										num11 = 698079093;
										continue;
									}
									goto case 6;
								case 7:
									num12 += 2;
									num11 = 698079102;
									continue;
								default:
									return dictionary;
								}
								break;
							}
						}
					}
					finally
					{
						if (list4 != null)
						{
							splitArrayPool.Push(list4);
						}
					}
				}
				goto IL_060b;
			}
			goto IL_0331;
		}

		private static object flrtfZtMzlaJCcNGRmbncUsgXgdQ(string P_0, Type P_1, out bool P_2)
		{
			if (P_0.Length == 0)
			{
				P_2 = false;
				return null;
			}
			object result = default(object);
			if (P_0[0] == '{' && P_0[P_0.Length - 1] == '}')
			{
				List<string> list = xnHRqaTqDTAykuvCThRUiqoFtXYP(P_0);
				try
				{
					if (list.Count % 2 != 0)
					{
						P_2 = false;
						goto IL_0047;
					}
					goto IL_01ae;
					IL_01ae:
					int num;
					if (P_1 != null)
					{
						int num2;
						if (!ReflectionTools.DoesTypeImplement(P_1, typeof(IAddKeyValue<string, object>)))
						{
							num = 177145047;
							num2 = num;
						}
						else
						{
							num = 177145049;
							num2 = num;
						}
						goto IL_004c;
					}
					goto IL_013f;
					IL_0047:
					num = 177145045;
					goto IL_004c;
					IL_004c:
					Dictionary<string, object> dictionary = default(Dictionary<string, object>);
					int num4 = default(int);
					IAddKeyValue<string, object> addKeyValue = default(IAddKeyValue<string, object>);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ 0xA8F04DD)
						{
						case 3:
							break;
						default:
							goto end_IL_0037;
						case 9:
							goto IL_0090;
						case 7:
						{
							bool flag;
							dictionary.Add(list[num4].Substring(1, list[num4].Length - 2), flrtfZtMzlaJCcNGRmbncUsgXgdQ(list[num4 + 1], P_1, out flag));
							num4 += 2;
							num = 177145044;
							continue;
						}
						case 8:
							result = null;
							goto end_IL_0037;
						case 0:
						{
							bool flag2;
							addKeyValue.Add(list[num3].Substring(1, list[num3].Length - 2), flrtfZtMzlaJCcNGRmbncUsgXgdQ(list[num3 + 1], P_1, out flag2));
							num = 177145048;
							continue;
						}
						case 10:
							goto IL_013f;
						case 4:
							addKeyValue = (IAddKeyValue<string, object>)Factory.CreateInstance(P_1, new object[1] { list.Count / 2 });
							num3 = 0;
							num = 177145041;
							continue;
						case 1:
							goto end_IL_0037;
						case 2:
							P_2 = true;
							result = dictionary;
							num = 177145046;
							continue;
						case 6:
							goto IL_01ae;
						case 5:
							num3 += 2;
							num = 177145041;
							continue;
						case 12:
							if (num3 >= list.Count)
							{
								P_2 = true;
								result = addKeyValue;
								num = 177145052;
								continue;
							}
							goto case 0;
						case 11:
							goto end_IL_0037;
						}
						break;
						IL_0090:
						int num5;
						if (num4 >= list.Count)
						{
							num = 177145055;
							num5 = num;
						}
						else
						{
							num = 177145050;
							num5 = num;
						}
					}
					goto IL_0047;
					IL_013f:
					dictionary = new Dictionary<string, object>(list.Count / 2);
					num4 = 0;
					num = 177145044;
					goto IL_004c;
					end_IL_0037:;
				}
				finally
				{
					if (list != null)
					{
						splitArrayPool.Push(list);
					}
				}
			}
			else
			{
				if (P_0[0] != '[')
				{
					goto IL_03fa;
				}
				while (true)
				{
					int num6 = 177145052;
					while (true)
					{
						switch (num6 ^ 0xA8F04DD)
						{
						case 0:
							break;
						case 1:
							goto IL_0241;
						default:
							goto end_IL_0223;
						}
						break;
						IL_0241:
						if (P_0[P_0.Length - 1] == ']')
						{
							num6 = 177145055;
							continue;
						}
						goto IL_03fa;
					}
					continue;
					end_IL_0223:
					break;
				}
				List<string> list2 = xnHRqaTqDTAykuvCThRUiqoFtXYP(P_0);
				try
				{
					IAddValue<object> addValue = default(IAddValue<object>);
					if (P_1 != null && ReflectionTools.DoesTypeImplement(P_1, typeof(IAddValue<object>)))
					{
						addValue = (IAddValue<object>)Factory.CreateInstance(P_1, new object[1] { list2.Count });
						goto IL_02a7;
					}
					goto IL_0375;
					IL_02ac:
					int num7;
					int num9 = default(int);
					List<object> list3 = default(List<object>);
					int num8 = default(int);
					while (true)
					{
						switch (num7 ^ 0xA8F04DD)
						{
						case 8:
							break;
						default:
							goto end_IL_0265;
						case 6:
							goto IL_02e8;
						case 5:
						{
							bool flag3;
							addValue.Add(flrtfZtMzlaJCcNGRmbncUsgXgdQ(list2[num9], P_1, out flag3));
							num7 = 177145049;
							continue;
						}
						case 1:
							num9 = 0;
							num7 = 177145051;
							continue;
						case 0:
							P_2 = true;
							num7 = 177145050;
							continue;
						case 10:
						{
							bool flag4;
							list3.Add(flrtfZtMzlaJCcNGRmbncUsgXgdQ(list2[num8], P_1, out flag4));
							num8++;
							num7 = 177145054;
							continue;
						}
						case 4:
							num9++;
							num7 = 177145051;
							continue;
						case 2:
							goto IL_0375;
						case 7:
							result = addValue;
							goto end_IL_0265;
						case 3:
							if (num8 >= list2.Count)
							{
								P_2 = true;
								result = list3;
								num7 = 177145044;
								continue;
							}
							goto case 10;
						case 9:
							goto end_IL_0265;
						}
						break;
						IL_02e8:
						int num10;
						if (num9 >= list2.Count)
						{
							num7 = 177145053;
							num10 = num7;
						}
						else
						{
							num7 = 177145048;
							num10 = num7;
						}
					}
					goto IL_02a7;
					IL_0375:
					list3 = new List<object>(list2.Count);
					num8 = 0;
					num7 = 177145054;
					goto IL_02ac;
					IL_02a7:
					num7 = 177145052;
					goto IL_02ac;
					end_IL_0265:;
				}
				finally
				{
					if (list2 != null)
					{
						while (true)
						{
							IL_03c8:
							int num11 = 177145052;
							while (true)
							{
								switch (num11 ^ 0xA8F04DD)
								{
								case 0:
									break;
								default:
									goto end_IL_03cd;
								case 1:
									goto IL_03e6;
								case 2:
									goto end_IL_03cd;
								}
								goto IL_03c8;
								IL_03e6:
								splitArrayPool.Push(list2);
								num11 = 177145055;
								continue;
								end_IL_03cd:
								break;
							}
							break;
						}
					}
				}
			}
			return result;
			IL_0456:
			int num12 = 177145052;
			goto IL_045b;
			IL_0478:
			double result2 = default(double);
			if (P_0.Contains("."))
			{
				P_2 = double.TryParse(P_0, NumberStyles.Any, CultureInfo.InvariantCulture, out result2);
				num12 = 177145053;
				goto IL_045b;
			}
			int result3;
			P_2 = int.TryParse(P_0, out result3);
			return result3;
			IL_03fa:
			if (P_0[0] == '"' && P_0[P_0.Length - 1] == '"')
			{
				string text = P_0.Substring(1, P_0.Length - 2);
				P_2 = true;
				return text.Replace("\\", string.Empty);
			}
			if (!char.IsDigit(P_0[0]))
			{
				if (P_0[0] == '-')
				{
					goto IL_0456;
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
				num12 = 177145055;
				goto IL_045b;
			}
			goto IL_0478;
			IL_045b:
			switch (num12 ^ 0xA8F04DD)
			{
			case 3:
				break;
			case 1:
				goto IL_0478;
			case 0:
				return result2;
			default:
				return null;
			}
			goto IL_0456;
		}

		private static object gHfWWkVHUWjTTHkZnJaLQhsStcS(Type P_0, string P_1, Type P_2)
		{
			object obj = Factory.CreateInstance(P_0);
			List<string> list = xnHRqaTqDTAykuvCThRUiqoFtXYP(P_1);
			try
			{
				if (list.Count % 2 != 0)
				{
					return obj;
				}
				Dictionary<string, PropertyInfo> value2 = default(Dictionary<string, PropertyInfo>);
				string key = default(string);
				PropertyInfo value3 = default(PropertyInfo);
				int num3 = default(int);
				string text = default(string);
				while (true)
				{
					Dictionary<string, FieldInfo> value;
					int num;
					int num2;
					if (qYckNrBSyujMzyehMpRjtDcTIDIi.TryGetValue(P_0, out value))
					{
						num = -699464219;
						num2 = num;
					}
					else
					{
						num = -699464210;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -699464212)
						{
						case 11:
							num = -699464216;
							continue;
						case 6:
							if (value2.TryGetValue(key, out value3))
							{
								int num5;
								if (!value3.CanWrite)
								{
									num = -699464213;
									num5 = num;
								}
								else
								{
									num = -699464212;
									num5 = num;
								}
								continue;
							}
							goto case 7;
						case 2:
							value = ReflectionTools.GetFields(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(delegate(FieldInfo fieldInfo)
							{
								if (!fieldInfo.IsPublic)
								{
									goto IL_0008;
								}
								goto IL_0057;
								IL_0008:
								int num7 = -2005212440;
								goto IL_000d;
								IL_000d:
								while (true)
								{
									switch (num7 ^ -2005212438)
									{
									case 3:
										break;
									case 2:
										goto IL_002a;
									case 1:
										goto IL_0057;
									default:
										return !fieldInfo.IsDefined(typeof(DoNotSerializeAttribute), true);
									}
									break;
									IL_002a:
									if (fieldInfo.IsDefined(typeof(SerializeAttribute), true))
									{
										goto IL_0057;
									}
									if (fieldInfo.IsDefined(typeof(SerializeField), true))
									{
										num7 = -2005212437;
										continue;
									}
									goto IL_0086;
								}
								goto IL_0008;
								IL_0086:
								return false;
								IL_0057:
								if (!fieldInfo.IsDefined(typeof(NonSerializedAttribute), true))
								{
									num7 = -2005212438;
									goto IL_000d;
								}
								goto IL_0086;
							}).ToDictionary((FieldInfo fieldInfo) =>
							{
								string name;
								return (fieldInfo.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(fieldInfo.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name)) ? name : fieldInfo.Name;
							});
							qYckNrBSyujMzyehMpRjtDcTIDIi.Add(P_0, value);
							num = -699464219;
							continue;
						case 10:
							value2 = (from propertyInfo in ReflectionTools.GetProperties(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
								where propertyInfo.CanWrite && propertyInfo.IsDefined(typeof(SerializeAttribute), true) && !propertyInfo.IsDefined(typeof(DoNotSerializeAttribute), true)
								select propertyInfo).ToDictionary(delegate(PropertyInfo propertyInfo)
							{
								if (propertyInfo.IsDefined(typeof(SerializeAttribute), true))
								{
									string name = default(string);
									while (true)
									{
										int num7 = -123285701;
										while (true)
										{
											switch (num7 ^ -123285702)
											{
											case 2:
												break;
											case 1:
												goto IL_0031;
											default:
												return name;
											}
											break;
											IL_0031:
											if (string.IsNullOrEmpty(name = (CollectionTools.GetValue(propertyInfo.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
											{
												goto end_IL_0013;
											}
											num7 = -123285702;
										}
										continue;
										end_IL_0013:
										break;
									}
								}
								return propertyInfo.Name;
							});
							KOvzKrYXYIdzJcnlYhhJBslYfOB.Add(P_0, value2);
							num = -699464215;
							continue;
						case 7:
							num3 += 2;
							num = -699464209;
							continue;
						case 1:
							num = -699464213;
							continue;
						case 8:
							if (list[num3].Length > 2)
							{
								key = list[num3].Substring(1, list[num3].Length - 2);
								text = list[num3 + 1];
								FieldInfo value4;
								if (value.TryGetValue(key, out value4))
								{
									bool flag2;
									value4.SetValue(obj, sUKdILaZWeDrhasByEWpgSlbzHuE(value4.FieldType, text, P_2, out flag2));
									num = -699464211;
									continue;
								}
								goto case 6;
							}
							goto case 7;
						case 0:
						{
							bool flag;
							value3.SetValue(obj, sUKdILaZWeDrhasByEWpgSlbzHuE(value3.PropertyType, text, P_2, out flag), null);
							num = -699464213;
							continue;
						}
						case 4:
							break;
						case 5:
							num3 = 0;
							num = -699464209;
							continue;
						case 9:
						{
							int num4;
							if (!KOvzKrYXYIdzJcnlYhhJBslYfOB.TryGetValue(P_0, out value2))
							{
								num = -699464218;
								num4 = num;
							}
							else
							{
								num = -699464215;
								num4 = num;
							}
							continue;
						}
						default:
							if (num3 >= list.Count)
							{
								ISerializationCallbackReceiver serializationCallbackReceiver = obj as ISerializationCallbackReceiver;
								if (serializationCallbackReceiver != null)
								{
									try
									{
										serializationCallbackReceiver.OnAfterDeserialize();
									}
									catch (Exception ex)
									{
										Logger.LogError(ex.ToString(), true);
									}
								}
								return obj;
							}
							goto case 8;
						}
						break;
					}
				}
			}
			finally
			{
				if (list != null)
				{
					while (true)
					{
						IL_0291:
						int num6 = -699464211;
						while (true)
						{
							switch (num6 ^ -699464212)
							{
							case 0:
								break;
							default:
								goto end_IL_0296;
							case 1:
								goto IL_02af;
							case 2:
								goto end_IL_0296;
							}
							goto IL_0291;
							IL_02af:
							splitArrayPool.Push(list);
							num6 = -699464210;
							continue;
							end_IL_0296:
							break;
						}
						break;
					}
				}
			}
		}

		private static int EkXqrISTUKKOfuOgjhIRIaDbiVB(bool P_0, int P_1, string P_2)
		{
			bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(P_2[P_1]);
			int num2 = default(int);
			while (true)
			{
				int num = -843291315;
				while (true)
				{
					switch (num ^ -843291313)
					{
					case 0:
						break;
					case 10:
						bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(P_2[num2]);
						return num2;
					case 4:
						if (P_2[num2] == '\\')
						{
							int num3;
							if (P_0)
							{
								num = -843291322;
								num3 = num;
							}
							else
							{
								num = -843291321;
								num3 = num;
							}
							continue;
						}
						goto case 5;
					case 6:
						num = -843291316;
						continue;
					case 7:
						num = -843291314;
						continue;
					case 1:
						num2++;
						num = -843291316;
						continue;
					case 9:
						bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(P_2[num2]);
						num = -843291321;
						continue;
					case 5:
						if (P_2[num2] != '"')
						{
							bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(P_2[num2]);
							num = -843291314;
						}
						else
						{
							num = -843291323;
						}
						continue;
					case 8:
						bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(P_2[num2 + 1]);
						num2++;
						num = -843291320;
						continue;
					case 2:
						num2 = P_1 + 1;
						num = -843291319;
						continue;
					default:
						if (num2 >= P_2.Length)
						{
							return P_2.Length - 1;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		private static List<string> xnHRqaTqDTAykuvCThRUiqoFtXYP(string P_0)
		{
			List<string> list = ((splitArrayPool.Count > 0) ? splitArrayPool.Pop() : new List<string>());
			list.Clear();
			int num = 0;
			int num3 = default(int);
			char c = default(char);
			while (true)
			{
				int num2 = -313757044;
				while (true)
				{
					switch (num2 ^ -313757043)
					{
					case 13:
						break;
					case 1:
						bYOseOqtFMGhZFCmMEBGaAjwmlE.Length = 0;
						num3 = 1;
						num2 = -313757048;
						continue;
					case 3:
						num2 = -313757052;
						continue;
					case 0:
						num3 = EkXqrISTUKKOfuOgjhIRIaDbiVB(true, num3, P_0);
						num2 = -313757042;
						continue;
					case 6:
						num2 = -313757052;
						continue;
					case 10:
						switch (c)
						{
						case '\\':
						case '|':
							goto IL_00df;
						case ':':
							goto IL_00fb;
						case '[':
						case '{':
							goto IL_0135;
						case ']':
						case '}':
							goto IL_0162;
						}
						num2 = -313757047;
						continue;
					case 4:
						goto IL_00df;
					case 12:
						goto IL_00fb;
					case 11:
						c = P_0[num3];
						num2 = -313757051;
						continue;
					case 2:
						goto IL_0135;
					case 8:
						if (c > ',')
						{
							goto case 10;
						}
						if (c == '"')
						{
							goto case 0;
						}
						if (c != ',')
						{
							num2 = -313757047;
							continue;
						}
						goto IL_00fb;
					case 7:
						goto IL_0162;
					case 9:
						num3++;
						num2 = -313757048;
						continue;
					default:
						{
							if (num3 >= P_0.Length - 1)
							{
								if (bYOseOqtFMGhZFCmMEBGaAjwmlE.Length == 0)
								{
									return list;
								}
								list.Add(bYOseOqtFMGhZFCmMEBGaAjwmlE.ToString());
								return list;
							}
							goto case 11;
						}
						IL_00fb:
						if (num == 0)
						{
							list.Add(bYOseOqtFMGhZFCmMEBGaAjwmlE.ToString());
							bYOseOqtFMGhZFCmMEBGaAjwmlE.Length = 0;
							num2 = -313757045;
							continue;
						}
						goto IL_00df;
						IL_00df:
						bYOseOqtFMGhZFCmMEBGaAjwmlE.Append(P_0[num3]);
						num2 = -313757052;
						continue;
						IL_0162:
						num--;
						num2 = -313757047;
						continue;
						IL_0135:
						num++;
						num2 = -313757047;
						continue;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static bool NTnqSJMTRTVZuGGcwjQRQqjNefO(FieldInfo P_0)
		{
			if (!P_0.IsPublic)
			{
				goto IL_0008;
			}
			goto IL_0057;
			IL_0008:
			int num = -2005212440;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -2005212438)
				{
				case 3:
					break;
				case 2:
					goto IL_002a;
				case 1:
					goto IL_0057;
				default:
					return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
				}
				break;
				IL_002a:
				if (P_0.IsDefined(typeof(SerializeAttribute), true))
				{
					goto IL_0057;
				}
				if (P_0.IsDefined(typeof(SerializeField), true))
				{
					num = -2005212437;
					continue;
				}
				goto IL_0086;
			}
			goto IL_0008;
			IL_0086:
			return false;
			IL_0057:
			if (!P_0.IsDefined(typeof(NonSerializedAttribute), true))
			{
				num = -2005212438;
				goto IL_000d;
			}
			goto IL_0086;
		}

		[CompilerGenerated]
		private static string jJEEJDnWDGGqCKeUMhNWzyMZtHt(FieldInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}

		[CompilerGenerated]
		private static bool TXdcdbXBtRDNPeANLRFEPqYurFoc(PropertyInfo P_0)
		{
			if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string FbwSSJcJAruMMMtGLtAECovqnsC(PropertyInfo P_0)
		{
			if (P_0.IsDefined(typeof(SerializeAttribute), true))
			{
				string name = default(string);
				while (true)
				{
					int num = -123285701;
					while (true)
					{
						switch (num ^ -123285702)
						{
						case 2:
							break;
						case 1:
							goto IL_0031;
						default:
							return name;
						}
						break;
						IL_0031:
						if (string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
						{
							goto end_IL_0013;
						}
						num = -123285702;
					}
					continue;
					end_IL_0013:
					break;
				}
			}
			return P_0.Name;
		}
	}
}
