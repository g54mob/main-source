public interface IBuildableExtendablePersistentData
{
	void Restore();

	void RestoreData(Buildable buildable);

	void RestoreReferences();

	void PopulateReferences();
}
