using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSlipOut : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float speedThresholdToSlipOut = 8f;

	private static Collider[] _colliders = new Collider[32];

	protected override void OnUpdateSimulation()
	{
		if (!base.isLocalPlayer || base.entity.rigidbody.velocity.sqrMagnitude < speedThresholdToSlipOut * speedThresholdToSlipOut || base.entity.GetObject<PlayerUpgrades>().HasUpgrade(PlayerUpgrade.Traction))
		{
			return;
		}
		Vector3 position = base.entity.transform.position;
		int num = Physics.OverlapSphereNonAlloc(position, 5f, _colliders, 131072);
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			Entity entity = _colliders[i].GetEntity();
			if (entity.TryGetObject<PuddleSlipOut>(out var obj) && math.distancesq(entity.transform.position, position) <= obj.radius * obj.radius)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			base.entity.GetObject<VehicleController>().RequestSlipOut(isBananaSlip: false);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
