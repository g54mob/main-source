using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class XmlKnownTypeMapExtensions
	{
		public static IXmlKnownType Require(this IXmlKnownTypeMap map, Type clrType)
		{
			if (map.TryGet(clrType, out var knownType))
			{
				return knownType;
			}
			throw Error.NotXmlKnownType(clrType);
		}
	}
}
