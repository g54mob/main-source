using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSelectionPanel : MonoBehaviour
{
	public List<ZoneData> allZones;

	public GameObject zoneItemPrefab;

	public Transform gridParent;

	private List<ZoneUIItem> spawnedZoneItems = new List<ZoneUIItem>();

	private void Start()
	{
		GameManager.Instance.LoadZoneUnlockData();
		CreateZoneItems();
		StartCoroutine(InitializeUIAfterPlayerStats());
	}

	private IEnumerator InitializeUIAfterPlayerStats()
	{
		while (PlayerStats.Instance == null)
		{
			yield return null;
		}
		while (SkillManager.Instance == null || SkillManager.Instance.allSkills == null)
		{
			yield return null;
		}
		yield return null;
		RefreshUI();
	}

	private void CreateZoneItems()
	{
		foreach (ZoneData allZone in allZones)
		{
			ZoneUIItem component = Object.Instantiate(zoneItemPrefab, gridParent).GetComponent<ZoneUIItem>();
			component.Setup(allZone, this);
			spawnedZoneItems.Add(component);
		}
	}

	public void RefreshUI()
	{
		foreach (ZoneUIItem spawnedZoneItem in spawnedZoneItems)
		{
			spawnedZoneItem.RefreshVisuals();
		}
	}

	public void AttemptUnlock(ZoneData zoneToUnlock)
	{
		if (GameManager.Instance.UnlockZone(zoneToUnlock))
		{
			RefreshUI();
		}
		else
		{
			Debug.Log("Not enough money to unlock " + zoneToUnlock.zoneName);
		}
	}
}
