using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SerializedObject : IEnumerable<SerializedObject.Field>, IEnumerable, IExportToXml, IExportToJson, IAddValue<object>, IAddKeyValue<string, object>
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

		private struct kqEXRpKnuzuLpMgLrWtYCdAbQSrc
		{
			public Type ZEDHQnvrtqVvvzaHAuzbkuZISTzd;

			public object wnHeSwbkoPeIIrTxLsXncztwOcjO;

			public FieldOptions lfNHDKFrayQeVPSnBgZNNPEOfzHgb;

			public kqEXRpKnuzuLpMgLrWtYCdAbQSrc(Type P_0, object P_1, FieldOptions P_2)
			{
				ZEDHQnvrtqVvvzaHAuzbkuZISTzd = P_0;
				wnHeSwbkoPeIIrTxLsXncztwOcjO = P_1;
				lfNHDKFrayQeVPSnBgZNNPEOfzHgb = P_2;
			}

			public string PPHITqtFroLwruwEIMTHhhqyBQad()
			{
				return string.Concat(string.Concat("" + "type = " + ((ZEDHQnvrtqVvvzaHAuzbkuZISTzd != null) ? ZEDHQnvrtqVvvzaHAuzbkuZISTzd.Name : "NULL") + "\n", "value = ", (wnHeSwbkoPeIIrTxLsXncztwOcjO != null) ? wnHeSwbkoPeIIrTxLsXncztwOcjO.ToString() : "NULL", "\n"), "options = ", lfNHDKFrayQeVPSnBgZNNPEOfzHgb.ToString(), "\n");
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

			public Field(string P_0, object P_1, Type P_2, FieldOptions P_3)
			{
				name = P_0;
				value = P_1;
				type = P_2;
				options = P_3;
			}

			public override string ToString()
			{
				return string.Concat(string.Concat(string.Concat("name = " + ((name != null) ? name : "NULL") + "\n", "value = ", (value != null) ? value.ToString() : "NULL", "\n"), "type = ", (type != null) ? type.Name : "NULL", "\n"), "options = ", options.ToString(), "\n");
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public class XmlInfo
		{
			public abstract class ewbCIKTfalDrUvvnomDKvzifAzKc
			{
			}

			public class HSMGFcRrEEtwLPynqpRDQWJesQYg : ewbCIKTfalDrUvvnomDKvzifAzKc
			{
				public string ZGFlSbWGOfUmLZdUdkUpxhWKZcME;

				public string ielDRFPPVThNrLWgcnBdvoVjXqeg;

				public string MFDdXiyHcPkUibxNoPMtNRhjvlXA;

				public string lPGTilhMaDlHVZPffTpyFffKvRGC;

				public virtual string ecrTJForItYgSVXKTuYFoalkYZxV()
				{
					return string.Concat(string.Concat(string.Concat("" + "prefix = " + ZGFlSbWGOfUmLZdUdkUpxhWKZcME + "\n", "localName = ", ielDRFPPVThNrLWgcnBdvoVjXqeg, "\n"), "ns = ", MFDdXiyHcPkUibxNoPMtNRhjvlXA, "\n"), "value = ", lPGTilhMaDlHVZPffTpyFffKvRGC, "\n");
				}
			}

			private List<ewbCIKTfalDrUvvnomDKvzifAzKc> kiWvdqQGnYpChpHwzHsmUMBuTIks;

			public List<ewbCIKTfalDrUvvnomDKvzifAzKc> attributes => kiWvdqQGnYpChpHwzHsmUMBuTIks ?? (kiWvdqQGnYpChpHwzHsmUMBuTIks = new List<ewbCIKTfalDrUvvnomDKvzifAzKc>());

			public override string ToString()
			{
				string text = "Attributes:\n";
				if (kiWvdqQGnYpChpHwzHsmUMBuTIks != null)
				{
					for (int i = 0; i < kiWvdqQGnYpChpHwzHsmUMBuTIks.Count; i++)
					{
						text = text + kiWvdqQGnYpChpHwzHsmUMBuTIks[i].ToString() + "\n";
					}
				}
				return text;
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<Field>, IEnumerator, IDisposable
		{
			private IndexedDictionary<string, kqEXRpKnuzuLpMgLrWtYCdAbQSrc> pmxQIwXSeHMpMJinSFekhjboLXeK;

			private Field sDHgZIrXapuQSwrvqAagljshKAEL;

			private IEnumerator<KeyValuePair<string, kqEXRpKnuzuLpMgLrWtYCdAbQSrc>> UHHELZGhMAnGiAQPutsLDzvtySJb;

			Field IEnumerator<Field>.Current => sDHgZIrXapuQSwrvqAagljshKAEL;

			object IEnumerator.Current => sDHgZIrXapuQSwrvqAagljshKAEL;

			internal Enumerator(object P_0)
			{
				pmxQIwXSeHMpMJinSFekhjboLXeK = (IndexedDictionary<string, kqEXRpKnuzuLpMgLrWtYCdAbQSrc>)P_0;
				sDHgZIrXapuQSwrvqAagljshKAEL = default(Field);
				UHHELZGhMAnGiAQPutsLDzvtySJb = pmxQIwXSeHMpMJinSFekhjboLXeK.GetEnumerator();
			}

			public bool MoveNext()
			{
				if (!UHHELZGhMAnGiAQPutsLDzvtySJb.MoveNext())
				{
					return false;
				}
				KeyValuePair<string, kqEXRpKnuzuLpMgLrWtYCdAbQSrc> current = UHHELZGhMAnGiAQPutsLDzvtySJb.Current;
				sDHgZIrXapuQSwrvqAagljshKAEL = new Field(current.Key, current.Value.wnHeSwbkoPeIIrTxLsXncztwOcjO, current.Value.ZEDHQnvrtqVvvzaHAuzbkuZISTzd, current.Value.lfNHDKFrayQeVPSnBgZNNPEOfzHgb);
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public void Dispose()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			void IEnumerator.Reset()
			{
				sDHgZIrXapuQSwrvqAagljshKAEL = default(Field);
				UHHELZGhMAnGiAQPutsLDzvtySJb = pmxQIwXSeHMpMJinSFekhjboLXeK.GetEnumerator();
			}
		}

		private class PeObbXOADTAXfreIhUgejERzUySl
		{
			public class ysfWEpqhUlIcCfHiRSkdnpcczbxx
			{
				public readonly string UXoXZGiQtWqeRcNNKjVHVAFtGkfc;

				public readonly ysfWEpqhUlIcCfHiRSkdnpcczbxx ZeuTKLymSGHasbnANwxKNGCRveAW;

				public string EgmMhhwCFLxkHPnlFqJMqHgLIHUV;

				public Dictionary<string, string> oDBUnEwPHRLShylMSGQMrRxTrrtF;

				public List<ysfWEpqhUlIcCfHiRSkdnpcczbxx> MlbkHxtGKRAAAoczXMXWjvFWviFG;

				public int kRHCemgLDJPeHjqOPhVwqqqHerxcb
				{
					get
					{
						if (MlbkHxtGKRAAAoczXMXWjvFWviFG == null)
						{
							return 0;
						}
						return MlbkHxtGKRAAAoczXMXWjvFWviFG.Count;
					}
				}

				public int vIedCRdePSkjgIwqDfxOnanlJMzz
				{
					get
					{
						if (oDBUnEwPHRLShylMSGQMrRxTrrtF == null)
						{
							return 0;
						}
						return oDBUnEwPHRLShylMSGQMrRxTrrtF.Count;
					}
				}

				public ysfWEpqhUlIcCfHiRSkdnpcczbxx(string P_0, ysfWEpqhUlIcCfHiRSkdnpcczbxx P_1)
				{
					UXoXZGiQtWqeRcNNKjVHVAFtGkfc = P_0;
					ZeuTKLymSGHasbnANwxKNGCRveAW = P_1;
					P_1?.HGWqiPuNXPMsbWdpxscCZFbzqYsF(this);
				}

				public void HGWqiPuNXPMsbWdpxscCZFbzqYsF(ysfWEpqhUlIcCfHiRSkdnpcczbxx P_0)
				{
					if (P_0 != null)
					{
						if (MlbkHxtGKRAAAoczXMXWjvFWviFG == null)
						{
							MlbkHxtGKRAAAoczXMXWjvFWviFG = new List<ysfWEpqhUlIcCfHiRSkdnpcczbxx>();
						}
						MlbkHxtGKRAAAoczXMXWjvFWviFG.Add(P_0);
					}
				}

				public void gJHvNaHMCNeXpDJFhFzfBhMWgZZuA(string P_0, string P_1)
				{
					if (!string.IsNullOrEmpty(P_0))
					{
						if (oDBUnEwPHRLShylMSGQMrRxTrrtF == null)
						{
							oDBUnEwPHRLShylMSGQMrRxTrrtF = new Dictionary<string, string>();
						}
						if (oDBUnEwPHRLShylMSGQMrRxTrrtF.ContainsKey(P_0))
						{
							oDBUnEwPHRLShylMSGQMrRxTrrtF[P_0] = P_1;
						}
						else
						{
							oDBUnEwPHRLShylMSGQMrRxTrrtF.Add(P_0, P_1);
						}
					}
				}

				public bool CJFTbnPiEpuXgErpOyMfVdiUrfsB(string P_0)
				{
					return VvwphlByfirLeauyzIfgdrncoJQx(P_0) != null;
				}

				public ysfWEpqhUlIcCfHiRSkdnpcczbxx VvwphlByfirLeauyzIfgdrncoJQx(string P_0)
				{
					if (kRHCemgLDJPeHjqOPhVwqqqHerxcb == 0)
					{
						return null;
					}
					for (int i = 0; i < MlbkHxtGKRAAAoczXMXWjvFWviFG.Count; i++)
					{
						if (string.Equals(MlbkHxtGKRAAAoczXMXWjvFWviFG[i].UXoXZGiQtWqeRcNNKjVHVAFtGkfc, P_0, StringComparison.Ordinal))
						{
							return MlbkHxtGKRAAAoczXMXWjvFWviFG[i];
						}
					}
					return null;
				}

				public object sCepTiGFOaqGfgtcqqBdilLTYyur()
				{
					if (kRHCemgLDJPeHjqOPhVwqqqHerxcb == 0)
					{
						return EgmMhhwCFLxkHPnlFqJMqHgLIHUV;
					}
					SerializedObject serializedObject = new SerializedObject(null, ObjectType.List);
					for (int i = 0; i < kRHCemgLDJPeHjqOPhVwqqqHerxcb; i++)
					{
						ysfWEpqhUlIcCfHiRSkdnpcczbxx ysfWEpqhUlIcCfHiRSkdnpcczbxx2 = MlbkHxtGKRAAAoczXMXWjvFWviFG[i];
						if (ysfWEpqhUlIcCfHiRSkdnpcczbxx2 != null)
						{
							serializedObject.Add(ysfWEpqhUlIcCfHiRSkdnpcczbxx2.UXoXZGiQtWqeRcNNKjVHVAFtGkfc, ysfWEpqhUlIcCfHiRSkdnpcczbxx2.sCepTiGFOaqGfgtcqqBdilLTYyur());
						}
					}
					return serializedObject;
				}

				public virtual string vtoLooyHTiFtkItSGGUpRSYsPYDdb()
				{
					return IqtsMbjQsdGgiuKtuLXmlCTdDnZr("", 0);
				}

				private string IqtsMbjQsdGgiuKtuLXmlCTdDnZr(string P_0, int P_1)
				{
					string text = "";
					for (int i = 0; i < P_1; i++)
					{
						text += "    ";
					}
					P_0 = P_0 + text + "Name = " + UXoXZGiQtWqeRcNNKjVHVAFtGkfc + "\n";
					P_0 = P_0 + text + "Content = " + ((EgmMhhwCFLxkHPnlFqJMqHgLIHUV == null) ? "NULL" : EgmMhhwCFLxkHPnlFqJMqHgLIHUV.ToString()) + "\n";
					P_0 = P_0 + text + "Attribute Count = " + vIedCRdePSkjgIwqDfxOnanlJMzz + "\n";
					if (oDBUnEwPHRLShylMSGQMrRxTrrtF != null)
					{
						foreach (KeyValuePair<string, string> item in oDBUnEwPHRLShylMSGQMrRxTrrtF)
						{
							P_0 = P_0 + text + "Attribute " + item.Key + ": = " + item.Value + "\n";
						}
					}
					P_0 = P_0 + text + "Child Count = " + kRHCemgLDJPeHjqOPhVwqqqHerxcb + "\n";
					if (MlbkHxtGKRAAAoczXMXWjvFWviFG != null)
					{
						string text2 = "";
						foreach (ysfWEpqhUlIcCfHiRSkdnpcczbxx item2 in MlbkHxtGKRAAAoczXMXWjvFWviFG)
						{
							text2 += "\n";
							text2 = item2.IqtsMbjQsdGgiuKtuLXmlCTdDnZr(text2, P_1 + 1);
						}
						P_0 += text2;
					}
					return P_0;
				}
			}

			private readonly ysfWEpqhUlIcCfHiRSkdnpcczbxx vEzGYlbXWMKRVpseNLAViUEIUkMw;

			public ysfWEpqhUlIcCfHiRSkdnpcczbxx iOcaoZFlPmptGIVehHtXkypAmhA => vEzGYlbXWMKRVpseNLAViUEIUkMw;

			public bool rTYbBhkniRHsadOIYFTRCggbFcvnB => vEzGYlbXWMKRVpseNLAViUEIUkMw != null;

			public PeObbXOADTAXfreIhUgejERzUySl(string P_0)
			{
				if (string.IsNullOrEmpty(P_0))
				{
					throw new ArgumentNullException("xml");
				}
				try
				{
					using StringReader input = new StringReader(P_0);
					XmlReader xmlReader = XmlReader.Create(input);
					if (xmlReader == null)
					{
						throw new ArgumentNullException("reader");
					}
					vEzGYlbXWMKRVpseNLAViUEIUkMw = new ysfWEpqhUlIcCfHiRSkdnpcczbxx("Root", null);
					kqAhCarYpdFfrAahqCIqGchsXSPnA(xmlReader);
				}
				catch
				{
					vEzGYlbXWMKRVpseNLAViUEIUkMw = null;
				}
			}

			private void kqAhCarYpdFfrAahqCIqGchsXSPnA(XmlReader P_0)
			{
				ysfWEpqhUlIcCfHiRSkdnpcczbxx ysfWEpqhUlIcCfHiRSkdnpcczbxx2 = vEzGYlbXWMKRVpseNLAViUEIUkMw;
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
							ysfWEpqhUlIcCfHiRSkdnpcczbxx2 = new ysfWEpqhUlIcCfHiRSkdnpcczbxx(P_0.LocalName, ysfWEpqhUlIcCfHiRSkdnpcczbxx2);
							for (int i = 0; i < P_0.AttributeCount; i++)
							{
								P_0.MoveToNextAttribute();
								ysfWEpqhUlIcCfHiRSkdnpcczbxx2.gJHvNaHMCNeXpDJFhFzfBhMWgZZuA(P_0.Name, P_0.Value);
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
							ysfWEpqhUlIcCfHiRSkdnpcczbxx2.EgmMhhwCFLxkHPnlFqJMqHgLIHUV = P_0.ReadContentAsString();
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
					if ((flag || P_0.NodeType == XmlNodeType.EndElement) && ysfWEpqhUlIcCfHiRSkdnpcczbxx2 != null && ysfWEpqhUlIcCfHiRSkdnpcczbxx2 != vEzGYlbXWMKRVpseNLAViUEIUkMw && P_0.Name == ysfWEpqhUlIcCfHiRSkdnpcczbxx2.UXoXZGiQtWqeRcNNKjVHVAFtGkfc)
					{
						ysfWEpqhUlIcCfHiRSkdnpcczbxx2 = ysfWEpqhUlIcCfHiRSkdnpcczbxx2.ZeuTKLymSGHasbnANwxKNGCRveAW;
					}
					num++;
				}
			}

			public virtual string tizwdswPOohSvfWcaFrVVgJOaxgY()
			{
				if (vEzGYlbXWMKRVpseNLAViUEIUkMw == null || vEzGYlbXWMKRVpseNLAViUEIUkMw.kRHCemgLDJPeHjqOPhVwqqqHerxcb == 0)
				{
					return "Document is empty.";
				}
				return vEzGYlbXWMKRVpseNLAViUEIUkMw.ToString();
			}
		}

		[Serializable]
		private sealed class BCEHTCFuLTFwGtlsBCAHehncHWuG
		{
			public static readonly BCEHTCFuLTFwGtlsBCAHehncHWuG _003C_003E9 = new BCEHTCFuLTFwGtlsBCAHehncHWuG();

			public static Func<FieldInfo, bool> _003C_003E9__63_0;

			public static Func<FieldInfo, string> _003C_003E9__63_1;

			public static Func<PropertyInfo, bool> _003C_003E9__63_2;

			public static Func<PropertyInfo, string> _003C_003E9__63_3;

			internal bool DAXQezlfWOzYSZxZBbIGtCHEDNJDA(FieldInfo P_0)
			{
				if ((P_0.IsPublic || P_0.IsDefined(typeof(SerializeAttribute), inherit: true) || P_0.IsDefined(typeof(SerializeField), inherit: true)) && !P_0.IsDefined(typeof(NonSerializedAttribute), inherit: true))
				{
					return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
				}
				return false;
			}

			internal string yONYGvdmHauDfcXbdJpbXwrbzVKl(FieldInfo P_0)
			{
				string name;
				if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
				{
					return name;
				}
				return P_0.Name;
			}

			internal bool UmbaZfEofXikPijdhQmMGEBEeJNXb(PropertyInfo P_0)
			{
				if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), inherit: true))
				{
					return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
				}
				return false;
			}

			internal string yEpDCRobTpOnzeCOtsKXHIvpTzpI(PropertyInfo P_0)
			{
				string name;
				if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
				{
					return name;
				}
				return P_0.Name;
			}
		}

		private readonly IndexedDictionary<string, kqEXRpKnuzuLpMgLrWtYCdAbQSrc> EVsZQndcblKnbsILzOcvfTjoLkMd;

		private XmlInfo QjEhCIcaOctXVaybFngnVshIEHFE;

		private Type QEqCwYDZLRSOUrdZmUSFrhfOSdfH;

		private ObjectType XgbaOzvdRpacNRpcesnQuetSycN;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> RqSkCuDqTzefVvGOocdJDulCzuJGA = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> ArRanMEYtfIAnDGMarmwFhOOiVeh = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		private bool allowDuplicateKeys => XgbaOzvdRpacNRpcesnQuetSycN == ObjectType.List;

		public ObjectType objectType
		{
			get
			{
				return XgbaOzvdRpacNRpcesnQuetSycN;
			}
			set
			{
				if (value != XgbaOzvdRpacNRpcesnQuetSycN)
				{
					XgbaOzvdRpacNRpcesnQuetSycN = value;
					EVsZQndcblKnbsILzOcvfTjoLkMd.AllowDuplicateKeys = allowDuplicateKeys;
				}
			}
		}

		public Type type => QEqCwYDZLRSOUrdZmUSFrhfOSdfH;

		public XmlInfo xmlInfo
		{
			get
			{
				return QjEhCIcaOctXVaybFngnVshIEHFE;
			}
			set
			{
				QjEhCIcaOctXVaybFngnVshIEHFE = value;
			}
		}

		public int count => EVsZQndcblKnbsILzOcvfTjoLkMd.Count;

		public Field this[int index]
		{
			get
			{
				kqEXRpKnuzuLpMgLrWtYCdAbQSrc kqEXRpKnuzuLpMgLrWtYCdAbQSrc2 = EVsZQndcblKnbsILzOcvfTjoLkMd[index];
				return new Field(EVsZQndcblKnbsILzOcvfTjoLkMd.GetKeyAt(index), kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.wnHeSwbkoPeIIrTxLsXncztwOcjO, kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.ZEDHQnvrtqVvvzaHAuzbkuZISTzd, kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.lfNHDKFrayQeVPSnBgZNNPEOfzHgb);
			}
		}

		bool IExportToXml.writesOwnElementTag => true;

		[CustomObfuscation(rename = false)]
		private SerializedObject()
			: this(0)
		{
		}

		private SerializedObject(int P_0)
		{
			XgbaOzvdRpacNRpcesnQuetSycN = ObjectType.List;
			EVsZQndcblKnbsILzOcvfTjoLkMd = new IndexedDictionary<string, kqEXRpKnuzuLpMgLrWtYCdAbQSrc>(P_0, true);
		}

		public SerializedObject(Type P_0, ObjectType P_1)
			: this(P_0, P_1, 0)
		{
		}

		public SerializedObject(Type P_0, ObjectType P_1, int P_2)
			: this(P_2)
		{
			QEqCwYDZLRSOUrdZmUSFrhfOSdfH = P_0;
			objectType = P_1;
		}

		public SerializedObject(Type P_0, IDictionary<string, object> P_1, ObjectType P_2)
			: this(P_0, P_2, P_1?.Count ?? 0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<string, object> item in P_1)
			{
				EVsZQndcblKnbsILzOcvfTjoLkMd.Add(item.Key, new kqEXRpKnuzuLpMgLrWtYCdAbQSrc((item.Value != null) ? item.Value.GetType() : null, item.Value, FieldOptions.None));
			}
		}

		public void Add<T>(string fieldName, T value, FieldOptions options = FieldOptions.None)
		{
			Add(typeof(T), fieldName, value, options);
		}

		public void Add(Type type, string fieldName, object value, FieldOptions options = FieldOptions.None)
		{
			if (type != null && value != null && (object)type != value.GetType())
			{
				throw new Exception("Type does not match value type.");
			}
			if (string.IsNullOrEmpty(fieldName))
			{
				if (XgbaOzvdRpacNRpcesnQuetSycN != ObjectType.List)
				{
					throw new ArgumentNullException("fieldName");
				}
				fieldName = "value";
			}
			if (allowDuplicateKeys)
			{
				EVsZQndcblKnbsILzOcvfTjoLkMd.Add(fieldName, new kqEXRpKnuzuLpMgLrWtYCdAbQSrc(type, value, options));
			}
			else if (!EVsZQndcblKnbsILzOcvfTjoLkMd.ContainsKey(fieldName))
			{
				EVsZQndcblKnbsILzOcvfTjoLkMd.Add(fieldName, new kqEXRpKnuzuLpMgLrWtYCdAbQSrc(type, value, options));
			}
			else
			{
				EVsZQndcblKnbsILzOcvfTjoLkMd.SetValue(fieldName, new kqEXRpKnuzuLpMgLrWtYCdAbQSrc(type, value, options));
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
			return EVsZQndcblKnbsILzOcvfTjoLkMd.Remove(fieldName);
		}

		public bool Contains(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return EVsZQndcblKnbsILzOcvfTjoLkMd.ContainsKey(fieldName);
		}

		public Type GetDataType(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			if (!EVsZQndcblKnbsILzOcvfTjoLkMd.TryGetValue(fieldName, out var value))
			{
				return null;
			}
			return value.ZEDHQnvrtqVvvzaHAuzbkuZISTzd;
		}

		public bool TryGetOriginalValue(string fieldName, out object value)
		{
			value = null;
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			if (!EVsZQndcblKnbsILzOcvfTjoLkMd.TryGetValue(fieldName, out var value2))
			{
				return false;
			}
			value = value2.wnHeSwbkoPeIIrTxLsXncztwOcjO;
			return true;
		}

		public Field GetEntry(string fieldName)
		{
			KeyValuePair<string, kqEXRpKnuzuLpMgLrWtYCdAbQSrc> entry = EVsZQndcblKnbsILzOcvfTjoLkMd.GetEntry(fieldName);
			return new Field(entry.Key, entry.Value.wnHeSwbkoPeIIrTxLsXncztwOcjO, entry.Value.ZEDHQnvrtqVvvzaHAuzbkuZISTzd, entry.Value.lfNHDKFrayQeVPSnBgZNNPEOfzHgb);
		}

		public object GetOriginalValue(string fieldName)
		{
			return EVsZQndcblKnbsILzOcvfTjoLkMd.GetEntry(fieldName).Value.wnHeSwbkoPeIIrTxLsXncztwOcjO;
		}

		public object GetOriginalValue(int index)
		{
			return EVsZQndcblKnbsILzOcvfTjoLkMd[index].wnHeSwbkoPeIIrTxLsXncztwOcjO;
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
			if (!EVsZQndcblKnbsILzOcvfTjoLkMd.TryGetValue(fieldName, out var value2))
			{
				value = default(T);
				return false;
			}
			return ppbpTBwJCmBYUGlPCnoPoQkAshasA<T>(value2.wnHeSwbkoPeIIrTxLsXncztwOcjO, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			if ((uint)index > (uint)EVsZQndcblKnbsILzOcvfTjoLkMd.Count)
			{
				value = default(T);
				return false;
			}
			return ppbpTBwJCmBYUGlPCnoPoQkAshasA<T>(EVsZQndcblKnbsILzOcvfTjoLkMd.GetEntryAt(index).Value.wnHeSwbkoPeIIrTxLsXncztwOcjO, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
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
			if ((uint)index > (uint)EVsZQndcblKnbsILzOcvfTjoLkMd.Count)
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
			if (QjEhCIcaOctXVaybFngnVshIEHFE == null)
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
				HmoVzCqfNMPhycnOFRcVtDhlAKBe(xmlWriter);
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
			stringBuilder.Append((QEqCwYDZLRSOUrdZmUSFrhfOSdfH != null) ? QEqCwYDZLRSOUrdZmUSFrhfOSdfH.Name : "NULL\n");
			stringBuilder.Append("objectType = ");
			stringBuilder.Append(XgbaOzvdRpacNRpcesnQuetSycN.ToString());
			stringBuilder.Append("\n");
			stringBuilder.Append("xmlInfo = ");
			stringBuilder.Append((QjEhCIcaOctXVaybFngnVshIEHFE != null) ? QjEhCIcaOctXVaybFngnVshIEHFE.ToString() : "NULL\n");
			stringBuilder.Append("\n");
			for (int i = 0; i < EVsZQndcblKnbsILzOcvfTjoLkMd.Count; i++)
			{
				string keyAt = EVsZQndcblKnbsILzOcvfTjoLkMd.GetKeyAt(i);
				stringBuilder.Append("key = ");
				stringBuilder.Append((keyAt != null) ? keyAt : "NULL");
				stringBuilder.Append(", value = ");
				stringBuilder.Append(EVsZQndcblKnbsILzOcvfTjoLkMd[i].ToString());
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}

		private void HmoVzCqfNMPhycnOFRcVtDhlAKBe(XmlWriter P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writer");
			}
			P_0.WriteStartElement(type.Name, "http://guavaman.com/rewired");
			ZxsEdlhVwzEnwdJhPHRXaBCcPoBKB(P_0);
			P_0.WriteEndElement();
		}

		private void ZxsEdlhVwzEnwdJhPHRXaBCcPoBKB(XmlWriter P_0)
		{
			int num = ((xmlInfo != null) ? xmlInfo.attributes.Count : 0);
			for (int i = 0; i < num; i++)
			{
				XmlInfo.ewbCIKTfalDrUvvnomDKvzifAzKc ewbCIKTfalDrUvvnomDKvzifAzKc = xmlInfo.attributes[i];
				if (ewbCIKTfalDrUvvnomDKvzifAzKc is XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg)
				{
					XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg hSMGFcRrEEtwLPynqpRDQWJesQYg = ewbCIKTfalDrUvvnomDKvzifAzKc as XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg;
					if (!string.IsNullOrEmpty(hSMGFcRrEEtwLPynqpRDQWJesQYg.ZGFlSbWGOfUmLZdUdkUpxhWKZcME))
					{
						P_0.WriteAttributeString(hSMGFcRrEEtwLPynqpRDQWJesQYg.ZGFlSbWGOfUmLZdUdkUpxhWKZcME, hSMGFcRrEEtwLPynqpRDQWJesQYg.ielDRFPPVThNrLWgcnBdvoVjXqeg, hSMGFcRrEEtwLPynqpRDQWJesQYg.MFDdXiyHcPkUibxNoPMtNRhjvlXA, hSMGFcRrEEtwLPynqpRDQWJesQYg.lPGTilhMaDlHVZPffTpyFffKvRGC);
					}
					else if (!string.IsNullOrEmpty(hSMGFcRrEEtwLPynqpRDQWJesQYg.MFDdXiyHcPkUibxNoPMtNRhjvlXA))
					{
						P_0.WriteAttributeString(hSMGFcRrEEtwLPynqpRDQWJesQYg.ielDRFPPVThNrLWgcnBdvoVjXqeg, hSMGFcRrEEtwLPynqpRDQWJesQYg.MFDdXiyHcPkUibxNoPMtNRhjvlXA, hSMGFcRrEEtwLPynqpRDQWJesQYg.lPGTilhMaDlHVZPffTpyFffKvRGC);
					}
					else
					{
						P_0.WriteAttributeString(hSMGFcRrEEtwLPynqpRDQWJesQYg.ielDRFPPVThNrLWgcnBdvoVjXqeg, hSMGFcRrEEtwLPynqpRDQWJesQYg.lPGTilhMaDlHVZPffTpyFffKvRGC);
					}
					continue;
				}
				throw new NotImplementedException();
			}
			for (int j = 0; j < count; j++)
			{
				kqEXRpKnuzuLpMgLrWtYCdAbQSrc kqEXRpKnuzuLpMgLrWtYCdAbQSrc2 = EVsZQndcblKnbsILzOcvfTjoLkMd[j];
				string text = EVsZQndcblKnbsILzOcvfTjoLkMd.GetKeyAt(j);
				if ((kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.lfNHDKFrayQeVPSnBgZNNPEOfzHgb & FieldOptions.ExculdeFromXml) == 0)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = ((kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.ZEDHQnvrtqVvvzaHAuzbkuZISTzd != null) ? kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.GetType().Name : ((kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.wnHeSwbkoPeIIrTxLsXncztwOcjO == null) ? "value" : kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.wnHeSwbkoPeIIrTxLsXncztwOcjO.GetType().Name));
					}
					SerializationTools.WriteXmlElement(P_0, text, kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.wnHeSwbkoPeIIrTxLsXncztwOcjO);
				}
			}
		}

		private void ucvpOtKvZzdrfjHWyxZhyUOVpche(XmlWriter P_0)
		{
			HmoVzCqfNMPhycnOFRcVtDhlAKBe(P_0);
		}

		void IExportToXml.WriteXml(XmlWriter P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ucvpOtKvZzdrfjHWyxZhyUOVpche
			this.ucvpOtKvZzdrfjHWyxZhyUOVpche(P_0);
		}

		private void qVMAFGmHYKRIVdIyfPDoiFiVsmei(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("stringBuilder");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("appendValueDelegate");
			}
			int num = EVsZQndcblKnbsILzOcvfTjoLkMd.Count;
			if (EVsZQndcblKnbsILzOcvfTjoLkMd.ContainsDuplicateKeys)
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
					P_1(P_0, EVsZQndcblKnbsILzOcvfTjoLkMd[i].wnHeSwbkoPeIIrTxLsXncztwOcjO);
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
				kqEXRpKnuzuLpMgLrWtYCdAbQSrc kqEXRpKnuzuLpMgLrWtYCdAbQSrc2 = EVsZQndcblKnbsILzOcvfTjoLkMd[j];
				string value = EVsZQndcblKnbsILzOcvfTjoLkMd.GetKeyAt(j);
				if (string.IsNullOrEmpty(value))
				{
					value = j.ToString();
				}
				P_0.Append('"');
				P_0.Append(value);
				P_0.Append("\":");
				P_1(P_0, kqEXRpKnuzuLpMgLrWtYCdAbQSrc2.wnHeSwbkoPeIIrTxLsXncztwOcjO);
			}
			P_0.Append('}');
		}

		void IExportToJson.WriteJson(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qVMAFGmHYKRIVdIyfPDoiFiVsmei
			this.qVMAFGmHYKRIVdIyfPDoiFiVsmei(P_0, P_1);
		}

		private void TQuRvqzFathEkTgceGaqMjFaBipIA(object P_0)
		{
			Add(null, P_0);
		}

		void IAddValue<object>.Add(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TQuRvqzFathEkTgceGaqMjFaBipIA
			this.TQuRvqzFathEkTgceGaqMjFaBipIA(P_0);
		}

		private void kbtFJovithYKMORVpjDbtjosMdwU(string P_0, object P_1)
		{
			Add(P_0, P_1);
		}

		void IAddKeyValue<string, object>.Add(string P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kbtFJovithYKMORVpjDbtjosMdwU
			this.kbtFJovithYKMORVpjDbtjosMdwU(P_0, P_1);
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return new Enumerator(EVsZQndcblKnbsILzOcvfTjoLkMd);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(EVsZQndcblKnbsILzOcvfTjoLkMd);
		}

		private static bool ppbpTBwJCmBYUGlPCnoPoQkAshasA<_0001>(object P_0, out _0001 P_1, NumberStyles P_2 = NumberStyles.Any, CultureInfo P_3 = null)
		{
			if (!MxjLcEKvugPgoVyhZcMaxczlcGQEA(typeof(_0001), P_0, out var obj, P_2, P_3))
			{
				P_1 = default(_0001);
				return false;
			}
			P_1 = (_0001)obj;
			return true;
		}

		private static bool MxjLcEKvugPgoVyhZcMaxczlcGQEA(Type P_0, object P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			P_2 = null;
			if (P_1 == null)
			{
				if ((object)P_0 == typeof(string))
				{
					P_2 = string.Empty;
					return true;
				}
				if (!ReflectionTools.IsValueType(P_0))
				{
					return true;
				}
				if (Nullable.GetUnderlyingType(P_0) != null)
				{
					return true;
				}
				return false;
			}
			Type type = P_1.GetType();
			if ((object)P_0 == type)
			{
				P_2 = P_1;
				return true;
			}
			try
			{
				if ((object)P_0 == typeof(string))
				{
					P_2 = P_1.ToString();
					return true;
				}
				if ((object)P_0 == typeof(int))
				{
					if ((object)type == typeof(float))
					{
						P_2 = (int)(float)P_1;
					}
					else if ((object)type == typeof(uint))
					{
						P_2 = (int)(uint)P_1;
					}
					else if ((object)type == typeof(long))
					{
						P_2 = (int)(long)P_1;
					}
					else if ((object)type == typeof(ulong))
					{
						P_2 = (int)(ulong)P_1;
					}
					else if ((object)type == typeof(double))
					{
						P_2 = (int)(double)P_1;
					}
					else if ((object)type == typeof(decimal))
					{
						P_2 = (int)(decimal)P_1;
					}
					else if ((object)type == typeof(short))
					{
						P_2 = (int)(short)P_1;
					}
					else if ((object)type == typeof(ushort))
					{
						P_2 = (int)(ushort)P_1;
					}
					else if ((object)type == typeof(byte))
					{
						P_2 = (int)(byte)P_1;
					}
					else if ((object)type == typeof(sbyte))
					{
						P_2 = (int)(sbyte)P_1;
					}
					else
					{
						if ((object)type != typeof(string))
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
				if ((object)P_0 == typeof(float))
				{
					if ((object)type == typeof(int))
					{
						P_2 = (float)(int)P_1;
					}
					else if ((object)type == typeof(uint))
					{
						P_2 = (float)(uint)P_1;
					}
					else if ((object)type == typeof(long))
					{
						P_2 = (float)(long)P_1;
					}
					else if ((object)type == typeof(ulong))
					{
						P_2 = (float)(ulong)P_1;
					}
					else if ((object)type == typeof(double))
					{
						P_2 = (float)(double)P_1;
					}
					else if ((object)type == typeof(decimal))
					{
						P_2 = (float)(decimal)P_1;
					}
					else if ((object)type == typeof(short))
					{
						P_2 = (float)(short)P_1;
					}
					else if ((object)type == typeof(ushort))
					{
						P_2 = (float)(int)(ushort)P_1;
					}
					else if ((object)type == typeof(byte))
					{
						P_2 = (float)(int)(byte)P_1;
					}
					else if ((object)type == typeof(sbyte))
					{
						P_2 = (float)(sbyte)P_1;
					}
					else
					{
						if ((object)type != typeof(string))
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
					if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(ReflectionTools.GetUnderlyingEnumType(P_0), P_1, out var value, P_3, P_4))
					{
						P_2 = Enum.ToObject(P_0, value);
						return true;
					}
					if ((object)type == typeof(string))
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
					if ((object)P_0 == typeof(uint))
					{
						if ((object)type == typeof(int))
						{
							P_2 = (uint)(int)P_1;
						}
						else if ((object)type == typeof(float))
						{
							P_2 = (uint)(float)P_1;
						}
						else if ((object)type == typeof(long))
						{
							P_2 = (uint)(long)P_1;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (uint)(ulong)P_1;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (uint)(double)P_1;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (uint)(decimal)P_1;
						}
						else if ((object)type == typeof(short))
						{
							P_2 = (uint)(short)P_1;
						}
						else if ((object)type == typeof(ushort))
						{
							P_2 = (uint)(ushort)P_1;
						}
						else if ((object)type == typeof(byte))
						{
							P_2 = (uint)(byte)P_1;
						}
						else if ((object)type == typeof(sbyte))
						{
							P_2 = (uint)(sbyte)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(double))
					{
						if ((object)type == typeof(float))
						{
							P_2 = (double)(float)P_1;
						}
						else if ((object)type == typeof(int))
						{
							P_2 = (double)(int)P_1;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (double)(uint)P_1;
						}
						else if ((object)type == typeof(long))
						{
							P_2 = (double)(long)P_1;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (double)(ulong)P_1;
						}
						else if ((object)type == typeof(short))
						{
							P_2 = (double)(short)P_1;
						}
						else if ((object)type == typeof(ushort))
						{
							P_2 = (double)(int)(ushort)P_1;
						}
						else if ((object)type == typeof(byte))
						{
							P_2 = (double)(int)(byte)P_1;
						}
						else if ((object)type == typeof(sbyte))
						{
							P_2 = (double)(sbyte)P_1;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (double)(decimal)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(bool))
					{
						if ((object)type == typeof(int))
						{
							P_2 = (int)P_1 > 0;
						}
						else if ((object)type == typeof(float))
						{
							P_2 = (float)P_1 > 0f;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (uint)P_1 != 0;
						}
						else if ((object)type == typeof(long))
						{
							P_2 = (long)P_1 > 0;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (ulong)P_1 != 0;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (double)P_1 > 0.0;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (decimal)P_1 > 0m;
						}
						else if ((object)type == typeof(short))
						{
							P_2 = (short)P_1 > 0;
						}
						else if ((object)type == typeof(ushort))
						{
							P_2 = (ushort)P_1 > 0;
						}
						else if ((object)type == typeof(byte))
						{
							P_2 = (byte)P_1 > 0;
						}
						else if ((object)type == typeof(sbyte))
						{
							P_2 = (sbyte)P_1 > 0;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(long))
					{
						if ((object)type == typeof(int))
						{
							P_2 = (long)(int)P_1;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (long)(ulong)P_1;
						}
						else if ((object)type == typeof(float))
						{
							P_2 = (long)(float)P_1;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (long)(uint)P_1;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (long)(double)P_1;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (long)(decimal)P_1;
						}
						else if ((object)type == typeof(short))
						{
							P_2 = (long)(short)P_1;
						}
						else if ((object)type == typeof(ushort))
						{
							P_2 = (long)(ushort)P_1;
						}
						else if ((object)type == typeof(byte))
						{
							P_2 = (long)(byte)P_1;
						}
						else if ((object)type == typeof(sbyte))
						{
							P_2 = (long)(sbyte)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(ulong))
					{
						if ((object)type == typeof(long))
						{
							P_2 = (ulong)(long)P_1;
						}
						else if ((object)type == typeof(int))
						{
							P_2 = (ulong)(int)P_1;
						}
						else if ((object)type == typeof(float))
						{
							P_2 = (ulong)(float)P_1;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (ulong)(uint)P_1;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (ulong)(double)P_1;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (ulong)(decimal)P_1;
						}
						else if ((object)type == typeof(short))
						{
							P_2 = (ulong)(short)P_1;
						}
						else if ((object)type == typeof(ushort))
						{
							P_2 = (ulong)(ushort)P_1;
						}
						else if ((object)type == typeof(byte))
						{
							P_2 = (ulong)(byte)P_1;
						}
						else if ((object)type == typeof(sbyte))
						{
							P_2 = (ulong)(sbyte)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(short))
					{
						if ((object)type == typeof(ushort))
						{
							P_2 = (short)(ushort)P_1;
						}
						else if ((object)type == typeof(int))
						{
							P_2 = (short)(int)P_1;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (short)(uint)P_1;
						}
						else if ((object)type == typeof(long))
						{
							P_2 = (short)(long)P_1;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (short)(ulong)P_1;
						}
						else if ((object)type == typeof(float))
						{
							P_2 = (short)(float)P_1;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (short)(double)P_1;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (short)(decimal)P_1;
						}
						else if ((object)type == typeof(byte))
						{
							P_2 = (short)(byte)P_1;
						}
						else if ((object)type == typeof(sbyte))
						{
							P_2 = (short)(sbyte)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(ushort))
					{
						if ((object)type == typeof(short))
						{
							P_2 = (ushort)(short)P_1;
						}
						else if ((object)type == typeof(int))
						{
							P_2 = (ushort)(int)P_1;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (ushort)(uint)P_1;
						}
						else if ((object)type == typeof(long))
						{
							P_2 = (ushort)(long)P_1;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (ushort)(ulong)P_1;
						}
						else if ((object)type == typeof(float))
						{
							P_2 = (ushort)(float)P_1;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (ushort)(double)P_1;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (ushort)(decimal)P_1;
						}
						else if ((object)type == typeof(byte))
						{
							P_2 = (ushort)(byte)P_1;
						}
						else if ((object)type == typeof(sbyte))
						{
							P_2 = (ushort)(sbyte)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(byte))
					{
						if ((object)type == typeof(sbyte))
						{
							P_2 = (byte)(sbyte)P_1;
						}
						else if ((object)type == typeof(int))
						{
							P_2 = (byte)(int)P_1;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (byte)(uint)P_1;
						}
						else if ((object)type == typeof(long))
						{
							P_2 = (byte)(long)P_1;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (byte)(ulong)P_1;
						}
						else if ((object)type == typeof(float))
						{
							P_2 = (byte)(float)P_1;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (byte)(double)P_1;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (byte)(decimal)P_1;
						}
						else if ((object)type == typeof(short))
						{
							P_2 = (byte)(short)P_1;
						}
						else if ((object)type == typeof(ushort))
						{
							P_2 = (byte)(ushort)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(sbyte))
					{
						if ((object)type == typeof(byte))
						{
							P_2 = (sbyte)(byte)P_1;
						}
						else if ((object)type == typeof(int))
						{
							P_2 = (sbyte)(int)P_1;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (sbyte)(uint)P_1;
						}
						else if ((object)type == typeof(long))
						{
							P_2 = (sbyte)(long)P_1;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (sbyte)(ulong)P_1;
						}
						else if ((object)type == typeof(float))
						{
							P_2 = (sbyte)(float)P_1;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (sbyte)(double)P_1;
						}
						else if ((object)type == typeof(decimal))
						{
							P_2 = (sbyte)(decimal)P_1;
						}
						else if ((object)type == typeof(short))
						{
							P_2 = (sbyte)(short)P_1;
						}
						else if ((object)type == typeof(ushort))
						{
							P_2 = (sbyte)(ushort)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(decimal))
					{
						if ((object)type == typeof(float))
						{
							P_2 = (decimal)(float)P_1;
						}
						else if ((object)type == typeof(double))
						{
							P_2 = (decimal)(double)P_1;
						}
						else if ((object)type == typeof(int))
						{
							P_2 = (decimal)(int)P_1;
						}
						else if ((object)type == typeof(long))
						{
							P_2 = (decimal)(long)P_1;
						}
						else if ((object)type == typeof(uint))
						{
							P_2 = (decimal)(uint)P_1;
						}
						else if ((object)type == typeof(ulong))
						{
							P_2 = (decimal)(ulong)P_1;
						}
						else if ((object)type == typeof(short))
						{
							P_2 = (decimal)(short)P_1;
						}
						else if ((object)type == typeof(ushort))
						{
							P_2 = (decimal)(ushort)P_1;
						}
						else if ((object)type == typeof(byte))
						{
							P_2 = (decimal)(byte)P_1;
						}
						else if ((object)type == typeof(sbyte))
						{
							P_2 = (decimal)(sbyte)P_1;
						}
						else
						{
							if ((object)type != typeof(string))
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
					if ((object)P_0 == typeof(char))
					{
						P_2 = P_1.ToString();
						return true;
					}
					if ((object)P_0 == typeof(Guid))
					{
						if ((object)type == typeof(string))
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
								if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(elementType, serializedObject[i].value, out var value2, P_3, P_4))
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
								if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(elementType, readOnlyList[j], out var value3, P_3, P_4))
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
								if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(elementType, list[k], out var value4, P_3, P_4))
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
								if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(elementType, array4.GetValue(l), out var value5, P_3, P_4))
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
								if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(type2, value15, out var value6, P_3, P_4))
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
								if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(elementType, item, out var value7, P_3, P_4))
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
								if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(elementType, item3, out var value8, P_3, P_4))
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
									if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(type3, serializedObject2[m].value, out var value9, P_3, P_4))
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
									if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(type3, readOnlyList2[n], out var value10, P_3, P_4))
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
									if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(type3, list4[num5], out var value11, P_3, P_4))
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
									if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(type3, array9.GetValue(num6), out var value12, P_3, P_4))
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
									if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(type3, item4, out var value13, P_3, P_4))
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
								if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(type4, key2, out var key, P_3, P_4) && MxjLcEKvugPgoVyhZcMaxczlcGQEA(type5, dictionary2[key2], out var value14, P_3, P_4))
								{
									dictionary3.Add(key, value14);
								}
							}
							P_2 = dictionary3;
							return true;
						}
					}
				}
				if ((object)P_0 == typeof(object))
				{
					P_2 = P_1;
					return true;
				}
				if (ReflectionTools.DoesTypeImplement(type, typeof(SerializedObject)))
				{
					if (!egdmGdqBRNcFAFpCvlrcOdaaDHrs(P_0, P_1 as SerializedObject, out P_1))
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

		private static bool egdmGdqBRNcFAFpCvlrcOdaaDHrs(Type P_0, SerializedObject P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			if (P_1 == null || P_0 == null)
			{
				P_2 = null;
				return false;
			}
			P_2 = Factory.CreateInstance(P_0);
			if (!RqSkCuDqTzefVvGOocdJDulCzuJGA.TryGetValue(P_0, out var value))
			{
				value = ReflectionTools.GetFields(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(BCEHTCFuLTFwGtlsBCAHehncHWuG._003C_003E9.DAXQezlfWOzYSZxZBbIGtCHEDNJDA).ToDictionary(BCEHTCFuLTFwGtlsBCAHehncHWuG._003C_003E9.yONYGvdmHauDfcXbdJpbXwrbzVKl);
				RqSkCuDqTzefVvGOocdJDulCzuJGA.Add(P_0, value);
			}
			if (!ArRanMEYtfIAnDGMarmwFhOOiVeh.TryGetValue(P_0, out var value2))
			{
				value2 = ReflectionTools.GetProperties(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(BCEHTCFuLTFwGtlsBCAHehncHWuG._003C_003E9.UmbaZfEofXikPijdhQmMGEBEeJNXb).ToDictionary(BCEHTCFuLTFwGtlsBCAHehncHWuG._003C_003E9.yEpDCRobTpOnzeCOtsKXHIvpTzpI);
				ArRanMEYtfIAnDGMarmwFhOOiVeh.Add(P_0, value2);
			}
			foreach (Field item in (IEnumerable<Field>)P_1)
			{
				string name = item.name;
				object value3 = item.value;
				object value5;
				PropertyInfo value6;
				if (value.TryGetValue(name, out var value4))
				{
					if (MxjLcEKvugPgoVyhZcMaxczlcGQEA(value4.FieldType, value3, out value5, P_3, P_4))
					{
						value4.SetValue(P_2, value5);
					}
				}
				else if (value2.TryGetValue(name, out value6) && value6.CanWrite && MxjLcEKvugPgoVyhZcMaxczlcGQEA(value6.PropertyType, value3, out value5, P_3, P_4))
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
			if (type == null)
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
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				throw new ArgumentNullException("xmlString");
			}
			PeObbXOADTAXfreIhUgejERzUySl peObbXOADTAXfreIhUgejERzUySl = new PeObbXOADTAXfreIhUgejERzUySl(xmlString);
			if (!peObbXOADTAXfreIhUgejERzUySl.rTYbBhkniRHsadOIYFTRCggbFcvnB)
			{
				throw new Exception("Failed to parse XML string.");
			}
			if (peObbXOADTAXfreIhUgejERzUySl.iOcaoZFlPmptGIVehHtXkypAmhA.kRHCemgLDJPeHjqOPhVwqqqHerxcb == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			if (!((peObbXOADTAXfreIhUgejERzUySl.iOcaoZFlPmptGIVehHtXkypAmhA.VvwphlByfirLeauyzIfgdrncoJQx(type.Name) ?? throw new Exception("Main element not found in XML string.")).sCepTiGFOaqGfgtcqqBdilLTYyur() is SerializedObject { count: not 0 } serializedObject))
			{
				throw new Exception("No data found in XML string.");
			}
			return serializedObject;
		}
	}
}
