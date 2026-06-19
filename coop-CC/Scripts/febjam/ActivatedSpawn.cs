using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;

public class ActivatedSpawn : EntityBehaviourBase, IBoxActivated
{
	public GameObject prefab;

	[Min(1f)]
	public int spawnCount = 1;

	[Min(0f)]
	public float spawnDistanceNoise;

	[Min(0f)]
	public float spawnExplosionForce;

	[Range(0f, 90f)]
	public float spawnExplosionUpwardsModifierDegrees = 25f;

	public bool inheritFire = true;

	[Space]
	public GameObject vfxPrefab;

	[Space]
	public string achievementStatId;

	public void ServerBoxActivated(ActivationContext context)
	{
		NetworkAggroManagerBase<VFXManager>.instance.Play(vfxPrefab, base.entity.transform.position);
		Unity.Mathematics.Random random = MathUtil.GetRandom(GetSeed(), TimeUtil.frame);
		int num = spawnCount;
		for (int i = 0; i < num; i++)
		{
			Vector3 vector = new Vector3(random.NextFloat(-1f, 1f), random.NextFloat(0f, 1f), random.NextFloat(-1f, 1f));
			Vector3 position = base.entity.transform.position + vector * spawnDistanceNoise;
			Entity entity = EntityUtil.Instantiate(prefab, position);
			if (spawnExplosionForce > 0f && entity.HasObject<Rigidbody>())
			{
				entity.rigidbody.AddExplosionForce(spawnExplosionForce, base.entity.transform.position, 0f, spawnExplosionUpwardsModifierDegrees, ForceMode.Impulse);
			}
			if (inheritFire && base.entity.TryGetObject<Flammable>(out var obj) && obj.isOnFire && entity.TryGetObject<Flammable>(out var obj2))
			{
				obj2.RequestSetFire();
			}
		}
		if (!string.IsNullOrEmpty(achievementStatId) && num > 0)
		{
			NetworkAggroManagerBase<AchievementManager>.instance.ServerAddStat(achievementStatId, num);
		}
	}
}
