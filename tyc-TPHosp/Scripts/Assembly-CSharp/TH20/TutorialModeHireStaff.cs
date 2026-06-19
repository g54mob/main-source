using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class TutorialModeHireStaff : TutorialMode
	{
		private enum States
		{
			None = 0,
			NeedToSelectHireMenu = 1,
			NeedToSelectStaffType = 2,
			NeedToSelectHire = 3
		}

		private readonly TutorialHireStaffDefinition _definition;

		private HubMenu _hubMenu;

		private Pingable _hiresPingable;

		private ButtonAnimator _hiresButtonAnimator;

		private Pingable _staffTabPingable;

		private Pingable _hireButtonPingable;

		private States State;

		public TutorialModeHireStaff(TutorialHireStaffDefinition definition)
		{
			_definition = definition;
		}

		public override void Enter()
		{
			_hubMenu = Level.HUD.FindMenu<HubMenu>();
			_hiresButtonAnimator = TutorialUtils.GetHubHiresButton(Level);
			RectTransform transform = (RectTransform)_hiresButtonAnimator.transform;
			Image image = _hiresButtonAnimator.Button.image;
			_hiresPingable = new Pingable(Level.TutorialManager.PingManagerProxy, transform, image);
		}

		public override void Destroy()
		{
			if (_hubMenu != null && _hubMenu.HubMenuButtons != null)
			{
				_hubMenu.HubMenuButtons.ShowTutorialHighlight(roomCircle: false, itemsCircle: false, hireCircle: false);
			}
			if (_hiresPingable != null)
			{
				_hiresPingable.Destroy();
				_hiresPingable = null;
			}
			if (_staffTabPingable != null)
			{
				_staffTabPingable.Destroy();
				_staffTabPingable = null;
			}
			if (_hireButtonPingable != null)
			{
				_hireButtonPingable.Destroy();
				_hireButtonPingable = null;
			}
			base.Destroy();
		}

		public override void Update()
		{
			RibbonMenu ribbonMenu = Level.HUD.FindMenu<RibbonMenu>();
			ButtonAnimator buttonAnimator = null;
			ButtonAnimator hireButtonAnimator = null;
			if (ribbonMenu != null && TutorialUtils.GetRibbonHireMenuSettings(Level, out var settings))
			{
				switch (_definition.StaffType)
				{
				case StaffDefinition.Type.Assistant:
					buttonAnimator = settings.AssistantsButtonAnimator;
					break;
				case StaffDefinition.Type.Doctor:
					buttonAnimator = settings.DoctorsButtonAnimator;
					break;
				case StaffDefinition.Type.Janitor:
					buttonAnimator = settings.JanitorsButtonAnimator;
					break;
				case StaffDefinition.Type.Nurse:
					buttonAnimator = settings.NursesButtonAnimator;
					break;
				}
				hireButtonAnimator = settings.HireButtonAnimator;
			}
			if (ribbonMenu == null)
			{
				State = States.NeedToSelectHireMenu;
			}
			else if (buttonAnimator != null)
			{
				if (buttonAnimator.CurrentState != ButtonAnimator.State.Selected)
				{
					State = States.NeedToSelectStaffType;
				}
				else
				{
					State = States.NeedToSelectHire;
				}
			}
			else
			{
				State = States.None;
			}
			switch (State)
			{
			case States.NeedToSelectHireMenu:
				StartHiresMenuAnimation();
				ResetStaffTypeAnimation(ribbonMenu);
				ResetAcceptHireAnimation(ribbonMenu);
				break;
			case States.NeedToSelectStaffType:
				ResetHiresMenuAnimation();
				StartStaffTypeAnimation(ribbonMenu, buttonAnimator);
				ResetAcceptHireAnimation(ribbonMenu);
				break;
			case States.NeedToSelectHire:
				ResetHiresMenuAnimation();
				ResetStaffTypeAnimation(ribbonMenu);
				StartAcceptHireAnimation(ribbonMenu, hireButtonAnimator);
				break;
			}
		}

		private void StartHiresMenuAnimation()
		{
			_hiresPingable.RectTransform.SetAsLastSibling();
			_hiresPingable.Ping(_definition.HiresPing);
			if (_hubMenu != null && _hubMenu.HubMenuButtons != null)
			{
				_hubMenu.HubMenuButtons.ShowTutorialHighlight(roomCircle: false, itemsCircle: false, hireCircle: true);
			}
		}

		private void ResetHiresMenuAnimation()
		{
			_hiresPingable.StopPing();
			if (_hubMenu != null && _hubMenu.HubMenuButtons != null)
			{
				_hubMenu.HubMenuButtons.ShowTutorialHighlight(roomCircle: false, itemsCircle: false, hireCircle: false);
			}
		}

		private void StartStaffTypeAnimation(RibbonMenu ribbonMenu, ButtonAnimator staffTypeButtonAnimator)
		{
			if (!(ribbonMenu == null))
			{
				ribbonMenu.RibbonMenuHireState.ShowTutorialStaffTypeHighlight(show: true, _definition.StaffType);
				if (staffTypeButtonAnimator != null && _staffTabPingable == null)
				{
					RectTransform transform = (RectTransform)staffTypeButtonAnimator.transform;
					Image image = staffTypeButtonAnimator.Button.image;
					_staffTabPingable = new Pingable(Level.TutorialManager.PingManagerProxy, transform, image);
					_staffTabPingable.Ping(_definition.StaffTabPing);
				}
			}
		}

		private void ResetStaffTypeAnimation(RibbonMenu ribbonMenu)
		{
			if (!(ribbonMenu == null))
			{
				ribbonMenu.RibbonMenuHireState.ShowTutorialStaffTypeHighlight(show: false, _definition.StaffType);
				if (_staffTabPingable != null)
				{
					_staffTabPingable.Destroy();
					_staffTabPingable = null;
				}
			}
		}

		private void StartAcceptHireAnimation(RibbonMenu ribbonMenu, ButtonAnimator hireButtonAnimator)
		{
			if (!(ribbonMenu == null))
			{
				ribbonMenu.RibbonMenuHireState.ShowTutorialHireButton(show: true);
				if (hireButtonAnimator != null && _hireButtonPingable == null)
				{
					RectTransform transform = (RectTransform)hireButtonAnimator.transform;
					Image image = hireButtonAnimator.Button.image;
					_hireButtonPingable = new Pingable(Level.TutorialManager.PingManagerProxy, transform, image);
					_hireButtonPingable.Ping(_definition.HireButtonPing);
				}
			}
		}

		private void ResetAcceptHireAnimation(RibbonMenu ribbonMenu)
		{
			if (!(ribbonMenu == null))
			{
				ribbonMenu.RibbonMenuHireState.ShowTutorialHireButton(show: false);
				if (_hireButtonPingable != null)
				{
					_hireButtonPingable.Destroy();
					_hireButtonPingable = null;
				}
			}
		}
	}
}
