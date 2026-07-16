using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDebugEnemies : Menu
{
	[SerializeField]
	private GameObject buttonPrefab;

	[SerializeField]
	private GameObject buttonBack;

	[SerializeField]
	private GameObject buttonsHolder;

	[SerializeField]
	private GameObject enemiesHolder;

	[SerializeField]
	private SerializedDictionary<Button, SpawnZone> Buttons;

	private List<GameObject> enemyButtons;

	public override void Init()
	{
		enemyButtons = new List<GameObject>();
		foreach (Button key in Buttons.Keys)
		{
			SpawnZone zone = Buttons[key];
			key.onClick.AddListener(delegate
			{
				InstantiateEnemyButtons(zone);
				buttonsHolder.SetActive(value: false);
			});
		}
	}

	protected override void OnClose()
	{
		base.OnClose();
		buttonsHolder.SetActive(value: true);
		while (enemyButtons.Count > 0)
		{
			Object.Destroy(enemyButtons[enemyButtons.Count - 1].gameObject);
			enemyButtons.RemoveAt(enemyButtons.Count - 1);
		}
	}

	public void InstantiateEnemyButtons(SpawnZone zone)
	{
		EnemyBase[] enemies = (from enemyGO in EnemyManager.Instance.EnemyPrefabs
			select enemyGO.Value.GetComponent<EnemyBase>() into enemyBase
			where enemyBase != null && !enemyBase.IsBoss && enemyBase.spawnZone == zone
			select enemyBase).ToArray();
		for (int num = 0; num < enemies.Length; num++)
		{
			int index = num;
			GameObject gameObject = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, enemiesHolder.transform);
			enemyButtons.Add(gameObject);
			if (index == 0)
			{
				defaultSelectedGo = gameObject;
			}
			gameObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				EnemyManager.Instance.SpawnEnemy(enemies[index].gameObject);
			});
			gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = enemies[index].Name;
		}
	}

	public void BackButton()
	{
		if (buttonsHolder.activeSelf)
		{
			MenuManager.Instance.CloseCurrentMenu();
			return;
		}
		buttonsHolder.SetActive(value: true);
		while (enemyButtons.Count > 0)
		{
			Object.Destroy(enemyButtons[enemyButtons.Count - 1].gameObject);
			enemyButtons.RemoveAt(enemyButtons.Count - 1);
		}
	}
}
