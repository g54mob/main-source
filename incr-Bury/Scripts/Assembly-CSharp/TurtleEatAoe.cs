using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleEatAoe : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> berriesInEatRange = new List<GameObject>();

	[Header("Turtle Parent")]
	[SerializeField]
	private GameObject turtleParent;

	[Header("Eating Params")]
	[SerializeField]
	private float canEatTimer_Curr;

	private bool canEat;

	[Header("Coin Spawning")]
	[SerializeField]
	private GameObject coinSpawnPoint;

	[SerializeField]
	private GameObject coinEjectTarget;

	[SerializeField]
	private float coinEject_Force;

	[SerializeField]
	private float coinEject_Torque;

	[Header("Coin Queue")]
	[SerializeField]
	private List<CoinPrefabValueSet> coinQueue = new List<CoinPrefabValueSet>();

	[SerializeField]
	private Vector2 coinQueueSpeed_MinMax;

	[SerializeField]
	private float queueSpeedMultiplierByCount;

	[SerializeField]
	private float coinQueue_ProcessSpeed;

	private float coinQueue_ProcessSpeed_Curr;

	private bool coinQueue_CanCompactValues;

	private Vector3 dirToChosenBerry;

	private Quaternion lookDirToBerry;

	private float angleThresholdForFacingBerry = 5f;

	private void Start()
	{
		coinQueue_CanCompactValues = true;
	}

	private void Update()
	{
		HandleCanEatCooldownTimer();
		HandleCoinQueue();
	}

	private void HandleCanEatCooldownTimer()
	{
		if (canEatTimer_Curr < PlayerStats.Singleton.turtleEatCooldown)
		{
			canEatTimer_Curr += Time.deltaTime;
		}
		else
		{
			canEatTimer_Curr = PlayerStats.Singleton.turtleEatCooldown;
		}
		canEat = canEatTimer_Curr == PlayerStats.Singleton.turtleEatCooldown;
	}

	private void HandleEatingBerriesNearby()
	{
		if (berriesInEatRange.Count > 0)
		{
			if (berriesInEatRange[0] == null)
			{
				berriesInEatRange.RemoveAt(0);
			}
			else
			{
				EatBerry(berriesInEatRange[0]);
			}
		}
	}

	private void EatBerry(GameObject _berry)
	{
		berriesInEatRange.Remove(_berry);
		Berry component = _berry.GetComponent<Berry>();
		component.CalculateCoinPayout();
		if (component.isNebulaBerry)
		{
			SpawnSeeds(component.berryTier + 1);
		}
		List<CoinPrefabValueSet> coinPrefabsFromAmount = GameManager.Singleton.GetCoinPrefabsFromAmount(component.GetPickUpScript().coinValue);
		AddCoinsToCoinQueue(coinPrefabsFromAmount);
		Object.Destroy(_berry);
		canEatTimer_Curr = 0f;
		if (PlayerStats.Singleton.RollForSeedDrop())
		{
			SpawnSeeds(1);
		}
	}

	public void SpawnACertainValueOfCoins(int _value)
	{
		List<CoinPrefabValueSet> coinPrefabsFromAmount = GameManager.Singleton.GetCoinPrefabsFromAmount(_value);
		AddCoinsToCoinQueue(coinPrefabsFromAmount);
	}

	private void SpawnSeeds(int _amount)
	{
		Vector3 normalized = (coinEjectTarget.transform.position - coinSpawnPoint.transform.position).normalized;
		Vector3 one = Vector3.one;
		for (int i = 0; i < _amount; i++)
		{
			Rigidbody component = Object.Instantiate(GameManager.Singleton.prefabBank.seedPrefab, coinSpawnPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			component.AddForce(normalized * coinEject_Force, ForceMode.VelocityChange);
			one = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			component.AddTorque(one * coinEject_Torque, ForceMode.VelocityChange);
		}
	}

	private void AddCoinsToCoinQueue(List<CoinPrefabValueSet> _coinPrefabsToSpawn)
	{
		foreach (CoinPrefabValueSet item in _coinPrefabsToSpawn)
		{
			coinQueue.Add(item);
		}
	}

	private void HandleCoinQueue()
	{
		if (!CompactCoinValuesIfQueueIsTooFull())
		{
			queueSpeedMultiplierByCount = 1f + Mathf.Lerp(coinQueueSpeed_MinMax.x, coinQueueSpeed_MinMax.y, Mathf.InverseLerp(0f, 100f, coinQueue.Count));
			if (coinQueue_ProcessSpeed_Curr > 0f)
			{
				coinQueue_ProcessSpeed_Curr -= Time.deltaTime * queueSpeedMultiplierByCount;
			}
			else if (coinQueue.Count > 0)
			{
				SpawnCoin(coinQueue[0].coinPrefab);
				coinQueue.RemoveAt(0);
				coinQueue_ProcessSpeed_Curr = coinQueue_ProcessSpeed;
			}
		}
	}

	private bool CompactCoinValuesIfQueueIsTooFull()
	{
		if (coinQueue_CanCompactValues && coinQueue.Count > 100)
		{
			int count = coinQueue.Count;
			int num = 0;
			foreach (CoinPrefabValueSet item in coinQueue)
			{
				num += item.coinValue;
			}
			coinQueue.Clear();
			List<CoinPrefabValueSet> coinPrefabsFromAmount = GameManager.Singleton.GetCoinPrefabsFromAmount(num);
			AddCoinsToCoinQueue(coinPrefabsFromAmount);
			int count2 = coinQueue.Count;
			Debug.Log("Compacted Coins from " + count + " to " + count2);
			StartCoroutine(HandleCoinQueueCompactingCooldown_Coroutine());
			return true;
		}
		return false;
	}

	private IEnumerator HandleCoinQueueCompactingCooldown_Coroutine()
	{
		coinQueue_CanCompactValues = false;
		yield return new WaitForSeconds(1f);
		coinQueue_CanCompactValues = true;
	}

	private void SpawnCoin(GameObject _coinPrefab)
	{
		Vector3 vector = coinEjectTarget.transform.position - coinSpawnPoint.transform.position;
		Vector3 one = Vector3.one;
		Rigidbody component = Object.Instantiate(_coinPrefab, coinSpawnPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
		component.AddForce(vector * coinEject_Force, ForceMode.VelocityChange);
		one = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		component.AddTorque(one * coinEject_Torque, ForceMode.VelocityChange);
		AudioManager.Singleton.PlayCoinSpawnSFX(GameManager.Singleton.GetYardObject().transform.position);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (GameManager.Singleton.gameState != GameManager.GameState.Playing || !other.gameObject.transform.root.CompareTag("PickUp"))
		{
			return;
		}
		bool flag = true;
		PickUppable component = other.gameObject.transform.root.GetComponent<PickUppable>();
		if (component.hasBeenDepositedInHole || component.GetItemIdentity() == ItemIdentity.Cultist || component.GetItemIdentity() == ItemIdentity.BlenderBot)
		{
			return;
		}
		switch (component.GetPickUpType())
		{
		case PickUpType.Berry:
			if (component.GetItemIdentity() == ItemIdentity.Smoothie)
			{
				PlayerStats.Singleton.deposited_SmoothieTotal++;
				GameManager.Singleton.holePrestigeJuice_Curr += component.smoothie_holePrestigeJuice;
				AnomalousMaterial_Manager.Singleton.RollForAnomalousMaterialDrop();
			}
			else if (component.GetItemIdentity() < ItemIdentity.Seed)
			{
				PlayerStats.Singleton.deposited_BerryTotals[(int)component.GetItemIdentity()]++;
				AnomalousMaterial_Manager.Singleton.RollForAnomalousMaterialDrop();
				int berryTier = component.GetComponent<Berry>().berryTier;
				try
				{
					GameManager.Singleton.holePrestigeJuice_Curr += berryTier + 1;
				}
				catch
				{
				}
				GameManager.Singleton.AddHoleMoveJuice(berryTier + 1);
			}
			break;
		case PickUpType.AnomalousMaterial:
			return;
		case PickUpType.MilestoneObject:
			if (component.isLargeEnoughToNotImmediatelyDeposit)
			{
				component.StartLargeObjectDepositingTimer();
				flag = false;
			}
			else
			{
				GameManager.Singleton.SpawnStarOrbsFromHoleDeposit(component);
			}
			if (component.isGnome)
			{
				StartCoroutine(GameManager.Singleton.WaitAFrameThenCheckHowManyGnomesWeHaveLeft());
			}
			break;
		case PickUpType.Candy:
			GameManager.Singleton.ActivateSugarRush();
			break;
		case PickUpType.TrackedPickUp:
			GameManager.Singleton.SetMilestoneFlagToFalse(component);
			break;
		}
		if (component.holeJuiceValue > 0f)
		{
			GameManager.Singleton.AddHoleMoveJuice(component.holeJuiceValue);
		}
		if (component.coinValue > 0)
		{
			List<CoinPrefabValueSet> coinPrefabsFromAmount = GameManager.Singleton.GetCoinPrefabsFromAmount(component.coinValue);
			AddCoinsToCoinQueue(coinPrefabsFromAmount);
		}
		else if (component.coinValue == -666 && !GameManager.Singleton.belladonnaBuddyEnding_IsActive)
		{
			GameManager.Singleton.SwitchToBelladonnaBuddyEndingEnvironment();
		}
		if (component.JUICED_amt > 0)
		{
			GameManager.Singleton.AddJUICEDJuice(component.JUICED_amt);
		}
		component.hasBeenDepositedInHole = true;
		if (flag && !component.doNotDestroyInHole)
		{
			Object.Destroy(other.gameObject.transform.root.gameObject);
		}
		if (component.doNotDestroyInHole)
		{
			component.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
			component.gameObject.transform.position = GameManager.Singleton.GetYardObject().transform.position + Vector3.up * 7f;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		other.gameObject.transform.root.CompareTag("PickUp");
	}
}
