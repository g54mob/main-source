using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class FlotsamSpawnerGroup
{
	private readonly List<FlotsamProperties> _allFlotsamProps = new List<FlotsamProperties>();

	public ISpawnerEvent SpawnerOutOfRangeEvent { get; } = new ISpawnerEvent();

	public ISpawnerEvent OnSalvaged { get; } = new ISpawnerEvent();

	public List<FlotsamSpawner> Spawners { get; }

	public FlotsamSpawnerGroup(int capacity = -1)
	{
		Spawners = new List<FlotsamSpawner>((capacity >= 0) ? capacity : 4);
	}

	public FlotsamSpawnerGroup(List<ItemProperties> propertiesList)
		: this(propertiesList.Count)
	{
		int count = propertiesList.Count;
		for (int i = 0; i < count; i++)
		{
			AddSpawner(FlotsamSpawner.CreateFromItemProperties(propertiesList[i]));
		}
	}

	public FlotsamSpawnerGroup(List<CompositedFlotsamProperties> propertiesList)
		: this(propertiesList.Count)
	{
		int count = propertiesList.Count;
		for (int i = 0; i < count; i++)
		{
			AddSpawner(FlotsamSpawner.CreateFromCompositeFlotsamProperties(propertiesList[i]));
		}
	}

	public void Initialize()
	{
	}

	public void Spawn(PointOfInterestSpawner pointOfInterestSpawner)
	{
		int flotsamCount = Spawners.Count;
		if (LoadingScreen.IsLoading)
		{
			ISpawnerState state = pointOfInterestSpawner.State;
			if ((uint)state > 1u)
			{
				return;
			}
			LoadingScreen.AddTask(delegate
			{
				for (int i = 0; i < flotsamCount; i++)
				{
					Spawners[i].Spawn(pointOfInterestSpawner);
				}
			});
		}
		else
		{
			for (int num = 0; num < flotsamCount; num++)
			{
				Spawners[num].Spawn(pointOfInterestSpawner);
			}
		}
	}

	public bool Despawn(bool destroyInstance)
	{
		for (int i = 0; i < Spawners.Count; i++)
		{
			if (!Spawners[i].Despawn(destroyInstance))
			{
				Spawners.RemoveAt(i--);
			}
		}
		return true;
	}

	public void SetWorldTileOffset(Vector3 offset)
	{
		if (Spawners.IsNullOrEmpty())
		{
			return;
		}
		foreach (FlotsamSpawner spawner in Spawners)
		{
			spawner.SetWorldTileOffset(offset);
		}
	}

	public void AddSpawner(FlotsamSpawner spawner)
	{
		spawner.OnSalvaged.AddListener(RemoveSpawner);
		spawner.OnOutOfRange.AddListener(OnSpawnerOutOfRange);
		Spawners.Add(spawner);
	}

	private void RemoveSpawner(FlotsamSpawner spawner)
	{
		if (Spawners.Remove(spawner))
		{
			spawner.OnSalvaged.RemoveListener(RemoveSpawner);
			OnSalvaged.Invoke(spawner);
		}
	}

	public void AddFlotsam(Flotsam flotsam)
	{
		if (!(flotsam == null))
		{
			AddSpawner(FlotsamSpawner.CreateFromFlotsam(flotsam));
		}
	}

	public void ClearSpawners()
	{
		Despawn(destroyInstance: false);
		Spawners.Clear();
	}

	public void Move(Vector3 movement)
	{
		int count = Spawners.Count;
		for (int i = 0; i < count; i++)
		{
			Spawners[i].Move(movement);
		}
	}

	public void RepositionRelativeToTownheart(Vector3 townheartPosition, Quaternion townheartRotation)
	{
		int count = Spawners.Count;
		for (int i = 0; i < count; i++)
		{
			Spawners[i].RepositionRelativeToTownheart(townheartPosition, townheartRotation);
		}
	}

	public void CountItems(InventoryAuditor auditor)
	{
		int count = Spawners.Count;
		for (int i = 0; i < count; i++)
		{
			Spawners[i].CountItems(auditor);
		}
	}

	public void CountItemsInRange(InventoryAuditor auditor, float range)
	{
		int count = Spawners.Count;
		for (int i = 0; i < count; i++)
		{
			Spawners[i].CountItemsInRange(auditor, range);
		}
	}

	public void SpawnersInRange(Vector3 position, float range, List<FlotsamSpawner> spawners)
	{
		int count = Spawners.Count;
		for (int i = 0; i < count; i++)
		{
			FlotsamSpawner flotsamSpawner = Spawners[i];
			if (flotsamSpawner.Instance.transform.position.IsInRange(position, range))
			{
				spawners.Add(flotsamSpawner);
			}
		}
	}

	public FlotsamSpawner ReturnClosestFlotsamSpawner(Vector3 position, ref float shortestDistanceSquared, FlotsamSpawner closestSpawner = null)
	{
		_ = Spawners.Count;
		foreach (FlotsamSpawner spawner in Spawners)
		{
			if (!(spawner.Instance == null))
			{
				float num = spawner.Instance.transform.position.DistanceToSquared(position);
				if (num < shortestDistanceSquared)
				{
					shortestDistanceSquared = num;
					closestSpawner = spawner;
				}
			}
		}
		return closestSpawner;
	}

	public IReadOnlyList<FlotsamProperties> GetAllFlotsamProperties()
	{
		_allFlotsamProps.Clear();
		foreach (FlotsamSpawner spawner in Spawners)
		{
			_allFlotsamProps.Add(spawner.Properties);
		}
		return _allFlotsamProps;
	}

	private void OnSpawnerOutOfRange(FlotsamSpawner spawner)
	{
		SpawnerOutOfRangeEvent.Invoke(spawner);
	}
}
