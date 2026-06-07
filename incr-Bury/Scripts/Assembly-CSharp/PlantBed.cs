using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBed : MonoBehaviour
{
	[Header("Berry Profile")]
	public BerryProfile currentBerryProfile;

	public int currentBerryTier;

	[Header("Leveling")]
	[SerializeField]
	private int berriesProduced;

	[SerializeField]
	private int xp;

	private bool isOnBonusTile;

	[SerializeField]
	private int level;

	[SerializeField]
	private int[] levelRequirements;

	[Header("Plants")]
	public PlantIdentity plantIdentity;

	[SerializeField]
	private Plant flowerPlant;

	[SerializeField]
	private Plant bushPlant;

	[SerializeField]
	private Plant treePlant;

	[Header("Growers")]
	[SerializeField]
	private List<BerryGrower> allGrowers;

	[SerializeField]
	private bool isProductionHalted;

	public bool isLoadedFromSave;

	[Header("Siding Boards")]
	public GameObject[] dirtPatchSidings;

	private void Awake()
	{
		InitializeAllGrowersList();
	}

	private void Start()
	{
		GameManager.Singleton.allPlantBeds.Add(this);
		GameManager.Singleton.updatePlantBedSidingsNextFrame = true;
		if (!isLoadedFromSave)
		{
			StartCoroutine(WaitAFrameThenCheckIfBonusTile());
		}
	}

	public IEnumerator LoadedPlantBedFromSave_WaitAMomentAndSetValues()
	{
		yield return null;
		yield return null;
		yield return null;
		CheckPlantIdentityAndSyncPlantChildren();
		if (currentBerryTier > -1)
		{
			ChangeBerryProfile(GameManager.Singleton.prefabBank.berryProfiles[currentBerryTier]);
		}
		CheckForLevelUp();
		StartCoroutine(WaitAFrameThenCheckIfBonusTile());
	}

	private IEnumerator WaitAFrameThenCheckIfBonusTile()
	{
		yield return null;
		yield return null;
		yield return null;
		CheckIfWeAreOnBonusTile();
	}

	public void CheckIfWeAreOnBonusTile()
	{
		try
		{
			isOnBonusTile = GameManager.Singleton.buildSpotsDict[GameManager.Singleton.GetGridDictFromPos(base.transform.position)].isBonusSpot;
			if (isOnBonusTile)
			{
				Debug.Log("We're on a bonus tile!!");
			}
			else
			{
				Debug.Log("NO BONUS TILE!!");
			}
		}
		catch
		{
		}
	}

	private void OnDestroy()
	{
		GameManager.Singleton.allPlantBeds.Remove(this);
	}

	private void InitializeAllGrowersList()
	{
		BerryGrower[] componentsInChildren = GetComponentsInChildren<BerryGrower>(includeInactive: true);
		allGrowers = new List<BerryGrower>();
		BerryGrower[] array = componentsInChildren;
		foreach (BerryGrower item in array)
		{
			allGrowers.Add(item);
		}
	}

	private void Update()
	{
	}

	public void ChangeBerryProfile(BerryProfile _newBerry)
	{
		currentBerryTier = _newBerry.tier;
		currentBerryProfile = _newBerry;
		if (plantIdentity == PlantIdentity.Flower)
		{
			if ((bool)flowerPlant)
			{
				flowerPlant.ChangeBerryType(_newBerry);
			}
		}
		else if (plantIdentity == PlantIdentity.Bush)
		{
			if ((bool)bushPlant)
			{
				bushPlant.ChangeBerryType(_newBerry);
				bushPlant.AddGrowthDelayOffsetsToGrowers();
			}
		}
		else if (plantIdentity == PlantIdentity.Tree && (bool)treePlant)
		{
			treePlant.ChangeBerryType(_newBerry);
			treePlant.AddGrowthDelayOffsetsToGrowers();
		}
	}

	public void IncreaseBerriesProducedStat(int _amount = 1)
	{
		berriesProduced += _amount;
		if (isOnBonusTile)
		{
			xp += _amount * PlayerStats.Singleton.bonusTile_XpMulti_Curr;
		}
		else
		{
			xp += _amount;
		}
	}

	public void CheckForLevelUp()
	{
		if (level < 3 && xp >= levelRequirements[level])
		{
			if (level == 1)
			{
				plantIdentity = PlantIdentity.Bush;
				CheckPlantIdentityAndSyncPlantChildren();
				ChangeBerryProfile(currentBerryProfile);
			}
			else if (level == 2)
			{
				plantIdentity = PlantIdentity.Tree;
				CheckPlantIdentityAndSyncPlantChildren();
				ChangeBerryProfile(currentBerryProfile);
			}
		}
	}

	public void UpgradeToFlower()
	{
		plantIdentity = PlantIdentity.Flower;
		CheckPlantIdentityAndSyncPlantChildren();
		ChangeBerryProfile(currentBerryProfile);
	}

	public void UpgradeToBush()
	{
		plantIdentity = PlantIdentity.Bush;
		CheckPlantIdentityAndSyncPlantChildren();
		ChangeBerryProfile(currentBerryProfile);
	}

	public void UpgradeToTree()
	{
		plantIdentity = PlantIdentity.Tree;
		CheckPlantIdentityAndSyncPlantChildren();
		ChangeBerryProfile(currentBerryProfile);
	}

	public int GetBerriesProduced()
	{
		return berriesProduced;
	}

	public void SetBerriesProduced(int _amt)
	{
		berriesProduced = _amt;
	}

	public int GetXP()
	{
		return xp;
	}

	public void SetXP(int _amt)
	{
		xp = _amt;
	}

	public float GetXPBarFill()
	{
		if (level < 3)
		{
			if (xp == 0)
			{
				return 0f;
			}
			return (float)xp / (float)levelRequirements[level];
		}
		return 1f;
	}

	public string GetNextLevelXpRequirementString()
	{
		if (level < 3)
		{
			return "/" + levelRequirements[level];
		}
		return "";
	}

	public void OnUpgraded()
	{
		if (currentBerryTier > -1)
		{
			CheckPlantIdentityAndSyncPlantChildren();
		}
	}

	public bool GetIsProductionHalted()
	{
		return isProductionHalted;
	}

	public void ToggleBerryHaltProduction()
	{
		if (isProductionHalted)
		{
			EnableBerryProduction();
		}
		else
		{
			HaltBerryProduction();
		}
	}

	public void HaltBerryProduction()
	{
		foreach (BerryGrower allGrower in allGrowers)
		{
			allGrower.isGrowingHalted = true;
		}
		isProductionHalted = true;
	}

	public void HideAllHalfGrownBerries()
	{
		foreach (BerryGrower allGrower in allGrowers)
		{
			allGrower.ResetAndHideHalfGrownBerry();
		}
	}

	public void SwapAllFlowerVisualsToBelladonnaFlowers()
	{
		try
		{
			foreach (BerryGrower allGrower in allGrowers)
			{
				allGrower.SwapToBelladonnaFlowerPetals();
			}
		}
		catch
		{
			Debug.Log("Something went wrong swapping the flower meshes, ignoring! as this isn't important.");
		}
	}

	public void EnableBerryProduction()
	{
		foreach (BerryGrower allGrower in allGrowers)
		{
			allGrower.isGrowingHalted = false;
		}
		isProductionHalted = false;
	}

	public void CheckPlantIdentityAndSyncPlantChildren()
	{
		switch (plantIdentity)
		{
		case PlantIdentity.Flower:
			flowerPlant.gameObject.SetActive(value: true);
			bushPlant.gameObject.SetActive(value: false);
			treePlant.gameObject.SetActive(value: false);
			level = 1;
			break;
		case PlantIdentity.Bush:
			flowerPlant.gameObject.SetActive(value: false);
			bushPlant.gameObject.SetActive(value: true);
			treePlant.gameObject.SetActive(value: false);
			level = 2;
			break;
		case PlantIdentity.Tree:
			flowerPlant.gameObject.SetActive(value: false);
			bushPlant.gameObject.SetActive(value: false);
			treePlant.gameObject.SetActive(value: true);
			level = 3;
			break;
		}
	}

	public void ResetPlantBed()
	{
		flowerPlant.gameObject.SetActive(value: false);
		bushPlant.gameObject.SetActive(value: false);
		treePlant.gameObject.SetActive(value: false);
		currentBerryTier = -1;
	}

	public void UpdateDirtPatchSidingVisuals()
	{
		if (dirtPatchSidings.Length == 4)
		{
			LayerMask layerMask = 1;
			Ray ray = new Ray(base.transform.position + Vector3.up * 10f + Vector3.right * -2.5f, Vector3.down);
			dirtPatchSidings[0].SetActive(value: true);
			if (Physics.Raycast(ray, out var hitInfo, 15f, layerMask, QueryTriggerInteraction.Ignore) && hitInfo.collider.gameObject.CompareTag("PlantBed"))
			{
				dirtPatchSidings[0].SetActive(value: false);
			}
			Ray ray2 = new Ray(base.transform.position + Vector3.up * 10f + Vector3.forward * 2.5f, Vector3.down);
			dirtPatchSidings[1].SetActive(value: true);
			if (Physics.Raycast(ray2, out hitInfo, 15f, layerMask, QueryTriggerInteraction.Ignore) && hitInfo.collider.gameObject.CompareTag("PlantBed"))
			{
				dirtPatchSidings[1].SetActive(value: false);
			}
			Ray ray3 = new Ray(base.transform.position + Vector3.up * 10f + Vector3.right * 2.5f, Vector3.down);
			dirtPatchSidings[2].SetActive(value: true);
			if (Physics.Raycast(ray3, out hitInfo, 15f, layerMask, QueryTriggerInteraction.Ignore) && hitInfo.collider.gameObject.CompareTag("PlantBed"))
			{
				dirtPatchSidings[2].SetActive(value: false);
			}
			Ray ray4 = new Ray(base.transform.position + Vector3.up * 10f + Vector3.forward * -2.5f, Vector3.down);
			dirtPatchSidings[3].SetActive(value: true);
			if (Physics.Raycast(ray4, out hitInfo, 15f, layerMask, QueryTriggerInteraction.Ignore) && hitInfo.collider.gameObject.CompareTag("PlantBed"))
			{
				dirtPatchSidings[3].SetActive(value: false);
			}
		}
	}
}
