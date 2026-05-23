using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUIHelper : MonoBehaviour
{
	[Serializable]
	public class SettingsTab
	{
		public TFUITextButton parentElement;

		public GameObject contentParent;

		public VerticalLayoutGroup childContainer;

		public bool disableNavigationProcessing;

		public void ComputeNavigationForSettingsTab()
		{
			if (disableNavigationProcessing)
			{
				return;
			}
			List<ThronefallUIElement> list = new List<ThronefallUIElement>();
			foreach (Transform item in childContainer.transform)
			{
				list.Add(item.GetComponent<ThronefallUIElement>());
			}
			parentElement.botNav = list[0];
			parentElement.topNav = list[list.Count - 1];
			for (int i = 0; i < list.Count; i++)
			{
				ThronefallUIElement thronefallUIElement = list[i];
				if (i == 0)
				{
					thronefallUIElement.topNav = parentElement;
				}
				else
				{
					thronefallUIElement.topNav = list[i - 1];
				}
				if (i == list.Count - 1)
				{
					thronefallUIElement.botNav = parentElement;
				}
				else
				{
					thronefallUIElement.botNav = list[i + 1];
				}
			}
		}
	}

	public UIFrame targetFrame;

	public SettingsTab videoTab;

	public SettingsTab audioTab;

	public SettingsTab gameplayTab;

	public SettingsTab controlsTab;

	public GameObject dimBG;

	private SettingsTab currentSelectedTab;

	private Dictionary<ThronefallUIElement, SettingsTab> allTabs = new Dictionary<ThronefallUIElement, SettingsTab>();

	private void Awake()
	{
		allTabs.Add(videoTab.parentElement, videoTab);
		allTabs.Add(audioTab.parentElement, audioTab);
		allTabs.Add(gameplayTab.parentElement, gameplayTab);
		allTabs.Add(controlsTab.parentElement, controlsTab);
		videoTab.contentParent.SetActive(value: false);
		audioTab.contentParent.SetActive(value: false);
		gameplayTab.contentParent.SetActive(value: false);
		controlsTab.contentParent.SetActive(value: false);
		RecomputeAllNavigation();
	}

	private void RecomputeAllNavigation()
	{
		videoTab.ComputeNavigationForSettingsTab();
		audioTab.ComputeNavigationForSettingsTab();
		gameplayTab.ComputeNavigationForSettingsTab();
		controlsTab.ComputeNavigationForSettingsTab();
	}

	public void OnShow()
	{
		if (SceneTransitionManager.instance.CurrentSceneState == SceneTransitionManager.SceneState.MainMenu)
		{
			dimBG.SetActive(value: false);
		}
		else
		{
			dimBG.SetActive(value: true);
		}
	}

	public void OnSelect()
	{
		SettingsTab value = null;
		if (allTabs.TryGetValue(targetFrame.CurrentSelection, out value))
		{
			if (currentSelectedTab != null)
			{
				currentSelectedTab.contentParent.SetActive(value: false);
				currentSelectedTab.parentElement.applyOverrideStyle = false;
			}
			currentSelectedTab = value;
			currentSelectedTab.contentParent.SetActive(value: true);
		}
		else if (currentSelectedTab != null)
		{
			currentSelectedTab.parentElement.applyOverrideStyle = true;
		}
	}
}
