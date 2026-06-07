using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Utils
{
	public static class SerializationTools
	{
		public static string SerializeObjectToXmlString<T>(T obj)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			string empty = string.Empty;
			using (StringWriter stringWriter = new StringWriter())
			{
				xmlSerializer.Serialize(stringWriter, obj);
				return stringWriter.ToString();
			}
		}

		public static void WriteXmlElement(XmlWriter writer, string name, object value)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			while (!string.IsNullOrEmpty(name))
			{
				while (true)
				{
					IL_004a:
					bool flag = false;
					int num;
					if (value is IExportToXml && (value as IExportToXml).writesOwnElementTag)
					{
						flag = true;
						num = 806935094;
						goto IL_0013;
					}
					goto IL_0038;
					IL_0013:
					while (true)
					{
						switch (num ^ 0x3018DA33)
						{
						case 0:
							num = 806935088;
							continue;
						case 5:
							break;
						case 1:
							goto IL_004a;
						case 4:
							goto IL_006a;
						case 3:
							goto end_IL_004a;
						default:
							WpByJrdvXmDlRxwNQNcWeChFIpHH(writer, value);
							writer.WriteEndElement();
							return;
						}
						break;
					}
					goto IL_0038;
					IL_006a:
					writer.WriteStartElement(name);
					num = 806935089;
					goto IL_0013;
					IL_0038:
					if (flag)
					{
						WpByJrdvXmDlRxwNQNcWeChFIpHH(writer, value);
						return;
					}
					goto IL_006a;
					continue;
					end_IL_004a:
					break;
				}
			}
			throw new ArgumentNullException("name");
		}

		public static void WriteXmlElement<T>(XmlWriter writer, string name, T value)
		{
			WriteXmlElement(writer, name, (object)value);
		}

		private static void WpByJrdvXmDlRxwNQNcWeChFIpHH(XmlWriter P_0, object P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writer");
			}
			int num2 = default(int);
			IList list = default(IList);
			bool flag = default(bool);
			IEnumerable enumerable = default(IEnumerable);
			FieldInfo current3 = default(FieldInfo);
			string name = default(string);
			object value = default(object);
			string name2 = default(string);
			object value2 = default(object);
			while (P_1 != null)
			{
				while (true)
				{
					IL_04e9:
					Type type = P_1.GetType();
					if (!ReflectionTools.DoesTypeImplement(type, typeof(IExportToXml)))
					{
						while (true)
						{
							IL_029f:
							int num;
							if (object.ReferenceEquals(type, typeof(string)))
							{
								P_0.WriteValue(CleanInvalidXmlChars((string)P_1));
								num = 1948389497;
								goto IL_0016;
							}
							goto IL_035d;
							IL_0016:
							while (true)
							{
								switch (num ^ 0x7422107D)
								{
								case 38:
									num = 1948389478;
									continue;
								case 28:
									break;
								case 0:
									if (object.ReferenceEquals(type, typeof(double)))
									{
										P_0.WriteValue((double)P_1);
										num = 1948389479;
										continue;
									}
									goto IL_0337;
								case 29:
									if (object.ReferenceEquals(type, typeof(DateTime)))
									{
										P_0.WriteValue((DateTime)P_1);
										return;
									}
									goto case 32;
								case 10:
									if (object.ReferenceEquals(type, typeof(ushort)))
									{
										P_0.WriteValue((ushort)P_1);
										return;
									}
									goto IL_04c3;
								case 26:
									return;
								case 16:
								{
									Type underlyingType = Enum.GetUnderlyingType(type);
									P_0.WriteValue(Convert.ChangeType(P_1, underlyingType));
									num = 1948389496;
									continue;
								}
								case 1:
									return;
								case 3:
									goto IL_01a7;
								case 9:
									goto IL_01cd;
								case 17:
									if (object.ReferenceEquals(type, typeof(ulong)))
									{
										P_0.WriteValue(((ulong)P_1).ToString());
										return;
									}
									goto case 23;
								case 12:
									num = 1948389474;
									continue;
								case 40:
									P_0.WriteValue((decimal)P_1);
									num = 1948389500;
									continue;
								case 31:
									if (num2 >= list.Count)
									{
										return;
									}
									goto case 18;
								case 27:
									goto end_IL_029f;
								case 23:
									if (object.ReferenceEquals(type, typeof(float)))
									{
										P_0.WriteValue((float)P_1);
										num = 1948389499;
										continue;
									}
									goto case 0;
								case 20:
									goto IL_029f;
								case 5:
									return;
								case 24:
									goto IL_02da;
								case 8:
									return;
								case 37:
									if (object.ReferenceEquals(type, typeof(long)))
									{
										P_0.WriteValue((long)P_1);
										return;
									}
									goto case 17;
								case 15:
									goto IL_0337;
								case 14:
									goto IL_035d;
								case 11:
									flag = ReflectionTools.IsDefined(type, typeof(SerializationTypeAttribute), true) && ReflectionTools.GetAttribute<SerializationTypeAttribute>(type, true).serializationType == SerializationTypeAttribute.SerializationType.Object;
									num = 1948389503;
									continue;
								case 2:
									goto IL_03be;
								case 19:
									P_0.WriteValue((int)P_1);
									num = 1948389476;
									continue;
								case 32:
									if (object.ReferenceEquals(type, typeof(Guid)))
									{
										P_0.WriteValue(((Guid)P_1/*cast due to .constrained prefix*/).ToString());
										return;
									}
									goto IL_0585;
								case 18:
									WriteXmlElement(P_0, (list[num2] != null) ? list[num2].GetType().Name : "value", list[num2]);
									num2++;
									num = 1948389474;
									continue;
								case 6:
									return;
								case 21:
									P_0.WriteValue((int)P_1);
									return;
								case 34:
									return;
								case 7:
									P_0.WriteValue((short)P_1);
									return;
								case 13:
									goto IL_04c3;
								case 22:
									goto IL_04e9;
								case 25:
									return;
								case 33:
									P_0.WriteValue((uint)P_1);
									num = 1948389493;
									continue;
								case 4:
									return;
								case 30:
									P_0.WriteValue((bool)P_1);
									num = 1948389471;
									continue;
								case 36:
									goto IL_055f;
								case 39:
									goto IL_0585;
								default:
									goto IL_05ab;
								}
								break;
								IL_055f:
								int num3;
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									num = 1948389468;
									num3 = num;
								}
								else
								{
									num = 1948389464;
									num3 = num;
								}
								continue;
								IL_01a7:
								int num4;
								if (!object.ReferenceEquals(type, typeof(bool)))
								{
									num = 1948389472;
									num4 = num;
								}
								else
								{
									num = 1948389475;
									num4 = num;
								}
								continue;
								IL_0585:
								int num5;
								if (ReflectionTools.DoesTypeImplement(type, typeof(Enum)))
								{
									num = 1948389485;
									num5 = num;
								}
								else
								{
									num = 1948389494;
									num5 = num;
								}
								continue;
								IL_03be:
								if (!flag)
								{
									if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
									{
										list = P_1 as IList;
										num2 = 0;
										num = 1948389489;
										continue;
									}
									goto IL_05ab;
								}
								goto IL_0780;
								IL_0337:
								int num6;
								if (!object.ReferenceEquals(type, typeof(decimal)))
								{
									num = 1948389502;
									num6 = num;
								}
								else
								{
									num = 1948389461;
									num6 = num;
								}
								continue;
								IL_04c3:
								int num7;
								if (object.ReferenceEquals(type, typeof(int)))
								{
									num = 1948389486;
									num7 = num;
								}
								else
								{
									num = 1948389465;
									num7 = num;
								}
								continue;
								IL_02da:
								int num8;
								if (!object.ReferenceEquals(type, typeof(short)))
								{
									num = 1948389495;
									num8 = num;
								}
								else
								{
									num = 1948389498;
									num8 = num;
								}
							}
							goto IL_00ca;
							IL_035d:
							if (object.ReferenceEquals(type, typeof(char)))
							{
								P_0.WriteValue(CleanInvalidXmlChars(P_1.ToString()));
								return;
							}
							goto IL_01cd;
							IL_00ca:
							int num9;
							if (object.ReferenceEquals(type, typeof(sbyte)))
							{
								num = 1948389480;
								num9 = num;
							}
							else
							{
								num = 1948389477;
								num9 = num;
							}
							goto IL_0016;
							IL_01cd:
							if (object.ReferenceEquals(type, typeof(byte)))
							{
								P_0.WriteValue((int)P_1);
								return;
							}
							goto IL_00ca;
							continue;
							end_IL_029f:
							break;
						}
						break;
					}
					((IExportToXml)P_1).WriteXml(P_0);
					return;
					IL_05ab:
					if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
					{
						IDictionary dictionary = P_1 as IDictionary;
						IEnumerator enumerator = dictionary.Keys.GetEnumerator();
						try
						{
							while (true)
							{
								int num10;
								int num11;
								if (enumerator.MoveNext())
								{
									num10 = 1948389503;
									num11 = num10;
								}
								else
								{
									num10 = 1948389502;
									num11 = num10;
								}
								while (true)
								{
									switch (num10 ^ 0x7422107D)
									{
									case 0:
										num10 = 1948389503;
										continue;
									default:
										return;
									case 2:
									{
										object current = enumerator.Current;
										WriteXmlElement(P_0, current.ToString(), dictionary[current]);
										num10 = 1948389500;
										continue;
									}
									case 1:
										break;
									case 3:
										return;
									}
									break;
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								while (true)
								{
									IL_0649:
									int num12 = 1948389500;
									while (true)
									{
										switch (num12 ^ 0x7422107D)
										{
										case 2:
											break;
										default:
											goto end_IL_064e;
										case 1:
											goto IL_0667;
										case 0:
											goto end_IL_064e;
										}
										goto IL_0649;
										IL_0667:
										disposable.Dispose();
										num12 = 1948389501;
										continue;
										end_IL_064e:
										break;
									}
									break;
								}
							}
						}
					}
					while (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
					{
						int num13 = 1948389500;
						while (true)
						{
							switch (num13 ^ 0x7422107D)
							{
							case 0:
								num13 = 1948389503;
								continue;
							case 2:
								break;
							case 1:
								enumerable = P_1 as IEnumerable;
								num13 = 1948389502;
								continue;
							default:
							{
								IEnumerator enumerator2 = enumerable.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										while (true)
										{
											object current2 = enumerator2.Current;
											WriteXmlElement(P_0, (current2 != null) ? current2.GetType().Name : "value", current2);
											int num14 = 1948389500;
											while (true)
											{
												switch (num14 ^ 0x7422107D)
												{
												case 0:
													num14 = 1948389503;
													continue;
												case 2:
													break;
												default:
													goto end_IL_06ed;
												}
												break;
											}
											continue;
											end_IL_06ed:
											break;
										}
									}
									return;
								}
								finally
								{
									IDisposable disposable2 = enumerator2 as IDisposable;
									if (disposable2 != null)
									{
										while (true)
										{
											IL_0734:
											int num15 = 1948389503;
											while (true)
											{
												switch (num15 ^ 0x7422107D)
												{
												case 0:
													break;
												default:
													goto end_IL_0739;
												case 2:
													goto IL_0752;
												case 1:
													goto end_IL_0739;
												}
												goto IL_0734;
												IL_0752:
												disposable2.Dispose();
												num15 = 1948389500;
												continue;
												end_IL_0739:
												break;
											}
											break;
										}
									}
								}
							}
							}
							break;
						}
					}
					goto IL_0780;
					IL_0780:
					while (true)
					{
						ISerializationCallbackReceiver serializationCallbackReceiver = P_1 as ISerializationCallbackReceiver;
						int num16 = 1948389500;
						while (true)
						{
							switch (num16 ^ 0x7422107D)
							{
							case 0:
								goto IL_0762;
							case 2:
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
								IEnumerable<FieldInfo> fields = ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
								IEnumerator<FieldInfo> enumerator3 = fields.GetEnumerator();
								try
								{
									while (true)
									{
										IL_08ce:
										int num17;
										int num18;
										if (!enumerator3.MoveNext())
										{
											num17 = 1948389500;
											num18 = num17;
										}
										else
										{
											num17 = 1948389499;
											num18 = num17;
										}
										while (true)
										{
											switch (num17 ^ 0x7422107D)
											{
											case 5:
												num17 = 1948389499;
												continue;
											default:
												goto end_IL_07ca;
											case 4:
												if (current3.IsDefined(typeof(SerializeAttribute), true))
												{
													int num20;
													if (!string.IsNullOrEmpty(name = (CollectionTools.GetValue(current3.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
													{
														num17 = 1948389493;
														num20 = num17;
													}
													else
													{
														num17 = 1948389503;
														num20 = num17;
													}
													continue;
												}
												goto case 2;
											case 8:
												WriteXmlElement(P_0, name, value);
												num17 = 1948389498;
												continue;
											case 6:
												current3 = enumerator3.Current;
												if (current3.IsDefined(typeof(NonSerializedAttribute), true) || current3.IsDefined(typeof(DoNotSerializeAttribute), true))
												{
													break;
												}
												if (!current3.IsPublic)
												{
													int num21;
													if (!current3.IsDefined(typeof(SerializeAttribute), true))
													{
														num17 = 1948389502;
														num21 = num17;
													}
													else
													{
														num17 = 1948389501;
														num21 = num17;
													}
													continue;
												}
												goto case 0;
											case 7:
												break;
											case 3:
											{
												int num19;
												if (!current3.IsDefined(typeof(SerializeField), true))
												{
													num17 = 1948389498;
													num19 = num17;
												}
												else
												{
													num17 = 1948389501;
													num19 = num17;
												}
												continue;
											}
											case 2:
												name = current3.Name;
												num17 = 1948389493;
												continue;
											case 0:
											{
												value = current3.GetValue(P_1);
												int num22;
												if (value == null)
												{
													num17 = 1948389498;
													num22 = num17;
												}
												else
												{
													num17 = 1948389497;
													num22 = num17;
												}
												continue;
											}
											case 1:
												goto end_IL_07ca;
											}
											goto IL_08ce;
											continue;
											end_IL_07ca:
											break;
										}
										break;
									}
								}
								finally
								{
									if (enumerator3 != null)
									{
										while (true)
										{
											IL_094e:
											int num23 = 1948389500;
											while (true)
											{
												switch (num23 ^ 0x7422107D)
												{
												case 0:
													break;
												default:
													goto end_IL_0953;
												case 1:
													goto IL_096c;
												case 2:
													goto end_IL_0953;
												}
												goto IL_094e;
												IL_096c:
												enumerator3.Dispose();
												num23 = 1948389503;
												continue;
												end_IL_0953:
												break;
											}
											break;
										}
									}
								}
								IEnumerable<PropertyInfo> properties = ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
								using (IEnumerator<PropertyInfo> enumerator4 = properties.GetEnumerator())
								{
									while (enumerator4.MoveNext())
									{
										while (true)
										{
											PropertyInfo current4 = enumerator4.Current;
											int num24 = 1948389497;
											while (true)
											{
												switch (num24 ^ 0x7422107D)
												{
												case 0:
													num24 = 1948389499;
													continue;
												case 2:
													WriteXmlElement(P_0, name2, value2);
													num24 = 1948389496;
													continue;
												case 1:
													name2 = current4.Name;
													num24 = 1948389503;
													continue;
												case 4:
													break;
												case 3:
													if (!current4.IsDefined(typeof(SerializeAttribute), true))
													{
														goto case 1;
													}
													goto IL_0a65;
												case 6:
													goto end_IL_0998;
												default:
													goto end_IL_0aa5;
												}
												if (!current4.CanWrite || !current4.IsDefined(typeof(SerializeAttribute), true) || current4.IsDefined(typeof(DoNotSerializeAttribute), true) || !current4.CanRead)
												{
													goto end_IL_0aa5;
												}
												value2 = current4.GetValue(P_1, null);
												int num25;
												if (value2 == null)
												{
													num24 = 1948389496;
													num25 = num24;
												}
												else
												{
													num24 = 1948389502;
													num25 = num24;
												}
												continue;
												IL_0a65:
												int num26;
												if (string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(current4.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
												{
													num24 = 1948389500;
													num26 = num24;
												}
												else
												{
													num24 = 1948389503;
													num26 = num24;
												}
												continue;
												end_IL_0998:
												break;
											}
											continue;
											end_IL_0aa5:
											break;
										}
									}
									return;
								}
							}
							}
							break;
							IL_0762:
							num16 = 1948389503;
						}
					}
				}
			}
		}

		public static string ReadXmlElement(XmlReader reader, string name)
		{
			string result = string.Empty;
			bool isEmptyElement = default(bool);
			while (true)
			{
				int num = 1785941503;
				while (true)
				{
					switch (num ^ 0x6A734DFC)
					{
					case 0:
						break;
					case 3:
						isEmptyElement = reader.IsEmptyElement;
						reader.ReadStartElement(name);
						num = 1785941501;
						continue;
					case 4:
						result = reader.ReadContentAsString();
						reader.ReadEndElement();
						num = 1785941502;
						continue;
					case 1:
					{
						int num2;
						if (isEmptyElement)
						{
							num = 1785941502;
							num2 = num;
						}
						else
						{
							num = 1785941496;
							num2 = num;
						}
						continue;
					}
					default:
						return result;
					}
					break;
				}
			}
		}

		public static T ReadXmlElement<T>(XmlReader reader, string name)
		{
			string text = ReadXmlElement(reader, name);
			Type typeFromHandle = typeof(T);
			int num;
			uint result4 = default(uint);
			long result5 = default(long);
			double result6 = default(double);
			decimal result7 = default(decimal);
			ulong result8 = default(ulong);
			byte result9 = default(byte);
			float result10 = default(float);
			if (object.ReferenceEquals(typeFromHandle, typeof(int)))
			{
				int result;
				if (int.TryParse(text, out result))
				{
					return (T)(object)result;
				}
			}
			else
			{
				if (!object.ReferenceEquals(typeFromHandle, typeof(float)))
				{
					if (object.ReferenceEquals(typeFromHandle, typeof(bool)))
					{
						num = -1369188357;
					}
					else
					{
						if (object.ReferenceEquals(typeFromHandle, typeof(string)))
						{
							return (T)(object)text;
						}
						if (object.ReferenceEquals(typeFromHandle, typeof(short)))
						{
							short result2;
							if (short.TryParse(text, out result2))
							{
								return (T)(object)result2;
							}
							goto IL_030d;
						}
						int num7;
						if (!object.ReferenceEquals(typeFromHandle, typeof(byte)))
						{
							if (object.ReferenceEquals(typeFromHandle, typeof(ushort)))
							{
								ushort result3;
								if (ushort.TryParse(text, out result3))
								{
									return (T)(object)result3;
								}
								goto IL_030d;
							}
							int num6;
							if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
							{
								int num2;
								if (uint.TryParse(text, out result4))
								{
									num = -1369188356;
									num2 = num;
								}
								else
								{
									num = -1369188358;
									num2 = num;
								}
							}
							else if (object.ReferenceEquals(typeFromHandle, typeof(long)))
							{
								int num3;
								if (long.TryParse(text, out result5))
								{
									num = -1369188360;
									num3 = num;
								}
								else
								{
									num = -1369188358;
									num3 = num;
								}
							}
							else if (!object.ReferenceEquals(typeFromHandle, typeof(ulong)))
							{
								if (object.ReferenceEquals(typeFromHandle, typeof(double)))
								{
									int num4;
									if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result6))
									{
										num = -1369188359;
										num4 = num;
									}
									else
									{
										num = -1369188358;
										num4 = num;
									}
								}
								else
								{
									if (!object.ReferenceEquals(typeFromHandle, typeof(decimal)))
									{
										throw new NotImplementedException();
									}
									int num5;
									if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result7))
									{
										num = -1369188355;
										num5 = num;
									}
									else
									{
										num = -1369188358;
										num5 = num;
									}
								}
							}
							else if (ulong.TryParse(text, out result8))
							{
								num = -1369188365;
								num6 = num;
							}
							else
							{
								num = -1369188358;
								num6 = num;
							}
						}
						else if (byte.TryParse(text, out result9))
						{
							num = -1369188368;
							num7 = num;
						}
						else
						{
							num = -1369188358;
							num7 = num;
						}
					}
					goto IL_006f;
				}
				if (float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result10))
				{
					goto IL_006a;
				}
			}
			goto IL_030d;
			IL_030d:
			return default(T);
			IL_006a:
			num = -1369188353;
			goto IL_006f;
			IL_006f:
			bool result11 = default(bool);
			while (true)
			{
				switch (num ^ -1369188359)
				{
				case 8:
					break;
				case 10:
					return (T)(object)result8;
				case 2:
					goto IL_00ef;
				case 6:
					return (T)(object)result10;
				case 0:
					return (T)(object)result6;
				case 9:
					return (T)(object)result9;
				case 5:
					return (T)(object)result4;
				case 4:
					return (T)(object)result7;
				case 7:
					return (T)(object)result11;
				case 1:
					return (T)(object)result5;
				default:
					goto IL_030d;
				}
				break;
				IL_00ef:
				int num8;
				if (!bool.TryParse(text, out result11))
				{
					num = -1369188358;
					num8 = num;
				}
				else
				{
					num = -1369188354;
					num8 = num;
				}
			}
			goto IL_006a;
		}

		public static bool TryReadXmlElement(XmlReader reader, string name, out string outValue)
		{
			outValue = string.Empty;
			bool isEmptyElement = reader.IsEmptyElement;
			try
			{
				reader.ReadStartElement(name);
			}
			catch
			{
				return false;
			}
			if (!isEmptyElement)
			{
				while (true)
				{
					int num = -585769416;
					while (true)
					{
						switch (num ^ -585769414)
						{
						case 0:
							break;
						case 2:
							outValue = reader.ReadContentAsString();
							reader.ReadEndElement();
							num = -585769413;
							continue;
						default:
							goto end_IL_001f;
						}
						break;
					}
					continue;
					end_IL_001f:
					break;
				}
			}
			return true;
		}

		public static bool TryReadXmlElement<T>(XmlReader reader, string name, out T outValue)
		{
			outValue = default(T);
			Type typeFromHandle = typeof(T);
			string outValue2;
			if (!TryReadXmlElement(reader, name, out outValue2))
			{
				return false;
			}
			if (object.ReferenceEquals(typeFromHandle, typeof(string)))
			{
				goto IL_0034;
			}
			int num;
			int result4 = default(int);
			sbyte result5 = default(sbyte);
			byte result6 = default(byte);
			int num4;
			if (!object.ReferenceEquals(typeFromHandle, typeof(byte)))
			{
				int num3;
				if (!object.ReferenceEquals(typeFromHandle, typeof(sbyte)))
				{
					if (object.ReferenceEquals(typeFromHandle, typeof(short)))
					{
						num = -1444931641;
					}
					else
					{
						if (object.ReferenceEquals(typeFromHandle, typeof(ushort)))
						{
							ushort result;
							if (ushort.TryParse(outValue2, out result))
							{
								outValue = (T)(object)result;
								return true;
							}
							goto IL_03c4;
						}
						int num2;
						if (!object.ReferenceEquals(typeFromHandle, typeof(int)))
						{
							if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
							{
								num = -1444931646;
							}
							else if (!object.ReferenceEquals(typeFromHandle, typeof(float)))
							{
								if (!object.ReferenceEquals(typeFromHandle, typeof(double)))
								{
									if (object.ReferenceEquals(typeFromHandle, typeof(decimal)))
									{
										decimal result2;
										if (decimal.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out result2))
										{
											outValue = (T)(object)result2;
											return true;
										}
									}
									else
									{
										if (!object.ReferenceEquals(typeFromHandle, typeof(bool)))
										{
											if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Enum)))
											{
												Type underlyingType = Enum.GetUnderlyingType(typeFromHandle);
												if (!object.ReferenceEquals(underlyingType, typeof(int)))
												{
													throw new NotImplementedException("Only INT enums are currently supported!");
												}
												goto IL_039e;
											}
											throw new NotImplementedException();
										}
										bool result3;
										if (bool.TryParse(outValue2, out result3))
										{
											outValue = (T)(object)result3;
											return true;
										}
									}
									goto IL_03c4;
								}
								num = -1444931639;
							}
							else
							{
								num = -1444931648;
							}
						}
						else if (!int.TryParse(outValue2, out result4))
						{
							num = -1444931634;
							num2 = num;
						}
						else
						{
							num = -1444931637;
							num2 = num;
						}
					}
				}
				else if (sbyte.TryParse(outValue2, out result5))
				{
					num = -1444931644;
					num3 = num;
				}
				else
				{
					num = -1444931634;
					num3 = num;
				}
			}
			else if (!byte.TryParse(outValue2, out result6))
			{
				num = -1444931634;
				num4 = num;
			}
			else
			{
				num = -1444931643;
				num4 = num;
			}
			goto IL_0039;
			IL_0039:
			float result9 = default(float);
			while (true)
			{
				switch (num ^ -1444931636)
				{
				case 10:
					break;
				case 3:
					return true;
				case 1:
					return true;
				case 11:
				{
					short result10;
					if (short.TryParse(outValue2, out result10))
					{
						outValue = (T)(object)result10;
						return true;
					}
					goto IL_03c4;
				}
				case 4:
					return true;
				case 9:
					outValue = (T)(object)result6;
					return true;
				case 12:
					goto IL_024c;
				case 7:
					outValue = (T)(object)result4;
					num = -1444931635;
					continue;
				case 13:
					return true;
				case 8:
					outValue = (T)(object)result5;
					num = -1444931633;
					continue;
				case 0:
					outValue = (T)(object)result9;
					return true;
				case 6:
					outValue = (T)(object)outValue2;
					return true;
				case 5:
				{
					double result8;
					if (double.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out result8))
					{
						outValue = (T)(object)result8;
						num = -1444931640;
						continue;
					}
					goto IL_03c4;
				}
				case 14:
				{
					uint result7;
					if (uint.TryParse(outValue2, out result7))
					{
						outValue = (T)(object)result7;
						return true;
					}
					goto IL_03c4;
				}
				case 15:
					goto IL_039e;
				default:
					goto IL_03c4;
				}
				break;
				IL_024c:
				int num5;
				if (!float.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out result9))
				{
					num = -1444931634;
					num5 = num;
				}
				else
				{
					num = -1444931636;
					num5 = num;
				}
			}
			goto IL_0034;
			IL_0034:
			num = -1444931638;
			goto IL_0039;
			IL_03c4:
			return true;
			IL_039e:
			int result11;
			if (int.TryParse(outValue2, out result11))
			{
				outValue = (T)(object)result11;
				num = -1444931647;
				goto IL_0039;
			}
			goto IL_03c4;
		}

		public static bool TryReadXmlElement<T>(XmlReader reader, string name, out T outValue, T defaultValue)
		{
			if (!TryReadXmlElement(reader, name, out outValue))
			{
				outValue = defaultValue;
				return false;
			}
			return true;
		}

		public static bool TryReadXmlStartElement(XmlReader reader, string name, out bool isEmpty)
		{
			isEmpty = reader.IsEmptyElement;
			try
			{
				reader.ReadStartElement(name);
			}
			catch
			{
				return false;
			}
			return true;
		}

		public static bool TryReadXmlEndElement(XmlReader reader)
		{
			try
			{
				reader.ReadEndElement();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static string CleanInvalidXmlChars(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			try
			{
				string pattern = "[^\\x09\\x0A\\x0D\\x20-\\xD7FF\\xE000-\\xFFFD\\x10000-x10FFFF]";
				return Regex.Replace(text, pattern, "");
			}
			catch
			{
				return string.Empty;
			}
		}
	}
}
