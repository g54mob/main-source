using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

[DisallowMultipleComponent]
public class ChangeVariationWhenContainingObjectAuthoring : MonoBehaviour
{
	public ObjectID objectID;

	public int variationToChangeTo;

	public bool alsoRemoveCollider;

	public ObjectID reinstantiateToNewObjectId;

	public LootTableID addLootFromTableToNewObject;

	public EffectID playEffectOnReinstantiate;

	[ArrayElementTitle("objectID")]
	public List<ObjectData> addItemsToNewObject;
}
