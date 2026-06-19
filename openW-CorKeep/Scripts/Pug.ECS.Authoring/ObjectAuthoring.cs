using System.Collections.Generic;
using Pug.Conversion;
using PugMod;
using UnityEngine;

public class ObjectAuthoring : MonoBehaviour, IEntityMonoBehaviourData, IPreferredObjectIndex
{
	public string objectName;

	public int initialAmount = 1;

	public int variation;

	public bool variationIsDynamic;

	public int variationToToggleTo;

	public ObjectType objectType;

	public List<ObjectCategoryTag> tags;

	public Rarity rarity;

	public float salvageMultiplier = 1f;

	public GameObject graphicalPrefab;

	[HideInInspector]
	public bool isCustomScenePrefab;

	public List<Sprite> additionalSprites;

	public GameObject GameObject => base.gameObject;

	public Transform Transform => base.transform;

	public ObjectInfo ObjectInfo => ObjectAuthoringToObjectInfo(this);

	public bool TryGetPreferredObjectIndex(out int objectIndex)
	{
		objectIndex = 0;
		ObjectInfo objectInfo = ObjectAuthoringToObjectInfo(this);
		if (objectInfo == null || objectInfo.objectID == ObjectID.None)
		{
			return false;
		}
		objectIndex = (int)objectInfo.objectID;
		return true;
	}

	private static ObjectInfo ObjectAuthoringToObjectInfo(ObjectAuthoring objectAuthoring)
	{
		MonoBehaviour prefab = ((objectAuthoring.graphicalPrefab == null) ? null : ((MonoBehaviour)objectAuthoring.graphicalPrefab.GetComponent(typeof(MonoBehaviour))));
		ObjectInfo objectInfo = new ObjectInfo
		{
			objectID = API.Authoring.GetObjectID(objectAuthoring.objectName),
			initialAmount = objectAuthoring.initialAmount,
			variation = objectAuthoring.variation,
			variationIsDynamic = objectAuthoring.variationIsDynamic,
			variationToToggleTo = objectAuthoring.variationToToggleTo,
			objectType = objectAuthoring.objectType,
			tags = objectAuthoring.tags,
			rarity = objectAuthoring.rarity,
			salvageMultiplier = objectAuthoring.salvageMultiplier,
			prefabInfos = new List<PrefabInfo>
			{
				new PrefabInfo
				{
					ecsPrefab = objectAuthoring.gameObject,
					prefab = prefab
				}
			},
			isCustomScenePrefab = objectAuthoring.isCustomScenePrefab,
			additionalSprites = objectAuthoring.additionalSprites,
			sellValue = -1,
			buyValueMultiplier = 1f,
			requiredObjectsToCraft = new List<CraftingObject>()
		};
		PlaceableObjectAuthoring component = objectAuthoring.GetComponent<PlaceableObjectAuthoring>();
		if (component != null)
		{
			objectInfo.prefabTileSize = component.prefabTileSize;
			objectInfo.prefabCornerOffset = component.prefabCornerOffset;
			objectInfo.centerIsAtEntityPosition = component.centerIsAtEntityPosition;
			objectInfo.appearInMapUI = component.appearInMapUI;
			objectInfo.mapColor = component.mapColor;
		}
		InventoryItemAuthoring component2 = objectAuthoring.GetComponent<InventoryItemAuthoring>();
		if (component2 != null)
		{
			objectInfo.sellValue = component2.sellValue;
			objectInfo.buyValueMultiplier = component2.buyValueMultiplier;
			objectInfo.icon = component2.icon;
			objectInfo.iconOffset = component2.iconOffset;
			objectInfo.smallIcon = component2.smallIcon;
			objectInfo.isStackable = component2.isStackable;
			objectInfo.craftingSettings = default(CraftingSettings);
			foreach (InventoryItemAuthoring.CraftingObject item in component2.requiredObjectsToCraft)
			{
				objectInfo.requiredObjectsToCraft.Add(new CraftingObject
				{
					objectID = API.Authoring.GetObjectID(item.objectName),
					amount = item.amount
				});
			}
			objectInfo.craftingTime = component2.craftingTime;
		}
		LocalizationAuthoring component3 = objectAuthoring.GetComponent<LocalizationAuthoring>();
		if (component3 != null)
		{
			objectInfo.languageGenders = component3.languageGenders;
		}
		TileAuthoring component4 = objectAuthoring.GetComponent<TileAuthoring>();
		if (component4 != null)
		{
			objectInfo.tileset = (int)component4.tileset;
			objectInfo.tileType = component4.tileType;
		}
		return objectInfo;
	}
}
