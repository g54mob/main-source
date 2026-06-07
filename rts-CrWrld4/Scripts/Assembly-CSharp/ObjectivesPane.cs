using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectivesPane : MonoBehaviour
{
	public GameObject objectiveRowPrefab;

	public GameObject objectiveOptionalPrefab;

	public Transform rowContainer;

	public TextMeshProUGUI requiredAnyText;

	public GameObject evacButton;

	public GameObject jumpingIndicator;

	private List<ObjectiveRow> rows;

	private int[] lastState;

	private bool requiredMode;

	public void OnEnable()
	{
	}

	private int GetState(int i)
	{
		return 0;
	}

	public bool RefreshContainer()
	{
		return false;
	}

	public void LateUpdate()
	{
	}

	private void ShowEvac()
	{
	}

	private void HideEvac()
	{
	}

	private void ShowJumpingIndicator()
	{
	}

	private void HideJumpingIndicator()
	{
	}
}
