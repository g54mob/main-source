using System;

namespace UI.Xml
{
	[Serializable]
	public class DefaultAttributeValueDictionary : SerializableDictionary<string, ClassAttributeCollectionDictionary>
	{
		public DefaultAttributeValueDictionary()
		{
			_Comparer = StringComparer.OrdinalIgnoreCase;
		}
	}
}
