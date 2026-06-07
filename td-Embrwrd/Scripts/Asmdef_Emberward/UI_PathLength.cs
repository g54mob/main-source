using TMPro;
using UnityEngine;

public class UI_PathLength : MonoBehaviour
{
	[SerializeField]
	private GameObject node_Content;

	[SerializeField]
	private TMP_Text text_Length;

	private bool isActivated;

	private float detectTimer;

	private float detectInterval;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameSettingChanged()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void UpdateLength()
	{
	}

	private int GetMaxMazeLength()
	{
		return 0;
	}
}
