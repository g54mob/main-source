using System;

namespace JetBrains.Annotations;

internal sealed class CollectionAccessAttribute(CollectionAccessType collectionAccessType) : Attribute
{
	private CollectionAccessType _003CCollectionAccessType_003Ek__BackingField = collectionAccessType;

	public CollectionAccessType CollectionAccessType
	{
		get
		{
			return _003CCollectionAccessType_003Ek__BackingField;
		}
		private set
		{
			_003CCollectionAccessType_003Ek__BackingField = value;
		}
	}
}
