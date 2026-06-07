using System;
using UnityEngine;

public class LaserDamage : LaserRayBase
{
	[SerializeField]
	private float laserDamage = 1000f;

	[SerializeField]
	private float laserForce = 150f;

	public event Action<bool, Vector3> OnLaserHitOrNotHitEvent;

	protected override void LaserHitHandler(RaycastHit objectRaycastHit, GameObject objectHit)
	{
		base.LaserHitHandler(objectRaycastHit, objectHit);
		if (!base.IsInAction || base.IsOnReplay)
		{
			return;
		}
		bool num = objectHit.CompareTag("Block");
		bool flag = objectHit.CompareTag("Level");
		bool flag2 = objectHit.CompareTag("WheelCollider");
		bool flag3 = objectHit.CompareTag("MirrorZone");
		if (num || flag2 || flag3)
		{
			BlockView blockView = ((!flag2) ? objectHit.GetBlockView() : objectHit.GetComponentInChildren<BlockView>(includeInactive: true));
			if (blockView != null)
			{
				blockView.Health -= laserDamage * (1f - (float)blockView.LaserResistence / 100f) * Time.deltaTime;
			}
		}
		else if (flag)
		{
			DynamicObjectBase component = objectHit.GetComponent<DynamicObjectBase>();
			if (component != null)
			{
				component.Health -= laserDamage * Time.deltaTime;
			}
		}
		this.OnLaserHitOrNotHitEvent?.Invoke(arg1: true, objectRaycastHit.point);
	}

	protected override void LaserHitHandlerFixedUpdate(RaycastHit objectRaycastHit, GameObject objectHit)
	{
		base.LaserHitHandlerFixedUpdate(objectRaycastHit, objectHit);
		Rigidbody rigidbody = objectRaycastHit.rigidbody;
		if (rigidbody != null)
		{
			if (rigidbody.isKinematic && !objectHit.CompareTag("Level"))
			{
				rigidbody = objectHit.transform.parent.GetComponentInParent<Rigidbody>();
			}
			if (rigidbody != null)
			{
				rigidbody.AddForce(worldLaserDirection * laserForce, ForceMode.Force);
			}
		}
	}

	protected override void LaserNotHitHandler()
	{
		base.LaserNotHitHandler();
		if (base.IsInAction && !base.IsOnReplay)
		{
			this.OnLaserHitOrNotHitEvent?.Invoke(arg1: false, Vector3.zero);
		}
	}
}
