using Pug.Conversion;
using UnityEngine;

public class ChangeVariationWhenContainingObjectConverter : SingleAuthoringComponentConverter<ChangeVariationWhenContainingObjectAuthoring>
{
	protected override void Convert(ChangeVariationWhenContainingObjectAuthoring authoring)
	{
		if (authoring.addItemsToNewObject.Count > 0)
		{
			EnsureHasBuffer<ItemsToAddToNewObjectBuffer>();
			foreach (ObjectData item in authoring.addItemsToNewObject)
			{
				int amount = item.amount;
				if (item.objectID == ObjectID.None)
				{
					amount = 0;
				}
				else
				{
					ObjectInfo objectInfo = PugDatabase.GetObjectInfo(item.objectID, item.variation);
					if (objectInfo == null)
					{
						Debug.LogError($"Object {item.objectID} {item.variation} in {authoring.name} not found in database");
						continue;
					}
					if (!objectInfo.isStackable)
					{
						amount = objectInfo.initialAmount;
					}
				}
				AddToBuffer(new ItemsToAddToNewObjectBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = item.objectID,
						variation = item.variation,
						amount = amount
					}
				});
			}
		}
		AddComponentData(new ChangeVariationWhenContainingObjectCD
		{
			objectID = authoring.objectID,
			variationToChangeTo = authoring.variationToChangeTo,
			alsoRemoveCollider = authoring.alsoRemoveCollider,
			reinstantiateToNewObjectId = authoring.reinstantiateToNewObjectId,
			addLootFromTableToNewObject = authoring.addLootFromTableToNewObject,
			playEffectOnReinstantiate = authoring.playEffectOnReinstantiate
		});
	}
}
