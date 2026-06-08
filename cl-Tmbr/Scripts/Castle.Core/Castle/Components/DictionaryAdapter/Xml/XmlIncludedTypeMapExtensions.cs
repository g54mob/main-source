using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class XmlIncludedTypeMapExtensions
	{
		public static IXmlIncludedType Require(this IXmlIncludedTypeMap includedTypes, Type clrType)
		{
			if (includedTypes.TryGet(clrType, out var includedType))
			{
				return includedType;
			}
			throw Error.NotXmlKnownType(clrType);
		}
	}
}
