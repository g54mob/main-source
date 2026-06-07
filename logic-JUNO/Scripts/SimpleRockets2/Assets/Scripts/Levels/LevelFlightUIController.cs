using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.State;
using Assets.Scripts.Ui;
using ModApi.Flight;
using ModApi.Levels;
using ModApi.Levels.Events;
using ModApi.Levels.Requirements;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class LevelFlightUIController : XmlLayoutController, ILevelUI, IXmlLayoutController
	{
		public class RequirementViewModel
		{
			private XmlElement _icon;

			private TextMeshProUGUI _label;

			private LevelRequirementStatus _status;

			private TextMeshProUGUI _value;

			public ILevelRequirement Requirement { get; }

			public XmlElement RequirementElement { get; set; }

			public RequirementViewModel(ILevelRequirement requirement, XmlElement element)
			{
				Requirement = requirement;
				RequirementElement = element;
				_label = element.GetElementByInternalId<TextMeshProUGUI>("label");
				_value = element.GetElementByInternalId<TextMeshProUGUI>("value");
				_icon = element.GetElementByInternalId("icon");
			}

			public void Update()
			{
				_label.text = Requirement.Name;
				_value.text = Requirement.DisplayValue ?? string.Empty;
				if (Requirement.VisibilityType == LevelRequirementVisibilityType.HiddenWhenPassed)
				{
					RequirementElement.SetActive(Requirement.Status != LevelRequirementStatus.Pass);
				}
				if (_status != Requirement.Status)
				{
					_status = Requirement.Status;
					if (_status == LevelRequirementStatus.Pass)
					{
						_icon.AddClass("passed");
						_icon.RemoveClass("failed");
					}
					else if (_status == LevelRequirementStatus.Fail)
					{
						_icon.RemoveClass("passed");
						_icon.AddClass("failed");
					}
					else
					{
						_icon.RemoveClass("passed");
						_icon.RemoveClass("failed");
					}
				}
			}
		}

		private XmlElement _endLevelButtons;

		private XmlElement _headerPanel;

		private XmlElement _infoPanel;

		private bool _infoPanelPinned;

		private TextMeshProUGUI _levelMessage;

		private List<RequirementViewModel> _requirements = new List<RequirementViewModel>();

		private XmlElement _requirementTemplate;

		public bool CustomUI { get; private set; }

		public bool InfoPanelPinned
		{
			get
			{
				return _infoPanelPinned;
			}
			set
			{
				if (_infoPanelPinned != value)
				{
					_infoPanelPinned = value;
					if (_infoPanelPinned)
					{
						_headerPanel.AddClass("pinned");
					}
					else
					{
						_headerPanel.RemoveClass("pinned");
					}
				}
			}
		}

		public ILevel Level { get; private set; }

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public static LevelFlightUIController CreateUI(RectTransform parent, ILevel level)
		{
			string uIXml = level.GetUIXml();
			bool flag = !string.IsNullOrWhiteSpace(uIXml);
			BuildUserInterfaceXmlRequest request = (flag ? BuildUserInterfaceXmlRequest.CreateFromXml(uIXml, level.LevelData.Id) : BuildUserInterfaceXmlRequest.CreateFromResource("Ui/Xml/Flight/LevelUIDefault"));
			LevelFlightUIController levelFlightUIController = UiUtilities.CreateUiGameObject("LevelUIController", parent).AddComponent<LevelFlightUIController>();
			levelFlightUIController.EventTarget = (flag ? ((object)level) : ((object)levelFlightUIController));
			levelFlightUIController.CustomUI = flag;
			levelFlightUIController.Level = level;
			Game.Instance.UserInterface.BuildUserInterfaceFromRequest(request, levelFlightUIController.xmlLayout);
			level.Initialize(levelFlightUIController);
			return levelFlightUIController;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_levelMessage = base.xmlLayout.GetElementById<TextMeshProUGUI>("level-message-text");
			_infoPanel = base.xmlLayout.GetElementById("info-panel");
			_headerPanel = base.xmlLayout.GetElementById("header-panel");
			_requirementTemplate = base.xmlLayout.GetElementById("requirement-template");
			_endLevelButtons = base.xmlLayout.GetElementById("end-level-buttons");
		}

		public void OnSceneLoaded()
		{
			foreach (ILevelRequirement levelRequirement in Level.LevelRequirements)
			{
				if (levelRequirement.VisibilityType != LevelRequirementVisibilityType.Hidden)
				{
					CreateRequirement(levelRequirement);
				}
			}
			_endLevelButtons.transform.SetAsLastSibling();
			Level.LevelPassed += OnLevelPassed;
			Level.LevelFailed += OnLevelFailed;
		}

		public void OnSceneUnloading()
		{
			Level.LevelPassed -= OnLevelPassed;
			Level.LevelFailed -= OnLevelFailed;
		}

		public void ShowMessage(string message, float duration = 5f)
		{
			Game.Instance.FlightScene?.FlightSceneUI?.ShowMessage(message, devlog: false, duration);
		}

		protected virtual void LateUpdate()
		{
			UpdateLevelMessage();
			if (!_infoPanel.Visible)
			{
				return;
			}
			foreach (RequirementViewModel requirement in _requirements)
			{
				requirement.Update();
			}
		}

		private void CreateRequirement(ILevelRequirement requirement)
		{
			XmlElement element = UiUtilities.CloneTemplate(_requirementTemplate, _infoPanel);
			RequirementViewModel item = new RequirementViewModel(requirement, element);
			_requirements.Add(item);
		}

		private void OnExitClicked()
		{
			GameState gameState = Game.Instance.GameState;
			Game.Instance.GameStateManager.RestoreGameStateTag(gameState.Id, gameState.GetTagPreFlight(), gameState.GetTagActive());
			FlightSceneScript.ReturnToSceneAfterFlight = "Menu";
			FlightSceneScript.Instance.ExitFlightScene(saveFlightState: false, FlightSceneExitReason.ExitLevel);
		}

		private void OnLevelFailed(object sender, LevelCompletedEventArgs e)
		{
			ShowEndLevel(passed: false);
		}

		private void OnLevelPassed(object sender, LevelCompletedEventArgs e)
		{
			ShowEndLevel(passed: true);
		}

		private void OnMouseClickPanel()
		{
			InfoPanelPinned = !InfoPanelPinned;
			if (InfoPanelPinned)
			{
				if (!_infoPanel.Visible)
				{
					_infoPanel.Show();
				}
			}
			else if (_infoPanel.Visible)
			{
				_infoPanel.Hide();
			}
		}

		private void OnMouseEnterPanel()
		{
			if (!_infoPanel.Visible)
			{
				_infoPanel.Show();
			}
		}

		private void OnMouseExitPanel()
		{
			if (!InfoPanelPinned)
			{
				_infoPanel.Hide();
			}
		}

		private void OnRetryClicked()
		{
			GameState gameState = Game.Instance.GameState;
			Game.Instance.GameStateManager.RestoreGameStateTag(gameState.Id, gameState.GetTagPreFlight(), gameState.GetTagActive());
			FlightSceneScript.Instance.ReloadFlightScene(saveFlightState: false, Game.Instance.GameState.PreflightLoadParameters, FlightSceneExitReason.Retry);
		}

		private void ShowEndLevel(bool passed)
		{
			_endLevelButtons.Show();
			if (passed)
			{
				_endLevelButtons.AddClass("win");
			}
			else
			{
				_endLevelButtons.AddClass("lose");
			}
			if (!InfoPanelPinned)
			{
				_infoPanel.Show();
				InfoPanelPinned = true;
			}
		}

		private void UpdateLevelMessage()
		{
			if (_levelMessage != null)
			{
				string persistentMessage = Level.GetPersistentMessage();
				_levelMessage.text = persistentMessage ?? string.Empty;
			}
		}
	}
}
