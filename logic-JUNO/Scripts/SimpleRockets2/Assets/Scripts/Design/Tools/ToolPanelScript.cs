using System.Collections.Generic;
using ModApi.Design;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Tools
{
	public class ToolPanelScript : DesignerFlyoutPanelScript
	{
		private class ToolButton
		{
			public XmlElement Button { get; set; }

			public Image Icon { get; set; }

			public DesignerSubPanelScript Panel { get; set; }

			public DesignerTool Tool { get; set; }
		}

		private ToolButton _activeButton;

		private ToolButton _movePartToolButton;

		private List<ToolButton> _toolButtons = new List<ToolButton>();

		private ToolButton ActiveButton
		{
			get
			{
				return _activeButton;
			}
			set
			{
				if (_activeButton != null)
				{
					_activeButton.Button.RemoveClass("toggle-button-toggled");
					if (_activeButton.Panel != null)
					{
						_activeButton.Panel.OnClosed();
						_activeButton.Panel.gameObject.SetActive(value: false);
					}
				}
				_activeButton = value;
				if (_activeButton != null)
				{
					_activeButton.Button.AddClass("toggle-button-toggled");
					base.DesignerUi.DesignerUiController.OnToolIconChanged(_activeButton.Icon.sprite);
					_activeButton.Panel.gameObject.SetActive(value: true);
					_activeButton.Panel.OnOpened();
					base.Flyout.Title = _activeButton.Button.GetAttribute("tooltip");
				}
			}
		}

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			DesignerScript designer = base.DesignerUi.Designer;
			foreach (XmlElement item in base.xmlLayout.GetElementById("tool-buttons").GetChildElementsWithClass("tool-button"))
			{
				string attribute = item.GetAttribute("data-tool-id");
				ToolButton toolButton = new ToolButton();
				toolButton.Button = item;
				switch (attribute)
				{
				case "MovePartTool":
					toolButton.Tool = designer.MovePartTool;
					_movePartToolButton = toolButton;
					break;
				case "NudgePartTool":
					toolButton.Tool = designer.NudgePartTool;
					break;
				case "RotatePartTool":
					toolButton.Tool = designer.RotatePartTool;
					break;
				case "FuselageShapeTool":
					toolButton.Tool = designer.FuselageShapeTool;
					break;
				case "PaintTool":
					toolButton.Tool = designer.PaintTool;
					break;
				case "PartConnectionsTool":
					toolButton.Tool = designer.PartConnectionsTool;
					break;
				}
				toolButton.Icon = item.GetChildElementsWithClass("toggle-button-icon")[0].GetComponent<Image>();
				toolButton.Panel = base.xmlLayout.GetElementById(attribute).GetComponentInChildren<DesignerSubPanelScript>(includeInactive: true);
				if (toolButton.Panel == null)
				{
					Debug.LogWarning("Could not find panel for tool button: " + attribute);
					continue;
				}
				toolButton.Panel.gameObject.SetActive(value: false);
				toolButton.Panel.Initialize(base.DesignerUi);
				_toolButtons.Add(toolButton);
			}
			base.DesignerUi.Designer.ActiveToolChanged += DesignerActiveToolChanged;
			UpdateActiveTool();
			base.Flyout.Closed += OnFlyoutClosed;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
		}

		public void OnToolButtonClicked(XmlElement element)
		{
			foreach (ToolButton toolButton in _toolButtons)
			{
				if (toolButton.Button == element && ActiveButton != toolButton)
				{
					base.DesignerUi.Designer.SelectTool(toolButton.Tool);
					break;
				}
			}
		}

		protected virtual void Update()
		{
		}

		private void DesignerActiveToolChanged(DesignerTool tool)
		{
			UpdateActiveTool();
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			base.DesignerUi.Designer.SelectTool(base.DesignerUi.Designer.MovePartTool);
		}

		private void UpdateActiveTool()
		{
			ToolButton toolButton = null;
			foreach (ToolButton toolButton2 in _toolButtons)
			{
				if (toolButton2 != _movePartToolButton && toolButton2.Tool.Active)
				{
					toolButton = toolButton2;
				}
			}
			if (toolButton == null)
			{
				toolButton = _movePartToolButton;
			}
			ActiveButton = toolButton;
		}
	}
}
