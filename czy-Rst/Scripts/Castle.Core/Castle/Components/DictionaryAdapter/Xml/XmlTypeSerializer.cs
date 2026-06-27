using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public abstract class XmlTypeSerializer
	{
		public abstract XmlTypeKind Kind { get; }

		public virtual bool CanGetStub => false;

		public virtual object GetStub(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			throw Error.NotSupported();
		}

		public abstract object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor);

		public abstract void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value);

		public static XmlTypeSerializer For(Type type)
		{
			return XmlTypeSerializerCache.Instance[type];
		}
	}
}
