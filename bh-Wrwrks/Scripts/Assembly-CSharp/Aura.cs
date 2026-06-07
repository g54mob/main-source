using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Aura
{
	public enum Type
	{
		Damage = 0,
		Booster = 1,
		Accel = 2,
		Accelerator = 3,
		Amplifier = 4,
		Amp = 5,
		Decelerator = 6,
		Decel = 7,
		Anvil = 8,
		AnvilDamage = 9,
		SnowballScale = 10,
		BandageAura = 11,
		BandageEffect = 12,
		InductorAura = 13,
		InductorEffect = 14,
		Fish = 15,
		HalfAccelerator = 16,
		HalfAmplifier = 17,
		HalfDecelerator = 18,
		MiniAccel = 19,
		MiniAmp = 20,
		MiniDecel = 21,
		RerollDiscount = 22,
		HealBuff = 23,
		CapacitorChecker = 24,
		InductorChecker = 25,
		PlayerHP = 26,
		Magnetizer = 27,
		PiggyChecker = 28,
		Treat = 29,
		Wolf = 30,
		Puppy = 31,
		Silicon = 32,
		BladeChecker = 33,
		CoolantAura = 34,
		CoolantEffect = 35,
		SlowBuff = 36,
		Scale = 37,
		Redchip = 38,
		CollarAura = 39,
		CollarEffect = 40,
		Doghouse = 41,
		Crown = 42,
		PerkFocused = 43,
		PerkLeader = 44,
		PerkConductor = 45,
		PerkBomber = 46,
		PerkDiscount = 47,
		PerkDividends = 48,
		PerkGigantism = 49,
		PerkHeavy = 50,
		PerkInspire = 51,
		PerkStatic = 52,
		PerkMechatron = 53,
		ManaRegen = 54,
		ManaCost = 55,
		ManaPot = 56,
		PerkMana = 57,
		Curse = 58,
		GlobeDisplay = 59,
		AdjacentWandDisplay = 60,
		Alchemy = 61,
		FlameAura = 62,
		FlameEffect = 63,
		SwipeAura = 64,
		BatteryAura = 65,
		RepeaterAura = 66,
		Repeat = 67,
		Longstaff = 68,
		MirrorCheck = 69,
		PerkTopped = 70,
		PerkSouldrain = 71,
		PerkUpsides = 72,
		PerkCompuwiz = 73,
		PerkCompuwizEffect = 74,
		PerkMagetech = 75,
		PerkMagetechEffect = 76,
		PerkHorsepower = 77,
		Wrench = 78,
		Horseshoe = 79,
		Rat = 80,
		Powermace = 81,
		PerkIntellect = 82,
		Microchip = 83,
		Mechanize = 84,
		Force_Gold = 85,
		Grimoire = 86,
		PerkBoosters = 87,
		PerkBoostersEffect = 88,
		USB = 89,
		FoodBuff = 90,
		MinusCount = 91,
		ElectrodeDisplay = 92,
		Screwdriver = 93,
		Dogwhistle = 94,
		Brass = 95,
		Juice = 96,
		BrassEffect = 97,
		BiochamberPreview = 98,
		BioSpeedBuff = 99,
		Bone = 100,
		ChannelDisplay = 101,
		PerkModulator = 102,
		PerkHerd = 103,
		Dryer = 104,
		Vortex = 105,
		Channel = 106,
		SandHighlight = 107,
		RecyclerAura = 108
	}

	public Type type;

	public bool foreign;

	public Aura source;

	public bool temp;

	public bool refreshed = true;

	public float value;

	public Module owner;

	public Dungeon dungeon => Dungeon.Instance;

	public Aura(Type t, bool foreign = false, bool temp = false, Aura source = null, float value = 1f)
	{
		type = t;
		this.value = value;
		this.foreign = foreign;
		this.temp = temp;
		this.source = source;
	}

	public static string GetAuraColor(Type t)
	{
		if (t == Type.Decel || t == Type.Wolf || t == Type.MinusCount)
		{
			return "C42430";
		}
		return "0098DC";
	}

	public void Activate()
	{
		switch (type)
		{
		case Type.Booster:
			Booster();
			break;
		case Type.Accelerator:
			Accelerator();
			break;
		case Type.Amplifier:
			Amplifier();
			break;
		case Type.Decelerator:
			Weight();
			break;
		case Type.HalfAccelerator:
			HalfAccelerator();
			break;
		case Type.HalfAmplifier:
			HalfAmplifier();
			break;
		case Type.HalfDecelerator:
			HalfDecelerator();
			break;
		case Type.Anvil:
			Anvil();
			break;
		case Type.BandageAura:
			BandageAura();
			break;
		case Type.InductorAura:
			InductorAura();
			break;
		case Type.Fish:
			Fish();
			break;
		case Type.InductorChecker:
			InductorChecker();
			break;
		case Type.CapacitorChecker:
			CapacitorChecker();
			break;
		case Type.Magnetizer:
			Magnetizer();
			break;
		case Type.PiggyChecker:
			PiggyChecker();
			break;
		case Type.Wolf:
			Wolf();
			break;
		case Type.Puppy:
			Puppy();
			break;
		case Type.Silicon:
			Silicon();
			break;
		case Type.BladeChecker:
			BladeChecker();
			break;
		case Type.CoolantAura:
			CoolantAura();
			break;
		case Type.Redchip:
			Redchip();
			break;
		case Type.CollarAura:
			CollarAura();
			break;
		case Type.Doghouse:
			Doghouse();
			break;
		case Type.Crown:
			Crown();
			break;
		case Type.PerkFocused:
			PerkFocused();
			break;
		case Type.PerkLeader:
			PerkLeader();
			break;
		case Type.PerkHeavy:
			PerkHeavy();
			break;
		case Type.PerkGigantism:
			PerkGigantism();
			break;
		case Type.PerkInspire:
			PerkInspire();
			break;
		case Type.PerkStatic:
			PerkStatic();
			break;
		case Type.PerkMechatron:
			PerkMechatron();
			break;
		case Type.ManaPot:
			ManaPot();
			break;
		case Type.PerkMana:
			PerkMana();
			break;
		case Type.Curse:
			Curse();
			break;
		case Type.Alchemy:
			Alchemy();
			break;
		case Type.FlameAura:
			FlameAura();
			break;
		case Type.SwipeAura:
			SwipeAura();
			break;
		case Type.RepeaterAura:
			RepeaterAura();
			break;
		case Type.Longstaff:
			Longstaff();
			break;
		case Type.MirrorCheck:
			MirrorCheck();
			break;
		case Type.PerkTopped:
			PerkTopped();
			break;
		case Type.PerkSouldrain:
			PerkSouldrain();
			break;
		case Type.PerkUpsides:
			PerkUpsides();
			break;
		case Type.PerkCompuwiz:
			PerkCompuwiz();
			break;
		case Type.PerkCompuwizEffect:
			PerkCompuwizEffect();
			break;
		case Type.PerkHorsepower:
			PerkHorsepower();
			break;
		case Type.PerkMagetech:
			PerkMagetech();
			break;
		case Type.PerkMagetechEffect:
			PerkMagetechEffect();
			break;
		case Type.Wrench:
			Wrench();
			break;
		case Type.Horseshoe:
			Horseshoe();
			break;
		case Type.Rat:
			Rat();
			break;
		case Type.Powermace:
			Powermace();
			break;
		case Type.PerkIntellect:
			PerkIntellect();
			break;
		case Type.Microchip:
			Microchip();
			break;
		case Type.Treat:
			Treat();
			break;
		case Type.Grimoire:
			Grimoire();
			break;
		case Type.PerkBoosters:
			PerkBoosters();
			break;
		case Type.PerkBoostersEffect:
			PerkBoostersEffect();
			break;
		case Type.USB:
			USB();
			break;
		case Type.BatteryAura:
			BatteryAura();
			break;
		case Type.Screwdriver:
			Screwdriver();
			break;
		case Type.Juice:
			Juice();
			break;
		case Type.Brass:
			Brass();
			break;
		case Type.Dogwhistle:
			Dogwhistle();
			break;
		case Type.Bone:
			Bone();
			break;
		case Type.PerkModulator:
			PerkModulator();
			break;
		case Type.PerkHerd:
			PerkHerd();
			break;
		case Type.Dryer:
			Dryer();
			break;
		case Type.Vortex:
			Vortex();
			break;
		case Type.Channel:
			Channel();
			break;
		case Type.RecyclerAura:
			RecyclerAura();
			break;
		case Type.Accel:
		case Type.Amp:
		case Type.Decel:
		case Type.AnvilDamage:
		case Type.SnowballScale:
		case Type.BandageEffect:
		case Type.InductorEffect:
		case Type.MiniAccel:
		case Type.MiniAmp:
		case Type.MiniDecel:
		case Type.RerollDiscount:
		case Type.HealBuff:
		case Type.PlayerHP:
		case Type.CoolantEffect:
		case Type.SlowBuff:
		case Type.Scale:
		case Type.CollarEffect:
		case Type.PerkConductor:
		case Type.PerkBomber:
		case Type.PerkDiscount:
		case Type.PerkDividends:
		case Type.ManaRegen:
		case Type.ManaCost:
		case Type.GlobeDisplay:
		case Type.AdjacentWandDisplay:
		case Type.FlameEffect:
		case Type.Repeat:
		case Type.Mechanize:
		case Type.Force_Gold:
		case Type.FoodBuff:
		case Type.MinusCount:
		case Type.ElectrodeDisplay:
		case Type.BrassEffect:
		case Type.BiochamberPreview:
		case Type.BioSpeedBuff:
		case Type.ChannelDisplay:
		case Type.SandHighlight:
			break;
		}
	}

	public void Highlight(int i = -1, bool anim = false)
	{
		if (i == -1)
		{
			i = owner.index;
		}
		switch (type)
		{
		case Type.Booster:
		case Type.Wolf:
		case Type.GlobeDisplay:
			HighlightAdjacents(i, anim);
			break;
		case Type.BandageAura:
		case Type.InductorAura:
			HighlightAdjacentWeapons(i, anim);
			break;
		case Type.Accelerator:
		case Type.Amplifier:
		case Type.HalfAccelerator:
		case Type.HalfAmplifier:
		case Type.HalfDecelerator:
			HighlightAdjacentModules(i, anim);
			break;
		case Type.Anvil:
			HighlightUntribeWeapons(anim);
			break;
		case Type.CapacitorChecker:
		case Type.InductorChecker:
		case Type.BladeChecker:
		case Type.Redchip:
		case Type.BatteryAura:
		case Type.Powermace:
		case Type.Dryer:
			HighlightNetwork(anim, Module.Tribe.Mech);
			break;
		case Type.USB:
			HighlightNetwork(anim, Module.Tribe.Mech);
			HighlightAdjacents(i, anim, Module.Tribe.Wand);
			break;
		case Type.PerkCompuwizEffect:
			HighlightNetwork(anim, Module.Tribe.Wand);
			break;
		case Type.PiggyChecker:
			HighlightNetwork(anim);
			break;
		case Type.ElectrodeDisplay:
			HighlightNetwork(anim, Module.Tribe.None, typed: true);
			break;
		case Type.Screwdriver:
			HighlightNetwork(anim, Module.Tribe.None, typed: true, Module.Type.Module, specialOnly: true);
			break;
		case Type.Fish:
		case Type.CollarAura:
		case Type.PerkBoostersEffect:
		case Type.Brass:
		case Type.Bone:
			HighlightAdjacents(i, anim, Module.Tribe.Pet);
			break;
		case Type.PerkMagetechEffect:
		case Type.Wrench:
			HighlightAdjacents(i, anim, Module.Tribe.Mech);
			break;
		case Type.Magnetizer:
		case Type.CoolantAura:
			HighlightAdjacents(i, anim, Module.Tribe.Mech);
			break;
		case Type.Puppy:
		case Type.MirrorCheck:
			HighlightLeft(i, anim);
			break;
		case Type.Doghouse:
		case Type.BiochamberPreview:
			HighlightRight(i, anim, Module.Tribe.Pet);
			break;
		case Type.Horseshoe:
			HighlightAboveWeapon(i, anim, Module.Tribe.Pet);
			break;
		case Type.Treat:
		case Type.Dogwhistle:
			HighlightRow(i, anim, Module.Tribe.Pet);
			break;
		case Type.Crown:
			HighlightBelow(i, anim);
			break;
		case Type.Juice:
			HighlightBelow(i, anim, Module.Tribe.Pet);
			break;
		case Type.Decelerator:
			HighlightAboveWeapon(i, anim);
			break;
		case Type.AdjacentWandDisplay:
		case Type.Alchemy:
			HighlightAdjacents(i, anim, Module.Tribe.Wand);
			break;
		case Type.FlameAura:
		case Type.ChannelDisplay:
			HighlightAllTribe(anim, Module.Tribe.Wand);
			break;
		case Type.SwipeAura:
			HighlightRow(i, anim, Module.Tribe.Pet);
			break;
		case Type.SandHighlight:
			HighlightRow(i, anim, Module.Tribe.Pet);
			HighlightRowModules(i, anim);
			break;
		case Type.Rat:
			HighlightName(anim, Module.Name.Rat);
			break;
		case Type.Grimoire:
			HighlightName(anim, Module.Name.Imp);
			break;
		}
	}

	public void InitAura(bool negative = false, bool silent = false)
	{
		int num = ((!negative) ? 1 : (-1));
		if (!silent && !negative && !owner.WIREMOD && !owner.shopItem && !owner.preview)
		{
			owner.dungeon.animationManager.BounceZoom(owner.gameObject, 0.0625f, 4, modWire: true);
			owner.HightlightAnim(GetAuraColor(type));
		}
		switch (type)
		{
		case Type.PlayerHP:
			dungeon.player.maxHealth += (int)value * num;
			if (dungeon.state != Dungeon.State.Combat)
			{
				dungeon.player.health = dungeon.player.maxHealth;
			}
			dungeon.player.health = Mathf.Min(dungeon.player.health, dungeon.player.maxHealth);
			break;
		case Type.Damage:
		case Type.FoodBuff:
			owner.damage += num * (int)value;
			break;
		case Type.Scale:
			owner.scale += (float)num * value * Vector3.one;
			break;
		case Type.AnvilDamage:
			owner.damage += num * 5;
			break;
		case Type.BioSpeedBuff:
			owner.accelMult += (float)num * 0.5f * value;
			break;
		case Type.Accel:
			owner.accelMult += (float)num * 0.3f * value;
			break;
		case Type.Decel:
			owner.accelMult += (float)num * -0.5f;
			break;
		case Type.Amp:
			owner.ampMult += (float)num * 0.3f;
			break;
		case Type.MiniAccel:
			owner.accelMult += (float)num * 0.15f;
			break;
		case Type.MiniDecel:
			owner.accelMult += (float)num * -0.2f;
			break;
		case Type.MiniAmp:
			owner.ampMult += (float)num * 0.15f;
			break;
		case Type.SnowballScale:
			owner.scale += num * Vector3.one * 0.2f;
			break;
		case Type.ManaRegen:
			owner.manaRegen += (float)num * value;
			break;
		case Type.ManaCost:
			owner.manaCost += (float)num * value;
			break;
		case Type.Repeat:
			owner.repeat += num * (int)value;
			break;
		case Type.MinusCount:
			owner.counter += num * -1 * (int)value;
			break;
		case Type.BandageEffect:
		{
			Trigger.Ability ability = Trigger.Ability.Bandage;
			if (!negative)
			{
				owner.AddTrigger(ability, this, 25f);
			}
			else
			{
				owner.RemoveTrigger(ability, this);
			}
			break;
		}
		case Type.CoolantEffect:
			if (!negative)
			{
				owner.AddTrigger(Trigger.Ability.Slow, this, 100f, 3);
			}
			else
			{
				owner.RemoveTrigger(Trigger.Ability.Slow, this);
			}
			break;
		case Type.InductorEffect:
			if (!negative)
			{
				owner.AddTrigger(Trigger.Ability.Inductor_Zap, this, 50f, 3, 0);
			}
			else
			{
				owner.RemoveTrigger(Trigger.Ability.Inductor_Zap, this);
			}
			break;
		case Type.CollarEffect:
			GiveSelfTrigger(Trigger.Ability.Collar, negative);
			break;
		case Type.BrassEffect:
			GiveSelfTrigger(Trigger.Ability.Stun, negative, value);
			break;
		case Type.FlameEffect:
			GiveSelfTrigger(Trigger.Ability.FlameMP, negative);
			break;
		case Type.PerkTopped:
			value = 0f;
			GiveSelfTrigger(Trigger.Ability.ToppedCheckHurt, negative);
			GiveSelfTrigger(Trigger.Ability.ToppedCheckHeal, negative);
			break;
		case Type.Mechanize:
			if (!Database.GetModData(owner).tribe.Contains(Module.Tribe.Mech))
			{
				if (!negative)
				{
					owner.tribes.Add(Module.Tribe.Mech);
				}
				else
				{
					owner.tribes.Remove(Module.Tribe.Mech);
				}
			}
			break;
		}
	}

	public void RemoveAura()
	{
		InitAura(negative: true);
	}

	private void GiveSelfTrigger(Trigger.Ability type, bool negative, float proc = 100f, int val = 0, int dmg = 1)
	{
		if (!negative)
		{
			owner.AddTrigger(type, this, proc, val, dmg);
		}
		else
		{
			owner.RemoveTrigger(type, this);
		}
	}

	private void GiveAdjWeapons(Type t, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (adjacent.WEAPON && (tribe == Module.Tribe.None || adjacent.tribes.Contains(tribe)))
			{
				adjacent.AddAura(new Aura(t, foreign: true, temp: false, this));
			}
		}
	}

	private void GiveAdjModules(Type t)
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (adjacent.MODULE)
			{
				adjacent.AddAura(new Aura(t, foreign: true, temp: false, this));
			}
		}
	}

	private void Booster()
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			adjacent.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, (!owner.UPGRADED) ? 1 : 2));
		}
	}

	private void BandageAura()
	{
		GiveAdjWeapons(Type.BandageEffect);
	}

	private void CoolantAura()
	{
		GiveAdjWeapons(Type.CoolantEffect, Module.Tribe.Mech);
	}

	private void InductorAura()
	{
		GiveAdjWeapons(Type.InductorEffect);
	}

	private void CollarAura()
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (!(adjacent == null) && adjacent.PET)
			{
				adjacent.AddAura(new Aura(Type.CollarEffect, foreign: true, temp: false, this));
			}
		}
	}

	private void Anvil()
	{
		foreach (Module weapon in owner.board.GetWeapons())
		{
			if (weapon.tribes.Count <= 0)
			{
				weapon.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
				if (owner.UPGRADED && !weapon.UPGRADED)
				{
					dungeon.board.UpgradeModule(weapon);
				}
			}
		}
	}

	private void Accelerator()
	{
		GiveAdjModules(Type.Accel);
	}

	private void Weight()
	{
		Module above = owner.GetAbove();
		if (above == null || !above.WEAPON)
		{
			return;
		}
		above.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, owner.UPGRADED ? 3 : 2));
		foreach (Module input in above.inputs)
		{
			input.AddAura(new Aura(Type.Decel, foreign: true, temp: false, this));
			if (owner.UPGRADED)
			{
				input.AddAura(new Aura(Type.MiniDecel, foreign: true, temp: false, this));
			}
		}
	}

	private void Amplifier()
	{
		GiveAdjModules(Type.Amp);
	}

	private void HalfAccelerator()
	{
		GiveAdjModules(Type.MiniAccel);
	}

	private void HalfDecelerator()
	{
		GiveAdjModules(Type.MiniDecel);
	}

	private void HalfAmplifier()
	{
		GiveAdjModules(Type.MiniAmp);
	}

	private void Fish()
	{
		List<Module> adjacents = owner.GetAdjacents();
		int num = 0;
		foreach (Module item in adjacents)
		{
			if (!(item == null) && item.PET)
			{
				num += 2;
			}
		}
		if (num > 0)
		{
			owner.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, num));
			if (owner.UPGRADED)
			{
				owner.AddAura(new Aura(Type.Accel, foreign: true, temp: false, this, num / 2));
			}
		}
	}

	private void CapacitorChecker()
	{
		owner.GetComponent<Capacitor>().CheckDamage();
	}

	private void InductorChecker()
	{
		owner.GetComponent<Inductor>().CheckDamage();
	}

	private void Magnetizer()
	{
		owner.GetComponent<Magnetizer>().CalcBuffs();
	}

	private void PiggyChecker()
	{
		if (owner.name == Module.Name.Armor)
		{
			owner.GetComponent<Armor>().Count();
		}
		else
		{
			owner.GetComponent<Piggy>().Count();
		}
	}

	private void Wolf()
	{
		owner.weapon.GetComponent<WolfWeapon>().SetDamage();
	}

	private void Puppy()
	{
		owner.weapon.GetComponent<Puppy>().FindTarget();
	}

	private void Silicon()
	{
		int count = owner.inputs.Count;
		if ((float)count > value && Camera.main.transform.position.x > -10f)
		{
			dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Beep, 0.9f, 1.1f, 0.6f, 0.6f);
		}
		value = count;
		owner.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, count));
	}

	private void BladeChecker()
	{
		owner.weapon.GetComponent<Blade>().CalcBuffs();
	}

	private void Redchip()
	{
		int networkCount = owner.board.GetNetworkCount(owner, Module.Tribe.Mech);
		int num = networkCount + (owner.UPGRADED ? 1 : 0);
		owner.counter = networkCount;
		foreach (Module item in owner.board.GetNetwork(owner))
		{
			if (item.MECH)
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, num));
			}
			else if (owner.UPGRADED)
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this));
			}
		}
	}

	private void Doghouse()
	{
		Module right = owner.GetRight();
		if (right == null || !right.PET)
		{
			return;
		}
		right.AddAura(new Aura(Type.Accel, foreign: true, temp: false, this, 1.3333333f));
		int num = 0;
		foreach (Module item in owner.board.GetBoard())
		{
			if (item.PET)
			{
				num++;
			}
		}
		if (owner.UPGRADED)
		{
			num += 3;
			right.AddAura(new Aura(Type.MiniAccel, foreign: true, temp: false, this));
		}
		right.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, num));
	}

	private void Horseshoe()
	{
		Module above = owner.GetAbove();
		if (!(above == null) && above.PET)
		{
			above.AddAura(new Aura(Type.Accel, foreign: true, temp: false, this, 1.6666666f));
			if (owner.UPGRADED)
			{
				above.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
			}
		}
	}

	private void Crown()
	{
		int num = ((!owner.UPGRADED) ? 1 : 2);
		Module below = owner.GetBelow();
		if (!(below == null))
		{
			below.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, num));
		}
	}

	private void PerkFocused()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.MODULE)
			{
				item.AddAura(new Aura(Type.MiniAccel, foreign: true, temp: false, this));
				item.AddAura(new Aura(Type.MiniAmp, foreign: true, temp: false, this));
			}
		}
	}

	private void PerkLeader()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.WEAPON)
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this));
				break;
			}
		}
	}

	private void PerkGigantism()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.PET)
			{
				item.AddAura(new Aura(Type.Scale, foreign: true, temp: false, this));
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
				break;
			}
		}
	}

	private void PerkInspire()
	{
		float num = (float)dungeon.board.GetTribe(Module.Tribe.Pet).Count * 0.1f / 0.3f;
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.PET)
			{
				item.AddAura(new Aura(Type.Accel, foreign: true, temp: false, this, num));
			}
		}
	}

	private void PerkHeavy()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
			item.AddAura(new Aura(Type.Decel, foreign: true, temp: false, this));
		}
	}

	private void PerkStatic()
	{
		int num = dungeon.board.CountAuras(Type.PerkStatic);
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (!item.MECH)
			{
				continue;
			}
			int num2 = 0;
			foreach (Trigger trigger in item.triggers)
			{
				if (trigger.ability == Trigger.Ability.PerkStatic)
				{
					num2++;
				}
			}
			while (num2 < num)
			{
				item.AddTrigger(Trigger.Ability.PerkStatic);
				foreach (Trigger trigger2 in item.triggers)
				{
					if (trigger2.ability == Trigger.Ability.PerkStatic)
					{
						num2++;
					}
				}
			}
		}
	}

	public void GiveTribeTrigger(Module.Tribe tribe, Trigger.Ability trigger)
	{
		int num = dungeon.board.CountAuras(type);
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (!item.tribes.Contains(tribe))
			{
				continue;
			}
			int num2 = 0;
			foreach (Trigger trigger2 in item.triggers)
			{
				if (trigger2.ability == trigger)
				{
					num2++;
				}
			}
			while (num2 < num)
			{
				item.AddTrigger(trigger);
				foreach (Trigger trigger3 in item.triggers)
				{
					if (trigger3.ability == trigger)
					{
						num2++;
					}
				}
			}
		}
	}

	private void PerkSouldrain()
	{
		GiveTribeTrigger(Module.Tribe.Wand, Trigger.Ability.PerkSouldrain);
	}

	private void PerkBoosters()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.MECH)
			{
				item.AddAura(new Aura(Type.PerkBoostersEffect, foreign: true, temp: false, this));
			}
		}
	}

	private void PerkBoostersEffect()
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (adjacent.PET)
			{
				adjacent.AddAura(new Aura(Type.Accel, foreign: true, temp: false, this, 1.3333334f));
			}
		}
	}

	private void PerkUpsides()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.UPGRADED)
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
			}
		}
	}

	private void PerkMechatron()
	{
		if (value == -1f)
		{
			return;
		}
		List<Module> board = owner.dungeon.board.GetBoard();
		int num = 0;
		foreach (Module item in board)
		{
			if (item.MECH)
			{
				num++;
			}
		}
		if (num >= 5)
		{
			value = -1f;
			owner.board.CreateExtraModule(Module.Name.Mechatron);
		}
	}

	private void ManaPot()
	{
		foreach (Module output in owner.outputs)
		{
			if (output.WAND)
			{
				output.AddAura(new Aura(Type.ManaRegen, foreign: true, temp: false, this, (!owner.UPGRADED) ? 1 : 2));
			}
		}
	}

	private void Microchip()
	{
		foreach (Module output in owner.outputs)
		{
			if (output.WEAPON)
			{
				output.AddAura(new Aura(Type.Mechanize, foreign: true, temp: false, this));
				output.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this));
			}
		}
		if (!owner.UPGRADED)
		{
			return;
		}
		foreach (Module item in owner.board.GetNetwork(owner))
		{
			item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this));
		}
	}

	private void PerkMana()
	{
		foreach (Module item in owner.dungeon.board.GetBoard())
		{
			if (item.WAND)
			{
				item.AddAura(new Aura(Type.ManaRegen, foreign: true, temp: false, this));
			}
		}
	}

	private void Curse()
	{
		foreach (Module output in owner.outputs)
		{
			if (output.WAND)
			{
				output.AddAura(new Aura(Type.ManaCost, foreign: true, temp: false, this));
				output.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, owner.UPGRADED ? 4 : 2));
				if (owner.UPGRADED)
				{
					output.AddAura(new Aura(Type.ManaRegen, foreign: true, temp: false, this, -2f));
				}
			}
		}
	}

	private void Vortex()
	{
		foreach (Module output in owner.outputs)
		{
			if (output.WAND)
			{
				output.AddAura(new Aura(Type.ManaCost, foreign: true, temp: false, this));
			}
		}
	}

	private void Alchemy()
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (adjacent.WAND)
			{
				adjacent.AddAura(new Aura(Type.ManaRegen, foreign: true, temp: false, this, (!owner.UPGRADED) ? 1 : 3));
			}
		}
	}

	private void USB()
	{
		List<Module> adjacents = owner.GetAdjacents();
		int networkCount = owner.board.GetNetworkCount(owner, Module.Tribe.Mech);
		owner.counter = networkCount;
		foreach (Module item in adjacents)
		{
			if (item.WAND)
			{
				item.AddAura(new Aura(Type.ManaRegen, foreign: true, temp: false, this, (float)networkCount * 0.5f));
				if (owner.UPGRADED)
				{
					item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, networkCount));
				}
			}
		}
	}

	private void FlameAura()
	{
		foreach (Module item in owner.board.GetBoard())
		{
			if (item.WAND || !(item != owner))
			{
				item.AddAura(new Aura(Type.FlameEffect, foreign: true, temp: false, this));
			}
		}
	}

	private void SwipeAura()
	{
		List<Module> row = owner.GetRow();
		int num = 0;
		foreach (Module item in row)
		{
			if (item.PET)
			{
				num++;
			}
		}
		if (num != 0)
		{
			owner.AddAura(new Aura(Type.ManaRegen, foreign: true, temp: false, this, num));
		}
	}

	private void RepeaterAura()
	{
		foreach (Module output in owner.outputs)
		{
			output.AddAura(new Aura(Type.Repeat, foreign: true, temp: false, this, (!owner.UPGRADED) ? 1 : 2));
		}
	}

	private void Longstaff()
	{
		if (dungeon.player.health == dungeon.player.maxHealth)
		{
			owner.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, owner.UPGRADED ? 3 : 2));
		}
	}

	private void MirrorCheck()
	{
		owner.weapon.GetComponent<MirrorWep>().CheckWeapon();
	}

	private void PerkTopped()
	{
		if (dungeon.player.health < dungeon.player.maxHealth)
		{
			return;
		}
		foreach (Module item in owner.board.GetBoard())
		{
			if (item.index <= 4)
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this));
			}
		}
	}

	private void PerkCompuwizEffect()
	{
		List<Module> network = dungeon.board.GetNetwork(owner);
		List<Module> list = new List<Module>();
		foreach (Module item in network)
		{
			if (item.WAND)
			{
				list.Add(item);
			}
		}
		int num = 1;
		if (owner.name == Module.Name.Bluechip)
		{
			num += (owner.UPGRADED ? 4 : 2);
		}
		foreach (Module item2 in list)
		{
			if (!(item2 == owner))
			{
				item2.AddAura(new Aura(Type.ManaRegen, foreign: true, temp: false, this, num));
			}
		}
	}

	private void PerkCompuwiz()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.MECH)
			{
				item.AddAura(new Aura(Type.PerkCompuwizEffect, foreign: true, temp: false, this));
			}
		}
	}

	private void PerkMagetech()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.WAND)
			{
				item.AddAura(new Aura(Type.PerkMagetechEffect, foreign: true, temp: false, this));
			}
		}
	}

	private void PerkMagetechEffect()
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (adjacent.MECH)
			{
				adjacent.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, (int)owner.manaRegen));
			}
		}
	}

	private void Wrench()
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (adjacent.MECH)
			{
				adjacent.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
			}
		}
	}

	private void PerkHorsepower()
	{
		GiveTribeTrigger(Module.Tribe.Pet, Trigger.Ability.PerkHorsepower);
	}

	private void Rat()
	{
		int num = 0;
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.name == Module.Name.Rat && item != owner)
			{
				num++;
			}
		}
		if (num != 0)
		{
			owner.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, num));
		}
	}

	private void PerkIntellect()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.WAND)
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this));
			}
		}
	}

	private void Powermace()
	{
		if (owner.UPGRADED)
		{
			foreach (Module item in owner.board.GetNetwork(owner))
			{
				if (item.MECH)
				{
					item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this));
				}
			}
		}
		int num = owner.board.GetNetworkCount(owner, Module.Tribe.Mech) - 1;
		owner.counter = num + 1;
		if (num != 0)
		{
			owner.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, num));
		}
	}

	private void Treat()
	{
		foreach (Module item in owner.GetRow())
		{
			if (item.PET)
			{
				item.AddAura(new Aura(Type.Accel, foreign: true, temp: false, this));
				if (owner.UPGRADED)
				{
					item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
				}
			}
		}
	}

	private void Grimoire()
	{
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.name == Module.Name.Imp)
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
			}
		}
	}

	private void BatteryAura()
	{
		int networkCount = dungeon.board.GetNetworkCount(owner, Module.Tribe.Mech);
		networkCount--;
		owner.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, networkCount));
	}

	private void Screwdriver()
	{
		foreach (Module item in owner.board.GetNetwork(owner))
		{
			if (item.MODULE && !Module.movementMods.Contains(item.name) && !Module.wireMods.Contains(item.name))
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, owner.UPGRADED ? 4 : 2));
			}
		}
	}

	private void PerkModulator()
	{
		foreach (Module item in owner.board.GetBoard())
		{
			if (item.MODULE && !Module.movementMods.Contains(item.name) && !Module.wireMods.Contains(item.name))
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
			}
		}
	}

	private void Brass()
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (!(adjacent == null) && adjacent.PET)
			{
				adjacent.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, (!owner.UPGRADED) ? 1 : 3));
				adjacent.AddAura(new Aura(Type.BrassEffect, foreign: true, temp: false, this, owner.UPGRADED ? 30 : 20));
			}
		}
	}

	private void Juice()
	{
		Module below = owner.GetBelow();
		if (!(below == null) && below.PET)
		{
			below.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 3f));
			if (owner.UPGRADED)
			{
				below.AddAura(new Aura(Type.Accel, foreign: true, temp: false, this, 1.6666666f));
			}
		}
	}

	private void Dogwhistle()
	{
		int num = 0;
		foreach (Module output in owner.outputs)
		{
			if (output.PET)
			{
				int num2 = output.damage;
				foreach (Aura aura in output.auras)
				{
					if (aura.source != null && aura.type == Type.Damage && aura.source.type == Type.Dogwhistle)
					{
						num2 -= (int)aura.value;
					}
				}
				num += num2;
			}
			else if (output.WEAPON)
			{
				if (output.name == Module.Name.Magnetizer)
				{
					int damage = output.damage;
					num += damage;
				}
				else
				{
					num += output.damage;
				}
			}
		}
		List<Module> list = (owner.UPGRADED ? owner.board.GetBoard() : owner.GetRow());
		num = Mathf.Max(0, num);
		if (num == 0)
		{
			return;
		}
		foreach (Module item in list)
		{
			if (item.PET)
			{
				item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, num));
			}
		}
	}

	private void Bone()
	{
		List<Module> adjacents = owner.GetAdjacents();
		int num = 0;
		foreach (Module item in adjacents)
		{
			if (!(item == null) && item.PET)
			{
				num += 2;
				if (owner.UPGRADED)
				{
					item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 2f));
				}
			}
		}
		if (num > 0)
		{
			owner.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, num));
		}
	}

	private void PerkHerd()
	{
		List<Module> list = new List<Module>();
		for (int i = 0; i < 3; i++)
		{
			list.Clear();
			int num = 0;
			foreach (Module module in dungeon.board.modules)
			{
				if (!(module == null) && module.index / 5 == i && !list.Contains(module))
				{
					list.Add(module);
					if (module.PET)
					{
						num++;
					}
				}
			}
			if (num < 3)
			{
				continue;
			}
			foreach (Module item in list)
			{
				if (!item.WIREMOD && !item.MOVEMOD)
				{
					item.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, 3f));
				}
			}
		}
	}

	private void Dryer()
	{
		int num = owner.board.GetNetworkCount(owner, Module.Tribe.Mech) - 1;
		if (num > 0)
		{
			owner.AddAura(new Aura(Type.ManaRegen, foreign: true, temp: false, this, 0.5f * (float)num));
		}
	}

	private void Channel()
	{
		float num = 0f;
		foreach (Module output in owner.outputs)
		{
			if (output.WAND)
			{
				num += output.manaRegen;
			}
		}
		if (num != 0f)
		{
			owner.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, (int)num));
		}
	}

	private void RecyclerAura()
	{
		foreach (Module output in owner.outputs)
		{
			output.AddAura(new Aura(Type.Damage, foreign: true, temp: false, this, owner.damage));
		}
	}

	private void HighlightAdjacentWeapons(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module adjacent in owner.GetAdjacents(i))
		{
			if (!(adjacent == owner) && (tribe == Module.Tribe.None || adjacent.tribes.Contains(tribe)) && adjacent.WEAPON)
			{
				if (anim)
				{
					adjacent.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					adjacent.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	private void HighlightAdjacentModules(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module adjacent in owner.GetAdjacents(i))
		{
			if (!(adjacent == owner) && (tribe == Module.Tribe.None || adjacent.tribes.Contains(tribe)) && adjacent.MODULE)
			{
				if (anim)
				{
					adjacent.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					adjacent.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	private void HighlightAdjacents(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module adjacent in owner.GetAdjacents(i))
		{
			if (!(adjacent == owner) && (tribe == Module.Tribe.None || adjacent.tribes.Contains(tribe)))
			{
				if (anim)
				{
					adjacent.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					adjacent.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	private void HighlightLeft(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		Module left = owner.GetLeft(i);
		if (!(left == null) && !(left == owner) && (tribe == Module.Tribe.None || left.tribes.Contains(tribe)))
		{
			if (anim)
			{
				left.HightlightAnim(GetAuraColor(type), 20, persist: true);
			}
			else
			{
				left.Highlight(GetAuraColor(type));
			}
		}
	}

	public void HighlightRight(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		Module right = owner.GetRight(i);
		if (!(right == null) && !(right == owner) && (tribe == Module.Tribe.None || right.tribes.Contains(tribe)))
		{
			if (anim)
			{
				right.HightlightAnim(GetAuraColor(type), 20, persist: true);
			}
			else
			{
				right.Highlight(GetAuraColor(type));
			}
		}
	}

	public void HighlightTopLeftWeapon(bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		Module module = null;
		foreach (Module item in dungeon.board.GetBoard())
		{
			if (item.WEAPON && (item.tribes.Contains(tribe) || tribe == Module.Tribe.None))
			{
				module = item;
				break;
			}
		}
		if (!(module == null) && !(module == owner) && (tribe == Module.Tribe.None || module.tribes.Contains(tribe)))
		{
			if (anim)
			{
				module.HightlightAnim(GetAuraColor(type), 20, persist: true);
			}
			else
			{
				module.Highlight(GetAuraColor(type));
			}
		}
	}

	public void HighlightWeapons(bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module weapon in Dungeon.Instance.board.GetWeapons())
		{
			if (!(weapon == owner) && (tribe == Module.Tribe.None || weapon.tribes.Contains(tribe)))
			{
				if (anim)
				{
					weapon.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					weapon.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightUntribeWeapons(bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module weapon in Dungeon.Instance.board.GetWeapons())
		{
			if (!(weapon == owner) && (tribe == Module.Tribe.None || weapon.tribes.Contains(tribe)) && weapon.tribes.Count <= 0)
			{
				if (anim)
				{
					weapon.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					weapon.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightNonMove(bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module item in Dungeon.Instance.board.GetBoard())
		{
			if (!(item == owner) && (tribe == Module.Tribe.None || item.tribes.Contains(tribe)) && !Module.movementMods.Contains(item.name) && !Module.wireMods.Contains(item.name))
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightMove(bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module item in Dungeon.Instance.board.GetBoard())
		{
			if (!(item == owner) && (tribe == Module.Tribe.None || item.tribes.Contains(tribe)) && Module.movementMods.Contains(item.name))
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightModules(bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module module in Dungeon.Instance.board.GetModules())
		{
			if (!(module == owner) && (tribe == Module.Tribe.None || module.tribes.Contains(tribe)))
			{
				if (anim)
				{
					module.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					module.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightNetwork(bool anim, Module.Tribe tribe = Module.Tribe.None, bool typed = false, Module.Type t = Module.Type.Weapon, bool specialOnly = false)
	{
		foreach (Module item in owner.board.GetNetwork(owner))
		{
			if (!(item == owner) && (tribe == Module.Tribe.None || item.tribes.Contains(tribe)) && (!typed || item.type == t) && (!(typed && t == Module.Type.Module && specialOnly) || (!Module.movementMods.Contains(item.name) && !Module.wireMods.Contains(item.name))))
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightRow(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module item in owner.board.GetBoard())
		{
			if (!(item == owner) && item.index / 5 == i / 5 && (tribe == Module.Tribe.None || item.tribes.Contains(tribe)))
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightRowModules(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module item in owner.board.GetBoard())
		{
			if (!(item == owner) && item.index / 5 == i / 5 && (tribe == Module.Tribe.None || item.tribes.Contains(tribe)) && item.MODULE && !item.WIREMOD)
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightAllTribe(bool anim, Module.Tribe tribe)
	{
		foreach (Module item in owner.board.GetBoard())
		{
			if (!(item == owner) && (tribe == Module.Tribe.None || item.tribes.Contains(tribe)))
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightName(bool anim, Module.Name name)
	{
		foreach (Module item in owner.board.GetBoard())
		{
			if (!(item == owner) && name == item.name)
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightAllUpgraded(bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module item in owner.board.GetBoard())
		{
			if (!(item == owner) && item.UPGRADED && (tribe == Module.Tribe.None || item.tribes.Contains(tribe)))
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightAllBelow(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		foreach (Module item in owner.GetAllBelow(i))
		{
			if (!(item == owner) && (tribe == Module.Tribe.None || item.tribes.Contains(tribe)))
			{
				if (anim)
				{
					item.HightlightAnim(GetAuraColor(type), 20, persist: true);
				}
				else
				{
					item.Highlight(GetAuraColor(type));
				}
			}
		}
	}

	public void HighlightBelow(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		Module below = owner.GetBelow(i);
		if (!(below == null) && !(below == owner) && (tribe == Module.Tribe.None || below.tribes.Contains(tribe)))
		{
			if (anim)
			{
				below.HightlightAnim(GetAuraColor(type), 20, persist: true);
			}
			else
			{
				below.Highlight(GetAuraColor(type));
			}
		}
	}

	public void HighlightAboveWeapon(int i, bool anim, Module.Tribe tribe = Module.Tribe.None)
	{
		Module above = owner.GetAbove(i);
		if (!(above == owner) && !(above == null) && (tribe == Module.Tribe.None || above.tribes.Contains(tribe)) && above.WEAPON)
		{
			if (anim)
			{
				above.HightlightAnim(GetAuraColor(type), 20, persist: true);
			}
			else
			{
				above.Highlight(GetAuraColor(type));
			}
		}
	}
}
