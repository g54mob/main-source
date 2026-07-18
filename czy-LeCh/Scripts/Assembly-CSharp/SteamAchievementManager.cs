using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Steamworks;
using UnityEngine;

public class SteamAchievementManager : MonoBehaviour
{
	public static SteamAchievementManager Instance;

	[SerializeField]
	private List<TileUnlock> tileUnlocks;

	[SerializeField]
	private List<GridObject> gridObjectsToShowAsUnlocked;

	[SerializeField]
	private GameObject achievementInstancePrefab;

	[SerializeField]
	private Transform achievementInstancesParent;

	[SerializeField]
	private Transform achievementsButton;

	[SerializeField]
	private GameObject confettiBurst;

	[SerializeField]
	private SoundManager soundManager1;

	[SerializeField]
	private SoundManager soundManager2;

	[SerializeField]
	private AudioClip unlockSound1;

	[SerializeField]
	private AudioClip unlockSound2;

	[SerializeField]
	private List<ObjectType> relevantObjectTypes;

	[SerializeField]
	private List<GridObject> gridObjectsPlaced;

	[SerializeField]
	private bool allTilesAreBuiltOn;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		foreach (TileUnlock tileUnlock in tileUnlocks)
		{
			AchievementInstanceController component = Object.Instantiate(achievementInstancePrefab, achievementInstancesParent).GetComponent<AchievementInstanceController>();
			component.SetAchievementData(tileUnlock.ach_name_loc, tileUnlock.ach_desc_loc);
			tileUnlock.ach_instance = component;
			MonoBehaviour.print("spawning achievement instance");
		}
		CheckAlreadyUnlocked();
	}

	private void CheckAlreadyUnlocked()
	{
		if (SteamManager.Initialized)
		{
			foreach (TileUnlock tileUnlock in tileUnlocks)
			{
				SteamUserStats.GetAchievement(tileUnlock.ach_key, out var pbAchieved);
				if (pbAchieved)
				{
					tileUnlock.ach_instance.QuickUnlockAchievement();
				}
			}
		}
		foreach (TileUnlock tileUnlock2 in tileUnlocks)
		{
			bool flag = false;
			foreach (GridObject item in tileUnlock2.tilesToUnlock)
			{
				if (item.IsUnlocked())
				{
					flag = true;
					continue;
				}
				flag = false;
				break;
			}
			if (flag)
			{
				tileUnlock2.ach_instance.QuickUnlockAchievement();
			}
		}
	}

	public void CheckAchievement(string ACHIEVEMENT_KEY)
	{
		TileUnlock tileUnlock = tileUnlocks.Find((TileUnlock x) => x.ach_key == ACHIEVEMENT_KEY);
		if (SteamManager.Initialized && !DemoController.Instance.IsDemo())
		{
			SteamUserStats.GetAchievement(ACHIEVEMENT_KEY, out var pbAchieved);
			if (!pbAchieved && SteamUserStats.RequestCurrentStats())
			{
				SteamUserStats.SetAchievement(ACHIEVEMENT_KEY);
				SteamUserStats.StoreStats();
				StartCoroutine(UpdateAchievementsPanel(tileUnlock));
			}
		}
		try
		{
			int num = 0;
			foreach (GridObject item in tileUnlock.tilesToUnlock)
			{
				if (DemoController.Instance.IsDemo() && !item.CanBeUnlockedInDemo())
				{
					break;
				}
				if (item.IsUnlocked())
				{
					if (num == tileUnlock.tilesToUnlock.Count - 1)
					{
						break;
					}
				}
				else
				{
					item.SetUnlocked();
					gridObjectsToShowAsUnlocked.Add(item);
				}
			}
		}
		catch
		{
			MonoBehaviour.print("No tile to unlock found");
		}
	}

	private IEnumerator UpdateAchievementsPanel(TileUnlock _achievementUnlocked)
	{
		confettiBurst.SetActive(value: true);
		DOTween.Sequence();
		achievementsButton.DOScale(new Vector3(2f, 2f, 2f), 0.75f);
		achievementsButton.DOLocalRotate(new Vector3(0f, 0f, 360f), 0.75f, RotateMode.FastBeyond360).SetRelative(isRelative: true).SetEase(Ease.OutExpo);
		yield return new WaitForSeconds(1f);
		achievementsButton.DOScale(Vector3.one, 0.75f).SetEase(Ease.OutElastic);
		achievementsButton.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.75f, RotateMode.FastBeyond360).SetRelative(isRelative: true).SetEase(Ease.OutElastic);
		yield return new WaitForSeconds(0.75f);
		achievementsButton.localRotation = Quaternion.Euler(0f, 0f, 0f);
		_achievementUnlocked.ach_instance.SetAchievementUnlocked();
		soundManager1.PlaySound(unlockSound1, randomPitch: false);
		yield return new WaitForSeconds(1.25f);
		soundManager2.PlaySound(unlockSound2, randomPitch: false);
	}

	public void ShowUnlockedTile()
	{
		if (gridObjectsToShowAsUnlocked.Count <= 0)
		{
			TileUnlockController.Instance.HideTileUnlockCanvas();
			TileUnlockController.Instance.ShowAllTiles();
			if (MouseController.Instance.CheckIfAllTilesUnlocked() && !DemoController.Instance.IsDemo())
			{
				CheckAchievement("TRUE_RULER");
			}
		}
		else
		{
			TileUnlockController.Instance.UnlockTile(gridObjectsToShowAsUnlocked[gridObjectsToShowAsUnlocked.Count - 1]);
			gridObjectsToShowAsUnlocked.RemoveAt(gridObjectsToShowAsUnlocked.Count - 1);
		}
	}

	public bool HasTilesToShowAsUnlocked()
	{
		return gridObjectsToShowAsUnlocked.Count > 0;
	}

	public void CheckForAchievements()
	{
		gridObjectsPlaced = GameManager.Instance.GetAllGridObjects();
		relevantObjectTypes = new List<ObjectType>();
		int worldSize = GridController.Instance.GetWorldSize();
		int count = GridController.Instance.GetAllTiles().Count;
		allTilesAreBuiltOn = gridObjectsPlaced.Count + Object.FindObjectsOfType<TileObject>().Count((TileObject tileObject) => tileObject.IsWater()) >= count;
		relevantObjectTypes.Clear();
		CheckAchievement("FIRST_BUILD");
		if (GridController.Instance.GetWorldSize() == 1)
		{
			CheckAchievement("QUICK_RUSH");
			relevantObjectTypes.Add(ObjectType.rock);
			if (gridObjectsPlaced.FindAll((GridObject gridObject) => relevantObjectTypes.Intersect(gridObject.GetObjectTypes()).Any()).Count != 0)
			{
				CheckAchievement("THE_ROCK");
			}
			relevantObjectTypes.Clear();
			relevantObjectTypes.Add(ObjectType.houses);
			if (gridObjectsPlaced.FindAll((GridObject gridObject) => relevantObjectTypes.Intersect(gridObject.GetObjectTypes()).Any()).Count != 0)
			{
				CheckAchievement("HERMIT");
			}
			gridObjectsToShowAsUnlocked.Reverse();
			return;
		}
		relevantObjectTypes.Add(ObjectType.castle);
		relevantObjectTypes.Add(ObjectType.wall);
		relevantObjectTypes.Add(ObjectType.gate);
		if (gridObjectsPlaced.FindAll((GridObject gridObject) => relevantObjectTypes.Intersect(gridObject.GetObjectTypes()).Any()).Count == 0 && allTilesAreBuiltOn)
		{
			CheckAchievement("NO_CASTLE_OBJECTS");
		}
		relevantObjectTypes.Clear();
		if (allTilesAreBuiltOn)
		{
			relevantObjectTypes.Add(ObjectType.trees);
			relevantObjectTypes.Add(ObjectType.water);
			relevantObjectTypes.Add(ObjectType.rock);
			if (gridObjectsPlaced.FindAll((GridObject gridObject) => relevantObjectTypes.Intersect(gridObject.GetObjectTypes()).Any()).Count == 0)
			{
				CheckAchievement("BE_GONE_NATURE");
			}
		}
		relevantObjectTypes.Clear();
		if (allTilesAreBuiltOn)
		{
			relevantObjectTypes.Add(ObjectType.houses);
			if (gridObjectsPlaced.FindAll((GridObject gridObject) => relevantObjectTypes.Intersect(gridObject.GetObjectTypes()).Any()).Count >= 3)
			{
				CheckAchievement("CITY_BUILDER");
			}
		}
		relevantObjectTypes.Clear();
		if (allTilesAreBuiltOn)
		{
			int count2 = gridObjectsPlaced.FindAll((GridObject gridObject) => gridObject.GetObjectTypes().Contains(ObjectType.houses)).Count;
			int count3 = gridObjectsPlaced.FindAll((GridObject gridObject) => gridObject.GetObjectTypes().Contains(ObjectType.cavalry)).Count;
			if (count3 > count2 && count3 > 0 && count2 > 0)
			{
				CheckAchievement("OVER_POPULATION");
			}
		}
		relevantObjectTypes.Clear();
		if (worldSize == 11 && allTilesAreBuiltOn)
		{
			CheckAchievement("NO_MINIMALISM");
		}
		relevantObjectTypes.Clear();
		if (worldSize >= 3 && allTilesAreBuiltOn && (from tileObject in Object.FindObjectsOfType<TileObject>()
			where tileObject.IsWater()
			select tileObject).Count() >= worldSize * worldSize)
		{
			CheckAchievement("OCEAN_TIME");
		}
		relevantObjectTypes.Clear();
		if (worldSize >= 5 && gridObjectsPlaced.Count == 1)
		{
			CheckAchievement("WHATS_THE_POINT");
		}
		relevantObjectTypes.Clear();
		if (worldSize >= 5 && allTilesAreBuiltOn)
		{
			relevantObjectTypes.Add(ObjectType.farm);
			relevantObjectTypes.Add(ObjectType.market);
			if (gridObjectsPlaced.FindAll((GridObject gridObject) => relevantObjectTypes.Intersect(gridObject.GetObjectTypes()).Any()).Count == 0)
			{
				CheckAchievement("FOOD_IS_FOR_THE_WEAK");
			}
		}
		relevantObjectTypes.Clear();
		relevantObjectTypes.Add(ObjectType.castle);
		int num = worldSize / 2 * 15;
		bool flag = true;
		if (worldSize >= 5)
		{
			for (int x = -num; x < num; x += 15)
			{
				int z;
				for (z = -num; z < num; z += 15)
				{
					if (x == num || x == -num || z == num || z == -num)
					{
						if (!gridObjectsPlaced.Exists((GridObject gridObject) => gridObject.transform.parent.position.x == (float)x && gridObject.transform.parent.position.z == (float)z))
						{
							flag = false;
							break;
						}
						if (!gridObjectsPlaced.Find((GridObject gridObject) => gridObject.transform.parent.position.x == (float)x && gridObject.transform.parent.position.z == (float)z).GetObjectTypes().Contains(ObjectType.castle))
						{
							flag = false;
							break;
						}
					}
				}
				if (!flag)
				{
					break;
				}
			}
			if (flag)
			{
				CheckAchievement("PROPER_KINGDOM");
			}
		}
		if (worldSize >= 3 && allTilesAreBuiltOn)
		{
			CheckAchievement("FILL_IT_UP");
		}
		if (worldSize >= 5 && allTilesAreBuiltOn)
		{
			CheckAchievement("MAKE_IT_BIGGER");
		}
		if (worldSize >= 7 && allTilesAreBuiltOn)
		{
			CheckAchievement("MAKE_IT_THE_BIGGEST");
		}
		if (worldSize >= 9 && allTilesAreBuiltOn)
		{
			CheckAchievement("MAKE_IT_MASSIVE");
		}
		gridObjectsToShowAsUnlocked.Reverse();
	}
}
