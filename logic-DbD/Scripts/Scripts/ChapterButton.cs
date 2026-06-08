using System;
using UnityEngine;
using UnityEngine.UI;

public class ChapterButton : MonoBehaviour
{
	[SerializeField]
	private ScrollRect scrollArea;

	[SerializeField]
	private Transform chapterContainer;

	[SerializeField]
	private int chapter;

	private static Button currentButton;

	private static int currentChapter;

	private AudioSwitcher audioPlayer;

	public static int GetCurrentChapter()
	{
		return currentChapter;
	}

	private void Awake()
	{
		audioPlayer = base.transform.parent.GetComponent<AudioSwitcher>();
	}

	private void OnEnable()
	{
		Button component = base.gameObject.GetComponent<Button>();
		if (chapter > 4)
		{
			component.interactable = false;
			return;
		}
		component.interactable = LevelManager.GetCurrLevel() + 1 >= chapter;
		if (currentChapter == chapter)
		{
			currentButton = base.gameObject.GetComponent<Button>();
			component.interactable = false;
		}
	}

	public void LaunchChapter()
	{
		if (chapter > 8 || chapter < 0)
		{
			throw new ArgumentException($"Instruction manual does not have chapter {chapter}");
		}
		foreach (Transform item in base.transform.parent)
		{
			_ = item;
			base.gameObject.GetComponent<Button>().interactable = false;
		}
		if (currentButton != null)
		{
			currentButton.interactable = true;
		}
		currentButton = base.gameObject.GetComponent<Button>();
		currentChapter = chapter;
		currentButton.interactable = false;
		audioPlayer.PlayEffect();
		Transform transform = chapterContainer.Find((chapter == 0) ? "Cover" : $"Chapter {chapter}");
		scrollArea.content = transform.GetComponent<RectTransform>();
		GameObject obj = transform.gameObject;
		CloseChapters();
		obj.SetActive(value: true);
	}

	public void SetInteractable(bool interactable)
	{
		base.gameObject.GetComponent<Button>().interactable = interactable;
	}

	private void CloseChapters()
	{
		foreach (Transform item in chapterContainer)
		{
			item.gameObject.SetActive(value: false);
		}
	}
}
