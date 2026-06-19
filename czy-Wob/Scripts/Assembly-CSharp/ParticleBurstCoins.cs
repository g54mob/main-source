using System.Collections.Generic;
using UnityEngine;

public class ParticleBurstCoins : MonoBehaviour
{
	public GameObject coinPrefab;

	private int coinNum = 100;

	private List<Rigidbody> coinBodyList = new List<Rigidbody>();

	private Vector3 coinForce = new Vector3(0f, -19f, 0f);

	private float timer = 3f;

	private float currentTimer;

	private void Awake()
	{
		SpawnCoins();
	}

	private void FixedUpdate()
	{
		CoinForce();
	}

	private void Update()
	{
		Tick();
	}

	private void SpawnCoins()
	{
		for (int i = 0; i < coinNum; i++)
		{
			GameObject gameObject = Object.Instantiate(coinPrefab, base.transform.position, Random.rotation, base.transform);
			coinBodyList.Add(gameObject.GetComponent<Rigidbody>());
		}
	}

	private void CoinForce()
	{
		for (int i = 0; i < coinBodyList.Count; i++)
		{
			coinBodyList[i].AddForce(coinForce);
		}
	}

	private void Tick()
	{
		currentTimer += Time.deltaTime;
		if (currentTimer >= timer)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
