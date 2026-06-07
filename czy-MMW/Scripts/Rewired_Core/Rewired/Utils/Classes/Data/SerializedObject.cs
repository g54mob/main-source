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

		[CustomObfuscation(rename = false)]
		[Flags]
		public enum FieldOptions
		{
			[CustomObfuscation(rename = false)]
			None = 0,
			[CustomObfuscation(rename = false)]
			ExculdeFromXml = 1
		}

		private struct pwuYnGUQdkoptYJhlUHwWrVAmhEm
		{
			public Type SbrWAGrdxtBDdhOrMNcNoGOprmlt;

			public object huxeBJJtqYaGKOjgHCPTpwJPsSvz;

			public FieldOptions aExhMtlRmxNkTOzsRPShXCqpBTLW;

			public pwuYnGUQdkoptYJhlUHwWrVAmhEm(Type P_0, object P_1, FieldOptions P_2)
			{
				SbrWAGrdxtBDdhOrMNcNoGOprmlt = P_0;
				huxeBJJtqYaGKOjgHCPTpwJPsSvz = P_1;
				aExhMtlRmxNkTOzsRPShXCqpBTLW = P_2;
			}

			public string UvlRLFbuFfVZtafUKKcbtIXDbouI()
			{
				return string.Concat(string.Concat("" + "type = " + ((SbrWAGrdxtBDdhOrMNcNoGOprmlt != null) ? SbrWAGrdxtBDdhOrMNcNoGOprmlt.Name : "NULL") + "\n", "value = ", (huxeBJJtqYaGKOjgHCPTpwJPsSvz != null) ? huxeBJJtqYaGKOjgHCPTpwJPsSvz.ToString() : "NULL", "\n"), "options = ", aExhMtlRmxNkTOzsRPShXCqpBTLW.ToString(), "\n");
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
			public abstract class buLVqdRafoDJfbNswacdlzZIsivr
			{
			}

			public class EqkbSPJHEHHtJoXsspdzqAzVcAQUA : buLVqdRafoDJfbNswacdlzZIsivr
			{
				public string OehazIAPEcSENVTqpypPfkRtzKCK;

				public string rzFSJcZEFOpFlXqzyhdFdwpOrpaJ;

				public string FqpwTkyfXldoEdOuFQPgNddSWNnN;

				public string sMgGiLjHAAIlXTFOzVTKBeTzOPUX;

				public virtual string tDBVIiqrOcgySFhPBsEncXJPfrvW()
				{
					return string.Concat(string.Concat(string.Concat("" + "prefix = " + OehazIAPEcSENVTqpypPfkRtzKCK + "\n", "localName = ", rzFSJcZEFOpFlXqzyhdFdwpOrpaJ, "\n"), "ns = ", FqpwTkyfXldoEdOuFQPgNddSWNnN, "\n"), "value = ", sMgGiLjHAAIlXTFOzVTKBeTzOPUX, "\n");
				}
			}

			private List<buLVqdRafoDJfbNswacdlzZIsivr> bLqayPQvrVhWvtfvdgQOGEdXuwkL;

			public List<buLVqdRafoDJfbNswacdlzZIsivr> attributes => bLqayPQvrVhWvtfvdgQOGEdXuwkL ?? (bLqayPQvrVhWvtfvdgQOGEdXuwkL = new List<buLVqdRafoDJfbNswacdlzZIsivr>());

			public override string ToString()
			{
				string text = "Attributes:\n";
				if (bLqayPQvrVhWvtfvdgQOGEdXuwkL != null)
				{
					for (int i = 0; i < bLqayPQvrVhWvtfvdgQOGEdXuwkL.Count; i++)
					{
						text = text + bLqayPQvrVhWvtfvdgQOGEdXuwkL[i].ToString() + "\n";
					}
				}
				return text;
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<Field>, IEnumerator, IDisposable
		{
			private IndexedDictionary<string, pwuYnGUQdkoptYJhlUHwWrVAmhEm> eNPLqJVImAKHOREsEFHCjlDHttwV;

			private Field fcljMnInymDsItaegCCOfzYeMsCZB;

			private IEnumerator<KeyValuePair<string, pwuYnGUQdkoptYJhlUHwWrVAmhEm>> DnpcVcYWlXCxGKqXcHjYXeHGhSScA;

			Field IEnumerator<Field>.Current => fcljMnInymDsItaegCCOfzYeMsCZB;

			object IEnumerator.Current => fcljMnInymDsItaegCCOfzYeMsCZB;

			internal Enumerator(object P_0)
			{
				eNPLqJVImAKHOREsEFHCjlDHttwV = (IndexedDictionary<string, pwuYnGUQdkoptYJhlUHwWrVAmhEm>)P_0;
				fcljMnInymDsItaegCCOfzYeMsCZB = default(Field);
				DnpcVcYWlXCxGKqXcHjYXeHGhSScA = eNPLqJVImAKHOREsEFHCjlDHttwV.GetEnumerator();
			}

			public bool MoveNext()
			{
				if (!DnpcVcYWlXCxGKqXcHjYXeHGhSScA.MoveNext())
				{
					return false;
				}
				KeyValuePair<string, pwuYnGUQdkoptYJhlUHwWrVAmhEm> current = DnpcVcYWlXCxGKqXcHjYXeHGhSScA.Current;
				fcljMnInymDsItaegCCOfzYeMsCZB = new Field(current.Key, current.Value.huxeBJJtqYaGKOjgHCPTpwJPsSvz, current.Value.SbrWAGrdxtBDdhOrMNcNoGOprmlt, current.Value.aExhMtlRmxNkTOzsRPShXCqpBTLW);
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
				fcljMnInymDsItaegCCOfzYeMsCZB = default(Field);
				DnpcVcYWlXCxGKqXcHjYXeHGhSScA = eNPLqJVImAKHOREsEFHCjlDHttwV.GetEnumerator();
			}
		}

		private class YGakQkCHyEVBvzTypsuMztMYYIrc
		{
			public class bpZLNOckCaWeOxOtDDgLhmELTPzw
			{
				public readonly string FudUtkqBYseccocMRbtxdFmSMykUA;

				public readonly bpZLNOckCaWeOxOtDDgLhmELTPzw UgUVLegkMPxsobTNHkrcZkauZSUx;

				public string HIEHWAaRVMlpXVnsBeYmwOEojxCF;

				public Dictionary<string, string> xAfRabsoLQXBxspFWAeodXVgHspj;

				public List<bpZLNOckCaWeOxOtDDgLhmELTPzw> DOJjwIpvOQCuCabiHCscvHfbHwZh;

				public int xRhKtHZWTEdyJgVPRmFQuOEufPzv
				{
					get
					{
						if (DOJjwIpvOQCuCabiHCscvHfbHwZh == null)
						{
							return 0;
						}
						return DOJjwIpvOQCuCabiHCscvHfbHwZh.Count;
					}
				}

				public int ccGMJmoCTBhbwjshRtbgtkZQJulxA
				{
					get
					{
						if (xAfRabsoLQXBxspFWAeodXVgHspj == null)
						{
							return 0;
						}
						return xAfRabsoLQXBxspFWAeodXVgHspj.Count;
					}
				}

				public bpZLNOckCaWeOxOtDDgLhmELTPzw(string P_0, bpZLNOckCaWeOxOtDDgLhmELTPzw P_1)
				{
					FudUtkqBYseccocMRbtxdFmSMykUA = P_0;
					UgUVLegkMPxsobTNHkrcZkauZSUx = P_1;
					P_1?.KKireeqcJEGUnGZypOmoLPVGQGko(this);
				}

				public void KKireeqcJEGUnGZypOmoLPVGQGko(bpZLNOckCaWeOxOtDDgLhmELTPzw P_0)
				{
					if (P_0 != null)
					{
						if (DOJjwIpvOQCuCabiHCscvHfbHwZh == null)
						{
							DOJjwIpvOQCuCabiHCscvHfbHwZh = new List<bpZLNOckCaWeOxOtDDgLhmELTPzw>();
						}
						DOJjwIpvOQCuCabiHCscvHfbHwZh.Add(P_0);
					}
				}

				public void nllsMBDrWIEXrHjUxevFhnwfdtHjA(string P_0, string P_1)
				{
					if (!string.IsNullOrEmpty(P_0))
					{
						if (xAfRabsoLQXBxspFWAeodXVgHspj == null)
						{
							xAfRabsoLQXBxspFWAeodXVgHspj = new Dictionary<string, string>();
						}
						if (xAfRabsoLQXBxspFWAeodXVgHspj.ContainsKey(P_0))
						{
							xAfRabsoLQXBxspFWAeodXVgHspj[P_0] = P_1;
						}
						else
						{
							xAfRabsoLQXBxspFWAeodXVgHspj.Add(P_0, P_1);
						}
					}
				}

				public bool HUdWUCRHyTduBGJqnFimdPVloRpaA(string P_0)
				{
					return ArSssEFYxvDJwoxnxKjGrkPFipGiA(P_0) != null;
				}

				public bpZLNOckCaWeOxOtDDgLhmELTPzw ArSssEFYxvDJwoxnxKjGrkPFipGiA(string P_0)
				{
					if (xRhKtHZWTEdyJgVPRmFQuOEufPzv == 0)
					{
						return null;
					}
					for (int i = 0; i < DOJjwIpvOQCuCabiHCscvHfbHwZh.Count; i++)
					{
						if (string.Equals(DOJjwIpvOQCuCabiHCscvHfbHwZh[i].FudUtkqBYseccocMRbtxdFmSMykUA, P_0, StringComparison.Ordinal))
						{
							return DOJjwIpvOQCuCabiHCscvHfbHwZh[i];
						}
					}
					return null;
				}

				public object tBGAEViUQxmEhOkdiKDRPqdmPKmHA()
				{
					if (xRhKtHZWTEdyJgVPRmFQuOEufPzv == 0)
					{
						return HIEHWAaRVMlpXVnsBeYmwOEojxCF;
					}
					SerializedObject serializedObject = new SerializedObject(null, ObjectType.List);
					for (int i = 0; i < xRhKtHZWTEdyJgVPRmFQuOEufPzv; i++)
					{
						bpZLNOckCaWeOxOtDDgLhmELTPzw bpZLNOckCaWeOxOtDDgLhmELTPzw2 = DOJjwIpvOQCuCabiHCscvHfbHwZh[i];
						if (bpZLNOckCaWeOxOtDDgLhmELTPzw2 != null)
						{
							serializedObject.Add(bpZLNOckCaWeOxOtDDgLhmELTPzw2.FudUtkqBYseccocMRbtxdFmSMykUA, bpZLNOckCaWeOxOtDDgLhmELTPzw2.tBGAEViUQxmEhOkdiKDRPqdmPKmHA());
						}
					}
					return serializedObject;
				}

				public virtual string izEwzDqcVzaxmvXLMLERKmmFCqHT()
				{
					return RrXpNOfimiYoeinwsPMQpzxMFlNG("", 0);
				}

				private string RrXpNOfimiYoeinwsPMQpzxMFlNG(string P_0, int P_1)
				{
					string text = "";
					for (int i = 0; i < P_1; i++)
					{
						text += "    ";
					}
					P_0 = P_0 + text + "Name = " + FudUtkqBYseccocMRbtxdFmSMykUA + "\n";
					P_0 = P_0 + text + "Content = " + ((HIEHWAaRVMlpXVnsBeYmwOEojxCF == null) ? "NULL" : HIEHWAaRVMlpXVnsBeYmwOEojxCF.ToString()) + "\n";
					P_0 = P_0 + text + "Attribute Count = " + ccGMJmoCTBhbwjshRtbgtkZQJulxA + "\n";
					if (xAfRabsoLQXBxspFWAeodXVgHspj != null)
					{
						foreach (KeyValuePair<string, string> item in xAfRabsoLQXBxspFWAeodXVgHspj)
						{
							P_0 = P_0 + text + "Attribute " + item.Key + ": = " + item.Value + "\n";
						}
					}
					P_0 = P_0 + text + "Child Count = " + xRhKtHZWTEdyJgVPRmFQuOEufPzv + "\n";
					if (DOJjwIpvOQCuCabiHCscvHfbHwZh != null)
					{
						string text2 = "";
						foreach (bpZLNOckCaWeOxOtDDgLhmELTPzw item2 in DOJjwIpvOQCuCabiHCscvHfbHwZh)
						{
							text2 += "\n";
							text2 = item2.RrXpNOfimiYoeinwsPMQpzxMFlNG(text2, P_1 + 1);
						}
						P_0 += text2;
					}
					return P_0;
				}
			}

			private readonly bpZLNOckCaWeOxOtDDgLhmELTPzw cgRINWtTCLHNVjllLHQzzssvgQOgb;

			public bpZLNOckCaWeOxOtDDgLhmELTPzw DbKclVNzLmMorAgFRHpzAFIXheaCb => cgRINWtTCLHNVjllLHQzzssvgQOgb;

			public bool yqzMAMoqYggaBYFMiZzWcMmaAvFb => cgRINWtTCLHNVjllLHQzzssvgQOgb != null;

			public YGakQkCHyEVBvzTypsuMztMYYIrc(string P_0)
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
					cgRINWtTCLHNVjllLHQzzssvgQOgb = new bpZLNOckCaWeOxOtDDgLhmELTPzw("Root", null);
					nUugVFhrraZvjFKqyaKEZiJZDeLLA(xmlReader);
				}
				catch
				{
					cgRINWtTCLHNVjllLHQzzssvgQOgb = null;
				}
			}

			private void nUugVFhrraZvjFKqyaKEZiJZDeLLA(XmlReader P_0)
			{
				bpZLNOckCaWeOxOtDDgLhmELTPzw bpZLNOckCaWeOxOtDDgLhmELTPzw2 = cgRINWtTCLHNVjllLHQzzssvgQOgb;
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
							bpZLNOckCaWeOxOtDDgLhmELTPzw2 = new bpZLNOckCaWeOxOtDDgLhmELTPzw(P_0.LocalName, bpZLNOckCaWeOxOtDDgLhmELTPzw2);
							for (int i = 0; i < P_0.AttributeCount; i++)
							{
								P_0.MoveToNextAttribute();
								bpZLNOckCaWeOxOtDDgLhmELTPzw2.nllsMBDrWIEXrHjUxevFhnwfdtHjA(P_0.Name, P_0.Value);
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
							bpZLNOckCaWeOxOtDDgLhmELTPzw2.HIEHWAaRVMlpXVnsBeYmwOEojxCF = P_0.ReadContentAsString();
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
					if ((flag || P_0.NodeType == XmlNodeType.EndElement) && bpZLNOckCaWeOxOtDDgLhmELTPzw2 != null && bpZLNOckCaWeOxOtDDgLhmELTPzw2 != cgRINWtTCLHNVjllLHQzzssvgQOgb && P_0.Name == bpZLNOckCaWeOxOtDDgLhmELTPzw2.FudUtkqBYseccocMRbtxdFmSMykUA)
					{
						bpZLNOckCaWeOxOtDDgLhmELTPzw2 = bpZLNOckCaWeOxOtDDgLhmELTPzw2.UgUVLegkMPxsobTNHkrcZkauZSUx;
					}
					num++;
				}
			}

			public virtual string eMPQsJcoIhXAnxJnoPxdNDlxUHuN()
			{
				if (cgRINWtTCLHNVjllLHQzzssvgQOgb == null || cgRINWtTCLHNVjllLHQzzssvgQOgb.xRhKtHZWTEdyJgVPRmFQuOEufPzv == 0)
				{
					return "Document is empty.";
				}
				return cgRINWtTCLHNVjllLHQzzssvgQOgb.ToString();
			}
		}

		[Serializable]
		private sealed class SxiUkrFFHEPZQjPoRCMdwmRHvHsK
		{
			public static readonly SxiUkrFFHEPZQjPoRCMdwmRHvHsK _003C_003E9 = new SxiUkrFFHEPZQjPoRCMdwmRHvHsK();

			public static Func<FieldInfo, bool> _003C_003E9__63_0;

			public static Func<FieldInfo, string> _003C_003E9__63_1;

			public static Func<PropertyInfo, bool> _003C_003E9__63_2;

			public static Func<PropertyInfo, string> _003C_003E9__63_3;

			internal bool WWtTvEbkCHJQYNWGFAOqpnnvahRv(FieldInfo P_0)
			{
				if ((P_0.IsPublic || P_0.IsDefined(typeof(SerializeAttribute), inherit: true) || P_0.IsDefined(typeof(SerializeField), inherit: true)) && !P_0.IsDefined(typeof(NonSerializedAttribute), inherit: true))
				{
					return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
				}
				return false;
			}

			internal string hmhoPUdKLjNFhiMohjtZVbLMdBAz(FieldInfo P_0)
			{
				string name;
				if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
				{
					return name;
				}
				return P_0.Name;
			}

			internal bool JgPKQOGnxEvoLnnwrSoyMZpDhfNn(PropertyInfo P_0)
			{
				if (P_0.CanWrite && P_0.IsDefined(typeof(SerializeAttribute), inherit: true))
				{
					return !P_0.IsDefined(typeof(DoNotSerializeAttribute), inherit: true);
				}
				return false;
			}

			internal string dlTCWqcOVgEDfmyDroVzPsBGlMvH(PropertyInfo P_0)
			{
				string name;
				if (P_0.IsDefined(typeof(SerializeAttribute), inherit: true) && !string.IsNullOrEmpty(name = (CollectionTools.GetValue(P_0.GetCustomAttributes(typeof(SerializeAttribute), inherit: true), 0) as SerializeAttribute).Name))
				{
					return name;
				}
				return P_0.Name;
			}
		}

		private readonly IndexedDictionary<string, pwuYnGUQdkoptYJhlUHwWrVAmhEm> XuUMVWhPuaQNxiBNfIAKpjdPBrUFA;

		private XmlInfo HGcamjgygbkjFgYrRrpDNRIpTkVs;

		private Type NYEVHjNZpSIlGfOJsSjfpLotsIje;

		private ObjectType YgGdnpxtbYGyiZsycDoTCbEGlGiM;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> UoscRXJVRuYjRvtXmmdnIoXfvATHB = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> ZmbbrjQLUsICpFGVqnxWLbmvIUsu = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		private bool allowDuplicateKeys => YgGdnpxtbYGyiZsycDoTCbEGlGiM == ObjectType.List;

		public ObjectType objectType
		{
			get
			{
				return YgGdnpxtbYGyiZsycDoTCbEGlGiM;
			}
			set
			{
				if (value != YgGdnpxtbYGyiZsycDoTCbEGlGiM)
				{
					YgGdnpxtbYGyiZsycDoTCbEGlGiM = value;
					XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.AllowDuplicateKeys = allowDuplicateKeys;
				}
			}
		}

		public Type type => NYEVHjNZpSIlGfOJsSjfpLotsIje;

		public XmlInfo xmlInfo
		{
			get
			{
				return HGcamjgygbkjFgYrRrpDNRIpTkVs;
			}
			set
			{
				HGcamjgygbkjFgYrRrpDNRIpTkVs = value;
			}
		}

		public int count => XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Count;

		public Field this[int index]
		{
			get
			{
				pwuYnGUQdkoptYJhlUHwWrVAmhEm pwuYnGUQdkoptYJhlUHwWrVAmhEm2 = XuUMVWhPuaQNxiBNfIAKpjdPBrUFA[index];
				return new Field(XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.GetKeyAt(index), pwuYnGUQdkoptYJhlUHwWrVAmhEm2.huxeBJJtqYaGKOjgHCPTpwJPsSvz, pwuYnGUQdkoptYJhlUHwWrVAmhEm2.SbrWAGrdxtBDdhOrMNcNoGOprmlt, pwuYnGUQdkoptYJhlUHwWrVAmhEm2.aExhMtlRmxNkTOzsRPShXCqpBTLW);
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
			YgGdnpxtbYGyiZsycDoTCbEGlGiM = ObjectType.List;
			XuUMVWhPuaQNxiBNfIAKpjdPBrUFA = new IndexedDictionary<string, pwuYnGUQdkoptYJhlUHwWrVAmhEm>(P_0, true);
		}

		public SerializedObject(Type P_0, ObjectType P_1)
			: this(P_0, P_1, 0)
		{
		}

		public SerializedObject(Type P_0, ObjectType P_1, int P_2)
			: this(P_2)
		{
			NYEVHjNZpSIlGfOJsSjfpLotsIje = P_0;
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
				XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Add(item.Key, new pwuYnGUQdkoptYJhlUHwWrVAmhEm((item.Value != null) ? item.Value.GetType() : null, item.Value, FieldOptions.None));
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
				if (YgGdnpxtbYGyiZsycDoTCbEGlGiM != ObjectType.List)
				{
					throw new ArgumentNullException("fieldName");
				}
				fieldName = "value";
			}
			if (allowDuplicateKeys)
			{
				XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Add(fieldName, new pwuYnGUQdkoptYJhlUHwWrVAmhEm(type, value, options));
			}
			else if (!XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.ContainsKey(fieldName))
			{
				XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Add(fieldName, new pwuYnGUQdkoptYJhlUHwWrVAmhEm(type, value, options));
			}
			else
			{
				XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.SetValue(fieldName, new pwuYnGUQdkoptYJhlUHwWrVAmhEm(type, value, options));
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
			return XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Remove(fieldName);
		}

		public bool Contains(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			return XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.ContainsKey(fieldName);
		}

		public Type GetDataType(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return null;
			}
			if (!XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.TryGetValue(fieldName, out var value))
			{
				return null;
			}
			return value.SbrWAGrdxtBDdhOrMNcNoGOprmlt;
		}

		public bool TryGetOriginalValue(string fieldName, out object value)
		{
			value = null;
			if (string.IsNullOrEmpty(fieldName))
			{
				return false;
			}
			if (!XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.TryGetValue(fieldName, out var value2))
			{
				return false;
			}
			value = value2.huxeBJJtqYaGKOjgHCPTpwJPsSvz;
			return true;
		}

		public Field GetEntry(string fieldName)
		{
			KeyValuePair<string, pwuYnGUQdkoptYJhlUHwWrVAmhEm> entry = XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.GetEntry(fieldName);
			return new Field(entry.Key, entry.Value.huxeBJJtqYaGKOjgHCPTpwJPsSvz, entry.Value.SbrWAGrdxtBDdhOrMNcNoGOprmlt, entry.Value.aExhMtlRmxNkTOzsRPShXCqpBTLW);
		}

		public object GetOriginalValue(string fieldName)
		{
			return XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.GetEntry(fieldName).Value.huxeBJJtqYaGKOjgHCPTpwJPsSvz;
		}

		public object GetOriginalValue(int index)
		{
			return XuUMVWhPuaQNxiBNfIAKpjdPBrUFA[index].huxeBJJtqYaGKOjgHCPTpwJPsSvz;
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
			if (!XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.TryGetValue(fieldName, out var value2))
			{
				value = default(T);
				return false;
			}
			return wuVyCosmCjhICvHYIzwhMEWfCBiGA<T>(value2.huxeBJJtqYaGKOjgHCPTpwJPsSvz, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public bool TryGetDeserializedValue<T>(int index, out T value)
		{
			if ((uint)index > (uint)XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Count)
			{
				value = default(T);
				return false;
			}
			return wuVyCosmCjhICvHYIzwhMEWfCBiGA<T>(XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.GetEntryAt(index).Value.huxeBJJtqYaGKOjgHCPTpwJPsSvz, out value, NumberStyles.Any, CultureInfo.InvariantCulture);
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
			if ((uint)index > (uint)XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Count)
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
			if (HGcamjgygbkjFgYrRrpDNRIpTkVs == null)
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
				WrGYetoxhXHvckcwJRLYherGcFXh(xmlWriter);
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
			stringBuilder.Append((NYEVHjNZpSIlGfOJsSjfpLotsIje != null) ? NYEVHjNZpSIlGfOJsSjfpLotsIje.Name : "NULL\n");
			stringBuilder.Append("objectType = ");
			stringBuilder.Append(YgGdnpxtbYGyiZsycDoTCbEGlGiM.ToString());
			stringBuilder.Append("\n");
			stringBuilder.Append("xmlInfo = ");
			stringBuilder.Append((HGcamjgygbkjFgYrRrpDNRIpTkVs != null) ? HGcamjgygbkjFgYrRrpDNRIpTkVs.ToString() : "NULL\n");
			stringBuilder.Append("\n");
			for (int i = 0; i < XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Count; i++)
			{
				string keyAt = XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.GetKeyAt(i);
				stringBuilder.Append("key = ");
				stringBuilder.Append((keyAt != null) ? keyAt : "NULL");
				stringBuilder.Append(", value = ");
				stringBuilder.Append(XuUMVWhPuaQNxiBNfIAKpjdPBrUFA[i].ToString());
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}

		private void WrGYetoxhXHvckcwJRLYherGcFXh(XmlWriter P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writer");
			}
			P_0.WriteStartElement(type.Name, "http://guavaman.com/rewired");
			GYYfuUnHucYxaXAiRLRxJqkkgKVz(P_0);
			P_0.WriteEndElement();
		}

		private void GYYfuUnHucYxaXAiRLRxJqkkgKVz(XmlWriter P_0)
		{
			int num = ((xmlInfo != null) ? xmlInfo.attributes.Count : 0);
			for (int i = 0; i < num; i++)
			{
				XmlInfo.buLVqdRafoDJfbNswacdlzZIsivr buLVqdRafoDJfbNswacdlzZIsivr = xmlInfo.attributes[i];
				if (buLVqdRafoDJfbNswacdlzZIsivr is XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA)
				{
					XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA eqkbSPJHEHHtJoXsspdzqAzVcAQUA = buLVqdRafoDJfbNswacdlzZIsivr as XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA;
					if (!string.IsNullOrEmpty(eqkbSPJHEHHtJoXsspdzqAzVcAQUA.OehazIAPEcSENVTqpypPfkRtzKCK))
					{
						P_0.WriteAttributeString(eqkbSPJHEHHtJoXsspdzqAzVcAQUA.OehazIAPEcSENVTqpypPfkRtzKCK, eqkbSPJHEHHtJoXsspdzqAzVcAQUA.rzFSJcZEFOpFlXqzyhdFdwpOrpaJ, eqkbSPJHEHHtJoXsspdzqAzVcAQUA.FqpwTkyfXldoEdOuFQPgNddSWNnN, eqkbSPJHEHHtJoXsspdzqAzVcAQUA.sMgGiLjHAAIlXTFOzVTKBeTzOPUX);
					}
					else if (!string.IsNullOrEmpty(eqkbSPJHEHHtJoXsspdzqAzVcAQUA.FqpwTkyfXldoEdOuFQPgNddSWNnN))
					{
						P_0.WriteAttributeString(eqkbSPJHEHHtJoXsspdzqAzVcAQUA.rzFSJcZEFOpFlXqzyhdFdwpOrpaJ, eqkbSPJHEHHtJoXsspdzqAzVcAQUA.FqpwTkyfXldoEdOuFQPgNddSWNnN, eqkbSPJHEHHtJoXsspdzqAzVcAQUA.sMgGiLjHAAIlXTFOzVTKBeTzOPUX);
					}
					else
					{
						P_0.WriteAttributeString(eqkbSPJHEHHtJoXsspdzqAzVcAQUA.rzFSJcZEFOpFlXqzyhdFdwpOrpaJ, eqkbSPJHEHHtJoXsspdzqAzVcAQUA.sMgGiLjHAAIlXTFOzVTKBeTzOPUX);
					}
					continue;
				}
				throw new NotImplementedException();
			}
			for (int j = 0; j < count; j++)
			{
				pwuYnGUQdkoptYJhlUHwWrVAmhEm pwuYnGUQdkoptYJhlUHwWrVAmhEm2 = XuUMVWhPuaQNxiBNfIAKpjdPBrUFA[j];
				string text = XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.GetKeyAt(j);
				if ((pwuYnGUQdkoptYJhlUHwWrVAmhEm2.aExhMtlRmxNkTOzsRPShXCqpBTLW & FieldOptions.ExculdeFromXml) == 0)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = ((pwuYnGUQdkoptYJhlUHwWrVAmhEm2.SbrWAGrdxtBDdhOrMNcNoGOprmlt != null) ? pwuYnGUQdkoptYJhlUHwWrVAmhEm2.GetType().Name : ((pwuYnGUQdkoptYJhlUHwWrVAmhEm2.huxeBJJtqYaGKOjgHCPTpwJPsSvz == null) ? "value" : pwuYnGUQdkoptYJhlUHwWrVAmhEm2.huxeBJJtqYaGKOjgHCPTpwJPsSvz.GetType().Name));
					}
					SerializationTools.WriteXmlElement(P_0, text, pwuYnGUQdkoptYJhlUHwWrVAmhEm2.huxeBJJtqYaGKOjgHCPTpwJPsSvz);
				}
			}
		}

		private void xYBySbAXpktrWvWeefZcakOiHvyb(XmlWriter P_0)
		{
			WrGYetoxhXHvckcwJRLYherGcFXh(P_0);
		}

		void IExportToXml.WriteXml(XmlWriter P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xYBySbAXpktrWvWeefZcakOiHvyb
			this.xYBySbAXpktrWvWeefZcakOiHvyb(P_0);
		}

		private void tuyDvpgFINLoBpsvdZrSeIviEbkh(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("stringBuilder");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("appendValueDelegate");
			}
			int num = XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.Count;
			if (XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.ContainsDuplicateKeys)
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
					P_1(P_0, XuUMVWhPuaQNxiBNfIAKpjdPBrUFA[i].huxeBJJtqYaGKOjgHCPTpwJPsSvz);
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
				pwuYnGUQdkoptYJhlUHwWrVAmhEm pwuYnGUQdkoptYJhlUHwWrVAmhEm2 = XuUMVWhPuaQNxiBNfIAKpjdPBrUFA[j];
				string value = XuUMVWhPuaQNxiBNfIAKpjdPBrUFA.GetKeyAt(j);
				if (string.IsNullOrEmpty(value))
				{
					value = j.ToString();
				}
				P_0.Append('"');
				P_0.Append(value);
				P_0.Append("\":");
				P_1(P_0, pwuYnGUQdkoptYJhlUHwWrVAmhEm2.huxeBJJtqYaGKOjgHCPTpwJPsSvz);
			}
			P_0.Append('}');
		}

		void IExportToJson.WriteJson(StringBuilder P_0, Action<StringBuilder, object> P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in tuyDvpgFINLoBpsvdZrSeIviEbkh
			this.tuyDvpgFINLoBpsvdZrSeIviEbkh(P_0, P_1);
		}

		private void QuYIfFvhyefriHGnqsgYEUlDINhl(object P_0)
		{
			Add(null, P_0);
		}

		void IAddValue<object>.Add(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QuYIfFvhyefriHGnqsgYEUlDINhl
			this.QuYIfFvhyefriHGnqsgYEUlDINhl(P_0);
		}

		private void tcPANKrdicYScISlvXDfpKrJVeJc(string P_0, object P_1)
		{
			Add(P_0, P_1);
		}

		void IAddKeyValue<string, object>.Add(string P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in tcPANKrdicYScISlvXDfpKrJVeJc
			this.tcPANKrdicYScISlvXDfpKrJVeJc(P_0, P_1);
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return new Enumerator(XuUMVWhPuaQNxiBNfIAKpjdPBrUFA);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(XuUMVWhPuaQNxiBNfIAKpjdPBrUFA);
		}

		private static bool wuVyCosmCjhICvHYIzwhMEWfCBiGA<_0001>(object P_0, out _0001 P_1, NumberStyles P_2 = NumberStyles.Any, CultureInfo P_3 = null)
		{
			if (!NaNYpzKTmleeaFKsZOSEdLDAwTIk(typeof(_0001), P_0, out var obj, P_2, P_3))
			{
				P_1 = default(_0001);
				return false;
			}
			P_1 = (_0001)obj;
			return true;
		}

		private static bool NaNYpzKTmleeaFKsZOSEdLDAwTIk(Type P_0, object P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
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
					if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(ReflectionTools.GetUnderlyingEnumType(P_0), P_1, out var value, P_3, P_4))
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
								if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(elementType, serializedObject[i].value, out var value2, P_3, P_4))
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
								if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(elementType, readOnlyList[j], out var value3, P_3, P_4))
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
								if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(elementType, list[k], out var value4, P_3, P_4))
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
								if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(elementType, array4.GetValue(l), out var value5, P_3, P_4))
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
								if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(type2, value15, out var value6, P_3, P_4))
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
								if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(elementType, item, out var value7, P_3, P_4))
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
								if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(elementType, item3, out var value8, P_3, P_4))
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
									if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(type3, serializedObject2[m].value, out var value9, P_3, P_4))
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
									if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(type3, readOnlyList2[n], out var value10, P_3, P_4))
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
									if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(type3, list4[num5], out var value11, P_3, P_4))
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
									if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(type3, array9.GetValue(num6), out var value12, P_3, P_4))
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
									if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(type3, item4, out var value13, P_3, P_4))
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
								if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(type4, key2, out var key, P_3, P_4) && NaNYpzKTmleeaFKsZOSEdLDAwTIk(type5, dictionary2[key2], out var value14, P_3, P_4))
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
					if (!rgNdlEwVOWVSCDNrrpaEGInTbFzG(P_0, P_1 as SerializedObject, out P_1))
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

		private static bool rgNdlEwVOWVSCDNrrpaEGInTbFzG(Type P_0, SerializedObject P_1, out object P_2, NumberStyles P_3 = NumberStyles.Any, CultureInfo P_4 = null)
		{
			if (P_1 == null || P_0 == null)
			{
				P_2 = null;
				return false;
			}
			P_2 = Factory.CreateInstance(P_0);
			if (!UoscRXJVRuYjRvtXmmdnIoXfvATHB.TryGetValue(P_0, out var value))
			{
				value = ReflectionTools.GetFields(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(SxiUkrFFHEPZQjPoRCMdwmRHvHsK._003C_003E9.WWtTvEbkCHJQYNWGFAOqpnnvahRv).ToDictionary(SxiUkrFFHEPZQjPoRCMdwmRHvHsK._003C_003E9.hmhoPUdKLjNFhiMohjtZVbLMdBAz);
				UoscRXJVRuYjRvtXmmdnIoXfvATHB.Add(P_0, value);
			}
			if (!ZmbbrjQLUsICpFGVqnxWLbmvIUsu.TryGetValue(P_0, out var value2))
			{
				value2 = ReflectionTools.GetProperties(P_0, ReflectionTools.BindingFlags.Instance | ReflectionTools.BindingFlags.Public | ReflectionTools.BindingFlags.NonPublic).Where(SxiUkrFFHEPZQjPoRCMdwmRHvHsK._003C_003E9.JgPKQOGnxEvoLnnwrSoyMZpDhfNn).ToDictionary(SxiUkrFFHEPZQjPoRCMdwmRHvHsK._003C_003E9.dlTCWqcOVgEDfmyDroVzPsBGlMvH);
				ZmbbrjQLUsICpFGVqnxWLbmvIUsu.Add(P_0, value2);
			}
			foreach (Field item in (IEnumerable<Field>)P_1)
			{
				string name = item.name;
				object value3 = item.value;
				object value5;
				PropertyInfo value6;
				if (value.TryGetValue(name, out var value4))
				{
					if (NaNYpzKTmleeaFKsZOSEdLDAwTIk(value4.FieldType, value3, out value5, P_3, P_4))
					{
						value4.SetValue(P_2, value5);
					}
				}
				else if (value2.TryGetValue(name, out value6) && value6.CanWrite && NaNYpzKTmleeaFKsZOSEdLDAwTIk(value6.PropertyType, value3, out value5, P_3, P_4))
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
			YGakQkCHyEVBvzTypsuMztMYYIrc yGakQkCHyEVBvzTypsuMztMYYIrc = new YGakQkCHyEVBvzTypsuMztMYYIrc(xmlString);
			if (!yGakQkCHyEVBvzTypsuMztMYYIrc.yqzMAMoqYggaBYFMiZzWcMmaAvFb)
			{
				throw new Exception("Failed to parse XML string.");
			}
			if (yGakQkCHyEVBvzTypsuMztMYYIrc.DbKclVNzLmMorAgFRHpzAFIXheaCb.xRhKtHZWTEdyJgVPRmFQuOEufPzv == 0)
			{
				throw new Exception("No data found in XML string.");
			}
			if (!((yGakQkCHyEVBvzTypsuMztMYYIrc.DbKclVNzLmMorAgFRHpzAFIXheaCb.ArSssEFYxvDJwoxnxKjGrkPFipGiA(type.Name) ?? throw new Exception("Main element not found in XML string.")).tBGAEViUQxmEhOkdiKDRPqdmPKmHA() is SerializedObject { count: not 0 } serializedObject))
			{
				throw new Exception("No data found in XML string.");
			}
			return serializedObject;
		}
	}
}
