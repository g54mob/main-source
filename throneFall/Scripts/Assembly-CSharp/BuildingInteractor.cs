using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInteractor : InteractorBase, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	public enum InteractionState
	{
		None = 0,
		Harvest = 1,
		Upgrade = 2
	}

	public static bool displayAllBuildPreviews;

	public BuildSlot targetBuilding;

	public Hp buildingHP;

	public CoinSpawner coinSpawner;

	public GameObject harvestCue;

	public GameObject harvestDeniedCue;

	public GameObject upgradeCue;

	public CostDisplay costDisplay;

	public Material previewMaterial;

	public bool showsHarvestDeniedCueEvenWithNoIncome;

	private List<IncomeModifyer> incomeModifiers = new List<IncomeModifyer>();

	private InteractionState currentState;

	private bool knockedOutTonight;

	private bool harvestedToday;

	private bool focussed;

	private Mesh upgradePreviewMesh;

	private bool interactionComplete;

	private bool interactionStarted;

	private bool isWaitingForChoice;

	private PlayerInteraction bufferedPlayer;

	public bool buildingIsCurrentlyBusyAndCantBeUpgraded;

	private bool neverDenyHarvest;

	public static int CurrentUpgradePreviewBranchNumber
	{
		get
		{
			if ((bool)ChoiceManager.instance && ChoiceManager.instance.ChoiceCoroutineRunning)
			{
				return ChoiceUIFrameHelper.CurrentSelectionIndex;
			}
			return Mathf.RoundToInt(Time.time * 2f);
		}
	}

	public List<IncomeModifyer> IncomeModifiers => incomeModifiers;

	public bool KnockedOutTonight => knockedOutTonight;

	public bool canBeHarvested
	{
		get
		{
			if (targetBuilding.State == BuildSlot.BuildingState.Built && !harvestedToday && targetBuilding.GoldIncome > 0)
			{
				return !knockedOutTonight;
			}
			return false;
		}
	}

	public bool harvestIsDenied
	{
		get
		{
			if (targetBuilding.State == BuildSlot.BuildingState.Built && (targetBuilding.GoldIncome > 0 || showsHarvestDeniedCueEvenWithNoIncome))
			{
				return knockedOutTonight;
			}
			return false;
		}
	}

	public int GoldIncome => targetBuilding.GoldIncome;

	public bool Focussed => focussed;

	public bool HarvestCueVisible => harvestCue.activeSelf;

	public bool UpgradeCueVisible => upgradeCue.activeSelf;

	public override bool CanBeInteractedWith => currentState != InteractionState.None;

	public bool IsWaitingForChoice => isWaitingForChoice;

	public Mesh UpgradePreviewMesh
	{
		get
		{
			if (targetBuilding.State == BuildSlot.BuildingState.Built)
			{
				if (!targetBuilding.CanBeUpgraded)
				{
					return null;
				}
				BuildSlot.Upgrade upgrade = targetBuilding.Upgrades[targetBuilding.Level];
				return upgrade.upgradeBranches[CurrentUpgradePreviewBranchNumber % upgrade.upgradeBranches.Count].replacementMesh;
			}
			return targetBuilding.MainMesh.mesh;
		}
	}

	public void SetHarvested(bool _harvested)
	{
		harvestedToday = _harvested;
	}

	public void MarkAsHarvested()
	{
		harvestedToday = true;
	}

	public void SetNeverDenyHarvest(bool _neverDenyHarvest)
	{
		neverDenyHarvest = _neverDenyHarvest;
	}

	public override string ReturnTooltip()
	{
		return targetBuilding.ReturnTooltip();
	}

	private void Start()
	{
		targetBuilding.buildingInteractor = this;
		if ((bool)buildingHP)
		{
			buildingHP.OnKillOrKnockout.AddListener(OnKnockOut);
		}
		targetBuilding.OnUpgrade.AddListener(OnTargetUpgrade);
		targetBuilding.OnUpgradeCancel.AddListener(OnTargetUpgradeCanceled);
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		UpdateInteractionState();
		if ((bool)TagManager.instance)
		{
			TagManager.instance.playerBuildingInteractors.Add(this);
		}
	}

	public override void InteractionBegin(PlayerInteraction player)
	{
		if (!isWaitingForChoice)
		{
			interactionStarted = true;
			interactionComplete = false;
			bufferedPlayer = player;
			if (currentState == InteractionState.Upgrade)
			{
				ThronefallAudioManager.Oneshot(ThronefallAudioManager.AudioOneShot.CoinslotInteractionStart);
			}
		}
	}

	public override void InteractionHold(PlayerInteraction player)
	{
		if (currentState != InteractionState.Upgrade || interactionComplete || !interactionStarted || isWaitingForChoice)
		{
			return;
		}
		if (costDisplay.CompletelyFilled)
		{
			isWaitingForChoice = targetBuilding.NextUpgradeIsChoice;
			targetBuilding.TryToBuildOrUpgradeAndPay(player);
			if (!isWaitingForChoice)
			{
				BuildComplete();
			}
			else
			{
				costDisplay.gameObject.SetActive(value: false);
			}
		}
		else if (player.Balance > 0)
		{
			if (costDisplay.FillUp())
			{
				player.SpendCoins(1);
			}
		}
		else
		{
			costDisplay.Deny();
		}
	}

	public override void InteractionEnd(PlayerInteraction player)
	{
		if (!isWaitingForChoice && interactionStarted)
		{
			interactionStarted = false;
			if (currentState == InteractionState.Upgrade)
			{
				costDisplay.CancelFill(player);
				ThronefallAudioManager.Instance.MakeSureCoinFillSoundIsNotPlayingAnymore();
			}
		}
	}

	private void BuildComplete()
	{
		harvestedToday = true;
		interactionComplete = true;
		costDisplay.OnCompletion();
		UpdateInteractionState();
	}

	private void CancelBuild()
	{
		costDisplay.CancelFill(bufferedPlayer);
	}

	private void OnTargetUpgrade()
	{
		if (isWaitingForChoice)
		{
			isWaitingForChoice = false;
			costDisplay.gameObject.SetActive(value: true);
			interactionStarted = false;
			BuildComplete();
		}
	}

	private void OnTargetUpgradeCanceled()
	{
		if (isWaitingForChoice)
		{
			isWaitingForChoice = false;
			if (DayNightCycle.Instance.CurrentTimestate != DayNightCycle.Timestate.Night)
			{
				costDisplay.gameObject.SetActive(value: true);
			}
			interactionStarted = false;
			CancelBuild();
		}
	}

	public void OnDusk()
	{
		knockedOutTonight = false;
		UpdateInteractionState(forceState: true);
	}

	public void OnDawn_BeforeSunrise()
	{
		harvestedToday = false;
	}

	public void OnDawn_AfterSunrise()
	{
		PlayerInteraction component = TagManager.instance.Players[0].GetComponent<PlayerInteraction>();
		Harvest(component);
		foreach (IncomeModifyer incomeModifier in incomeModifiers)
		{
			incomeModifier.OnDawn();
		}
		UpdateInteractionState();
	}

	public void UpdateInteractionState(bool forceState = false, InteractionState forcedState = InteractionState.None)
	{
		if (isWaitingForChoice || !base.gameObject)
		{
			return;
		}
		base.gameObject.SetActive(value: true);
		if (canBeHarvested)
		{
			currentState = InteractionState.Harvest;
		}
		else if (targetBuilding.CanBeUpgraded)
		{
			currentState = InteractionState.Upgrade;
		}
		else
		{
			currentState = InteractionState.None;
		}
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			currentState = InteractionState.None;
		}
		if (forceState)
		{
			currentState = forcedState;
		}
		if (harvestIsDenied)
		{
			harvestDeniedCue.SetActive(value: true);
		}
		else
		{
			harvestDeniedCue.SetActive(value: false);
		}
		if (buildingIsCurrentlyBusyAndCantBeUpgraded)
		{
			currentState = InteractionState.None;
		}
		switch (currentState)
		{
		case InteractionState.None:
			harvestCue.SetActive(value: false);
			upgradeCue.SetActive(value: false);
			DisableCostDisplay();
			break;
		case InteractionState.Harvest:
			harvestCue.SetActive(value: true);
			upgradeCue.SetActive(targetBuilding.CanBeUpgraded);
			DisableCostDisplay();
			break;
		case InteractionState.Upgrade:
			harvestCue.SetActive(value: false);
			if (focussed)
			{
				ActivateCostDisplay();
				upgradeCue.SetActive(value: false);
				break;
			}
			DisableCostDisplay();
			if (targetBuilding.State == BuildSlot.BuildingState.Built)
			{
				upgradeCue.SetActive(value: true);
			}
			else
			{
				upgradeCue.SetActive(value: false);
			}
			break;
		}
	}

	public override void Focus(PlayerInteraction player)
	{
		focussed = true;
		UpdateInteractionState();
		if (currentState == InteractionState.Harvest)
		{
			Harvest(player);
		}
	}

	public void Harvest(PlayerInteraction player)
	{
		if (canBeHarvested)
		{
			coinSpawner.TriggerCoinSpawn(targetBuilding.GoldIncome, player);
			harvestedToday = true;
			UpdateInteractionState();
		}
	}

	public override void Unfocus(PlayerInteraction player)
	{
		focussed = false;
		if (!costDisplay.CompletelyEmpty)
		{
			costDisplay.CancelFill(player);
		}
		UpdateInteractionState();
		ThronefallAudioManager.Instance.MakeSureCoinFillSoundIsNotPlayingAnymore();
	}

	private void ActivateCostDisplay()
	{
		costDisplay.UpdateDisplay(targetBuilding.NextUpgradeOrBuildCost);
	}

	private void DisableCostDisplay()
	{
		costDisplay.Hide();
	}

	public void OnKnockOut()
	{
		if (!neverDenyHarvest)
		{
			knockedOutTonight = true;
		}
	}

	private void Update()
	{
		if ((focussed || displayAllBuildPreviews) && currentState == InteractionState.Upgrade)
		{
			if (!targetBuilding.ActivatorUpgradesThis)
			{
				PreviewSelf();
			}
			else
			{
				targetBuilding.ActivatorBuilding.buildingInteractor.PreviewSelf();
			}
		}
		if (!focussed && costDisplay.gameObject.activeSelf)
		{
			costDisplay.Hide();
		}
	}

	public void PreviewSelf()
	{
		MeshFilter mainMesh = targetBuilding.MainMesh;
		if ((bool)UpgradePreviewMesh)
		{
			Graphics.DrawMesh(UpgradePreviewMesh, targetBuilding.MainMesh.transform.localToWorldMatrix, previewMaterial, 0);
		}
		else if (!mainMesh.gameObject.activeInHierarchy)
		{
			Graphics.DrawMesh(mainMesh.mesh, mainMesh.transform.localToWorldMatrix, previewMaterial, 0);
		}
		List<GameObject> gameObjectsThatWillUnlockWhenUpgraded = targetBuilding.GetGameObjectsThatWillUnlockWhenUpgraded(CurrentUpgradePreviewBranchNumber);
		for (int i = 0; i < gameObjectsThatWillUnlockWhenUpgraded.Count; i++)
		{
			if (gameObjectsThatWillUnlockWhenUpgraded[i].transform.parent == null)
			{
				PreviewGameObject(gameObjectsThatWillUnlockWhenUpgraded[i]);
			}
			else if (gameObjectsThatWillUnlockWhenUpgraded[i].transform.parent.gameObject.activeSelf || gameObjectsThatWillUnlockWhenUpgraded.Contains(gameObjectsThatWillUnlockWhenUpgraded[i].transform.parent.gameObject))
			{
				PreviewGameObject(gameObjectsThatWillUnlockWhenUpgraded[i]);
			}
		}
		for (int j = 0; j < targetBuilding.BuiltSlotsThatRelyOnThisBuilding.Count; j++)
		{
			BuildSlot buildSlot = targetBuilding.BuiltSlotsThatRelyOnThisBuilding[j];
			if (buildSlot.ActivatorUpgradesThis && buildSlot.ActivatorBuilding == targetBuilding && (bool)buildSlot.buildingInteractor)
			{
				buildSlot.buildingInteractor.PreviewSelf();
			}
		}
		List<MeshFilter> blueprintPreviewsThatWillUnlockWhenUpgraded = targetBuilding.GetBlueprintPreviewsThatWillUnlockWhenUpgraded();
		for (int k = 0; k < blueprintPreviewsThatWillUnlockWhenUpgraded.Count; k++)
		{
			mainMesh = blueprintPreviewsThatWillUnlockWhenUpgraded[k];
			Graphics.DrawMesh(mainMesh.mesh, mainMesh.transform.localToWorldMatrix, previewMaterial, 0);
		}
	}

	private void PreviewGameObject(GameObject _go)
	{
		MeshFilter[] componentsInChildren = _go.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			Graphics.DrawMesh(meshFilter.mesh, meshFilter.transform.localToWorldMatrix, previewMaterial, 0);
		}
	}

	private void OnDestroy()
	{
		DayNightCycle.Instance.UnregisterDaytimeSensitiveObject(this);
		if ((bool)TagManager.instance)
		{
			TagManager.instance.playerBuildingInteractors.Remove(this);
		}
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		MatchSaveLoadHandler.TryLoadValue(guid, "knockedOutTonight", ref knockedOutTonight);
		harvestedToday = true;
		StartCoroutine(UpdateInteractionStateDelayed());
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "knockedOutTonight", knockedOutTonight);
	}

	private IEnumerator UpdateInteractionStateDelayed()
	{
		yield return null;
		yield return null;
		UpdateInteractionState();
	}

	public void OnDuskEarly()
	{
	}
}
