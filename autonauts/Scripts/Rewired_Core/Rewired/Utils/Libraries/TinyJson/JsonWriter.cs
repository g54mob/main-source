using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils.Libraries.TinyJson
{
	public static class JsonWriter
	{
		private static Action<StringBuilder, object> nACrUjRhsFXprnyaIBnGKQzwkQ;

		private static Action<StringBuilder, object> appendValueDelegate
		{
			get
			{
				return QXZZsSmuZbRLMnVrYKzFjdolGLM;
			}
		}

		public static string ToJson(object item)
		{
			StringBuilder stringBuilder = new StringBuilder();
			QXZZsSmuZbRLMnVrYKzFjdolGLM(stringBuilder, item);
			return stringBuilder.ToString();
		}

		private static void QXZZsSmuZbRLMnVrYKzFjdolGLM(StringBuilder P_0, object P_1)
		{
			if (P_1 == null)
			{
				P_0.Append("null");
				return;
			}
			ISerializationCallbackReceiver serializationCallbackReceiver = P_1 as ISerializationCallbackReceiver;
			if (serializationCallbackReceiver != null)
			{
				try
				{
					serializationCallbackReceiver.OnBeforeSerialize();
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString(), true);
				}
			}
			Type type = P_1.GetType();
			bool flag2 = default(bool);
			Type conversionType = default(Type);
			Type type2 = default(Type);
			bool flag3 = default(bool);
			Type underlyingType = default(Type);
			int num5 = default(int);
			IDictionary dictionary = default(IDictionary);
			IList list = default(IList);
			object current = default(object);
			bool flag4 = default(bool);
			string name = default(string);
			object value = default(object);
			object value2 = default(object);
			PropertyInfo current3 = default(PropertyInfo);
			string name2 = default(string);
			while (true)
			{
				int num = -485569390;
				while (true)
				{
					int num11;
					switch (num ^ -485569381)
					{
					case 27:
						break;
					case 23:
						flag2 = true;
						conversionType = ReflectionTools.GetUnderlyingEnumType(type2);
						num = -485569384;
						continue;
					case 25:
						flag2 = false;
						conversionType = null;
						num = -485569379;
						continue;
					case 1:
						return;
					case 18:
						if (flag3)
						{
							flag3 = false;
							num = -485569400;
							continue;
						}
						goto case 2;
					case 7:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							P_0.Append(((double)P_1).ToString(CultureInfo.InvariantCulture));
							return;
						}
						goto case 15;
					case 15:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_0.Append(((decimal)P_1).ToString(CultureInfo.InvariantCulture));
							return;
						}
						goto case 10;
					case 13:
						if (ReflectionTools.IsGenericType(type) && ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
						{
							type2 = ReflectionTools.GetGenericArguments(type)[0];
							num = -485569406;
							continue;
						}
						goto IL_0610;
					case 14:
					{
						int num10;
						if (object.ReferenceEquals(type, typeof(int)))
						{
							num = -485569407;
							num10 = num;
						}
						else
						{
							num = -485569393;
							num10 = num;
						}
						continue;
					}
					case 0:
					{
						int num6;
						if (!ReflectionTools.DoesTypeImplement(type, typeof(IList)))
						{
							num = -485569386;
							num6 = num;
						}
						else
						{
							num = -485569378;
							num6 = num;
						}
						continue;
					}
					case 12:
					{
						int num4;
						if (object.ReferenceEquals(type, typeof(string)))
						{
							num = -485569398;
							num4 = num;
						}
						else
						{
							num = -485569387;
							num4 = num;
						}
						continue;
					}
					case 29:
						if (ReflectionTools.IsEnum(type))
						{
							underlyingType = Enum.GetUnderlyingType(type);
							num = -485569395;
							continue;
						}
						goto case 0;
					case 21:
						num5 = 0;
						num = -485569392;
						continue;
					case 3:
						P_0.Append('{');
						dictionary = P_1 as IDictionary;
						num = -485569405;
						continue;
					case 20:
						if (!object.ReferenceEquals(type, typeof(uint)) && !object.ReferenceEquals(type, typeof(long)) && !object.ReferenceEquals(type, typeof(ulong)) && !object.ReferenceEquals(type, typeof(short)) && !object.ReferenceEquals(type, typeof(ushort)) && !object.ReferenceEquals(type, typeof(byte)))
						{
							int num9;
							if (!object.ReferenceEquals(type, typeof(sbyte)))
							{
								num = -485569397;
								num9 = num;
							}
							else
							{
								num = -485569407;
								num9 = num;
							}
							continue;
						}
						goto case 26;
					case 2:
						P_0.Append(',');
						num = -485569400;
						continue;
					case 17:
						P_0.Append('"');
						P_0.Append((string)P_1);
						P_0.Append('"');
						num = -485569382;
						continue;
					case 6:
					{
						int num7;
						if (!ReflectionTools.IsEnum(type2))
						{
							num = -485569384;
							num7 = num;
						}
						else
						{
							num = -485569396;
							num7 = num;
						}
						continue;
					}
					case 4:
					{
						int num8;
						if (!object.ReferenceEquals(type, typeof(Guid)))
						{
							num = -485569402;
							num8 = num;
						}
						else
						{
							num = -485569401;
							num8 = num;
						}
						continue;
					}
					case 19:
						QXZZsSmuZbRLMnVrYKzFjdolGLM(P_0, list[num5]);
						num5++;
						num = -485569392;
						continue;
					case 9:
						if (ReflectionTools.DoesTypeImplement(type, typeof(IExportToJson)))
						{
							((IExportToJson)P_1).WriteJson(P_0, appendValueDelegate);
							num = -485569389;
							continue;
						}
						goto case 12;
					case 28:
						QXZZsSmuZbRLMnVrYKzFjdolGLM(P_0, P_1.ToString());
						return;
					case 11:
						if (num5 >= list.Count)
						{
							P_0.Append(']');
							return;
						}
						goto case 18;
					case 26:
						P_0.Append(P_1.ToString());
						return;
					case 16:
						if (object.ReferenceEquals(type, typeof(float)))
						{
							P_0.Append(((float)P_1).ToString(CultureInfo.InvariantCulture));
							return;
						}
						goto case 7;
					case 8:
						return;
					case 22:
						QXZZsSmuZbRLMnVrYKzFjdolGLM(P_0, Convert.ChangeType(P_1, underlyingType));
						return;
					case 5:
						P_0.Append('[');
						flag3 = true;
						list = P_1 as IList;
						num = -485569394;
						continue;
					case 10:
						if (object.ReferenceEquals(type, typeof(bool)))
						{
							P_0.Append(((bool)P_1) ? "true" : "false");
							return;
						}
						goto case 4;
					default:
						{
							bool flag = true;
							{
								IEnumerator enumerator = dictionary.Keys.GetEnumerator();
								try
								{
									while (true)
									{
										IL_0596:
										int num2;
										int num3;
										if (!enumerator.MoveNext())
										{
											num2 = -485569384;
											num3 = num2;
										}
										else
										{
											num2 = -485569377;
											num3 = num2;
										}
										while (true)
										{
											switch (num2 ^ -485569381)
											{
											case 2:
												num2 = -485569377;
												continue;
											default:
												goto end_IL_04f9;
											case 4:
												current = enumerator.Current;
												if (flag)
												{
													flag = false;
													num2 = -485569379;
													continue;
												}
												goto case 5;
											case 1:
												P_0.Append(flag2 ? Convert.ChangeType(current, conversionType).ToString() : current.ToString());
												P_0.Append("\":");
												QXZZsSmuZbRLMnVrYKzFjdolGLM(P_0, dictionary[current]);
												num2 = -485569381;
												continue;
											case 5:
												P_0.Append(',');
												num2 = -485569379;
												continue;
											case 0:
												break;
											case 6:
												P_0.Append('"');
												num2 = -485569382;
												continue;
											case 3:
												goto end_IL_04f9;
											}
											goto IL_0596;
											continue;
											end_IL_04f9:
											break;
										}
										break;
									}
								}
								finally
								{
									IDisposable disposable = enumerator as IDisposable;
									if (disposable != null)
									{
										disposable.Dispose();
									}
								}
							}
							P_0.Append('}');
							goto IL_05e6;
						}
						IL_0610:
						P_0.Append('{');
						flag4 = true;
						num11 = -485569382;
						goto IL_05eb;
						IL_05eb:
						switch (num11 ^ -485569381)
						{
						case 0:
							break;
						case 2:
							return;
						case 3:
							goto IL_0610;
						default:
						{
							IEnumerable<FieldInfo> fields = ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
							IEnumerator<FieldInfo> enumerator2 = fields.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										FieldInfo current2 = enumerator2.Current;
										int num12;
										int num13;
										if (current2.IsDefined(typeof(NonSerializedAttribute), true))
										{
											num12 = -485569380;
											num13 = num12;
										}
										else
										{
											num12 = -485569382;
											num13 = num12;
										}
										while (true)
										{
											switch (num12 ^ -485569381)
											{
											case 13:
												num12 = -485569384;
												continue;
											case 10:
												break;
											case 1:
												goto IL_06ae;
											case 4:
												P_0.Append(',');
												num12 = -485569381;
												continue;
											case 2:
												flag4 = false;
												num12 = -485569392;
												continue;
											case 11:
												num12 = -485569381;
												continue;
											case 8:
												name = current2.Name;
												num12 = -485569379;
												continue;
											case 5:
												goto IL_0713;
											case 6:
												P_0.Append(name);
												num12 = -485569390;
												continue;
											case 3:
												goto end_IL_0640;
											case 9:
												P_0.Append("\":");
												num12 = -485569385;
												continue;
											case 12:
												QXZZsSmuZbRLMnVrYKzFjdolGLM(P_0, value);
												num12 = -485569380;
												continue;
											case 0:
												P_0.Append('"');
												if (!current2.IsDefined(typeof(SerializeAttribute), true))
												{
													goto case 8;
												}
												goto IL_07ea;
											default:
												goto end_IL_0771;
											}
											goto IL_0688;
											IL_07ea:
											int num14;
											if (!string.IsNullOrEmpty(name = (CollectionTools.GetValue(current2.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
											{
												num12 = -485569379;
												num14 = num12;
											}
											else
											{
												num12 = -485569389;
												num14 = num12;
											}
											continue;
											IL_06ae:
											int num15;
											if (!current2.IsDefined(typeof(DoNotSerializeAttribute), true))
											{
												num12 = -485569378;
												num15 = num12;
											}
											else
											{
												num12 = -485569380;
												num15 = num12;
											}
											continue;
											IL_0688:
											value = current2.GetValue(P_1);
											if (value == null)
											{
												goto end_IL_0771;
											}
											int num16;
											if (!flag4)
											{
												num12 = -485569377;
												num16 = num12;
											}
											else
											{
												num12 = -485569383;
												num16 = num12;
											}
											continue;
											IL_0713:
											if (!current2.IsPublic && !current2.IsDefined(typeof(SerializeAttribute), true))
											{
												int num17;
												if (current2.IsDefined(typeof(SerializeField), true))
												{
													num12 = -485569391;
													num17 = num12;
												}
												else
												{
													num12 = -485569380;
													num17 = num12;
												}
												continue;
											}
											goto IL_0688;
											continue;
											end_IL_0640:
											break;
										}
										continue;
										end_IL_0771:
										break;
									}
								}
							}
							finally
							{
								if (enumerator2 != null)
								{
									while (true)
									{
										IL_083c:
										int num18 = -485569382;
										while (true)
										{
											switch (num18 ^ -485569381)
											{
											case 2:
												break;
											default:
												goto end_IL_0841;
											case 1:
												goto IL_085a;
											case 0:
												goto end_IL_0841;
											}
											goto IL_083c;
											IL_085a:
											enumerator2.Dispose();
											num18 = -485569381;
											continue;
											end_IL_0841:
											break;
										}
										break;
									}
								}
							}
							IEnumerable<PropertyInfo> properties = ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
							using (IEnumerator<PropertyInfo> enumerator3 = properties.GetEnumerator())
							{
								while (true)
								{
									IL_0955:
									int num19;
									int num20;
									if (enumerator3.MoveNext())
									{
										num19 = -485569392;
										num20 = num19;
									}
									else
									{
										num19 = -485569383;
										num20 = num19;
									}
									while (true)
									{
										switch (num19 ^ -485569381)
										{
										case 10:
											num19 = -485569392;
											continue;
										default:
											goto end_IL_0886;
										case 3:
											value2 = current3.GetValue(P_1, null);
											num19 = -485569378;
											continue;
										case 8:
											if (current3.CanWrite)
											{
												int num23;
												if (current3.IsDefined(typeof(SerializeAttribute), true))
												{
													num19 = -485569377;
													num23 = num19;
												}
												else
												{
													num19 = -485569380;
													num23 = num19;
												}
												continue;
											}
											break;
										case 1:
											P_0.Append(',');
											num19 = -485569381;
											continue;
										case 9:
											P_0.Append(name2);
											P_0.Append("\":");
											QXZZsSmuZbRLMnVrYKzFjdolGLM(P_0, value2);
											num19 = -485569380;
											continue;
										case 5:
											if (value2 == null)
											{
												break;
											}
											if (flag4)
											{
												flag4 = false;
												num19 = -485569381;
												continue;
											}
											goto case 1;
										case 7:
											break;
										case 4:
											if (!current3.IsDefined(typeof(DoNotSerializeAttribute), true))
											{
												int num22;
												if (current3.CanRead)
												{
													num19 = -485569384;
													num22 = num19;
												}
												else
												{
													num19 = -485569380;
													num22 = num19;
												}
												continue;
											}
											break;
										case 11:
											current3 = enumerator3.Current;
											num19 = -485569389;
											continue;
										case 6:
											name2 = current3.Name;
											num19 = -485569390;
											continue;
										case 0:
											P_0.Append('"');
											if (current3.IsDefined(typeof(SerializeAttribute), true))
											{
												int num21;
												if (!string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(current3.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
												{
													num19 = -485569390;
													num21 = num19;
												}
												else
												{
													num19 = -485569379;
													num21 = num19;
												}
												continue;
											}
											goto case 6;
										case 2:
											goto end_IL_0886;
										}
										goto IL_0955;
										continue;
										end_IL_0886:
										break;
									}
									break;
								}
							}
							P_0.Append('}');
							return;
						}
						}
						goto IL_05e6;
						IL_05e6:
						num11 = -485569383;
						goto IL_05eb;
					}
					break;
				}
			}
		}
	}
}
