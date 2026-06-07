using UnityEngine;

public class CombatExplosion : MonoBehaviour
{
	public float radius;

	[Header("Player")]
	public float playerDamage;

	public float playerKnockback;

	[Header("Enemy")]
	public float enemyKnockback;

	private void Start()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}
