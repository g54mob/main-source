using System.Collections;
using System.Collections.Generic;
using Data.FactoryFloor.GameMode;
using Logic.Factory;
using UnityEngine;

public class UIGameModeSwitcher : MonoBehaviour
{
	[SerializeField]
	private CurrentGameMode _currentGameMode;

	[SerializeField]
	private CampaignModeSO _campaignModeSO;

	[SerializeField]
	private EditorModeSO _editorModeSO;

	[SerializeField]
	private GameObject _gameToolbar;

	[SerializeField]
	private List<GameObject> _editorToolItems;

	[SerializeField]
	private GameObject _saveAsButton;

	[SerializeField]
	private GameObject _saveTerrainButton;

	private IEnumerator Start()
	{
		yield return null;
		OnGameModeChanged(_currentGameMode.Mode);
		_currentGameMode.CurrentGameModeChanged += OnGameModeChanged;
	}

	private void OnDestroy()
	{
		_currentGameMode.CurrentGameModeChanged -= OnGameModeChanged;
	}

	private void OnGameModeChanged(GameModeSO newGameMode)
	{
		if (_gameToolbar != null)
		{
			_gameToolbar.SetActive(newGameMode == _campaignModeSO);
		}
		foreach (GameObject editorToolItem in _editorToolItems)
		{
			editorToolItem.SetActive(newGameMode == _editorModeSO);
		}
		if (!(_saveAsButton == null) && !(_saveTerrainButton == null))
		{
			_saveAsButton.SetActive(Application.isEditor);
			_saveTerrainButton.SetActive(Application.isEditor);
		}
	}
}
