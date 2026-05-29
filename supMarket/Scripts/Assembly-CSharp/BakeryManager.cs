using System;
using System.Collections.Generic;
using UnityEngine;

public class BakeryManager : NoktaSingleton<BakeryManager>
{
	[SerializeField]
	private GameObject m_BakerPrefab;

	public List<Oven> Ovens;

	public List<Baker> Bakers;

	public Action<Oven> OnOvenAdded;

	public Action<Oven> OnOvenRemoved;

	public Action<Oven> OnOvenBakeFinished;

	public Action<Display> OnBakeryDisplayAdded;

	public Action<Display> OnBakeryDisplayRemoved;

	public List<Oven> GetOvenList()
	{
		return null;
	}

	public void SubscribeBaker(Baker baker)
	{
	}

	public void UnsubscribeBaker(Baker baker)
	{
	}

	public void SubscribeOven(Oven oven)
	{
	}

	public void UnsubscribeOven(Oven oven)
	{
	}

	public void SpawnBaker(int bakerId)
	{
	}

	public void DespawnBaker()
	{
	}

	public void DespawnBakerNetwork()
	{
	}

	public Transform GetBakerWaitingPosition(Baker baker = null)
	{
		return null;
	}
}
