using OneUseScripts;
using SettingScripts;
using UIScripts.SettingHandles;
using UnityEngine;

namespace UIScripts.UIPanels
{
	public class DynamicSettingsPanel : UIPanel
	{
		public GameObject[] Panels;

		public MenuDynamicSettingsManager GSH;

		public ZonesEditorPanel zonesEditorPanel;

		public ScenarioSaver scenarioSaver;

		public GameObject zonesPreview;

		private int curTab;

		private bool previewWasOpen;

		private int prevPanel;

		public override void InitPanel()
		{
			hasInit = true;
			base.gameObject.SetActive(value: false);
			GSH.StartLoadingSettingsHandles();
			SetActiveAllTabs();
			zonesEditorPanel.FillPanel();
			OpenTab(0);
			base.gameObject.SetActive(value: false);
		}

		public void SetActiveAllTabs(bool active = true)
		{
			GameObject[] panels = Panels;
			for (int i = 0; i < panels.Length; i++)
			{
				panels[i].SetActive(active);
			}
		}

		public void OpenTab(DynamicSettingsTabs tab)
		{
			OpenTab((int)tab);
		}

		public void OpenTab(int i)
		{
			if (i < Panels.Length)
			{
				curTab = i;
				SetActiveAllTabs(active: false);
				Panels[i].SetActive(value: true);
			}
		}

		public void OpenScenarioSaver()
		{
			prevPanel = curTab;
			OpenTab(DynamicSettingsTabs.ZonesTab);
			previewWasOpen = zonesPreview.activeSelf;
			zonesPreview.SetActive(value: true);
			zonesEditorPanel.SetShowLabels(val: false);
			RectScreenShooter.instance.CaptureObject(zonesEditorPanel.previewRT, ActuallyOpenSaverPanel, alsoSaveTempScreenshot: true);
		}

		private void ActuallyOpenSaverPanel(Texture2D screenshot)
		{
			zonesEditorPanel.SetShowLabels(val: true);
			OpenTab(prevPanel);
			zonesPreview.SetActive(previewWasOpen);
			scenarioSaver.OpenWithImage(screenshot);
		}
	}
}
