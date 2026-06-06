public interface IDecoBehaviourPersistentData
{
	void Restore(IDecorationBehaviour behaviour, DecorationProperties decorationProperties);

	void RestoreReferences()
	{
	}

	void PopulateReferences()
	{
	}
}
