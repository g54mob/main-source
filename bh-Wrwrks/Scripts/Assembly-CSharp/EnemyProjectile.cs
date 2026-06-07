using System.Collections;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	public int damage = 1;

	public void Timer(int x)
	{
		StartCoroutine(timer(x));
	}

	private IEnumerator timer(int x)
	{
		yield return Dungeon.Wait(x);
		HurtPlayer();
	}

	public void HurtPlayer()
	{
		Dungeon.Instance.player.Hurt(damage);
		Object.Destroy(base.gameObject);
	}
}
