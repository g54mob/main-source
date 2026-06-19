using Pug.Conversion;

public class CooldownConverter : SingleAuthoringComponentConverter<CooldownAuthoring>
{
	protected override void Convert(CooldownAuthoring authoring)
	{
		EntityMonoBehaviourData component = authoring.GetComponent<EntityMonoBehaviourData>();
		SyncedSharedCooldownType syncedSharedCooldownType;
		if (component != null)
		{
			PlayerController.GetCooldownTypeFromCooldownIdentifier(authoring.sharedCooldownIdentifier, component.objectInfo.objectType, component.objectInfo.objectID, out syncedSharedCooldownType);
		}
		else
		{
			ObjectAuthoring component2 = authoring.GetComponent<ObjectAuthoring>();
			PlayerController.GetCooldownTypeFromCooldownIdentifier(authoring.sharedCooldownIdentifier, component2.objectType, ObjectID.None, out syncedSharedCooldownType);
		}
		AddComponentData(new CooldownCD
		{
			cooldown = authoring.cooldown,
			syncedSharedCooldownType = syncedSharedCooldownType,
			casualCharacterIgnoresCustomCooldown = authoring.casualCharacterIgnoresCustomCooldown
		});
	}
}
