using UnityEngine;

public class FPSWeaponBase : MonoBehaviour, IFPSWeaponHandler
{
	public float hitDamage;

	public SphereCollider detectorCollider;

	public virtual void Equip()
	{
		Debug.Log("Equip");
	}

	public virtual void Hit(float delay)
	{
		Debug.Log("Hit");
	}

	public virtual void Recoil()
	{
		Debug.Log("Recoil");
	}

	public virtual void UnEquip()
	{
		Debug.Log("UnEquip");
	}
}
