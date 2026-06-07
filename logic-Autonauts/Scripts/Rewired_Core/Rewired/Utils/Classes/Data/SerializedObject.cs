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
				text = text + "value = " + ((value != null) ? value.ToString() : "NULL") + "\n";
				object[] array = default(object[]);
				while (true)
				{
					int num = 1599116823;
					while (true)
					{
						switch (num ^ 0x5F509616)
						{
						case 2:
							break;
						case 1:
							goto IL_007a;
						default:
							array[3] = "\n";
							return string.Concat(array);
						}
						break;
						IL_007a:
						object obj = text;
						array = new object[4] { obj, "options = ", options, null };
						num = 1599116822;
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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
				text = text + "type = " + (((object)type != null) ? type.Name : "NULL") + "\n";
				object obj = text;
				return string.Concat(obj, "options = ", options, "\n");
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
					while (true)
					{
						int num = 1266575142;
						while (true)
						{
							switch (num ^ 0x4B7E6724)
							{
							case 0:
								break;
							case 2:
								goto IL_0052;
							default:
								return text + "value = " + value + "\n";
							}
							break;
							IL_0052:
							text = text + "ns = " + ns + "\n";
							num = 1266575141;
						}
					}
				}
			}

			private List<XmlAttribute> zWLuItIXFQMLfNAKEJgqilNJPHx;

			public List<XmlAttribute> attributes
			{
				get
				{
					return zWLuItIXFQMLfNAKEJgqilNJPHx ?? (zWLuItIXFQMLfNAKEJgqilNJPHx = new List<XmlAttribute>());
				}
			}

			public override string ToString()
			{
				string text = "Attributes:\n";
				if (zWLuItIXFQMLfNAKEJgqilNJPHx != null)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < zWLuItIXFQMLfNAKEJgqilNJPHx.Count)
						{
							num2 = 1758474719;
							num3 = num2;
						}
						else
						{
							num2 = 1758474718;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x68D031DC)
							{
							case 0:
								num2 = 1758474719;
								continue;
							case 3:
								text = text + zWLuItIXFQMLfNAKEJgqilNJPHx[num].ToString() + "\n";
								num++;
								num2 = 1758474717;
								continue;
							case 1:
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
			private IndexedDictionary<string, Entry> kByLbWRXiXsWnZdJKBoJqLwPfkS;

			private Field CLjmYleEuCraJMMUJEFwtuAaGlg;

			private IEnumerator<KeyValuePair<string, Entry>> bXHxTzHsAVFzRlQtEhjipjovrQi;

			public Field Current
			{
				get
				{
					return CLjmYleEuCraJMMUJEFwtuAaGlg;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return CLjmYleEuCraJMMUJEFwtuAaGlg;
				}
			}

			internal Enumerator(object dictionary)
			{
				kByLbWRXiXsWnZdJKBoJqLwPfkS = (IndexedDictionary<string, Entry>)dictionary;
				CLjmYleEuCraJMMUJEFwtuAaGlg = default(Field);
				bXHxTzHsAVFzRlQtEhjipjovrQi = kByLbWRXiXsWnZdJKBoJqLwPfkS.GetEnumerator();
			}

			public bool MoveNext()
			{
				if (!bXHxTzHsAVFzRlQtEhjipjovrQi.MoveNext())
				{
					goto IL_000d;
				}
				KeyValuePair<string, Entry> current = bXHxTzHsAVFzRlQtEhjipjovrQi.Current;
				int num = 1002962937;
				goto IL_0012;
				IL_0012:
				switch (num ^ 0x3BC7FFFB)
				{
				case 0:
					break;
				case 1:
					return false;
				default:
					CLjmYleEuCraJMMUJEFwtuAaGlg = new Field(current.Key, current.Value.value, current.Value.type, current.Value.options);
					return true;
				}
				goto IL_000d;
				IL_000d:
				num = 1002962938;
				goto IL_0012;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				CLjmYleEuCraJMMUJEFwtuAaGlg = default(Field);
				bXHxTzHsAVFzRlQtEhjipjovrQi = kByLbWRXiXsWnZdJKBoJqLwPfkS.GetEnumerator();
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
					while (true)
					{
						int num = -589345993;
						while (true)
						{
							switch (num ^ -589345995)
							{
							case 0:
								break;
							default:
								return;
							case 2:
								this.name = name;
								this.parent = parent;
								if (parent != null)
								{
									goto IL_0035;
								}
								return;
							case 1:
								return;
							}
							break;
							IL_0035:
							parent.AddChild(this);
							num = -589345996;
						}
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
						if (children == null)
						{
							children = new List<Element>();
							num = -1398528544;
							goto IL_0009;
						}
						goto IL_0040;
						IL_0009:
						while (true)
						{
							switch (num ^ -1398528543)
							{
							case 3:
								num = -1398528541;
								continue;
							default:
								return;
							case 2:
								break;
							case 1:
								goto IL_0040;
							case 0:
								return;
							}
							break;
						}
						continue;
						IL_0040:
						children.Add(element);
						num = -1398528543;
						goto IL_0009;
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
						int num2;
						if (attributes == null)
						{
							num = -830186901;
							num2 = num;
						}
						else
						{
							num = -830186899;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -830186898)
							{
							case 0:
								num = -830186902;
								continue;
							case 4:
								break;
							case 5:
								attributes = new Dictionary<string, string>();
								num = -830186899;
								continue;
							case 1:
								attributes[key] = value;
								return;
							case 3:
							{
								int num3;
								if (attributes.ContainsKey(key))
								{
									num = -830186897;
									num3 = num;
								}
								else
								{
									num = -830186900;
									num3 = num;
								}
								continue;
							}
							default:
								attributes.Add(key, value);
								return;
							}
							break;
						}
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
						goto IL_0008;
					}
					int num = 0;
					int num2 = 727691753;
					goto IL_000d;
					IL_000d:
					while (true)
					{
						switch (num2 ^ 0x2B5FB1E8)
						{
						case 2:
							break;
						case 3:
							return null;
						case 0:
							if (!string.Equals(children[num].name, name, StringComparison.Ordinal))
							{
								goto IL_005c;
							}
							return children[num];
						default:
							if (num >= children.Count)
							{
								return null;
							}
							goto case 0;
						}
						break;
						IL_005c:
						num++;
						num2 = 727691753;
					}
					goto IL_0008;
					IL_0008:
					num2 = 727691755;
					goto IL_000d;
				}

				public object GetSerializedObject()
				{
					if (childCount == 0)
					{
						goto IL_0008;
					}
					SerializedObject serializedObject = new SerializedObject(null, ObjectType.List);
					int num = 0;
					int num2 = -1636818259;
					goto IL_000d;
					IL_000d:
					Element element = default(Element);
					while (true)
					{
						switch (num2 ^ -1636818264)
						{
						case 6:
							break;
						case 1:
							return content;
						case 3:
							element = children[num];
							num2 = -1636818262;
							continue;
						case 4:
							num++;
							num2 = -1636818259;
							continue;
						case 2:
							if (element != null)
							{
								serializedObject.Add(element.name, element.GetSerializedObject());
								num2 = -1636818260;
								continue;
							}
							goto case 4;
						case 5:
						{
							int num3;
							if (num < childCount)
							{
								num2 = -1636818261;
								num3 = num2;
							}
							else
							{
								num2 = -1636818264;
								num3 = num2;
							}
							continue;
						}
						default:
							return serializedObject;
						}
						break;
					}
					goto IL_0008;
					IL_0008:
					num2 = -1636818263;
					goto IL_000d;
				}

				public override string ToString()
				{
					return ToString("", 0);
				}

				private string ToString(string s, int indent)
				{
					string text = "";
					string[] array4 = default(string[]);
					object[] array = default(object[]);
					int num5 = default(int);
					object obj2 = default(object);
					string[] array2 = default(string[]);
					string text2 = default(string);
					while (true)
					{
						int num = -419612577;
						while (true)
						{
							switch (num ^ -419612578)
							{
							case 9:
								break;
							case 6:
								array4[3] = name;
								num = -419612578;
								continue;
							case 2:
								array[1] = text;
								num = -419612579;
								continue;
							case 8:
								text += "    ";
								num5++;
								num = -419612583;
								continue;
							case 4:
								array[0] = obj2;
								num = -419612580;
								continue;
							case 0:
							{
								array4[4] = "\n";
								s = string.Concat(array4);
								string text5 = s;
								s = text5 + text + "Content = " + ((content == null) ? "NULL" : content.ToString()) + "\n";
								obj2 = s;
								array = new object[5];
								num = -419612582;
								continue;
							}
							case 1:
								num5 = 0;
								num = -419612583;
								continue;
							case 7:
								if (num5 >= indent)
								{
									string text4 = s;
									array4 = new string[5] { text4, text, "Name = ", null, null };
									num = -419612584;
									continue;
								}
								goto case 8;
							case 3:
								array[2] = "Attribute Count = ";
								num = -419612581;
								continue;
							default:
							{
								array[3] = attributeCount;
								array[4] = "\n";
								s = string.Concat(array);
								if (attributes != null)
								{
									using (Dictionary<string, string>.Enumerator enumerator = attributes.GetEnumerator())
									{
										while (enumerator.MoveNext())
										{
											while (true)
											{
												KeyValuePair<string, string> current = enumerator.Current;
												int num2 = -419612580;
												while (true)
												{
													switch (num2 ^ -419612578)
													{
													case 0:
														num2 = -419612581;
														continue;
													case 1:
														array2 = new string[7] { text2, text, "Attribute ", null, null, null, null };
														num2 = -419612582;
														continue;
													case 3:
														array2[6] = "\n";
														s = string.Concat(array2);
														num2 = -419612584;
														continue;
													case 5:
														break;
													case 2:
														text2 = s;
														num2 = -419612577;
														continue;
													case 4:
														array2[3] = current.Key;
														array2[4] = ": = ";
														array2[5] = current.Value;
														num2 = -419612579;
														continue;
													default:
														goto end_IL_01f4;
													}
													break;
												}
												continue;
												end_IL_01f4:
												break;
											}
										}
									}
								}
								object obj = s;
								object[] array3 = new object[5] { obj, null, null, null, null };
								while (true)
								{
									int num3 = -419612580;
									while (true)
									{
										switch (num3 ^ -419612578)
										{
										case 0:
											break;
										case 2:
											array3[1] = text;
											array3[2] = "Child Count = ";
											num3 = -419612577;
											continue;
										case 1:
											array3[3] = childCount;
											array3[4] = "\n";
											s = string.Concat(array3);
											if (children != null)
											{
												num3 = -419612579;
												continue;
											}
											goto IL_0355;
										default:
											{
												string text3 = "";
												using (List<Element>.Enumerator enumerator2 = children.GetEnumerator())
												{
													while (enumerator2.MoveNext())
													{
														while (true)
														{
															Element current2 = enumerator2.Current;
															text3 += "\n";
															int num4 = -419612579;
															while (true)
															{
																switch (num4 ^ -419612578)
																{
																case 0:
																	num4 = -419612580;
																	continue;
																case 2:
																	break;
																case 3:
																	text3 = current2.ToString(text3, indent + 1);
																	num4 = -419612577;
																	continue;
																default:
																	goto end_IL_0304;
																}
																break;
															}
															continue;
															end_IL_0304:
															break;
														}
													}
												}
												s += text3;
												goto IL_0355;
											}
											IL_0355:
											return s;
										}
										break;
									}
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
				int num = 0;
				int num4 = default(int);
				bool flag = default(bool);
				bool isEmptyElement = default(bool);
				while (true)
				{
					int num2;
					int num3;
					if (!reader.Read())
					{
						num2 = -2015757496;
						num3 = num2;
					}
					else
					{
						num2 = -2015757497;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -2015757496)
						{
						case 8:
							num2 = -2015757497;
							continue;
						default:
							return;
						case 20:
							num++;
							num2 = -2015757501;
							continue;
						case 12:
							if (reader.IsStartElement())
							{
								bool isEmptyElement2 = reader.IsEmptyElement;
								element = new Element(reader.LocalName, element);
								num4 = 0;
								num2 = -2015757503;
								continue;
							}
							goto case 18;
						case 7:
							num++;
							num2 = -2015757501;
							continue;
						case 5:
							num2 = -2015757478;
							continue;
						case 1:
						{
							int num7;
							if (!reader.HasValue)
							{
								num2 = -2015757493;
								num7 = num2;
							}
							else
							{
								num2 = -2015757498;
								num7 = num2;
							}
							continue;
						}
						case 18:
							if (!flag)
							{
								int num6;
								if (reader.NodeType == XmlNodeType.EndElement)
								{
									num2 = -2015757475;
									num6 = num2;
								}
								else
								{
									num2 = -2015757476;
									num6 = num2;
								}
								continue;
							}
							goto case 21;
						case 2:
						{
							int num11;
							if (!reader.IsEmptyElement)
							{
								num2 = -2015757478;
								num11 = num2;
							}
							else
							{
								num2 = -2015757490;
								num11 = num2;
							}
							continue;
						}
						case 22:
							element.AddAttribute(reader.Name, reader.Value);
							num4++;
							num2 = -2015757480;
							continue;
						case 19:
							reader.MoveToNextAttribute();
							num2 = -2015757474;
							continue;
						case 15:
						{
							int num10;
							switch (reader.NodeType)
							{
							case XmlNodeType.Comment:
								break;
							default:
								num2 = -2015757492;
								num10 = num2;
								continue;
							case XmlNodeType.XmlDeclaration:
								num2 = -2015757489;
								num10 = num2;
								continue;
							}
							goto case 7;
						}
						case 4:
						{
							flag = false;
							int num9;
							if (reader.NodeType != XmlNodeType.Element)
							{
								num2 = -2015757479;
								num9 = num2;
							}
							else
							{
								num2 = -2015757500;
								num9 = num2;
							}
							continue;
						}
						case 9:
							num2 = -2015757480;
							continue;
						case 6:
							flag = true;
							num2 = -2015757491;
							continue;
						case 11:
							break;
						case 14:
							element.content = reader.ReadContentAsString();
							num2 = -2015757478;
							continue;
						case 3:
							flag = true;
							num2 = -2015757478;
							continue;
						case 13:
						{
							int num8;
							if (isEmptyElement)
							{
								num2 = -2015757493;
								num8 = num2;
							}
							else
							{
								num2 = -2015757495;
								num8 = num2;
							}
							continue;
						}
						case 21:
							if (element != null && element != _root && reader.Name == element.name)
							{
								element = element.parent;
								num2 = -2015757476;
								continue;
							}
							goto case 20;
						case 17:
							if (reader.NodeType == XmlNodeType.Text)
							{
								isEmptyElement = reader.IsEmptyElement;
								num2 = -2015757499;
								continue;
							}
							goto case 10;
						case 10:
						{
							XmlNodeType nodeType = reader.NodeType;
							int num12 = 15;
							num2 = -2015757478;
							continue;
						}
						case 16:
						{
							int num5;
							if (num4 >= reader.AttributeCount)
							{
								num2 = -2015757494;
								num5 = num2;
							}
							else
							{
								num2 = -2015757477;
								num5 = num2;
							}
							continue;
						}
						case 0:
							return;
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

		private readonly IndexedDictionary<string, Entry> DfrXwxPlmqecDNirhBhnXpgMtSm;

		private XmlInfo PYTtAvhhKZwWArYkEkMRZOUnwfi;

		private Type JNNGbJEWijctWBKzGmlLLQzaVVsi;

		private ObjectType GTVNGoiiOfQCvZVixHIrMuLKeCg;

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

		private bool allowDuplicateKeys
		{
			get
			{
				return GTVNGoiiOfQCvZVixHIrMuLKeCg == ObjectType.List;
			}
		}

		public ObjectType objectType
		{
			get
			{
				return GTVNGoiiOfQCvZVixHIrMuLKeCg;
			}
			set
			{
				if (value == GTVNGoiiOfQCvZVixHIrMuLKeCg)
				{
					return;
				}
				while (true)
				{
					GTVNGoiiOfQCvZVixHIrMuLKeCg = value;
					int num = -1319402885;
					while (true)
					{
						switch (num ^ -1319402887)
						{
						case 0:
							goto IL_000a;
						case 1:
							break;
						default:
							DfrXwxPlmqecDNirhBhnXpgMtSm.AllowDuplicateKeys = allowDuplicateKeys;
							return;
						}
						break;
						IL_000a:
						num = -1319402888;
					}
				}
			}
		}

		public Type type
		{
			get
			{
				return JNNGbJEWijctWBKzGmlLLQzaVVsi;
			}
		}

		public XmlInfo xmlInfo
		{
			get
			{
				return PYTtAvhhKZwWArYkEkMRZOUnwfi;
			}
			set
			{
				PYTtAvhhKZwWArYkEkMRZOUnwfi = value;
			}
		}

		public int count
		{
			get
			{
				return DfrXwxPlmqecDNirhBhnXpgMtSm.Count;
			}
		}

		public Field this[int index]
		{
			get
			{
				Entry entry = DfrXwxPlmqecDNirhBhnXpgMtSm[index];
				string keyAt = DfrXwxPlmqecDNirhBhnXpgMtSm.GetKeyAt(index);
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
			GTVNGoiiOfQCvZVixHIrMuLKeCg = ObjectType.List;
			DfrXwxPlmqecDNirhBhnXpgMtSm = new IndexedDictionary<string, Entry>(capacity, true);
		}

		public SerializedObject(Type type, ObjectType objectType)
			: this(type, objectType, 0)
		{
		}

		public SerializedObject(Type type, ObjectType objectType, int capacity)
			: this(capacity)
		{
			JNNGbJEWijctWBKzGmlLLQzaVVsi = type;
			this.objectType = objectType;
		}

		public SerializedObject(Type type, IDictionary<string, object> dictionary, ObjectType objectType)
			: this(type, objectType, (dictionary != null) ? dictionary.Count : 0)
		{
			while (true)
			{
				switch (0x2A1EF3DB ^ 0x2A1EF3D9)
				{
				case 0:
					continue;
				case 2:
					if ((object)type == null)
					{
						throw new ArgumentNullException("dictionary");
					}
					break;
				}
				break;
			}
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				DfrXwxPlmqecDNirhBhnXpgMtSm.Add(item.Key, new Entry((item.Value != null) ? item.Value.GetType() : null, item.Value, FieldOptions.None));
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
				goto IL_0006;
			}
			goto IL_0124;
			IL_0006:
			int num = -712570705;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num ^ -712570710)
				{
				case 7:
					break;
				case 6:
					goto IL_0047;
				case 4:
					if (!object.ReferenceEquals(type, value.GetType()))
					{
						throw new Exception("Type does not match value type.");
					}
					goto IL_0124;
				case 5:
					goto IL_0089;
				case 3:
					fieldName = "value";
					num = -712570709;
					continue;
				case 2:
					DfrXwxPlmqecDNirhBhnXpgMtSm.Add(fieldName, new Entry(type, value, options));
					return;
				case 8:
					if (GTVNGoiiOfQCvZVixHIrMuLKeCg != ObjectType.List)
					{
						throw new ArgumentNullException("fieldName");
					}
					goto case 3;
				case 1:
					if (allowDuplicateKeys)
					{
						DfrXwxPlmqecDNirhBhnXpgMtSm.Add(fieldName, new Entry(type, value, options));
						num = -712570720;
						continue;
					}
					goto IL_0047;
				case 10:
					return;
				case 9:
					goto IL_0124;
				default:
					DfrXwxPlmqecDNirhBhnXpgMtSm.SetValue(fieldName, new Entry(type, value, options));
					return;
				}
				break;
				IL_0089:
				int num2;
				if (value != null)
				{
					num = -712570706;
					num2 = num;
				}
				else
				{
					num = -712570717;
					num2 = num;
				}
				continue;
				IL_0047:
				int num3;
				if (DfrXwxPlmqecDNirhBhnXpgMtSm.ContainsKey(fieldName))
				{
					num = -712570710;
					num3 = num;
				}
				else
				{
					num = -712570712;
					num3 = num;
				}
			}
			goto IL_0006;
			IL_0124:
			int num4;
			if (string.IsNullOrEmpty(fieldName))
			{
				num = -712570718;
				num4 = num;
			}
			else
			{
				num = -712570709;
				num4 = num;
			}
			goto IL_000b;
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
			return DfrXwxPlmqecDNirhBhnXpgMtSm.Remove(fieldName);
		}

		public bool Contains(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return DfrXwxPlmqecDNirhBhnXpgMtSm.ContainsKey(fieldName);
		}

		public Type GetDataType(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			Entry value;
			if (!DfrXwxPlmqecDNirhBhnXpgMtSm.TryGetValue(fieldName, out value))
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
			if (!DfrXwxPlmqecDNirhBhnXpgMtSm.TryGetValue(fieldName, out value2))
			{
				return false;
			}
			value = value2.value;
			return true;
		}

		public Field GetEntry(string fieldName)
		{
			KeyValuePair<string, Entry> entry = DfrXwxPlmqecDNirhBhnXpgMtSm.GetEntry(fieldName);
			return new Field(entry.Key, entry.Value.value, entry.Value.type, entry.Value.options);
		}

		public object GetOriginalValue(string fieldName)
		{
			return DfrXwxPlmqecDNirhBhnXpgMtSm.GetEntry(fieldName).Value.value;
		}

		public object GetOriginalValue(int index)
		{
			return DfrXwxPlmqecDNirhBhnXpgMtSm[index].value;
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
			if (!DfrXwxPlmqecDNirhBhnXpgMtSm.TryGetValue(fieldName, out value2))
			{
				value = default(T);
				return false;
			}
			return TryConvertOrCreateObject<T>(value2.value, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			if ((uint)index > (uint)DfrXwxPlmqecDNirhBhnXpgMtSm.Count)
			{
				goto IL_000e;
			}
			Entry value2 = DfrXwxPlmqecDNirhBhnXpgMtSm.GetEntryAt(index).Value;
			int num = -346386829;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -346386832)
				{
				case 0:
					break;
				case 2:
					goto IL_0030;
				case 1:
					return false;
				default:
					return TryConvertOrCreateObject<T>(value2.value, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
				}
				break;
				IL_0030:
				value = default(T);
				num = -346386831;
			}
			goto IL_000e;
			IL_000e:
			num = -346386830;
			goto IL_0013;
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
			if ((uint)index > (uint)DfrXwxPlmqecDNirhBhnXpgMtSm.Count)
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
			if (PYTtAvhhKZwWArYkEkMRZOUnwfi == null)
			{
				while (true)
				{
					switch (0x766E4FE5 ^ 0x766E4FE4)
					{
					case 0:
						continue;
					case 1:
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
			stringBuilder.Append("count = ");
			stringBuilder.Append(count.ToString());
			stringBuilder.Append("\n");
			int num2 = default(int);
			while (true)
			{
				int num = -1540764865;
				while (true)
				{
					switch (num ^ -1540764866)
					{
					case 5:
						break;
					case 1:
						stringBuilder.Append("type = ");
						num = -1540764866;
						continue;
					case 2:
					{
						string keyAt = DfrXwxPlmqecDNirhBhnXpgMtSm.GetKeyAt(num2);
						stringBuilder.Append("key = ");
						stringBuilder.Append((keyAt != null) ? keyAt : "NULL");
						num = -1540764871;
						continue;
					}
					case 4:
						stringBuilder.Append(DfrXwxPlmqecDNirhBhnXpgMtSm[num2].ToString());
						stringBuilder.Append("\n");
						num2++;
						num = -1540764872;
						continue;
					case 9:
						stringBuilder.Append((PYTtAvhhKZwWArYkEkMRZOUnwfi != null) ? PYTtAvhhKZwWArYkEkMRZOUnwfi.ToString() : "NULL\n");
						stringBuilder.Append("\n");
						num = -1540764874;
						continue;
					case 6:
					{
						int num3;
						if (num2 >= DfrXwxPlmqecDNirhBhnXpgMtSm.Count)
						{
							num = -1540764867;
							num3 = num;
						}
						else
						{
							num = -1540764868;
							num3 = num;
						}
						continue;
					}
					case 0:
						stringBuilder.Append(((object)JNNGbJEWijctWBKzGmlLLQzaVVsi != null) ? JNNGbJEWijctWBKzGmlLLQzaVVsi.Name : "NULL\n");
						stringBuilder.Append("objectType = ");
						stringBuilder.Append(GTVNGoiiOfQCvZVixHIrMuLKeCg.ToString());
						stringBuilder.Append("\n");
						stringBuilder.Append("xmlInfo = ");
						num = -1540764873;
						continue;
					case 7:
						stringBuilder.Append(", value = ");
						num = -1540764870;
						continue;
					case 8:
						num2 = 0;
						num = -1540764872;
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
				throw new ArgumentNullException("writer");
			}
			writer.WriteStartElement(type.Name, "http://guavaman.com/rewired");
			WriteXml_Value(writer);
			writer.WriteEndElement();
		}

		private void WriteXml_Value(XmlWriter writer)
		{
			int num = ((xmlInfo != null) ? xmlInfo.attributes.Count : 0);
			XmlInfo.XmlStringAttribute xmlStringAttribute = default(XmlInfo.XmlStringAttribute);
			string text = default(string);
			Entry entry = default(Entry);
			int num3 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num2 = 233615376;
				while (true)
				{
					switch (num2 ^ 0xDECB002)
					{
					case 7:
						break;
					case 3:
						writer.WriteAttributeString(xmlStringAttribute.localName, xmlStringAttribute.value);
						num2 = 233615370;
						continue;
					case 4:
						throw new NotImplementedException();
					case 14:
						SerializationTools.WriteXmlElement(writer, text, entry.value);
						num2 = 233615360;
						continue;
					case 0:
						if (!string.IsNullOrEmpty(xmlStringAttribute.ns))
						{
							writer.WriteAttributeString(xmlStringAttribute.localName, xmlStringAttribute.ns, xmlStringAttribute.value);
							num2 = 233615370;
							continue;
						}
						goto case 3;
					case 5:
						if ((object)entry.type != null)
						{
							text = entry.GetType().Name;
							num2 = 233615368;
							continue;
						}
						goto case 17;
					case 17:
						if (entry.value != null)
						{
							text = entry.value.GetType().Name;
							num2 = 233615371;
							continue;
						}
						goto case 16;
					case 16:
						text = "value";
						num2 = 233615372;
						continue;
					case 11:
					{
						entry = DfrXwxPlmqecDNirhBhnXpgMtSm[num3];
						text = DfrXwxPlmqecDNirhBhnXpgMtSm.GetKeyAt(num3);
						int num6;
						if ((entry.options & FieldOptions.ExculdeFromXml) == 0)
						{
							num2 = 233615374;
							num6 = num2;
						}
						else
						{
							num2 = 233615360;
							num6 = num2;
						}
						continue;
					}
					case 9:
						num2 = 233615372;
						continue;
					case 18:
						num5 = 0;
						num2 = 233615373;
						continue;
					case 15:
						if (num5 >= num)
						{
							num3 = 0;
							num2 = 233615375;
							continue;
						}
						goto case 1;
					case 1:
					{
						XmlInfo.XmlAttribute xmlAttribute = xmlInfo.attributes[num5];
						if (!(xmlAttribute is XmlInfo.XmlStringAttribute))
						{
							goto case 4;
						}
						xmlStringAttribute = xmlAttribute as XmlInfo.XmlStringAttribute;
						if (!string.IsNullOrEmpty(xmlStringAttribute.prefix))
						{
							writer.WriteAttributeString(xmlStringAttribute.prefix, xmlStringAttribute.localName, xmlStringAttribute.ns, xmlStringAttribute.value);
							num2 = 233615364;
							continue;
						}
						goto case 0;
					}
					case 8:
						num5++;
						num2 = 233615373;
						continue;
					case 2:
						num3++;
						num2 = 233615375;
						continue;
					case 6:
						num2 = 233615370;
						continue;
					case 10:
						num2 = 233615372;
						continue;
					case 12:
					{
						int num4;
						if (!string.IsNullOrEmpty(text))
						{
							num2 = 233615372;
							num4 = num2;
						}
						else
						{
							num2 = 233615367;
							num4 = num2;
						}
						continue;
					}
					default:
						if (num3 >= count)
						{
							return;
						}
						goto case 11;
					}
					break;
				}
			}
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
			bool flag = default(bool);
			string value = default(string);
			int num5 = default(int);
			int num4 = default(int);
			Entry entry = default(Entry);
			bool flag2 = default(bool);
			while (appendValueDelegate != null)
			{
				while (true)
				{
					IL_019c:
					int num = DfrXwxPlmqecDNirhBhnXpgMtSm.Count;
					int num2;
					int num3;
					if (DfrXwxPlmqecDNirhBhnXpgMtSm.ContainsDuplicateKeys)
					{
						num2 = -121901713;
						num3 = num2;
					}
					else
					{
						num2 = -121901728;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -121901722)
						{
						case 5:
							num2 = -121901706;
							continue;
						case 17:
							break;
						case 8:
							goto IL_0086;
						case 11:
							num2 = -121901717;
							continue;
						case 1:
							if (flag)
							{
								flag = false;
								num2 = -121901716;
								continue;
							}
							goto case 15;
						case 18:
							stringBuilder.Append(',');
							num2 = -121901717;
							continue;
						case 14:
							value = DfrXwxPlmqecDNirhBhnXpgMtSm.GetKeyAt(num5);
							if (string.IsNullOrEmpty(value))
							{
								value = num5.ToString();
								num2 = -121901724;
								continue;
							}
							goto case 2;
						case 12:
							if (num4 >= num)
							{
								stringBuilder.Append(']');
								return;
							}
							goto case 1;
						case 16:
							goto end_IL_0016;
						case 13:
							entry = DfrXwxPlmqecDNirhBhnXpgMtSm[num5];
							num2 = -121901720;
							continue;
						case 0:
							flag2 = false;
							num2 = -121901715;
							continue;
						case 10:
							num2 = -121901723;
							continue;
						case 6:
							stringBuilder.Append('{');
							flag2 = true;
							num5 = 0;
							num2 = -121901714;
							continue;
						case 3:
							appendValueDelegate(stringBuilder, DfrXwxPlmqecDNirhBhnXpgMtSm[num4].value);
							num4++;
							num2 = -121901718;
							continue;
						case 7:
							goto IL_019c;
						case 2:
							stringBuilder.Append('"');
							stringBuilder.Append(value);
							stringBuilder.Append("\":");
							appendValueDelegate(stringBuilder, entry.value);
							num5++;
							num2 = -121901714;
							continue;
						case 15:
							stringBuilder.Append(',');
							num2 = -121901723;
							continue;
						case 9:
							stringBuilder.Append('[');
							flag = true;
							num4 = 0;
							num2 = -121901718;
							continue;
						default:
							stringBuilder.Append('}');
							return;
						}
						int num6;
						if (!flag2)
						{
							num2 = -121901708;
							num6 = num2;
						}
						else
						{
							num2 = -121901722;
							num6 = num2;
						}
						continue;
						IL_0086:
						int num7;
						if (num5 >= num)
						{
							num2 = -121901726;
							num7 = num2;
						}
						else
						{
							num2 = -121901705;
							num7 = num2;
						}
						continue;
						end_IL_0016:
						break;
					}
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
			return new Enumerator(DfrXwxPlmqecDNirhBhnXpgMtSm);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(DfrXwxPlmqecDNirhBhnXpgMtSm);
		}

		private static bool TryConvertOrCreateObject<T>(object obj, out T result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			object result2;
			if (!TryConvertOrCreateObject(typeof(T), obj, out result2, numberStyle, cultureInfo))
			{
				while (true)
				{
					int num = 50939008;
					while (true)
					{
						switch (num ^ 0x3094481)
						{
						case 0:
							break;
						case 1:
							goto IL_0034;
						default:
							return false;
						}
						break;
						IL_0034:
						result = default(T);
						num = 50939011;
					}
				}
			}
			result = (T)result2;
			return true;
		}

		private static bool TryConvertOrCreateObject(Type targetType, object obj, out object result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			result = null;
			if (obj == null)
			{
				if (object.ReferenceEquals(targetType, typeof(string)))
				{
					result = string.Empty;
					return true;
				}
				if (!ReflectionTools.IsValueType(targetType))
				{
					return true;
				}
				if ((object)Nullable.GetUnderlyingType(targetType) != null)
				{
					return true;
				}
				return false;
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
					result = obj.ToString();
					result2 = true;
				}
				else
				{
					ICollection collection = default(ICollection);
					Type elementType = default(Type);
					object current = default(object);
					Array array = default(Array);
					int num4 = default(int);
					Type type2 = default(Type);
					IList list3 = default(IList);
					int num10 = default(int);
					IList list4 = default(IList);
					int num9 = default(int);
					Array array2 = default(Array);
					IList list2 = default(IList);
					IList list6 = default(IList);
					Type genericTypeDefinition = default(Type);
					int num12 = default(int);
					int num11 = default(int);
					SerializedObject serializedObject = default(SerializedObject);
					IReadOnlyList readOnlyList = default(IReadOnlyList);
					IList list5 = default(IList);
					object result7 = default(object);
					IDictionary dictionary = default(IDictionary);
					Type type3 = default(Type);
					Type type4 = default(Type);
					Type[] genericArguments = default(Type[]);
					IDictionary dictionary2 = default(IDictionary);
					int result11 = default(int);
					float result12 = default(float);
					int num45 = default(int);
					IReadOnlyList readOnlyList2 = default(IReadOnlyList);
					Array array9 = default(Array);
					ulong result16 = default(ulong);
					int num44 = default(int);
					Array array4 = default(Array);
					Array array8 = default(Array);
					long result22 = default(long);
					short result21 = default(short);
					Array array6 = default(Array);
					IList list7 = default(IList);
					int num41 = default(int);
					double result13 = default(double);
					byte result24 = default(byte);
					decimal result20 = default(decimal);
					ushort result18 = default(ushort);
					sbyte result19 = default(sbyte);
					SerializedObject serializedObject2 = default(SerializedObject);
					int num43 = default(int);
					Array array5 = default(Array);
					Type targetType2 = default(Type);
					IDictionary dictionary3 = default(IDictionary);
					Array array7 = default(Array);
					int num42 = default(int);
					uint result14 = default(uint);
					object result26 = default(object);
					object result27 = default(object);
					object result28 = default(object);
					object current5 = default(object);
					while (true)
					{
						IL_023a:
						if (!object.ReferenceEquals(targetType, typeof(int)))
						{
							goto IL_02e4;
						}
						int num;
						if (object.ReferenceEquals(type, typeof(float)))
						{
							result = (int)(float)obj;
							num = -1164548942;
							goto IL_0076;
						}
						goto IL_0360;
						IL_3033:
						IEnumerator enumerator = collection.GetEnumerator();
						try
						{
							while (true)
							{
								IL_3064:
								int num2;
								int num3;
								if (!enumerator.MoveNext())
								{
									num2 = -1164548950;
									num3 = num2;
								}
								else
								{
									num2 = -1164548945;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ -1164548949)
									{
									case 2:
										num2 = -1164548945;
										continue;
									default:
										goto end_IL_3043;
									case 3:
										break;
									case 0:
									{
										object result3;
										if (TryConvertOrCreateObject(elementType, current, out result3, numberStyle, cultureInfo))
										{
											array.SetValue(result3, num4);
											num4++;
											num2 = -1164548952;
											continue;
										}
										break;
									}
									case 4:
										current = enumerator.Current;
										num2 = -1164548949;
										continue;
									case 1:
										goto end_IL_3043;
									}
									goto IL_3064;
									continue;
									end_IL_3043:
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
								while (true)
								{
									IL_30c5:
									int num5 = -1164548950;
									while (true)
									{
										switch (num5 ^ -1164548949)
										{
										case 0:
											break;
										default:
											goto end_IL_30ca;
										case 1:
											goto IL_30e3;
										case 2:
											goto end_IL_30ca;
										}
										goto IL_30c5;
										IL_30e3:
										disposable.Dispose();
										num5 = -1164548951;
										continue;
										end_IL_30ca:
										break;
									}
									break;
								}
							}
						}
						result = array;
						result2 = true;
						while (true)
						{
							switch (-1164548950 ^ -1164548949)
							{
							case 2:
								continue;
							case 1:
								goto end_IL_30f9;
							}
							goto IL_3123;
							continue;
							end_IL_30f9:
							break;
						}
						break;
						IL_3252:
						int num6;
						while (true)
						{
							switch (num6 ^ -1164548949)
							{
							case 31:
								break;
							case 9:
							{
								object result6;
								if (TryConvertOrCreateObject(type2, list3[num10], out result6, numberStyle, cultureInfo))
								{
									list4.Add(result6);
									num6 = -1164548953;
									continue;
								}
								goto case 12;
							}
							case 34:
								num6 = -1164548952;
								continue;
							case 7:
								goto IL_332a;
							case 28:
								num6 = -1164548938;
								continue;
							case 30:
								num9++;
								num6 = -1164548956;
								continue;
							case 8:
								goto IL_3351;
							case 6:
								if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
								{
									array2 = obj as Array;
									num6 = -1164548945;
									continue;
								}
								goto IL_3635;
							case 20:
							{
								object result5;
								if (TryConvertOrCreateObject(type2, array2.GetValue(num9), out result5, numberStyle, cultureInfo))
								{
									list2.Add(result5);
									num6 = -1164548939;
									continue;
								}
								goto case 30;
							}
							case 3:
								if (num10 >= list3.Count)
								{
									result = list4;
									num6 = -1164548946;
									continue;
								}
								goto case 9;
							case 35:
								result2 = true;
								goto end_IL_023a;
							case 18:
								list6 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
								num12 = 0;
								num6 = -1164548937;
								continue;
							case 11:
								num11++;
								num6 = -1164548943;
								continue;
							case 25:
								serializedObject = obj as SerializedObject;
								num6 = -1164548935;
								continue;
							case 2:
								goto IL_343d;
							case 1:
								goto end_IL_023a;
							case 14:
								num6 = -1164548956;
								continue;
							case 12:
								num10++;
								num6 = -1164548952;
								continue;
							case 29:
								if (num12 >= serializedObject.count)
								{
									result = list6;
									num6 = -1164548931;
									continue;
								}
								goto case 27;
							case 27:
							{
								object result8;
								if (TryConvertOrCreateObject(type2, serializedObject[num12].value, out result8, numberStyle, cultureInfo))
								{
									list6.Add(result8);
									num6 = -1164548954;
									continue;
								}
								goto case 13;
							}
							case 17:
								goto end_IL_023a;
							case 13:
								num12++;
								num6 = -1164548938;
								continue;
							case 24:
								goto IL_34f9;
							case 22:
								result2 = true;
								goto end_IL_023a;
							case 26:
								if (num11 >= readOnlyList.Count)
								{
									result = list5;
									result2 = true;
									num6 = -1164548934;
									continue;
								}
								goto IL_343d;
							case 10:
								num10 = 0;
								num6 = -1164548983;
								continue;
							case 21:
								goto IL_355d;
							case 4:
								list2 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
								num9 = 0;
								num6 = -1164548955;
								continue;
							case 23:
								if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
								{
									readOnlyList = obj as IReadOnlyList;
									list5 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
									num11 = 0;
									num6 = -1164548943;
									continue;
								}
								goto IL_34f9;
							case 16:
								list5.Add(result7);
								num6 = -1164548960;
								continue;
							case 32:
								goto IL_3635;
							case 19:
								genericTypeDefinition = targetType.GetGenericTypeDefinition();
								num6 = -1164548930;
								continue;
							case 5:
								result2 = true;
								goto end_IL_023a;
							case 15:
								if (num9 >= array2.Length)
								{
									result = list2;
									result2 = true;
									goto end_IL_023a;
								}
								goto case 20;
							case 0:
								list3 = obj as IList;
								list4 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
								num6 = -1164548959;
								continue;
							default:
							{
								IEnumerable enumerable = obj as IEnumerable;
								IList list = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type2));
								enumerator = enumerable.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										while (true)
										{
											object current2 = enumerator.Current;
											object result4;
											if (!TryConvertOrCreateObject(type2, current2, out result4, numberStyle, cultureInfo))
											{
												break;
											}
											list.Add(result4);
											int num7 = -1164548951;
											while (true)
											{
												switch (num7 ^ -1164548949)
												{
												case 0:
													num7 = -1164548950;
													continue;
												case 1:
													break;
												default:
													goto end_IL_3727;
												}
												break;
											}
											continue;
											end_IL_3727:
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
											IL_3769:
											int num8 = -1164548950;
											while (true)
											{
												switch (num8 ^ -1164548949)
												{
												case 0:
													break;
												default:
													goto end_IL_376e;
												case 1:
													goto IL_3787;
												case 2:
													goto end_IL_376e;
												}
												goto IL_3769;
												IL_3787:
												disposable.Dispose();
												num8 = -1164548951;
												continue;
												end_IL_376e:
												break;
											}
											break;
										}
									}
								}
								result = list;
								result2 = true;
								goto end_IL_023a;
							}
							}
							break;
							IL_355d:
							if (ReflectionTools.DoesTypeImplement(targetType, typeof(IList)))
							{
								type2 = ReflectionTools.GetGenericArguments(targetType)[0];
								int num13;
								if (!ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
								{
									num6 = -1164548932;
									num13 = num6;
								}
								else
								{
									num6 = -1164548942;
									num13 = num6;
								}
								continue;
							}
							goto IL_384d;
							IL_3635:
							if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
							{
								num6 = -1164548982;
								continue;
							}
							goto IL_3996;
							IL_34f9:
							int num14;
							if (!ReflectionTools.DoesTypeImplement(type, typeof(IList)))
							{
								num6 = -1164548947;
								num14 = num6;
							}
							else
							{
								num6 = -1164548949;
								num14 = num6;
							}
							continue;
							IL_343d:
							int num15;
							if (!TryConvertOrCreateObject(type2, readOnlyList[num11], out result7, numberStyle, cultureInfo))
							{
								num6 = -1164548960;
								num15 = num6;
							}
							else
							{
								num6 = -1164548933;
								num15 = num6;
							}
						}
						goto IL_324d;
						IL_02e4:
						if (object.ReferenceEquals(targetType, typeof(float)))
						{
							int num16;
							if (!object.ReferenceEquals(type, typeof(int)))
							{
								num = -1164548944;
								num16 = num;
							}
							else
							{
								num = -1164548965;
								num16 = num;
							}
							goto IL_0076;
						}
						goto IL_02cf;
						IL_384d:
						while (ReflectionTools.DoesTypeImplement(genericTypeDefinition, typeof(IDictionary)))
						{
							int num17 = -1164548947;
							while (true)
							{
								switch (num17 ^ -1164548949)
								{
								case 0:
									num17 = -1164548951;
									continue;
								case 7:
									dictionary = (IDictionary)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type3, type4));
									num17 = -1164548946;
									continue;
								case 6:
									genericArguments = ReflectionTools.GetGenericArguments(targetType);
									type3 = genericArguments[0];
									num17 = -1164548952;
									continue;
								case 1:
									result2 = false;
									num17 = -1164548945;
									continue;
								case 3:
									break;
								case 2:
									goto end_IL_37a7;
								case 4:
									goto end_IL_023a;
								default:
									goto IL_387c;
								}
								type4 = genericArguments[1];
								dictionary2 = obj as IDictionary;
								int num18;
								if (dictionary2 == null)
								{
									num17 = -1164548950;
									num18 = num17;
								}
								else
								{
									num17 = -1164548948;
									num18 = num17;
								}
								continue;
								end_IL_37a7:
								break;
							}
						}
						goto IL_3996;
						IL_2fc0:
						int num19 = -1164548951;
						goto IL_2fc5;
						IL_3123:
						IEnumerator enumerator2;
						if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
						{
							IEnumerable enumerable2 = obj as IEnumerable;
							int num20 = 0;
							{
								enumerator2 = enumerable2.GetEnumerator();
								try
								{
									while (true)
									{
										IL_3185:
										int num21;
										int num22;
										if (enumerator2.MoveNext())
										{
											num21 = -1164548952;
											num22 = num21;
										}
										else
										{
											num21 = -1164548950;
											num22 = num21;
										}
										while (true)
										{
											switch (num21 ^ -1164548949)
											{
											case 2:
												num21 = -1164548952;
												continue;
											default:
												goto end_IL_3153;
											case 3:
											{
												object current6 = enumerator2.Current;
												num20++;
												num21 = -1164548949;
												continue;
											}
											case 0:
												break;
											case 1:
												goto end_IL_3153;
											}
											goto IL_3185;
											continue;
											end_IL_3153:
											break;
										}
										break;
									}
								}
								finally
								{
									IDisposable disposable2 = enumerator2 as IDisposable;
									if (disposable2 != null)
									{
										disposable2.Dispose();
									}
								}
							}
							Array array3 = Array.CreateInstance(elementType, num20);
							int num23 = 0;
							{
								enumerator2 = enumerable2.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										while (true)
										{
											object current3 = enumerator2.Current;
											int num24 = -1164548952;
											while (true)
											{
												switch (num24 ^ -1164548949)
												{
												case 0:
													num24 = -1164548950;
													continue;
												case 1:
													break;
												case 3:
												{
													object result9;
													if (TryConvertOrCreateObject(elementType, current3, out result9, numberStyle, cultureInfo))
													{
														array3.SetValue(result9, num23);
														num23++;
														num24 = -1164548951;
														continue;
													}
													goto end_IL_31f1;
												}
												default:
													goto end_IL_31f1;
												}
												break;
											}
											continue;
											end_IL_31f1:
											break;
										}
									}
								}
								finally
								{
									IDisposable disposable3 = enumerator2 as IDisposable;
									if (disposable3 != null)
									{
										disposable3.Dispose();
									}
								}
							}
							result = array3;
							goto IL_324d;
						}
						goto IL_332a;
						IL_02cf:
						if (ReflectionTools.IsEnum(targetType))
						{
							num = -1164548958;
							goto IL_0076;
						}
						if (object.ReferenceEquals(targetType, typeof(uint)))
						{
							goto IL_0833;
						}
						goto IL_1199;
						IL_3996:
						int num25;
						if (object.ReferenceEquals(targetType, typeof(object)))
						{
							result = obj;
							num25 = -1164548945;
							goto IL_3953;
						}
						goto IL_3a09;
						IL_0076:
						while (true)
						{
							switch (num ^ -1164548949)
							{
							case 55:
								num = -1164548946;
								continue;
							case 25:
								result2 = true;
								num = -1164548981;
								continue;
							case 34:
								break;
							case 47:
								num = -1164548942;
								continue;
							case 13:
								if (object.ReferenceEquals(type, typeof(double)))
								{
									result = (float)(double)obj;
									num = -1164548990;
									continue;
								}
								goto IL_0586;
							case 40:
								goto end_IL_0076;
							case 8:
								goto IL_01df;
							case 0:
								result = (float)(decimal)obj;
								num = -1164548990;
								continue;
							case 48:
								result = (float)(int)obj;
								num = -1164548939;
								continue;
							case 5:
								goto IL_023a;
							case 46:
								goto IL_027c;
							case 12:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (float)(short)obj;
									num = -1164548947;
									continue;
								}
								goto case 11;
							case 45:
								goto IL_02cf;
							case 52:
								goto IL_02e4;
							case 9:
							{
								Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(targetType);
								object result10;
								if (TryConvertOrCreateObject(underlyingEnumType, obj, out result10, numberStyle, cultureInfo))
								{
									result = Enum.ToObject(targetType, result10);
									num = -1164548937;
									continue;
								}
								goto IL_07c1;
							}
							case 17:
								result = (float)(int)(byte)obj;
								num = -1164548990;
								continue;
							case 16:
								goto IL_0360;
							case 4:
								result2 = false;
								goto end_IL_0076;
							case 2:
								num = -1164548990;
								continue;
							case 21:
								result = (float)(long)obj;
								num = -1164548990;
								continue;
							case 41:
								result2 = true;
								goto end_IL_0076;
							case 28:
								result2 = true;
								num = -1164548956;
								continue;
							case 22:
								result = result11;
								num = -1164548942;
								continue;
							case 33:
								result = (int)(ushort)obj;
								num = -1164548942;
								continue;
							case 1:
								result = (int)(long)obj;
								num = -1164548942;
								continue;
							case 23:
								if (!float.TryParse(obj.ToString(), out result12))
								{
									result2 = false;
									num = -1164548940;
									continue;
								}
								goto case 3;
							case 43:
								if (object.ReferenceEquals(type, typeof(double)))
								{
									result = (int)(double)obj;
									num = -1164548942;
									continue;
								}
								goto case 37;
							case 36:
								goto end_IL_0076;
							case 6:
								num = -1164548990;
								continue;
							case 31:
								goto end_IL_0076;
							case 32:
								goto end_IL_0076;
							case 54:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (int)(ulong)obj;
									num = -1164548942;
									continue;
								}
								goto case 43;
							case 30:
								num = -1164548990;
								continue;
							case 27:
								goto IL_04d1;
							case 35:
								result = (int)(short)obj;
								num = -1164548942;
								continue;
							case 50:
								goto IL_050e;
							case 39:
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (int)(sbyte)obj;
									num = -1164548942;
									continue;
								}
								goto case 14;
							case 49:
								if (object.ReferenceEquals(type, typeof(byte)))
								{
									result = (int)(byte)obj;
									num = -1164548942;
									continue;
								}
								goto case 39;
							case 24:
								goto IL_0586;
							case 44:
								goto IL_05ac;
							case 19:
								result = (float)(uint)obj;
								num = -1164548951;
								continue;
							case 29:
								result2 = false;
								goto end_IL_0076;
							case 11:
								if (object.ReferenceEquals(type, typeof(ushort)))
								{
									result = (float)(int)(ushort)obj;
									num = -1164548990;
									continue;
								}
								goto IL_05ac;
							case 18:
								result = (float)(ulong)obj;
								num = -1164548990;
								continue;
							case 15:
								goto end_IL_0076;
							case 10:
								result = (int)(uint)obj;
								num = -1164548942;
								continue;
							case 3:
								result = result12;
								num = -1164548990;
								continue;
							case 37:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (int)(decimal)obj;
									num = -1164548988;
									continue;
								}
								goto IL_073b;
							case 20:
								result2 = false;
								goto end_IL_0076;
							case 14:
								if (object.ReferenceEquals(type, typeof(string)))
								{
									if (cultureInfo != null)
									{
										if (!int.TryParse(obj.ToString(), numberStyle, cultureInfo, out result11))
										{
											result2 = false;
											num = -1164548989;
											continue;
										}
										goto case 22;
									}
									goto IL_050e;
								}
								goto case 51;
							case 42:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 4;
								}
								if (cultureInfo == null)
								{
									goto case 23;
								}
								goto IL_0715;
							case 7:
								goto IL_073b;
							case 26:
								goto IL_0761;
							case 38:
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (float)(sbyte)obj;
									num = -1164548990;
									continue;
								}
								goto case 42;
							case 51:
								result2 = false;
								num = -1164548977;
								continue;
							default:
								goto IL_07c1;
							}
							int num26;
							if (object.ReferenceEquals(type, typeof(ushort)))
							{
								num = -1164548982;
								num26 = num;
							}
							else
							{
								num = -1164548966;
								num26 = num;
							}
							continue;
							IL_0761:
							int num27;
							if (object.ReferenceEquals(type, typeof(ulong)))
							{
								num = -1164548935;
								num27 = num;
							}
							else
							{
								num = -1164548954;
								num27 = num;
							}
							continue;
							IL_01df:
							int num28;
							if (!object.ReferenceEquals(type, typeof(long)))
							{
								num = -1164548963;
								num28 = num;
							}
							else
							{
								num = -1164548950;
								num28 = num;
							}
							continue;
							IL_05ac:
							int num29;
							if (object.ReferenceEquals(type, typeof(byte)))
							{
								num = -1164548934;
								num29 = num;
							}
							else
							{
								num = -1164548979;
								num29 = num;
							}
							continue;
							IL_0715:
							int num30;
							if (float.TryParse(obj.ToString(), numberStyle, cultureInfo, out result12))
							{
								num = -1164548952;
								num30 = num;
							}
							else
							{
								num = -1164548938;
								num30 = num;
							}
							continue;
							IL_073b:
							int num31;
							if (object.ReferenceEquals(type, typeof(short)))
							{
								num = -1164548984;
								num31 = num;
							}
							else
							{
								num = -1164548983;
								num31 = num;
							}
							continue;
							IL_027c:
							int num32;
							if (!object.ReferenceEquals(type, typeof(long)))
							{
								num = -1164548943;
								num32 = num;
							}
							else
							{
								num = -1164548930;
								num32 = num;
							}
							continue;
							IL_050e:
							int num33;
							if (!int.TryParse(obj.ToString(), out result11))
							{
								num = -1164548929;
								num33 = num;
							}
							else
							{
								num = -1164548931;
								num33 = num;
							}
							continue;
							IL_0586:
							int num34;
							if (!object.ReferenceEquals(type, typeof(decimal)))
							{
								num = -1164548953;
								num34 = num;
							}
							else
							{
								num = -1164548949;
								num34 = num;
							}
							continue;
							IL_04d1:
							int num35;
							if (!object.ReferenceEquals(type, typeof(uint)))
							{
								num = -1164548987;
								num35 = num;
							}
							else
							{
								num = -1164548936;
								num35 = num;
							}
							continue;
							end_IL_0076:
							break;
						}
						break;
						IL_0360:
						int num36;
						if (!object.ReferenceEquals(type, typeof(uint)))
						{
							num = -1164548957;
							num36 = num;
						}
						else
						{
							num = -1164548959;
							num36 = num;
						}
						goto IL_0076;
						IL_394e:
						num25 = -1164548951;
						goto IL_3953;
						IL_0833:
						int num37 = -1164548865;
						goto IL_0838;
						IL_07c1:
						if (object.ReferenceEquals(type, typeof(string)))
						{
							try
							{
								result = Enum.Parse(targetType, (string)obj, true);
								result2 = true;
							}
							catch
							{
								while (true)
								{
									IL_07ee:
									int num38 = -1164548950;
									while (true)
									{
										switch (num38 ^ -1164548949)
										{
										case 0:
											break;
										default:
											goto end_IL_07f3;
										case 1:
											goto IL_080c;
										case 2:
											goto end_IL_07f3;
										}
										goto IL_07ee;
										IL_080c:
										result = null;
										result2 = false;
										num38 = -1164548951;
										continue;
										end_IL_07f3:
										break;
									}
									break;
								}
							}
							break;
						}
						goto IL_3996;
						IL_3a09:
						int num39;
						if (!ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
						{
							num25 = -1164548948;
							num39 = num25;
						}
						else
						{
							num25 = -1164548952;
							num39 = num25;
						}
						goto IL_3953;
						IL_332a:
						result2 = false;
						num6 = -1164548950;
						goto IL_3252;
						IL_1199:
						int num40;
						if (object.ReferenceEquals(targetType, typeof(double)))
						{
							num37 = -1164548888;
							num40 = num37;
						}
						else
						{
							num37 = -1164549074;
							num40 = num37;
						}
						goto IL_0838;
						IL_324d:
						num6 = -1164548984;
						goto IL_3252;
						IL_3351:
						if (ReflectionTools.IsGenericType(targetType))
						{
							num6 = -1164548936;
							goto IL_3252;
						}
						goto IL_3996;
						IL_0838:
						while (true)
						{
							switch (num37 ^ -1164548949)
							{
							case 249:
								break;
							case 272:
								goto IL_0cc0;
							case 108:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (short)obj > 0;
									num37 = -1164548920;
									continue;
								}
								goto IL_29ce;
							case 276:
								num37 = -1164549042;
								continue;
							case 7:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (uint)obj != 0;
									num37 = -1164549088;
									continue;
								}
								goto case 143;
							case 14:
								if (object.ReferenceEquals(type, typeof(ushort)))
								{
									result = (sbyte)(ushort)obj;
									num37 = -1164549083;
									continue;
								}
								goto case 199;
							case 235:
								num37 = -1164549106;
								continue;
							case 128:
								result2 = false;
								num37 = -1164548697;
								continue;
							case 219:
								num37 = -1164549066;
								continue;
							case 56:
								num37 = -1164548925;
								continue;
							case 63:
								goto IL_0da6;
							case 261:
								result = (ulong)(long)obj;
								num37 = -1164548990;
								continue;
							case 243:
								if (object.ReferenceEquals(type, typeof(int)))
								{
									result = (long)(int)obj;
									num37 = -1164548890;
									continue;
								}
								goto case 11;
							case 30:
								goto IL_0e10;
							case 136:
								goto IL_0e36;
							case 55:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (byte)(uint)obj;
									num37 = -1164549063;
									continue;
								}
								goto case 25;
							case 120:
								result2 = true;
								goto end_IL_023a;
							case 188:
								result2 = false;
								num37 = -1164548898;
								continue;
							case 25:
								if (object.ReferenceEquals(type, typeof(long)))
								{
									result = (byte)(long)obj;
									num37 = -1164549063;
									continue;
								}
								goto case 282;
							case 250:
								num37 = -1164548890;
								continue;
							case 191:
								goto IL_0edc;
							case 121:
								goto IL_0f02;
							case 133:
								if (!object.ReferenceEquals(targetType, typeof(bool)))
								{
									goto IL_0edc;
								}
								if (object.ReferenceEquals(type, typeof(int)))
								{
									result = (int)obj > 0;
									num37 = -1164548920;
									continue;
								}
								goto IL_1a84;
							case 102:
								if (num45 >= readOnlyList2.Count)
								{
									result = array9;
									result2 = true;
									goto end_IL_023a;
								}
								goto case 246;
							case 127:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (short)(decimal)obj;
									num37 = -1164548943;
									continue;
								}
								goto case 177;
							case 65:
								num37 = -1164549058;
								continue;
							case 184:
								goto IL_0fc8;
							case 118:
								result = (ushort)(decimal)obj;
								num37 = -1164548974;
								continue;
							case 132:
								goto IL_100a;
							case 105:
								result2 = false;
								num37 = -1164549095;
								continue;
							case 255:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (ushort)(uint)obj;
									num37 = -1164548689;
									continue;
								}
								goto case 101;
							case 192:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (short)(uint)obj;
									num37 = -1164549106;
									continue;
								}
								goto case 110;
							case 77:
								result2 = true;
								goto end_IL_023a;
							case 211:
								result2 = false;
								goto end_IL_023a;
							case 43:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (sbyte)(ulong)obj;
									num37 = -1164549083;
									continue;
								}
								goto case 36;
							case 274:
								goto IL_10e8;
							case 82:
								if (object.ReferenceEquals(type, typeof(int)))
								{
									result = (sbyte)(int)obj;
									num37 = -1164549083;
									continue;
								}
								goto case 179;
							case 115:
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (short)(float)obj;
									num37 = -1164549106;
									continue;
								}
								goto case 228;
							case 152:
								result = (double)(int)obj;
								num37 = -1164549066;
								continue;
							case 178:
								goto end_IL_023a;
							case 113:
								result = result16;
								num37 = -1164549034;
								continue;
							case 168:
								goto IL_1199;
							case 34:
								num37 = -1164549106;
								continue;
							case 233:
								if (object.ReferenceEquals(type, typeof(byte)))
								{
									result = (sbyte)(byte)obj;
									num37 = -1164549083;
									continue;
								}
								goto case 82;
							case 204:
								result = (long)(double)obj;
								num37 = -1164548890;
								continue;
							case 74:
								if (!ulong.TryParse(obj.ToString(), out result16))
								{
									result2 = false;
									goto end_IL_023a;
								}
								goto case 113;
							case 159:
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (sbyte)obj > 0;
									num37 = -1164548920;
									continue;
								}
								goto case 1;
							case 164:
								result2 = false;
								num37 = -1164548937;
								continue;
							case 251:
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (long)(float)obj;
									num37 = -1164548890;
									continue;
								}
								goto case 124;
							case 137:
								num37 = -1164548920;
								continue;
							case 79:
								if (object.ReferenceEquals(targetType, typeof(char)))
								{
									result = obj.ToString();
									result2 = true;
									goto end_IL_023a;
								}
								goto case 196;
							case 71:
								goto IL_12d4;
							case 84:
								if (object.ReferenceEquals(type, typeof(int)))
								{
									result = (uint)(int)obj;
									num37 = -1164548996;
									continue;
								}
								goto case 76;
							case 75:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 2;
								}
								if (cultureInfo != null)
								{
									goto IL_133b;
								}
								goto case 195;
							case 16:
								if (num44 >= array4.Length)
								{
									result = array8;
									result2 = true;
									goto end_IL_023a;
								}
								goto case 5;
							case 41:
								num37 = -1164549058;
								continue;
							case 67:
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (double)(float)obj;
									num37 = -1164549066;
									continue;
								}
								goto IL_2a44;
							case 201:
								goto IL_13bc;
							case 148:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 61;
								}
								if (cultureInfo == null)
								{
									goto IL_1e40;
								}
								if (!long.TryParse(obj.ToString(), numberStyle, cultureInfo, out result22))
								{
									result2 = false;
									num37 = -1164549046;
									continue;
								}
								goto case 170;
							case 22:
								num37 = -1164548933;
								continue;
							case 280:
								goto IL_142a;
							case 13:
								result = (double)(long)obj;
								num37 = -1164549066;
								continue;
							case 119:
								result = result21;
								num37 = -1164548952;
								continue;
							case 10:
								array6 = Array.CreateInstance(elementType, list7.Count);
								num41 = 0;
								num37 = -1164548993;
								continue;
							case 20:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (decimal)(ulong)obj;
									num37 = -1164549042;
									continue;
								}
								goto case 222;
							case 139:
								num37 = -1164548920;
								continue;
							case 17:
								result = (ushort)(int)obj;
								num37 = -1164548974;
								continue;
							case 187:
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (ulong)(float)obj;
									num37 = -1164549058;
									continue;
								}
								goto case 50;
							case 263:
								result2 = false;
								goto end_IL_023a;
							case 21:
								if (object.ReferenceEquals(type, typeof(long)))
								{
									result = (decimal)(long)obj;
									num37 = -1164548875;
									continue;
								}
								goto case 180;
							case 176:
								goto end_IL_023a;
							case 203:
								num41++;
								num37 = -1164548993;
								continue;
							case 2:
								result2 = false;
								goto end_IL_023a;
							case 101:
								if (object.ReferenceEquals(type, typeof(long)))
								{
									result = (ushort)(long)obj;
									num37 = -1164548935;
									continue;
								}
								goto case 86;
							case 83:
								if (string.Equals((string)obj, "false", StringComparison.OrdinalIgnoreCase))
								{
									result = false;
									num37 = -1164548920;
									continue;
								}
								goto case 211;
							case 1:
								if (object.ReferenceEquals(type, typeof(string)))
								{
									if (string.Equals((string)obj, "true", StringComparison.OrdinalIgnoreCase))
									{
										result = true;
										num37 = -1164549078;
										continue;
									}
									goto case 83;
								}
								goto case 267;
							case 146:
								result2 = true;
								num37 = -1164548988;
								continue;
							case 226:
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (long)(sbyte)obj;
									num37 = -1164548890;
									continue;
								}
								goto case 148;
							case 239:
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (ulong)(sbyte)obj;
									num37 = -1164548894;
									continue;
								}
								goto case 52;
							case 173:
								result = (float)obj > 0f;
								num37 = -1164549086;
								continue;
							case 143:
								if (object.ReferenceEquals(type, typeof(long)))
								{
									result = (long)obj > 0;
									num37 = -1164548920;
									continue;
								}
								goto case 162;
							case 260:
								num37 = -1164548974;
								continue;
							case 58:
								if (object.ReferenceEquals(type, typeof(double)))
								{
									result = (sbyte)(double)obj;
									num37 = -1164549083;
									continue;
								}
								goto case 185;
							case 232:
								if (object.ReferenceEquals(targetType, typeof(short)))
								{
									goto IL_171c;
								}
								goto case 238;
							case 212:
								goto IL_1742;
							case 66:
								if (object.ReferenceEquals(type, typeof(byte)))
								{
									result = (double)(int)(byte)obj;
									num37 = -1164548674;
									continue;
								}
								goto case 92;
							case 209:
								result2 = false;
								goto end_IL_023a;
							case 169:
								num37 = -1164549063;
								continue;
							case 175:
								num37 = -1164549066;
								continue;
							case 47:
								goto end_IL_023a;
							case 73:
								num37 = -1164549058;
								continue;
							case 60:
								goto IL_17cd;
							case 29:
								num37 = -1164548974;
								continue;
							case 117:
								goto end_IL_023a;
							case 107:
								result2 = false;
								goto end_IL_023a;
							case 181:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (sbyte)(short)obj;
									num37 = -1164549083;
									continue;
								}
								goto case 14;
							case 190:
								if (!double.TryParse(obj.ToString(), out result13))
								{
									result2 = false;
									goto end_IL_023a;
								}
								goto case 49;
							case 91:
								goto IL_186f;
							case 142:
								result2 = true;
								num37 = -1164548870;
								continue;
							case 70:
								result = (uint)(long)obj;
								num37 = -1164548925;
								continue;
							case 48:
								if (!object.ReferenceEquals(targetType, typeof(ulong)))
								{
									goto case 232;
								}
								goto IL_18cf;
							case 237:
								goto end_IL_023a;
							case 150:
								num37 = -1164548925;
								continue;
							case 18:
								num37 = -1164548974;
								continue;
							case 62:
								goto IL_1918;
							case 109:
								result = (byte)obj > 0;
								num37 = -1164548920;
								continue;
							case 196:
								if (object.ReferenceEquals(targetType, typeof(Guid)))
								{
									if (object.ReferenceEquals(type, typeof(string)))
									{
										result = StringTools.ToGuid((string)obj);
										num37 = -1164548700;
										continue;
									}
									goto case 80;
								}
								goto IL_2784;
							case 195:
								if (!byte.TryParse(obj.ToString(), out result24))
								{
									result2 = false;
									goto end_IL_023a;
								}
								goto case 97;
							case 126:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 89;
								}
								if (cultureInfo == null)
								{
									goto IL_2801;
								}
								if (!decimal.TryParse(obj.ToString(), numberStyle, cultureInfo, out result20))
								{
									result2 = false;
									num37 = -1164549050;
									continue;
								}
								goto case 214;
							case 104:
								result2 = true;
								goto end_IL_023a;
							case 160:
								result = (double)(ulong)obj;
								num37 = -1164548866;
								continue;
							case 15:
								goto IL_1a24;
							case 151:
								result = (short)(sbyte)obj;
								num37 = -1164548986;
								continue;
							case 123:
								goto end_IL_023a;
							case 221:
								num37 = -1164549063;
								continue;
							case 96:
								num37 = -1164548925;
								continue;
							case 273:
								goto IL_1a84;
							case 129:
								num37 = -1164548920;
								continue;
							case 11:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (long)(ulong)obj;
									num37 = -1164548890;
									continue;
								}
								goto case 251;
							case 217:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 263;
								}
								if (cultureInfo != null)
								{
									if (!ushort.TryParse(obj.ToString(), numberStyle, cultureInfo, out result18))
									{
										result2 = false;
										goto end_IL_023a;
									}
									goto case 31;
								}
								goto IL_2a21;
							case 179:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (sbyte)(uint)obj;
									num37 = -1164549083;
									continue;
								}
								goto IL_2eed;
							case 166:
								goto end_IL_023a;
							case 97:
								result = result24;
								num37 = -1164549063;
								continue;
							case 206:
								array8 = Array.CreateInstance(elementType, array4.Length);
								num44 = 0;
								num37 = -1164548931;
								continue;
							case 199:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 254;
								}
								if (cultureInfo != null)
								{
									if (!sbyte.TryParse(obj.ToString(), numberStyle, cultureInfo, out result19))
									{
										result2 = false;
										goto end_IL_023a;
									}
									goto case 140;
								}
								goto IL_2eca;
							case 215:
								num37 = -1164548925;
								continue;
							case 216:
								goto end_IL_023a;
							case 95:
								result2 = false;
								goto end_IL_023a;
							case 116:
							{
								object result17;
								if (TryConvertOrCreateObject(elementType, serializedObject2[num43].value, out result17, numberStyle, cultureInfo))
								{
									array5.SetValue(result17, num43);
									num37 = -1164548695;
									continue;
								}
								goto case 258;
							}
							case 68:
								result = array6;
								result2 = true;
								goto end_IL_023a;
							case 189:
								num37 = -1164549063;
								continue;
							case 253:
								num37 = -1164549058;
								continue;
							case 171:
								result2 = false;
								goto end_IL_023a;
							case 138:
								targetType2 = ReflectionTools.GetGenericArguments(targetType)[1];
								dictionary3 = obj as IDictionary;
								array7 = Array.CreateInstance(elementType, dictionary3.Count);
								num37 = -1164549018;
								continue;
							case 88:
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (uint)(sbyte)obj;
									num37 = -1164548925;
									continue;
								}
								goto case 200;
							case 110:
								if (object.ReferenceEquals(type, typeof(long)))
								{
									result = (short)(long)obj;
									num37 = -1164549106;
									continue;
								}
								goto IL_1ffa;
							case 154:
								result = (byte)(int)obj;
								num37 = -1164549063;
								continue;
							case 236:
								goto IL_1d0a;
							case 158:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (byte)(short)obj;
									num37 = -1164549063;
									continue;
								}
								goto case 35;
							case 61:
								result2 = false;
								goto end_IL_023a;
							case 205:
								num42 = 0;
								num37 = -1164549015;
								continue;
							case 228:
								if (object.ReferenceEquals(type, typeof(double)))
								{
									result = (short)(double)obj;
									num37 = -1164549106;
									continue;
								}
								goto case 127;
							case 28:
								goto end_IL_023a;
							case 258:
								num43++;
								num37 = -1164548971;
								continue;
							case 270:
								goto IL_1dc8;
							case 51:
								result2 = false;
								goto end_IL_023a;
							case 42:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (uint)(ulong)obj;
									num37 = -1164548973;
									continue;
								}
								goto case 197;
							case 49:
								result = result13;
								num37 = -1164549116;
								continue;
							case 134:
								goto IL_1e40;
							case 31:
								result = result18;
								num37 = -1164548974;
								continue;
							case 238:
								if (object.ReferenceEquals(targetType, typeof(ushort)))
								{
									if (object.ReferenceEquals(type, typeof(short)))
									{
										result = (ushort)(short)obj;
										num37 = -1164548974;
										continue;
									}
									goto IL_1f82;
								}
								goto case 202;
							case 222:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (decimal)(short)obj;
									num37 = -1164549112;
									continue;
								}
								goto case 72;
							case 167:
								result = (double)(uint)obj;
								num37 = -1164549066;
								continue;
							case 266:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (uint)(short)obj;
									num37 = -1164548925;
									continue;
								}
								goto case 141;
							case 80:
								result2 = false;
								goto end_IL_023a;
							case 52:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 188;
								}
								if (cultureInfo == null)
								{
									goto case 74;
								}
								goto IL_1f5c;
							case 241:
								goto IL_1f82;
							case 141:
								if (object.ReferenceEquals(type, typeof(ushort)))
								{
									result = (uint)(ushort)obj;
									num37 = -1164548925;
									continue;
								}
								goto IL_2579;
							case 37:
								num37 = -1164549106;
								continue;
							case 12:
								result = (ulong)(decimal)obj;
								num37 = -1164549058;
								continue;
							case 44:
								goto IL_1ffa;
							case 0:
								result2 = false;
								num37 = -1164549107;
								continue;
							case 282:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (byte)(ulong)obj;
									num37 = -1164549118;
									continue;
								}
								goto IL_0e36;
							case 157:
								result2 = true;
								goto end_IL_023a;
							case 147:
								result2 = false;
								num37 = -1164548963;
								continue;
							case 242:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (uint)(decimal)obj;
									num37 = -1164549059;
									continue;
								}
								goto case 266;
							case 162:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (ulong)obj != 0;
									num37 = -1164548920;
									continue;
								}
								goto case 218;
							case 268:
								goto end_IL_023a;
							case 92:
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (double)(sbyte)obj;
									num37 = -1164549066;
									continue;
								}
								goto case 265;
							case 4:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (ulong)(short)obj;
									num37 = -1164548691;
									continue;
								}
								goto case 220;
							case 57:
								result2 = true;
								num37 = -1164549005;
								continue;
							case 180:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (decimal)(uint)obj;
									num37 = -1164549042;
									continue;
								}
								goto case 20;
							case 53:
								if (object.ReferenceEquals(type, typeof(int)))
								{
									result = (ulong)(int)obj;
									num37 = -1164549058;
									continue;
								}
								goto case 187;
							case 252:
								result = (byte)(float)obj;
								num37 = -1164549063;
								continue;
							case 174:
								num37 = -1164548925;
								continue;
							case 38:
								result2 = false;
								num37 = -1164548987;
								continue;
							case 200:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 107;
								}
								goto IL_21f2;
							case 103:
								result = (byte)(double)obj;
								num37 = -1164549002;
								continue;
							case 99:
								result2 = true;
								goto end_IL_023a;
							case 35:
								if (object.ReferenceEquals(type, typeof(ushort)))
								{
									result = (byte)(ushort)obj;
									num37 = -1164549063;
									continue;
								}
								goto case 75;
							case 161:
								num37 = -1164548920;
								continue;
							case 264:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (long)(decimal)obj;
									num37 = -1164549039;
									continue;
								}
								goto case 93;
							case 54:
								goto end_IL_023a;
							case 202:
								if (!object.ReferenceEquals(targetType, typeof(byte)))
								{
									goto IL_1a24;
								}
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (byte)(sbyte)obj;
									num37 = -1164549098;
									continue;
								}
								goto IL_26e3;
							case 32:
								if (object.ReferenceEquals(type, typeof(byte)))
								{
									result = (long)(byte)obj;
									num37 = -1164548890;
									continue;
								}
								goto case 226;
							case 81:
								goto end_IL_023a;
							case 86:
								if (object.ReferenceEquals(type, typeof(ulong)))
								{
									result = (ushort)(ulong)obj;
									num37 = -1164548974;
									continue;
								}
								goto case 275;
							case 90:
								result = (short)(int)obj;
								num37 = -1164549056;
								continue;
							case 279:
							{
								object result15;
								if (TryConvertOrCreateObject(elementType, list7[num41], out result15, numberStyle, cultureInfo))
								{
									array6.SetValue(result15, num41);
									num37 = -1164549024;
									continue;
								}
								goto case 203;
							}
							case 271:
								num37 = -1164548698;
								continue;
							case 33:
								if (!object.ReferenceEquals(targetType, typeof(decimal)))
								{
									goto case 79;
								}
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (decimal)(float)obj;
									num37 = -1164549042;
									continue;
								}
								goto IL_1dc8;
							case 186:
								result = (sbyte)(long)obj;
								num37 = -1164549083;
								continue;
							case 23:
								result = array5;
								num37 = -1164548909;
								continue;
							case 24:
								goto end_IL_023a;
							case 275:
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (ushort)(float)obj;
									num37 = -1164548938;
									continue;
								}
								goto IL_0fc8;
							case 269:
								result2 = true;
								goto end_IL_023a;
							case 46:
								goto end_IL_023a;
							case 144:
								goto end_IL_023a;
							case 278:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (decimal)obj > 0m;
									num37 = -1164549110;
									continue;
								}
								goto case 108;
							case 87:
								num44++;
								num37 = -1164548933;
								continue;
							case 36:
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (sbyte)(float)obj;
									num37 = -1164549083;
									continue;
								}
								goto case 58;
							case 254:
								result2 = false;
								goto end_IL_023a;
							case 50:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (ulong)(uint)obj;
									num37 = -1164549058;
									continue;
								}
								goto case 145;
							case 78:
								goto IL_2548;
							case 259:
								goto IL_2579;
							case 265:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (double)(decimal)obj;
									num37 = -1164549066;
									continue;
								}
								goto IL_2851;
							case 64:
								result = (ushort)(sbyte)obj;
								num37 = -1164548974;
								continue;
							case 163:
								num37 = -1164549042;
								continue;
							case 3:
								num37 = -1164549106;
								continue;
							case 277:
								num37 = -1164549066;
								continue;
							case 284:
								result = (ushort)(byte)obj;
								num37 = -1164548974;
								continue;
							case 240:
								result2 = false;
								goto end_IL_023a;
							case 244:
								result2 = false;
								goto end_IL_023a;
							case 156:
								result = (double)(int)(ushort)obj;
								num37 = -1164549008;
								continue;
							case 208:
								goto IL_265a;
							case 76:
								if (object.ReferenceEquals(type, typeof(float)))
								{
									result = (uint)(float)obj;
									num37 = -1164548925;
									continue;
								}
								goto IL_2b8d;
							case 69:
								result2 = false;
								num37 = -1164548941;
								continue;
							case 225:
								goto end_IL_023a;
							case 210:
								result = (ushort)obj > 0;
								num37 = -1164548920;
								continue;
							case 172:
								goto IL_26e3;
							case 6:
								result = result14;
								num37 = -1164549115;
								continue;
							case 114:
								goto IL_271c;
							case 234:
								array4 = obj as Array;
								num37 = -1164549019;
								continue;
							case 155:
								goto IL_274b;
							case 140:
								result = result19;
								num37 = -1164549083;
								continue;
							case 283:
								goto IL_2784;
							case 27:
								result = (decimal)(double)obj;
								num37 = -1164549042;
								continue;
							case 248:
								result = (uint)(byte)obj;
								num37 = -1164548917;
								continue;
							case 207:
								goto IL_2801;
							case 124:
								if (object.ReferenceEquals(type, typeof(uint)))
								{
									result = (long)(uint)obj;
									num37 = -1164548890;
									continue;
								}
								goto IL_2996;
							case 285:
								goto IL_2851;
							case 40:
								result = (ushort)(double)obj;
								num37 = -1164548974;
								continue;
							case 106:
								num37 = -1164548890;
								continue;
							case 213:
								goto IL_2899;
							case 5:
							{
								object result23;
								if (TryConvertOrCreateObject(elementType, array4.GetValue(num44), out result23, numberStyle, cultureInfo))
								{
									array8.SetValue(result23, num44);
									num37 = -1164548868;
									continue;
								}
								goto case 87;
							}
							case 89:
								result2 = false;
								num37 = -1164548924;
								continue;
							case 125:
								if (object.ReferenceEquals(type, typeof(ushort)))
								{
									result = (long)(ushort)obj;
									num37 = -1164549014;
									continue;
								}
								goto case 32;
							case 183:
								num45++;
								num37 = -1164548915;
								continue;
							case 72:
								if (object.ReferenceEquals(type, typeof(ushort)))
								{
									result = (decimal)(ushort)obj;
									num37 = -1164549026;
									continue;
								}
								goto case 231;
							case 227:
								if (object.ReferenceEquals(type, typeof(byte)))
								{
									result = (ulong)(byte)obj;
									num37 = -1164549058;
									continue;
								}
								goto case 239;
							case 112:
								goto IL_2996;
							case 229:
								result2 = true;
								goto end_IL_023a;
							case 39:
								goto IL_29ce;
							case 220:
								if (object.ReferenceEquals(type, typeof(ushort)))
								{
									result = (ulong)(ushort)obj;
									num37 = -1164549058;
									continue;
								}
								goto case 227;
							case 230:
								goto IL_2a21;
							case 131:
								goto IL_2a44;
							case 85:
								num37 = -1164549066;
								continue;
							case 130:
								num37 = -1164549042;
								continue;
							case 170:
								result = result22;
								num37 = -1164548890;
								continue;
							case 267:
								result2 = false;
								num37 = -1164549061;
								continue;
							case 193:
								num37 = -1164548890;
								continue;
							case 281:
								goto IL_2aa8;
							case 247:
								result = (short)(ushort)obj;
								num37 = -1164548978;
								continue;
							case 177:
								if (object.ReferenceEquals(type, typeof(byte)))
								{
									result = (short)(byte)obj;
									num37 = -1164549106;
									continue;
								}
								goto IL_0f02;
							case 149:
								result2 = true;
								goto end_IL_023a;
							case 59:
								if (object.ReferenceEquals(type, typeof(sbyte)))
								{
									result = (decimal)(sbyte)obj;
									num37 = -1164549042;
									continue;
								}
								goto case 126;
							case 100:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (byte)(decimal)obj;
									num37 = -1164549063;
									continue;
								}
								goto case 158;
							case 26:
								num37 = -1164549106;
								continue;
							case 122:
								goto IL_2b8d;
							case 153:
								goto IL_2bb3;
							case 111:
								goto end_IL_023a;
							case 94:
								num37 = -1164549042;
								continue;
							case 93:
								if (object.ReferenceEquals(type, typeof(short)))
								{
									result = (long)(short)obj;
									num37 = -1164548927;
									continue;
								}
								goto case 125;
							case 145:
								if (object.ReferenceEquals(type, typeof(double)))
								{
									result = (ulong)(double)obj;
									num37 = -1164548886;
									continue;
								}
								goto IL_0e10;
							case 198:
								goto IL_2c4c;
							case 224:
								result = (short)(ulong)obj;
								num37 = -1164548983;
								continue;
							case 8:
								result = (double)(short)obj;
								num37 = -1164549066;
								continue;
							case 231:
								if (object.ReferenceEquals(type, typeof(byte)))
								{
									result = (decimal)(byte)obj;
									num37 = -1164549042;
									continue;
								}
								goto case 59;
							case 218:
								if (object.ReferenceEquals(type, typeof(double)))
								{
									result = (double)obj > 0.0;
									num37 = -1164548920;
									continue;
								}
								goto case 278;
							case 223:
								goto IL_2d19;
							case 98:
								if (cultureInfo == null)
								{
									goto case 190;
								}
								if (!double.TryParse(obj.ToString(), numberStyle, cultureInfo, out result13))
								{
									result2 = false;
									goto end_IL_023a;
								}
								goto case 49;
							case 214:
								result = result20;
								num37 = -1164549079;
								continue;
							case 197:
								if (object.ReferenceEquals(type, typeof(double)))
								{
									result = (uint)(double)obj;
									num37 = -1164548925;
									continue;
								}
								goto case 242;
							case 135:
								result = (decimal)(int)obj;
								num37 = -1164548673;
								continue;
							case 256:
								if (!object.ReferenceEquals(type, typeof(string)))
								{
									goto case 105;
								}
								goto IL_2dde;
							case 246:
							{
								object result25;
								if (TryConvertOrCreateObject(elementType, readOnlyList2[num45], out result25, numberStyle, cultureInfo))
								{
									array9.SetValue(result25, num45);
									num37 = -1164549092;
									continue;
								}
								goto case 183;
							}
							case 245:
								num37 = -1164549042;
								continue;
							case 182:
								goto IL_2e2f;
							case 45:
								num37 = -1164549106;
								continue;
							case 262:
								num37 = -1164549058;
								continue;
							case 185:
								if (object.ReferenceEquals(type, typeof(decimal)))
								{
									result = (sbyte)(decimal)obj;
									num37 = -1164549083;
									continue;
								}
								goto case 181;
							case 165:
								result2 = true;
								num37 = -1164549093;
								continue;
							case 257:
								goto IL_2ea4;
							case 19:
								goto IL_2eca;
							case 9:
								goto IL_2eed;
							default:
								goto IL_2f13;
							}
							break;
							IL_2ea4:
							int num46;
							if (!short.TryParse(obj.ToString(), numberStyle, cultureInfo, out result21))
							{
								num37 = -1164548998;
								num46 = num37;
							}
							else
							{
								num37 = -1164548900;
								num46 = num37;
							}
							continue;
							IL_1a84:
							int num47;
							if (!object.ReferenceEquals(type, typeof(float)))
							{
								num37 = -1164548948;
								num47 = num37;
							}
							else
							{
								num37 = -1164549114;
								num47 = num37;
							}
							continue;
							IL_1f5c:
							int num48;
							if (ulong.TryParse(obj.ToString(), numberStyle, cultureInfo, out result16))
							{
								num37 = -1164548902;
								num48 = num37;
							}
							else
							{
								num37 = -1164549120;
								num48 = num37;
							}
							continue;
							IL_2dde:
							int num49;
							if (cultureInfo == null)
							{
								num37 = -1164548686;
								num49 = num37;
							}
							else
							{
								num37 = -1164548694;
								num49 = num37;
							}
							continue;
							IL_10e8:
							array5 = Array.CreateInstance(elementType, serializedObject2.count);
							num43 = 0;
							num37 = -1164548971;
							continue;
							IL_26e3:
							int num50;
							if (!object.ReferenceEquals(type, typeof(int)))
							{
								num37 = -1164548964;
								num50 = num37;
							}
							else
							{
								num37 = -1164549071;
								num50 = num37;
							}
							continue;
							IL_2d19:
							int num51;
							if (!object.ReferenceEquals(type, typeof(uint)))
							{
								num37 = -1164549070;
								num51 = num37;
							}
							else
							{
								num37 = -1164549108;
								num51 = num37;
							}
							continue;
							IL_2801:
							int num52;
							if (!decimal.TryParse(obj.ToString(), out result20))
							{
								num37 = -1164549025;
								num52 = num37;
							}
							else
							{
								num37 = -1164548995;
								num52 = num37;
							}
							continue;
							IL_1a24:
							int num53;
							if (!object.ReferenceEquals(targetType, typeof(sbyte)))
							{
								num37 = -1164548982;
								num53 = num37;
							}
							else
							{
								num37 = -1164549054;
								num53 = num37;
							}
							continue;
							IL_2bb3:
							int num54;
							if (!object.ReferenceEquals(type, typeof(long)))
							{
								num37 = -1164548880;
								num54 = num37;
							}
							else
							{
								num37 = -1164548954;
								num54 = num37;
							}
							continue;
							IL_12d4:
							if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
							{
								num37 = -1164549087;
								continue;
							}
							goto IL_3017;
							IL_142a:
							int num55;
							if (!object.ReferenceEquals(type, typeof(decimal)))
							{
								num37 = -1164549049;
								num55 = num37;
							}
							else
							{
								num37 = -1164548899;
								num55 = num37;
							}
							continue;
							IL_2aa8:
							int num56;
							if (!short.TryParse(obj.ToString(), out result21))
							{
								num37 = -1164549105;
								num56 = num37;
							}
							else
							{
								num37 = -1164548900;
								num56 = num37;
							}
							continue;
							IL_1e40:
							int num57;
							if (!long.TryParse(obj.ToString(), out result22))
							{
								num37 = -1164549077;
								num57 = num37;
							}
							else
							{
								num37 = -1164549119;
								num57 = num37;
							}
							continue;
							IL_1ffa:
							int num58;
							if (object.ReferenceEquals(type, typeof(ulong)))
							{
								num37 = -1164549045;
								num58 = num37;
							}
							else
							{
								num37 = -1164548904;
								num58 = num37;
							}
							continue;
							IL_2899:
							int num59;
							if (object.ReferenceEquals(type, typeof(short)))
							{
								num37 = -1164548957;
								num59 = num37;
							}
							else
							{
								num37 = -1164549022;
								num59 = num37;
							}
							continue;
							IL_2851:
							int num60;
							if (object.ReferenceEquals(type, typeof(string)))
							{
								num37 = -1164548919;
								num60 = num37;
							}
							else
							{
								num37 = -1164548968;
								num60 = num37;
							}
							continue;
							IL_2b8d:
							int num61;
							if (object.ReferenceEquals(type, typeof(long)))
							{
								num37 = -1164548883;
								num61 = num37;
							}
							else
							{
								num37 = -1164548991;
								num61 = num37;
							}
							continue;
							IL_274b:
							int num62;
							if (!object.ReferenceEquals(type, typeof(sbyte)))
							{
								num37 = -1164549006;
								num62 = num37;
							}
							else
							{
								num37 = -1164548885;
								num62 = num37;
							}
							continue;
							IL_2784:
							if (ReflectionTools.IsArray(targetType))
							{
								elementType = targetType.GetElementType();
								if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
								{
									serializedObject2 = obj as SerializedObject;
									if (serializedObject2 == null)
									{
										result2 = false;
										goto end_IL_023a;
									}
									goto IL_10e8;
								}
								goto IL_2548;
							}
							goto IL_3351;
							IL_29ce:
							int num63;
							if (object.ReferenceEquals(type, typeof(ushort)))
							{
								num37 = -1164548999;
								num63 = num37;
							}
							else
							{
								num37 = -1164548677;
								num63 = num37;
							}
							continue;
							IL_2579:
							int num64;
							if (object.ReferenceEquals(type, typeof(byte)))
							{
								num37 = -1164549037;
								num64 = num37;
							}
							else
							{
								num37 = -1164548877;
								num64 = num37;
							}
							continue;
							IL_265a:
							int num65;
							if (!ReflectionTools.DoesTypeImplement(type, typeof(Array)))
							{
								num37 = -1164548884;
								num65 = num37;
							}
							else
							{
								num37 = -1164549055;
								num65 = num37;
							}
							continue;
							IL_271c:
							array9 = Array.CreateInstance(elementType, readOnlyList2.Count);
							num45 = 0;
							num37 = -1164548915;
							continue;
							IL_1dc8:
							int num66;
							if (object.ReferenceEquals(type, typeof(double)))
							{
								num37 = -1164548944;
								num66 = num37;
							}
							else
							{
								num37 = -1164548972;
								num66 = num37;
							}
							continue;
							IL_2548:
							if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
							{
								readOnlyList2 = obj as IReadOnlyList;
								if (readOnlyList2 == null)
								{
									result2 = false;
									num37 = -1164548912;
									continue;
								}
								goto IL_271c;
							}
							goto IL_2c4c;
							IL_100a:
							int num67;
							if (object.ReferenceEquals(type, typeof(double)))
							{
								num37 = -1164548916;
								num67 = num37;
							}
							else
							{
								num37 = -1164548913;
								num67 = num37;
							}
							continue;
							IL_1d0a:
							int num68;
							if (!object.ReferenceEquals(type, typeof(byte)))
							{
								num37 = -1164549072;
								num68 = num37;
							}
							else
							{
								num37 = -1164548681;
								num68 = num37;
							}
							continue;
							IL_2a44:
							int num69;
							if (object.ReferenceEquals(type, typeof(int)))
							{
								num37 = -1164549069;
								num69 = num37;
							}
							else
							{
								num37 = -1164549004;
								num69 = num37;
							}
							continue;
							IL_2996:
							int num70;
							if (object.ReferenceEquals(type, typeof(double)))
							{
								num37 = -1164549017;
								num70 = num37;
							}
							else
							{
								num37 = -1164548701;
								num70 = num37;
							}
							continue;
							IL_21f2:
							if (cultureInfo != null)
							{
								int num71;
								if (!uint.TryParse(obj.ToString(), numberStyle, cultureInfo, out result14))
								{
									num37 = -1164549029;
									num71 = num37;
								}
								else
								{
									num37 = -1164548947;
									num71 = num37;
								}
								continue;
							}
							goto IL_2e2f;
							IL_2eca:
							int num72;
							if (!sbyte.TryParse(obj.ToString(), out result19))
							{
								num37 = -1164548949;
								num72 = num37;
							}
							else
							{
								num37 = -1164549081;
								num72 = num37;
							}
							continue;
							IL_1f82:
							int num73;
							if (!object.ReferenceEquals(type, typeof(int)))
							{
								num37 = -1164549036;
								num73 = num37;
							}
							else
							{
								num37 = -1164548934;
								num73 = num37;
							}
							continue;
							IL_2c4c:
							if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
							{
								list7 = obj as IList;
								int num74;
								if (list7 != null)
								{
									num37 = -1164548959;
									num74 = num37;
								}
								else
								{
									num37 = -1164548979;
									num74 = num37;
								}
								continue;
							}
							goto IL_265a;
							IL_2e2f:
							int num75;
							if (uint.TryParse(obj.ToString(), out result14))
							{
								num37 = -1164548947;
								num75 = num37;
							}
							else
							{
								num37 = -1164549064;
								num75 = num37;
							}
							continue;
							IL_0e36:
							int num76;
							if (object.ReferenceEquals(type, typeof(float)))
							{
								num37 = -1164549033;
								num76 = num37;
							}
							else
							{
								num37 = -1164549073;
								num76 = num37;
							}
							continue;
							IL_1742:
							int num77;
							if (num41 >= list7.Count)
							{
								num37 = -1164548881;
								num77 = num37;
							}
							else
							{
								num37 = -1164548676;
								num77 = num37;
							}
							continue;
							IL_2a21:
							int num78;
							if (ushort.TryParse(obj.ToString(), out result18))
							{
								num37 = -1164548940;
								num78 = num37;
							}
							else
							{
								num37 = -1164548882;
								num78 = num37;
							}
							continue;
							IL_133b:
							int num79;
							if (byte.TryParse(obj.ToString(), numberStyle, cultureInfo, out result24))
							{
								num37 = -1164548918;
								num79 = num37;
							}
							else
							{
								num37 = -1164548876;
								num79 = num37;
							}
							continue;
							IL_0e10:
							int num80;
							if (object.ReferenceEquals(type, typeof(decimal)))
							{
								num37 = -1164548953;
								num80 = num37;
							}
							else
							{
								num37 = -1164548945;
								num80 = num37;
							}
							continue;
							IL_1918:
							int num81;
							if (num43 >= serializedObject2.count)
							{
								num37 = -1164548932;
								num81 = num37;
							}
							else
							{
								num37 = -1164548897;
								num81 = num37;
							}
							continue;
							IL_0fc8:
							int num82;
							if (!object.ReferenceEquals(type, typeof(double)))
							{
								num37 = -1164548685;
								num82 = num37;
							}
							else
							{
								num37 = -1164548989;
								num82 = num37;
							}
							continue;
							IL_13bc:
							int num83;
							if (!object.ReferenceEquals(type, typeof(ushort)))
							{
								num37 = -1164548887;
								num83 = num37;
							}
							else
							{
								num37 = -1164549065;
								num83 = num37;
							}
							continue;
							IL_18cf:
							int num84;
							if (!object.ReferenceEquals(type, typeof(long)))
							{
								num37 = -1164548962;
								num84 = num37;
							}
							else
							{
								num37 = -1164548690;
								num84 = num37;
							}
							continue;
							IL_171c:
							int num85;
							if (!object.ReferenceEquals(type, typeof(ushort)))
							{
								num37 = -1164548969;
								num85 = num37;
							}
							else
							{
								num37 = -1164549028;
								num85 = num37;
							}
							continue;
							IL_0cc0:
							int num86;
							if (object.ReferenceEquals(type, typeof(byte)))
							{
								num37 = -1164548922;
								num86 = num37;
							}
							else
							{
								num37 = -1164549068;
								num86 = num37;
							}
							continue;
							IL_186f:
							int num87;
							if (object.ReferenceEquals(type, typeof(ulong)))
							{
								num37 = -1164549109;
								num87 = num37;
							}
							else
							{
								num37 = -1164548994;
								num87 = num37;
							}
							continue;
							IL_0f02:
							int num88;
							if (object.ReferenceEquals(type, typeof(sbyte)))
							{
								num37 = -1164549060;
								num88 = num37;
							}
							else
							{
								num37 = -1164548693;
								num88 = num37;
							}
							continue;
							IL_0da6:
							int num89;
							if (!object.ReferenceEquals(type, typeof(int)))
							{
								num37 = -1164548930;
								num89 = num37;
							}
							else
							{
								num37 = -1164549076;
								num89 = num37;
							}
							continue;
							IL_17cd:
							int num90;
							if (object.ReferenceEquals(type, typeof(int)))
							{
								num37 = -1164548879;
								num90 = num37;
							}
							else
							{
								num37 = -1164549013;
								num90 = num37;
							}
							continue;
							IL_2eed:
							int num91;
							if (object.ReferenceEquals(type, typeof(long)))
							{
								num37 = -1164549103;
								num91 = num37;
							}
							else
							{
								num37 = -1164548992;
								num91 = num37;
							}
							continue;
							IL_0edc:
							int num92;
							if (!object.ReferenceEquals(targetType, typeof(long)))
							{
								num37 = -1164548965;
								num92 = num37;
							}
							else
							{
								num37 = -1164549032;
								num92 = num37;
							}
						}
						goto IL_0833;
						IL_2f13:
						enumerator2 = dictionary3.Values.GetEnumerator();
						try
						{
							while (true)
							{
								IL_2f49:
								int num93;
								int num94;
								if (enumerator2.MoveNext())
								{
									num93 = -1164548945;
									num94 = num93;
								}
								else
								{
									num93 = -1164548950;
									num94 = num93;
								}
								while (true)
								{
									switch (num93 ^ -1164548949)
									{
									case 3:
										num93 = -1164548945;
										continue;
									default:
										goto end_IL_2f28;
									case 0:
										break;
									case 2:
										array7.SetValue(result26, num42);
										num42++;
										num93 = -1164548949;
										continue;
									case 4:
									{
										object current4 = enumerator2.Current;
										int num95;
										if (TryConvertOrCreateObject(targetType2, current4, out result26, numberStyle, cultureInfo))
										{
											num93 = -1164548951;
											num95 = num93;
										}
										else
										{
											num93 = -1164548949;
											num95 = num93;
										}
										continue;
									}
									case 1:
										goto end_IL_2f28;
									}
									goto IL_2f49;
									continue;
									end_IL_2f28:
									break;
								}
								break;
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
						result = array7;
						goto IL_2fc0;
						IL_3953:
						while (true)
						{
							switch (num25 ^ -1164548949)
							{
							case 6:
								break;
							case 4:
								result2 = true;
								goto end_IL_023a;
							case 5:
								goto IL_3996;
							case 2:
								goto end_IL_023a;
							case 3:
								goto IL_39be;
							case 0:
								result2 = false;
								goto end_IL_023a;
							case 1:
								result = obj;
								result2 = true;
								goto end_IL_023a;
							case 8:
								goto IL_3a09;
							default:
								goto IL_3a3c;
							}
							break;
							IL_39be:
							int num96;
							if (TryCreateObject(targetType, obj as SerializedObject, out obj))
							{
								num25 = -1164548950;
								num96 = num25;
							}
							else
							{
								num25 = -1164548949;
								num96 = num25;
							}
						}
						goto IL_394e;
						IL_3017:
						if (ReflectionTools.DoesTypeImplement(type, typeof(ICollection)))
						{
							num19 = -1164548952;
							goto IL_2fc5;
						}
						goto IL_3123;
						IL_387c:
						enumerator2 = dictionary2.Keys.GetEnumerator();
						try
						{
							while (true)
							{
								IL_3913:
								int num97;
								int num98;
								if (enumerator2.MoveNext())
								{
									num97 = -1164548945;
									num98 = num97;
								}
								else
								{
									num97 = -1164548950;
									num98 = num97;
								}
								while (true)
								{
									switch (num97 ^ -1164548949)
									{
									case 3:
										num97 = -1164548945;
										continue;
									default:
										goto end_IL_3894;
									case 0:
										dictionary.Add(result27, result28);
										num97 = -1164548951;
										continue;
									case 5:
										if (TryConvertOrCreateObject(type3, current5, out result27, numberStyle, cultureInfo))
										{
											int num99;
											if (!TryConvertOrCreateObject(type4, dictionary2[current5], out result28, numberStyle, cultureInfo))
											{
												num97 = -1164548951;
												num99 = num97;
											}
											else
											{
												num97 = -1164548949;
												num99 = num97;
											}
											continue;
										}
										break;
									case 4:
										current5 = enumerator2.Current;
										num97 = -1164548946;
										continue;
									case 2:
										break;
									case 1:
										goto end_IL_3894;
									}
									goto IL_3913;
									continue;
									end_IL_3894:
									break;
								}
								break;
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
						result = dictionary;
						result2 = true;
						goto IL_394e;
						IL_2fc5:
						while (true)
						{
							switch (num19 ^ -1164548949)
							{
							case 0:
								break;
							case 2:
								result2 = true;
								goto end_IL_023a;
							case 3:
								collection = obj as ICollection;
								array = Array.CreateInstance(elementType, collection.Count);
								num4 = 0;
								num19 = -1164548950;
								continue;
							case 4:
								goto IL_3017;
							default:
								goto IL_3033;
							}
							break;
						}
						goto IL_2fc0;
						continue;
						end_IL_023a:
						break;
					}
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				goto IL_3a3c;
			}
			return result2;
			IL_3a3c:
			return false;
		}

		private static bool TryCreateObject(Type type, SerializedObject serializedObject, out object result, NumberStyles numberStyle = NumberStyles.Any, CultureInfo cultureInfo = null)
		{
			int num;
			if (serializedObject != null)
			{
				if ((object)type == null)
				{
					goto IL_0006;
				}
				result = Factory.CreateInstance(type);
				num = -963937930;
				goto IL_000b;
			}
			goto IL_002f;
			IL_000b:
			Dictionary<string, PropertyInfo> value4 = default(Dictionary<string, PropertyInfo>);
			Dictionary<string, FieldInfo> value = default(Dictionary<string, FieldInfo>);
			PropertyInfo value5 = default(PropertyInfo);
			while (true)
			{
				switch (num ^ -963937929)
				{
				case 0:
					break;
				case 2:
					goto IL_002f;
				case 3:
					if (!tknsOaiPSIUNmMayaHzXqipCMuW.TryGetValue(type, out value4))
					{
						value4 = (from P_0 in ReflectionTools.GetProperties(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
							where P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), true) && !P_0.IsDefined(typeof(DoNotSerializeAttribute), true)
							select P_0).ToDictionary((PropertyInfo P_0) =>
						{
							string name2;
							return (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name)) ? name2 : P_0.Name;
						});
						tknsOaiPSIUNmMayaHzXqipCMuW.Add(type, value4);
						num = -963937933;
						continue;
					}
					goto default;
				case 1:
					if (!FigRKutykumzSMBgeLVlQswHuQZ.TryGetValue(type, out value))
					{
						value = (from P_0 in ReflectionTools.GetFields(type, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
							where (P_0.IsPublic || P_0.IsDefined(typeof(SerializeAttribute), true) || P_0.IsDefined(typeof(SerializeField), true)) && !P_0.IsDefined(typeof(NonSerializedAttribute), true) && !P_0.IsDefined(typeof(DoNotSerializeAttribute), true)
							select P_0).ToDictionary((FieldInfo P_0) =>
						{
							string name2;
							return (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name)) ? name2 : P_0.Name;
						});
						FigRKutykumzSMBgeLVlQswHuQZ.Add(type, value);
						num = -963937932;
						continue;
					}
					goto case 3;
				default:
				{
					using (IEnumerator<Field> enumerator = ((IEnumerable<Field>)serializedObject).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							while (true)
							{
								IL_01b4:
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
									num2 = -963937931;
									goto IL_0140;
								}
								goto IL_018f;
								IL_018f:
								if (!value4.TryGetValue(name, out value5))
								{
									break;
								}
								int num3;
								if (value5.CanWrite)
								{
									num2 = -963937930;
									num3 = num2;
								}
								else
								{
									num2 = -963937931;
									num3 = num2;
								}
								goto IL_0140;
								IL_0140:
								while (true)
								{
									switch (num2 ^ -963937929)
									{
									case 0:
										num2 = -963937932;
										continue;
									case 1:
										if (TryConvertOrCreateObject(value5.PropertyType, value2, out result2, numberStyle, cultureInfo))
										{
											value5.SetValue(result, result2, null);
											num2 = -963937931;
											continue;
										}
										goto end_IL_01b4;
									case 4:
										break;
									case 3:
										goto IL_01b4;
									default:
										goto end_IL_01b4;
									}
									break;
								}
								goto IL_018f;
								continue;
								end_IL_01b4:
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
			}
			goto IL_0006;
			IL_002f:
			result = null;
			return false;
			IL_0006:
			num = -963937931;
			goto IL_000b;
		}

		public static SerializedObject FromJson(Type type, string jsonString)
		{
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			SerializedObject serializedObject = default(SerializedObject);
			while (true)
			{
				int num;
				int num2;
				if (!string.IsNullOrEmpty(jsonString))
				{
					num = -1756039093;
					num2 = num;
				}
				else
				{
					num = -1756039092;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1756039095)
					{
					case 6:
						num = -1756039096;
						continue;
					case 1:
						break;
					case 4:
						if (serializedObject != null)
						{
							int num3;
							if (serializedObject.count == 0)
							{
								num = -1756039094;
								num3 = num;
							}
							else
							{
								num = -1756039095;
								num3 = num;
							}
							continue;
						}
						goto case 3;
					case 3:
						throw new Exception("No data found in Json string.");
					case 2:
						serializedObject = JsonParser.FromJson<SerializedObject>(jsonString, typeof(SerializedObject));
						num = -1756039091;
						continue;
					case 5:
						throw new ArgumentNullException("jsonString");
					default:
						return serializedObject;
					}
					break;
				}
			}
		}

		public static SerializedObject FromXml(Type type, string xmlString)
		{
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			SerializedObject serializedObject = default(SerializedObject);
			XmlDocument.Element element = default(XmlDocument.Element);
			while (!string.IsNullOrEmpty(xmlString))
			{
				while (true)
				{
					XmlDocument xmlDocument = new XmlDocument(xmlString);
					if (xmlDocument.isValid)
					{
						while (true)
						{
							int num;
							int num2;
							if (xmlDocument.root.childCount != 0)
							{
								num = 1635531426;
								num2 = num;
							}
							else
							{
								num = 1635531428;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x617C3AA0)
								{
								case 7:
									num = 1635531425;
									continue;
								case 5:
									serializedObject = element.GetSerializedObject() as SerializedObject;
									if (serializedObject != null)
									{
										goto IL_005c;
									}
									goto case 3;
								case 6:
									break;
								case 0:
									goto end_IL_0075;
								case 4:
									throw new Exception("No data found in XML string.");
								case 1:
									goto end_IL_0093;
								case 2:
									element = xmlDocument.root.FindChild(type.Name);
									if (element == null)
									{
										throw new Exception("Main element not found in XML string.");
									}
									goto case 5;
								case 3:
									throw new Exception("No data found in XML string.");
								default:
									return serializedObject;
								}
								break;
								IL_005c:
								int num3;
								if (serializedObject.count == 0)
								{
									num = 1635531427;
									num3 = num;
								}
								else
								{
									num = 1635531432;
									num3 = num;
								}
							}
							continue;
							end_IL_0075:
							break;
						}
						continue;
					}
					throw new Exception("Failed to parse XML string.");
					continue;
					end_IL_0093:
					break;
				}
			}
			throw new ArgumentNullException("xmlString");
		}

		[CompilerGenerated]
		private static bool CHFQWYKPKWnMLQiSPPQBBvsTnJZ(FieldInfo P_0)
		{
			if ((P_0.IsPublic || P_0.IsDefined(typeof(SerializeAttribute), true) || P_0.IsDefined(typeof(SerializeField), true)) && !P_0.IsDefined(typeof(NonSerializedAttribute), true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string lUBrAWcchvgiVFeBNHyXoygYMHq(FieldInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}

		[CompilerGenerated]
		private static bool MTogZAGZbvYYYyZKOPUGDurwlLW(PropertyInfo P_0)
		{
			if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string PjZzdzpVzflDOymiMEXNDsTcVdgx(PropertyInfo P_0)
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
