using System.Collections.Generic;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui
{
	public class StatsDialogScript : DialogScript
	{
		protected TextMeshProUGUI _headerText;

		protected XmlElement _panel;

		protected TextMeshProUGUI _statsHeader;

		protected XmlLayout _xmlLayout;

		private List<XmlElement> _stats = new List<XmlElement>();

		private XmlElement _templateStatsRow;

		public XmlElement ButtonCancel { get; private set; }

		public XmlElement ButtonCenter { get; private set; }

		public XmlElement ButtonLeft { get; private set; }

		public XmlElement ButtonRight { get; private set; }

		public void AddStat(string label, string value)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_templateStatsRow, _templateStatsRow.parentElement);
			TextMeshProUGUI elementByInternalId = xmlElement.GetElementByInternalId<TextMeshProUGUI>("label");
			TextMeshProUGUI elementByInternalId2 = xmlElement.GetElementByInternalId<TextMeshProUGUI>("value");
			elementByInternalId.text = label;
			elementByInternalId2.text = value;
			_stats.Add(xmlElement);
		}

		public void ClearStats()
		{
			foreach (XmlElement stat in _stats)
			{
				Object.Destroy(stat.gameObject);
			}
			_stats.Clear();
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				Object.Destroy(base.gameObject);
			});
		}

		public void SetButtonText(XmlElement buttonElement, string text)
		{
			buttonElement.GetComponentInChildren<TextMeshProUGUI>().text = text;
		}

		protected virtual void OnCancelClicked()
		{
			Close();
		}

		protected virtual void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_templateStatsRow = xmlLayout.GetElementById("template-stat-row");
			_templateStatsRow.SetActive(active: false);
			_headerText = xmlLayout.GetElementById<TextMeshProUGUI>("header-text");
			_statsHeader = xmlLayout.GetElementById<TextMeshProUGUI>("stats-header");
			ButtonCancel = xmlLayout.GetElementById("button-cancel");
			ButtonLeft = xmlLayout.GetElementById("button-left");
			ButtonCenter = xmlLayout.GetElementById("button-center");
			ButtonRight = xmlLayout.GetElementById("button-right");
			_panel.SetAttribute("active", "false");
			_xmlLayout = xmlLayout;
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show();
		}

		protected virtual void Update()
		{
			if (this == Game.Instance.UserInterface.ActiveDialog && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
		}
	}
}
