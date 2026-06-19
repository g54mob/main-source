using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class ActivatedSplash : EntityBehaviourBase, IBoxActivated
{
	[Min(0f)]
	public float splashRadius = 5f;

	public GameObject vfxPrefab;

	private static Collider[] _colliders = new Collider[128];

	public void ServerBoxActivated(ActivationContext context)
	{
		Vector3 position = base.entity.transform.position;
		int num = Physics.OverlapSphereNonAlloc(position, splashRadius, _colliders, 147464);
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			if (_colliders[i].GetEntity().TryGetObject<IFlammable>(out var obj) && obj.ServerFlammableCanBePutOut())
			{
				obj.ServerFlammablePutOut();
				num2++;
			}
		}
		if (num2 > 0)
		{
			NetworkAggroManagerBase<AchievementManager>.instance.ServerAddStat("stat_fires_extinguished", num2);
		}
		NetworkAggroManagerBase<VFXManager>.instance.Play(vfxPrefab, position);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(base.transform.position, splashRadius);
	}
}
