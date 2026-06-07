using System.Collections.Generic;
using UnityEngine;

public class SpawnerPosition_FixedPositions : SpawnerPosition
{
	private int lastPosition = -1;

	private List<Transform> fixedPositions;

	private List<int> randomSequence;

	protected override void Awake()
	{
		base.Awake();
		randomSequence = new List<int>();
		StoreFixedPositions();
	}

	private void StoreFixedPositions()
	{
		fixedPositions = new List<Transform>();
		foreach (Transform item in base.transform)
		{
			fixedPositions.Add(item);
		}
	}

	protected override SpawnTransform GetSpawnPositionSequential()
	{
		lastPosition++;
		return GetSpawnTransformFromFixedPosition(lastPosition % fixedPositions.Count);
	}

	protected override SpawnTransform GetSpawnPositionRandom()
	{
		return GetSpawnTransformFromFixedPosition(Random.Range(0, fixedPositions.Count - 1));
	}

	protected override SpawnTransform GetSpawnPositionRandomSequence()
	{
		if (randomSequence.Count == 0)
		{
			for (int i = 0; i < fixedPositions.Count; i++)
			{
				randomSequence.Add(i);
			}
		}
		int index = Random.Range(0, randomSequence.Count);
		SpawnTransform spawnTransformFromFixedPosition = GetSpawnTransformFromFixedPosition(randomSequence[index]);
		randomSequence.RemoveAt(index);
		return spawnTransformFromFixedPosition;
	}

	private SpawnTransform GetSpawnTransformFromFixedPosition(int position)
	{
		SpawnTransform spawnTransform = new SpawnTransform();
		spawnTransform.position = base.transform.position;
		spawnTransform.rotation = base.transform.rotation;
		if (position < fixedPositions.Count)
		{
			spawnTransform.position = fixedPositions[position].position;
			spawnTransform.rotation = fixedPositions[position].rotation;
		}
		return spawnTransform;
	}

	private void OnDrawGizmosSelected()
	{
		GameObject gameObject = GetComponent<Spawner>()?.Config.ObjectToSpawn;
		StoreFixedPositions();
		Gizmos.color = Color.grey;
		for (int i = 0; i < fixedPositions.Count; i++)
		{
			SpawnTransform spawnTransformFromFixedPosition = GetSpawnTransformFromFixedPosition(i);
			if ((bool)gameObject)
			{
				foreach (Mesh mesh in FunctionLibrary.GetMeshes(gameObject))
				{
					Gizmos.DrawMesh(mesh, spawnTransformFromFixedPosition.position, spawnTransformFromFixedPosition.rotation);
				}
			}
			else
			{
				Gizmos.DrawWireSphere(spawnTransformFromFixedPosition.position + base.transform.up * 0.5f, 0.5f);
			}
		}
	}
}
