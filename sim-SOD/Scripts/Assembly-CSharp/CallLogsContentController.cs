using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CallLogsContentController : MonoBehaviour
{
	public WindowContentController windowContent;

	public InfoWindow parentWindow;

	public TextMeshProUGUI descriptionText;

	public GameObject entryPrefab;

	public bool incoming;

	public TextMeshProUGUI titleText;

	public List<CallLogsEntryController> spawnedEntries;

	public VerticalLayoutGroup layout;

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
