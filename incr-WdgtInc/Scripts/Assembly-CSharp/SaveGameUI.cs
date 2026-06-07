using System;
using System.Collections.Generic;
using Assets.Behaviour.UI;
using Assets.Source.Util;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameUI : MonoBehaviour
{
	[SerializeField]
	private ScrollRect _scroll;

	[SerializeField]
	private RectTransform _savesParent;

	[SerializeField]
	private SaveGameRow _savePrefab;

	[SerializeField]
	private TMP_InputField _textInput;

	protected List<SaveGameRow> _rows = new List<SaveGameRow>();

	private void OnEnable()
	{
		((RectTransform)base.transform).anchoredPosition = Vector2.zero;
		_rows.Clear();
		_savesParent.DestroyChildren();
		List<SaveGameFile> saveGames = SaveGame.GetSaveGames();
		saveGames.Sort((SaveGameFile a, SaveGameFile b) => b.Timestamp.CompareTo(a.Timestamp));
		float num = 0f;
		foreach (SaveGameFile item in saveGames)
		{
			SaveGameRow saveGameRow = UnityEngine.Object.Instantiate(_savePrefab, _savesParent);
			saveGameRow.SetSave(item);
			_rows.Add(saveGameRow);
			(saveGameRow.transform as RectTransform).anchoredPosition = new Vector2(0f, num);
			num -= 36f;
		}
		_savesParent.sizeDelta = new Vector2(_savesParent.sizeDelta.x, 0f - num);
	}

	private void OnDisable()
	{
		if ((bool)_textInput)
		{
			_textInput.text = "";
		}
	}

	private void Update()
	{
		if (_textInput == null || !_textInput.isFocused)
		{
			float y = PlayerControls.MenuDelta.y;
			if (y != 0f)
			{
				_scroll.verticalNormalizedPosition += y * Time.unscaledDeltaTime * 2000f / _savesParent.sizeDelta.y;
			}
		}
	}

	public virtual void ShowSaveGame(SaveGameFile file)
	{
		_textInput.text = file.Name;
		foreach (SaveGameRow row in _rows)
		{
			row.SetHighlighted(file);
		}
	}

	public virtual void DoExecuteAction()
	{
		if (string.IsNullOrEmpty(_textInput.text))
		{
			return;
		}
		try
		{
			SaveGame.DoSave(_textInput.text);
			if ((bool)GameUI.Instance)
			{
				GameUI.Instance.IngameMenuResume();
			}
		}
		catch (Exception exception)
		{
			UIAlertWindow.Show("@SGError", "@SGErrorFailed");
			Debug.LogException(exception);
		}
	}

	public void CancelSaveGame()
	{
		if ((bool)GameUI.Instance)
		{
			GameUI.Instance.ReturnToIngameMenu();
		}
		else if ((bool)MainMenuUI.Instance)
		{
			MainMenuUI.Instance.ShowMainMenu();
		}
	}

	public void EndEdit()
	{
		((RectTransform)base.transform).anchoredPosition = Vector2.zero;
		if (PlayerControls.Return)
		{
			DoExecuteAction();
		}
	}

	public void OnInputFieldSelected()
	{
		Rect rect = ((RectTransform)_textInput.transform).rect;
		if (SteamManager.Initialized && SteamUtils.ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeSingleLine, Mathf.RoundToInt(rect.xMin), Mathf.RoundToInt(rect.yMin), Mathf.RoundToInt(rect.width), Mathf.RoundToInt(rect.height)))
		{
			((RectTransform)base.transform).anchoredPosition = new Vector2(0f, 300f);
		}
	}
}
