using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CraftingSelectorData))]
public class CraftingSelectorDataAllObjects : MonoBehaviour
{
	private void Start()
	{
		IEnumerable<ObjectIDCategory> subCategories = ObjectIDCategoryManager.SubCategories;
		List<ObjectID> list = new List<ObjectID>();
		foreach (ObjectIDCategory item in subCategories)
		{
			foreach (ObjectID objectId in item.ObjectIds)
			{
				list.Add(objectId);
			}
		}
		AddAllObjects(list);
	}

	private void AddAllObjects(List<ObjectID> objectIdsInCategories)
	{
		CraftingSelectorData component = GetComponent<CraftingSelectorData>();
		HashSet<ObjectID> hashSet = new HashSet<ObjectID>();
		foreach (ObjectID objectIdsInCategory in objectIdsInCategories)
		{
			hashSet.Add(objectIdsInCategory);
		}
		component.allObjects.Clear();
		foreach (IEntityMonoBehaviourData entityMonobehaviour in PugDatabase.entityMonobehaviours)
		{
			ObjectInfo objectInfo = entityMonobehaviour.ObjectInfo;
			if (hashSet.Contains(objectInfo.objectID) && (objectInfo.variation == 0 || objectInfo.objectID == ObjectID.Bucket || (objectInfo.objectID == ObjectID.LargeAncientDestructible && objectInfo.variation <= 5) || objectInfo.objectID == ObjectID.LargeCityDestructible || objectInfo.objectID == ObjectID.LargeMoldDestructible || objectInfo.objectID == ObjectID.LargeJellyfishDestructable || objectInfo.objectID == ObjectID.LargeDesertDestructible || objectInfo.objectID == ObjectID.WoodenDestructible || objectInfo.objectID == ObjectID.NatureWoodenDestructible || objectInfo.objectID == ObjectID.SeaWoodenDestructible || objectInfo.objectID == ObjectID.LavaWoodenDestructible || objectInfo.objectID == ObjectID.LargeDesertTempleDestructible || objectInfo.objectID == ObjectID.HiveDestructible || objectInfo.objectID == ObjectID.LargeMoldDestructible || objectInfo.objectID == ObjectID.NatureDestructible || objectInfo.objectID == ObjectID.GreenLargeDesertDestructible || objectInfo.objectID == ObjectID.LargeAlienTechDestructible || objectInfo.objectID == ObjectID.Stalagmite || objectInfo.objectID == ObjectID.AFWoodenDestructible || (objectInfo.objectID == ObjectID.Larva && objectInfo.variation <= 1) || (objectInfo.objectID == ObjectID.BigLarva && objectInfo.variation <= 1)) && !objectInfo.isCustomScenePrefab)
			{
				ObjectDataCD objectDataCD = new ObjectDataCD
				{
					objectID = objectInfo.objectID,
					amount = 1,
					variation = objectInfo.variation
				};
				component.allObjects.Add(objectDataCD);
			}
		}
		Dictionary<ObjectID, int> idToIndex = new Dictionary<ObjectID, int>();
		for (int i = 0; i < objectIdsInCategories.Count; i++)
		{
			idToIndex[objectIdsInCategories[i]] = i;
		}
		component.allObjects.Sort(delegate(ObjectData a, ObjectData b)
		{
			int num = idToIndex[a.objectID];
			int value = idToIndex[b.objectID];
			int num2 = num.CompareTo(value);
			return (num2 != 0) ? num2 : a.variation.CompareTo(b.variation);
		});
	}
}
