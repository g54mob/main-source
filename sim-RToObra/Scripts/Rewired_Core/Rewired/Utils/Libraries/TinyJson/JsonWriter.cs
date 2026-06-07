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
		private static Action<StringBuilder, object> EyKmqFZjCwqwGFbREHdbriWxdaN;

		private static Action<StringBuilder, object> appendValueDelegate
		{
			get
			{
				return hCJWJvYFclybsTQQwAQtIgdrEHG;
			}
		}

		public static string ToJson(object item)
		{
			StringBuilder stringBuilder = new StringBuilder();
			hCJWJvYFclybsTQQwAQtIgdrEHG(stringBuilder, item);
			return stringBuilder.ToString();
		}

		private static void hCJWJvYFclybsTQQwAQtIgdrEHG(StringBuilder P_0, object P_1)
		{
			if (P_1 == null)
			{
				P_0.Append("null");
				return;
			}
			bool flag = default(bool);
			IList list = default(IList);
			int num13 = default(int);
			bool flag3 = default(bool);
			Type conversionType = default(Type);
			bool flag2 = default(bool);
			object value = default(object);
			string name = default(string);
			string name2 = default(string);
			object value2 = default(object);
			while (true)
			{
				ISerializationCallbackReceiver serializationCallbackReceiver = P_1 as ISerializationCallbackReceiver;
				int num = 615757455;
				while (true)
				{
					switch (num ^ 0x24B3B68F)
					{
					case 2:
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
								Logger.LogError(ex.ToString(), true);
							}
						}
						Type type = P_1.GetType();
						if (ReflectionTools.DoesTypeImplement(type, typeof(IExportToJson)))
						{
							((IExportToJson)P_1).WriteJson(P_0, appendValueDelegate);
							return;
						}
						while (true)
						{
							IL_046c:
							int num2;
							if (object.ReferenceEquals(type, typeof(string)))
							{
								P_0.Append('"');
								num2 = 615757468;
								goto IL_0089;
							}
							goto IL_0184;
							IL_0089:
							while (true)
							{
								int num3;
								switch (num2 ^ 0x24B3B68F)
								{
								case 18:
									num2 = 615757447;
									continue;
								case 15:
									return;
								case 21:
									break;
								case 16:
									if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
									{
										P_0.Append('[');
										flag = true;
										num2 = 615757453;
										continue;
									}
									goto case 10;
								case 3:
									goto end_IL_0089;
								case 0:
									goto IL_01fe;
								case 7:
									hCJWJvYFclybsTQQwAQtIgdrEHG(P_0, list[num13]);
									num13++;
									num2 = 615757455;
									continue;
								case 10:
									if (ReflectionTools.IsGenericType(type) && ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
									{
										Type type2 = ReflectionTools.GetGenericArguments(type)[0];
										flag3 = false;
										conversionType = null;
										if (ReflectionTools.IsEnum(type2))
										{
											flag3 = true;
											conversionType = ReflectionTools.GetUnderlyingEnumType(type2);
											num2 = 615757449;
											continue;
										}
										goto default;
									}
									goto IL_0615;
								case 20:
									P_0.Append(']');
									return;
								case 14:
									if (ReflectionTools.IsEnum(type))
									{
										Type underlyingType = Enum.GetUnderlyingType(type);
										hCJWJvYFclybsTQQwAQtIgdrEHG(P_0, Convert.ChangeType(P_1, underlyingType));
										num2 = 615757440;
										continue;
									}
									goto case 16;
								case 4:
									goto IL_02cb;
								case 25:
									if (object.ReferenceEquals(type, typeof(Guid)))
									{
										hCJWJvYFclybsTQQwAQtIgdrEHG(P_0, P_1.ToString());
										return;
									}
									goto case 14;
								case 12:
									P_0.Append(((float)P_1).ToString(CultureInfo.InvariantCulture));
									return;
								case 19:
									P_0.Append((string)P_1);
									P_0.Append('"');
									return;
								case 2:
									list = P_1 as IList;
									num13 = 0;
									num2 = 615757455;
									continue;
								case 17:
									if (object.ReferenceEquals(type, typeof(bool)))
									{
										P_0.Append(((bool)P_1) ? "true" : "false");
										return;
									}
									goto case 25;
								case 9:
									P_0.Append(((decimal)P_1).ToString(CultureInfo.InvariantCulture));
									return;
								case 23:
									num2 = 615757448;
									continue;
								case 24:
									if (object.ReferenceEquals(type, typeof(double)))
									{
										P_0.Append(((double)P_1).ToString(CultureInfo.InvariantCulture));
										return;
									}
									goto IL_0494;
								case 11:
									goto IL_041c;
								case 22:
									P_0.Append(',');
									num2 = 615757448;
									continue;
								case 13:
									flag = false;
									num2 = 615757464;
									continue;
								case 1:
									goto end_IL_046c;
								case 8:
									goto IL_046c;
								case 5:
									goto IL_0494;
								default:
									{
										P_0.Append('{');
										IDictionary dictionary = P_1 as IDictionary;
										bool flag4 = true;
										IEnumerator enumerator3 = dictionary.Keys.GetEnumerator();
										try
										{
											while (enumerator3.MoveNext())
											{
												while (true)
												{
													IL_0583:
													object current3 = enumerator3.Current;
													int num14;
													if (flag4)
													{
														flag4 = false;
														num14 = 615757450;
														goto IL_04e6;
													}
													goto IL_0570;
													IL_04e6:
													while (true)
													{
														switch (num14 ^ 0x24B3B68F)
														{
														case 4:
															num14 = 615757453;
															continue;
														case 6:
															P_0.Append("\":");
															hCJWJvYFclybsTQQwAQtIgdrEHG(P_0, dictionary[current3]);
															num14 = 615757455;
															continue;
														case 3:
															P_0.Append(flag3 ? Convert.ChangeType(current3, conversionType).ToString() : current3.ToString());
															num14 = 615757449;
															continue;
														case 5:
															P_0.Append('"');
															num14 = 615757452;
															continue;
														case 1:
															break;
														case 2:
															goto IL_0583;
														default:
															goto end_IL_0583;
														}
														break;
													}
													goto IL_0570;
													IL_0570:
													P_0.Append(',');
													num14 = 615757450;
													goto IL_04e6;
													continue;
													end_IL_0583:
													break;
												}
											}
										}
										finally
										{
											IDisposable disposable = enumerator3 as IDisposable;
											while (true)
											{
												IL_05b1:
												int num15 = 615757454;
												while (true)
												{
													switch (num15 ^ 0x24B3B68F)
													{
													case 2:
														break;
													default:
														goto end_IL_05b6;
													case 1:
														if (disposable != null)
														{
															goto IL_05d3;
														}
														goto end_IL_05b6;
													case 0:
														goto end_IL_05b6;
													}
													goto IL_05b1;
													IL_05d3:
													disposable.Dispose();
													num15 = 615757455;
													continue;
													end_IL_05b6:
													break;
												}
												break;
											}
										}
										P_0.Append('}');
										goto IL_05eb;
									}
									IL_0615:
									P_0.Append('{');
									flag2 = true;
									num3 = 615757453;
									goto IL_05f0;
									IL_05f0:
									switch (num3 ^ 0x24B3B68F)
									{
									case 3:
										break;
									case 1:
										return;
									case 0:
										goto IL_0615;
									default:
									{
										IEnumerable<FieldInfo> fields = ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
										using (IEnumerator<FieldInfo> enumerator = fields.GetEnumerator())
										{
											while (enumerator.MoveNext())
											{
												while (true)
												{
													FieldInfo current = enumerator.Current;
													if (current.IsDefined(typeof(NonSerializedAttribute), true) || current.IsDefined(typeof(DoNotSerializeAttribute), true))
													{
														break;
													}
													int num4;
													int num5;
													if (current.IsPublic)
													{
														num4 = 615757453;
														num5 = num4;
													}
													else
													{
														num4 = 615757447;
														num5 = num4;
													}
													while (true)
													{
														switch (num4 ^ 0x24B3B68F)
														{
														case 0:
															num4 = 615757451;
															continue;
														case 6:
															if (current.IsDefined(typeof(SerializeAttribute), true))
															{
																goto IL_0695;
															}
															goto case 1;
														case 5:
															P_0.Append("\":");
															hCJWJvYFclybsTQQwAQtIgdrEHG(P_0, value);
															num4 = 615757446;
															continue;
														case 1:
															name = current.Name;
															num4 = 615757448;
															continue;
														case 2:
															value = current.GetValue(P_1);
															if (value == null)
															{
																goto end_IL_073b;
															}
															if (flag2)
															{
																flag2 = false;
																num4 = 615757452;
																continue;
															}
															goto case 10;
														case 10:
															P_0.Append(',');
															num4 = 615757452;
															continue;
														case 4:
															break;
														case 8:
															if (current.IsDefined(typeof(SerializeAttribute), true))
															{
																goto case 2;
															}
															goto IL_07a6;
														case 7:
															P_0.Append(name);
															num4 = 615757450;
															continue;
														case 3:
															P_0.Append('"');
															num4 = 615757449;
															continue;
														default:
															goto end_IL_073b;
														}
														break;
														IL_07a6:
														int num6;
														if (current.IsDefined(typeof(SerializeField), true))
														{
															num4 = 615757453;
															num6 = num4;
														}
														else
														{
															num4 = 615757446;
															num6 = num4;
														}
														continue;
														IL_0695:
														int num7;
														if (!string.IsNullOrEmpty(name = (CollectionTools.GetValue(current.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
														{
															num4 = 615757448;
															num7 = num4;
														}
														else
														{
															num4 = 615757454;
															num7 = num4;
														}
													}
													continue;
													end_IL_073b:
													break;
												}
											}
										}
										IEnumerable<PropertyInfo> properties = ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
										using (IEnumerator<PropertyInfo> enumerator2 = properties.GetEnumerator())
										{
											while (enumerator2.MoveNext())
											{
												while (true)
												{
													PropertyInfo current2 = enumerator2.Current;
													int num8;
													int num9;
													if (!current2.CanWrite)
													{
														num8 = 615757446;
														num9 = num8;
													}
													else
													{
														num8 = 615757453;
														num9 = num8;
													}
													while (true)
													{
														switch (num8 ^ 0x24B3B68F)
														{
														case 8:
															num8 = 615757452;
															continue;
														case 1:
															P_0.Append(',');
															num8 = 615757450;
															continue;
														case 6:
															P_0.Append(name2);
															P_0.Append("\":");
															num8 = 615757444;
															continue;
														case 0:
															name2 = current2.Name;
															num8 = 615757449;
															continue;
														case 7:
															break;
														case 10:
															value2 = current2.GetValue(P_1, null);
															if (value2 == null)
															{
																goto end_IL_0938;
															}
															if (flag2)
															{
																flag2 = false;
																num8 = 615757450;
																continue;
															}
															goto case 1;
														case 2:
															goto IL_08e7;
														case 11:
															hCJWJvYFclybsTQQwAQtIgdrEHG(P_0, value2);
															num8 = 615757446;
															continue;
														case 3:
															goto end_IL_082b;
														case 4:
															if (!current2.IsDefined(typeof(SerializeAttribute), true))
															{
																goto case 0;
															}
															goto IL_0975;
														case 5:
															P_0.Append('"');
															num8 = 615757451;
															continue;
														default:
															goto end_IL_0938;
														}
														int num10;
														if (!current2.CanRead)
														{
															num8 = 615757446;
															num10 = num8;
														}
														else
														{
															num8 = 615757445;
															num10 = num8;
														}
														continue;
														IL_0975:
														int num11;
														if (string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(current2.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
														{
															num8 = 615757455;
															num11 = num8;
														}
														else
														{
															num8 = 615757449;
															num11 = num8;
														}
														continue;
														IL_08e7:
														if (!current2.IsDefined(typeof(SerializeAttribute), true))
														{
															goto end_IL_0938;
														}
														int num12;
														if (!current2.IsDefined(typeof(DoNotSerializeAttribute), true))
														{
															num8 = 615757448;
															num12 = num8;
														}
														else
														{
															num8 = 615757446;
															num12 = num8;
														}
														continue;
														end_IL_082b:
														break;
													}
													continue;
													end_IL_0938:
													break;
												}
											}
										}
										P_0.Append('}');
										return;
									}
									}
									goto IL_05eb;
									IL_05eb:
									num3 = 615757454;
									goto IL_05f0;
								}
								if (object.ReferenceEquals(type, typeof(ushort)) || object.ReferenceEquals(type, typeof(byte)))
								{
									goto end_IL_046c;
								}
								int num16;
								if (!object.ReferenceEquals(type, typeof(sbyte)))
								{
									num2 = 615757451;
									num16 = num2;
								}
								else
								{
									num2 = 615757454;
									num16 = num2;
								}
								continue;
								IL_041c:
								int num17;
								if (flag)
								{
									num2 = 615757442;
									num17 = num2;
								}
								else
								{
									num2 = 615757465;
									num17 = num2;
								}
								continue;
								IL_02cb:
								int num18;
								if (!object.ReferenceEquals(type, typeof(float)))
								{
									num2 = 615757463;
									num18 = num2;
								}
								else
								{
									num2 = 615757443;
									num18 = num2;
								}
								continue;
								IL_01fe:
								int num19;
								if (num13 < list.Count)
								{
									num2 = 615757444;
									num19 = num2;
								}
								else
								{
									num2 = 615757467;
									num19 = num2;
								}
								continue;
								IL_0494:
								int num20;
								if (!object.ReferenceEquals(type, typeof(decimal)))
								{
									num2 = 615757470;
									num20 = num2;
								}
								else
								{
									num2 = 615757446;
									num20 = num2;
								}
								continue;
								end_IL_0089:
								break;
							}
							goto IL_0184;
							IL_0184:
							if (object.ReferenceEquals(type, typeof(int)) || object.ReferenceEquals(type, typeof(uint)) || object.ReferenceEquals(type, typeof(long)) || object.ReferenceEquals(type, typeof(ulong)))
							{
								break;
							}
							int num21;
							if (!object.ReferenceEquals(type, typeof(short)))
							{
								num2 = 615757466;
								num21 = num2;
							}
							else
							{
								num2 = 615757454;
								num21 = num2;
							}
							goto IL_0089;
							continue;
							end_IL_046c:
							break;
						}
						P_0.Append(P_1.ToString());
						return;
					}
					}
					break;
					IL_0010:
					num = 615757454;
				}
			}
		}
	}
}
