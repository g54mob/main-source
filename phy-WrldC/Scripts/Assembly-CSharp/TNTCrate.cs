using System;
using UnityEngine;

public class TNTCrate : DynamicObjectBase, IExplosiveObject
{
	[SerializeField]
	private float explosionPower = 500f;

	[SerializeField]
	private float explosionDamage = 100f;

	[SerializeField]
	private float explosionRadius = 5f;

	[SerializeField]
	private float impactTrigger = 5f;

	[SerializeField]
	private GameObject explosionPrefab;

	private SimpleExplosion simpleExplosion;

	public event Action OnExplosionEvent;

	protected override void Awake()
	{
		base.Awake();
		simpleExplosion = base.gameObject.AddComponent<SimpleExplosion>();
	}

	public override void Recycle()
	{
		base.Recycle();
		base.gameObject.SetActive(value: true);
	}

	protected override void OnDestroyedObject()
	{
		base.OnDestroyedObject();
		GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(explosionPrefab);
		particlesInstance.transform.position = base.transform.position;
		particlesInstance.transform.rotation = base.transform.rotation;
		simpleExplosion.Power = explosionPower;
		simpleExplosion.Damage = explosionDamage;
		simpleExplosion.Radius = explosionRadius;
		simpleExplosion.Explode();
		if (this.OnExplosionEvent != null)
		{
			this.OnExplosionEvent();
		}
		SetExistence(isExisting: false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		float magnitude = collision.relativeVelocity.magnitude;
		if (magnitude >= impactTrigger)
		{
			base.Health -= magnitude;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, explosionRadius);
	}
}
