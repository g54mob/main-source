using UnityEngine;

public class DatabaseJP : MonoBehaviour
{
	public static Database.ModuleInfo GetModData(Module m)
	{
		return GetModData(m.name);
	}

	public static Database.ModuleInfo GetModData(Module.Name m)
	{
		Database.ModuleInfo moduleInfo = new Database.ModuleInfo();
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

	public static Database.ModuleInfo Horizontal()
	{
		return new Database.ModuleInfo
		{
			name = "横",
			desc = "武器を左右に動かす",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			upgrade = "+10% AMP/SPD",
			statsUpgrade = "AMP: {AMP}[g]+10%[/g]\nSPD: {SPD}[g]+10%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Vertical()
	{
		return new Database.ModuleInfo
		{
			name = "縦",
			desc = "武器を上下に動かす",
			upgrade = "+10% AMP/SPD",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "AMP: {AMP}[g]+10%[/g]\nSPD: {SPD}[g]+10%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Circle()
	{
		return new Database.ModuleInfo
		{
			name = "丸",
			desc = "武器を丸に動かす",
			upgrade = "+20% SPD",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "AMP: {AMP}\nSPD: {SPD}[g]+20%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Square()
	{
		return new Database.ModuleInfo
		{
			name = "四角",
			desc = "武器を四角に動かす",
			upgrade = "+20% SPD",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "AMP: {AMP}\nSPD: {SPD}[g]+20%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Scaler()
	{
		return new Database.ModuleInfo
		{
			name = "スケーラー",
			desc = "武器は大きくと小さく成る",
			upgrade = "+50% 大小",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			price = 5
		};
	}

	public static Database.ModuleInfo Spiral()
	{
		return new Database.ModuleInfo
		{
			name = "螺旋",
			desc = "武器を螺旋に動かす",
			upgrade = "+20% AMP",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "AMP: {AMP}[g]+20%[/g]\nSPD: {SPD}",
			price = 3
		};
	}

	public static Database.ModuleInfo Sword()
	{
		return new Database.ModuleInfo
		{
			name = "剣",
			desc = "基本的な武器",
			upgrade = "+1 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static Database.ModuleInfo Turbo()
	{
		return new Database.ModuleInfo
		{
			name = "ターボボット",
			desc = "隣モジュール\n+30% SPD",
			upgrade = "+1 DMG\n+15% SPD バフ",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static Database.ModuleInfo Snowball()
	{
		return new Database.ModuleInfo
		{
			name = "雪玉",
			desc = "キルに: +1 DMG と +20% 大小[white]1秒[/g]",
			upgrade = "+1 DMG\n+1s 効果時間",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 15
		};
	}

	public static Database.ModuleInfo Shiv()
	{
		return new Database.ModuleInfo
		{
			name = "ナイフ",
			desc = "キルに:\n[white]50% チャンス[/g]に\n[green]1 HP ヒール[/g]",
			upgrade = "+1 DMG, +1 ヒール",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static Database.ModuleInfo Axe()
	{
		return new Database.ModuleInfo
		{
			name = "斧",
			desc = "ヒットにスプラッシュダメージする",
			upgrade = "+1 DMG\n大きめスプラッシュ",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static Database.ModuleInfo Boost()
	{
		return new Database.ModuleInfo
		{
			name = "ダンベル",
			desc = "隣アイテム +1 DMG",
			upgrade = "+1 DMG",
			price = 5
		};
	}

	public static Database.ModuleInfo Accelerator()
	{
		return new Database.ModuleInfo
		{
			name = "砂時計",
			desc = "隣モジュール\n+30% SPD",
			upgrade = "+15% SPD",
			price = 5
		};
	}

	public static Database.ModuleInfo Decelerator()
	{
		return new Database.ModuleInfo
		{
			name = "重量",
			desc = "[white]上[/w]の武器 +2 DMG\n全インプット -50% SPD",
			upgrade = "+1 DMG, -20% SPD",
			price = 10
		};
	}

	public static Database.ModuleInfo Amplifier()
	{
		return new Database.ModuleInfo
		{
			name = "物差し",
			desc = "隣モジュール\n+30% AMP",
			upgrade = "+15% AMP バフ",
			price = 5
		};
	}

	public static Database.ModuleInfo Earth()
	{
		return new Database.ModuleInfo
		{
			name = "地の宝石",
			desc = "アイテム +2 DMG",
			upgrade = "ノックバックを付ける",
			price = 10
		};
	}

	public static Database.ModuleInfo Fire()
	{
		return new Database.ModuleInfo
		{
			name = "火の宝石",
			desc = "武器に火尾を付ける",
			upgrade = "+1 DMG\nもっと長い尾",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static Database.ModuleInfo Toxic()
	{
		return new Database.ModuleInfo
		{
			name = "毒素",
			desc = "ヒットにエリアを毒害する",
			upgrade = "余分な効果時間",
			stats = "DMG: {DMG}\nCD: {CD}",
			price = 10
		};
	}

	public static Database.ModuleInfo Fish()
	{
		return new Database.ModuleInfo
		{
			name = "魚",
			desc = "隣ペット当たり\n+2 DMG",
			upgrade = "隣ペット当たり +30% SPD",
			stats = "DMG: {DMG}",
			tribe = { Module.Tribe.Pet },
			price = 5
		};
	}

	public static Database.ModuleInfo Wolf()
	{
		return new Database.ModuleInfo
		{
			name = "一匹狼",
			desc = "隣アイテムがないスロット当たり +3 DMG",
			upgrade = "スロット当たり +3 DMG",
			stats = "DMG: {DMG}",
			tribe = { Module.Tribe.Pet },
			price = 15
		};
	}

	public static Database.ModuleInfo Longsword()
	{
		return new Database.ModuleInfo
		{
			name = "ロングソード",
			desc = "基本的な武器",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 5
		};
	}

	public static Database.ModuleInfo Blood()
	{
		return new Database.ModuleInfo
		{
			name = "血の刃",
			desc = "[white]40 キル[/g]ごとに+1 DMG",
			upgrade = "ダブルキルバフ",
			stats = "DMG: {DMG}\nKILLS: {COUNT}",
			price = 15
		};
	}

	public static Database.ModuleInfo Explosive()
	{
		return new Database.ModuleInfo
		{
			name = "爆薬",
			desc = "手動支配する爆発",
			upgrade = "+20% 大小\n-0.5s CD",
			stats = "DMG: {DMG}\nCD: {CD}",
			price = 10
		};
	}

	public static Database.ModuleInfo Bow()
	{
		return new Database.ModuleInfo
		{
			name = "弓",
			desc = "距離の武器",
			upgrade = "ラピッドファイア",
			stats = "DMG: {DMG}",
			price = 10
		};
	}

	public static Database.ModuleInfo Diagonal()
	{
		return new Database.ModuleInfo
		{
			name = "対角",
			desc = "武器を対角の形に動かす",
			stats = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}",
			upgrade = "+10% AMP/SPD",
			statsUpgrade = "ANG: {ANG}\nAMP: {AMP}[g]+10%[/g]\nSPD: {SPD}[g]+10%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Quarter()
	{
		return new Database.ModuleInfo
		{
			name = "四半",
			desc = "武器を四半丸に動かす",
			upgrade = "+15% SPD\n半分の丸に動かす",
			stats = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}[g]+15%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Triangle()
	{
		return new Database.ModuleInfo
		{
			name = "三角",
			desc = "武器を三角に動かす",
			upgrade = "+20% SPD",
			stats = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}[g]+20%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Star()
	{
		return new Database.ModuleInfo
		{
			name = "星",
			desc = "武器を星形に動かす",
			upgrade = "+1 星ポイント\n+15% SPD",
			stats = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}",
			statsUpgrade = "ANG: {ANG}\nAMP: {AMP}\nSPD: {SPD}[g]+15%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Meds()
	{
		return new Database.ModuleInfo
		{
			name = "メディキット",
			desc = "[white]キルに[/g]武器は\n[white]40% チャンス[/g]に\n[green]1 HP[/g] ヒールする",
			upgrade = "キルに +1 ヒール",
			price = 10
		};
	}

	public static Database.ModuleInfo Wave()
	{
		return new Database.ModuleInfo
		{
			name = "波",
			desc = "武器を波形に動かす",
			stats = "AMP: {AMP}\nSPD: {SPD}",
			upgrade = "+10% AMP/SPD",
			statsUpgrade = "AMP: {AMP}[g]+10%[/g]\nSPD: {SPD}[g]+10%[/g]",
			price = 3
		};
	}

	public static Database.ModuleInfo Field()
	{
		return new Database.ModuleInfo
		{
			name = "力場",
			desc = "[red]被 DMG [/g]に:近い敵をザップする[white]動かさない[/g]",
			upgrade = "+1 DMG\n定期のザップ",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Drone()
	{
		return new Database.ModuleInfo
		{
			name = "ドローン",
			desc = "ロケットを発射する\n[white]オートムーブ[/g]",
			upgrade = "+30% ATK SPD\n+30% エリア",
			stats = "DMG: {DMG}",
			price = 15,
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Pet
			}
		};
	}

	public static Database.ModuleInfo Spear()
	{
		return new Database.ModuleInfo
		{
			name = "槍",
			desc = "推力の武器",
			upgrade = "範囲アップ\n+1 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static Database.ModuleInfo Shuriken()
	{
		return new Database.ModuleInfo
		{
			name = "手裏剣",
			desc = "三倍の弾数",
			upgrade = "+1 弾数",
			stats = "DMG: {DMG}\nANG: {ANG}",
			price = 10
		};
	}

	public static Database.ModuleInfo Flame()
	{
		return new Database.ModuleInfo
		{
			name = "火炎放射器",
			desc = "短距離火",
			upgrade = "範囲アップ\n+1 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 15,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Grimoire()
	{
		return new Database.ModuleInfo
		{
			name = "魔道書",
			desc = "[white]ウェーブスタート[/g]:\n邪鬼ペットを生み出す",
			upgrade = "邪鬼 +2 DMG\n邪鬼+ 生み出す",
			price = 15
		};
	}

	public static Database.ModuleInfo Magnet()
	{
		return new Database.ModuleInfo
		{
			name = "マグネット",
			desc = "武器を近い敵に引っ張る",
			upgrade = "敵を武器に引っ張る",
			price = 20
		};
	}

	public static Database.ModuleInfo Imp()
	{
		return new Database.ModuleInfo
		{
			name = "邪鬼",
			desc = "敵を無作為に撃つ",
			upgrade = "+1 DMG\n+25% ATK SPD",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 2,
			tribe = { Module.Tribe.Pet }
		};
	}

	public static Database.ModuleInfo Demon()
	{
		return new Database.ModuleInfo
		{
			name = "魔",
			desc = "火玉の波浪を撃つ",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 15,
			tribe = { Module.Tribe.Pet }
		};
	}

	public static Database.ModuleInfo Mace()
	{
		return new Database.ModuleInfo
		{
			name = "メイス",
			desc = "ヒットにノックバックする",
			upgrade = "+1 DMG\n25% ヒットにスタンする",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static Database.ModuleInfo Wind()
	{
		return new Database.ModuleInfo
		{
			name = "風の宝石",
			desc = "ヒットに武器を[white] 30% チャンス[/g]に[white]ザップ[/g]する",
			upgrade = "+1 DMG\n余分なバウンド",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static Database.ModuleInfo Capacitor()
	{
		return new Database.ModuleInfo
		{
			name = "キャパシタ",
			desc = "[white]2秒ごとに[/g]武器\nは爆発する\nネットワーク中のメック当たり +1 DMG",
			upgrade = "メック当たり +1 DMG",
			stats = "DMG: {DMG}",
			price = 10,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Inductor()
	{
		return new Database.ModuleInfo
		{
			name = "インダクタ",
			desc = "ヒットに隣武器\nを[white]ザップ[/g]する\nネットワーク中のメック当たり +1 DMG 得る",
			upgrade = "メック当たり\u3000+1 DMG",
			stats = "DMG: {DMG}",
			price = 15,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Dynamite()
	{
		return new Database.ModuleInfo
		{
			name = "ダイナマイト",
			desc = "キルに武器を爆発する",
			upgrade = "25% ヒットに爆発する",
			stats = "DMG: {DMG}",
			price = 5
		};
	}

	public static Database.ModuleInfo Fang()
	{
		return new Database.ModuleInfo
		{
			name = "ヴァンプの牙",
			desc = "[white]ヒットに[/g]武器を\n[white] 10% チャンス[/g]に\n1 HP ヒールする",
			upgrade = "+1 ヒーリング",
			price = 15
		};
	}

	public static Database.ModuleInfo Maelstrom()
	{
		return new Database.ModuleInfo
		{
			name = "渦中",
			desc = "ヒットに[white] 50% チャンス[/g]に[white]ザップ[/g]する",
			upgrade = "+2 DMG\n100% ザップ チャンス",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 20
		};
	}

	public static Database.ModuleInfo Scythe()
	{
		return new Database.ModuleInfo
		{
			name = "大鎌",
			desc = "キルに:\n味方ゴーストを呼ぶ",
			upgrade = "+1 ゴースト",
			stats = "DMG: {DMG}",
			price = 15
		};
	}

	public static Database.ModuleInfo Merger()
	{
		return new Database.ModuleInfo
		{
			name = "併合",
			desc = "インプット二つをアウトプット一つに併合する",
			price = 5
		};
	}

	public static Database.ModuleInfo Splitter()
	{
		return new Database.ModuleInfo
		{
			name = "スプリッター",
			desc = "インプット一つをアウトプット二つに分裂する",
			price = 5
		};
	}

	public static Database.ModuleInfo Recycler()
	{
		return new Database.ModuleInfo
		{
			name = "リサイクラー",
			desc = "[white]ショップリセット[/g]に:[white]ウェーブエンド[/g]まで武器 +2 DMG",
			upgrade = "-$1 リセット価格",
			stats = "DMG: {DMG}",
			price = 10
		};
	}

	public static Database.ModuleInfo Egg()
	{
		return new Database.ModuleInfo
		{
			name = "卵",
			desc = "キルに:\n鳥ペットになる",
			upgrade = "+1 DMG\n鳥+ 生み出す",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5,
			tribe = { Module.Tribe.Pet }
		};
	}

	public static Database.ModuleInfo Bird()
	{
		return new Database.ModuleInfo
		{
			name = "鳥",
			desc = "[white]40 キル[/g]ごとに[white]卵[/g]を生み出す",
			stats = "DMG: {DMG}\nKILLS: {COUNT}",
			upgrade = "+3 DMG\n+15% SPD",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]\nKILLS: {COUNT}",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static Database.ModuleInfo Cross()
	{
		return new Database.ModuleInfo
		{
			name = "十字",
			desc = "ヒールするとき光線を撃つ",
			upgrade = "+1 DMG\n+1 ヒーリング HP",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static Database.ModuleInfo Gold()
	{
		return new Database.ModuleInfo
		{
			name = "金棒",
			desc = "キルに[white]15% チャンス[/g]に +$1",
			upgrade = "+1 DMG, +10% チャンス",
			stats = "DMG: {DMG}",
			price = 10
		};
	}

	public static Database.ModuleInfo Bandage()
	{
		return new Database.ModuleInfo
		{
			name = "包帯",
			desc = "キルに隣武器は\n[white]25% チャンス[/g]に\n[green]1 HP[/g] ヒールする",
			upgrade = "キルに +1 ヒールする",
			price = 15
		};
	}

	public static Database.ModuleInfo Point()
	{
		return new Database.ModuleInfo
		{
			name = "地点",
			desc = "武器を固定地点に動かす",
			upgrade = "+1 DMG 上がる",
			price = 3,
			stats = "ANG: {ANG}\nAMP: {AMP}"
		};
	}

	public static Database.ModuleInfo Piggy()
	{
		return new Database.ModuleInfo
		{
			name = "貯金箱",
			desc = "[white]ウェーブエンド[/g]:\nネットワーク中のアイテム当たり +$1 得る",
			upgrade = "アイテム当たり +$1",
			stats = "COUNT: {COUNT}",
			price = 15
		};
	}

	public static Database.ModuleInfo Treat()
	{
		return new Database.ModuleInfo
		{
			name = "おやつ",
			desc = "[white]この並びの[/g]\nペット +30% SPD",
			upgrade = "+2 DMG",
			price = 10
		};
	}

	public static Database.ModuleInfo Juice()
	{
		return new Database.ModuleInfo
		{
			name = "ジュース",
			desc = "この[white]下[/g]のペット[/g] +3 DMG",
			upgrade = "+50% SPD",
			price = 10
		};
	}

	public static Database.ModuleInfo Brass()
	{
		return new Database.ModuleInfo
		{
			name = "真鍮足",
			desc = "隣ペット +1 DMG と [white]20% チャンス[/g]に[white]スタン[/g]する",
			upgrade = "+2 DMG, +10% スタン",
			price = 15
		};
	}

	public static Database.ModuleInfo Dogwhistle()
	{
		return new Database.ModuleInfo
		{
			name = "犬笛",
			desc = "[white]この並びの[/g]ペットは接続[red]武器[/g]の DMG 増加",
			upgrade = "全ペット影響する",
			price = 20
		};
	}

	public static Database.ModuleInfo Biochamber()
	{
		return new Database.ModuleInfo
		{
			name = "バイオチャンバー",
			desc = "[white]ウェーブスタート:[/g]\nこの[white]右[/g]ペットの[white]クローン[/g]になる",
			upgrade = "クローン+10 DMG, +50% SPD",
			price = 20
		};
	}

	public static Database.ModuleInfo Armor()
	{
		return new Database.ModuleInfo
		{
			name = "鎧",
			desc = "ネットワーク中アイテム当たり [green]+5 マックス HP[/green]",
			upgrade = "アイテム当たり +5 HP",
			stats = "COUNT: {COUNT}",
			price = 5
		};
	}

	public static Database.ModuleInfo Butterfly()
	{
		return new Database.ModuleInfo
		{
			name = "蝶",
			desc = "毎 [white]1秒[/g]に [green]1 HP[/green] ヒールする",
			upgrade = "+1 DMG\n+2 ヒーリング",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static Database.ModuleInfo Puppy()
	{
		return new Database.ModuleInfo
		{
			name = "子犬",
			desc = "[white]左[/w]の武器についていく",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static Database.ModuleInfo Rock()
	{
		return new Database.ModuleInfo
		{
			name = "石ペット",
			desc = "ヒットに:\n[white]30% チャンス[/g]に[white]砂利[/g]をはねかす",
			upgrade = "+1 DMG\n+30% チャンス",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Pet },
			price = 5
		};
	}

	public static Database.ModuleInfo Beehive()
	{
		return new Database.ModuleInfo
		{
			name = "蜂の巣",
			desc = "毎[white]0.5秒[/g]に蜂を生み出す\n[white]20 キル[/g]ごとに:\n[g]蜂蜜[/g]作る",
			upgrade = "+50% SPD\n蜂蜜作る+",
			stats = "DMG: {DMG}\nKILLS: {COUNT}",
			tribe = { Module.Tribe.Pet },
			price = 15
		};
	}

	public static Database.ModuleInfo Honey()
	{
		return new Database.ModuleInfo
		{
			name = "蜂蜜",
			desc = "[g]高価[/g]な[white]売り[/g]物",
			upgrade = "+100% 価格",
			price = 20
		};
	}

	public static Database.ModuleInfo Silicon()
	{
		return new Database.ModuleInfo
		{
			name = "シリコン",
			desc = "接続[white]インプット[/g]当たり\n+1 DMG",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = { Module.Tribe.Mech },
			price = 15
		};
	}

	public static Database.ModuleInfo Robot()
	{
		return new Database.ModuleInfo
		{
			name = "虫ロボット",
			desc = "近い敵に[red]光線[/g]撃つ\n[white]オートムーブ[/g]",
			upgrade = "+2 DMG, +範囲",
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

	public static Database.ModuleInfo Electrodes()
	{
		return new Database.ModuleInfo
		{
			name = "電極",
			desc = "[white]ネットワーク中[/g]全武器の間に[red]電場[/g]を作る",
			upgrade = "+2 DMG, +15% スタン",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = { Module.Tribe.Mech },
			price = 15
		};
	}

	public static Database.ModuleInfo Coolant()
	{
		return new Database.ModuleInfo
		{
			name = "冷却水",
			desc = "ヒットに隣メックは2秒にスローする",
			upgrade = "全スローを磨く",
			price = 10
		};
	}

	public static Database.ModuleInfo Redchip()
	{
		return new Database.ModuleInfo
		{
			name = "赤いチップ",
			desc = "メック当たりネットワーク中のメック +1 DMG",
			upgrade = "ネットワーク +1 DMG",
			stats = "COUNT: {COUNT}",
			tribe = { Module.Tribe.Mech },
			price = 15
		};
	}

	public static Database.ModuleInfo Microchip()
	{
		return new Database.ModuleInfo
		{
			name = "マイクロチップ",
			desc = "武器をメックの数に入れるし +1 DMG ある",
			upgrade = "ネットワーク +1 DMG",
			tribe = { Module.Tribe.Mech },
			price = 5
		};
	}

	public static Database.ModuleInfo Collar()
	{
		return new Database.ModuleInfo
		{
			name = "スパークプラグ",
			desc = "[white]キルに[/g]隣ペットはエリアを[white]ザップ[/g]する",
			upgrade = "+2 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 10,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Doghouse()
	{
		return new Database.ModuleInfo
		{
			name = "犬小屋",
			desc = "ペット当たりこの[white]右[/w]のペット +1 DMG と +40% SPD",
			upgrade = "+3 DMG, +15% SPD",
			price = 15
		};
	}

	public static Database.ModuleInfo Penguin()
	{
		return new Database.ModuleInfo
		{
			name = "ペンギン",
			desc = "敵に滑る\nヒットに2秒スローする",
			upgrade = "+2 DMG\n氷爆発",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static Database.ModuleInfo Glass()
	{
		return new Database.ModuleInfo
		{
			name = "グラス",
			desc = "[white]30 ヒット[/g]あと:\n[white]ウェーブエンド[/g]まで割れる",
			stats = "DMG: {DMG}\nHITS: {COUNT}",
			upgrade = "+2 DMG\n+20 マックスヒット",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]\nHITS: {COUNT}",
			price = 10
		};
	}

	public static Database.ModuleInfo Crown()
	{
		return new Database.ModuleInfo
		{
			name = "王冠",
			desc = "この [white]下[/w] のアイテム\n+1 DMG",
			upgrade = "+1 DMG",
			price = 10
		};
	}

	public static Database.ModuleInfo Bolt()
	{
		return new Database.ModuleInfo
		{
			name = "ボルト",
			desc = "{SPELL}: ランドムの敵に撃つ\n[white]動かさない[/g]",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +1 MP/s",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}[g]+1[/g]",
			price = 10,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo ManaPot()
	{
		return new Database.ModuleInfo
		{
			name = "マナポット",
			desc = "ワンド +1 MP/s",
			upgrade = "+1 MP/s",
			price = 5
		};
	}

	public static Database.ModuleInfo Soulrod()
	{
		return new Database.ModuleInfo
		{
			name = "霊魂棒",
			desc = "[white]キルに[/g]ワンドは[white] 10% チャンス[/g]に[blue]撃つ[/g]",
			upgrade = "+10% チャンス",
			price = 10
		};
	}

	public static Database.ModuleInfo Sonic()
	{
		return new Database.ModuleInfo
		{
			name = "ソニックウェーブ",
			desc = "ワンドは[white]ソニックウェーブ[/g]を[blue]撃つ[/g]",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]",
			upgrade = "+3 DMG",
			price = 15
		};
	}

	public static Database.ModuleInfo Lifestaff()
	{
		return new Database.ModuleInfo
		{
			name = "生命杖",
			desc = "{SPELL}: 3 HP ヒールする",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +3 ヒール",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			tribe = { Module.Tribe.Wand },
			price = 15
		};
	}

	public static Database.ModuleInfo Curse()
	{
		return new Database.ModuleInfo
		{
			name = "呪いルーン",
			desc = "ワンド +2 DMG と\n[red]+1 MP 価格[/g]",
			upgrade = "+2 DMG, -2 MP/s",
			price = 15
		};
	}

	public static Database.ModuleInfo Storm()
	{
		return new Database.ModuleInfo
		{
			name = "嵐棒",
			desc = "{SPELL}: 次のヒットに近い敵をザップする",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+2 MP/s",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+2[/g]",
			price = 15,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo Frost()
	{
		return new Database.ModuleInfo
		{
			name = "フロストオーブ",
			desc = "ヒットに[white]1秒[/g]にスローする\n{SPELL}: 全スロー敵に [red]3[/g] DMG 与える",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 MP/s, +1s スロー",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+1[/g]",
			price = 20,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo Clown()
	{
		return new Database.ModuleInfo
		{
			name = "ピエロ棒",
			desc = "{SPELL}: 跳ねるボールを6個作る",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			upgrade = "+1 DMG, +3 ボール",
			price = 10,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo Globe()
	{
		return new Database.ModuleInfo
		{
			name = "スノーグローブ",
			desc = "{SPELL}: 隣アイテム[white]1秒[/g]に +2 DMG",
			stats = "MP: {MP}",
			upgrade = "+1s 効果時間",
			price = 10,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo Soulripper()
	{
		return new Database.ModuleInfo
		{
			name = "霊魂リッパ―",
			desc = "キルに:\n隣ワンド [blue]+2 MP[/g]",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]",
			upgrade = "+3 DMG, +2 MP 利得",
			price = 15
		};
	}

	public static Database.ModuleInfo Alchemy()
	{
		return new Database.ModuleInfo
		{
			name = "アルケミー",
			desc = "隣ワンド +1 MP/s",
			upgrade = "+2 MP/s",
			price = 15
		};
	}

	public static Database.ModuleInfo FlameBall()
	{
		return new Database.ModuleInfo
		{
			name = "炎",
			desc = "ほかの[blue]ワンド[/g]が撃つとき [blue]+1 MP[/g]\n{SPELL}: 大きいボルトを発射する",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+5[/g]\nMP: {MP}",
			upgrade = "+5 DMG",
			price = 15,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo Mageblade()
	{
		return new Database.ModuleInfo
		{
			name = "メイジの刃",
			desc = "{SPELL}: [white]1秒[/g]に +2 DMG",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]\nMP: {MP}",
			upgrade = "+2 DMG, +2 MP DMG",
			price = 15,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo Necromancy()
	{
		return new Database.ModuleInfo
		{
			name = "ネクロマンシー",
			desc = "{SPELL}: 味方[green]骸骨[/g]を呼ぶ\n[white]動かさない[/g]",
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

	public static Database.ModuleInfo Swipe()
	{
		return new Database.ModuleInfo
		{
			name = "熊爪",
			desc = "{SPELL}: 次のヒットをスワイプして与 [red]2x DMG[/g]\nこの並びのペット当たり +1 MP/s",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			upgrade = "+1 DMG, ノックバック",
			price = 15,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo Battery()
	{
		return new Database.ModuleInfo
		{
			name = "電池",
			desc = "{SPELL}: ネットワーク中のメックはエリア\n[white]ザップ[/g]する\nメック当たり +1 DMG",
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

	public static Database.ModuleInfo Matchstick()
	{
		return new Database.ModuleInfo
		{
			name = "マッチ棒",
			desc = "{SPELL}: [white]火玉[/g]輪を武器に繋ぐ",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 火玉",
			price = 10,
			tribe = { Module.Tribe.Wand }
		};
	}

	public static Database.ModuleInfo Fairy()
	{
		return new Database.ModuleInfo
		{
			name = "妖精",
			desc = "敵を回る\n{SPELL}: エリアを爆発する\n1秒にスタンする",
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

	public static Database.ModuleInfo Raccoon()
	{
		return new Database.ModuleInfo
		{
			name = "ゴミイーター",
			desc = "武器を[white]売る[/g]とき[red]永久に[/g] +1 DMG",
			stats = "DMG: {DMG}",
			upgrade = "売り当たり +1 DMG",
			price = 10,
			tribe = { Module.Tribe.Pet }
		};
	}

	public static Database.ModuleInfo Cellphone()
	{
		return new Database.ModuleInfo
		{
			name = "携帯",
			desc = "{SPELL}: [red]ランドムの効果[/g]を起こす",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG\n効果ブースト",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			price = 10,
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Wand
			}
		};
	}

	public static Database.ModuleInfo Balloon()
	{
		return new Database.ModuleInfo
		{
			name = "風船",
			desc = "武器を持ち上がって[white]ヒットに[/g][white] 25% チャンス[/g]に爆発する",
			upgrade = "+1 DMG\n+25% チャンス",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 5
		};
	}

	public static Database.ModuleInfo Repeater()
	{
		return new Database.ModuleInfo
		{
			name = "リピーター",
			desc = "武器は効果を二回起こす",
			upgrade = "+1 余分なトリガー",
			price = 20,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Food()
	{
		return new Database.ModuleInfo
		{
			name = "食品",
			desc = "[white]ウェーブスタート[/g]:\n武器 [red]+1 恒久的な DMG[/g]\n[white]有限使い[/g]",
			upgrade = "+6 CHARGE",
			stats = "[white]CHARGE: {COUNT}[/g]",
			statsUpgrade = "[white]CHARGE: {COUNT}[g]+6[/g]",
			price = 10
		};
	}

	public static Database.ModuleInfo Water()
	{
		return new Database.ModuleInfo
		{
			name = "水差し",
			desc = "[red]爆発的な花[/g]を植える",
			stats = "DMG: {DMG}\n[white]MAX: {COUNT}[/g]",
			upgrade = "+1 DMG\n+10 マックス花",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\n[white]MAX: {COUNT}[/g][g]+10[/g]",
			price = 15
		};
	}

	public static Database.ModuleInfo Longstaff()
	{
		return new Database.ModuleInfo
		{
			name = "長い杖",
			desc = "フル HP とき +2 DMG",
			stats = "DMG: {DMG}",
			upgrade = "+1 DMG\n+1 フル HP DMG",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			price = 10
		};
	}

	public static Database.ModuleInfo Wrench()
	{
		return new Database.ModuleInfo
		{
			name = "レンチ",
			desc = "隣メック +2 DMG",
			stats = "DMG: {DMG}",
			upgrade = "+1 DMG, ランドムのメックをアップグレードする",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static Database.ModuleInfo Screwdriver()
	{
		return new Database.ModuleInfo
		{
			name = "ねじ回り",
			desc = "[white]ネットワーク[/g]中モジュール +2 DMG",
			stats = "DMG: {DMG}",
			upgrade = "モジュールを\u3000+2 DMG 上がる",
			price = 10
		};
	}

	public static Database.ModuleInfo Ice()
	{
		return new Database.ModuleInfo
		{
			name = "氷の宝石",
			desc = "ヒットに武器は1秒に\nスローする",
			upgrade = "+1s スロー",
			price = 10
		};
	}

	public static Database.ModuleInfo Pointer()
	{
		return new Database.ModuleInfo
		{
			name = "ポインタ",
			desc = "隣メックは毎1秒に撃つ",
			upgrade = "+1 DMG, +50% SPD",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static Database.ModuleInfo Blast()
	{
		return new Database.ModuleInfo
		{
			name = "ブラスター",
			desc = "{SPELL}: エリアを\n爆発する",
			upgrade = "+1 MP/s\n+爆発大きさ",
			stats = "DMG: {DMG}\nMP: {MP}",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+1[/g]",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static Database.ModuleInfo Cold()
	{
		return new Database.ModuleInfo
		{
			name = "冷気棒",
			desc = "{SPELL}: 近い敵に撃つ\n2秒[/g]にスローする",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +1s スロー",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static Database.ModuleInfo Sand()
	{
		return new Database.ModuleInfo
		{
			name = "砂棒",
			desc = "{SPELL}: 1秒に[/g][white]この並びの[/g]アイテム +50% SPD",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 DMG, +1s バフ",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]\nMP: {MP}",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static Database.ModuleInfo Firestaff()
	{
		return new Database.ModuleInfo
		{
			name = "火杖",
			desc = "{SPELL}: [white]火玉[/g]輪を\n生み出す",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+1 MP/s\n+1 火玉",
			statsUpgrade = "DMG: {DMG}\nMP: {MP}[g]+1[/g]",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static Database.ModuleInfo Bell()
	{
		return new Database.ModuleInfo
		{
			name = "鐘",
			desc = "ヒットに:\n[white]10% チャンス[/g]に[white]1秒[/g]にエリアを[white]スタン[/g]する",
			stats = "DMG: {DMG}",
			upgrade = "+1 DMG\n+5% スタン チャンス",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			price = 10
		};
	}

	public static Database.ModuleInfo Bone()
	{
		return new Database.ModuleInfo
		{
			name = "骨棍棒",
			desc = "隣ペット当たり +2 DMG",
			stats = "DMG: {DMG}",
			upgrade = "隣ペットを +2 DMG 上がる",
			statsUpgrade = "DMG: {DMG}",
			price = 10
		};
	}

	public static Database.ModuleInfo Horseshoe()
	{
		return new Database.ModuleInfo
		{
			name = "蹄鉄",
			desc = "この[white]上[/g]のペット\n+50% SPD",
			upgrade = "+2 DMG",
			price = 10
		};
	}

	public static Database.ModuleInfo Monitor()
	{
		return new Database.ModuleInfo
		{
			name = "モニター",
			desc = "光線を発射する. [white]毎1秒[/g]とヒールに起こす[white]動かさない[/g]",
			upgrade = "+2 DMG, +50% SPD",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+2[/g]",
			tribe = { Module.Tribe.Mech },
			price = 20
		};
	}

	public static Database.ModuleInfo Powermace()
	{
		return new Database.ModuleInfo
		{
			name = "パワーメイス",
			desc = "ネットワーク中のメック当たり +1 DMG",
			upgrade = "全ネットワーク中のメック\u3000+1 DMG",
			stats = "DMG: {DMG}\nCOUNT: {COUNT}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static Database.ModuleInfo USB()
	{
		return new Database.ModuleInfo
		{
			name = "USB",
			desc = "[white]ネットワーク中[/g]のメック当たり隣ワンド [blue]+0.5 MP/s[/g]",
			upgrade = "ネットワーク中のメック当たり +1 DMG",
			stats = "DMG: {DMG}\nCOUNT: {COUNT}",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static Database.ModuleInfo Rat()
	{
		return new Database.ModuleInfo
		{
			name = "鼠",
			desc = "別の鼠当たり +1 DMG",
			upgrade = "+1 DMG\nもう一匹生み出す",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+1[/g]",
			tribe = { Module.Tribe.Pet },
			price = 5
		};
	}

	public static Database.ModuleInfo Tortoise()
	{
		return new Database.ModuleInfo
		{
			name = "亀",
			desc = "-80% SPD",
			upgrade = "+4 DMG, -40% SPD",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+4[/g]",
			tribe = { Module.Tribe.Pet },
			price = 10
		};
	}

	public static Database.ModuleInfo Mirror()
	{
		return new Database.ModuleInfo
		{
			name = "鏡",
			desc = "この[white]左[/g]の武器の[white]反射[/g]を作る",
			stats = "DMG: {DMG}",
			upgrade = "+3 DMG",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]",
			price = 15
		};
	}

	public static Database.ModuleInfo Dryer()
	{
		return new Database.ModuleInfo
		{
			name = "ヘアドライヤー",
			desc = "{SPELL}: [white]ノックバック[/g]爆風を撃つ.\n[white]ネットワーク[/g]中のメック当たり [blue]+0.5 MP/s[/g]",
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

	public static Database.ModuleInfo Blade()
	{
		return new Database.ModuleInfo
		{
			name = "飛び出しナイフ",
			desc = "毎 1秒に近い敵を[white]刺す[/g]\nネットワーク中のメック当たり [white]+1 刺す[/g]",
			upgrade = "メック当たり +1 刺す",
			stats = "DMG: {DMG}\n[white]COUNT: {COUNT}[/g]",
			statsUpgrade = "DMG: {DMG}\n[white]COUNT: {COUNT}[g]x2[/g]",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static Database.ModuleInfo Anvil()
	{
		return new Database.ModuleInfo
		{
			name = "金床",
			desc = "全[white]基本的な[/g]武器 +2 DMG",
			upgrade = "全基本的な武器を\nアップグレードする",
			price = 20
		};
	}

	public static Database.ModuleInfo Vortex()
	{
		return new Database.ModuleInfo
		{
			name = "ボーテックス",
			desc = "ワンド [red]+1 MP 価格[/g]と[blue]撃つ[/g]に1秒にエリアを[white]スタン[/g]する",
			upgrade = "+5 DMG",
			stats = "DMG: {DMG}",
			statsUpgrade = "DMG: {DMG}[g]+5[/g]",
			price = 15
		};
	}

	public static Database.ModuleInfo Bluechip()
	{
		return new Database.ModuleInfo
		{
			name = "プロセッサー",
			desc = "[white]ネットワーク中[/g]にメック\u3000[mech]3[/g]つとして数える",
			upgrade = "+2 メック数",
			price = 20,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Leshy()
	{
		return new Database.ModuleInfo
		{
			name = "レシ",
			desc = "{SPELL}: 2秒に全ペット +3 DMG",
			stats = "DMG: {DMG}\nMP: {MP}",
			upgrade = "+3 DMG\n+3 バフ DMG",
			statsUpgrade = "DMG: {DMG}[g]+3[/g]\nMP: {MP}",
			price = 15,
			tribe = 
			{
				Module.Tribe.Pet,
				Module.Tribe.Wand
			}
		};
	}

	public static Database.ModuleInfo Cutter()
	{
		return new Database.ModuleInfo
		{
			name = "カッター",
			desc = "[white]100% SPD 上[/g]ときヒットに +2 DMG",
			upgrade = "+2 SPD ボーナス DMG",
			stats = "DMG: {DMG}",
			tribe = { Module.Tribe.Mech },
			price = 10
		};
	}

	public static Database.ModuleInfo Mixer()
	{
		return new Database.ModuleInfo
		{
			name = "ミキサー",
			desc = "インプット二つをアウトプット二つに混ぜる",
			price = 10
		};
	}

	public static Database.ModuleInfo MixerTriple()
	{
		return new Database.ModuleInfo
		{
			name = "3・ミキサー",
			desc = "インプット三つをアウトプット三つに混ぜる",
			price = 15
		};
	}

	public static Database.ModuleInfo MergeTriple()
	{
		return new Database.ModuleInfo
		{
			name = "3・併合",
			desc = "インプット三つをアウトプット一つに併合する",
			price = 10
		};
	}

	public static Database.ModuleInfo SplitTriple()
	{
		return new Database.ModuleInfo
		{
			name = "3・スプリット",
			desc = "インプット一つをアウトプット三つに分ける",
			price = 10
		};
	}

	public static Database.ModuleInfo Laser()
	{
		return new Database.ModuleInfo
		{
			name = "レーザー",
			desc = "長距離の武器",
			upgrade = "+1 インプット",
			stats = "DMG: {DMG}",
			price = 20,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Magnetizer()
	{
		return new Database.ModuleInfo
		{
			name = "マグネタイザー",
			desc = "隣メックの総計 DMG の等量 DMG を得る",
			upgrade = "+1 インプット",
			stats = "DMG: {DMG}",
			price = 10,
			tribe = { Module.Tribe.Mech }
		};
	}

	public static Database.ModuleInfo Channel()
	{
		return new Database.ModuleInfo
		{
			name = "チャネラー",
			desc = "毎[white]2秒[/g]に[white]魔法波浪[/g]を撃つ\n[blue]MP/s[/g] 当たり接続ワンド +1 DMG",
			upgrade = "+50% SPD",
			stats = "DMG: {DMG}",
			price = 15
		};
	}

	public static Database.ModuleInfo Phial()
	{
		return new Database.ModuleInfo
		{
			name = "瓶",
			desc = "[blue]撃つ[/g]に隣ワンド [blue]+0.5 MP[/g]",
			upgrade = "+0.5 MP Gained",
			price = 5
		};
	}

	public static Database.ModuleInfo Spellbook()
	{
		return new Database.ModuleInfo
		{
			name = "呪文の本",
			desc = "{SPELL}: ワンドの呪文をかける",
			upgrade = "+1 MP/s",
			stats = "MP: {MP}",
			statsUpgrade = "MP: {MP}[g]+1[/g]",
			tribe = { Module.Tribe.Wand },
			price = 10
		};
	}

	public static Database.ModuleInfo Razor()
	{
		return new Database.ModuleInfo
		{
			name = "剃刀",
			desc = "[white]100% SPD 上[/g]ときヒットに +1 DMG",
			upgrade = "+2 SPD ボーナス DMG",
			stats = "DMG: {DMG}",
			tribe = { Module.Tribe.Mech },
			price = 5
		};
	}

	public static Database.ModuleInfo Discharger()
	{
		return new Database.ModuleInfo
		{
			name = "放電し",
			desc = "{SPELL}: 全敵を[white]ザップ[/g]する[/g]",
			upgrade = "+1 DMG\n0.5s ザップ スタン",
			stats = "DMG: {DMG}\nMP: {MP}",
			tribe = 
			{
				Module.Tribe.Mech,
				Module.Tribe.Wand
			},
			price = 10
		};
	}
}
