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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	[Preserve]
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

		[CustomObfuscation(rename = false)]
		[Flags]
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
				text = text + "type = " + ((type != null) ? type.Name : "NULL") + "\n";
				text = text + "value = " + ((value != null) ? value.ToString() : "NULL") + "\n";
				object[] array = default(object[]);
				while (true)
				{
					int num = 1496978904;
					while (true)
					{
						switch (num ^ 0x593A15DA)
						{
						case 0:
							break;
						case 2:
						{
							object obj = text;
							array = new object[4] { obj, null, null, null };
							num = 1496978905;
							continue;
						}
						case 3:
							array[1] = "options = ";
							num = 1496978907;
							continue;
						default:
							array[2] = options;
							array[3] = "\n";
							return string.Concat(array);
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
				object[] array = default(object[]);
				object obj = default(object);
				while (true)
				{
					int num = -1338562455;
					while (true)
					{
						string text2;
						string obj2;
						switch (num ^ -1338562453)
						{
						case 0:
							break;
						case 2:
							text = text + "value = " + ((value != null) ? value.ToString() : "NULL") + "\n";
							text2 = text;
							obj2 = ((type != null) ? type.Name : "NULL");
							goto IL_008e;
						default:
							array[0] = obj;
							array[1] = "options = ";
							array[2] = options;
							array[3] = "\n";
							return string.Concat(array);
						}
						break;
						IL_008e:
						text = text2 + "type = " + obj2 + "\n";
						obj = text;
						array = new object[4];
						num = -1338562454;
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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

			private List<XmlAttribute> GJHtXewcRYthYfwNaufiDGXRdSu;

			public List<XmlAttribute> attributes
			{
				get
				{
					return GJHtXewcRYthYfwNaufiDGXRdSu ?? (GJHtXewcRYthYfwNaufiDGXRdSu = new List<XmlAttribute>());
				}
			}

			public override string ToString()
			{
				string text = "Attributes:\n";
				int num2 = default(int);
				while (true)
				{
					int num = -1293508873;
					while (true)
					{
						switch (num ^ -1293508874)
						{
						case 2:
							break;
						case 0:
						{
							int num3;
							if (num2 < GJHtXewcRYthYfwNaufiDGXRdSu.Count)
							{
								num = -1293508875;
								num3 = num;
							}
							else
							{
								num = -1293508878;
								num3 = num;
							}
							continue;
						}
						case 3:
							text = text + GJHtXewcRYthYfwNaufiDGXRdSu[num2].ToString() + "\n";
							num2++;
							num = -1293508874;
							continue;
						case 1:
							if (GJHtXewcRYthYfwNaufiDGXRdSu != null)
							{
								num2 = 0;
								num = -1293508874;
								continue;
							}
							goto default;
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
		public struct Enumerator : IDisposable, IEnumerator, IEnumerator<Field>
		{
			private IndexedDictionary<string, Entry> LbwQyRfKuLNxSjFIaAsDJTuLixL;

			private Field xbRrcEKKIAKiQkVzQCekOswVHrJ;

			private IEnumerator<KeyValuePair<string, Entry>> IkPdsmfCAFYyoVaHwofaSiapYaf;

			public Field Current
			{
				get
				{
					return xbRrcEKKIAKiQkVzQCekOswVHrJ;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return xbRrcEKKIAKiQkVzQCekOswVHrJ;
				}
			}

			internal Enumerator(object dictionary)
			{
				LbwQyRfKuLNxSjFIaAsDJTuLixL = (IndexedDictionary<string, Entry>)dictionary;
				xbRrcEKKIAKiQkVzQCekOswVHrJ = default(Field);
				IkPdsmfCAFYyoVaHwofaSiapYaf = LbwQyRfKuLNxSjFIaAsDJTuLixL.GetEnumerator();
			}

			public bool MoveNext()
			{
				if (!IkPdsmfCAFYyoVaHwofaSiapYaf.MoveNext())
				{
					return false;
				}
				KeyValuePair<string, Entry> current = IkPdsmfCAFYyoVaHwofaSiapYaf.Current;
				xbRrcEKKIAKiQkVzQCekOswVHrJ = new Field(current.Key, current.Value.value, current.Value.type, current.Value.options);
				return true;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				xbRrcEKKIAKiQkVzQCekOswVHrJ = default(Field);
				IkPdsmfCAFYyoVaHwofaSiapYaf = LbwQyRfKuLNxSjFIaAsDJTuLixL.GetEnumerator();
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
					if (parent != null)
					{
						parent.AddChild(this);
					}
				}

				public void AddChild(Element element)
				{
					if (element == null)
					{
						return;
					}
					while (true)
					{
						int num;
						int num2;
						if (children != null)
						{
							num = -2045556206;
							num2 = num;
						}
						else
						{
							num = -2045556205;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -2045556206)
							{
							case 3:
								num = -2045556208;
								continue;
							case 2:
								break;
							case 1:
								children = new List<Element>();
								num = -2045556206;
								continue;
							default:
								children.Add(element);
								return;
							}
							break;
						}
					}
				}

				public void AddAttribute(string key, string value)
				{
					if (string.IsNullOrEmpty(key))
					{
						return;
					}
					while (true)
					{
						int num;
						if (attributes == null)
						{
							attributes = new Dictionary<string, string>();
							num = 794701998;
							goto IL_000e;
						}
						goto IL_0049;
						IL_000e:
						while (true)
						{
							switch (num ^ 0x2F5E30AF)
							{
							case 0:
								num = 794701997;
								continue;
							case 2:
								break;
							case 1:
								goto IL_0049;
							case 4:
								attributes[key] = value;
								return;
							default:
								attributes.Add(key, value);
								return;
							}
							break;
						}
						continue;
						IL_0049:
						int num2;
						if (attributes.ContainsKey(key))
						{
							num = 794701995;
							num2 = num;
						}
						else
						{
							num = 794701996;
							num2 = num;
						}
						goto IL_000e;
					}
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
							int num2;
							if (string.Equals(children[num].name, name, StringComparison.Ordinal))
							{
								num2 = 1402946455;
							}
							else
							{
								num++;
								num2 = 1402946454;
							}
							while (true)
							{
								switch (num2 ^ 0x539F4394)
								{
								case 0:
									num2 = 1402946453;
									continue;
								case 1:
									break;
								case 3:
									return children[num];
								default:
									goto end_IL_0030;
								}
								break;
							}
							continue;
							end_IL_0030:
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
					while (num < childCount)
					{
						while (true)
						{
							Element element = children[num];
							int num2 = -601758857;
							while (true)
							{
								switch (num2 ^ -601758859)
								{
								case 0:
									num2 = -601758858;
									continue;
								case 3:
									break;
								case 2:
									if (element != null)
									{
										serializedObject.Add(element.name, element.GetSerializedObject());
										num2 = -601758863;
										continue;
									}
									goto case 4;
								case 4:
									num++;
									num2 = -601758860;
									continue;
								default:
									goto end_IL_0041;
								}
								break;
							}
							continue;
							end_IL_0041:
							break;
						}
					}
					return serializedObject;
				}

				public override string ToString()
				{
					return ToString("", 0);
				}

				private string ToString(string s, int indent)
				{
					string text = "";
					int num = 0;
					string[] array3 = default(string[]);
					string[] array4 = default(string[]);
					object[] array2 = default(object[]);
					object obj = default(object);
					string text5 = default(string);
					while (true)
					{
						int num2;
						int num3;
						if (num < indent)
						{
							num2 = 644181323;
							num3 = num2;
						}
						else
						{
							num2 = 644181325;
							num3 = num2;
						}
						while (true)
						{
							object obj2;
							switch (num2 ^ 0x26656D48)
							{
							case 7:
								num2 = 644181323;
								continue;
							case 4:
							{
								string text4 = s;
								array3 = new string[5]
								{
									text4,
									text,
									"Content = ",
									(content == null) ? "NULL" : content.ToString(),
									"\n"
								};
								num2 = 644181322;
								continue;
							}
							case 1:
								array4[1] = text;
								array4[2] = "Name = ";
								array4[3] = name;
								array4[4] = "\n";
								s = string.Concat(array4);
								num2 = 644181324;
								continue;
							case 0:
								s = string.Concat(array2);
								if (attributes != null)
								{
									num2 = 644181313;
									continue;
								}
								goto IL_026a;
							case 5:
							{
								string text3 = s;
								array4 = new string[5] { text3, null, null, null, null };
								num2 = 644181321;
								continue;
							}
							case 2:
								s = string.Concat(array3);
								obj = s;
								num2 = 644181326;
								continue;
							case 6:
								array2 = new object[5] { obj, text, "Attribute Count = ", attributeCount, "\n" };
								num2 = 644181320;
								continue;
							case 3:
								text += "    ";
								num++;
								num2 = 644181312;
								continue;
							case 8:
								break;
							default:
								{
									using (Dictionary<string, string>.Enumerator enumerator = attributes.GetEnumerator())
									{
										while (enumerator.MoveNext())
										{
											while (true)
											{
												KeyValuePair<string, string> current = enumerator.Current;
												string text2 = s;
												string[] array = new string[7] { text2, null, null, null, null, null, null };
												int num4 = 644181323;
												while (true)
												{
													switch (num4 ^ 0x26656D48)
													{
													case 2:
														num4 = 644181325;
														continue;
													case 6:
														array[3] = current.Key;
														array[4] = ": = ";
														array[5] = current.Value;
														num4 = 644181321;
														continue;
													case 3:
														array[1] = text;
														num4 = 644181324;
														continue;
													case 4:
														array[2] = "Attribute ";
														num4 = 644181326;
														continue;
													case 1:
														array[6] = "\n";
														s = string.Concat(array);
														num4 = 644181320;
														continue;
													case 5:
														break;
													default:
														goto end_IL_022e;
													}
													break;
												}
												continue;
												end_IL_022e:
												break;
											}
										}
									}
									goto IL_026a;
								}
								IL_026a:
								obj2 = s;
								while (true)
								{
									int num5 = 644181321;
									while (true)
									{
										switch (num5 ^ 0x26656D48)
										{
										case 3:
											break;
										case 1:
											s = string.Concat(obj2, text, "Child Count = ", childCount, "\n");
											num5 = 644181320;
											continue;
										case 0:
											if (children != null)
											{
												text5 = "";
												num5 = 644181322;
												continue;
											}
											goto IL_0362;
										default:
											{
												using (List<Element>.Enumerator enumerator2 = children.GetEnumerator())
												{
													while (enumerator2.MoveNext())
													{
														while (true)
														{
															Element current2 = enumerator2.Current;
															text5 += "\n";
															text5 = current2.ToString(text5, indent + 1);
															int num6 = 644181322;
															while (true)
															{
																switch (num6 ^ 0x26656D48)
																{
																case 0:
																	num6 = 644181321;
																	continue;
																case 1:
																	break;
																default:
																	goto end_IL_0318;
																}
																break;
															}
															continue;
															end_IL_0318:
															break;
														}
													}
												}
												s += text5;
												goto IL_0362;
											}
											IL_0362:
											return s;
										}
										break;
									}
								}
							}
							break;
						}
					}
				}
			}

			private readonly Element _root;

			public Element root
			{
				get
				{
					return _root;
				}
			}

			public bool isValid
			{
				get
				{
					return _root != null;
				}
			}

			public XmlDocument(string xml)
			{
				if (string.IsNullOrEmpty(xml))
				{
					throw new ArgumentNullException("xml");
				}
				try
				{
					using (StringReader reader = new StringReader(xml))
					{
						XmlReader xmlReader = XmlReader.Create(reader);
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
				int num = 0;
				int num4 = default(int);
				bool flag = default(bool);
				bool isEmptyElement = default(bool);
				while (reader.Read())
				{
					while (true)
					{
						IL_0202:
						XmlNodeType nodeType = reader.NodeType;
						int num2;
						if (nodeType != XmlNodeType.Comment)
						{
							int num3;
							if (nodeType != XmlNodeType.XmlDeclaration)
							{
								num2 = -1529668257;
								num3 = num2;
							}
							else
							{
								num2 = -1529668265;
								num3 = num2;
							}
							goto IL_0013;
						}
						goto IL_016a;
						IL_0013:
						while (true)
						{
							switch (num2 ^ -1529668267)
							{
							case 6:
								num2 = -1529668261;
								continue;
							case 0:
								element = element.parent;
								num2 = -1529668271;
								continue;
							case 16:
								if (num4 >= reader.AttributeCount)
								{
									if (reader.IsEmptyElement)
									{
										flag = true;
										num2 = -1529668258;
										continue;
									}
									goto case 11;
								}
								goto case 12;
							case 10:
								break;
							case 4:
								num++;
								num2 = -1529668270;
								continue;
							case 1:
								if (!isEmptyElement && reader.HasValue)
								{
									element.content = reader.ReadContentAsString();
									num2 = -1529668258;
									continue;
								}
								goto case 3;
							case 9:
								if (element == null)
								{
									goto case 4;
								}
								goto IL_00f9;
							case 11:
								if (flag)
								{
									goto case 9;
								}
								goto IL_0119;
							case 3:
								flag = true;
								num2 = -1529668258;
								continue;
							case 12:
								reader.MoveToNextAttribute();
								element.AddAttribute(reader.Name, reader.Value);
								num4++;
								num2 = -1529668283;
								continue;
							case 2:
								goto end_IL_0013;
							case 5:
								goto IL_0178;
							case 13:
								isEmptyElement = reader.IsEmptyElement;
								num2 = -1529668268;
								continue;
							case 17:
							{
								XmlNodeType nodeType2 = reader.NodeType;
								int num10 = 15;
								num2 = -1529668258;
								continue;
							}
							case 8:
								goto IL_01bb;
							case 15:
							{
								bool isEmptyElement2 = reader.IsEmptyElement;
								element = new Element(reader.LocalName, element);
								num4 = 0;
								num2 = -1529668283;
								continue;
							}
							case 14:
								goto IL_0202;
							default:
								goto end_IL_0202;
							}
							flag = false;
							if (reader.NodeType == XmlNodeType.Element)
							{
								int num5;
								if (!reader.IsStartElement())
								{
									num2 = -1529668258;
									num5 = num2;
								}
								else
								{
									num2 = -1529668262;
									num5 = num2;
								}
								continue;
							}
							goto IL_0178;
							IL_01bb:
							int num6;
							if (!(reader.Name == element.name))
							{
								num2 = -1529668271;
								num6 = num2;
							}
							else
							{
								num2 = -1529668267;
								num6 = num2;
							}
							continue;
							IL_0119:
							int num7;
							if (reader.NodeType == XmlNodeType.EndElement)
							{
								num2 = -1529668260;
								num7 = num2;
							}
							else
							{
								num2 = -1529668271;
								num7 = num2;
							}
							continue;
							IL_00f9:
							int num8;
							if (element == _root)
							{
								num2 = -1529668271;
								num8 = num2;
							}
							else
							{
								num2 = -1529668259;
								num8 = num2;
							}
							continue;
							IL_0178:
							int num9;
							if (reader.NodeType == XmlNodeType.Text)
							{
								num2 = -1529668264;
								num9 = num2;
							}
							else
							{
								num2 = -1529668284;
								num9 = num2;
							}
							continue;
							end_IL_0013:
							break;
						}
						goto IL_016a;
						IL_016a:
						num++;
						num2 = -1529668270;
						goto IL_0013;
						continue;
						end_IL_0202:
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

		private readonly IndexedDictionary<string, Entry> mxzBQunVokqPuzPaXadbiKiQQDn;

		private XmlInfo oyRwzqHrrNTWvVBSqmfVwErntqp;

		private Type iaFziOmGetWMviBsUmpNhLnTJKt;

		private ObjectType fTTIFxKJIdubQrjfLjEltEHWSLl;

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

		private bool allowDuplicateKeys
		{
			get
			{
				return fTTIFxKJIdubQrjfLjEltEHWSLl == ObjectType.List;
			}
		}

		public ObjectType objectType
		{
			get
			{
				return fTTIFxKJIdubQrjfLjEltEHWSLl;
			}
			set
			{
				if (value == fTTIFxKJIdubQrjfLjEltEHWSLl)
				{
					while (true)
					{
						switch (-1938379975 ^ -1938379973)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				fTTIFxKJIdubQrjfLjEltEHWSLl = value;
				mxzBQunVokqPuzPaXadbiKiQQDn.AllowDuplicateKeys = allowDuplicateKeys;
			}
		}

		public Type type
		{
			get
			{
				return iaFziOmGetWMviBsUmpNhLnTJKt;
			}
		}

		public XmlInfo xmlInfo
		{
			get
			{
				return oyRwzqHrrNTWvVBSqmfVwErntqp;
			}
			set
			{
				oyRwzqHrrNTWvVBSqmfVwErntqp = value;
			}
		}

		public int count
		{
			get
			{
				return mxzBQunVokqPuzPaXadbiKiQQDn.Count;
			}
		}

		public Field this[int index]
		{
			get
			{
				Entry entry = mxzBQunVokqPuzPaXadbiKiQQDn[index];
				string keyAt = mxzBQunVokqPuzPaXadbiKiQQDn.GetKeyAt(index);
				return new Field(keyAt, entry.value, entry.type, entry.options);
			}
		}

		bool IExportToXml.writesOwnElementTag
		{
			get
			{
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		private SerializedObject()
			: this(0)
		{
		}

		private SerializedObject(int capacity)
		{
			fTTIFxKJIdubQrjfLjEltEHWSLl = ObjectType.List;
			mxzBQunVokqPuzPaXadbiKiQQDn = new IndexedDictionary<string, Entry>(capacity, true);
		}

		public SerializedObject(Type type, ObjectType objectType)
			: this(type, objectType, 0)
		{
		}

		public SerializedObject(Type type, ObjectType objectType, int capacity)
			: this(capacity)
		{
			iaFziOmGetWMviBsUmpNhLnTJKt = type;
			this.objectType = objectType;
		}

		public SerializedObject(Type type, IDictionary<string, object> dictionary, ObjectType objectType)
			: this(type, objectType, (dictionary != null) ? dictionary.Count : 0)
		{
			if (type == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				mxzBQunVokqPuzPaXadbiKiQQDn.Add(item.Key, new Entry((item.Value != null) ? item.Value.GetType() : null, item.Value, FieldOptions.None));
			}
		}

		public void Add<T>(string fieldName, T value, FieldOptions options = FieldOptions.None)
		{
			Add(typeof(T), fieldName, value, options);
		}

		public void Add(Type type, string fieldName, object value, FieldOptions options = FieldOptions.None)
		{
			if (type != null && value != null && !object.ReferenceEquals(type, value.GetType()))
			{
				goto IL_0014;
			}
			goto IL_0082;
			IL_00d0:
			fieldName = "value";
			int num = -1781626102;
			goto IL_0019;
			IL_0057:
			if (!mxzBQunVokqPuzPaXadbiKiQQDn.ContainsKey(fieldName))
			{
				mxzBQunVokqPuzPaXadbiKiQQDn.Add(fieldName, new Entry(type, value, options));
				return;
			}
			goto IL_00e1;
			IL_0014:
			num = -1781626097;
			goto IL_0019;
			IL_0019:
			switch (num ^ -1781626100)
			{
			case 5:
				break;
			case 3:
				throw new Exception("Type does not match value type.");
			case 0:
				goto IL_0057;
			case 4:
				goto IL_0082;
			case 6:
				goto IL_00a8;
			case 2:
				goto IL_00d0;
			default:
				goto IL_00e1;
			}
			goto IL_0014;
			IL_00e1:
			mxzBQunVokqPuzPaXadbiKiQQDn.SetValue(fieldName, new Entry(type, value, options));
			return;
			IL_0082:
			if (!string.IsNullOrEmpty(fieldName))
			{
				goto IL_00a8;
			}
			if (fTTIFxKJIdubQrjfLjEltEHWSLl != ObjectType.List)
			{
				throw new ArgumentNullException("fieldName");
			}
			goto IL_00d0;
			IL_00a8:
			if (allowDuplicateKeys)
			{
				mxzBQunVokqPuzPaXadbiKiQQDn.Add(fieldName, new Entry(type, value, options));
				return;
			}
			goto IL_0057;
		}

		public void Add(string fieldName, object value)
		{
			Add((value != null) ? value.GetType() : null, fieldName, value);
		}

		public bool Remove(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return mxzBQunVokqPuzPaXadbiKiQQDn.Remove(fieldName);
		}

		public bool Contains(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return mxzBQunVokqPuzPaXadbiKiQQDn.ContainsKey(fieldName);
		}

		public Type GetDataType(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			Entry value;
			if (!mxzBQunVokqPuzPaXadbiKiQQDn.TryGetValue(fieldName, out value))
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
			Entry value2;
			if (!mxzBQunVokqPuzPaXadbiKiQQDn.TryGetValue(fieldName, out value2))
			{
				return false;
			}
			value = value2.value;
			return true;
		}

		public Field GetEntry(string fieldName)
		{
			KeyValuePair<string, Entry> entry = mxzBQunVokqPuzPaXadbiKiQQDn.GetEntry(fieldName);
			return new Field(entry.Key, entry.Value.value, entry.Value.type, entry.Value.options);
		}

		public object GetOriginalValue(string fieldName)
		{
			return mxzBQunVokqPuzPaXadbiKiQQDn.GetEntry(fieldName).Value.value;
		}

		public object GetOriginalValue(int index)
		{
			return mxzBQunVokqPuzPaXadbiKiQQDn[index].value;
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
			Entry value2;
			if (!mxzBQunVokqPuzPaXadbiKiQQDn.TryGetValue(fieldName, out value2))
			{
				value = default(T);
				return false;
			}
			return TryConvertOrCreateObject<T>(value2.value, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			if ((uint)index > (uint)mxzBQunVokqPuzPaXadbiKiQQDn.Count)
			{
				value = default(T);
				return false;
			}
			return TryConvertOrCreateObject<T>(mxzBQunVokqPuzPaXadbiKiQQDn.GetEntryAt(index).Value.value, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public bool TryGetDeserializedValueByRef<T>(string fieldName, ref T value)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			T value2;
			if (!TryGetDeserializedValue<T>(fieldName, out value2))
			{
				return false;
			}
			value = value2;
			return true;
		}

		public bool TryGetDeserializedValueByRef<T>(int index, ref T value)
		{
			if ((uint)index > (uint)mxzBQunVokqPuzPaXadbiKiQQDn.Count)
			{
				return false;
			}
			T value2;
			if (!TryGetDeserializedValue<T>(index, out value2))
			{
				return false;
			}
			value = value2;
			return true;
		}

		public string ToXmlString(bool writeDocumentTag)
		{
			if (oyRwzqHrrNTWvVBSqmfVwErntqp == null)
			{
				while (true)
				{
					switch (-1626153593 ^ -1626153595)
					{
					case 0:
						continue;
					case 2:
						throw new Exception("XmlInfo is null. Cannot write Xml without XmlInfo.");
					}
					break;
				}
			}
			string empty = string.Empty;
			using (StringWriter stringWriter = new StringWriter())
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
				{
					if (writeDocumentTag)
					{
						xmlWriter.WriteStartDocument();
					}
					WriteXml(xmlWriter);
					xmlWriter.Flush();
				}
				return stringWriter.ToString();
			}
		}

		public string ToJsonString()
		{
			return JsonWriter.ToJson(this);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string keyAt = default(string);
			int num2 = default(int);
			while (true)
			{
				int num = -729155350;
				while (true)
				{
					switch (num ^ -729155348)
					{
					case 4:
						break;
					case 1:
						stringBuilder.Append("key = ");
						stringBuilder.Append((keyAt != null) ? keyAt : "NULL");
						stringBuilder.Append(", value = ");
						stringBuilder.Append(mxzBQunVokqPuzPaXadbiKiQQDn[num2].ToString());
						stringBuilder.Append("\n");
						num2++;
						num = -729155351;
						continue;
					case 2:
						stringBuilder.Append((iaFziOmGetWMviBsUmpNhLnTJKt != null) ? iaFziOmGetWMviBsUmpNhLnTJKt.Name : "NULL\n");
						stringBuilder.Append("objectType = ");
						stringBuilder.Append(fTTIFxKJIdubQrjfLjEltEHWSLl.ToString());
						stringBuilder.Append("\n");
						stringBuilder.Append("xmlInfo = ");
						stringBuilder.Append((oyRwzqHrrNTWvVBSqmfVwErntqp != null) ? oyRwzqHrrNTWvVBSqmfVwErntqp.ToString() : "NULL\n");
						stringBuilder.Append("\n");
						num2 = 0;
						num = -729155345;
						continue;
					case 0:
						keyAt = mxzBQunVokqPuzPaXadbiKiQQDn.GetKeyAt(num2);
						num = -729155347;
						continue;
					case 6:
						stringBuilder.Append("count = ");
						stringBuilder.Append(count.ToString());
						stringBuilder.Append("\n");
						stringBuilder.Append("type = ");
						num = -729155346;
						continue;
					case 3:
						num = -729155351;
						continue;
					default:
						if (num2 >= mxzBQunVokqPuzPaXadbiKiQQDn.Count)
						{
							return stringBuilder.ToString();
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private void WriteXml(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.WriteStartElement(type.Name, "http://guavaman.com/rewired");
			WriteXml_Value(writer);
			writer.WriteEndElement();
		}

		private void WriteXml_Value(XmlWriter writer)
		{
			if (xmlInfo == null)
			{
				goto IL_000b;
			}
			int num = xmlInfo.attributes.Count;
			goto IL_0253;
			IL_0253:
			int num2 = num;
			int num3 = 0;
			int num4 = -400295392;
			goto IL_0010;
			IL_000b:
			num4 = -400295387;
			goto IL_0010;
			IL_0010:
			XmlInfo.XmlStringAttribute xmlStringAttribute = default(XmlInfo.XmlStringAttribute);
			string text = default(string);
			Entry entry = default(Entry);
			int num5 = default(int);
			while (true)
			{
				switch (num4 ^ -400295381)
				{
				case 19:
					break;
				default:
					return;
				case 12:
					num4 = -400295384;
					continue;
				case 16:
				{
					XmlInfo.XmlAttribute xmlAttribute = xmlInfo.attributes[num3];
					if (xmlAttribute is XmlInfo.XmlStringAttribute)
					{
						xmlStringAttribute = xmlAttribute as XmlInfo.XmlStringAttribute;
						if (!string.IsNullOrEmpty(xmlStringAttribute.prefix))
						{
							writer.WriteAttributeString(xmlStringAttribute.prefix, xmlStringAttribute.localName, xmlStringAttribute.ns, xmlStringAttribute.value);
							num4 = -400295385;
							continue;
						}
						goto IL_0123;
					}
					goto case 2;
				}
				case 4:
					writer.WriteAttributeString(xmlStringAttribute.localName, xmlStringAttribute.value);
					num4 = -400295384;
					continue;
				case 10:
					text = "value";
					num4 = -400295367;
					continue;
				case 5:
					if (entry.value != null)
					{
						text = entry.value.GetType().Name;
						num4 = -400295366;
						continue;
					}
					goto case 10;
				case 9:
					goto IL_0123;
				case 1:
					writer.WriteAttributeString(xmlStringAttribute.localName, xmlStringAttribute.ns, xmlStringAttribute.value);
					num4 = -400295384;
					continue;
				case 15:
					entry = mxzBQunVokqPuzPaXadbiKiQQDn[num5];
					num4 = -400295389;
					continue;
				case 6:
					num5++;
					num4 = -400295381;
					continue;
				case 18:
					SerializationTools.WriteXmlElement(writer, text, entry.value);
					num4 = -400295379;
					continue;
				case 8:
					text = mxzBQunVokqPuzPaXadbiKiQQDn.GetKeyAt(num5);
					num4 = -400295386;
					continue;
				case 2:
					throw new NotImplementedException();
				case 3:
					num3++;
					num4 = -400295392;
					continue;
				case 0:
					goto IL_01df;
				case 13:
					if ((entry.options & FieldOptions.ExculdeFromXml) != FieldOptions.None)
					{
						goto case 6;
					}
					if (string.IsNullOrEmpty(text))
					{
						if (entry.type != null)
						{
							text = entry.GetType().Name;
							num4 = -400295367;
							continue;
						}
						goto case 5;
					}
					goto case 18;
				case 14:
					goto IL_0240;
				case 17:
					num4 = -400295367;
					continue;
				case 11:
					if (num3 >= num2)
					{
						num5 = 0;
						num4 = -400295381;
						continue;
					}
					goto case 16;
				case 7:
					return;
				}
				break;
				IL_01df:
				int num6;
				if (num5 >= count)
				{
					num4 = -400295380;
					num6 = num4;
				}
				else
				{
					num4 = -400295388;
					num6 = num4;
				}
				continue;
				IL_0123:
				int num7;
				if (string.IsNullOrEmpty(xmlStringAttribute.ns))
				{
					num4 = -400295377;
					num7 = num4;
				}
				else
				{
					num4 = -400295382;
					num7 = num4;
				}
			}
			goto IL_000b;
			IL_0240:
			num = 0;
			goto IL_0253;
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
			bool flag2 = default(bool);
			int num4 = default(int);
			Entry entry = default(Entry);
			bool flag = default(bool);
			int num5 = default(int);
			string value = default(string);
			while (appendValueDelegate != null)
			{
				while (true)
				{
					int num = mxzBQunVokqPuzPaXadbiKiQQDn.Count;
					int num2;
					int num3;
					if (!mxzBQunVokqPuzPaXadbiKiQQDn.ContainsDuplicateKeys)
					{
						num2 = -1999272925;
						num3 = num2;
					}
					else
					{
						num2 = -1999272915;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1999272918)
						{
						case 2:
							num2 = -1999272914;
							continue;
						default:
							return;
						case 9:
							stringBuilder.Append('{');
							flag2 = true;
							num4 = 0;
							num2 = -1999272913;
							continue;
						case 14:
							appendValueDelegate(stringBuilder, entry.value);
							num2 = -1999272922;
							continue;
						case 7:
							stringBuilder.Append('[');
							flag = true;
							num5 = 0;
							num2 = -1999272923;
							continue;
						case 18:
							appendValueDelegate(stringBuilder, mxzBQunVokqPuzPaXadbiKiQQDn[num5].value);
							num5++;
							num2 = -1999272923;
							continue;
						case 8:
							stringBuilder.Append("\":");
							num2 = -1999272924;
							continue;
						case 16:
							stringBuilder.Append(',');
							num2 = -1999272901;
							continue;
						case 11:
							stringBuilder.Append(']');
							return;
						case 15:
							break;
						case 5:
							if (num4 >= num)
							{
								stringBuilder.Append('}');
								num2 = -1999272898;
								continue;
							}
							goto case 0;
						case 3:
							stringBuilder.Append('"');
							stringBuilder.Append(value);
							num2 = -1999272926;
							continue;
						case 12:
							num4++;
							num2 = -1999272913;
							continue;
						case 17:
							goto IL_0180;
						case 1:
							value = num4.ToString();
							num2 = -1999272919;
							continue;
						case 10:
							goto end_IL_0016;
						case 13:
							if (flag)
							{
								flag = false;
								num2 = -1999272904;
								continue;
							}
							goto case 6;
						case 6:
							stringBuilder.Append(',');
							num2 = -1999272904;
							continue;
						case 19:
							num2 = -1999272901;
							continue;
						case 0:
							if (flag2)
							{
								flag2 = false;
								num2 = -1999272903;
								continue;
							}
							goto case 16;
						case 4:
							goto end_IL_01ce;
						case 20:
							return;
						}
						int num6;
						if (num5 >= num)
						{
							num2 = -1999272927;
							num6 = num2;
						}
						else
						{
							num2 = -1999272921;
							num6 = num2;
						}
						continue;
						IL_0180:
						entry = mxzBQunVokqPuzPaXadbiKiQQDn[num4];
						value = mxzBQunVokqPuzPaXadbiKiQQDn.GetKeyAt(num4);
						int num7;
						if (string.IsNullOrEmpty(value))
						{
							num2 = -1999272917;
							num7 = num2;
						}
						else
						{
							num2 = -1999272919;
							num7 = num2;
						}
						continue;
						end_IL_0016:
						break;
					}
					continue;
					end_IL_01ce:
					break;
				}
			}
			throw new ArgumentNullException("appendValueDelegate");
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
			return new Enumerator(mxzBQunVokqPuzPaXadbiKiQQDn);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(mxzBQunVokqPuzPaXadbiKiQQDn);
		}

		private static bool TryConvertOrCreateObject<T>(object obj, out T result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			object result2;
			if (!TryConvertOrCreateObject(typeof(T), obj, out result2, numberStyle, cultureInfo))
			{
				result = default(T);
				return false;
			}
			result = (T)result2;
			return true;
		}

		private static bool TryConvertOrCreateObject(Type targetType, object obj, out object result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			result = null;
			Type type = default(Type);
			IDictionary dictionary = default(IDictionary);
			Type type2 = default(Type);
			Type type3 = default(Type);
			IDictionary dictionary2 = default(IDictionary);
			bool result4 = default(bool);
			int result5 = default(int);
			object result7 = default(object);
			float result6 = default(float);
			Type genericTypeDefinition = default(Type);
			Type elementType = default(Type);
			Type targetType2 = default(Type);
			ICollection collection = default(ICollection);
			Array array3 = default(Array);
			int num26 = default(int);
			Type type4 = default(Type);
			short result23 = default(short);
			sbyte result21 = default(sbyte);
			int num37 = default(int);
			ushort result18 = default(ushort);
			IList list2 = default(IList);
			Array array6 = default(Array);
			byte result16 = default(byte);
			int num35 = default(int);
			IReadOnlyList readOnlyList = default(IReadOnlyList);
			Array array8 = default(Array);
			double result12 = default(double);
			SerializedObject serializedObject = default(SerializedObject);
			ulong result22 = default(ulong);
			Array array4 = default(Array);
			int num36 = default(int);
			decimal result15 = default(decimal);
			Array array7 = default(Array);
			int num38 = default(int);
			Array array5 = default(Array);
			uint result20 = default(uint);
			long result14 = default(long);
			IReadOnlyList readOnlyList2 = default(IReadOnlyList);
			IList list7 = default(IList);
			int num87 = default(int);
			Array array9 = default(Array);
			IList list4 = default(IList);
			int num88 = default(int);
			int num89 = default(int);
			IList list5 = default(IList);
			IList list6 = default(IList);
			SerializedObject serializedObject2 = default(SerializedObject);
			IList list3 = default(IList);
			int num86 = default(int);
			object result26 = default(object);
			while (true)
			{
				int num = -1847995812;
				while (true)
				{
					switch (num ^ -1847995811)
					{
					case 2:
						break;
					case 1:
						if (obj != null)
						{
							goto IL_0055;
						}
						if (object.ReferenceEquals(targetType, typeof(string)))
						{
							result = string.Empty;
							return true;
						}
						if (!ReflectionTools.IsValueType(targetType))
						{
							return true;
						}
						if (Nullable.GetUnderlyingType(targetType) != null)
						{
							return true;
						}
						return false;
					default:
						{
							if (object.ReferenceEquals(targetType, type))
							{
								result = obj;
								return true;
							}
							try
							{
								if (object.ReferenceEquals(targetType, typeof(string)))
								{
									result = obj.ToString();
									goto IL_008e;
								}
								goto IL_04a7;
								IL_3785:
								IEnumerator enumerator = dictionary.Keys.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										while (true)
										{
											object current = enumerator.Current;
											object result2;
											if (!TryConvertOrCreateObject(type2, current, out result2, numberStyle, cultureInfo))
											{
												break;
											}
											object result3;
											int num2;
											int num3;
											if (TryConvertOrCreateObject(type3, dictionary[current], out result3, numberStyle, cultureInfo))
											{
												num2 = -1847995809;
												num3 = num2;
											}
											else
											{
												num2 = -1847995810;
												num3 = num2;
											}
											while (true)
											{
												switch (num2 ^ -1847995811)
												{
												case 0:
													num2 = -1847995812;
													continue;
												case 1:
													break;
												case 2:
													dictionary2.Add(result2, result3);
													num2 = -1847995810;
													continue;
												default:
													goto end_IL_37b7;
												}
												break;
											}
											continue;
											end_IL_37b7:
											break;
										}
									}
								}
								finally
								{
									IDisposable disposable2 = enumerator as IDisposable;
									if (disposable2 != null)
									{
										disposable2.Dispose();
									}
								}
								result = dictionary2;
								result4 = true;
								goto IL_3831;
								IL_008e:
								int num4 = -1847995827;
								goto IL_0093;
								IL_0093:
								while (true)
								{
									switch (num4 ^ -1847995811)
									{
									case 14:
										break;
									case 1:
										num4 = -1847995788;
										continue;
									case 45:
										goto IL_0179;
									case 41:
										result4 = true;
										goto end_IL_0071;
									case 13:
										if (!int.TryParse(obj.ToString(), numberStyle, cultureInfo, out result5))
										{
											result4 = false;
											num4 = -1847995818;
											continue;
										}
										goto case 47;
									case 4:
										num4 = -1847995814;
										continue;
									case 23:
										if (object.ReferenceEquals(type, typeof(ulong)))
										{
											result = (float)(ulong)obj;
											num4 = -1847995814;
											continue;
										}
										goto case 3;
									case 3:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (float)(double)obj;
											num4 = -1847995814;
											continue;
										}
										goto case 42;
									case 29:
										result = (int)(byte)obj;
										num4 = -1847995828;
										continue;
									case 12:
										if (object.ReferenceEquals(type, typeof(ushort)))
										{
											result = (float)(int)(ushort)obj;
											num4 = -1847995814;
											continue;
										}
										goto case 43;
									case 24:
										num4 = -1847995814;
										continue;
									case 36:
										result4 = false;
										num4 = -1847995816;
										continue;
									case 18:
										result = Enum.ToObject(targetType, result7);
										num4 = -1847995834;
										continue;
									case 30:
										goto IL_02aa;
									case 32:
										if (int.TryParse(obj.ToString(), out result5))
										{
											goto case 47;
										}
										result4 = false;
										goto end_IL_0071;
									case 21:
										num4 = -1847995788;
										continue;
									case 37:
										goto IL_0309;
									case 43:
										if (object.ReferenceEquals(type, typeof(byte)))
										{
											result = (float)(int)(byte)obj;
											num4 = -1847995814;
											continue;
										}
										goto case 40;
									case 40:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (float)(sbyte)obj;
											num4 = -1847995781;
											continue;
										}
										goto case 46;
									case 34:
										goto IL_0386;
									case 47:
										result = result5;
										num4 = -1847995788;
										continue;
									case 35:
										result4 = false;
										goto end_IL_0071;
									case 8:
										goto IL_03d6;
									case 17:
										num4 = -1847995788;
										continue;
									case 38:
										num4 = -1847995814;
										continue;
									case 11:
										goto end_IL_0071;
									case 33:
										result = result6;
										num4 = -1847995814;
										continue;
									case 10:
										goto IL_044d;
									case 22:
										num4 = -1847995788;
										continue;
									case 16:
										result4 = true;
										goto end_IL_0071;
									case 7:
										result4 = true;
										goto end_IL_0071;
									case 48:
										goto IL_04a7;
									case 44:
										if (object.ReferenceEquals(type, typeof(short)))
										{
											result = (float)(short)obj;
											num4 = -1847995835;
											continue;
										}
										goto case 12;
									case 50:
										goto IL_0516;
									case 0:
										goto IL_0543;
									case 19:
										goto IL_0566;
									case 9:
										result4 = false;
										goto end_IL_0071;
									case 28:
										if (!object.ReferenceEquals(type, typeof(string)))
										{
											goto case 36;
										}
										goto IL_05b7;
									case 27:
										result4 = true;
										goto end_IL_0071;
									case 46:
										if (!object.ReferenceEquals(type, typeof(string)))
										{
											goto case 35;
										}
										if (cultureInfo == null)
										{
											goto IL_0543;
										}
										if (float.TryParse(obj.ToString(), numberStyle, cultureInfo, out result6))
										{
											goto case 33;
										}
										result4 = false;
										goto end_IL_0071;
									case 20:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (int)(sbyte)obj;
											num4 = -1847995788;
											continue;
										}
										goto case 28;
									case 26:
										num4 = -1847995788;
										continue;
									case 15:
										goto IL_065a;
									case 31:
										goto IL_0680;
									case 42:
										if (object.ReferenceEquals(type, typeof(decimal)))
										{
											result = (float)(decimal)obj;
											num4 = -1847995815;
											continue;
										}
										goto case 44;
									case 39:
										goto IL_06df;
									case 5:
										goto end_IL_0071;
									case 2:
										goto IL_071c;
									case 6:
										result = (float)(long)obj;
										num4 = -1847995814;
										continue;
									case 49:
										num4 = -1847995788;
										continue;
									default:
										goto IL_0772;
									}
									break;
									IL_05b7:
									int num5;
									if (cultureInfo == null)
									{
										num4 = -1847995779;
										num5 = num4;
									}
									else
									{
										num4 = -1847995824;
										num5 = num4;
									}
									continue;
									IL_0543:
									int num6;
									if (float.TryParse(obj.ToString(), out result6))
									{
										num4 = -1847995780;
										num6 = num4;
									}
									else
									{
										num4 = -1847995820;
										num6 = num4;
									}
								}
								goto IL_008e;
								IL_36c9:
								int num7 = -1847995809;
								goto IL_36ce;
								IL_3702:
								if (ReflectionTools.DoesTypeImplement(genericTypeDefinition, typeof(IDictionary)))
								{
									Type[] genericArguments = ReflectionTools.GetGenericArguments(targetType);
									type2 = genericArguments[0];
									type3 = genericArguments[1];
									num7 = -1847995811;
									goto IL_36ce;
								}
								goto IL_38fc;
								IL_0db3:
								int num8;
								int num9;
								if (!object.ReferenceEquals(targetType, typeof(bool)))
								{
									num8 = -1847995738;
									num9 = num8;
								}
								else
								{
									num8 = -1847995885;
									num9 = num8;
								}
								goto IL_07eb;
								IL_3031:
								int num10;
								while (true)
								{
									switch (num10 ^ -1847995811)
									{
									case 0:
										break;
									case 3:
										result4 = true;
										num10 = -1847995812;
										continue;
									case 2:
										goto IL_305c;
									case 1:
										goto end_IL_0071;
									default:
										goto IL_3084;
									}
									break;
								}
								goto IL_302c;
								IL_2243:
								if (!object.ReferenceEquals(targetType, typeof(double)))
								{
									goto IL_0db3;
								}
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (double)(float)obj;
									num8 = -1847995898;
									goto IL_07eb;
								}
								goto IL_1bf2;
								IL_32a9:
								result4 = false;
								goto end_IL_0071;
								IL_071c:
								if (ReflectionTools.IsEnum(targetType))
								{
									Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(targetType);
									int num11;
									if (TryConvertOrCreateObject(underlyingEnumType, obj, out result7, numberStyle, cultureInfo))
									{
										num4 = -1847995825;
										num11 = num4;
									}
									else
									{
										num4 = -1847995836;
										num11 = num4;
									}
									goto IL_0093;
								}
								if (object.ReferenceEquals(targetType, typeof(uint)))
								{
									if (object.ReferenceEquals(type, typeof(int)))
									{
										result = (uint)(int)obj;
										goto IL_161d;
									}
									goto IL_1d50;
								}
								goto IL_2243;
								IL_3084:
								IEnumerable enumerable = obj as IEnumerable;
								int num12 = 0;
								IEnumerator enumerator2 = enumerable.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										while (true)
										{
											object current6 = enumerator2.Current;
											num12++;
											int num13 = -1847995811;
											while (true)
											{
												switch (num13 ^ -1847995811)
												{
												case 2:
													num13 = -1847995812;
													continue;
												case 1:
													break;
												default:
													goto end_IL_30b8;
												}
												break;
											}
											continue;
											end_IL_30b8:
											break;
										}
									}
								}
								finally
								{
									IDisposable disposable = enumerator2 as IDisposable;
									while (true)
									{
										IL_30e1:
										int num14 = -1847995809;
										while (true)
										{
											switch (num14 ^ -1847995811)
											{
											case 0:
												break;
											default:
												goto end_IL_30e6;
											case 2:
												if (disposable != null)
												{
													goto IL_3103;
												}
												goto end_IL_30e6;
											case 1:
												goto end_IL_30e6;
											}
											goto IL_30e1;
											IL_3103:
											disposable.Dispose();
											num14 = -1847995812;
											continue;
											end_IL_30e6:
											break;
										}
										break;
									}
								}
								Array array = Array.CreateInstance(elementType, num12);
								int num15 = 0;
								enumerator2 = enumerable.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										while (true)
										{
											object current2 = enumerator2.Current;
											object result8;
											if (!TryConvertOrCreateObject(elementType, current2, out result8, numberStyle, cultureInfo))
											{
												break;
											}
											array.SetValue(result8, num15);
											num15++;
											int num16 = -1847995811;
											while (true)
											{
												switch (num16 ^ -1847995811)
												{
												case 2:
													num16 = -1847995812;
													continue;
												case 1:
													break;
												default:
													goto end_IL_3149;
												}
												break;
											}
											continue;
											end_IL_3149:
											break;
										}
									}
								}
								finally
								{
									IDisposable disposable = enumerator2 as IDisposable;
									while (true)
									{
										IL_318e:
										int num17 = -1847995812;
										while (true)
										{
											switch (num17 ^ -1847995811)
											{
											case 0:
												break;
											default:
												goto end_IL_3193;
											case 1:
												if (disposable != null)
												{
													goto IL_31b0;
												}
												goto end_IL_3193;
											case 2:
												goto end_IL_3193;
											}
											goto IL_318e;
											IL_31b0:
											disposable.Dispose();
											num17 = -1847995809;
											continue;
											end_IL_3193:
											break;
										}
										break;
									}
								}
								result = array;
								goto IL_31c3;
								IL_0f72:
								int num18;
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									num8 = -1847995726;
									num18 = num8;
								}
								else
								{
									num8 = -1847995723;
									num18 = num8;
								}
								goto IL_07eb;
								IL_044d:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (int)(short)obj;
									num4 = -1847995829;
									goto IL_0093;
								}
								goto IL_0386;
								IL_1d50:
								int num19;
								if (object.ReferenceEquals(type, typeof(float)))
								{
									num8 = -1847995888;
									num19 = num8;
								}
								else
								{
									num8 = -1847995704;
									num19 = num8;
								}
								goto IL_07eb;
								IL_302c:
								num10 = -1847995810;
								goto IL_3031;
								IL_2f00:
								int num20 = -1847995815;
								goto IL_2f05;
								IL_2e1d:
								IDictionary dictionary3 = obj as IDictionary;
								Array array2 = Array.CreateInstance(elementType, dictionary3.Count);
								int num21 = 0;
								enumerator2 = dictionary3.Values.GetEnumerator();
								try
								{
									while (true)
									{
										IL_2ea6:
										int num22;
										int num23;
										if (!enumerator2.MoveNext())
										{
											num22 = -1847995811;
											num23 = num22;
										}
										else
										{
											num22 = -1847995809;
											num23 = num22;
										}
										while (true)
										{
											switch (num22 ^ -1847995811)
											{
											case 4:
												num22 = -1847995809;
												continue;
											default:
												goto end_IL_2e4d;
											case 2:
											{
												object current3 = enumerator2.Current;
												object result9;
												if (TryConvertOrCreateObject(targetType2, current3, out result9, numberStyle, cultureInfo))
												{
													array2.SetValue(result9, num21);
													num22 = -1847995812;
													continue;
												}
												break;
											}
											case 1:
												num21++;
												num22 = -1847995810;
												continue;
											case 3:
												break;
											case 0:
												goto end_IL_2e4d;
											}
											goto IL_2ea6;
											continue;
											end_IL_2e4d:
											break;
										}
										break;
									}
								}
								finally
								{
									IDisposable disposable = enumerator2 as IDisposable;
									if (disposable != null)
									{
										while (true)
										{
											IL_2ecf:
											int num24 = -1847995809;
											while (true)
											{
												switch (num24 ^ -1847995811)
												{
												case 0:
													break;
												default:
													goto end_IL_2ed4;
												case 2:
													goto IL_2eed;
												case 1:
													goto end_IL_2ed4;
												}
												goto IL_2ecf;
												IL_2eed:
												disposable.Dispose();
												num24 = -1847995812;
												continue;
												end_IL_2ed4:
												break;
											}
											break;
										}
									}
								}
								result = array2;
								goto IL_2f00;
								IL_3831:
								int num25 = -1847995820;
								goto IL_3836;
								IL_2f05:
								while (true)
								{
									switch (num20 ^ -1847995811)
									{
									case 0:
										break;
									case 2:
										collection = obj as ICollection;
										array3 = Array.CreateInstance(elementType, collection.Count);
										num26 = 0;
										num20 = -1847995812;
										continue;
									case 3:
										goto IL_2f48;
									case 4:
										result4 = true;
										goto end_IL_0071;
									default:
										goto IL_2f73;
									}
									break;
								}
								goto IL_2f00;
								IL_03d6:
								if (object.ReferenceEquals(targetType, typeof(float)))
								{
									if (object.ReferenceEquals(type, typeof(int)))
									{
										result = (float)(int)obj;
										num4 = -1847995814;
										goto IL_0093;
									}
									goto IL_06df;
								}
								goto IL_071c;
								IL_305c:
								if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
								{
									num10 = -1847995815;
									goto IL_3031;
								}
								goto IL_32a9;
								IL_0680:
								if (object.ReferenceEquals(type, typeof(double)))
								{
									result = (int)(double)obj;
									num4 = -1847995812;
									goto IL_0093;
								}
								goto IL_02aa;
								IL_3836:
								while (true)
								{
									switch (num25 ^ -1847995811)
									{
									case 10:
										break;
									case 6:
										result4 = false;
										num25 = -1847995816;
										continue;
									case 7:
										result = obj;
										result4 = true;
										num25 = -1847995815;
										continue;
									case 5:
										goto end_IL_0071;
									case 1:
										goto IL_3895;
									case 2:
										result = obj;
										num25 = -1847995819;
										continue;
									case 9:
										goto end_IL_0071;
									case 8:
										result4 = true;
										goto end_IL_0071;
									case 0:
										goto IL_38fc;
									case 4:
										goto end_IL_0071;
									default:
										goto IL_393b;
									}
									break;
									IL_3895:
									if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
									{
										int num27;
										if (!TryCreateObject(targetType, obj as SerializedObject, out obj))
										{
											num25 = -1847995813;
											num27 = num25;
										}
										else
										{
											num25 = -1847995814;
											num27 = num25;
										}
										continue;
									}
									goto IL_393b;
								}
								goto IL_3831;
								IL_38fc:
								int num28;
								if (!object.ReferenceEquals(targetType, typeof(object)))
								{
									num25 = -1847995812;
									num28 = num25;
								}
								else
								{
									num25 = -1847995809;
									num28 = num25;
								}
								goto IL_3836;
								IL_0772:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto IL_38fc;
								}
								try
								{
									result = Enum.Parse(targetType, (string)obj, true);
									result4 = true;
								}
								catch
								{
									result = null;
									result4 = false;
								}
								goto end_IL_0071;
								IL_2f73:
								enumerator2 = collection.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										while (true)
										{
											object current4 = enumerator2.Current;
											int num29 = -1847995812;
											while (true)
											{
												switch (num29 ^ -1847995811)
												{
												case 0:
													num29 = -1847995810;
													continue;
												case 3:
													break;
												case 1:
												{
													object result10;
													if (TryConvertOrCreateObject(elementType, current4, out result10, numberStyle, cultureInfo))
													{
														array3.SetValue(result10, num26);
														num29 = -1847995815;
														continue;
													}
													goto end_IL_2fa4;
												}
												case 4:
													num26++;
													num29 = -1847995809;
													continue;
												default:
													goto end_IL_2fa4;
												}
												break;
											}
											continue;
											end_IL_2fa4:
											break;
										}
									}
								}
								finally
								{
									IDisposable disposable = enumerator2 as IDisposable;
									while (true)
									{
										IL_2ff7:
										int num30 = -1847995812;
										while (true)
										{
											switch (num30 ^ -1847995811)
											{
											case 0:
												break;
											default:
												goto end_IL_2ffc;
											case 1:
												if (disposable != null)
												{
													goto IL_3019;
												}
												goto end_IL_2ffc;
											case 2:
												goto end_IL_2ffc;
											}
											goto IL_2ff7;
											IL_3019:
											disposable.Dispose();
											num30 = -1847995809;
											continue;
											end_IL_2ffc:
											break;
										}
										break;
									}
								}
								result = array3;
								goto IL_302c;
								IL_35d4:
								if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
								{
									IEnumerable enumerable2 = obj as IEnumerable;
									IList list = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type4));
									enumerator2 = enumerable2.GetEnumerator();
									try
									{
										while (enumerator2.MoveNext())
										{
											while (true)
											{
												object current5 = enumerator2.Current;
												object result11;
												int num31;
												int num32;
												if (TryConvertOrCreateObject(type4, current5, out result11, numberStyle, cultureInfo))
												{
													num31 = -1847995811;
													num32 = num31;
												}
												else
												{
													num31 = -1847995810;
													num32 = num31;
												}
												while (true)
												{
													switch (num31 ^ -1847995811)
													{
													case 2:
														num31 = -1847995812;
														continue;
													case 1:
														break;
													case 0:
														list.Add(result11);
														num31 = -1847995810;
														continue;
													default:
														goto end_IL_3642;
													}
													break;
												}
												continue;
												end_IL_3642:
												break;
											}
										}
									}
									finally
									{
										IDisposable disposable = enumerator2 as IDisposable;
										while (true)
										{
											IL_3691:
											int num33 = -1847995812;
											while (true)
											{
												switch (num33 ^ -1847995811)
												{
												case 2:
													break;
												default:
													goto end_IL_3696;
												case 1:
													if (disposable != null)
													{
														goto IL_36b3;
													}
													goto end_IL_3696;
												case 0:
													goto end_IL_3696;
												}
												goto IL_3691;
												IL_36b3:
												disposable.Dispose();
												num33 = -1847995811;
												continue;
												end_IL_3696:
												break;
											}
											break;
										}
									}
									result = list;
									result4 = true;
									goto IL_36c9;
								}
								goto IL_38fc;
								IL_161d:
								result4 = true;
								num8 = -1847995714;
								goto IL_07eb;
								IL_0516:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (int)(ulong)obj;
									num4 = -1847995788;
									goto IL_0093;
								}
								goto IL_0680;
								IL_0309:
								int num34;
								if (!object.ReferenceEquals(type, typeof(byte)))
								{
									num4 = -1847995831;
									num34 = num4;
								}
								else
								{
									num4 = -1847995840;
									num34 = num4;
								}
								goto IL_0093;
								IL_0386:
								if (object.ReferenceEquals(type, typeof(ushort)))
								{
									result = (int)(ushort)obj;
									num4 = -1847995788;
									goto IL_0093;
								}
								goto IL_0309;
								IL_02aa:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (int)(decimal)obj;
									num4 = -1847995796;
									goto IL_0093;
								}
								goto IL_044d;
								IL_2f48:
								if (ReflectionTools.DoesTypeImplement(type, typeof(ICollection)))
								{
									num20 = -1847995809;
									goto IL_2f05;
								}
								goto IL_305c;
								IL_36ce:
								while (true)
								{
									switch (num7 ^ -1847995811)
									{
									case 3:
										break;
									case 2:
										goto end_IL_0071;
									case 5:
										goto IL_3702;
									case 1:
										dictionary2 = (IDictionary)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2, type3));
										num7 = -1847995815;
										continue;
									case 0:
										dictionary = obj as IDictionary;
										if (dictionary != null)
										{
											goto case 1;
										}
										result4 = false;
										goto end_IL_0071;
									default:
										goto IL_3785;
									}
									break;
								}
								goto IL_36c9;
								IL_0566:
								if (object.ReferenceEquals(type, typeof(long)))
								{
									result = (int)(long)obj;
									num4 = -1847995788;
									goto IL_0093;
								}
								goto IL_0516;
								IL_0179:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (int)(uint)obj;
									num4 = -1847995832;
									goto IL_0093;
								}
								goto IL_0566;
								IL_07eb:
								while (true)
								{
									switch (num8 ^ -1847995811)
									{
									case 154:
										num8 = -1847995562;
										continue;
									case 208:
										result = (short)(int)obj;
										num8 = -1847995875;
										continue;
									case 26:
										break;
									case 182:
										num8 = -1847995766;
										continue;
									case 211:
										result4 = false;
										num8 = -1847995715;
										continue;
									case 23:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (decimal)(double)obj;
											num8 = -1847995677;
											continue;
										}
										goto case 6;
									case 155:
										goto end_IL_07eb;
									case 27:
										num8 = -1847995842;
										continue;
									case 152:
										num8 = -1847995829;
										continue;
									case 109:
										if (object.ReferenceEquals(type, typeof(decimal)))
										{
											result = (ulong)(decimal)obj;
											num8 = -1847995766;
											continue;
										}
										goto case 43;
									case 74:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (byte)(double)obj;
											num8 = -1847995795;
											continue;
										}
										goto IL_2a44;
									case 202:
										goto IL_0d5b;
									case 38:
										if (object.ReferenceEquals(type, typeof(ushort)))
										{
											result = (ushort)obj > 0;
											num8 = -1847995703;
											continue;
										}
										goto case 264;
									case 73:
										goto IL_0db3;
									case 270:
										if (object.ReferenceEquals(type, typeof(long)))
										{
											result = (short)(long)obj;
											num8 = -1847995900;
											continue;
										}
										goto IL_1897;
									case 86:
										if (object.ReferenceEquals(type, typeof(int)))
										{
											result = (sbyte)(int)obj;
											num8 = -1847995701;
											continue;
										}
										goto case 258;
									case 201:
										result4 = false;
										goto end_IL_07eb;
									case 250:
										result4 = true;
										goto end_IL_07eb;
									case 258:
										if (object.ReferenceEquals(type, typeof(uint)))
										{
											result = (sbyte)(uint)obj;
											num8 = -1847995897;
											continue;
										}
										goto IL_26f7;
									case 243:
										if (object.ReferenceEquals(type, typeof(float)))
										{
											result = (ulong)(float)obj;
											num8 = -1847995766;
											continue;
										}
										goto case 186;
									case 89:
										result4 = true;
										goto end_IL_07eb;
									case 9:
										if (object.ReferenceEquals(type, typeof(ulong)))
										{
											result = (double)(ulong)obj;
											num8 = -1847995898;
											continue;
										}
										goto case 261;
									case 21:
										num8 = -1847995842;
										continue;
									case 57:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (long)(sbyte)obj;
											num8 = -1847995696;
											continue;
										}
										goto case 162;
									case 134:
										if (object.ReferenceEquals(type, typeof(string)))
										{
											if (cultureInfo != null)
											{
												if (!short.TryParse(obj.ToString(), numberStyle, cultureInfo, out result23))
												{
													result4 = false;
													goto end_IL_07eb;
												}
												goto case 25;
											}
											goto case 118;
										}
										goto case 117;
									case 172:
										num8 = -1847995740;
										continue;
									case 151:
										goto IL_0f72;
									case 98:
										if (!sbyte.TryParse(obj.ToString(), out result21))
										{
											result4 = false;
											num8 = -1847995805;
											continue;
										}
										goto case 36;
									case 174:
										goto IL_0fb7;
									case 241:
										if (object.ReferenceEquals(targetType, typeof(short)))
										{
											goto IL_0ff2;
										}
										goto case 112;
									case 170:
										if (object.ReferenceEquals(type, typeof(ushort)))
										{
											result = (byte)(ushort)obj;
											num8 = -1847995795;
											continue;
										}
										goto case 0;
									case 119:
										goto end_IL_07eb;
									case 210:
										result = (double)(int)(ushort)obj;
										num8 = -1847995898;
										continue;
									case 259:
										num37++;
										num8 = -1847995666;
										continue;
									case 239:
										result = (double)(uint)obj;
										num8 = -1847995898;
										continue;
									case 35:
										result4 = false;
										goto end_IL_07eb;
									case 167:
										if (!ushort.TryParse(obj.ToString(), out result18))
										{
											result4 = false;
											num8 = -1847995706;
											continue;
										}
										goto case 138;
									case 205:
										num8 = -1847995740;
										continue;
									case 179:
										if (num37 >= list2.Count)
										{
											result = array6;
											num8 = -1847995894;
											continue;
										}
										goto case 37;
									case 36:
										result = result21;
										num8 = -1847995701;
										continue;
									case 254:
										if (object.ReferenceEquals(type, typeof(ulong)))
										{
											result = (sbyte)(ulong)obj;
											num8 = -1847995701;
											continue;
										}
										goto case 127;
									case 46:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (double)(sbyte)obj;
											num8 = -1847995898;
											continue;
										}
										goto case 10;
									case 30:
										goto end_IL_07eb;
									case 193:
										if (object.ReferenceEquals(targetType, typeof(sbyte)))
										{
											if (object.ReferenceEquals(type, typeof(byte)))
											{
												result = (sbyte)(byte)obj;
												num8 = -1847995701;
												continue;
											}
											goto case 86;
										}
										goto IL_1393;
									case 224:
										goto end_IL_07eb;
									case 77:
										result = (uint)(float)obj;
										num8 = -1847995842;
										continue;
									case 29:
										goto IL_11d1;
									case 7:
										num8 = -1847995703;
										continue;
									case 127:
										if (object.ReferenceEquals(type, typeof(float)))
										{
											result = (sbyte)(float)obj;
											num8 = -1847995701;
											continue;
										}
										goto case 244;
									case 248:
										result = obj.ToString();
										result4 = true;
										goto end_IL_07eb;
									case 166:
										result = (short)(decimal)obj;
										num8 = -1847995900;
										continue;
									case 116:
										result = (int)obj > 0;
										num8 = -1847995703;
										continue;
									case 94:
										if (!byte.TryParse(obj.ToString(), numberStyle, cultureInfo, out result16))
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 159;
									case 233:
										result4 = false;
										goto end_IL_07eb;
									case 78:
										goto IL_12b7;
									case 114:
										if (object.ReferenceEquals(type, typeof(short)))
										{
											result = (decimal)(short)obj;
											num8 = -1847995677;
											continue;
										}
										goto case 137;
									case 90:
										num8 = -1847995701;
										continue;
									case 230:
										if (num35 >= readOnlyList.Count)
										{
											result = array8;
											result4 = true;
											goto end_IL_07eb;
										}
										goto case 161;
									case 80:
										result4 = false;
										num8 = -1847995866;
										continue;
									case 47:
										if (!double.TryParse(obj.ToString(), out result12))
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 199;
									case 232:
										goto IL_136d;
									case 242:
										goto IL_1393;
									case 252:
										if (object.ReferenceEquals(type, typeof(int)))
										{
											result = (byte)(int)obj;
											num8 = -1847995795;
											continue;
										}
										goto case 158;
									case 187:
										num8 = -1847995740;
										continue;
									case 217:
										num8 = -1847995703;
										continue;
									case 120:
										if (object.ReferenceEquals(type, typeof(float)))
										{
											result = (short)(float)obj;
											num8 = -1847995900;
											continue;
										}
										goto case 66;
									case 97:
										if (object.ReferenceEquals(type, typeof(ulong)))
										{
											result = (uint)(ulong)obj;
											num8 = -1847995832;
											continue;
										}
										goto case 92;
									case 277:
										num8 = -1847995829;
										continue;
									case 245:
										goto IL_1473;
									case 160:
										array8 = Array.CreateInstance(elementType, readOnlyList.Count);
										num8 = -1847995812;
										continue;
									case 54:
										result = (byte)(float)obj;
										num8 = -1847995795;
										continue;
									case 276:
										serializedObject = obj as SerializedObject;
										if (serializedObject == null)
										{
											result4 = false;
											num8 = -1847995558;
											continue;
										}
										goto case 49;
									case 143:
										if (object.ReferenceEquals(type, typeof(decimal)))
										{
											result = (sbyte)(decimal)obj;
											num8 = -1847995701;
											continue;
										}
										goto IL_1527;
									case 22:
										result4 = true;
										goto end_IL_07eb;
									case 168:
										goto IL_1527;
									case 12:
										goto IL_154d;
									case 34:
										if (!ulong.TryParse(obj.ToString(), numberStyle, cultureInfo, out result22))
										{
											result4 = false;
											num8 = -1847995843;
											continue;
										}
										goto case 221;
									case 129:
										if (object.ReferenceEquals(type, typeof(byte)))
										{
											result = (long)(byte)obj;
											num8 = -1847995698;
											continue;
										}
										goto case 57;
									case 171:
										num8 = -1847995829;
										continue;
									case 3:
										if (object.ReferenceEquals(type, typeof(float)))
										{
											result = (float)obj > 0f;
											num8 = -1847995772;
											continue;
										}
										goto case 19;
									case 96:
										goto end_IL_07eb;
									case 72:
										goto end_IL_07eb;
									case 99:
										goto IL_161d;
									case 218:
										result = (short)(ushort)obj;
										num8 = -1847995900;
										continue;
									case 100:
										goto IL_1642;
									case 214:
										result = (decimal)(byte)obj;
										num8 = -1847995660;
										continue;
									case 42:
										result = (uint)(long)obj;
										num8 = -1847995842;
										continue;
									case 6:
										if (object.ReferenceEquals(type, typeof(int)))
										{
											result = (decimal)(int)obj;
											num8 = -1847995677;
											continue;
										}
										goto case 58;
									case 165:
										result = (double)(long)obj;
										num8 = -1847995898;
										continue;
									case 178:
										if (object.ReferenceEquals(type, typeof(decimal)))
										{
											result = (ushort)(decimal)obj;
											num8 = -1847995707;
											continue;
										}
										goto IL_2528;
									case 49:
										array4 = Array.CreateInstance(elementType, serializedObject.count);
										num36 = 0;
										num8 = -1847995749;
										continue;
									case 102:
										goto end_IL_07eb;
									case 192:
										result = (byte)(decimal)obj;
										num8 = -1847995855;
										continue;
									case 104:
										array6 = Array.CreateInstance(elementType, list2.Count);
										num37 = 0;
										num8 = -1847995666;
										continue;
									case 212:
										num8 = -1847995842;
										continue;
									case 262:
										result4 = false;
										goto end_IL_07eb;
									case 37:
									{
										object result17;
										if (TryConvertOrCreateObject(elementType, list2[num37], out result17, numberStyle, cultureInfo))
										{
											array6.SetValue(result17, num37);
											num8 = -1847995554;
											continue;
										}
										goto case 259;
									}
									case 158:
										if (object.ReferenceEquals(type, typeof(uint)))
										{
											result = (byte)(uint)obj;
											num8 = -1847995795;
											continue;
										}
										goto IL_1a40;
									case 169:
										num8 = -1847995677;
										continue;
									case 20:
										num8 = -1847995703;
										continue;
									case 82:
										result = (decimal)(float)obj;
										num8 = -1847995677;
										continue;
									case 61:
										if (cultureInfo == null)
										{
											goto case 98;
										}
										goto IL_182b;
									case 269:
										result = (ulong)(long)obj;
										num8 = -1847995766;
										continue;
									case 139:
										result = (long)obj > 0;
										num8 = -1847995703;
										continue;
									case 105:
										num8 = -1847995766;
										continue;
									case 81:
										num8 = -1847995898;
										continue;
									case 68:
										goto IL_1897;
									case 4:
										goto IL_18bd;
									case 141:
										num8 = -1847995740;
										continue;
									case 162:
										if (object.ReferenceEquals(type, typeof(string)))
										{
											goto IL_1902;
										}
										goto case 222;
									case 135:
										if (object.ReferenceEquals(type, typeof(byte)))
										{
											result = (ulong)(byte)obj;
											num8 = -1847995766;
											continue;
										}
										goto case 142;
									case 45:
										if (object.ReferenceEquals(type, typeof(uint)))
										{
											result = (short)(uint)obj;
											num8 = -1847995900;
											continue;
										}
										goto case 270;
									case 189:
										goto end_IL_07eb;
									case 271:
										if (!ulong.TryParse(obj.ToString(), out result22))
										{
											result4 = false;
											num8 = -1847995883;
											continue;
										}
										goto case 221;
									case 138:
										result = result18;
										num8 = -1847995829;
										continue;
									case 10:
										if (object.ReferenceEquals(type, typeof(decimal)))
										{
											result = (double)(decimal)obj;
											num8 = -1847995898;
											continue;
										}
										goto case 113;
									case 56:
										goto IL_19e7;
									case 225:
										goto IL_1a0d;
									case 95:
										num8 = -1847995740;
										continue;
									case 13:
										num8 = -1847995677;
										continue;
									case 266:
										goto IL_1a40;
									case 28:
										if (object.ReferenceEquals(type, typeof(ushort)))
										{
											result = (uint)(ushort)obj;
											num8 = -1847995842;
											continue;
										}
										goto case 121;
									case 199:
										result = result12;
										num8 = -1847995898;
										continue;
									case 157:
										goto IL_1aa5;
									case 249:
										result4 = true;
										goto end_IL_07eb;
									case 200:
										result = (sbyte)(long)obj;
										num8 = -1847995701;
										continue;
									case 257:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (double)obj > 0.0;
											num8 = -1847995703;
											continue;
										}
										goto case 85;
									case 196:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (ushort)(sbyte)obj;
											num8 = -1847995576;
											continue;
										}
										goto IL_264a;
									case 115:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (decimal)(sbyte)obj;
											num8 = -1847995677;
											continue;
										}
										goto IL_28be;
									case 223:
										if (object.ReferenceEquals(targetType, typeof(Guid)))
										{
											if (object.ReferenceEquals(type, typeof(string)))
											{
												result = StringTools.ToGuid((string)obj);
												num8 = -1847995737;
												continue;
											}
											goto case 262;
										}
										goto IL_1eb3;
									case 67:
										result = (long)(uint)obj;
										num8 = -1847995679;
										continue;
									case 256:
										num8 = -1847995717;
										continue;
									case 24:
										goto IL_1bf2;
									case 268:
										goto IL_1c1f;
									case 32:
										if (!decimal.TryParse(obj.ToString(), out result15))
										{
											result4 = false;
											num8 = -1847995680;
											continue;
										}
										goto case 52;
									case 237:
										num8 = -1847995740;
										continue;
									case 140:
										if (object.ReferenceEquals(type, typeof(ulong)))
										{
											result = (ulong)obj != 0;
											num8 = -1847995703;
											continue;
										}
										goto case 257;
									case 2:
										if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
										{
											goto IL_1cb3;
										}
										goto case 216;
									case 175:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (short)(sbyte)obj;
											num8 = -1847995900;
											continue;
										}
										goto case 134;
									case 191:
										if (object.ReferenceEquals(type, typeof(int)))
										{
											result = (ulong)(int)obj;
											num8 = -1847995766;
											continue;
										}
										goto case 243;
									case 190:
										result4 = true;
										goto end_IL_07eb;
									case 234:
										result4 = false;
										goto end_IL_07eb;
									case 267:
										goto IL_1d50;
									case 142:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (ulong)(sbyte)obj;
											num8 = -1847995852;
											continue;
										}
										goto case 40;
									case 5:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (uint)(sbyte)obj;
											num8 = -1847995842;
											continue;
										}
										goto case 219;
									case 15:
										if (string.Equals((string)obj, "false", StringComparison.OrdinalIgnoreCase))
										{
											result = false;
											num8 = -1847995831;
											continue;
										}
										goto case 133;
									case 110:
										goto IL_1df7;
									case 255:
									{
										object result19;
										if (TryConvertOrCreateObject(elementType, array7.GetValue(num38), out result19, numberStyle, cultureInfo))
										{
											array5.SetValue(result19, num38);
											num8 = -1847995890;
											continue;
										}
										goto case 83;
									}
									case 112:
										if (!object.ReferenceEquals(targetType, typeof(ushort)))
										{
											goto case 71;
										}
										if (object.ReferenceEquals(type, typeof(short)))
										{
											result = (ushort)(short)obj;
											num8 = -1847995829;
											continue;
										}
										goto IL_295f;
									case 148:
										result4 = true;
										goto end_IL_07eb;
									case 52:
										result = result15;
										num8 = -1847995670;
										continue;
									case 185:
										goto IL_1eb3;
									case 213:
										if (object.ReferenceEquals(type, typeof(float)))
										{
											result = (ushort)(float)obj;
											num8 = -1847995829;
											continue;
										}
										goto case 16;
									case 44:
										result = (long)(ushort)obj;
										num8 = -1847995760;
										continue;
									case 65:
										num35++;
										num8 = -1847995717;
										continue;
									case 108:
										num8 = -1847995795;
										continue;
									case 272:
										num8 = -1847995900;
										continue;
									case 84:
										result = result20;
										num8 = -1847995842;
										continue;
									case 103:
										result = (ushort)(byte)obj;
										num8 = -1847995658;
										continue;
									case 124:
										result = (long)(decimal)obj;
										num8 = -1847995902;
										continue;
									case 156:
										num8 = -1847995829;
										continue;
									case 111:
										result = (short)obj > 0;
										num8 = -1847995899;
										continue;
									case 87:
										result4 = true;
										goto end_IL_07eb;
									case 186:
										if (object.ReferenceEquals(type, typeof(uint)))
										{
											result = (ulong)(uint)obj;
											num8 = -1847995877;
											continue;
										}
										goto IL_11d1;
									case 8:
										result4 = false;
										num8 = -1847995758;
										continue;
									case 149:
										goto IL_200b;
									case 71:
										if (!object.ReferenceEquals(targetType, typeof(byte)))
										{
											goto case 193;
										}
										goto IL_2046;
									case 92:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (uint)(double)obj;
											num8 = -1847995767;
											continue;
										}
										break;
									case 228:
										result = (short)(ulong)obj;
										num8 = -1847995571;
										continue;
									case 126:
										if (object.ReferenceEquals(type, typeof(string)))
										{
											if (string.Equals((string)obj, "true", StringComparison.OrdinalIgnoreCase))
											{
												result = true;
												num8 = -1847995703;
												continue;
											}
											goto case 15;
										}
										goto case 240;
									case 261:
										if (object.ReferenceEquals(type, typeof(short)))
										{
											result = (double)(short)obj;
											num8 = -1847995892;
											continue;
										}
										goto IL_2df7;
									case 58:
										if (object.ReferenceEquals(type, typeof(long)))
										{
											result = (decimal)(long)obj;
											num8 = -1847995677;
											continue;
										}
										goto case 69;
									case 263:
										goto end_IL_07eb;
									case 60:
										result = (ulong)(double)obj;
										num8 = -1847995669;
										continue;
									case 203:
										if (object.ReferenceEquals(type, typeof(sbyte)))
										{
											result = (sbyte)obj > 0;
											num8 = -1847995703;
											continue;
										}
										goto case 126;
									case 173:
										if (object.ReferenceEquals(type, typeof(ulong)))
										{
											result = (byte)(ulong)obj;
											num8 = -1847995795;
											continue;
										}
										goto IL_2985;
									case 122:
										array5 = Array.CreateInstance(elementType, array7.Length);
										num38 = 0;
										num8 = -1847995716;
										continue;
									case 159:
										result = result16;
										num8 = -1847995672;
										continue;
									case 274:
										result = (byte)(sbyte)obj;
										num8 = -1847995795;
										continue;
									case 204:
										if (object.ReferenceEquals(type, typeof(ulong)))
										{
											result = (long)(ulong)obj;
											num8 = -1847995674;
											continue;
										}
										goto case 76;
									case 231:
										goto IL_2243;
									case 85:
										if (object.ReferenceEquals(type, typeof(decimal)))
										{
											result = (decimal)obj > 0m;
											num8 = -1847995703;
											continue;
										}
										goto IL_27ba;
									case 195:
										if (object.ReferenceEquals(type, typeof(byte)))
										{
											result = (double)(int)(byte)obj;
											num8 = -1847995898;
											continue;
										}
										goto case 46;
									case 194:
										num8 = -1847995701;
										continue;
									case 48:
										result4 = true;
										num8 = -1847995837;
										continue;
									case 133:
										result4 = false;
										goto end_IL_07eb;
									case 113:
										if (!object.ReferenceEquals(type, typeof(string)))
										{
											goto case 201;
										}
										if (cultureInfo == null)
										{
											goto case 47;
										}
										if (!double.TryParse(obj.ToString(), numberStyle, cultureInfo, out result12))
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 199;
									case 222:
										result4 = false;
										goto end_IL_07eb;
									case 69:
										if (object.ReferenceEquals(type, typeof(uint)))
										{
											result = (decimal)(uint)obj;
											num8 = -1847995677;
											continue;
										}
										goto IL_1473;
									case 17:
										goto IL_2398;
									case 198:
										goto IL_23b0;
									case 238:
										if (!uint.TryParse(obj.ToString(), out result20))
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 84;
									case 163:
										result = (byte)(long)obj;
										num8 = -1847995795;
										continue;
									case 51:
										if (!long.TryParse(obj.ToString(), numberStyle, cultureInfo, out result14))
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 236;
									case 53:
										goto IL_2432;
									case 260:
										result4 = false;
										num8 = -1847995775;
										continue;
									case 207:
										goto end_IL_07eb;
									case 229:
										if (object.ReferenceEquals(type, typeof(ushort)))
										{
											result = (sbyte)(ushort)obj;
											num8 = -1847995745;
											continue;
										}
										goto IL_18bd;
									case 216:
										if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
										{
											array7 = obj as Array;
											num8 = -1847995865;
											continue;
										}
										goto IL_0d5b;
									case 150:
										result4 = true;
										goto end_IL_07eb;
									case 161:
									{
										object result24;
										if (TryConvertOrCreateObject(elementType, readOnlyList[num35], out result24, numberStyle, cultureInfo))
										{
											array8.SetValue(result24, num35);
											num8 = -1847995876;
											continue;
										}
										goto case 65;
									}
									case 235:
										num36++;
										num8 = -1847995749;
										continue;
									case 62:
										goto end_IL_07eb;
									case 180:
										goto IL_2528;
									case 219:
										if (!object.ReferenceEquals(type, typeof(string)))
										{
											goto case 8;
										}
										if (cultureInfo != null)
										{
											if (!uint.TryParse(obj.ToString(), numberStyle, cultureInfo, out result20))
											{
												result4 = false;
												goto end_IL_07eb;
											}
											goto case 84;
										}
										goto case 238;
									case 183:
										num8 = -1847995677;
										continue;
									case 101:
										result = array4;
										result4 = true;
										goto end_IL_07eb;
									case 40:
										if (!object.ReferenceEquals(type, typeof(string)))
										{
											goto case 233;
										}
										goto IL_25c6;
									case 70:
										num8 = -1847995766;
										continue;
									case 79:
										goto IL_25e8;
									case 19:
										if (object.ReferenceEquals(type, typeof(uint)))
										{
											result = (uint)obj != 0;
											num8 = -1847995703;
											continue;
										}
										goto IL_1642;
									case 215:
										result4 = true;
										num8 = -1847995862;
										continue;
									case 206:
										goto IL_264a;
									case 43:
										if (object.ReferenceEquals(type, typeof(short)))
										{
											result = (ulong)(short)obj;
											num8 = -1847995766;
											continue;
										}
										goto IL_2c94;
									case 244:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (sbyte)(double)obj;
											num8 = -1847995744;
											continue;
										}
										goto case 143;
									case 16:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (ushort)(double)obj;
											num8 = -1847995829;
											continue;
										}
										goto case 178;
									case 146:
										goto IL_26f7;
									case 64:
										num8 = -1847995900;
										continue;
									case 209:
										if (object.ReferenceEquals(type, typeof(short)))
										{
											result = (long)(short)obj;
											num8 = -1847995663;
											continue;
										}
										goto IL_1aa5;
									case 33:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (long)(double)obj;
											num8 = -1847995740;
											continue;
										}
										goto IL_1c1f;
									case 136:
										result4 = false;
										goto end_IL_07eb;
									case 220:
										goto end_IL_07eb;
									case 176:
										result = (sbyte)(short)obj;
										num8 = -1847995701;
										continue;
									case 145:
										goto IL_27ba;
									case 130:
										goto IL_27e0;
									case 55:
										num8 = -1847995842;
										continue;
									case 265:
										goto IL_2810;
									case 63:
										if (object.ReferenceEquals(type, typeof(byte)))
										{
											result = (short)(byte)obj;
											num8 = -1847995900;
											continue;
										}
										goto case 175;
									case 83:
										num38++;
										num8 = -1847995716;
										continue;
									case 128:
										goto IL_2872;
									case 18:
										goto IL_2898;
									case 106:
										goto IL_28be;
									case 132:
										if (!byte.TryParse(obj.ToString(), out result16))
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 159;
									case 25:
										result = result23;
										num8 = -1847995900;
										continue;
									case 184:
										goto end_IL_07eb;
									case 147:
										num8 = -1847995740;
										continue;
									case 88:
										num8 = -1847995703;
										continue;
									case 118:
										if (!short.TryParse(obj.ToString(), out result23))
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 25;
									case 75:
										goto IL_295f;
									case 197:
										goto IL_2985;
									case 93:
										result = array5;
										result4 = true;
										goto end_IL_07eb;
									case 91:
										result4 = true;
										goto end_IL_07eb;
									case 221:
										result = result22;
										num8 = -1847995766;
										continue;
									case 31:
										result = (ushort)(int)obj;
										num8 = -1847995829;
										continue;
									case 153:
										if (cultureInfo == null)
										{
											goto case 32;
										}
										if (!decimal.TryParse(obj.ToString(), numberStyle, cultureInfo, out result15))
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 52;
									case 50:
										result = (ushort)(uint)obj;
										num8 = -1847995829;
										continue;
									case 14:
										goto IL_2a44;
									case 275:
										if (!long.TryParse(obj.ToString(), out result14))
										{
											result4 = false;
											num8 = -1847995675;
											continue;
										}
										goto case 236;
									case 137:
										if (object.ReferenceEquals(type, typeof(ushort)))
										{
											result = (decimal)(ushort)obj;
											num8 = -1847995677;
											continue;
										}
										goto IL_154d;
									case 125:
										readOnlyList = obj as IReadOnlyList;
										if (readOnlyList == null)
										{
											result4 = false;
											goto end_IL_07eb;
										}
										goto case 160;
									case 164:
									{
										object result13;
										if (TryConvertOrCreateObject(elementType, serializedObject[num36].value, out result13, numberStyle, cultureInfo))
										{
											array4.SetValue(result13, num36);
											num8 = -1847995722;
											continue;
										}
										goto case 235;
									}
									case 66:
										if (object.ReferenceEquals(type, typeof(double)))
										{
											result = (short)(double)obj;
											num8 = -1847995900;
											continue;
										}
										goto IL_25e8;
									case 76:
										if (object.ReferenceEquals(type, typeof(float)))
										{
											result = (long)(float)obj;
											num8 = -1847995740;
											continue;
										}
										goto IL_2432;
									case 39:
										goto IL_2b69;
									case 177:
										result = (uint)(decimal)obj;
										num8 = -1847995798;
										continue;
									case 41:
										if (object.ReferenceEquals(type, typeof(long)))
										{
											result = (ushort)(long)obj;
											num8 = -1847995829;
											continue;
										}
										goto IL_2b69;
									case 273:
										result = (decimal)(ulong)obj;
										num8 = -1847995824;
										continue;
									case 246:
										if (object.ReferenceEquals(type, typeof(short)))
										{
											result = (uint)(short)obj;
											num8 = -1847995834;
											continue;
										}
										goto case 28;
									case 59:
										result = (ulong)(ushort)obj;
										num8 = -1847995766;
										continue;
									case 107:
										result4 = false;
										goto end_IL_07eb;
									case 264:
										if (object.ReferenceEquals(type, typeof(byte)))
										{
											result = (byte)obj > 0;
											num8 = -1847995814;
											continue;
										}
										goto case 203;
									case 253:
										num8 = -1847995701;
										continue;
									case 188:
										num8 = -1847995740;
										continue;
									case 181:
										num8 = -1847995795;
										continue;
									case 247:
										goto IL_2c94;
									case 117:
										result4 = false;
										num8 = -1847995845;
										continue;
									case 123:
										goto end_IL_07eb;
									case 131:
										if (object.ReferenceEquals(type, typeof(short)))
										{
											result = (byte)(short)obj;
											num8 = -1847995795;
											continue;
										}
										goto case 170;
									case 0:
										if (!object.ReferenceEquals(type, typeof(string)))
										{
											goto case 80;
										}
										goto IL_2d18;
									case 227:
										goto end_IL_07eb;
									case 226:
										result = (ushort)(ulong)obj;
										num8 = -1847995711;
										continue;
									case 236:
										result = result14;
										num8 = -1847995728;
										continue;
									case 1:
										num35 = 0;
										num8 = -1847995555;
										continue;
									case 251:
										if (object.ReferenceEquals(targetType, typeof(long)))
										{
											if (object.ReferenceEquals(type, typeof(int)))
											{
												result = (long)(int)obj;
												num8 = -1847995740;
												continue;
											}
											goto case 204;
										}
										goto IL_2898;
									case 121:
										if (object.ReferenceEquals(type, typeof(byte)))
										{
											result = (uint)(byte)obj;
											num8 = -1847995842;
											continue;
										}
										goto case 5;
									case 240:
										result4 = false;
										goto end_IL_07eb;
									case 11:
										goto IL_2df7;
									default:
										goto IL_2e1d;
									}
									int num39;
									if (!object.ReferenceEquals(type, typeof(decimal)))
									{
										num8 = -1847995733;
										num39 = num8;
									}
									else
									{
										num8 = -1847995668;
										num39 = num8;
									}
									continue;
									IL_2b69:
									int num40;
									if (object.ReferenceEquals(type, typeof(ulong)))
									{
										num8 = -1847995713;
										num40 = num8;
									}
									else
									{
										num8 = -1847995768;
										num40 = num8;
									}
									continue;
									IL_2528:
									int num41;
									if (!object.ReferenceEquals(type, typeof(byte)))
									{
										num8 = -1847995751;
										num41 = num8;
									}
									else
									{
										num8 = -1847995846;
										num41 = num8;
									}
									continue;
									IL_2d18:
									int num42;
									if (cultureInfo != null)
									{
										num8 = -1847995901;
										num42 = num8;
									}
									else
									{
										num8 = -1847995687;
										num42 = num8;
									}
									continue;
									IL_2898:
									int num43;
									if (object.ReferenceEquals(targetType, typeof(ulong)))
									{
										num8 = -1847995661;
										num43 = num8;
									}
									else
									{
										num8 = -1847995732;
										num43 = num8;
									}
									continue;
									IL_0fb7:
									int num44;
									if (object.ReferenceEquals(type, typeof(long)))
									{
										num8 = -1847995568;
										num44 = num8;
									}
									else
									{
										num8 = -1847995678;
										num44 = num8;
									}
									continue;
									IL_27ba:
									int num45;
									if (!object.ReferenceEquals(type, typeof(short)))
									{
										num8 = -1847995781;
										num45 = num8;
									}
									else
									{
										num8 = -1847995854;
										num45 = num8;
									}
									continue;
									IL_2810:
									int num46;
									if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
									{
										num8 = -1847995872;
										num46 = num8;
									}
									else
									{
										num8 = -1847995809;
										num46 = num8;
									}
									continue;
									IL_136d:
									int num47;
									if (!object.ReferenceEquals(type, typeof(long)))
									{
										num8 = -1847995820;
										num47 = num8;
									}
									else
									{
										num8 = -1847995656;
										num47 = num8;
									}
									continue;
									IL_2c94:
									int num48;
									if (object.ReferenceEquals(type, typeof(ushort)))
									{
										num8 = -1847995802;
										num48 = num8;
									}
									else
									{
										num8 = -1847995686;
										num48 = num8;
									}
									continue;
									IL_27e0:
									int num49;
									if (!ushort.TryParse(obj.ToString(), numberStyle, cultureInfo, out result18))
									{
										num8 = -1847995778;
										num49 = num8;
									}
									else
									{
										num8 = -1847995689;
										num49 = num8;
									}
									continue;
									IL_1642:
									int num50;
									if (object.ReferenceEquals(type, typeof(long)))
									{
										num8 = -1847995690;
										num50 = num8;
									}
									else
									{
										num8 = -1847995695;
										num50 = num8;
									}
									continue;
									IL_154d:
									int num51;
									if (!object.ReferenceEquals(type, typeof(byte)))
									{
										num8 = -1847995858;
										num51 = num8;
									}
									else
									{
										num8 = -1847995765;
										num51 = num8;
									}
									continue;
									IL_23b0:
									int num52;
									if (num36 < serializedObject.count)
									{
										num8 = -1847995655;
										num52 = num8;
									}
									else
									{
										num8 = -1847995848;
										num52 = num8;
									}
									continue;
									IL_26f7:
									int num53;
									if (!object.ReferenceEquals(type, typeof(long)))
									{
										num8 = -1847995741;
										num53 = num8;
									}
									else
									{
										num8 = -1847995755;
										num53 = num8;
									}
									continue;
									IL_25c6:
									int num54;
									if (cultureInfo != null)
									{
										num8 = -1847995777;
										num54 = num8;
									}
									else
									{
										num8 = -1847995566;
										num54 = num8;
									}
									continue;
									IL_2398:
									int num55;
									if (cultureInfo == null)
									{
										num8 = -1847995654;
										num55 = num8;
									}
									else
									{
										num8 = -1847995681;
										num55 = num8;
									}
									continue;
									IL_295f:
									int num56;
									if (object.ReferenceEquals(type, typeof(int)))
									{
										num8 = -1847995838;
										num56 = num8;
									}
									else
									{
										num8 = -1847995803;
										num56 = num8;
									}
									continue;
									IL_25e8:
									int num57;
									if (!object.ReferenceEquals(type, typeof(decimal)))
									{
										num8 = -1847995806;
										num57 = num8;
									}
									else
									{
										num8 = -1847995653;
										num57 = num8;
									}
									continue;
									IL_2432:
									int num58;
									if (object.ReferenceEquals(type, typeof(uint)))
									{
										num8 = -1847995874;
										num58 = num8;
									}
									else
									{
										num8 = -1847995780;
										num58 = num8;
									}
									continue;
									IL_1902:
									int num59;
									if (cultureInfo != null)
									{
										num8 = -1847995794;
										num59 = num8;
									}
									else
									{
										num8 = -1847995570;
										num59 = num8;
									}
									continue;
									IL_0ff2:
									int num60;
									if (object.ReferenceEquals(type, typeof(ushort)))
									{
										num8 = -1847995769;
										num60 = num8;
									}
									else
									{
										num8 = -1847995853;
										num60 = num8;
									}
									continue;
									IL_2985:
									int num61;
									if (!object.ReferenceEquals(type, typeof(float)))
									{
										num8 = -1847995881;
										num61 = num8;
									}
									else
									{
										num8 = -1847995797;
										num61 = num8;
									}
									continue;
									IL_182b:
									int num62;
									if (sbyte.TryParse(obj.ToString(), numberStyle, cultureInfo, out result21))
									{
										num8 = -1847995783;
										num62 = num8;
									}
									else
									{
										num8 = -1847995691;
										num62 = num8;
									}
									continue;
									IL_11d1:
									int num63;
									if (!object.ReferenceEquals(type, typeof(double)))
									{
										num8 = -1847995856;
										num63 = num8;
									}
									else
									{
										num8 = -1847995807;
										num63 = num8;
									}
									continue;
									IL_200b:
									int num64;
									if (object.ReferenceEquals(type, typeof(long)))
									{
										num8 = -1847995785;
										num64 = num8;
									}
									else
									{
										num8 = -1847995844;
										num64 = num8;
									}
									continue;
									IL_1a0d:
									int num65;
									if (num38 < array7.Length)
									{
										num8 = -1847995742;
										num65 = num8;
									}
									else
									{
										num8 = -1847995904;
										num65 = num8;
									}
									continue;
									IL_2046:
									int num66;
									if (object.ReferenceEquals(type, typeof(sbyte)))
									{
										num8 = -1847995569;
										num66 = num8;
									}
									else
									{
										num8 = -1847995743;
										num66 = num8;
									}
									continue;
									IL_1df7:
									int num67;
									if (!object.ReferenceEquals(type, typeof(int)))
									{
										num8 = -1847995792;
										num67 = num8;
									}
									else
									{
										num8 = -1847995763;
										num67 = num8;
									}
									continue;
									IL_0d5b:
									if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
									{
										targetType2 = ReflectionTools.GetGenericArguments(targetType)[1];
										num8 = -1847995699;
										continue;
									}
									goto IL_2f48;
									IL_12b7:
									int num68;
									if (object.ReferenceEquals(type, typeof(int)))
									{
										num8 = -1847995863;
										num68 = num8;
									}
									else
									{
										num8 = -1847995810;
										num68 = num8;
									}
									continue;
									IL_1cb3:
									list2 = obj as IList;
									int num69;
									if (list2 != null)
									{
										num8 = -1847995851;
										num69 = num8;
									}
									else
									{
										num8 = -1847995762;
										num69 = num8;
									}
									continue;
									IL_18bd:
									int num70;
									if (object.ReferenceEquals(type, typeof(string)))
									{
										num8 = -1847995808;
										num70 = num8;
									}
									else
									{
										num8 = -1847995559;
										num70 = num8;
									}
									continue;
									IL_2df7:
									int num71;
									if (object.ReferenceEquals(type, typeof(ushort)))
									{
										num8 = -1847995761;
										num71 = num8;
									}
									else
									{
										num8 = -1847995746;
										num71 = num8;
									}
									continue;
									IL_1c1f:
									int num72;
									if (object.ReferenceEquals(type, typeof(decimal)))
									{
										num8 = -1847995871;
										num72 = num8;
									}
									else
									{
										num8 = -1847995764;
										num72 = num8;
									}
									continue;
									IL_2a44:
									int num73;
									if (!object.ReferenceEquals(type, typeof(decimal)))
									{
										num8 = -1847995682;
										num73 = num8;
									}
									else
									{
										num8 = -1847995747;
										num73 = num8;
									}
									continue;
									IL_2872:
									int num74;
									if (object.ReferenceEquals(targetType, typeof(char)))
									{
										num8 = -1847995739;
										num74 = num8;
									}
									else
									{
										num8 = -1847995774;
										num74 = num8;
									}
									continue;
									IL_1eb3:
									if (ReflectionTools.IsArray(targetType))
									{
										elementType = targetType.GetElementType();
										int num75;
										if (!ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
										{
											num8 = -1847995564;
											num75 = num8;
										}
										else
										{
											num8 = -1847995575;
											num75 = num8;
										}
										continue;
									}
									goto IL_3399;
									IL_19e7:
									int num76;
									if (object.ReferenceEquals(type, typeof(uint)))
									{
										num8 = -1847995793;
										num76 = num8;
									}
									else
									{
										num8 = -1847995788;
										num76 = num8;
									}
									continue;
									IL_1aa5:
									int num77;
									if (object.ReferenceEquals(type, typeof(ushort)))
									{
										num8 = -1847995791;
										num77 = num8;
									}
									else
									{
										num8 = -1847995684;
										num77 = num8;
									}
									continue;
									IL_1393:
									if (object.ReferenceEquals(targetType, typeof(decimal)))
									{
										int num78;
										if (object.ReferenceEquals(type, typeof(float)))
										{
											num8 = -1847995889;
											num78 = num8;
										}
										else
										{
											num8 = -1847995830;
											num78 = num8;
										}
										continue;
									}
									goto IL_2872;
									IL_28be:
									int num79;
									if (object.ReferenceEquals(type, typeof(string)))
									{
										num8 = -1847995708;
										num79 = num8;
									}
									else
									{
										num8 = -1847995721;
										num79 = num8;
									}
									continue;
									IL_1897:
									int num80;
									if (object.ReferenceEquals(type, typeof(ulong)))
									{
										num8 = -1847995719;
										num80 = num8;
									}
									else
									{
										num8 = -1847995867;
										num80 = num8;
									}
									continue;
									IL_1a40:
									int num81;
									if (!object.ReferenceEquals(type, typeof(long)))
									{
										num8 = -1847995664;
										num81 = num8;
									}
									else
									{
										num8 = -1847995650;
										num81 = num8;
									}
									continue;
									IL_264a:
									int num82;
									if (!object.ReferenceEquals(type, typeof(string)))
									{
										num8 = -1847995850;
										num82 = num8;
									}
									else
									{
										num8 = -1847995828;
										num82 = num8;
									}
									continue;
									IL_1473:
									int num83;
									if (object.ReferenceEquals(type, typeof(ulong)))
									{
										num8 = -1847995572;
										num83 = num8;
									}
									else
									{
										num8 = -1847995857;
										num83 = num8;
									}
									continue;
									IL_1527:
									int num84;
									if (!object.ReferenceEquals(type, typeof(short)))
									{
										num8 = -1847995720;
										num84 = num8;
									}
									else
									{
										num8 = -1847995667;
										num84 = num8;
									}
									continue;
									end_IL_07eb:
									break;
								}
								goto end_IL_0071;
								IL_1bf2:
								if (object.ReferenceEquals(type, typeof(int)))
								{
									result = (double)(int)obj;
									num8 = -1847995898;
									goto IL_07eb;
								}
								goto IL_0f72;
								IL_04a7:
								if (object.ReferenceEquals(targetType, typeof(int)))
								{
									if (object.ReferenceEquals(type, typeof(float)))
									{
										result = (int)(float)obj;
										num4 = -1847995833;
										goto IL_0093;
									}
									goto IL_0179;
								}
								goto IL_03d6;
								IL_06df:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (float)(uint)obj;
									num4 = -1847995814;
									goto IL_0093;
								}
								goto IL_065a;
								IL_31c8:
								int num85;
								while (true)
								{
									switch (num85 ^ -1847995811)
									{
									case 10:
										break;
									case 17:
										result4 = true;
										goto end_IL_0071;
									case 22:
										if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
										{
											readOnlyList2 = obj as IReadOnlyList;
											list7 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type4));
											num85 = -1847995820;
											continue;
										}
										goto case 3;
									case 19:
										goto IL_32a9;
									case 2:
										goto IL_32bb;
									case 7:
										goto IL_32eb;
									case 12:
										num87++;
										num85 = -1847995824;
										continue;
									case 13:
										goto IL_331a;
									case 21:
										if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
										{
											array9 = obj as Array;
											list4 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type4));
											num87 = 0;
											num85 = -1847995824;
											continue;
										}
										goto IL_35d4;
									case 26:
										result4 = true;
										goto end_IL_0071;
									case 18:
										goto IL_3399;
									case 6:
										result = list4;
										num85 = -1847995833;
										continue;
									case 5:
										result4 = true;
										goto end_IL_0071;
									case 8:
										num88++;
										num85 = -1847995831;
										continue;
									case 28:
										num89++;
										num85 = -1847995830;
										continue;
									case 23:
										if (num89 >= readOnlyList2.Count)
										{
											result = list7;
											num85 = -1847995828;
											continue;
										}
										goto case 15;
									case 9:
										num89 = 0;
										num85 = -1847995830;
										continue;
									case 15:
									{
										object result28;
										if (TryConvertOrCreateObject(type4, readOnlyList2[num89], out result28, numberStyle, cultureInfo))
										{
											list7.Add(result28);
											num85 = -1847995839;
											continue;
										}
										goto case 28;
									}
									case 3:
										if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
										{
											list5 = obj as IList;
											list6 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type4));
											num88 = 0;
											num85 = -1847995811;
											continue;
										}
										goto case 21;
									case 24:
										if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
										{
											serializedObject2 = obj as SerializedObject;
											list3 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type4));
											num86 = 0;
											num85 = -1847995814;
											continue;
										}
										goto case 22;
									case 20:
										if (num88 < list5.Count)
										{
											goto case 27;
										}
										result = list6;
										result4 = true;
										goto end_IL_0071;
									case 1:
										list3.Add(result26);
										num85 = -1847995836;
										continue;
									case 11:
									{
										object result25;
										if (TryConvertOrCreateObject(type4, array9.GetValue(num87), out result25, numberStyle, cultureInfo))
										{
											list4.Add(result25);
											num85 = -1847995823;
											continue;
										}
										goto case 12;
									}
									case 16:
										result = list3;
										num85 = -1847995815;
										continue;
									case 0:
										num85 = -1847995831;
										continue;
									case 25:
										num86++;
										num85 = -1847995814;
										continue;
									case 4:
										result4 = true;
										goto end_IL_0071;
									case 27:
									{
										object result27;
										if (TryConvertOrCreateObject(type4, list5[num88], out result27, numberStyle, cultureInfo))
										{
											list6.Add(result27);
											num85 = -1847995819;
											continue;
										}
										goto case 8;
									}
									default:
										goto IL_35d4;
									}
									break;
									IL_331a:
									int num90;
									if (num87 >= array9.Length)
									{
										num85 = -1847995813;
										num90 = num85;
									}
									else
									{
										num85 = -1847995818;
										num90 = num85;
									}
									continue;
									IL_32eb:
									int num91;
									if (num86 < serializedObject2.count)
									{
										num85 = -1847995809;
										num91 = num85;
									}
									else
									{
										num85 = -1847995827;
										num91 = num85;
									}
									continue;
									IL_32bb:
									int num92;
									if (!TryConvertOrCreateObject(type4, serializedObject2[num86].value, out result26, numberStyle, cultureInfo))
									{
										num85 = -1847995836;
										num92 = num85;
									}
									else
									{
										num85 = -1847995812;
										num92 = num85;
									}
								}
								goto IL_31c3;
								IL_065a:
								int num93;
								if (object.ReferenceEquals(type, typeof(long)))
								{
									num4 = -1847995813;
									num93 = num4;
								}
								else
								{
									num4 = -1847995830;
									num93 = num4;
								}
								goto IL_0093;
								IL_3399:
								if (ReflectionTools.IsGenericType(targetType))
								{
									genericTypeDefinition = targetType.GetGenericTypeDefinition();
									if (ReflectionTools.DoesTypeImplement(targetType, typeof(IList)))
									{
										type4 = ReflectionTools.GetGenericArguments(targetType)[0];
										num85 = -1847995835;
										goto IL_31c8;
									}
									goto IL_3702;
								}
								goto IL_38fc;
								IL_31c3:
								num85 = -1847995816;
								goto IL_31c8;
								end_IL_0071:;
							}
							catch (Exception message)
							{
								Debug.LogError(message);
								goto IL_393b;
							}
							return result4;
						}
						IL_393b:
						return false;
					}
					break;
					IL_0055:
					type = obj.GetType();
					num = -1847995811;
				}
			}
		}

		private static bool TryCreateObject(Type type, SerializedObject serializedObject, out object result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			if (serializedObject != null)
			{
				goto IL_0006;
			}
			goto IL_00c1;
			IL_0006:
			int num = -2055221646;
			goto IL_000b;
			IL_000b:
			Dictionary<string, FieldInfo> value = default(Dictionary<string, FieldInfo>);
			Dictionary<string, PropertyInfo> value4 = default(Dictionary<string, PropertyInfo>);
			PropertyInfo value5 = default(PropertyInfo);
			while (true)
			{
				switch (num ^ -2055221644)
				{
				case 5:
					break;
				case 4:
					if (!qYckNrBSyujMzyehMpRjtDcTIDIi.TryGetValue(type, out value))
					{
						value = ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(delegate(FieldInfo P_0)
						{
							if (!P_0.IsPublic)
							{
								while (true)
								{
									int num4 = 1909619261;
									while (true)
									{
										switch (num4 ^ 0x71D27A3F)
										{
										case 0:
											break;
										case 2:
											goto IL_002a;
										case 1:
											goto IL_004e;
										default:
											goto end_IL_0008;
										}
										break;
										IL_004e:
										if (P_0.IsDefined(typeof(SerializeField), true))
										{
											num4 = 1909619260;
											continue;
										}
										goto IL_0090;
										IL_002a:
										int num5;
										if (P_0.IsDefined(typeof(SerializeAttribute), true))
										{
											num4 = 1909619260;
											num5 = num4;
										}
										else
										{
											num4 = 1909619262;
											num5 = num4;
										}
									}
									continue;
									end_IL_0008:
									break;
								}
							}
							if (!P_0.IsDefined(typeof(NonSerializedAttribute), true))
							{
								return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
							}
							goto IL_0090;
							IL_0090:
							return false;
						}).ToDictionary((FieldInfo P_0) =>
						{
							string name2;
							return (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name)) ? name2 : P_0.Name;
						});
						qYckNrBSyujMzyehMpRjtDcTIDIi.Add(type, value);
						num = -2055221641;
						continue;
					}
					goto case 3;
				case 0:
					return false;
				case 2:
					goto IL_00c1;
				case 6:
					goto IL_00ce;
				case 3:
					if (!KOvzKrYXYIdzJcnlYhhJBslYfOB.TryGetValue(type, out value4))
					{
						value4 = (from P_0 in ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
							where P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), true) && !P_0.IsDefined(typeof(DoNotSerializeAttribute), true)
							select P_0).ToDictionary((PropertyInfo P_0) =>
						{
							string name2;
							return (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name)) ? name2 : P_0.Name;
						});
						KOvzKrYXYIdzJcnlYhhJBslYfOB.Add(type, value4);
						num = -2055221643;
						continue;
					}
					goto default;
				default:
				{
					using (IEnumerator<Field> enumerator = ((IEnumerable<Field>)serializedObject).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							while (true)
							{
								IL_01d3:
								Field current = enumerator.Current;
								string name = current.name;
								object value2 = current.value;
								FieldInfo value3;
								object result2;
								int num2;
								if (value.TryGetValue(name, out value3))
								{
									if (!TryConvertOrCreateObject(value3.FieldType, value2, out result2, numberStyle, cultureInfo))
									{
										break;
									}
									value3.SetValue(result, result2);
									num2 = -2055221641;
									goto IL_015f;
								}
								goto IL_01ae;
								IL_01ae:
								if (!value4.TryGetValue(name, out value5))
								{
									break;
								}
								int num3;
								if (!value5.CanWrite)
								{
									num2 = -2055221641;
									num3 = num2;
								}
								else
								{
									num2 = -2055221648;
									num3 = num2;
								}
								goto IL_015f;
								IL_015f:
								while (true)
								{
									switch (num2 ^ -2055221644)
									{
									case 0:
										num2 = -2055221643;
										continue;
									case 4:
										if (TryConvertOrCreateObject(value5.PropertyType, value2, out result2, numberStyle, cultureInfo))
										{
											value5.SetValue(result, result2, null);
											num2 = -2055221641;
											continue;
										}
										goto end_IL_01d3;
									case 2:
										break;
									case 1:
										goto IL_01d3;
									default:
										goto end_IL_01d3;
									}
									break;
								}
								goto IL_01ae;
								continue;
								end_IL_01d3:
								break;
							}
						}
					}
					ISerializationCallbackReceiver serializationCallbackReceiver = result as ISerializationCallbackReceiver;
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
					return true;
				}
				}
				break;
				IL_00ce:
				if (type != null)
				{
					result = Factory.CreateInstance(type);
					num = -2055221648;
				}
				else
				{
					num = -2055221642;
				}
			}
			goto IL_0006;
			IL_00c1:
			result = null;
			num = -2055221644;
			goto IL_000b;
		}

		public static SerializedObject FromJson(Type type, string jsonString)
		{
			if (type == null)
			{
				goto IL_0003;
			}
			goto IL_007e;
			IL_0003:
			int num = 1035665648;
			goto IL_0008;
			IL_0008:
			SerializedObject serializedObject = default(SerializedObject);
			switch (num ^ 0x3DBB00F3)
			{
			case 0:
				break;
			case 2:
				goto IL_002d;
			case 5:
				goto IL_005a;
			case 3:
				throw new ArgumentNullException("type");
			case 4:
				goto IL_007e;
			default:
				return serializedObject;
			}
			goto IL_0003;
			IL_005a:
			throw new Exception("No data found in Json string.");
			IL_007e:
			if (string.IsNullOrEmpty(jsonString))
			{
				throw new ArgumentNullException("jsonString");
			}
			goto IL_002d;
			IL_002d:
			serializedObject = JsonParser.FromJson<SerializedObject>(jsonString, typeof(SerializedObject));
			if (serializedObject != null)
			{
				int num2;
				if (serializedObject.count != 0)
				{
					num = 1035665650;
					num2 = num;
				}
				else
				{
					num = 1035665654;
					num2 = num;
				}
				goto IL_0008;
			}
			goto IL_005a;
		}

		public static SerializedObject FromXml(Type type, string xmlString)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			SerializedObject serializedObject = default(SerializedObject);
			while (!string.IsNullOrEmpty(xmlString))
			{
				while (true)
				{
					XmlDocument xmlDocument = new XmlDocument(xmlString);
					if (!xmlDocument.isValid)
					{
						throw new Exception("Failed to parse XML string.");
					}
					while (true)
					{
						IL_00c3:
						if (xmlDocument.root.childCount == 0)
						{
							throw new Exception("No data found in XML string.");
						}
						while (true)
						{
							IL_0110:
							XmlDocument.Element element = xmlDocument.root.FindChild(type.Name);
							int num = -1852218074;
							while (true)
							{
								switch (num ^ -1852218080)
								{
								case 0:
									num = -1852218076;
									continue;
								case 9:
									if (serializedObject != null)
									{
										goto IL_0054;
									}
									goto case 7;
								case 6:
									if (element == null)
									{
										throw new Exception("Main element not found in XML string.");
									}
									goto case 1;
								case 5:
									break;
								case 4:
									goto end_IL_0082;
								case 3:
									goto IL_00c3;
								case 1:
									serializedObject = element.GetSerializedObject() as SerializedObject;
									num = -1852218071;
									continue;
								case 7:
									throw new Exception("No data found in XML string.");
								case 8:
									goto IL_0110;
								default:
									return serializedObject;
								}
								break;
								IL_0054:
								int num2;
								if (serializedObject.count == 0)
								{
									num = -1852218073;
									num2 = num;
								}
								else
								{
									num = -1852218078;
									num2 = num;
								}
							}
							break;
						}
						break;
					}
					continue;
					end_IL_0082:
					break;
				}
			}
			throw new ArgumentNullException("xmlString");
		}

		[CompilerGenerated]
		private static bool xDQXVGqDGQYozgxUjRXNclCToMK(FieldInfo P_0)
		{
			if (!P_0.IsPublic)
			{
				while (true)
				{
					int num = 1909619261;
					while (true)
					{
						switch (num ^ 0x71D27A3F)
						{
						case 0:
							break;
						case 2:
							goto IL_002a;
						case 1:
							goto IL_004e;
						default:
							goto end_IL_0008;
						}
						break;
						IL_004e:
						if (P_0.IsDefined(typeof(SerializeField), true))
						{
							num = 1909619260;
							continue;
						}
						goto IL_0090;
						IL_002a:
						int num2;
						if (P_0.IsDefined(typeof(SerializeAttribute), true))
						{
							num = 1909619260;
							num2 = num;
						}
						else
						{
							num = 1909619262;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!P_0.IsDefined(typeof(NonSerializedAttribute), true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
			}
			goto IL_0090;
			IL_0090:
			return false;
		}

		[CompilerGenerated]
		private static string QKPmcLKtSjNHgfEjrqzLZkYWUGt(FieldInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}

		[CompilerGenerated]
		private static bool dWywCRrivdyldKSTyVYMaIjulGV(PropertyInfo P_0)
		{
			if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string kWZGcqgTbpLelKKxidPNeXNiWanx(PropertyInfo P_0)
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
