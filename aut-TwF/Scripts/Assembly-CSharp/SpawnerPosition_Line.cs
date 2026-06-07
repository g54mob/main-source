using System.Collections.Generic;
using UnityEngine;

public class SpawnerPosition_Line : SpawnerPosition
{
	private enum EAlignRotation
	{
		Parallel = 0,
		Orthogonal = 1
	}

	[SerializeField]
	[Range(0.0001f, 100f)]
	private float size = 1f;

	[SerializeField]
	[Range(1f, 30f)]
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
		return GetSpawnTransformFromLine(lastSegment % segments);
	}

	protected override SpawnTransform GetSpawnPositionRandom()
	{
		return GetSpawnTransformFromLine(Random.Range(0, segments));
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
		SpawnTransform spawnTransformFromLine = GetSpawnTransformFromLine(randomSequence[index]);
		randomSequence.RemoveAt(index);
		return spawnTransformFromLine;
	}

	private SpawnTransform GetSpawnTransformFromLine(int position)
	{
		SpawnTransform spawnTransform = new SpawnTransform();
		if (segments == 1)
		{
			spawnTransform.position = base.transform.position;
		}
		else
		{
			float num = size / (float)(segments - 1);
			spawnTransform.position = base.transform.position + base.transform.forward * (size * 0.5f - (float)position * num);
		}
		switch (alignRotation)
		{
		case EAlignRotation.Parallel:
			spawnTransform.rotation = base.transform.rotation;
			break;
		case EAlignRotation.Orthogonal:
			spawnTransform.rotation = base.transform.rotation * Quaternion.AngleAxis(90f, Vector3.up);
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
			SpawnTransform spawnTransformFromLine = GetSpawnTransformFromLine(i);
			if ((bool)gameObject)
			{
				foreach (Mesh mesh in FunctionLibrary.GetMeshes(gameObject))
				{
					Gizmos.DrawMesh(mesh, spawnTransformFromLine.position, spawnTransformFromLine.rotation);
				}
			}
			else
			{
				Gizmos.DrawWireSphere(spawnTransformFromLine.position + base.transform.up * 0.5f, 0.5f);
			}
		}
	}
}
