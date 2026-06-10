using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SalesLedgerContentController : MonoBehaviour
{
	public class Transaction
	{
		public string text;

		public int amount;
	}

	public WindowContentController windowContent;

	public InfoWindow parentWindow;

	public TextMeshProUGUI descriptionText;

	public GameObject entryPrefab;

	public List<SalesLedgerEntryController> spawnedEntries;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void CheckEnabled()
	{
	}
}
