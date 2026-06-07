using System.Collections.Generic;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class PreflightPanelScript : DesignerFlyoutPanelScript
	{
		public class TabButton
		{
			public XmlElement Button { get; set; }

			public DesignerSubPanelScript Panel { get; set; }
		}

		private TabButton _activeButton;

		private TabButton _stagingButton;

		private List<TabButton> _tabButtons = new List<TabButton>();

		private TabButton _validationButton;

		public TabButton ActiveButton
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
					_activeButton.Panel.gameObject.SetActive(value: true);
					_activeButton.Panel.OnOpened();
					base.Flyout.Title = _activeButton.Button.GetAttribute("tooltip");
				}
			}
		}

		public IReadOnlyList<TabButton> TabButtons => _tabButtons;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			_ = base.DesignerUi.Designer;
			foreach (XmlElement item in base.xmlLayout.GetElementById("tool-buttons").GetChildElementsWithClass("tool-button"))
			{
				string attribute = item.GetAttribute("data-tool-id");
				TabButton tabButton = new TabButton();
				tabButton.Button = item;
				if (!(attribute == "StagingPanel"))
				{
					if (attribute == "ValidationPanel")
					{
						_validationButton = tabButton;
					}
				}
				else
				{
					_stagingButton = tabButton;
				}
				tabButton.Panel = base.xmlLayout.GetElementById(attribute).GetComponentInChildren<DesignerSubPanelScript>(includeInactive: true);
				if (tabButton.Panel == null)
				{
					Debug.LogWarning("Could not find panel for tab button: " + attribute);
					continue;
				}
				tabButton.Panel.gameObject.SetActive(value: false);
				tabButton.Panel.Initialize(base.DesignerUi);
				_tabButtons.Add(tabButton);
			}
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
		}

		public void OnToolButtonClicked(XmlElement element)
		{
			foreach (TabButton tabButton in _tabButtons)
			{
				if (tabButton.Button == element && ActiveButton != tabButton)
				{
					ActiveButton = tabButton;
					break;
				}
			}
		}

		public void ShowValidationPanel()
		{
			ActiveButton = _validationButton;
		}

		protected virtual void Update()
		{
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			_activeButton?.Panel.OnClosed();
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			if (_activeButton == null)
			{
				ActiveButton = _stagingButton;
			}
			_activeButton?.Panel.OnOpened();
		}
	}
}
