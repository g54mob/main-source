using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class TutorialModeEmergencyResponse : TutorialMode
	{
		private enum States
		{
			None = 0,
			NeedToOpenSatNav = 1,
			NeedToSelectEmergency = 2,
			NeedToOpenEmergency = 3,
			NeedToDispatch = 4,
			WaitAndClose = 5
		}

		private States State;

		private TutorialModeEmergencyResponseDefinition _definition;

		private EmergencyChallengeMenu _emergencyHUDMenu;

		private EmergencyDispatchMenu _emergencyMenu;

		private EmergencyDispatchMap _emergencyMap;

		private EmergencyPin _tutorialPin;

		private RibbonDispatchRow _assignRow;

		private float _closeTimer;

		public TutorialModeEmergencyResponse(TutorialModeEmergencyResponseDefinition definition)
		{
			_definition = definition;
		}

		public override void Enter()
		{
			_emergencyHUDMenu = Level.HUD.FindMenu<GeneralNotificationMenu>().EmergencyChallengeMenu;
			_emergencyHUDMenu.TutorialCircleDispatchButton(active: true);
			State = States.NeedToOpenSatNav;
		}

		public override void Update()
		{
			switch (State)
			{
			case States.NeedToOpenSatNav:
				if (_emergencyHUDMenu.EmergencyDispatchMenu != null && _emergencyHUDMenu.EmergencyDispatchMenu.isActiveAndEnabled)
				{
					_emergencyMenu = _emergencyHUDMenu.EmergencyDispatchMenu;
					_emergencyMap = _emergencyMenu.EmergencyDispatchMap;
					_emergencyHUDMenu.TutorialCircleDispatchButton(active: false);
					_tutorialPin = _emergencyMap.CircleTutorialPin(active: true);
					State = States.NeedToSelectEmergency;
				}
				break;
			case States.NeedToSelectEmergency:
				if (_emergencyMap.SelectedPin == _tutorialPin && _tutorialPin.SelectMenu.isActiveAndEnabled)
				{
					_emergencyMap.CircleTutorialPin(active: false);
					_tutorialPin.SelectMenu.CircleDispatchButton(active: true);
					State = States.NeedToOpenEmergency;
				}
				break;
			case States.NeedToOpenEmergency:
				if (_emergencyMap.SelectedPin == _tutorialPin && _emergencyMenu.AmbulanceSelectionMenu.InActivePosition)
				{
					_tutorialPin.SelectMenu.CircleDispatchButton(active: false);
					_assignRow = _emergencyMenu.AmbulanceSelectionMenu.CircleFirstAssignButton(active: true);
					State = States.NeedToDispatch;
				}
				break;
			case States.NeedToDispatch:
				if (!_assignRow.IsAssignable)
				{
					_emergencyMenu.AmbulanceSelectionMenu.CircleFirstAssignButton(active: false);
					_closeTimer = 0f;
					State = States.WaitAndClose;
				}
				break;
			case States.WaitAndClose:
				if (_emergencyHUDMenu.EmergencyDispatchMenu == null || !_emergencyHUDMenu.EmergencyDispatchMenu.isActiveAndEnabled)
				{
					State = States.None;
					break;
				}
				_closeTimer += Time.deltaTime;
				if (_closeTimer >= _definition.SecondsBeforeClosingSatNav)
				{
					_emergencyHUDMenu.EmergencyDispatchMenu.CloseMenu();
					State = States.None;
				}
				break;
			}
		}
	}
}
