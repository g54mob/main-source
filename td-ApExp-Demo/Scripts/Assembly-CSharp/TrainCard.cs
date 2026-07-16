using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public class TrainCard : InventoryCard
{
	[Header("Localization Keys")]
	[SerializeField]
	private LocalizedString trainHullKey;

	[SerializeField]
	private LocalizedString locationsVisitedKey;

	[SerializeField]
	private LocalizedString upgradeCountKey;

	[SerializeField]
	private LocalizedString distanceTravelledKey;

	private void Awake()
	{
		Clear();
		LevelManager.Instance.LevelCompleted += Instance_LocationVisited;
	}

	public void SetInfo()
	{
		string trainHull = Train.Instance.HealthComponent.HealthCurrent.ToString();
		string upgrades = UpgradeManager.Instance.UpgradesInInventory.Count.ToString();
		string distance = ((float)Mathf.FloorToInt(Train.Instance.GlobalDistance) / 100f).ToString();
		StartCoroutine(UpdateText(trainHull, upgrades, distance));
	}

	private IEnumerator UpdateText(string trainHull, string upgrades, string distance)
	{
		yield return trainHullKey.GetLocalizedStringAsync();
		yield return locationsVisitedKey.GetLocalizedStringAsync();
		yield return upgradeCountKey.GetLocalizedStringAsync();
		textDesc.text = string.Format(trainHullKey.GetLocalizedString(), trainHull) + "\n" + string.Format(locationsVisitedKey.GetLocalizedString(), GameManager.Instance.locationsVisitedInRun) + "\n" + string.Format(upgradeCountKey.GetLocalizedString(), upgrades) + "\n" + string.Format(distanceTravelledKey.GetLocalizedString(), distance);
	}

	public override void Clear()
	{
		textDesc.text = "";
	}

	private void Instance_LocationVisited()
	{
		GameManager.Instance.locationsVisitedInRun += 1f;
	}
}
