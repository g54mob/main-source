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
				goto IL_0006;
			}
			goto IL_00a7;
			IL_0006:
			int num = 1896182021;
			goto IL_000b;
			IL_000b:
			bool flag = default(bool);
			while (true)
			{
				switch (num ^ 0x71057103)
				{
				case 0:
					break;
				case 5:
					flag = true;
					num = 1896182023;
					continue;
				case 4:
					goto IL_0044;
				case 6:
					throw new ArgumentNullException("writer");
				case 3:
					goto IL_006a;
				case 7:
					rzVCEkcFDktOcDTWkIeSgPrRdqGy(writer, value);
					return;
				case 2:
					goto IL_00a7;
				default:
					writer.WriteStartElement(name);
					rzVCEkcFDktOcDTWkIeSgPrRdqGy(writer, value);
					writer.WriteEndElement();
					return;
				}
				break;
			}
			goto IL_0006;
			IL_00a7:
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			goto IL_006a;
			IL_0044:
			int num2;
			if (!flag)
			{
				num = 1896182018;
				num2 = num;
			}
			else
			{
				num = 1896182020;
				num2 = num;
			}
			goto IL_000b;
			IL_006a:
			flag = false;
			if (value is IExportToXml)
			{
				int num3;
				if ((value as IExportToXml).writesOwnElementTag)
				{
					num = 1896182022;
					num3 = num;
				}
				else
				{
					num = 1896182023;
					num3 = num;
				}
				goto IL_000b;
			}
			goto IL_0044;
		}

		public static void WriteXmlElement<T>(XmlWriter writer, string name, T value)
		{
			WriteXmlElement(writer, name, (object)value);
		}

		private static void rzVCEkcFDktOcDTWkIeSgPrRdqGy(XmlWriter P_0, object P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writer");
			}
			IList list = default(IList);
			int num3 = default(int);
			IEnumerable enumerable = default(IEnumerable);
			string name = default(string);
			object value = default(object);
			string name2 = default(string);
			object value2 = default(object);
			while (P_1 != null)
			{
				while (true)
				{
					Type type = P_1.GetType();
					int num;
					int num2;
					if (!ReflectionTools.DoesTypeImplement(type, typeof(IExportToXml)))
					{
						num = -1476844790;
						num2 = num;
					}
					else
					{
						num = -1476844774;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1476844792)
						{
						case 0:
							num = -1476844770;
							continue;
						case 32:
							if (object.ReferenceEquals(type, typeof(char)))
							{
								P_0.WriteValue(CleanInvalidXmlChars(P_1.ToString()));
								return;
							}
							goto case 24;
						case 13:
							if (object.ReferenceEquals(type, typeof(long)))
							{
								P_0.WriteValue((long)P_1);
								return;
							}
							goto case 8;
						case 36:
							if (object.ReferenceEquals(type, typeof(sbyte)))
							{
								P_0.WriteValue((int)P_1);
								num = -1476844793;
								continue;
							}
							goto case 35;
						case 27:
							if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
							{
								list = P_1 as IList;
								num3 = 0;
								num = -1476844788;
								continue;
							}
							goto IL_057d;
						case 37:
							if (object.ReferenceEquals(type, typeof(Guid)))
							{
								P_0.WriteValue(((Guid)P_1/*cast due to .constrained prefix*/).ToString());
								num = -1476844789;
								continue;
							}
							goto IL_0464;
						case 10:
							P_0.WriteValue((DateTime)P_1);
							return;
						case 9:
							P_0.WriteValue((bool)P_1);
							num = -1476844775;
							continue;
						case 12:
							break;
						case 2:
							if (object.ReferenceEquals(type, typeof(string)))
							{
								P_0.WriteValue(CleanInvalidXmlChars((string)P_1));
								return;
							}
							goto case 32;
						case 17:
							return;
						case 23:
							if (object.ReferenceEquals(type, typeof(float)))
							{
								P_0.WriteValue((float)P_1);
								num = -1476844785;
								continue;
							}
							goto case 16;
						case 29:
							return;
						case 4:
							goto IL_026b;
						case 24:
							if (object.ReferenceEquals(type, typeof(byte)))
							{
								P_0.WriteValue((int)P_1);
								return;
							}
							goto case 36;
						case 7:
							return;
						case 30:
							goto end_IL_0016;
						case 28:
							return;
						case 25:
							goto IL_02f8;
						case 15:
							return;
						case 33:
							if (object.ReferenceEquals(type, typeof(int)))
							{
								P_0.WriteValue((int)P_1);
								return;
							}
							goto IL_048a;
						case 14:
						{
							Type underlyingType = Enum.GetUnderlyingType(type);
							P_0.WriteValue(Convert.ChangeType(P_1, underlyingType));
							return;
						}
						case 20:
							goto IL_0374;
						case 8:
							if (object.ReferenceEquals(type, typeof(ulong)))
							{
								P_0.WriteValue(((ulong)P_1).ToString());
								return;
							}
							goto case 23;
						case 3:
							return;
						case 21:
							P_0.WriteValue((uint)P_1);
							return;
						case 11:
							WriteXmlElement(P_0, (list[num3] != null) ? list[num3].GetType().Name : "value", list[num3]);
							num3++;
							num = -1476844788;
							continue;
						case 34:
							if (object.ReferenceEquals(type, typeof(ushort)))
							{
								P_0.WriteValue((ushort)P_1);
								return;
							}
							goto case 33;
						case 1:
							return;
						case 19:
							goto IL_0464;
						case 6:
							goto IL_048a;
						case 5:
							goto IL_04b0;
						case 16:
							if (object.ReferenceEquals(type, typeof(double)))
							{
								P_0.WriteValue((double)P_1);
								num = -1476844780;
								continue;
							}
							goto case 26;
						case 18:
							((IExportToXml)P_1).WriteXml(P_0);
							num = -1476844791;
							continue;
						case 26:
							if (object.ReferenceEquals(type, typeof(decimal)))
							{
								P_0.WriteValue((decimal)P_1);
								return;
							}
							goto IL_02f8;
						case 35:
							if (object.ReferenceEquals(type, typeof(short)))
							{
								P_0.WriteValue((short)P_1);
								return;
							}
							goto case 34;
						case 22:
							goto end_IL_02c0;
						default:
							goto IL_057d;
						}
						if (ReflectionTools.GetAttribute<SerializationTypeAttribute>(type, true).serializationType != SerializationTypeAttribute.SerializationType.Object)
						{
							goto IL_01ef;
						}
						goto IL_0734;
						IL_04b0:
						int num4;
						if (object.ReferenceEquals(type, typeof(DateTime)))
						{
							num = -1476844798;
							num4 = num;
						}
						else
						{
							num = -1476844755;
							num4 = num;
						}
						continue;
						IL_02f8:
						int num5;
						if (object.ReferenceEquals(type, typeof(bool)))
						{
							num = -1476844799;
							num5 = num;
						}
						else
						{
							num = -1476844787;
							num5 = num;
						}
						continue;
						IL_01ef:
						num = -1476844781;
						continue;
						IL_0374:
						if (ReflectionTools.IsDefined(type, typeof(SerializationTypeAttribute), true))
						{
							num = -1476844796;
							continue;
						}
						goto IL_01ef;
						IL_048a:
						int num6;
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							num = -1476844771;
							num6 = num;
						}
						else
						{
							num = -1476844795;
							num6 = num;
						}
						continue;
						IL_026b:
						int num7;
						if (num3 >= list.Count)
						{
							num = -1476844779;
							num7 = num;
						}
						else
						{
							num = -1476844797;
							num7 = num;
						}
						continue;
						IL_0464:
						int num8;
						if (!ReflectionTools.DoesTypeImplement(type, typeof(Enum)))
						{
							num = -1476844772;
							num8 = num;
						}
						else
						{
							num = -1476844794;
							num8 = num;
						}
						continue;
						end_IL_0016:
						break;
					}
					continue;
					IL_057d:
					if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
					{
						IDictionary dictionary = P_1 as IDictionary;
						IEnumerator enumerator = dictionary.Keys.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								while (true)
								{
									object current = enumerator.Current;
									WriteXmlElement(P_0, current.ToString(), dictionary[current]);
									int num9 = -1476844790;
									while (true)
									{
										switch (num9 ^ -1476844792)
										{
										case 0:
											num9 = -1476844791;
											continue;
										case 1:
											break;
										default:
											goto end_IL_05c8;
										}
										break;
									}
									continue;
									end_IL_05c8:
									break;
								}
							}
							return;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								while (true)
								{
									IL_0606:
									int num10 = -1476844790;
									while (true)
									{
										switch (num10 ^ -1476844792)
										{
										case 0:
											break;
										default:
											goto end_IL_060b;
										case 2:
											goto IL_0624;
										case 1:
											goto end_IL_060b;
										}
										goto IL_0606;
										IL_0624:
										disposable.Dispose();
										num10 = -1476844791;
										continue;
										end_IL_060b:
										break;
									}
									break;
								}
							}
						}
					}
					while (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
					{
						int num11 = -1476844789;
						while (true)
						{
							switch (num11 ^ -1476844792)
							{
							case 0:
								num11 = -1476844790;
								continue;
							case 2:
								break;
							case 3:
								enumerable = P_1 as IEnumerable;
								num11 = -1476844791;
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
											int num12 = -1476844790;
											while (true)
											{
												switch (num12 ^ -1476844792)
												{
												case 0:
													num12 = -1476844791;
													continue;
												case 1:
													break;
												default:
													goto end_IL_06aa;
												}
												break;
											}
											continue;
											end_IL_06aa:
											break;
										}
									}
									return;
								}
								finally
								{
									IDisposable disposable2 = enumerator2 as IDisposable;
									while (true)
									{
										IL_06ed:
										int num13 = -1476844791;
										while (true)
										{
											switch (num13 ^ -1476844792)
											{
											case 0:
												break;
											default:
												goto end_IL_06f2;
											case 1:
											{
												int num14;
												if (disposable2 == null)
												{
													num13 = -1476844790;
													num14 = num13;
												}
												else
												{
													num13 = -1476844789;
													num14 = num13;
												}
												continue;
											}
											case 3:
												disposable2.Dispose();
												num13 = -1476844790;
												continue;
											case 2:
												goto end_IL_06f2;
											}
											goto IL_06ed;
											continue;
											end_IL_06f2:
											break;
										}
										break;
									}
								}
							}
							}
							break;
						}
					}
					goto IL_0734;
					IL_0734:
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
					IEnumerable<FieldInfo> fields = ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
					using (IEnumerator<FieldInfo> enumerator3 = fields.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							while (true)
							{
								FieldInfo current3 = enumerator3.Current;
								int num15;
								int num16;
								if (current3.IsDefined(typeof(NonSerializedAttribute), true))
								{
									num15 = -1476844787;
									num16 = num15;
								}
								else
								{
									num15 = -1476844790;
									num16 = num15;
								}
								while (true)
								{
									switch (num15 ^ -1476844792)
									{
									case 3:
										num15 = -1476844791;
										continue;
									case 4:
										name = current3.Name;
										num15 = -1476844792;
										continue;
									case 8:
										if (!current3.IsDefined(typeof(SerializeAttribute), true))
										{
											goto case 4;
										}
										goto IL_07cf;
									case 2:
										break;
									case 7:
										goto IL_0843;
									case 0:
										WriteXmlElement(P_0, name, value);
										num15 = -1476844787;
										continue;
									case 1:
										goto end_IL_0777;
									case 6:
										goto IL_08aa;
									default:
										goto end_IL_0879;
									}
									if (current3.IsDefined(typeof(DoNotSerializeAttribute), true))
									{
										goto end_IL_0879;
									}
									int num17;
									if (!current3.IsPublic)
									{
										num15 = -1476844786;
										num17 = num15;
									}
									else
									{
										num15 = -1476844785;
										num17 = num15;
									}
									continue;
									IL_08aa:
									if (!current3.IsDefined(typeof(SerializeAttribute), true))
									{
										int num18;
										if (current3.IsDefined(typeof(SerializeField), true))
										{
											num15 = -1476844785;
											num18 = num15;
										}
										else
										{
											num15 = -1476844787;
											num18 = num15;
										}
										continue;
									}
									goto IL_0843;
									IL_07cf:
									int num19;
									if (string.IsNullOrEmpty(name = (CollectionTools.GetValue(current3.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
									{
										num15 = -1476844788;
										num19 = num15;
									}
									else
									{
										num15 = -1476844792;
										num19 = num15;
									}
									continue;
									IL_0843:
									value = current3.GetValue(P_1);
									int num20;
									if (value != null)
									{
										num15 = -1476844800;
										num20 = num15;
									}
									else
									{
										num15 = -1476844787;
										num20 = num15;
									}
									continue;
									end_IL_0777:
									break;
								}
								continue;
								end_IL_0879:
								break;
							}
						}
					}
					IEnumerable<PropertyInfo> properties = ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
					IEnumerator<PropertyInfo> enumerator4 = properties.GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							while (true)
							{
								PropertyInfo current4 = enumerator4.Current;
								int num21 = -1476844789;
								while (true)
								{
									switch (num21 ^ -1476844792)
									{
									case 0:
										num21 = -1476844791;
										continue;
									case 2:
										WriteXmlElement(P_0, name2, value2);
										num21 = -1476844788;
										continue;
									case 3:
										if (!current4.CanWrite || !current4.IsDefined(typeof(SerializeAttribute), true) || current4.IsDefined(typeof(DoNotSerializeAttribute), true) || !current4.CanRead)
										{
											goto end_IL_09fc;
										}
										value2 = current4.GetValue(P_1, null);
										if (value2 == null)
										{
											goto end_IL_09fc;
										}
										if (current4.IsDefined(typeof(SerializeAttribute), true))
										{
											goto IL_09bc;
										}
										goto case 5;
									case 1:
										break;
									case 5:
										name2 = current4.Name;
										num21 = -1476844790;
										continue;
									default:
										goto end_IL_09fc;
									}
									break;
									IL_09bc:
									int num22;
									if (!string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(current4.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
									{
										num21 = -1476844790;
										num22 = num21;
									}
									else
									{
										num21 = -1476844787;
										num22 = num21;
									}
								}
								continue;
								end_IL_09fc:
								break;
							}
						}
						return;
					}
					finally
					{
						if (enumerator4 != null)
						{
							while (true)
							{
								IL_0a31:
								int num23 = -1476844790;
								while (true)
								{
									switch (num23 ^ -1476844792)
									{
									case 0:
										break;
									default:
										goto end_IL_0a36;
									case 2:
										goto IL_0a4f;
									case 1:
										goto end_IL_0a36;
									}
									goto IL_0a31;
									IL_0a4f:
									enumerator4.Dispose();
									num23 = -1476844791;
									continue;
									end_IL_0a36:
									break;
								}
								break;
							}
						}
					}
					continue;
					end_IL_02c0:
					break;
				}
			}
		}

		public static string ReadXmlElement(XmlReader reader, string name)
		{
			string result = string.Empty;
			bool isEmptyElement = reader.IsEmptyElement;
			reader.ReadStartElement(name);
			if (!isEmptyElement)
			{
				while (true)
				{
					int num = 1182985720;
					while (true)
					{
						switch (num ^ 0x4682EDF9)
						{
						case 2:
							break;
						case 1:
							result = reader.ReadContentAsString();
							num = 1182985722;
							continue;
						case 3:
							reader.ReadEndElement();
							num = 1182985721;
							continue;
						default:
							goto end_IL_0017;
						}
						break;
					}
					continue;
					end_IL_0017:
					break;
				}
			}
			return result;
		}

		public static T ReadXmlElement<T>(XmlReader reader, string name)
		{
			string text = ReadXmlElement(reader, name);
			uint result11 = default(uint);
			ushort result3 = default(ushort);
			while (true)
			{
				int num = -554960792;
				while (true)
				{
					switch (num ^ -554960800)
					{
					case 7:
						break;
					case 2:
						return (T)(object)result11;
					case 5:
					{
						ulong result2;
						if (ulong.TryParse(text, out result2))
						{
							return (T)(object)result2;
						}
						goto default;
					}
					case 8:
					{
						Type typeFromHandle = typeof(T);
						if (object.ReferenceEquals(typeFromHandle, typeof(int)))
						{
							int result4;
							if (int.TryParse(text, out result4))
							{
								return (T)(object)result4;
							}
						}
						else if (object.ReferenceEquals(typeFromHandle, typeof(float)))
						{
							float result5;
							if (float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result5))
							{
								return (T)(object)result5;
							}
						}
						else if (object.ReferenceEquals(typeFromHandle, typeof(bool)))
						{
							bool result6;
							if (bool.TryParse(text, out result6))
							{
								return (T)(object)result6;
							}
						}
						else
						{
							if (object.ReferenceEquals(typeFromHandle, typeof(string)))
							{
								return (T)(object)text;
							}
							short result10;
							if (!object.ReferenceEquals(typeFromHandle, typeof(short)))
							{
								if (object.ReferenceEquals(typeFromHandle, typeof(byte)))
								{
									num = -554960800;
									continue;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(ushort)))
								{
									num = -554960799;
									continue;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
								{
									num = -554960794;
									continue;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(long)))
								{
									long result7;
									if (long.TryParse(text, out result7))
									{
										return (T)(object)result7;
									}
								}
								else
								{
									if (object.ReferenceEquals(typeFromHandle, typeof(ulong)))
									{
										num = -554960795;
										continue;
									}
									if (object.ReferenceEquals(typeFromHandle, typeof(double)))
									{
										double result8;
										if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result8))
										{
											return (T)(object)result8;
										}
									}
									else
									{
										if (!object.ReferenceEquals(typeFromHandle, typeof(decimal)))
										{
											throw new NotImplementedException();
										}
										decimal result9;
										if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result9))
										{
											return (T)(object)result9;
										}
									}
								}
							}
							else if (short.TryParse(text, out result10))
							{
								return (T)(object)result10;
							}
						}
						goto default;
					}
					case 6:
					{
						int num3;
						if (uint.TryParse(text, out result11))
						{
							num = -554960798;
							num3 = num;
						}
						else
						{
							num = -554960797;
							num3 = num;
						}
						continue;
					}
					case 1:
					{
						int num2;
						if (!ushort.TryParse(text, out result3))
						{
							num = -554960797;
							num2 = num;
						}
						else
						{
							num = -554960796;
							num2 = num;
						}
						continue;
					}
					case 4:
						return (T)(object)result3;
					case 0:
					{
						byte result;
						if (byte.TryParse(text, out result))
						{
							return (T)(object)result;
						}
						goto default;
					}
					default:
						return default(T);
					}
					break;
				}
			}
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
					int num = -1731055531;
					while (true)
					{
						switch (num ^ -1731055530)
						{
						case 0:
							break;
						case 3:
							outValue = reader.ReadContentAsString();
							num = -1731055532;
							continue;
						case 2:
							reader.ReadEndElement();
							num = -1731055529;
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
				outValue = (T)(object)outValue2;
				goto IL_0040;
			}
			int num;
			int result2 = default(int);
			bool result4 = default(bool);
			byte result6;
			if (!object.ReferenceEquals(typeFromHandle, typeof(byte)))
			{
				if (object.ReferenceEquals(typeFromHandle, typeof(sbyte)))
				{
					num = 853755020;
					goto IL_0045;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(short)))
				{
					short result;
					if (short.TryParse(outValue2, out result))
					{
						outValue = (T)(object)result;
						num = 853755011;
						goto IL_0045;
					}
				}
				else
				{
					if (!object.ReferenceEquals(typeFromHandle, typeof(ushort)))
					{
						if (object.ReferenceEquals(typeFromHandle, typeof(int)))
						{
							int num2;
							if (!int.TryParse(outValue2, out result2))
							{
								num = 853755022;
								num2 = num;
							}
							else
							{
								num = 853755013;
								num2 = num;
							}
						}
						else
						{
							if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
							{
								uint result3;
								if (uint.TryParse(outValue2, out result3))
								{
									outValue = (T)(object)result3;
									return true;
								}
								goto IL_03f4;
							}
							if (object.ReferenceEquals(typeFromHandle, typeof(float)))
							{
								num = 853755036;
							}
							else if (!object.ReferenceEquals(typeFromHandle, typeof(double)))
							{
								if (!object.ReferenceEquals(typeFromHandle, typeof(decimal)))
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
											goto IL_03b5;
										}
										throw new NotImplementedException();
									}
									int num3;
									if (!bool.TryParse(outValue2, out result4))
									{
										num = 853755022;
										num3 = num;
									}
									else
									{
										num = 853755012;
										num3 = num;
									}
								}
								else
								{
									num = 853755008;
								}
							}
							else
							{
								num = 853755015;
							}
						}
						goto IL_0045;
					}
					ushort result5;
					if (ushort.TryParse(outValue2, out result5))
					{
						outValue = (T)(object)result5;
						return true;
					}
				}
			}
			else if (byte.TryParse(outValue2, out result6))
			{
				outValue = (T)(object)result6;
				return true;
			}
			goto IL_03f4;
			IL_0040:
			num = 853755016;
			goto IL_0045;
			IL_03b5:
			int result7 = default(int);
			int num4;
			if (int.TryParse(outValue2, out result7))
			{
				num = 853755023;
				num4 = num;
			}
			else
			{
				num = 853755022;
				num4 = num;
			}
			goto IL_0045;
			IL_0045:
			float result9 = default(float);
			sbyte result11 = default(sbyte);
			decimal result10 = default(decimal);
			while (true)
			{
				switch (num ^ 0x32E3448C)
				{
				case 13:
					break;
				case 17:
					outValue = (T)(object)result9;
					num = 853755014;
					continue;
				case 1:
					outValue = (T)(object)result11;
					return true;
				case 0:
					goto IL_0107;
				case 3:
					outValue = (T)(object)result7;
					num = 853755018;
					continue;
				case 5:
					outValue = (T)(object)result10;
					return true;
				case 4:
					return true;
				case 8:
					outValue = (T)(object)result4;
					return true;
				case 15:
					return true;
				case 9:
					outValue = (T)(object)result2;
					return true;
				case 16:
					goto IL_0302;
				case 6:
					return true;
				case 7:
					return true;
				case 12:
					goto IL_035d;
				case 11:
				{
					double result8;
					if (double.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out result8))
					{
						outValue = (T)(object)result8;
						num = 853755019;
						continue;
					}
					goto IL_03f4;
				}
				case 14:
					goto IL_03b5;
				case 10:
					return true;
				default:
					goto IL_03f4;
				}
				break;
				IL_035d:
				int num5;
				if (!decimal.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out result10))
				{
					num = 853755022;
					num5 = num;
				}
				else
				{
					num = 853755017;
					num5 = num;
				}
				continue;
				IL_0302:
				int num6;
				if (!float.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out result9))
				{
					num = 853755022;
					num6 = num;
				}
				else
				{
					num = 853755037;
					num6 = num;
				}
				continue;
				IL_0107:
				int num7;
				if (sbyte.TryParse(outValue2, out result11))
				{
					num = 853755021;
					num7 = num;
				}
				else
				{
					num = 853755022;
					num7 = num;
				}
			}
			goto IL_0040;
			IL_03f4:
			return true;
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
