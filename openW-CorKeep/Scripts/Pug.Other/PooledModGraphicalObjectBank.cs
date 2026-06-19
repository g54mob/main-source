using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

[CreateAssetMenu(menuName = "PugMod/PooledModGraphicalObjectBank", order = 1)]
public class PooledModGraphicalObjectBank : PoolablePrefabBank
{
	private const int DEFAULT_INITIAL_SIZE = 16;

	private const int DEFAULT_MAX_FREE_SIZE = 16;

	private const int DEFAULT_MAX_SIZE = 1024;

	[ArrayElementTitle("prefab, initialSize, maxSize")]
	public List<PoolablePrefab> modPoolInitializers = new List<PoolablePrefab>();

	public override IEnumerator<PoolablePrefab> GetEnumerator()
	{
		foreach (PoolablePrefab modPoolInitializer in modPoolInitializers)
		{
			if (modPoolInitializer.initialSize <= 0)
			{
				modPoolInitializer.initialSize = 16;
			}
			if (modPoolInitializer.maxFreeSize <= 0)
			{
				modPoolInitializer.maxFreeSize = 16;
			}
			if (modPoolInitializer.maxSize <= 0)
			{
				modPoolInitializer.maxSize = 1024;
			}
			yield return modPoolInitializer;
		}
	}
}
