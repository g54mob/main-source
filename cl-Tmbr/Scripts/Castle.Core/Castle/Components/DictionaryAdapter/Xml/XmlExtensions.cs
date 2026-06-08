using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	internal static class XmlExtensions
	{
		public static bool PositionEquals(this IXmlNode nodeA, IXmlNode nodeB)
		{
			return XmlPositionComparer.Instance.Equals(nodeA, nodeB);
		}

		public static void CopyTo(this IXmlNode source, IXmlNode target)
		{
			using XmlReader xmlReader = source.ReadSubtree();
			if (!xmlReader.Read())
			{
				return;
			}
			using (XmlWriter xmlWriter = target.WriteAttributes())
			{
				xmlWriter.WriteAttributes(xmlReader, defattr: false);
			}
			if (!xmlReader.Read())
			{
				return;
			}
			using XmlWriter xmlWriter2 = target.WriteChildren();
			do
			{
				xmlWriter2.WriteNode(xmlReader, defattr: false);
			}
			while (!xmlReader.EOF && xmlReader.NodeType != XmlNodeType.EndElement);
		}
	}
}
