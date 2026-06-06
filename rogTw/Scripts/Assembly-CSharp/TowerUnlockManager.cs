using System.Collections.Generic;
using UnityEngine;

public class TowerUnlockManager : MonoBehaviour
{
	public static TowerUnlockManager instance;

	[SerializeField]
	private List<GameObject> unlockedTowers = new List<GameObject>();

	[SerializeField]
	private List<GameObject> unlockedBuildings = new List<GameObject>();

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		DisplayButtons();
	}

	public void UnlockTower(GameObject towerUIObject, bool isTower)
	{
		towerUIObject.SetActive(value: true);
		if (isTower)
		{
			unlockedTowers.Add(towerUIObject);
		}
		else
		{
			unlockedBuildings.Add(towerUIObject);
		}
		DisplayButtons();
	}

	private void DisplayButtons()
	{
		int num = 0;
		int num2 = ((unlockedBuildings.Count > 0) ? 1 : 0);
		foreach (GameObject unlockedTower in unlockedTowers)
		{
			unlockedTower.transform.localPosition = new Vector3(num * 100 - unlockedTowers.Count * 50 + 50, 100 * num2, 0f);
			num++;
		}
		num = 0;
		foreach (GameObject unlockedBuilding in unlockedBuildings)
		{
			unlockedBuilding.transform.localPosition = new Vector3(num * 100 - unlockedBuildings.Count * 50 + 50, 0f, 0f);
			num++;
		}
	}
}
