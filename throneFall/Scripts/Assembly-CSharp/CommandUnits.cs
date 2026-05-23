using System.Collections.Generic;
using Pathfinding;
using Rewired;
using UnityEngine;

public class CommandUnits : MonoBehaviour
{
	public static CommandUnits instance;

	public UnitCommandRadiusAnimation rangeIndicator;

	public GameObject commandingIndicator;

	public ParticleSystem dropWaypointFx;

	public int drowWaypointParticleCount = 100;

	public float attractRange;

	public string graphNameOfPlayerUnits;

	public string graphNameOfFlyingUnits;

	public float unitDistanceFromEachOther = 2f;

	public float unitDistanceMoveStep = 0.5f;

	public int maxPositioningRepeats = 5;

	public float holdToHoldPositionTime = 1f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float commanderUnitMoveSpeedMulti = 1.6f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float commanderHoldHealthMulti = 1.2f;

	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	public float commanderHoldDamageMulti = 1.2f;

	private ThronefallAudioManager audioManager;

	private AudioSet audioSet;

	private NNConstraint nearestConstraint = new NNConstraint();

	private NNConstraint nearestConstraintAir = new NNConstraint();

	private List<PathfindMovementPlayerunit> playerUnitsCommanding = new List<PathfindMovementPlayerunit>();

	private List<PathfindMovementPlayerunit> playerUnitsCommandingBuffer = new List<PathfindMovementPlayerunit>();

	private Player input;

	[HideInInspector]
	public bool commanding;

	private TagManager tagManager;

	private AstarPath astarPath;

	private PlayerUpgradeManager playerUPgradeManager;

	private Hp hpPlayer;

	private float timeSincePlace;

	private bool switchedToHold;

	private List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	private List<TaggedObject> results = new List<TaggedObject>();

	private bool commandUnitsToggledOn;

	[SerializeField]
	private bool canCommandUnitsInThisMode = true;

	private float royalProtectionHealthMulti = 1f;

	private bool royalProtectionEquipped;

	private bool rangeIndicatorActive;

	private bool commandUnitsButtonLast;

	private List<PathfindMovementPlayerunit> toBePlaced = new List<PathfindMovementPlayerunit>();

	private List<AutoAttack> autoAttacksToEnable = new List<AutoAttack>();

	public bool ShouldShowUnitTypes
	{
		get
		{
			if (!rangeIndicator.Active)
			{
				return commandingIndicator.activeSelf;
			}
			return true;
		}
	}

