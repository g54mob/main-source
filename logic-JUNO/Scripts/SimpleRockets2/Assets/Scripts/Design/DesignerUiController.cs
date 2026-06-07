using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Crew;
using ModApi.Craft.Parts;
using ModApi.Levels;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class DesignerUiController : XmlLayoutController
	{
		private class ToggleFlyoutButton
		{
			public XmlElement ButtonElement { get; set; }

			public IFlyout Flyout { get; set; }
		}

		private Image _activeToolIcon;

		private DesignerUiScript _designerUi;

		private XmlElement _messageText;

		private float _messageTime;

		private XmlElement _partPropertiesHint;

		private XmlElement _redoButton;

		private bool _selectedPartIsGrouped;

		private List<ToggleFlyoutButton> _toggleFlyoutButtons = new List<ToggleFlyoutButton>();

		private XmlElement _togglePerformanceButton;

		private XmlElement _undoButton;

		public FingerTool FingerTool { get; private set; }

		public DesignerFlyouts Flyouts { get; private set; }

		public XmlElement MainPanel { get; private set; }

		public bool PartPropertiesHintVisible
		{
			get
			{
				return _partPropertiesHint.Visible;
			}
			set
			{
				_partPropertiesHint.SetActive(value);
			}
		}

		public void Initialize(DesignerUiScript designerUi)
		{
			_designerUi = designerUi;
			Flyouts = new DesignerFlyouts();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_toggleFlyoutButtons.Clear();
			if (!(_designerUi != null))
			{
				return;
			}
			_undoButton = base.xmlLayout.GetElementById("undo-button");
			_redoButton = base.xmlLayout.GetElementById("redo-button");
			MainPanel = base.xmlLayout.GetElementById("main-panel");
			_togglePerformanceButton = base.xmlLayout.GetElementById("toggle-performance-button");
			_partPropertiesHint = base.xmlLayout.GetElementById("part-properties-hint");
			_messageText = base.xmlLayout.GetElementById("message-text");
			if (Game.Instance.LevelManager.CurrentLevel != null)
			{
				_messageText.AddClass("level-in-progress");
			}
			XmlElement elementById = base.xmlLayout.GetElementById("finger-tool");
			FingerTool = new FingerTool(elementById, _designerUi.Designer, _designerUi.DesignerWidget);
			FingerTool.OnEnabledChanged += OnFingerToolEnabledChanged;
			UpdateFingerToolToggleButton();
			List<XmlElement> elementsByClass = base.xmlLayout.GetElementsByClass("flyout");
			Flyouts.ClearFlyouts();
			foreach (XmlElement item in elementsByClass)
			{
				FlyoutScript flyoutScript = item.gameObject.AddComponent<FlyoutScript>();
				flyoutScript.Initialize(item);
				flyoutScript.Closing += OnFlyoutClosing;
				flyoutScript.Opening += OnFlyoutOpening;
				item.GetComponentInChildren<DesignerFlyoutPanelScript>(includeInactive: true).Initialize(_designerUi);
				Flyouts.RegisterFlyout(item.id, flyoutScript);
			}
			foreach (XmlElement item2 in base.xmlLayout.GetElementsByClass("toggle-flyout"))
			{
				string attribute = item2.GetAttribute("internalId");
				XmlElement elementById2 = base.xmlLayout.GetElementById(attribute);
				if (elementById2 != null)
				{
					FlyoutScript component = elementById2.GetComponent<FlyoutScript>();
					if (component != null)
					{
						AddToggleFlyoutButton(item2, component);
						continue;
					}
				}
				Debug.LogWarning("Could not find flyout: " + attribute);
			}
			_activeToolIcon = base.xmlLayout.GetElementById<Image>("active-tool-icon");
		}

		public void OnToolIconChanged(Sprite icon)
		{
			if (_activeToolIcon != null)
			{
				_activeToolIcon.overrideSprite = icon;
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
			if (_designerUi.Designer.PerformanceAnalysis.Visible)
			{
				_togglePerformanceButton.AddClass("toggle-button-toggled");
			}
			else
			{
				_togglePerformanceButton.RemoveClass("toggle-button-toggled");
			}
			if (_designerUi.Designer.UndoHistory.UndoStepsAvailable)
			{
				_undoButton.Show();
			}
			else
			{
				_undoButton.Hide();
			}
			if (_designerUi.Designer.UndoHistory.RedoStepsAvailable)
			{
				_redoButton.Show();
			}
			else
			{
				_redoButton.Hide();
			}
			bool flag = _designerUi.Designer.SelectedPart?.Data.GroupId.HasValue ?? false;
			if (_selectedPartIsGrouped != flag)
			{
				_selectedPartIsGrouped = flag;
				XmlElement elementById = base.xmlLayout.GetElementById("group-parts-button");
				if (_selectedPartIsGrouped)
				{
					elementById.AddClass("btn-primary");
				}
				else
				{
					elementById.RemoveClass("btn-primary");
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
		}

		private void AddToggleFlyoutButton(XmlElement button, IFlyout flyout)
		{
			ToggleFlyoutButton toggleFlyoutButton = new ToggleFlyoutButton();
			toggleFlyoutButton.ButtonElement = button;
			toggleFlyoutButton.Flyout = flyout;
			_toggleFlyoutButtons.Add(toggleFlyoutButton);
		}

		private void OnCrewButtonClicked()
		{
			CrewAssignmentDialogScript.Create(_designerUi.Designer.CraftScript, _designerUi.Transform, _designerUi.Designer);
		}

		private void OnEditProgramButtonClicked()
		{
			FlightProgramScript obj = _designerUi.Designer.SelectedPart?.GetModifier<FlightProgramScript>();
			PartData part = _designerUi.Designer.CraftScript.PrimaryCommandPod.Part;
			if (obj != null)
			{
				part = _designerUi.Designer.SelectedPart.Data;
			}
			_designerUi.EditFlightProgram(part);
		}

		private void OnFingerToolEnabledChanged(object sender, EventArgs e)
		{
			UpdateFingerToolToggleButton();
		}

		private void OnFlyoutCloseButtonClicked(XmlElement closeButtonElement)
		{
			closeButtonElement.GetComponentInParent<FlyoutScript>().Close();
		}

		private void OnFlyoutClosing(IFlyout flyout)
		{
			if (_designerUi.SelectedFlyout == flyout)
			{
				_designerUi.SelectedFlyout = null;
			}
		}

		private void OnFlyoutOpening(IFlyout flyout)
		{
			if (_designerUi.SelectedFlyout != flyout)
			{
				_designerUi.SelectedFlyout = flyout;
			}
		}

		private void OnGroupPartsButtonClicked()
		{
			_designerUi.Designer.WeldSelectedPartLimb();
		}

		private void OnPerformanceAnalyzerButtonClicked()
		{
			_designerUi.Designer.PerformanceAnalysis.ToggleInspectorPanel();
		}

		private void OnPlayButtonClicked()
		{
			if (_designerUi.Designer.IsTutorialRunning)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "This button is disabled while the tutorial is in progress.";
				return;
			}
			Action launchAction = delegate
			{
				_designerUi.Designer.PerformanceAnalysis.ClosePanel();
				_designerUi.Designer.SelectPart(null, null, justAdded: false);
				_designerUi.OnBeginFlightClicked();
			};
			ILevel currentLevel = Game.Instance.LevelManager.CurrentLevel;
			if (currentLevel == null || !string.IsNullOrEmpty(currentLevel.LevelData.ContractId))
			{
				LaunchLocationsViewModel launchLocationsViewModel = new LaunchLocationsViewModel(_designerUi.Designer.CraftScript);
				launchLocationsViewModel.PrimaryButtonText = "LAUNCH";
				launchLocationsViewModel.LaunchLocationSelected = delegate
				{
					launchAction();
				};
				Game.Instance.UserInterface.CreateListView(launchLocationsViewModel);
			}
			else
			{
				launchAction();
			}
		}

		private void OnRedoButtonClicked()
		{
			_designerUi.Designer.Redo();
		}

		private void OnToggleFingerToolButtonClicked()
		{
			FingerTool.Enabled = !FingerTool.Enabled;
		}

		private void OnToggleFlyoutButtonClicked(XmlElement xmlElement)
		{
			foreach (ToggleFlyoutButton toggleFlyoutButton in _toggleFlyoutButtons)
			{
				if (toggleFlyoutButton.ButtonElement == xmlElement)
				{
					_designerUi.ToggleFlyout(toggleFlyoutButton.Flyout);
				}
			}
		}

		private void OnUndoButtonClicked()
		{
			_designerUi.Designer.Undo();
		}

		private void UpdateFingerToolToggleButton()
		{
			XmlElement elementById = base.xmlLayout.GetElementById("toggle-finger-tool-button");
			if (elementById != null)
			{
				if (FingerTool.Enabled)
				{
					elementById.AddClass("btn-primary");
				}
				else
				{
					elementById.RemoveClass("btn-primary");
				}
			}
		}
	}
}
