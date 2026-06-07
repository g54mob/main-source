using UnityEngine;

public abstract class SpawnerPosition : MonoBehaviour
{
	public enum ESpawnDistribution
	{
		Sequential = 0,
		Random = 1,
		RandomSequence = 2
	}

	public class SpawnTransform
	{
		public Vector3 position;

		public Quaternion rotation;

		public SpawnTransform()
		{
		}

		public SpawnTransform(Vector3 position, Quaternion rotation)
		{
			this.position = position;
			this.rotation = rotation;
		}
	}

	protected Spawner spawner;

	[SerializeField]
	protected ESpawnDistribution spawnDistribution;

	protected virtual void Awake()
	{
		spawner = GetComponent<Spawner>();
	}

	protected virtual void Start()
	{
	}

	public SpawnTransform GetSpawnPosition()
	{
		return spawnDistribution switch
		{
			ESpawnDistribution.Sequential => GetSpawnPositionSequential(), 
			ESpawnDistribution.Random => GetSpawnPositionRandom(), 
			ESpawnDistribution.RandomSequence => GetSpawnPositionRandomSequence(), 
			_ => new SpawnTransform(base.transform.position, base.transform.rotation), 
		};
	}

	protected abstract SpawnTransform GetSpawnPositionSequential();

	protected abstract SpawnTransform GetSpawnPositionRandom();

	protected abstract SpawnTransform GetSpawnPositionRandomSequence();
}
