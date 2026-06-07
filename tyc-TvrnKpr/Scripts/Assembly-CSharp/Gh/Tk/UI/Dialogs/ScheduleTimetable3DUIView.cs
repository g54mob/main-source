using System.Collections.Generic;
using Gh.Tk.UI.InfoPanels;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class ScheduleTimetable3DUIView : MonoBehaviour
	{
		[SerializeField]
		private List<ScheduleTimeslot3DUIView> _timeslots;

		[SerializeField]
		private StaffInfoPanelElement _staffInfoPanelElement;

		[SerializeField]
		private GameObject _roomHeaderObj;

		[SerializeField]
		private TMP_InputField _roomNameInput;

		[SerializeField]
		private GameObject _maintainableHeaderObj;

		[SerializeField]
		private TextBlock3DUIView _maintainableName;

		[SerializeField]
		private TextBlock3DUIView _maintainableLocation;

		[SerializeField]
		private TraitsContainer3DUIView _maintainableTraitsContainer3DuiView;

		[SerializeField]
		private Stars3DUIView _maintainableStarsView;

		[SerializeField]
		private GameObject _maintainablePreviewParent;

		private GameObject _maintainableModel;

		[SerializeField]
		private Button3DUIView _resetToDefaultButton;

		private ScheduleDialog3DUIView _dialog;

		[SerializeField]
		private GameObject _highlight;

		public ScheduleTimetable ScheduleTimetable { get; private set; }

		public List<SlotOption> SlotOptions { get; private set; }

		public void RefreshTimeslotUIStates()
		{
		}

		private static bool TraitsFilter(IAiComponentVisualInfo aiComponentVisualInfo)
		{
			return false;
		}

		private void Awake()
		{
		}

		public void SetTimetable(ScheduleDialog3DUIView dialog, ScheduleTimetable timetable, List<SlotOption> slotOptions)
		{
		}

		public void ToggleSlotOption(int hour, SlotOption currentSlotOption, bool isSegmentLocked)
		{
		}

		public bool TryHandleSameOptionOwnerClicked(int hour, SlotOption option, ScheduleTimeSlot scheduleTimeSlot)
		{
			return false;
		}

		private void OnSameOptionClicked(int hour, SlotOption option)
		{
		}

		private IEnumerable<SlotOption> GetSlotOptions(IEnumerable<string> ids)
		{
			return null;
		}

		private void AddSlotOption(int hour, SlotOption option)
		{
		}

		private void PlayHourToggleSound(int hour)
		{
		}

		private void RemoveSlotOption(int hour, SlotOption option)
		{
		}

		private void RefreshTimeslots()
		{
		}

		private void MergeDuplicateSlots()
		{
		}

		public void ShowHighlight(bool show)
		{
		}
	}
}
