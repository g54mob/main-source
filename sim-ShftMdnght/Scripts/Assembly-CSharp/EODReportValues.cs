using System.Collections.Generic;
using UnityEngine;

public class EODReportValues : MonoBehaviour
{
	public float mandatoryRevenue;

	public float todayMoneyGained;

	public float todayMoneyLost;

	public int doppelsLetThru;

	public List<int> npcID = new List<int>();

	public List<int> npcKilledID = new List<int>();

	public int todaysDayObjIndex;

	public int curDay;

	public static EODReportValues Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
