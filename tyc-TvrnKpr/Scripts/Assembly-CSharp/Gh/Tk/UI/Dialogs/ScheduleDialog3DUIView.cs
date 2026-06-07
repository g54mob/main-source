using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class ScheduleDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private GameObject _pageSwitcherParent;

		[SerializeField]
		private TextMeshProI18n _pageNumberText;

		[SerializeField]
		private Button3DUIView _nextPageButton;

		[SerializeField]
		private Button3DUIView _previousPageButton;

		public static string IconPrefabNameTemplate;

		[SerializeField]
		private Transform _timeIndicator;

		[SerializeField]
		private List<Transform> _timeIndicatorTransformPositions;

		[SerializeField]
		private GameObject _optionButtonPrefab;

		[SerializeField]
		private Container3DUIView _optionButtonContainer;

		[SerializeField]
		private Button3DUIView _okButton;

		[SerializeField]
		private Button3DUIView _cancelButton;

		[SerializeField]
		private TextMeshProI18n _title;

		private string _currentSlotOptionId;

		private List<SlotOption> _slotOptions;

		[SerializeField]
		private List<ScheduleTimetable3DUIView> _timetableViews;

		private List<ScheduleTimetable> _allTimetables;

		private int _currentPage;

		public ColorLibrary staffRoleColors;

		[SerializeField]
		private TextMeshProI18n _openingTimeText;

		private bool _isDirty;

		public static SlotOption DragStartOption { get; set; }

		public bool IsDragging => false;

		public bool IsDragRemoveMode => false;

		public SlotOption CurrentSlotOption => null;

		public bool IsDirty
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public static GameObject CreateToggleOption(ScheduleDialog3DUIView dialog, SlotOption owner, KeyValuePair<SlotOption, bool> ownedOption, GameObject togglePrefab, Container3DUIView toggleContainer)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		private void SaveScheduleChanges()
		{
		}

		private void NextPage()
		{
		}

		private void PreviousPage()
		{
		}

		private void ChangePage(int page)
		{
		}

		private void SetTimetables(List<ScheduleTimetable> timetables)
		{
		}

		public void SetData(string titleKey, List<SlotOption> slotOptions, IEnumerable<ScheduleTimetable> timetables, GameObjectX openerGox)
		{
		}

		private void HighlightOpenerOnPage(GameObjectX openerGox)
		{
		}

		private void HighlightPage(int pageIndex)
		{
		}

		private void UpdateTimeIndicator()
		{
		}

		private void UpdateOptionButtons()
		{
		}

		private void SetSelectedOption(string optionId)
		{
		}

		private void ApplySchedulesToOwners()
		{
		}

		public static Color GetColor(string id)
		{
			return default(Color);
		}

		public void UpdateOpeningHoursInfo()
		{
		}

		private int[] GetOpenHours()
		{
			return null;
		}

		private bool WillTavernBeOpenAt(int hour)
		{
			return false;
		}

		public void MarkAsDirty()
		{
		}

		public override bool IsBackable()
		{
			return false;
		}

		public override void Back()
		{
		}
	}
}
