using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SerializedObject : IEnumerable, IEnumerable<SerializedObject.Field>, IAddValue<object>, IAddKeyValue<string, object>, IExportToXml, IExportToJson
	{
		[CustomObfuscation(rename = false)]
		public enum ObjectType
		{
			[CustomObfuscation(rename = false)]
			Object = 0,
			[CustomObfuscation(rename = false)]
			List = 1
		}

		[Flags]
		[CustomObfuscation(rename = false)]
		public enum FieldOptions
		{
			[CustomObfuscation(rename = false)]
			None = 0,
			[CustomObfuscation(rename = false)]
			ExculdeFromXml = 1
		}

		private struct Entry
		{
			public Type type;

			public object value;

			public FieldOptions options;

			public Entry(Type type, object value, FieldOptions options)
			{
				this.type = type;
				this.value = value;
				this.options = options;
			}

			public override string ToString()
			{
				string text = "";
				text = text + "type = " + (((object)type != null) ? type.Name : "NULL") + "\n";
				object obj = default(object);
				object[] array = default(object[]);
				while (true)
				{
					int num = 2009895923;
					while (true)
					{
						switch (num ^ 0x77CC93F1)
						{
						case 5:
							break;
						case 2:
							text = text + "value = " + ((value != null) ? value.ToString() : "NULL") + "\n";
							num = 2009895920;
							continue;
						case 1:
							obj = text;
							num = 2009895921;
							continue;
						case 4:
							array[1] = "options = ";
							array[2] = options;
							array[3] = "\n";
							text = string.Concat(array);
							num = 2009895922;
							continue;
						case 0:
							array = new object[4] { obj, null, null, null };
							num = 2009895925;
							continue;
						default:
							return text;
						}
						break;
					}
				}
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Field
		{
			public string name;

			public object value;

			public Type type;

			public FieldOptions options;

			public Field(string name, object value, Type type, FieldOptions options)
			{
				this.name = name;
				this.value = value;
				this.type = type;
				this.options = options;
			}

			public override string ToString()
			{
				string text = "name = " + ((name != null) ? name : "NULL") + "\n";
				text = text + "value = " + ((value != null) ? value.ToString() : "NULL") + "\n";
				object[] array = default(object[]);
				while (true)
				{
					int num = -1385747719;
					while (true)
					{
						switch (num ^ -1385747720)
						{
						case 2:
							break;
						case 1:
							text = text + "type = " + (((object)type != null) ? type.Name : "NULL") + "\n";
							num = -1385747717;
							continue;
						case 3:
						{
							object obj = text;
							array = new object[4] { obj, "options = ", options, "\n" };
							num = -1385747720;
							continue;
						}
						default:
							return string.Concat(array);
						}
						break;
					}
				}
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public class XmlInfo
		{
			public abstract class XmlAttribute
			{
			}

			public class XmlStringAttribute : XmlAttribute
			{
				public string prefix;

				public string localName;

				public string ns;

				public string value;

				public override string ToString()
				{
					string text = "";
					text = text + "prefix = " + prefix + "\n";
					text = text + "localName = " + localName + "\n";
					text = text + "ns = " + ns + "\n";
					return text + "value = " + value + "\n";
				}
			}

			private List<XmlAttribute> IbXoDeqKqAgDsEetDnFnxsfWSAQe;

			public List<XmlAttribute> attributes => IbXoDeqKqAgDsEetDnFnxsfWSAQe ?? (IbXoDeqKqAgDsEetDnFnxsfWSAQe = new List<XmlAttribute>());

			public override string ToString()
			{
				string text = "Attributes:\n";
				if (IbXoDeqKqAgDsEetDnFnxsfWSAQe != null)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < IbXoDeqKqAgDsEetDnFnxsfWSAQe.Count)
						{
							num2 = 1112935619;
							num3 = num2;
						}
						else
						{
							num2 = 1112935616;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x42560CC1)
							{
							case 0:
								num2 = 1112935619;
								continue;
							case 2:
								text = text + IbXoDeqKqAgDsEetDnFnxsfWSAQe[num].ToString() + "\n";
								num++;
								num2 = 1112935618;
								continue;
							case 3:
								break;
							default:
								goto end_IL_005c;
							}
							break;
						}
						continue;
						end_IL_005c:
						break;
					}
				}
				return text;
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IEnumerator<Field>
		{
			private IndexedDictionary<string, Entry> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

			private Field fSpdVoeWhOYoAilpUehbSxUxANDS;

			private IEnumerator<KeyValuePair<string, Entry>> QwJHWapfnXXOEMUfNbKjrAGwDmD;

			public Field Current => fSpdVoeWhOYoAilpUehbSxUxANDS;

			object IEnumerator.Current => fSpdVoeWhOYoAilpUehbSxUxANDS;

			internal Enumerator(object dictionary)
			{
				ZXmCvDfLDDrtmgBgFDRMaBCKoyr = (IndexedDictionary<string, Entry>)dictionary;
				fSpdVoeWhOYoAilpUehbSxUxANDS = default(Field);
				QwJHWapfnXXOEMUfNbKjrAGwDmD = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.GetEnumerator();
			}

			public bool MoveNext()
			{
				if (!QwJHWapfnXXOEMUfNbKjrAGwDmD.MoveNext())
				{
					return false;
				}
				KeyValuePair<string, Entry> current = QwJHWapfnXXOEMUfNbKjrAGwDmD.Current;
				while (true)
				{
					int num = -73067032;
					while (true)
					{
						switch (num ^ -73067030)
						{
						case 0:
							break;
						case 2:
							goto IL_0039;
						default:
							return true;
						}
						break;
						IL_0039:
						fSpdVoeWhOYoAilpUehbSxUxANDS = new Field(current.Key, current.Value.value, current.Value.type, current.Value.options);
						num = -73067029;
					}
				}
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				fSpdVoeWhOYoAilpUehbSxUxANDS = default(Field);
				QwJHWapfnXXOEMUfNbKjrAGwDmD = ZXmCvDfLDDrtmgBgFDRMaBCKoyr.GetEnumerator();
			}
		}

		private class XmlDocument
		{
			public class Element
			{
				public readonly string name;

				public readonly Element parent;

				public string content;

				public Dictionary<string, string> attributes;

				public List<Element> children;

				public int childCount
				{
					get
					{
						if (children == null)
						{
							return 0;
						}
						return children.Count;
					}
				}

				public int attributeCount
				{
					get
					{
						if (attributes == null)
						{
							return 0;
						}
						return attributes.Count;
					}
				}

				public Element(string name, Element parent)
				{
					this.name = name;
					this.parent = parent;
					parent?.AddChild(this);
				}

				public void AddChild(Element element)
				{
					if (element == null)
					{
						goto IL_0003;
					}
					goto IL_002d;
					IL_0003:
					int num = 158655517;
					goto IL_0008;
					IL_0008:
					switch (num ^ 0x974E41C)
					{
					case 0:
						break;
					case 1:
						return;
					case 2:
						goto IL_002d;
					default:
						goto IL_0047;
					}
					goto IL_0003;
					IL_002d:
					if (children == null)
					{
						children = new List<Element>();
						num = 158655519;
						goto IL_0008;
					}
					goto IL_0047;
					IL_0047:
					children.Add(element);
				}

				public void AddAttribute(string key, string value)
				{
					if (string.IsNullOrEmpty(key))
					{
						goto IL_0008;
					}
					goto IL_0071;
					IL_0008:
					int num = 2146099968;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0x7FEAE304)
					{
					case 2:
						break;
					default:
						return;
					case 4:
						return;
					case 1:
						goto IL_003a;
					case 3:
						goto IL_005d;
					case 0:
						goto IL_0071;
					case 5:
						return;
					}
					goto IL_0008;
					IL_0071:
					if (attributes == null)
					{
						attributes = new Dictionary<string, string>();
						num = 2146099973;
						goto IL_000d;
					}
					goto IL_003a;
					IL_005d:
					attributes.Add(key, value);
					num = 2146099969;
					goto IL_000d;
					IL_003a:
					if (attributes.ContainsKey(key))
					{
						attributes[key] = value;
						return;
					}
					goto IL_005d;
				}

				public bool ContainsChild(string name)
				{
					return FindChild(name) != null;
				}

				public Element FindChild(string name)
				{
					if (childCount == 0)
					{
						return null;
					}
					int num = 0;
					while (num < children.Count)
					{
						while (true)
						{
							if (string.Equals(children[num].name, name, StringComparison.Ordinal))
							{
								return children[num];
							}
							num++;
							int num2 = -802357818;
							while (true)
							{
								switch (num2 ^ -802357818)
								{
								case 2:
									num2 = -802357817;
									continue;
								case 1:
									break;
								default:
									goto end_IL_002c;
								}
								break;
							}
							continue;
							end_IL_002c:
							break;
						}
					}
					return null;
				}

				public object GetSerializedObject()
				{
					if (childCount == 0)
					{
						return content;
					}
					SerializedObject serializedObject = new SerializedObject(null, ObjectType.List);
					int num = 0;
					Element element = default(Element);
					while (true)
					{
						int num2;
						int num3;
						if (num >= childCount)
						{
							num2 = -703741808;
							num3 = num2;
						}
						else
						{
							num2 = -703741801;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ -703741804)
							{
							case 0:
								num2 = -703741801;
								continue;
							case 3:
							{
								element = children[num];
								int num4;
								if (element != null)
								{
									num2 = -703741807;
									num4 = num2;
								}
								else
								{
									num2 = -703741802;
									num4 = num2;
								}
								continue;
							}
							case 2:
								num++;
								num2 = -703741803;
								continue;
							case 1:
								break;
							case 5:
								serializedObject.Add(element.name, element.GetSerializedObject());
								num2 = -703741802;
								continue;
							default:
								return serializedObject;
							}
							break;
						}
					}
				}

				public override string ToString()
				{
					return ToString("", 0);
				}

				private string ToString(string s, int indent)
				{
					string text = "";
					int num = 0;
					string text2 = default(string);
					object[] array4 = default(object[]);
					string[] array2 = default(string[]);
					string text4 = default(string);
					string[] array3 = default(string[]);
					string[] array = default(string[]);
					KeyValuePair<string, string> current = default(KeyValuePair<string, string>);
					object[] array5 = default(object[]);
					while (true)
					{
						int num2;
						if (num >= indent)
						{
							text2 = s;
							num2 = 1517855773;
							goto IL_0012;
						}
						goto IL_014d;
						IL_0012:
						while (true)
						{
							object obj;
							switch (num2 ^ 0x5A78A41D)
							{
							case 5:
								num2 = 1517855765;
								continue;
							case 9:
							{
								object obj2 = s;
								array4 = new object[5] { obj2, text, null, null, null };
								num2 = 1517855770;
								continue;
							}
							case 2:
								array4[4] = "\n";
								s = string.Concat(array4);
								if (attributes != null)
								{
									num2 = 1517855766;
									continue;
								}
								goto IL_0283;
							case 0:
								array2 = new string[5] { text2, text, "Name = ", name, null };
								num2 = 1517855771;
								continue;
							case 1:
								break;
							case 3:
								text4 = s;
								array3 = new string[5];
								num2 = 1517855769;
								continue;
							case 4:
								array3[0] = text4;
								array3[1] = text;
								array3[2] = "Content = ";
								array3[3] = ((content == null) ? "NULL" : content.ToString());
								num2 = 1517855767;
								continue;
							case 7:
								array4[2] = "Attribute Count = ";
								array4[3] = attributeCount;
								num2 = 1517855775;
								continue;
							case 8:
								goto IL_014d;
							case 10:
								array3[4] = "\n";
								s = string.Concat(array3);
								num2 = 1517855764;
								continue;
							case 6:
								array2[4] = "\n";
								s = string.Concat(array2);
								num2 = 1517855774;
								continue;
							default:
								{
									using (Dictionary<string, string>.Enumerator enumerator = attributes.GetEnumerator())
									{
										while (true)
										{
											IL_0213:
											int num3;
											int num4;
											if (!enumerator.MoveNext())
											{
												num3 = 1517855772;
												num4 = num3;
											}
											else
											{
												num3 = 1517855768;
												num4 = num3;
											}
											while (true)
											{
												switch (num3 ^ 0x5A78A41D)
												{
												case 0:
													num3 = 1517855768;
													continue;
												default:
													goto end_IL_01b3;
												case 2:
													array[5] = current.Value;
													array[6] = "\n";
													s = string.Concat(array);
													num3 = 1517855771;
													continue;
												case 3:
													array[4] = ": = ";
													num3 = 1517855775;
													continue;
												case 6:
													break;
												case 5:
												{
													current = enumerator.Current;
													string text3 = s;
													array = new string[7] { text3, text, "Attribute ", null, null, null, null };
													num3 = 1517855769;
													continue;
												}
												case 4:
													array[3] = current.Key;
													num3 = 1517855774;
													continue;
												case 1:
													goto end_IL_01b3;
												}
												goto IL_0213;
												continue;
												end_IL_01b3:
												break;
											}
											break;
										}
									}
									goto IL_0283;
								}
								IL_0283:
								obj = s;
								while (true)
								{
									int num5 = 1517855772;
									while (true)
									{
										switch (num5 ^ 0x5A78A41D)
										{
										case 0:
											break;
										case 1:
											array5 = new object[5] { obj, null, null, null, null };
											num5 = 1517855774;
											continue;
										case 3:
											array5[1] = text;
											array5[2] = "Child Count = ";
											num5 = 1517855775;
											continue;
										default:
											array5[3] = childCount;
											array5[4] = "\n";
											s = string.Concat(array5);
											if (children != null)
											{
												string text5 = "";
												using (List<Element>.Enumerator enumerator2 = children.GetEnumerator())
												{
													while (enumerator2.MoveNext())
													{
														while (true)
														{
															Element current2 = enumerator2.Current;
															int num6 = 1517855774;
															while (true)
															{
																switch (num6 ^ 0x5A78A41D)
																{
																case 0:
																	num6 = 1517855775;
																	continue;
																case 2:
																	break;
																case 4:
																	text5 = current2.ToString(text5, indent + 1);
																	num6 = 1517855772;
																	continue;
																case 3:
																	text5 += "\n";
																	num6 = 1517855769;
																	continue;
																default:
																	goto end_IL_0339;
																}
																break;
															}
															continue;
															end_IL_0339:
															break;
														}
													}
												}
												s += text5;
											}
											return s;
										}
										break;
									}
								}
							}
							break;
						}
						continue;
						IL_014d:
						text += "    ";
						num++;
						num2 = 1517855772;
						goto IL_0012;
					}
				}
			}

			private readonly Element _root;

			public Element root => _root;

			public bool isValid => _root != null;

			public XmlDocument(string xml)
			{
				if (string.IsNullOrEmpty(xml))
				{
					throw new ArgumentNullException("xml");
				}
				try
				{
					using (StringReader input = new StringReader(xml))
					{
						XmlReader xmlReader = XmlReader.Create(input);
						if (xmlReader == null)
						{
							throw new ArgumentNullException("reader");
						}
						_root = new Element("Root", null);
						ReadAll(xmlReader);
					}
				}
				catch
				{
					_root = null;
				}
			}

			private void ReadAll(XmlReader reader)
			{
				Element element = _root;
				bool flag = default(bool);
				int num6 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num = 664701718;
					while (true)
					{
						switch (num ^ 0x279E8B12)
						{
						case 10:
							break;
						case 0:
							if (!flag)
							{
								int num7;
								if (reader.NodeType != XmlNodeType.EndElement)
								{
									num = 664701722;
									num7 = num;
								}
								else
								{
									num = 664701698;
									num7 = num;
								}
								continue;
							}
							goto case 16;
						case 1:
							flag = false;
							if (reader.NodeType == XmlNodeType.Element)
							{
								int num3;
								if (!reader.IsStartElement())
								{
									num = 664701714;
									num3 = num;
								}
								else
								{
									num = 664701723;
									num3 = num;
								}
								continue;
							}
							goto case 17;
						case 2:
							if (num6 >= reader.AttributeCount)
							{
								if (reader.IsEmptyElement)
								{
									flag = true;
									num = 664701714;
									continue;
								}
								goto case 0;
							}
							goto case 7;
						case 8:
							num4++;
							num = 664701724;
							continue;
						case 9:
							_ = reader.IsEmptyElement;
							element = new Element(reader.LocalName, element);
							num6 = 0;
							num = 664701712;
							continue;
						case 13:
							_ = reader.NodeType;
							_ = 15;
							num = 664701714;
							continue;
						case 4:
							num4 = 0;
							num = 664701724;
							continue;
						case 6:
						{
							int num5;
							switch (reader.NodeType)
							{
							default:
								num = 664701715;
								num5 = num;
								continue;
							case XmlNodeType.XmlDeclaration:
								num = 664701713;
								num5 = num;
								continue;
							case XmlNodeType.Comment:
								break;
							}
							goto case 3;
						}
						case 16:
							if (element != null && element != _root && reader.Name == element.name)
							{
								element = element.parent;
								num = 664701722;
								continue;
							}
							goto case 8;
						case 11:
							num = 664701714;
							continue;
						case 15:
							flag = true;
							num = 664701714;
							continue;
						case 3:
							num4++;
							num = 664701724;
							continue;
						case 7:
							reader.MoveToNextAttribute();
							element.AddAttribute(reader.Name, reader.Value);
							num6++;
							num = 664701712;
							continue;
						case 12:
							element.content = reader.ReadContentAsString();
							num = 664701721;
							continue;
						case 17:
						{
							int num8;
							if (reader.NodeType != XmlNodeType.Text)
							{
								num = 664701727;
								num8 = num;
							}
							else
							{
								num = 664701719;
								num8 = num;
							}
							continue;
						}
						case 5:
							if (!reader.IsEmptyElement)
							{
								int num2;
								if (reader.HasValue)
								{
									num = 664701726;
									num2 = num;
								}
								else
								{
									num = 664701725;
									num2 = num;
								}
								continue;
							}
							goto case 15;
						default:
							if (!reader.Read())
							{
								return;
							}
							goto case 6;
						}
						break;
					}
				}
			}

			public override string ToString()
			{
				if (_root == null || _root.childCount == 0)
				{
					return "Document is empty.";
				}
				return _root.ToString();
			}
		}

		private readonly IndexedDictionary<string, Entry> ejjIumfYByuzEoXWaUogFHERZVH;

		private XmlInfo uATAKekNULJnPDOlfNNCOVgfslDN;

		private Type mlHEPMoLvhyxVvGHhIjSYBQKMrF;

		private ObjectType tuDnWvAbjhELceCHmvtwYnnZJUX;

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

		private bool allowDuplicateKeys => tuDnWvAbjhELceCHmvtwYnnZJUX == ObjectType.List;

		public ObjectType objectType
		{
			get
			{
				return tuDnWvAbjhELceCHmvtwYnnZJUX;
			}
			set
			{
				if (value == tuDnWvAbjhELceCHmvtwYnnZJUX)
				{
					return;
				}
				while (true)
				{
					tuDnWvAbjhELceCHmvtwYnnZJUX = value;
					ejjIumfYByuzEoXWaUogFHERZVH.AllowDuplicateKeys = allowDuplicateKeys;
					int num = 1053909688;
					while (true)
					{
						switch (num ^ 0x3ED162B8)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 1053909689;
					}
				}
			}
		}

		public Type type => mlHEPMoLvhyxVvGHhIjSYBQKMrF;

		public XmlInfo xmlInfo
		{
			get
			{
				return uATAKekNULJnPDOlfNNCOVgfslDN;
			}
			set
			{
				uATAKekNULJnPDOlfNNCOVgfslDN = value;
			}
		}

		public int count => ejjIumfYByuzEoXWaUogFHERZVH.Count;

		public Field this[int index]
		{
			get
			{
				Entry entry = ejjIumfYByuzEoXWaUogFHERZVH[index];
				string keyAt = ejjIumfYByuzEoXWaUogFHERZVH.GetKeyAt(index);
				return new Field(keyAt, entry.value, entry.type, entry.options);
			}
		}

		bool IExportToXml.writesOwnElementTag => true;

		[CustomObfuscation(rename = false)]
		private SerializedObject()
			: this(0)
		{
		}

		private SerializedObject(int capacity)
		{
			tuDnWvAbjhELceCHmvtwYnnZJUX = ObjectType.List;
			ejjIumfYByuzEoXWaUogFHERZVH = new IndexedDictionary<string, Entry>(capacity, allowDuplicateKeys: true);
		}

		public SerializedObject(Type type, ObjectType objectType)
			: this(type, objectType, 0)
		{
		}

		public SerializedObject(Type type, ObjectType objectType, int capacity)
			: this(capacity)
		{
			mlHEPMoLvhyxVvGHhIjSYBQKMrF = type;
			this.objectType = objectType;
		}

		public SerializedObject(Type type, IDictionary<string, object> dictionary, ObjectType objectType)
			: this(type, objectType, dictionary?.Count ?? 0)
		{
			if ((object)type == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				ejjIumfYByuzEoXWaUogFHERZVH.Add(item.Key, new Entry((item.Value != null) ? item.Value.GetType() : null, item.Value, FieldOptions.None));
			}
		}

		public void Add<T>(string fieldName, T value, FieldOptions options = FieldOptions.None)
		{
			Add(typeof(T), fieldName, value, options);
		}

		public void Add(Type type, string fieldName, object value, FieldOptions options = FieldOptions.None)
		{
			if ((object)type != null)
			{
				goto IL_0003;
			}
			goto IL_0063;
			IL_0003:
			int num = 1528015465;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x5B13AA61)
				{
				case 6:
					break;
				case 3:
					fieldName = "value";
					num = 1528015457;
					continue;
				case 0:
					goto IL_004a;
				case 4:
					goto IL_0063;
				case 8:
					if (value != null && !object.ReferenceEquals(type, value.GetType()))
					{
						throw new Exception("Type does not match value type.");
					}
					goto IL_0063;
				case 7:
					ejjIumfYByuzEoXWaUogFHERZVH.Add(fieldName, new Entry(type, value, options));
					return;
				case 2:
					throw new ArgumentNullException("fieldName");
				case 5:
					if (!ejjIumfYByuzEoXWaUogFHERZVH.ContainsKey(fieldName))
					{
						ejjIumfYByuzEoXWaUogFHERZVH.Add(fieldName, new Entry(type, value, options));
						return;
					}
					goto default;
				default:
					ejjIumfYByuzEoXWaUogFHERZVH.SetValue(fieldName, new Entry(type, value, options));
					return;
				}
				break;
			}
			goto IL_0003;
			IL_004a:
			int num2;
			if (allowDuplicateKeys)
			{
				num = 1528015462;
				num2 = num;
			}
			else
			{
				num = 1528015460;
				num2 = num;
			}
			goto IL_0008;
			IL_0063:
			if (string.IsNullOrEmpty(fieldName))
			{
				int num3;
				if (tuDnWvAbjhELceCHmvtwYnnZJUX != ObjectType.List)
				{
					num = 1528015459;
					num3 = num;
				}
				else
				{
					num = 1528015458;
					num3 = num;
				}
				goto IL_0008;
			}
			goto IL_004a;
		}

		public void Add(string fieldName, object value)
		{
			Add(value?.GetType(), fieldName, value);
		}

		public bool Remove(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return ejjIumfYByuzEoXWaUogFHERZVH.Remove(fieldName);
		}

		public bool Contains(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return ejjIumfYByuzEoXWaUogFHERZVH.ContainsKey(fieldName);
		}

		public Type GetDataType(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			if (!ejjIumfYByuzEoXWaUogFHERZVH.TryGetValue(fieldName, out var value))
			{
				return null;
			}
			return value.type;
		}

		public bool TryGetOriginalValue(string fieldName, out object value)
		{
			value = null;
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			if (!ejjIumfYByuzEoXWaUogFHERZVH.TryGetValue(fieldName, out var value2))
			{
				return false;
			}
			value = value2.value;
			return true;
		}

		public Field GetEntry(string fieldName)
		{
			KeyValuePair<string, Entry> entry = ejjIumfYByuzEoXWaUogFHERZVH.GetEntry(fieldName);
			return new Field(entry.Key, entry.Value.value, entry.Value.type, entry.Value.options);
		}

		public object GetOriginalValue(string fieldName)
		{
			return ejjIumfYByuzEoXWaUogFHERZVH.GetEntry(fieldName).Value.value;
		}

		public object GetOriginalValue(int index)
		{
			return ejjIumfYByuzEoXWaUogFHERZVH[index].value;
		}

		public T GetOriginalValue<T>(string fieldName)
		{
			return (T)GetOriginalValue(fieldName);
		}

		public T GetOriginalValue<T>(int index)
		{
			return (T)GetOriginalValue(index);
		}

		public bool TryGetDeserializedValue<T>(string fieldName, out T value)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				value = default(T);
				return false;
			}
			if (!ejjIumfYByuzEoXWaUogFHERZVH.TryGetValue(fieldName, out var value2))
			{
				value = default(T);
				return false;
			}
			return TryConvertOrCreateObject<T>(value2.value, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			if ((uint)index > (uint)ejjIumfYByuzEoXWaUogFHERZVH.Count)
			{
				goto IL_000e;
			}
			KeyValuePair<string, Entry> entryAt = ejjIumfYByuzEoXWaUogFHERZVH.GetEntryAt(index);
			int num = -2131206277;
			goto IL_0013;
			IL_0013:
			switch (num ^ -2131206278)
			{
			case 0:
				break;
			case 2:
				value = default(T);
				return false;
			default:
				return TryConvertOrCreateObject<T>(entryAt.Value.value, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
			}
			goto IL_000e;
			IL_000e:
			num = -2131206280;
			goto IL_0013;
		}

		public bool TryGetDeserializedValueByRef<T>(string fieldName, ref T value)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			if (!TryGetDeserializedValue<T>(fieldName, out var value2))
			{
				return false;
			}
			value = value2;
			return true;
		}

		public bool TryGetDeserializedValueByRef<T>(int index, ref T value)
		{
			if ((uint)index > (uint)ejjIumfYByuzEoXWaUogFHERZVH.Count)
			{
				return false;
			}
			if (!TryGetDeserializedValue<T>(index, out var value2))
			{
				return false;
			}
			value = value2;
			return true;
		}

		public string ToXmlString(bool writeDocumentTag)
		{
			if (uATAKekNULJnPDOlfNNCOVgfslDN == null)
			{
				throw new Exception("XmlInfo is null. Cannot write Xml without XmlInfo.");
			}
			string empty = string.Empty;
			StringWriter stringWriter = new StringWriter();
			try
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
				{
					if (writeDocumentTag)
					{
						xmlWriter.WriteStartDocument();
						goto IL_002f;
					}
					goto IL_0051;
					IL_0051:
					WriteXml(xmlWriter);
					int num = -1759860045;
					goto IL_0034;
					IL_002f:
					num = -1759860046;
					goto IL_0034;
					IL_0034:
					while (true)
					{
						switch (num ^ -1759860045)
						{
						case 3:
							break;
						default:
							goto end_IL_0026;
						case 1:
							goto IL_0051;
						case 0:
							xmlWriter.Flush();
							num = -1759860047;
							continue;
						case 2:
							goto end_IL_0026;
						}
						break;
					}
					goto IL_002f;
					end_IL_0026:;
				}
				return stringWriter.ToString();
			}
			finally
			{
				if (stringWriter != null)
				{
					while (true)
					{
						IL_0084:
						int num2 = -1759860046;
						while (true)
						{
							switch (num2 ^ -1759860045)
							{
							case 0:
								break;
							default:
								goto end_IL_0089;
							case 1:
								goto IL_00a2;
							case 2:
								goto end_IL_0089;
							}
							goto IL_0084;
							IL_00a2:
							((IDisposable)stringWriter).Dispose();
							num2 = -1759860047;
							continue;
							end_IL_0089:
							break;
						}
						break;
					}
				}
			}
		}

		public string ToJsonString()
		{
			return JsonWriter.ToJson(this);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = default(int);
			string keyAt = default(string);
			while (true)
			{
				int num = 1818404522;
				while (true)
				{
					switch (num ^ 0x6C62A6A2)
					{
					case 0:
						break;
					case 8:
						stringBuilder.Append("count = ");
						stringBuilder.Append(count.ToString());
						num = 1818404526;
						continue;
					case 5:
						stringBuilder.Append((uATAKekNULJnPDOlfNNCOVgfslDN != null) ? uATAKekNULJnPDOlfNNCOVgfslDN.ToString() : "NULL\n");
						stringBuilder.Append("\n");
						num2 = 0;
						num = 1818404520;
						continue;
					case 9:
						stringBuilder.Append(tuDnWvAbjhELceCHmvtwYnnZJUX.ToString());
						stringBuilder.Append("\n");
						num = 1818404521;
						continue;
					case 1:
						stringBuilder.Append("\n");
						num = 1818404513;
						continue;
					case 12:
						stringBuilder.Append("\n");
						stringBuilder.Append("type = ");
						num = 1818404512;
						continue;
					case 11:
						stringBuilder.Append("xmlInfo = ");
						num = 1818404519;
						continue;
					case 6:
						stringBuilder.Append((keyAt != null) ? keyAt : "NULL");
						stringBuilder.Append(", value = ");
						stringBuilder.Append(ejjIumfYByuzEoXWaUogFHERZVH[num2].ToString());
						num = 1818404515;
						continue;
					case 10:
					{
						int num3;
						if (num2 < ejjIumfYByuzEoXWaUogFHERZVH.Count)
						{
							num = 1818404517;
							num3 = num;
						}
						else
						{
							num = 1818404518;
							num3 = num;
						}
						continue;
					}
					case 7:
						keyAt = ejjIumfYByuzEoXWaUogFHERZVH.GetKeyAt(num2);
						num = 1818404527;
						continue;
					case 3:
						num2++;
						num = 1818404520;
						continue;
					case 2:
						stringBuilder.Append(((object)mlHEPMoLvhyxVvGHhIjSYBQKMrF != null) ? mlHEPMoLvhyxVvGHhIjSYBQKMrF.Name : "NULL\n");
						stringBuilder.Append("objectType = ");
						num = 1818404523;
						continue;
					case 13:
						stringBuilder.Append("key = ");
						num = 1818404516;
						continue;
					default:
						return stringBuilder.ToString();
					}
					break;
				}
			}
		}

		private void WriteXml(XmlWriter writer)
		{
			if (writer == null)
			{
				while (true)
				{
					switch (0x3E90A19E ^ 0x3E90A19C)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("writer");
					}
					break;
				}
			}
			writer.WriteStartElement(type.Name, "http://guavaman.com/rewired");
			WriteXml_Value(writer);
			writer.WriteEndElement();
		}

		private void WriteXml_Value(XmlWriter writer)
		{
			if (xmlInfo == null)
			{
				goto IL_0008;
			}
			int num = xmlInfo.attributes.Count;
			goto IL_0080;
			IL_0080:
			int num2 = num;
			int num3 = 0;
			int num4 = 2094079194;
			goto IL_000d;
			IL_0008:
			num4 = 2094079173;
			goto IL_000d;
			IL_000d:
			int num5 = default(int);
			string text = default(string);
			Entry entry = default(Entry);
			XmlInfo.XmlStringAttribute xmlStringAttribute = default(XmlInfo.XmlStringAttribute);
			XmlInfo.XmlAttribute xmlAttribute = default(XmlInfo.XmlAttribute);
			while (true)
			{
				switch (num4 ^ 0x7CD11CC8)
				{
				case 4:
					break;
				case 13:
					goto IL_006d;
				case 18:
					if (num3 >= num2)
					{
						num5 = 0;
						num4 = 2094079170;
						continue;
					}
					goto IL_0161;
				case 19:
					num4 = 2094079192;
					continue;
				case 2:
					text = entry.value.GetType().Name;
					num4 = 2094079195;
					continue;
				case 9:
					throw new NotImplementedException();
				case 12:
					if ((entry.options & FieldOptions.ExculdeFromXml) == 0)
					{
						if (string.IsNullOrEmpty(text))
						{
							if ((object)entry.type != null)
							{
								text = entry.GetType().Name;
								num4 = 2094079192;
								continue;
							}
							goto IL_01ab;
						}
						goto case 16;
					}
					goto case 3;
				case 0:
					if (!string.IsNullOrEmpty(xmlStringAttribute.prefix))
					{
						writer.WriteAttributeString(xmlStringAttribute.prefix, xmlStringAttribute.localName, xmlStringAttribute.ns, xmlStringAttribute.value);
						num4 = 2094079193;
						continue;
					}
					goto case 5;
				case 14:
					text = "value";
					num4 = 2094079192;
					continue;
				case 15:
					goto IL_0161;
				case 11:
					writer.WriteAttributeString(xmlStringAttribute.localName, xmlStringAttribute.value);
					num4 = 2094079193;
					continue;
				case 6:
					goto IL_01ab;
				case 16:
					SerializationTools.WriteXmlElement(writer, text, entry.value);
					num4 = 2094079179;
					continue;
				case 3:
					num5++;
					num4 = 2094079170;
					continue;
				case 1:
					xmlStringAttribute = xmlAttribute as XmlInfo.XmlStringAttribute;
					num4 = 2094079176;
					continue;
				case 5:
					if (!string.IsNullOrEmpty(xmlStringAttribute.ns))
					{
						writer.WriteAttributeString(xmlStringAttribute.localName, xmlStringAttribute.ns, xmlStringAttribute.value);
						num4 = 2094079193;
						continue;
					}
					goto case 11;
				case 7:
					entry = ejjIumfYByuzEoXWaUogFHERZVH[num5];
					num4 = 2094079168;
					continue;
				case 17:
					num3++;
					num4 = 2094079194;
					continue;
				case 8:
					text = ejjIumfYByuzEoXWaUogFHERZVH.GetKeyAt(num5);
					num4 = 2094079172;
					continue;
				default:
					if (num5 >= count)
					{
						return;
					}
					goto case 7;
				}
				break;
				IL_01ab:
				int num6;
				if (entry.value != null)
				{
					num4 = 2094079178;
					num6 = num4;
				}
				else
				{
					num4 = 2094079174;
					num6 = num4;
				}
				continue;
				IL_0161:
				xmlAttribute = xmlInfo.attributes[num3];
				int num7;
				if (xmlAttribute is XmlInfo.XmlStringAttribute)
				{
					num4 = 2094079177;
					num7 = num4;
				}
				else
				{
					num4 = 2094079169;
					num7 = num4;
				}
			}
			goto IL_0008;
			IL_006d:
			num = 0;
			goto IL_0080;
		}

		void IExportToXml.WriteXml(XmlWriter writer)
		{
			WriteXml(writer);
		}

		void IExportToJson.WriteJson(StringBuilder stringBuilder, Action<StringBuilder, object> appendValueDelegate)
		{
			if (stringBuilder == null)
			{
				throw new ArgumentNullException("stringBuilder");
			}
			int num4 = default(int);
			int num3 = default(int);
			string value = default(string);
			Entry entry = default(Entry);
			int num5 = default(int);
			bool flag = default(bool);
			bool flag2 = default(bool);
			while (true)
			{
				int num;
				int num2;
				if (appendValueDelegate == null)
				{
					num = -1486220646;
					num2 = num;
				}
				else
				{
					num = -1486220644;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1486220664)
					{
					case 8:
						num = -1486220658;
						continue;
					default:
						return;
					case 9:
						if (num4 >= num3)
						{
							stringBuilder.Append(']');
							return;
						}
						goto case 10;
					case 5:
						stringBuilder.Append('"');
						stringBuilder.Append(value);
						stringBuilder.Append("\":");
						appendValueDelegate(stringBuilder, entry.value);
						num5++;
						num = -1486220660;
						continue;
					case 18:
						throw new ArgumentNullException("appendValueDelegate");
					case 11:
						num = -1486220648;
						continue;
					case 3:
						num5 = 0;
						num = -1486220660;
						continue;
					case 13:
						stringBuilder.Append(',');
						num = -1486220665;
						continue;
					case 19:
					{
						int num7;
						if (string.IsNullOrEmpty(value))
						{
							num = -1486220657;
							num7 = num;
						}
						else
						{
							num = -1486220659;
							num7 = num;
						}
						continue;
					}
					case 4:
						if (num5 >= num3)
						{
							stringBuilder.Append('}');
							num = -1486220668;
							continue;
						}
						goto case 1;
					case 0:
						stringBuilder.Append('{');
						flag = true;
						num = -1486220661;
						continue;
					case 16:
						entry = ejjIumfYByuzEoXWaUogFHERZVH[num5];
						value = ejjIumfYByuzEoXWaUogFHERZVH.GetKeyAt(num5);
						num = -1486220645;
						continue;
					case 10:
						if (flag2)
						{
							flag2 = false;
							num = -1486220665;
							continue;
						}
						goto case 13;
					case 7:
						value = num5.ToString();
						num = -1486220659;
						continue;
					case 17:
						if (ejjIumfYByuzEoXWaUogFHERZVH.ContainsDuplicateKeys)
						{
							stringBuilder.Append('[');
							flag2 = true;
							num4 = 0;
							num = -1486220671;
							continue;
						}
						goto case 0;
					case 1:
					{
						int num6;
						if (!flag)
						{
							num = -1486220666;
							num6 = num;
						}
						else
						{
							num = -1486220662;
							num6 = num;
						}
						continue;
					}
					case 2:
						flag = false;
						num = -1486220669;
						continue;
					case 15:
						appendValueDelegate(stringBuilder, ejjIumfYByuzEoXWaUogFHERZVH[num4].value);
						num4++;
						num = -1486220671;
						continue;
					case 6:
						break;
					case 20:
						num3 = ejjIumfYByuzEoXWaUogFHERZVH.Count;
						num = -1486220647;
						continue;
					case 14:
						stringBuilder.Append(',');
						num = -1486220648;
						continue;
					case 12:
						return;
					}
					break;
				}
			}
		}

		void IAddValue<object>.Add(object value)
		{
			Add(null, value);
		}

		void IAddKeyValue<string, object>.Add(string key, object value)
		{
			Add(key, value);
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return new Enumerator(ejjIumfYByuzEoXWaUogFHERZVH);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(ejjIumfYByuzEoXWaUogFHERZVH);
		}

		private static bool TryConvertOrCreateObject<T>(object obj, out T result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			if (!TryConvertOrCreateObject(typeof(T), obj, out var result2, numberStyle, cultureInfo))
			{
				goto IL_0016;
			}
			result = (T)result2;
			int num = 1896962727;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ 0x71115AA5)
				{
				case 0:
					break;
				case 1:
					goto IL_0038;
				case 3:
					return false;
				default:
					return true;
				}
				break;
				IL_0038:
				result = default(T);
				num = 1896962726;
			}
			goto IL_0016;
			IL_0016:
			num = 1896962724;
			goto IL_001b;
		}

		private static bool TryConvertOrCreateObject(Type targetType, object obj, out object result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			result = null;
			if (obj == null)
			{
				while (true)
				{
					int num = 277931159;
					while (true)
					{
						switch (num ^ 0x1090E494)
						{
						case 0:
							break;
						case 3:
							if (object.ReferenceEquals(targetType, typeof(string)))
							{
								num = 277931158;
							}
							else
							{
								if (!ReflectionTools.IsValueType(targetType))
								{
									return true;
								}
								if ((object)Nullable.GetUnderlyingType(targetType) == null)
								{
									return false;
								}
								num = 277931157;
							}
							continue;
						case 2:
							result = string.Empty;
							return true;
						default:
							return true;
						}
						break;
					}
				}
			}
			Type type = obj.GetType();
			if (object.ReferenceEquals(targetType, type))
			{
				result = obj;
				return true;
			}
			bool result2 = default(bool);
			try
			{
				if (object.ReferenceEquals(targetType, typeof(string)))
				{
					goto IL_0091;
				}
				goto IL_01dc;
				IL_0091:
				int num2 = 277931144;
				goto IL_0096;
				IL_0096:
				int result4 = default(int);
				float result3 = default(float);
				while (true)
				{
					switch (num2 ^ 0x1090E494)
					{
					case 30:
						break;
					case 36:
						goto end_IL_007c;
					case 3:
						result2 = false;
						num2 = 277931145;
						continue;
					case 11:
						result2 = false;
						goto end_IL_007c;
					case 15:
						if (object.ReferenceEquals(type, typeof(ulong)))
						{
							result = (float)(ulong)obj;
							num2 = 277931162;
							continue;
						}
						goto case 7;
					case 32:
						num2 = 277931162;
						continue;
					case 23:
						goto IL_01dc;
					case 12:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (float)(int)(byte)obj;
							num2 = 277931162;
							continue;
						}
						goto case 42;
					case 38:
						goto IL_024b;
					case 2:
						result = (float)(uint)obj;
						num2 = 277931162;
						continue;
					case 13:
						goto IL_02a3;
					case 20:
						result = result4;
						num2 = 277931196;
						continue;
					case 26:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (int)(byte)obj;
							num2 = 277931196;
							continue;
						}
						goto case 1;
					case 27:
						result = (int)(uint)obj;
						num2 = 277931196;
						continue;
					case 47:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (int)(long)obj;
							num2 = 277931196;
							continue;
						}
						goto case 9;
					case 25:
						goto end_IL_007c;
					case 37:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (float)(long)obj;
							num2 = 277931162;
							continue;
						}
						goto case 15;
					case 7:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (float)(double)obj;
							num2 = 277931188;
							continue;
						}
						goto case 10;
					case 16:
						num2 = 277931196;
						continue;
					case 29:
						goto end_IL_007c;
					case 50:
						result = (float)(int)(ushort)obj;
						num2 = 277931162;
						continue;
					case 43:
						if (!int.TryParse(obj.ToString(), out result4))
						{
							result2 = false;
							num2 = 277931184;
							continue;
						}
						goto case 20;
					case 9:
						if (object.ReferenceEquals(type, typeof(ulong)))
						{
							result = (int)(ulong)obj;
							num2 = 277931196;
							continue;
						}
						goto case 51;
					case 6:
						goto IL_0431;
					case 42:
						if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							result = (float)(sbyte)obj;
							num2 = 277931162;
							continue;
						}
						goto case 5;
					case 0:
						result2 = false;
						goto end_IL_007c;
					case 21:
						if (object.ReferenceEquals(type, typeof(ushort)))
						{
							result = (int)(ushort)obj;
							num2 = 277931196;
							continue;
						}
						goto case 26;
					case 22:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							result = (int)(decimal)obj;
							num2 = 277931140;
							continue;
						}
						goto IL_02a3;
					case 4:
						goto IL_04f3;
					case 5:
						if (object.ReferenceEquals(type, typeof(string)))
						{
							goto IL_052b;
						}
						goto case 17;
					case 51:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (int)(double)obj;
							num2 = 277931196;
							continue;
						}
						goto case 22;
					case 41:
						goto end_IL_007c;
					case 45:
						if (!float.TryParse(obj.ToString(), out result3))
						{
							result2 = false;
							num2 = 277931147;
							continue;
						}
						goto case 35;
					case 17:
						result2 = false;
						goto end_IL_007c;
					case 18:
						goto IL_05b0;
					case 39:
						goto IL_05d6;
					case 10:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							result = (float)(decimal)obj;
							num2 = 277931162;
							continue;
						}
						goto case 46;
					case 14:
						result2 = true;
						num2 = 277931149;
						continue;
					case 8:
						num2 = 277931196;
						continue;
					case 33:
						goto IL_0645;
					case 34:
						goto IL_065d;
					case 1:
						if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							result = (int)(sbyte)obj;
							num2 = 277931196;
							continue;
						}
						goto IL_0728;
					case 40:
						result2 = true;
						num2 = 277931173;
						continue;
					case 49:
						goto end_IL_007c;
					case 31:
						goto end_IL_007c;
					case 44:
						goto IL_06f0;
					case 35:
						result = result3;
						num2 = 277931162;
						continue;
					case 19:
						goto IL_0728;
					case 28:
						result = obj.ToString();
						result2 = true;
						num2 = 277931197;
						continue;
					case 46:
						if (object.ReferenceEquals(type, typeof(short)))
						{
							result = (float)(short)obj;
							num2 = 277931162;
							continue;
						}
						goto IL_05b0;
					case 24:
						result = (int)(short)obj;
						num2 = 277931196;
						continue;
					default:
						goto IL_07a7;
					}
					break;
					IL_0645:
					int num3;
					if (cultureInfo == null)
					{
						num2 = 277931199;
						num3 = num2;
					}
					else
					{
						num2 = 277931154;
						num3 = num2;
					}
					continue;
					IL_0728:
					int num4;
					if (!object.ReferenceEquals(type, typeof(string)))
					{
						num2 = 277931159;
						num4 = num2;
					}
					else
					{
						num2 = 277931189;
						num4 = num2;
					}
					continue;
					IL_02a3:
					int num5;
					if (object.ReferenceEquals(type, typeof(short)))
					{
						num2 = 277931148;
						num5 = num2;
					}
					else
					{
						num2 = 277931137;
						num5 = num2;
					}
					continue;
					IL_04f3:
					int num6;
					if (!float.TryParse(obj.ToString(), numberStyle, cultureInfo, out result3))
					{
						num2 = 277931167;
						num6 = num2;
					}
					else
					{
						num2 = 277931191;
						num6 = num2;
					}
					continue;
					IL_052b:
					int num7;
					if (cultureInfo == null)
					{
						num2 = 277931193;
						num7 = num2;
					}
					else
					{
						num2 = 277931152;
						num7 = num2;
					}
					continue;
					IL_05b0:
					int num8;
					if (!object.ReferenceEquals(type, typeof(ushort)))
					{
						num2 = 277931160;
						num8 = num2;
					}
					else
					{
						num2 = 277931174;
						num8 = num2;
					}
					continue;
					IL_0431:
					int num9;
					if (!int.TryParse(obj.ToString(), numberStyle, cultureInfo, out result4))
					{
						num2 = 277931156;
						num9 = num2;
					}
					else
					{
						num2 = 277931136;
						num9 = num2;
					}
				}
				goto IL_0091;
				IL_379d:
				int num10 = 277931154;
				goto IL_37a2;
				IL_34f6:
				int num11;
				int num12;
				if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
				{
					num11 = 277931165;
					num12 = num11;
				}
				else
				{
					num11 = 277931160;
					num12 = num11;
				}
				goto IL_3107;
				IL_3310:
				result2 = false;
				num11 = 277931158;
				goto IL_3107;
				IL_06f0:
				int num13;
				if (object.ReferenceEquals(type, typeof(uint)))
				{
					num2 = 277931158;
					num13 = num2;
				}
				else
				{
					num2 = 277931185;
					num13 = num2;
				}
				goto IL_0096;
				IL_024b:
				if (!ReflectionTools.IsEnum(targetType))
				{
					if (object.ReferenceEquals(targetType, typeof(uint)))
					{
						if (!object.ReferenceEquals(type, typeof(int)))
						{
							goto IL_1efd;
						}
						result = (uint)(int)obj;
						goto IL_222b;
					}
					goto IL_248d;
				}
				Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(targetType);
				if (!TryConvertOrCreateObject(underlyingEnumType, obj, out var result5, numberStyle, cultureInfo))
				{
					goto IL_07a7;
				}
				result = Enum.ToObject(targetType, result5);
				result2 = true;
				goto end_IL_007c;
				IL_05d6:
				int num14;
				if (!object.ReferenceEquals(type, typeof(uint)))
				{
					num2 = 277931195;
					num14 = num2;
				}
				else
				{
					num2 = 277931151;
					num14 = num2;
				}
				goto IL_0096;
				IL_07a7:
				if (!object.ReferenceEquals(type, typeof(string)))
				{
					goto IL_37f3;
				}
				try
				{
					result = Enum.Parse(targetType, (string)obj, ignoreCase: true);
					result2 = true;
				}
				catch
				{
					result = null;
					result2 = false;
				}
				goto end_IL_007c;
				IL_164f:
				int num15;
				int num16;
				if (!object.ReferenceEquals(type, typeof(long)))
				{
					num15 = 277931137;
					num16 = num15;
				}
				else
				{
					num15 = 277931044;
					num16 = num15;
				}
				goto IL_0820;
				IL_37f3:
				int num17;
				if (object.ReferenceEquals(targetType, typeof(object)))
				{
					num10 = 277931153;
					num17 = num10;
				}
				else
				{
					num10 = 277931155;
					num17 = num10;
				}
				goto IL_37a2;
				IL_32b3:
				Type genericTypeDefinition = default(Type);
				Type type2 = default(Type);
				SerializedObject serializedObject = default(SerializedObject);
				Type type3 = default(Type);
				Type type4 = default(Type);
				IDictionary dictionary = default(IDictionary);
				if (ReflectionTools.IsGenericType(targetType))
				{
					genericTypeDefinition = targetType.GetGenericTypeDefinition();
					if (ReflectionTools.DoesTypeImplement(targetType, typeof(IList)))
					{
						type2 = ReflectionTools.GetGenericArguments(targetType)[0];
						if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
						{
							serializedObject = obj as SerializedObject;
							num11 = 277931137;
							goto IL_3107;
						}
						goto IL_34f6;
					}
					while (ReflectionTools.DoesTypeImplement(genericTypeDefinition, typeof(IDictionary)))
					{
						int num18 = 277931157;
						while (true)
						{
							switch (num18 ^ 0x1090E494)
							{
							case 0:
								num18 = 277931153;
								continue;
							case 4:
								break;
							case 1:
							{
								Type[] genericArguments = ReflectionTools.GetGenericArguments(targetType);
								type3 = genericArguments[0];
								type4 = genericArguments[1];
								num18 = 277931154;
								continue;
							}
							case 5:
								goto IL_3668;
							case 6:
								dictionary = obj as IDictionary;
								num18 = 277931158;
								continue;
							case 2:
								if (dictionary == null)
								{
									result2 = false;
									num18 = 277931152;
									continue;
								}
								goto IL_36a5;
							default:
								goto IL_36a5;
							}
							break;
						}
						goto end_IL_007c;
						IL_3668:;
					}
				}
				goto IL_37f3;
				IL_3107:
				int num22 = default(int);
				IList list2 = default(IList);
				int num25 = default(int);
				Array array = default(Array);
				IList list6 = default(IList);
				int num23 = default(int);
				IList list4 = default(IList);
				IList list5 = default(IList);
				int num24 = default(int);
				IReadOnlyList readOnlyList = default(IReadOnlyList);
				IList list3 = default(IList);
				IEnumerator enumerator;
				while (true)
				{
					switch (num11 ^ 0x1090E494)
					{
					case 23:
						num11 = 277931150;
						continue;
					case 7:
						num11 = 277931159;
						continue;
					case 3:
						if (num22 >= serializedObject.count)
						{
							result = list2;
							num11 = 277931142;
							continue;
						}
						goto case 13;
					case 2:
						break;
					case 24:
						if (num25 >= array.Length)
						{
							result = list6;
							num11 = 277931149;
							continue;
						}
						goto case 6;
					case 14:
						num23++;
						num11 = 277931156;
						continue;
					case 20:
						if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
						{
							array = obj as Array;
							list6 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
							num11 = 277931138;
							continue;
						}
						goto IL_334b;
					case 28:
						num25++;
						num11 = 277931148;
						continue;
					case 12:
						if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
						{
							list4 = obj as IList;
							list5 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
							num11 = 277931152;
							continue;
						}
						goto case 20;
					case 10:
						if (num24 >= readOnlyList.Count)
						{
							result = list3;
							num11 = 277931140;
							continue;
						}
						goto case 11;
					case 29:
						goto IL_32b3;
					case 26:
						goto IL_3310;
					case 6:
					{
						if (TryConvertOrCreateObject(type2, array.GetValue(num25), out var result7, numberStyle, cultureInfo))
						{
							list6.Add(result7);
							num11 = 277931144;
							continue;
						}
						goto case 28;
					}
					case 15:
						goto IL_334b;
					case 0:
						if (num23 >= list4.Count)
						{
							result = list5;
							result2 = true;
							break;
						}
						goto case 19;
					case 11:
					{
						if (TryConvertOrCreateObject(type2, readOnlyList[num24], out var result9, numberStyle, cultureInfo))
						{
							list3.Add(result9);
							num11 = 277931164;
							continue;
						}
						goto case 8;
					}
					case 18:
						result2 = true;
						num11 = 277931151;
						continue;
					case 17:
						num22++;
						num11 = 277931159;
						continue;
					case 22:
						num25 = 0;
						num11 = 277931148;
						continue;
					case 13:
					{
						if (TryConvertOrCreateObject(type2, serializedObject[num22].value, out var result10, numberStyle, cultureInfo))
						{
							list2.Add(result10);
							num11 = 277931141;
							continue;
						}
						goto case 17;
					}
					case 1:
						list3 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
						num24 = 0;
						num11 = 277931166;
						continue;
					case 4:
						num23 = 0;
						num11 = 277931156;
						continue;
					case 8:
						num24++;
						num11 = 277931166;
						continue;
					case 21:
						list2 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
						num22 = 0;
						num11 = 277931155;
						continue;
					case 27:
						break;
					case 19:
					{
						if (TryConvertOrCreateObject(type2, list4[num23], out var result8, numberStyle, cultureInfo))
						{
							list5.Add(result8);
							num11 = 277931162;
							continue;
						}
						goto case 14;
					}
					case 16:
						result2 = true;
						break;
					case 9:
						readOnlyList = obj as IReadOnlyList;
						num11 = 277931157;
						continue;
					case 5:
						goto IL_34f6;
					case 25:
						result2 = true;
						break;
					default:
					{
						IEnumerable enumerable = obj as IEnumerable;
						IList list = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
						enumerator = enumerable.GetEnumerator();
						try
						{
							while (true)
							{
								IL_35b1:
								int num19;
								int num20;
								if (!enumerator.MoveNext())
								{
									num19 = 277931158;
									num20 = num19;
								}
								else
								{
									num19 = 277931157;
									num20 = num19;
								}
								while (true)
								{
									switch (num19 ^ 0x1090E494)
									{
									case 3:
										num19 = 277931157;
										continue;
									default:
										goto end_IL_356a;
									case 1:
									{
										object current = enumerator.Current;
										if (TryConvertOrCreateObject(type2, current, out var result6, numberStyle, cultureInfo))
										{
											list.Add(result6);
											num19 = 277931156;
											continue;
										}
										break;
									}
									case 0:
										break;
									case 2:
										goto end_IL_356a;
									}
									goto IL_35b1;
									continue;
									end_IL_356a:
									break;
								}
								break;
							}
						}
						finally
						{
							if (enumerator is IDisposable disposable)
							{
								while (true)
								{
									IL_35da:
									int num21 = 277931158;
									while (true)
									{
										switch (num21 ^ 0x1090E494)
										{
										case 0:
											break;
										default:
											goto end_IL_35df;
										case 2:
											goto IL_35f8;
										case 1:
											goto end_IL_35df;
										}
										goto IL_35da;
										IL_35f8:
										disposable.Dispose();
										num21 = 277931157;
										continue;
										end_IL_35df:
										break;
									}
									break;
								}
							}
						}
						result = list;
						result2 = true;
						break;
					}
					}
					break;
					IL_334b:
					if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
					{
						num11 = 277931146;
						continue;
					}
					goto IL_37f3;
				}
				goto end_IL_007c;
				IL_248d:
				int num26;
				if (!object.ReferenceEquals(targetType, typeof(double)))
				{
					num15 = 277931032;
					num26 = num15;
				}
				else
				{
					num15 = 277931072;
					num26 = num15;
				}
				goto IL_0820;
				IL_065d:
				if (!object.ReferenceEquals(targetType, typeof(float)))
				{
					goto IL_024b;
				}
				if (object.ReferenceEquals(type, typeof(int)))
				{
					result = (float)(int)obj;
					num2 = 277931162;
					goto IL_0096;
				}
				goto IL_06f0;
				IL_2ee3:
				Type elementType = default(Type);
				while (true)
				{
					IL_2ee3_2:
					if (ReflectionTools.DoesTypeImplement(type, typeof(ICollection)))
					{
						ICollection collection = obj as ICollection;
						Array array2 = Array.CreateInstance(elementType, collection.Count);
						int num27 = 277931158;
						while (true)
						{
							switch (num27 ^ 0x1090E494)
							{
							case 0:
								goto IL_2ec5;
							case 1:
								break;
							default:
							{
								int num28 = 0;
								enumerator = collection.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										while (true)
										{
											object current2 = enumerator.Current;
											int num29;
											int num30;
											if (!TryConvertOrCreateObject(elementType, current2, out var result11, numberStyle, cultureInfo))
											{
												num29 = 277931152;
												num30 = num29;
											}
											else
											{
												num29 = 277931156;
												num30 = num29;
											}
											while (true)
											{
												switch (num29 ^ 0x1090E494)
												{
												case 2:
													num29 = 277931159;
													continue;
												case 3:
													break;
												case 1:
													num28++;
													num29 = 277931152;
													continue;
												case 0:
													array2.SetValue(result11, num28);
													num29 = 277931157;
													continue;
												default:
													goto end_IL_2f4b;
												}
												break;
											}
											continue;
											end_IL_2f4b:
											break;
										}
									}
								}
								finally
								{
									IDisposable disposable2 = enumerator as IDisposable;
									while (true)
									{
										IL_2fa8:
										int num31 = 277931158;
										while (true)
										{
											switch (num31 ^ 0x1090E494)
											{
											case 0:
												break;
											default:
												goto end_IL_2fad;
											case 2:
												if (disposable2 != null)
												{
													goto IL_2fca;
												}
												goto end_IL_2fad;
											case 1:
												goto end_IL_2fad;
											}
											goto IL_2fa8;
											IL_2fca:
											disposable2.Dispose();
											num31 = 277931157;
											continue;
											end_IL_2fad:
											break;
										}
										break;
									}
								}
								result = array2;
								result2 = true;
								goto end_IL_2eca;
							}
							}
							goto IL_2ee3_2;
							IL_2ec5:
							num27 = 277931157;
							continue;
							end_IL_2eca:
							break;
						}
						break;
					}
					if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
					{
						IEnumerable enumerable2 = obj as IEnumerable;
						int num32 = 0;
						{
							IEnumerator enumerator2 = enumerable2.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										_ = enumerator2.Current;
										int num33 = 277931158;
										while (true)
										{
											switch (num33 ^ 0x1090E494)
											{
											case 3:
												num33 = 277931157;
												continue;
											case 1:
												break;
											case 2:
												num32++;
												num33 = 277931156;
												continue;
											default:
												goto end_IL_3032;
											}
											break;
										}
										continue;
										end_IL_3032:
										break;
									}
								}
							}
							finally
							{
								IDisposable disposable4 = enumerator2 as IDisposable;
								if (disposable4 != null)
								{
									disposable4.Dispose();
								}
							}
						}
						Array array3 = Array.CreateInstance(elementType, num32);
						int num34 = 0;
						{
							IEnumerator enumerator2 = enumerable2.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									while (true)
									{
										object current3 = enumerator2.Current;
										if (!TryConvertOrCreateObject(elementType, current3, out var result12, numberStyle, cultureInfo))
										{
											break;
										}
										array3.SetValue(result12, num34);
										num34++;
										int num35 = 277931158;
										while (true)
										{
											switch (num35 ^ 0x1090E494)
											{
											case 0:
												num35 = 277931157;
												continue;
											case 1:
												break;
											default:
												goto end_IL_30a5;
											}
											break;
										}
										continue;
										end_IL_30a5:
										break;
									}
								}
							}
							finally
							{
								IDisposable disposable5 = enumerator2 as IDisposable;
								if (disposable5 != null)
								{
									disposable5.Dispose();
								}
							}
						}
						result = array3;
						result2 = true;
						break;
					}
					goto IL_3310;
				}
				goto end_IL_007c;
				IL_1efd:
				if (object.ReferenceEquals(type, typeof(float)))
				{
					result = (uint)(float)obj;
					num15 = 277931230;
					goto IL_0820;
				}
				goto IL_164f;
				IL_222b:
				result2 = true;
				num15 = 277931194;
				goto IL_0820;
				IL_36a5:
				IDictionary dictionary2 = (IDictionary)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type3, type4));
				enumerator = dictionary.Keys.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							object current4 = enumerator.Current;
							if (!TryConvertOrCreateObject(type3, current4, out var result13, numberStyle, cultureInfo) || !TryConvertOrCreateObject(type4, dictionary[current4], out var result14, numberStyle, cultureInfo))
							{
								break;
							}
							dictionary2.Add(result13, result14);
							int num36 = 277931158;
							while (true)
							{
								switch (num36 ^ 0x1090E494)
								{
								case 0:
									num36 = 277931157;
									continue;
								case 1:
									break;
								default:
									goto end_IL_36fd;
								}
								break;
							}
							continue;
							end_IL_36fd:
							break;
						}
					}
				}
				finally
				{
					IDisposable disposable2 = enumerator as IDisposable;
					while (true)
					{
						IL_3753:
						int num37 = 277931157;
						while (true)
						{
							switch (num37 ^ 0x1090E494)
							{
							case 0:
								break;
							default:
								goto end_IL_3758;
							case 1:
							{
								int num38;
								if (disposable2 == null)
								{
									num37 = 277931158;
									num38 = num37;
								}
								else
								{
									num37 = 277931159;
									num38 = num37;
								}
								continue;
							}
							case 3:
								disposable2.Dispose();
								num37 = 277931158;
								continue;
							case 2:
								goto end_IL_3758;
							}
							goto IL_3753;
							continue;
							end_IL_3758:
							break;
						}
						break;
					}
				}
				result = dictionary2;
				goto IL_379d;
				IL_01dc:
				if (object.ReferenceEquals(targetType, typeof(int)))
				{
					if (object.ReferenceEquals(type, typeof(float)))
					{
						result = (int)(float)obj;
						num2 = 277931164;
						goto IL_0096;
					}
					goto IL_05d6;
				}
				goto IL_065d;
				IL_37a2:
				while (true)
				{
					switch (num10 ^ 0x1090E494)
					{
					case 2:
						break;
					case 6:
						result2 = true;
						goto end_IL_007c;
					case 1:
						result = obj;
						result2 = true;
						goto end_IL_007c;
					case 0:
						goto IL_37f3;
					case 5:
						result = obj;
						result2 = true;
						goto end_IL_007c;
					case 3:
						if (TryCreateObject(targetType, obj as SerializedObject, out obj))
						{
							goto case 1;
						}
						result2 = false;
						goto end_IL_007c;
					case 7:
						goto IL_384d;
					default:
						goto IL_3880;
					}
					break;
					IL_384d:
					int num39;
					if (!ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
					{
						num10 = 277931152;
						num39 = num10;
					}
					else
					{
						num10 = 277931159;
						num39 = num10;
					}
				}
				goto IL_379d;
				IL_0820:
				SerializedObject serializedObject2 = default(SerializedObject);
				int num45 = default(int);
				int num46 = default(int);
				Array array7 = default(Array);
				Array array8 = default(Array);
				ulong result23 = default(ulong);
				byte result17 = default(byte);
				long result22 = default(long);
				short result28 = default(short);
				int num44 = default(int);
				double result27 = default(double);
				decimal result18 = default(decimal);
				IList list7 = default(IList);
				IReadOnlyList readOnlyList2 = default(IReadOnlyList);
				sbyte result20 = default(sbyte);
				Array array9 = default(Array);
				int num47 = default(int);
				Array array6 = default(Array);
				ushort result16 = default(ushort);
				Array array5 = default(Array);
				uint result25 = default(uint);
				IDictionary dictionary3 = default(IDictionary);
				Type targetType2 = default(Type);
				while (true)
				{
					switch (num15 ^ 0x1090E494)
					{
					case 6:
						num15 = 277931113;
						continue;
					case 94:
						result = (uint)(ushort)obj;
						num15 = 277931028;
						continue;
					case 97:
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							result = (short)(uint)obj;
							num15 = 277931203;
							continue;
						}
						goto case 236;
					case 22:
						break;
					case 143:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (uint)(double)obj;
							num15 = 277931179;
							continue;
						}
						goto case 11;
					case 188:
						if (object.ReferenceEquals(type, typeof(int)))
						{
							result = (short)(int)obj;
							num15 = 277931203;
							continue;
						}
						goto case 97;
					case 88:
						if (object.ReferenceEquals(type, typeof(short)))
						{
							result = (ulong)(short)obj;
							num15 = 277931236;
							continue;
						}
						goto case 270;
					case 43:
						if (object.ReferenceEquals(type, typeof(int)))
						{
							result = (double)(int)obj;
							num15 = 277931419;
							continue;
						}
						goto case 73;
					case 40:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							result = (short)(decimal)obj;
							num15 = 277931203;
							continue;
						}
						goto IL_176a;
					case 233:
						result2 = false;
						goto end_IL_0820;
					case 198:
						result2 = true;
						num15 = 277931162;
						continue;
					case 235:
						num15 = 277931203;
						continue;
					case 183:
						num15 = 277931239;
						continue;
					case 213:
						if (object.ReferenceEquals(type, typeof(ulong)))
						{
							result = (ulong)obj != 0;
							num15 = 277931112;
							continue;
						}
						goto case 99;
					case 270:
						if (object.ReferenceEquals(type, typeof(ushort)))
						{
							result = (ulong)(ushort)obj;
							num15 = 277931144;
							continue;
						}
						goto case 144;
					case 124:
						result = (double)(decimal)obj;
						num15 = 277931419;
						continue;
					case 49:
						result = (byte)(ushort)obj;
						num15 = 277931043;
						continue;
					case 103:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (byte)obj > 0;
							num15 = 277931112;
							continue;
						}
						goto IL_229a;
					case 72:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (long)(double)obj;
							num15 = 277931232;
							continue;
						}
						goto case 195;
					case 190:
						num15 = 277931209;
						continue;
					case 29:
						serializedObject2 = obj as SerializedObject;
						if (serializedObject2 == null)
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 100;
					case 64:
						goto IL_0f0f;
					case 70:
						result = (sbyte)(short)obj;
						num15 = 277931161;
						continue;
					case 90:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (double)(long)obj;
							num15 = 277931419;
							continue;
						}
						goto case 18;
					case 207:
						num15 = 277931022;
						continue;
					case 8:
						num15 = 277931163;
						continue;
					case 171:
						num15 = 277931209;
						continue;
					case 99:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (double)obj > 0.0;
							num15 = 277931112;
							continue;
						}
						goto IL_2a13;
					case 126:
						goto IL_0fe2;
					case 37:
						goto end_IL_0820;
					case 222:
						num45++;
						num15 = 277931244;
						continue;
					case 252:
						result2 = true;
						goto end_IL_0820;
					case 257:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (short)(double)obj;
							num15 = 277931203;
							continue;
						}
						goto case 40;
					case 194:
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							result = (ushort)(uint)obj;
							num15 = 277931107;
							continue;
						}
						goto case 234;
					case 272:
						if (num46 >= array7.Length)
						{
							result = array8;
							result2 = true;
							goto end_IL_0820;
						}
						goto case 68;
					case 249:
						if (!ulong.TryParse(obj.ToString(), out result23))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 127;
					case 67:
						if (!byte.TryParse(obj.ToString(), numberStyle, cultureInfo, out result17))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 26;
					case 76:
						if (object.ReferenceEquals(targetType, typeof(long)))
						{
							if (object.ReferenceEquals(type, typeof(int)))
							{
								result = (long)(int)obj;
								num15 = 277931149;
								continue;
							}
							goto IL_1687;
						}
						goto IL_286e;
					case 85:
						goto IL_1141;
					case 2:
						goto IL_1167;
					case 224:
						num15 = 277931209;
						continue;
					case 68:
					{
						if (TryConvertOrCreateObject(elementType, array7.GetValue(num46), out var result24, numberStyle, cultureInfo))
						{
							array8.SetValue(result24, num46);
							num15 = 277931020;
							continue;
						}
						goto case 152;
					}
					case 129:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (byte)(double)obj;
							num15 = 277931239;
							continue;
						}
						goto case 256;
					case 236:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (short)(long)obj;
							num15 = 277931250;
							continue;
						}
						goto IL_2615;
					case 152:
						num46++;
						num15 = 277931396;
						continue;
					case 208:
						if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							result = (uint)(sbyte)obj;
							num15 = 277931163;
							continue;
						}
						goto IL_24bd;
					case 122:
						if (object.ReferenceEquals(type, typeof(int)))
						{
							result = (ushort)(int)obj;
							num15 = 277931024;
							continue;
						}
						goto case 194;
					case 57:
						if (object.ReferenceEquals(type, typeof(short)))
						{
							result = (long)(short)obj;
							num15 = 277931149;
							continue;
						}
						goto case 267;
					case 210:
						if (object.ReferenceEquals(type, typeof(int)))
						{
							result = (ulong)(int)obj;
							num15 = 277931236;
							continue;
						}
						goto IL_1c95;
					case 38:
						if (object.ReferenceEquals(type, typeof(int)))
						{
							result = (decimal)(int)obj;
							num15 = 277931209;
							continue;
						}
						goto case 31;
					case 89:
						num15 = 277931236;
						continue;
					case 84:
						if (object.ReferenceEquals(targetType, typeof(short)))
						{
							if (object.ReferenceEquals(type, typeof(ushort)))
							{
								result = (short)(ushort)obj;
								num15 = 277931203;
								continue;
							}
							goto case 188;
						}
						goto case 172;
					case 140:
						if (!object.ReferenceEquals(targetType, typeof(bool)))
						{
							goto case 76;
						}
						if (object.ReferenceEquals(type, typeof(int)))
						{
							result = (int)obj > 0;
							num15 = 277931112;
							continue;
						}
						goto case 161;
					case 164:
						if (object.ReferenceEquals(type, typeof(ushort)))
						{
							result = (ushort)obj > 0;
							num15 = 277931065;
							continue;
						}
						goto case 103;
					case 254:
						goto IL_13d0;
					case 139:
						result = obj.ToString();
						num15 = 277931106;
						continue;
					case 112:
						result2 = true;
						goto end_IL_0820;
					case 220:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (ulong)(long)obj;
							num15 = 277931236;
							continue;
						}
						goto case 210;
					case 66:
						if (!long.TryParse(obj.ToString(), out result22))
						{
							result2 = false;
							num15 = 277931062;
							continue;
						}
						goto case 82;
					case 216:
						result = (short)(ulong)obj;
						num15 = 277931135;
						continue;
					case 96:
						if (!object.ReferenceEquals(type, typeof(string)))
						{
							goto case 238;
						}
						if (cultureInfo == null)
						{
							goto IL_0fe2;
						}
						if (!short.TryParse(obj.ToString(), numberStyle, cultureInfo, out result28))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 206;
					case 209:
						num15 = 277931163;
						continue;
					case 75:
						result2 = false;
						goto end_IL_0820;
					case 24:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (sbyte)(byte)obj;
							num15 = 277931189;
							continue;
						}
						goto case 148;
					case 264:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (ushort)(byte)obj;
							num15 = 277931022;
							continue;
						}
						goto case 217;
					case 182:
						goto end_IL_0820;
					case 156:
						if (object.ReferenceEquals(type, typeof(string)))
						{
							result = StringTools.ToGuid((string)obj);
							num15 = 277931090;
							continue;
						}
						goto case 205;
					case 78:
						num15 = 277931022;
						continue;
					case 98:
						num44++;
						num15 = 277931259;
						continue;
					case 221:
						result = (ulong)(sbyte)obj;
						num15 = 277931236;
						continue;
					case 269:
						if (object.ReferenceEquals(type, typeof(ulong)))
						{
							result = (decimal)(ulong)obj;
							num15 = 277931209;
							continue;
						}
						goto IL_2566;
					case 61:
						num15 = 277931203;
						continue;
					case 53:
						result = result27;
						num15 = 277931419;
						continue;
					case 151:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (ulong)(double)obj;
							num15 = 277931213;
							continue;
						}
						goto case 187;
					case 144:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (ulong)(byte)obj;
							num15 = 277931236;
							continue;
						}
						goto IL_22c0;
					case 95:
						goto IL_164f;
					case 107:
						result2 = false;
						goto end_IL_0820;
					case 241:
						goto IL_1687;
					case 145:
						num15 = 277931163;
						continue;
					case 9:
						if (!decimal.TryParse(obj.ToString(), out result18))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 142;
					case 187:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							result = (ulong)(decimal)obj;
							num15 = 277931236;
							continue;
						}
						goto case 88;
					case 232:
						goto end_IL_0820;
					case 218:
						num15 = 277931419;
						continue;
					case 234:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (ushort)(long)obj;
							num15 = 277931022;
							continue;
						}
						goto case 197;
					case 215:
						result = (byte)(ulong)obj;
						num15 = 277931239;
						continue;
					case 45:
						goto IL_176a;
					case 119:
						num15 = 277931209;
						continue;
					case 237:
						result2 = false;
						num15 = 277931066;
						continue;
					case 82:
						result = result22;
						num15 = 277931149;
						continue;
					case 250:
						if (!ReflectionTools.DoesTypeImplement(type, typeof(IList)))
						{
							goto case 114;
						}
						list7 = obj as IList;
						if (list7 == null)
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 50;
					case 229:
						goto IL_17f0;
					case 170:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (ushort)(double)obj;
							num15 = 277931022;
							continue;
						}
						goto case 219;
					case 135:
						goto IL_1843;
					case 159:
						if (!ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
						{
							goto case 250;
						}
						readOnlyList2 = obj as IReadOnlyList;
						if (readOnlyList2 == null)
						{
							result2 = false;
							num15 = 277931042;
							continue;
						}
						goto case 60;
					case 137:
						num15 = 277931209;
						continue;
					case 141:
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							result = (sbyte)(uint)obj;
							num15 = 277931161;
							continue;
						}
						goto case 79;
					case 62:
						num15 = 277931161;
						continue;
					case 185:
						goto IL_18db;
					case 80:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (double)(int)(byte)obj;
							num15 = 277931419;
							continue;
						}
						goto case 180;
					case 102:
						num15 = 277931203;
						continue;
					case 81:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (long)(byte)obj;
							num15 = 277931149;
							continue;
						}
						goto IL_23dd;
					case 162:
						goto end_IL_0820;
					case 16:
						if (!double.TryParse(obj.ToString(), out result27))
						{
							result2 = false;
							num15 = 277931079;
							continue;
						}
						goto case 53;
					case 266:
						goto IL_1993;
					case 109:
						if (object.ReferenceEquals(type, typeof(short)))
						{
							result = (double)(short)obj;
							num15 = 277931419;
							continue;
						}
						goto case 167;
					case 196:
						num15 = 277931163;
						continue;
					case 180:
						if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							result = (double)(sbyte)obj;
							num15 = 277931151;
							continue;
						}
						goto IL_17f0;
					case 225:
						result2 = false;
						goto end_IL_0820;
					case 201:
						if (!sbyte.TryParse(obj.ToString(), out result20))
						{
							result2 = false;
							num15 = 277931185;
							continue;
						}
						goto case 130;
					case 26:
						result = result17;
						num15 = 277931239;
						continue;
					case 157:
						if (object.ReferenceEquals(type, typeof(string)))
						{
							if (cultureInfo == null)
							{
								goto case 249;
							}
							goto IL_1a7d;
						}
						goto case 5;
					case 56:
						if (object.ReferenceEquals(type, typeof(int)))
						{
							result = (byte)(int)obj;
							num15 = 277931249;
							continue;
						}
						goto IL_2247;
					case 114:
						if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
						{
							array7 = obj as Array;
							array8 = Array.CreateInstance(elementType, array7.Length);
							num46 = 0;
							num15 = 277931396;
							continue;
						}
						goto IL_2980;
					case 100:
						array9 = Array.CreateInstance(elementType, serializedObject2.count);
						num47 = 0;
						num15 = 277931197;
						continue;
					case 149:
						num47++;
						num15 = 277931197;
						continue;
					case 163:
					{
						if (TryConvertOrCreateObject(elementType, serializedObject2[num47].value, out var result26, numberStyle, cultureInfo))
						{
							array9.SetValue(result26, num47);
							num15 = 277931009;
							continue;
						}
						goto case 149;
					}
					case 168:
						if (cultureInfo != null)
						{
							goto IL_1b6f;
						}
						goto case 23;
					case 31:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (decimal)(long)obj;
							num15 = 277931209;
							continue;
						}
						goto case 158;
					case 154:
						result2 = true;
						goto end_IL_0820;
					case 39:
						goto IL_1bd8;
					case 212:
						if (object.ReferenceEquals(type, typeof(float)))
						{
							result = (double)(float)obj;
							num15 = 277931419;
							continue;
						}
						goto case 43;
					case 246:
						result2 = true;
						goto end_IL_0820;
					case 247:
						num15 = 277931022;
						continue;
					case 123:
						num15 = 277931161;
						continue;
					case 34:
						result = (long)(ulong)obj;
						num15 = 277931149;
						continue;
					case 260:
						if (object.ReferenceEquals(type, typeof(float)))
						{
							result = (sbyte)(float)obj;
							num15 = 277931161;
							continue;
						}
						goto case 0;
					case 179:
						goto IL_1c95;
					case 41:
						if (num47 >= serializedObject2.count)
						{
							result = array9;
							result2 = true;
							goto end_IL_0820;
						}
						goto case 163;
					case 177:
						num15 = 277931419;
						continue;
					case 32:
						result2 = false;
						goto end_IL_0820;
					case 54:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (byte)(long)obj;
							num15 = 277931239;
							continue;
						}
						goto IL_2d7f;
					case 92:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (long)obj > 0;
							num15 = 277931410;
							continue;
						}
						goto case 213;
					case 261:
						result = (uint)(byte)obj;
						num15 = 277931077;
						continue;
					case 181:
						result2 = false;
						num15 = 277931102;
						continue;
					case 93:
						result2 = true;
						goto end_IL_0820;
					case 244:
						result2 = false;
						num15 = 277931058;
						continue;
					case 265:
						result = (long)(float)obj;
						num15 = 277931149;
						continue;
					case 59:
						if (object.ReferenceEquals(type, typeof(float)))
						{
							result = (short)(float)obj;
							num15 = 277931031;
							continue;
						}
						goto case 257;
					case 228:
						if (!object.ReferenceEquals(type, typeof(string)))
						{
							goto case 75;
						}
						if (cultureInfo == null)
						{
							goto case 66;
						}
						if (!long.TryParse(obj.ToString(), numberStyle, cultureInfo, out result22))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 82;
					case 238:
						result2 = false;
						goto end_IL_0820;
					case 87:
						result2 = true;
						goto end_IL_0820;
					case 259:
						result2 = false;
						goto end_IL_0820;
					case 153:
						goto IL_1e59;
					case 231:
						result = (byte)(uint)obj;
						num15 = 277931239;
						continue;
					case 120:
						if (num45 >= readOnlyList2.Count)
						{
							result = array6;
							result2 = true;
							goto end_IL_0820;
						}
						goto case 51;
					case 174:
						goto end_IL_0820;
					case 161:
						if (object.ReferenceEquals(type, typeof(float)))
						{
							result = (float)obj > 0f;
							num15 = 277931112;
							continue;
						}
						goto case 69;
					case 253:
						goto IL_1efd;
					case 52:
						result = (decimal)obj > 0m;
						num15 = 277931112;
						continue;
					case 192:
						goto end_IL_0820;
					case 73:
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							result = (double)(uint)obj;
							num15 = 277931045;
							continue;
						}
						goto case 90;
					case 203:
						if (!object.ReferenceEquals(type, typeof(string)))
						{
							goto case 244;
						}
						if (cultureInfo == null)
						{
							goto case 16;
						}
						goto IL_1fa5;
					case 155:
						if (cultureInfo == null)
						{
							goto case 201;
						}
						if (!sbyte.TryParse(obj.ToString(), numberStyle, cultureInfo, out result20))
						{
							result2 = false;
							num15 = 277931258;
							continue;
						}
						goto case 130;
					case 200:
						result = (long)(sbyte)obj;
						num15 = 277931149;
						continue;
					case 35:
						goto IL_200c;
					case 226:
						if (object.ReferenceEquals(type, typeof(short)))
						{
							result = (short)obj > 0;
							num15 = 277931112;
							continue;
						}
						goto case 164;
					case 133:
						if (object.ReferenceEquals(type, typeof(float)))
						{
							result = (ushort)(float)obj;
							num15 = 277931414;
							continue;
						}
						goto case 170;
					case 251:
						if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							result = (decimal)(sbyte)obj;
							num15 = 277931235;
							continue;
						}
						goto IL_1bd8;
					case 106:
						if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							result = (byte)(sbyte)obj;
							num15 = 277931239;
							continue;
						}
						goto case 56;
					case 17:
						goto IL_20ec;
					case 258:
						num15 = 277931022;
						continue;
					case 60:
						array6 = Array.CreateInstance(elementType, readOnlyList2.Count);
						num45 = 0;
						num15 = 277931182;
						continue;
					case 173:
						num15 = 277931112;
						continue;
					case 197:
						if (object.ReferenceEquals(type, typeof(ulong)))
						{
							result = (ushort)(ulong)obj;
							num15 = 277931026;
							continue;
						}
						goto case 133;
					case 69:
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							result = (uint)obj != 0;
							num15 = 277931112;
							continue;
						}
						goto case 92;
					case 10:
						goto IL_219f;
					case 91:
						if (object.ReferenceEquals(type, typeof(float)))
						{
							result = (byte)(float)obj;
							num15 = 277931239;
							continue;
						}
						goto case 129;
					case 142:
						result = result18;
						num15 = 277931209;
						continue;
					case 227:
						goto IL_2205;
					case 15:
						goto IL_222b;
					case 14:
						goto end_IL_0820;
					case 121:
						goto IL_2247;
					case 160:
						if (object.ReferenceEquals(type, typeof(ulong)))
						{
							result = (sbyte)(ulong)obj;
							num15 = 277931161;
							continue;
						}
						goto case 260;
					case 1:
						goto IL_229a;
					case 19:
						goto IL_22c0;
					case 63:
						num15 = 277931163;
						continue;
					case 146:
						if (!ushort.TryParse(obj.ToString(), out result16))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 7;
					case 166:
						goto end_IL_0820;
					case 11:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							result = (uint)(decimal)obj;
							num15 = 277931163;
							continue;
						}
						goto IL_18db;
					case 46:
						goto end_IL_0820;
					case 158:
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							result = (decimal)(uint)obj;
							num15 = 277931209;
							continue;
						}
						goto case 269;
					case 58:
						num15 = 277931244;
						continue;
					case 134:
						num15 = 277931022;
						continue;
					case 108:
						goto end_IL_0820;
					case 3:
						result = (decimal)(short)obj;
						num15 = 277931071;
						continue;
					case 104:
						num15 = 277931161;
						continue;
					case 239:
						goto IL_23dd;
					case 79:
						if (object.ReferenceEquals(type, typeof(long)))
						{
							result = (sbyte)(long)obj;
							num15 = 277931178;
							continue;
						}
						goto case 160;
					case 83:
						goto IL_2430;
					case 47:
						num15 = 277931149;
						continue;
					case 267:
						if (object.ReferenceEquals(type, typeof(ushort)))
						{
							result = (long)(ushort)obj;
							num15 = 277931149;
							continue;
						}
						goto case 81;
					case 230:
						goto IL_248d;
					case 33:
						num15 = 277931161;
						continue;
					case 186:
						goto IL_24bd;
					case 36:
						if (string.Equals((string)obj, "false", StringComparison.OrdinalIgnoreCase))
						{
							result = false;
							num15 = 277931112;
							continue;
						}
						goto case 237;
					case 125:
						result = (short)(sbyte)obj;
						num15 = 277931203;
						continue;
					case 256:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							result = (byte)(decimal)obj;
							num15 = 277931239;
							continue;
						}
						goto IL_1843;
					case 127:
						result = result23;
						num15 = 277931236;
						continue;
					case 65:
						goto IL_2566;
					case 42:
						result2 = false;
						num15 = 277931111;
						continue;
					case 111:
						if (num44 >= list7.Count)
						{
							result = array5;
							result2 = true;
							goto end_IL_0820;
						}
						goto case 86;
					case 243:
						goto end_IL_0820;
					case 271:
						result2 = true;
						goto end_IL_0820;
					case 28:
						num15 = 277931236;
						continue;
					case 167:
						if (object.ReferenceEquals(type, typeof(ushort)))
						{
							result = (double)(int)(ushort)obj;
							num15 = 277931086;
							continue;
						}
						goto case 80;
					case 191:
						goto IL_2615;
					case 240:
						num15 = 277931149;
						continue;
					case 48:
						if (cultureInfo == null)
						{
							goto case 9;
						}
						if (!decimal.TryParse(obj.ToString(), numberStyle, cultureInfo, out result18))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 142;
					case 136:
						if (!byte.TryParse(obj.ToString(), out result17))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 26;
					case 169:
						if (cultureInfo == null)
						{
							goto case 146;
						}
						if (!ushort.TryParse(obj.ToString(), numberStyle, cultureInfo, out result16))
						{
							result2 = false;
							num15 = 277931256;
							continue;
						}
						goto case 7;
					case 74:
						num15 = 277931163;
						continue;
					case 13:
						result2 = true;
						goto end_IL_0820;
					case 172:
						if (object.ReferenceEquals(targetType, typeof(ushort)))
						{
							if (object.ReferenceEquals(type, typeof(short)))
							{
								result = (ushort)(short)obj;
								num15 = 277931226;
								continue;
							}
							goto case 122;
						}
						goto IL_2b2f;
					case 268:
						result = (short)(byte)obj;
						num15 = 277931177;
						continue;
					case 55:
						goto IL_2735;
					case 195:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							result = (long)(decimal)obj;
							num15 = 277931195;
							continue;
						}
						goto case 57;
					case 199:
						result = (sbyte)(decimal)obj;
						num15 = 277931161;
						continue;
					case 110:
						goto end_IL_0820;
					case 105:
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							result = (decimal)(byte)obj;
							num15 = 277931037;
							continue;
						}
						goto case 251;
					case 219:
						if (object.ReferenceEquals(type, typeof(decimal)))
						{
							result = (ushort)(decimal)obj;
							num15 = 277931022;
							continue;
						}
						goto case 264;
					case 117:
						result = (sbyte)obj > 0;
						num15 = 277931112;
						continue;
					case 242:
						result2 = false;
						num15 = 277931225;
						continue;
					case 262:
						num15 = 277931112;
						continue;
					case 23:
						if (!uint.TryParse(obj.ToString(), out result25))
						{
							result2 = false;
							goto end_IL_0820;
						}
						goto case 147;
					case 223:
						goto IL_286e;
					case 263:
						if (!object.ReferenceEquals(type, typeof(string)))
						{
							goto case 259;
						}
						goto IL_28a9;
					case 193:
						if (object.ReferenceEquals(type, typeof(string)))
						{
							if (string.Equals((string)obj, "true", StringComparison.OrdinalIgnoreCase))
							{
								result = true;
								num15 = 277931112;
								continue;
							}
							goto case 36;
						}
						goto case 242;
					case 115:
						result2 = true;
						goto end_IL_0820;
					case 20:
						result = (byte)(short)obj;
						num15 = 277931239;
						continue;
					case 255:
						result2 = false;
						num15 = 277931132;
						continue;
					case 4:
						result2 = false;
						goto end_IL_0820;
					case 12:
						goto IL_2947;
					case 206:
						result = result28;
						num15 = 277931203;
						continue;
					case 184:
						goto IL_2980;
					case 21:
						if (object.ReferenceEquals(type, typeof(ulong)))
						{
							result = (uint)(ulong)obj;
							num15 = 277931013;
							continue;
						}
						goto case 143;
					case 7:
						result = result16;
						num15 = 277931099;
						continue;
					case 77:
						goto end_IL_0820;
					case 147:
						result = result25;
						num15 = 277931163;
						continue;
					case 245:
						goto IL_2a13;
					case 86:
					{
						if (TryConvertOrCreateObject(elementType, list7[num44], out var result19, numberStyle, cultureInfo))
						{
							array5.SetValue(result19, num44);
							num15 = 277931254;
							continue;
						}
						goto case 98;
					}
					case 204:
						num44 = 0;
						num15 = 277931259;
						continue;
					case 30:
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							result = (ulong)(uint)obj;
							num15 = 277931236;
							continue;
						}
						goto case 151;
					case 148:
						if (object.ReferenceEquals(type, typeof(int)))
						{
							result = (sbyte)(int)obj;
							num15 = 277931161;
							continue;
						}
						goto case 141;
					case 176:
						result = (uint)(long)obj;
						num15 = 277931164;
						continue;
					case 202:
						goto end_IL_0820;
					case 71:
						result = (decimal)(double)obj;
						num15 = 277931050;
						continue;
					case 205:
						result2 = false;
						goto end_IL_0820;
					case 101:
						num15 = 277931239;
						continue;
					case 248:
						goto IL_2b2f;
					case 217:
						if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							result = (ushort)(sbyte)obj;
							num15 = 277931022;
							continue;
						}
						goto IL_13d0;
					case 150:
						if (object.ReferenceEquals(type, typeof(ushort)))
						{
							result = (sbyte)(ushort)obj;
							num15 = 277931161;
							continue;
						}
						goto IL_200c;
					case 0:
						if (object.ReferenceEquals(type, typeof(double)))
						{
							result = (sbyte)(double)obj;
							num15 = 277931247;
							continue;
						}
						goto IL_1993;
					case 50:
						array5 = Array.CreateInstance(elementType, list7.Count);
						num15 = 277931096;
						continue;
					case 18:
						if (object.ReferenceEquals(type, typeof(ulong)))
						{
							result = (double)(ulong)obj;
							num15 = 277931419;
							continue;
						}
						goto case 109;
					case 113:
						result = (ulong)(float)obj;
						num15 = 277931236;
						continue;
					case 138:
						if (object.ReferenceEquals(type, typeof(uint)))
						{
							result = (long)(uint)obj;
							num15 = 277931108;
							continue;
						}
						goto case 72;
					case 211:
						goto end_IL_0820;
					case 5:
						result2 = false;
						goto end_IL_0820;
					case 165:
						goto IL_2c8a;
					case 51:
					{
						if (TryConvertOrCreateObject(elementType, readOnlyList2[num45], out var result21, numberStyle, cultureInfo))
						{
							array6.SetValue(result21, num45);
							num15 = 277931082;
							continue;
						}
						goto case 222;
					}
					case 128:
						num15 = 277931163;
						continue;
					case 132:
						num15 = 277931022;
						continue;
					case 27:
						num15 = 277931419;
						continue;
					case 189:
						result = (decimal)(float)obj;
						num15 = 277931124;
						continue;
					case 25:
						result2 = true;
						num15 = 277931092;
						continue;
					case 118:
						if (object.ReferenceEquals(type, typeof(ushort)))
						{
							result = (decimal)(ushort)obj;
							num15 = 277931209;
							continue;
						}
						goto case 105;
					case 131:
						num15 = 277931203;
						continue;
					case 116:
						num15 = 277931149;
						continue;
					case 130:
						result = result20;
						num15 = 277931260;
						continue;
					case 175:
						goto IL_2d7f;
					case 44:
						goto IL_2da5;
					case 178:
						result = (uint)(short)obj;
						num15 = 277931088;
						continue;
					default:
					{
						Array array4 = Array.CreateInstance(elementType, dictionary3.Count);
						int num40 = 0;
						enumerator = dictionary3.Values.GetEnumerator();
						try
						{
							while (true)
							{
								IL_2e63:
								int num41;
								int num42;
								if (enumerator.MoveNext())
								{
									num41 = 277931159;
									num42 = num41;
								}
								else
								{
									num41 = 277931152;
									num42 = num41;
								}
								while (true)
								{
									switch (num41 ^ 0x1090E494)
									{
									case 2:
										num41 = 277931159;
										continue;
									default:
										goto end_IL_2e0a;
									case 3:
									{
										object current5 = enumerator.Current;
										if (TryConvertOrCreateObject(targetType2, current5, out var result15, numberStyle, cultureInfo))
										{
											array4.SetValue(result15, num40);
											num41 = 277931156;
											continue;
										}
										break;
									}
									case 0:
										num40++;
										num41 = 277931157;
										continue;
									case 1:
										break;
									case 4:
										goto end_IL_2e0a;
									}
									goto IL_2e63;
									continue;
									end_IL_2e0a:
									break;
								}
								break;
							}
						}
						finally
						{
							if (enumerator is IDisposable disposable3)
							{
								while (true)
								{
									IL_2e8c:
									int num43 = 277931157;
									while (true)
									{
										switch (num43 ^ 0x1090E494)
										{
										case 0:
											break;
										default:
											goto end_IL_2e91;
										case 1:
											goto IL_2eaa;
										case 2:
											goto end_IL_2e91;
										}
										goto IL_2e8c;
										IL_2eaa:
										disposable3.Dispose();
										num43 = 277931158;
										continue;
										end_IL_2e91:
										break;
									}
									break;
								}
							}
						}
						result = array4;
						result2 = true;
						goto end_IL_0820;
					}
					}
					int num48;
					if (!object.ReferenceEquals(type, typeof(short)))
					{
						num15 = 277931010;
						num48 = num15;
					}
					else
					{
						num15 = 277931218;
						num48 = num15;
					}
					continue;
					IL_2da5:
					int num49;
					if (!object.ReferenceEquals(type, typeof(byte)))
					{
						num15 = 277931076;
						num49 = num15;
					}
					else
					{
						num15 = 277931409;
						num49 = num15;
					}
					continue;
					IL_2247:
					int num50;
					if (object.ReferenceEquals(type, typeof(uint)))
					{
						num15 = 277931123;
						num50 = num15;
					}
					else
					{
						num15 = 277931170;
						num50 = num15;
					}
					continue;
					IL_2980:
					if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
					{
						targetType2 = ReflectionTools.GetGenericArguments(targetType)[1];
						dictionary3 = obj as IDictionary;
						num15 = 277931074;
						continue;
					}
					goto IL_2ee3;
					IL_2c8a:
					int num51;
					if (object.ReferenceEquals(type, typeof(ushort)))
					{
						num15 = 277931210;
						num51 = num15;
					}
					else
					{
						num15 = 277931192;
						num51 = num15;
					}
					continue;
					IL_22c0:
					int num52;
					if (!object.ReferenceEquals(type, typeof(sbyte)))
					{
						num15 = 277931017;
						num52 = num15;
					}
					else
					{
						num15 = 277931081;
						num52 = num15;
					}
					continue;
					IL_286e:
					int num53;
					if (object.ReferenceEquals(targetType, typeof(ulong)))
					{
						num15 = 277931080;
						num53 = num15;
					}
					else
					{
						num15 = 277931200;
						num53 = num15;
					}
					continue;
					IL_2947:
					int num54;
					if (!object.ReferenceEquals(targetType, typeof(sbyte)))
					{
						num15 = 277931171;
						num54 = num15;
					}
					else
					{
						num15 = 277931148;
						num54 = num15;
					}
					continue;
					IL_176a:
					int num55;
					if (object.ReferenceEquals(type, typeof(byte)))
					{
						num15 = 277931416;
						num55 = num15;
					}
					else
					{
						num15 = 277931141;
						num55 = num15;
					}
					continue;
					IL_1c95:
					int num56;
					if (!object.ReferenceEquals(type, typeof(float)))
					{
						num15 = 277931146;
						num56 = num15;
					}
					else
					{
						num15 = 277931237;
						num56 = num15;
					}
					continue;
					IL_28a9:
					int num57;
					if (cultureInfo != null)
					{
						num15 = 277931223;
						num57 = num15;
					}
					else
					{
						num15 = 277931036;
						num57 = num15;
					}
					continue;
					IL_1a7d:
					int num58;
					if (ulong.TryParse(obj.ToString(), numberStyle, cultureInfo, out result23))
					{
						num15 = 277931243;
						num58 = num15;
					}
					else
					{
						num15 = 277931125;
						num58 = num15;
					}
					continue;
					IL_1b6f:
					int num59;
					if (!uint.TryParse(obj.ToString(), numberStyle, cultureInfo, out result25))
					{
						num15 = 277931041;
						num59 = num15;
					}
					else
					{
						num15 = 277931015;
						num59 = num15;
					}
					continue;
					IL_2735:
					int num60;
					if (!object.ReferenceEquals(targetType, typeof(decimal)))
					{
						num15 = 277931158;
						num60 = num15;
					}
					else
					{
						num15 = 277931166;
						num60 = num15;
					}
					continue;
					IL_24bd:
					int num61;
					if (object.ReferenceEquals(type, typeof(string)))
					{
						num15 = 277931068;
						num61 = num15;
					}
					else
					{
						num15 = 277931152;
						num61 = num15;
					}
					continue;
					IL_1167:
					int num62;
					if (!object.ReferenceEquals(targetType, typeof(char)))
					{
						num15 = 277931021;
						num62 = num15;
					}
					else
					{
						num15 = 277931039;
						num62 = num15;
					}
					continue;
					IL_2430:
					int num63;
					if (object.ReferenceEquals(type, typeof(float)))
					{
						num15 = 277931421;
						num63 = num15;
					}
					else
					{
						num15 = 277931038;
						num63 = num15;
					}
					continue;
					IL_2a13:
					int num64;
					if (object.ReferenceEquals(type, typeof(decimal)))
					{
						num15 = 277931168;
						num64 = num15;
					}
					else
					{
						num15 = 277931126;
						num64 = num15;
					}
					continue;
					IL_1141:
					int num65;
					if (!object.ReferenceEquals(type, typeof(ushort)))
					{
						num15 = 277931411;
						num65 = num15;
					}
					else
					{
						num15 = 277931173;
						num65 = num15;
					}
					continue;
					IL_2205:
					int num66;
					if (!object.ReferenceEquals(type, typeof(double)))
					{
						num15 = 277931186;
						num66 = num15;
					}
					else
					{
						num15 = 277931219;
						num66 = num15;
					}
					continue;
					IL_13d0:
					int num67;
					if (!object.ReferenceEquals(type, typeof(string)))
					{
						num15 = 277931198;
						num67 = num15;
					}
					else
					{
						num15 = 277931069;
						num67 = num15;
					}
					continue;
					IL_1687:
					int num68;
					if (!object.ReferenceEquals(type, typeof(ulong)))
					{
						num15 = 277931207;
						num68 = num15;
					}
					else
					{
						num15 = 277931190;
						num68 = num15;
					}
					continue;
					IL_219f:
					int num69;
					if (object.ReferenceEquals(type, typeof(float)))
					{
						num15 = 277931049;
						num69 = num15;
					}
					else
					{
						num15 = 277931127;
						num69 = num15;
					}
					continue;
					IL_17f0:
					int num70;
					if (object.ReferenceEquals(type, typeof(decimal)))
					{
						num15 = 277931240;
						num70 = num15;
					}
					else
					{
						num15 = 277931103;
						num70 = num15;
					}
					continue;
					IL_0fe2:
					int num71;
					if (!short.TryParse(obj.ToString(), out result28))
					{
						num15 = 277931115;
						num71 = num15;
					}
					else
					{
						num15 = 277931098;
						num71 = num15;
					}
					continue;
					IL_20ec:
					int num72;
					if (!object.ReferenceEquals(type, typeof(sbyte)))
					{
						num15 = 277931252;
						num72 = num15;
					}
					else
					{
						num15 = 277931241;
						num72 = num15;
					}
					continue;
					IL_1bd8:
					int num73;
					if (object.ReferenceEquals(type, typeof(string)))
					{
						num15 = 277931172;
						num73 = num15;
					}
					else
					{
						num15 = 277931133;
						num73 = num15;
					}
					continue;
					IL_229a:
					int num74;
					if (!object.ReferenceEquals(type, typeof(sbyte)))
					{
						num15 = 277931093;
						num74 = num15;
					}
					else
					{
						num15 = 277931233;
						num74 = num15;
					}
					continue;
					IL_200c:
					int num75;
					if (object.ReferenceEquals(type, typeof(string)))
					{
						num15 = 277931023;
						num75 = num15;
					}
					else
					{
						num15 = 277931188;
						num75 = num15;
					}
					continue;
					IL_0f0f:
					if (ReflectionTools.IsArray(targetType))
					{
						elementType = targetType.GetElementType();
						int num76;
						if (!ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
						{
							num15 = 277931019;
							num76 = num15;
						}
						else
						{
							num15 = 277931145;
							num76 = num15;
						}
						continue;
					}
					goto IL_32b3;
					IL_2615:
					int num77;
					if (object.ReferenceEquals(type, typeof(ulong)))
					{
						num15 = 277931084;
						num77 = num15;
					}
					else
					{
						num15 = 277931183;
						num77 = num15;
					}
					continue;
					IL_1fa5:
					int num78;
					if (!double.TryParse(obj.ToString(), numberStyle, cultureInfo, out result27))
					{
						num15 = 277931263;
						num78 = num15;
					}
					else
					{
						num15 = 277931169;
						num78 = num15;
					}
					continue;
					IL_23dd:
					int num79;
					if (!object.ReferenceEquals(type, typeof(sbyte)))
					{
						num15 = 277931120;
						num79 = num15;
					}
					else
					{
						num15 = 277931100;
						num79 = num15;
					}
					continue;
					IL_2b2f:
					int num80;
					if (object.ReferenceEquals(targetType, typeof(byte)))
					{
						num15 = 277931262;
						num80 = num15;
					}
					else
					{
						num15 = 277931160;
						num80 = num15;
					}
					continue;
					IL_1e59:
					int num81;
					if (!object.ReferenceEquals(targetType, typeof(Guid)))
					{
						num15 = 277931220;
						num81 = num15;
					}
					else
					{
						num15 = 277931016;
						num81 = num15;
					}
					continue;
					IL_18db:
					int num82;
					if (object.ReferenceEquals(type, typeof(short)))
					{
						num15 = 277931046;
						num82 = num15;
					}
					else
					{
						num15 = 277931057;
						num82 = num15;
					}
					continue;
					IL_1843:
					int num83;
					if (object.ReferenceEquals(type, typeof(short)))
					{
						num15 = 277931136;
						num83 = num15;
					}
					else
					{
						num15 = 277931201;
						num83 = num15;
					}
					continue;
					IL_2d7f:
					int num84;
					if (object.ReferenceEquals(type, typeof(ulong)))
					{
						num15 = 277931075;
						num84 = num15;
					}
					else
					{
						num15 = 277931215;
						num84 = num15;
					}
					continue;
					IL_2566:
					int num85;
					if (object.ReferenceEquals(type, typeof(short)))
					{
						num15 = 277931159;
						num85 = num15;
					}
					else
					{
						num15 = 277931234;
						num85 = num15;
					}
					continue;
					IL_1993:
					int num86;
					if (!object.ReferenceEquals(type, typeof(decimal)))
					{
						num15 = 277931138;
						num86 = num15;
					}
					else
					{
						num15 = 277931091;
						num86 = num15;
					}
					continue;
					end_IL_0820:
					break;
				}
				end_IL_007c:;
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				goto IL_3880;
			}
			return result2;
			IL_3880:
			return false;
		}

		private static bool TryCreateObject(Type type, SerializedObject serializedObject, out object result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			if (serializedObject == null)
			{
				goto IL_002b;
			}
			if ((object)type == null)
			{
				goto IL_0006;
			}
			result = Factory.CreateInstance(type);
			Dictionary<string, FieldInfo> value = default(Dictionary<string, FieldInfo>);
			int num;
			if (!qIsdjfNUTaMkNdoFvCeoEzYWORs.TryGetValue(type, out value))
			{
				value = (from field in ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
					where (field.IsPublic || field.IsDefined(typeof(SerializeAttribute), inherit: true) || field.IsDefined(typeof(SerializeField), inherit: true)) && !field.IsDefined(typeof(NonSerializedAttribute), inherit: true) && !field.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
					select field).ToDictionary((FieldInfo field) =>
				{
					string name2;
					return (field.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(field.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name2 : field.Name;
				});
				qIsdjfNUTaMkNdoFvCeoEzYWORs.Add(type, value);
				num = 1999867240;
				goto IL_000b;
			}
			goto IL_00ab;
			IL_011d:
			Dictionary<string, PropertyInfo> value4 = default(Dictionary<string, PropertyInfo>);
			using (IEnumerator<Field> enumerator = ((IEnumerable<Field>)serializedObject).GetEnumerator())
			{
				object value2 = default(object);
				string name = default(string);
				while (enumerator.MoveNext())
				{
					while (true)
					{
						Field current = enumerator.Current;
						int num2 = 1999867241;
						while (true)
						{
							object result2;
							switch (num2 ^ 0x77338D6B)
							{
							case 0:
								num2 = 1999867247;
								continue;
							case 6:
							{
								value2 = current.value;
								if (value.TryGetValue(name, out var value3))
								{
									if (TryConvertOrCreateObject(value3.FieldType, value2, out result2, numberStyle, cultureInfo))
									{
										value3.SetValue(result, result2);
										num2 = 1999867246;
										continue;
									}
									goto end_IL_01ac;
								}
								goto case 3;
							}
							case 2:
								name = current.name;
								num2 = 1999867245;
								continue;
							case 5:
								num2 = 1999867242;
								continue;
							case 4:
								break;
							case 3:
							{
								if (value4.TryGetValue(name, out var value5) && value5.CanWrite && TryConvertOrCreateObject(value5.PropertyType, value2, out result2, numberStyle, cultureInfo))
								{
									value5.SetValue(result, result2, null);
									num2 = 1999867242;
									continue;
								}
								goto end_IL_01ac;
							}
							default:
								goto end_IL_01ac;
							}
							break;
						}
						continue;
						end_IL_01ac:
						break;
					}
				}
			}
			if (result is ISerializationCallbackReceiver serializationCallbackReceiver)
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
			return true;
			IL_00ab:
			if (!COxHPvYShQwVlvoLrQUKoILVDrf.TryGetValue(type, out value4))
			{
				value4 = (from p in ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
					where p.CanWrite && p.IsDefined(typeof(SerializeAttribute), inherit: true) && !p.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
					select p).ToDictionary((PropertyInfo p) =>
				{
					string name2;
					return (p.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(p.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name2 : p.Name;
				});
				COxHPvYShQwVlvoLrQUKoILVDrf.Add(type, value4);
				num = 1999867243;
				goto IL_000b;
			}
			goto IL_011d;
			IL_0006:
			num = 1999867242;
			goto IL_000b;
			IL_002b:
			result = null;
			return false;
			IL_000b:
			switch (num ^ 0x77338D6B)
			{
			case 2:
				break;
			case 1:
				goto IL_002b;
			case 3:
				goto IL_00ab;
			default:
				goto IL_011d;
			}
			goto IL_0006;
		}

		public static SerializedObject FromJson(Type type, string jsonString)
		{
			if ((object)type == null)
			{
				goto IL_0006;
			}
			goto IL_009c;
			IL_0006:
			int num = 989802167;
			goto IL_000b;
			IL_000b:
			SerializedObject serializedObject = default(SerializedObject);
			while (true)
			{
				switch (num ^ 0x3AFF2EB3)
				{
				case 5:
					break;
				case 4:
					throw new ArgumentNullException("type");
				case 6:
					goto IL_0049;
				case 0:
					throw new Exception("No data found in Json string.");
				case 3:
					goto IL_0074;
				case 1:
					goto IL_009c;
				default:
					return serializedObject;
				}
				break;
				IL_0049:
				int num2;
				if (serializedObject.count == 0)
				{
					num = 989802163;
					num2 = num;
				}
				else
				{
					num = 989802161;
					num2 = num;
				}
			}
			goto IL_0006;
			IL_0074:
			serializedObject = JsonParser.FromJson<SerializedObject>(jsonString, typeof(SerializedObject));
			int num3;
			if (serializedObject != null)
			{
				num = 989802165;
				num3 = num;
			}
			else
			{
				num = 989802163;
				num3 = num;
			}
			goto IL_000b;
			IL_009c:
			if (string.IsNullOrEmpty(jsonString))
			{
				throw new ArgumentNullException("jsonString");
			}
			goto IL_0074;
		}

		public static SerializedObject FromXml(Type type, string xmlString)
		{
			if ((object)type == null)
			{
				goto IL_0006;
			}
			goto IL_00d7;
			IL_0006:
			int num = -1108188459;
			goto IL_000b;
			IL_000b:
			SerializedObject serializedObject = default(SerializedObject);
			switch (num ^ -1108188464)
			{
			case 0:
				break;
			case 1:
				goto IL_003f;
			case 2:
				goto IL_0061;
			case 8:
				goto IL_0082;
			case 5:
				throw new ArgumentNullException("type");
			case 4:
				goto IL_00c2;
			case 7:
				goto IL_00d7;
			case 3:
				goto IL_00f4;
			default:
				return serializedObject;
			}
			goto IL_0006;
			IL_00c2:
			throw new Exception("No data found in XML string.");
			IL_00d7:
			if (string.IsNullOrEmpty(xmlString))
			{
				throw new ArgumentNullException("xmlString");
			}
			goto IL_0061;
			IL_0061:
			XmlDocument xmlDocument = new XmlDocument(xmlString);
			if (!xmlDocument.isValid)
			{
				throw new Exception("Failed to parse XML string.");
			}
			goto IL_003f;
			IL_003f:
			if (xmlDocument.root.childCount == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			goto IL_00f4;
			IL_00f4:
			XmlDocument.Element element = xmlDocument.root.FindChild(type.Name);
			if (element == null)
			{
				throw new Exception("Main element not found in XML string.");
			}
			goto IL_0082;
			IL_0082:
			serializedObject = element.GetSerializedObject() as SerializedObject;
			if (serializedObject != null)
			{
				int num2;
				if (serializedObject.count == 0)
				{
					num = -1108188460;
					num2 = num;
				}
				else
				{
					num = -1108188458;
					num2 = num;
				}
				goto IL_000b;
			}
			goto IL_00c2;
		}
	}
}
