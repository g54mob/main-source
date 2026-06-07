using System.Collections.Generic;
using UnityEngine;

public class CheckoutChangeManager : MonoBehaviour
{
	private const float m_MoneyJumpPower = 0.1f;

	private const float m_MoneyJumpDuration = 0.5f;

	[SerializeField]
	private Transform m_PaperMoneySpawnPosition;

	[SerializeField]
	private float m_GapBetweenPaperMoney;

	[SerializeField]
	private Transform m_CoinSpawnPosition;

	[SerializeField]
	private float m_GapBetweenCoin;

	private List<Money> m_SpawnedMoney;

	private List<Money> m_SpawnedCoin;

	private MoneyPack[] m_MoneyPacks;

	private void Awake()
	{
	}

	public bool AddOrRemoveMoney(MoneyPack moneyPack, bool add)
	{
		return false;
	}

	public void ResetChange()
	{
	}

	private void SpawnMoney(MoneyPack moneyPack, bool isCoin)
	{
	}

	private bool DespawnMoney(MoneyPack moneyPack, bool isCoin)
	{
		return false;
	}

	private void UpdateMoneyPosition(int indexFrom)
	{
	}

	private void UpdateCoinPosition(int indexFrom)
	{
	}
}
