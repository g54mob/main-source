using System;
using System.Collections.Generic;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class HospitalEventLogMenu : AnimatedMenuBase
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
		private DynamicButton _buttonExit;

		[SerializeField]
		private GameObject _rowPrefab;

		[SerializeField]
		private Button _buttonFilterAll;

		[SerializeField]
		private Button _buttonFilterFinance;

		[SerializeField]
		private Button _buttonFilterStaff;

		[SerializeField]
		private Button _buttonFilterPatient;

		private Level _level;

		private Filter _filter;

		private readonly List<GameObject> _rows = new List<GameObject>();

		private List<HospitalEvent> _events = new List<HospitalEvent>();

		public void Setup(Level level)
		{
			_level = level;
			_buttonExit.onPrimaryDown.AddListener(OnExit);
			RefreshList();
			HospitalEventLog hospitalEventLog = _level.HospitalEventLog;
			hospitalEventLog.OnEventAdded = (Action)Delegate.Remove(hospitalEventLog.OnEventAdded, new Action(RefreshList));
			HospitalEventLog hospitalEventLog2 = _level.HospitalEventLog;
			hospitalEventLog2.OnEventAdded = (Action)Delegate.Combine(hospitalEventLog2.OnEventAdded, new Action(RefreshList));
			_buttonFilterAll.onClick.AddListener(delegate
			{
				_filter = Filter.All;
				RefreshList();
			});
			_buttonFilterFinance.onClick.AddListener(delegate
			{
				_filter = Filter.Finance;
				RefreshList();
			});
			_buttonFilterStaff.onClick.AddListener(delegate
			{
				_filter = Filter.Staff;
				RefreshList();
			});
			_buttonFilterPatient.onClick.AddListener(delegate
			{
				_filter = Filter.Patient;
				RefreshList();
			});
		}

		private void OnExit()
		{
			HospitalEventLog hospitalEventLog = _level.HospitalEventLog;
			hospitalEventLog.OnEventAdded = (Action)Delegate.Remove(hospitalEventLog.OnEventAdded, new Action(RefreshList));
			CloseMenu();
		}

		private void RefreshList()
		{
			_events.Clear();
			switch (_filter)
			{
			case Filter.All:
				_level.HospitalEventLog.GetEvents(ref _events, (HospitalEvent he) => true);
				break;
			case Filter.Finance:
				_level.HospitalEventLog.GetEvents(ref _events, (HospitalEvent he) => he is IHospitalEventFinance hospitalEventFinance && hospitalEventFinance.IsFinanceValueValid());
				break;
			case Filter.Staff:
				_level.HospitalEventLog.GetEvents(ref _events, (HospitalEvent he) => he is IHospitalEventStaff);
				break;
			case Filter.Patient:
				_level.HospitalEventLog.GetEvents(ref _events, (HospitalEvent he) => he is IHospitalEventPatient);
				break;
			}
			int count = _events.Count;
			int count2 = _rows.Count;
			int num = count2 - count;
			for (int num2 = count2 - num; num2 < count2; num2++)
			{
				GameObjectUtils.SetActive(_rows[num2], isActive: false);
				GameObjectUtils.SetParent(_rows[num2].transform, base.transform);
			}
			int num3 = count - count2;
			for (int num4 = 0; num4 < num3; num4++)
			{
				GameObject gameObject = _table.InstantiateAsRow(_rowPrefab);
				gameObject.transform.SetParent(_table.Rows, worldPositionStays: false);
				_rows.Add(gameObject);
			}
			for (int num5 = count - 1; num5 >= 0; num5--)
			{
				HospitalEvent hospitalEvent = _events[num5];
				GameObject obj = _rows[num5];
				HospitalEventLogMenuRow component = obj.GetComponent<HospitalEventLogMenuRow>();
				GameObjectUtils.SetParent(obj.transform, _table.Rows);
				component.Initialise(_level, hospitalEvent, num5, generateTestData: false);
				GameObjectUtils.SetActive(obj, isActive: true);
			}
			_table.SetDirty();
		}

		protected override void Update()
		{
			base.Update();
			if (_level.InputManager.GetKeyDown(KeyCode.Escape))
			{
				OnExit();
			}
		}
	}
}
