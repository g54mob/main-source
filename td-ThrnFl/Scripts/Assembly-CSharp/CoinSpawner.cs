using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	public GameObject coinPrefab;

	public float interval = 0.5f;

	private int coinsLeft;

	public static List<CoinSpawner> allCoinSpawners = new List<CoinSpawner>();

	public int CoinsLeft => coinsLeft;

	public static int AllCoinsLeftToBeSpawned
	{
		get
		{
			int num = 0;
			for (int num2 = allCoinSpawners.Count - 1; num2 >= 0; num2--)
			{
				if (allCoinSpawners[num2] == null)
				{
					allCoinSpawners.RemoveAt(num2);
				}
				else
				{
					num += allCoinSpawners[num2].CoinsLeft;
				}
			}
			return num;
		}
	}

	private void OnEnable()
	{
		allCoinSpawners.Add(this);
	}

	private void OnDisable()
	{
		allCoinSpawners.Remove(this);
	}

	public void TriggerCoinSpawn(int amount, PlayerInteraction player)
	{
		StartCoroutine(SpawnCoins(amount, interval, player));
	}

	private IEnumerator SpawnCoins(int amount, float delay, PlayerInteraction player)
	{
		coinsLeft = amount;
		WaitForSeconds wait = new WaitForSeconds(delay);
		for (int i = 0; i < amount; i++)
		{
			coinsLeft--;
			Object.Instantiate(coinPrefab, base.transform.position, Quaternion.identity).GetComponent<Coin>().SetTarget(player);
			yield return wait;
		}
	}
}
