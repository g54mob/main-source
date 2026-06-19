using System;
using UnityEngine;

namespace TH20
{
	public class CursorStaffHeld : CursorMode
	{
		private readonly Level _level;

		private readonly WorldState _worldState;

		private readonly Staff _staff;

		private readonly JobApplicant _applicant;

		private readonly bool _newCharacter;

		private Room _room;

		public CursorStaffHeld(CursorManager cursorManager, Level level, Staff staff, JobApplicant applicant)
			: base(cursorManager)
		{
			_level = level;
			_worldState = level.WorldState;
			_staff = staff;
			_applicant = applicant;
			_newCharacter = _applicant != null;
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffCancelPickup = (Action<bool>)Delegate.Combine(characterEvents.OnStaffCancelPickup, new Action<bool>(Cancel));
			_cursorManager.PopMode<CursorRoomItem>();
			PickUp(_cursorManager.WorldPosition, _newCharacter);
			_level.HUD.CreateMenu<StaffHeldMenu>().Setup(_staff, _level);
		}

		public override void OnBecomeActive()
		{
			_cursorManager.SetPlaneOffset(2f);
			_cursorManager.SetCursorVisible(visible: true);
		}

		public override void Destroy()
		{
			_cursorManager.SetPlaneOffset(0f);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffCancelPickup = (Action<bool>)Delegate.Remove(characterEvents.OnStaffCancelPickup, new Action<bool>(Cancel));
			_level.HUD.DestroyMenu<StaffHeldMenu>();
			base.Destroy();
		}

		private void PickUp(Vector3 pickupPosition, bool immediate)
		{
			StaffPickedUpState staffPickedUpState = _staff.GetComponent<StaffPickedUpState>();
			if (staffPickedUpState != null)
			{
				staffPickedUpState.CancelExit();
			}
			else
			{
				staffPickedUpState = _staff.AddComponent<StaffPickedUpState>();
			}
			staffPickedUpState.Start(pickupPosition, immediate, DropComplete, _newCharacter);
		}

		private void Drop()
		{
			StaffPickedUpState component = _staff.GetComponent<StaffPickedUpState>();
			if (component != null)
			{
				component.PlaceInWorld();
				component.Destroy();
			}
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			base.CursorUpdate(inputManager);
			StaffPickedUpState component = _staff.GetComponent<StaffPickedUpState>();
			if (component == null)
			{
				_level.CharacterEvents.OnStaffCancelPickup.InvokeSafe(param: false);
				return;
			}
			component.SetPosition(_cursorManager.WorldPosition);
			if (inputManager.GetMouseDownOnScene(MouseButton.Left))
			{
				_room = _worldState.GetRoomAtWorldCoord(_cursorManager.GridPosition, includeHospital: true, includeClosedPlots: false);
				if (_room != null && !_room.FloorPlan.HospitalMap.Plot.Definition.UseEnergyUI && RoomAlgorithms.CanReachAnyDoor(_cursorManager.WorldPosition, _room.FloorPlan, _level))
				{
					component.RequestExit();
					if (_newCharacter)
					{
						_level.CharacterEvents.OnStaffHired.InvokeSafe(_staff, _applicant, _applicant.RecruitmentFee);
					}
					_level.CharacterEvents.OnRequestStaffDrop.InvokeSafe(_staff, _room);
					_cursorManager.PopMode<CursorStaffHeld>();
				}
			}
			else if (inputManager.GetMouseQuickOnScene(MouseButton.Right))
			{
				_level.CharacterEvents.OnStaffCancelPickup.InvokeSafe(param: true);
			}
		}

		private void DropComplete()
		{
			_level.CharacterEvents.OnStaffDrop.InvokeSafe(_staff, _room, param3: false);
		}

		private void Cancel(bool requestedByUser)
		{
			_cursorManager.PopMode<CursorStaffHeld>();
			_staff.GetComponent<StaffPickedUpState>()?.AbortPickup();
		}
	}
}
