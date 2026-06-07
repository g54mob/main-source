using UnityEngine;

public class WeaponDamageDealer : MonoBehaviour
{
	protected float damageMultiplyer = 1f;

	public float DamageMultiplyer
	{
		get
		{
			return damageMultiplyer;
		}
		set
		{
			damageMultiplyer = value;
		}
	}
}
