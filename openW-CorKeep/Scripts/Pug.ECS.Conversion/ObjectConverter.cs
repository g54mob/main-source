using Pug.Conversion;
using PugMod;
using UnityEngine;

public class ObjectConverter : SingleAuthoringComponentConverter<ObjectAuthoring>
{
	protected override void Convert(ObjectAuthoring authoring)
	{
		if (Application.isPlaying)
		{
			Manager.mod.Authoring.ObjectIDLookup.TryAdd(authoring.objectName, (ObjectID)base.ObjectIndex);
		}
		if (authoring.variation == 0 && authoring.GetComponent<CustomScenePrefabAuthoring>() == null)
		{
			base.PropertiesBuilder.SetPropertyString(base.ObjectIndex, "name", authoring.objectName);
		}
		EnsureHasComponent<IsObjectCD>();
		AddComponentData(new ObjectDataCD
		{
			objectID = (ObjectID)base.ObjectIndex,
			variation = authoring.variation,
			amount = authoring.initialAmount
		});
		if (!TryGetActiveComponent<DontSerializeAuthoring>(authoring, out var _))
		{
			EnsureHasChunkComponent<SerializedChunkData>();
		}
		AddComponentData(new ObjectCategoryTagsCD
		{
			tagsBitMask = ObjectCategoryTagsCD.ConvertToBitMask(authoring.tags)
		});
		ObjectType objectType = authoring.objectType;
		if (objectType == ObjectType.Creature || objectType == ObjectType.Critter)
		{
			EnsureHasComponent<DistanceToPlayerCD>();
			EnsureHasComponent<SeparateIfStuckCD>();
		}
		if (TryGetActiveComponent<LocalizationAuthoring>(authoring, out var component2))
		{
			base.PropertiesBuilder.SetPropertyString(base.ObjectIndex, "termKey", component2.termKey);
		}
	}
}
