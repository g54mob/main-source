using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectivesContentController : MonoBehaviour
{
	[Header("References")]
	public WindowContentController wcc;

	public RectTransform pageRect;

	public RectTransform objectiveContainer;

	public SideJob job;

	public TextMeshProUGUI jobDetails;

	public List<ObjectiveContentListEntry> spawnedStartingObjectives;

	[Header("Prefabs")]
	public GameObject elementPrefab;

	public void Setup(WindowContentController newWcc)
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateJobDetails()
	{
	}
}
