using System.Collections.Generic;
using RainbowArt.CleanFlatUI;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
	[SerializeField]
	private GameObject[] tutorialWindows;

	[SerializeField]
	private GameObject ParentMemoUI;

	private List<ModalWindow> currentlyOpenWindows = new List<ModalWindow>();

	private void Start()
	{
		GameManager.S.OnTutorialWindowOn += Gm_OnTutorialWindowOn;
		StickyNote.OnReadStickyNote += StickyNote_OnReadStickyNote;
		BusStopUI.OnFadeInDone += BusStopUI_OnFadeInDone;
	}

	private void BusStopUI_OnFadeInDone()
	{
		FirstPersonController.S.canControl = true;
	}

	private void StickyNote_OnReadStickyNote()
	{
		FirstPersonController.S.canControl = false;
		Cursor.visible = true;
		ParentMemoUI.SetActive(value: true);
	}

	private void OnDestroy()
	{
		GameManager.S.OnTutorialWindowOn -= Gm_OnTutorialWindowOn;
		StickyNote.OnReadStickyNote -= StickyNote_OnReadStickyNote;
		BusStopUI.OnFadeInDone -= BusStopUI_OnFadeInDone;
	}

	private void Gm_OnTutorialWindowOn(int index)
	{
		if (index == -1)
		{
			FirstPersonController.S.canControl = true;
			return;
		}
		tutorialWindows[index].SetActive(value: true);
		ModalWindow component = tutorialWindows[index].GetComponent<ModalWindow>();
		component.ShowModalWindow();
		AudioManager.S.PlaySFX(AudioManager.S.tutorialUIOn);
		if (!currentlyOpenWindows.Contains(component))
		{
			currentlyOpenWindows.Add(component);
		}
	}

	private void Update()
	{
	}

	public void OffUI(ModalWindow window)
	{
		if (currentlyOpenWindows.Contains(window))
		{
			currentlyOpenWindows.Remove(window);
			window.HideModalWindow();
			Debug.Log(currentlyOpenWindows.Count);
			if (currentlyOpenWindows.Count == 0)
			{
				Cursor.visible = false;
				FirstPersonController.S.canControl = true;
			}
		}
	}

	public void OffUITutorial(ModalWindow window)
	{
		if (currentlyOpenWindows.Contains(window))
		{
			currentlyOpenWindows.Remove(window);
		}
		window.HideModalWindow();
	}
}
