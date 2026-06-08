using System;
using System.Globalization;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public sealed class DefaultXmlReferenceFormat : IXmlReferenceFormat
	{
		public static readonly DefaultXmlReferenceFormat Instance = new DefaultXmlReferenceFormat();

		private const NumberStyles IntegerStyle = NumberStyles.Integer;

		private static readonly IFormatProvider Culture = CultureInfo.InvariantCulture;

		private DefaultXmlReferenceFormat()
		{
		}

		public bool TryGetIdentity(IXmlNode node, out int id)
		{
			return int.TryParse(node.GetAttribute(XRef.Id), NumberStyles.Integer, Culture, out id);
		}

		public bool TryGetReference(IXmlNode node, out int id)
		{
			return int.TryParse(node.GetAttribute(XRef.Ref), NumberStyles.Integer, Culture, out id);
		}

		public void SetIdentity(IXmlNode node, int id)
		{
			node.SetAttribute(XRef.Id, id.ToString(Culture));
		}

		public void SetReference(IXmlNode node, int id)
		{
			node.SetAttribute(XRef.Ref, id.ToString(Culture));
		}

		public void ClearIdentity(IXmlNode node)
		{
			node.SetAttribute(XRef.Id, null);
		}

		public void ClearReference(IXmlNode node)
		{
			node.SetAttribute(XRef.Ref, null);
		}
	}
}
