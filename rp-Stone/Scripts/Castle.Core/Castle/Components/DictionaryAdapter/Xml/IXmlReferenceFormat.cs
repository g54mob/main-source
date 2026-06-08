namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IXmlReferenceFormat
	{
		bool TryGetIdentity(IXmlNode node, out int id);

		bool TryGetReference(IXmlNode node, out int id);

		void SetIdentity(IXmlNode node, int id);

		void SetReference(IXmlNode node, int id);

		void ClearIdentity(IXmlNode node);

		void ClearReference(IXmlNode node);
	}
}
