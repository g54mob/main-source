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
			while (true)
			{
				int num = -599321732;
				while (true)
				{
					switch (num ^ -599321730)
					{
					case 0:
						break;
					case 2:
						goto IL_0031;
					default:
					{
						using (StringWriter stringWriter = new StringWriter())
						{
							xmlSerializer.Serialize(stringWriter, obj);
							return stringWriter.ToString();
						}
					}
					}
					break;
					IL_0031:
					string empty = string.Empty;
					num = -599321729;
				}
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
					bool flag = false;
					int num;
					if (value is IExportToXml)
					{
						int num2;
						if (!(value as IExportToXml).writesOwnElementTag)
						{
							num = -1152548724;
							num2 = num;
						}
						else
						{
							num = -1152548725;
							num2 = num;
						}
						goto IL_0016;
					}
					goto IL_008b;
					IL_0016:
					while (true)
					{
						switch (num ^ -1152548725)
						{
						case 2:
							num = -1152548722;
							continue;
						case 6:
							OxFtXpfcqwXitijahJBNPcHAppz(writer, value);
							return;
						case 4:
							break;
						case 1:
							writer.WriteStartElement(name);
							num = -1152548728;
							continue;
						case 7:
							goto IL_008b;
						case 5:
							goto end_IL_0055;
						case 0:
							flag = true;
							num = -1152548724;
							continue;
						default:
							OxFtXpfcqwXitijahJBNPcHAppz(writer, value);
							writer.WriteEndElement();
							return;
						}
						break;
					}
					continue;
					IL_008b:
					int num3;
					if (flag)
					{
						num = -1152548723;
						num3 = num;
					}
					else
					{
						num = -1152548726;
						num3 = num;
					}
					goto IL_0016;
					continue;
					end_IL_0055:
					break;
				}
			}
			throw new ArgumentNullException("name");
		}

		public static void WriteXmlElement<T>(XmlWriter writer, string name, T value)
		{
			WriteXmlElement(writer, name, (object)value);
		}

		private static void OxFtXpfcqwXitijahJBNPcHAppz(XmlWriter P_0, object P_1)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_03b0;
			IL_0006:
			int num = -2003183679;
			goto IL_000b;
			IL_000b:
			Type type = default(Type);
			Type underlyingType = default(Type);
			IList list = default(IList);
			int num5 = default(int);
			string name = default(string);
			object value = default(object);
			string name2 = default(string);
			object value2 = default(object);
			while (true)
			{
				switch (num ^ -2003183668)
				{
				case 14:
					break;
				case 27:
					goto IL_00c7;
				case 2:
					if (ReflectionTools.DoesTypeImplement(type, typeof(Enum)))
					{
						underlyingType = Enum.GetUnderlyingType(type);
						num = -2003183668;
						continue;
					}
					goto IL_04b1;
				case 35:
					WriteXmlElement(P_0, (list[num5] != null) ? list[num5].GetType().Name : "value", list[num5]);
					num = -2003183650;
					continue;
				case 13:
					throw new ArgumentNullException("writer");
				case 32:
					if (object.ReferenceEquals(type, typeof(float)))
					{
						P_0.WriteValue((float)P_1);
						num = -2003183638;
						continue;
					}
					goto IL_02d5;
				case 10:
					goto IL_018e;
				case 16:
					if (object.ReferenceEquals(type, typeof(DateTime)))
					{
						P_0.WriteValue((DateTime)P_1);
						num = -2003183663;
						continue;
					}
					goto case 39;
				case 0:
					P_0.WriteValue(Convert.ChangeType(P_1, underlyingType));
					num = -2003183644;
					continue;
				case 22:
					P_0.WriteValue((decimal)P_1);
					return;
				case 42:
					goto IL_0217;
				case 8:
					if (object.ReferenceEquals(type, typeof(int)))
					{
						P_0.WriteValue((int)P_1);
						num = -2003183662;
						continue;
					}
					goto IL_03f2;
				case 38:
					return;
				case 3:
					if (object.ReferenceEquals(type, typeof(bool)))
					{
						P_0.WriteValue((bool)P_1);
						return;
					}
					goto case 16;
				case 23:
					if (object.ReferenceEquals(type, typeof(short)))
					{
						P_0.WriteValue((short)P_1);
						return;
					}
					goto case 20;
				case 37:
					goto IL_02d5;
				case 17:
					if (num5 >= list.Count)
					{
						return;
					}
					goto case 35;
				case 20:
					if (object.ReferenceEquals(type, typeof(ushort)))
					{
						P_0.WriteValue((ushort)P_1);
						return;
					}
					goto case 8;
				case 15:
					P_0.WriteValue(((ulong)P_1).ToString());
					num = -2003183680;
					continue;
				case 31:
					if (object.ReferenceEquals(type, typeof(long)))
					{
						P_0.WriteValue((long)P_1);
						return;
					}
					goto IL_0470;
				case 4:
					goto IL_038a;
				case 11:
					goto IL_03b0;
				case 26:
					goto IL_03c1;
				case 29:
					return;
				case 34:
					goto IL_03f2;
				case 40:
					return;
				case 19:
					list = P_1 as IList;
					num5 = 0;
					num = -2003183651;
					continue;
				case 12:
					return;
				case 5:
					P_0.WriteValue((int)P_1);
					return;
				case 25:
					P_0.WriteValue((int)P_1);
					return;
				case 9:
					goto IL_0470;
				case 18:
					num5++;
					num = -2003183651;
					continue;
				case 7:
					return;
				case 41:
					goto IL_04b1;
				case 6:
					goto IL_04ce;
				case 21:
					goto IL_04ed;
				case 36:
					P_0.WriteValue((uint)P_1);
					return;
				case 39:
					if (object.ReferenceEquals(type, typeof(Guid)))
					{
						P_0.WriteValue(((Guid)P_1/*cast due to .constrained prefix*/).ToString());
						return;
					}
					goto case 2;
				case 33:
					goto IL_057f;
				case 24:
					P_0.WriteValue((double)P_1);
					num = -2003183664;
					continue;
				case 30:
					return;
				case 28:
					return;
				default:
				{
					IDictionary dictionary = P_1 as IDictionary;
					IEnumerator enumerator = dictionary.Keys.GetEnumerator();
					try
					{
						while (true)
						{
							int num2;
							int num3;
							if (enumerator.MoveNext())
							{
								num2 = -2003183667;
								num3 = num2;
							}
							else
							{
								num2 = -2003183665;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -2003183668)
								{
								case 2:
									num2 = -2003183667;
									continue;
								default:
									return;
								case 1:
								{
									object current = enumerator.Current;
									WriteXmlElement(P_0, current.ToString(), dictionary[current]);
									num2 = -2003183668;
									continue;
								}
								case 0:
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
						while (true)
						{
							IL_0661:
							int num4 = -2003183667;
							while (true)
							{
								switch (num4 ^ -2003183668)
								{
								case 2:
									break;
								default:
									goto end_IL_0666;
								case 1:
									if (disposable != null)
									{
										goto IL_0683;
									}
									goto end_IL_0666;
								case 0:
									goto end_IL_0666;
								}
								goto IL_0661;
								IL_0683:
								disposable.Dispose();
								num4 = -2003183668;
								continue;
								end_IL_0666:
								break;
							}
							break;
						}
					}
				}
				}
				break;
				IL_04ed:
				if (ReflectionTools.GetAttribute<SerializationTypeAttribute>(type, inherit: true).serializationType != SerializationTypeAttribute.SerializationType.Object)
				{
					goto IL_0506;
				}
				goto IL_0759;
				IL_04ce:
				if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
				{
					num = -2003183667;
					continue;
				}
				if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
				{
					IEnumerable enumerable = P_1 as IEnumerable;
					IEnumerator enumerator2 = enumerable.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							while (true)
							{
								object current2 = enumerator2.Current;
								int num6 = -2003183666;
								while (true)
								{
									switch (num6 ^ -2003183668)
									{
									case 0:
										num6 = -2003183667;
										continue;
									case 1:
										break;
									case 2:
										WriteXmlElement(P_0, (current2 != null) ? current2.GetType().Name : "value", current2);
										num6 = -2003183665;
										continue;
									default:
										goto end_IL_06dd;
									}
									break;
								}
								continue;
								end_IL_06dd:
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
							IL_0727:
							int num7 = -2003183666;
							while (true)
							{
								switch (num7 ^ -2003183668)
								{
								case 0:
									break;
								default:
									goto end_IL_072c;
								case 2:
									if (disposable2 != null)
									{
										goto IL_0749;
									}
									goto end_IL_072c;
								case 1:
									goto end_IL_072c;
								}
								goto IL_0727;
								IL_0749:
								disposable2.Dispose();
								num7 = -2003183667;
								continue;
								end_IL_072c:
								break;
							}
							break;
						}
					}
				}
				goto IL_0759;
				IL_0506:
				int num8;
				if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
				{
					num = -2003183649;
					num8 = num;
				}
				else
				{
					num = -2003183670;
					num8 = num;
				}
				continue;
				IL_04b1:
				if (ReflectionTools.IsDefined(type, typeof(SerializationTypeAttribute), inherit: true))
				{
					num = -2003183655;
					continue;
				}
				goto IL_0506;
				IL_0470:
				int num9;
				if (!object.ReferenceEquals(type, typeof(ulong)))
				{
					num = -2003183636;
					num9 = num;
				}
				else
				{
					num = -2003183677;
					num9 = num;
				}
				continue;
				IL_0759:
				if (P_1 is ISerializationCallbackReceiver serializationCallbackReceiver)
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
				IEnumerable<FieldInfo> fields = ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic);
				IEnumerator<FieldInfo> enumerator3 = fields.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						while (true)
						{
							FieldInfo current3 = enumerator3.Current;
							int num10 = -2003183676;
							while (true)
							{
								switch (num10 ^ -2003183668)
								{
								case 4:
									num10 = -2003183671;
									continue;
								case 2:
									WriteXmlElement(P_0, name, value);
									num10 = -2003183668;
									continue;
								case 6:
									value = current3.GetValue(P_1);
									num10 = -2003183667;
									continue;
								case 3:
									break;
								case 8:
									if (current3.IsDefined(typeof(NonSerializedAttribute), inherit: true) || current3.IsDefined(typeof(DoNotSerializeAttribute), inherit: true))
									{
										goto end_IL_08ba;
									}
									if (current3.IsPublic)
									{
										goto case 6;
									}
									goto IL_0852;
								case 7:
									goto IL_087a;
								case 5:
									goto end_IL_079c;
								case 9:
									name = current3.Name;
									num10 = -2003183666;
									continue;
								case 1:
									goto IL_08e0;
								default:
									goto end_IL_08ba;
								}
								int num11;
								if (current3.IsDefined(typeof(SerializeField), inherit: true))
								{
									num10 = -2003183670;
									num11 = num10;
								}
								else
								{
									num10 = -2003183668;
									num11 = num10;
								}
								continue;
								IL_08e0:
								if (value == null)
								{
									goto end_IL_08ba;
								}
								int num12;
								if (current3.IsDefined(typeof(SerializeAttribute), inherit: true))
								{
									num10 = -2003183669;
									num12 = num10;
								}
								else
								{
									num10 = -2003183675;
									num12 = num10;
								}
								continue;
								IL_087a:
								int num13;
								if (string.IsNullOrEmpty(name = (CollectionTools.GetValue(current3.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
								{
									num10 = -2003183675;
									num13 = num10;
								}
								else
								{
									num10 = -2003183666;
									num13 = num10;
								}
								continue;
								IL_0852:
								int num14;
								if (current3.IsDefined(typeof(SerializeAttribute), inherit: true))
								{
									num10 = -2003183670;
									num14 = num10;
								}
								else
								{
									num10 = -2003183665;
									num14 = num10;
								}
								continue;
								end_IL_079c:
								break;
							}
							continue;
							end_IL_08ba:
							break;
						}
					}
				}
				finally
				{
					if (enumerator3 != null)
					{
						while (true)
						{
							IL_091b:
							int num15 = -2003183667;
							while (true)
							{
								switch (num15 ^ -2003183668)
								{
								case 0:
									break;
								default:
									goto end_IL_0920;
								case 1:
									goto IL_0939;
								case 2:
									goto end_IL_0920;
								}
								goto IL_091b;
								IL_0939:
								enumerator3.Dispose();
								num15 = -2003183666;
								continue;
								end_IL_0920:
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
							if (!current4.CanWrite || !current4.IsDefined(typeof(SerializeAttribute), inherit: true))
							{
								break;
							}
							int num16;
							int num17;
							if (!current4.IsDefined(typeof(DoNotSerializeAttribute), inherit: true))
							{
								num16 = -2003183671;
								num17 = num16;
							}
							else
							{
								num16 = -2003183666;
								num17 = num16;
							}
							while (true)
							{
								switch (num16 ^ -2003183668)
								{
								case 0:
									num16 = -2003183665;
									continue;
								case 4:
									name2 = current4.Name;
									num16 = -2003183667;
									continue;
								case 5:
									if (!current4.CanRead)
									{
										goto end_IL_0a23;
									}
									value2 = current4.GetValue(P_1, null);
									if (value2 == null)
									{
										goto end_IL_0a23;
									}
									if (!current4.IsDefined(typeof(SerializeAttribute), inherit: true))
									{
										goto case 4;
									}
									goto IL_09cf;
								case 1:
									WriteXmlElement(P_0, name2, value2);
									num16 = -2003183666;
									continue;
								case 3:
									break;
								default:
									goto end_IL_0a23;
								}
								break;
								IL_09cf:
								int num18;
								if (!string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(current4.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
								{
									num16 = -2003183667;
									num18 = num16;
								}
								else
								{
									num16 = -2003183672;
									num18 = num16;
								}
							}
							continue;
							end_IL_0a23:
							break;
						}
					}
					return;
				}
				IL_00c7:
				int num19;
				if (object.ReferenceEquals(type, typeof(decimal)))
				{
					num = -2003183654;
					num19 = num;
				}
				else
				{
					num = -2003183665;
					num19 = num;
				}
				continue;
				IL_02d5:
				int num20;
				if (object.ReferenceEquals(type, typeof(double)))
				{
					num = -2003183660;
					num20 = num;
				}
				else
				{
					num = -2003183657;
					num20 = num;
				}
				continue;
				IL_03f2:
				int num21;
				if (!object.ReferenceEquals(type, typeof(uint)))
				{
					num = -2003183661;
					num21 = num;
				}
				else
				{
					num = -2003183640;
					num21 = num;
				}
				continue;
				IL_03c1:
				int num22;
				if (!object.ReferenceEquals(type, typeof(sbyte)))
				{
					num = -2003183653;
					num22 = num;
				}
				else
				{
					num = -2003183671;
					num22 = num;
				}
			}
			goto IL_0006;
			IL_018e:
			if (object.ReferenceEquals(type, typeof(string)))
			{
				P_0.WriteValue(CleanInvalidXmlChars((string)P_1));
				num = -2003183669;
				goto IL_000b;
			}
			goto IL_057f;
			IL_038a:
			int num23;
			if (!object.ReferenceEquals(type, typeof(byte)))
			{
				num = -2003183658;
				num23 = num;
			}
			else
			{
				num = -2003183659;
				num23 = num;
			}
			goto IL_000b;
			IL_03b0:
			if (P_1 == null)
			{
				return;
			}
			goto IL_0217;
			IL_057f:
			if (object.ReferenceEquals(type, typeof(char)))
			{
				P_0.WriteValue(CleanInvalidXmlChars(P_1.ToString()));
				return;
			}
			goto IL_038a;
			IL_0217:
			type = P_1.GetType();
			if (ReflectionTools.DoesTypeImplement(type, typeof(IExportToXml)))
			{
				((IExportToXml)P_1).WriteXml(P_0);
				return;
			}
			goto IL_018e;
		}

		public static string ReadXmlElement(XmlReader reader, string name)
		{
			string result = string.Empty;
			bool isEmptyElement = reader.IsEmptyElement;
			while (true)
			{
				int num = -1235670629;
				while (true)
				{
					switch (num ^ -1235670630)
					{
					case 3:
						break;
					case 1:
						reader.ReadStartElement(name);
						num = -1235670630;
						continue;
					case 0:
					{
						int num2;
						if (!isEmptyElement)
						{
							num = -1235670626;
							num2 = num;
						}
						else
						{
							num = -1235670632;
							num2 = num;
						}
						continue;
					}
					case 4:
						result = reader.ReadContentAsString();
						reader.ReadEndElement();
						num = -1235670632;
						continue;
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
			short result4 = default(short);
			uint result6 = default(uint);
			float result5 = default(float);
			byte result2 = default(byte);
			decimal result9 = default(decimal);
			T result = default(T);
			while (true)
			{
				int num = -2097819871;
				while (true)
				{
					switch (num ^ -2097819868)
					{
					case 0:
						break;
					case 7:
						return (T)(object)result4;
					case 10:
					{
						if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result7))
						{
							return (T)(object)result7;
						}
						goto case 6;
					}
					case 4:
						return (T)(object)result6;
					case 5:
						if (object.ReferenceEquals(typeFromHandle, typeof(int)))
						{
							if (int.TryParse(text, out var result10))
							{
								return (T)(object)result10;
							}
						}
						else
						{
							if (object.ReferenceEquals(typeFromHandle, typeof(float)))
							{
								int num3;
								if (float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result5))
								{
									num = -2097819864;
									num3 = num;
								}
								else
								{
									num = -2097819870;
									num3 = num;
								}
								continue;
							}
							bool result12;
							if (!object.ReferenceEquals(typeFromHandle, typeof(bool)))
							{
								if (object.ReferenceEquals(typeFromHandle, typeof(string)))
								{
									return (T)(object)text;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(short)))
								{
									int num4;
									if (short.TryParse(text, out result4))
									{
										num = -2097819869;
										num4 = num;
									}
									else
									{
										num = -2097819870;
										num4 = num;
									}
									continue;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(byte)))
								{
									int num5;
									if (byte.TryParse(text, out result2))
									{
										num = -2097819866;
										num5 = num;
									}
									else
									{
										num = -2097819870;
										num5 = num;
									}
									continue;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(ushort)))
								{
									num = -2097819857;
									continue;
								}
								if (object.ReferenceEquals(typeFromHandle, typeof(uint)))
								{
									num = -2097819867;
									continue;
								}
								if (!object.ReferenceEquals(typeFromHandle, typeof(long)))
								{
									if (object.ReferenceEquals(typeFromHandle, typeof(ulong)))
									{
										num = -2097819859;
									}
									else if (!object.ReferenceEquals(typeFromHandle, typeof(double)))
									{
										if (!object.ReferenceEquals(typeFromHandle, typeof(decimal)))
										{
											throw new NotImplementedException();
										}
										int num6;
										if (!decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out result9))
										{
											num = -2097819870;
											num6 = num;
										}
										else
										{
											num = -2097819860;
											num6 = num;
										}
									}
									else
									{
										num = -2097819858;
									}
									continue;
								}
								if (long.TryParse(text, out var result11))
								{
									return (T)(object)result11;
								}
							}
							else if (bool.TryParse(text, out result12))
							{
								return (T)(object)result12;
							}
						}
						goto case 6;
					case 8:
						return (T)(object)result9;
					case 11:
					{
						if (ushort.TryParse(text, out var result8))
						{
							return (T)(object)result8;
						}
						goto case 6;
					}
					case 1:
					{
						int num2;
						if (!uint.TryParse(text, out result6))
						{
							num = -2097819870;
							num2 = num;
						}
						else
						{
							num = -2097819872;
							num2 = num;
						}
						continue;
					}
					case 12:
						return (T)(object)result5;
					case 9:
					{
						if (ulong.TryParse(text, out var result3))
						{
							return (T)(object)result3;
						}
						goto case 6;
					}
					case 6:
						result = default(T);
						num = -2097819865;
						continue;
					case 2:
						return (T)(object)result2;
					default:
						return result;
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
				bool result = default(bool);
				while (true)
				{
					int num = -783479313;
					while (true)
					{
						switch (num ^ -783479315)
						{
						case 0:
							break;
						case 2:
							goto IL_0036;
						default:
							return result;
						}
						break;
						IL_0036:
						result = false;
						num = -783479316;
					}
				}
			}
			if (!isEmptyElement)
			{
				outValue = reader.ReadContentAsString();
				reader.ReadEndElement();
			}
			return true;
		}

		public static bool TryReadXmlElement<T>(XmlReader reader, string name, out T outValue)
		{
			outValue = default(T);
			string outValue2 = default(string);
			byte result10 = default(byte);
			bool result5 = default(bool);
			int result11 = default(int);
			double result4 = default(double);
			while (true)
			{
				int num = 2143057413;
				while (true)
				{
					switch (num ^ 0x7FBC760F)
					{
					case 6:
						break;
					case 1:
					{
						int num4;
						if (byte.TryParse(outValue2, out result10))
						{
							num = 2143057414;
							num4 = num;
						}
						else
						{
							num = 2143057415;
							num4 = num;
						}
						continue;
					}
					case 5:
						return true;
					case 0:
						outValue = (T)(object)result5;
						return true;
					case 4:
					{
						if (int.TryParse(outValue2, out var result9))
						{
							outValue = (T)(object)result9;
							return true;
						}
						goto default;
					}
					case 2:
						return true;
					case 9:
						outValue = (T)(object)result10;
						return true;
					case 3:
					{
						int num5;
						if (int.TryParse(outValue2, out result11))
						{
							num = 2143057416;
							num5 = num;
						}
						else
						{
							num = 2143057415;
							num5 = num;
						}
						continue;
					}
					case 12:
						outValue = (T)(object)result4;
						return true;
					case 7:
						outValue = (T)(object)result11;
						return true;
					case 11:
						return true;
					case 10:
					{
						Type typeFromHandle = typeof(T);
						if (!TryReadXmlElement(reader, name, out outValue2))
						{
							return false;
						}
						if (!object.ReferenceEquals(typeFromHandle, typeof(string)))
						{
							if (object.ReferenceEquals(typeFromHandle, typeof(byte)))
							{
								num = 2143057422;
								continue;
							}
							ushort result8;
							if (object.ReferenceEquals(typeFromHandle, typeof(sbyte)))
							{
								if (sbyte.TryParse(outValue2, out var result))
								{
									outValue = (T)(object)result;
									return true;
								}
							}
							else if (object.ReferenceEquals(typeFromHandle, typeof(short)))
							{
								if (short.TryParse(outValue2, out var result2))
								{
									outValue = (T)(object)result2;
									return true;
								}
							}
							else if (!object.ReferenceEquals(typeFromHandle, typeof(ushort)))
							{
								if (object.ReferenceEquals(typeFromHandle, typeof(int)))
								{
									num = 2143057419;
									continue;
								}
								uint result7;
								if (!object.ReferenceEquals(typeFromHandle, typeof(uint)))
								{
									if (object.ReferenceEquals(typeFromHandle, typeof(float)))
									{
										if (float.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out var result3))
										{
											outValue = (T)(object)result3;
											num = 2143057412;
											continue;
										}
									}
									else
									{
										if (object.ReferenceEquals(typeFromHandle, typeof(double)))
										{
											int num2;
											if (!double.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out result4))
											{
												num = 2143057415;
												num2 = num;
											}
											else
											{
												num = 2143057411;
												num2 = num;
											}
											continue;
										}
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
													goto case 3;
												}
												throw new NotImplementedException();
											}
											int num3;
											if (!bool.TryParse(outValue2, out result5))
											{
												num = 2143057415;
												num3 = num;
											}
											else
											{
												num = 2143057423;
												num3 = num;
											}
											continue;
										}
										if (decimal.TryParse(outValue2, NumberStyles.Any, CultureInfo.InvariantCulture, out var result6))
										{
											outValue = (T)(object)result6;
											return true;
										}
									}
								}
								else if (uint.TryParse(outValue2, out result7))
								{
									outValue = (T)(object)result7;
									num = 2143057418;
									continue;
								}
							}
							else if (ushort.TryParse(outValue2, out result8))
							{
								outValue = (T)(object)result8;
								return true;
							}
							goto default;
						}
						outValue = (T)(object)outValue2;
						num = 2143057421;
						continue;
					}
					default:
						return true;
					}
					break;
				}
			}
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
				bool result = default(bool);
				while (true)
				{
					int num = -1124607125;
					while (true)
					{
						switch (num ^ -1124607126)
						{
						case 2:
							break;
						case 1:
							goto IL_0030;
						default:
							return result;
						}
						break;
						IL_0030:
						result = false;
						num = -1124607126;
					}
				}
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
