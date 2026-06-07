using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Module owner;

	public int cooldown;

	public int side;

	public List<Module> mods;

	public Vector3 pos = Vector3.zero;

	public Vector3 scale = Vector3.one;

	public Module currentModule;

	private List<Module> lateMods = new List<Module>();

	public bool noInput = true;

	public float o;

	private Vector3 magnetMomentum = Vector3.zero;

	public Player player => dungeon.player;

	public bool UPGRADED => owner.UPGRADED;

	public int damage => owner.damage;

	public Dungeon dungeon => owner.dungeon;

	public AnimationManager animationManager => owner.dungeon.animationManager;

	public void PlaySound(AudioManager.Sound s)
	{
		dungeon.audioManager.PlaySound(s);
	}

	public IEnumerator Wait(int x)
	{
		return Dungeon.Wait(x);
	}

	public void Hit(Monster monster)
	{
		for (int i = 0; i < owner.repeat; i++)
		{
			StartCoroutine(delayedTrig(monster, (i + 1) * 5));
		}
		HitTrigger(monster);
		if (monster.health <= 0)
		{
			KillTrigger(monster);
		}
		SpecialTriggers(monster);
	}

	private IEnumerator delayedTrig(Monster monster, int f)
	{
		yield return Dungeon.Wait(f);
		HitTrigger(monster);
		if (monster.health <= 0)
		{
			KillTrigger(monster);
		}
	}

	public virtual void ProjectileHit(Monster monster)
	{
		SpecialTriggers(monster);
	}

	public virtual void HitTrigger(Monster monster)
	{
	}

	public virtual void KillTrigger(Monster monster)
	{
	}

	public void SpecialTriggers(Monster monster)
	{
		foreach (Trigger trigger in dungeon.player.triggers)
		{
			trigger.ActivateTrigger(this, monster, Trigger.Type.Hit);
			if (monster.health <= 0)
			{
				trigger.ActivateTrigger(this, monster, Trigger.Type.Kill);
			}
		}
		foreach (Trigger trigger2 in owner.triggers)
		{
			trigger2.ActivateTrigger(this, monster, Trigger.Type.Hit);
			if (monster.health <= 0)
			{
				trigger2.ActivateTrigger(this, monster, Trigger.Type.Kill);
			}
		}
		foreach (Module input in owner.inputs)
		{
			if (Module.wireMods.Contains(input.name))
			{
				continue;
			}
			foreach (Trigger trigger3 in input.triggers)
			{
				trigger3.ActivateTrigger(this, monster, Trigger.Type.Hit);
				if (monster.health <= 0)
				{
					trigger3.ActivateTrigger(this, monster, Trigger.Type.Kill);
				}
			}
		}
	}

	public void SpecialKillTriggers(Monster monster)
	{
		foreach (Trigger trigger in dungeon.player.triggers)
		{
			if (monster.health <= 0)
			{
				trigger.ActivateTrigger(this, monster, Trigger.Type.Kill);
			}
		}
		foreach (Trigger trigger2 in owner.triggers)
		{
			if (monster.health <= 0)
			{
				trigger2.ActivateTrigger(this, monster, Trigger.Type.Kill);
			}
		}
		foreach (Module input in owner.inputs)
		{
			if (Module.wireMods.Contains(input.name))
			{
				continue;
			}
			foreach (Trigger trigger3 in input.triggers)
			{
				if (monster.health <= 0)
				{
					trigger3.ActivateTrigger(this, monster, Trigger.Type.Kill);
				}
			}
		}
	}

	public virtual void CastSpell()
	{
	}

	public void SetCooldown(float seconds)
	{
		cooldown = (int)(seconds * 60f);
		foreach (Module input in owner.inputs)
		{
			input.ResetPhase();
		}
	}

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
		StartCoroutine(Spin());
		StartCoroutine(ParseModules());
		GetOffset();
	}

	private void GetOffset()
	{
		int num = 0;
		bool flag = true;
		do
		{
			o = UnityEngine.Random.Range(0f, MathF.PI / 2f);
			foreach (Weapon value in dungeon.weaponMods.Values)
			{
				if (!(value == this) && Mathf.Abs(value.o - o) < MathF.PI / 8f)
				{
					flag = false;
				}
			}
			num++;
		}
		while (!flag && num < 1000);
	}

	private IEnumerator ParseModules()
	{
		while (true)
		{
			if (owner.ZAPPED)
			{
				base.transform.localPosition += Utils.RandDir() * 0.5f / 16f;
				yield return Dungeon.Wait(1);
				continue;
			}
			pos = Vector3.zero;
			scale = owner.scale;
			lateMods.Clear();
			noInput = true;
			foreach (Module input in owner.inputs)
			{
				if (cooldown > 0)
				{
					break;
				}
				if (input.WEAPON)
				{
					continue;
				}
				currentModule = input;
				switch (input.name)
				{
				case Module.Name.Horizontal:
					noInput = false;
					Horizontal();
					break;
				case Module.Name.Vertical:
					noInput = false;
					Vertical();
					break;
				case Module.Name.Circle:
					noInput = false;
					Circle();
					break;
				case Module.Name.Diagonal:
					noInput = false;
					Diagonal();
					break;
				case Module.Name.Quarter:
					noInput = false;
					Quarter();
					break;
				case Module.Name.Wave:
					noInput = false;
					Wave();
					break;
				case Module.Name.Point:
					noInput = false;
					Point();
					break;
				case Module.Name.Spiral:
					noInput = false;
					Spiral();
					break;
				case Module.Name.Triangle:
					noInput = false;
					Triangle();
					break;
				case Module.Name.Star:
					noInput = false;
					Star();
					break;
				case Module.Name.Square:
					noInput = false;
					Square();
					break;
				case Module.Name.Balloon:
					noInput = false;
					lateMods.Add(input);
					break;
				case Module.Name.Scaler:
					Scaler();
					break;
				case Module.Name.Magnet:
					Magnet();
					break;
				case Module.Name.Capacitor:
					if (dungeon.combat)
					{
						Capacitor();
					}
					break;
				case Module.Name.Fire:
					Fire();
					break;
				}
			}
			foreach (Module lateMod in lateMods)
			{
				if (cooldown > 0)
				{
					break;
				}
				if (!lateMod.WEAPON)
				{
					currentModule = lateMod;
					if (lateMod.name == Module.Name.Balloon)
					{
						Balloon();
					}
				}
			}
			if (cooldown > 0)
			{
				scale = Vector3.zero;
				cooldown--;
			}
			if (scale.x < 0f)
			{
				scale = new Vector3(0f, scale.y);
			}
			if (scale.y < 0f)
			{
				scale = new Vector3(scale.x, 0f);
			}
			base.transform.localScale = scale;
			if (noInput && pos == Vector3.zero)
			{
				pos = new Vector3(-1.2f + 2.4f * (float)side, 0f);
			}
			ProcessFrame();
			yield return Dungeon.Wait(1);
		}
	}

	public virtual void ProcessFrame()
	{
		base.transform.localPosition = pos;
	}

	public static float PointTo(Vector3 g, Vector3 target, float ang = 0f)
	{
		return 180f / MathF.PI * Mathf.Atan2(g.y - target.y, g.x - target.x) + ang;
	}

	public virtual IEnumerator Spin()
	{
		Vector3 OP = base.transform.position;
		float lastAng = base.transform.localEulerAngles.z;
		while (true)
		{
			float num = PointTo(OP, base.transform.position, 90f);
			if (Mathf.Abs(lastAng + 360f - num) < Mathf.Abs(lastAng - num))
			{
				lastAng += 360f;
			}
			else if (Mathf.Abs(lastAng - 360f - num) < Mathf.Abs(lastAng - num))
			{
				lastAng -= 360f;
			}
			if (Mathf.Abs(num - lastAng) >= 1f)
			{
				num = Mathf.Lerp(lastAng, num, 0.2f);
			}
			base.transform.localEulerAngles = new Vector3(0f, 0f, num);
			lastAng = num;
			OP = base.transform.position;
			yield return Dungeon.Wait(1);
		}
	}

	public void Horizontal()
	{
		Horizontal component = currentModule.GetComponent<Horizontal>();
		pos += new Vector3(component.amp * Mathf.Sin(component.t + o), 0f);
	}

	public void Vertical()
	{
		Horizontal component = currentModule.GetComponent<Horizontal>();
		pos += new Vector3(0f, component.amp * Mathf.Sin(component.t + o));
	}

	public void Balloon()
	{
		Horizontal component = currentModule.GetComponent<Horizontal>();
		pos += new Vector3(0f, 1f + 0.5f * Mathf.Sin(component.t + o));
	}

	public void Circle()
	{
		Horizontal component = currentModule.GetComponent<Horizontal>();
		pos += new Vector3(component.amp * Mathf.Cos(component.t + o), component.amp * Mathf.Sin(component.t + o));
	}

	public void Square()
	{
		Horizontal component = currentModule.GetComponent<Horizontal>();
		float amp = component.amp;
		Vector3 vector = new Vector3((amp + 1f) * Mathf.Cos(component.t + o), (amp + 1f) * Mathf.Sin(component.t + o));
		vector = new Vector3(Mathf.Clamp(vector.x, 0f - amp, amp), Mathf.Clamp(vector.y, 0f - amp, amp));
		pos += vector;
	}

	public void Scaler()
	{
		Horizontal component = currentModule.GetComponent<Horizontal>();
		float num = component.amp * 0.33f;
		scale += num * Mathf.Sin(component.t + o) * Vector3.one + (component.UPGRADED ? (Vector3.one * 0.5f) : Vector3.zero);
	}

	public void Star()
	{
		Star component = currentModule.GetComponent<Star>();
		float x = component.x;
		float f = (component.angle - 180f) * MathF.PI / 180f + (float)(component.wing * 2) * MathF.PI / component.points;
		pos += x * new Vector3(Mathf.Cos(f), Mathf.Sin(f));
	}

	public void Spiral()
	{
		Horizontal component = currentModule.GetComponent<Horizontal>();
		float num = 2f + component.amp * Mathf.Sin(component.x);
		pos += num * new Vector3(Mathf.Cos(component.t + o), Mathf.Sin(component.t + o));
	}

	public void Diagonal()
	{
		Diagonal component = currentModule.GetComponent<Diagonal>();
		float f = (component.angle - 180f) * MathF.PI / 180f;
		_ = component.amp;
		Mathf.Sin(component.t);
		float num = 0.3f;
		float x = component.amp * Mathf.Cos(f) * Mathf.Cos(component.t + o) - component.amp * num * Mathf.Sin(f) * Mathf.Sin(component.t + o);
		float y = component.amp * Mathf.Sin(f) * Mathf.Cos(component.t + o) + component.amp * num * Mathf.Cos(f) * Mathf.Sin(component.t + o);
		pos += new Vector3(x, y);
	}

	public void Triangle()
	{
		Triangle component = currentModule.GetComponent<Triangle>();
		float num = (component.angle - 180f) * MathF.PI / 180f;
		Vector3 vector = component.amp * new Vector3(Mathf.Cos(num), Mathf.Sin(num));
		Vector3 vector2 = component.amp * new Vector3(Mathf.Cos(num + MathF.PI * 2f / 3f), Mathf.Sin(num + MathF.PI * 2f / 3f));
		Vector3 vector3 = component.amp * new Vector3(Mathf.Cos(num + 4.1887903f), Mathf.Sin(num + 4.1887903f));
		Vector3 vector4 = vector;
		float t = component.t / (float)component.maxT;
		switch (component.x)
		{
		case 0:
			vector4 = Vector3.Lerp(vector, vector2, t);
			break;
		case 1:
			vector4 = Vector3.Lerp(vector2, vector3, t);
			break;
		case 2:
			vector4 = Vector3.Lerp(vector3, vector, t);
			break;
		}
		pos += vector4;
	}

	public void Quarter()
	{
		Quarter component = currentModule.GetComponent<Quarter>();
		float f = (component.angle - 180f) * MathF.PI / 180f + component.t + o;
		float amp = component.amp;
		pos += amp * new Vector3(Mathf.Cos(f), Mathf.Sin(f));
	}

	public void Point()
	{
		Point component = currentModule.GetComponent<Point>();
		float f = (component.angle - 180f) * MathF.PI / 180f;
		float amp = component.amp;
		pos += amp * new Vector3(Mathf.Cos(f), Mathf.Sin(f));
	}

	public void Wave()
	{
		Horizontal component = currentModule.GetComponent<Horizontal>();
		pos += new Vector3(component.ampMult * component.x * 0.5f, component.amp * Mathf.Sin(component.t + o));
	}

	public void Magnet()
	{
		List<Monster> list = new List<Monster>();
		float amp = currentModule.amp;
		foreach (Monster livingEnemy in dungeon.livingEnemies)
		{
			if (Vector3.Distance(base.transform.position, livingEnemy.transform.position) <= amp)
			{
				list.Add(livingEnemy);
			}
		}
		foreach (Monster item in list)
		{
			Vector3 normalized = (item.transform.position - base.transform.position).normalized;
			float num = currentModule.accel * (1f - Vector3.Distance(item.transform.position, base.transform.position) / amp);
			if (currentModule.UPGRADED)
			{
				item.transform.position += num / 2.5f * -normalized;
			}
			Vector3 vector = num * normalized;
			magnetMomentum += vector;
		}
		pos += magnetMomentum;
		magnetMomentum += -magnetMomentum * 0.005f;
	}

	public virtual void Fire()
	{
		Fire component = currentModule.GetComponent<Fire>();
		if (component.trigger)
		{
			component.CreateFireParticle(this);
		}
	}

	public virtual void Capacitor()
	{
		Capacitor component = currentModule.GetComponent<Capacitor>();
		if (component.t == 0)
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Electric);
			Projectile projectile = dungeon.animationManager.CreateExplosion("FFA214", "FFC825", 10, insta: true);
			projectile.sourceModule = component;
			projectile.transform.position = base.transform.position;
			projectile.transform.localScale = base.transform.localScale * 1.2f;
		}
	}
}
