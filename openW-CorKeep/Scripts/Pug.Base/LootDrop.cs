using System;
using NaughtyAttributes;
using Pug.UnityExtensions;

[Serializable]
public struct LootDrop
{
	public ObjectID lootDropID;

	public int amount;

	public float multiplayerAmountAdditionScaling;

	public bool skipDropIfScanned;

	[ShowIf("skipDropIfScanned")]
	[AllowNesting]
	public ObjectID scanObjectID;

	public OptionalValue<DataBlockRef<ContentBundleDataBlock>> requiredContentBundle;
}
