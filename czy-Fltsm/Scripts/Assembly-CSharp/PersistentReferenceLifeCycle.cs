public class PersistentReferenceLifeCycle<T> : IPersistentReferenceLifeCycle where T : IPersistentReference
{
	public void OnPrePersistenceAction()
	{
		PersistentReference<T>.OnPrePersistenceOperation();
	}

	public void OnPostPersistenceAction()
	{
		PersistentReference<T>.OnPostPersistenceOperation();
	}
}
