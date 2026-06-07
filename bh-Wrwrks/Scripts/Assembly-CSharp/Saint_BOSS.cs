using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saint_BOSS : Monster
{
	private bool approach = true;

	private float ang;

	private float dist;

	private int dir = 1;

	private int t;

	public Sprite attackSprite;

	private int attackTime
	{
		get
		{
			if (!base.dungeon.harderBosses)
			{
				return 45;
			}
			return 30;
		}
	}

	public override void InitStats()
	{
		attackDistance = -1f;
		StartCoroutine(SupportLoop());
	}

	private void SetArea()
	{
		ang = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		dist = Vector3.Distance(base.pos, base.player.pos);
		bool flag = base.pos.x < base.player.pos.x;
		bool flag2 = base.pos.y > base.player.pos.y;
		dir = ((flag ^ flag2) ? 1 : (-1));
	}

	public override IEnumerator Movement()
	{
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		if (!approach)
		{
			base.spriteRenderer.flipX = base.pos.y < base.player.pos.y;
		}
		if (dir == -1 && !approach)
		{
			base.spriteRenderer.flipX = !base.spriteRenderer.flipX;
		}
		if (approach)
		{
			Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
			float num = base.speed / 16f;
			base.pos += normalized * num;
			if (Vector3.Distance(base.pos, base.player.pos) <= 4f)
			{
				approach = false;
				SetArea();
				yield break;
			}
		}
		if (!approach)
		{
			ang += (float)dir * 0.01f;
			base.pos = base.player.pos + new Vector3(Mathf.Cos(ang), Mathf.Sin(ang)) * dist;
		}
		t++;
		if (t == attackTime)
		{
			t = 0;
			StartCoroutine(SpawnSkeletons());
		}
		yield return Wait(2);
	}

	private IEnumerator SpawnSkeletons()
	{
		int num = (base.dungeon.harderBosses ? 4 : 3);
		StartCoroutine(spawner(num));
		base.animator.StopAnim();
		base.spriteRenderer.sprite = attackSprite;
		yield return Wait(10 * num);
		base.animator.StartAnim();
	}

	private IEnumerator spawner(int count)
	{
		for (int i = 0; i < count; i++)
		{
			yield return Wait(10);
			Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.RandomBoneSound, 0.9f, 1.1f, 1f);
			Monster monster = base.dungeon.SpawnMonster(Type.Skeleton);
			Vector3 vector = Utils.RandDir();
			monster.transform.position = base.pos + 1.4f * vector;
		}
	}

	private IEnumerator SupportLoop()
	{
		List<Type> monsters = new List<Type>
		{
			Type.Archer,
			Type.Skull,
			Type.Wizard,
			Type.Soldier,
			Type.Sapper
		};
		yield return Dungeon.Wait(120);
		while (true)
		{
			yield return Dungeon.Wait(base.dungeon.harderBosses ? 20 : 25);
			base.dungeon.SpawnMonster(Utils.RandElem(monsters));
		}
	}
}
