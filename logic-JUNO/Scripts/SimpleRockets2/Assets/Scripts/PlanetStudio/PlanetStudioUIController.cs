using System;
using System.Collections.Generic;
using Assets.Scripts.PlanetStudio.Flyouts;
using Assets.Scripts.PlanetStudio.UI;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Inspector;
using ModApi.PlanetStudio;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio
{
	public class PlanetStudioUIController : XmlLayoutController
	{
		private class ToggleFlyoutButton
		{
			public XmlElement ButtonElement { get; set; }

			public IFlyout Flyout { get; set; }
		}

		private TextMeshProUGUI _loadingText;

		private XmlElement _messageText;

		private float _messageTime;

		private PlanetStudioUIScript _planetStudioUI;

		private XmlElement _redoButton;

		private XmlElement _timePanel;

		private List<ToggleFlyoutButton> _toggleFlyoutButtons = new List<ToggleFlyoutButton>();

		private XmlElement _undoButton;

		public ElementBuilder ElementBuilder { get; private set; }

		public EquirectangularMapViewScript EquirectangularMapView { get; private set; }

		public bool IsLoading
		{
			get
			{
				return _loadingText.gameObject.activeSelf;
			}
			set
			{
				_loadingText.gameObject.SetActive(value);
			}
		}

		public IPlanetStudioUI PlanetStudioUI => _planetStudioUI;

		public PlanetStudioTimePanelController TimePanelController { get; private set; }

		public List<PlanetStudioFlyoutScript> Flyouts { get; private set; } = new List<PlanetStudioFlyoutScript>();

		public void InitializeUI(PlanetStudioUIScript planetStudioUI)
		{
			_planetStudioUI = planetStudioUI;
			foreach (XmlElement item in base.xmlLayout.GetElementsByClass("flyout"))
			{
				FlyoutScript flyoutScript = item.gameObject.AddComponent<FlyoutScript>();
				flyoutScript.Initialize(item);
				flyoutScript.Closing += OnFlyoutClosing;
				flyoutScript.Opening += OnFlyoutOpening;
				PlanetStudioFlyoutScript componentInChildren = flyoutScript.GetComponentInChildren<PlanetStudioFlyoutScript>();
				Flyouts.Add(componentInChildren);
			}
			_toggleFlyoutButtons.Clear();
			foreach (XmlElement item2 in base.xmlLayout.GetElementsByClass("toggle-flyout"))
			{
				string attribute = item2.GetAttribute("internalId");
				XmlElement elementById = base.xmlLayout.GetElementById(attribute);
				if (elementById != null)
				{
					FlyoutScript component = elementById.GetComponent<FlyoutScript>();
					if (component != null)
					{
						AddToggleFlyoutButton(item2, component);
						continue;
					}
				}
				Debug.LogWarning("Could not find flyout: " + attribute);
			}
			ElementBuilder elementBuilder = new ElementBuilder(base.xmlLayout.GetElementById("inspector-panel").GetComponentInChildren<XmlLayoutController>(includeInactive: true));
			ElementBuilder = elementBuilder;
			XmlElement elementById2 = base.xmlLayout.GetElementById("equirectangular-map-view");
			EquirectangularMapView = elementById2.gameObject.AddComponent<EquirectangularMapViewScript>();
			IPlanetStudioInitialized[] componentsInChildren = GetComponentsInChildren<IPlanetStudioInitialized>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnInitialized(_planetStudioUI);
			}
			_timePanel = base.xmlLayout.GetElementById("time-panel");
			_undoButton = base.xmlLayout.GetElementById("undo-button");
			_redoButton = base.xmlLayout.GetElementById("redo-button");
			_messageText = base.xmlLayout.GetElementById("message-text");
			PlanetStudioUI.EditModeChanged += OnEditModeChanged;
			OnEditModeChanged(null, null);
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_loadingText = base.xmlLayout.GetElementById<TextMeshProUGUI>("loading-text");
			TimePanelController = GetComponentInChildren<PlanetStudioTimePanelController>();
		}

		public void OnToggleFlyoutButtonClicked(XmlElement xmlElement)
		{
			foreach (ToggleFlyoutButton toggleFlyoutButton in _toggleFlyoutButtons)
			{
				if (toggleFlyoutButton.ButtonElement == xmlElement)
				{
					if (PlanetStudioUI.SelectedFlyout == toggleFlyoutButton.Flyout)
					{
						PlanetStudioUI.SelectedFlyout = null;
					}
					else
					{
						PlanetStudioUI.SelectedFlyout = toggleFlyoutButton.Flyout;
					}
				}
			}
		}

		public void ShowMessage(string message, float time)
		{
			_messageText.Show();
			_messageText.SetAndApplyAttribute("text", message);
			_messageTime = time;
		}

		protected virtual void Update()
		{
			foreach (ToggleFlyoutButton toggleFlyoutButton in _toggleFlyoutButtons)
			{
				if (toggleFlyoutButton.Flyout != null && toggleFlyoutButton.Flyout.IsOpen)
				{
					toggleFlyoutButton.ButtonElement.AddClass("toggle-button-toggled");
				}
				else
				{
					toggleFlyoutButton.ButtonElement.RemoveClass("toggle-button-toggled");
				}
			}
			if (_messageTime > 0f)
			{
				_messageTime -= Time.unscaledDeltaTime;
			}
			else if (_messageText.Visible && !_messageText.IsAnimating)
			{
				_messageText.Hide();
			}
			_redoButton.SetActive(_planetStudioUI.UndoHistory.RedoStepsAvailable);
			_undoButton.SetActive(_planetStudioUI.UndoHistory.UndoStepsAvailable);
		}

		private void AddToggleFlyoutButton(XmlElement button, IFlyout flyout)
		{
			ToggleFlyoutButton toggleFlyoutButton = new ToggleFlyoutButton();
			toggleFlyoutButton.ButtonElement = button;
			toggleFlyoutButton.Flyout = flyout;
			_toggleFlyoutButtons.Add(toggleFlyoutButton);
		}

		private void OnButtonRedoClicked()
		{
			_planetStudioUI.Redo();
		}

		private void OnButtonUndoClicked()
		{
			_planetStudioUI.Undo();
		}

		private void OnEditModeChanged(object sender, EventArgs e)
		{
			PlanetStudioUI.SelectedFlyout = null;
			List<XmlElement> elementsByClass = base.xmlLayout.GetElementsByClass("ps-only");
			foreach (XmlElement item in base.xmlLayout.GetElementsByClass("cb-only"))
			{
				item.SetActive(PlanetStudioUI.EditMode == PlanetStudioEditMode.CelestialBody);
			}
			foreach (XmlElement item2 in elementsByClass)
			{
				item2.SetActive(PlanetStudioUI.EditMode == PlanetStudioEditMode.PlanetarySystem);
			}
			_timePanel.SetActive(PlanetStudioUI.EditMode == PlanetStudioEditMode.PlanetarySystem);
		}

		private void OnFlyoutCloseButtonClicked(XmlElement closeButtonElement)
		{
			closeButtonElement.GetComponentInParent<FlyoutScript>().Close();
		}

		private void OnFlyoutClosing(IFlyout flyout)
		{
			if (PlanetStudioUI.SelectedFlyout == flyout)
			{
				PlanetStudioUI.SelectedFlyout = null;
			}
		}

		private void OnFlyoutOpening(IFlyout flyout)
		{
			if (PlanetStudioUI.SelectedFlyout != flyout)
			{
				PlanetStudioUI.SelectedFlyout = flyout;
			}
		}
	}
}
