using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : Monster
{
	private enum Attacks
	{
		Spiral = 0,
		Stream = 1,
		Adds = 2,
		Wave = 3,
		Cross = 4
	}

	public List<Sprite> downSprites;

	public List<Sprite> upSprites;

	private int t = 60;

	private List<Attacks> list = new List<Attacks>();

	private int atkInd;

	private Coroutine floater;

	private bool init;

	private float burst;

	private bool splashing;

	public GameObject charger;

	private int attackTime
	{
		get
		{
			if (!base.dungeon.harderBosses)
			{
				return 40;
			}
			return 30;
		}
	}

	public void CreateBubble(Vector3 pos, int frameDelay)
	{
		pos += base.player.pos;
		Monster monster = base.dungeon.SpawnMonster(Type.Bubble);
		monster.transform.position = pos;
		if (base.dungeon.harderBosses)
		{
			monster.health += 5;
			monster.maxHealth += 5;
			monster.damage += 2;
			monster.speed += 0.15f;
		}
		AudioManager.Sound c = Utils.RandElem(new List<AudioManager.Sound>
		{
			AudioManager.Sound.Underwater_Bubble_0,
			AudioManager.Sound.Underwater_Bubble_1,
			AudioManager.Sound.Underwater_Bubble_2
		});
		base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
	}

	public void CreateBubble(int frameDelay)
	{
		Monster monster = base.dungeon.SpawnMonster(Type.Bubble);
		monster.transform.position = base.pos + new Vector3(0f, -0.125f);
		if (base.dungeon.harderBosses)
		{
			monster.health += 5;
			monster.maxHealth += 5;
			monster.damage += 2;
			monster.speed += 0.15f;
		}
		AudioManager.Sound c = Utils.RandElem(new List<AudioManager.Sound>
		{
			AudioManager.Sound.Underwater_Bubble_0,
			AudioManager.Sound.Underwater_Bubble_1,
			AudioManager.Sound.Underwater_Bubble_2
		});
		base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
	}

	public void DownAnim()
	{
		base.animator.CustomAnim(downSprites, 6f);
	}

	public void UpAnim()
	{
		base.animator.CustomAnim(upSprites, 6f);
	}

	public override void InitStats()
	{
		attackDistance = -1f;
		list = new List<Attacks>
		{
			Attacks.Spiral,
			Attacks.Stream,
			Attacks.Wave,
			Attacks.Cross
		};
		if (base.dungeon.state == Dungeon.State.Combat)
		{
			StartCoroutine(Adds());
		}
		list = Utils.Shuffle(list);
	}

	private void StartFloater()
	{
		if (floater == null)
		{
			floater = StartCoroutine(floatAnim());
		}
	}

	private void EndFloater()
	{
		if (floater != null)
		{
			StopCoroutine(floater);
			floater = null;
		}
	}

	private IEnumerator floatAnim()
	{
		float t = 0f;
		Vector3 p = new Vector3(base.pos.x, base.pos.y);
		while (true)
		{
			base.pos = p + new Vector3(0f, Mathf.Sin(t)) * -2f / 16f;
			t += 0.05f;
			yield return Wait(1);
		}
	}

	private void Update()
	{
		if (!splashing)
		{
			base.spriteRenderer.flipX = base.pos.x > base.player.pos.x;
		}
	}

	public override void InitPosition(float presetAngle = -1f)
	{
		base.pos = new Vector3(Utils.RandSign(4.5f) + base.player.pos.x, -9f);
	}

	public override IEnumerator Movement()
	{
		if (!init)
		{
			init = true;
			burst = 0.36375f;
			while (base.pos.y < 0f)
			{
				base.pos += new Vector3(0f, 1f) * burst;
				burst -= 0.0075f;
				burst = Mathf.Max(0.0075f, burst);
				yield return Wait(1);
			}
		}
		if (t > 0)
		{
			if (t == attackTime)
			{
				StartFloater();
			}
			t--;
			if (t == 20)
			{
				DownAnim();
			}
			if (t == 0)
			{
				UpAnim();
				EndFloater();
			}
			yield return Wait(1);
			yield break;
		}
		t = attackTime;
		Attacks attacks = list[atkInd++ % list.Count];
		switch (attacks)
		{
		case Attacks.Spiral:
			yield return Spiral();
			break;
		case Attacks.Wave:
			yield return Wave();
			break;
		case Attacks.Stream:
			yield return Stream();
			break;
		case Attacks.Adds:
			yield return Adds();
			break;
		case Attacks.Cross:
			yield return Cross();
			break;
		default:
			Debug.LogWarning("Unknown Squid Attack: " + attacks);
			break;
		}
		yield return SplashItems();
		yield return Wait(1);
	}

	private IEnumerator Wave()
	{
		float angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		float rad = Vector3.Distance(base.pos, base.player.pos);
		float t = 0f;
		int i = 0;
		int dir = Utils.RandSign();
		int count = 3;
		while (count > 0)
		{
			if (i % 20 == 0)
			{
				if (count != 3)
				{
					yield return Wait(10);
					DownAnim();
					yield return Wait(10);
					UpAnim();
				}
				float num = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
				Vector3 vector = Utils.Dir(num);
				Vector3 vector2 = Utils.Dir(num + MathF.PI / 20f);
				Vector3 vector3 = Utils.Dir(num - MathF.PI / 20f);
				CreateBubble(vector * rad, 0);
				CreateBubble(vector2 * (rad + 0.4f), 0);
				CreateBubble(vector3 * (rad + 0.4f), 0);
				AudioManager.Sound c = Utils.RandElem(new List<AudioManager.Sound>
				{
					AudioManager.Sound.Underwater_Bubble_0,
					AudioManager.Sound.Underwater_Bubble_1,
					AudioManager.Sound.Underwater_Bubble_2
				});
				base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
				base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
				base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
				count--;
				if (count == 0)
				{
					break;
				}
			}
			base.transform.position = base.player.pos + rad * Utils.Dir(angle + t);
			i++;
			t += (float)dir * 0.1f;
			yield return Wait(1);
		}
	}

	private IEnumerator Spiral()
	{
		float angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		float rad = Vector3.Distance(base.pos, base.player.pos);
		float r = rad;
		float t = 0f;
		int i = 0;
		int dir = Utils.RandSign();
		while (t < MathF.PI * 2f)
		{
			if (i % 5 == 0)
			{
				CreateBubble(0);
			}
			base.transform.position = base.player.pos + rad * Utils.Dir(angle + (float)dir * t);
			i++;
			t += 0.075f;
			rad = r + Mathf.Sin(t / 2f) * 1f;
			yield return Wait(1);
		}
	}

	private IEnumerator Stream()
	{
		float angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		float rad = Vector3.Distance(base.pos, base.player.pos);
		float t = 0f;
		int i = 0;
		int time = 75;
		Utils.RandSign();
		float t2 = 0f;
		float angMod = UnityEngine.Random.Range(4f, 7f);
		while (time > 0)
		{
			if (i % 10 == 0)
			{
				CreateBubble(0);
			}
			base.transform.position = base.player.pos + rad * Utils.Dir(angle + t);
			i++;
			t = MathF.PI / angMod * Mathf.Sin(t2);
			t2 += 0.1f;
			time--;
			yield return Wait(1);
		}
	}

	private IEnumerator Adds()
	{
		yield return Wait(60);
		while (true)
		{
			base.dungeon.SpawnMonster(base.dungeon.randomMonster);
			yield return Wait(15);
		}
	}

	private IEnumerator Cross()
	{
		float angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		float rad = Vector3.Distance(base.pos, base.player.pos);
		_ = rad;
		float t = 0f;
		int i = 0;
		int dir = Utils.RandSign();
		while (t < MathF.PI * 6f)
		{
			if (i % 11 == 0)
			{
				CreateBubble(0);
			}
			base.transform.position = base.player.pos + rad * Utils.Dir(angle + (float)dir * t);
			i++;
			t += 0.15f;
			yield return Wait(1);
		}
	}

	public IEnumerator SplashItems()
	{
		List<Module> targets = new List<Module>();
		foreach (Module item in base.dungeon.board.GetBoard())
		{
			if ((item.MOVEMOD || item.PET || item.WAND) && !item.SPLASH)
			{
				targets.Add(item);
			}
		}
		if (targets.Count == 0)
		{
			yield break;
		}
		UpAnim();
		yield return Dungeon.Wait(5);
		bool oflip = base.spriteRenderer.flipX;
		base.spriteRenderer.flipX = true;
		DownAnim();
		Module tar = Utils.RandElem(targets);
		Vector3 a = charger.transform.position;
		int chargeTime = 30;
		for (int i = 0; i < chargeTime; i++)
		{
			if (i == 0)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.BubbleCharge, 0.85f, 0.8f);
			}
			if (i == 10)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.BubbleCharge, 1f, 0.9f);
			}
			if (i == 20)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.BubbleCharge, 1.15f);
			}
			base.spriteRenderer.flipX = true;
			base.dungeon.animationManager.LerpZoom(charger, Vector3.one, chargeTime);
			base.dungeon.animationManager.Spin(charger, Utils.RandSign() * 10, chargeTime);
			yield return Dungeon.Wait(1);
		}
		int num = 4;
		string[] array = new string[3] { "0CF1FF", "00CDF9", "94FDFF" };
		float num2 = 360f / (float)num;
		for (int j = 0; j < num; j++)
		{
			Vector3 vector = tar.transform.position + 0.5f * Utils.DirEuler(num2 * (float)j + (float)UnityEngine.Random.Range(-20, 20));
			base.dungeon.animationManager.CreateGibs(array[j % array.Length], vector, 5f, 0.1f, unmasked: true);
			base.dungeon.animationManager.CreateWave(a, vector, array[j % array.Length], 0.3f, silent: true, unmasked: true);
		}
		base.dungeon.audioManager.PlaySound(AudioManager.Sound.BossSplash);
		tar.Splash(150, 0.4f);
		base.dungeon.animationManager.LerpZoom(charger, Vector3.zero, 2f);
		UpAnim();
		yield return Dungeon.Wait(base.dungeon.harderBosses ? 10 : 20);
		base.spriteRenderer.flipX = oflip;
		splashing = false;
	}
}
