using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public int coinTier;

	private int coinValue;

	private bool hasDepositied;

	private void Start()
	{
		CalculateCoinValue();
		GameManager.Singleton.AddToSpawnedCoinList(base.gameObject);
		StartCoroutine(ChangeLayerAfterAFewSeconds());
	}

	private void OnDestroy()
	{
		GameManager.Singleton.RemoveFromSpawnedCoinList(base.gameObject);
		StopAllCoroutines();
	}

	public void CalculateCoinValue()
	{
		coinValue = GameManager.Singleton.prefabBank.coinValueAmounts[coinTier];
	}

	public int GetCoinValue()
	{
		return coinValue;
	}

	private IEnumerator ChangeLayerAfterAFewSeconds()
	{
		yield return new WaitForSeconds(2f);
		base.gameObject.layer = 0;
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.layer = 0;
		}
	}
}
