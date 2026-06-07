using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
	public enum Name
	{
		Sword = 0,
		Horizontal = 1,
		Vertical = 2,
		Circle = 3,
		Axe = 4,
		Dumbbell = 5,
		Fire = 6,
		Toxic = 7,
		Longsword = 8,
		Diagonal = 9,
		Hourglass = 10,
		Ruler = 11,
		Bow = 12,
		Meds = 13,
		Wave = 14,
		Explosive = 15,
		Laser = 16,
		Spear = 17,
		Shiv = 18,
		Weight = 19,
		Blood = 20,
		Earth = 21,
		Anvil = 22,
		Snowball = 23,
		Shuriken = 24,
		Mace = 25,
		Grimoire = 26,
		Imp = 27,
		Quarter = 28,
		Dynamite = 29,
		Wind = 30,
		Maelstrom = 31,
		Merger = 32,
		Splitter = 33,
		Recycler = 34,
		Egg = 35,
		Bird = 36,
		Cross = 37,
		Bandage = 38,
		Point = 39,
		Fang = 40,
		Scythe = 41,
		Spiral = 42,
		Triangle = 43,
		Magnet = 44,
		Star = 45,
		Gold = 46,
		Capacitor = 47,
		Inductor = 48,
		Scaler = 49,
		Turbo = 50,
		Flame = 51,
		Fish = 52,
		Field = 53,
		Drone = 54,
		Magnetizer = 55,
		Piggy = 56,
		Treat = 57,
		Wolf = 58,
		Armor = 59,
		Butterfly = 60,
		Puppy = 61,
		Rock = 62,
		Beehive = 63,
		Honey = 64,
		Silicon = 65,
		Blade = 66,
		Powermace = 67,
		Microchip = 68,
		Coolant = 69,
		Cutter = 70,
		Collar = 71,
		Doghouse = 72,
		Penguin = 73,
		Glass = 74,
		Crown = 75,
		Mechatron = 76,
		Bolt = 77,
		ManaPot = 78,
		Curse = 79,
		Lifestaff = 80,
		Storm = 81,
		Frost = 82,
		Clown = 83,
		Globe = 84,
		Soulripper = 85,
		Alchemy = 86,
		FlameBall = 87,
		Mageblade = 88,
		Necromancy = 89,
		Swipe = 90,
		Fairy = 91,
		Cellphone = 92,
		Battery = 93,
		Balloon = 94,
		Repeater = 95,
		Water = 96,
		Bell = 97,
		Longstaff = 98,
		Mirror = 99,
		Square = 100,
		Wrench = 101,
		Pointer = 102,
		Ice = 103,
		Cold = 104,
		Blast = 105,
		Horseshoe = 106,
		Monitor = 107,
		Rat = 108,
		Demon = 109,
		Redchip = 110,
		Tortoise = 111,
		Sand = 112,
		Firestaff = 113,
		USB = 114,
		Matchstick = 115,
		Food = 116,
		Robot = 117,
		Electrodes = 118,
		Screwdriver = 119,
		Leshy = 120,
		Soulrod = 121,
		Sonic = 122,
		Dogwhistle = 123,
		Brass = 124,
		Juice = 125,
		Biochamber = 126,
		Bone = 127,
		Raccoon = 128,
		Dryer = 129,
		Vortex = 130,
		Bluechip = 131,
		Mixer = 132,
		MergeTriple = 133,
		SplitTriple = 134,
		MixerTriple = 135,
		Phial = 136,
		Spellbook = 137,
		Channel = 138,
		Razor = 139,
		Discharger = 140,
		_COUNT = 141
	}

	public enum Type
	{
		Weapon = 0,
		Module = 1
	}

	public enum Size
	{
		Small = 0,
		Medium = 1,
		Large = 2
	}

	public enum Tribe
	{
		None = 0,
		Pet = 1,
		Mech = 2,
		Wand = 3
	}

	public static List<Name> demoMods = new List<Name>
	{
		Name.Grimoire,
		Name.Imp,
		Name.Egg,
		Name.Bird,
		Name.Fish,
		Name.Drone,
		Name.Treat,
		Name.Puppy,
		Name.Swipe,
		Name.Fairy,
		Name.Horseshoe,
		Name.Rat,
		Name.Dogwhistle,
		Name.Juice,
		Name.Bone,
		Name.Bolt,
		Name.ManaPot,
		Name.Lifestaff,
		Name.Clown,
		Name.Globe,
		Name.Swipe,
		Name.Fairy,
		Name.Cold,
		Name.Blast,
		Name.Firestaff,
		Name.Sand,
		Name.Soulrod,
		Name.Laser,
		Name.Field,
		Name.Inductor,
		Name.Turbo,
		Name.Flame,
		Name.Drone,
		Name.Powermace,
		Name.Microchip,
		Name.Cutter,
		Name.Wrench,
		Name.USB,
		Name.Screwdriver,
		Name.Diagonal,
		Name.Horizontal,
		Name.Vertical,
		Name.Spiral,
		Name.Quarter,
		Name.Circle,
		Name.Wave,
		Name.Triangle,
		Name.Point,
		Name.Merger,
		Name.Splitter,
		Name.Sword,
		Name.Axe,
		Name.Dumbbell,
		Name.Fire,
		Name.Longsword,
		Name.Hourglass,
		Name.Meds,
		Name.Spear,
		Name.Blood,
		Name.Earth,
		Name.Snowball,
		Name.Shuriken,
		Name.Dynamite,
		Name.Wind,
		Name.Cross,
		Name.Bandage,
		Name.Mace,
		Name.Scythe,
		Name.Scaler,
		Name.Crown,
		Name.Raccoon
	};

	public static List<Name> demoMovs = new List<Name>
	{
		Name.Diagonal,
		Name.Horizontal,
		Name.Vertical,
		Name.Spiral,
		Name.Quarter,
		Name.Circle,
		Name.Wave,
		Name.Triangle,
		Name.Point
	};

	public static List<Name> demoWire = new List<Name>
	{
		Name.Merger,
		Name.Splitter
	};

	public bool shopUpped;

	public bool init;

	public float _amp = 2f;

	public float _accel = 0.1f;

	public float accelMult = 1f;

	public float ampMult = 1f;

	public int damage = 1;

	public int counter;

	public float cooldown;

	public float mana;

	public float manaRegen;

	public float manaCost;

	public bool castOnlyInCombat;

	public Vector3 scale = Vector3.one;

	public List<Aura> auras;

	private SpriteRenderer highlight;

	public GameObject weaponObj;

	public List<Module> inputs;

	public List<Module> outputs;

	public int index = -1;

	public bool shopItem;

	public bool bankItem;

	public int shopPrice;

	public bool TOKEN;

	public bool UPGRADED;

	public int repeat;

	public bool preview;

	public static List<Name> movementMods = new List<Name>
	{
		Name.Horizontal,
		Name.Vertical,
		Name.Circle,
		Name.Diagonal,
		Name.Wave,
		Name.Quarter,
		Name.Point,
		Name.Spiral,
		Name.Triangle,
		Name.Star,
		Name.Square
	};

	public static List<Name> wireMods = new List<Name>
	{
		Name.Merger,
		Name.Splitter,
		Name.Mixer,
		Name.MergeTriple,
		Name.SplitTriple,
		Name.MixerTriple
	};

	public new Name name;

	public Type type;

	public Size size;

	public List<Tribe> tribes = new List<Tribe>();

	public SpriteRenderer spriteRenderer;

	private bool bouncing;

	private Vector3 OP = Vector3.zero;

	public bool isElevated;

	private Vector3 clickPos;

	public bool dragging;

	public bool clickMoving;

	private int dragFrames = 6;

	private int dragCount;

	private Coroutine dragger;

	private Coroutine f;

	public bool ZAPPED;

	public bool SPLASH;

	public bool swapAnim;

	private Dictionary<string, int> buffAnims = new Dictionary<string, int>();

	public List<Trigger> triggers;

	private SpriteRenderer animHighlight;

	public SpriteRenderer upgradeHighlight;

	private bool hUp;

	private bool pers;

	private Coroutine UHAnim;

	private SpriteRenderer upgradePips;

	private Vector3 offset;

	private bool antiDrag;

	public bool inner;

	public bool seller;

	public bool banker;

	public bool bankButton;

	public bool sellButton;

	public float amp
	{
		get
		{
			return _amp * ampMult;
		}
		set
		{
			_amp = value;
		}
	}

	public float accel
	{
		get
		{
			return _accel * accelMult;
		}
		set
		{
			_accel = value;
		}
	}

	public Dungeon dungeon => Dungeon.Instance;

	public Weapon weapon
	{
		get
		{
			if (!dungeon.weaponMods.ContainsKey(this))
			{
				return null;
			}
			return dungeon.weaponMods[this];
		}
	}

	public Board board => Dungeon.Instance.board;

	public Bank bank => Dungeon.Instance.bank;

	public Plug[] plugs => GetComponentsInChildren<Plug>();

	public bool allConnected
	{
		get
		{
			Plug[] array = plugs;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].connected)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool PRIORITY
	{
		get
		{
			foreach (Aura aura in auras)
			{
				if (SaveManager.permanentAuras.Contains(aura.type))
				{
					return true;
				}
			}
			return false;
		}
	}

	public int sellPrice
	{
		get
		{
			if (!UPGRADED)
			{
				return (int)Mathf.Floor((float)shopPrice / 2f);
			}
			return shopPrice;
		}
	}

	public bool WEAPON => type == Type.Weapon;

	public bool MODULE => type == Type.Module;

	public bool MECH => tribes.Contains(Tribe.Mech);

	public bool WIREMOD => wireMods.Contains(name);

	public bool MOVEMOD => movementMods.Contains(name);

	public bool PET => tribes.Contains(Tribe.Pet);

	public bool WAND => tribes.Contains(Tribe.Wand);

	public void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sortingOrder = -1;
		spriteRenderer.sortingLayerName = "Widget";
		SetHighlight();
		foreach (Aura aura in auras)
		{
			aura.owner = this;
		}
		foreach (Trigger trigger in triggers)
		{
			trigger.owner = this;
		}
	}

	public virtual void InitUpgrade(bool loaded = false)
	{
		if (shopUpped)
		{
			loaded = true;
		}
		switch (name)
		{
		case Name.Sword:
		case Name.Axe:
		case Name.Fire:
		case Name.Spear:
		case Name.Shiv:
		case Name.Snowball:
		case Name.Egg:
		case Name.Flame:
		case Name.Field:
		case Name.Butterfly:
		case Name.Rock:
		case Name.Blade:
		case Name.Lifestaff:
		case Name.Clown:
		case Name.Cellphone:
		case Name.Longstaff:
		case Name.Sand:
		case Name.Discharger:
			damage++;
			break;
		case Name.Longsword:
		case Name.Puppy:
		case Name.Silicon:
		case Name.Collar:
		case Name.Penguin:
		case Name.Glass:
		case Name.Mageblade:
		case Name.Demon:
		case Name.Robot:
			damage += 2;
			break;
		case Name.Electrodes:
			damage += 2;
			AddTrigger(global::Trigger.Ability.Stun, null, 15f, 1);
			break;
		case Name.Bird:
		case Name.Soulripper:
		case Name.Mirror:
		case Name.Leshy:
		case Name.Sonic:
			damage += 3;
			break;
		case Name.FlameBall:
		case Name.Vortex:
			damage += 5;
			break;
		case Name.Tortoise:
			damage += 4;
			accelMult -= 0.4f;
			break;
		case Name.Monitor:
			damage += 2;
			accelMult += 0.5f;
			break;
		case Name.Water:
			damage++;
			counter += 10;
			break;
		case Name.Rat:
			damage++;
			if (!loaded)
			{
				board.CreateModuleSmall(Name.Rat);
			}
			break;
		case Name.Turbo:
			damage++;
			AddAura(Aura.Type.HalfAccelerator);
			break;
		case Name.Grimoire:
			AddAura(Aura.Type.Grimoire);
			break;
		case Name.Wrench:
		{
			damage++;
			List<Module> tribe = board.GetTribe(Tribe.Mech);
			List<Module> list = new List<Module>();
			foreach (Module item in tribe)
			{
				if (!(item == null) && !item.UPGRADED)
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				Module module = Utils.RandElem(list);
				if (module != null && !loaded)
				{
					board.UpgradeModule(module);
				}
			}
			break;
		}
		case Name.Bolt:
		case Name.Necromancy:
		case Name.Fairy:
		case Name.Dryer:
			damage++;
			manaRegen += 1f;
			break;
		case Name.Cold:
			damage++;
			break;
		case Name.Swipe:
			damage++;
			AddTrigger(global::Trigger.Ability.Knockback);
			break;
		case Name.Pointer:
			damage++;
			accelMult += 0.5f;
			break;
		case Name.Frost:
			manaRegen += 1f;
			GetTrigger(global::Trigger.Ability.Slow, null).value++;
			break;
		case Name.Ice:
			GetTrigger(global::Trigger.Ability.Slow, null).value++;
			break;
		case Name.Battery:
		case Name.Blast:
		case Name.Firestaff:
		case Name.Spellbook:
			manaRegen += 1f;
			break;
		case Name.Storm:
			manaRegen += 2f;
			break;
		case Name.Maelstrom:
			damage += 2;
			triggers[0].chance = 100f;
			triggers[0].damage = 2;
			break;
		case Name.Bell:
			damage++;
			break;
		case Name.Wind:
			damage++;
			triggers[0].value = 5;
			triggers[0].damage++;
			break;
		case Name.Balloon:
			damage++;
			triggers[0].chance += 25f;
			break;
		case Name.Imp:
			damage++;
			accelMult += 0.2f;
			break;
		case Name.Horizontal:
		case Name.Vertical:
		case Name.Diagonal:
		case Name.Wave:
			ampMult += 0.1f;
			accelMult += 0.1f;
			break;
		case Name.Circle:
		case Name.Triangle:
		case Name.Square:
			accelMult += 0.2f;
			break;
		case Name.Quarter:
		case Name.Star:
			accelMult += 0.15f;
			break;
		case Name.Spiral:
			ampMult += 0.2f;
			break;
		case Name.Explosive:
			scale += Vector3.one * 0.2f;
			cooldown -= 0.5f;
			break;
		case Name.Laser:
		case Name.Magnetizer:
		{
			Plug[] componentsInChildren = GetComponentsInChildren<Plug>();
			componentsInChildren[0].transform.localPosition = new Vector3(-1.375f, -1.375f, -1f);
			componentsInChildren[0].transform.localScale = Vector3.one;
			componentsInChildren[1].transform.localScale = Vector3.one;
			break;
		}
		case Name.Blood:
		{
			int num = counter / 25;
			for (int i = 0; i < num; i++)
			{
				AddAura(new Aura(Aura.Type.Damage));
			}
			break;
		}
		case Name.Ruler:
			AddAura(Aura.Type.HalfAmplifier);
			break;
		case Name.Hourglass:
			AddAura(Aura.Type.HalfAccelerator);
			break;
		case Name.Drone:
			accelMult += 0.3f;
			break;
		case Name.Recycler:
			AddAura(Aura.Type.RerollDiscount);
			if (!loaded)
			{
				dungeon.shop.restockPrice--;
			}
			break;
		case Name.Dynamite:
		{
			Trigger trigger = new Trigger(global::Trigger.Ability.Dynamite, this);
			trigger.type = global::Trigger.Type.Hit;
			trigger.chance = 25f;
			AddTrigger(trigger);
			break;
		}
		case Name.Mace:
		{
			damage++;
			Trigger t = new Trigger(global::Trigger.Ability.Stun, this, null, 25f);
			AddTrigger(t);
			break;
		}
		case Name.Cross:
			damage++;
			AddAura(Aura.Type.HealBuff);
			break;
		case Name.Coolant:
			AddAura(Aura.Type.SlowBuff);
			break;
		case Name.Gold:
			damage++;
			triggers[0].chance += 10f;
			break;
		case Name.Soulrod:
			triggers[0].chance += 10f;
			break;
		case Name.Food:
			if (!loaded || shopUpped)
			{
				counter += 6;
			}
			break;
		case Name.Dumbbell:
		case Name.Toxic:
		case Name.Bow:
		case Name.Meds:
		case Name.Weight:
		case Name.Earth:
		case Name.Anvil:
		case Name.Shuriken:
		case Name.Merger:
		case Name.Splitter:
		case Name.Bandage:
		case Name.Point:
		case Name.Fang:
		case Name.Scythe:
		case Name.Magnet:
		case Name.Capacitor:
		case Name.Inductor:
		case Name.Scaler:
		case Name.Fish:
		case Name.Piggy:
		case Name.Treat:
		case Name.Wolf:
		case Name.Armor:
		case Name.Beehive:
		case Name.Honey:
		case Name.Powermace:
		case Name.Microchip:
		case Name.Cutter:
		case Name.Doghouse:
		case Name.Crown:
		case Name.Mechatron:
		case Name.ManaPot:
		case Name.Curse:
		case Name.Globe:
		case Name.Alchemy:
		case Name.Repeater:
		case Name.Horseshoe:
		case Name.Redchip:
		case Name.USB:
		case Name.Matchstick:
		case Name.Screwdriver:
		case Name.Dogwhistle:
		case Name.Brass:
		case Name.Juice:
		case Name.Biochamber:
		case Name.Bone:
		case Name.Raccoon:
		case Name.Bluechip:
		case Name.Mixer:
		case Name.MergeTriple:
		case Name.SplitTriple:
		case Name.MixerTriple:
		case Name.Phial:
		case Name.Channel:
		case Name.Razor:
			break;
		}
	}

	public void InitSpecialUp()
	{
		switch (name)
		{
		case Name.Rat:
			board.CreateModuleSmall(Name.Rat);
			break;
		case Name.Recycler:
			dungeon.shop.restockPrice--;
			break;
		case Name.Wrench:
		{
			List<Module> tribe = board.GetTribe(Tribe.Mech, bankInlucded: true);
			List<Module> list = new List<Module>();
			foreach (Module item in tribe)
			{
				if (!(item == null) && !item.UPGRADED)
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				Module module = Utils.RandElem(list);
				if (module != null)
				{
					board.UpgradeModule(module);
				}
			}
			break;
		}
		}
	}

	public void ShopUp()
	{
		if (!WIREMOD)
		{
			shopUpped = true;
			UPGRADED = true;
			InitUpgrade(loaded: true);
			ShowUpgradePips();
		}
	}

	public void InitOnBoard(bool playSound = false)
	{
		if (!init)
		{
			if (shopPrice == 0)
			{
				int num = dungeon.board.CountAuras(Aura.Type.PerkDiscount);
				shopPrice = (int)((float)Database.GetModData(name).price * Mathf.Pow(0.75f, num));
			}
			tribes = new List<Tribe>(Database.GetModData(name).tribe);
			init = true;
			if (shopUpped)
			{
				InitSpecialUp();
			}
			Init();
			if (playSound)
			{
				dungeon.audioManager.PlayModSound(this);
			}
			StartCoroutine(Increment());
			StartCoroutine(CheckMana());
		}
	}

	public virtual void Init()
	{
	}

	public IEnumerator delayedTrig(Trigger trigger, Monster m, Weapon w, Trigger.Type t, Module mod, int frames)
	{
		yield return Dungeon.Wait(frames);
		trigger.ActivateTrigger(w, m, t, mod);
	}

	public void SetPreview()
	{
		preview = true;
		SpriteRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer obj in componentsInChildren)
		{
			obj.sortingLayerName = "Default";
			obj.sortingOrder += 2;
		}
		Plug[] array = plugs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<Collider2D>().enabled = false;
		}
	}

	public virtual void ResetPhase()
	{
	}

	public void ResetAll()
	{
		foreach (Module output in outputs)
		{
			foreach (Module input in output.inputs)
			{
				input.ResetPhase();
			}
		}
	}

	public virtual void InitConnection(Module connectedMod)
	{
	}

	public virtual void EndConnection(Module disconenctedMod)
	{
	}

	public virtual void SetSlider(float x)
	{
	}

	public virtual void ActivateButton()
	{
	}

	public virtual void SetDial(float x)
	{
	}

	public virtual IEnumerator Increment()
	{
		yield return null;
	}

	public virtual IEnumerator CheckMana()
	{
		yield return null;
		if (!tribes.Contains(Tribe.Wand) && manaRegen == 0f)
		{
			yield break;
		}
		while (true)
		{
			if (ZAPPED)
			{
				yield return Dungeon.Wait(1);
				continue;
			}
			mana += manaRegen / 60f;
			mana = Mathf.Clamp(mana, 0f, 9999f);
			if (mana >= manaCost)
			{
				if (castOnlyInCombat || bankItem)
				{
					while (!dungeon.combat)
					{
						yield return Dungeon.Wait(1);
					}
				}
				TriggerBounce();
				yield return Dungeon.Wait(5);
				mana -= manaCost;
				for (int i = 0; i < repeat + 1; i++)
				{
					Cast();
					if (repeat > 0)
					{
						yield return Dungeon.Wait(5);
					}
				}
			}
			yield return Dungeon.Wait(1);
		}
	}

	public void Cast()
	{
		board.TriggerModules(global::Trigger.Type.Cast, this);
		CastSpell();
		if (weapon != null)
		{
			weapon.CastSpell();
		}
		board.CheckAuras();
	}

	public void CastDelayed()
	{
		StartCoroutine(CastDelayed(5));
	}

	private IEnumerator CastDelayed(int x)
	{
		yield return Dungeon.Wait(5);
		Cast();
	}

	public void TriggerBounce(int frames = 1)
	{
		if (!bouncing)
		{
			StartCoroutine(bounce(this, frames));
		}
	}

	public IEnumerator bounce(MonoBehaviour m, int f = 3)
	{
		Plug[] array = plugs;
		foreach (Plug plug in array)
		{
			if (plug.dragging || (plug.connectedPlug != null && plug.connectedPlug.dragging))
			{
				yield break;
			}
		}
		bouncing = true;
		DragPlugs();
		for (int j = 0; j < f; j++)
		{
			m.transform.localPosition += new Vector3(0f, 0.0625f);
			yield return Dungeon.Wait(1);
		}
		for (int j = 0; j < f; j++)
		{
			yield return Dungeon.Wait(1);
			m.transform.localPosition -= new Vector3(0f, 0.0625f);
		}
		if (!dragging && !clickMoving)
		{
			EndDragPlugs();
		}
		yield return null;
		yield return null;
		yield return null;
		bouncing = false;
	}

	protected virtual void CastSpell()
	{
	}

	public void DragPlugs()
	{
		Plug[] componentsInChildren = GetComponentsInChildren<Plug>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].StartDrag();
		}
	}

	public void EndDragPlugs()
	{
		Plug[] componentsInChildren = GetComponentsInChildren<Plug>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].EndDrag();
		}
	}

	public void SetElevated(bool elev)
	{
		isElevated = elev;
		SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer obj in componentsInChildren)
		{
			obj.sortingLayerName = (elev ? "WidgetElevated" : "Widget");
			obj.sortingOrder += (elev ? 20000 : (-20000));
		}
	}

	private void OnMouseDrag()
	{
		if (preview)
		{
			return;
		}
		if (dragCount < dragFrames)
		{
			dragCount++;
			return;
		}
		if (!dragging)
		{
			if (Vector3.Distance(GetMousePos(), clickPos) < 0.125f || dragCount < dragFrames || !CanDrag(showErrors: true))
			{
				return;
			}
			dragging = true;
			clickMoving = false;
			if (!dragging)
			{
				return;
			}
		}
		CanDrag(showErrors: true);
	}

	private void OnMouseDown()
	{
		if (preview)
		{
			return;
		}
		if (clickMoving)
		{
			clickMoving = false;
			dungeon.movingMods = false;
			dungeon.draggingModule = null;
			dungeon.bank.HidePreviews();
			return;
		}
		clickPos = GetMousePos();
		if (CanDrag())
		{
			clickMoving = true;
			dungeon.movingMods = true;
			dungeon.draggingModule = this;
			dungeon.audioManager.PlayModSound(this);
			offset = base.transform.position - GetMousePos();
			dungeon.animationManager.BounceZoom(base.gameObject, 0.1f, 2, modWire: false, UI: true);
			dragger = StartCoroutine(rotateAnim());
			SetElevated(elev: true);
			dungeon.board.ShowPreviews(this, shopItem);
			dungeon.bank.ShowPreviews();
			if (dungeon.tooltip.currMod == this)
			{
				dungeon.tooltip.Hide(force: true);
			}
			DragPlugs();
			OP = base.transform.position;
		}
	}

	private void OnMouseUp()
	{
		if (preview || clickMoving)
		{
			return;
		}
		if (dragger != null)
		{
			StopCoroutine(dragger);
		}
		dungeon.movingMods = false;
		dungeon.draggingModule = null;
		clickMoving = false;
		if (f != null)
		{
			StopCoroutine(f);
		}
		dragging = false;
		dragCount = 0;
		StartCoroutine(unrotateAnim());
		base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		base.transform.localScale = Vector3.one;
		if (CanDrag())
		{
			StartCoroutine(antiD());
			dungeon.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.8f);
			bool flag = seller || sellButton;
			dungeon.board.HidePreviews(shopItem);
			dungeon.bank.HidePreviews();
			SetElevated(elev: false);
			if (inner && (sellButton || bankButton) && size == Size.Medium && 1.8f > Vector2.Distance(base.transform.position, dungeon.toggleStateButton.transform.position))
			{
				inner = false;
			}
			if (!inner && !flag && !banker && !bankButton)
			{
				PlaceOutside();
			}
			else if (inner)
			{
				PlaceOnBoard();
			}
			else if (banker)
			{
				PlaceOnBankFrame();
			}
			else if (bankButton)
			{
				PlaceOnBankButton();
			}
			else if (flag)
			{
				PlaceSell();
			}
			bankButton = false;
			sellButton = false;
		}
	}

	private IEnumerator follower()
	{
		while (true)
		{
			base.transform.position = DragPos(base.gameObject) + new Vector3(0f, 0f, -7f);
			yield return null;
		}
	}

	private IEnumerator rotateAnim()
	{
		if (f != null)
		{
			StopCoroutine(f);
		}
		f = StartCoroutine(follower());
		yield return dungeon.animationManager.LerpRotate(base.gameObject, new Vector3(0f, 0f, UnityEngine.Random.Range(-10, 10)), 3f, 0f, UI: true);
		yield return dungeon.animationManager.LerpRotate(base.gameObject, new Vector3(0f, 0f, 0f), 10f, 0f, UI: true);
		Vector3 last = DragPos(base.gameObject);
		float angle = 0f;
		int hoveredSlot = -1;
		while (true)
		{
			Vector3 vector = DragPos(base.gameObject);
			float x = vector.x;
			float x2 = last.x;
			float b = Mathf.Clamp(x - x2, -2f, 2f) / 2f * 45f;
			angle = Mathf.Lerp(angle, b, 0.75f);
			base.transform.localEulerAngles = new Vector3(0f, 0f, angle);
			last = vector;
			if (inner)
			{
				if (!board.modules.Contains(this) && !shopItem && !bankItem)
				{
					yield return null;
					continue;
				}
				int num = ClosestSlot();
				board.StartPreview(num, this);
				if (hoveredSlot != num)
				{
					hoveredSlot = num;
					dungeon.tooltip.Hide(force: true);
					dungeon.board.ShowUpgradeTip(hoveredSlot, this);
				}
			}
			else if (banker)
			{
				int num2 = ClosestBankSlot();
				if (hoveredSlot != num2)
				{
					hoveredSlot = num2;
					dungeon.tooltip.Hide(force: true);
					dungeon.bank.ShowUpgradeTip(hoveredSlot, this);
				}
			}
			else if (hoveredSlot != -1)
			{
				hoveredSlot = -1;
				dungeon.tooltip.Hide(force: true);
			}
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				inner = false;
				seller = false;
				banker = false;
				bankButton = false;
				sellButton = false;
				clickMoving = false;
				dungeon.movingMods = false;
				dungeon.draggingModule = null;
				dragging = false;
				OnMouseUp();
			}
			if (!Input.GetKey(KeyCode.Mouse0) && !clickMoving && !dragging)
			{
				break;
			}
			yield return null;
		}
	}

	private IEnumerator unrotateAnim()
	{
		yield return null;
		yield return null;
		base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		base.transform.localScale = Vector3.one;
	}

	public void RefreshForeignAuras()
	{
		List<Aura> list = new List<Aura>();
		foreach (Aura aura in auras)
		{
			if (aura.foreign && !aura.refreshed)
			{
				list.Add(aura);
			}
			else if (aura.foreign && aura.refreshed)
			{
				aura.refreshed = false;
			}
		}
		foreach (Aura item in list)
		{
			RemoveAura(item);
		}
	}

	public void RemoveAura(Aura a)
	{
		auras.Remove(a);
		a.RemoveAura();
	}

	public Aura FindForeignAura(Aura a)
	{
		if (!a.foreign)
		{
			return null;
		}
		foreach (Aura aura in auras)
		{
			if (a.type == aura.type && aura.foreign && a.source == aura.source && a.value == aura.value)
			{
				return aura;
			}
		}
		return null;
	}

	public void AddAura(Aura.Type t, int timer = -1, float val = 1f, bool silent = false)
	{
		AddAura(new Aura(t, foreign: false, temp: false, null, val), timer, silent);
	}

	public void AddAura(Aura a, int timer = -1, bool silent = false)
	{
		Aura aura = FindForeignAura(a);
		if (aura != null && aura.foreign && aura.source == a.source)
		{
			aura.refreshed = true;
			return;
		}
		if (aura == null && a.foreign)
		{
			a.refreshed = true;
		}
		a.owner = this;
		a.InitAura(negative: false, silent);
		auras.Add(a);
		if (timer != -1)
		{
			StartCoroutine(AuraTimer(a, timer));
		}
	}

	private IEnumerator AuraTimer(Aura a, int timer)
	{
		yield return Dungeon.Wait(timer);
		RemoveAura(a);
		board.CheckAuras();
	}

	public void Splash(int timeFrames, float slow = 0.3f)
	{
		if (!SPLASH)
		{
			SPLASH = true;
			StartCoroutine(SplashTimer(timeFrames, slow));
		}
	}

	private IEnumerator SplashTimer(int frames, float slow)
	{
		accelMult += 0f - slow;
		float debuffMP = manaRegen * slow;
		if (WAND)
		{
			manaRegen += 0f - debuffMP;
		}
		int num = 9;
		if (UPGRADED)
		{
			num += 2;
		}
		if (size == Size.Medium)
		{
			num++;
		}
		SpriteRenderer zap = UnityEngine.Object.Instantiate(Dungeon.Instance.modHighlights[num]).GetComponent<SpriteRenderer>();
		SpriteRenderer anim = zap.GetComponentsInChildren<SpriteRenderer>()[1];
		zap.transform.parent = base.transform;
		zap.transform.localScale = Vector3.one;
		zap.transform.localPosition = Vector3.zero;
		zap.enabled = true;
		Color c = new Color(1f, 1f, 1f, 0.55f);
		Color canim = new Color(1f, 1f, 1f, 0.75f);
		Color waveColor = new Color(0f, 0f, 0f, 0.1f);
		float range = 1f;
		if (size == Size.Medium)
		{
			range = 2f;
		}
		for (int i = 0; i < frames; i++)
		{
			zap.color = c + Mathf.Sin((float)i * 0.1f) * waveColor;
			anim.color = canim + Mathf.Sin((float)i * 0.1f) * waveColor;
			if (i % 4 == 0)
			{
				dungeon.animationManager.CreateGibs("0CF1FF", base.transform.position + new Vector3(UnityEngine.Random.Range(0f - range, range), UnityEngine.Random.Range(-1.8f, 1.8f)), 1f, 0.1f, unmasked: true);
				if (weapon != null)
				{
					dungeon.animationManager.CreateGibs("0CF1FF", weapon.transform.position, 2f, 0.05f);
				}
			}
			yield return Dungeon.Wait(1);
		}
		accelMult += slow;
		if (WAND)
		{
			manaRegen += debuffMP;
		}
		SPLASH = false;
		while (zap.color.a > 0f || anim.color.a > 0f)
		{
			zap.color += new Color(0f, 0f, 0f, -0.05f);
			anim.color += new Color(0f, 0f, 0f, -0.05f);
			yield return Dungeon.Wait(1);
		}
		UnityEngine.Object.Destroy(zap.gameObject);
	}

	public void Zap(int timeFrames)
	{
		if (!ZAPPED)
		{
			ZAPPED = true;
			StartCoroutine(ZapTimer(timeFrames));
		}
	}

	private IEnumerator ZapTimer(int frames)
	{
		int num = 5;
		if (UPGRADED)
		{
			num += 2;
		}
		if (size == Size.Medium)
		{
			num++;
		}
		SpriteRenderer zap = UnityEngine.Object.Instantiate(Dungeon.Instance.modHighlights[num]).GetComponent<SpriteRenderer>();
		zap.transform.parent = base.transform;
		zap.transform.localScale = Vector3.one;
		zap.transform.localPosition = Vector3.zero;
		zap.enabled = true;
		Color c = new Color(1f, 1f, 1f, 0.65f);
		Color waveColor = new Color(0f, 0f, 0f, 0.1f);
		float range = 1f;
		if (size == Size.Medium)
		{
			range = 2f;
		}
		Vector3 OP = board.GetModulePos(this, index);
		DragPlugs();
		for (int i = 0; i < frames; i++)
		{
			zap.color = c + Mathf.Sin((float)i * 0.1f) * waveColor;
			if (i % 2 == 0)
			{
				dungeon.animationManager.CreateGibs("FFEB57", base.transform.position + new Vector3(UnityEngine.Random.Range(0f - range, range), UnityEngine.Random.Range(-1.8f, 1.8f)), 1f, 0.1f, unmasked: true);
				base.transform.localPosition = OP + new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f)) * 1f / 16f;
				if (weapon != null)
				{
					dungeon.animationManager.CreateGibs("FFEB57", weapon.transform.position, 2f, 0.05f);
				}
			}
			yield return Dungeon.Wait(1);
		}
		base.transform.localPosition = OP;
		EndDragPlugs();
		ZAPPED = false;
		while (zap.color.a > 0f)
		{
			zap.color += new Color(0f, 0f, 0f, -0.05f);
			yield return Dungeon.Wait(1);
		}
		UnityEngine.Object.Destroy(zap.gameObject);
	}

	public void BuffParticles(string color, int frames)
	{
		if (!WIREMOD && (!buffAnims.ContainsKey(color) || buffAnims[color] < 1))
		{
			StartCoroutine(buffEffect(color, frames));
		}
	}

	private IEnumerator buffEffect(string color, int frames)
	{
		float range = 1f;
		if (size == Size.Medium)
		{
			range = 2f;
		}
		if (buffAnims.ContainsKey(color))
		{
			buffAnims[color]++;
		}
		else
		{
			buffAnims.Add(color, 1);
		}
		int gibber = ((dungeon.animationManager.gibCount >= 250) ? 5 : 2);
		if (gibber != 5)
		{
		}
		for (int i = 0; i < frames; i++)
		{
			if (i % gibber == 0)
			{
				gibber = ((dungeon.animationManager.gibCount >= 100) ? 5 : 2);
				int num = ((gibber == 5) ? 2 : 3);
				Vector3 position = base.transform.position + new Vector3(UnityEngine.Random.Range(0f - range, range), UnityEngine.Random.Range(-2f, 1.5f));
				dungeon.animationManager.CreateFallingGibs(color, position, 1f, 0.5f, unmasked: true, 0.65f, MathF.PI / 2f);
				if (weapon != null)
				{
					dungeon.animationManager.CreateFallingGibs(color, weapon.transform.position + 0.2f * Utils.RandDir(), num, 0.2f, unmasked: false, 0.65f, UnityEngine.Random.Range(0f, MathF.PI * 2f), oldStyle: true);
				}
			}
			yield return Dungeon.Wait(1);
		}
		buffAnims[color]--;
	}

	public Module GetLeft(int previewInd = -1)
	{
		Module result = null;
		int num = ((previewInd == -1) ? index : previewInd);
		foreach (Module adjacent in GetAdjacents(num))
		{
			if (adjacent.index < num)
			{
				result = adjacent;
			}
		}
		return result;
	}

	public Module GetRight(int previewInd = -1)
	{
		Module result = null;
		int num = ((previewInd == -1) ? index : previewInd);
		foreach (Module adjacent in GetAdjacents(num))
		{
			if (adjacent.index > num)
			{
				result = adjacent;
			}
		}
		return result;
	}

	public List<Module> GetRow(int previewInd = -1)
	{
		List<Module> list = new List<Module>();
		int num = ((previewInd == -1) ? index : previewInd);
		foreach (Module item in board.GetBoard())
		{
			if (item.index / 5 == num / 5 && item != this)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public Module GetBelow(int previewInd = -1)
	{
		Module result = null;
		int num = ((previewInd == -1) ? index : previewInd);
		foreach (Module item in board.GetBoard())
		{
			if (size == Size.Medium && (item.index == index + 5 || item.index == index + 6))
			{
				return item;
			}
			if (item.size == Size.Medium)
			{
				if (item.index == index + 5 || item.index == index + 4)
				{
					return item;
				}
			}
			else if (item.index == num + 5)
			{
				return item;
			}
		}
		return result;
	}

	public Module GetAbove(int previewInd = -1)
	{
		Module result = null;
		int num = ((previewInd == -1) ? index : previewInd);
		foreach (Module item in board.GetBoard())
		{
			if (item.size == Size.Medium)
			{
				if (item.index == num - 5 || item.index == num - 6)
				{
					return item;
				}
			}
			else if (item.index == num - 5)
			{
				return item;
			}
		}
		return result;
	}

	public List<Module> GetAllBelow(int previewInd = -1)
	{
		List<Module> list = new List<Module>();
		int num = ((previewInd == -1) ? index : previewInd);
		foreach (Module item in board.GetBoard())
		{
			if (size == Size.Medium)
			{
				if (item.index == num + 5 || item.index == num + 6)
				{
					list.Add(item);
				}
				if (item.index == num + 10 || item.index == num + 11)
				{
					list.Add(item);
				}
			}
			if (item.size == Size.Medium)
			{
				if (item.index == num + 5 || item.index == num + 4)
				{
					list.Add(item);
				}
				if (item.index == num + 10 || item.index == num + 9)
				{
					list.Add(item);
				}
			}
			else
			{
				if (item.index == num + 5)
				{
					list.Add(item);
				}
				if (item.index == num + 10)
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public int GetEmptyNeighbors()
	{
		int num = 2;
		if (size == Size.Medium)
		{
			if (index % 5 == 3 || index % 5 == 0)
			{
				num--;
			}
		}
		else if (index % 5 == 4 || index % 5 == 0)
		{
			num--;
		}
		num -= GetAdjacents().Count;
		return Mathf.Max(0, num);
	}

	public List<Module> GetAdjacents(int previewInd = -1)
	{
		List<Module> list = new List<Module>();
		if (!board.modules.Contains(this) && previewInd == -1)
		{
			return list;
		}
		int num = -1;
		int num2 = -1;
		int num3 = index;
		if (previewInd != -1)
		{
			num3 = previewInd;
		}
		switch (size)
		{
		case Size.Small:
			num = ((num3 % 5 != 0) ? (num3 - 1) : (-1));
			num2 = (((num3 + 1) % 5 != 0) ? (num3 + 1) : (-1));
			break;
		case Size.Medium:
			num = ((num3 % 5 != 0) ? (num3 - 1) : (-1));
			num2 = (((num3 + 2) % 5 != 0) ? (num3 + 2) : (-1));
			break;
		case Size.Large:
			num = ((num3 % 5 != 0) ? (num3 - 1) : (-1));
			num2 = (((num3 + 3) % 5 != 0) ? (num3 + 3) : (-1));
			break;
		}
		if (num != -1 && board.modules[num] != null)
		{
			list.Add(board.modules[num]);
		}
		if (num2 != -1 && board.modules[num2] != null)
		{
			list.Add(board.modules[num2]);
		}
		return list;
	}

	public void AddTrigger(Trigger t, int timer = -1)
	{
		triggers.Add(t);
		if (timer != -1)
		{
			StartCoroutine(TriggerTimer(t, timer));
		}
	}

	private IEnumerator TriggerTimer(Trigger t, int frames)
	{
		yield return Dungeon.Wait(UnityEngine.Random.Range(0, 60));
		while (triggers.Contains(t))
		{
			yield return Dungeon.Wait(frames);
			t.ActivateTrigger(null, null, global::Trigger.Type.Timer);
		}
	}

	public void AddTrigger(Trigger.Ability ability, Aura source = null, float proc = 100f, int val = 0, int dmg = 1)
	{
		triggers.Add(new Trigger(ability, this, source, proc, val, dmg));
	}

	public bool HasTrigger(Trigger.Ability a)
	{
		foreach (Trigger trigger in triggers)
		{
			if (trigger.ability == a)
			{
				return true;
			}
		}
		return false;
	}

	public Trigger GetTrigger(Trigger.Ability a, Aura source)
	{
		foreach (Trigger trigger in triggers)
		{
			if (trigger.ability == a && (trigger.source == source || source == null))
			{
				return trigger;
			}
		}
		return null;
	}

	public void RemoveTrigger(Trigger t)
	{
		triggers.Remove(t);
	}

	public void RemoveTrigger(Trigger.Ability a, Aura source = null)
	{
		Trigger trigger = GetTrigger(a, source);
		if (trigger != null)
		{
			RemoveTrigger(trigger);
		}
	}

	public void SetHighlight()
	{
		try
		{
			highlight = UnityEngine.Object.Instantiate(Dungeon.Instance.modHighlights[(int)size]).GetComponent<SpriteRenderer>();
			highlight.transform.parent = base.transform;
			highlight.transform.localPosition = Vector3.zero;
			highlight.enabled = false;
			animHighlight = UnityEngine.Object.Instantiate(Dungeon.Instance.modHighlights[(int)size]).GetComponent<SpriteRenderer>();
			animHighlight.transform.parent = base.transform;
			animHighlight.transform.localPosition = Vector3.zero;
			animHighlight.sortingOrder++;
			animHighlight.enabled = false;
			upgradeHighlight = UnityEngine.Object.Instantiate(Dungeon.Instance.modUpgrades[(int)size]).GetComponent<SpriteRenderer>();
			upgradeHighlight.transform.parent = base.transform;
			upgradeHighlight.transform.localPosition = Vector3.zero;
			upgradeHighlight.sortingOrder += 2;
			upgradeHighlight.transform.localScale = Vector3.zero;
			upgradeHighlight.enabled = false;
		}
		catch
		{
			StartCoroutine(delaySet());
		}
	}

	private IEnumerator delaySet()
	{
		yield return null;
		yield return null;
		SetHighlight();
	}

	public void HighlightUpgrade()
	{
		if (hUp)
		{
			return;
		}
		hUp = true;
		if (!wireMods.Contains(name) && (dungeon.state != Dungeon.State.Combat || shopItem) && !upgradeHighlight.enabled)
		{
			if (highlight.enabled || animHighlight.enabled)
			{
				Unhighlight(insta: true);
			}
			upgradeHighlight.transform.localScale = Vector3.one;
			upgradeHighlight.enabled = true;
			upgradeHighlight.GetComponentInChildren<Animator>().StopAnim(force: true);
			upgradeHighlight.GetComponentInChildren<Animator>().StartAnim();
		}
	}

	public void UnhighlightUpgrade()
	{
		hUp = false;
		if (!(upgradeHighlight.transform.localScale != Vector3.one))
		{
			upgradeHighlight.transform.localScale = Vector3.zero;
			upgradeHighlight.enabled = false;
			upgradeHighlight.GetComponentInChildren<Animator>().StopAnim();
		}
	}

	public void HightlightAnim(string color, int frames = 20, bool persist = false)
	{
		if (!hUp)
		{
			if (UHAnim != null)
			{
				StopCoroutine(UHAnim);
				UHAnim = null;
			}
			if (pers)
			{
				Highlight(color);
			}
			else
			{
				UHAnim = StartCoroutine(_highlightAnim(color, frames, persist));
			}
		}
	}

	private IEnumerator _highlightAnim(string color, int frames, bool persist)
	{
		int f = frames / 2;
		animHighlight.color = Utils.GetColor(color);
		animHighlight.color -= new Color(0f, 0f, 0f, 1f);
		animHighlight.enabled = true;
		for (int i = 0; i < f; i++)
		{
			animHighlight.color += new Color(0f, 0f, 0f, 1f / (float)f);
			yield return Dungeon.Wait(1);
		}
		if (!highlight.enabled && !persist)
		{
			for (int i = 0; i < f; i++)
			{
				animHighlight.color += new Color(0f, 0f, 0f, -1f / (float)f);
				yield return Dungeon.Wait(1);
			}
		}
		else
		{
			highlight.color += new Color(0f, 0f, 0f, 1f);
		}
		animHighlight.color += new Color(0f, 0f, 0f, -1f);
		animHighlight.enabled = false;
		if (persist)
		{
			Highlight(color);
			pers = true;
		}
	}

	public void Highlight(string color = "FFFFFF")
	{
		if (!hUp)
		{
			if (UHAnim != null)
			{
				StopCoroutine(UHAnim);
				animHighlight.enabled = false;
				UHAnim = null;
			}
			highlight.color = Utils.GetColor(color);
			highlight.enabled = true;
		}
	}

	public void Unhighlight(bool insta = false)
	{
		if (UHAnim != null)
		{
			StopCoroutine(UHAnim);
			UHAnim = null;
		}
		if (insta)
		{
			pers = false;
			highlight.enabled = false;
			animHighlight.enabled = false;
		}
		else
		{
			UHAnim = StartCoroutine(uh());
		}
	}

	public SpriteRenderer GetUpgradePips()
	{
		return upgradePips;
	}

	public void ShowUpgradePips()
	{
		SpriteRenderer component = UnityEngine.Object.Instantiate(Dungeon.Instance.modHighlights[4]).GetComponent<SpriteRenderer>();
		component.transform.parent = base.transform;
		component.transform.localPosition = Vector3.zero;
		component.transform.localScale = Vector3.one;
		component.enabled = true;
		if (preview)
		{
			component.sortingLayerName = "Default";
			component.sortingOrder = 11;
		}
		upgradePips = component;
		highlight.sprite = ((size == Size.Small) ? dungeon.modHighlightUpgrades[0] : dungeon.modHighlightUpgrades[1]);
		animHighlight.sprite = ((size == Size.Small) ? dungeon.modHighlightUpgrades[0] : dungeon.modHighlightUpgrades[1]);
	}

	private IEnumerator uh()
	{
		for (int i = 0; i < 10; i++)
		{
			highlight.color += new Color(0f, 0f, 0f, -0.1f);
			animHighlight.color += new Color(0f, 0f, 0f, -0.1f);
			yield return Dungeon.Wait(1);
		}
		pers = false;
		highlight.enabled = false;
		animHighlight.enabled = false;
	}

	public void Kill()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void Trigger(Trigger.Type t, Module sourceModule = null)
	{
		foreach (Trigger trigger in triggers)
		{
			trigger.ActivateTrigger(null, null, t, sourceModule);
		}
	}

	public Vector3 GetMousePos()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0f, 0f, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
	}

	public Vector3 DragPos(GameObject obj)
	{
		return GetMousePos() + offset;
	}

	private IEnumerator antiD()
	{
		antiDrag = true;
		yield return null;
		antiDrag = false;
	}

	public bool CanDrag(bool showErrors = false)
	{
		if (antiDrag)
		{
			return false;
		}
		if (dungeon.state == Dungeon.State.Combat)
		{
			if (showErrors)
			{
				board.CombatError(this);
			}
			return false;
		}
		if (dungeon.targeting)
		{
			return false;
		}
		if (dungeon.gold < shopPrice && shopItem)
		{
			return false;
		}
		return true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "boardCollider")
		{
			inner = true;
		}
		if (collision.gameObject.name == "shopCollider" && !shopItem)
		{
			seller = true;
		}
		if (collision.gameObject.name == "toggleState" && dungeon.toggleStateButton.bg.sprite == dungeon.shopIcon)
		{
			bankButton = false;
			sellButton = true;
		}
		if (collision.gameObject.name == "toggleState" && dungeon.toggleStateButton.bg.sprite == dungeon.bankIcon)
		{
			bankButton = true;
			sellButton = false;
		}
		if (collision.gameObject.name == "bankCollider" && !shopItem)
		{
			banker = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "boardCollider")
		{
			inner = false;
			board.EndPreview();
		}
		if (collision.gameObject.name == "shopCollider" && !shopItem)
		{
			seller = false;
		}
		if (collision.gameObject.name == "toggleState")
		{
			bankButton = false;
			sellButton = false;
		}
		if (collision.gameObject.name == "bankCollider" && !shopItem)
		{
			banker = false;
		}
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButton(1))
		{
			dungeon.tooltip.Hide();
		}
		if (shopItem || bankItem || preview || Input.GetMouseButton(0))
		{
			return;
		}
		foreach (Aura aura in auras)
		{
			aura.Highlight();
		}
	}

	private void OnMouseEnter()
	{
		try
		{
			dungeon.hoveredModule = this;
			dungeon.tooltip.Set(this);
		}
		catch
		{
		}
	}

	private void OnMouseExit()
	{
		try
		{
			dungeon.hoveredModule = null;
			dungeon.tooltip.Hide();
			board.UnhighlightAll();
		}
		catch
		{
		}
	}

	public static bool GetInputUp()
	{
		if (!Input.GetKey(KeyCode.W))
		{
			return Input.GetKey(KeyCode.UpArrow);
		}
		return true;
	}

	public static bool GetInputDown()
	{
		if (!Input.GetKey(KeyCode.S))
		{
			return Input.GetKey(KeyCode.DownArrow);
		}
		return true;
	}

	public static bool GetInputLeft()
	{
		if (!Input.GetKey(KeyCode.A))
		{
			return Input.GetKey(KeyCode.LeftArrow);
		}
		return true;
	}

	public static bool GetInputRight()
	{
		if (!Input.GetKey(KeyCode.D))
		{
			return Input.GetKey(KeyCode.RightArrow);
		}
		return true;
	}

	private List<Module> GetModsOnSpace(int i)
	{
		List<Module> list = new List<Module>();
		if (size == Size.Medium)
		{
			list.Add(board.modules[i]);
			if ((i + 1) % 5 != 0 && !list.Contains(board.modules[i + 1]))
			{
				list.Add(board.modules[i + 1]);
			}
		}
		else
		{
			list.Add(board.modules[i]);
		}
		list.RemoveAll((Module x) => x == null);
		list.RemoveAll((Module x) => x == this);
		return list;
	}

	private List<Module> GetBankModsOnSpace(int i)
	{
		List<Module> list = new List<Module>();
		if (size == Size.Medium)
		{
			list.Add(bank.modules[i]);
			if ((i + 1) % 5 != 0 && !list.Contains(bank.modules[i + 1]))
			{
				list.Add(bank.modules[i + 1]);
			}
		}
		else
		{
			list.Add(bank.modules[i]);
		}
		list.RemoveAll((Module x) => x == null);
		list.RemoveAll((Module x) => x == this);
		return list;
	}

	private int ClosestSlot()
	{
		int result = -1;
		float num = 999f;
		int num2 = 0;
		Vector3 position = base.transform.position;
		if (size == Size.Medium)
		{
			position += new Vector3(-1.125f, 0f);
		}
		if (size == Size.Large)
		{
			position += new Vector3(-2.25f, 0f);
		}
		foreach (SpriteRenderer preview in board.previews)
		{
			float num3 = Vector3.Distance(position, preview.transform.position);
			if (num3 < num)
			{
				result = num2;
				num = num3;
			}
			num2++;
		}
		return result;
	}

	private int ClosestBankSlot()
	{
		int result = -1;
		float num = 999f;
		int num2 = 0;
		Vector3 position = base.transform.position;
		if (size == Size.Medium)
		{
			position += new Vector3(-1.125f, 0f);
		}
		if (size == Size.Large)
		{
			position += new Vector3(-2.25f, 0f);
		}
		foreach (SpriteRenderer preview in bank.previews)
		{
			float num3 = Vector3.Distance(position, preview.transform.position);
			if (num3 < num)
			{
				result = num2;
				num = num3;
			}
			num2++;
		}
		return result;
	}

	private void PlaceOutside()
	{
		ResetPos();
		EndDragPlugs();
	}

	private void UpgradeOnBoard(int slot)
	{
		if (shopItem && !dungeon.shop.Purchase(this))
		{
			return;
		}
		List<(Plug, Plug)> list = new List<(Plug, Plug)>();
		Plug[] array = plugs;
		foreach (Plug plug in array)
		{
			if (plug.connected)
			{
				list.Add((plug, plug.connectedPlug));
			}
			else
			{
				list.Add((null, null));
			}
		}
		if (board.modules[slot].PRIORITY || (!board.modules[slot].PRIORITY && !PRIORITY))
		{
			board.UpgradeModule(slot, silent: false, manual: true);
			if (bankItem)
			{
				bank.RemoveModule(index);
			}
			else if (!shopItem)
			{
				board.RemoveModule(this);
			}
			EndDragPlugs();
			for (int j = 0; j < board.modules[slot].plugs.Length; j++)
			{
				if (!board.modules[slot].plugs[j].connected && !(list[j].Item1 == null))
				{
					board.modules[slot].plugs[j].ConnectTo(list[j].Item2, manual: false);
				}
			}
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Module module = board.modules[slot];
		if (bankItem)
		{
			bank.RemoveModule(index);
		}
		else if (!shopItem)
		{
			board.RemoveModule(this);
		}
		for (int k = 0; k < plugs.Length; k++)
		{
			if (list[k].Item1 != null)
			{
				list[k].Item1.ConnectTo(list[k].Item2, manual: false);
			}
			else if (module.plugs[k].connected)
			{
				Plug connectedPlug = module.plugs[k].connectedPlug;
				module.plugs[k].Disconnect();
				plugs[k].ConnectTo(connectedPlug, manual: false);
			}
		}
		int x = module.index;
		board.RemoveModule(module);
		board.AddModule(this, x);
		EndDragPlugs();
		UnityEngine.Object.Destroy(module.gameObject);
		board.UpgradeModule(slot, silent: false, manual: true);
	}

	public bool PlaceCheckSwap(int slot)
	{
		List<Module> modsOnSpace = GetModsOnSpace(slot);
		if (modsOnSpace.Count == 2 && size == Size.Medium && init)
		{
			Board.SwapInfo info = board.CanSwapTriple(this, modsOnSpace[0], modsOnSpace[1], slot);
			if (info.canSwap)
			{
				board.TripleSwap(this, modsOnSpace[0], modsOnSpace[1], info);
				return true;
			}
			return false;
		}
		if (modsOnSpace.Count != 1 || shopItem || !init)
		{
			return false;
		}
		if (modsOnSpace.Count == 1)
		{
			Module y = modsOnSpace[0];
			Board.SwapInfo info2 = board.CanSwap(this, y, slot);
			if (info2.canSwap)
			{
				board.SwapMods(this, y, info2);
				return true;
			}
			return false;
		}
		return false;
	}

	private void PlaceOnBoard()
	{
		int num = ClosestSlot();
		switch (board.CanFit(num, this))
		{
		case Board.FitState.Upgrade:
			UpgradeOnBoard(num);
			break;
		case Board.FitState.True:
			if (!shopItem || dungeon.shop.Purchase(this))
			{
				if (bankItem)
				{
					bank.RemoveModule(index);
				}
				board.AddModule(this, num);
				EndDragPlugs();
			}
			break;
		case Board.FitState.False:
		case Board.FitState.Swap:
			if (shopItem)
			{
				ResetPos();
			}
			else if (bankItem)
			{
				if (!PlaceCheckInterSwap(num, placingOnBank: false))
				{
					ResetPos();
					dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Error);
				}
			}
			else if (!PlaceCheckSwap(num))
			{
				ResetPos();
			}
			EndDragPlugs();
			break;
		}
	}

	private void PlaceOnBankFrame()
	{
		int num = ClosestBankSlot();
		switch (bank.CanFit(this, num))
		{
		case Board.FitState.Upgrade:
			UpgradeInBank(num);
			break;
		case Board.FitState.False:
		case Board.FitState.Swap:
			if (bankItem)
			{
				if (!PlaceCheckSwapBank(num))
				{
					ResetPos();
					if (num != index)
					{
						dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Error);
					}
				}
			}
			else if (!PlaceCheckInterSwap(num, placingOnBank: true))
			{
				ResetPos();
				dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Error);
			}
			break;
		case Board.FitState.True:
			if (shopItem)
			{
				if (!dungeon.shop.Purchase(this))
				{
					break;
				}
			}
			else if (bankItem)
			{
				bank.RemoveModule(index);
			}
			else
			{
				board.RemoveModule(this);
			}
			bank.AddModule(this, num);
			EndDragPlugs();
			break;
		}
	}

	private void PlaceOnBankButton()
	{
		bool flag = false;
		int num = -1;
		foreach (Module item in dungeon.bank.GetBank())
		{
			if (WIREMOD)
			{
				break;
			}
			if (item.name == name && !item.UPGRADED && !UPGRADED)
			{
				num = item.index;
				flag = true;
				break;
			}
		}
		if (flag)
		{
			if (num != -1)
			{
				UpgradeInBank(num);
			}
			return;
		}
		if (!bank.CanFitAuto(this))
		{
			dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Error);
			PlaceOutside();
			return;
		}
		if (shopItem)
		{
			if (!dungeon.shop.Purchase(this))
			{
				return;
			}
		}
		else
		{
			board.RemoveModule(this);
		}
		bank.AutoAdd(this);
	}

	private void UpgradeInBank(int slot)
	{
		if (shopItem && !dungeon.shop.Purchase(this))
		{
			return;
		}
		if (bank.modules[slot].PRIORITY || (!bank.modules[slot].PRIORITY && !PRIORITY))
		{
			board.UpgradeModule(slot, silent: false, manual: true, loaded: false, bank: true);
			if (bankItem)
			{
				bank.RemoveModule(index);
			}
			else if (!shopItem)
			{
				board.RemoveModule(this);
			}
			EndDragPlugs();
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Module module = bank.modules[slot];
		int x = module.index;
		if (bankItem)
		{
			bank.RemoveModule(module.index);
		}
		else if (!shopItem)
		{
			board.RemoveModule(this);
		}
		bank.AddModule(this, x);
		EndDragPlugs();
		UnityEngine.Object.Destroy(module.gameObject);
		board.UpgradeModule(slot, silent: false, manual: true, loaded: false, bank: true);
	}

	public bool PlaceCheckSwapBank(int slot)
	{
		List<Module> bankModsOnSpace = GetBankModsOnSpace(slot);
		if (bankModsOnSpace.Count == 2 && size == Size.Medium && init)
		{
			Board.SwapInfo info = bank.CanSwapTriple(this, bankModsOnSpace[0], bankModsOnSpace[1], slot);
			if (info.canSwap)
			{
				bank.TripleSwap(this, bankModsOnSpace[0], bankModsOnSpace[1], info);
				return true;
			}
			return false;
		}
		if (bankModsOnSpace.Count != 1 || shopItem || !init)
		{
			return false;
		}
		if (bankModsOnSpace.Count == 1)
		{
			Module y = bankModsOnSpace[0];
			Board.SwapInfo info2 = bank.CanSwap(this, y, slot);
			if (info2.canSwap)
			{
				bank.SwapMods(this, y, info2);
				return true;
			}
			return false;
		}
		return false;
	}

	public bool PlaceCheckInterSwap(int slot, bool placingOnBank)
	{
		List<Module> list = (placingOnBank ? GetBankModsOnSpace(slot) : GetModsOnSpace(slot));
		if (list.Count == 2 && size == Size.Medium && init)
		{
			Board.SwapInfo info = (placingOnBank ? bank.CanSwapTripleFromBoard(this, list[0], list[1], slot) : board.CanSwapTripleFromBank(this, list[0], list[1], slot));
			if (info.canSwap)
			{
				if (placingOnBank)
				{
					bank.TripleSwapFromBoard(this, list[0], list[1], info);
				}
				else
				{
					board.TripleSwapFromBank(this, list[0], list[1], info);
				}
				return true;
			}
			return false;
		}
		if (list.Count != 1 || shopItem || !init)
		{
			return false;
		}
		if (list.Count == 1)
		{
			Module y = list[0];
			Board.SwapInfo info2 = (placingOnBank ? bank.CanSwapFromBoard(this, y, slot) : board.CanSwapFromBank(this, y, slot));
			if (info2.canSwap)
			{
				if (placingOnBank)
				{
					dungeon.bank.SwapBoardToBank(this, y, info2);
				}
				else
				{
					dungeon.board.SwapBankToBoard(this, y, info2);
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private void PlaceSell()
	{
		if (shopItem)
		{
			base.transform.position = OP;
			EndDragPlugs();
		}
		else
		{
			board.RemoveModule(this);
			dungeon.shop.Sell(this);
		}
	}

	private void ResetPos()
	{
		if (shopItem)
		{
			base.transform.position = new Vector3(OP.x, OP.y, -1f);
		}
		else if (bankItem)
		{
			base.transform.localPosition = dungeon.bank.GetModulePos(this, index);
			banker = true;
		}
		else
		{
			base.transform.localPosition = dungeon.board.GetModulePos(this, index);
			inner = true;
		}
	}
}
