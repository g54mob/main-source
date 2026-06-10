using UnityEngine;

public class DamageColliderController : MonoBehaviour
{
	public Collider coll;

	public Actor attacker;

	public Actor target;

	public float damage;

	public Human enableKill;

	public MurderWeaponPreset weapon;

	public void Setup(Actor newAttacker, Actor newTarget, float newDamage, Human newEnableKill, MurderWeaponPreset newWeapon)
	{
	}

	private void OnCollisionEnter(Collision other)
	{
	}

	private void OnControllerColliderHit(ControllerColliderHit other)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void ProcessHit(Actor hit, Vector3 contactPoint, Vector3 contactNormal)
	{
	}
}
