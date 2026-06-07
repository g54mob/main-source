using System.Collections;
using UnityEngine;

public class Necro_Skele : Projectile
{
	private Monster target;

	public float speed => 0.03f * source.owner.accelMult;

	public void Death()
	{
		StopAllCoroutines();
		source.animationManager.LerpZoom(base.gameObject, Vector3.zero, 10f, 0f, destroy: true);
	}

	public void StartPathing()
	{
		StartCoroutine(pathing());
	}

	private IEnumerator Knockback(Monster m)
	{
		Vector3 dir = (m.transform.position - base.transform.position).normalized;
		float dist = 0.25f;
		base.transform.position += dir * dist;
		Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.RandomBoneSound, 0.9f, 1.1f, 1f);
		m.Hurt(base.damage, this);
		for (int i = 0; i < 4; i++)
		{
			base.transform.position += dir * (0f - dist) / 4f;
			yield return Dungeon.Wait(2);
		}
	}

	private IEnumerator pathing()
	{
		while (true)
		{
			target = source.dungeon.GetClosestMonster(base.transform.position);
			int t = 0;
			while (target != null && target.health > 0)
			{
				Vector3 normalized = (target.transform.position - base.transform.position).normalized;
				if (Vector3.Distance(base.transform.position, target.pos) <= 0.5f)
				{
					if (t == 0)
					{
						t = (int)(20f / source.owner.accelMult);
						yield return Knockback(target);
					}
					else
					{
						t--;
					}
				}
				else
				{
					base.transform.position += normalized * speed;
				}
				if (target == null)
				{
					break;
				}
				base.spriteRenderer.flipX = target.pos.x > base.transform.position.x;
				yield return Dungeon.Wait(1);
			}
			yield return Dungeon.Wait(1);
		}
	}
}
