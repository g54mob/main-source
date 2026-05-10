using System.Collections.Generic;
using UnityEngine;

public class SpawnerPosition_Circle : SpawnerPosition
{
	private enum EAlignRotation
	{
		Default = 0,
		Inwards = 1,
		Outwards = 2
	}

	[SerializeField]
	[Range(0f, 100f)]
	private float radius = 1f;

	[SerializeField]
	[Range(1f, 50f)]
	private int segments = 5;

	[SerializeField]
	private EAlignRotation alignRotation;

	private int lastSegment = -1;

	private List<int> randomSequence;

	protected override void Awake()
	{
		base.Awake();
		randomSequence = new List<int>();
	}

	protected override SpawnTransform GetSpawnPositionSequential()
	{
		lastSegment++;
		return GetSpawnTransformFromCircle(lastSegment % segments);
	}

	protected override SpawnTransform GetSpawnPositionRandom()
	{
		return GetSpawnTransformFromCircle(Random.Range(0, segments));
	}

	protected override SpawnTransform GetSpawnPositionRandomSequence()
	{
		if (randomSequence.Count == 0)
		{
			for (int i = 0; i < segments; i++)
			{
				randomSequence.Add(i);
			}
		}
		int index = Random.Range(0, randomSequence.Count);
		SpawnTransform spawnTransformFromCircle = GetSpawnTransformFromCircle(randomSequence[index]);
		randomSequence.RemoveAt(index);
		return spawnTransformFromCircle;
	}

	private SpawnTransform GetSpawnTransformFromCircle(int position)
	{
		SpawnTransform spawnTransform = new SpawnTransform();
		Quaternion quaternion = Quaternion.AngleAxis(360f * ((float)position / (float)segments), base.transform.up);
		spawnTransform.position = base.transform.position + quaternion * (base.transform.forward.normalized * radius);
		switch (alignRotation)
		{
		case EAlignRotation.Default:
			spawnTransform.rotation = base.transform.rotation;
			break;
		case EAlignRotation.Inwards:
			spawnTransform.rotation = Quaternion.LookRotation(base.transform.position - spawnTransform.position, base.transform.up);
			break;
		case EAlignRotation.Outwards:
			spawnTransform.rotation = Quaternion.LookRotation(spawnTransform.position - base.transform.position, base.transform.up);
			break;
		}
		return spawnTransform;
	}

	private void OnDrawGizmosSelected()
	{
		GameObject gameObject = GetComponent<Spawner>()?.Config.ObjectToSpawn;
		Gizmos.color = Color.grey;
		for (int i = 0; i < segments; i++)
		{
			SpawnTransform spawnTransformFromCircle = GetSpawnTransformFromCircle(i);
			if ((bool)gameObject)
			{
				foreach (Mesh mesh in FunctionLibrary.GetMeshes(gameObject))
				{
					Gizmos.DrawMesh(mesh, spawnTransformFromCircle.position, spawnTransformFromCircle.rotation);
				}
			}
			else
			{
				Gizmos.DrawWireSphere(spawnTransformFromCircle.position + base.transform.up * 0.5f, 0.5f);
			}
		}
	}
}
