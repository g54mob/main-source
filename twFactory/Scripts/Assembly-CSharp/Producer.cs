using System.Collections;
using UnityEngine;

public class Producer : GameplayObject
{
	private enum EProductionPolicy
	{
		ProduceAlways = 0,
		ProduceOnlyIfEmpty = 1,
		ProduceOnDemand = 2,
		Infinite = 3
	}

	[SerializeField]
	private GameplayObject objectToProduce;

	[SerializeField]
	private bool startFull = true;

	[SerializeField]
	private EProductionPolicy productionPolicy = EProductionPolicy.ProduceOnlyIfEmpty;

	[SerializeField]
	private int maxObjectsAmount = 1;

	[SerializeField]
	private float productionTime = 1f;

	private float lastTimeProduction;

	[SerializeField]
	private int objectsPerProduction = 1;

	[SerializeField]
	private Storage<GameplayObject> externalStorage;

	private Storage<GameplayObject> storage;

	private Coroutine productionCoroutine_var;

	public GameplayObject ObjectToProduce => objectToProduce;

	public float ProductionTime => productionTime;

	public float LastTimeProduction => lastTimeProduction;

	public Storage<GameplayObject> Storage => storage;

	private void Awake()
	{
		Interactive[] componentsInChildren = GetComponentsInChildren<Interactive>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].onInteract += OnInteract;
		}
		InitProducer();
	}

	protected void InitProducer()
	{
		if ((bool)externalStorage)
		{
			storage = externalStorage;
		}
		else
		{
			storage = base.gameObject.AddComponent<Storage<GameplayObject>>();
			storage.Size = maxObjectsAmount;
		}
		if (startFull)
		{
			for (int i = 0; i < maxObjectsAmount; i++)
			{
				ProduceObject();
			}
		}
		else if (productionPolicy == EProductionPolicy.Infinite)
		{
			ProduceObject();
		}
		else
		{
			this.StartCoroutineCheckingVar(ProductionCoroutine(), ref productionCoroutine_var, stopCoroutineIfRunning: true);
		}
	}

	private IEnumerator ProductionCoroutine()
	{
		int producedProducts = 0;
		do
		{
			lastTimeProduction = Time.time;
			yield return new WaitForSeconds(productionTime);
			ProduceObject();
			producedProducts += objectsPerProduction;
		}
		while (storage.StoredObjects.Count < maxObjectsAmount && (productionPolicy != EProductionPolicy.ProduceOnlyIfEmpty || producedProducts < maxObjectsAmount));
		productionCoroutine_var = null;
	}

	public bool DemandProductGeneration()
	{
		if (productionPolicy == EProductionPolicy.ProduceOnDemand)
		{
			ProduceObject();
			return true;
		}
		return false;
	}

	protected void ProduceObject()
	{
		storage.StoreObject(objectToProduce, objectToProduce.ObjectData.Id, objectsPerProduction);
	}

	private void OnInteract(ref Interaction interaction)
	{
	}
}
