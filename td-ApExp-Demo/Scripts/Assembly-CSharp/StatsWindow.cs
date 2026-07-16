using System;
using TMPro;
using UnityEngine;

public class StatsWindow : Menu, ISaveable
{
	[Header("Stats")]
	[SerializeField]
	private TextMeshProUGUI mostEnemiesTx;

	[SerializeField]
	private TextMeshProUGUI mostDamageDealtTx;

	[SerializeField]
	private TextMeshProUGUI totalEnemiesTx;

	[SerializeField]
	private TextMeshProUGUI totalKmTraveledTx;

	[SerializeField]
	private TextMeshProUGUI totalJourneysTx;

	[NonSerialized]
	public float enemiesKilled;

	[NonSerialized]
	public float damageDealt;

	[NonSerialized]
	public float kmTraveled;

	private float mostEnemiesKilled;

	private float mostDamageDealt;

	private float totalEnemiesKilled;

	private float totalKilometersTraveled;

	public float totalJourneys;

	[NonSerialized]
	public bool isReadyToSave;

	protected override void Awake()
	{
		base.Awake();
		Debug.LogWarning("Stats window awake");
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		mostEnemiesTx.text = mostEnemiesKilled.ToString();
		mostDamageDealtTx.text = mostDamageDealt.ToString();
		totalEnemiesTx.text = totalEnemiesKilled.ToString();
		totalKmTraveledTx.text = totalKilometersTraveled.ToString();
		totalJourneysTx.text = totalJourneys.ToString();
	}

	public void Save(SaveDataContext context)
	{
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		MetaSavefile metaSave = context.MetaSave;
		mostEnemiesKilled = metaSave.mostEnemiesKilled;
		mostDamageDealt = metaSave.mostDamageDealt;
		totalEnemiesKilled = metaSave.totalEnemiesKilled;
		totalKilometersTraveled = metaSave.totalKilometersTraveled;
		totalJourneys = metaSave.totalJourneys;
		Debug.Log("Loaded Stats");
	}
}
