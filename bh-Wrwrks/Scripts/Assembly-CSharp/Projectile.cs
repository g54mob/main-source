using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Weapon source;

	public Module sourceModule;

	public bool dieOnHit;

	public int forceDamage = -1;

	public bool sharedWeapon;

	public Monster.Debuff debuff;

	public float debuffValue;

	public int damage
	{
		get
		{
			if (forceDamage != -1)
			{
				return forceDamage;
			}
			if (!(sourceModule != null))
			{
				return source.damage;
			}
			return sourceModule.damage;
		}
		set
		{
			forceDamage = value;
		}
	}

	public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

	public void Start()
	{
		SpriteRenderer[] components = GetComponents<SpriteRenderer>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
		}
		components = GetComponentsInChildren<SpriteRenderer>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
		}
	}

	public virtual void HitTrigger(Monster monster)
	{
		if (source != null)
		{
			source.ProjectileHit(monster);
		}
		else if (sourceModule != null && sourceModule == Dungeon.Instance.player.sentinel)
		{
			sourceModule.Trigger(Trigger.Type.Hit);
			if (monster.health <= 0)
			{
				sourceModule.Trigger(Trigger.Type.Kill);
			}
		}
	}

	public void Die()
	{
		StopAllCoroutines();
		Dungeon.Instance.animationManager.LerpZoom(base.gameObject, Vector3.zero, 5f);
		Dungeon.Instance.animationManager.Fade(base.gameObject, 1, 7);
	}

	public virtual void EnterMonster(Monster m)
	{
		if (debuff != Monster.Debuff.None)
		{
			Color color = spriteRenderer.color;
			if (debuff == Monster.Debuff.Slow)
			{
				color = Utils.GetColor("00CDF9");
			}
			Dungeon.Instance.animationManager.CreateDust(m.transform.position, color, 8);
			m.ApplyDebuff(debuff, debuffValue);
		}
	}

	public virtual void ExitMonster(Monster m)
	{
	}
}
