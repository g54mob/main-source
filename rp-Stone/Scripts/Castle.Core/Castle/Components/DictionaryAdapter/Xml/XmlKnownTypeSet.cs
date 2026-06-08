using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlKnownTypeSet : IXmlKnownTypeMap, IEnumerable<IXmlKnownType>, IEnumerable
	{
		private sealed class XmlIdentityComparer : IEqualityComparer<IXmlIdentity>
		{
			public static readonly XmlIdentityComparer Instance = new XmlIdentityComparer();

			private XmlIdentityComparer()
			{
			}

			public bool Equals(IXmlIdentity x, IXmlIdentity y)
			{
				XmlName name = x.Name;
				XmlName name2 = y.Name;
				if (!NameComparer.Equals(name.LocalName, name2.LocalName))
				{
					return false;
				}
				if (!XsiTypeComparer.Equals(x.XsiType, y.XsiType))
				{
					return false;
				}
				if (name.NamespaceUri != null && name2.NamespaceUri != null)
				{
					return NameComparer.Equals(name.NamespaceUri, name2.NamespaceUri);
				}
				return true;
			}

			public int GetHashCode(IXmlIdentity name)
			{
				int num = NameComparer.GetHashCode(name.Name.LocalName);
				if (name.XsiType != XmlName.Empty)
				{
					num = ((num << 7) | (num >> 25)) ^ XsiTypeComparer.GetHashCode(name.XsiType);
				}
				return num;
			}
		}

		private sealed class XmlKnownTypeNameComparer : IEqualityComparer<IXmlKnownType>
		{
			public static readonly XmlKnownTypeNameComparer Instance = new XmlKnownTypeNameComparer();

			private XmlKnownTypeNameComparer()
			{
			}

			public bool Equals(IXmlKnownType knownTypeA, IXmlKnownType knownTypeB)
			{
				return XmlNameComparer.IgnoreCase.Equals(knownTypeA.Name, knownTypeB.Name);
			}

			public int GetHashCode(IXmlKnownType knownType)
			{
				return XmlNameComparer.IgnoreCase.GetHashCode(knownType.Name);
			}
		}

		private readonly Dictionary<IXmlIdentity, IXmlKnownType> itemsByXmlIdentity;

		private readonly Dictionary<Type, IXmlKnownType> itemsByClrType;

		private readonly Type defaultType;

		private static readonly StringComparer NameComparer = StringComparer.OrdinalIgnoreCase;

		private static readonly XmlNameComparer XsiTypeComparer = XmlNameComparer.Default;

		public IXmlKnownType Default
		{
			get
			{
				if (defaultType == null || !TryGet(defaultType, out var knownType))
				{
					throw Error.NoDefaultKnownType();
				}
				return knownType;
			}
		}

		public XmlKnownTypeSet(Type defaultType)
		{
			if (defaultType == null)
			{
				throw Error.ArgumentNull("defaultType");
			}
			itemsByXmlIdentity = new Dictionary<IXmlIdentity, IXmlKnownType>(XmlIdentityComparer.Instance);
			itemsByClrType = new Dictionary<Type, IXmlKnownType>();
			this.defaultType = defaultType;
		}

		public void Add(IXmlKnownType knownType, bool overwrite)
		{
			if (overwrite || !itemsByXmlIdentity.ContainsKey(knownType))
			{
				itemsByXmlIdentity[knownType] = knownType;
			}
			Type clrType = knownType.ClrType;
			if (overwrite || !itemsByClrType.ContainsKey(clrType))
			{
				itemsByClrType[clrType] = knownType;
			}
		}

		public void AddXsiTypeDefaults()
		{
			Dictionary<IXmlKnownType, bool> dictionary = new Dictionary<IXmlKnownType, bool>(itemsByXmlIdentity.Count, XmlKnownTypeNameComparer.Instance);
			foreach (IXmlKnownType value2 in itemsByXmlIdentity.Values)
			{
				dictionary[value2] = !dictionary.TryGetValue(value2, out var _) && value2.XsiType != XmlName.Empty;
			}
			foreach (KeyValuePair<IXmlKnownType, bool> item in dictionary)
			{
				if (item.Value)
				{
					IXmlKnownType key = item.Key;
					XmlKnownType knownType = new XmlKnownType(key.Name, XmlName.Empty, key.ClrType);
					Add(knownType, overwrite: true);
				}
			}
		}

		public bool TryGet(IXmlIdentity xmlIdentity, out IXmlKnownType knownType)
		{
			return itemsByXmlIdentity.TryGetValue(xmlIdentity, out knownType);
		}

		public bool TryGet(Type clrType, out IXmlKnownType knownType)
		{
			return itemsByClrType.TryGetValue(clrType, out knownType);
		}

		public IXmlKnownType[] ToArray()
		{
			return itemsByXmlIdentity.Values.ToArray();
		}

		public IEnumerator<IXmlKnownType> GetEnumerator()
		{
			return itemsByXmlIdentity.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return itemsByXmlIdentity.Values.GetEnumerator();
		}
	}
}
