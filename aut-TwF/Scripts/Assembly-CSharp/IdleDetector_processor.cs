using UnityEngine;

[RequireComponent(typeof(Processor))]
public class IdleDetector_processor : IdleDetector
{
	private Processor processor;

	private void Awake()
	{
		processor = GetComponent<Processor>();
	}

	protected override void Start()
	{
		base.Start();
		processor.InputStorage.onStoreObject += OnInputObjectStored;
		processor.InputStorage.onCanStoreFailed += OnFailedStorage;
	}

	private void OnInputObjectStored(Storage<ResourceData>.StoredObjectData storedObject, int storedAmount, string storeSourceID)
	{
		if (base.IsIdle)
		{
			InvokeOnStopIdle();
		}
	}

	private void OnFailedStorage(string objectID, bool isTotallyFool)
	{
		if (!base.IsIdle && !isTotallyFool)
		{
			InvokeOnStartIdle();
		}
	}
}
