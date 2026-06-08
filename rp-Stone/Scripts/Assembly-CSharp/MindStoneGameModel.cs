using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

public class MindStoneGameModel : AStonescriptGameModel, IPostAsciiRendererEffect
{
	private struct AdvancedPrintCommand
	{
		public string command;

		public int offsetX;

		public int offsetY;

		public Character character;

		public AdvancedPrintCommand(string str, int x, int y)
		{
			command = str;
			offsetX = x;
			offsetY = y;
			character = null;
		}

		public AdvancedPrintCommand(Character c, int x, int y)
		{
			character = c;
			offsetX = x;
			offsetY = y;
			command = null;
		}
	}

	private struct DrawBackgroundCommand
	{
		public int x;

		public int y;

		public int w;

		public int h;

		public Color color;

		public DrawBackgroundCommand(int x, int y, int w, int h, Color c)
		{
			this.x = x;
			this.y = y;
			this.w = w;
			this.h = h;
			color = c;
		}
	}

	private const int FOE_COUNT_DISTANCE_THRESHOLD = 46;

	private string cachedLocation;

	private string cachedFoe;

	private int cachedFoeDamage = -1;

	private int cachedFoeDistance = -9999;

	private int cachedFoeCount = -1;

	private int cachedFoeHitpoints = -1;

	private int cachedFoeMaxHitpoints = -1;

	private int cachedFoeArmor = -1;

	private string cachedPickup;

	private int cachedPickupDistance = -9999;

	private string cachedHarvest;

	private int cachedHarvestDistance = -9999;

	private int cachedPlayerBuffCount = -1;

	private string cachedPlayerBuffString;

	private int cachedPlayerDebuffCount = -1;

	private string cachedPlayerDebuffString;

	private int cachedFoeBuffCount = -1;

	private string cachedFoeBuffString;

	private int cachedFoeDebuffCount = -1;

	private string cachedFoeDebuffString;

	private int cachedFoeState = -2;

	private int cachedFoeStateTime = -1;

	private int cachedFoeLevel = -1;

	private string cachedFacialExpression;

	private HeroAI cachedHeroAi;

	private StringBuilder _stringBuilder = new StringBuilder(1024);

	private StonescriptStorage ssStorage;

	public bool bindToMindstone = true;

	public bool drawWhilePaused;

	private static readonly char[] SPACE_SPLIT = new char[1] { ' ' };

	private Dictionary<string, string[]> splitCache;

	private float secondsPerSound;

	private float lastSfxRealTime;

	private bool isStart;

	private bool isLoop;

	private static readonly char[] COMMA_SPLIT = new char[1] { ',' };

	private AsciiRenderProcedural rendererRef;

	private List<Character> advancedPrintCharacters = new List<Character>();

	private Dictionary<Character, List<AdvancedPrintCommand>> advancedPrintCharacterCommands = new Dictionary<Character, List<AdvancedPrintCommand>>();

	private List<AdvancedPrintCommand> advancedPrintBigHeadQueue = new List<AdvancedPrintCommand>();

	private List<object> queuedPrintCommands = new List<object>();

	private List<DrawBackgroundCommand> drawBackgroundQueue = new List<DrawBackgroundCommand>();

	private MindstoneInputProvider inputProvider;

	private bool inputIsUpdatePhase = true;

	private List<string> inputList = new List<string>();

	private string inputCache;

	private string clearString;

	private List<StonescriptResult> lastResults = new List<StonescriptResult>();

	private List<StonescriptResult> nonPrintResults = new List<StonescriptResult>();

	public StonescriptStorage Storage
	{
		get
		{
			return ssStorage;
		}
		set
		{
			ssStorage = value;
		}
	}

	public MindStoneGameModel()
	{
		Character.OnCharacterCleanedUp += HandleCharacterCleanup;
		BigHead.OnPostDraw = (Action<AsciiRenderProcedural, int, int>)Delegate.Combine(BigHead.OnPostDraw, new Action<AsciiRenderProcedural, int, int>(HandleBigHeadPostDraw));
	}

	~MindStoneGameModel()
	{
		CleanupInputProvider();
	}

	public void ClearCache()
	{
		cachedLocation = null;
		cachedFoe = null;
		cachedFoeDamage = -1;
		cachedFoeDistance = -9999;
		cachedFoeCount = -1;
		cachedFoeHitpoints = -1;
		cachedFoeMaxHitpoints = -1;
		cachedFoeArmor = -1;
		cachedPickup = null;
		cachedPickupDistance = -9999;
		cachedHarvest = null;
		cachedHarvestDistance = -9999;
		cachedPlayerBuffCount = -1;
		cachedPlayerBuffString = null;
		cachedPlayerDebuffCount = -1;
		cachedPlayerDebuffString = null;
		cachedFoeBuffCount = -1;
		cachedFoeBuffString = null;
		cachedFoeDebuffCount = -1;
		cachedFoeDebuffString = null;
		cachedFoeState = -2;
		cachedFoeStateTime = -1;
		cachedFoeLevel = -1;
		cachedFacialExpression = null;
		cachedHeroAi = null;
		ClearAdvancedPrint();
	}

	public void PrepareToRun()
	{
		ClearCache();
		ResetGameElements();
	}

	public override void HandleSimulationTic()
	{
		ClearCache();
	}

	public void ResetGameElements()
	{
		EnableGameElement("player");
		EnableGameElement("hud");
		EnableGameElement("pause");
		EnableGameElement("loadout print");
		EnableGameElement("level");
	}

	public override void Print(string str, Character character)
	{
		AdvancedPrintRelativeToCharacter(str, character);
	}

	public override void Print(string str)
	{
		if (str.Length >= 5 && str[0] == '(')
		{
			GameStates.Singleton.hero.bigHead.SetFacialExpression(str);
		}
		else if (str.Length >= 6 && str[0] == 'o' && ValidateAdvancedPrint(str))
		{
			AdvancedPrintRelativeToHero(str);
		}
		else if (str.Length >= 6 && str[0] == 'h' && ValidateAdvancedPrint(str))
		{
			AdvancedPrintRelativeToBigHead(str);
		}
		else if (str.Length >= 6 && str[0] == '`' && ValidateAdvancedPrint(str))
		{
			AdvancedPrintRelativeToUpperLeft(str);
		}
		else if (str.Length >= 6 && str[0] == 'c' && ValidateAdvancedPrint(str))
		{
			AdvancedPrintRelativeToCenter(str);
		}
		else if (str.Length >= 6 && str[0] == 'f' && ValidateAdvancedPrint(str))
		{
			AdvancedPrintRelativeToFoe(str);
		}
		else
		{
			GameplayActionMessages.SetMessage(str);
		}
	}

	public override void Error(string str)
	{
		Utils.LogError(str);
		str = " " + str + " ";
		GameplayActionMessages.SetMessage(str, ColorConstants.red);
		DiagnosticsUI.singleton.AddStonescriptError(str);
	}

	public override void Warn(string str)
	{
		Utils.LogWarning(str);
		str = " " + str + " ";
		GameplayActionMessages.SetMessage(str, ColorConstants.yellow);
		DiagnosticsUI.singleton.AddStonescriptWarning(str);
	}

	public override int GetApplicationState()
	{
		return GameStates.Singleton.GetStateNumericRepresentation();
	}

