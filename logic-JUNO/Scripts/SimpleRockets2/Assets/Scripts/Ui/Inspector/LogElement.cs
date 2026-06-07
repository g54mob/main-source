using System;
using System.Text;
using DigitalLegacy.UI.Sizing;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class LogElement : ItemElement
	{
		private InspectorPanelScript _inspectorPanelScript;

		private RectTransform _logPanel;

		private LogModel _model;

		private bool _refresh = true;

		private TextMeshProUGUI _text;

		private LayoutElement _textLayoutRoot;

		public LogElement(XmlElement xmlElement, LogModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
			_logPanel = xmlElement.GetElementByInternalId("log-panel").GetComponent<RectTransform>();
			_text = xmlElement.GetElementByInternalId<TextMeshProUGUI>("log-text");
			_model.Changed += OnLogModelChanged;
			_logPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100f);
			_logPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100f);
			_inspectorPanelScript = _logPanel.GetComponentInParent<InspectorPanelScript>();
			_textLayoutRoot = _logPanel.GetComponentInParent<ScrollRect>().transform.parent.GetComponent<LayoutElement>();
			if (_inspectorPanelScript.IsResizable)
			{
				uResize componentInParent = _logPanel.GetComponentInParent<uResize>();
				componentInParent.OnResizeUpdate.AddListener(OnResizeUpdate);
				componentInParent.OnResizeEnd.AddListener(OnResizeUpdate);
				componentInParent.MinSize = new Vector2(250f, 100f);
				if (_inspectorPanelScript.MaxHeight > 0)
				{
					OnResizeUpdate();
				}
			}
		}

		public override void OnDesroyed()
		{
			_model.Changed -= OnLogModelChanged;
			_model = null;
		}

		public override void Update()
		{
			base.Update();
			if (_refresh)
			{
				_refresh = false;
				StringBuilder stringBuilder = new StringBuilder();
				for (int num = _model.Logs.Count - 1; num >= 0; num--)
				{
					stringBuilder.Append(_model.Logs[num]);
					stringBuilder.Append("\n");
				}
				_text.text = stringBuilder.ToString();
				float size = Mathf.Max(_text.preferredWidth + 10f, 100f);
				float size2 = Mathf.Max(_text.preferredHeight + 10f, 100f);
				_logPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size2);
				_logPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
			}
		}

		private void OnLogModelChanged(object sender, EventArgs e)
		{
			_refresh = true;
		}

		private void OnResizeUpdate()
		{
			_textLayoutRoot.preferredHeight = _inspectorPanelScript.MaxHeight - 40;
		}
	}
}
