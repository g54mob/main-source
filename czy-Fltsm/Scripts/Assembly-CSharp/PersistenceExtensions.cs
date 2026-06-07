public static class PersistenceExtensions
{
	public static bool IsNull<T>(this PersistentReference<T>.Reference reference) where T : IPersistentReference
	{
		if (reference != null)
		{
			return reference.PersistentIndex < 0;
		}
		return true;
	}

	public static bool TryReturn<T>(this PersistentReference<T>.Reference reference, out T instance) where T : IPersistentReference
	{
		if (reference == null)
		{
			instance = default(T);
			return false;
		}
		return reference.TryReturnInstance(out instance);
	}

	public static bool IsNull(this ProjectTargetPersistentData target)
	{
		if (target != null)
		{
			return target.PersistentIndex == -1;
		}
		return true;
	}
}
