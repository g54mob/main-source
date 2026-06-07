using System.Collections.Generic;
using UnityEngine;

public class AlphaZone : MonoBehaviour
{
	public GameObject regionButtonPrefab;

	public GameObject regionLinePrefab;

	public Transform horizontalLine;

	public Transform verticalLine;

	private CanvasGroup canvasGroup;

	private Dictionary<string, Vector2> regionPositions;

	public void Show()
	{
	}

	public void Hide()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateRegion(string regionName, Vector2 pos, RegionButton.ClickCallback callback)
	{
	}

	private void CreateLine(Vector2 pos1, Vector2 pos2)
	{
	}

	public void LoadMapsKnucracker()
	{
	}

	public void LoadMapsK75()
	{
	}

	public void LoadMapsMrX()
	{
	}
}
