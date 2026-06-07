using System.Collections;
using UnityEngine;

public class Blade : Weapon
{
	private int i;

	public GameObject projObj;

	internal void CalcBuffs()
	{
		owner.counter = owner.board.GetNetworkCount(owner, Module.Tribe.Mech);
		if (base.UPGRADED)
		{
			owner.counter *= 2;
		}
	}

	public override void ProcessFrame()
	{
		i++;
		if (i == 60)
		{
			StartCoroutine(stabs());
			i = 0;
		}
		base.ProcessFrame();
	}

	private IEnumerator stabs()
	{
		int delay = ((owner.counter >= 6) ? 3 : 5);
		for (int i = 0; i < owner.counter; i++)
		{
			Vector3 position = base.transform.position;
			Monster closestMonster = base.dungeon.GetClosestMonster(position);
			if (!(closestMonster == null))
			{
				Projectile component = base.dungeon.InstantiateExternal(projObj).GetComponent<Projectile>();
				component.source = this;
				component.transform.position = position;
				component.transform.localScale = Vector3.one;
				Dungeon.Instance.animationManager.BounceZoom(component.gameObject, 0.2f, 4);
				Vector3 normalized = (closestMonster.transform.position - position).normalized;
				component.transform.localEulerAngles = new Vector3(0f, 0f, Weapon.PointTo(position, closestMonster.transform.position, 90f));
				base.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.4f);
				base.dungeon.animationManager.Fade(component.gameObject, 3, 10);
				base.dungeon.animationManager.FlashSprite(component.gameObject);
				base.dungeon.audioManager.PlayModSound(owner, 0.9f);
				yield return Wait(delay);
			}
		}
	}
}
