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
		private static Action<StringBuilder, object> KMIuOJTqYcdKgSKJhccsYsksbthc;

		private static Action<StringBuilder, object> appendValueDelegate => xENAmxaALffSCvCkFhvuQtVcrLgR;

		public static string ToJson(object item)
		{
			StringBuilder stringBuilder = new StringBuilder();
			xENAmxaALffSCvCkFhvuQtVcrLgR(stringBuilder, item);
			return stringBuilder.ToString();
		}

		private static void xENAmxaALffSCvCkFhvuQtVcrLgR(StringBuilder P_0, object P_1)
		{
			if (P_1 == null)
			{
				P_0.Append("null");
				return;
			}
			bool flag3 = default(bool);
			IList list = default(IList);
			int num7 = default(int);
			bool flag2 = default(bool);
			Type conversionType = default(Type);
			FieldInfo current2 = default(FieldInfo);
			object value = default(object);
			string name = default(string);
			object value2 = default(object);
			string name2 = default(string);
			object current = default(object);
			while (true)
			{
				ISerializationCallbackReceiver serializationCallbackReceiver = P_1 as ISerializationCallbackReceiver;
				int num = -423108578;
				while (true)
				{
					switch (num ^ -423108580)
					{
					case 0:
						goto IL_0010;
					case 1:
						break;
					default:
					{
						if (serializationCallbackReceiver != null)
						{
							try
							{
								serializationCallbackReceiver.OnBeforeSerialize();
							}
							catch (Exception ex)
							{
								Logger.LogError(ex.ToString(), requiredThreadSafety: true);
							}
						}
						Type type = P_1.GetType();
						while (true)
						{
							int num2 = -423108598;
							while (true)
							{
								switch (num2 ^ -423108580)
								{
								case 6:
									break;
								case 0:
								{
									int num20;
									if (!object.ReferenceEquals(type, typeof(int)))
									{
										num2 = -423108601;
										num20 = num2;
									}
									else
									{
										num2 = -423108578;
										num20 = num2;
									}
									continue;
								}
								case 18:
								{
									int num8;
									if (!object.ReferenceEquals(type, typeof(decimal)))
									{
										num2 = -423108590;
										num8 = num2;
									}
									else
									{
										num2 = -423108604;
										num8 = num2;
									}
									continue;
								}
								case 23:
									if (flag3)
									{
										flag3 = false;
										num2 = -423108579;
										continue;
									}
									goto case 26;
								case 17:
									if (ReflectionTools.IsEnum(type))
									{
										Type underlyingType = Enum.GetUnderlyingType(type);
										xENAmxaALffSCvCkFhvuQtVcrLgR(P_0, Convert.ChangeType(P_1, underlyingType));
										return;
									}
									goto case 12;
								case 8:
									if (object.ReferenceEquals(type, typeof(string)))
									{
										P_0.Append('"');
										P_0.Append((string)P_1);
										num2 = -423108577;
										continue;
									}
									goto case 0;
								case 2:
									P_0.Append(P_1.ToString());
									num2 = -423108586;
									continue;
								case 19:
									xENAmxaALffSCvCkFhvuQtVcrLgR(P_0, list[num7]);
									num7++;
									num2 = -423108603;
									continue;
								case 25:
									if (num7 >= list.Count)
									{
										P_0.Append(']');
										return;
									}
									goto case 23;
								case 12:
									if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
									{
										P_0.Append('[');
										flag3 = true;
										list = P_1 as IList;
										num7 = 0;
										num2 = -423108581;
										continue;
									}
									goto case 13;
								case 15:
									if (!object.ReferenceEquals(type, typeof(long)) && !object.ReferenceEquals(type, typeof(ulong)))
									{
										int num6;
										if (object.ReferenceEquals(type, typeof(short)))
										{
											num2 = -423108578;
											num6 = num2;
										}
										else
										{
											num2 = -423108600;
											num6 = num2;
										}
										continue;
									}
									goto case 2;
								case 21:
									if (object.ReferenceEquals(type, typeof(double)))
									{
										P_0.Append(((double)P_1).ToString(CultureInfo.InvariantCulture));
										num2 = -423108585;
										continue;
									}
									goto case 18;
								case 13:
									if (ReflectionTools.IsGenericType(type) && ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
									{
										Type type2 = ReflectionTools.GetGenericArguments(type)[0];
										flag2 = false;
										conversionType = null;
										if (ReflectionTools.IsEnum(type2))
										{
											flag2 = true;
											conversionType = ReflectionTools.GetUnderlyingEnumType(type2);
											num2 = -423108596;
											continue;
										}
										goto default;
									}
									while (true)
									{
										P_0.Append('{');
										int num10 = -423108580;
										while (true)
										{
											switch (num10 ^ -423108580)
											{
											case 2:
												goto IL_05ed;
											case 1:
												break;
											default:
											{
												bool flag4 = true;
												IEnumerable<FieldInfo> fields = ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
												IEnumerator<FieldInfo> enumerator2 = fields.GetEnumerator();
												try
												{
													while (true)
													{
														IL_06a1:
														int num11;
														int num12;
														if (!enumerator2.MoveNext())
														{
															num11 = -423108578;
															num12 = num11;
														}
														else
														{
															num11 = -423108581;
															num12 = num11;
														}
														while (true)
														{
															switch (num11 ^ -423108580)
															{
															case 0:
																num11 = -423108581;
																continue;
															default:
																goto end_IL_0638;
															case 3:
															{
																int num15;
																if (current2.IsDefined(typeof(SerializeAttribute), inherit: true))
																{
																	num11 = -423108587;
																	num15 = num11;
																}
																else
																{
																	num11 = -423108592;
																	num15 = num11;
																}
																continue;
															}
															case 11:
																break;
															case 5:
																value = current2.GetValue(P_1);
																num11 = -423108584;
																continue;
															case 4:
																if (value == null)
																{
																	break;
																}
																if (flag4)
																{
																	flag4 = false;
																	num11 = -423108582;
																	continue;
																}
																goto case 8;
															case 10:
																P_0.Append('"');
																num11 = -423108577;
																continue;
															case 1:
																P_0.Append(name);
																P_0.Append("\":");
																xENAmxaALffSCvCkFhvuQtVcrLgR(P_0, value);
																num11 = -423108585;
																continue;
															case 7:
																current2 = enumerator2.Current;
																if (current2.IsDefined(typeof(NonSerializedAttribute), inherit: true) || current2.IsDefined(typeof(DoNotSerializeAttribute), inherit: true))
																{
																	break;
																}
																if (!current2.IsPublic && !current2.IsDefined(typeof(SerializeAttribute), inherit: true))
																{
																	int num14;
																	if (current2.IsDefined(typeof(SerializeField), inherit: true))
																	{
																		num11 = -423108583;
																		num14 = num11;
																	}
																	else
																	{
																		num11 = -423108585;
																		num14 = num11;
																	}
																	continue;
																}
																goto case 5;
															case 9:
															{
																int num13;
																if (string.IsNullOrEmpty(name = (CollectionTools.GetValue(current2.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
																{
																	num11 = -423108592;
																	num13 = num11;
																}
																else
																{
																	num11 = -423108579;
																	num13 = num11;
																}
																continue;
															}
															case 12:
																name = current2.Name;
																num11 = -423108579;
																continue;
															case 8:
																P_0.Append(',');
																num11 = -423108586;
																continue;
															case 6:
																num11 = -423108586;
																continue;
															case 2:
																goto end_IL_0638;
															}
															goto IL_06a1;
															continue;
															end_IL_0638:
															break;
														}
														break;
													}
												}
												finally
												{
													if (enumerator2 != null)
													{
														while (true)
														{
															IL_081c:
															int num16 = -423108578;
															while (true)
															{
																switch (num16 ^ -423108580)
																{
																case 0:
																	break;
																default:
																	goto end_IL_0821;
																case 2:
																	goto IL_083a;
																case 1:
																	goto end_IL_0821;
																}
																goto IL_081c;
																IL_083a:
																enumerator2.Dispose();
																num16 = -423108579;
																continue;
																end_IL_0821:
																break;
															}
															break;
														}
													}
												}
												IEnumerable<PropertyInfo> properties = ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
												using (IEnumerator<PropertyInfo> enumerator3 = properties.GetEnumerator())
												{
													while (enumerator3.MoveNext())
													{
														while (true)
														{
															PropertyInfo current3 = enumerator3.Current;
															int num17 = -423108577;
															while (true)
															{
																switch (num17 ^ -423108580)
																{
																case 7:
																	num17 = -423108588;
																	continue;
																case 10:
																	break;
																case 3:
																	if (!current3.CanWrite || !current3.IsDefined(typeof(SerializeAttribute), inherit: true) || current3.IsDefined(typeof(DoNotSerializeAttribute), inherit: true) || !current3.CanRead)
																	{
																		goto end_IL_096c;
																	}
																	value2 = current3.GetValue(P_1, null);
																	if (value2 == null)
																	{
																		goto end_IL_096c;
																	}
																	if (flag4)
																	{
																		flag4 = false;
																		num17 = -423108578;
																		continue;
																	}
																	goto case 9;
																case 2:
																	num17 = -423108586;
																	continue;
																case 1:
																	P_0.Append(name2);
																	num17 = -423108580;
																	continue;
																case 5:
																	name2 = current3.Name;
																	num17 = -423108579;
																	continue;
																case 8:
																	goto end_IL_0866;
																case 4:
																	goto IL_097f;
																case 0:
																	P_0.Append("\":");
																	xENAmxaALffSCvCkFhvuQtVcrLgR(P_0, value2);
																	num17 = -423108582;
																	continue;
																case 9:
																	P_0.Append(',');
																	num17 = -423108586;
																	continue;
																default:
																	goto end_IL_096c;
																}
																P_0.Append('"');
																int num18;
																if (!current3.IsDefined(typeof(SerializeAttribute), inherit: true))
																{
																	num17 = -423108583;
																	num18 = num17;
																}
																else
																{
																	num17 = -423108584;
																	num18 = num17;
																}
																continue;
																IL_097f:
																int num19;
																if (string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(current3.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
																{
																	num17 = -423108583;
																	num19 = num17;
																}
																else
																{
																	num17 = -423108579;
																	num19 = num17;
																}
																continue;
																end_IL_0866:
																break;
															}
															continue;
															end_IL_096c:
															break;
														}
													}
												}
												P_0.Append('}');
												return;
											}
											}
											break;
											IL_05ed:
											num10 = -423108579;
										}
									}
								case 26:
									P_0.Append(',');
									num2 = -423108593;
									continue;
								case 14:
									if (object.ReferenceEquals(type, typeof(bool)))
									{
										P_0.Append(((bool)P_1) ? "true" : "false");
										return;
									}
									goto case 4;
								case 5:
									xENAmxaALffSCvCkFhvuQtVcrLgR(P_0, P_1.ToString());
									return;
								case 11:
									return;
								case 24:
									P_0.Append(((decimal)P_1).ToString(CultureInfo.InvariantCulture));
									return;
								case 9:
									if (object.ReferenceEquals(type, typeof(float)))
									{
										P_0.Append(((float)P_1).ToString(CultureInfo.InvariantCulture));
										return;
									}
									goto case 21;
								case 1:
									num2 = -423108593;
									continue;
								case 27:
								{
									int num9;
									if (!object.ReferenceEquals(type, typeof(uint)))
									{
										num2 = -423108589;
										num9 = num2;
									}
									else
									{
										num2 = -423108578;
										num9 = num2;
									}
									continue;
								}
								case 10:
									return;
								case 7:
									num2 = -423108603;
									continue;
								case 4:
								{
									int num21;
									if (!object.ReferenceEquals(type, typeof(Guid)))
									{
										num2 = -423108595;
										num21 = num2;
									}
									else
									{
										num2 = -423108583;
										num21 = num2;
									}
									continue;
								}
								case 22:
									if (ReflectionTools.DoesTypeImplement(type, typeof(IExportToJson)))
									{
										((IExportToJson)P_1).WriteJson(P_0, appendValueDelegate);
										return;
									}
									goto case 8;
								case 20:
									if (!object.ReferenceEquals(type, typeof(ushort)) && !object.ReferenceEquals(type, typeof(byte)))
									{
										int num3;
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											num2 = -423108578;
											num3 = num2;
										}
										else
										{
											num2 = -423108587;
											num3 = num2;
										}
										continue;
									}
									goto case 2;
								case 3:
									P_0.Append('"');
									return;
								default:
								{
									P_0.Append('{');
									IDictionary dictionary = P_1 as IDictionary;
									bool flag = true;
									{
										IEnumerator enumerator = dictionary.Keys.GetEnumerator();
										try
										{
											while (true)
											{
												IL_0531:
												int num4;
												int num5;
												if (enumerator.MoveNext())
												{
													num4 = -423108579;
													num5 = num4;
												}
												else
												{
													num4 = -423108577;
													num5 = num4;
												}
												while (true)
												{
													switch (num4 ^ -423108580)
													{
													case 2:
														num4 = -423108579;
														continue;
													default:
														goto end_IL_0505;
													case 4:
														break;
													case 6:
														P_0.Append(',');
														num4 = -423108583;
														continue;
													case 0:
														P_0.Append("\":");
														xENAmxaALffSCvCkFhvuQtVcrLgR(P_0, dictionary[current]);
														num4 = -423108584;
														continue;
													case 5:
														P_0.Append('"');
														P_0.Append(flag2 ? Convert.ChangeType(current, conversionType).ToString() : current.ToString());
														num4 = -423108580;
														continue;
													case 1:
														current = enumerator.Current;
														if (flag)
														{
															flag = false;
															num4 = -423108583;
															continue;
														}
														goto case 6;
													case 3:
														goto end_IL_0505;
													}
													goto IL_0531;
													continue;
													end_IL_0505:
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
									return;
								}
								}
								break;
							}
						}
					}
					}
					break;
					IL_0010:
					num = -423108579;
				}
			}
		}
	}
}
