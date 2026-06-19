using Pug.Conversion;
using PugMod;
using UnityEngine;

public class EntityMonoBehaviourDataConverter : SingleAuthoringComponentConverter<EntityMonoBehaviourData>
{
	protected override void Convert(EntityMonoBehaviourData authoring)
	{
		string text = authoring.objectInfo.objectID.ToString();
		if (Application.isPlaying)
		{
			Manager.mod.Authoring.ObjectIDLookup.TryAdd(text, authoring.objectInfo.objectID);
		}
		if (authoring.objectInfo.variation == 0 && authoring.GetComponent<CustomScenePrefabAuthoring>() == null)
		{
			if (base.PropertiesBuilder.HasProperty(base.ObjectIndex, "name"))
			{
				Debug.LogError("trying to set name " + text + " twice (duplicate objectID?)");
			}
			else
			{
				base.PropertiesBuilder.SetPropertyString(base.ObjectIndex, "name", text);
			}
		}
		EnsureHasComponent<IsObjectCD>();
		AddComponentData(new ObjectDataCD
		{
			objectID = authoring.objectInfo.objectID,
			variation = authoring.objectInfo.variation,
			amount = authoring.objectInfo.initialAmount
		});
		AddComponentData(new ObjectCategoryTagsCD
		{
			tagsBitMask = ObjectCategoryTagsCD.ConvertToBitMask(authoring.objectInfo.tags)
		});
		AddComponentData(new ObjectTypeCD
		{
			Value = authoring.objectInfo.objectType
		});
		if (!TryGetActiveComponent<DontSerializeAuthoring>(authoring, out var _))
		{
			EnsureHasChunkComponent<SerializedChunkData>();
		}
		ObjectType objectType = authoring.objectInfo.objectType;
		if (objectType == ObjectType.Creature || objectType == ObjectType.Critter)
		{
			EnsureHasComponent<DistanceToPlayerCD>();
			EnsureHasComponent<SeparateIfStuckCD>();
		}
	}
}
