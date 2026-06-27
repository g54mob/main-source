using System;
using System.Collections;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public abstract class XmlCollectionSerializer : XmlTypeSerializer
	{
		public override XmlTypeKind Kind => XmlTypeKind.Collection;

		public override bool CanGetStub => true;

		public abstract Type ListTypeConstructor { get; }

		public override object GetStub(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			return GetValueCore(node, parent, accessor);
		}

		public override object GetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			return GetValueCore(node.Save(), parent, accessor);
		}

		private object GetValueCore(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor)
		{
			Type type = node.ClrType.GetGenericArguments()[0];
			Type type2 = ListTypeConstructor.MakeGenericType(type);
			IXmlCollectionAccessor collectionAccessor = accessor.GetCollectionAccessor(type);
			return Activator.CreateInstance(type2, node, parent, collectionAccessor);
		}

		public override void SetValue(IXmlNode node, IDictionaryAdapter parent, IXmlAccessor accessor, object oldValue, ref object value)
		{
			if (!(value is IXmlNodeSource xmlNodeSource) || !xmlNodeSource.Node.PositionEquals(node))
			{
				if (!(value is IEnumerable source))
				{
					throw Error.NotSupported();
				}
				if (oldValue is ICollectionProjection collectionProjection)
				{
					collectionProjection.ClearReferences();
				}
				ICollectionProjection collectionProjection2 = (ICollectionProjection)GetValue(node, parent, accessor);
				collectionProjection2.Replace(source);
				value = collectionProjection2;
			}
		}
	}
}
