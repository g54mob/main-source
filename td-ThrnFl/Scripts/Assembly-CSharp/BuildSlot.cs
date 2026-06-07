using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
public class BuildSlot : MonoBehaviour, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	public enum BuildingState
	{
		Blueprint = 0,
		Built = 1
	}

	[Serializable]
	public class Upgrade
	{
		public string upgradeTooltip;

		[Min(0f)]
		public int cost = 3;

		public bool disableInThisMode;

		public List<UpgradeBranch> upgradeBranches;
	}

	[Serializable]
	public class UpgradeBranch
	{
		[Tooltip("Only necessary when there are multiple options:")]
		public Choice choiceDetails;

		public Mesh replacementMesh;

		public int goldIncomeChange;

		[BalancingParameter(BalancingParameter.EType.Default)]
		public int hpChange;

		public List<GameObject> objectsToActivate = new List<GameObject>();

		public List<GameObject> objectsToDisable = new List<GameObject>();
	}

	public string buildingName;

	[Tooltip("The root is the required parent object no arrow points to, so this is pretty much always gonna be the casle center.E.g. this is set to 0 this building can not have a higher level than the castle center level.")]
	[SerializeField]
	private int requiredRootLevelDifference = -100;

	private BuildSlot requiredRoot;

	private List<BuildSlot> isRootOf = new List<BuildSlot>();

	private List<BuildSlot> isActivatorOf = new List<BuildSlot>();

	[SerializeField]
	private bool startDeactivated = true;

	[SerializeField]
	private BuildSlot activatorBuilding;

	[Min(0f)]
	[SerializeField]
	private int activatorLevel;

	[SerializeField]
	private bool activatorUpgradesThis;

	public List<Upgrade> upgrades = new List<Upgrade>();

	private int level;

	private List<int> appliedUpgrades = new List<int>();

	[HideInInspector]
	public UnityEvent OnAfterDelayedLoadFinished = new UnityEvent();

	private Hp hpParent;

	[SerializeField]
	private GameObject buildingParent;

	[SerializeField]
	private GameObject bluepringParent;

	[SerializeField]
	private BuildingInteractor interactor;

	[SerializeField]
	private MeshFilter mainMesh;

	[SerializeField]
	private BoxCollider mainCollider;

	[SerializeField]
	private BoxCollider damageCollider;

	[SerializeField]
	private BoxCollider interactorCollider;

	[SerializeField]
	private NavmeshCut navmeshCut;

	public bool hideGizmos;

	public float navmeshCutPadding = 1f;

	public BuildingMeshTracker buildingMeshTracker;

	[HideInInspector]
	public BuildingInteractor buildingInteractor;

	private int goldIncome;

	private List<Upgrade> upgradesWithCostsLoadedFromSave = new List<Upgrade>();

	[HideInInspector]
	public UnityEvent OnUpgradeEarly = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnUpgrade = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnParentUpgrade = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnUpgradeCancel = new UnityEvent();

	private List<BuildSlot> builtSlotsThatRelyOnThisBuilding = new List<BuildSlot>();

	private bool gotActivated;

	private Upgrade upgradeSelected;

	private PlayerInteraction playerInteractionSelected;

	public string LOCIDENTIFIER_NAME => "Building/" + buildingName;

	public int RequiredRootLevelDifference => requiredRootLevelDifference;

	public List<BuildSlot> IsRootOf => isRootOf;

	public List<BuildSlot> IsActivatorOf => isActivatorOf;

	public BuildSlot ActivatorBuilding => activatorBuilding;

	public bool StartDeactivated
	{
		get
		{
			return startDeactivated;
		}
		set
		{
			startDeactivated = value;
		}
	}

	public int ActivatorLevel
	{
		get
		{
			return activatorLevel;
		}
		set
		{
			activatorLevel = value;
		}
	}

	public bool ActivatorUpgradesThis => activatorUpgradesThis;

	public List<Upgrade> Upgrades
	{
		get
		{
			if (!activatorUpgradesThis)
			{
				return upgrades;
			}
			return activatorBuilding.Upgrades;
		}
	}

	public List<Upgrade> OwnUpgrades => upgrades;

	public int Level
	{
		get
		{
			if (!activatorUpgradesThis)
			{
				return level;
			}
			return activatorBuilding.Level;
		}
	}

	public List<int> AppliedUpgrades => appliedUpgrades;

	private Hp HpParent
	{
		get
		{
			if (!hpParent && (bool)buildingParent)
			{
				hpParent = buildingParent.GetComponent<Hp>();
			}
			return hpParent;
		}
	}

	public BuildingInteractor Interactor => interactor;

	public MeshFilter MainMesh => mainMesh;

	public ReadOnlyCollection<Upgrade> UpgradesWithCostsLoadedFromSave => upgradesWithCostsLoadedFromSave.AsReadOnly();

	public BuildingState State
	{
		get
		{
			if (level < 1)
			{
				return BuildingState.Blueprint;
			}
			return BuildingState.Built;
		}
	}

	public int GoldIncome
	{
		get
		{
			return goldIncome;
		}
		set
		{
			goldIncome = value;
		}
	}

	public bool CanBeUpgraded
	{
		get
		{
			if (activatorUpgradesThis)
			{
				return activatorBuilding.CanBeUpgraded;
			}
			if (level >= upgrades.Count)
			{
				return false;
			}
			if (upgrades[level].disableInThisMode)
			{
				return false;
			}
			if (requiredRoot == null)
			{
				return level < upgrades.Count;
			}
			if (requiredRoot.Level <= level + requiredRootLevelDifference)
			{
				return level == 0;
			}
			return true;
		}
	}

	public bool NextUpgradeIsChoice
	{
		get
		{
			if (CanBeUpgraded)
			{
				return upgrades[level].upgradeBranches.Count > 1;
			}
			return false;
		}
	}

	public int NextUpgradeOrBuildCost
	{
		get
		{
			if (activatorUpgradesThis)
			{
				return activatorBuilding.NextUpgradeOrBuildCost;
			}
			if (CanBeUpgraded)
			{
				return upgrades[level].cost;
			}
			return 100;
		}
		set
		{
			if (activatorUpgradesThis)
			{
				activatorBuilding.NextUpgradeOrBuildCost = value;
			}
			if (CanBeUpgraded)
			{
				upgrades[level].cost = value;
			}
		}
	}

	public GameObject BuildingParent => buildingParent;

	private bool IsBlueprint => level == 0;

	public List<BuildSlot> BuiltSlotsThatRelyOnThisBuilding => builtSlotsThatRelyOnThisBuilding;

	public string GET_LOCIDENTIFIER_UPGRADE(int upgradeNumber)
	{
		return LOCIDENTIFIER_NAME + " Upgrade " + upgradeNumber;
	}

	public string GET_LOCIDENTIFIER_CHOICENAME(Choice choice)
	{
		return LOCIDENTIFIER_NAME + " Choice " + choice.name;
	}

	public string GET_LOCIDENTIFIER_CHOICEDESCRIPTION(Choice choice)
	{
		return GET_LOCIDENTIFIER_CHOICENAME(choice) + " Description";
	}

	public void SetRequiredRootLevelDifference(int _value)
	{
		requiredRootLevelDifference = _value;
	}

	public void SetActivatorBuilding(BuildSlot _bs)
	{
		activatorBuilding = _bs;
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		if (MatchSaveLoadHandler.TryLoadValue(guid, "level", ref level))
		{
			startDeactivated = false;
		}
		int[] value = new int[0];
		MatchSaveLoadHandler.TryLoadValue(guid, "appliedUpgrades", ref value);
		if (value.Length != 0)
		{
			appliedUpgrades = new List<int>(value);
		}
		int value2 = 0;
		MatchSaveLoadHandler.TryLoadValue(guid, "NextUpgradeOrBuildCost", ref value2);
		if (value2 != 0 && level < upgrades.Count)
		{
			upgrades[level].cost = value2;
			upgradesWithCostsLoadedFromSave.Add(upgrades[level]);
		}
		StartCoroutine(ApplyLoadedUpgradesDelayed());
	}

	private IEnumerator ApplyLoadedUpgradesDelayed()
	{
		yield return null;
		for (int i = 0; i < appliedUpgrades.Count; i++)
		{
			ApplyLocalUpgradeChanges(upgrades[i].upgradeBranches[appliedUpgrades[i]], isLoadingFromSavedata: true);
		}
		OnAfterDelayedLoadFinished.Invoke();
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "level", level);
		MatchSaveLoadHandler.SaveValue(guid, "appliedUpgrades", appliedUpgrades.ToArray());
		if (level < upgrades.Count)
		{
			MatchSaveLoadHandler.SaveValue(guid, "NextUpgradeOrBuildCost", upgrades[level].cost);
		}
	}

	public string ReturnTooltip()
	{
		if (!CanBeUpgraded)
		{
			return "";
		}
		string text = ((level <= 0) ? TextTranslator.Translate("Tooltip/Build") : TextTranslator.Translate("Tooltip/Upgrade Building"));
		string text2 = "<style=\"Tooltip Header\">" + text + " " + TextTranslator.Translate(LOCIDENTIFIER_NAME) + ":\n";
		text2 = text2 + "<style=\"Tooltip Default\">" + TextTranslator.Translate(GET_LOCIDENTIFIER_UPGRADE(level)) + "\n";
		text2 += "<style=\"Tooltip Numerals\">";
		int num = 0;
		Hp componentInChildren = GetComponentInChildren<Hp>(includeInactive: true);
		if ((bool)componentInChildren)
		{
			num = (int)componentInChildren.maxHp;
		}
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		foreach (UpgradeBranch upgradeBranch in upgrades[level].upgradeBranches)
		{
			int item = goldIncome + upgradeBranch.goldIncomeChange;
			if (!list.Contains(item))
			{
				list.Add(item);
			}
			int item2 = num + upgradeBranch.hpChange;
			if (!list2.Contains(item2))
			{
				list2.Add(item2);
			}
		}
		list2.Sort();
		list.Sort();
		string text3 = "";
		string text4 = "";
		for (int i = 0; i < list.Count; i++)
		{
			if (i > 0)
			{
				text3 += "/";
			}
			text3 += list[i];
		}
		for (int j = 0; j < list2.Count; j++)
		{
			if (j > 0)
			{
				text4 += "/";
			}
			text4 += list2[j];
		}
		if (level > 0)
		{
			text2 = ((list2.Count <= 1 && list2[0] == num) ? (text2 + "\n" + num + "<sprite name=\"heart\">") : (text2 + "\n" + num + "<sprite name=\"heart\"> <sprite name=\"arrow_right\"> " + text4 + "<sprite name=\"heart\">"));
			if (list.Count > 1 || list[0] != goldIncome)
			{
				return text2 + "\n" + goldIncome + "<sprite name=\"coin\"> <sprite name=\"arrow_right\"> " + text3 + "<sprite name=\"coin\">";
			}
			return text2 + "\n" + goldIncome + "<sprite name=\"coin\">";
		}
		text2 = ((list2.Count <= 1 && list2[0] == num) ? (text2 + "\n<sprite name=\"arrow_right\"> " + num + "<sprite name=\"heart\">") : (text2 + "\n<sprite name=\"arrow_right\"> " + text4 + "<sprite name=\"heart\">"));
		if (list.Count > 1 || list[0] != goldIncome)
		{
			return text2 + "\n<sprite name=\"arrow_right\"> " + text3 + "<sprite name=\"coin\">";
		}
		return text2 + "\n<sprite name=\"arrow_right\"> " + goldIncome + "<sprite name=\"coin\">";
	}

	private void OnEnable()
	{
		foreach (Upgrade upgrade in upgrades)
		{
			foreach (UpgradeBranch upgradeBranch in upgrade.upgradeBranches)
			{
				foreach (GameObject item in upgradeBranch.objectsToActivate)
				{
					if ((bool)item)
					{
						item.SetActive(value: false);
					}
				}
			}
		}
		StartCoroutine(GodOfChoiceHandling());
	}

	private IEnumerator GodOfChoiceHandling()
	{
		yield return null;
		if (!PerkManager.instance.GodOfChoiceEquipped)
		{
			yield break;
		}
		foreach (Upgrade upgrade in upgrades)
		{
			foreach (UpgradeBranch upgradeBranch in upgrade.upgradeBranches)
			{
				upgradeBranch.choiceDetails.disabledInThisMode = false;
			}
			string gUID = GetComponent<SaveLoadEntity>().GUID;
			if (string.IsNullOrEmpty(gUID))
			{
				Debug.LogWarning("GUID is null or empty for upgrade: " + upgrade);
				continue;
			}
			int count = upgrade.upgradeBranches.Count;
			int num = Mathf.FloorToInt((float)count / 2f);
			int num2 = 0;
			for (int i = 0; i < count; i++)
			{
				if (num2 >= num)
				{
					break;
				}
				if (gUID[i % gUID.Length] % 2 == 0 && !upgrade.upgradeBranches[i].choiceDetails.disabledInThisMode)
				{
					upgrade.upgradeBranches[i].choiceDetails.disabledInThisMode = true;
					num2++;
				}
			}
			if (num2 < num)
			{
				int num3 = gUID.Sum((char c) => c) % count;
				for (int num4 = 0; num4 < count; num4++)
				{
					if (num2 >= num)
					{
						break;
					}
					int index = (num3 + num4) % count;
					if (!upgrade.upgradeBranches[index].choiceDetails.disabledInThisMode)
					{
						upgrade.upgradeBranches[index].choiceDetails.disabledInThisMode = true;
						num2++;
					}
				}
			}
			int num5 = upgrade.upgradeBranches.Count((UpgradeBranch b) => b.choiceDetails.disabledInThisMode);
			if (num5 != num)
			{
				Debug.LogWarning($"Mismatch in disabled branches for upgrade {upgrade}. Expected: {num}, Actual: {num5}");
			}
		}
	}

	public List<BuildSlot> GetBuildSlotsThatWillUnlockWhenUpgraded()
	{
		List<BuildSlot> list = new List<BuildSlot>();
		for (int i = 0; i < builtSlotsThatRelyOnThisBuilding.Count; i++)
		{
			if (builtSlotsThatRelyOnThisBuilding[i].activatorLevel == level)
			{
				list.Add(builtSlotsThatRelyOnThisBuilding[i]);
			}
		}
		return list;
	}

	public List<MeshFilter> GetBlueprintPreviewsThatWillUnlockWhenUpgraded()
	{
		List<MeshFilter> list = new List<MeshFilter>();
		for (int i = 0; i < builtSlotsThatRelyOnThisBuilding.Count; i++)
		{
			if (builtSlotsThatRelyOnThisBuilding[i].activatorLevel == level)
			{
				if (builtSlotsThatRelyOnThisBuilding[i].State == BuildingState.Built || builtSlotsThatRelyOnThisBuilding[i].activatorUpgradesThis)
				{
					MeshFilter[] componentsInChildren = builtSlotsThatRelyOnThisBuilding[i].buildingParent.GetComponentsInChildren<MeshFilter>();
					list.AddRange(componentsInChildren);
				}
				else
				{
					MeshFilter[] componentsInChildren2 = builtSlotsThatRelyOnThisBuilding[i].bluepringParent.GetComponentsInChildren<MeshFilter>();
					list.AddRange(componentsInChildren2);
				}
			}
		}
		return list;
	}

	public List<GameObject> GetGameObjectsThatWillUnlockWhenUpgraded(int _upgradeBranch)
	{
		if (level >= upgrades.Count)
		{
			return new List<GameObject>();
		}
		return upgrades[level].upgradeBranches[_upgradeBranch % upgrades[level].upgradeBranches.Count].objectsToActivate;
	}

	private void Start()
	{
		requiredRoot = this;
		if ((bool)activatorBuilding)
		{
			activatorBuilding.isActivatorOf.Add(this);
		}
		while (requiredRoot.activatorBuilding != null)
		{
			requiredRoot = requiredRoot.activatorBuilding;
		}
		if (requiredRoot != this)
		{
			requiredRoot.isRootOf.Add(this);
		}
		if ((bool)activatorBuilding)
		{
			activatorBuilding.builtSlotsThatRelyOnThisBuilding.Add(this);
		}
		if (startDeactivated)
		{
			base.gameObject.SetActive(value: false);
			if ((bool)activatorBuilding)
			{
				activatorBuilding.OnUpgrade.AddListener(Activate);
			}
		}
		else
		{
			Activate();
		}
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	public void Activate()
	{
		if (!gotActivated && (!startDeactivated || activatorBuilding.Level > activatorLevel))
		{
			gotActivated = true;
			base.gameObject.SetActive(value: true);
			ActivateOrDeactivateBuliding(State);
		}
	}

	public void ActivateIgrnoringActivatorLevel()
	{
		if (!gotActivated)
		{
			gotActivated = true;
			base.gameObject.SetActive(value: true);
			ActivateOrDeactivateBuliding(State);
		}
	}

	private void ActivateOrDeactivateBuliding(BuildingState nextState)
	{
		switch (nextState)
		{
		case BuildingState.Blueprint:
			if ((bool)buildingParent)
			{
				buildingParent.SetActive(value: false);
			}
			if ((bool)bluepringParent)
			{
				bluepringParent.SetActive(value: true);
			}
			break;
		case BuildingState.Built:
			if ((bool)buildingParent)
			{
				buildingParent.SetActive(value: true);
			}
			if ((bool)bluepringParent)
			{
				bluepringParent.SetActive(value: false);
			}
			break;
		}
	}

	public void TryToBuildOrUpgradeAndPay(PlayerInteraction player, bool _presentChoice = true)
	{
		if (!CanBeUpgraded)
		{
			return;
		}
		if (activatorUpgradesThis)
		{
			activatorBuilding.TryToBuildOrUpgradeAndPay(player, _presentChoice);
			return;
		}
		for (int i = 0; i < builtSlotsThatRelyOnThisBuilding.Count; i++)
		{
			BuildSlot buildSlot = builtSlotsThatRelyOnThisBuilding[i];
			if (buildSlot.ActivatorUpgradesThis && buildSlot.activatorBuilding == this)
			{
				buildSlot.gameObject.SetActive(value: true);
				buildSlot.ExecuteBuildOrUpgrade(player, _presentChoice: false);
			}
		}
		ExecuteBuildOrUpgrade(player, _presentChoice);
		for (int j = 0; j < builtSlotsThatRelyOnThisBuilding.Count; j++)
		{
			BuildSlot buildSlot2 = builtSlotsThatRelyOnThisBuilding[j];
			if ((bool)buildSlot2.buildingInteractor)
			{
				buildSlot2.buildingInteractor.UpdateInteractionState();
			}
		}
		if ((bool)buildingInteractor)
		{
			buildingInteractor.UpdateInteractionState();
		}
	}

	public void ExecuteBuildOrUpgrade(PlayerInteraction _player, bool _presentChoice)
	{
		if (CanBeUpgraded)
		{
			ExecuteUpgrade(upgrades[level], _player, _presentChoice);
		}
	}

	private void ExecuteUpgrade(Upgrade _upg, PlayerInteraction _player, bool _presentChoice)
	{
		if (ChoiceManager.instance.ChoiceCoroutineRunning)
		{
			return;
		}
		List<Choice> list = new List<Choice>();
		foreach (UpgradeBranch upgradeBranch in _upg.upgradeBranches)
		{
			list.Add(upgradeBranch.choiceDetails);
		}
		upgradeSelected = _upg;
		playerInteractionSelected = _player;
		if (_presentChoice)
		{
			ChoiceManager.instance.PresentChoices(list, this, OnUpgradeChoiceComplete);
		}
		else
		{
			OnUpgradeChoiceComplete(_upg.upgradeBranches[UnityEngine.Random.Range(0, _upg.upgradeBranches.Count)].choiceDetails);
		}
	}

	public void OnUpgradeChoiceComplete(Choice _choiceMade)
	{
		if (_choiceMade == null)
		{
			OnUpgradeCancel.Invoke();
			return;
		}
		if (level == 0)
		{
			ActivateOrDeactivateBuliding(BuildingState.Built);
		}
		level++;
		UpgradeBranch upgBranch = null;
		int num = 0;
		foreach (UpgradeBranch upgradeBranch in upgradeSelected.upgradeBranches)
		{
			if (upgradeBranch.choiceDetails == _choiceMade)
			{
				upgBranch = upgradeBranch;
				appliedUpgrades.Add(num);
			}
			num++;
		}
		ApplyLocalUpgradeChanges(upgBranch);
		foreach (BuildSlot item in isRootOf)
		{
			if (item == null)
			{
				continue;
			}
			BuildingInteractor[] componentsInChildren = item.GetComponentsInChildren<BuildingInteractor>();
			foreach (BuildingInteractor buildingInteractor in componentsInChildren)
			{
				if (!(buildingInteractor == null))
				{
					buildingInteractor.UpdateInteractionState();
				}
			}
		}
		if (activatorUpgradesThis)
		{
			OnParentUpgrade.Invoke();
			return;
		}
		OnUpgradeEarly.Invoke();
		OnUpgrade.Invoke();
		TooltipManager.instance.SetInteractorRefreshFlag();
	}

	public void ForceManualUpgradeWithoutFeedbackEffects(UpgradeBranch upgBranch)
	{
		if (upgBranch == null)
		{
			OnUpgradeEarly.Invoke();
			OnUpgradeCancel.Invoke();
			return;
		}
		if (level == 0)
		{
			ActivateOrDeactivateBuliding(BuildingState.Built);
		}
		level++;
		ApplyLocalUpgradeChanges(upgBranch);
		foreach (BuildSlot item in isRootOf)
		{
			if (item == null)
			{
				continue;
			}
			BuildingInteractor[] componentsInChildren = item.GetComponentsInChildren<BuildingInteractor>();
			foreach (BuildingInteractor buildingInteractor in componentsInChildren)
			{
				if (!(buildingInteractor == null))
				{
					buildingInteractor.UpdateInteractionState();
				}
			}
		}
		foreach (BuildSlot item2 in isActivatorOf)
		{
			item2.Activate();
		}
		int num = upgrades[level - 1].upgradeBranches.FindIndex((UpgradeBranch c) => c == upgBranch);
		if (num == -1)
		{
			num = 0;
		}
		appliedUpgrades.Add(num);
		if (!activatorUpgradesThis)
		{
			TooltipManager.instance.SetInteractorRefreshFlag();
		}
	}

	public void ApplyLocalUpgradeChanges(UpgradeBranch upgBranch, bool isLoadingFromSavedata = false)
	{
		if (upgBranch == null)
		{
			return;
		}
		buildingMeshTracker.Unfreeze();
		buildingMeshTracker.FreezeMeshWithDelay();
		if (upgBranch.replacementMesh != null)
		{
			mainMesh.mesh = upgBranch.replacementMesh;
		}
		goldIncome += upgBranch.goldIncomeChange;
		if ((bool)HpParent && !isLoadingFromSavedata)
		{
			if (HpParent.HpValue <= 0f && level > 1)
			{
				HpParent.Revive();
				HpParent.SetHpTo(1f);
			}
			HpParent.maxHp += upgBranch.hpChange;
			HpParent.Heal(upgBranch.hpChange);
			if ((bool)HpParent.TaggedObj)
			{
				HpParent.TaggedObj.RemoveTag(TagManager.ETag.AUTO_NoReviveNextMorning);
			}
		}
		else if ((bool)HpParent)
		{
			HpParent.maxHp += upgBranch.hpChange;
			HpParent.OnHpChange.Invoke();
		}
		foreach (GameObject item in upgBranch.objectsToActivate)
		{
			if (item != null)
			{
				item.SetActive(value: true);
			}
		}
		foreach (GameObject item2 in upgBranch.objectsToDisable)
		{
			if (item2 != null)
			{
				item2.SetActive(value: false);
			}
		}
	}

	public void ReplaceMeshExternal(Mesh replacement)
	{
		buildingMeshTracker.Unfreeze();
		buildingMeshTracker.FreezeMeshWithDelay();
		mainMesh.mesh = replacement;
	}

	public void DEBUGUpgradeToMax()
	{
		while (CanBeUpgraded)
		{
			TryToBuildOrUpgradeAndPay(null, _presentChoice: false);
		}
		if ((bool)interactor)
		{
			interactor.UpdateInteractionState();
		}
	}

	public void OnDusk()
	{
		if (IsBlueprint && (bool)bluepringParent)
		{
			bluepringParent.SetActive(value: false);
		}
	}

	public void OnDawn_AfterSunrise()
	{
		if (IsBlueprint && (bool)bluepringParent)
		{
			bluepringParent.SetActive(value: true);
		}
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDuskEarly()
	{
	}
}
