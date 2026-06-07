using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class HuntManager : NetworkBehaviour
{
	public GameObject[] allBarricades;

	public Transform[] allVents;

	public bool annoyedState;

	public AstarPath path;

	public List<GameObject> allEnemyHolders;

	public List<Enemy> allEnemies;

	public Transform[] huntSpawnPoints;

	public Transform leavePoint;

	public bool oneCreature;

	public GameObject[] monsterObjs;

	public int[] monsterDifficultyPoints;

	public int[] monsterSingleplayerDifficultyPoints;

	public int[] monsterMinimumDay;

	public GameObject jackInTheBox;

	public static HuntManager Instance { get; private set; }

	public void StartHunt()
	{
		if (ClientPlayer.Instance.isServer)
		{
			Invoke("SpawnEnemies", 1f);
		}
	}

	private void SpawnEnemies()
	{
		if (SaveManager.Instance.huntsDone == 1)
		{
			SpawnEnemy(0);
			return;
		}
		if (StoreManager.Instance.demo)
		{
			SpawnEnemy(0);
			SpawnEnemy(2);
			return;
		}
		int num = 10 + (StoreManager.Instance.doppelsLetThru - 1) * 7 + CurrentDayManager.Instance.curDay * 2;
		int num2 = 0;
		int num3 = 1000;
		int num4 = 0;
		while (num4++ < num3)
		{
			int num5 = num - num2;
			if (num5 <= 0)
			{
				break;
			}
			List<int> shuffledIndices = GetShuffledIndices(monsterDifficultyPoints.Length);
			bool flag = false;
			foreach (int item in shuffledIndices)
			{
				int num6 = 0;
				num6 = ((StoreManager.Instance.playerMans.Count >= 2) ? monsterDifficultyPoints[item] : monsterSingleplayerDifficultyPoints[item]);
				if (num6 > 0 && num6 <= num5 && monsterMinimumDay[item] <= CurrentDayManager.Instance.curDay)
				{
					SpawnEnemy(item);
					num2 += num6;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Debug.Log($"No monsters fit remaining difficulty={num5}. Exiting. " + $"Target={num}, Current={num2}");
				break;
			}
		}
		if (num4 >= num3)
		{
			Debug.LogWarning("SpawnEnemies hit maxIterations guard (check monsterDifficultyPoints values).");
		}
	}

	private List<int> GetShuffledIndices(int length)
	{
		List<int> list = new List<int>(length);
		for (int i = 0; i < length; i++)
		{
			list.Add(i);
		}
		for (int num = list.Count - 1; num > 0; num--)
		{
			int num2 = Random.Range(0, num + 1);
			List<int> list2 = list;
			int index = num;
			List<int> list3 = list;
			int index2 = num2;
			int num3 = list[num2];
			int num4 = list[num];
			int num5 = (list2[index] = num3);
			num5 = (list3[index2] = num4);
		}
		return list;
	}

	public void SpawnEnemy(int enemyType)
	{
		GameObject gameObject = Object.Instantiate(monsterObjs[enemyType], base.transform.position, Quaternion.identity);
		NetworkServer.Spawn(gameObject);
		int num = Random.Range(0, huntSpawnPoints.Length - 1);
		allEnemies.Add(gameObject.GetComponent<EnemyHolder>().enemy);
		gameObject.GetComponent<EnemyHolder>().enemy.transform.position = huntSpawnPoints[num].position;
		allEnemyHolders.Add(gameObject);
		gameObject.GetComponent<EnemyHolder>().enemy.leaveLocation = leavePoint;
	}

	public void EnemyDied()
	{
		Invoke("CheckEnemiesLeft", 0.2f);
	}

	private void CheckEnemiesLeft()
	{
		int num = 0;
		bool flag = true;
		foreach (Enemy allEnemy in allEnemies)
		{
			if (allEnemy.gameObject.activeInHierarchy && !allEnemy.leaving)
			{
				num++;
				flag = false;
			}
		}
		_ = 1;
		if (flag)
		{
			StoreManager.Instance.Invoke("EndHunt", 1f);
			JackInTheBox.Instance.opened = true;
			NetworkServer.Destroy(JackInTheBox.Instance.gameObject);
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}
}
