public class Structure
{
	public static EntityId ToId(StructureType s)
	{
		return new EntityId((int)s, EntityType.Structure);
	}
}
