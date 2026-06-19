using AssembleSystem;
using UnityEngine;
using Zenject;

public class PartObjectInventoryFactory : IPartObjectInventoryFactory, IFactory<PartObject>, IFactory
{
	private DiContainer _container;

	public PartObjectInventoryFactory(DiContainer container)
	{
		_container = container;
	}

	public PartObject Create(PartObject prototype)
	{
		PartObject partObject = Object.Instantiate(prototype);
		_container.Inject(partObject);
		return partObject;
	}

	public PartObject Create()
	{
		Debug.LogError("Use with prototype");
		return null;
	}
}
