using System.Collections.Generic;
using UnityEngine;

public class UpcomingEvents : MonoBehaviour
{
	public GameObject rowPrefab;

	public Transform rowContainer;

	private Dictionary<string, UpcomingEventRow> rows;

	public void AddItem(string unit, int count, float deltaT)
	{
	}

	public void GameUpdate()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
