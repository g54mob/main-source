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

		private static StringBuilder UiGrpFCGPSkncrvdsKXMJOteagV = new StringBuilder();

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> FigRKutykumzSMBgeLVlQswHuQZ = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> tknsOaiPSIUNmMayaHzXqipCMuW = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		[CompilerGenerated]
		private static Func<FieldInfo, bool> GyZiWpwRwosxGLUULQtnUoicfHh;

		[CompilerGenerated]
		private static Func<FieldInfo, string> gjWpSCTHTdhtCYRkbGgvESMQzBx;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> JZlEuQGxHGIJfoYTYVPAJSMcKVlT;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> bKuFLQhnKaHgJCioIdOSQKUtaCM;

		public static bool TryFromJson<T>(string json, out T value)
		{
			return TryFromJson<T>(json, out value, null);
		}

		[CustomObfuscation(rename = false)]
		internal static bool TryFromJson<T>(string json, out T value, Type preferredAnonymousObjectType)
		{
			try
			{
				if (string.IsNullOrEmpty(json))
				{
					value = default(T);
					return false;
				}
				char c = default(char);
				int num2 = default(int);
				while (true)
				{
					UiGrpFCGPSkncrvdsKXMJOteagV.Length = 0;
					int num = 1232193022;
					while (true)
					{
						switch (num ^ 0x4971C5FC)
						{
						case 6:
							num = 1232193016;
							continue;
						case 8:
							num = 1232193017;
							continue;
						case 7:
							c = json[num2];
							num = 1232193021;
							continue;
						case 1:
							if (c == '"')
							{
								num2 = zODtsPgEMWGtQSGhBuvRnbRleUQB(true, num2, json);
								num = 1232193012;
								continue;
							}
							goto case 3;
						case 5:
							num2++;
							num = 1232193020;
							continue;
						case 4:
							break;
						case 3:
						{
							int num3;
							if (!char.IsWhiteSpace(c))
							{
								num = 1232193013;
								num3 = num;
							}
							else
							{
								num = 1232193017;
								num3 = num;
							}
							continue;
						}
						case 2:
							num2 = 0;
							num = 1232193020;
							continue;
						case 9:
							UiGrpFCGPSkncrvdsKXMJOteagV.Append(c);
							num = 1232193017;
							continue;
						default:
							if (num2 >= json.Length)
							{
								bool flag;
								value = (T)XvQyJSzsOeEGWMrASHYhryzzLWj(typeof(T), UiGrpFCGPSkncrvdsKXMJOteagV.ToString(), preferredAnonymousObjectType, out flag);
								return true;
							}
							goto case 7;
						}
						break;
					}
				}
			}
			catch
			{
				while (true)
				{
					int num4 = 1232193021;
					while (true)
					{
						switch (num4 ^ 0x4971C5FC)
						{
						case 0:
							break;
						case 1:
							goto IL_0132;
						default:
							return false;
						}
						break;
						IL_0132:
						value = default(T);
						num4 = 1232193022;
					}
				}
			}
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
			UiGrpFCGPSkncrvdsKXMJOteagV.Length = 0;
			int num = 0;
			int num2 = -1443010166;
			goto IL_000d;
			IL_000d:
			char c = default(char);
			T result = default(T);
			while (true)
			{
				switch (num2 ^ -1443010164)
				{
				case 3:
					break;
				case 5:
					num++;
					num2 = -1443010166;
					continue;
				case 1:
					if (!char.IsWhiteSpace(c))
					{
						UiGrpFCGPSkncrvdsKXMJOteagV.Append(c);
						num2 = -1443010167;
						continue;
					}
					goto case 5;
				case 2:
					return result;
				case 0:
					c = json[num];
					if (c == '"')
					{
						num = zODtsPgEMWGtQSGhBuvRnbRleUQB(true, num, json);
						num2 = -1443010167;
						continue;
					}
					goto case 1;
				case 4:
					result = default(T);
					num2 = -1443010162;
					continue;
				default:
				{
					bool flag;
					if (num >= json.Length)
					{
						return (T)XvQyJSzsOeEGWMrASHYhryzzLWj(typeof(T), UiGrpFCGPSkncrvdsKXMJOteagV.ToString(), preferredAnonymousObjectType, out flag);
					}
					goto case 0;
				}
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1443010168;
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
				return null;
			}
			UiGrpFCGPSkncrvdsKXMJOteagV.Length = 0;
			char c = default(char);
			int num2 = default(int);
			while (true)
			{
				int num = -1452120723;
				while (true)
				{
					switch (num ^ -1452120724)
					{
					case 7:
						break;
					case 6:
						UiGrpFCGPSkncrvdsKXMJOteagV.Append(c);
						num = -1452120728;
						continue;
					case 3:
						num2 = zODtsPgEMWGtQSGhBuvRnbRleUQB(true, num2, json);
						num = -1452120728;
						continue;
					case 8:
					{
						c = json[num2];
						int num3;
						if (c == '"')
						{
							num = -1452120721;
							num3 = num;
						}
						else
						{
							num = -1452120727;
							num3 = num;
						}
						continue;
					}
					case 5:
					{
						int num4;
						if (!char.IsWhiteSpace(c))
						{
							num = -1452120726;
							num4 = num;
						}
						else
						{
							num = -1452120728;
							num4 = num;
						}
						continue;
					}
					case 2:
						num = -1452120724;
						continue;
					case 1:
						num2 = 0;
						num = -1452120722;
						continue;
					case 4:
						num2++;
						num = -1452120724;
						continue;
					default:
					{
						bool flag;
						if (num2 >= json.Length)
						{
							return XvQyJSzsOeEGWMrASHYhryzzLWj(type, UiGrpFCGPSkncrvdsKXMJOteagV.ToString(), preferredAnonymousObjectType, out flag);
						}
						goto case 8;
					}
					}
					break;
				}
			}
		}

		private static object XvQyJSzsOeEGWMrASHYhryzzLWj(Type P_0, string P_1, Type P_2, out bool P_3)
		{
			if (string.IsNullOrEmpty(P_1))
			{
				P_3 = false;
				goto IL_000e;
			}
			int num;
			object result2 = default(object);
			int num4;
			double result3 = default(double);
			if (!object.ReferenceEquals(P_0, typeof(string)))
			{
				if (object.ReferenceEquals(P_0, typeof(int)))
				{
					num = 1698557001;
				}
				else
				{
					if (object.ReferenceEquals(P_0, typeof(float)))
					{
						float result;
						P_3 = float.TryParse(P_1, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
						return result;
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
									string g = (string)XvQyJSzsOeEGWMrASHYhryzzLWj(typeof(string), P_1, P_2, out flag);
									if (!flag)
									{
										P_3 = false;
										result2 = Guid.Empty;
									}
									else
									{
										P_3 = true;
										result2 = new Guid(g);
									}
								}
								catch
								{
									P_3 = false;
									while (true)
									{
										IL_01e3:
										int num2 = 1698557001;
										while (true)
										{
											switch (num2 ^ 0x653DEC48)
											{
											case 0:
												break;
											default:
												goto end_IL_01e8;
											case 1:
												goto IL_0201;
											case 2:
												goto end_IL_01e8;
											}
											goto IL_01e3;
											IL_0201:
											result2 = Guid.Empty;
											num2 = 1698557002;
											continue;
											end_IL_01e8:
											break;
										}
										break;
									}
								}
								goto IL_07a4;
							}
							if (ReflectionTools.IsEnum(P_0))
							{
								Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(P_0);
								bool flag2 = default(bool);
								object obj2 = default(object);
								while (true)
								{
									int num3 = 1698557001;
									while (true)
									{
										switch (num3 ^ 0x653DEC48)
										{
										case 4:
											break;
										case 0:
											goto IL_0252;
										case 3:
											goto IL_026b;
										case 1:
											obj2 = XvQyJSzsOeEGWMrASHYhryzzLWj(underlyingEnumType, P_1, P_2, out flag2);
											num3 = 1698557003;
											continue;
										default:
											P_3 = true;
											return Enum.ToObject(P_0, obj2);
										}
										break;
										IL_026b:
										if (!flag2)
										{
											goto end_IL_022c;
										}
										num3 = 1698557000;
										continue;
										IL_0252:
										if (obj2 == null || !ReflectionTools.IsValueType(obj2.GetType()))
										{
											goto end_IL_022c;
										}
										num3 = 1698557002;
									}
									continue;
									end_IL_022c:
									break;
								}
								try
								{
									obj2 = XvQyJSzsOeEGWMrASHYhryzzLWj(typeof(string), P_1, P_2, out flag2);
									if (flag2 && !string.IsNullOrEmpty((string)obj2))
									{
										obj2 = Enum.Parse(P_0, (string)obj2, true);
										if (obj2 != null)
										{
											P_3 = true;
											result2 = obj2;
											goto IL_07a4;
										}
									}
								}
								catch
								{
								}
							}
							if (P_1 == "null")
							{
								goto IL_02f2;
							}
							if ((object)P_2 != null)
							{
								num4 = 1698557004;
								goto IL_02f7;
							}
							goto IL_055d;
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
						P_3 = true;
						num = 1698557004;
					}
					else
					{
						P_3 = double.TryParse(P_1, NumberStyles.Any, CultureInfo.InvariantCulture, out result3);
						num = 1698557005;
					}
				}
			}
			else
			{
				if (P_1.Length > 2)
				{
					string text = P_1.Substring(1, P_1.Length - 2);
					P_3 = true;
					return text.Replace("\\", string.Empty);
				}
				num = 1698557003;
			}
			goto IL_0013;
			IL_0737:
			int num5;
			while (true)
			{
				switch (num5 ^ 0x653DEC48)
				{
				case 2:
					break;
				case 4:
					return UCpdwYHDdllydarZidllwxgLktga(P_1, P_2, out P_3);
				case 1:
					P_3 = true;
					num5 = 1698557003;
					continue;
				case 0:
					goto IL_077d;
				default:
					return FHnbXxchISxcagtKBmuFxToEirP(P_0, P_1, P_2);
				}
				break;
				IL_077d:
				if (P_1[P_1.Length - 1] == '}')
				{
					num5 = 1698557001;
					continue;
				}
				goto IL_079f;
			}
			goto IL_0732;
			IL_03e0:
			P_3 = false;
			return null;
			IL_02f7:
			int num7 = default(int);
			List<string> list3 = default(List<string>);
			IList list2 = default(IList);
			Type type = default(Type);
			Array array = default(Array);
			int num6 = default(int);
			List<string> list = default(List<string>);
			Type elementType = default(Type);
			while (true)
			{
				switch (num4 ^ 0x653DEC48)
				{
				case 8:
					break;
				case 12:
					if (num7 >= list3.Count)
					{
						splitArrayPool.Push(list3);
						P_3 = true;
						return list2;
					}
					goto case 0;
				case 5:
					goto IL_03e0;
				case 0:
				{
					bool flag3;
					list2.Add(XvQyJSzsOeEGWMrASHYhryzzLWj(type, list3[num7], P_2, out flag3));
					num4 = 1698557007;
					continue;
				}
				case 16:
					goto IL_042c;
				case 6:
					if (P_1[0] == '[')
					{
						goto IL_0447;
					}
					goto case 3;
				case 1:
					return array;
				case 17:
					num6 = 0;
					num4 = 1698556994;
					continue;
				case 10:
					if (num6 >= list.Count)
					{
						splitArrayPool.Push(list);
						num4 = 1698556997;
						continue;
					}
					goto case 18;
				case 9:
					P_3 = true;
					return null;
				case 18:
				{
					bool flag4;
					array.SetValue(XvQyJSzsOeEGWMrASHYhryzzLWj(elementType, list[num6], P_2, out flag4), num6);
					num4 = 1698556995;
					continue;
				}
				case 15:
					return null;
				case 7:
					num7++;
					num4 = 1698556996;
					continue;
				case 3:
					P_3 = false;
					num4 = 1698556999;
					continue;
				case 4:
					goto IL_054b;
				case 13:
					P_3 = true;
					num4 = 1698557001;
					continue;
				case 11:
					num6++;
					num4 = 1698556994;
					continue;
				case 14:
					goto IL_05ba;
				default:
					return null;
				}
				break;
				IL_05ba:
				if ((object)P_0.GetGenericTypeDefinition() == typeof(List<>))
				{
					type = ReflectionTools.GetGenericArguments(P_0)[0];
					num4 = 1698557006;
					continue;
				}
				goto IL_0373;
				IL_0447:
				if (P_1[P_1.Length - 1] != ']')
				{
					num4 = 1698557003;
					continue;
				}
				list2 = (IList)Factory.CreateInstance(typeof(List<>).MakeGenericType(type));
				list3 = OVFHtttmPXAXTWjDfgVAGXsJKKZd(P_1);
				num7 = 0;
				num4 = 1698556996;
			}
			goto IL_02f2;
			IL_054b:
			if (ReflectionTools.DoesTypeImplement(P_2, P_0))
			{
				return UCpdwYHDdllydarZidllwxgLktga(P_1, P_2, out P_3);
			}
			goto IL_055d;
			IL_07a4:
			return result2;
			IL_02f2:
			num4 = 1698556993;
			goto IL_02f7;
			IL_079f:
			P_3 = false;
			return null;
			IL_0013:
			switch (num ^ 0x653DEC48)
			{
			case 0:
				break;
			case 5:
				return result3;
			case 3:
				P_3 = false;
				return string.Empty;
			case 1:
			{
				int result4;
				P_3 = int.TryParse(P_1, out result4);
				return result4;
			}
			case 2:
				return null;
			default:
				return false;
			}
			goto IL_000e;
			IL_000e:
			num = 1698557002;
			goto IL_0013;
			IL_0732:
			num5 = 1698557004;
			goto IL_0737;
			IL_042c:
			P_3 = false;
			num4 = 1698557002;
			goto IL_02f7;
			IL_0373:
			bool flag5 = default(bool);
			if (flag5 && (object)P_0.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				Type[] genericArguments = ReflectionTools.GetGenericArguments(P_0);
				Type type2 = genericArguments[0];
				Type type3 = genericArguments[1];
				if ((object)type2 != typeof(string))
				{
					P_3 = false;
					return null;
				}
				if (P_1[0] != '{')
				{
					goto IL_042c;
				}
				if (P_1[P_1.Length - 1] != '}')
				{
					num4 = 1698557016;
					goto IL_02f7;
				}
				List<string> list4 = OVFHtttmPXAXTWjDfgVAGXsJKKZd(P_1);
				try
				{
					if (list4.Count % 2 != 0)
					{
						P_3 = false;
						result2 = null;
					}
					else
					{
						while (true)
						{
							IL_062c:
							IDictionary dictionary = (IDictionary)Factory.CreateInstance(typeof(Dictionary<, >).MakeGenericType(type2, type3));
							int num8 = 0;
							int num9 = 1698557000;
							while (true)
							{
								switch (num9 ^ 0x653DEC48)
								{
								case 2:
									num9 = 1698557001;
									continue;
								case 1:
									break;
								case 3:
									num8 += 2;
									num9 = 1698557000;
									continue;
								case 4:
									if (list4[num8].Length > 2)
									{
										string key = list4[num8].Substring(1, list4[num8].Length - 2);
										bool flag6;
										object value = XvQyJSzsOeEGWMrASHYhryzzLWj(type3, list4[num8 + 1], P_2, out flag6);
										dictionary.Add(key, value);
										num9 = 1698557003;
										continue;
									}
									goto case 3;
								default:
									if (num8 >= list4.Count)
									{
										P_3 = true;
										result2 = dictionary;
										goto end_IL_0608;
									}
									goto case 4;
								}
								goto IL_062c;
								continue;
								end_IL_0608:
								break;
							}
							break;
						}
					}
				}
				finally
				{
					if (list4 != null)
					{
						while (true)
						{
							IL_06ee:
							int num10 = 1698557001;
							while (true)
							{
								switch (num10 ^ 0x653DEC48)
								{
								case 0:
									break;
								default:
									goto end_IL_06f3;
								case 1:
									goto IL_070c;
								case 2:
									goto end_IL_06f3;
								}
								goto IL_06ee;
								IL_070c:
								splitArrayPool.Push(list4);
								num10 = 1698557002;
								continue;
								end_IL_06f3:
								break;
							}
							break;
						}
					}
				}
				goto IL_07a4;
			}
			if (object.ReferenceEquals(P_0, typeof(object)))
			{
				goto IL_0732;
			}
			if (P_1[0] == '{')
			{
				num5 = 1698557000;
				goto IL_0737;
			}
			goto IL_079f;
			IL_055d:
			if (!ReflectionTools.IsArray(P_0))
			{
				flag5 = ReflectionTools.IsGenericType(P_0);
				if (!flag5)
				{
					goto IL_0373;
				}
				num4 = 1698556998;
			}
			else
			{
				elementType = P_0.GetElementType();
				if (P_1[0] != '[')
				{
					goto IL_03e0;
				}
				if (P_1[P_1.Length - 1] == ']')
				{
					list = OVFHtttmPXAXTWjDfgVAGXsJKKZd(P_1);
					array = Array.CreateInstance(elementType, list.Count);
					num4 = 1698557017;
				}
				else
				{
					num4 = 1698557005;
				}
			}
			goto IL_02f7;
		}

		private static object UCpdwYHDdllydarZidllwxgLktga(string P_0, Type P_1, out bool P_2)
		{
			if (P_0.Length == 0)
			{
				goto IL_0008;
			}
			int num;
			if (P_0[0] == '{')
			{
				num = 965062157;
				goto IL_000d;
			}
			goto IL_0266;
			IL_0416:
			int num2 = 965062157;
			goto IL_041b;
			IL_041b:
			while (true)
			{
				switch (num2 ^ 0x3985AE0C)
				{
				case 4:
					break;
				case 1:
					goto IL_043f;
				case 2:
				{
					string text = P_0.Substring(1, P_0.Length - 2);
					P_2 = true;
					return text.Replace("\\", string.Empty);
				}
				case 3:
					goto IL_04a1;
				default:
					return true;
				}
				break;
				IL_043f:
				if (P_0[P_0.Length - 1] == '"')
				{
					num2 = 965062158;
					continue;
				}
				goto IL_047e;
			}
			goto IL_0416;
			IL_0008:
			num = 965062158;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x3985AE0C)
			{
			case 0:
				break;
			case 2:
				P_2 = false;
				return null;
			default:
				goto IL_0040;
			}
			goto IL_0008;
			IL_04a1:
			if (P_0.Contains("."))
			{
				double result;
				P_2 = double.TryParse(P_0, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
				return result;
			}
			int result2;
			P_2 = int.TryParse(P_0, out result2);
			return result2;
			IL_0040:
			if (P_0[P_0.Length - 1] != '}')
			{
				goto IL_0266;
			}
			List<string> list = OVFHtttmPXAXTWjDfgVAGXsJKKZd(P_0);
			object result3 = default(object);
			try
			{
				if (list.Count % 2 != 0)
				{
					goto IL_0069;
				}
				goto IL_0102;
				IL_0069:
				int num3 = 965062159;
				goto IL_006e;
				IL_006e:
				IAddKeyValue<string, object> addKeyValue = default(IAddKeyValue<string, object>);
				int num5 = default(int);
				Dictionary<string, object> dictionary = default(Dictionary<string, object>);
				int num4 = default(int);
				while (true)
				{
					switch (num3 ^ 0x3985AE0C)
					{
					case 13:
						break;
					case 5:
						num3 = 965062156;
						continue;
					case 10:
						if (ReflectionTools.DoesTypeImplement(P_1, typeof(IAddKeyValue<string, object>)))
						{
							addKeyValue = (IAddKeyValue<string, object>)Factory.CreateInstance(P_1, new object[1] { list.Count / 2 });
							num5 = 0;
							num3 = 965062155;
							continue;
						}
						goto case 1;
					case 9:
						goto IL_0102;
					case 1:
						dictionary = new Dictionary<string, object>(list.Count / 2);
						num4 = 0;
						num3 = 965062153;
						continue;
					case 4:
						goto end_IL_005c;
					case 12:
						result3 = addKeyValue;
						num3 = 965062152;
						continue;
					case 11:
					{
						bool flag2;
						addKeyValue.Add(list[num5].Substring(1, list[num5].Length - 2), UCpdwYHDdllydarZidllwxgLktga(list[num5 + 1], P_1, out flag2));
						num5 += 2;
						num3 = 965062158;
						continue;
					}
					case 6:
					{
						bool flag;
						dictionary.Add(list[num4].Substring(1, list[num4].Length - 2), UCpdwYHDdllydarZidllwxgLktga(list[num4 + 1], P_1, out flag));
						num3 = 965062148;
						continue;
					}
					case 3:
						P_2 = false;
						result3 = null;
						goto end_IL_005c;
					case 2:
						if (num5 >= list.Count)
						{
							P_2 = true;
							num3 = 965062144;
							continue;
						}
						goto case 11;
					case 8:
						num4 += 2;
						num3 = 965062156;
						continue;
					case 7:
						num3 = 965062158;
						continue;
					default:
						if (num4 < list.Count)
						{
							goto case 6;
						}
						P_2 = true;
						result3 = dictionary;
						goto end_IL_005c;
					}
					break;
				}
				goto IL_0069;
				IL_0102:
				int num6;
				if ((object)P_1 != null)
				{
					num3 = 965062150;
					num6 = num3;
				}
				else
				{
					num3 = 965062157;
					num6 = num3;
				}
				goto IL_006e;
				end_IL_005c:;
			}
			finally
			{
				if (list != null)
				{
					while (true)
					{
						IL_0235:
						int num7 = 965062157;
						while (true)
						{
							switch (num7 ^ 0x3985AE0C)
							{
							case 0:
								break;
							default:
								goto end_IL_023a;
							case 1:
								goto IL_0253;
							case 2:
								goto end_IL_023a;
							}
							goto IL_0235;
							IL_0253:
							splitArrayPool.Push(list);
							num7 = 965062158;
							continue;
							end_IL_023a:
							break;
						}
						break;
					}
				}
			}
			goto IL_0519;
			IL_0266:
			if (P_0[0] == '[' && P_0[P_0.Length - 1] == ']')
			{
				List<string> list2 = OVFHtttmPXAXTWjDfgVAGXsJKKZd(P_0);
				try
				{
					if ((object)P_1 != null && ReflectionTools.DoesTypeImplement(P_1, typeof(IAddValue<object>)))
					{
						goto IL_02a6;
					}
					goto IL_02f8;
					IL_02f8:
					List<object> list3 = new List<object>(list2.Count);
					int num8 = 0;
					int num9 = 965062157;
					goto IL_02ab;
					IL_02a6:
					num9 = 965062155;
					goto IL_02ab;
					IL_02ab:
					int num10 = default(int);
					IAddValue<object> addValue = default(IAddValue<object>);
					while (true)
					{
						switch (num9 ^ 0x3985AE0C)
						{
						case 0:
							break;
						case 8:
							if (num10 >= list2.Count)
							{
								P_2 = true;
								num9 = 965062153;
								continue;
							}
							goto case 9;
						case 6:
							goto IL_02f8;
						case 4:
						{
							bool flag4;
							list3.Add(UCpdwYHDdllydarZidllwxgLktga(list2[num8], P_1, out flag4));
							num8++;
							num9 = 965062157;
							continue;
						}
						case 5:
							result3 = addValue;
							num9 = 965062159;
							continue;
						case 2:
							num10++;
							num9 = 965062148;
							continue;
						case 9:
						{
							bool flag3;
							addValue.Add(UCpdwYHDdllydarZidllwxgLktga(list2[num10], P_1, out flag3));
							num9 = 965062158;
							continue;
						}
						case 3:
							goto end_IL_0291;
						case 7:
							addValue = (IAddValue<object>)Factory.CreateInstance(P_1, new object[1] { list2.Count });
							num10 = 0;
							num9 = 965062148;
							continue;
						default:
							if (num8 < list2.Count)
							{
								goto case 4;
							}
							P_2 = true;
							result3 = list3;
							goto end_IL_0291;
						}
						break;
					}
					goto IL_02a6;
					end_IL_0291:;
				}
				finally
				{
					if (list2 != null)
					{
						while (true)
						{
							IL_03d9:
							int num11 = 965062157;
							while (true)
							{
								switch (num11 ^ 0x3985AE0C)
								{
								case 0:
									break;
								default:
									goto end_IL_03de;
								case 1:
									goto IL_03f7;
								case 2:
									goto end_IL_03de;
								}
								goto IL_03d9;
								IL_03f7:
								splitArrayPool.Push(list2);
								num11 = 965062158;
								continue;
								end_IL_03de:
								break;
							}
							break;
						}
					}
				}
				goto IL_0519;
			}
			if (P_0[0] == '"')
			{
				goto IL_0416;
			}
			goto IL_047e;
			IL_0519:
			return result3;
			IL_047e:
			if (!char.IsDigit(P_0[0]))
			{
				if (P_0[0] == '-')
				{
					num2 = 965062159;
				}
				else
				{
					if (!(P_0 == "true"))
					{
						if (P_0 == "false")
						{
							P_2 = true;
							return false;
						}
						P_2 = true;
						return null;
					}
					P_2 = true;
					num2 = 965062156;
				}
				goto IL_041b;
			}
			goto IL_04a1;
		}

		private static object FHnbXxchISxcagtKBmuFxToEirP(Type P_0, string P_1, Type P_2)
		{
			object obj = Factory.CreateInstance(P_0);
			List<string> list = OVFHtttmPXAXTWjDfgVAGXsJKKZd(P_1);
			try
			{
				if (list.Count % 2 != 0)
				{
					return obj;
				}
				Dictionary<string, PropertyInfo> value2 = default(Dictionary<string, PropertyInfo>);
				string key = default(string);
				string text = default(string);
				int num3 = default(int);
				while (true)
				{
					Dictionary<string, FieldInfo> value;
					int num;
					int num2;
					if (!FigRKutykumzSMBgeLVlQswHuQZ.TryGetValue(P_0, out value))
					{
						num = 1085871398;
						num2 = num;
					}
					else
					{
						num = 1085871399;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x40B91527)
						{
						case 5:
							num = 1085871407;
							continue;
						case 12:
						{
							PropertyInfo value3;
							if (value2.TryGetValue(key, out value3) && value3.CanWrite)
							{
								bool flag;
								value3.SetValue(obj, XvQyJSzsOeEGWMrASHYhryzzLWj(value3.PropertyType, text, P_2, out flag), null);
								num = 1085871406;
								continue;
							}
							goto case 9;
						}
						case 4:
							if (list[num3].Length > 2)
							{
								key = list[num3].Substring(1, list[num3].Length - 2);
								num = 1085871396;
								continue;
							}
							goto case 9;
						case 0:
							if (!tknsOaiPSIUNmMayaHzXqipCMuW.TryGetValue(P_0, out value2))
							{
								value2 = (from propertyInfo in ReflectionTools.GetProperties(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
									where propertyInfo.CanWrite && propertyInfo.IsDefined(typeof(SerializeAttribute), true) && !propertyInfo.IsDefined(typeof(DoNotSerializeAttribute), true)
									select propertyInfo).ToDictionary((PropertyInfo propertyInfo) =>
								{
									string name;
									return (propertyInfo.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(propertyInfo.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name)) ? name : propertyInfo.Name;
								});
								num = 1085871392;
								continue;
							}
							goto case 10;
						case 9:
							num3 += 2;
							num = 1085871404;
							continue;
						case 1:
							value = ReflectionTools.GetFields(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(delegate(FieldInfo fieldInfo)
							{
								if (fieldInfo.IsPublic || fieldInfo.IsDefined(typeof(SerializeAttribute), true))
								{
									goto IL_004c;
								}
								if (fieldInfo.IsDefined(typeof(SerializeField), true))
								{
									goto IL_002e;
								}
								goto IL_007b;
								IL_004c:
								int num5;
								if (!fieldInfo.IsDefined(typeof(NonSerializedAttribute), true))
								{
									num5 = 1689095134;
									goto IL_0033;
								}
								goto IL_007b;
								IL_007b:
								return false;
								IL_002e:
								num5 = 1689095133;
								goto IL_0033;
								IL_0033:
								switch (num5 ^ 0x64AD8BDF)
								{
								case 0:
									break;
								case 2:
									goto IL_004c;
								default:
									return !fieldInfo.IsDefined(typeof(DoNotSerializeAttribute), true);
								}
								goto IL_002e;
							}).ToDictionary((FieldInfo fieldInfo) =>
							{
								string name;
								return (fieldInfo.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(fieldInfo.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name)) ? name : fieldInfo.Name;
							});
							num = 1085871393;
							continue;
						case 11:
						{
							int num4;
							if (num3 >= list.Count)
							{
								num = 1085871397;
								num4 = num;
							}
							else
							{
								num = 1085871395;
								num4 = num;
							}
							continue;
						}
						case 7:
							tknsOaiPSIUNmMayaHzXqipCMuW.Add(P_0, value2);
							num = 1085871405;
							continue;
						case 6:
							FigRKutykumzSMBgeLVlQswHuQZ.Add(P_0, value);
							num = 1085871399;
							continue;
						case 8:
							break;
						case 3:
						{
							text = list[num3 + 1];
							FieldInfo value4;
							if (value.TryGetValue(key, out value4))
							{
								bool flag2;
								value4.SetValue(obj, XvQyJSzsOeEGWMrASHYhryzzLWj(value4.FieldType, text, P_2, out flag2));
								num = 1085871406;
								continue;
							}
							goto case 12;
						}
						case 10:
							num3 = 0;
							num = 1085871404;
							continue;
						default:
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
						}
						break;
					}
				}
			}
			finally
			{
				if (list != null)
				{
					splitArrayPool.Push(list);
				}
			}
		}

		private static int zODtsPgEMWGtQSGhBuvRnbRleUQB(bool P_0, int P_1, string P_2)
		{
			UiGrpFCGPSkncrvdsKXMJOteagV.Append(P_2[P_1]);
			int num = P_1 + 1;
			while (true)
			{
				int num2;
				int num3;
				if (num >= P_2.Length)
				{
					num2 = 1557555495;
					num3 = num2;
				}
				else
				{
					num2 = 1557555491;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x5CD66925)
					{
					case 0:
						num2 = 1557555491;
						continue;
					case 3:
						if (P_2[num] == '"')
						{
							UiGrpFCGPSkncrvdsKXMJOteagV.Append(P_2[num]);
							return num;
						}
						UiGrpFCGPSkncrvdsKXMJOteagV.Append(P_2[num]);
						num2 = 1557555492;
						continue;
					case 1:
						num++;
						num2 = 1557555489;
						continue;
					case 5:
						UiGrpFCGPSkncrvdsKXMJOteagV.Append(P_2[num]);
						num2 = 1557555490;
						continue;
					case 7:
						UiGrpFCGPSkncrvdsKXMJOteagV.Append(P_2[num + 1]);
						num2 = 1557555501;
						continue;
					case 6:
						if (P_2[num] == '\\')
						{
							int num4;
							if (P_0)
							{
								num2 = 1557555488;
								num4 = num2;
							}
							else
							{
								num2 = 1557555490;
								num4 = num2;
							}
							continue;
						}
						goto case 3;
					case 8:
						num++;
						num2 = 1557555492;
						continue;
					case 4:
						break;
					default:
						return P_2.Length - 1;
					}
					break;
				}
			}
		}

		private static List<string> OVFHtttmPXAXTWjDfgVAGXsJKKZd(string P_0)
		{
			List<string> list = ((splitArrayPool.Count > 0) ? splitArrayPool.Pop() : new List<string>());
			int num2 = default(int);
			char c = default(char);
			int num3 = default(int);
			while (true)
			{
				int num = -1195836512;
				while (true)
				{
					switch (num ^ -1195836501)
					{
					case 15:
						break;
					case 1:
						UiGrpFCGPSkncrvdsKXMJOteagV.Append(P_0[num2]);
						num = -1195836501;
						continue;
					case 10:
						num2 = zODtsPgEMWGtQSGhBuvRnbRleUQB(true, num2, P_0);
						num = -1195836501;
						continue;
					case 19:
					{
						int num6;
						if (c == ',')
						{
							num = -1195836487;
							num6 = num;
						}
						else
						{
							num = -1195836503;
							num6 = num;
						}
						continue;
					}
					case 14:
						num = -1195836501;
						continue;
					case 12:
						goto IL_00d3;
					case 4:
						switch (c)
						{
						case '\\':
							break;
						case ']':
							goto IL_00d3;
						default:
							goto IL_00fb;
						case '[':
							goto IL_010f;
						case ':':
							goto IL_0155;
						}
						goto case 1;
					case 2:
						num = -1195836502;
						continue;
					case 17:
						goto IL_010f;
					case 5:
						switch (c)
						{
						case '|':
							break;
						case '}':
							goto IL_00d3;
						case '{':
							goto IL_010f;
						default:
							goto IL_0132;
						}
						goto case 1;
					case 7:
					{
						int num5;
						if (c == '"')
						{
							num = -1195836511;
							num5 = num;
						}
						else
						{
							num = -1195836488;
							num5 = num;
						}
						continue;
					}
					case 18:
						goto IL_0155;
					case 3:
						num3 = 0;
						UiGrpFCGPSkncrvdsKXMJOteagV.Length = 0;
						num2 = 1;
						num = -1195836499;
						continue;
					case 6:
						if (num2 >= P_0.Length - 1)
						{
							if (UiGrpFCGPSkncrvdsKXMJOteagV.Length == 0)
							{
								num = -1195836510;
								continue;
							}
							list.Add(UiGrpFCGPSkncrvdsKXMJOteagV.ToString());
							return list;
						}
						goto case 8;
					case 16:
						num = -1195836502;
						continue;
					case 13:
						UiGrpFCGPSkncrvdsKXMJOteagV.Length = 0;
						num = -1195836507;
						continue;
					case 0:
						num2++;
						num = -1195836499;
						continue;
					case 11:
						list.Clear();
						num = -1195836504;
						continue;
					case 8:
					{
						c = P_0[num2];
						int num4;
						if (c <= ',')
						{
							num = -1195836500;
							num4 = num;
						}
						else
						{
							num = -1195836497;
							num4 = num;
						}
						continue;
					}
					default:
						{
							return list;
						}
						IL_010f:
						num3++;
						num = -1195836502;
						continue;
						IL_00fb:
						num = -1195836498;
						continue;
						IL_00d3:
						num3--;
						num = -1195836485;
						continue;
						IL_0132:
						num = -1195836502;
						continue;
						IL_0155:
						if (num3 == 0)
						{
							list.Add(UiGrpFCGPSkncrvdsKXMJOteagV.ToString());
							num = -1195836506;
							continue;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static bool cIrbrKmDZLOyFiOnSLjFzmxXsbP(FieldInfo P_0)
		{
			if (P_0.IsPublic || P_0.IsDefined(typeof(SerializeAttribute), true))
			{
				goto IL_004c;
			}
			if (P_0.IsDefined(typeof(SerializeField), true))
			{
				goto IL_002e;
			}
			goto IL_007b;
			IL_004c:
			int num;
			if (!P_0.IsDefined(typeof(NonSerializedAttribute), true))
			{
				num = 1689095134;
				goto IL_0033;
			}
			goto IL_007b;
			IL_007b:
			return false;
			IL_002e:
			num = 1689095133;
			goto IL_0033;
			IL_0033:
			switch (num ^ 0x64AD8BDF)
			{
			case 0:
				break;
			case 2:
				goto IL_004c;
			default:
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
			}
			goto IL_002e;
		}

		[CompilerGenerated]
		private static string OWYuIYLjVWDRjWZHiMPKXlUHgIw(FieldInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}

		[CompilerGenerated]
		private static bool iFtcYsxTlBgYammMlNlOZMYkKwl(PropertyInfo P_0)
		{
			if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string eEsjZGElGnqlvgjDtWWUpxzelQZ(PropertyInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}
	}
}
