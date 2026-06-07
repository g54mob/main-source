using System;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class CreativeModeWindowUI : MonoBehaviour
{
	[SerializeField]
	private Button exitButton;

	[SerializeField]
	private Button playButton;

	[SerializeField]
	private TextMeshProUGUI playText;

	[SerializeField]
	private TextMeshProUGUI lockedText;

	[SerializeField]
	private Button arrowLeftButton;

	[SerializeField]
	private Button arrowRightButton;

	[SerializeField]
	private List<CreativeModeChapterUI> chaptersList;

	[SerializeField]
	private Scrollbar scrollbar;

	[SerializeField]
	private List<float> scrollBarValues;

	private int selectedChapter;

	private bool doubleClickProtection;

	private void Start()
	{
		MainMenuUI.Instance.OnCreativeModeButton += MainMenuUI_OnCreativeModeButton;
		exitButton.onClick.AddListener(Hide);
		playButton.onClick.AddListener(PlayChapter);
		arrowLeftButton.onClick.AddListener(GoLeft);
		arrowRightButton.onClick.AddListener(GoRight);
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		Hide();
	}

	private void OnEnable()
	{
		for (int i = 0; i < chaptersList.Count; i++)
		{
			int index = i;
			chaptersList[index].GetButton().onClick.AddListener(delegate
			{
				ChapterChosen(index);
			});
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.OpenedLevels.Contains(i))
			{
				UnlockChapter(i);
			}
		}
		SetSelectedChapter(0);
	}

	private void OnDestroy()
	{
		MainMenuUI.Instance.OnCreativeModeButton -= MainMenuUI_OnCreativeModeButton;
		exitButton.onClick.RemoveAllListeners();
		playButton.onClick.RemoveAllListeners();
		arrowLeftButton.onClick.RemoveAllListeners();
		arrowRightButton.onClick.RemoveAllListeners();
		InputManager.Instance.OnEscape -= InputManager_OnEscape;
		foreach (CreativeModeChapterUI chapters in chaptersList)
		{
			chapters.GetButton().onClick.RemoveAllListeners();
		}
	}

	private void MainMenuUI_OnCreativeModeButton(object sender, EventArgs e)
	{
		Show();
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		Hide();
	}

	private void ClearSelectedChapter()
	{
		chaptersList[selectedChapter].Unselect();
	}

	private void SetSelectedChapter(int chapterNumber)
	{
		selectedChapter = chapterNumber;
		chaptersList[selectedChapter].Select();
		SetScrollBarValue(scrollBarValues[selectedChapter]);
		if (chaptersList[selectedChapter].IsUnlocked())
		{
			playText.gameObject.SetActive(value: true);
			lockedText.gameObject.SetActive(value: false);
			playButton.interactable = true;
		}
		else
		{
			playText.gameObject.SetActive(value: false);
			lockedText.gameObject.SetActive(value: true);
			playButton.interactable = false;
		}
	}

	private void ChapterChosen(int chapterNumber)
	{
		ClearSelectedChapter();
		SetSelectedChapter(chapterNumber);
	}

	private void PlayChapter()
	{
		if (!doubleClickProtection)
		{
			doubleClickProtection = true;
			MainMenuUI.Instance.CreativeModeButton(selectedChapter);
		}
	}

	private void UnlockChapter(int chapterNumber)
	{
		bool tagActive = AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeModeNewLevels.Contains(chapterNumber);
		chaptersList[chapterNumber].Unlock(tagActive);
	}

	private void SetScrollBarValue(float value)
	{
		DOTween.To(() => scrollbar.value, delegate(float x)
		{
			scrollbar.value = x;
		}, value, 0.5f);
	}

	private void GoLeft()
	{
		if (selectedChapter > 0)
		{
			ChapterChosen(selectedChapter - 1);
		}
	}

	private void GoRight()
	{
		if (selectedChapter < chaptersList.Count - 1)
		{
			ChapterChosen(selectedChapter + 1);
		}
	}

	private void Hide()
	{
		if (base.isActiveAndEnabled)
		{
			MainMenuUI.Instance.ToggleMainMenu(value: true);
			MainMenuUI.Instance.InnerWindowOpen = false;
			base.gameObject.SetActive(value: false);
		}
	}

	private void Show()
	{
		MainMenuUI.Instance.InnerWindowOpen = true;
		base.gameObject.SetActive(value: true);
	}
}
