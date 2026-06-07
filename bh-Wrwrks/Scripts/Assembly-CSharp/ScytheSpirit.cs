using System.Collections;
using UnityEngine;

public class ScytheSpirit : Projectile
{
	public float speed = 0.07f;

	public IEnumerator Seeker()
	{
		GetComponent<PolygonCollider2D>().enabled = false;
		yield return Dungeon.Wait(10);
		Dungeon.Instance.animationManager.LerpZoom(base.gameObject, Vector3.one, 10f);
		yield return Dungeon.Wait(5);
		if (source == null)
		{
			Object.Destroy(base.gameObject);
		}
		else if (source.owner.name == Module.Name.Scythe)
		{
			Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.RandomBoneSound, 0.9f, 1.1f, 1f);
		}
		else if (source.owner.name == Module.Name.Beehive)
		{
			Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.Sound.Buzz_Bee, 0.9f, 1.1f, 1f);
		}
		GetComponent<PolygonCollider2D>().enabled = true;
		dieOnHit = true;
		Monster target = null;
		int i = 0;
		while (true)
		{
			if (target == null)
			{
				if (Dungeon.Instance.livingEnemies.Count > 0)
				{
					target = Utils.RandElem(source.owner.dungeon.livingEnemies);
				}
			}
			else
			{
				Vector3 normalized = (target.transform.position - base.transform.position).normalized;
				base.transform.position += normalized * speed;
				GetComponent<SpriteRenderer>().flipX = base.transform.position.x < target.transform.position.x;
			}
			base.transform.position += new Vector3(0f, (float)((i < 45) ? 1 : (-1)) * 0.1f / 16f);
			i++;
			if (i % 90 == 0)
			{
				i = 0;
			}
			yield return Dungeon.Wait(1);
		}
	}
}
