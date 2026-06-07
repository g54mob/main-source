using System;
using TMPro;
using UnityEngine;

public class UpcomingEventRow : MonoBehaviour
{
	private UpcomingEvents upcomingEvents;

	private string unitName;

	[NonSerialized]
	public float deltaT;

	private int count;

	public TextMeshProUGUI textRow;

	private bool refreshed;

	public void Init(UpcomingEvents upcomingEvents)
	{
	}

	public void Refresh(string unitName, int count, float deltaT)
	{
	}

	public void LateRefresh()
	{
	}
}
