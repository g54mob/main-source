using System;
using Pug.UnityExtensions;

[Serializable]
public struct InitialInventoryItem
{
	public OptionalValue<DataBlockAddress> requiredContentBundle;

	public ObjectData item;
}
