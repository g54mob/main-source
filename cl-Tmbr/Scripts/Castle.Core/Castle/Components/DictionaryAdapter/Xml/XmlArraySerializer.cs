using System;
using System.Collections;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlArraySerializer : XmlTypeSerializer
	{
		public static readonly XmlArraySerializer Instance = new XmlArraySerializer();

		public override XmlTypeKind Kind => XmlTypeKind.Collection;

		public override bool CanGetStub => true;

		protected XmlArraySerializer()
		{
		}

		public override object GetStub(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			return Array.CreateInstance(node.ClrType.GetElementType(), 0);
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			ArrayList arrayList = new ArrayList();
			Type elementType = node.ClrType.GetElementType();
			XmlReferenceManager references = XmlAdapter.For(parent).References;
			accessor.GetCollectionAccessor(elementType).GetCollectionItems(node, parent, references, arrayList);
			return arrayList.ToArray(elementType);
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			Array array = (Array)value;
			Array array2 = null;
			Array array3 = (Array)oldValue;
			Type elementType = array.GetType().GetElementType();
			IXmlCollectionAccessor collectionAccessor = accessor.GetCollectionAccessor(elementType);
			IXmlCursor xmlCursor = collectionAccessor.SelectCollectionItems(node, mutable: true);
			_ = collectionAccessor.Serializer;
			XmlReferenceManager references = XmlAdapter.For(parent).References;
			for (int i = 0; i < array.Length; i++)
			{
				object itemSafe = GetItemSafe(array3, i);
				object value2 = array.GetValue(i);
				object newValue = value2;
				collectionAccessor.SetValue(xmlCursor, parent, references, xmlCursor.MoveNext(), itemSafe, ref newValue);
				if (array2 != null)
				{
					array2.SetValue(newValue, i);
				}
				else if (!object.Equals(newValue, value2))
				{
					array2 = Array.CreateInstance(elementType, array.Length);
					Array.Copy(array, array2, i);
					array2.SetValue(newValue, i);
				}
			}
			xmlCursor.RemoveAllNext();
			if (array2 != null)
			{
				value = array2;
			}
		}

		private static object GetItemSafe(Array array, int index)
		{
			if (array == null || index < 0 || index >= array.Length)
			{
				return null;
			}
			return array.GetValue(index);
		}
	}
}
