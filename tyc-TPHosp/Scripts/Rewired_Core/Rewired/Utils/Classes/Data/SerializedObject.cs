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
	[Preserve]
	[CustomObfuscation(rename = false)]
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

		private struct pBFnMUkqZurapwJfzasmHKaRedG
		{
			public Type NKrRavQzBncjnBNomJbbjeXhgCD;

			public object HpxePuhaScltgSCBmgsrsCpjliL;

			public FieldOptions RmejrHhGmdrPzXkxpiABNmKtOnI;

			public pBFnMUkqZurapwJfzasmHKaRedG(Type type, object value, FieldOptions options)
			{
				NKrRavQzBncjnBNomJbbjeXhgCD = type;
				HpxePuhaScltgSCBmgsrsCpjliL = value;
				RmejrHhGmdrPzXkxpiABNmKtOnI = options;
			}

			public override string ToString()
			{
				string text = "";
				text = text + "type = " + (((object)NKrRavQzBncjnBNomJbbjeXhgCD != null) ? NKrRavQzBncjnBNomJbbjeXhgCD.Name : "NULL") + "\n";
				text = text + "value = " + ((HpxePuhaScltgSCBmgsrsCpjliL != null) ? HpxePuhaScltgSCBmgsrsCpjliL.ToString() : "NULL") + "\n";
				object obj = text;
				return string.Concat(obj, "options = ", RmejrHhGmdrPzXkxpiABNmKtOnI, "\n");
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
				text = text + "type = " + (((object)type != null) ? type.Name : "NULL") + "\n";
				object obj = text;
				return string.Concat(obj, "options = ", options, "\n");
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class XmlInfo
		{
			public abstract class jEsOHjtWZugHpJbcerYroDoLmll
			{
			}

			public class OyVEtLlgkNfHXzDuiVPrVGAKdJW : jEsOHjtWZugHpJbcerYroDoLmll
			{
				public string LwDBNnNFqBxCeHOdFxAkCpxXHQR;

				public string zYwYmGHTCLOJxCByvWzioBevSzj;

				public string oseqaDGmYbdubOOmISVVBGRFzNc;

				public string HpxePuhaScltgSCBmgsrsCpjliL;

				public override string ToString()
				{
					string text = "";
					text = text + "prefix = " + LwDBNnNFqBxCeHOdFxAkCpxXHQR + "\n";
					text = text + "localName = " + zYwYmGHTCLOJxCByvWzioBevSzj + "\n";
					text = text + "ns = " + oseqaDGmYbdubOOmISVVBGRFzNc + "\n";
					return text + "value = " + HpxePuhaScltgSCBmgsrsCpjliL + "\n";
				}
			}

			private List<jEsOHjtWZugHpJbcerYroDoLmll> KPKVOZiJXapmEVaLohycKybKtMF;

			public List<jEsOHjtWZugHpJbcerYroDoLmll> attributes => KPKVOZiJXapmEVaLohycKybKtMF ?? (KPKVOZiJXapmEVaLohycKybKtMF = new List<jEsOHjtWZugHpJbcerYroDoLmll>());

			public override string ToString()
			{
				string text = "Attributes:\n";
				if (KPKVOZiJXapmEVaLohycKybKtMF != null)
				{
					for (int i = 0; i < KPKVOZiJXapmEVaLohycKybKtMF.Count; i++)
					{
						text = text + KPKVOZiJXapmEVaLohycKybKtMF[i].ToString() + "\n";
					}
				}
				return text;
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IDisposable, IEnumerator, IEnumerator<Field>
		{
			private IndexedDictionary<string, pBFnMUkqZurapwJfzasmHKaRedG> JIrXlwvAsrFbMRDIqaqVCXOEeRm;

			private Field bAihUPOaQoqOwOHZvtGkVuGzqqW;

			private IEnumerator<KeyValuePair<string, pBFnMUkqZurapwJfzasmHKaRedG>> KCIgXJAxUjCseajTqtbyFBOakZYf;

			public Field Current => bAihUPOaQoqOwOHZvtGkVuGzqqW;

			object IEnumerator.Current => bAihUPOaQoqOwOHZvtGkVuGzqqW;

			internal Enumerator(object dictionary)
			{
				JIrXlwvAsrFbMRDIqaqVCXOEeRm = (IndexedDictionary<string, pBFnMUkqZurapwJfzasmHKaRedG>)dictionary;
				bAihUPOaQoqOwOHZvtGkVuGzqqW = default(Field);
				KCIgXJAxUjCseajTqtbyFBOakZYf = JIrXlwvAsrFbMRDIqaqVCXOEeRm.GetEnumerator();
			}

			public bool MoveNext()
			{
				if (!KCIgXJAxUjCseajTqtbyFBOakZYf.MoveNext())
				{
					return false;
				}
				KeyValuePair<string, pBFnMUkqZurapwJfzasmHKaRedG> current = KCIgXJAxUjCseajTqtbyFBOakZYf.Current;
				bAihUPOaQoqOwOHZvtGkVuGzqqW = new Field(current.Key, current.Value.HpxePuhaScltgSCBmgsrsCpjliL, current.Value.NKrRavQzBncjnBNomJbbjeXhgCD, current.Value.RmejrHhGmdrPzXkxpiABNmKtOnI);
				return true;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				bAihUPOaQoqOwOHZvtGkVuGzqqW = default(Field);
				KCIgXJAxUjCseajTqtbyFBOakZYf = JIrXlwvAsrFbMRDIqaqVCXOEeRm.GetEnumerator();
			}
		}

		private class ErLCouIyxIKZlPELbhIAagMFCDOf
		{
			public class zfdExcQbYfGXxFgwlDUbOnevxri
			{
				public readonly string MLmLjcwSbKBkEhcbqGJFmLCQUrjT;

				public readonly zfdExcQbYfGXxFgwlDUbOnevxri IqqFMkivXajbnQieKffNsZWOHNR;

				public string HMLWlSECOiVOzGrIKGhNElmqFNf;

				public Dictionary<string, string> nwJxhFTRJmkXvkVzmYghMcvPqfV;

				public List<zfdExcQbYfGXxFgwlDUbOnevxri> uFvhbocttwSJFAfGbgBaeZJYbdbp;

				public int childCount
				{
					get
					{
						if (uFvhbocttwSJFAfGbgBaeZJYbdbp == null)
						{
							return 0;
						}
						return uFvhbocttwSJFAfGbgBaeZJYbdbp.Count;
					}
				}

				public int attributeCount
				{
					get
					{
						if (nwJxhFTRJmkXvkVzmYghMcvPqfV == null)
						{
							return 0;
						}
						return nwJxhFTRJmkXvkVzmYghMcvPqfV.Count;
					}
				}

				public zfdExcQbYfGXxFgwlDUbOnevxri(string name, zfdExcQbYfGXxFgwlDUbOnevxri parent)
				{
					MLmLjcwSbKBkEhcbqGJFmLCQUrjT = name;
					IqqFMkivXajbnQieKffNsZWOHNR = parent;
					parent?.qnXxbqrGKQALpqdYfZcosrLBTLZ(this);
				}

				public void qnXxbqrGKQALpqdYfZcosrLBTLZ(zfdExcQbYfGXxFgwlDUbOnevxri P_0)
				{
					if (P_0 != null)
					{
						if (uFvhbocttwSJFAfGbgBaeZJYbdbp == null)
						{
							uFvhbocttwSJFAfGbgBaeZJYbdbp = new List<zfdExcQbYfGXxFgwlDUbOnevxri>();
						}
						uFvhbocttwSJFAfGbgBaeZJYbdbp.Add(P_0);
					}
				}

				public void iwUEWfDzCEkNAUDecnXxrDjOLif(string P_0, string P_1)
				{
					if (!string.IsNullOrEmpty(P_0))
					{
						if (nwJxhFTRJmkXvkVzmYghMcvPqfV == null)
						{
							nwJxhFTRJmkXvkVzmYghMcvPqfV = new Dictionary<string, string>();
						}
						if (nwJxhFTRJmkXvkVzmYghMcvPqfV.ContainsKey(P_0))
						{
							nwJxhFTRJmkXvkVzmYghMcvPqfV[P_0] = P_1;
						}
						else
						{
							nwJxhFTRJmkXvkVzmYghMcvPqfV.Add(P_0, P_1);
						}
					}
				}

				public bool RuSdaBMSYEjCpklHHsCYKavMKka(string P_0)
				{
					return bltzZVKjzjBuihntKgHQwAwYrGv(P_0) != null;
				}

				public zfdExcQbYfGXxFgwlDUbOnevxri bltzZVKjzjBuihntKgHQwAwYrGv(string P_0)
				{
					if (childCount == 0)
					{
						return null;
					}
					for (int i = 0; i < uFvhbocttwSJFAfGbgBaeZJYbdbp.Count; i++)
					{
						if (string.Equals(uFvhbocttwSJFAfGbgBaeZJYbdbp[i].MLmLjcwSbKBkEhcbqGJFmLCQUrjT, P_0, StringComparison.Ordinal))
						{
							return uFvhbocttwSJFAfGbgBaeZJYbdbp[i];
						}
					}
					return null;
				}

				public object ZzuCXrUSihrnLzfXOzrtdqcXmTD()
				{
					if (childCount == 0)
					{
						return HMLWlSECOiVOzGrIKGhNElmqFNf;
					}
					SerializedObject serializedObject = new SerializedObject(null, ObjectType.List);
					for (int i = 0; i < childCount; i++)
					{
						zfdExcQbYfGXxFgwlDUbOnevxri zfdExcQbYfGXxFgwlDUbOnevxri2 = uFvhbocttwSJFAfGbgBaeZJYbdbp[i];
						if (zfdExcQbYfGXxFgwlDUbOnevxri2 != null)
						{
							serializedObject.Add(zfdExcQbYfGXxFgwlDUbOnevxri2.MLmLjcwSbKBkEhcbqGJFmLCQUrjT, zfdExcQbYfGXxFgwlDUbOnevxri2.ZzuCXrUSihrnLzfXOzrtdqcXmTD());
						}
					}
					return serializedObject;
				}

				public override string ToString()
				{
					return oCdzzqtmttficMJJtYbgFwqkohN("", 0);
				}

				private string oCdzzqtmttficMJJtYbgFwqkohN(string P_0, int P_1)
				{
					string text = "";
					for (int i = 0; i < P_1; i++)
					{
						text += "    ";
					}
					string text2 = P_0;
					P_0 = text2 + text + "Name = " + MLmLjcwSbKBkEhcbqGJFmLCQUrjT + "\n";
					string text3 = P_0;
					P_0 = text3 + text + "Content = " + ((HMLWlSECOiVOzGrIKGhNElmqFNf == null) ? "NULL" : HMLWlSECOiVOzGrIKGhNElmqFNf.ToString()) + "\n";
					object obj = P_0;
					P_0 = string.Concat(obj, text, "Attribute Count = ", attributeCount, "\n");
					if (nwJxhFTRJmkXvkVzmYghMcvPqfV != null)
					{
						foreach (KeyValuePair<string, string> item in nwJxhFTRJmkXvkVzmYghMcvPqfV)
						{
							string text4 = P_0;
							P_0 = text4 + text + "Attribute " + item.Key + ": = " + item.Value + "\n";
						}
					}
					object obj2 = P_0;
					P_0 = string.Concat(obj2, text, "Child Count = ", childCount, "\n");
					if (uFvhbocttwSJFAfGbgBaeZJYbdbp != null)
					{
						string text5 = "";
						foreach (zfdExcQbYfGXxFgwlDUbOnevxri item2 in uFvhbocttwSJFAfGbgBaeZJYbdbp)
						{
							text5 += "\n";
							text5 = item2.oCdzzqtmttficMJJtYbgFwqkohN(text5, P_1 + 1);
						}
						P_0 += text5;
					}
					return P_0;
				}
			}

			private readonly zfdExcQbYfGXxFgwlDUbOnevxri DfSfAFYWQxTAlONEuriYYXsEmW;

			public zfdExcQbYfGXxFgwlDUbOnevxri root => DfSfAFYWQxTAlONEuriYYXsEmW;

			public bool isValid => DfSfAFYWQxTAlONEuriYYXsEmW != null;

			public ErLCouIyxIKZlPELbhIAagMFCDOf(string xml)
			{
				if (string.IsNullOrEmpty(xml))
				{
					throw new ArgumentNullException("xml");
				}
				try
				{
					using StringReader input = new StringReader(xml);
					XmlReader xmlReader = XmlReader.Create(input);
					if (xmlReader == null)
					{
						throw new ArgumentNullException("reader");
					}
					DfSfAFYWQxTAlONEuriYYXsEmW = new zfdExcQbYfGXxFgwlDUbOnevxri("Root", null);
					LGldnmIMMSwTOrkurbpprVvbINb(xmlReader);
				}
				catch
				{
					DfSfAFYWQxTAlONEuriYYXsEmW = null;
				}
			}

			private void LGldnmIMMSwTOrkurbpprVvbINb(XmlReader P_0)
			{
				zfdExcQbYfGXxFgwlDUbOnevxri zfdExcQbYfGXxFgwlDUbOnevxri2 = DfSfAFYWQxTAlONEuriYYXsEmW;
				int num = 0;
				while (P_0.Read())
				{
					XmlNodeType nodeType = P_0.NodeType;
					if (nodeType == XmlNodeType.Comment || nodeType == XmlNodeType.XmlDeclaration)
					{
						num++;
						continue;
					}
					bool flag = false;
					if (P_0.NodeType == XmlNodeType.Element)
					{
						if (P_0.IsStartElement())
						{
							_ = P_0.IsEmptyElement;
							zfdExcQbYfGXxFgwlDUbOnevxri2 = new zfdExcQbYfGXxFgwlDUbOnevxri(P_0.LocalName, zfdExcQbYfGXxFgwlDUbOnevxri2);
							for (int i = 0; i < P_0.AttributeCount; i++)
							{
								P_0.MoveToNextAttribute();
								zfdExcQbYfGXxFgwlDUbOnevxri2.iwUEWfDzCEkNAUDecnXxrDjOLif(P_0.Name, P_0.Value);
							}
							if (P_0.IsEmptyElement)
							{
								flag = true;
							}
						}
					}
					else if (P_0.NodeType == XmlNodeType.Text)
					{
						if (!P_0.IsEmptyElement && P_0.HasValue)
						{
							zfdExcQbYfGXxFgwlDUbOnevxri2.HMLWlSECOiVOzGrIKGhNElmqFNf = P_0.ReadContentAsString();
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						_ = P_0.NodeType;
						_ = 15;
					}
					if ((flag || P_0.NodeType == XmlNodeType.EndElement) && zfdExcQbYfGXxFgwlDUbOnevxri2 != null && zfdExcQbYfGXxFgwlDUbOnevxri2 != DfSfAFYWQxTAlONEuriYYXsEmW && P_0.Name == zfdExcQbYfGXxFgwlDUbOnevxri2.MLmLjcwSbKBkEhcbqGJFmLCQUrjT)
					{
						zfdExcQbYfGXxFgwlDUbOnevxri2 = zfdExcQbYfGXxFgwlDUbOnevxri2.IqqFMkivXajbnQieKffNsZWOHNR;
					}
					num++;
				}
			}

			public override string ToString()
			{
				if (DfSfAFYWQxTAlONEuriYYXsEmW == null || DfSfAFYWQxTAlONEuriYYXsEmW.childCount == 0)
				{
					return "Document is empty.";
				}
				return DfSfAFYWQxTAlONEuriYYXsEmW.ToString();
			}
		}

		private readonly IndexedDictionary<string, pBFnMUkqZurapwJfzasmHKaRedG> gXucvRhtqGcNqATsRvxdnsUJXuE;

		private XmlInfo eLYQJJHpjbBDlzjXseoFGjcmXEQ;

		private Type wZYPyxmKgRSHjYJwEjuLiELShEK;

		private ObjectType zFYscIEEWZhbEJbyZEbuutUDuOQ;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> aRhsUGFchKOGdQlvGBuxyIzMqJp = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> QcceECBWCowbJVMdAPhVIKTZCOuL = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		[CompilerGenerated]
		private static Func<FieldInfo, bool> lOQcCRGEDAZVfMHZnMEpswIpjBVD;

		[CompilerGenerated]
		private static Func<FieldInfo, string> LDLmDsvfHVpKxKAhJlObsDuRmDN;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> wNyWUmLMRqqfCWaWaDRQiHidubV;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> IofEnaXWxGryaGqpiazUeyamIko;

		private bool allowDuplicateKeys => zFYscIEEWZhbEJbyZEbuutUDuOQ == ObjectType.List;

		public ObjectType objectType
		{
			get
			{
				return zFYscIEEWZhbEJbyZEbuutUDuOQ;
			}
			set
			{
				if (value != zFYscIEEWZhbEJbyZEbuutUDuOQ)
				{
					zFYscIEEWZhbEJbyZEbuutUDuOQ = value;
					gXucvRhtqGcNqATsRvxdnsUJXuE.AllowDuplicateKeys = allowDuplicateKeys;
				}
			}
		}

		public Type type => wZYPyxmKgRSHjYJwEjuLiELShEK;

		public XmlInfo xmlInfo
		{
			get
			{
				return eLYQJJHpjbBDlzjXseoFGjcmXEQ;
			}
			set
			{
				eLYQJJHpjbBDlzjXseoFGjcmXEQ = value;
			}
		}

		public int count => gXucvRhtqGcNqATsRvxdnsUJXuE.Count;

		public Field this[int index]
		{
			get
			{
				pBFnMUkqZurapwJfzasmHKaRedG pBFnMUkqZurapwJfzasmHKaRedG2 = gXucvRhtqGcNqATsRvxdnsUJXuE[index];
				string keyAt = gXucvRhtqGcNqATsRvxdnsUJXuE.GetKeyAt(index);
				return new Field(keyAt, pBFnMUkqZurapwJfzasmHKaRedG2.HpxePuhaScltgSCBmgsrsCpjliL, pBFnMUkqZurapwJfzasmHKaRedG2.NKrRavQzBncjnBNomJbbjeXhgCD, pBFnMUkqZurapwJfzasmHKaRedG2.RmejrHhGmdrPzXkxpiABNmKtOnI);
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
			zFYscIEEWZhbEJbyZEbuutUDuOQ = ObjectType.List;
			gXucvRhtqGcNqATsRvxdnsUJXuE = new IndexedDictionary<string, pBFnMUkqZurapwJfzasmHKaRedG>(capacity, allowDuplicateKeys: true);
		}

		public SerializedObject(Type type, ObjectType objectType)
			: this(type, objectType, 0)
		{
		}

		public SerializedObject(Type type, ObjectType objectType, int capacity)
			: this(capacity)
		{
			wZYPyxmKgRSHjYJwEjuLiELShEK = type;
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
				gXucvRhtqGcNqATsRvxdnsUJXuE.Add(item.Key, new pBFnMUkqZurapwJfzasmHKaRedG((item.Value != null) ? item.Value.GetType() : null, item.Value, FieldOptions.None));
			}
		}

		public void Add<T>(string fieldName, T value, FieldOptions options = FieldOptions.None)
		{
			Add(typeof(T), fieldName, value, options);
		}

		public void Add(Type type, string fieldName, object value, FieldOptions options = FieldOptions.None)
		{
			if ((object)type != null && value != null && !object.ReferenceEquals(type, value.GetType()))
			{
				throw new Exception("Type does not match value type.");
			}
			if (string.IsNullOrEmpty(fieldName))
			{
				if (zFYscIEEWZhbEJbyZEbuutUDuOQ != ObjectType.List)
				{
					throw new ArgumentNullException("fieldName");
				}
				fieldName = "value";
			}
			if (allowDuplicateKeys)
			{
				gXucvRhtqGcNqATsRvxdnsUJXuE.Add(fieldName, new pBFnMUkqZurapwJfzasmHKaRedG(type, value, options));
			}
			else if (!gXucvRhtqGcNqATsRvxdnsUJXuE.ContainsKey(fieldName))
			{
				gXucvRhtqGcNqATsRvxdnsUJXuE.Add(fieldName, new pBFnMUkqZurapwJfzasmHKaRedG(type, value, options));
			}
			else
			{
				gXucvRhtqGcNqATsRvxdnsUJXuE.SetValue(fieldName, new pBFnMUkqZurapwJfzasmHKaRedG(type, value, options));
			}
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
			return gXucvRhtqGcNqATsRvxdnsUJXuE.Remove(fieldName);
		}

		public bool Contains(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return gXucvRhtqGcNqATsRvxdnsUJXuE.ContainsKey(fieldName);
		}

		public Type GetDataType(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			if (!gXucvRhtqGcNqATsRvxdnsUJXuE.TryGetValue(fieldName, out var value))
			{
				return null;
			}
			return value.NKrRavQzBncjnBNomJbbjeXhgCD;
		}

		public bool TryGetOriginalValue(string fieldName, out object value)
		{
			value = null;
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			if (!gXucvRhtqGcNqATsRvxdnsUJXuE.TryGetValue(fieldName, out var value2))
			{
				return false;
			}
			value = value2.HpxePuhaScltgSCBmgsrsCpjliL;
			return true;
		}

		public Field GetEntry(string fieldName)
		{
			KeyValuePair<string, pBFnMUkqZurapwJfzasmHKaRedG> entry = gXucvRhtqGcNqATsRvxdnsUJXuE.GetEntry(fieldName);
			return new Field(entry.Key, entry.Value.HpxePuhaScltgSCBmgsrsCpjliL, entry.Value.NKrRavQzBncjnBNomJbbjeXhgCD, entry.Value.RmejrHhGmdrPzXkxpiABNmKtOnI);
		}

		public object GetOriginalValue(string fieldName)
		{
			return gXucvRhtqGcNqATsRvxdnsUJXuE.GetEntry(fieldName).Value.HpxePuhaScltgSCBmgsrsCpjliL;
		}

		public object GetOriginalValue(int index)
		{
			return gXucvRhtqGcNqATsRvxdnsUJXuE[index].HpxePuhaScltgSCBmgsrsCpjliL;
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
			if (!gXucvRhtqGcNqATsRvxdnsUJXuE.TryGetValue(fieldName, out var value2))
			{
				value = default(T);
				return false;
			}
			return gOUwTUsTKjuhwcVxUIVukpBgNEE<T>(value2.HpxePuhaScltgSCBmgsrsCpjliL, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			if ((uint)index > (uint)gXucvRhtqGcNqATsRvxdnsUJXuE.Count)
			{
				value = default(T);
				return false;
			}
			return gOUwTUsTKjuhwcVxUIVukpBgNEE<T>(gXucvRhtqGcNqATsRvxdnsUJXuE.GetEntryAt(index).Value.HpxePuhaScltgSCBmgsrsCpjliL, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
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
			if ((uint)index > (uint)gXucvRhtqGcNqATsRvxdnsUJXuE.Count)
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
			if (eLYQJJHpjbBDlzjXseoFGjcmXEQ == null)
			{
				throw new Exception("XmlInfo is null. Cannot write Xml without XmlInfo.");
			}
			string empty = string.Empty;
			using StringWriter stringWriter = new StringWriter();
			using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
			{
				if (writeDocumentTag)
				{
					xmlWriter.WriteStartDocument();
				}
				BNIaqayCuHiXcuukdJHCTCzTfPT(xmlWriter);
				xmlWriter.Flush();
			}
			return stringWriter.ToString();
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
			stringBuilder.Append("type = ");
			stringBuilder.Append(((object)wZYPyxmKgRSHjYJwEjuLiELShEK != null) ? wZYPyxmKgRSHjYJwEjuLiELShEK.Name : "NULL\n");
			stringBuilder.Append("objectType = ");
			stringBuilder.Append(zFYscIEEWZhbEJbyZEbuutUDuOQ.ToString());
			stringBuilder.Append("\n");
			stringBuilder.Append("xmlInfo = ");
			stringBuilder.Append((eLYQJJHpjbBDlzjXseoFGjcmXEQ != null) ? eLYQJJHpjbBDlzjXseoFGjcmXEQ.ToString() : "NULL\n");
			stringBuilder.Append("\n");
			for (int i = 0; i < gXucvRhtqGcNqATsRvxdnsUJXuE.Count; i++)
			{
				string keyAt = gXucvRhtqGcNqATsRvxdnsUJXuE.GetKeyAt(i);
				stringBuilder.Append("key = ");
				stringBuilder.Append((keyAt != null) ? keyAt : "NULL");
				stringBuilder.Append(", value = ");
				stringBuilder.Append(gXucvRhtqGcNqATsRvxdnsUJXuE[i].ToString());
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}

		private void BNIaqayCuHiXcuukdJHCTCzTfPT(XmlWriter P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writer");
			}
			P_0.WriteStartElement(type.Name, "http://guavaman.com/rewired");
			bDedkqUqSSgVOftnwmJbUVYNlxP(P_0);
			P_0.WriteEndElement();
		}

		private void bDedkqUqSSgVOftnwmJbUVYNlxP(XmlWriter P_0)
		{
			int num = ((xmlInfo != null) ? xmlInfo.attributes.Count : 0);
			for (int i = 0; i < num; i++)
			{
				XmlInfo.jEsOHjtWZugHpJbcerYroDoLmll jEsOHjtWZugHpJbcerYroDoLmll = xmlInfo.attributes[i];
				if (jEsOHjtWZugHpJbcerYroDoLmll is XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW)
				{
					XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW oyVEtLlgkNfHXzDuiVPrVGAKdJW = jEsOHjtWZugHpJbcerYroDoLmll as XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW;
					if (!string.IsNullOrEmpty(oyVEtLlgkNfHXzDuiVPrVGAKdJW.LwDBNnNFqBxCeHOdFxAkCpxXHQR))
					{
						P_0.WriteAttributeString(oyVEtLlgkNfHXzDuiVPrVGAKdJW.LwDBNnNFqBxCeHOdFxAkCpxXHQR, oyVEtLlgkNfHXzDuiVPrVGAKdJW.zYwYmGHTCLOJxCByvWzioBevSzj, oyVEtLlgkNfHXzDuiVPrVGAKdJW.oseqaDGmYbdubOOmISVVBGRFzNc, oyVEtLlgkNfHXzDuiVPrVGAKdJW.HpxePuhaScltgSCBmgsrsCpjliL);
					}
					else if (!string.IsNullOrEmpty(oyVEtLlgkNfHXzDuiVPrVGAKdJW.oseqaDGmYbdubOOmISVVBGRFzNc))
					{
						P_0.WriteAttributeString(oyVEtLlgkNfHXzDuiVPrVGAKdJW.zYwYmGHTCLOJxCByvWzioBevSzj, oyVEtLlgkNfHXzDuiVPrVGAKdJW.oseqaDGmYbdubOOmISVVBGRFzNc, oyVEtLlgkNfHXzDuiVPrVGAKdJW.HpxePuhaScltgSCBmgsrsCpjliL);
					}
					else
					{
						P_0.WriteAttributeString(oyVEtLlgkNfHXzDuiVPrVGAKdJW.zYwYmGHTCLOJxCByvWzioBevSzj, oyVEtLlgkNfHXzDuiVPrVGAKdJW.HpxePuhaScltgSCBmgsrsCpjliL);
					}
					continue;
				}
				throw new NotImplementedException();
			}
			for (int j = 0; j < count; j++)
			{
				pBFnMUkqZurapwJfzasmHKaRedG pBFnMUkqZurapwJfzasmHKaRedG2 = gXucvRhtqGcNqATsRvxdnsUJXuE[j];
				string text = gXucvRhtqGcNqATsRvxdnsUJXuE.GetKeyAt(j);
				if ((pBFnMUkqZurapwJfzasmHKaRedG2.RmejrHhGmdrPzXkxpiABNmKtOnI & FieldOptions.ExculdeFromXml) == 0)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = (((object)pBFnMUkqZurapwJfzasmHKaRedG2.NKrRavQzBncjnBNomJbbjeXhgCD != null) ? pBFnMUkqZurapwJfzasmHKaRedG2.GetType().Name : ((pBFnMUkqZurapwJfzasmHKaRedG2.HpxePuhaScltgSCBmgsrsCpjliL == null) ? "value" : pBFnMUkqZurapwJfzasmHKaRedG2.HpxePuhaScltgSCBmgsrsCpjliL.GetType().Name));
					}
					SerializationTools.WriteXmlElement(P_0, text, pBFnMUkqZurapwJfzasmHKaRedG2.HpxePuhaScltgSCBmgsrsCpjliL);
				}
			}
		}

		private void BqjkWgrXdeQEsHRojKJahljqbxEg(XmlWriter P_0)
		{
			BNIaqayCuHiXcuukdJHCTCzTfPT(P_0);
		}

		void IExportToXml.WriteXml(XmlWriter P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BqjkWgrXdeQEsHRojKJahljqbxEg
			this.BqjkWgrXdeQEsHRojKJahljqbxEg(P_0);
		}

		private void RDtCeVswloQxbkHiBLBSBMQbSxZ(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("stringBuilder");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("appendValueDelegate");
			}
			int num = gXucvRhtqGcNqATsRvxdnsUJXuE.Count;
			if (gXucvRhtqGcNqATsRvxdnsUJXuE.ContainsDuplicateKeys)
			{
				P_0.Append('[');
				bool flag = true;
				for (int i = 0; i < num; i++)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						P_0.Append(',');
					}
					P_1(P_0, gXucvRhtqGcNqATsRvxdnsUJXuE[i].HpxePuhaScltgSCBmgsrsCpjliL);
				}
				P_0.Append(']');
				return;
			}
			P_0.Append('{');
			bool flag2 = true;
			for (int j = 0; j < num; j++)
			{
				if (flag2)
				{
					flag2 = false;
				}
				else
				{
					P_0.Append(',');
				}
				pBFnMUkqZurapwJfzasmHKaRedG pBFnMUkqZurapwJfzasmHKaRedG2 = gXucvRhtqGcNqATsRvxdnsUJXuE[j];
				string value = gXucvRhtqGcNqATsRvxdnsUJXuE.GetKeyAt(j);
				if (string.IsNullOrEmpty(value))
				{
					value = j.ToString();
				}
				P_0.Append('"');
				P_0.Append(value);
				P_0.Append("\":");
				P_1(P_0, pBFnMUkqZurapwJfzasmHKaRedG2.HpxePuhaScltgSCBmgsrsCpjliL);
			}
			P_0.Append('}');
		}

		void IExportToJson.WriteJson(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RDtCeVswloQxbkHiBLBSBMQbSxZ
			this.RDtCeVswloQxbkHiBLBSBMQbSxZ(P_0, P_1);
		}

		private void tGEzSIMKskfNubTqZlpFobVEzkq(object P_0)
		{
			Add(null, P_0);
		}

		void IAddValue<object>.Add(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in tGEzSIMKskfNubTqZlpFobVEzkq
			this.tGEzSIMKskfNubTqZlpFobVEzkq(P_0);
		}

		private void JNlNOQvVYroTHFPmPOGtlYOCNOg(string P_0, object P_1)
		{
			Add(P_0, P_1);
		}

		void IAddKeyValue<string, object>.Add(string P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JNlNOQvVYroTHFPmPOGtlYOCNOg
			this.JNlNOQvVYroTHFPmPOGtlYOCNOg(P_0, P_1);
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return new Enumerator(gXucvRhtqGcNqATsRvxdnsUJXuE);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(gXucvRhtqGcNqATsRvxdnsUJXuE);
		}

		private static bool gOUwTUsTKjuhwcVxUIVukpBgNEE<T>(object P_0, out T P_1, NumberStyles P_2 = NumberStyles.Any, CultureInfo P_3 = null)
		{
			if (!gOUwTUsTKjuhwcVxUIVukpBgNEE(typeof(T), P_0, out var obj, P_2, P_3))
			{
				P_1 = default(T);
				return false;
			}
			P_1 = (T)obj;
			return true;
		}

		private static bool gOUwTUsTKjuhwcVxUIVukpBgNEE(Type P_0, object P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			P_2 = null;
			if (P_1 == null)
			{
				if (object.ReferenceEquals(P_0, typeof(string)))
				{
					P_2 = string.Empty;
					return true;
				}
				if (!ReflectionTools.IsValueType(P_0))
				{
					return true;
				}
				if ((object)Nullable.GetUnderlyingType(P_0) != null)
				{
					return true;
				}
				return false;
			}
			Type type = P_1.GetType();
			if (object.ReferenceEquals(P_0, type))
			{
				P_2 = P_1;
				return true;
			}
			try
			{
				if (object.ReferenceEquals(P_0, typeof(string)))
				{
					P_2 = P_1.ToString();
					return true;
				}
				if (object.ReferenceEquals(P_0, typeof(int)))
				{
					if (object.ReferenceEquals(type, typeof(float)))
					{
						P_2 = (int)(float)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(uint)))
					{
						P_2 = (int)(uint)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(long)))
					{
						P_2 = (int)(long)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(ulong)))
					{
						P_2 = (int)(ulong)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(double)))
					{
						P_2 = (int)(double)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(decimal)))
					{
						P_2 = (int)(decimal)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(short)))
					{
						P_2 = (int)(short)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(ushort)))
					{
						P_2 = (int)(ushort)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(byte)))
					{
						P_2 = (int)(byte)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(sbyte)))
					{
						P_2 = (int)(sbyte)P_1;
					}
					else
					{
						if (!object.ReferenceEquals(type, typeof(string)))
						{
							return false;
						}
						int result;
						if (P_4 != null)
						{
							if (!int.TryParse(P_1.ToString(), P_3, P_4, out result))
							{
								return false;
							}
						}
						else if (!int.TryParse(P_1.ToString(), out result))
						{
							return false;
						}
						P_2 = result;
					}
					return true;
				}
				if (object.ReferenceEquals(P_0, typeof(float)))
				{
					if (object.ReferenceEquals(type, typeof(int)))
					{
						P_2 = (float)(int)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(uint)))
					{
						P_2 = (float)(uint)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(long)))
					{
						P_2 = (float)(long)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(ulong)))
					{
						P_2 = (float)(ulong)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(double)))
					{
						P_2 = (float)(double)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(decimal)))
					{
						P_2 = (float)(decimal)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(short)))
					{
						P_2 = (float)(short)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(ushort)))
					{
						P_2 = (float)(int)(ushort)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(byte)))
					{
						P_2 = (float)(int)(byte)P_1;
					}
					else if (object.ReferenceEquals(type, typeof(sbyte)))
					{
						P_2 = (float)(sbyte)P_1;
					}
					else
					{
						if (!object.ReferenceEquals(type, typeof(string)))
						{
							return false;
						}
						float result2;
						if (P_4 != null)
						{
							if (!float.TryParse(P_1.ToString(), P_3, P_4, out result2))
							{
								return false;
							}
						}
						else if (!float.TryParse(P_1.ToString(), out result2))
						{
							return false;
						}
						P_2 = result2;
					}
					return true;
				}
				if (ReflectionTools.IsEnum(P_0))
				{
					Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(P_0);
					if (gOUwTUsTKjuhwcVxUIVukpBgNEE(underlyingEnumType, P_1, out var value, P_3, P_4))
					{
						P_2 = Enum.ToObject(P_0, value);
						return true;
					}
					if (object.ReferenceEquals(type, typeof(string)))
					{
						try
						{
							P_2 = Enum.Parse(P_0, (string)P_1, ignoreCase: true);
							return true;
						}
						catch
						{
							P_2 = null;
							return false;
						}
					}
				}
				else
				{
					if (object.ReferenceEquals(P_0, typeof(uint)))
					{
						if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (uint)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (uint)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (uint)(long)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (uint)(ulong)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (uint)(double)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (uint)(decimal)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (uint)(short)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (uint)(ushort)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (uint)(byte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (uint)(sbyte)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							uint result3;
							if (P_4 != null)
							{
								if (!uint.TryParse(P_1.ToString(), P_3, P_4, out result3))
								{
									return false;
								}
							}
							else if (!uint.TryParse(P_1.ToString(), out result3))
							{
								return false;
							}
							P_2 = result3;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(double)))
					{
						if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (double)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (double)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (double)(uint)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (double)(long)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (double)(ulong)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (double)(short)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (double)(int)(ushort)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (double)(int)(byte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (double)(sbyte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (double)(decimal)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							double result4;
							if (P_4 != null)
							{
								if (!double.TryParse(P_1.ToString(), P_3, P_4, out result4))
								{
									return false;
								}
							}
							else if (!double.TryParse(P_1.ToString(), out result4))
							{
								return false;
							}
							P_2 = result4;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(bool)))
					{
						if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (int)P_1 > 0;
						}
						else if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (float)P_1 > 0f;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (uint)P_1 != 0;
						}
						else if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (long)P_1 > 0;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (ulong)P_1 != 0;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (double)P_1 > 0.0;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (decimal)P_1 > 0m;
						}
						else if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (short)P_1 > 0;
						}
						else if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (ushort)P_1 > 0;
						}
						else if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (byte)P_1 > 0;
						}
						else if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (sbyte)P_1 > 0;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							if (string.Equals((string)P_1, "true", StringComparison.OrdinalIgnoreCase))
							{
								P_2 = true;
							}
							else
							{
								if (!string.Equals((string)P_1, "false", StringComparison.OrdinalIgnoreCase))
								{
									return false;
								}
								P_2 = false;
							}
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(long)))
					{
						if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (long)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (long)(ulong)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (long)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (long)(uint)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (long)(double)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (long)(decimal)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (long)(short)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (long)(ushort)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (long)(byte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (long)(sbyte)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							long result5;
							if (P_4 != null)
							{
								if (!long.TryParse(P_1.ToString(), P_3, P_4, out result5))
								{
									return false;
								}
							}
							else if (!long.TryParse(P_1.ToString(), out result5))
							{
								return false;
							}
							P_2 = result5;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(ulong)))
					{
						if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (ulong)(long)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (ulong)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (ulong)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (ulong)(uint)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (ulong)(double)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (ulong)(decimal)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (ulong)(short)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (ulong)(ushort)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (ulong)(byte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (ulong)(sbyte)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							ulong result6;
							if (P_4 != null)
							{
								if (!ulong.TryParse(P_1.ToString(), P_3, P_4, out result6))
								{
									return false;
								}
							}
							else if (!ulong.TryParse(P_1.ToString(), out result6))
							{
								return false;
							}
							P_2 = result6;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(short)))
					{
						if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (short)(ushort)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (short)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (short)(uint)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (short)(long)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (short)(ulong)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (short)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (short)(double)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (short)(decimal)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (short)(byte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (short)(sbyte)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							short result7;
							if (P_4 != null)
							{
								if (!short.TryParse(P_1.ToString(), P_3, P_4, out result7))
								{
									return false;
								}
							}
							else if (!short.TryParse(P_1.ToString(), out result7))
							{
								return false;
							}
							P_2 = result7;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(ushort)))
					{
						if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (ushort)(short)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (ushort)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (ushort)(uint)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (ushort)(long)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (ushort)(ulong)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (ushort)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (ushort)(double)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (ushort)(decimal)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (ushort)(byte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (ushort)(sbyte)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							ushort result8;
							if (P_4 != null)
							{
								if (!ushort.TryParse(P_1.ToString(), P_3, P_4, out result8))
								{
									return false;
								}
							}
							else if (!ushort.TryParse(P_1.ToString(), out result8))
							{
								return false;
							}
							P_2 = result8;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(byte)))
					{
						if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (byte)(sbyte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (byte)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (byte)(uint)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (byte)(long)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (byte)(ulong)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (byte)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (byte)(double)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (byte)(decimal)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (byte)(short)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (byte)(ushort)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							byte result9;
							if (P_4 != null)
							{
								if (!byte.TryParse(P_1.ToString(), P_3, P_4, out result9))
								{
									return false;
								}
							}
							else if (!byte.TryParse(P_1.ToString(), out result9))
							{
								return false;
							}
							P_2 = result9;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(sbyte)))
					{
						if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (sbyte)(byte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (sbyte)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (sbyte)(uint)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (sbyte)(long)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (sbyte)(ulong)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (sbyte)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (sbyte)(double)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(decimal)))
						{
							P_2 = (sbyte)(decimal)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (sbyte)(short)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (sbyte)(ushort)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							sbyte result10;
							if (P_4 != null)
							{
								if (!sbyte.TryParse(P_1.ToString(), P_3, P_4, out result10))
								{
									return false;
								}
							}
							else if (!sbyte.TryParse(P_1.ToString(), out result10))
							{
								return false;
							}
							P_2 = result10;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(decimal)))
					{
						if (object.ReferenceEquals(type, typeof(float)))
						{
							P_2 = (decimal)(float)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(double)))
						{
							P_2 = (decimal)(double)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(int)))
						{
							P_2 = (decimal)(int)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(long)))
						{
							P_2 = (decimal)(long)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(uint)))
						{
							P_2 = (decimal)(uint)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ulong)))
						{
							P_2 = (decimal)(ulong)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(short)))
						{
							P_2 = (decimal)(short)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(ushort)))
						{
							P_2 = (decimal)(ushort)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(byte)))
						{
							P_2 = (decimal)(byte)P_1;
						}
						else if (object.ReferenceEquals(type, typeof(sbyte)))
						{
							P_2 = (decimal)(sbyte)P_1;
						}
						else
						{
							if (!object.ReferenceEquals(type, typeof(string)))
							{
								return false;
							}
							decimal result11;
							if (P_4 != null)
							{
								if (!decimal.TryParse(P_1.ToString(), P_3, P_4, out result11))
								{
									return false;
								}
							}
							else if (!decimal.TryParse(P_1.ToString(), out result11))
							{
								return false;
							}
							P_2 = result11;
						}
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(char)))
					{
						P_2 = P_1.ToString();
						return true;
					}
					if (object.ReferenceEquals(P_0, typeof(Guid)))
					{
						if (object.ReferenceEquals(type, typeof(string)))
						{
							P_2 = StringTools.ToGuid((string)P_1);
							return true;
						}
						return false;
					}
					if (ReflectionTools.IsArray(P_0))
					{
						Type elementType = P_0.GetElementType();
						if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
						{
							if (!(P_1 is SerializedObject serializedObject))
							{
								return false;
							}
							Array array = Array.CreateInstance(elementType, serializedObject.count);
							for (int i = 0; i < serializedObject.count; i++)
							{
								if (gOUwTUsTKjuhwcVxUIVukpBgNEE(elementType, serializedObject[i].value, out var value2, P_3, P_4))
								{
									array.SetValue(value2, i);
								}
							}
							P_2 = array;
							return true;
						}
						if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
						{
							if (!(P_1 is IReadOnlyList readOnlyList))
							{
								return false;
							}
							Array array2 = Array.CreateInstance(elementType, readOnlyList.Count);
							for (int j = 0; j < readOnlyList.Count; j++)
							{
								if (gOUwTUsTKjuhwcVxUIVukpBgNEE(elementType, readOnlyList[j], out var value3, P_3, P_4))
								{
									array2.SetValue(value3, j);
								}
							}
							P_2 = array2;
							return true;
						}
						if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
						{
							if (!(P_1 is IList list))
							{
								return false;
							}
							Array array3 = Array.CreateInstance(elementType, list.Count);
							for (int k = 0; k < list.Count; k++)
							{
								if (gOUwTUsTKjuhwcVxUIVukpBgNEE(elementType, list[k], out var value4, P_3, P_4))
								{
									array3.SetValue(value4, k);
								}
							}
							P_2 = array3;
							return true;
						}
						if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
						{
							Array array4 = P_1 as Array;
							Array array5 = Array.CreateInstance(elementType, array4.Length);
							for (int l = 0; l < array4.Length; l++)
							{
								if (gOUwTUsTKjuhwcVxUIVukpBgNEE(elementType, array4.GetValue(l), out var value5, P_3, P_4))
								{
									array5.SetValue(value5, l);
								}
							}
							P_2 = array5;
							return true;
						}
						if (ReflectionTools.DoesTypeImplement(type, typeof(IDictionary)))
						{
							Type type2 = ReflectionTools.GetGenericArguments(P_0)[1];
							IDictionary dictionary = P_1 as IDictionary;
							Array array6 = Array.CreateInstance(elementType, dictionary.Count);
							int num = 0;
							foreach (object value15 in dictionary.Values)
							{
								if (gOUwTUsTKjuhwcVxUIVukpBgNEE(type2, value15, out var value6, P_3, P_4))
								{
									array6.SetValue(value6, num);
									num++;
								}
							}
							P_2 = array6;
							return true;
						}
						if (ReflectionTools.DoesTypeImplement(type, typeof(ICollection)))
						{
							ICollection collection = P_1 as ICollection;
							Array array7 = Array.CreateInstance(elementType, collection.Count);
							int num2 = 0;
							foreach (object item in collection)
							{
								if (gOUwTUsTKjuhwcVxUIVukpBgNEE(elementType, item, out var value7, P_3, P_4))
								{
									array7.SetValue(value7, num2);
									num2++;
								}
							}
							P_2 = array7;
							return true;
						}
						if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
						{
							IEnumerable enumerable = P_1 as IEnumerable;
							int num3 = 0;
							foreach (object item2 in enumerable)
							{
								_ = item2;
								num3++;
							}
							Array array8 = Array.CreateInstance(elementType, num3);
							int num4 = 0;
							foreach (object item3 in enumerable)
							{
								if (gOUwTUsTKjuhwcVxUIVukpBgNEE(elementType, item3, out var value8, P_3, P_4))
								{
									array8.SetValue(value8, num4);
									num4++;
								}
							}
							P_2 = array8;
							return true;
						}
						return false;
					}
					if (ReflectionTools.IsGenericType(P_0))
					{
						Type genericTypeDefinition = P_0.GetGenericTypeDefinition();
						if (ReflectionTools.DoesTypeImplement(P_0, typeof(IList)))
						{
							Type type3 = ReflectionTools.GetGenericArguments(P_0)[0];
							if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
							{
								SerializedObject serializedObject2 = P_1 as SerializedObject;
								IList list2 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type3));
								for (int m = 0; m < serializedObject2.count; m++)
								{
									if (gOUwTUsTKjuhwcVxUIVukpBgNEE(type3, serializedObject2[m].value, out var value9, P_3, P_4))
									{
										list2.Add(value9);
									}
								}
								P_2 = list2;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(IReadOnlyList)))
							{
								IReadOnlyList readOnlyList2 = P_1 as IReadOnlyList;
								IList list3 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type3));
								for (int n = 0; n < readOnlyList2.Count; n++)
								{
									if (gOUwTUsTKjuhwcVxUIVukpBgNEE(type3, readOnlyList2[n], out var value10, P_3, P_4))
									{
										list3.Add(value10);
									}
								}
								P_2 = list3;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(IList)))
							{
								IList list4 = P_1 as IList;
								IList list5 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type3));
								for (int num5 = 0; num5 < list4.Count; num5++)
								{
									if (gOUwTUsTKjuhwcVxUIVukpBgNEE(type3, list4[num5], out var value11, P_3, P_4))
									{
										list5.Add(value11);
									}
								}
								P_2 = list5;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(Array)))
							{
								Array array9 = P_1 as Array;
								IList list6 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type3));
								for (int num6 = 0; num6 < array9.Length; num6++)
								{
									if (gOUwTUsTKjuhwcVxUIVukpBgNEE(type3, array9.GetValue(num6), out var value12, P_3, P_4))
									{
										list6.Add(value12);
									}
								}
								P_2 = list6;
								return true;
							}
							if (ReflectionTools.DoesTypeImplement(type, typeof(IEnumerable)))
							{
								IEnumerable enumerable2 = P_1 as IEnumerable;
								IList list7 = (IList)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type3));
								foreach (object item4 in enumerable2)
								{
									if (gOUwTUsTKjuhwcVxUIVukpBgNEE(type3, item4, out var value13, P_3, P_4))
									{
										list7.Add(value13);
									}
								}
								P_2 = list7;
								return true;
							}
						}
						else if (ReflectionTools.DoesTypeImplement(genericTypeDefinition, typeof(IDictionary)))
						{
							Type[] genericArguments = ReflectionTools.GetGenericArguments(P_0);
							Type type4 = genericArguments[0];
							Type type5 = genericArguments[1];
							if (!(P_1 is IDictionary dictionary2))
							{
								return false;
							}
							IDictionary dictionary3 = (IDictionary)Factory.CreateInstance(genericTypeDefinition.MakeGenericType(type4, type5));
							foreach (object key2 in dictionary2.Keys)
							{
								if (gOUwTUsTKjuhwcVxUIVukpBgNEE(type4, key2, out var key, P_3, P_4) && gOUwTUsTKjuhwcVxUIVukpBgNEE(type5, dictionary2[key2], out var value14, P_3, P_4))
								{
									dictionary3.Add(key, value14);
								}
							}
							P_2 = dictionary3;
							return true;
						}
					}
				}
				if (object.ReferenceEquals(P_0, typeof(object)))
				{
					P_2 = P_1;
					return true;
				}
				if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
				{
					if (!ZPkfUPkeobJrerlcFjVAlKWLrMO(P_0, P_1 as SerializedObject, out P_1))
					{
						return false;
					}
					P_2 = P_1;
					return true;
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			return false;
		}

		private static bool ZPkfUPkeobJrerlcFjVAlKWLrMO(Type P_0, SerializedObject P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			if (P_1 == null || (object)P_0 == null)
			{
				P_2 = null;
				return false;
			}
			P_2 = Factory.CreateInstance(P_0);
			if (!aRhsUGFchKOGdQlvGBuxyIzMqJp.TryGetValue(P_0, out var value))
			{
				value = (from fieldInfo in ReflectionTools.GetFields(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
					where (fieldInfo.IsPublic || fieldInfo.IsDefined(typeof(SerializeAttribute), inherit: true) || fieldInfo.IsDefined(typeof(SerializeField), inherit: true)) && !fieldInfo.IsDefined(typeof(NonSerializedAttribute), inherit: true) && !fieldInfo.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
					select fieldInfo).ToDictionary((FieldInfo fieldInfo) =>
				{
					string name2;
					return (fieldInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(fieldInfo.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name2 : fieldInfo.Name;
				});
				aRhsUGFchKOGdQlvGBuxyIzMqJp.Add(P_0, value);
			}
			if (!QcceECBWCowbJVMdAPhVIKTZCOuL.TryGetValue(P_0, out var value2))
			{
				value2 = (from propertyInfo in ReflectionTools.GetProperties(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
					where propertyInfo.CanWrite && propertyInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !propertyInfo.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
					select propertyInfo).ToDictionary((PropertyInfo propertyInfo) =>
				{
					string name2;
					return (propertyInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(propertyInfo.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name2 : propertyInfo.Name;
				});
				QcceECBWCowbJVMdAPhVIKTZCOuL.Add(P_0, value2);
			}
			foreach (Field item in (IEnumerable<Field>)P_1)
			{
				string name = item.name;
				object value3 = item.value;
				object value5;
				PropertyInfo value6;
				if (value.TryGetValue(name, out var value4))
				{
					if (gOUwTUsTKjuhwcVxUIVukpBgNEE(value4.FieldType, value3, out value5, P_3, P_4))
					{
						value4.SetValue(P_2, value5);
					}
				}
				else if (value2.TryGetValue(name, out value6) && value6.CanWrite && gOUwTUsTKjuhwcVxUIVukpBgNEE(value6.PropertyType, value3, out value5, P_3, P_4))
				{
					value6.SetValue(P_2, value5, null);
				}
			}
			if (P_2 is ISerializationCallbackReceiver serializationCallbackReceiver)
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
		}

		public static SerializedObject FromJson(Type type, string jsonString)
		{
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				throw new ArgumentNullException("jsonString");
			}
			SerializedObject serializedObject = JsonParser.FromJson<SerializedObject>(jsonString, typeof(SerializedObject));
			if (serializedObject == null || serializedObject.count == 0)
			{
				throw new Exception("No data found in Json string.");
			}
			return serializedObject;
		}

		public static SerializedObject FromXml(Type type, string xmlString)
		{
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				throw new ArgumentNullException("xmlString");
			}
			ErLCouIyxIKZlPELbhIAagMFCDOf erLCouIyxIKZlPELbhIAagMFCDOf = new ErLCouIyxIKZlPELbhIAagMFCDOf(xmlString);
			if (!erLCouIyxIKZlPELbhIAagMFCDOf.isValid)
			{
				throw new Exception("Failed to parse XML string.");
			}
			if (erLCouIyxIKZlPELbhIAagMFCDOf.root.childCount == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			ErLCouIyxIKZlPELbhIAagMFCDOf.zfdExcQbYfGXxFgwlDUbOnevxri zfdExcQbYfGXxFgwlDUbOnevxri = erLCouIyxIKZlPELbhIAagMFCDOf.root.bltzZVKjzjBuihntKgHQwAwYrGv(type.Name);
			if (zfdExcQbYfGXxFgwlDUbOnevxri == null)
			{
				throw new Exception("Main element not found in XML string.");
			}
			if (!(zfdExcQbYfGXxFgwlDUbOnevxri.ZzuCXrUSihrnLzfXOzrtdqcXmTD() is SerializedObject serializedObject) || serializedObject.count == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			return serializedObject;
		}

		[CompilerGenerated]
		private static bool hrSfsecuVmgMyYndtLLNpoHQaNj(FieldInfo P_0)
		{
			if ((P_0.IsPublic || P_0.IsDefined(typeof(SerializeAttribute), inherit: true) || P_0.IsDefined(typeof(SerializeField), inherit: true)) && !P_0.IsDefined(typeof(NonSerializedAttribute), inherit: true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string UEMIPySgzZLLmJBInHcLiYGTAbID(FieldInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}

		[CompilerGenerated]
		private static bool jwdlEabavThlxwLTsUMIbnVrdtqc(PropertyInfo P_0)
		{
			if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), inherit: true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string oQQaRFZxfXIgpqMfaJHDJWjhqVOM(PropertyInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}
	}
}
