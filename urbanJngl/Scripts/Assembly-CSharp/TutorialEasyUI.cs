using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEasyUI : MonoBehaviour
{
	[SerializeField]
	private Button buttonNext;

	[SerializeField]
	private Button buttonPrevious;

	[SerializeField]
	private List<TextMeshProUGUI> tutorialTextsList;

	private int currentIndex;

	private void Start()
	{
		buttonNext.onClick.AddListener(NextTutorial);
		buttonPrevious.onClick.AddListener(PreviousTutorial);
		Hide();
	}

	private void OnDestroy()
	{
		buttonNext.onClick.RemoveAllListeners();
		buttonPrevious.onClick.RemoveAllListeners();
	}

	private void NextTutorial()
	{
		tutorialTextsList[currentIndex].gameObject.SetActive(value: false);
		currentIndex++;
		tutorialTextsList[currentIndex].gameObject.SetActive(value: true);
	}

	private void PreviousTutorial()
	{
		tutorialTextsList[currentIndex].gameObject.SetActive(value: true);
		currentIndex--;
		tutorialTextsList[currentIndex].gameObject.SetActive(value: false);
	}

	private void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}
}
