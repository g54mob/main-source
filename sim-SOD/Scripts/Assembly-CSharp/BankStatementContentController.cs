using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankStatementContentController : MonoBehaviour
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

	public string transactionMessageID;

	public VerticalLayoutGroup entryLayoutGroup;

	public List<BankStatementEntryController> spawnedEntries;

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
