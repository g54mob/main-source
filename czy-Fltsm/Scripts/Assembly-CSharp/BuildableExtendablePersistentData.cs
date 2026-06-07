using System;

[Serializable]
public abstract class BuildableExtendablePersistentData<T> : PersistentReference<T>, IBuildableExtendablePersistentData where T : IPersistentReference
{
	public BuildableExtendablePersistentData(T reference)
		: base(reference)
	{
	}

	public abstract void RestoreData(Buildable buildable);

	public virtual void RestoreReferences()
	{
	}

	public virtual void PopulateReferences()
	{
	}
}
