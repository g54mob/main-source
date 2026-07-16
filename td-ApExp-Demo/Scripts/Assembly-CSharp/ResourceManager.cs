using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour, ISaveable
{
	public Resource Ammo;

	public Resource Scrap;

	public Resource Rerolls;

	public Resource Cores;

	private Resource[] resources;

	public float baseBossDroppedCoresAmount;

	public bool DebugIsInfiniteCoal;

	public static ResourceManager Instance { get; private set; }

	public float TotalCores { get; set; }

	public float AvailableAmmo => Ammo.Value - Cannon.Instance.AmmoReservedByCannon;

	public event Action OnCoresAdded;

	private void Awake()
	{
		Instance = this;
		resources = new Resource[4] { Ammo, Scrap, Rerolls, Cores };
	}

	private void Start()
	{
		Resource[] array = resources;
		foreach (Resource obj in array)
		{
			obj.SetValue(obj.Value);
		}
	}

	private void OnValidate()
	{
		if (resources != null)
		{
			Resource[] array = resources;
			foreach (Resource obj in array)
			{
				obj.SetValue(obj.Value);
			}
		}
	}

	public void SetInfiniteAmmo(bool isInfiniteAmmo)
	{
		Ammo.DebugIsInfinite = isInfiniteAmmo;
	}

	public void SetInfiniteScrap(bool isInfiniteScrap)
	{
		Scrap.DebugIsInfinite = isInfiniteScrap;
	}

	public void SetInfiniteCoal(bool isInfiniteCoal)
	{
		DebugIsInfiniteCoal = isInfiniteCoal;
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		MetaSavefile metaSave = context.MetaSave;
		Cores.SetValue(metaSave.cores);
		TotalCores = metaSave.totalCores;
	}

	public void Save(SaveDataContext context)
	{
		MetaSavefile metaSave = context.MetaSave;
		metaSave.cores = Cores.Value;
		metaSave.totalCores = TotalCores;
	}

	public void LootCores(float cores)
	{
		float value = Cores.Value;
		Cores.AddValue(cores);
		float num = Cores.Value - value;
		TotalCores += num;
		this.OnCoresAdded?.Invoke();
	}

	public void DropCoresFromBoss(int coresToDrop)
	{
		float value = Cores.Value;
		Cores.AddValue(Instance.baseBossDroppedCoresAmount + DifficultyManager.Instance.additionalBossCores + (float)coresToDrop);
		float num = Cores.Value - value;
		TotalCores += num;
		this.OnCoresAdded?.Invoke();
	}
}
