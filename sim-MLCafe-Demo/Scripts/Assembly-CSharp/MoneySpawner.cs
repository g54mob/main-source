using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject coinPrefab;

	[SerializeField]
	private Transform container;

	private List<CoinComponent> coins = new List<CoinComponent>();

	public void SpawnAmount(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject obj = Object.Instantiate(coinPrefab, container);
			obj.transform.position = container.position + Vector3.up * 0.012f * i;
			CoinComponent component = obj.GetComponent<CoinComponent>();
			component.Init(1);
			coins.Add(component);
		}
	}

	public void TakeAllSpawnedMoney()
	{
		string text = "";
		foreach (CoinComponent coin in coins)
		{
			if (!(coin == null))
			{
				coin.TakeCoin(playSound: false);
				text = coin.soundTakeCoin;
			}
		}
		SoundManager.PlaySoundOnce(text);
		coins.Clear();
	}

	public List<CoinComponent> GetCoins()
	{
		return coins;
	}
}
