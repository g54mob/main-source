using TMPro;
using UnityEngine;

namespace TH20
{
	public class StaffHeldMenu : InWorldMenuObject
	{
		[SerializeField]
		private GameObject _root;

		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private float _timeBeforeDisplayed = 1f;

		private Staff _staff;

		private Room _room;

		private float _displayTime;

		public void Setup(Staff staff, Level level)
		{
			base.Setup(staff, level);
			_staff = staff;
			if (_root != null)
			{
				GameObjectUtils.SetActive(_root, isActive: false);
			}
		}

		protected override void Update()
		{
			base.Update();
			Room room = _room;
			_room = base.Level.WorldState.GetRoomAtWorldCoord(base.Level.CursorManager.GridPosition, includeHospital: true, includeClosedPlots: false);
			if (_room != room)
			{
				_displayTime = 0f;
			}
			_displayTime += Time.unscaledDeltaTime;
			ICursorSelectable highlightObject;
			string staffDropResult = base.Level.StaffWorkScheduler.GetStaffDropResult(_staff, _room, out highlightObject);
			bool isActive = staffDropResult != null && _displayTime > _timeBeforeDisplayed;
			GameObjectUtils.SetActive(_root, isActive);
			if (highlightObject != null && highlightObject.CanHighlight())
			{
				base.Level.HighlightManager.HighlightObject(highlightObject);
			}
			if (staffDropResult != null)
			{
				_text.text = staffDropResult;
			}
		}

		protected override Vector3 GetMenuPosition()
		{
			return base.Level.CursorManager.WorldPosition + Vector3.up * _menuYOffset;
		}
	}
}
