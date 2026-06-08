using System.Collections.Generic;
using Dorfromantik.UI;
using UnityEngine;

public class TutorialScreen : HideableUi
{
	[SerializeField]
	private List<GameObject> pages;

	[SerializeField]
	private GameObject previousScreenButton;

	[SerializeField]
	private GameObject nextScreenButton;

	private int currentPage;

	private void OnEnable()
	{
		UpdateScreenVisibility();
	}

	public void ChangePage(int delta)
	{
		currentPage = Mathf.Clamp(currentPage + delta, 0, pages.Count - 1);
		UpdateScreenVisibility();
	}

	public void ChangePageTo(int targetPage)
	{
		currentPage = Mathf.Clamp(targetPage, 0, pages.Count - 1);
		UpdateScreenVisibility();
	}

	private void UpdateScreenVisibility()
	{
		for (int i = 0; i < pages.Count; i++)
		{
			pages[i].SetActive(i == currentPage);
		}
	}
}