	public List<PathfindMovementPlayerunit> PlayerUnitsCommanding => playerUnitsCommanding;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		audioManager = ThronefallAudioManager.Instance;
		audioSet = audioManager.audioContent;
		input = ReInput.players.GetPlayer(0);
		tagManager = TagManager.instance;
		astarPath = AstarPath.active;
		nearestConstraint.graphMask = GraphMask.FromGraphName(graphNameOfPlayerUnits);
		nearestConstraintAir.graphMask = GraphMask.FromGraphName(graphNameOfFlyingUnits);
		playerUPgradeManager = PlayerUpgradeManager.instance;
		hpPlayer = GetComponent<Hp>();
		UnitProductionSelector.Clear();
		royalProtectionEquipped = PerkManager.instance.RoyalProtectionEquipped;
		royalProtectionHealthMulti = 1f / PerkManager.instance.royalProtectionDamageTakenMultiplyer;
	}

	private void Update()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		float distanceFromCollider;
		UnitProductionSelector standingInSelectRangeOf = UnitProductionSelector.FindClosestToPoint(base.transform.position, out distanceFromCollider);
		if (distanceFromCollider > 4f)
		{
			standingInSelectRangeOf = null;
		}
		if (input.GetButtonDown("Command Units Toggle"))
		{
			commandUnitsToggledOn = !commandUnitsToggledOn;
		}
		bool button = input.GetButton("Command Units");
		if (button)
		{
			commandUnitsToggledOn = false;
		}
		bool button2 = input.GetButton("Smart Command Units");
		bool flag = button || button2 || commandUnitsToggledOn;
		bool flag2 = flag && !commandUnitsButtonLast;
		bool flag3 = !flag && commandUnitsButtonLast;
		commandUnitsButtonLast = flag;
		bool selectButtonPressed = flag;
		if (!LocalGamestate.Instance.PlayerFrozen)
		{
			if (input.GetButtonDown("Select All Army") && hpPlayer.HpValue > 0f)
			{
				mustHaveTags.Clear();
				mayNotHaveTags.Clear();
				mustHaveTags.Add(TagManager.ETag.PlayerUnit);
				TagManager.instance.FindAllTaggedObjectsWithTags(results, mustHaveTags, mayNotHaveTags);
				TryToSelectUnits(results);
				AfterTutorialTipManager.AddPostTutorialTipAsComplete("allarmy");
			}
			if (input.GetButtonDown("Select All Melee") && hpPlayer.HpValue > 0f)
			{
				mustHaveTags.Clear();
				mayNotHaveTags.Clear();
				mustHaveTags.Add(TagManager.ETag.PlayerUnit);
				mustHaveTags.Add(TagManager.ETag.MeeleFighter);
				mayNotHaveTags.Add(TagManager.ETag.PlayerHeroUnit);
				TagManager.instance.FindAllTaggedObjectsWithTags(results, mustHaveTags, mayNotHaveTags);
				TryToSelectUnits(results);
				AfterTutorialTipManager.AddPostTutorialTipAsComplete("allmelee");
			}
			if (input.GetButtonDown("Select All Ranged") && hpPlayer.HpValue > 0f)
			{
				mustHaveTags.Clear();
				mayNotHaveTags.Clear();
				mustHaveTags.Add(TagManager.ETag.PlayerUnit);
				mustHaveTags.Add(TagManager.ETag.RangedFighter);
				mayNotHaveTags.Add(TagManager.ETag.PlayerHeroUnit);
				TagManager.instance.FindAllTaggedObjectsWithTags(results, mustHaveTags, mayNotHaveTags);
				TryToSelectUnits(results);
				AfterTutorialTipManager.AddPostTutorialTipAsComplete("allranged");
			}
			if (input.GetButtonDown("Select All Heroes") && hpPlayer.HpValue > 0f)
			{
				mustHaveTags.Clear();
				mayNotHaveTags.Clear();
				mustHaveTags.Add(TagManager.ETag.PlayerUnit);
				mustHaveTags.Add(TagManager.ETag.PlayerHeroUnit);
				TagManager.instance.FindAllTaggedObjectsWithTags(results, mustHaveTags, mayNotHaveTags);
				TryToSelectUnits(results);
				AfterTutorialTipManager.AddPostTutorialTipAsComplete("allhero");
			}
		}
		if (!commanding)
		{
			if (flag2 && hpPlayer.HpValue > 0f)
			{
				rangeIndicator.Activate();
				rangeIndicatorActive = true;
			}
			if (flag && hpPlayer.HpValue > 0f)
			{
				foreach (TaggedObject playerUnit in TagManager.instance.PlayerUnits)
				{
					if (tagManager.MeasureDistanceToTaggedObject(playerUnit, base.transform.position) <= attractRange)
					{
						OnUnitAdd(playerUnit, button2);
					}
					else if (playerUnit.Tags.Contains(TagManager.ETag.Flying) && (new Vector2(base.transform.position.x, base.transform.position.z) - new Vector2(playerUnit.transform.position.x, playerUnit.transform.position.z)).magnitude <= attractRange)
					{
						OnUnitAdd(playerUnit, button2);
					}
				}
			}
			else if (playerUnitsCommanding.Count > 0)
			{
				commanding = true;
			}
		}
		else
		{
			if (flag2 || hpPlayer.HpValue <= 0f)
			{
				PlaceCommandedUnitsAndCalculateTargetPositions(button2);
				timeSincePlace = 0f;
				switchedToHold = false;
			}
			if (flag && hpPlayer.HpValue > 0f)
			{
				timeSincePlace += Time.deltaTime;
				if (timeSincePlace > holdToHoldPositionTime && !switchedToHold)
				{
					switchedToHold = true;
					MakeUnitsInBufferHoldPosition();
				}
			}
			if (flag3 || hpPlayer.HpValue <= 0f)
			{
				commanding = false;
				timeSincePlace = 0f;
			}
		}
		for (int num = playerUnitsCommanding.Count - 1; num >= 0; num--)
		{
			PathfindMovementPlayerunit pathfindMovementPlayerunit = playerUnitsCommanding[num];
			pathfindMovementPlayerunit.HomePosition = base.transform.position;
			if (!pathfindMovementPlayerunit.enabled)
			{
				playerUnitsCommanding.RemoveAt(num);
				OnUnitRemove(pathfindMovementPlayerunit);
			}
		}
		if (playerUnitsCommanding.Count > 0 && !flag)
		{
			commandingIndicator.SetActive(value: true);
		}
		else
		{
			commandingIndicator.SetActive(value: false);
		}
		if (!flag && rangeIndicator.Active)
		{
			rangeIndicator.Deactivate();
			rangeIndicatorActive = false;
		}
		if (commanding)
		{
			standingInSelectRangeOf = null;
			selectButtonPressed = false;
		}
		UnitProductionSelector.CustomUpdate(standingInSelectRangeOf, selectButtonPressed, button2);
	}

	public void MakeUnitsInBufferHoldPosition()
	{
		if (playerUnitsCommandingBuffer.Count > 0)
		{
			audioManager.PlaySoundAsOneShot(audioSet.HoldPosition, 0.45f, 0.9f + Random.value * 0.2f, audioManager.mgSFX, 10);
		}
		foreach (PathfindMovementPlayerunit item in playerUnitsCommandingBuffer)
		{
			item.HoldPosition = true;
		}
	}

	public void ForceCommandingEnd()
	{
		if (commanding)
		{
			PlaceCommandedUnitsAndCalculateTargetPositions(_smartCommand: false);
		}
	}

	public void PlaceCommandedUnitsAndCalculateTargetPositions(bool _smartCommand)
	{
		if (!commanding || playerUnitsCommanding.Count <= 0)
		{
			return;
		}
		commandUnitsToggledOn = false;
		audioManager.PlaySoundAsOneShot(audioSet.PlaceCommandingUnits, 0.35f, 0.9f + Random.value * 0.2f, audioManager.mgSFX, 10);
		dropWaypointFx.Emit(drowWaypointParticleCount);
		string text = playerUnitsCommanding[0].name;
		toBePlaced.Clear();
		foreach (PathfindMovementPlayerunit item in playerUnitsCommanding)
		{
			if (!_smartCommand || item.name == text)
			{
				toBePlaced.Add(item);
			}
		}
		foreach (PathfindMovementPlayerunit item2 in toBePlaced)
		{
			OnUnitRemove(item2);
			playerUnitsCommanding.Remove(item2);
		}
		for (int num = autoAttacksToEnable.Count - 1; num >= 0; num--)
		{
			AutoAttack autoAttack = autoAttacksToEnable[num];
			if (autoAttack != null && (!_smartCommand || autoAttack.gameObject.name == text) && autoAttack.GetComponent<Hp>().HpValue > 0f)
			{
				autoAttack.enabled = true;
				autoAttacksToEnable.RemoveAt(num);
			}
		}
		for (int i = 0; i < toBePlaced.Count; i++)
		{
			PathfindMovementPlayerunit pathfindMovementPlayerunit = toBePlaced[i];
			Vector3 vector = Quaternion.AngleAxis((float)(i / toBePlaced.Count) * 360f, Vector3.up) * Vector3.right * unitDistanceMoveStep;
			pathfindMovementPlayerunit.HomePosition = astarPath.GetNearest(base.transform.position + vector + new Vector3(Random.value - 0.5f, 0f, Random.value - 0.5f) * unitDistanceMoveStep * 0.1f, pathfindMovementPlayerunit.Flying ? nearestConstraintAir : nearestConstraint).position;
		}
		for (int j = 0; j < maxPositioningRepeats; j++)
		{
			bool flag = false;
			for (int k = 0; k < toBePlaced.Count; k++)
			{
				PathfindMovementPlayerunit pathfindMovementPlayerunit2 = toBePlaced[k];
				for (int l = k + 1; l < toBePlaced.Count; l++)
				{
					PathfindMovementPlayerunit pathfindMovementPlayerunit3 = toBePlaced[l];
					if (!((pathfindMovementPlayerunit2.HomePosition - pathfindMovementPlayerunit3.HomePosition).magnitude > unitDistanceFromEachOther))
					{
						Vector3 vector2 = (pathfindMovementPlayerunit2.HomePosition - pathfindMovementPlayerunit3.HomePosition).normalized * unitDistanceMoveStep;
						pathfindMovementPlayerunit2.HomePosition = astarPath.GetNearest(pathfindMovementPlayerunit2.HomePosition + vector2, pathfindMovementPlayerunit2.Flying ? nearestConstraintAir : nearestConstraint).position;
						pathfindMovementPlayerunit3.HomePosition = astarPath.GetNearest(pathfindMovementPlayerunit3.HomePosition - vector2, pathfindMovementPlayerunit3.Flying ? nearestConstraintAir : nearestConstraint).position;
						flag = true;
					}
				}
			}
			if (!flag)
			{
				break;
			}
		}
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			foreach (PathfindMovementPlayerunit item3 in toBePlaced)
			{
				item3.transform.position = item3.HomePosition;
				item3.ClearCurrentPath();
			}
		}
		playerUnitsCommandingBuffer.Clear();
		playerUnitsCommandingBuffer.AddRange(toBePlaced);
	}

	public void OnUnitAdd(TaggedObject _t, bool _smartCommand)
	{
		if (_t == null || _t.Hp == null || !_t.Hp.Alive || !canCommandUnitsInThisMode)
		{
			return;
		}
		PathfindMovementPlayerunit pathfindMovementPlayerunit = (PathfindMovementPlayerunit)_t.Hp.PathfindMovement;
		if (playerUnitsCommanding.Contains(pathfindMovementPlayerunit) || (_smartCommand && playerUnitsCommanding.Count > 0 && playerUnitsCommanding[0].name != _t.name))
		{
			return;
		}
		audioManager.PlaySoundAsOneShot(audioSet.AddedUnitToCommanding, 0.55f, 0.7f + (float)playerUnitsCommanding.Count * 0.025f, audioManager.mgSFX, 50);
		playerUnitsCommanding.Add(pathfindMovementPlayerunit);
		pathfindMovementPlayerunit.FollowPlayer(_follow: true);
		MaterialFlasherFX componentInChildren = pathfindMovementPlayerunit.GetComponentInChildren<MaterialFlasherFX>();
		if ((bool)componentInChildren)
		{
			componentInChildren.SetSelected(_selected: true);
		}
		UnitTypeDisplay component = pathfindMovementPlayerunit.GetComponent<UnitTypeDisplay>();
		if ((bool)component)
		{
			component.SetSelected(_selected: true);
		}
		_t.AddTag(TagManager.ETag.AUTO_Commanded);
		if (royalProtectionEquipped)
		{
			pathfindMovementPlayerunit.hp.ScaleHp(royalProtectionHealthMulti);
		}
		if (playerUPgradeManager.commander)
		{
			pathfindMovementPlayerunit.movementSpeed *= commanderUnitMoveSpeedMulti;
			return;
		}
		AutoAttack[] components = _t.GetComponents<AutoAttack>();
		foreach (AutoAttack autoAttack in components)
		{
			autoAttack.enabled = false;
			autoAttacksToEnable.Add(autoAttack);
		}
	}

	public void OnUnitRemove(PathfindMovementPlayerunit _p)
	{
		if (canCommandUnitsInThisMode)
		{
			_p.HasReachedHomePositionAlready = false;
			_p.FollowPlayer(_follow: false);
			MaterialFlasherFX componentInChildren = _p.GetComponentInChildren<MaterialFlasherFX>();
			if ((bool)componentInChildren)
			{
				componentInChildren.SetSelected(_selected: false);
			}
			_p.GetComponent<TaggedObject>().RemoveTag(TagManager.ETag.AUTO_Commanded);
			UnitTypeDisplay component = _p.GetComponent<UnitTypeDisplay>();
			if ((bool)component)
			{
				component.SetSelected(_selected: false);
			}
			if (royalProtectionEquipped)
			{
				_p.hp.ScaleHp(1f / royalProtectionHealthMulti);
			}
			if (playerUPgradeManager.commander)
			{
				_p.movementSpeed /= commanderUnitMoveSpeedMulti;
			}
		}
	}

	private void TryToSelectUnits(List<TaggedObject> _select)
	{
		if (commanding)
		{
			PlaceCommandedUnitsAndCalculateTargetPositions(_smartCommand: false);
			commanding = false;
			return;
		}
		foreach (TaggedObject item in _select)
		{
			OnUnitAdd(item, _smartCommand: false);
		}
		commanding = playerUnitsCommanding.Count > 0;
	}
}
