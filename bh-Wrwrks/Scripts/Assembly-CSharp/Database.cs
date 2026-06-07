using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
	public class ModuleInfo
	{
		public string name = "";

		public string desc = "";

		public string upgrade = "";

		public string stats = "";

		public string statsUpgrade = "";

		public List<Module.Tribe> tribe = new List<Module.Tribe>();

		public int price = 10;
	}

	public class MonsterInfo
	{
		public int health = 2;

		public int damage = 1;

		public float speed = 0.5f;

		public int healthUp = 3;

		public int damageUp = 2;

		public float speedUp = 0.7f;
	}

	public static ModuleInfo GetPerkData(Perks.Type t)
	{
		ModuleInfo moduleInfo = new ModuleInfo();
		if (Dungeon.Instance.saveData.language == SaveManager.Language.Japanese)
		{
			Perks.PerkInfo perkText = Perks.GetPerkText(t);
			moduleInfo.name = perkText.name;
			moduleInfo.desc = perkText.desc;
			return moduleInfo;
		}
		moduleInfo.name = t.ToString().ToUpper();
		moduleInfo.name = moduleInfo.name.Replace('_', ' ');
		switch (t)
		{
		case Perks.Type.Fortified:
			moduleInfo.desc = "[green]+25 Max HP[/g]";
			break;
		case Perks.Type.Feedback:
			moduleInfo.desc = "[blue]+0.5 MP[/g] to a random Wand on another Wands cast";
			break;
		case Perks.Type.Stutter:
			moduleInfo.desc = "[white]Every 3s[/g]:\nStun all enemies for [white]0.25s[/g]";
			break;
		case Perks.Type.Souldrain:
			moduleInfo.desc = "Wands get [blue]+0.25 MP[/g] on kill";
			break;
		case Perks.Type.Herd:
			moduleInfo.desc = "+2 DMG to [white]rows[/g] with [green]3+[/g] Pets";
			break;
		default:
			moduleInfo.desc = Perks.GetPerkText(t).desc;
			break;
		}
		return moduleInfo;
	}

	public static ModuleInfo GetModData_Localized(Module m)
	{
		if (Dungeon.Instance.saveData.language == SaveManager.Language.Japanese)
		{
			return DatabaseJP.GetModData(m);
		}
		return GetModData(m);
	}

	public static ModuleInfo GetModData_Localized(Module.Name m)
	{
		if (Dungeon.Instance.saveData.language == SaveManager.Language.Japanese)
		{
			return DatabaseJP.GetModData(m);
		}
		return GetModData(m);
	}

	public static ModuleInfo GetModData(Module m)
	{
		return GetModData(m.name);
	}

	public static ModuleInfo GetModData(Module.Name m)
	{
		ModuleInfo moduleInfo = new ModuleInfo();
		switch (m)
		{
		case Module.Name.Horizontal:
			return Horizontal();
		case Module.Name.Vertical:
			return Vertical();
		case Module.Name.Sword:
			return Sword();
		case Module.Name.Circle:
			return Circle();
		case Module.Name.Axe:
			return Axe();
		case Module.Name.Dumbbell:
			return Boost();
		case Module.Name.Fire:
			return Fire();
		case Module.Name.Capacitor:
			return Capacitor();
		case Module.Name.Toxic:
			return Toxic();
		case Module.Name.Longsword:
			return Longsword();
		case Module.Name.Diagonal:
			return Diagonal();
		case Module.Name.Hourglass:
			return Accelerator();
		case Module.Name.Ruler:
			return Amplifier();
		case Module.Name.Bow:
			return Bow();
		case Module.Name.Meds:
			return Meds();
		case Module.Name.Wave:
			return Wave();
		case Module.Name.Explosive:
			return Explosive();
		case Module.Name.Laser:
			return Laser();
		case Module.Name.Spear:
			return Spear();
		case Module.Name.Weight:
			return Decelerator();
		case Module.Name.Shiv:
			return Shiv();
		case Module.Name.Blood:
			return Blood();
		case Module.Name.Earth:
			return Earth();
		case Module.Name.Anvil:
			return Anvil();
		case Module.Name.Snowball:
			return Snowball();
		case Module.Name.Shuriken:
			return Shuriken();
		case Module.Name.Mace:
			return Mace();
		case Module.Name.Grimoire:
			return Grimoire();
		case Module.Name.Imp:
			return Imp();
		case Module.Name.Quarter:
			return Quarter();
		case Module.Name.Dynamite:
			return Dynamite();
		case Module.Name.Wind:
			return Wind();
		case Module.Name.Maelstrom:
			return Maelstrom();
		case Module.Name.Merger:
			return Merger();
		case Module.Name.Splitter:
			return Splitter();
		case Module.Name.Recycler:
			return Recycler();
		case Module.Name.Egg:
			return Egg();
		case Module.Name.Bird:
			return Bird();
		case Module.Name.Cross:
			return Cross();
		case Module.Name.Bandage:
			return Bandage();
		case Module.Name.Point:
			return Point();
		case Module.Name.Fang:
			return Fang();
		case Module.Name.Scythe:
			return Scythe();
		case Module.Name.Spiral:
			return Spiral();
		case Module.Name.Triangle:
			return Triangle();
		case Module.Name.Star:
			return Star();
		case Module.Name.Turbo:
			return Turbo();
		case Module.Name.Magnet:
			return Magnet();
		case Module.Name.Gold:
			return Gold();
		case Module.Name.Inductor:
			return Inductor();
		case Module.Name.Scaler:
			return Scaler();
		case Module.Name.Flame:
			return Flame();
		case Module.Name.Fish:
			return Fish();
		case Module.Name.Field:
			return Field();
		case Module.Name.Drone:
			return Drone();
		case Module.Name.Magnetizer:
			return Magnetizer();
		case Module.Name.Piggy:
			return Piggy();
		case Module.Name.Treat:
			return Treat();
		case Module.Name.Wolf:
			return Wolf();
		case Module.Name.Armor:
			return Armor();
		case Module.Name.Butterfly:
			return Butterfly();
		case Module.Name.Puppy:
			return Puppy();
		case Module.Name.Rock:
			return Rock();
		case Module.Name.Beehive:
			return Beehive();
		case Module.Name.Honey:
			return Honey();
		case Module.Name.Silicon:
			return Silicon();
		case Module.Name.Powermace:
			return Powermace();
		case Module.Name.Cutter:
			return Cutter();
		case Module.Name.Blade:
			return Blade();
		case Module.Name.Coolant:
			return Coolant();
		case Module.Name.Redchip:
			return Redchip();
		case Module.Name.Collar:
			return Collar();
		case Module.Name.Doghouse:
			return Doghouse();
		case Module.Name.Penguin:
			return Penguin();
		case Module.Name.Glass:
			return Glass();
		case Module.Name.Crown:
			return Crown();
		case Module.Name.Mechatron:
			moduleInfo.name = m.ToString();
			moduleInfo.tribe.Add(Module.Tribe.Mech);
			break;
		case Module.Name.Bolt:
			return Bolt();
		case Module.Name.ManaPot:
			return ManaPot();
		case Module.Name.Curse:
			return Curse();
		case Module.Name.Lifestaff:
			return Lifestaff();
		case Module.Name.Storm:
			return Storm();
		case Module.Name.Frost:
			return Frost();
		case Module.Name.Clown:
			return Clown();
		case Module.Name.Globe:
			return Globe();
		case Module.Name.Soulripper:
			return Soulripper();
		case Module.Name.Alchemy:
			return Alchemy();
		case Module.Name.FlameBall:
			return FlameBall();
		case Module.Name.Mageblade:
			return Mageblade();
		case Module.Name.Necromancy:
			return Necromancy();
		case Module.Name.Swipe:
			return Swipe();
		case Module.Name.Battery:
			return Battery();
		case Module.Name.Fairy:
			return Fairy();
		case Module.Name.Balloon:
			return Balloon();
		case Module.Name.Repeater:
			return Repeater();
		case Module.Name.Cellphone:
			return Cellphone();
		case Module.Name.Water:
			return Water();
		case Module.Name.Longstaff:
			return Longstaff();
		case Module.Name.Bell:
			return Bell();
		case Module.Name.Mirror:
			return Mirror();
		case Module.Name.Square:
			return Square();
		case Module.Name.Wrench:
			return Wrench();
		case Module.Name.Ice:
			return Ice();
		case Module.Name.Pointer:
			return Pointer();
		case Module.Name.Blast:
			return Blast();
		case Module.Name.Cold:
			return Cold();
		case Module.Name.Horseshoe:
			return Horseshoe();
		case Module.Name.Monitor:
			return Monitor();
		case Module.Name.Rat:
			return Rat();
		case Module.Name.Demon:
			return Demon();
		case Module.Name.Microchip:
			return Microchip();
		case Module.Name.Tortoise:
			return Tortoise();
		case Module.Name.Sand:
			return Sand();
		case Module.Name.Firestaff:
			return Firestaff();
		case Module.Name.USB:
			return USB();
		case Module.Name.Matchstick:
			return Matchstick();
		case Module.Name.Food:
			return Food();
		case Module.Name.Robot:
			return Robot();
		case Module.Name.Electrodes:
			return Electrodes();
		case Module.Name.Screwdriver:
			return Screwdriver();
		case Module.Name.Leshy:
			return Leshy();
		case Module.Name.Soulrod:
			return Soulrod();
		case Module.Name.Sonic:
			return Sonic();
		case Module.Name.Dogwhistle:
			return Dogwhistle();
		case Module.Name.Brass:
			return Brass();
		case Module.Name.Juice:
			return Juice();
		case Module.Name.Biochamber:
			return Biochamber();
		case Module.Name.Bone:
			return Bone();
		case Module.Name.Raccoon:
			return Raccoon();
		case Module.Name.Dryer:
			return Dryer();
		case Module.Name.Vortex:
			return Vortex();
		case Module.Name.Bluechip:
			return Bluechip();
		case Module.Name.Mixer:
			return Mixer();
		case Module.Name.MergeTriple:
			return MergeTriple();
		case Module.Name.SplitTriple:
			return SplitTriple();
		case Module.Name.MixerTriple:
			return MixerTriple();
		case Module.Name.Phial:
			return Phial();
		case Module.Name.Spellbook:
			return Spellbook();
		case Module.Name.Channel:
			return Channel();
		case Module.Name.Razor:
			return Razor();
		case Module.Name.Discharger:
			return Discharger();
		default:
			moduleInfo.name = m.ToString();
			moduleInfo.desc = "[UNIMPLEMENTED]";
			Debug.LogWarning("UNKNOWN MODULE");
			break;
		}
		return moduleInfo;
	}

	public static ModuleInfo Horizontal()
	{
		return new ModuleInfo
		{
			name = "HORIZONTAL",
			desc = "Move Weapon\nleft and right",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			upgrade = "+10% AMP/SPD",
			statsUpgrade = "AMP: {AMP}[g]+10%[/g]\nSPD: {SPD}[g]+10%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Vertical()
	{
		return new ModuleInfo
		{
			name = "VERTICAL",
			desc = "Move Weapon\nup and down",
			upgrade = "+10% AMP/SPD",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "AMP: {AMP}[g]+10%[/g]\nSPD: {SPD}[g]+10%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Circle()
	{
		return new ModuleInfo
		{
			name = "CIRCLE",
			desc = "Move Weapon\nin a circle",
			upgrade = "+20% SPD",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "AMP: {AMP}\nSPD: {SPD}[g]+20%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Square()
	{
		return new ModuleInfo
		{
			name = "SQUARE",
			desc = "Move Weapon\nin a Square",
			upgrade = "+20% SPD",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "AMP: {AMP}\nSPD: {SPD}[g]+20%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Scaler()
	{
		return new ModuleInfo
		{
			name = "SCALER",
			desc = "Scale Weapon\nup and down",
			upgrade = "+50% Size",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			price = 5
		};
	}

	public static ModuleInfo Spiral()
	{
		return new ModuleInfo
		{
			name = "SPIRAL",
			desc = "Move Weapon\nin a spiral",
			upgrade = "+20% AMP",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "AMP: {AMP}[g]+20%[/g]\nSPD: {SPD}",
			price = 3
		};
	}

	public static ModuleInfo Sword()
	{
		return new ModuleInfo
		{
			name = "SWORD",
			desc = "Basic Weapon",
			upgrade = "+1 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static ModuleInfo Turbo()
	{
		return new ModuleInfo
		{
			name = "TURBO BOT",
			desc = "Give adjacent Modules +30% SPD",
			upgrade = "+1 DMG\n+15% SPD buff",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static ModuleInfo Snowball()
	{
		return new ModuleInfo
		{
			name = "SNOWBALL",
			desc = "On Kill: +1 DMG and +20% size\nfor [white]1 second[/g]",
			upgrade = "+1 DMG\n+1s Duration",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 15
		};
	}

	public static ModuleInfo Shiv()
	{
		return new ModuleInfo
		{
			name = "SHIV",
			desc = "On Kill:\n[white]50% chance[/g] to\n[green]Heal 1 HP[/g]",
			upgrade = "+1 DMG, +1 Heal",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static ModuleInfo Axe()
	{
		return new ModuleInfo
		{
			name = "AXE",
			desc = "Splash damage\non hit",
			upgrade = "+1 DMG\nLarger splash",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static ModuleInfo Boost()
	{
		return new ModuleInfo
		{
			name = "DUMBBELL",
			desc = "Give adjacent items +1 DMG",
			upgrade = "+1 DMG",
			price = 5
		};
	}

	public static ModuleInfo Accelerator()
	{
		return new ModuleInfo
		{
			name = "HOURGLASS",
			desc = "Give adjacent Modules +30% SPD",
			upgrade = "+15% SPD",
			price = 5
		};
	}

	public static ModuleInfo Decelerator()
	{
		return new ModuleInfo
		{
			name = "WEIGHT",
			desc = "Give Weapon [white]above[/w] this +2 DMG and\n-50% SPD to all of its inputs",
			upgrade = "+1 DMG, -20% SPD",
			price = 10
		};
	}

	public static ModuleInfo Amplifier()
	{
		return new ModuleInfo
		{
			name = "RULER",
			desc = "Give adjacent Modules +30% AMP",
			upgrade = "+15% AMP buff",
			price = 5
		};
	}

	public static ModuleInfo Earth()
	{
		return new ModuleInfo
		{
			name = "EARTH GEM",
			desc = "Give +2 DMG to attached item",
			upgrade = "Gives Knockback",
			price = 10
		};
	}

	public static ModuleInfo Fire()
	{
		return new ModuleInfo
		{
			name = "FIRE GEM",
			desc = "Give Weapon\nFire Trail",
			upgrade = "+1 DMG\nLonger Trail",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static ModuleInfo Toxic()
	{
		return new ModuleInfo
		{
			name = "TOXIN",
			desc = "Poison area\non hit",
			upgrade = "Extra duration",
			stats = "DMG: {DMG}\nCD: {CD}",
			price = 10
		};
	}

	public static ModuleInfo Fish()
	{
		return new ModuleInfo
		{
			name = "FISH",
			desc = "Gains +2 DMG per adjacent Pet",
			upgrade = "+30% SPD per adjacent Pet",
			stats = "DMG: {DMG}",
			tribe = { Module.Tribe.Pet },
			price = 5
		};
	}

	public static ModuleInfo Wolf()
	{
		return new ModuleInfo
		{
			name = "LONE WOLF",
			desc = "Gains +3 DMG per adjacent empty item slot",
			upgrade = "+3 DMG per slot",
			stats = "DMG: {DMG}",
			tribe = { Module.Tribe.Pet },
			price = 15
		};
	}

	public static ModuleInfo Longsword()
	{
		return new ModuleInfo
		{
			name = "LONGSWORD",
			desc = "Basic Weapon",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 5
		};
	}

	public static ModuleInfo Blood()
	{
		return new ModuleInfo
		{
			name = "BLOODBLADE",
			desc = "Gain +1 DMG\nevery [white]40 kills[/g]",
			upgrade = "Double kill buff",
			stats = "DMG: {DMG}\nKILLS: {COUNT}",
			price = 15
		};
	}

	public static ModuleInfo Explosive()
	{
		return new ModuleInfo
		{
			name = "EXPLOSIVE",
			desc = "Manual controlled\ndetonation",
			upgrade = "+20% size\n-0.5s CD",
			stats = "DMG: {DMG}\nCD: {CD}",
			price = 10
		};
	}

	public static ModuleInfo Bow()
	{
		return new ModuleInfo
		{
			name = "BOW",
			desc = "Ranged Weapon",
			upgrade = "Rapid fire",
			stats = "DMG: {DMG}",
			price = 10
		};
	}

	public static ModuleInfo Diagonal()
	{
		return new ModuleInfo
		{
			name = "DIAGONAL",
			desc = "Move Weapon in a diagonal ellipse",
			stats = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}",
			upgrade = "+10% AMP/SPD",
			statsUpgrade = "ANG: {ANG}\nAMP: {AMP}[g]+10%[/g]\nSPD: {SPD}[g]+10%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Quarter()
	{
		return new ModuleInfo
		{
			name = "QUARTER",
			desc = "Move Weapon in a\nQuarter Circle",
			upgrade = "+15% SPD\nMove Half Circle",
			stats = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}[g]+15%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Triangle()
	{
		return new ModuleInfo
		{
			name = "TRIANGLE",
			desc = "Move Weapon\nin a triangle",
			upgrade = "+20% SPD",
			stats = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}[g]+20%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Star()
	{
		return new ModuleInfo
		{
			name = "STAR",
			desc = "Move Weapon in\n a star pattern",
			upgrade = "+1 Star Point\n+15% SPD",
			stats = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}[g]+15%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Meds()
	{
		return new ModuleInfo
		{
			name = "MEDKIT",
			desc = "Give Weapon a\n[white]40% chance[/g] to \nheal [green]1[/g] on [white]kill[/g]",
			upgrade = "+1 Heal on kill",
			price = 10
		};
	}

	public static ModuleInfo Wave()
	{
		return new ModuleInfo
		{
			name = "WAVE",
			desc = "Move Weapon\nin a wave",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			upgrade = "+10% AMP/SPD",
			statsUpgrade = "AMP: {AMP}[g]+10%[/g]\nSPD: {SPD}[g]+10%[/g]",
			price = 3
		};
	}

	public static ModuleInfo Field()
	{
		return new ModuleInfo
		{
			name = "FORCEFIELD",
			desc = "On [red]DMG taken[/g]:\nZap nearby enemies\n[white]Can't be moved[/g]",
			upgrade = "+1 DMG\nZap periodically",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Drone()
	{
		return new ModuleInfo
		{
			name = "DRONE",
			desc = "Fires explosive rockets\n[white]Auto-Movement[/g]",
			upgrade = "+30% ATK SPD\n+30% Area",
			stats = "DMG: {DMG}",
			price = 15,
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Pet
			}
		};
	}

	public static ModuleInfo Spear()
	{
		return new ModuleInfo
		{
			name = "SPEAR",
			desc = "Thrust Weapon",
			upgrade = "Range up\n+1 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static ModuleInfo Shuriken()
	{
		return new ModuleInfo
		{
			name = "SHURIKEN",
			desc = "Triple Projectile",
			upgrade = "+1 Projectile",
			stats = "DMG: {DMG}\nANG: {ANG}",
			price = 10
		};
	}

	public static ModuleInfo Flame()
	{
		return new ModuleInfo
		{
			name = "FLAMETHROWER",
			desc = "Short range fire",
			upgrade = "Range up\n+1 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 15,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Grimoire()
	{
		return new ModuleInfo
		{
			name = "GRIMOIRE",
			desc = "[white]Start of Wave[/g]:\nCreate a Pet Imp ",
			upgrade = "Gives Imps +2 DMG\nCreates Imp+\n",
			price = 15
		};
	}

	public static ModuleInfo Magnet()
	{
		return new ModuleInfo
		{
			name = "MAGNET",
			desc = "Pull Weapon to\nnearby enemies",
			upgrade = "Pulls enemies\nto Weapon",
			price = 20
		};
	}

	public static ModuleInfo Imp()
	{
		return new ModuleInfo
		{
			name = "IMP",
			desc = "Shoots random enemies",
			upgrade = "+1 DMG\n+25% ATK SPD",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 2,
			tribe = { Module.Tribe.Pet }
		};
	}

	public static ModuleInfo Demon()
	{
		return new ModuleInfo
		{
			name = "DEMON",
			desc = "Shoots waves of fireballs",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 15,
			tribe = { Module.Tribe.Pet }
		};
	}

	public static ModuleInfo Mace()
	{
		return new ModuleInfo
		{
			name = "MACE",
			desc = "Knockback on hit",
			upgrade = "+1 DMG\n25% Stun on hit",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static ModuleInfo Wind()
	{
		return new ModuleInfo
		{
			name = "WIND GEM",
			desc = "Give Weapon\n[white]30% chance[/g] to\n[white]Zap[/g] on hit",
			upgrade = "+1 DMG\nExtra Bounces",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static ModuleInfo Capacitor()
	{
		return new ModuleInfo
		{
			name = "CAPACITOR",
			desc = "Weapon explodes\n[white]every 2 seconds[/g]\nGains +1 DMG per\nMech in network",
			upgrade = "+1 DMG per Mech",
			stats = "DMG: {DMG}",
			price = 10,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Inductor()
	{
		return new ModuleInfo
		{
			name = "INDUCTOR",
			desc = "Adjacent Weapons\nget [white]Zap[/g] on hit\nGains +1 DMG per\nMech in network",
			upgrade = "+1 DMG per Mech",
			stats = "DMG: {DMG}",
			price = 15,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Dynamite()
	{
		return new ModuleInfo
		{
			name = "DYNAMITE",
			desc = "Give Weapon\nExplode on kill",
			upgrade = "25% Explode on hit",
			stats = "DMG: {DMG}",
			price = 5
		};
	}

	public static ModuleInfo Fang()
	{
		return new ModuleInfo
		{
			name = "VAMP FANG",
			desc = "Give Weapon a\n[white]10% chance[/g] to\nheal 1 HP on [white]hit[/g]",
			upgrade = "+1 Healing",
			price = 15
		};
	}

	public static ModuleInfo Maelstrom()
	{
		return new ModuleInfo
		{
			name = "MAELSTROM",
			desc = "[white]50% Chance[/g] to\n[white]Zap[/g] on hit",
			upgrade = "+2 DMG\n100% Zap Chance",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 20
		};
	}

	public static ModuleInfo Scythe()
	{
		return new ModuleInfo
		{
			name = "SCYTHE",
			desc = "On Kill:\nSummon ally ghost",
			upgrade = "+1 Ghost",
			stats = "DMG: {DMG}",
			price = 15
		};
	}

	public static ModuleInfo Merger()
	{
		return new ModuleInfo
		{
			name = "MERGER",
			desc = "Merge two inputs\ninto one output",
			price = 5
		};
	}

	public static ModuleInfo Splitter()
	{
		return new ModuleInfo
		{
			name = "SPLITTER",
			desc = "Split one input\ninto two outputs",
			price = 5
		};
	}

	public static ModuleInfo Recycler()
	{
		return new ModuleInfo
		{
			name = "RECYCLER",
			desc = "On [white]Shop Reroll[/g]:\nGive Weapon +2 DMG\nuntil [white]End of Wave[/g]",
			upgrade = "-$1 Reroll Cost",
			stats = "DMG: {DMG}",
			price = 10
		};
	}

	public static ModuleInfo Egg()
	{
		return new ModuleInfo
		{
			name = "EGG",
			desc = "On Kill:\nTransform into\na Pet Bird",
			upgrade = "+1 DMG\nCreates Bird+",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5,
			tribe = { Module.Tribe.Pet }
		};
	}

	public static ModuleInfo Bird()
	{
		return new ModuleInfo
		{
			name = "BIRD",
			desc = "Create an [white]Egg[/g] every [white]40 kills[/g]",
			stats = "DMG: {DMG}\nKILLS: {COUNT}",
			upgrade = "+3 DMG\n+15% SPD",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]\nKILLS: {COUNT}",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static ModuleInfo Cross()
	{
		return new ModuleInfo
		{
			name = "CROSS",
			desc = "Shoots holy beams\nwhenever you heal",
			upgrade = "+1 DMG\n+1 Healing HP",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static ModuleInfo Gold()
	{
		return new ModuleInfo
		{
			name = "GOLD ROD",
			desc = "[white]15% chance[/g] to get +$1 on kill",
			upgrade = "+1 DMG, +10% chance",
			stats = "DMG: {DMG}",
			price = 10
		};
	}

	public static ModuleInfo Bandage()
	{
		return new ModuleInfo
		{
			name = "BANDAGE",
			desc = "Adjacent Weapons\nhave a [white]25% chance[/g] to heal [green]1[/g] on [white]kill[/g]",
			upgrade = "+1 Heal on kill",
			price = 15
		};
	}

	public static ModuleInfo Point()
	{
		return new ModuleInfo
		{
			name = "POINT",
			desc = "Move Weapon\nto fixed point",
			upgrade = "Gives +1 DMG",
			price = 3,
			stats = "ANG: {ANG}\nAMP: {AMP}"
		};
	}

	public static ModuleInfo Piggy()
	{
		return new ModuleInfo
		{
			name = "PIGGY BANK",
			desc = "[white]End of Wave[/g]:\nGet +$1 for each\nitem in network",
			upgrade = "+$1 per item",
			stats = "COUNT: {COUNT}",
			price = 20
		};
	}

	public static ModuleInfo Treat()
	{
		return new ModuleInfo
		{
			name = "TREAT",
			desc = "Gives +30% SPD to Pets on [white]this row[/g]",
			upgrade = "Gives +2 DMG",
			price = 10
		};
	}

	public static ModuleInfo Juice()
	{
		return new ModuleInfo
		{
			name = "JUICE",
			desc = "Give +3 DMG to\nPet [white]below[/g] this[/g]",
			upgrade = "Gives +50% SPD",
			price = 10
		};
	}

	public static ModuleInfo Brass()
	{
		return new ModuleInfo
		{
			name = "BRASS PAW",
			desc = "Give +1 DMG and [white]20% chance[/g] to [white]Stun[/g] to adjacent Pets",
			upgrade = "+2 DMG, +10% Stun",
			price = 15
		};
	}

	public static ModuleInfo Dogwhistle()
	{
		return new ModuleInfo
		{
			name = "DOGWHISTLE",
			desc = "Give Pets on [white]this row[/g] DMG equal to attached Weapon[red]'s[/g]",
			upgrade = "Affects ALL Pets",
			price = 20
		};
	}

	public static ModuleInfo Biochamber()
	{
		return new ModuleInfo
		{
			name = "BIOCHAMBER",
			desc = "[white]Start of Wave:[/g]\nTransform into a [white]clone[/g] of the Pet\nto the [white]right[/g]",
			upgrade = "Give cloned pet\n+10 DMG, +50% SPD",
			price = 20
		};
	}

	public static ModuleInfo Armor()
	{
		return new ModuleInfo
		{
			name = "ARMOR",
			desc = "[green]+5 Max HP[/green] for each item in network",
			upgrade = "+5 HP per item",
			stats = "COUNT: {COUNT}",
			price = 5
		};
	}

	public static ModuleInfo Butterfly()
	{
		return new ModuleInfo
		{
			name = "BUTTERFLY",
			desc = "Heals [green]1 HP[/green]\nevery [white]1 second[/g]",
			upgrade = "+1 DMG\n+2 Healing",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Pet },
			price = 5
		};
	}

	public static ModuleInfo Puppy()
	{
		return new ModuleInfo
		{
			name = "PUPPY",
			desc = "Follows Weapon\nto the [white]left[/w]",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static ModuleInfo Rock()
	{
		return new ModuleInfo
		{
			name = "PET ROCK",
			desc = "On Hit:\n[white]30% chance[/g] to splash [white]pebbles[/g]",
			upgrade = "+1 DMG\n+30% chance",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Pet },
			price = 5
		};
	}

	public static ModuleInfo Beehive()
	{
		return new ModuleInfo
		{
			name = "BEEHIVE",
			desc = "Spawns a Bee\nevery [white]0.5 seconds[/g]\nEvery [white]20 kills[/g]:\nCreate [g]Honey[/g]",
			upgrade = "+50% Spawn Speed\nCreates Honey+",
			stats = "DMG: {DMG}\nKILLS: {COUNT}",
			tribe = { Module.Tribe.Pet },
			price = 15
		};
	}

	public static ModuleInfo Honey()
	{
		return new ModuleInfo
		{
			name = "HONEY",
			desc = "Can be [white]sold[/g] for \na [g]high price[/g]",
			upgrade = "+100% Sell Value",
			price = 20
		};
	}

	public static ModuleInfo Silicon()
	{
		return new ModuleInfo
		{
			name = "SILICON",
			desc = "+1 DMG for each\nconnected [white]input[/g]",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = { Module.Tribe.Mech },
			price = 20
		};
	}

	public static ModuleInfo Robot()
	{
		return new ModuleInfo
		{
			name = "ROBOT BUG",
			desc = "Shoots [red]beams[/g] at nearby enemies\n[white]Auto-Movement[/g]",
			upgrade = "+2 DMG, +Range",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Pet
			},
			price = 15
		};
	}

	public static ModuleInfo Electrodes()
	{
		return new ModuleInfo
		{
			name = "ELECTRODES",
			desc = "Create an [red]electric field[/g] between all Weapons in [white]Network[/g]",
			upgrade = "+2 DMG, +15% Stun",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = { Module.Tribe.Mech },
			price = 15
		};
	}

	public static ModuleInfo Coolant()
	{
		return new ModuleInfo
		{
			name = "COOLANT",
			desc = "Adjacent Mechs apply Slow for\n2s on hit",
			upgrade = "Improve all Slows",
			price = 10
		};
	}

	public static ModuleInfo Redchip()
	{
		return new ModuleInfo
		{
			name = "RED CHIP",
			desc = "Give Mechs in network +1 DMG\nfor each Mech",
			upgrade = "+1 DMG to Network",
			stats = "COUNT: {COUNT}",
			tribe = { Module.Tribe.Mech },
			price = 20
		};
	}

	public static ModuleInfo Microchip()
	{
		return new ModuleInfo
		{
			name = "MICROCHIP",
			desc = "Attached Weapon counts as Mech\nand has +1 DMG",
			upgrade = "+1 DMG to Network",
			tribe = { Module.Tribe.Mech },
			price = 5
		};
	}

	public static ModuleInfo Collar()
	{
		return new ModuleInfo
		{
			name = "SPARKPLUGS",
			desc = "Adjacent Pets [white]Zap[/g] area [white]on kill[/g]",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 10,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Doghouse()
	{
		return new ModuleInfo
		{
			name = "DOGHOUSE",
			desc = "Give Pet to the [white]right[/w] +1 DMG per Pet on board and +40% SPD",
			upgrade = "+3 DMG, +15% SPD",
			price = 15
		};
	}

	public static ModuleInfo Penguin()
	{
		return new ModuleInfo
		{
			name = "PENGUIN",
			desc = "Slides at enemies\nSlow for 2s on hit",
			upgrade = "+2 DMG\nIce Explosion",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static ModuleInfo Glass()
	{
		return new ModuleInfo
		{
			name = "GLASS",
			desc = "After [white]30 hits[/g]:\nBreaks until the [white]end of wave[/g]",
			stats = "DMG: {DMG}\nHITS: {COUNT}",
			upgrade = "+2 DMG\n+20 Max Hits",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]\nHITS: {COUNT}",
			price = 10
		};
	}

	public static ModuleInfo Crown()
	{
		return new ModuleInfo
		{
			name = "CROWN",
			desc = "Give the item [white]below[/w] this +1 DMG",
			upgrade = "+1 DMG",
			price = 10
		};
	}

	public static ModuleInfo Bolt()
	{
		return new ModuleInfo
		{
			name = "BOLT",
			desc = "{SPELL}: Shoot bolt at a random enemy\n[white]Can't be moved[/g]",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +1 MP/s",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}[g]+1[/g]",
			price = 10,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo ManaPot()
	{
		return new ModuleInfo
		{
			name = "MANA POT",
			desc = "Give +1 MP/s to attached Wand",
			upgrade = "+1 MP/s",
			price = 5
		};
	}

	public static ModuleInfo Soulrod()
	{
		return new ModuleInfo
		{
			name = "SOULROD",
			desc = "Give Wand a\n[white]10% chance[/g] to\n[blue]cast[/g] [white]on kill[/g]",
			upgrade = "+10% chance",
			price = 10
		};
	}

	public static ModuleInfo Sonic()
	{
		return new ModuleInfo
		{
			name = "SONIC WAVE",
			desc = "Attached Wand fires [white]sonic wave[/g]\non [blue]casting[/g]",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]",
			upgrade = "+3 DMG",
			price = 15
		};
	}

	public static ModuleInfo Lifestaff()
	{
		return new ModuleInfo
		{
			name = "LIFESTAFF",
			desc = "{SPELL}: Heal 3 HP",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +3 Heal",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			tribe = { Module.Tribe.Wand },
			price = 15
		};
	}

	public static ModuleInfo Curse()
	{
		return new ModuleInfo
		{
			name = "CURSE RUNE",
			desc = "Give Wand +2 DMG and [red]+1 MP Cost[/g]",
			upgrade = "+2 DMG, -2 MP/s",
			price = 15
		};
	}

	public static ModuleInfo Storm()
	{
		return new ModuleInfo
		{
			name = "STORM ROD",
			desc = "{SPELL}: Zap nearby enemies next hit",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+2 MP/s",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+2[/g]",
			price = 15,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo Frost()
	{
		return new ModuleInfo
		{
			name = "FROST ORBS",
			desc = "Slow on hit\nfor [white]1 second[/g]\n{SPELL}: [red]3[/g] DMG to all slowed enemies",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 MP/s, +1s Slow",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+1[/g]",
			price = 20,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo Clown()
	{
		return new ModuleInfo
		{
			name = "CLOWN ROD",
			desc = "{SPELL}: Create 6 bouncing balls",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			upgrade = "+1 DMG, +3 Balls",
			price = 10,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo Globe()
	{
		return new ModuleInfo
		{
			name = "SNOWGLOBE",
			desc = "{SPELL}: Give +2 DMG to adjacent items for [white]1 second[/g]",
			stats = "MP: {MP}",
			upgrade = "+1s Duration",
			price = 10,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo Soulripper()
	{
		return new ModuleInfo
		{
			name = "SOULRIPPER",
			desc = "On Kill:\nGive [blue]+2 MP[/g] to adjacent Wands",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]",
			upgrade = "+3 DMG, +2 MP Gain",
			price = 15
		};
	}

	public static ModuleInfo Alchemy()
	{
		return new ModuleInfo
		{
			name = "ALCHEMY",
			desc = "Give +1 MP/s to adjacent Wands",
			upgrade = "+2 MP/s",
			price = 15
		};
	}

	public static ModuleInfo FlameBall()
	{
		return new ModuleInfo
		{
			name = "FLAME",
			desc = "Gain [blue]+1 MP[/g] when other [blue]Wands[/g] cast\n{SPELL}: Fire large explosive bolt",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+5[/g]\nMP: {MP}",
			upgrade = "+5 DMG",
			price = 15,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo Mageblade()
	{
		return new ModuleInfo
		{
			name = "MAGEBLADE",
			desc = "{SPELL}: Gain +2 DMG for [white]1 second[/g]",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]\nMP: {MP}",
			upgrade = "+2 DMG, +2 MP DMG",
			price = 15,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo Necromancy()
	{
		return new ModuleInfo
		{
			name = "NECROMANCY",
			desc = "{SPELL}: Summon a [green]Skeleton[/g] ally\n[white]Can't be moved[/g]",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}[g]+1[/g]",
			upgrade = "+1 DMG, +1 MP/s",
			price = 20,
			tribe = 
			{
				Module.Tribe.Wand,
				Module.Tribe.Pet
			}
		};
	}

	public static ModuleInfo Swipe()
	{
		return new ModuleInfo
		{
			name = "BEAR CLAWS",
			desc = "{SPELL}: Swipe next hit for [red]2x DMG[/g]\nGains +1 MP/s per Pet on this row",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			upgrade = "+1 DMG, Knockback",
			price = 15,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo Battery()
	{
		return new ModuleInfo
		{
			name = "BATTERY",
			desc = "{SPELL}: Mechs in network [white]Zap[/g] area\n+1 DMG per Mech",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+1[/g]",
			upgrade = "+1 MP/s",
			price = 10,
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Wand
			}
		};
	}

	public static ModuleInfo Matchstick()
	{
		return new ModuleInfo
		{
			name = "MATCHSTICK",
			desc = "{SPELL}: Give a ring of [white]fireballs[/g] to connected Weapon",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 Fireball",
			price = 10,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static ModuleInfo Fairy()
	{
		return new ModuleInfo
		{
			name = "FAIRY",
			desc = "Orbits enemies\n{SPELL}: Blast area\nStuns for 1s",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +1 MP/s",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}[g]+1[/g]",
			price = 10,
			tribe = 
			{
				Module.Tribe.Pet,
				Module.Tribe.Wand
			}
		};
	}

	public static ModuleInfo Raccoon()
	{
		return new ModuleInfo
		{
			name = "TRASH EATER",
			desc = "Gain +1 DMG [red]permanently[/g] when you [white]sell[/g] a Weapon",
			stats = "DMG: {DMG}",
			upgrade = "+1 DMG per sell",
			price = 10,
			tribe = { Module.Tribe.Pet }
		};
	}

	public static ModuleInfo Cellphone()
	{
		return new ModuleInfo
		{
			name = "CELLPHONE",
			desc = "{SPELL}: Trigger a [red]random effect[/g]",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG\nBoosted Effects",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			price = 10,
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Wand
			}
		};
	}

	public static ModuleInfo Balloon()
	{
		return new ModuleInfo
		{
			name = "BALLOON",
			desc = "Move Weapon up and Give [white]25% chance[/g] to explode [white]On Hit[/g]",
			upgrade = "+1 DMG\n+25% chance",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static ModuleInfo Repeater()
	{
		return new ModuleInfo
		{
			name = "REPEATER",
			desc = "Connected Weapon triggers effects twice",
			upgrade = "+1 Extra Trigger",
			price = 20,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Food()
	{
		return new ModuleInfo
		{
			name = "FOOD",
			desc = "[white]Start of Wave[/g]:\nGive Weapon [red]+1 permanent DMG[/g]\n[white]Limited Uses[/g]",
			upgrade = "+6 CHARGE",
			stats = "[white]CHARGE: {COUNT}[/g]",
			statsUpgrade = "[white]CHARGE: {COUNT}[g]+6[/g]",
			price = 10
		};
	}

	public static ModuleInfo Water()
	{
		return new ModuleInfo
		{
			name = "WATER CAN",
			desc = "Grows [red]Explosive Flowers[/g] in path",
			stats = "DMG: {DMG}\n[white]MAX: {COUNT}[/g]",
			upgrade = "+1 DMG\n+10 Max Flowers",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\n[white]MAX: {COUNT}[/g][g]+10[/g]",
			price = 15
		};
	}

	public static ModuleInfo Longstaff()
	{
		return new ModuleInfo
		{
			name = "LONGSTAFF",
			desc = "Has +2 DMG while at full HP",
			stats = "DMG: {DMG}",
			upgrade = "+1 DMG\n+1 Full HP DMG",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 10
		};
	}

	public static ModuleInfo Wrench()
	{
		return new ModuleInfo
		{
			name = "WRENCH",
			desc = "Gives +2 DMG to adjacent Mechs",
			stats = "DMG: {DMG}",
			upgrade = "+1 DMG, Upgrade a random Mech",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static ModuleInfo Screwdriver()
	{
		return new ModuleInfo
		{
			name = "SCREWDRIVER",
			desc = "Gives +2 DMG to Modules in [white]Network[/g]",
			stats = "DMG: {DMG}",
			upgrade = "+2 DMG to Modules",
			price = 10
		};
	}

	public static ModuleInfo Ice()
	{
		return new ModuleInfo
		{
			name = "ICE GEM",
			desc = "Give Weapon\nSlow on hit for 1s",
			upgrade = "+1s Slow",
			price = 10
		};
	}

	public static ModuleInfo Pointer()
	{
		return new ModuleInfo
		{
			name = "POINTER",
			desc = "Adjacent Mech Weapons shoot lasers every 1s",
			upgrade = "+1 DMG, +50% SPD",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static ModuleInfo Blast()
	{
		return new ModuleInfo
		{
			name = "BLASTER",
			desc = "{SPELL}: Blast area",
			upgrade = "+1 MP/s\n+Explosion Size",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+1[/g]",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static ModuleInfo Cold()
	{
		return new ModuleInfo
		{
			name = "COLD ROD",
			desc = "{SPELL}: Shoot beams at nearby enemies\nSlows for 2s[/g]",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +1s Slow",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static ModuleInfo Sand()
	{
		return new ModuleInfo
		{
			name = "SANDSTICK",
			desc = "{SPELL}: Give items on [white]this row[/g]\n+50% SPD for 1s[/g]",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +1s Buff",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static ModuleInfo Firestaff()
	{
		return new ModuleInfo
		{
			name = "FIRESTAFF",
			desc = "{SPELL}: Create ring of fireballs",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 MP/s\n+1 Fireball",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+1[/g]",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static ModuleInfo Bell()
	{
		return new ModuleInfo
		{
			name = "BELL",
			desc = "On Hit:\n[white]10% chance[/g] to\n[white]Stun[/g] area for [white]1s[/g]",
			stats = "DMG: {DMG}",
			upgrade = "+1 DMG\n+5% Stun Chance",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static ModuleInfo Bone()
	{
		return new ModuleInfo
		{
			name = "BONE CLUB",
			desc = "Gains +2 DMG per adjacent Pet",
			stats = "DMG: {DMG}",
			upgrade = "Gives +2 DMG to adjacent Pets",
			statsUpgrade = "DMG: {DMG}",
			price = 10
		};
	}

	public static ModuleInfo Horseshoe()
	{
		return new ModuleInfo
		{
			name = "HORSESHOE",
			desc = "Give +50% SPD to Pet [white]above[/g] this ",
			upgrade = "Gives +2 DMG",
			price = 10
		};
	}

	public static ModuleInfo Monitor()
	{
		return new ModuleInfo
		{
			name = "MONITOR",
			desc = "Fires explosive beams. Triggers on Heal and [white]every 1s[/g]\n[white]Can't be moved[/g]",
			upgrade = "+2 DMG, +50% SPD",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = { Module.Tribe.Mech },
			price = 20
		};
	}

	public static ModuleInfo Powermace()
	{
		return new ModuleInfo
		{
			name = "POWERMACE",
			desc = "Gains +1 DMG per Mech in network",
			upgrade = "+1 DMG to all Mechs in network",
			stats = "DMG: {DMG}\nCOUNT: {COUNT}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static ModuleInfo USB()
	{
		return new ModuleInfo
		{
			name = "USB",
			desc = "Give [blue]+0.5 MP/s[/g] to adjacent Wands per Mech in [white]network[/g]",
			upgrade = "Gives +1 DMG per\nMech in network",
			stats = "DMG: {DMG}\nCOUNT: {COUNT}",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static ModuleInfo Rat()
	{
		return new ModuleInfo
		{
			name = "RAT",
			desc = "Gains +1 DMG for each other Rat",
			upgrade = "+1 DMG\nCreate another Rat",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Pet },
			price = 5
		};
	}

	public static ModuleInfo Tortoise()
	{
		return new ModuleInfo
		{
			name = "TORTOISE",
			desc = "-80% SPD",
			upgrade = "+4 DMG, -40% SPD",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+4[/g]",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static ModuleInfo Mirror()
	{
		return new ModuleInfo
		{
			name = "MIRROR",
			desc = "Create [white]reflection[/g] of Weapon to the [white]left[/g] of this",
			stats = "DMG: {DMG}",
			upgrade = "+3 DMG",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]",
			price = 15
		};
	}

	public static ModuleInfo Dryer()
	{
		return new ModuleInfo
		{
			name = "HAIRDRYER",
			desc = "{SPELL}: Shoots a [white]knockback[/g] blast\n[blue]+0.5 MP/s[/g] per\nMech in [white]Network[/g]",
			upgrade = "+1 DMG, +1 MP/s",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}[g]+1[/g]",
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Wand
			},
			price = 15
		};
	}

	public static ModuleInfo Blade()
	{
		return new ModuleInfo
		{
			name = "SWITCHBLADE",
			desc = "[white]Stabs[/g] nearby enemies every 1s\n[white]+1 Stab[/g] fired per\nMech in Network",
			upgrade = "+1 Stab per Mech",
			stats = "DMG: {DMG}\n[white]COUNT: {COUNT}[/g]",
			statsUpgrade = "DMG: {DMG}\n[white]COUNT: {COUNT}[g]x2[/g]",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static ModuleInfo Anvil()
	{
		return new ModuleInfo
		{
			name = "ANVIL",
			desc = "Give +2 DMG to\nall [white]basic[/g] Weapons",
			upgrade = "Upgrades all\nbasic Weapons",
			price = 20
		};
	}

	public static ModuleInfo Vortex()
	{
		return new ModuleInfo
		{
			name = "VORTEX",
			desc = "Give Wand [red]+1 MP Cost[/g] and [white]Stun[/g] area on [blue]cast[/g] for 1s",
			upgrade = "+5 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+5[/g]",
			price = 15
		};
	}

	public static ModuleInfo Bluechip()
	{
		return new ModuleInfo
		{
			name = "PROCESSOR",
			desc = "Counts as [mech]3[/g] Mechs in its [white]Network[/g]",
			upgrade = "+2 Mech Count",
			price = 15,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Leshy()
	{
		return new ModuleInfo
		{
			name = "LESHY",
			desc = "{SPELL}: Give +3 DMG to all Pets for 2s",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+3 DMG\n+3 Buff DMG",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]\nMP: {MP}",
			price = 15,
			tribe = 
			{
				Module.Tribe.Pet,
				Module.Tribe.Wand
			}
		};
	}

	public static ModuleInfo Cutter()
	{
		return new ModuleInfo
		{
			name = "CUTTER",
			desc = "Deals +2 DMG on hit if moving at [white]over 100% SPD[/g]",
			upgrade = "+2 SPD Bonus DMG",
			stats = "DMG: {DMG}",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static ModuleInfo Mixer()
	{
		return new ModuleInfo
		{
			name = "MIXER",
			desc = "Mix two inputs\ninto two outputs",
			price = 10
		};
	}

	public static ModuleInfo MixerTriple()
	{
		return new ModuleInfo
		{
			name = "3-MIXER",
			desc = "Mix three inputs\ninto three outputs",
			price = 15
		};
	}

	public static ModuleInfo MergeTriple()
	{
		return new ModuleInfo
		{
			name = "3-MERGE",
			desc = "Merge three inputs\ninto one output",
			price = 8
		};
	}

	public static ModuleInfo SplitTriple()
	{
		return new ModuleInfo
		{
			name = "3-SPLIT",
			desc = "Split one input\ninto three outputs",
			price = 8
		};
	}

	public static ModuleInfo Laser()
	{
		return new ModuleInfo
		{
			name = "LASER",
			desc = "Long range Weapon",
			upgrade = "+1 Input",
			stats = "DMG: {DMG}",
			price = 20,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Magnetizer()
	{
		return new ModuleInfo
		{
			name = "MAGNETIZER",
			desc = "Gains DMG equal to\nadjacent Mechs'\ntotal DMG",
			upgrade = "+1 Input",
			stats = "DMG: {DMG}",
			price = 10,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static ModuleInfo Channel()
	{
		return new ModuleInfo
		{
			name = "CHANNELLER",
			desc = "Fire a [white]magic wave[/g] every [white]3 seconds[/g]\n+1 DMG per [blue]MP/s[/g]\non attached Wands",
			upgrade = "+50% SPD",
			stats = "DMG: {DMG}",
			price = 15
		};
	}

	public static ModuleInfo Phial()
	{
		return new ModuleInfo
		{
			name = "PHIAL",
			desc = "Adjacent Wands get [blue]+0.5 MP[/g] on [blue]cast[/g]",
			upgrade = "+0.5 MP Gained",
			price = 5
		};
	}

	public static ModuleInfo Spellbook()
	{
		return new ModuleInfo
		{
			name = "SPELLBOOK",
			desc = "{SPELL}: Cast spell of connected Wand",
			upgrade = "+1 MP/s",
			stats = "MP: {MP}",
			statsUpgrade = "MP: {MP}[g]+1[/g]",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static ModuleInfo Razor()
	{
		return new ModuleInfo
		{
			name = "RAZOR",
			desc = "Deals +1 DMG on hit if moving at [white]over 100% SPD[/g]",
			upgrade = "+2 SPD Bonus DMG",
			stats = "DMG: {DMG}",
			tribe = { Module.Tribe.Mech },
			price = 5
		};
	}

	public static ModuleInfo Discharger()
	{
		return new ModuleInfo
		{
			name = "DISCHARGER",
			desc = "{SPELL}: [white]Zap[/g] all enemies on screen[/g]",
			upgrade = "+1 DMG\n0.5s Zap Stun",
			stats = "DMG: {DMG}\nMP: {MP}",
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Wand
			},
			price = 10
		};
	}

	public static MonsterInfo GetMonsterInfo(Monster.Type type)
	{
		MonsterInfo monsterInfo = new MonsterInfo();
		switch (type)
		{
		case Monster.Type.Zombie:
			monsterInfo.damage = 2;
			monsterInfo.health = 2;
			monsterInfo.speed = 0.5f;
			monsterInfo.damageUp = 2;
			monsterInfo.healthUp = 3;
			monsterInfo.speedUp = 0.7f;
			break;
		case Monster.Type.Bat:
			monsterInfo.damage = 1;
			monsterInfo.health = 1;
			monsterInfo.speed = 1f;
			monsterInfo.damageUp = 1;
			monsterInfo.healthUp = 2;
			monsterInfo.speedUp = 1.2f;
			break;
		case Monster.Type.Grunt:
			monsterInfo.damage = 3;
			monsterInfo.health = 4;
			monsterInfo.speed = 0.6f;
			monsterInfo.damageUp = 3;
			monsterInfo.healthUp = 5;
			monsterInfo.speedUp = 0.7f;
			break;
		case Monster.Type.Soldier:
			monsterInfo.damage = 4;
			monsterInfo.health = 8;
			monsterInfo.speed = 0.7f;
			monsterInfo.damageUp = 4;
			monsterInfo.healthUp = 10;
			monsterInfo.speedUp = 0.8f;
			break;
		case Monster.Type.Wizard:
			monsterInfo.damage = 3;
			monsterInfo.health = 7;
			monsterInfo.speed = 0.5f;
			monsterInfo.damageUp = 3;
			monsterInfo.healthUp = 8;
			monsterInfo.speedUp = 0.7f;
			break;
		case Monster.Type.Skull:
			monsterInfo.damage = 4;
			monsterInfo.health = 7;
			monsterInfo.speed = 1.1f;
			monsterInfo.damageUp = 4;
			monsterInfo.healthUp = 9;
			monsterInfo.speedUp = 1.3f;
			break;
		case Monster.Type.Redbat:
			monsterInfo.damage = 2;
			monsterInfo.health = 6;
			monsterInfo.speed = 1.15f;
			monsterInfo.damageUp = 2;
			monsterInfo.healthUp = 8;
			monsterInfo.speedUp = 1.35f;
			break;
		case Monster.Type.Archer:
			monsterInfo.damage = 3;
			monsterInfo.health = 7;
			monsterInfo.speed = 0.6f;
			monsterInfo.damageUp = 3;
			monsterInfo.healthUp = 9;
			monsterInfo.speedUp = 0.7f;
			break;
		case Monster.Type.Sapper:
			monsterInfo.damage = 10;
			monsterInfo.health = 8;
			monsterInfo.speed = 0.95f;
			monsterInfo.damageUp = 10;
			monsterInfo.healthUp = 9;
			monsterInfo.speedUp = 1.1f;
			break;
		case Monster.Type.Skeleton:
			monsterInfo.damage = 3;
			monsterInfo.health = 12;
			monsterInfo.speed = 0.85f;
			monsterInfo.damageUp = 3;
			monsterInfo.healthUp = 15;
			monsterInfo.speedUp = 0.85f;
			break;
		case Monster.Type.BOSS_Saint:
			monsterInfo.damage = 1;
			monsterInfo.health = 300;
			monsterInfo.speed = 0.7f;
			monsterInfo.damageUp = 1;
			monsterInfo.healthUp = 375;
			monsterInfo.speedUp = 0.8f;
			break;
		case Monster.Type.Gold:
			monsterInfo.damage = 0;
			monsterInfo.health = 5;
			monsterInfo.speed = 0.8f;
			monsterInfo.damageUp = 0;
			monsterInfo.healthUp = 5;
			monsterInfo.speedUp = 0.85f;
			break;
		case Monster.Type.Naga:
			monsterInfo.damage = 4;
			monsterInfo.health = 20;
			monsterInfo.speed = 0.8f;
			monsterInfo.damageUp = 5;
			monsterInfo.healthUp = 25;
			monsterInfo.speedUp = 0.9f;
			break;
		case Monster.Type.Naga_Soldier:
			monsterInfo.damage = 3;
			monsterInfo.health = 20;
			monsterInfo.speed = 0.8f;
			monsterInfo.damageUp = 4;
			monsterInfo.healthUp = 25;
			monsterInfo.speedUp = 0.9f;
			break;
		case Monster.Type.Naga_Tank:
			monsterInfo.damage = 4;
			monsterInfo.health = 30;
			monsterInfo.speed = 0.8f;
			monsterInfo.damageUp = 5;
			monsterInfo.healthUp = 35;
			monsterInfo.speedUp = 0.9f;
			break;
		case Monster.Type.Jellyfish:
			monsterInfo.damage = 3;
			monsterInfo.health = 20;
			monsterInfo.speed = 0.6f;
			monsterInfo.damageUp = 4;
			monsterInfo.healthUp = 25;
			monsterInfo.speedUp = 0.75f;
			break;
		case Monster.Type.Red_Jellyfish:
			monsterInfo.damage = 4;
			monsterInfo.health = 25;
			monsterInfo.speed = 0.75f;
			monsterInfo.damageUp = 5;
			monsterInfo.healthUp = 30;
			monsterInfo.speedUp = 0.8f;
			break;
		case Monster.Type.Tadpole:
			monsterInfo.damage = 4;
			monsterInfo.health = 15;
			monsterInfo.speed = 0.85f;
			monsterInfo.damageUp = 5;
			monsterInfo.healthUp = 20;
			monsterInfo.speedUp = 1f;
			break;
		case Monster.Type.Submarine:
			monsterInfo.damage = 5;
			monsterInfo.health = 23;
			monsterInfo.speed = 0.85f;
			monsterInfo.damageUp = 6;
			monsterInfo.healthUp = 28;
			monsterInfo.speedUp = 0.9f;
			break;
		case Monster.Type.Snake:
			monsterInfo.damage = 4;
			monsterInfo.health = 20;
			monsterInfo.speed = 0.85f;
			monsterInfo.damageUp = 5;
			monsterInfo.healthUp = 25;
			monsterInfo.speedUp = 0.95f;
			break;
		case Monster.Type.Fishbones:
			monsterInfo.damage = 5;
			monsterInfo.health = 20;
			monsterInfo.speed = 1f;
			monsterInfo.damageUp = 5;
			monsterInfo.healthUp = 25;
			monsterInfo.speedUp = 1.2f;
			break;
		case Monster.Type.Bubble:
			monsterInfo.damage = 3;
			monsterInfo.health = 20;
			monsterInfo.speed = 1.6f;
			monsterInfo.damageUp = 3;
			monsterInfo.healthUp = 20;
			monsterInfo.speedUp = 1.6f;
			break;
		case Monster.Type.BOSS_Squid:
			monsterInfo.damage = 1;
			monsterInfo.health = 600;
			monsterInfo.speed = 0.7f;
			monsterInfo.damageUp = 2;
			monsterInfo.healthUp = 750;
			monsterInfo.speedUp = 0.8f;
			break;
		case Monster.Type.Gold_Naga:
			monsterInfo.damage = 0;
			monsterInfo.health = 10;
			monsterInfo.speed = 1.25f;
			monsterInfo.damageUp = 0;
			monsterInfo.healthUp = 10;
			monsterInfo.speedUp = 1.4f;
			break;
		case Monster.Type.Rocket:
			monsterInfo.damage = 3;
			monsterInfo.health = 25;
			monsterInfo.speed = 0.75f;
			monsterInfo.damageUp = 3;
			monsterInfo.healthUp = 35;
			monsterInfo.speedUp = 0.85f;
			break;
		case Monster.Type.Rocket_Soldier:
			monsterInfo.damage = 4;
			monsterInfo.health = 30;
			monsterInfo.speed = 0.85f;
			monsterInfo.damageUp = 4;
			monsterInfo.healthUp = 40;
			monsterInfo.speedUp = 0.95f;
			break;
		case Monster.Type.UFO:
			monsterInfo.damage = 4;
			monsterInfo.health = 30;
			monsterInfo.speed = 0.85f;
			monsterInfo.damageUp = 4;
			monsterInfo.healthUp = 40;
			monsterInfo.speedUp = 0.95f;
			break;
		case Monster.Type.UFO_Soldier:
			monsterInfo.damage = 5;
			monsterInfo.health = 40;
			monsterInfo.speed = 0.85f;
			monsterInfo.damageUp = 5;
			monsterInfo.healthUp = 50;
			monsterInfo.speedUp = 0.95f;
			break;
		case Monster.Type.Bot:
			monsterInfo.damage = 3;
			monsterInfo.health = 25;
			monsterInfo.speed = 1f;
			monsterInfo.damageUp = 3;
			monsterInfo.healthUp = 35;
			monsterInfo.speedUp = 1.2f;
			break;
		case Monster.Type.Deathbot:
			monsterInfo.damage = 4;
			monsterInfo.health = 35;
			monsterInfo.speed = 0.6f;
			monsterInfo.damageUp = 4;
			monsterInfo.healthUp = 45;
			monsterInfo.speedUp = 0.75f;
			break;
		case Monster.Type.Drill:
			monsterInfo.damage = 2;
			monsterInfo.health = 40;
			monsterInfo.speed = 1.35f;
			monsterInfo.damageUp = 3;
			monsterInfo.healthUp = 50;
			monsterInfo.speedUp = 1.8f;
			break;
		case Monster.Type.Asteroid_L:
			monsterInfo.damage = 15;
			monsterInfo.health = 40;
			monsterInfo.speed = 0.75f;
			monsterInfo.damageUp = 15;
			monsterInfo.healthUp = 50;
			monsterInfo.speedUp = 0.85f;
			break;
		case Monster.Type.Asteroid_M0:
		case Monster.Type.Asteroid_M1:
			monsterInfo.damage = 10;
			monsterInfo.health = 30;
			monsterInfo.speed = 0.8f;
			monsterInfo.damageUp = 10;
			monsterInfo.healthUp = 40;
			monsterInfo.speedUp = 0.9f;
			break;
		case Monster.Type.Asteroid_S:
			monsterInfo.damage = 5;
			monsterInfo.health = 20;
			monsterInfo.speed = 0.9f;
			monsterInfo.damageUp = 5;
			monsterInfo.healthUp = 25;
			monsterInfo.speedUp = 1f;
			break;
		case Monster.Type.BOSS_Mothership:
			monsterInfo.damage = 8;
			monsterInfo.health = 1500;
			monsterInfo.speed = 0.6f;
			monsterInfo.damageUp = 8;
			monsterInfo.healthUp = 2000;
			monsterInfo.speedUp = 0.7f;
			break;
		case Monster.Type.Gold_UFO:
			monsterInfo.damage = 0;
			monsterInfo.health = 20;
			monsterInfo.speed = 1.65f;
			monsterInfo.damageUp = 2;
			monsterInfo.healthUp = 20;
			monsterInfo.speedUp = 1.85f;
			break;
		case Monster.Type.Charger:
			monsterInfo.damage = 8;
			monsterInfo.health = 400;
			monsterInfo.speed = 1f;
			monsterInfo.damageUp = 9;
			monsterInfo.healthUp = 600;
			monsterInfo.speedUp = 1.2f;
			break;
		}
		return monsterInfo;
	}
}