	public override object GetStateNumber(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for app.GetStateNumber function");
		}
		return GameStates.Singleton.GetStateNumericRepresentation((string)parameters[0]);
	}

	public override string GetCurrentLocation()
	{
		if (cachedLocation != null)
		{
			return cachedLocation;
		}
		cachedLocation = "";
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		if (questData != null && GameStates.Singleton.CurrentState >= GameStates.State.Playing)
		{
			cachedLocation = questData.id + " " + questData.name;
			int level = questData.level;
			if (level > 0)
			{
				cachedLocation = cachedLocation + " ☆" + level;
			}
			Data.Quest parentQuest = GameStates.Singleton.parentQuest;
			if (parentQuest != null)
			{
				cachedLocation = cachedLocation + " " + parentQuest.id + " " + parentQuest.name;
			}
		}
		return cachedLocation;
	}

	public override string GetCurrentLocationID()
	{
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		if (questData != null)
		{
			return questData.id;
		}
		return "";
	}

	public override string GetCurrentLocationName()
	{
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		if (questData != null)
		{
			return Te.xt(questData.name);
		}
		return "";
	}

	public override int GetCurrentLocationStars()
	{
		return GameStates.Singleton.level.QuestData?.level ?? 0;
	}

	public override int GetCurrentLocationBestTime()
	{
		return GetCurrentLocationStats()?.bestTime ?? (-1);
	}

	public override int GetCurrentLocationAverageTime()
	{
		Data.QuestStats currentLocationStats = GetCurrentLocationStats();
		if (currentLocationStats != null)
		{
			return Mathf.RoundToInt(currentLocationStats.averageTime.GetValue());
		}
		return -1;
	}

	private Data.QuestStats GetCurrentLocationStats()
	{
		string text = null;
		int difficulty = -1;
		Data.Quest parentQuest = GameStates.Singleton.parentQuest;
		if (parentQuest != null)
		{
			text = parentQuest.id;
			difficulty = parentQuest.level;
		}
		else
		{
			Data.Quest questData = GameStates.Singleton.level.QuestData;
			if (questData != null)
			{
				text = questData.id;
				difficulty = questData.level;
			}
		}
		if (text != null)
		{
			return OfflineFarmController.singleton.GetStatsForQuest(text, difficulty);
		}
		return null;
	}

	public override bool IsCurrentLocationCustomQuest()
	{
		return GameStates.Singleton.level.QuestData?.isCustomQuest ?? false;
	}

	public override int GetTime()
	{
		return GameStates.Singleton.level.gameTime;
	}

	public override int GetTotalTime()
	{
		return GameStates.Singleton.GetTotalTime();
	}

	private Enemy GetPrimaryFoe()
	{
		Enemy enemy = GameStates.Singleton.hero.GetComponent<HeroAI>().targetEnemy;
		if (enemy == null)
		{
			Hero hero = GameStates.Singleton.hero;
			List<Enemy> enemies = GameStates.Singleton.level.Enemies;
			int num = 999;
			for (int i = 0; i < enemies.Count; i++)
			{
				Enemy enemy2 = enemies[i];
				if (enemy2.CurrentState != Enemy.State.Dying && enemy2.CurrentState != Enemy.State.Sleeping)
				{
					if (enemy == null)
					{
						enemy = enemy2;
					}
					int num2 = enemy2.PositionX - hero.PositionX;
					if (num2 < num)
					{
						enemy = enemy2;
						num = num2;
					}
				}
			}
		}
		return enemy;
	}

	public override string GetFoe()
	{
		if (cachedFoe != null)
		{
			return cachedFoe;
		}
		cachedFoe = "";
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			cachedFoe = primaryFoe.id + " " + primaryFoe.displayName;
			for (int i = 0; i < primaryFoe.tags.Count; i++)
			{
				cachedFoe = cachedFoe + " " + primaryFoe.tags[i];
			}
			for (int j = 0; j < primaryFoe.immuneTo.Count; j++)
			{
				cachedFoe = cachedFoe + " immune_to_" + primaryFoe.immuneTo[j];
			}
		}
		return cachedFoe;
	}

	public override string GetFoeId()
	{
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			return primaryFoe.id;
		}
		return "";
	}

	public override string GetFoeName()
	{
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			return Te.xt(primaryFoe.displayName);
		}
		return "";
	}

	public override int GetFoeDamage()
	{
		if (cachedFoeDamage > 0)
		{
			return cachedFoeDamage;
		}
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe == null)
		{
			return -1;
		}
		if (primaryFoe.weapon == null)
		{
			return 0;
		}
		cachedFoeDamage = primaryFoe.weapon.baseDamage;
		if (primaryFoe.weapon.statModController != null)
		{
			Damage damage = new Damage();
			damage.amount = cachedFoeDamage;
			damage.Owner = primaryFoe;
			primaryFoe.weapon.statModController.ModDamage(damage, GameStates.Singleton.hero);
			cachedFoeDamage = damage.amount;
		}
		return cachedFoeDamage;
	}

	public override int GetFoeDistance()
	{
		if (cachedFoeDistance > -9999)
		{
			return cachedFoeDistance;
		}
		cachedFoeDistance = 9999;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			Hero hero = GameStates.Singleton.hero;
			cachedFoeDistance = primaryFoe.PositionX - hero.PositionX;
		}
		return cachedFoeDistance;
	}

	public override int GetFoeCount()
	{
		if (cachedFoeCount >= 0)
		{
			return cachedFoeCount;
		}
		cachedFoeCount = GetFoeCount(46);
		return cachedFoeCount;
	}

	public override object GetFoeCount(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for foe.GetCount function");
		}
		return GetFoeCount((int)parameters[0]);
	}

	private int GetFoeCount(int distanceThreshold)
	{
		int num = 0;
		Hero hero = GameStates.Singleton.hero;
		List<Enemy> enemies = GameStates.Singleton.level.Enemies;
		for (int i = 0; i < enemies.Count; i++)
		{
			Enemy enemy = enemies[i];
			if (enemy.CurrentState != Enemy.State.Dying)
			{
				int num2 = enemy.PositionX - hero.PositionX;
				if (num2 >= 0 && num2 <= distanceThreshold && distanceThreshold > 0)
				{
					num++;
				}
				else if (num2 <= 0 && num2 >= distanceThreshold && distanceThreshold < 0)
				{
					num++;
				}
			}
		}
		return num;
	}

	public override int GetFoeHitpoints()
	{
		if (cachedFoeHitpoints >= 0)
		{
			return cachedFoeHitpoints;
		}
		cachedFoeHitpoints = 0;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			cachedFoeHitpoints = primaryFoe.Hitpoints;
		}
		return cachedFoeHitpoints;
	}

	public override int GetFoeMaxHitpoints()
	{
		if (cachedFoeMaxHitpoints >= 0)
		{
			return cachedFoeMaxHitpoints;
		}
		cachedFoeMaxHitpoints = 0;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			cachedFoeMaxHitpoints = primaryFoe.MaxHitpoints;
		}
		return cachedFoeMaxHitpoints;
	}

	public override int GetFoeArmor()
	{
		if (cachedFoeArmor >= 0)
		{
			return cachedFoeArmor;
		}
		cachedFoeArmor = 0;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			cachedFoeArmor = Mathf.CeilToInt(primaryFoe.Armor);
		}
		return cachedFoeArmor;
	}

	public override int GetFoeMaxArmor()
	{
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			return Mathf.CeilToInt(primaryFoe.MaxArmor);
		}
		return 0;
	}

	public override string GetPickup()
	{
		if (cachedPickup != null)
		{
			return cachedPickup;
		}
		cachedPickup = "";
		Pickup targetPickup = GameStates.Singleton.hero.GetComponent<HeroAI>().targetPickup;
		if (targetPickup != null)
		{
			cachedPickup = targetPickup.displayName;
		}
		return cachedPickup;
	}

	public override int GetPickupDistance()
	{
		if (cachedPickupDistance > -9999)
		{
			return cachedPickupDistance;
		}
		cachedPickupDistance = 9999;
		Hero hero = GameStates.Singleton.hero;
		Pickup targetPickup = hero.GetComponent<HeroAI>().targetPickup;
		if (targetPickup != null)
		{
			cachedPickupDistance = targetPickup.PositionX - hero.PositionX;
		}
		return cachedPickupDistance;
	}

	public override string GetHarvest()
	{
		if (cachedHarvest != null)
		{
			return cachedHarvest;
		}
		cachedHarvest = "";
		HarvestableResource nearestHarvest = GameStates.Singleton.hero.GetComponent<HeroAI>().nearestHarvest;
		if (nearestHarvest != null)
		{
			cachedHarvest = nearestHarvest.character.displayName;
		}
		return cachedHarvest;
	}

	public override int GetHarvestDistance()
	{
		if (cachedHarvestDistance > -9999)
		{
			return cachedHarvestDistance;
		}
		cachedHarvestDistance = 9999;
		Hero hero = GameStates.Singleton.hero;
		HarvestableResource nearestHarvest = hero.GetComponent<HeroAI>().nearestHarvest;
		if (nearestHarvest != null)
		{
			cachedHarvestDistance = nearestHarvest.character.PositionX - hero.PositionX;
		}
		return cachedHarvestDistance;
	}

	public override int GetHitpoints()
	{
		return GameStates.Singleton.hero.Hitpoints;
	}

	public override int GetMaxHitpoints()
	{
		return GameStates.Singleton.hero.MaxHitpoints;
	}

	public override int GetArmor()
	{
		int num = Mathf.CeilToInt(GameStates.Singleton.hero.Armor);
		if (GetArmorFraction() > 0)
		{
			num--;
		}
		return num;
	}

	public override int GetArmorFraction()
	{
		return Mathf.CeilToInt(GameStates.Singleton.hero.Armor * 10f) % 10;
	}

	public override int GetMaxArmor()
	{
		int num = Mathf.CeilToInt(GameStates.Singleton.hero.MaxArmor);
		if (GetMaxArmorFraction() > 0)
		{
			num--;
		}
		return num;
	}

	public int GetMaxArmorFraction()
	{
		return Mathf.CeilToInt(GameStates.Singleton.hero.MaxArmor * 10f) % 10;
	}

	public override int GetPosX()
	{
		return GameStates.Singleton.hero.PositionX;
	}

	public override int GetPosY()
	{
		return GameStates.Singleton.hero.PositionY;
	}

	public override int GetPosZ()
	{
		return GameStates.Singleton.hero.PositionZ;
	}

	public override int GetPlayerBuffCount()
	{
		if (cachedPlayerBuffCount >= 0)
		{
			return cachedPlayerBuffCount;
		}
		cachedPlayerBuffCount = 0;
		Hero hero = GameStates.Singleton.hero;
		if (hero.statModController != null)
		{
			cachedPlayerBuffCount = CountDebuffs(hero.statModController.debuffs, isPositiveBuff: true);
		}
		return cachedPlayerBuffCount;
	}

	public override string GetPlayerBuffString()
	{
		if (cachedPlayerBuffString != null)
		{
			return cachedPlayerBuffString;
		}
		cachedPlayerBuffString = "";
		Hero hero = GameStates.Singleton.hero;
		if (hero.statModController != null)
		{
			cachedPlayerBuffString = BuildDebuffsString(hero.statModController.debuffs, isPositiveBuff: true);
		}
		return cachedPlayerBuffString;
	}

	public override string GetPlayerOldestBuff()
	{
		Hero hero = GameStates.Singleton.hero;
		if (hero.statModController != null)
		{
			return hero.statModController.GetOldestBuff().id;
		}
		return null;
	}

	public override int GetPlayerDebuffCount()
	{
		if (cachedPlayerDebuffCount >= 0)
		{
			return cachedPlayerDebuffCount;
		}
		cachedPlayerDebuffCount = 0;
		Hero hero = GameStates.Singleton.hero;
		if (hero.statModController != null)
		{
			cachedPlayerDebuffCount = CountDebuffs(hero.statModController.debuffs, isPositiveBuff: false);
		}
		return cachedPlayerDebuffCount;
	}

	public override string GetPlayerDebuffString()
	{
		if (cachedPlayerDebuffString != null)
		{
			return cachedPlayerDebuffString;
		}
		cachedPlayerDebuffString = "";
		Hero hero = GameStates.Singleton.hero;
		if (hero.statModController != null)
		{
			cachedPlayerDebuffString = BuildDebuffsString(hero.statModController.debuffs, isPositiveBuff: false);
		}
		return cachedPlayerDebuffString;
	}

	public override string GetPlayerOldestDebuff()
	{
		Hero hero = GameStates.Singleton.hero;
		if (hero.statModController != null)
		{
			return hero.statModController.GetOldestDebuff().id;
		}
		return null;
	}

	public override int GetFoeBuffCount()
	{
		if (cachedFoeBuffCount >= 0)
		{
			return cachedFoeBuffCount;
		}
		cachedFoeBuffCount = 0;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null && primaryFoe.statModController != null)
		{
			cachedFoeBuffCount = CountDebuffs(primaryFoe.statModController.debuffs, isPositiveBuff: true);
		}
		return cachedFoeBuffCount;
	}

	public override string GetFoeBuffString()
	{
		if (cachedFoeBuffString != null)
		{
			return cachedFoeBuffString;
		}
		cachedFoeBuffString = "";
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null && primaryFoe.statModController != null)
		{
			cachedFoeBuffString = BuildDebuffsString(primaryFoe.statModController.debuffs, isPositiveBuff: true);
		}
		return cachedFoeBuffString;
	}

	public override int GetFoeDebuffCount()
	{
		if (cachedFoeDebuffCount >= 0)
		{
			return cachedFoeDebuffCount;
		}
		cachedFoeDebuffCount = 0;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null && primaryFoe.statModController != null)
		{
			cachedFoeDebuffCount = CountDebuffs(primaryFoe.statModController.debuffs, isPositiveBuff: false);
		}
		return cachedFoeDebuffCount;
	}

	public override string GetFoeDebuffString()
	{
		if (cachedFoeDebuffString != null)
		{
			return cachedFoeDebuffString;
		}
		cachedFoeDebuffString = "";
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null && primaryFoe.statModController != null)
		{
			cachedFoeDebuffString = BuildDebuffsString(primaryFoe.statModController.debuffs, isPositiveBuff: false);
		}
		return cachedFoeDebuffString;
	}

	public override int GetFoeState()
	{
		if (cachedFoeState >= -1)
		{
			return cachedFoeState;
		}
		cachedFoeState = -1;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			cachedFoeState = primaryFoe.GetStateNumericRepresentation();
		}
		return cachedFoeState;
	}

	public override int GetFoeStateTime()
	{
		if (cachedFoeStateTime >= 0)
		{
			return cachedFoeStateTime;
		}
		cachedFoeStateTime = 0;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			cachedFoeStateTime = primaryFoe.GetStateTimeRepresentation();
		}
		return cachedFoeStateTime;
	}

	public override int GetFoeLevel()
	{
		if (cachedFoeLevel >= 0)
		{
			return cachedFoeLevel;
		}
		cachedFoeLevel = 0;
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			cachedFoeLevel = primaryFoe.level;
		}
		return cachedFoeLevel;
	}

	private int CountDebuffs(List<List<StatModifier>> debuffs, bool isPositiveBuff)
	{
		int num = 0;
		for (int i = 0; i < debuffs.Count; i++)
		{
			for (int j = 0; j < debuffs[i].Count; j++)
			{
				if (debuffs[i][j].isPositiveBuff == isPositiveBuff)
				{
					num++;
				}
			}
		}
		return num;
	}

	private string BuildDebuffsString(List<List<StatModifier>> debuffs, bool isPositiveBuff)
	{
		_stringBuilder.Length = 0;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			if (list.Count <= 0)
			{
				continue;
			}
			StatModifier statModifier = list[0];
			if (statModifier.isPositiveBuff != isPositiveBuff)
			{
				continue;
			}
			if (_stringBuilder.Length > 0)
			{
				_stringBuilder.Append(',');
			}
			char value = ((statModifier.customHudSymbol.Length <= 0) ? ItemData.CharForElement(statModifier.element) : statModifier.customHudSymbol[0]);
			_stringBuilder.Append(value);
			_stringBuilder.Append(':');
			_stringBuilder.Append(statModifier.id);
			_stringBuilder.Append(':');
			_stringBuilder.Append(list.Count);
			_stringBuilder.Append(':');
			int num = statModifier.GetRemainingTics();
			for (int j = 1; j < list.Count; j++)
			{
				statModifier = list[j];
				int remainingTics = statModifier.GetRemainingTics();
				if (remainingTics < num)
				{
					num = remainingTics;
				}
			}
			_stringBuilder.Append(num);
		}
		return _stringBuilder.ToString();
	}

	public override void Equip(string itemDescription)
	{
		if (!IsPlaying())
		{
			return;
		}
		itemDescription = TrimComment(itemDescription);
		Weapon weapon = Inventory.Singleton.FindBestWeapon(itemDescription, Weapon.HandType.LeftOrRight);
		if ((bool)weapon)
		{
			GameStates.Singleton.hero.Equip(weapon);
			GameStates.Singleton.abilityActivationHUD.UpdateContents();
			if (IsStartEvent() && GameStates.Singleton.level.loops == 0)
			{
				GameStates.Singleton.hero.ReplenishHitpoints();
			}
		}
		else
		{
			GameplayActionMessages.SetMessage(string.Format(Te.xt(" Mind Stone: Equipment '{0}' not found. "), itemDescription), Color.yellow);
		}
	}

	public override void EquipLeft(string itemDescription)
	{
		if (!IsPlaying())
		{
			return;
		}
		itemDescription = TrimComment(itemDescription);
		Weapon weapon = Inventory.Singleton.FindBestWeapon(itemDescription, Weapon.HandType.LeftOnly);
		if ((bool)weapon)
		{
			GameStates.Singleton.hero.EquipLeft(weapon);
			GameStates.Singleton.abilityActivationHUD.UpdateContents();
			if (IsStartEvent() && GameStates.Singleton.level.loops == 0)
			{
				GameStates.Singleton.hero.ReplenishHitpoints();
			}
		}
		else
		{
			GameplayActionMessages.SetMessage(string.Format(Te.xt(" Mind Stone: Equipment '{0}' not found for left hand. "), itemDescription), Color.yellow);
		}
	}

	public override void EquipRight(string itemDescription)
	{
		if (!IsPlaying())
		{
			return;
		}
		itemDescription = TrimComment(itemDescription);
		Weapon weapon = Inventory.Singleton.FindBestWeapon(itemDescription, Weapon.HandType.RightOnly);
		if ((bool)weapon)
		{
			GameStates.Singleton.hero.EquipRight(weapon);
			GameStates.Singleton.abilityActivationHUD.UpdateContents();
			if (IsStartEvent() && GameStates.Singleton.level.loops == 0)
			{
				GameStates.Singleton.hero.ReplenishHitpoints();
			}
		}
		else
		{
			GameplayActionMessages.SetMessage(string.Format(Te.xt(" Mind Stone: Equipment '{0}' not found for right hand. "), itemDescription), Color.yellow);
		}
	}

	public override void EquipFaerie(string itemDescription)
	{
		if (IsPlaying())
		{
			itemDescription = TrimComment(itemDescription);
			Utils.Log("EquipF \"" + itemDescription + "\"");
		}
	}

	public override void EquipLoadout(int loadoutNumber)
	{
		if (IsPlaying())
		{
			UtilityBeltKeyShortcuts.singleton.RecallLoadout(loadoutNumber);
		}
	}

	public override void ActivateAbility(string abilityId)
	{
		if (IsPlaying())
		{
			if (Compare(abilityId, "potion") || Compare(abilityId, "P"))
			{
				GameStates.Singleton.abilityActivationHUD.FirePotionActivated(withStonescript: true);
			}
			else if (Compare(abilityId, "left") || Compare(abilityId, "L"))
			{
				GameStates.Singleton.abilityActivationHUD.FireLeftItemActivated(withStonescript: true);
			}
			else if (Compare(abilityId, "right") || Compare(abilityId, "R"))
			{
				GameStates.Singleton.abilityActivationHUD.FireRightItemActivated(withStonescript: true);
			}
			else if (Compare(abilityId, "faerie") || Compare(abilityId, "F"))
			{
				GameStates.Singleton.abilityActivationHUD.FireFaerieItemActivated(withStonescript: true);
			}
			else
			{
				GameStates.Singleton.abilityActivationHUD.FireAbilityWithId(abilityId, withStonescript: true);
			}
		}
	}

	public static string TrimComment(string commandMessage)
	{
		int num = commandMessage.IndexOf("//");
		if (num > 0)
		{
			return commandMessage.Substring(0, num);
		}
		return commandMessage;
	}

	private bool IsPlaying()
	{
		return GameStates.Singleton.CurrentState == GameStates.State.Playing;
	}

	public override void EnableGameElement(string elementId)
	{
		if (Compare(elementId, "player"))
		{
			GameStates.Singleton.hero.renderingEnabled = true;
		}
		else if (elementId.StartsWith("hud", ignoreCase: true, CultureInfo.InvariantCulture))
		{
			if (elementId.Length > 3)
			{
				for (int i = 3; i < elementId.Length; i++)
				{
					switch (elementId[i])
					{
					case 'p':
						Hud.Enable(Hud.Flag.PLAYER);
						break;
					case 'f':
						Hud.Enable(Hud.Flag.FOE);
						break;
					case 'a':
						Hud.Enable(Hud.Flag.ABILITIES);
						break;
					case 'r':
						Hud.Enable(Hud.Flag.RESOURCES);
						break;
					case 'b':
						Hud.Enable(Hud.Flag.BANNER);
						break;
					case 'u':
						Hud.Enable(Hud.Flag.UTIL_BELT);
						break;
					}
				}
			}
			else
			{
				bool num = Hud.IsEnabled(Hud.Flag.PAUSE);
				Hud.EnableAll();
				if (!num)
				{
					Hud.Disable(Hud.Flag.PAUSE);
				}
			}
		}
		else if (Compare(elementId, "pause"))
		{
			Hud.Enable(Hud.Flag.PAUSE);
		}
		else if (Compare(elementId, "banner"))
		{
			GameStates.Singleton.bannerEnabled = true;
		}
		else if (Compare(elementId, "abilities"))
		{
			AbilityActivationHUD.activationFullDisable = false;
		}
		else if (Compare(elementId, "loadout input"))
		{
			UtilityBeltKeyShortcuts.singleton.inputEnabled = true;
		}
		else if (Compare(elementId, "loadout print"))
		{
			UtilityBeltKeyShortcuts.singleton.printEnabled = true;
		}
		else if (Compare(elementId, "level"))
		{
			GameStates.Singleton.level.EnableRendering = true;
		}
		else if (Compare(elementId, "mindstone"))
		{
			MindStoneController.singleton.mindstoneEnabledMasterSwitch = true;
		}
		else if (Compare(elementId, "moveSpeedBuffs"))
		{
			HeroAI.moveSpeedBuffsEnabled = true;
		}
	}

	public override void DisableGameElement(string elementId)
	{
		if (Compare(elementId, "player"))
		{
			GameStates.Singleton.hero.renderingEnabled = false;
		}
		else if (Compare(elementId, "hud"))
		{
			if (elementId.Length > 3)
			{
				for (int i = 3; i < elementId.Length; i++)
				{
					switch (elementId[i])
					{
					case 'p':
						Hud.Disable(Hud.Flag.PLAYER);
						break;
					case 'f':
						Hud.Disable(Hud.Flag.FOE);
						break;
					case 'a':
						Hud.Disable(Hud.Flag.ABILITIES);
						break;
					case 'r':
						Hud.Disable(Hud.Flag.RESOURCES);
						break;
					case 'b':
						Hud.Disable(Hud.Flag.BANNER);
						break;
					case 'u':
						Hud.Disable(Hud.Flag.UTIL_BELT);
						break;
					}
				}
			}
			else
			{
				bool num = Hud.IsEnabled(Hud.Flag.PAUSE);
				Hud.DisableAll();
				if (num)
				{
					Hud.Enable(Hud.Flag.PAUSE);
				}
			}
		}
		else if (Compare(elementId, "pause"))
		{
			Hud.Disable(Hud.Flag.PAUSE);
		}
		else if (Compare(elementId, "banner"))
		{
			GameStates.Singleton.bannerEnabled = false;
		}
		else if (Compare(elementId, "abilities"))
		{
			AbilityActivationHUD.activationFullDisable = true;
		}
		else if (Compare(elementId, "loadout input"))
		{
			UtilityBeltKeyShortcuts.singleton.inputEnabled = false;
		}
		else if (Compare(elementId, "loadout print"))
		{
			UtilityBeltKeyShortcuts.singleton.printEnabled = false;
		}
		else if (Compare(elementId, "level"))
		{
			GameStates.Singleton.level.EnableRendering = false;
		}
		else if (Compare(elementId, "mindstone"))
		{
			MindStoneController.singleton.mindstoneEnabledMasterSwitch = false;
		}
		else if (Compare(elementId, "moveSpeedBuffs"))
		{
			HeroAI.moveSpeedBuffsEnabled = false;
		}
	}

	private string[] CachedSplit(string str)
	{
		if (splitCache == null)
		{
			splitCache = new Dictionary<string, string[]>();
		}
		if (splitCache.ContainsKey(str))
		{
			return splitCache[str];
		}
		string[] array = str.Split(SPACE_SPLIT, StringSplitOptions.RemoveEmptyEntries);
		splitCache[str] = array;
		return array;
	}

	public override void PlaySound(string sfxId)
	{
		if (SfxController.singleton != null)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float num = realtimeSinceStartup - lastSfxRealTime;
			lastSfxRealTime = realtimeSinceStartup;
			secondsPerSound -= num;
			if (secondsPerSound < 0f)
			{
				secondsPerSound = 0f;
			}
			if (secondsPerSound < 1f)
			{
				PlaySoundParseOptions(sfxId);
				secondsPerSound += 0.2f;
			}
		}
	}

	public static void PlaySoundParseOptions(string sfxId)
	{
		string text = null;
		int num = sfxId.IndexOf(' ');
		if (num > 0)
		{
			text = sfxId.Substring(num + 1);
			sfxId = sfxId.Substring(0, num);
		}
		Sfx sfx = SfxController.singleton.Play(sfxId);
		if (!(sfx != null) || !(sfx.currentSfx != null))
		{
			return;
		}
		sfx.currentSfx.loop = false;
		if (text != null)
		{
			try
			{
				float pitch = (float)Utils.ParseInt(text) / 100f;
				sfx.SetPitch(pitch);
			}
			catch
			{
			}
		}
	}

	private bool Compare(string a, string b)
	{
		return CultureInfo.InvariantCulture.CompareInfo.IndexOf(a, b, CompareOptions.IgnoreCase) == 0;
	}

	public override string GetFacialExpression()
	{
		if (cachedFacialExpression != null)
		{
			return cachedFacialExpression;
		}
		cachedFacialExpression = GameStates.Singleton.hero.bigHead.GetFacialExpression();
		return cachedFacialExpression;
	}

	public override bool IsStartEvent()
	{
		return isStart;
	}

	public override void SetStartEvent(bool start = true)
	{
		isStart = start;
	}

	public override bool IsLoopEvent()
	{
		return isLoop;
	}

	public override void SetLoopEvent(bool loop = true)
	{
		isLoop = loop;
	}

	public override bool IsAiEnabled()
	{
		HeroAI heroAi = GetHeroAi();
		if (heroAi != null)
		{
			return heroAi.enabled;
		}
		return false;
	}

	public override bool IsAiPaused()
	{
		HeroAI heroAi = GetHeroAi();
		if (heroAi == null)
		{
			return false;
		}
		if (heroAi.remainingPause > 0f)
		{
			return true;
		}
		if (heroAi.targetWaypoint != null)
		{
			return GameStates.Singleton.hero.PositionX == heroAi.targetWaypoint.PositionX;
		}
		return false;
	}

	private HeroAI GetHeroAi()
	{
		if (cachedHeroAi == null)
		{
			cachedHeroAi = GameStates.Singleton.hero.GetComponent<HeroAI>();
		}
		return cachedHeroAi;
	}

	public override bool IsAiIdle()
	{
		return GameStates.Singleton.hero.CurrentState == Hero.State.Idle;
	}

	public override bool IsAiWalking()
	{
		return GameStates.Singleton.hero.CurrentState == Hero.State.Walking;
	}

	public override bool IsBigHead()
	{
		if (GameStates.Singleton.hero.bigHead.enabled)
		{
			return HeroSettings.bigHeadEnabled;
		}
		return false;
	}

	public override int GetResourceStone()
	{
		return (int)InventoryResources.singleton.GetResourceOfType(Data.Resource.Stone);
	}

	public override int GetResourceWood()
	{
		return (int)InventoryResources.singleton.GetResourceOfType(Data.Resource.Wood);
	}

	public override int GetResourceTar()
	{
		return (int)InventoryResources.singleton.GetResourceOfType(Data.Resource.Tar);
	}

	public override int GetResourceKi()
	{
		return (int)InventoryResources.singleton.GetResourceOfType(Data.Resource.Xi);
	}

	public override int GetResourceBronze()
	{
		return (int)InventoryResources.singleton.GetResourceOfType(Data.Resource.Bronze);
	}

	public override int GetKiCrystalCount()
	{
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("ki_crystal");
		if (firstItemWithId != null)
		{
			return firstItemWithId.count;
		}
		return 0;
	}

	public override int GetPlayerDirection()
	{
		if (GameStates.Singleton.hero.lookDirection == Character.LookDirection.Left)
		{
			return -1;
		}
		return 1;
	}

	public override string GetPlayerName()
	{
		if (HeroSettings.isNameSet)
		{
			return HeroSettings.name;
		}
		return "";
	}

	public override object ShowPlayerScaredFace(List<object> parameters, InvocationContext ctx)
	{
		float seeingBossTime = 2f;
		if (parameters.Count > 0 && parameters[0] is int)
		{
			seeingBossTime = (float)(int)parameters[0] / 30f;
		}
		BigHead.seeingBossTime = seeingBossTime;
		return null;
	}

	public override int GetTotalGearPoints()
	{
		return Inventory.Singleton.GetTotalGearPoints();
	}

	public bool HasItem(string item)
	{
		return false;
	}

	public override int GetScreenIndex()
	{
		Level level = GameStates.Singleton.level;
		if (level.QuestData != null && level.QuestData.sections != null)
		{
			return level.sectionIndex;
		}
		return 0;
	}

	public override int GetScreenPosX()
	{
		return GameStates.Singleton.level.gameCamera.PositionX;
	}

	public override int GetScreenWidth()
	{
		return GameStates.Singleton.asciiRenderer.width;
	}

	public override int GetScreenHeight()
	{
		return GameStates.Singleton.asciiRenderer.height;
	}

	public override object FromScreenToWorldX(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for screen.FromWorldX function");
		}
		int num = (int)parameters[0];
		GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		return num + gameCamera.PositionX - (asciiRenderer.width >> 1);
	}

	public override object FromScreenToWorldZ(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for screen.FromWorldZ function");
		}
		int num = (int)parameters[0];
		GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		return num + gameCamera.PositionZ - (asciiRenderer.height >> 1);
	}

	public override object FromWorldToScreenX(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for screen.ToWorldX function");
		}
		int num = (int)parameters[0];
		GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		return num - gameCamera.PositionX + (asciiRenderer.width >> 1);
	}

	public override object FromWorldToScreenZ(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for screen.ToWorldZ function");
		}
		int num = (int)parameters[0];
		GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		return num - gameCamera.PositionZ + (asciiRenderer.height >> 1);
	}

	public override object MoveCameraToNextScreen(List<object> parameters, InvocationContext ctx)
	{
		Level level = GameStates.Singleton.level;
		if (level.QuestData == null)
		{
			return null;
		}
		if (level.QuestData.sections == null)
		{
			return null;
		}
		GameCamera gameCamera = level.gameCamera;
		int destinationX = (level.sectionIndex + 1) * 69;
		gameCamera.SetupLerpToPos(destinationX, gameCamera.PositionY, gameCamera.PositionZ, 0.11f);
		return null;
	}

	public override object MoveCameraToPreviousScreen(List<object> parameters, InvocationContext ctx)
	{
		Level level = GameStates.Singleton.level;
		if (level.QuestData == null)
		{
			return null;
		}
		if (level.QuestData.sections == null)
		{
			return null;
		}
		GameCamera gameCamera = level.gameCamera;
		int destinationX = (level.sectionIndex - 1) * 69;
		gameCamera.SetupLerpToPos(destinationX, gameCamera.PositionY, gameCamera.PositionZ, 0.11f);
		return null;
	}

	public override object ResetCameraScreenOffset(List<object> parameters, InvocationContext ctx)
	{
		Level level = GameStates.Singleton.level;
		if (level.QuestData == null)
		{
			return null;
		}
		if (level.QuestData.sections == null)
		{
			return null;
		}
		GameCamera gameCamera = level.gameCamera;
		int destinationX = level.sectionIndex * 69;
		gameCamera.SetupLerpToPos(destinationX, gameCamera.PositionY, gameCamera.PositionZ, 0.11f);
		return null;
	}

	public override int GetRandom()
	{
		return UnityEngine.Random.Range(0, 9999);
	}

	public override int GetCursorX()
	{
		return AsciiMouse.singleton.x;
	}

	public override int GetCursorY()
	{
		return AsciiMouse.singleton.y;
	}

	private bool ValidateAdvancedPrint(string str)
	{
		if (str[2] != ',' && str[3] != ',')
		{
			return str[4] == ',';
		}
		return true;
	}

	private void AdvancedPrintRelativeToHero(string str)
	{
		Hero hero = GameStates.Singleton.hero;
		AdvancedPrintRelativeToCharacter(str, hero);
	}

	private void AdvancedPrintRelativeToBigHead(string str)
	{
		Hero hero = GameStates.Singleton.hero;
		AdvancedPrintCommand item = new AdvancedPrintCommand(str, hero.HeadPivotX, hero.HeadPivotY);
		advancedPrintBigHeadQueue.Add(item);
	}

	private void AdvancedPrintRelativeToUpperLeft(string str)
	{
		AdvancedPrintInternal(str, 0, 0);
	}

	private void AdvancedPrintRelativeToCenter(string str)
	{
		int x = GameStates.Singleton.asciiRenderer.width >> 1;
		int y = GameStates.Singleton.asciiRenderer.height >> 1;
		AdvancedPrintInternal(str, x, y);
	}

	private void AdvancedPrintRelativeToFoe(string str)
	{
		Enemy primaryFoe = GetPrimaryFoe();
		if (primaryFoe != null)
		{
			int x = primaryFoe.lastDrawX + primaryFoe.HeadPivotX;
			int y = primaryFoe.lastDrawY + primaryFoe.HeadPivotY;
			AdvancedPrintInternal(str, x, y);
		}
		else
		{
			GameplayActionMessages.SetMessage(str);
		}
	}

	private void AdvancedPrintRelativeToCharacter(string str, Character c)
	{
		List<AdvancedPrintCommand> list;
		if (advancedPrintCharacterCommands.ContainsKey(c))
		{
			list = advancedPrintCharacterCommands[c];
		}
		else
		{
			list = new List<AdvancedPrintCommand>();
			advancedPrintCharacterCommands.Add(c, list);
			advancedPrintCharacters.Add(c);
			c.OnPostDrawCharacter += HandlePostDrawCharacter;
		}
		AdvancedPrintCommand item = new AdvancedPrintCommand(str, c.HeadPivotX, c.HeadPivotY);
		list.Add(item);
	}

	private void HandleCharacterCleanup(Character c)
	{
		if (advancedPrintCharacterCommands.ContainsKey(c))
		{
			c.OnPostDrawCharacter -= HandlePostDrawCharacter;
			advancedPrintCharacters.Remove(c);
			advancedPrintCharacterCommands.Remove(c);
		}
	}

	private void HandleBigHeadPostDraw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		AdvancedPrintDrawQueue(advancedPrintBigHeadQueue, offsetX, offsetY);
	}

	private void HandlePostDrawCharacter(Character c, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		List<AdvancedPrintCommand> queue = advancedPrintCharacterCommands[c];
		AdvancedPrintDrawQueue(queue, offsetX, offsetY);
	}

	private void ClearAdvancedPrint()
	{
		for (int i = 0; i < advancedPrintCharacters.Count; i++)
		{
			Character key = advancedPrintCharacters[i];
			advancedPrintCharacterCommands[key].Clear();
		}
		advancedPrintBigHeadQueue.Clear();
		queuedPrintCommands.Clear();
		drawBackgroundQueue.Clear();
	}

	private void AdvancedPrintInternal(string str, int x, int y)
	{
		InitRendererRef();
		if (rendererRef == null)
		{
			GameplayActionMessages.SetMessage(str);
			return;
		}
		AdvancedPrintCommand advancedPrintCommand = new AdvancedPrintCommand(str, x, y);
		queuedPrintCommands.Add(advancedPrintCommand);
	}

	private void InitRendererRef()
	{
		if (rendererRef == null)
		{
			rendererRef = GameStates.Singleton.asciiRenderer;
			if (rendererRef != null)
			{
				rendererRef.AddPostEffect(this);
			}
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if ((drawWhilePaused || GameStates.Singleton.CurrentState == GameStates.State.Playing || GameStates.Singleton.CurrentState == GameStates.State.PlayPaused) && (!bindToMindstone || MindStoneController.singleton.enabled) && (!bindToMindstone || MindStoneController.singleton.mindstoneEnabledMasterSwitch))
		{
			AdvancedPrintDrawQueue(queuedPrintCommands, 0, 0);
			DrawBackgroundCommands();
		}
	}

	private void AdvancedPrintDrawQueue(List<object> queue, int offsetX, int offsetY)
	{
		if (bindToMindstone && !MindStoneController.singleton.mindstoneEnabledMasterSwitch)
		{
			return;
		}
		for (int i = 0; i < queue.Count; i++)
		{
			object obj = queue[i];
			if (obj is AdvancedPrintCommand command)
			{
				AdvancedPrintDrawQueue(command, offsetX, offsetY);
			}
			else if (obj is BoxDrawing.Command)
			{
				AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
				BoxDrawing.Command command2 = (BoxDrawing.Command)obj;
				BoxDrawing.Draw(asciiRenderer, command2);
			}
		}
	}

	private void AdvancedPrintDrawQueue(List<AdvancedPrintCommand> queue, int offsetX, int offsetY)
	{
		if (!bindToMindstone || MindStoneController.singleton.mindstoneEnabledMasterSwitch)
		{
			for (int i = 0; i < queue.Count; i++)
			{
				AdvancedPrintCommand command = queue[i];
				AdvancedPrintDrawQueue(command, offsetX, offsetY);
			}
		}
	}

	private void AdvancedPrintDrawQueue(AdvancedPrintCommand command, int offsetX, int offsetY)
	{
		if (command.command != null)
		{
			DrawOne(command.command, command.offsetX + offsetX, command.offsetY + offsetY);
		}
		else if (command.character != null)
		{
			AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
			GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
			int num = -gameCamera.PositionX + (asciiRenderer.width >> 1);
			int num2 = -gameCamera.PositionZ + gameCamera.PositionY + (asciiRenderer.height >> 1);
			num += command.offsetX;
			num2 += command.offsetY;
			command.character.Draw(asciiRenderer, num, num2);
			command.character.FireOnPostDraw(asciiRenderer, num, num2);
			asciiRenderer.ResetClip();
		}
	}

	private void DrawOne(string str, int x, int y)
	{
		int num = str.IndexOf(',', 2);
		int num2 = str.IndexOf(',', num + 1);
		int startIndex = num2 + 1;
		if (num2 < 0 || num2 == str.Length - 1)
		{
			GameplayActionMessages.SetMessage(str);
			return;
		}
		string str2 = str.Substring(1, num - 1);
		try
		{
			int num3 = Utils.ParseInt(str2);
			x += num3;
		}
		catch
		{
			GameplayActionMessages.SetMessage(str);
			return;
		}
		str2 = str.Substring(num + 1, num2 - num - 1);
		try
		{
			int num4 = Utils.ParseInt(str2);
			y += num4;
		}
		catch
		{
			GameplayActionMessages.SetMessage(str);
			return;
		}
		Color foreground = ColorConstants.white;
		bool flag = false;
		float num5 = 1f;
		if (str[num2 + 1] == '#')
		{
			int num6 = str.IndexOf(',', num2 + 1);
			if (num6 <= num2 + 9 && num6 > num2 + 4)
			{
				Color color = ColorConstants.white;
				string text = str.Substring(num2 + 1, num6 - num2 - 1);
				if (text.StartsWith("#rain"))
				{
					flag = true;
					if (text.Length == 7)
					{
						text = text.Substring(5, 2);
						Color color2 = default(Color);
						if (ColorUtility.TryParseHtmlString("#" + text + text + text, out color2))
						{
							num5 = color2.r;
						}
					}
				}
				else
				{
					color = Utils.ConvertColor(text);
				}
				if (color != ColorConstants.invalid)
				{
					startIndex = num6 + 1;
					foreground = color;
				}
			}
		}
		str = str.Substring(startIndex);
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		int num7 = x;
		for (int i = 0; i < str.Length; i++)
		{
			if (flag)
			{
				foreground = AsciiString.GetRainbowColor(i, str.Length) * num5;
			}
			char c = str[i];
			if (c == '\\' && i + 1 < str.Length && str[i + 1] == 'n')
			{
				num7 = x;
				y++;
				i++;
				continue;
			}
			switch (c)
			{
			case '\n':
				num7 = x;
				y++;
				continue;
			default:
			{
				int num8 = SpecialSymbols.Map(c);
				if (num8 >= 0)
				{
					asciiRenderer.SetCell(num7, y, num8, foreground);
				}
				else
				{
					asciiRenderer.SetCell(num7, y, c, foreground);
				}
				break;
			}
			case '#':
				break;
			}
			num7++;
		}
	}

	public void SetInputProvider(MindstoneInputProvider newProvider)
	{
		CleanupInputProvider();
		inputProvider = newProvider;
		MindstoneInputProvider mindstoneInputProvider = inputProvider;
		mindstoneInputProvider.OnPostUpdate = (Action)Delegate.Combine(mindstoneInputProvider.OnPostUpdate, new Action(HandleInputPostUpdate));
	}

	private void CleanupInputProvider()
	{
		if (inputProvider != null)
		{
			MindstoneInputProvider mindstoneInputProvider = inputProvider;
			mindstoneInputProvider.OnPostUpdate = (Action)Delegate.Remove(mindstoneInputProvider.OnPostUpdate, new Action(HandleInputPostUpdate));
			inputProvider = null;
		}
	}

	private void HandleInputPostUpdate()
	{
		if (GameStates.Singleton.CurrentState != GameStates.State.Playing)
		{
			inputProvider.Clear();
			return;
		}
		if (!inputIsUpdatePhase)
		{
			inputIsUpdatePhase = true;
			inputList.Clear();
			inputCache = null;
		}
		if (inputProvider.IsLeft())
		{
			inputList.Add("left");
		}
		if (inputProvider.IsLeftBegin())
		{
			inputList.Add("leftBegin");
		}
		if (inputProvider.IsLeftEnd())
		{
			inputList.Add("leftEnd");
		}
		if (inputProvider.IsRight())
		{
			inputList.Add("right");
		}
		if (inputProvider.IsRightBegin())
		{
			inputList.Add("rightBegin");
		}
		if (inputProvider.IsRightEnd())
		{
			inputList.Add("rightEnd");
		}
		if (inputProvider.IsUp())
		{
			inputList.Add("up");
		}
		if (inputProvider.IsUpBegin())
		{
			inputList.Add("upBegin");
		}
		if (inputProvider.IsUpEnd())
		{
			inputList.Add("upEnd");
		}
		if (inputProvider.IsDown())
		{
			inputList.Add("down");
		}
		if (inputProvider.IsDownBegin())
		{
			inputList.Add("downBegin");
		}
		if (inputProvider.IsDownEnd())
		{
			inputList.Add("downEnd");
		}
		if (inputProvider.IsPrimary())
		{
			inputList.Add("primary");
		}
		if (inputProvider.IsPrimaryBegin())
		{
			inputList.Add("primaryBegin");
		}
		if (inputProvider.IsPrimaryEnd())
		{
			inputList.Add("primaryEnd");
		}
		if (inputProvider.IsBack())
		{
			inputList.Add("back");
		}
		if (inputProvider.IsBackBegin())
		{
			inputList.Add("backBegin");
		}
		if (inputProvider.IsBackEnd())
		{
			inputList.Add("backEnd");
		}
		if (inputProvider.IsAbility1())
		{
			inputList.Add("ability1");
		}
		if (inputProvider.IsAbility1Begin())
		{
			inputList.Add("ability1Begin");
		}
		if (inputProvider.IsAbility1End())
		{
			inputList.Add("ability1End");
		}
		if (inputProvider.IsAbility2())
		{
			inputList.Add("ability2");
		}
		if (inputProvider.IsAbility2Begin())
		{
			inputList.Add("ability2Begin");
		}
		if (inputProvider.IsAbility2End())
		{
			inputList.Add("ability2End");
		}
		if (inputProvider.IsBumpLeft())
		{
			inputList.Add("bumpL");
		}
		if (inputProvider.IsBumpLeftBegin())
		{
			inputList.Add("bumpLBegin");
		}
		if (inputProvider.IsBumpLeftEnd())
		{
			inputList.Add("bumpLEnd");
		}
		if (inputProvider.IsBumpRight())
		{
			inputList.Add("bumpR");
		}
		if (inputProvider.IsBumpRightBegin())
		{
			inputList.Add("bumpRBegin");
		}
		if (inputProvider.IsBumpRightEnd())
		{
			inputList.Add("bumpREnd");
		}
	}

	public override string GetKeyInput()
	{
		if (inputIsUpdatePhase)
		{
			inputIsUpdatePhase = false;
			inputProvider.Clear();
			if (inputList.Count > 0)
			{
				inputCache = string.Join(" ", inputList.ToArray());
			}
			else
			{
				inputCache = " ";
			}
		}
		return inputCache;
	}

	public override object ClearScreen(List<object> parameters, InvocationContext ctx)
	{
		if (clearString == null)
		{
			int screenWidth = GetScreenWidth();
			int screenHeight = GetScreenHeight();
			StringBuilder stringBuilder = new StringBuilder((screenWidth + 1) * screenHeight + 14);
			stringBuilder.Append("`0,0,#000000,");
			for (int i = 0; i < screenHeight; i++)
			{
				for (int j = 0; j < screenWidth; j++)
				{
					stringBuilder.Append(" ");
				}
				stringBuilder.Append("\\n");
			}
			clearString = stringBuilder.ToString();
		}
		Print(clearString);
		return null;
	}

	public override object DrawHero(List<object> parameters, InvocationContext ctx)
	{
		InitRendererRef();
		int x = 0;
		int y = 0;
		if (parameters.Count == 2 && parameters[0] is int && parameters[1] is int)
		{
			x = (int)parameters[0];
			y = (int)parameters[1];
		}
		queuedPrintCommands.Add(new AdvancedPrintCommand(GameStates.Singleton.hero, x, y));
		return null;
	}

	public override object DrawBackground(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 3 || parameters.Count > 5 || !(parameters[0] is int) || !(parameters[1] is int) || !(parameters[2] is string) || (parameters.Count == 5 && (!(parameters[3] is int) || !(parameters[4] is int))))
		{
			throw new StonescriptRuntimeException("Invalid parameters for Bg function");
		}
		InitRendererRef();
		int x = (int)parameters[0];
		int y = (int)parameters[1];
		int w = 1;
		int h = 1;
		string colorStr = parameters[2] as string;
		if (parameters.Count == 5)
		{
			w = (int)parameters[3];
			h = (int)parameters[4];
		}
		Color c = Utils.ConvertColor(colorStr);
		DrawBackgroundCommand item = new DrawBackgroundCommand(x, y, w, h, c);
		drawBackgroundQueue.Add(item);
		return null;
	}

	public override object DrawBox(List<object> parameters, InvocationContext ctx)
	{
		if ((parameters.Count != 5 && parameters.Count != 6) || !(parameters[0] is int) || !(parameters[1] is int) || !(parameters[2] is int) || !(parameters[3] is int) || !(parameters[4] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for DrawBox function");
		}
		if (parameters.Count == 6 && !(parameters[5] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for DrawBox function");
		}
		InitRendererRef();
		int x = (int)parameters[0];
		int y = (int)parameters[1];
		int w = (int)parameters[2];
		int h = (int)parameters[3];
		string colorStr = parameters[4] as string;
		int style = 1;
		if (parameters.Count == 6)
		{
			style = (int)parameters[5];
		}
		Color c = Utils.ConvertColor(colorStr);
		BoxDrawing.Command command = new BoxDrawing.Command(x, y, w, h, c, style);
		queuedPrintCommands.Add(command);
		return null;
	}

	public override object DrawGetSymbol(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 2 || !(parameters[0] is int) || !(parameters[1] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for GetSymbol function");
		}
		int x = (int)parameters[0];
		int y = (int)parameters[1];
		AsciiCellProcedural cell = GameStates.Singleton.asciiRenderer.GetCell(x, y);
		if (cell != null)
		{
			char unicodeValue = cell.GetUnicodeValue();
			if (unicodeValue != 0)
			{
				return unicodeValue.ToString();
			}
			return SpecialSymbols.ReverseMap(cell.GetValue()).ToString();
		}
		return " ";
	}

	private void DrawBackgroundCommands()
	{
		for (int i = 0; i < drawBackgroundQueue.Count; i++)
		{
			DrawBackgroundCommand drawBackgroundCommand = drawBackgroundQueue[i];
			for (int j = 0; j < drawBackgroundCommand.w; j++)
			{
				int num = drawBackgroundCommand.x + j;
				for (int k = 0; k < drawBackgroundCommand.h; k++)
				{
					int num2 = drawBackgroundCommand.y + k;
					if (AsciiMouse.singleton.IsHidden() || AsciiMouse.singleton.x != num || AsciiMouse.singleton.y != num2)
					{
						GameStates.Singleton.asciiRenderer.GetCell(num, num2)?.SetBackground(drawBackgroundCommand.color);
					}
				}
			}
		}
	}

	public override object LeaveLocation(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.LeaveQuest();
		return null;
	}

	public override object PauseLocation(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.SchedulePause();
		return null;
	}

	public override object StorageGet(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || parameters.Count > 2)
		{
			throw new StonescriptRuntimeException("Invalid number of parameters for storage.Get");
		}
		string scriptName = ctx.ScriptName;
		string text = parameters[0] as string;
		object defaultValue = null;
		if (parameters.Count == 2)
		{
			defaultValue = parameters[1];
		}
		if (string.IsNullOrEmpty(scriptName) || string.IsNullOrEmpty(text))
		{
			throw new StonescriptRuntimeException("Null key for storage.Get");
		}
		return ssStorage.Get(scriptName, text, defaultValue);
	}

	public override object StorageSet(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 2)
		{
			throw new StonescriptRuntimeException("Invalid number of parameters for storage.Set");
		}
		string scriptName = ctx.ScriptName;
		string text = parameters[0] as string;
		object value = parameters[1];
		if (string.IsNullOrEmpty(scriptName) || string.IsNullOrEmpty(text))
		{
			throw new StonescriptRuntimeException("Null key for storage.Set");
		}
		ssStorage.Set(scriptName, text, value);
		return null;
	}

	public override object StorageExists(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1)
		{
			throw new StonescriptRuntimeException("Invalid number of parameters for storage.Exists");
		}
		string scriptName = ctx.ScriptName;
		string text = parameters[0] as string;
		if (string.IsNullOrEmpty(scriptName) || string.IsNullOrEmpty(text))
		{
			throw new StonescriptRuntimeException("Null key for storage.Exists");
		}
		return ssStorage.Exists(scriptName, text);
	}

	public override object StorageDelete(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1)
		{
			throw new StonescriptRuntimeException("Invalid number of parameters for storage.Delete");
		}
		string scriptName = ctx.ScriptName;
		string text = parameters[0] as string;
		if (string.IsNullOrEmpty(scriptName) || string.IsNullOrEmpty(text))
		{
			throw new StonescriptRuntimeException("Null key for storage.Delete");
		}
		ssStorage.Delete(scriptName, text);
		return null;
	}

	public override object StorageIncr(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || parameters.Count > 2)
		{
			throw new StonescriptRuntimeException("Invalid number of parameters for storage.Incr");
		}
		string scriptName = ctx.ScriptName;
		string key = parameters[0] as string;
		int amount = 1;
		if (parameters.Count == 2)
		{
			if (!(parameters[1] is int))
			{
				throw new StonescriptRuntimeException("storage.Incr amount must be an integer");
			}
			amount = (int)parameters[1];
		}
		return ssStorage.Increment(scriptName, key, amount);
	}

	public override object StorageKeys(List<object> parameters, InvocationContext ctx)
	{
		string scriptName = ctx.ScriptName;
		if (string.IsNullOrEmpty(scriptName))
		{
			throw new StonescriptRuntimeException("Null context for storage.Keys");
		}
		return new StonescriptArray(ssStorage.Keys(scriptName).ToArray());
	}

	public override object ItemCanActivate(List<object> parameters, InvocationContext ctx)
	{
		if (AbilityActivationHUD.IsDisabledState())
		{
			return false;
		}
		if (parameters.Count > 0)
		{
			if (!(parameters[0] is string))
			{
				throw new StonescriptRuntimeException("Invalid parameters for item.CanActivate function");
			}
			string abilityId = (string)parameters[0];
			if (!GameStates.Singleton.abilityActivationHUD.IsAbilityEnabled(abilityId))
			{
				return false;
			}
			if (AbilityClock.HasClockForAbility(abilityId))
			{
				AbilityClock clockForAbility = AbilityClock.GetClockForAbility(abilityId);
				return clockForAbility.elapsed >= clockForAbility.duration;
			}
		}
		return true;
	}

	public override object ItemGetCooldown(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for item.GetCooldown function");
		}
		string abilityId = (string)parameters[0];
		if (AbilityClock.HasClockForAbility(abilityId))
		{
			AbilityClock clockForAbility = AbilityClock.GetClockForAbility(abilityId);
			return clockForAbility.duration - clockForAbility.elapsed;
		}
		return -1;
	}

	public override object ItemGetCount(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Invalid parameters for item.GetCount function");
		}
		string criteria = (string)parameters[0];
		Weapon weapon = Inventory.Singleton.FindBestWeapon(criteria, Weapon.HandType.LeftOrRight);
		if ((bool)weapon)
		{
			if (weapon.isLost)
			{
				return weapon.lostCount;
			}
			return weapon.count;
		}
		return 0;
	}

	public override object LoadoutGetLeft(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for loadout.GetL function");
		}
		int bindingIndex = (int)parameters[0];
		UtilityBeltKeyShortcuts.Loadout loadout = UtilityBeltKeyShortcuts.singleton.GetLoadout(bindingIndex);
		if (loadout != null && !loadout.leftItemInvalid && loadout.leftHand != null)
		{
			return loadout.leftHand;
		}
		return "";
	}

	public override object LoadoutGetRight(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid parameters for loadout.GetR function");
		}
		int bindingIndex = (int)parameters[0];
		UtilityBeltKeyShortcuts.Loadout loadout = UtilityBeltKeyShortcuts.singleton.GetLoadout(bindingIndex);
		if (loadout != null && !loadout.rightItemInvalid && loadout.rightHand != null)
		{
			return loadout.rightHand;
		}
		return "";
	}

	public override object SummonGetCount()
	{
		return GameStates.Singleton.level.Summons.Count;
	}

	public override object SummonGetId(List<object> parameters, InvocationContext ctx)
	{
		Summon summon = _GetSummonFromParams(parameters, "summon.GetId");
		if (summon != null)
		{
			return summon.id;
		}
		return null;
	}

	public override object SummonGetName(List<object> parameters, InvocationContext ctx)
	{
		Summon summon = _GetSummonFromParams(parameters, "summon.GetName");
		if (summon != null)
		{
			return Te.xt(summon.displayName);
		}
		return null;
	}

	public override object SummonGetVar(List<object> parameters, InvocationContext ctx)
	{
		Summon summon = _GetSummonFromParams(parameters, "summon.GetVar");
		if (summon != null)
		{
			if (parameters.Count < 1 || !(parameters[0] is string))
			{
				throw new StonescriptRuntimeException("Invalid parameters for summon.GetVar function");
			}
			string propertyName = (string)parameters[0];
			return summon.GetCustomProperty(propertyName);
		}
		return null;
	}

	public override object SummonGetState(List<object> parameters, InvocationContext ctx)
	{
		Summon summon = _GetSummonFromParams(parameters, "summon.GetState");
		if (summon != null)
		{
			return summon.GetStateNumericRepresentation();
		}
		return -1;
	}

	public override object SummonGetTime(List<object> parameters, InvocationContext ctx)
	{
		Summon summon = _GetSummonFromParams(parameters, "summon.GetTime");
		if (summon != null)
		{
			return summon.GetStateTimeRepresentation();
		}
		return -1;
	}

	private Summon _GetSummonFromParams(List<object> parameters, string errorFuncName)
	{
		List<Summon> summons = GameStates.Singleton.level.Summons;
		if (summons.Count <= 0)
		{
			return null;
		}
		int num = 0;
		if (parameters.Count > 0)
		{
			int index = parameters.Count - 1;
			if (parameters[index] is int)
			{
				num = (int)parameters[index];
				if (num < 0 || num >= summons.Count)
				{
					return null;
				}
			}
		}
		return summons[num];
	}

	public override object ItemGetTreasureCount(List<object> parameters, InvocationContext ctx)
	{
		return Inventory.Singleton.GetTreasures().Count;
	}

	public override object ItemGetTreasureLimit(List<object> parameters, InvocationContext ctx)
	{
		return Inventory.Singleton.GetTreasurePickupLimit();
	}

	public override object ItemGetPotion()
	{
		Potion item = Potion.GetItem();
		if (item != null)
		{
			string text = item.displayName;
			if (Te.id != "EN")
			{
				text = text + " " + Te.xt(item.displayName);
			}
			if (item.autoRefill)
			{
				text += " auto";
			}
			return text;
		}
		return "";
	}

	public override object ItemGetLeft()
	{
		return ItemGetSearchDescription(GameStates.Singleton.hero.LeftHand);
	}

	public override object ItemGetRight()
	{
		return ItemGetSearchDescription(GameStates.Singleton.hero.RightHand);
	}

	private string ItemGetSearchDescription(Weapon weapon)
	{
		if (weapon != null)
		{
			Inventory.Singleton.CacheWeaponDescriptions();
			if (weapon.cachedSearchDescription != null)
			{
				return weapon.cachedSearchDescription;
			}
		}
		return "";
	}

	public override string ItemGetLeftId()
	{
		return ItemGetGroupId(GameStates.Singleton.hero.LeftHand);
	}

	public override string ItemGetRightId()
	{
		return ItemGetGroupId(GameStates.Singleton.hero.RightHand);
	}

	public override int ItemGetLeftState()
	{
		return ItemGetState(GameStates.Singleton.hero.LeftHand);
	}

	public override int ItemGetRightState()
	{
		return ItemGetState(GameStates.Singleton.hero.RightHand);
	}

	public override int ItemGetLeftTime()
	{
		return ItemGetTime(GameStates.Singleton.hero.LeftHand);
	}

	public override int ItemGetRightTime()
	{
		return ItemGetTime(GameStates.Singleton.hero.RightHand);
	}

	private string ItemGetGroupId(Weapon weapon)
	{
		if (weapon != null)
		{
			return weapon.GetGroupId();
		}
		return "";
	}

	private int ItemGetState(Weapon weapon)
	{
		if (weapon != null)
		{
			return (int)weapon.CurrentState;
		}
		return -1;
	}

	private int ItemGetTime(Weapon weapon)
	{
		if (weapon != null)
		{
			return weapon.StateElapsedTics;
		}
		return -1;
	}

	public override void Brew(string ingredients)
	{
		if (ingredients == "fire_elemental")
		{
			Potion item = Potion.GetItem();
			item.costs.Clear();
			item.Refill(Potion.Type.FireElemental);
		}
		else if (ingredients == "empty")
		{
			Potion item2 = Potion.GetItem();
			item2.costs.Clear();
			item2.Refill(Potion.Type.Empty);
		}
		else
		{
			if (!IsStartEvent() || GameStates.Singleton.level.loops != 0)
			{
				return;
			}
			Potion item3 = Potion.GetItem();
			if (!item3)
			{
				return;
			}
			string[] array = ingredients.Split(new char[1] { '+' });
			List<Data.Resource> list = new List<Data.Resource>();
			foreach (string text in array)
			{
				if (Compare(text.Trim(), Te.ToEnglish("Stone")))
				{
					list.Add(Data.Resource.Stone);
				}
				else if (Compare(text.Trim(), Te.ToEnglish("Wood")))
				{
					list.Add(Data.Resource.Wood);
				}
				else if (Compare(text.Trim(), Te.ToEnglish("Tar")))
				{
					list.Add(Data.Resource.Tar);
				}
				else if (Compare(text.Trim(), Te.ToEnglish("Bronze")))
				{
					list.Add(Data.Resource.Bronze);
				}
			}
			Potion.Type potionForResources = Potion.GetPotionForResources(list);
			if (potionForResources == Potion.Type.Empty || list.Count <= 0)
			{
				Error(" Invalid brew ingredients: " + ingredients + " ");
			}
			else
			{
				if (potionForResources == item3.type)
				{
					return;
				}
				if (CauldronScreen.singleton.CheckInterruption(potionForResources))
				{
					Error(Te.xt("tid_craft_interrupted"));
					return;
				}
				item3.costs.Clear();
				for (int j = 0; j < list.Count; j++)
				{
					Data.Resource resource = list[j];
					Data.Cost cost = new Data.Cost();
					cost.resource = resource;
					cost.amount = Mathf.CeilToInt(20f / (float)list.Count);
					item3.costs.Add(cost);
				}
				item3.Refill(potionForResources);
			}
		}
	}

	public void ClearResults()
	{
		lastResults.Clear();
		nonPrintResults.Clear();
	}

	public void ExecuteResults(List<StonescriptResult> results)
	{
		for (int i = 0; i < results.Count; i++)
		{
			StonescriptResult stonescriptResult = results[i];
			if (stonescriptResult.type == StonescriptResult.Type.Print)
			{
				Print(stonescriptResult.param);
			}
			else if (stonescriptResult.type == StonescriptResult.Type.PlaySound)
			{
				PlaySound(stonescriptResult.param);
			}
			else
			{
				nonPrintResults.Add(stonescriptResult);
			}
		}
		if (!StonescriptResult.CompareResults(nonPrintResults, lastResults))
		{
			for (int j = 0; j < lastResults.Count; j++)
			{
				StonescriptResult.Recycle(lastResults[j]);
			}
			lastResults.Clear();
			for (int k = 0; k < nonPrintResults.Count; k++)
			{
				StonescriptResult stonescriptResult2 = nonPrintResults[k];
				lastResults.Add(stonescriptResult2.Clone());
				if (stonescriptResult2.type == StonescriptResult.Type.Error)
				{
					Error(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.Warning)
				{
					Warn(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.Equip)
				{
					Equip(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.EquipLeft)
				{
					EquipLeft(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.EquipRight)
				{
					EquipRight(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.EquipFaerie)
				{
					EquipFaerie(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.EquipLoadout)
				{
					EquipLoadout(stonescriptResult2.paramInt);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.ActivateAbility)
				{
					ActivateAbility(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.EnableGameElement)
				{
					EnableGameElement(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.DisableGameElement)
				{
					DisableGameElement(stonescriptResult2.param);
				}
				else if (stonescriptResult2.type == StonescriptResult.Type.Brew)
				{
					Brew(stonescriptResult2.param);
				}
			}
		}
		nonPrintResults.Clear();
		for (int l = 0; l < results.Count; l++)
		{
			StonescriptResult.Recycle(results[l]);
		}
		results.Clear();
	}
}
