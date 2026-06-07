using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Trigger
{
	public enum Ability
	{
		Lifesteal = 0,
		Chain_Lightning = 1,
		Meds = 2,
		Knockback = 3,
		Grimoire = 4,
		Dynamite = 5,
		Recycle = 6,
		RecycleReset = 7,
		Egg = 8,
		Cross = 9,
		Bandage = 10,
		BandageUpg = 11,
		Gold = 12,
		Field = 13,
		Stun = 14,
		Inductor_Zap = 15,
		PerkMidas = 16,
		Piggy = 17,
		Treat = 18,
		Slow = 19,
		Collar = 20,
		GlassKill = 21,
		GlassReset = 22,
		PerkRegen = 23,
		PerkVampire = 24,
		PerkChemicals = 25,
		PerkStatic = 26,
		PerkHail = 27,
		PerkSplinter = 28,
		PerkBlizzard = 29,
		PerkFeedback = 30,
		FlameMP = 31,
		NecroEnd = 32,
		Balloon = 33,
		LongstaffCheck = 34,
		Bell = 35,
		ToppedCheckHurt = 36,
		ToppedCheckHeal = 37,
		PerkFrostbite = 38,
		PerkSouldrain = 39,
		PerkWindwalk = 40,
		PerkTechtrash = 41,
		PerkRestore = 42,
		PerkStutter = 43,
		PerkSniper = 44,
		PerkHorsepower = 45,
		Monitor = 46,
		Food = 47,
		Soulrod = 48,
		Sonic = 49,
		Biochamber = 50,
		Channeler = 51,
		Raccoon = 52,
		PerkUnstable = 53,
		Vortex = 54,
		Phial = 55
	}

	public enum Type
	{
		Hit = 0,
		Kill = 1,
		End = 2,
		Reroll = 3,
		Heal = 4,
		Gold = 5,
		Hurt = 6,
		Start = 7,
		Timer = 8,
		Cast = 9,
		Force = 10,
		Buy = 11,
		Sell = 12
	}

	public Ability ability;

	public Module owner;

	public Aura source;

	public Type type;

	public float chance = 100f;

	public int value;

	public int damage = 1;

	private Dungeon dungeon => owner.dungeon;

	private Player player => owner.dungeon.player;

	private Board board => owner.dungeon.board;

	public Trigger(Ability a, Module m, Aura sourceAura = null, float proc = 100f, int val = 0, int dmg = 1, Type triggerType = Type.Hit)
	{
		ability = a;
		owner = m;
		source = sourceAura;
		chance = proc;
		damage = dmg;
		value = val;
		type = triggerType;
		switch (a)
		{
		case Ability.Lifesteal:
		case Ability.Chain_Lightning:
		case Ability.Knockback:
		case Ability.Stun:
		case Ability.Inductor_Zap:
		case Ability.Slow:
		case Ability.PerkSplinter:
		case Ability.Balloon:
		case Ability.Bell:
		case Ability.PerkSniper:
			type = Type.Hit;
			break;
		case Ability.Meds:
		case Ability.Dynamite:
		case Ability.Bandage:
		case Ability.BandageUpg:
		case Ability.PerkMidas:
		case Ability.Collar:
		case Ability.PerkVampire:
		case Ability.PerkChemicals:
		case Ability.PerkSouldrain:
		case Ability.PerkHorsepower:
			type = Type.Kill;
			break;
		case Ability.ToppedCheckHurt:
			type = Type.Hurt;
			break;
		case Ability.ToppedCheckHeal:
			type = Type.Heal;
			break;
		case Ability.PerkTechtrash:
			type = Type.Sell;
			break;
		case Ability.PerkFeedback:
		case Ability.FlameMP:
		case Ability.PerkRestore:
		case Ability.Channeler:
		case Ability.PerkUnstable:
		case Ability.Vortex:
			type = Type.Cast;
			break;
		case Ability.Grimoire:
		case Ability.Recycle:
		case Ability.RecycleReset:
		case Ability.Egg:
		case Ability.Cross:
		case Ability.Gold:
		case Ability.Field:
		case Ability.Piggy:
		case Ability.Treat:
		case Ability.GlassKill:
		case Ability.GlassReset:
		case Ability.PerkRegen:
		case Ability.PerkStatic:
		case Ability.PerkHail:
		case Ability.PerkBlizzard:
		case Ability.NecroEnd:
		case Ability.LongstaffCheck:
		case Ability.PerkFrostbite:
		case Ability.PerkWindwalk:
		case Ability.PerkStutter:
		case Ability.Monitor:
		case Ability.Food:
		case Ability.Soulrod:
		case Ability.Sonic:
		case Ability.Biochamber:
		case Ability.Raccoon:
			break;
		}
	}

	public void ActivateTrigger(Weapon weapon, Monster monster, Type t, Module module = null)
	{
		if ((t != type && t != Type.Force) || (chance != 0f && !Utils.RNG(chance) && t != Type.Force))
		{
			return;
		}
		if (t != Type.Force)
		{
			int num = owner.repeat;
			if (weapon != null && weapon.owner != owner)
			{
				num += weapon.owner.repeat;
			}
			for (int i = 0; i < num; i++)
			{
				owner.StartCoroutine(owner.delayedTrig(this, monster, weapon, Type.Force, module, (1 + i) * 5));
			}
		}
		if ((type != Type.Hit || (type == Type.Hit && chance != 0f && chance != 100f)) && owner != dungeon.player.sentinel)
		{
			Ability ability = this.ability;
			if (ability != Ability.Food && ability != Ability.Raccoon && ability != Ability.Phial)
			{
				owner.TriggerBounce();
			}
		}
		switch (this.ability)
		{
		case Ability.Lifesteal:
			Lifesteal(weapon);
			break;
		case Ability.Chain_Lightning:
			Chain_Lightning(monster);
			break;
		case Ability.Meds:
			Meds();
			break;
		case Ability.Knockback:
			Knockback(monster);
			break;
		case Ability.Grimoire:
			Grimoire();
			break;
		case Ability.Dynamite:
			Dynamite(monster, weapon);
			break;
		case Ability.Recycle:
			Recycle(reset: false);
			break;
		case Ability.RecycleReset:
			Recycle(reset: true);
			break;
		case Ability.Egg:
			Egg();
			break;
		case Ability.Cross:
			Cross();
			break;
		case Ability.Bandage:
			Bandage();
			break;
		case Ability.Gold:
			GoldScepter();
			break;
		case Ability.Field:
			Field();
			break;
		case Ability.Stun:
			Stun(monster);
			break;
		case Ability.Inductor_Zap:
			Inductor_Zap(monster);
			break;
		case Ability.PerkMidas:
			Midas(monster);
			break;
		case Ability.Piggy:
			Piggy();
			break;
		case Ability.Treat:
			Treat();
			break;
		case Ability.Slow:
			Slow(monster);
			break;
		case Ability.Collar:
			Collar(weapon, monster);
			break;
		case Ability.GlassKill:
			GlassKill();
			break;
		case Ability.GlassReset:
			GlassReset();
			break;
		case Ability.PerkRegen:
			PerkRegen();
			break;
		case Ability.PerkVampire:
			PerkVampire();
			break;
		case Ability.PerkChemicals:
			PerkChemicals();
			break;
		case Ability.PerkStatic:
			PerkStatic();
			break;
		case Ability.PerkHail:
			PerkHail();
			break;
		case Ability.PerkSplinter:
			PerkSplinter(weapon, monster);
			break;
		case Ability.PerkBlizzard:
			PerkBlizzard();
			break;
		case Ability.PerkFeedback:
			PerkFeedback(module);
			break;
		case Ability.FlameMP:
			FlameMP(module);
			break;
		case Ability.NecroEnd:
			NecroEnd();
			break;
		case Ability.Balloon:
			Balloon(monster, weapon);
			break;
		case Ability.LongstaffCheck:
			LongstaffCheck();
			break;
		case Ability.Bell:
			Bell(weapon);
			break;
		case Ability.ToppedCheckHurt:
		case Ability.ToppedCheckHeal:
			ToppedCheck();
			break;
		case Ability.PerkFrostbite:
			PerkFrostbite();
			break;
		case Ability.PerkSouldrain:
			PerkSouldrain();
			break;
		case Ability.PerkWindwalk:
			PerkWindwalk();
			break;
		case Ability.PerkTechtrash:
			PerkTechtrash(module);
			break;
		case Ability.PerkRestore:
			PerkRestore();
			break;
		case Ability.PerkStutter:
			PerkStutter();
			break;
		case Ability.PerkHorsepower:
			PerkHorsepower();
			break;
		case Ability.PerkSniper:
			PerkSniper(monster, weapon);
			break;
		case Ability.Monitor:
			Monitor();
			break;
		case Ability.Food:
			Food();
			break;
		case Ability.Soulrod:
			Soulrod(weapon, module);
			break;
		case Ability.Sonic:
			Sonic(module);
			break;
		case Ability.Biochamber:
			Biochamber();
			break;
		case Ability.Channeler:
			Channeler();
			break;
		case Ability.Raccoon:
			Raccoon(module);
			break;
		case Ability.PerkUnstable:
			PerkUnstable(module);
			break;
		case Ability.Vortex:
			Vortex(module);
			break;
		case Ability.Phial:
			Phial(module);
			break;
		default:
			Debug.LogError("UNDEFINED TRIGGER ABIL");
			break;
		}
	}

	private void LongstaffCheck()
	{
		if (player.health < player.maxHealth && owner.counter == 0)
		{
			owner.counter = 1;
			board.CheckAuras();
		}
		if (player.health == player.maxHealth && owner.counter == 1)
		{
			owner.counter = 0;
			board.CheckAuras();
		}
	}

	private void ToppedCheck()
	{
		if (player.health < player.maxHealth && source.value == 0f)
		{
			source.value = 1f;
			board.CheckAuras();
		}
		if (player.health == player.maxHealth && source.value == 1f)
		{
			source.value = 0f;
			board.CheckAuras();
		}
	}

	private void PerkRegen()
	{
		owner.dungeon.player.Heal(5);
	}

	private void PerkVampire()
	{
		owner.dungeon.player.Heal(1);
	}

	private void Lifesteal(Weapon wep)
	{
		owner.dungeon.player.Heal((!owner.UPGRADED) ? 1 : 2);
	}

	private void Meds()
	{
		owner.dungeon.player.Heal((!owner.UPGRADED) ? 1 : 2);
	}

	private void Bandage()
	{
		if (source.source.owner.UPGRADED)
		{
			owner.dungeon.player.Heal(2);
		}
		else
		{
			owner.dungeon.player.Heal(1);
		}
	}

	private void Knockback(Monster m)
	{
		m.Knockback(0.25f);
	}

	private void Grimoire()
	{
		Module module = owner.dungeon.board.CreateModuleSmall(Module.Name.Imp);
		if (module == null)
		{
			List<Module> list = new List<Module>();
			list.AddRange(board.GetBoard());
			list.AddRange(dungeon.bank.GetBank());
			foreach (Module item in list)
			{
				if (item.name == Module.Name.Imp && !item.UPGRADED)
				{
					owner.dungeon.board.UpgradeModule(item, silent: false, load: false, item.bankItem);
					return;
				}
			}
		}
		if (owner.UPGRADED && module != null)
		{
			owner.dungeon.board.UpgradeModule(module.index, silent: false, manual: false, loaded: false, module.bankItem);
		}
	}

	private void Dynamite(Monster m, Weapon weapon)
	{
		if (dungeon.animationManager.projGibs <= 200)
		{
			owner.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Small);
			Projectile projectile = owner.dungeon.animationManager.CreateExplosion("C42430", "EA323C", 10, insta: true);
			projectile.sourceModule = owner;
			projectile.transform.position = m.transform.position;
			projectile.transform.localScale = weapon.transform.localScale * 0.9f;
		}
	}

	private void Balloon(Monster m, Weapon weapon)
	{
		if (dungeon.animationManager.projGibs <= 200)
		{
			owner.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Balloon);
			Projectile projectile = owner.dungeon.animationManager.CreateExplosion("F389F5", "CA52C9", 10, insta: true, ticks: false, spin: true, shake: false);
			projectile.sourceModule = owner;
			projectile.transform.position = m.transform.position;
			projectile.transform.localScale = weapon.transform.localScale * 0.75f;
		}
	}

	private void Chain_Lightning(Monster m, float distance = 3.5f)
	{
		if (owner.name == Module.Name.Wind || owner.name == Module.Name.Maelstrom)
		{
			damage = owner.damage;
		}
		if (damage == 0)
		{
			return;
		}
		int num = value;
		LightningEffect component = Dungeon.Instance.InstantiateExternal(Dungeon.Instance.LightningEffect).GetComponent<LightningEffect>();
		List<Monster> list = new List<Monster> { m };
		Monster monster = m;
		num += owner.dungeon.board.CountAuras(Aura.Type.PerkConductor);
		for (int i = 0; i < num - 1; i++)
		{
			List<Monster> list2 = new List<Monster>();
			foreach (Monster livingEnemy in Dungeon.Instance.livingEnemies)
			{
				if (Vector3.Distance(livingEnemy.pos, monster.pos) < distance && !list.Contains(livingEnemy))
				{
					list2.Add(livingEnemy);
				}
			}
			if (list2.Count == 0)
			{
				break;
			}
			Monster monster2 = Utils.RandElem(list2);
			monster = monster2;
			list.Add(monster2);
		}
		List<Vector3> list3 = new List<Vector3>();
		foreach (Monster item in list)
		{
			Module module = ((ability == Ability.Inductor_Zap) ? source.source.owner : owner);
			item.Hurt(damage, null, noDeathrattle: false, 2, module);
			list3.Add(item.pos);
		}
		component.SetPoints(list3);
	}

	private void Recycle(bool reset)
	{
		if (reset)
		{
			owner.GetComponent<Recycler>().ResetCounter();
			return;
		}
		dungeon.audioManager.PlayModSound(owner);
		owner.GetComponent<Recycler>().AddCounter();
	}

	private void Egg()
	{
		if (owner.damage != 0 && value != 999)
		{
			value = 999;
			int index = owner.index;
			owner.board.RemoveModule(owner);
			Module module = owner.board.CreateModuleSmall(Module.Name.Bird, index);
			if (owner.UPGRADED)
			{
				owner.board.UpgradeModule(module.index);
			}
			owner.Kill();
		}
	}

	private void Cross()
	{
		owner.weapon.GetComponent<Cross>().ShootBeam();
	}

	private void Field()
	{
		owner.weapon.GetComponent<Zapper>().ZapEnemies();
	}

	private void GoldScepter()
	{
		owner.GetComponent<Gold>().CalcBuffs();
	}

	private void Stun(Monster m)
	{
		if (owner.name == Module.Name.Electrodes)
		{
			if (m != null)
			{
				dungeon.animationManager.CreateGibs("FFC825", m.transform.position, 5f, 0.66f);
			}
			dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Electric);
		}
		else
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Bash);
		}
		if (m != null)
		{
			m.Stun(1.5f);
		}
	}

	private void Midas(Monster m)
	{
		if (m != null)
		{
			dungeon.animationManager.CreateDust(m.transform.position, "FFA214", 5);
		}
		dungeon.GetBonusCash(1, dungeon.player.transform.position);
	}

	private void Inductor_Zap(Monster m)
	{
		damage = source.source.owner.damage;
		Chain_Lightning(m);
	}

	private void Piggy()
	{
		int num = owner.board.GetNetworkCount(owner);
		if (num > 0)
		{
			if (owner.UPGRADED)
			{
				num *= 2;
			}
			owner.dungeon.gold += num;
			owner.HightlightAnim("ED7614");
			owner.dungeon.animationManager.BounceZoom(owner.gameObject, 0.0625f, 4, modWire: true);
		}
	}

	private void Treat()
	{
		List<Module> list = owner.board.GetBoard();
		bool flag = false;
		foreach (Module item in list)
		{
			if (!(item == owner) && item.PET && (item.index / 5 == owner.index / 5 || owner.UPGRADED))
			{
				flag = true;
				item.AddAura(Aura.Type.MiniAccel);
				if (owner.UPGRADED)
				{
					item.AddAura(Aura.Type.MiniAccel);
				}
			}
		}
		if (flag)
		{
			dungeon.audioManager.PlayModSound(owner);
		}
	}

	private void Slow(Monster m)
	{
		m.ApplyDebuff(Monster.Debuff.Slow, value * 60);
	}

	private void Collar(Weapon wep, Monster monster)
	{
		if (source != null)
		{
			damage = source.source.owner.damage;
		}
		float num = 3.5f;
		List<Monster> list = new List<Monster>();
		if (owner.name == Module.Name.Cellphone)
		{
			num = 5f;
		}
		foreach (Monster livingEnemy in owner.dungeon.livingEnemies)
		{
			if (!(livingEnemy == monster) && Vector3.Distance(livingEnemy.pos, wep.transform.position) <= num)
			{
				list.Add(livingEnemy);
			}
		}
		foreach (Monster item in list)
		{
			List<Monster> list2 = new List<Monster>();
			LightningEffect component = Dungeon.Instance.InstantiateExternal(Dungeon.Instance.LightningEffect).GetComponent<LightningEffect>();
			List<Vector3> list3 = new List<Vector3>();
			int num2 = owner.board.CountAuras(Aura.Type.PerkConductor);
			list2.Add(item);
			for (int i = 0; i < num2; i++)
			{
				if (list2.Count >= list.Count)
				{
					break;
				}
				Monster monster2 = Utils.RandElem(list);
				while (monster2 == item)
				{
					monster2 = Utils.RandElem(list);
				}
				list2.Add(Utils.RandElem(list));
			}
			list3.Add(wep.transform.position);
			foreach (Monster item2 in list2)
			{
				item2.Hurt(damage, null, noDeathrattle: false, 2, (source == null) ? owner : source.source.owner);
				list3.Add(item2.transform.position);
			}
			component.SetPoints(list3);
		}
	}

	private void GlassKill()
	{
		owner.counter++;
		int num = 30;
		if (owner.UPGRADED)
		{
			num += 20;
		}
		if (owner.counter >= num)
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Potion);
			owner.weapon.SetCooldown(999f);
		}
	}

	private void GlassReset()
	{
		owner.counter = 0;
		if (owner.weapon.cooldown > 0)
		{
			owner.weapon.SetCooldown(0f);
		}
	}

	private void PerkChemicals()
	{
		if (dungeon.animationManager.projGibsAlt <= 20 || dungeon.animationManager.projGibs <= 100)
		{
			value++;
			if (value == 10)
			{
				GameObject gameObject = Dungeon.Instance.InstantiateExternal(Dungeon.Instance.perks.perkObjects[0]);
				gameObject.transform.position = owner.dungeon.player.transform.position;
				owner.dungeon.animationManager.TossEffect(gameObject, owner.dungeon.player.transform.position + Utils.RandDir() * 3f, 30);
				value = 0;
			}
		}
	}

	private void PerkStatic()
	{
		float percent = 20f;
		int num = 4;
		float num2 = 0.25f;
		float num3 = 0.65f;
		float num4 = 0.75f;
		float num5 = 1f;
		foreach (Weapon value in dungeon.weaponMods.Values)
		{
			if (value.owner.MECH && Utils.RNG(percent))
			{
				float num6 = UnityEngine.Random.Range(0f, 360f);
				for (int i = 0; i < num; i++)
				{
					Vector3 op = value.transform.position + UnityEngine.Random.Range(num2, num2 + num3) * Utils.DirEuler(num6);
					Vector3 pp = value.transform.position + UnityEngine.Random.Range(num2 + num4, num2 + num4 + num5) * Utils.DirEuler(num6);
					Projectile projectile = owner.dungeon.animationManager.CreateSpark(op, pp, "FFC825");
					projectile.sourceModule = owner;
					projectile.forceDamage = 3;
					num6 += (float)(360 / num) + UnityEngine.Random.Range(-20f, 20f);
				}
				dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Explosion_Electric, 1f, 1.25f, 0.6f, 0.6f);
			}
		}
	}

	private void PerkHail()
	{
		float num = UnityEngine.Random.Range(0f, 360f);
		dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Ice_Small);
		for (int i = 0; i < 8; i++)
		{
			GameObject gameObject = Dungeon.Instance.InstantiateExternal(Dungeon.Instance.perks.perkObjects[2]);
			gameObject.GetComponent<Projectile>().sourceModule = player.sentinel;
			gameObject.transform.position = player.transform.position;
			gameObject.transform.localEulerAngles = new Vector3(0f, 0f, (float)(-i) * 360f / 8f - 90f + num);
			float f = ((float)(-i) * 360f / 8f + num) * MathF.PI / 180f;
			Vector3 dir = new Vector3(Mathf.Cos(f), Mathf.Sin(f));
			dungeon.animationManager.MoveDir(gameObject, dir, 0.25f);
			dungeon.animationManager.Fade(gameObject, 2, 100);
		}
	}

	private void PerkSplinter(Weapon w, Monster m)
	{
		if ((w == null && m == null) || owner.dungeon.animationManager.projGibs > 100)
		{
			return;
		}
		Vector3 position = ((m == null) ? w.transform.position : m.transform.position);
		List<(int, int)> list = new List<(int, int)>
		{
			(1, 1),
			(1, -1),
			(-1, -1),
			(-1, 1)
		};
		Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.RandomBoneSound, 0.9f, 1.1f, 1f);
		for (int i = 0; i < 4; i++)
		{
			float f = UnityEngine.Random.Range(-MathF.PI / 6f, MathF.PI / 3f);
			Vector3 vector = new Vector3((float)list[i].Item1 * Mathf.Cos(f), (float)list[i].Item2 * Mathf.Sin(f));
			float num = UnityEngine.Random.Range(2f, 4f);
			GameObject gameObject = Dungeon.Instance.InstantiateExternal(Dungeon.Instance.perks.perkObjects[3]);
			if (i < 2)
			{
				gameObject.GetComponent<SpriteRenderer>().flipX = true;
			}
			gameObject.transform.position = position;
			owner.dungeon.animationManager.TossEffect(gameObject, gameObject.transform.position + num * vector, 30);
		}
	}

	public void PerkBlizzard()
	{
		if (dungeon.livingEnemies.Count == 0)
		{
			return;
		}
		Monster monster = null;
		foreach (Monster livingEnemy in dungeon.livingEnemies)
		{
			if (Vector3.Distance(livingEnemy.transform.position, dungeon.player.transform.position) < 3.5f)
			{
				monster = livingEnemy;
				break;
			}
		}
		if (!(monster == null))
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Ice);
			Dungeon.Instance.animationManager.CreateLaser(new List<Vector3>
			{
				dungeon.player.transform.position,
				monster.transform.position
			}, "0CF1FF", 0.25f);
			Projectile projectile = dungeon.animationManager.CreateExplosion("0CF1FF", "00CDF9", 10, insta: true);
			projectile.sourceModule = dungeon.player.sentinel;
			projectile.forceDamage = 2;
			projectile.transform.position = monster.transform.position;
			projectile.debuff = Monster.Debuff.Slow;
			projectile.debuffValue = 120f;
			projectile.transform.localScale = Vector3.one * 1f;
		}
	}

	public void PerkFrostbite()
	{
		if (dungeon.livingEnemies.Count == 0)
		{
			return;
		}
		List<Monster> list = new List<Monster>(dungeon.livingEnemies);
		bool flag = false;
		foreach (Monster item in list)
		{
			if (item.speedMult < 1f)
			{
				item.Hurt(2);
				dungeon.animationManager.CreateGibs("0CF1FF", item.transform.position, 5f, 0.66f);
				flag = true;
			}
		}
		if (flag)
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Ice_Small);
		}
	}

	public void PerkFeedback(Module module)
	{
		List<Module> tribe = owner.dungeon.board.GetTribe(Module.Tribe.Wand);
		tribe.Remove(module);
		if (tribe.Count > 0)
		{
			Utils.RandElem(tribe).mana += 0.5f;
		}
	}

	public void FlameMP(Module mod)
	{
		if (!(mod == owner))
		{
			owner.mana += 1f;
		}
	}

	public void NecroEnd()
	{
		owner.weapon.GetComponent<Necromancy>().KillSkeletons();
	}

	public void PerkSouldrain()
	{
		owner.mana += 0.25f;
	}

	public void Bell(Weapon wep)
	{
		if (Utils.RNG(owner.UPGRADED ? 15 : 10))
		{
			Projectile projectile = dungeon.animationManager.CreateCircleEffect(wep.transform.position, "FFA214", Vector3.one * 2f);
			owner.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Bell_Proc, 0.9f, 1.1f, 1f);
			projectile.forceDamage = 0;
			projectile.debuff = Monster.Debuff.Stun;
			projectile.debuffValue = 1.5f;
			owner.counter = 2;
		}
		else if (owner.counter == 0)
		{
			List<float> l = new List<float> { 1f, 1.1851852f, 1.3333334f, 1.5f };
			dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Bell_Hit0, Utils.RandElem(l));
			owner.counter = 2;
		}
		else
		{
			owner.counter--;
		}
	}

	public void PerkWindwalk()
	{
		foreach (Module item in board.GetBoard())
		{
			if (item.PET)
			{
				item.AddAura(Aura.Type.Accel, 60);
				item.BuffParticles("94FDFF", 60);
			}
		}
	}

	public void PerkHorsepower()
	{
		foreach (Module item in board.GetBoard())
		{
			if (item.MECH)
			{
				player.sentinel.GetComponentInChildren<Horsepower>().AddBuff(item);
				item.BuffParticles("C7CFDD", 120);
			}
		}
	}

	public void PerkTechtrash(Module m)
	{
		if (m.MECH)
		{
			Module module = Utils.RandElem(board.GetWeapons());
			module.AddAura(Aura.Type.FoodBuff);
			module.AddAura(Aura.Type.FoodBuff);
		}
	}

	public void PerkRestore()
	{
		player.Heal(1);
	}

	public void PerkStutter()
	{
		if (dungeon.livingEnemies.Count == 0)
		{
			return;
		}
		List<Monster> list = new List<Monster>(dungeon.livingEnemies);
		bool flag = false;
		foreach (Monster item in list)
		{
			item.ApplyDebuff(Monster.Debuff.Stun, 0.25f);
			dungeon.animationManager.CreateGibs("FFC825", item.transform.position, 5f, 0.66f);
			flag = true;
		}
		if (flag)
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Electric);
		}
	}

	public void PerkSniper(Monster m, Weapon w)
	{
		if (!(m == null) && Vector3.Distance(m.transform.position, player.transform.position) >= 5f)
		{
			Module module = null;
			if (w != null)
			{
				module = w.owner;
			}
			m.Hurt(2, null, noDeathrattle: false, 5, module, "FFEB57");
			if (m.health <= 0)
			{
				_ = module != null;
			}
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Bloody_Punch, 0.9f, 1.1f, 1f);
		}
	}

	public void Monitor()
	{
		owner.weapon.GetComponent<Monitor>().BeamMonster();
	}

	public void Food()
	{
		if (owner.counter == 0)
		{
			return;
		}
		bool flag = false;
		foreach (Module output in owner.outputs)
		{
			flag = true;
			output.AddAura(Aura.Type.FoodBuff);
		}
		if (flag)
		{
			owner.TriggerBounce();
			dungeon.audioManager.PlayModSound(owner, 0.85f);
			owner.AddAura(Aura.Type.MinusCount);
		}
	}

	public void Sonic(Module mod)
	{
		owner.GetComponent<Sonic>().SonicWave(mod);
	}

	public void Channeler()
	{
		if (owner.weapon == null)
		{
			return;
		}
		float num = 4f;
		bool flag = false;
		foreach (Monster item in new List<Monster>(dungeon.livingEnemies))
		{
			if (!(Vector3.Distance(item.transform.position, owner.weapon.transform.position) > num))
			{
				flag = true;
				item.Hurt(owner.damage, null, noDeathrattle: false, 2, owner);
				owner.weapon.Hit(item);
				Dungeon.Instance.animationManager.CreateDust(item.transform.position, "33984B", 10, 0.75f);
				Dungeon.Instance.animationManager.CreateLaser(new List<Vector3>
				{
					owner.weapon.transform.position,
					item.transform.position
				}, "33984B", 0.25f);
			}
		}
		if (flag)
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Ice);
		}
		else
		{
			Dungeon.Instance.animationManager.CreateDust(owner.weapon.transform.position, "33984B", 10, 0.75f);
		}
	}

	public void Soulrod(Weapon wep, Module m)
	{
		if (wep == null)
		{
			if (m == null || !m.WAND)
			{
				return;
			}
		}
		else if (!wep.owner.WAND)
		{
			return;
		}
		if (wep != null)
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Mageblade, UnityEngine.Random.Range(0.85f, 1.15f));
			if (wep.owner != null)
			{
				wep.owner.Cast();
			}
		}
		else
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.Mageblade, UnityEngine.Random.Range(0.85f, 1.15f));
			if (m != null)
			{
				m.Cast();
			}
		}
	}

	public void Vortex(Module m)
	{
		if (owner.outputs.Contains(m) && !(m.weapon == null))
		{
			Vector3 pos = ((m.weapon == null) ? player.transform.position : m.weapon.transform.position);
			Projectile projectile = dungeon.animationManager.CreateCircleEffect(pos, "622461", Vector3.one * 1.5f);
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Vortex, 0.9f, 1.1f, 0.9f, 0.9f);
			projectile.sourceModule = owner;
			projectile.forceDamage = owner.damage;
			projectile.debuff = Monster.Debuff.Stun;
			projectile.debuffValue = 1f;
			owner.counter = 1;
		}
	}

	public void Biochamber()
	{
		Module right = owner.GetRight();
		if (!(right == null) && right.PET)
		{
			AudioManager.Sound c = Utils.RandElem(new List<AudioManager.Sound>
			{
				AudioManager.Sound.Underwater_Bubble_0,
				AudioManager.Sound.Underwater_Bubble_1,
				AudioManager.Sound.Underwater_Bubble_2
			});
			dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
			dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
			bool uPGRADED = right.UPGRADED;
			bool uPGRADED2 = owner.UPGRADED;
			Module component = Dungeon.Instance.InstantiateExternal(owner.dungeon.moduleObjects[(int)right.name]).GetComponent<Module>();
			int num = owner.index;
			board.RemoveModule(owner);
			if (component.size == Module.Size.Small)
			{
				num++;
			}
			board.AddModule(component, num, forcedSwap: false, playSound: true);
			if (uPGRADED)
			{
				board.UpgradeModule(component, silent: true);
			}
			if (uPGRADED2)
			{
				component.AddAura(Aura.Type.FoodBuff);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.FoodBuff, -1, 1f, silent: true);
				component.AddAura(Aura.Type.BioSpeedBuff);
			}
			component.HightlightAnim("5AC54F");
			component.dungeon.animationManager.BounceZoom(owner.gameObject, 0.0625f, 4, modWire: true);
			component.BuffParticles("5AC54F", 90);
			owner.Kill();
		}
	}

	public void Raccoon(Module m)
	{
		if (m.WEAPON && !(m == owner))
		{
			owner.TriggerBounce();
			dungeon.audioManager.PlayModSound(owner, 0.9f);
			owner.AddAura(Aura.Type.FoodBuff);
			if (owner.UPGRADED)
			{
				owner.AddAura(Aura.Type.FoodBuff);
			}
		}
	}

	public void PerkUnstable(Module mod)
	{
		if (dungeon.animationManager.projGibs <= 200 && !(mod.weapon == null))
		{
			Vector3 position = ((mod.weapon == null) ? dungeon.player.pos : mod.weapon.transform.position);
			owner.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Fairy, 1f, 0.85f);
			Projectile projectile = owner.dungeon.animationManager.CreateExplosion("1E6F50", "1E6F50", 10, insta: true);
			projectile.sourceModule = owner;
			projectile.transform.position = position;
		}
	}

	public void Phial(Module mod)
	{
		if (owner.GetAdjacents().Contains(mod))
		{
			owner.TriggerBounce();
			mod.mana += (owner.UPGRADED ? 1f : 0.5f);
		}
	}
}
