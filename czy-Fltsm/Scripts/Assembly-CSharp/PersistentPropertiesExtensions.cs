public static class PersistentPropertiesExtensions
{
	public static int GetPersistentIndex(this PersistentProperties persistentProperties)
	{
		if (persistentProperties == null)
		{
			return -1;
		}
		return persistentProperties.GetIndex();
	}

	public static bool TryGetPersistentIndex(this PersistentProperties persistentProperties, out int index)
	{
		index = -1;
		if (persistentProperties == null)
		{
			return false;
		}
		index = GameManager.PersistenceManager.ReturnPropertiesIndex(persistentProperties);
		return -1 < index;
	}
}
