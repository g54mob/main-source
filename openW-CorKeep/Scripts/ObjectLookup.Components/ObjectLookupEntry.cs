using Unity.Entities;

public struct ObjectLookupEntry
{
	public ObjectID objectId;

	public Entity optionalEntityIfLoaded;
}
