using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Pug/Gameplay/PooledGraphicalObjectBank", order = 1)]
public class PooledGraphicalObjectBank : PoolablePrefabBank
{
	[FormerlySerializedAs("PoolablePlatformScaling")]
	[SerializeField]
	public List<PlatformObjectPoolScaling> poolablePlatformScaling;

	[ArrayElementTitle("prefab, initialSize, maxSize")]
	public List<PoolablePrefab> poolInitializers;

	public override IEnumerator<PoolablePrefab> GetEnumerator()
	{
		return poolInitializers.GetEnumerator();
	}

	public override bool TryGetCurrentPlatformPoolScaling(out PlatformObjectPoolScaling poolScaling)
	{
		poolScaling = poolablePlatformScaling.FirstOrDefault((PlatformObjectPoolScaling scaling) => scaling.Platform.Equals(Application.platform));
		return poolScaling != null;
	}
}
