using LightTower;
using UnityEngine;

public class SpawnerPosition_PathTile : SpawnerPosition
{
	public class LTSpawnTransform : SpawnTransform
	{
		public PathTile pathTile;
	}

	private LTSpawnTransform spawnTransform;

	private LTSpawner ltSpawner;

	[SerializeField]
	private bool reverse;

	[SerializeField]
	private int startPathTileOffset;

	[SerializeField]
	private int maxStartPathTileDistance;

	private int lastStartPathTileDistance;

	private int[] randomSequence;

	protected override void Start()
	{
		base.Start();
		spawnTransform = new LTSpawnTransform();
		ltSpawner = spawner as LTSpawner;
		ltSpawner.onStartPathTileChanged += delegate
		{
			lastStartPathTileDistance = 0;
			if (maxStartPathTileDistance == 0)
			{
				SetSpawnTransformsFromPathTile(startPathTileOffset);
			}
		};
		if (maxStartPathTileDistance == 0)
		{
			SetSpawnTransformsFromPathTile(startPathTileOffset);
		}
		randomSequence = new int[maxStartPathTileDistance];
		for (int num = 0; num < maxStartPathTileDistance; num++)
		{
			randomSequence[num] = num + startPathTileOffset;
		}
		randomSequence.Shuffle();
	}

	protected override SpawnTransform GetSpawnPositionSequential()
	{
		if (maxStartPathTileDistance > 0)
		{
			if (reverse)
			{
				SetSpawnTransformsFromPathTile(startPathTileOffset + maxStartPathTileDistance - lastStartPathTileDistance);
			}
			else
			{
				SetSpawnTransformsFromPathTile(lastStartPathTileDistance + startPathTileOffset);
			}
			lastStartPathTileDistance = (lastStartPathTileDistance + 1) % (maxStartPathTileDistance + 1);
		}
		return spawnTransform;
	}

	protected override SpawnTransform GetSpawnPositionRandom()
	{
		if (maxStartPathTileDistance > 0)
		{
			SetSpawnTransformsFromPathTile(Random.Range(0, maxStartPathTileDistance + 1) + startPathTileOffset);
		}
		return spawnTransform;
	}

	protected override SpawnTransform GetSpawnPositionRandomSequence()
	{
		if (maxStartPathTileDistance > 0)
		{
			SetSpawnTransformsFromPathTile(randomSequence[lastStartPathTileDistance]);
			lastStartPathTileDistance = (lastStartPathTileDistance + 1) % (maxStartPathTileDistance + 1);
		}
		return spawnTransform;
	}

	private void SetSpawnTransformsFromPathTile(int startPathTileDistance)
	{
		if (ltSpawner.StartPathTile == null)
		{
			return;
		}
		PathTile pathTile = ltSpawner.StartPathTile;
		for (int i = 0; i < startPathTileDistance; i++)
		{
			if (pathTile.NextPathTiles.Count <= 0)
			{
				break;
			}
			pathTile = pathTile.NextPathTiles[0];
		}
		spawnTransform.pathTile = pathTile;
		spawnTransform.position = pathTile.GetAllPaths()[0].positions[0];
		spawnTransform.rotation = Quaternion.LookRotation((pathTile.GetAllPaths()[0].positions[1] - pathTile.GetAllPaths()[0].positions[0]).normalized.XZ().XZ());
	}
}
