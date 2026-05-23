using System.Collections.Generic;
using Pathfinding.RVO;
using Rewired;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager instance;

	private PlayerInteraction playerInteraction;

	private DayNightCycle dayNightCycle;

	private TooltipManager tooltipManager;

	private TagManager tagManager;

	private EnemySpawner enemySpawner;

	private bool allowStartingTheNight = true;

	private static readonly string LOCIDENTIFIER = "Tutorial/";

	[SerializeField]
	private Transform arrowMarkerTransform;

	[SerializeField]
	private ScreenMarker arrowMarker;

	[SerializeField]
	private Transform player;

	[Header("When you're dead")]
	[SerializeField]
	private Hp playerHp;

	[Header("Movement Tutorial")]
	[SerializeField]
	private RVOController playerRvo;

	[SerializeField]
	private float requiredMoveDist;

	[SerializeField]
	private GameObject treasureChest;

	private bool playerHasLearnedHowToMove;

	private bool destroyedPracticeTargets;

	private bool playerDidSprint;

	private bool timeToShowSpecialAttackPrompt;

	[Header("Build Castle Center")]
	[SerializeField]
	private BuildingInteractor caslteBuildInteractor;

	private bool castleCenterBuilt;

	private bool mayShowEnemySpawn;

	[Header("Start The Night")]
	private bool firstNightStarted;

	[Header("First Night")]
	[SerializeField]
	private StabMA activeStabAttack;

	[Header("Build Houses")]
	[SerializeField]
	private List<BuildSlot> houses;

	private bool housesBuilt;

	[Header("Start The 2nd Night")]
	private bool secondNightStarted;

	[Header("2nd Night")]
	[Header("Collect Taxes")]
	[SerializeField]
	private List<BuildSlot> towers;

	private bool towersBuilt;

	private bool previewBuildingsUsed;

	[Header("Start The 3d Night")]
	private bool thirdNightStarted;

	[Header("Upgrade Castle Center")]
	[SerializeField]
	private BuildSlot caslteBuilSlot;

	[SerializeField]
	private GameObject royalTraining;

	[SerializeField]
	private GameObject buildersGuild;

	private bool castleCenterUpgraded;

	private bool fourthNightStarted;

	[Header("It's up to you!")]
	[SerializeField]
	private BuildSlot barracks;

	[SerializeField]
	private CommandUnits command;

	private float showCastleCenterTimer;

	private bool lockTargetTried;

	private int unitSelectionTutorialProgress;

	private List<TaggedObject> findTaggedObjects = new List<TaggedObject>();

	private List<TagManager.ETag> mustHaveTag = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveTag = new List<TagManager.ETag>();

	private Player input;

	private string tipHeader = "";

	private string tipBody = "";

	private bool localize;

	public static bool AllowStartingTheNight
	{
		get
		{
			if (!instance)
			{
				return true;
			}
			return instance.allowStartingTheNight;
		}
	}

	public bool MayShowEnemySpawn => mayShowEnemySpawn;

	private void SetArrowMarker(bool _enabled, Vector3 _pos, bool _offScreenOnly = false)
	{
		if ((bool)arrowMarker)
		{
			arrowMarkerTransform.gameObject.SetActive(_enabled);
			arrowMarkerTransform.position = _pos + Vector3.up * 10f;
			arrowMarker.showWhenOnScreen = !_offScreenOnly;
		}
	}

	private void MarkNearestObjectWithTag(TagManager.ETag _tag, bool _offScreenOnly = false)
	{
		findTaggedObjects.Clear();
		mustHaveTag.Clear();
		mayNotHaveTag.Clear();
		mustHaveTag.Add(_tag);
		TagManager.instance.FindAllTaggedObjectsWithTags(findTaggedObjects, mustHaveTag, mayNotHaveTag);
		if (findTaggedObjects.Count <= 0)
		{
			return;
		}
		TaggedObject taggedObject = null;
		float num = float.MaxValue;
		for (int i = 0; i < findTaggedObjects.Count; i++)
		{
			float magnitude = (player.transform.position - findTaggedObjects[i].transform.position).magnitude;
			if (magnitude < num)
			{
				num = magnitude;
				taggedObject = findTaggedObjects[i];
			}
		}
		SetArrowMarker(_enabled: true, taggedObject.transform.position, _offScreenOnly);
	}

	private void MarkNearestUnbuiltBuilding(List<BuildSlot> _buildSlots)
	{
		List<BuildSlot> list = new List<BuildSlot>(_buildSlots);
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (list[num].State == BuildSlot.BuildingState.Built)
			{
				list.RemoveAt(num);
			}
			else if (!list[num].gameObject.activeInHierarchy)
			{
				list.RemoveAt(num);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		BuildSlot buildSlot = null;
		float num2 = float.MaxValue;
		for (int i = 0; i < list.Count; i++)
		{
			float magnitude = (player.transform.position - list[i].transform.position).magnitude;
			if (magnitude < num2)
			{
				num2 = magnitude;
				buildSlot = list[i];
			}
		}
		SetArrowMarker(_enabled: true, buildSlot.transform.position);
	}

	private void MarkNearestGoldCoin()
	{
		List<Coin> freeCoins = TagManager.instance.freeCoins;
		if (freeCoins.Count <= 0)
		{
			return;
		}
		Coin coin = null;
		float num = float.MaxValue;
		for (int i = 0; i < freeCoins.Count; i++)
		{
			float magnitude = (player.transform.position - freeCoins[i].transform.position).magnitude;
			if (magnitude < num)
			{
				num = magnitude;
				coin = freeCoins[i];
			}
		}
		SetArrowMarker(_enabled: true, coin.transform.position);
	}

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		dayNightCycle = DayNightCycle.Instance;
		tooltipManager = TooltipManager.instance;
		tagManager = TagManager.instance;
		playerInteraction = PlayerInteraction.instance;
		enemySpawner = EnemySpawner.instance;
		treasureChest.SetActive(value: false);
		TreasureChestUIHelper.instance.overrideActiveState = false;
		input = ReInput.players.GetPlayer(0);
	}

	private void SetTutorialTipLocalize(string _tipHeader, string _tipBody)
	{
		tipHeader = _tipHeader;
		tipBody = _tipBody;
		localize = true;
	}

	private void SetTutorialTip(string _tipHeader, string _tipBody)
	{
		tipHeader = _tipHeader;
		tipBody = _tipBody;
		localize = false;
	}

	private void Update()
	{
		tipHeader = "";
		tipBody = "";
		SetArrowMarker(_enabled: false, Vector3.zero);
		tooltipManager.SetTutorialOverride("");
		tooltipManager.SetTutorialOverride("", _priorityText: false);
		TooltipManager.instance.hideAllTooltips = true;
		TutorialUpdate();
		if (localize)
		{
			TipManager.instance.UpdateTipLocalized(tipHeader, tipBody, isTutorial: true);
		}
		else
		{
			TipManager.instance.UpdateTipRaw(tipHeader, tipBody, isTutorial: true);
		}
	}

	private void OnDisable()
	{
		TooltipManager.instance.hideAllTooltips = false;
	}

	private void TutorialUpdate()
	{
		if (SceneTransitionManager.instance.SceneTransitionIsRunning)
		{
			return;
		}
		if (playerInteraction.Balance > 0 && !treasureChest.activeSelf)
		{
			treasureChest.SetActive(value: true);
			TreasureChestUIHelper.instance.overrideActiveState = true;
		}
		if (playerHp.KnockedOut)
		{
			SetTutorialTipLocalize("", "NewTutorial/dead");
			return;
		}
		if (!playerHasLearnedHowToMove)
		{
			MarkNearestObjectWithTag(TagManager.ETag.PracticeTargets);
			SetTutorialTipLocalize("NewTutorial/move", "");
			requiredMoveDist -= playerRvo.velocity.magnitude * Time.deltaTime;
			if (requiredMoveDist < 0f)
			{
				playerHasLearnedHowToMove = true;
			}
			return;
		}
		if (!destroyedPracticeTargets)
		{
			MarkNearestObjectWithTag(TagManager.ETag.PracticeTargets);
			if (tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.PracticeTargets) <= 0)
			{
				destroyedPracticeTargets = true;
			}
			return;
		}
		if (tagManager.freeCoins.Count > 0 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day && enemySpawner.Wavenumber == -1 && enemySpawner.Wavenumber <= 3)
		{
			MarkNearestGoldCoin();
			return;
		}
		if (!castleCenterBuilt)
		{
			if (PlayerManager.Instance.RegisteredPlayers[0].Sprinting)
			{
				playerDidSprint = true;
			}
			if (playerInteraction.FocussedInteractor != caslteBuildInteractor)
			{
				SetTutorialTipLocalize("NewTutorial/sprintA", "NewTutorial/sprintB");
				if (playerDidSprint)
				{
					SetArrowMarker(_enabled: true, caslteBuildInteractor.transform.position);
					SetTutorialTipLocalize("", "NewTutorial/sprintB");
				}
			}
			else
			{
				tooltipManager.SetTutorialOverrideToNone();
				SetTutorialTipLocalize("NewTutorial/build", "");
			}
			if (tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.Building) > 0)
			{
				castleCenterBuilt = true;
				mayShowEnemySpawn = true;
				enemySpawner.EnemySpawnersHornUnFocussed();
			}
			return;
		}
		if (playerInteraction.FocussedInteractor != null && playerInteraction.FocussedInteractor.GetType() == typeof(BuildingInteractor))
		{
			BuildingInteractor buildingInteractor = (BuildingInteractor)playerInteraction.FocussedInteractor;
			if (buildingInteractor.targetBuilding.CanBeUpgraded && playerInteraction.Balance + CostDisplay.currentlyFilledCoinsFromLastActiveDisplay < buildingInteractor.targetBuilding.NextUpgradeOrBuildCost && !buildingInteractor.UpgradeCueVisible)
			{
				if (buildingInteractor.targetBuilding.State == BuildSlot.BuildingState.Blueprint)
				{
					SetTutorialTipLocalize("", "NewTutorial/noGoldToBuild");
				}
				else if (buildingInteractor.targetBuilding.GetComponentInChildren<TaggedObject>().Tags.Contains(TagManager.ETag.CastleCenter))
				{
					tooltipManager.SetTutorialOverrideToNone();
					if (enemySpawner.Wavenumber == 2)
					{
						SetTutorialTipLocalize("", "");
					}
					else
					{
						SetTutorialTipLocalize("", "NewTutorial/castleCenter");
					}
				}
				else
				{
					SetTutorialTipLocalize("", "NewTutorial/noGoldToUpgrade");
				}
				return;
			}
		}
		if (!firstNightStarted)
		{
			SetTutorialTipLocalize("NewTutorial/callNight", "NewTutorial/enemiesAttack");
			if (dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
			{
				firstNightStarted = true;
			}
			return;
		}
		if (enemySpawner.Wavenumber == 0 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			if (TagManager.instance.CountAllTaggedObjectsWithTag(TagManager.ETag.EnemyOwned) <= 2 && enemySpawner.LastSpawnPeriodClock > 4.5f)
			{
				timeToShowSpecialAttackPrompt = true;
			}
			enemySpawner.InfinitelySpawning = activeStabAttack.TargetsStabeed < 3;
			MarkNearestObjectWithTag(TagManager.ETag.EnemyOwned, _offScreenOnly: true);
			allowStartingTheNight = false;
			if (timeToShowSpecialAttackPrompt)
			{
				if (activeStabAttack.TargetsStabeed < 3)
				{
					SetTutorialTip(TextTranslator.Translate("NewTutorial/attack"), "<style=highlighted>" + activeStabAttack.TargetsStabeed + "/3</style> " + TextTranslator.Translate("NewTutorial/attackCount"));
				}
				else
				{
					SetTutorialTipLocalize("", "NewTutorial/wellDone");
				}
			}
			return;
		}
		if (!housesBuilt && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			MarkNearestUnbuiltBuilding(houses);
			int num = tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.Building);
			int num2 = num - 1;
			SetTutorialTip("", TextTranslator.Translate("NewTutorial/buildHousesA") + "\n<style=highlighted>" + num2 + "/3 " + TextTranslator.Translate("NewTutorial/buildHousesB") + "</style>");
			if (playerInteraction.FocussedInteractor != null && playerInteraction.FocussedInteractor.GetType() == typeof(BuildingInteractor))
			{
				SetArrowMarker(_enabled: false, Vector3.zero);
				if (num2 == 0)
				{
					tooltipManager.SetTutorialOverrideToNone();
					SetTutorialTip(TextTranslator.Translate("NewTutorial/build"), TextTranslator.Translate("NewTutorial/buildHousesA") + "\n<style=highlighted>" + num2 + "/3 " + TextTranslator.Translate("NewTutorial/buildHousesB") + "</style>");
				}
			}
			if (num >= 4)
			{
				housesBuilt = true;
			}
			return;
		}
		if (!secondNightStarted && housesBuilt)
		{
			allowStartingTheNight = true;
			SetTutorialTipLocalize("", "NewTutorial/startNightAfterHouses");
			if (dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
			{
				secondNightStarted = true;
			}
			return;
		}
		if (enemySpawner.Wavenumber == 1 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			MarkNearestObjectWithTag(TagManager.ETag.EnemyOwned, _offScreenOnly: true);
			allowStartingTheNight = false;
			if (enemySpawner.LastSpawnPeriodClock > 4.5f)
			{
				SetTutorialTipLocalize("", "NewTutorial/rememberMeleeAttack");
			}
			return;
		}
		if (!towersBuilt && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			if (dayNightCycle.AfterSunrise)
			{
				MarkNearestUnbuiltBuilding(towers);
				if (playerInteraction.FocussedInteractor != null && playerInteraction.FocussedInteractor.GetType() == typeof(BuildingInteractor))
				{
					SetArrowMarker(_enabled: false, Vector3.zero);
				}
				int num3 = tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.Building) - 4;
				SetTutorialTip("", TextTranslator.Translate("NewTutorial/buildDefenses") + " <style=highlighted>(" + num3 + "/2)</style>");
				if (num3 >= 2)
				{
					towersBuilt = true;
				}
			}
			return;
		}
		if (!thirdNightStarted && towersBuilt)
		{
			allowStartingTheNight = true;
			SetTutorialTipLocalize("", "NewTutorial/defensesDone");
			if (dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
			{
				thirdNightStarted = true;
			}
			return;
		}
		if (ChoiceManager.instance.ChoiceCoroutineRunning)
		{
			showCastleCenterTimer = 0f;
			SetTutorialTipLocalize("", "NewTutorial/chooseAnUpgrade");
			return;
		}
		if (thirdNightStarted && !castleCenterUpgraded && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			allowStartingTheNight = false;
			if (!dayNightCycle.AfterSunrise)
			{
				return;
			}
			if (!(showCastleCenterTimer > 0.5f))
			{
				showCastleCenterTimer += Time.deltaTime;
				return;
			}
			if (playerInteraction.FocussedInteractor == caslteBuildInteractor)
			{
				SetTutorialTipLocalize("NewTutorial/howToUpgrade", "NewTutorial/letsUpgradeCastleCenter");
				return;
			}
			SetArrowMarker(_enabled: true, caslteBuildInteractor.transform.position);
			SetTutorialTipLocalize("", "NewTutorial/letsUpgradeCastleCenter");
			if (caslteBuilSlot.Level != 2)
			{
				return;
			}
			castleCenterUpgraded = true;
			allowStartingTheNight = true;
		}
		if (!fourthNightStarted && castleCenterUpgraded)
		{
			allowStartingTheNight = true;
			if (royalTraining.activeInHierarchy)
			{
				SetTutorialTipLocalize("", "NewTutorial/ccUpgrade1");
			}
			else if (buildersGuild.activeInHierarchy)
			{
				SetTutorialTipLocalize("", "NewTutorial/ccUpgrade2");
			}
			else
			{
				SetTutorialTipLocalize("", "NewTutorial/ccUpgrade3");
			}
			if (dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
			{
				fourthNightStarted = true;
			}
			return;
		}
		if (enemySpawner.Wavenumber == 3 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			allowStartingTheNight = false;
			return;
		}
		if (enemySpawner.Wavenumber >= 3)
		{
			TooltipManager.instance.hideAllTooltips = false;
		}
		if (barracks.State == BuildSlot.BuildingState.Built && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			if (!dayNightCycle.AfterSunrise)
			{
				return;
			}
			allowStartingTheNight = false;
			if (unitSelectionTutorialProgress == 0)
			{
				if (command.PlayerUnitsCommanding.Count <= 0 || input.GetButton("Command Units"))
				{
					SetTutorialTipLocalize("NewTutorial/unitCommandA", "NewTutorial/unitCommandB");
					return;
				}
				unitSelectionTutorialProgress++;
			}
			if (unitSelectionTutorialProgress == 1)
			{
				if (command.PlayerUnitsCommanding.Count > 0)
				{
					SetTutorialTipLocalize("NewTutorial/unitCommandC", "NewTutorial/unitCommandD");
					return;
				}
				unitSelectionTutorialProgress++;
			}
			if (unitSelectionTutorialProgress == 2)
			{
				if (command.PlayerUnitsCommanding.Count <= 0 || input.GetButton("Command Units"))
				{
					SetTutorialTipLocalize("NewTutorial/unitCommandE", "NewTutorial/unitCommandF");
					return;
				}
				unitSelectionTutorialProgress++;
			}
			if (unitSelectionTutorialProgress == 3)
			{
				if (command.PlayerUnitsCommanding.Count > 0)
				{
					SetTutorialTipLocalize("NewTutorial/unitCommandG", "NewTutorial/unitCommandH");
					return;
				}
				unitSelectionTutorialProgress++;
			}
			if (unitSelectionTutorialProgress == 4)
			{
				List<TaggedObject> list = new List<TaggedObject>();
				TagManager.instance.FindAllTaggedObjectsWithTag(list, TagManager.ETag.PlayerUnit);
				bool flag = false;
				foreach (TaggedObject item in list)
				{
					if (item.GetComponentInChildren<PathfindMovementPlayerunit>().HoldPosition)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					SetTutorialTipLocalize("", "NewTutorial/unitCommandI");
					return;
				}
				unitSelectionTutorialProgress++;
			}
			allowStartingTheNight = true;
		}
		if (enemySpawner.Wavenumber == 3 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			if (!dayNightCycle.AfterSunrise)
			{
				return;
			}
			allowStartingTheNight = true;
			if (!previewBuildingsUsed)
			{
				if (input.GetButtonDown("Preview Build Options"))
				{
					previewBuildingsUsed = true;
				}
				SetTutorialTipLocalize("NewTutorial/previewBuildOptionsA", "NewTutorial/previewBuildOptionsB");
				allowStartingTheNight = false;
			}
			else if (PlayerInteraction.instance.Balance > 1)
			{
				tooltipManager.SetTutorialOverride(TextTranslator.Translate("NewTutorial/upToYouNow"), _priorityText: false);
			}
			else
			{
				SetTutorialTipLocalize("", "NewTutorial/lateStartNightTip");
			}
			return;
		}
		if (enemySpawner.Wavenumber == 4 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			if (enemySpawner.LastSpawnPeriodClock > 4.5f)
			{
				SetTutorialTipLocalize("", "NewTutorial/healthRegen");
			}
			return;
		}
		allowStartingTheNight = false;
		if (enemySpawner.Wavenumber >= 4 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day && barracks.State != BuildSlot.BuildingState.Built && playerInteraction.Balance + CostDisplay.currentlyFilledCoinsFromLastActiveDisplay >= 4)
		{
			if (dayNightCycle.AfterSunrise)
			{
				SetTutorialTipLocalize("", "NewTutorial/buildBarracks");
				if (playerInteraction.FocussedInteractor == null)
				{
					SetArrowMarker(_enabled: true, barracks.transform.position + Vector3.up * 3f);
				}
			}
			return;
		}
		allowStartingTheNight = true;
		if (enemySpawner.Wavenumber == 6 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			tooltipManager.SetTutorialOverride(TextTranslator.Translate("NewTutorial/lastDay"), _priorityText: false);
		}
		else if (enemySpawner.Wavenumber == 7 && dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Night && !lockTargetTried)
		{
			if (input.GetButton("Lock Target"))
			{
				lockTargetTried = true;
			}
			if (enemySpawner.LastSpawnPeriodClock > 4.5f)
			{
				SetTutorialTipLocalize("NewTutorial/lockTarget", "");
			}
		}
	}
}
