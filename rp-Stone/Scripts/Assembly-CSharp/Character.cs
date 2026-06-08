using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class Character : MonoBehaviour, IAsciiObject
{
	public enum LookDirection
	{
		None = 0,
		Left = 1,
		Right = 2
	}

	public enum DeathReason
	{
		Unknown = 0,
		DamageTaken = 1,
		ProjectileImpacted = 2,
		LifetimeEnded = 3,
		DecorationCleanup = 4,
		Unmake = 5,
		SharedDeath = 6,
		Custom = 7
	}

	private const int DAMAGED_COLOR_TICS = 4;

	protected const float DAMAGED_COLOR_MULT_FULL = 0.55f;

	protected const float DAMAGED_COLOR_MULT_HALF = 0.775f;

	[NonSerialized]
	public int debugId;

	public string id;

	public string instanceId;

	public string displayName;

	public string iconPath;

	public string flavorText;

	public List<string> tags = new List<string>();

	public List<string> immuneTo = new List<string>();

	public bool requiredForLevelCompletion = true;

	private AsciiSprite mySprite;

	[SerializeField]
	private int positionX;

	private SafeInt safePosX;

	[SerializeField]
	private int positionY;

	private SafeInt safePosY;

	[SerializeField]
	private int positionZ;

	private SafeInt safePosZ;

	[SerializeField]
	private int collisionWidth = 1;

	[SerializeField]
	private int collisionDepth = 1;

	[SerializeField]
	private int headPivotX;

	[SerializeField]
	private int headPivotY;

	public int mouthOffsetX = 6;

	public int mouthOffsetY;

	public int dialogOffsetX;

	public int dialogOffsetY;

	public int dialogPreferredWidth;

	public string dialogTalkSfx;

	[SerializeField]
	private int hitpoints = 1;

	private SafeInt safeHP;

	protected SafeFloat f_hitpoints;

	public int level;

	public int hitpointsPerLevel = 1;

	private SafeInt maxHitpoints;

	private SafeInt defaultHP;

	private SafeFloat defaultMaxArmor;

	private SafeFloat safeArmor;

	public float armorPerSecond;

	[SerializeField]
	private float maxArmor;

	private SafeFloat safeMaxArmor;

	public float armorDegen;

	public int deathDurationTics;

	public bool blinkOnDeath = true;

	[SerializeField]
	private int money;

	public Data.Resource moneyType = Data.Resource.Xi;

	public float baseChanceToEvade;

	public FloatingText damageTextPrefab;

	public int sortTiebreaker = -1;

	private bool alive = true;

	private int elapsedDeathTics;

	private bool hidden;

	private bool cleaningUp;

	private StatModController _statModController;

	private Color _tint = Color.white;

	private int lastLevel;

	protected int lookDir_lastPos;

	protected int lookDir_lastPos2;

	private static int nextDebugId;

	public AsciiSprite MySprite
	{
		get
		{
			return mySprite;
		}
		set
		{
			mySprite = value;
		}
	}

	public LookDirection lookDirection { get; set; }

	public int PositionX
	{
		get
		{
			return safePosX.GetValue();
		}
		set
		{
			positionX = value;
			safePosX = new SafeInt(value);
		}
	}

	public int PositionY
	{
		get
		{
			return safePosY.GetValue();
		}
		set
		{
			positionY = value;
			safePosY = new SafeInt(value);
		}
	}

	public int PositionZ
	{
		get
		{
			return safePosZ.GetValue();
		}
		set
		{
			positionZ = value;
			safePosZ = new SafeInt(value);
		}
	}

	public int CollisionWidth
	{
		get
		{
			return collisionWidth;
		}
		set
		{
			collisionWidth = value;
		}
	}

	public int CollisionDepth
	{
		get
		{
			return collisionDepth;
		}
		set
		{
			collisionDepth = value;
		}
	}

	public int HeadPivotX
	{
		get
		{
			return headPivotX;
		}
		set
		{
			headPivotX = value;
		}
	}

	public int HeadPivotY
	{
		get
		{
			return headPivotY;
		}
		set
		{
			headPivotY = value;
		}
	}

	public int Hitpoints
	{
		get
		{
			return safeHP.GetValue();
		}
		set
		{
			int num = value - safeHP.GetValue();
			hitpoints = value;
			safeHP = new SafeInt(value);
			f_hitpoints += (float)num;
		}
	}

	public int MaxHitpoints
	{
		get
		{
			return maxHitpoints.GetValue();
		}
		set
		{
			maxHitpoints = new SafeInt(value);
		}
	}

	public int DefaultHitpoints
	{
		get
		{
			return defaultHP.GetValue();
		}
		set
		{
			defaultHP = new SafeInt(value);
		}
	}

	public float Armor
	{
		get
		{
			return safeArmor.GetValue();
		}
		set
		{
			safeArmor = new SafeFloat(value);
		}
	}

	public float MaxArmor
	{
		get
		{
			return safeMaxArmor.GetValue();
		}
		set
		{
			maxArmor = value;
			safeMaxArmor = new SafeFloat(value);
		}
	}

	public int Money
	{
		get
		{
			_ = statModController != null;
			return money;
		}
		set
		{
			money = value;
		}
	}

	public virtual bool Alive => alive;

	public DeathReason deathReason { get; private set; }

	public bool Hidden
	{
		get
		{
			return hidden;
		}
		set
		{
			hidden = value;
		}
	}

	protected int damagedTics { get; private set; }

	public float lastDamageColorMultiply { get; private set; }

	public StatModController statModController => _statModController;

	public int lastDrawX { get; protected set; }

	public int lastDrawY { get; protected set; }

	public bool willProbablyDie { get; set; }

	public Color colorTint
	{
		get
		{
			return _tint;
		}
		set
		{
			_tint = value;
		}
	}

	public StonescriptObject ssObject
	{
		get
		{
			SSScriptableObject sSScriptableObject = GetComponent<SSScriptableObject>();
			if (sSScriptableObject == null)
			{
				sSScriptableObject = base.gameObject.AddComponent<SSScriptableObject>();
			}
			return sSScriptableObject.Target;
		}
	}

	public static event Action<Character> OnCharacterCreated;

	public static event Action<Character, Weapon> OnCharacterEquippedWeapon;

	public static event Action<Character, Weapon> OnCharacterUnequippedWeapon;

	public static event Action<Character, Character, Weapon> OnCharacterAttackEnded;

	public static event Action<Character, Damage> OnCharacterGoingToTakeDamage;

	public static event Action<Character, Damage> OnCharacterTookDamage;

	public static event Action<Character, Damage, int> OnCharacterDamagePrevented;

	public static event Action<Character, Damage> OnCharacterGoingToBeHealed;

	public static event Action<Character, Damage> OnCharacterWasHealed;

	public static event Action<Character, Bullet> OnCharacterEvaded;

	public static event Action<Character, float> OnArmorGained;

	public static event Action<Character, DeathReason, Damage> OnCharacterDied;

	public static event Action<Character> OnCharacterCleanedUp;

	public event Action<Character> OnAddedToLevel;

	public event Action<Character> OnUpdateTic;

	public event Action<Character> OnPostUpdateTic;

	public event Action<Character, AsciiRenderProcedural, int, int> OnPostDrawCharacter;

	public virtual void ParseArguments(string sjson)
	{
		if (sjson.StartsWith("["))
		{
			string[] array = SlimJson.ParseArray("{0:" + sjson + "}", "0");
			for (int i = 0; i < array.Length; i++)
			{
				ParseArguments(array[i]);
			}
			return;
		}
		string text = SlimJson.Parse(sjson, "deathEvent");
		if (text != null)
		{
			base.gameObject.AddComponent<CharacterDeathEvent>().Parse(text);
			return;
		}
		string text2 = SlimJson.Parse(sjson, "cleanupEvent");
		if (text2 != null)
		{
			base.gameObject.AddComponent<CharacterCleanupEvent>().Parse(text2);
			return;
		}
		string text3 = SlimJson.Parse(sjson, "drop");
		if (text3 != null)
		{
			GameObject gameObject = Utils.LoadPrefab(text3);
			if (gameObject != null)
			{
				Character component = gameObject.GetComponent<Character>();
				if (component != null)
				{
					CharacterBurstSpawner characterBurstSpawner = base.gameObject.AddComponent<CharacterBurstSpawner>();
					characterBurstSpawner.fixedSpawns = new Character[1] { component };
					int ticDelay = SlimJson.ParseInt(sjson, "ticDelay", 30);
					int x = SlimJson.ParseInt(sjson, "offsetX", 4);
					characterBurstSpawner.ticDelay = ticDelay;
					characterBurstSpawner.positionOffset = new IntPosition(x, 0, 0);
					AddTravelInfoToSpawner(characterBurstSpawner, sjson);
					return;
				}
			}
			Utils.LogError("Failed to load drop at " + text3 + " for character " + this);
			return;
		}
		if (SlimJson.HasKey(sjson, "requiredForLevelCompletion"))
		{
			requiredForLevelCompletion = SlimJson.ParseBool(sjson, "requiredForLevelCompletion");
			return;
		}
		string text4 = SlimJson.Parse(sjson, "treasureId");
		if (text4 != null)
		{
			CharacterBurstTreasureById characterBurstTreasureById = TreasureFactory.singleton.AddTreasureToCharacter(text4, this);
			characterBurstTreasureById.exceptDeathReasons = SlimJson.ParseEnumArray<DeathReason>(sjson, "exceptReasons");
			if (SlimJson.HasKey(sjson, "offsetX"))
			{
				int x2 = SlimJson.ParseInt(sjson, "offsetX");
				characterBurstTreasureById.positionOffset = new IntPosition(x2, 0, 0);
			}
			AddTravelInfoToSpawner(characterBurstTreasureById, sjson);
		}
		else
		{
			int num = SlimJson.ParseInt(sjson, "bonusKi");
			if (num > 0)
			{
				money += num;
			}
		}
	}

	private void AddTravelInfoToSpawner(CharacterBurstSpawner spawner, string sjson)
	{
		spawner.travelTics = SlimJson.ParseInt(sjson, "travelTics");
		if (spawner.travelTics > 0)
		{
			spawner.travelX = SlimJson.ParseFloat(sjson, "travelX");
		}
	}

	public virtual void UpdateTic()
	{
		if (this.OnUpdateTic != null)
		{
			this.OnUpdateTic(this);
		}
		if (statModController != null)
		{
			statModController.UpdateTic();
		}
		if (!alive)
		{
			elapsedDeathTics++;
			if (elapsedDeathTics > deathDurationTics)
			{
				Cleanup();
			}
		}
		else
		{
			UpdateHitpoints();
			UpdateArmor();
			UpdateLookDirection();
		}
		damagedTics--;
		if (this.OnPostUpdateTic != null)
		{
			this.OnPostUpdateTic(this);
		}
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (hidden || (!alive && blinkOnDeath && elapsedDeathTics % 4 <= 1))
		{
			return;
		}
		offsetX += PositionX;
		offsetY += PositionZ - PositionY;
		if (mySprite != null)
		{
			if (alive && damagedTics <= 0)
			{
				mySprite.Draw(r, offsetX, offsetY, 1f, colorTint);
				lastDamageColorMultiply = 1f;
			}
			else if (damagedTics == 1)
			{
				mySprite.Draw(r, offsetX, offsetY, 0.775f, colorTint);
				lastDamageColorMultiply = 0.775f;
			}
			else
			{
				mySprite.Draw(r, offsetX, offsetY, 0.55f, colorTint);
				lastDamageColorMultiply = 0.55f;
			}
		}
		if (alive && statModController != null)
		{
			statModController.Draw(r, offsetX, offsetY, this);
		}
		lastDrawX = offsetX;
		lastDrawY = offsetY;
	}

	public void FireOnPostDraw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionZ - PositionY;
		if (this.OnPostDrawCharacter != null)
		{
			this.OnPostDrawCharacter(this, r, offsetX, offsetY);
		}
	}

	public virtual void AddStatModifier(StatModifier modifier)
	{
		if (!alive)
		{
			Debug.LogError("Cannot add modifier '" + modifier.id + "' to dead " + this);
			return;
		}
		if (immuneTo.Contains(modifier.id))
		{
			UnityEngine.Object.Destroy(modifier.gameObject);
			return;
		}
		InitStatModController();
		statModController.AddStatModifier(modifier);
	}

	public void Cleanse()
	{
		if (statModController != null)
		{
			statModController.Cleanse();
		}
		damagedTics = 0;
	}

	private void InitStatModController()
	{
		if (_statModController == null)
		{
			_statModController = base.gameObject.AddComponent<StatModController>();
			_statModController.character = this;
		}
	}

	public void InflictDamage(Damage dmg)
	{
		dmg.startHitpoints = (dmg.endHitpoints = Hitpoints);
		dmg.startArmor = (dmg.endArmor = Armor);
		if (Character.OnCharacterGoingToTakeDamage != null)
		{
			Character.OnCharacterGoingToTakeDamage(this, dmg);
		}
		if (dmg.amount > 0)
		{
			damagedTics = 4;
			if (dmg.tags.Contains("pure"))
			{
				Hitpoints -= dmg.amount;
				dmg.hitpointsLost = dmg.amount;
			}
			else
			{
				float num = Armor;
				float num2 = num;
				int num3 = dmg.amount;
				if (num > 0f)
				{
					num3 -= Mathf.CeilToInt(num);
					num3 = Mathf.Max(num3, 0);
					num -= (float)dmg.amount;
					if (num <= 0f)
					{
						num = -1f;
					}
					Armor = num;
				}
				Hitpoints -= num3;
				dmg.hitpointsLost = num3;
				dmg.armorLost = num2 - Mathf.Clamp(num, 0f, 999999f);
			}
		}
		dmg.endHitpoints = Hitpoints;
		dmg.endArmor = Armor;
		if (Character.OnCharacterTookDamage != null)
		{
			Character.OnCharacterTookDamage(this, dmg);
		}
		if (dmg.amount <= 0)
		{
			return;
		}
		if (dmg.isCritical)
		{
			string message = dmg.amount + "!";
			FloatingText floatingText = ShowFloatingText(message);
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.red;
			}
		}
		else if (dmg.showFloatingText)
		{
			string message2 = "-" + dmg.amount;
			ShowFloatingText(message2);
		}
		if (Hitpoints <= 0)
		{
			Die(DeathReason.DamageTaken, dmg);
		}
	}

	public void ApplyHeal(Damage heal)
	{
		if (heal.amount <= 0)
		{
			return;
		}
		if (Character.OnCharacterGoingToBeHealed != null)
		{
			Character.OnCharacterGoingToBeHealed(this, heal);
		}
		if (heal.amount > 0)
		{
			if (Hitpoints < MaxHitpoints)
			{
				Hitpoints = Mathf.Min(MaxHitpoints, Hitpoints + heal.amount);
			}
			if (Character.OnCharacterWasHealed != null)
			{
				Character.OnCharacterWasHealed(this, heal);
			}
			string message = "+" + heal.amount;
			FloatingText floatingText = ShowFloatingText(message);
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.green;
			}
		}
	}

	public virtual void UpdateHitpoints()
	{
		if (lastLevel != level)
		{
			int num = level - lastLevel;
			lastLevel = level;
			Hitpoints += num * hitpointsPerLevel;
			MaxHitpoints += num * hitpointsPerLevel;
		}
		if (statModController != null)
		{
			int num2 = statModController.ModMaxHealth(DefaultHitpoints);
			num2 += level * hitpointsPerLevel;
			if (MaxHitpoints != num2)
			{
				float num3 = (float)(num2 - MaxHitpoints) / (float)MaxHitpoints;
				float value = f_hitpoints.GetValue();
				float num4 = Mathf.Min(value + num3 * value, num2);
				MaxHitpoints = num2;
				Hitpoints = Mathf.RoundToInt(num4);
				f_hitpoints = new SafeFloat(num4);
			}
		}
	}

	protected void UpdateArmor()
	{
		float num = armorPerSecond;
		float num2 = defaultMaxArmor.GetValue();
		float num3 = armorDegen;
		if (statModController != null)
		{
			num = statModController.ModArmorPerSecond(num);
			num2 = (MaxArmor = statModController.ModMaxArmor(num2));
		}
		float num5 = Armor;
		if (num3 < 0f && num5 > num2)
		{
			float armorCeiling = GetArmorCeiling();
			num5 = ((!(num5 > armorCeiling)) ? (num5 + num3 * 0.03333333f) : (num5 + num3 * 0.03333333f * 2f));
			num5 = Mathf.Max(num5, 0f);
		}
		else if (num > 0f && num5 < num2)
		{
			float num6 = num * 0.03333333f;
			num5 += num6;
			FireOnArmorGained(this, num6);
			num5 = Mathf.Min(num5, num2);
		}
		else if (num < 0f && num5 > 0f)
		{
			float num7 = num * 0.03333333f;
			num5 += num7;
			FireOnArmorGained(this, num7);
			num5 = Mathf.Max(num5, 0f);
		}
		Armor = num5;
		LimitArmorToCeiling(200f);
	}

	public void LimitArmorToCeiling(float bonusCeiling = 0f)
	{
		float num = GetArmorCeiling() + bonusCeiling;
		if (Armor > num)
		{
			Armor = num;
		}
	}

	public float GetArmorCeiling()
	{
		return MaxArmor + (float)MaxHitpoints;
	}

	public bool IsStunned()
	{
		if (statModController != null)
		{
			for (int i = 0; i < statModController.debuffs.Count; i++)
			{
				List<StatModifier> list = statModController.debuffs[i];
				if (list.Count > 0 && list[0].statData != null && list[0].statData.type == ItemData.Stat.Type.Stun)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void FireEquippedWeapon(Character character, Weapon weapon)
	{
		if (Character.OnCharacterEquippedWeapon != null)
		{
			Character.OnCharacterEquippedWeapon(character, weapon);
		}
	}

	public static void FireUnequippedWeapon(Character character, Weapon weapon)
	{
		if (Character.OnCharacterUnequippedWeapon != null)
		{
			Character.OnCharacterUnequippedWeapon(character, weapon);
		}
	}

	public static void FireAttackEnded(Character character, Character target, Weapon weapon)
	{
		if (Character.OnCharacterAttackEnded != null)
		{
			Character.OnCharacterAttackEnded(character, target, weapon);
		}
	}

	public static void FireOnDamagePrevented(Character character, Damage dmg, int amountPrevented)
	{
		if (Character.OnCharacterDamagePrevented != null)
		{
			Character.OnCharacterDamagePrevented(character, dmg, amountPrevented);
		}
	}

	public static void FireOnEvaded(Character character, Bullet bullet)
	{
		Character.OnCharacterEvaded?.Invoke(character, bullet);
	}

	public static void FireOnArmorGained(Character character, float armorAmount)
	{
		Character.OnArmorGained?.Invoke(character, armorAmount);
	}

	public bool IsInvulnerable()
	{
		return tags.Contains("undamageable");
	}

	public FloatingText ShowFloatingText(string message, int delay = 0)
	{
		if (damageTextPrefab == null)
		{
			return null;
		}
		FloatingText floatingText = UnityEngine.Object.Instantiate(damageTextPrefab);
		floatingText.SetMessage(message);
		floatingText.PositionX = PositionX + headPivotX;
		floatingText.PositionY = PositionZ + headPivotY - PositionY;
		floatingText.initialDelay = delay;
		GameStates.Singleton.level.AddObject(floatingText);
		return floatingText;
	}

	public FloatingText ShowFloatingText(string message, Color c, int delay = 0)
	{
		FloatingText floatingText = ShowFloatingText(message, delay);
		if (floatingText != null)
		{
			floatingText.Message.color = c;
		}
		return floatingText;
	}

	public virtual void Die(DeathReason reason)
	{
		Die(reason, null);
	}

	public virtual void Die(DeathReason reason, Damage damage)
	{
		if (!alive)
		{
			Utils.LogWarning(this?.ToString() + " already dead for reason of " + deathReason.ToString() + ". Cannot be killed again by reason of " + reason);
			return;
		}
		alive = false;
		deathReason = reason;
		if (Character.OnCharacterDied != null)
		{
			Character.OnCharacterDied(this, reason, damage);
		}
		Cleanse();
		if (deathDurationTics <= 0)
		{
			Cleanup();
		}
	}

	public ItemData.Element GetElement()
	{
		if (tags.Contains("Ice"))
		{
			return ItemData.Element.Ice;
		}
		if (tags.Contains("Fire"))
		{
			return ItemData.Element.Fire;
		}
		if (tags.Contains("Poison"))
		{
			return ItemData.Element.Poison;
		}
		if (tags.Contains("Vigor"))
		{
			return ItemData.Element.Vigor;
		}
		if (tags.Contains("AEther"))
		{
			return ItemData.Element.AEther;
		}
		if (tags.Contains("Air"))
		{
			return ItemData.Element.Air;
		}
		return ItemData.Element.Stone;
	}

	public void FireOnAddedToLevel()
	{
		if (this.OnAddedToLevel != null)
		{
			this.OnAddedToLevel(this);
		}
	}

	public void SetLevel(int newLevel)
	{
		newLevel = HamartiaEventController.singleton.ProcessEnemy(this, newLevel);
		level = newLevel;
		Weapon[] componentsInChildren = GetComponentsInChildren<Weapon>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].level = ItemFactory.CalculateItemLevelFromDisplayLevel(newLevel + 1);
		}
		UpdateHitpoints();
		UpdateArmor();
		Armor = MaxArmor;
		colorTint = UpgradeRelicScreen.GetColorForDifficulty(newLevel + 5);
		if (colorTint != ColorConstants.white)
		{
			SpriteAccessory[] componentsInChildren2 = GetComponentsInChildren<SpriteAccessory>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].tint = colorTint;
			}
		}
	}

	protected virtual void UpdateLookDirection()
	{
		if (lookDir_lastPos == 0)
		{
			lookDir_lastPos = PositionX;
		}
		else if (lookDir_lastPos != PositionX)
		{
			if (lookDirection != LookDirection.Left && PositionX < lookDir_lastPos && lookDir_lastPos < lookDir_lastPos2)
			{
				lookDirection = LookDirection.Left;
			}
			else if (lookDirection != LookDirection.Right && PositionX > lookDir_lastPos && lookDir_lastPos > lookDir_lastPos2)
			{
				lookDirection = LookDirection.Right;
			}
			lookDir_lastPos2 = lookDir_lastPos;
			lookDir_lastPos = PositionX;
		}
	}

	protected virtual void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
		if (mySprite != null)
		{
			mySprite.Load();
		}
		debugId = nextDebugId++;
		if (Character.OnCharacterCreated != null)
		{
			Character.OnCharacterCreated(this);
		}
	}

	public string GetDebugName()
	{
		return id + " " + debugId;
	}

	public virtual void Init()
	{
		safePosX = new SafeInt(positionX);
		safePosY = new SafeInt(positionY);
		safePosZ = new SafeInt(positionZ);
		Hitpoints = hitpoints;
		MaxHitpoints = hitpoints;
		DefaultHitpoints = hitpoints;
		f_hitpoints = new SafeFloat(hitpoints);
		safeMaxArmor = new SafeFloat(maxArmor);
		defaultMaxArmor = new SafeFloat(maxArmor);
	}

	protected virtual void Start()
	{
	}

	protected void Cleanup()
	{
		if (!cleaningUp)
		{
			cleaningUp = true;
			if (Character.OnCharacterCleanedUp != null)
			{
				Character.OnCharacterCleanedUp(this);
			}
			GameStates.Singleton.level.RemoveCharacter(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	[StonescriptNativeGetter("id")]
	public object Property_GetId()
	{
		return id;
	}

	[StonescriptNativeGetter("name")]
	public object Property_GetName()
	{
		return displayName;
	}

	[StonescriptNativeGetter("positionX")]
	public object Property_GetPositionX()
	{
		return PositionX;
	}

	[StonescriptNativeSetter("positionX")]
	public void Property_SetPositionX(object value)
	{
		PositionX = (int)value;
	}

	[StonescriptNativeGetter("positionY")]
	public object Property_GetPositionY()
	{
		return PositionZ;
	}

	[StonescriptNativeSetter("positionY")]
	public void Property_SetPositionY(object value)
	{
		PositionZ = (int)value;
	}

	[StonescriptNativeGetter("mouthOffsetX")]
	public object Property_GetMouthOffsetX()
	{
		return mouthOffsetX;
	}

	[StonescriptNativeSetter("mouthOffsetX")]
	public void Property_SetMouthOffsetX(object value)
	{
		mouthOffsetX = (int)value;
	}

	[StonescriptNativeGetter("mouthOffsetY")]
	public object Property_GetMouthOffsetY()
	{
		return mouthOffsetY;
	}

	[StonescriptNativeSetter("mouthOffsetY")]
	public void Property_SetMouthOffsetY(object value)
	{
		mouthOffsetY = (int)value;
	}

	[StonescriptNativeGetter("dialogOffsetX")]
	public object Property_GetDialogOffsetX()
	{
		return dialogOffsetX;
	}

	[StonescriptNativeSetter("dialogOffsetX")]
	public void Property_SetDialogOffsetX(object value)
	{
		dialogOffsetX = (int)value;
	}

	[StonescriptNativeGetter("dialogOffsetY")]
	public object Property_GetDialogOffsetY()
	{
		return dialogOffsetY;
	}

	[StonescriptNativeSetter("dialogOffsetY")]
	public void Property_SetDialogOffsetY(object value)
	{
		dialogOffsetY = (int)value;
	}

	[StonescriptNativeGetter("sortTiebreaker")]
	public object Property_GetSortTiebreaker()
	{
		return sortTiebreaker;
	}

	[StonescriptNativeSetter("sortTiebreaker")]
	public void Property_SetSortTiebreaker(object value)
	{
		sortTiebreaker = (int)value;
	}

	[StonescriptNativeGetter("lookDirection")]
	public object Property_GetLookDirection()
	{
		return lookDirection.ToString();
	}

	[StonescriptNativeSetter("lookDirection")]
	public void Property_SetLookDirection(object value)
	{
		if (!(value is string) || (value as string).Length < 2)
		{
			throw new StonescriptRuntimeException($"\"{value}\" is not a valid look direction.");
		}
		string text = value as string;
		if (Enum.TryParse<LookDirection>(text, out var result))
		{
			lookDirection = result;
			return;
		}
		text = text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
		if (Enum.TryParse<LookDirection>(text, out result))
		{
			lookDirection = result;
			return;
		}
		throw new StonescriptRuntimeException($"\"{value}\" is not a valid look direction.");
	}

	[StonescriptNativeMethod]
	public object SetHidden(List<object> parameters, InvocationContext ctx)
	{
		bool flag = (bool)parameters[0];
		Hidden = flag;
		return null;
	}

	[StonescriptNativeGetter("instanceId")]
	public object Property_GetInstanceId()
	{
		return instanceId;
	}

	[StonescriptNativeSetter("instanceId")]
	public void Property_SetInstanceId(object value)
	{
		instanceId = value as string;
	}

	[StonescriptNativeGetter("hitpoints")]
	public object Property_GetHitpoints()
	{
		return Hitpoints;
	}

	[StonescriptNativeGetter("maxHitpoints")]
	public object Property_GetMaxHitpoints()
	{
		return MaxHitpoints;
	}

	[StonescriptNativeGetter("armor")]
	public object Property_GetArmor()
	{
		return Armor;
	}

	[StonescriptNativeGetter("maxArmor")]
	public object Property_GetMaxArmor()
	{
		return MaxArmor;
	}

	[StonescriptNativeGetter("isEnemy")]
	public object Property_GetIsEnemy()
	{
		return this is Enemy;
	}

	[StonescriptNativeGetter("isHero")]
	public object Property_GetIsHero()
	{
		return this is Hero;
	}

	[StonescriptNativeGetter("element")]
	public object Property_GetElement()
	{
		return GetElement().ToString();
	}

	[StonescriptNativeMethod]
	public object HasTag(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("HasTag requires a string parameter");
		}
		string text = parameters[0] as string;
		return HasTag(text);
	}

	public bool HasTag(string tag)
	{
		if (tags == null)
		{
			return false;
		}
		return tags.Contains(tag);
	}

	[StonescriptNativeMethod]
	public object AddSprite(List<object> parameters, InvocationContext ctx)
	{
		int index = 0;
		string value = parameters[index++] as string;
		if (string.IsNullOrEmpty(value))
		{
			throw new StonescriptRuntimeException("Invalid sprite name");
		}
		GameObject obj = new GameObject(value);
		obj.transform.SetParent(base.transform);
		AsciiSprite asciiSprite = obj.AddComponent<AsciiSprite>();
		if (parameters[index] is string)
		{
			string text = parameters[index++] as string;
			text = text.Replace("\\n", "\n");
			asciiSprite.Load(text);
		}
		return obj.AddComponent<SSScriptableObject>().Target;
	}

	[StonescriptNativeMethod]
	public object GetSprite(List<object> parameters, InvocationContext ctx)
	{
		int num = 0;
		string text = parameters[num++] as string;
		if (string.IsNullOrEmpty(text))
		{
			throw new StonescriptRuntimeException("Invalid sprite name");
		}
		Transform transform = base.transform.Find(text);
		if (transform == null)
		{
			return null;
		}
		if (transform.GetComponent<AsciiSprite>() == null)
		{
			throw new StonescriptRuntimeException("\"" + text + "\" is not a sprite.");
		}
		SSScriptableObject sSScriptableObject = transform.gameObject.GetComponent<SSScriptableObject>();
		if (sSScriptableObject == null)
		{
			sSScriptableObject = transform.gameObject.AddComponent<SSScriptableObject>();
		}
		return sSScriptableObject.Target;
	}

	[StonescriptNativeMethod]
	public object GetAnimation(List<object> parameters, InvocationContext ctx)
	{
		int num = 0;
		string text = parameters[num++] as string;
		if (string.IsNullOrEmpty(text))
		{
			throw new StonescriptRuntimeException("Invalid animation name");
		}
		Transform transform = base.transform.Find(text);
		if (transform == null)
		{
			return null;
		}
		if (transform.GetComponent<AsciiAnimation>() == null)
		{
			throw new StonescriptRuntimeException("\"" + text + "\" is not an animation.");
		}
		SSScriptableObject component = transform.gameObject.GetComponent<SSScriptableObject>();
		if (component == null)
		{
			throw new StonescriptRuntimeException("Animation \"" + text + "\" is not scriptable.");
		}
		return component.Target;
	}

	[StonescriptNativeMethod]
	public object AddAnimation(List<object> parameters, InvocationContext ctx)
	{
		int num = 0;
		GameObject obj = new GameObject(parameters[num++] as string);
		obj.transform.SetParent(base.transform);
		AsciiSprite asciiSprite = obj.AddComponent<AsciiSprite>();
		string text = parameters[num++] as string;
		text = text.Replace("\\n", "\n");
		asciiSprite.Load(text);
		obj.AddComponent<AsciiAnimation>();
		SSScriptableObject sSScriptableObject = obj.AddComponent<SSScriptableObject>();
		MultilayerSprite multilayerSprite = mySprite as MultilayerSprite;
		if (multilayerSprite != null && multilayerSprite.additionalLayers.Count == 0)
		{
			multilayerSprite.additionalLayers.Add(asciiSprite);
		}
		return sSScriptableObject.Target;
	}

	[StonescriptNativeMethod]
	public object AddLineSprite(List<object> parameters, InvocationContext ctx)
	{
		int num = 0;
		string value = parameters[num++] as string;
		if (string.IsNullOrEmpty(value))
		{
			throw new StonescriptRuntimeException("Invalid sprite name");
		}
		GameObject obj = new GameObject(value);
		obj.transform.SetParent(base.transform);
		obj.AddComponent<AsciiLineSprite>();
		return obj.AddComponent<SSScriptableObject>().Target;
	}

	[StonescriptNativeMethod]
	public object DealDamage(List<object> parameters, InvocationContext ctx)
	{
		Damage source;
		if (parameters.Count >= 1 && parameters[0] is SSNativeObject<Damage>)
		{
			SSNativeObject<Damage> sSNativeObject = (SSNativeObject<Damage>)parameters[0];
			if (sSNativeObject != null)
			{
				source = sSNativeObject.Source;
				InflictDamage(source);
				return sSNativeObject;
			}
		}
		if (parameters.Count == 0 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("DealDamage expects first parameter to be an int or damage object.");
		}
		int num = 0;
		source = new Damage();
		source.amount = (int)parameters[num++];
		if (parameters.Count > num && parameters[num] is string)
		{
			string text = parameters[num++] as string;
			if (!Enum.TryParse<Damage.Type>(text, out source.type))
			{
				throw new StonescriptRuntimeException("\"" + text + "\" is not a valid damage type.");
			}
		}
		if (parameters.Count > num && parameters[num] is StonescriptObject && parameters[num++] is StonescriptObject stonescriptObject && stonescriptObject.Scriptable != null)
		{
			source.Owner = stonescriptObject.Scriptable.GetComponent<Character>();
		}
		InflictDamage(source);
		return new SSNativeObject<Damage>(source);
	}

	[StonescriptNativeMethod("Heal")]
	public object Method_Heal(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Heal expects parameter int.");
		}
		Damage damage = new Damage();
		damage.amount = (int)parameters[0];
		ApplyHeal(damage);
		return null;
	}

	[StonescriptNativeMethod("Cleanse")]
	public object Method_Cleanse(List<object> parameters, InvocationContext ctx)
	{
		Cleanse();
		return null;
	}

	[StonescriptNativeMethod]
	public object ApplyDebuff(List<object> parameters, InvocationContext ctx)
	{
		if (!Alive)
		{
			throw new StonescriptRuntimeException("Cannot ApplyDebuff to dead characters");
		}
		if (parameters.Count < 2 || !(parameters[0] is string) || !(parameters[1] is int))
		{
			throw new StonescriptRuntimeException("ApplyDebuff expects parameters (string, int).");
		}
		string text = parameters[0] as string;
		int ticDuration = (int)parameters[1];
		GameObject obj = Utils.InstantiatePrefab(text);
		if (obj == null)
		{
			throw new StonescriptRuntimeException("Did not find object at " + text);
		}
		DebuffStatMod component = obj.GetComponent<DebuffStatMod>();
		if (component == null)
		{
			throw new StonescriptRuntimeException("Did not find debuff at " + text);
		}
		component.character = this;
		component.statData = component.replacementStat;
		component.ticDuration = ticDuration;
		component.Init();
		AddStatModifier(component);
		return null;
	}
}
