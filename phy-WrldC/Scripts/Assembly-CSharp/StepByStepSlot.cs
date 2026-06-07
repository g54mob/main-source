using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StepByStepSlot : MonoBehaviour
{
	[Serializable]
	public class TutorialPage
	{
		[SerializeField]
		private string tutorialId;

		[SerializeField]
		private GameObject tutorialContentObject;

		[SerializeField]
		private GameObject graphicsContentObject;

		private GameObject lastStepPageSelected;

		private GameObject lastGraphicPageSelected;

		public string TutorialId => tutorialId;

		public void SetContentVisibility(bool isVisible)
		{
			if (tutorialContentObject != null && tutorialContentObject.activeInHierarchy != isVisible)
			{
				tutorialContentObject.SetActive(isVisible);
			}
			if (graphicsContentObject != null && graphicsContentObject.activeInHierarchy != isVisible)
			{
				graphicsContentObject.SetActive(isVisible);
			}
		}

		public StepPageSlot SelectStepContentPage(int stepContentPageIndex)
		{
			lastStepPageSelected?.SetActive(value: false);
			lastGraphicPageSelected?.SetActive(value: false);
			StepPageSlot result = null;
			string text = string.Empty;
			if (tutorialContentObject != null && stepContentPageIndex < tutorialContentObject.transform.childCount - 1)
			{
				GameObject gameObject = tutorialContentObject.transform.GetChild(stepContentPageIndex).gameObject;
				gameObject.SetActive(value: true);
				text = gameObject.name;
				result = gameObject.GetComponent<StepPageSlot>();
				lastStepPageSelected = gameObject;
			}
			if (graphicsContentObject != null && !string.IsNullOrEmpty(text))
			{
				Transform transform = graphicsContentObject.transform.Find(text);
				if (transform != null)
				{
					GameObject gameObject2 = transform.gameObject;
					gameObject2.SetActive(value: true);
					lastGraphicPageSelected = gameObject2;
				}
			}
			return result;
		}

		public int GetTotalStepPages()
		{
			return tutorialContentObject.transform.childCount;
		}

		public void HideAllStepPages()
		{
			foreach (Transform item in tutorialContentObject.transform)
			{
				item.gameObject.SetActive(value: false);
			}
			foreach (Transform item2 in graphicsContentObject.transform)
			{
				item2.gameObject.SetActive(value: false);
			}
		}
	}

	[SerializeField]
	private List<TutorialPage> tutorialPages;

	private TextMeshProUGUI titleText;

	private Button previousPageButton;

	private Button nextPageButton;

	private TextMeshProUGUI pageCountText;

	private TutorialPage selectedTutorialPage;

	private int stepPageIndex;

	private DraggableWindow draggableWindow;

	public Canvas ParentCanvas { get; set; }

	private void Awake()
	{
		titleText = base.transform.FindComponent<TextMeshProUGUI>("TitleText", isRecursively: true);
		previousPageButton = base.transform.FindComponent<Button>("PreviousPageButton", isRecursively: true);
		nextPageButton = base.transform.FindComponent<Button>("NextPageButton", isRecursively: true);
		pageCountText = base.transform.FindComponent<TextMeshProUGUI>("PageCountText", isRecursively: true);
		draggableWindow = GetComponent<DraggableWindow>();
		selectedTutorialPage = tutorialPages[0];
		stepPageIndex = 0;
		tutorialPages.ForEach(delegate(TutorialPage tutorialPage)
		{
			tutorialPage.HideAllStepPages();
		});
		previousPageButton.onClick.AddListener(delegate
		{
			stepPageIndex--;
			UpdatePages();
		});
		nextPageButton.onClick.AddListener(delegate
		{
			stepPageIndex++;
			UpdatePages();
		});
		UpdatePages();
	}

	public void SetTutorialPage(string tutorialId)
	{
		foreach (TutorialPage tutorialPage in tutorialPages)
		{
			if (tutorialPage.TutorialId == tutorialId)
			{
				selectedTutorialPage = tutorialPage;
				tutorialPage.SetContentVisibility(isVisible: true);
			}
			else
			{
				tutorialPage.SetContentVisibility(isVisible: false);
			}
		}
		stepPageIndex = 0;
		UpdatePages();
	}

	public void SetStepPage(int pageNumber)
	{
		stepPageIndex = pageNumber - 1;
		UpdatePages();
	}

	public void SaveWindowPosition()
	{
		draggableWindow.SaveWindowPosition();
	}

	public void ResetWindowPosition()
	{
		draggableWindow.ResetWindowPosition();
	}

	private void UpdatePages()
	{
		if (tutorialPages.Count == 0 || selectedTutorialPage.GetTotalStepPages() == 0)
		{
			return;
		}
		int num = selectedTutorialPage.GetTotalStepPages() - 1;
		stepPageIndex = Mathf.Clamp(stepPageIndex, 0, num - 1);
		StepPageSlot stepPageSlot = selectedTutorialPage.SelectStepContentPage(stepPageIndex);
		previousPageButton.interactable = stepPageIndex > 0;
		nextPageButton.interactable = stepPageIndex < num - 1;
		string sourceText = "Tutorial";
		string sourceText2 = stepPageIndex + 1 + " / " + num;
		if (stepPageSlot != null)
		{
			var (text, num2, num3) = stepPageSlot.GetStepPageInfos();
			if (!string.IsNullOrEmpty(text))
			{
				sourceText2 = num2 + " / " + num3;
				sourceText = LanguagesManager.Instance.GetText("label.text." + selectedTutorialPage.TutorialId.Replace("_", "") + "." + text);
			}
		}
		else
		{
			sourceText = LanguagesManager.Instance.GetText("label.text.stepbystep.title", "Tutorial");
		}
		titleText.SetText(sourceText);
		pageCountText.SetText(sourceText2);
	}
}
