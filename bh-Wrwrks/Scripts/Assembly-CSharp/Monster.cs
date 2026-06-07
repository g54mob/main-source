using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
	public enum Debuff
	{
		None = 0,
		Slow = 1,
		Stun = 2,
		Oil = 3,
		Knockback = 4
	}

	public enum Type
	{
		Zombie = 0,
		Grunt = 1,
		Wizard = 2,
		Soldier = 3,
		Bat = 4,
		Skull = 5,
		Redbat = 6,
		Archer = 7,
		Sapper = 8,
		BOSS_Saint = 9,
		Skeleton = 10,
		Gold = 11,
		Naga = 12,
		Jellyfish = 13,
		Tadpole = 14,
		Submarine = 15,
		Snake = 16,
		Naga_Soldier = 17,
		Fishbones = 18,
		Red_Jellyfish = 19,
		BOSS_Squid = 20,
		Gold_Naga = 21,
		Bubble = 22,
		Naga_Tank = 23,
		Rocket = 24,
		Rocket_Soldier = 25,
		UFO = 26,
		UFO_Soldier = 27,
		Asteroid_L = 28,
		Asteroid_M0 = 29,
		Asteroid_M1 = 30,
		Asteroid_S = 31,
		Drill = 32,
		Bot = 33,
		BOSS_Mothership = 34,
		Deathbot = 35,
		Gold_UFO = 36,
		Charger = 37
	}

	public int health = 1;

	public int damage = 1;

	private List<MonoBehaviour> hitters = new List<MonoBehaviour>();

	[NonSerialized]
	public int maxHealth;

	public float speedMult = 1f;

	public bool customSprite;

	public SpriteRenderer customSpriteRenderer;

	private bool STUNNED;

	private bool SLOWED;

	private bool OIL;

	public Type type;

	private Healthbar healthbar;

	public Material default_mat;

	public bool boss;

	private float _speedInternal = 0.5f;

	public float attackDistance = 1.1f;

	public bool knockbacking;

	private ushort oilTimer;

	private ushort slowTimer;

	public SpriteRenderer spriteRenderer
	{
		get
		{
			if (!customSprite)
			{
				return GetComponent<SpriteRenderer>();
			}
			return customSpriteRenderer;
		}
	}

	public Dungeon dungeon => Dungeon.Instance;

	public Player player => dungeon.player;

	public Animator animator => GetComponent<Animator>();

	public Vector3 pos
	{
		get
		{
			return base.transform.position;
		}
		set
		{
			base.transform.position = value;
		}
	}

	public float speed
	{
		get
		{
			return _speedInternal * speedMult;
		}
		set
		{
			_speedInternal = value;
		}
	}

	public GameObject ShootProjectile(GameObject projectile, int frames, Vector3 dir, bool spin = true)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(projectile);
		gameObject.transform.position = pos + dir * 0.25f;
		gameObject.GetComponent<EnemyProjectile>().damage = damage;
		gameObject.GetComponent<EnemyProjectile>().Timer(frames);
		if (spin)
		{
			dungeon.animationManager.Spin(gameObject, 10f);
		}
		else
		{
			AnimationManager.PointTo(gameObject, player.pos, 90f);
		}
		dungeon.animationManager.LerpTo(gameObject, player.pos, frames, 0f, slerp: false, destroy: true);
		return gameObject;
	}

	public IEnumerator Wait(int x)
	{
		for (int i = 0; i < x; i++)
		{
			while (STUNNED)
			{
				yield return null;
			}
			yield return Dungeon.Wait(1);
		}
	}

	public Vector3 RandomDirection()
	{
		Vector3 vector = new Vector3(player.transform.position.x, player.transform.position.y);
		float f = UnityEngine.Random.Range(0f, 360f) * MathF.PI / 180f;
		vector.x += Mathf.Cos(f);
		vector.y += Mathf.Sin(f);
		return (player.transform.position - vector).normalized;
	}

	public virtual void InitStats()
	{
		attackDistance = 1.125f;
	}

	public void Init(float fixedAngle = -1f)
	{
		Database.MonsterInfo monsterInfo = Database.GetMonsterInfo(type);
		boss = type.ToString().Contains("BOSS");
		if ((dungeon.harderEnemies && !boss) || (boss && dungeon.harderBosses))
		{
			health = (maxHealth = monsterInfo.healthUp);
			damage = monsterInfo.damageUp;
		}
		else
		{
			health = (maxHealth = monsterInfo.health);
			damage = monsterInfo.damage;
		}
		if (dungeon.fasterEnemies)
		{
			speed = monsterInfo.speedUp;
		}
		else
		{
			speed = monsterInfo.speed;
		}
		if (dungeon.endlessLevel > 0)
		{
			int num;
			int num2;
			float num3;
			if (dungeon.demo)
			{
				num = 75;
				num2 = 8 + 4 * (dungeon.currLevel - dungeon.maxLevel);
				num3 = 0.08f;
			}
			else
			{
				num = 150;
				num2 = 40 + 4 * (dungeon.currLevel - dungeon.maxLevel);
				num3 = 0.15f;
			}
			if (boss)
			{
				health += dungeon.endlessLevel * num;
				maxHealth += dungeon.endlessLevel * num;
			}
			else
			{
				health += dungeon.endlessLevel * num2;
				maxHealth += dungeon.endlessLevel * num2;
			}
			speed *= 1f + num3 * (float)dungeon.endlessLevel;
			damage += dungeon.endlessLevel;
		}
		default_mat = spriteRenderer.material;
		spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
		Healthbar component = UnityEngine.Object.Instantiate(dungeon.healthbarObject).GetComponent<Healthbar>();
		component.transform.parent = base.transform;
		component.transform.localScale = Vector3.one;
		component.monster = this;
		healthbar = component;
		BoxCollider2D component2 = GetComponent<BoxCollider2D>();
		component.transform.localPosition = component2.offset + new Vector2(0f, component2.size.y / 2f + 0.125f);
		InitPosition(fixedAngle);
		InitStats();
		StartRoute();
	}

	public virtual void InitPosition(float presetAngle = -1f)
	{
		Vector3 vector;
		if (presetAngle != -1f)
		{
			vector = new Vector3(player.transform.position.x, player.transform.position.y);
			vector.x += Mathf.Cos(presetAngle);
			vector.y += Mathf.Sin(presetAngle);
			vector = (player.transform.position - vector).normalized;
		}
		else
		{
			vector = RandomDirection();
		}
		pos = player.transform.position + vector * 9f;
	}

	public virtual void StartRoute()
	{
		StartCoroutine(Route());
	}

	public IEnumerator Route()
	{
		while (true)
		{
			if (!(Vector3.Distance(pos, player.pos) <= attackDistance))
			{
				yield return Movement();
			}
			else if (dungeon.player.health > 0)
			{
				yield return Attack();
			}
			else
			{
				yield return null;
			}
		}
	}

	public virtual IEnumerator Movement()
	{
		Vector3 normalized = (player.transform.position - base.transform.position).normalized;
		spriteRenderer.flipX = pos.x < player.pos.x;
		float num = speed / 16f;
		pos += normalized * num;
		if (!(Vector3.Distance(pos, player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}

	public virtual IEnumerator Attack()
	{
		Vector3 dir = (player.transform.position - base.transform.position).normalized;
		player.Hurt(damage);
		float dist = 0.25f;
		base.transform.position += dir * dist;
		for (int i = 0; i < 4; i++)
		{
			base.transform.position += dir * (0f - dist) / 4f;
			yield return Wait(2);
		}
		yield return Wait(60);
	}

	public void LogDamage(int damage, MonoBehaviour m, Module source)
	{
		if (source == null && m != null)
		{
			bool num = m.GetComponents<Projectile>().Length != 0;
			bool flag = m.GetComponents<Weapon>().Length != 0;
			if (num)
			{
				Projectile projectile = m.GetComponents<Projectile>()[0];
				if (projectile.sourceModule != null)
				{
					source = projectile.sourceModule;
				}
				else if (projectile.source != null)
				{
					source = projectile.source.owner;
				}
			}
			else if (flag)
			{
				source = m.GetComponents<Weapon>()[0].owner;
			}
		}
		if (source != null)
		{
			dungeon.DPS.AddDamage(source, damage);
		}
	}

	public void Hurt(int damage = 1, MonoBehaviour m = null, bool noDeathrattle = false, int offset = 2, Module source = null, string customColor = "")
	{
		if (damage == 0 || health <= 0 || hitters.Contains(m))
		{
			return;
		}
		if (OIL)
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Sizzle0);
			damage += 2;
		}
		if (!noDeathrattle)
		{
			StartCoroutine(Flash(m));
			dungeon.animationManager.CreateNumber(damage, base.transform.position + new Vector3(Utils.RandSign(offset) / 16f, (float)(3 - offset) / 16f), Number.Type.Damage, customColor);
		}
		LogDamage(Mathf.Min(health, damage), m, source);
		health -= damage;
		if (!noDeathrattle && m != null)
		{
			if (m.GetComponents<Projectile>().Length != 0)
			{
				HitProjectileEffect();
			}
			else
			{
				HitEffect();
			}
		}
		if (health <= 0)
		{
			GetComponent<BoxCollider2D>().enabled = false;
			StopAllCoroutines();
			if (!noDeathrattle)
			{
				DeathEffect();
			}
			StartCoroutine(Death());
			if (!noDeathrattle)
			{
				PlayDeathSound(m);
			}
		}
		else
		{
			HitVisual();
			if (!noDeathrattle)
			{
				PlayHitSound(m);
			}
		}
	}

	public virtual void PlayHitSound(MonoBehaviour m)
	{
		Module.Name monobehaviorMod = GetMonobehaviorMod(m);
		if (monobehaviorMod <= Module.Name.Laser)
		{
			switch (monobehaviorMod)
			{
			}
		}
		else if (monobehaviorMod != Module.Name.Flame)
		{
			_ = 97;
		}
		dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Hit, 0.9f, 1.1f, 1f);
	}

	public virtual void PlayDeathSound(MonoBehaviour m)
	{
		Module.Name monobehaviorMod = GetMonobehaviorMod(m);
		if (type > Type.Gold && type <= Type.Naga_Tank && type != Type.Bubble)
		{
			AudioManager.Sound c = Utils.RandElem(new List<AudioManager.Sound>
			{
				AudioManager.Sound.Underwater_Bubble_0,
				AudioManager.Sound.Underwater_Bubble_1,
				AudioManager.Sound.Underwater_Bubble_2
			});
			dungeon.audioManager.PlaySoundRandomized(c, 0.9f, 1.1f, 0.9f, 0.9f);
		}
		if (monobehaviorMod != Module.Name.Fire && monobehaviorMod != Module.Name.Laser)
		{
			_ = 51;
		}
		switch (type)
		{
		case Type.BOSS_Saint:
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Boss_Goblin, 0.9f, 1.1f, 1f);
			break;
		case Type.BOSS_Squid:
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Boss_Squid, 0.9f, 1.1f, 1f);
			break;
		case Type.Bat:
		case Type.Redbat:
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Bat, 0.9f, 1.1f, 1f);
			break;
		case Type.Jellyfish:
		case Type.Tadpole:
		case Type.Snake:
		case Type.Red_Jellyfish:
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Fish, 0.9f, 1.1f, 1f);
			break;
		case Type.Skull:
		case Type.Skeleton:
		case Type.Fishbones:
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Bones, 0.9f, 1.1f, 1f);
			break;
		case Type.Submarine:
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Crash, 0.9f, 1.1f, 1f);
			break;
		case Type.Bubble:
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Basic, 0.9f, 1.1f, 1f);
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Bubble, 0.9f, 1.1f, 1f);
			break;
		default:
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Monster_Death_Basic, 0.9f, 1.1f, 1f);
			break;
		}
	}

	private Module.Name GetMonobehaviorMod(MonoBehaviour m)
	{
		Module.Name result = Module.Name.Sword;
		if (m != null)
		{
			if (m.GetComponents<Projectile>().Length != 0)
			{
				if (m.GetComponents<Projectile>()[0].source != null)
				{
					result = m.GetComponents<Projectile>()[0].source.owner.name;
				}
				else if (m.GetComponents<Projectile>()[0].sourceModule != null)
				{
					result = m.GetComponents<Projectile>()[0].sourceModule.name;
				}
			}
			else if (m.GetComponents<Weapon>().Length != 0)
			{
				result = m.GetComponents<Weapon>()[0].owner.name;
			}
		}
		return result;
	}

	private IEnumerator Flash(MonoBehaviour m)
	{
		bool trackWep = false;
		MonoBehaviour tracked = null;
		if (m != null)
		{
			if (m.GetComponents<Projectile>().Length != 0)
			{
				Projectile component = m.GetComponent<Projectile>();
				if (component.sharedWeapon)
				{
					tracked = ((component.source == null) ? ((MonoBehaviour)component.sourceModule) : ((MonoBehaviour)component.source));
					trackWep = true;
					hitters.Add(tracked);
				}
			}
			hitters.Add(m);
		}
		spriteRenderer.material = dungeon.shadowMat;
		yield return Dungeon.Wait(10);
		spriteRenderer.material = default_mat;
		yield return Dungeon.Wait(3);
		hitters.Remove(m);
		if (trackWep)
		{
			hitters.Remove(tracked);
		}
	}

	public virtual IEnumerator Death()
	{
		dungeon.livingEnemies.Remove(this);
		CreateGibs();
		GetComponent<Collider2D>().enabled = false;
		yield return dungeon.animationManager.LerpZoom(base.gameObject, Vector3.zero, 2f);
		yield return Dungeon.Wait(20);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public virtual void HitEffect()
	{
		Knockback(0.0625f);
	}

	public virtual void HitProjectileEffect()
	{
	}

	public virtual void DeathEffect()
	{
	}

	public virtual void HitVisual()
	{
	}

	public void Knockback(float dist)
	{
		if (!boss)
		{
			StartCoroutine(Knocker(dist));
		}
	}

	private IEnumerator Knocker(float dist)
	{
		Monster m = this;
		float FRAMES = 3f;
		Vector3 dir = m.pos - m.player.pos;
		knockbacking = true;
		for (int i = 0; (float)i < FRAMES; i++)
		{
			m.pos += dir.normalized * dist / FRAMES;
			yield return Dungeon.Wait(1);
		}
		knockbacking = false;
	}

	public void Stun(float seconds)
	{
		if (!STUNNED && !boss)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(dungeon.StunEffect);
			gameObject.transform.position = healthbar.transform.position;
			gameObject.transform.parent = base.transform;
			gameObject.transform.localScale = Vector3.one;
			StartCoroutine(Stunner(seconds, gameObject));
		}
	}

	private IEnumerator Stunner(float s, GameObject g)
	{
		STUNNED = true;
		yield return Dungeon.Wait((int)(s * 60f));
		STUNNED = false;
		UnityEngine.Object.Destroy(g);
	}

	public virtual void CreateGibs()
	{
		List<(string, int)> list = new List<(string, int)>();
		switch (type)
		{
		default:
			list.Add(("5AC54F", 4));
			list.Add(("BF6F4A", 4));
			break;
		case Type.Grunt:
			list.Add(("5AC54F", 4));
			list.Add(("C7CFDD", 4));
			break;
		case Type.Soldier:
			list.Add(("5AC54F", 4));
			list.Add(("FFA214", 4));
			break;
		case Type.Wizard:
			list.Add(("5AC54F", 4));
			list.Add(("93388F", 4));
			break;
		case Type.Archer:
			list.Add(("5AC54F", 4));
			list.Add(("134C4C", 4));
			break;
		case Type.Sapper:
			list.Add(("5AC54F", 4));
			list.Add(("1E6F50", 4));
			list.Add(("EA323C", 2));
			break;
		case Type.Skull:
			list.Add(("B4B4B4", 5));
			break;
		case Type.Bat:
			list.Add(("0098DC", 5));
			break;
		case Type.Redbat:
			list.Add(("C42430", 5));
			break;
		case Type.Skeleton:
			list.Add(("FFFFFF", 4));
			break;
		case Type.BOSS_Saint:
			list.Add(("5AC54F", 5));
			list.Add(("C42430", 5));
			list.Add(("FFA214", 2));
			list.Add(("8A4836", 1));
			break;
		case Type.Gold:
		case Type.Gold_Naga:
		case Type.Gold_UFO:
			list.Add(("FFA214", 4));
			list.Add(("C64524", 4));
			break;
		case Type.Naga:
			list.Add(("0098DC", 4));
			list.Add(("C7CFDD", 4));
			break;
		case Type.Naga_Soldier:
			list.Add(("0098DC", 4));
			list.Add(("FFA214", 4));
			break;
		case Type.Naga_Tank:
			list.Add(("0098DC", 4));
			list.Add(("EDAB50", 4));
			break;
		case Type.Tadpole:
			list.Add(("0098DC", 5));
			break;
		case Type.Snake:
			list.Add(("33984B", 5));
			break;
		case Type.Fishbones:
			list.Add(("F9E6CF", 5));
			break;
		case Type.Jellyfish:
			list.Add(("CA52C9", 6));
			break;
		case Type.Red_Jellyfish:
			list.Add(("C42430", 6));
			break;
		case Type.Submarine:
			list.Add(("EDAB50", 5));
			list.Add(("F9E6CF", 3));
			break;
		case Type.BOSS_Squid:
			list.Add(("CA52C9", 8));
			list.Add(("FFA214", 2));
			break;
		case Type.Bubble:
			list.Add(("94FDFF", 2));
			break;
		case Type.Asteroid_L:
		case Type.Asteroid_M0:
		case Type.Asteroid_M1:
		case Type.Asteroid_S:
			list.Add(("C64524", 6));
			break;
		case Type.Rocket:
		case Type.UFO:
			list.Add(("D3FC7E", 4));
			list.Add(("C7CFDD", 4));
			break;
		case Type.Rocket_Soldier:
			list.Add(("D3FC7E", 4));
			list.Add(("FFA214", 4));
			break;
		case Type.UFO_Soldier:
			list.Add(("D3FC7E", 4));
			list.Add(("92A1B9", 5));
			break;
		case Type.Drill:
			list.Add(("C7CFDD", 5));
			list.Add(("424C6E", 5));
			break;
		case Type.Bot:
			list.Add(("C7CFDD", 7));
			break;
		case Type.Deathbot:
			list.Add(("8E251D", 7));
			break;
		case Type.BOSS_Mothership:
			list.Add(("C7CFDD", 15));
			break;
		}
		foreach (var item in list)
		{
			dungeon.animationManager.CreateGibs(item.Item1, base.transform.position, item.Item2);
		}
	}

	public void HitWeapon(Weapon wep)
	{
		if (!hitters.Contains(wep))
		{
			Hurt(wep.damage, wep);
			wep.Hit(this);
		}
	}

	private void HitProjectile(Projectile projectile)
	{
		if (!hitters.Contains(projectile) && (!projectile.sharedWeapon || !hitters.Contains((projectile.source == null) ? ((MonoBehaviour)projectile.sourceModule) : ((MonoBehaviour)projectile.source))) && !(projectile == null))
		{
			if (projectile.dieOnHit)
			{
				projectile.Die();
			}
			Hurt(projectile.damage, projectile);
			projectile.HitTrigger(this);
		}
	}

	public void ApplyDebuff(Debuff type, float value = 0f)
	{
		switch (type)
		{
		case Debuff.Knockback:
			Knockback(value);
			break;
		case Debuff.Stun:
			Stun(value);
			break;
		case Debuff.Oil:
			if (OIL)
			{
				oilTimer = (ushort)Mathf.Max((ushort)value, oilTimer);
				break;
			}
			oilTimer = (ushort)value;
			OIL = true;
			StartCoroutine(oilAnim());
			break;
		case Debuff.Slow:
			value += (float)(dungeon.board.CountAuras(Aura.Type.SlowBuff) * 30);
			if (SLOWED)
			{
				slowTimer = (ushort)Mathf.Max((ushort)value, slowTimer);
				break;
			}
			slowTimer = (ushort)value;
			SLOWED = true;
			StartCoroutine(slowAnim());
			break;
		}
	}

	private IEnumerator oilAnim()
	{
		int i = 0;
		float t = 0f;
		Color dp = Utils.GetColor("9398C3");
		float amp = 30f;
		while (oilTimer > 0)
		{
			spriteRenderer.color = Color.Lerp(Color.white, dp, (float)i / amp);
			i = (int)(amp / 2f * Mathf.Sin(t) + amp / 2f);
			t += 0.1f;
			oilTimer--;
			yield return Dungeon.Wait(1);
		}
		OIL = false;
		spriteRenderer.color = Color.white;
	}

	private IEnumerator slowAnim()
	{
		int i = 0;
		float t = 0f;
		Color dp = Utils.GetColor("8BF8FB");
		float amp = 30f;
		float slow = 0.25f + (float)dungeon.board.CountAuras(Aura.Type.SlowBuff) * 0.2f;
		speedMult -= slow;
		while (slowTimer > 0)
		{
			spriteRenderer.color = Color.Lerp(Color.white, dp, (float)i / amp);
			i = (int)(amp / 2f * Mathf.Sin(t) + amp / 2f);
			t += 0.1f;
			slowTimer--;
			yield return Dungeon.Wait(1);
		}
		SLOWED = false;
		speedMult += slow;
		spriteRenderer.color = Color.white;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponentsInChildren<Weapon>().Length != 0)
		{
			Weapon component = collision.gameObject.GetComponent<Weapon>();
			HitWeapon(component);
		}
		if (collision.gameObject.GetComponentsInChildren<Projectile>().Length != 0)
		{
			Projectile component2 = collision.gameObject.GetComponent<Projectile>();
			HitProjectile(component2);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool num = collision.gameObject.GetComponentsInChildren<Weapon>().Length != 0;
		bool flag = collision.gameObject.GetComponentsInChildren<Projectile>().Length != 0;
		if (num)
		{
			Weapon component = collision.gameObject.GetComponent<Weapon>();
			HitWeapon(component);
		}
		else if (flag)
		{
			Projectile component2 = collision.gameObject.GetComponent<Projectile>();
			HitProjectile(component2);
			component2.EnterMonster(this);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponentsInChildren<Projectile>().Length != 0)
		{
			collision.gameObject.GetComponent<Projectile>().ExitMonster(this);
		}
	}

	private void Update()
	{
	}
}
