using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class AfterTutorialTipManager : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public static AfterTutorialTipManager instance;

	[SerializeField]
	private float updateRate = 1.5f;

	private float nextUpdateIn = 3f;

	private Player input;

	private Coroutine tipCoroutine;

	private List<string> tipsShown = new List<string>();

	private TagManager tagManager;

	private PlayerInteraction playerInteraction;

	private DayNightCycle dayNightCycle;

	private EnemySpawner enemySpawner;

	private TipManager tipManager;

	private CommandUnits command;

	private bool coroutineRunning;

	private bool dontShowAnotherStartupTip;

	private bool dontShowAnotherUnitHotkeyTip;

	private List<TaggedObject> enemies;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		input = ReInput.players.GetPlayer(0);
		tipManager = TipManager.instance;
		tipManager.UpdateTipRaw("", "");
		tipsShown = LevelProgressManager.instance.tipsShown;
		tagManager = TagManager.instance;
		playerInteraction = PlayerInteraction.instance;
		dayNightCycle = DayNightCycle.Instance;
		enemySpawner = EnemySpawner.instance;
		command = CommandUnits.instance;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	private void OnDisable()
	{
		tipManager.UpdateTipRaw("", "");
		DayNightCycle.Instance.UnregisterDaytimeSensitiveObject(this);
	}

	private void Update()
	{
		if (!coroutineRunning)
		{
			nextUpdateIn -= Time.unscaledDeltaTime;
			if (nextUpdateIn <= 0f)
			{
				nextUpdateIn = updateRate;
				coroutineRunning = true;
				tipCoroutine = CheckForAvailableTips();
			}
		}
	}

	private Coroutine CheckForAvailableTips()
	{
		if (tipsShown.Count >= 14)
		{
			base.enabled = false;
			return null;
		}
		if (dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			if (!tipsShown.Contains("locktrg"))
			{
				enemies = tagManager.FindAllTaggedObjectsWithTagDirect_UseWithCare(TagManager.ETag.EnemyOwned);
				float num = 0f;
				foreach (TaggedObject enemy in enemies)
				{
					num = Mathf.Max(enemy.Hp.maxHp, num);
				}
				if (num >= 175f)
				{
					return StartCoroutine(DisplayUntilHotkeyTipNight("NewTutorial/tipLockTargetA", "NewTutorial/tipLockTargetB", "locktrg", "Lock Target"));
				}
			}
			coroutineRunning = false;
			return null;
		}
		if (tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.CastleCenter) >= 1 && enemySpawner.WaveBeforeFinalWaveComingUp(enemySpawner.Wavenumber) && !tipsShown.Contains("finale"))
		{
			return StartCoroutine(DisplayUntilBuild("", "NewTutorial/almostLastWave", "finale"));
		}
		if (enemySpawner.Wavenumber >= 2 && !tipsShown.Contains("edescri"))
		{
			bool flag = false;
			foreach (Spawn spawn in EnemySpawner.GetNextWave().spawns)
			{
				if (spawn == null || spawn.enemyPrefab == null)
				{
					continue;
				}
				TaggedObject component = spawn.enemyPrefab.GetComponent<TaggedObject>();
				if (!(component == null))
				{
					if (component.Tags.Contains(TagManager.ETag.Flying))
					{
						flag = true;
						break;
					}
					if (component.Tags.Contains(TagManager.ETag.Boss))
					{
						flag = true;
						break;
					}
					if (component.Tags.Contains(TagManager.ETag.FastMoving))
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				return StartCoroutine(DisplayUntilBuild("", "NewTutorial/getEnemyInfo", "edescri"));
			}
		}
		List<BuildSlot> isActivatorOf = CastleCenter.instance.GetComponentInParent<BuildSlot>().IsActivatorOf;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		for (int num2 = isActivatorOf.Count - 1; num2 >= 0; num2--)
		{
			BuildSlot buildSlot = isActivatorOf[num2];
			if (!(buildSlot == null))
			{
				string text = buildSlot.name;
				if (buildSlot.CanBeUpgraded && buildSlot.ActivatorLevel <= 0)
				{
					if (text.Contains("House"))
					{
						flag2 = true;
					}
					if (text.Contains("Mill"))
					{
						flag3 = true;
					}
					if (text.Contains("Mine Shaft"))
					{
						flag4 = true;
					}
					if (text.Contains("Defense Tower"))
					{
						flag5 = true;
					}
					if (text.Contains("Archer Hut") || text.Contains("Swordsmen Hut"))
					{
						flag6 = true;
					}
				}
			}
		}
		if (!dontShowAnotherStartupTip && enemySpawner.Wavenumber == -1 && tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.CastleCenter) >= 1)
		{
			dontShowAnotherStartupTip = true;
			if (!tipsShown.Contains("prev"))
			{
				return StartCoroutine(DisplayBuildOptionsTipDay());
			}
			if (!tipsShown.Contains("mines") && flag2 && flag4)
			{
				return StartCoroutine(DisplayUntilBuild("", "NewTutorial/goldMines", "mines"));
			}
			if (!tipsShown.Contains("sprnt"))
			{
				return StartCoroutine(DisplayToggleSprintTip());
			}
			if (!tipsShown.Contains("mills") && flag2 && flag3)
			{
				return StartCoroutine(DisplayUntilBuild("", "NewTutorial/mills", "mills"));
			}
			if (!tipsShown.Contains("towrs") && flag5 && flag6)
			{
				return StartCoroutine(DisplayUntilBuild("", "NewTutorial/towers", "towrs"));
			}
			if (!tipsShown.Contains("alone"))
			{
				return StartCoroutine(DisplayUntilBuild("", "NewTutorial/defendAlone", "alone"));
			}
		}
		if (enemySpawner.Wavenumber == 0 && tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.CastleCenter) >= 1 && !tipsShown.Contains("zoom"))
		{
			return StartCoroutine(DisplayUntilHotkeyTipDay("Controls/Zoom", "NewTutorial/tipZoom", "zoom", "Zoom"));
		}
		int num3 = tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.PlayerUnit, TagManager.ETag.MeeleFighter, TagManager.ETag.PlayerHeroUnit);
		int num4 = tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.PlayerUnit, TagManager.ETag.RangedFighter, TagManager.ETag.PlayerHeroUnit);
		int num5 = tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.PlayerHeroUnit);
		int num6 = tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.PlayerUnit);
		if (!dontShowAnotherUnitHotkeyTip && enemySpawner.Wavenumber > -1)
		{
			if (num6 >= 16 && !tipsShown.Contains("allarmy"))
			{
				dontShowAnotherUnitHotkeyTip = true;
				return StartCoroutine(DisplayUntilHotkeyTipDay("NewTutorial/selectArmyA", "NewTutorial/selectArmyB", "allarmy", "Select All Army"));
			}
			if (num3 >= 16 && num4 > 0 && !tipsShown.Contains("allmelee"))
			{
				dontShowAnotherUnitHotkeyTip = true;
				return StartCoroutine(DisplayUntilHotkeyTipDay("NewTutorial/selectMelee", "NewTutorial/selectArmyB", "allmelee", "Select All Melee"));
			}
			if (num4 >= 16 && num3 > 0 && !tipsShown.Contains("allranged"))
			{
				dontShowAnotherUnitHotkeyTip = true;
				return StartCoroutine(DisplayUntilHotkeyTipDay("NewTutorial/selectRanged", "NewTutorial/selectArmyB", "allranged", "Select All Ranged"));
			}
			if (num5 >= 1 && !tipsShown.Contains("allhero"))
			{
				dontShowAnotherUnitHotkeyTip = true;
				return StartCoroutine(DisplayUntilHotkeyTipDay("NewTutorial/selectHeroes", "NewTutorial/selectArmyB", "allhero", "Select All Heroes"));
			}
		}
		if (command.PlayerUnitsCommanding.Count > 2)
		{
			bool flag7 = false;
			bool flag8 = false;
			foreach (PathfindMovementPlayerunit item in command.PlayerUnitsCommanding)
			{
				List<TagManager.ETag> tags = item.GetComponent<TaggedObject>().Tags;
				if (tags.Contains(TagManager.ETag.MeeleFighter))
				{
					flag7 = true;
				}
				else if (tags.Contains(TagManager.ETag.RangedFighter))
				{
					flag8 = true;
				}
				if (flag7 && flag8)
				{
					break;
				}
			}
			if (flag8 && !flag7 && !tipsShown.Contains("holdp"))
			{
				return StartCoroutine(DisplayRangedHoldPositionTip());
			}
			if (flag8 && flag7 && !tipsShown.Contains("smrtc") && command.PlayerUnitsCommanding.Count >= 8)
			{
				return StartCoroutine(DisplaySmartCommandTip());
			}
		}
		coroutineRunning = false;
		return null;
	}

	private IEnumerator DisplayUntilHotkeyTipNight(string _keyA, string _keyB, string _tipKey, string _buttonKey)
	{
		tipManager.UpdateTipLocalized(_keyA, _keyB);
		while (!input.GetButton(_buttonKey) && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night && !LocalGamestate.Instance.PlayerFrozen)
		{
			yield return null;
		}
		if (input.GetButton(_buttonKey))
		{
			tipsShown.Add(_tipKey);
		}
		tipManager.UpdateTipLocalized("", "");
		coroutineRunning = false;
	}

	private IEnumerator DisplayUntilHotkeyTipDay(string _keyA, string _keyB, string _tipKey, string _buttonKey)
	{
		tipManager.UpdateTipLocalized(_keyA, _keyB);
		while (!input.GetButton(_buttonKey) && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day && !LocalGamestate.Instance.PlayerFrozen)
		{
			yield return null;
		}
		if (input.GetButton(_buttonKey))
		{
			tipsShown.Add(_tipKey);
		}
		tipManager.UpdateTipLocalized("", "");
		coroutineRunning = false;
	}

	public static void AddPostTutorialTipAsComplete(string _tipKey)
	{
		if ((bool)instance && !instance.tipsShown.Contains(_tipKey))
		{
			instance.tipsShown.Add(_tipKey);
		}
	}

	private IEnumerator DisplaySmartCommandTip()
	{
		tipManager.UpdateTipLocalized("NewTutorial/smartCommandA", "NewTutorial/smartCommandB");
		while (!input.GetButton("Smart Command Units") && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day && command.PlayerUnitsCommanding.Count >= 8 && !LocalGamestate.Instance.PlayerFrozen)
		{
			yield return null;
		}
		if (input.GetButton("Smart Command Units"))
		{
			tipsShown.Add("smrtc");
		}
		tipManager.UpdateTipLocalized("", "");
		coroutineRunning = false;
	}

	private IEnumerator DisplayRangedHoldPositionTip()
	{
		bool someHoldingPosition = false;
		while (!someHoldingPosition && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day && (command.PlayerUnitsCommanding.Count > 2 || input.GetButton("Command Units")) && !LocalGamestate.Instance.PlayerFrozen)
		{
			List<TaggedObject> list = new List<TaggedObject>();
			TagManager.instance.FindAllTaggedObjectsWithTag(list, TagManager.ETag.PlayerUnit);
			foreach (TaggedObject item in list)
			{
				if (item.GetComponentInChildren<PathfindMovementPlayerunit>().HoldPosition)
				{
					someHoldingPosition = true;
				}
			}
			tipManager.UpdateTipLocalized("NewTutorial/unitCommandG", "NewTutorial/holdArchersTip");
			yield return null;
		}
		if (someHoldingPosition)
		{
			tipsShown.Add("holdp");
		}
		tipManager.UpdateTipLocalized("", "");
		coroutineRunning = false;
	}

	private IEnumerator DisplayBuildOptionsTipDay()
	{
		tipManager.UpdateTipLocalized("NewTutorial/previewBuildOptionsA", "NewTutorial/previewBuildOptionsB");
		while (!input.GetButton("Preview Build Options") && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day && !LocalGamestate.Instance.PlayerFrozen)
		{
			yield return null;
		}
		if (input.GetButton("Preview Build Options"))
		{
			tipsShown.Add("prev");
		}
		tipManager.UpdateTipLocalized("", "");
		coroutineRunning = false;
	}

	private IEnumerator DisplayToggleSprintTip()
	{
		tipManager.UpdateTipLocalized("NewTutorial/toggsprintA", "NewTutorial/toggsprintB");
		while (!input.GetButton("Sprint Toggle") && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day && !LocalGamestate.Instance.PlayerFrozen)
		{
			yield return null;
		}
		if (input.GetButton("Sprint Toggle"))
		{
			tipsShown.Add("sprnt");
		}
		tipManager.UpdateTipLocalized("", "");
		coroutineRunning = false;
	}

	private IEnumerator DisplayUntilBuild(string keyA, string keyB, string tipKey)
	{
		tipManager.UpdateTipLocalized(keyA, keyB);
		int buildingsCount = tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.Building);
		while (buildingsCount == tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.Building) && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day && !LocalGamestate.Instance.PlayerFrozen)
		{
			yield return null;
		}
		tipsShown.Add(tipKey);
		tipManager.UpdateTipLocalized("", "");
		coroutineRunning = false;
	}

	public void OnDuskEarly()
	{
	}

	public void OnDusk()
	{
		SaveLoadManager.instance.SaveGame();
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}
}
