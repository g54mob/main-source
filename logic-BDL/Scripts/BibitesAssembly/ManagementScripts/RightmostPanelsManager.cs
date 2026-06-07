using System.Collections.Generic;
using UIScripts;
using UnityEngine;

namespace ManagementScripts
{
	public class RightmostPanelsManager : MonoBehaviour
	{
		[Header("Panels")]
		public UIPanel DynamicSettingsPanel;

		public UIPanel StatisticsPanel;

		public UIPanel QuickStatisticsPanel;

		public UIPanel AncestralLineagePanel;

		public UIPanel graphsPanel;

		public List<UIPanel> Panels;

		private void Awake()
		{
			Panels = new List<UIPanel> { DynamicSettingsPanel, StatisticsPanel, QuickStatisticsPanel, AncestralLineagePanel };
			QuickStatisticsPanel.OpenPanel();
		}

		private void Start()
		{
			DynamicSettingsPanel.OpenPanel();
			AncestralLineagePanel.Initialize();
			Panels.ForEach(delegate(UIPanel p)
			{
				p.ClosePanel();
			});
			graphsPanel.gameObject.SetActive(value: true);
			graphsPanel.gameObject.SetActive(value: false);
		}

		public void OpenPanel(RightmostPanelChoice panel)
		{
			OpenPanel(panel.panel);
		}

		public void OpenPanel(RightmostPanels panel)
		{
			switch (panel)
			{
			case RightmostPanels.StatisticsPanel:
				StatisticsPanel.OpenPanel();
				DynamicSettingsPanel.ClosePanel();
				AncestralLineagePanel.ClosePanel();
				break;
			case RightmostPanels.DynamicSettingsPanel:
				StatisticsPanel.ClosePanel();
				DynamicSettingsPanel.OpenPanel();
				AncestralLineagePanel.ClosePanel();
				break;
			case RightmostPanels.AncestralLineagePanel:
				StatisticsPanel.ClosePanel();
				DynamicSettingsPanel.ClosePanel();
				AncestralLineagePanel.OpenPanel();
				break;
			}
		}

		public void CloseAllPanels()
		{
			Panels.ForEach(delegate(UIPanel p)
			{
				p.ClosePanel();
			});
		}
	}
}
