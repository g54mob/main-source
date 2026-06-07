using System.Collections;
using UnityEngine;

public class FishingHarbour : IncomeModifyer, ISaveLoad
{
	public int incomeIncreasePerTurn = 1;

	public int maximumIncome = 5;

	private int maximumBoats;

	public Transform activeChildOnIncomeIncrease;

	private int activationNr;

	private int shipsBuilt;

	[Header("Perk Upgrade")]
	[SerializeField]
	private Equippable perk;

	[SerializeField]
	private int additionalBoatCapacity;

	private void Start()
	{
		buildingInteractor.IncomeModifiers.Add(this);
		for (int i = 0; i < activeChildOnIncomeIncrease.childCount; i++)
		{
			activeChildOnIncomeIncrease.GetChild(i).gameObject.SetActive(value: false);
		}
		if (PerkManager.instance.CurrentlyEquipped.Contains(perk))
		{
			foreach (BuildSlot.UpgradeBranch upgradeBranch in buildSlot.Upgrades[0].upgradeBranches)
			{
				upgradeBranch.objectsToActivate.Add(activeChildOnIncomeIncrease.GetChild(0).gameObject);
			}
			maximumIncome += additionalBoatCapacity;
			activationNr = 1;
		}
		maximumBoats = maximumIncome;
	}

	public override void OnDawn()
	{
		if (buildSlot.Level > 0 && !buildingInteractor.KnockedOutTonight)
		{
			StartCoroutine(IncreaseIncomeAndBuildShip());
		}
	}

	private IEnumerator IncreaseIncomeAndBuildShip()
	{
		yield return null;
		yield return null;
		if (activationNr < maximumBoats)
		{
			activeChildOnIncomeIncrease.GetChild(activationNr).gameObject.SetActive(value: true);
		}
		activationNr++;
		shipsBuilt++;
		buildSlot.GoldIncome = Mathf.Min(buildSlot.GoldIncome + incomeIncreasePerTurn, maximumIncome);
		buildSlot.Upgrades[1].upgradeBranches[0].goldIncomeChange = buildSlot.GoldIncome;
		buildSlot.Interactor.MarkAsHarvested();
	}

	private IEnumerator BatchBuildShipsOnLoad(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			yield return StartCoroutine(IncreaseIncomeAndBuildShip());
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
		int value = 0;
		MatchSaveLoadHandler.TryLoadValue(guid, "shipsBuilt", ref value);
		if (value > 0)
		{
			StartCoroutine(BatchBuildShipsOnLoad(value));
		}
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "shipsBuilt", shipsBuilt);
	}
}
