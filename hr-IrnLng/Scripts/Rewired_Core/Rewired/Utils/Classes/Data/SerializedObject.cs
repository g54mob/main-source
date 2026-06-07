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

		private struct RodYdwBjqjcHlAbPcnsvFRDpWns
		{
			public Type bAPyGAfeWoGVtSjhtFRwzpyXFad;

			public object lvXCTCWOhrCtuFDbbEqyqyUVPhp;

			public FieldOptions dCEaYrMIDmGupaCRkNUGTLpPJvkK;

			public RodYdwBjqjcHlAbPcnsvFRDpWns(Type type, object value, FieldOptions options)
			{
				bAPyGAfeWoGVtSjhtFRwzpyXFad = type;
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = value;
				dCEaYrMIDmGupaCRkNUGTLpPJvkK = options;
			}

			public override string ToString()
			{
				string text = "";
				text = text + "type = " + (((object)bAPyGAfeWoGVtSjhtFRwzpyXFad != null) ? bAPyGAfeWoGVtSjhtFRwzpyXFad.Name : "NULL") + "\n";
				text = text + "value = " + ((lvXCTCWOhrCtuFDbbEqyqyUVPhp != null) ? lvXCTCWOhrCtuFDbbEqyqyUVPhp.ToString() : "NULL") + "\n";
				object obj = text;
				return string.Concat(obj, "options = ", dCEaYrMIDmGupaCRkNUGTLpPJvkK, "\n");
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
			public abstract class DlYeiFaSwjdirAYOnEUmEePrUvTA
			{
			}

			public class yOvafjSNTWBQXamMnEDaXllsdXm : DlYeiFaSwjdirAYOnEUmEePrUvTA
			{
				public string tpjeoHgHRUvvsMOVGUmfENOfWgb;

				public string NSIraOohUuxbwNWwnOfcoaPLKLA;

				public string KyKFPbDbzyvJvQZYVoBMpXenzVYN;

				public string lvXCTCWOhrCtuFDbbEqyqyUVPhp;

				public override string ToString()
				{
					string text = "";
					text = text + "prefix = " + tpjeoHgHRUvvsMOVGUmfENOfWgb + "\n";
					text = text + "localName = " + NSIraOohUuxbwNWwnOfcoaPLKLA + "\n";
					text = text + "ns = " + KyKFPbDbzyvJvQZYVoBMpXenzVYN + "\n";
					return text + "value = " + lvXCTCWOhrCtuFDbbEqyqyUVPhp + "\n";
				}
			}

			private List<DlYeiFaSwjdirAYOnEUmEePrUvTA> gZgDjfDTytlUUWpvvgojECGagtbk;

			public List<DlYeiFaSwjdirAYOnEUmEePrUvTA> attributes => gZgDjfDTytlUUWpvvgojECGagtbk ?? (gZgDjfDTytlUUWpvvgojECGagtbk = new List<DlYeiFaSwjdirAYOnEUmEePrUvTA>());

			public override string ToString()
			{
				string text = "Attributes:\n";
				if (gZgDjfDTytlUUWpvvgojECGagtbk != null)
				{
					for (int i = 0; i < gZgDjfDTytlUUWpvvgojECGagtbk.Count; i++)
					{
						text = text + gZgDjfDTytlUUWpvvgojECGagtbk[i].ToString() + "\n";
					}
				}
				return text;
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IDisposable, IEnumerator, IEnumerator<Field>
		{
			private IndexedDictionary<string, RodYdwBjqjcHlAbPcnsvFRDpWns> lzZBwAKNPsUaSIywjNiGInbihBW;

			private Field TrWUdtjebjTxiTudwuGvXSlDJgg;

			private IEnumerator<KeyValuePair<string, RodYdwBjqjcHlAbPcnsvFRDpWns>> gWqpynMzbqKHecqxjMhhRmpEiDm;

			public Field Current => TrWUdtjebjTxiTudwuGvXSlDJgg;

			object IEnumerator.Current => TrWUdtjebjTxiTudwuGvXSlDJgg;

			internal Enumerator(object dictionary)
			{
				lzZBwAKNPsUaSIywjNiGInbihBW = (IndexedDictionary<string, RodYdwBjqjcHlAbPcnsvFRDpWns>)dictionary;
				TrWUdtjebjTxiTudwuGvXSlDJgg = default(Field);
				gWqpynMzbqKHecqxjMhhRmpEiDm = lzZBwAKNPsUaSIywjNiGInbihBW.GetEnumerator();
			}

			public bool MoveNext()
			{
				if (!gWqpynMzbqKHecqxjMhhRmpEiDm.MoveNext())
				{
					return false;
				}
				KeyValuePair<string, RodYdwBjqjcHlAbPcnsvFRDpWns> current = gWqpynMzbqKHecqxjMhhRmpEiDm.Current;
				TrWUdtjebjTxiTudwuGvXSlDJgg = new Field(current.Key, current.Value.lvXCTCWOhrCtuFDbbEqyqyUVPhp, current.Value.bAPyGAfeWoGVtSjhtFRwzpyXFad, current.Value.dCEaYrMIDmGupaCRkNUGTLpPJvkK);
				return true;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				TrWUdtjebjTxiTudwuGvXSlDJgg = default(Field);
				gWqpynMzbqKHecqxjMhhRmpEiDm = lzZBwAKNPsUaSIywjNiGInbihBW.GetEnumerator();
			}
		}

		private class abjoFKTACLegvAMdmRALGmbnQVkL
		{
			public class eAkzflHaPbtRGzfaAzYjQvWYEvG
			{
				public readonly string qROaKKGTWVzDYhhRdQZEfZxsihTO;

				public readonly eAkzflHaPbtRGzfaAzYjQvWYEvG ugKyZyJTGtYLrHpCFnUKcqkaRKt;

				public string vgdHGalJrxixvHHoLihCGFDKjBJB;

				public Dictionary<string, string> PIrODvkBwzDJjvCzrIFoIGPrHcv;

				public List<eAkzflHaPbtRGzfaAzYjQvWYEvG> YLJxUWDNInjyLDXmqDTdUFksGnHu;

				public int childCount
				{
					get
					{
						if (YLJxUWDNInjyLDXmqDTdUFksGnHu == null)
						{
							return 0;
						}
						return YLJxUWDNInjyLDXmqDTdUFksGnHu.Count;
					}
				}

				public int attributeCount
				{
					get
					{
						if (PIrODvkBwzDJjvCzrIFoIGPrHcv == null)
						{
							return 0;
						}
						return PIrODvkBwzDJjvCzrIFoIGPrHcv.Count;
					}
				}

				public eAkzflHaPbtRGzfaAzYjQvWYEvG(string name, eAkzflHaPbtRGzfaAzYjQvWYEvG parent)
				{
					qROaKKGTWVzDYhhRdQZEfZxsihTO = name;
					ugKyZyJTGtYLrHpCFnUKcqkaRKt = parent;
					parent?.QabEwIWziDyOxdwrocdfmyqjFCn(this);
				}

				public void QabEwIWziDyOxdwrocdfmyqjFCn(eAkzflHaPbtRGzfaAzYjQvWYEvG P_0)
				{
					if (P_0 != null)
					{
						if (YLJxUWDNInjyLDXmqDTdUFksGnHu == null)
						{
							YLJxUWDNInjyLDXmqDTdUFksGnHu = new List<eAkzflHaPbtRGzfaAzYjQvWYEvG>();
						}
						YLJxUWDNInjyLDXmqDTdUFksGnHu.Add(P_0);
					}
				}

				public void UKKfDayQMFHRLPffjhcEtRmmDzC(string P_0, string P_1)
				{
					if (!string.IsNullOrEmpty(P_0))
					{
						if (PIrODvkBwzDJjvCzrIFoIGPrHcv == null)
						{
							PIrODvkBwzDJjvCzrIFoIGPrHcv = new Dictionary<string, string>();
						}
						if (PIrODvkBwzDJjvCzrIFoIGPrHcv.ContainsKey(P_0))
						{
							PIrODvkBwzDJjvCzrIFoIGPrHcv[P_0] = P_1;
						}
						else
						{
							PIrODvkBwzDJjvCzrIFoIGPrHcv.Add(P_0, P_1);
						}
					}
				}

				public bool zneXOrndzZtRllDrOAiXWeYkdyM(string P_0)
				{
					return JuNHydreIuODygBLFuTRoJRegUHC(P_0) != null;
				}

				public eAkzflHaPbtRGzfaAzYjQvWYEvG JuNHydreIuODygBLFuTRoJRegUHC(string P_0)
				{
					if (childCount == 0)
					{
						return null;
					}
					for (int i = 0; i < YLJxUWDNInjyLDXmqDTdUFksGnHu.Count; i++)
					{
						if (string.Equals(YLJxUWDNInjyLDXmqDTdUFksGnHu[i].qROaKKGTWVzDYhhRdQZEfZxsihTO, P_0, StringComparison.Ordinal))
						{
							return YLJxUWDNInjyLDXmqDTdUFksGnHu[i];
						}
					}
					return null;
				}

				public object dJSqsNriNcUWJeVjXpZevEVniaz()
				{
					if (childCount == 0)
					{
						return vgdHGalJrxixvHHoLihCGFDKjBJB;
					}
					SerializedObject serializedObject = new SerializedObject(null, ObjectType.List);
					for (int i = 0; i < childCount; i++)
					{
						eAkzflHaPbtRGzfaAzYjQvWYEvG eAkzflHaPbtRGzfaAzYjQvWYEvG2 = YLJxUWDNInjyLDXmqDTdUFksGnHu[i];
						if (eAkzflHaPbtRGzfaAzYjQvWYEvG2 != null)
						{
							serializedObject.Add(eAkzflHaPbtRGzfaAzYjQvWYEvG2.qROaKKGTWVzDYhhRdQZEfZxsihTO, eAkzflHaPbtRGzfaAzYjQvWYEvG2.dJSqsNriNcUWJeVjXpZevEVniaz());
						}
					}
					return serializedObject;
				}

				public override string ToString()
				{
					return MwDiYSCEAeSRuXLjmZnjHUDEbWd("", 0);
				}

				private string MwDiYSCEAeSRuXLjmZnjHUDEbWd(string P_0, int P_1)
				{
					string text = "";
					for (int i = 0; i < P_1; i++)
					{
						text += "    ";
					}
					string text2 = P_0;
					P_0 = text2 + text + "Name = " + qROaKKGTWVzDYhhRdQZEfZxsihTO + "\n";
					string text3 = P_0;
					P_0 = text3 + text + "Content = " + ((vgdHGalJrxixvHHoLihCGFDKjBJB == null) ? "NULL" : vgdHGalJrxixvHHoLihCGFDKjBJB.ToString()) + "\n";
					object obj = P_0;
					P_0 = string.Concat(obj, text, "Attribute Count = ", attributeCount, "\n");
					if (PIrODvkBwzDJjvCzrIFoIGPrHcv != null)
					{
						foreach (KeyValuePair<string, string> item in PIrODvkBwzDJjvCzrIFoIGPrHcv)
						{
							string text4 = P_0;
							P_0 = text4 + text + "Attribute " + item.Key + ": = " + item.Value + "\n";
						}
					}
					object obj2 = P_0;
					P_0 = string.Concat(obj2, text, "Child Count = ", childCount, "\n");
					if (YLJxUWDNInjyLDXmqDTdUFksGnHu != null)
					{
						string text5 = "";
						foreach (eAkzflHaPbtRGzfaAzYjQvWYEvG item2 in YLJxUWDNInjyLDXmqDTdUFksGnHu)
						{
							text5 += "\n";
							text5 = item2.MwDiYSCEAeSRuXLjmZnjHUDEbWd(text5, P_1 + 1);
						}
						P_0 += text5;
					}
					return P_0;
				}
			}

			private readonly eAkzflHaPbtRGzfaAzYjQvWYEvG pkJEDebRzZudYsclVlujUQoWkLi;

			public eAkzflHaPbtRGzfaAzYjQvWYEvG root => pkJEDebRzZudYsclVlujUQoWkLi;

			public bool isValid => pkJEDebRzZudYsclVlujUQoWkLi != null;

			public abjoFKTACLegvAMdmRALGmbnQVkL(string xml)
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
					pkJEDebRzZudYsclVlujUQoWkLi = new eAkzflHaPbtRGzfaAzYjQvWYEvG("Root", null);
					baFSUPjjJxNAXmQmozaafYcPURW(xmlReader);
				}
				catch
				{
					pkJEDebRzZudYsclVlujUQoWkLi = null;
				}
			}

			private void baFSUPjjJxNAXmQmozaafYcPURW(XmlReader P_0)
			{
				eAkzflHaPbtRGzfaAzYjQvWYEvG eAkzflHaPbtRGzfaAzYjQvWYEvG2 = pkJEDebRzZudYsclVlujUQoWkLi;
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
							eAkzflHaPbtRGzfaAzYjQvWYEvG2 = new eAkzflHaPbtRGzfaAzYjQvWYEvG(P_0.LocalName, eAkzflHaPbtRGzfaAzYjQvWYEvG2);
							for (int i = 0; i < P_0.AttributeCount; i++)
							{
								P_0.MoveToNextAttribute();
								eAkzflHaPbtRGzfaAzYjQvWYEvG2.UKKfDayQMFHRLPffjhcEtRmmDzC(P_0.Name, P_0.Value);
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
							eAkzflHaPbtRGzfaAzYjQvWYEvG2.vgdHGalJrxixvHHoLihCGFDKjBJB = P_0.ReadContentAsString();
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
					if ((flag || P_0.NodeType == XmlNodeType.EndElement) && eAkzflHaPbtRGzfaAzYjQvWYEvG2 != null && eAkzflHaPbtRGzfaAzYjQvWYEvG2 != pkJEDebRzZudYsclVlujUQoWkLi && P_0.Name == eAkzflHaPbtRGzfaAzYjQvWYEvG2.qROaKKGTWVzDYhhRdQZEfZxsihTO)
					{
						eAkzflHaPbtRGzfaAzYjQvWYEvG2 = eAkzflHaPbtRGzfaAzYjQvWYEvG2.ugKyZyJTGtYLrHpCFnUKcqkaRKt;
					}
					num++;
				}
			}

			public override string ToString()
			{
				if (pkJEDebRzZudYsclVlujUQoWkLi == null || pkJEDebRzZudYsclVlujUQoWkLi.childCount == 0)
				{
					return "Document is empty.";
				}
				return pkJEDebRzZudYsclVlujUQoWkLi.ToString();
			}
		}

		private readonly IndexedDictionary<string, RodYdwBjqjcHlAbPcnsvFRDpWns> QkWQAhGTNPowwIiGAEpalVljNee;

		private XmlInfo WcshgjBkMeKovFwhAjyAArZoQEeM;

		private Type AkkykLRVUWzqzDOfDtdSigYijIy;

		private ObjectType HtoPHohwdKMPASsVIWoimSWriwg;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> EHBFZkcSRXhShXoBBZVmqGziarX = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> oPCplcvpjvESFFfPRkrGIGqtuGO = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		[CompilerGenerated]
		private static Func<FieldInfo, bool> ZyemrtlocPgopITzwWGmeAtLePxI;

		[CompilerGenerated]
		private static Func<FieldInfo, string> fqbZuOCzaGEtjRCXGpKkmkLnbRtb;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> ErYjYWcizjTYyRiNnNTXgBKNzrm;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> qlTsISqPSBCPcaLBnKlZucNUKOOT;

		private bool allowDuplicateKeys => HtoPHohwdKMPASsVIWoimSWriwg == ObjectType.List;

		public ObjectType objectType
		{
			get
			{
				return HtoPHohwdKMPASsVIWoimSWriwg;
			}
			set
			{
				if (value != HtoPHohwdKMPASsVIWoimSWriwg)
				{
					HtoPHohwdKMPASsVIWoimSWriwg = value;
					QkWQAhGTNPowwIiGAEpalVljNee.AllowDuplicateKeys = allowDuplicateKeys;
				}
			}
		}

		public Type type => AkkykLRVUWzqzDOfDtdSigYijIy;

		public XmlInfo xmlInfo
		{
			get
			{
				return WcshgjBkMeKovFwhAjyAArZoQEeM;
			}
			set
			{
				WcshgjBkMeKovFwhAjyAArZoQEeM = value;
			}
		}

		public int count => QkWQAhGTNPowwIiGAEpalVljNee.Count;

		public Field this[int index]
		{
			get
			{
				RodYdwBjqjcHlAbPcnsvFRDpWns rodYdwBjqjcHlAbPcnsvFRDpWns = QkWQAhGTNPowwIiGAEpalVljNee[index];
				string keyAt = QkWQAhGTNPowwIiGAEpalVljNee.GetKeyAt(index);
				return new Field(keyAt, rodYdwBjqjcHlAbPcnsvFRDpWns.lvXCTCWOhrCtuFDbbEqyqyUVPhp, rodYdwBjqjcHlAbPcnsvFRDpWns.bAPyGAfeWoGVtSjhtFRwzpyXFad, rodYdwBjqjcHlAbPcnsvFRDpWns.dCEaYrMIDmGupaCRkNUGTLpPJvkK);
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
			HtoPHohwdKMPASsVIWoimSWriwg = ObjectType.List;
			QkWQAhGTNPowwIiGAEpalVljNee = new IndexedDictionary<string, RodYdwBjqjcHlAbPcnsvFRDpWns>(capacity, allowDuplicateKeys: true);
		}

		public SerializedObject(Type type, ObjectType objectType)
			: this(type, objectType, 0)
		{
		}

		public SerializedObject(Type type, ObjectType objectType, int capacity)
			: this(capacity)
		{
			AkkykLRVUWzqzDOfDtdSigYijIy = type;
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
				QkWQAhGTNPowwIiGAEpalVljNee.Add(item.Key, new RodYdwBjqjcHlAbPcnsvFRDpWns((item.Value != null) ? item.Value.GetType() : null, item.Value, FieldOptions.None));
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
				if (HtoPHohwdKMPASsVIWoimSWriwg != ObjectType.List)
				{
					throw new ArgumentNullException("fieldName");
				}
				fieldName = "value";
			}
			if (allowDuplicateKeys)
			{
				QkWQAhGTNPowwIiGAEpalVljNee.Add(fieldName, new RodYdwBjqjcHlAbPcnsvFRDpWns(type, value, options));
			}
			else if (!QkWQAhGTNPowwIiGAEpalVljNee.ContainsKey(fieldName))
			{
				QkWQAhGTNPowwIiGAEpalVljNee.Add(fieldName, new RodYdwBjqjcHlAbPcnsvFRDpWns(type, value, options));
			}
			else
			{
				QkWQAhGTNPowwIiGAEpalVljNee.SetValue(fieldName, new RodYdwBjqjcHlAbPcnsvFRDpWns(type, value, options));
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
			return QkWQAhGTNPowwIiGAEpalVljNee.Remove(fieldName);
		}

		public bool Contains(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return QkWQAhGTNPowwIiGAEpalVljNee.ContainsKey(fieldName);
		}

		public Type GetDataType(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			if (!QkWQAhGTNPowwIiGAEpalVljNee.TryGetValue(fieldName, out var value))
			{
				return null;
			}
			return value.bAPyGAfeWoGVtSjhtFRwzpyXFad;
		}

		public bool TryGetOriginalValue(string fieldName, out object value)
		{
			value = null;
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			if (!QkWQAhGTNPowwIiGAEpalVljNee.TryGetValue(fieldName, out var value2))
			{
				return false;
			}
			value = value2.lvXCTCWOhrCtuFDbbEqyqyUVPhp;
			return true;
		}

		public Field GetEntry(string fieldName)
		{
			KeyValuePair<string, RodYdwBjqjcHlAbPcnsvFRDpWns> entry = QkWQAhGTNPowwIiGAEpalVljNee.GetEntry(fieldName);
			return new Field(entry.Key, entry.Value.lvXCTCWOhrCtuFDbbEqyqyUVPhp, entry.Value.bAPyGAfeWoGVtSjhtFRwzpyXFad, entry.Value.dCEaYrMIDmGupaCRkNUGTLpPJvkK);
		}

		public object GetOriginalValue(string fieldName)
		{
			return QkWQAhGTNPowwIiGAEpalVljNee.GetEntry(fieldName).Value.lvXCTCWOhrCtuFDbbEqyqyUVPhp;
		}

		public object GetOriginalValue(int index)
		{
			return QkWQAhGTNPowwIiGAEpalVljNee[index].lvXCTCWOhrCtuFDbbEqyqyUVPhp;
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
			if (!QkWQAhGTNPowwIiGAEpalVljNee.TryGetValue(fieldName, out var value2))
			{
				value = default(T);
				return false;
			}
			return IlwDosFDikgLedNxRTMAkLGCtTe<T>(value2.lvXCTCWOhrCtuFDbbEqyqyUVPhp, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			if ((uint)index > (uint)QkWQAhGTNPowwIiGAEpalVljNee.Count)
			{
				value = default(T);
				return false;
			}
			return IlwDosFDikgLedNxRTMAkLGCtTe<T>(QkWQAhGTNPowwIiGAEpalVljNee.GetEntryAt(index).Value.lvXCTCWOhrCtuFDbbEqyqyUVPhp, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
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
			if ((uint)index > (uint)QkWQAhGTNPowwIiGAEpalVljNee.Count)
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
			if (WcshgjBkMeKovFwhAjyAArZoQEeM == null)
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
				tuodVALMLWIRmBrIyMBJITCdrPlj(xmlWriter);
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
			stringBuilder.Append(((object)AkkykLRVUWzqzDOfDtdSigYijIy != null) ? AkkykLRVUWzqzDOfDtdSigYijIy.Name : "NULL\n");
			stringBuilder.Append("objectType = ");
			stringBuilder.Append(HtoPHohwdKMPASsVIWoimSWriwg.ToString());
			stringBuilder.Append("\n");
			stringBuilder.Append("xmlInfo = ");
			stringBuilder.Append((WcshgjBkMeKovFwhAjyAArZoQEeM != null) ? WcshgjBkMeKovFwhAjyAArZoQEeM.ToString() : "NULL\n");
			stringBuilder.Append("\n");
			for (int i = 0; i < QkWQAhGTNPowwIiGAEpalVljNee.Count; i++)
			{
				string keyAt = QkWQAhGTNPowwIiGAEpalVljNee.GetKeyAt(i);
				stringBuilder.Append("key = ");
				stringBuilder.Append((keyAt != null) ? keyAt : "NULL");
				stringBuilder.Append(", value = ");
				stringBuilder.Append(QkWQAhGTNPowwIiGAEpalVljNee[i].ToString());
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}

		private void tuodVALMLWIRmBrIyMBJITCdrPlj(XmlWriter P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writer");
			}
			P_0.WriteStartElement(type.Name, "http://guavaman.com/rewired");
			ZGKMGbrnsJJIJcZehkIaKrNrdCd(P_0);
			P_0.WriteEndElement();
		}

		private void ZGKMGbrnsJJIJcZehkIaKrNrdCd(XmlWriter P_0)
		{
			int num = ((xmlInfo != null) ? xmlInfo.attributes.Count : 0);
			for (int i = 0; i < num; i++)
			{
				XmlInfo.DlYeiFaSwjdirAYOnEUmEePrUvTA dlYeiFaSwjdirAYOnEUmEePrUvTA = xmlInfo.attributes[i];
				if (dlYeiFaSwjdirAYOnEUmEePrUvTA is XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm)
				{
					XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm yOvafjSNTWBQXamMnEDaXllsdXm = dlYeiFaSwjdirAYOnEUmEePrUvTA as XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm;
					if (!string.IsNullOrEmpty(yOvafjSNTWBQXamMnEDaXllsdXm.tpjeoHgHRUvvsMOVGUmfENOfWgb))
					{
						P_0.WriteAttributeString(yOvafjSNTWBQXamMnEDaXllsdXm.tpjeoHgHRUvvsMOVGUmfENOfWgb, yOvafjSNTWBQXamMnEDaXllsdXm.NSIraOohUuxbwNWwnOfcoaPLKLA, yOvafjSNTWBQXamMnEDaXllsdXm.KyKFPbDbzyvJvQZYVoBMpXenzVYN, yOvafjSNTWBQXamMnEDaXllsdXm.lvXCTCWOhrCtuFDbbEqyqyUVPhp);
					}
					else if (!string.IsNullOrEmpty(yOvafjSNTWBQXamMnEDaXllsdXm.KyKFPbDbzyvJvQZYVoBMpXenzVYN))
					{
						P_0.WriteAttributeString(yOvafjSNTWBQXamMnEDaXllsdXm.NSIraOohUuxbwNWwnOfcoaPLKLA, yOvafjSNTWBQXamMnEDaXllsdXm.KyKFPbDbzyvJvQZYVoBMpXenzVYN, yOvafjSNTWBQXamMnEDaXllsdXm.lvXCTCWOhrCtuFDbbEqyqyUVPhp);
					}
					else
					{
						P_0.WriteAttributeString(yOvafjSNTWBQXamMnEDaXllsdXm.NSIraOohUuxbwNWwnOfcoaPLKLA, yOvafjSNTWBQXamMnEDaXllsdXm.lvXCTCWOhrCtuFDbbEqyqyUVPhp);
					}
					continue;
				}
				throw new NotImplementedException();
			}
			for (int j = 0; j < count; j++)
			{
				RodYdwBjqjcHlAbPcnsvFRDpWns rodYdwBjqjcHlAbPcnsvFRDpWns = QkWQAhGTNPowwIiGAEpalVljNee[j];
				string text = QkWQAhGTNPowwIiGAEpalVljNee.GetKeyAt(j);
				if ((rodYdwBjqjcHlAbPcnsvFRDpWns.dCEaYrMIDmGupaCRkNUGTLpPJvkK & FieldOptions.ExculdeFromXml) == 0)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = (((object)rodYdwBjqjcHlAbPcnsvFRDpWns.bAPyGAfeWoGVtSjhtFRwzpyXFad != null) ? rodYdwBjqjcHlAbPcnsvFRDpWns.GetType().Name : ((rodYdwBjqjcHlAbPcnsvFRDpWns.lvXCTCWOhrCtuFDbbEqyqyUVPhp == null) ? "value" : rodYdwBjqjcHlAbPcnsvFRDpWns.lvXCTCWOhrCtuFDbbEqyqyUVPhp.GetType().Name));
					}
					SerializationTools.WriteXmlElement(P_0, text, rodYdwBjqjcHlAbPcnsvFRDpWns.lvXCTCWOhrCtuFDbbEqyqyUVPhp);
				}
			}
		}

		private void vwRztMSRCjPnuAKImeRbddWUmpc(XmlWriter P_0)
		{
			tuodVALMLWIRmBrIyMBJITCdrPlj(P_0);
		}

		void IExportToXml.WriteXml(XmlWriter P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in vwRztMSRCjPnuAKImeRbddWUmpc
			this.vwRztMSRCjPnuAKImeRbddWUmpc(P_0);
		}

		private void rWTZGrZjKdYCtlxYIPCDFUdDhWp(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("stringBuilder");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("appendValueDelegate");
			}
			int num = QkWQAhGTNPowwIiGAEpalVljNee.Count;
			if (QkWQAhGTNPowwIiGAEpalVljNee.ContainsDuplicateKeys)
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
					P_1(P_0, QkWQAhGTNPowwIiGAEpalVljNee[i].lvXCTCWOhrCtuFDbbEqyqyUVPhp);
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
				RodYdwBjqjcHlAbPcnsvFRDpWns rodYdwBjqjcHlAbPcnsvFRDpWns = QkWQAhGTNPowwIiGAEpalVljNee[j];
				string value = QkWQAhGTNPowwIiGAEpalVljNee.GetKeyAt(j);
				if (string.IsNullOrEmpty(value))
				{
					value = j.ToString();
				}
				P_0.Append('"');
				P_0.Append(value);
				P_0.Append("\":");
				P_1(P_0, rodYdwBjqjcHlAbPcnsvFRDpWns.lvXCTCWOhrCtuFDbbEqyqyUVPhp);
			}
			P_0.Append('}');
		}

		void IExportToJson.WriteJson(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rWTZGrZjKdYCtlxYIPCDFUdDhWp
			this.rWTZGrZjKdYCtlxYIPCDFUdDhWp(P_0, P_1);
		}

		private void XQgHdorcHfIeadOMSudIwhcykuWe(object P_0)
		{
			Add(null, P_0);
		}

		void IAddValue<object>.Add(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XQgHdorcHfIeadOMSudIwhcykuWe
			this.XQgHdorcHfIeadOMSudIwhcykuWe(P_0);
		}

		private void rFjiqHAnKgRZAOEgKOkmtxmcFgW(string P_0, object P_1)
		{
			Add(P_0, P_1);
		}

		void IAddKeyValue<string, object>.Add(string P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rFjiqHAnKgRZAOEgKOkmtxmcFgW
			this.rFjiqHAnKgRZAOEgKOkmtxmcFgW(P_0, P_1);
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return new Enumerator(QkWQAhGTNPowwIiGAEpalVljNee);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(QkWQAhGTNPowwIiGAEpalVljNee);
		}

		private static bool IlwDosFDikgLedNxRTMAkLGCtTe<T>(object P_0, out T P_1, NumberStyles P_2 = NumberStyles.Any, CultureInfo P_3 = null)
		{
			if (!IlwDosFDikgLedNxRTMAkLGCtTe(typeof(T), P_0, out var obj, P_2, P_3))
			{
				P_1 = default(T);
				return false;
			}
			P_1 = (T)obj;
			return true;
		}

		private static bool IlwDosFDikgLedNxRTMAkLGCtTe(Type P_0, object P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
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
					if (IlwDosFDikgLedNxRTMAkLGCtTe(underlyingEnumType, P_1, out var value, P_3, P_4))
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
								if (IlwDosFDikgLedNxRTMAkLGCtTe(elementType, serializedObject[i].value, out var value2, P_3, P_4))
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
								if (IlwDosFDikgLedNxRTMAkLGCtTe(elementType, readOnlyList[j], out var value3, P_3, P_4))
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
								if (IlwDosFDikgLedNxRTMAkLGCtTe(elementType, list[k], out var value4, P_3, P_4))
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
								if (IlwDosFDikgLedNxRTMAkLGCtTe(elementType, array4.GetValue(l), out var value5, P_3, P_4))
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
								if (IlwDosFDikgLedNxRTMAkLGCtTe(type2, value15, out var value6, P_3, P_4))
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
								if (IlwDosFDikgLedNxRTMAkLGCtTe(elementType, item, out var value7, P_3, P_4))
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
								if (IlwDosFDikgLedNxRTMAkLGCtTe(elementType, item3, out var value8, P_3, P_4))
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
									if (IlwDosFDikgLedNxRTMAkLGCtTe(type3, serializedObject2[m].value, out var value9, P_3, P_4))
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
									if (IlwDosFDikgLedNxRTMAkLGCtTe(type3, readOnlyList2[n], out var value10, P_3, P_4))
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
									if (IlwDosFDikgLedNxRTMAkLGCtTe(type3, list4[num5], out var value11, P_3, P_4))
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
									if (IlwDosFDikgLedNxRTMAkLGCtTe(type3, array9.GetValue(num6), out var value12, P_3, P_4))
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
									if (IlwDosFDikgLedNxRTMAkLGCtTe(type3, item4, out var value13, P_3, P_4))
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
								if (IlwDosFDikgLedNxRTMAkLGCtTe(type4, key2, out var key, P_3, P_4) && IlwDosFDikgLedNxRTMAkLGCtTe(type5, dictionary2[key2], out var value14, P_3, P_4))
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
					if (!pdGSNpPZxqGfouJEYNcJzcvrHYa(P_0, P_1 as SerializedObject, out P_1))
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

		private static bool pdGSNpPZxqGfouJEYNcJzcvrHYa(Type P_0, SerializedObject P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			if (P_1 == null || (object)P_0 == null)
			{
				P_2 = null;
				return false;
			}
			P_2 = Factory.CreateInstance(P_0);
			if (!EHBFZkcSRXhShXoBBZVmqGziarX.TryGetValue(P_0, out var value))
			{
				value = (from fieldInfo in ReflectionTools.GetFields(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
					where (fieldInfo.IsPublic || fieldInfo.IsDefined(typeof(SerializeAttribute), inherit: true) || fieldInfo.IsDefined(typeof(SerializeField), inherit: true)) && !fieldInfo.IsDefined(typeof(NonSerializedAttribute), inherit: true) && !fieldInfo.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
					select fieldInfo).ToDictionary((FieldInfo fieldInfo) =>
				{
					string name2;
					return (fieldInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(fieldInfo.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name2 : fieldInfo.Name;
				});
				EHBFZkcSRXhShXoBBZVmqGziarX.Add(P_0, value);
			}
			if (!oPCplcvpjvESFFfPRkrGIGqtuGO.TryGetValue(P_0, out var value2))
			{
				value2 = (from propertyInfo in ReflectionTools.GetProperties(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic)
					where propertyInfo.CanWrite && propertyInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !propertyInfo.IsDefined(typeof(DoNotSerializeAttribute), inherit: true)
					select propertyInfo).ToDictionary((PropertyInfo propertyInfo) =>
				{
					string name2;
					return (propertyInfo.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name2 = (CollectionTools.GetValue(propertyInfo.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name)) ? name2 : propertyInfo.Name;
				});
				oPCplcvpjvESFFfPRkrGIGqtuGO.Add(P_0, value2);
			}
			foreach (Field item in (IEnumerable<Field>)P_1)
			{
				string name = item.name;
				object value3 = item.value;
				object value5;
				PropertyInfo value6;
				if (value.TryGetValue(name, out var value4))
				{
					if (IlwDosFDikgLedNxRTMAkLGCtTe(value4.FieldType, value3, out value5, P_3, P_4))
					{
						value4.SetValue(P_2, value5);
					}
				}
				else if (value2.TryGetValue(name, out value6) && value6.CanWrite && IlwDosFDikgLedNxRTMAkLGCtTe(value6.PropertyType, value3, out value5, P_3, P_4))
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
			abjoFKTACLegvAMdmRALGmbnQVkL abjoFKTACLegvAMdmRALGmbnQVkL2 = new abjoFKTACLegvAMdmRALGmbnQVkL(xmlString);
			if (!abjoFKTACLegvAMdmRALGmbnQVkL2.isValid)
			{
				throw new Exception("Failed to parse XML string.");
			}
			if (abjoFKTACLegvAMdmRALGmbnQVkL2.root.childCount == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			abjoFKTACLegvAMdmRALGmbnQVkL.eAkzflHaPbtRGzfaAzYjQvWYEvG eAkzflHaPbtRGzfaAzYjQvWYEvG = abjoFKTACLegvAMdmRALGmbnQVkL2.root.JuNHydreIuODygBLFuTRoJRegUHC(type.Name);
			if (eAkzflHaPbtRGzfaAzYjQvWYEvG == null)
			{
				throw new Exception("Main element not found in XML string.");
			}
			if (!(eAkzflHaPbtRGzfaAzYjQvWYEvG.dJSqsNriNcUWJeVjXpZevEVniaz() is SerializedObject serializedObject) || serializedObject.count == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			return serializedObject;
		}

		[CompilerGenerated]
		private static bool TnsuFGTMkdWvgJKTspDYpbaudZLG(FieldInfo P_0)
		{
			if ((P_0.IsPublic || P_0.IsDefined(typeof(SerializeAttribute), inherit: true) || P_0.IsDefined(typeof(SerializeField), inherit: true)) && !P_0.IsDefined(typeof(NonSerializedAttribute), inherit: true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string eBsyaOxNSMWcuQwiesiUWLrfkvy(FieldInfo P_0)
		{
			string name;
			if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
			{
				return name;
			}
			return P_0.Name;
		}

		[CompilerGenerated]
		private static bool NqXIEQAAoOGZnpzWbOGHrmCFfPU(PropertyInfo P_0)
		{
			if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), inherit: true))
			{
				return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
			}
			return false;
		}

		[CompilerGenerated]
		private static string GDuyQreDECBozfyZbZlAAuCRLTw(PropertyInfo P_0)
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
