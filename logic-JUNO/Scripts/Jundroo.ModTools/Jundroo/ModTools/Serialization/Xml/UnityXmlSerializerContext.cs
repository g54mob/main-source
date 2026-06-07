namespace Jundroo.ModTools.Serialization.Xml
{
	public class UnityXmlSerializerContext
	{
		public bool IgnoreUnderscorePrefix { get; set; }

		public XmlSerializationFlags MemberSerializationOptions { get; set; }

		public bool SaveTypeInfo { get; set; }

		public UnityXmlSerializer Serializer { get; internal set; }

		public UnityXmlSerializerContext()
		{
			SaveTypeInfo = false;
		}

		public UnityXmlSerializerContext(bool saveTypeInfo, bool ignoreUnderscorePrefix)
		{
			SaveTypeInfo = saveTypeInfo;
			IgnoreUnderscorePrefix = ignoreUnderscorePrefix;
		}
	}
}
