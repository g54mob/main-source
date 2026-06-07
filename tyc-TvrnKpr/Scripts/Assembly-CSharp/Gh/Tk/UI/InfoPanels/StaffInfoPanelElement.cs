using System;
using System.Collections.Generic;
using Gh.Tk.UI.Dialogs.StaffHiring;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class StaffInfoPanelElement : StaffHireElement
	{
		public Button3DUIView OpenScheduleButton;

		public InventoryElement InventoryElement;

		public CurrentActivityElement CurrentActivityElement;

		public ActiveTasks3DUIView _activeTasksElement;

		public Button3DUIView FireButton;

		public GiveCashBonusButton3DUIView GiveCashBonusButton;

		public RoomAssignmentButton3DUIView RoomAssignmentModeButton;

		public Button3DUIView BedAssignmentModeButton;

		public TextMeshProI18n Role;

		public TextMeshProI18n WorkHours;

		[SerializeField]
		protected ProblemInfoElement ProblemInfoElement;

		[SerializeField]
		protected Transform _awayElement;

		[SerializeField]
		protected Transform _disableIfAwayElement;

		public GameObject _nextPreviousButtonContainer;

		public Button3DUIView _nextButton;

		public Button3DUIView _previousButton;

		public List<ScheduleTimeSlot> TemporarySchedule { get; set; }

		public override Staff Staff
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		private void Actor_CurrentRoleChanged(object sender, EventArgs<Staff> e)
		{
		}

		private void Prop_ValidPropsChanged(object sender, EventArgs e)
		{
		}

		protected override void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void RefreshRoleText()
		{
		}

		private void Actor_StaffWageChanged(object sender, EventArgs<Staff> e)
		{
		}

		public void OnModelChanged(object sender, EventArgs eventArgs)
		{
		}

		private void RefreshAwayState()
		{
		}

		private void OnProblemsChanged(object sender, EventArgs e)
		{
		}

		private void RefreshProblems()
		{
		}

		private void Start()
		{
		}

		private void FireButtonClicked()
		{
		}
	}
}
