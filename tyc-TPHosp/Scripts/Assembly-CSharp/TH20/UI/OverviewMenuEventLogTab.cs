using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OverviewMenuEventLogTab : OverviewMenuTab
	{
		private enum Filter
		{
			All = 0,
			Finance = 1,
			Staff = 2,
			Patient = 3
		}

		[SerializeField]
		private Table _table;

		[SerializeField]
		private GameObject _rowPrefab;

		[SerializeField]
		private DynamicButton _buttonFilterAll;

		[SerializeField]
		private DynamicButton _buttonFilterFinance;

		[SerializeField]
		private DynamicButton _buttonFilterStaff;

		[SerializeField]
		private DynamicButton _buttonFilterPatient;

		[SerializeField]
		private bool _generateTestData;

		[SerializeField]
		private int _generateTestDataNumItems;

		private readonly List<GameObject> _rows = new List<GameObject>();

		private List<HospitalEvent> _events = new List<HospitalEvent>();

		public override void Setup(OverviewMenu theOverviewRoot, OverviewMenu.Mode theMode)
		{
			base.Setup(theOverviewRoot, theMode);
			HospitalEventLog hospitalEventLog = theOverviewRoot.TheLevel.HospitalEventLog;
			PopulateList(hospitalEventLog, Filter.All);
			_buttonFilterAll.onPrimaryDown.AddListener(delegate
			{
				PopulateList(hospitalEventLog, Filter.All);
			});
			_buttonFilterFinance.onPrimaryDown.AddListener(delegate
			{
				PopulateList(hospitalEventLog, Filter.Finance);
			});
			_buttonFilterStaff.onPrimaryDown.AddListener(delegate
			{
				PopulateList(hospitalEventLog, Filter.Staff);
			});
			_buttonFilterPatient.onPrimaryDown.AddListener(delegate
			{
				PopulateList(hospitalEventLog, Filter.Patient);
			});
			Table table = _table;
			table.onSortOrderChanged = (Action)Delegate.Combine(table.onSortOrderChanged, new Action(OnSortOrderChanged));
		}

		protected void OnDestroy()
		{
			Table table = _table;
			table.onSortOrderChanged = (Action)Delegate.Remove(table.onSortOrderChanged, new Action(OnSortOrderChanged));
		}

		private void OnSortOrderChanged()
		{
			UpdateRowItemRowIndexes();
		}

		private void PopulateList(HospitalEventLog hospitalEventLog, Filter filter)
		{
			_events.Clear();
			switch (filter)
			{
			case Filter.All:
				hospitalEventLog.GetEvents(ref _events, (HospitalEvent he) => true);
				break;
			case Filter.Finance:
				hospitalEventLog.GetEvents(ref _events, (HospitalEvent he) => he is IHospitalEventFinance hospitalEventFinance && hospitalEventFinance.IsFinanceValueValid());
				break;
			case Filter.Staff:
				hospitalEventLog.GetEvents(ref _events, (HospitalEvent he) => he is IHospitalEventStaff);
				break;
			case Filter.Patient:
				hospitalEventLog.GetEvents(ref _events, (HospitalEvent he) => he is IHospitalEventPatient);
				break;
			}
			SetButtonSelected(_buttonFilterAll, selected: false);
			SetButtonSelected(_buttonFilterFinance, selected: false);
			SetButtonSelected(_buttonFilterStaff, selected: false);
			SetButtonSelected(_buttonFilterPatient, selected: false);
			switch (filter)
			{
			case Filter.All:
				SetButtonSelected(_buttonFilterAll, selected: true);
				break;
			case Filter.Finance:
				SetButtonSelected(_buttonFilterFinance, selected: true);
				break;
			case Filter.Staff:
				SetButtonSelected(_buttonFilterStaff, selected: true);
				break;
			case Filter.Patient:
				SetButtonSelected(_buttonFilterPatient, selected: true);
				break;
			}
			_rows.ClearAndDestroy();
			_table.Refresh();
		}

		private void Update()
		{
			if (_events.Count != 0)
			{
				HospitalEvent hospitalEvent = _events[0];
				GameObject gameObject = _table.InstantiateAsRow(_rowPrefab);
				HospitalEventLogMenuRow component = gameObject.GetComponent<HospitalEventLogMenuRow>();
				gameObject.transform.SetParent(_table.Rows, base.transform);
				component.Initialise(base.TheOverviewMenu.TheLevel, hospitalEvent, _rows.Count, _generateTestData);
				_rows.Add(gameObject);
				_events.RemoveAt(0);
			}
		}

		private void SetButtonSelected(DynamicButton button, bool selected)
		{
			ButtonAnimator component = button.GetComponent<ButtonAnimator>();
			if (component != null)
			{
				component.CurrentState = (selected ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			}
		}

		private void UpdateRowItemRowIndexes()
		{
			int childCount = _table.Rows.childCount;
			for (int i = 0; i < childCount; i++)
			{
				_table.Rows.GetChild(i).GetComponent<HospitalEventLogMenuRow>().SetRowIndex(i);
			}
			_table.Refresh();
		}

		public override void Activate(bool state)
		{
			base.Activate(state);
			if (state)
			{
				PopulateList(base.TheOverviewMenu.TheLevel.HospitalEventLog, Filter.All);
			}
		}
	}
}
