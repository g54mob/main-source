using System.Collections.Generic;
using UnityEngine;

public class InputTutorial : MonoBehaviour
{
	private bool isShowingTiles;

	public Transform playerTransform;

	public List<SpriteRenderer> tutorialTiles = new List<SpriteRenderer>();

	public void Start()
	{
		if (SaveSystem.currentPlayerSaveData.overworldState == OverworldTrollManager.OverworldState.ACT_I)
		{
			isShowingTiles = true;
			EnableTiles();
		}
		else
		{
			DisableTiles();
		}
	}

	public void Update()
	{
		if (isShowingTiles && SaveSystem.currentPlayerSaveData.overworldState == OverworldTrollManager.OverworldState.ACT_I && playerTransform.position.y > -20f)
		{
			isShowingTiles = false;
			DisableTiles();
		}
	}

	private void EnableTiles()
	{
		foreach (SpriteRenderer tutorialTile in tutorialTiles)
		{
			tutorialTile.gameObject.SetActive(value: true);
		}
	}

	private void DisableTiles()
	{
		foreach (SpriteRenderer tutorialTile in tutorialTiles)
		{
			tutorialTile.gameObject.SetActive(value: false);
		}
	}
}
