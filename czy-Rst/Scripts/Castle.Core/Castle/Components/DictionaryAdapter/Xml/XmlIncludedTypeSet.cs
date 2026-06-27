using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlIncludedTypeSet : IXmlIncludedTypeMap, IEnumerable<IXmlIncludedType>, IEnumerable
	{
		private readonly Dictionary<XmlName, IXmlIncludedType> itemsByXsiType;

		private readonly Dictionary<Type, IXmlIncludedType> itemsByClrType;

		public static readonly IList<IXmlIncludedType> DefaultEntries = Array.AsReadOnly(new IXmlIncludedType[20]
		{
			new XmlIncludedType("anyType", "http://www.w3.org/2001/XMLSchema", typeof(object)),
			new XmlIncludedType("string", "http://www.w3.org/2001/XMLSchema", typeof(string)),
			new XmlIncludedType("boolean", "http://www.w3.org/2001/XMLSchema", typeof(bool)),
			new XmlIncludedType("byte", "http://www.w3.org/2001/XMLSchema", typeof(sbyte)),
			new XmlIncludedType("unsignedByte", "http://www.w3.org/2001/XMLSchema", typeof(byte)),
			new XmlIncludedType("short", "http://www.w3.org/2001/XMLSchema", typeof(short)),
			new XmlIncludedType("unsignedShort", "http://www.w3.org/2001/XMLSchema", typeof(ushort)),
			new XmlIncludedType("int", "http://www.w3.org/2001/XMLSchema", typeof(int)),
			new XmlIncludedType("unsignedInt", "http://www.w3.org/2001/XMLSchema", typeof(uint)),
			new XmlIncludedType("long", "http://www.w3.org/2001/XMLSchema", typeof(long)),
			new XmlIncludedType("unsignedLong", "http://www.w3.org/2001/XMLSchema", typeof(ulong)),
			new XmlIncludedType("float", "http://www.w3.org/2001/XMLSchema", typeof(float)),
			new XmlIncludedType("double", "http://www.w3.org/2001/XMLSchema", typeof(double)),
			new XmlIncludedType("decimal", "http://www.w3.org/2001/XMLSchema", typeof(decimal)),
			new XmlIncludedType("guid", "http://microsoft.com/wsdl/types/", typeof(Guid)),
			new XmlIncludedType("dateTime", "http://www.w3.org/2001/XMLSchema", typeof(DateTime)),
			new XmlIncludedType("duration", "http://www.w3.org/2001/XMLSchema", typeof(TimeSpan)),
			new XmlIncludedType("base64Binary", "http://www.w3.org/2001/XMLSchema", typeof(byte[])),
			new XmlIncludedType("anyURI", "http://www.w3.org/2001/XMLSchema", typeof(Uri)),
			new XmlIncludedType("QName", "http://www.w3.org/2001/XMLSchema", typeof(XmlQualifiedName))
		});

		IXmlIncludedType IXmlIncludedTypeMap.Default
		{
			get
			{
				throw Error.NoDefaultKnownType();
			}
		}

		public XmlIncludedTypeSet()
		{
			itemsByXsiType = new Dictionary<XmlName, IXmlIncludedType>();
			itemsByClrType = new Dictionary<Type, IXmlIncludedType>();
			foreach (IXmlIncludedType defaultEntry in DefaultEntries)
			{
				Add(defaultEntry);
			}
		}

		public void Add(IXmlIncludedType includedType)
		{
			itemsByXsiType.Add(includedType.XsiType, includedType);
			itemsByClrType[includedType.ClrType] = includedType;
		}

		public bool TryGet(XmlName xsiType, out IXmlIncludedType includedType)
		{
			return itemsByXsiType.TryGetValue(xsiType, out includedType);
		}

		public bool TryGet(Type clrType, out IXmlIncludedType includedType)
		{
			return itemsByClrType.TryGetValue(clrType, out includedType);
		}

		public IEnumerator<IXmlIncludedType> GetEnumerator()
		{
			return itemsByXsiType.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
