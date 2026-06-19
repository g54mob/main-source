using System;
using System.Collections.Generic;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class StaffMenuRowProvider : MustCallDestroy, ITableRowProvider
	{
		private class DefaultStaffOrderComparer : IComparer<StaffEntry>
		{
			public int Compare(StaffEntry t1, StaffEntry t2)
			{
				int result = 0;
				Staff staff = t1.Staff;
				Staff staff2 = t2.Staff;
				int defaultOrderStaffSortValue = GetDefaultOrderStaffSortValue(staff, staff.ID);
				int defaultOrderStaffSortValue2 = GetDefaultOrderStaffSortValue(staff2, staff2.ID);
				if (defaultOrderStaffSortValue < defaultOrderStaffSortValue2)
				{
					result = 1;
				}
				else if (defaultOrderStaffSortValue > defaultOrderStaffSortValue2)
				{
					result = -1;
				}
				return result;
			}
		}

		private class RankComparer : IComparer<StaffEntry>
		{
			private int _direction = 1;

			public RankComparer(Table.SortDirection direction)
			{
				if (direction == Table.SortDirection.Descending)
				{
					_direction = -1;
				}
			}

			public int Compare(StaffEntry staffEntry1, StaffEntry staffEntry2)
			{
				Staff staff = staffEntry1.Staff;
				Staff staff2 = staffEntry2.Staff;
				if (staff.Rank < staff2.Rank)
				{
					return _direction * -1;
				}
				if (staff.Rank > staff2.Rank)
				{
					return _direction;
				}
				return _direction * staff.ID.CompareTo(staff2.ID);
			}
		}

		private class QualificationComparer : IComparer<StaffEntry>
		{
			private int _direction = 1;

			public QualificationComparer(Table.SortDirection direction)
			{
				if (direction == Table.SortDirection.Descending)
				{
					_direction = -1;
				}
			}

			public int Compare(StaffEntry staffEntry1, StaffEntry staffEntry2)
			{
				Staff staff = staffEntry1.Staff;
				Staff staff2 = staffEntry2.Staff;
				if (staff.Qualifications.Count < staff2.Qualifications.Count)
				{
					return _direction * -1;
				}
				if (staff.Qualifications.Count > staff2.Qualifications.Count)
				{
					return _direction;
				}
				return _direction * staff.ID.CompareTo(staff2.ID);
			}
		}

		private class HappinessComparer : IComparer<StaffEntry>
		{
			private int _direction = 1;

			public HappinessComparer(Table.SortDirection direction)
			{
				if (direction == Table.SortDirection.Descending)
				{
					_direction = -1;
				}
			}

			public int Compare(StaffEntry staffEntry1, StaffEntry staffEntry2)
			{
				Staff staff = staffEntry1.Staff;
				Staff staff2 = staffEntry2.Staff;
				float num = ((staff.Happiness != null) ? staff.Happiness.Value() : 0f);
				float num2 = ((staff2.Happiness != null) ? staff2.Happiness.Value() : 0f);
				if (num < num2)
				{
					return _direction * -1;
				}
				if (num > num2)
				{
					return _direction;
				}
				return _direction * staff.ID.CompareTo(staff2.ID);
			}
		}

		private class EnergyComparer : IComparer<StaffEntry>
		{
			private int _direction = 1;

			public EnergyComparer(Table.SortDirection direction)
			{
				if (direction == Table.SortDirection.Descending)
				{
					_direction = -1;
				}
			}

			public int Compare(StaffEntry staffEntry1, StaffEntry staffEntry2)
			{
				Staff staff = staffEntry1.Staff;
				Staff staff2 = staffEntry2.Staff;
				float num = ((staff.Energy != null) ? staff.Energy.Value() : 0f);
				float num2 = ((staff2.Energy != null) ? staff2.Energy.Value() : 0f);
				if (num < num2)
				{
					return _direction * -1;
				}
				if (num > num2)
				{
					return _direction;
				}
				return _direction * staff.ID.CompareTo(staff2.ID);
			}
		}

		private class SalaryComparer : IComparer<StaffEntry>
		{
			private int _direction = 1;

			public SalaryComparer(Table.SortDirection direction)
			{
				if (direction == Table.SortDirection.Descending)
				{
					_direction = -1;
				}
			}

			public int Compare(StaffEntry staffEntry1, StaffEntry staffEntry2)
			{
				Staff staff = staffEntry1.Staff;
				Staff staff2 = staffEntry2.Staff;
				if (staff.GetSalary() < staff2.GetSalary())
				{
					return _direction * -1;
				}
				if (staff.GetSalary() > staff2.GetSalary())
				{
					return _direction;
				}
				return _direction * staff.ID.CompareTo(staff2.ID);
			}
		}

		private struct StaffEntry
		{
			public Staff Staff;

			public bool CanRevert;

			public bool IsSatisfied;

			public int InitialSalary;

			public float PayRiseSlider;

			public StaffDefinition.Satisfaction PaySatisfaction;
		}

		public Action<JobDescription> OnTogglePressed;

		private GameObject _rowPrefab;

		private Table _table;

		private CharacterManager _characterManager;

		private CharacterEvents _characterEvents;

		private StaffMenu.StaffMenuSettings _staffMenuSettings;

		private StaffMenu _staffMenu;

		private Staff _currentSelectedStaff;

		private List<JobDescription>[] _jobs;

		private StaffDefinition.Type _staffFilter;

		private List<StaffEntry> _staff = new List<StaffEntry>();

		private List<StaffMenuRowBase> _rowsPool = new List<StaffMenuRowBase>();

		private Dictionary<int, StaffMenuRowBase> _rowsInUse = new Dictionary<int, StaffMenuRowBase>();

		private List<Graphic> _cachedGraphicsList = new List<Graphic>(8);

		private List<CanvasRenderer> _cachedCanvasRendererList = new List<CanvasRenderer>(32);

		private DefaultStaffOrderComparer _defaultStaffOrderComparer = new DefaultStaffOrderComparer();

		private RankComparer _rankComparerAscending = new RankComparer(Table.SortDirection.Ascending);

		private RankComparer _rankComparerDescending = new RankComparer(Table.SortDirection.Descending);

		private QualificationComparer _qualificationComparerAscending = new QualificationComparer(Table.SortDirection.Ascending);

		private QualificationComparer _qualificationComparerDescending = new QualificationComparer(Table.SortDirection.Descending);

		private HappinessComparer _happinessComparerAscending = new HappinessComparer(Table.SortDirection.Ascending);

		private HappinessComparer _happinessComparerDescending = new HappinessComparer(Table.SortDirection.Descending);

		private EnergyComparer _energyComparerAscending = new EnergyComparer(Table.SortDirection.Ascending);

		private EnergyComparer _energyComparerDescending = new EnergyComparer(Table.SortDirection.Descending);

		private SalaryComparer _salaryComparerAscending = new SalaryComparer(Table.SortDirection.Ascending);

		private SalaryComparer _salaryComparerDescending = new SalaryComparer(Table.SortDirection.Descending);

		public int NumOfRows => _staff.Count;

		public int NumOfRowsInUsed => _rowsInUse.Count;

		public StaffDefinition.Type StaffFilter
		{
			get
			{
				return _staffFilter;
			}
			set
			{
				_staffFilter = value;
			}
		}

		public GameObject RowPrefab
		{
			get
			{
				return _rowPrefab;
			}
			set
			{
				_rowPrefab = value;
			}
		}

		public List<JobDescription>[] Jobs
		{
			get
			{
				return _jobs;
			}
			set
			{
				_jobs = value;
				foreach (StaffMenuRowBase value2 in _rowsInUse.Values)
				{
					StaffMenuJobAssignRow staffMenuJobAssignRow = value2 as StaffMenuJobAssignRow;
					if (staffMenuJobAssignRow != null)
					{
						staffMenuJobAssignRow.RefreshJobs(_jobs[(int)staffMenuJobAssignRow.Staff.Definition._type]);
					}
				}
			}
		}

		public Staff CurrentSelectedStaff
		{
			get
			{
				return _currentSelectedStaff;
			}
			set
			{
				if (_currentSelectedStaff == value)
				{
					return;
				}
				_currentSelectedStaff = value;
				foreach (StaffMenuRowBase value2 in _rowsInUse.Values)
				{
					if (value2.Staff == _currentSelectedStaff)
					{
						value2.ButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
					}
					else
					{
						value2.ButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
					}
				}
			}
		}

		private static int GetDefaultOrderStaffSortValue(Staff staff, int instanceID)
		{
			StaffDefinition.Type type = staff.Definition._type;
			return (((int)(StaffDefinition.GetNumTypes() - type) << 3) + staff.Rank << 16) + (instanceID & 0xFFFF);
		}

		public StaffMenuRowProvider(StaffDefinition.Type staffType, CharacterManager characterManager, CharacterEvents characterEvents, StaffMenu staffMenu, StaffMenu.StaffMenuSettings staffMenuSettings, GameObject rowPrefab)
		{
			_staffFilter = staffType;
			_rowPrefab = rowPrefab;
			_characterManager = characterManager;
			_staffMenu = staffMenu;
			_staffMenuSettings = staffMenuSettings;
			_characterEvents = characterEvents;
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffFired, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents3.OnStaffResigned, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents4.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			RebuildStaffList();
		}

		private void AddStaff(Staff staff)
		{
			_staff.Add(new StaffEntry
			{
				Staff = staff,
				InitialSalary = staff.GetSalary(),
				IsSatisfied = StaffMenuPayReviewRow.IsStaffSatisfied(staff),
				PaySatisfaction = GameAlgorithms.CalculatePaySatisfactionLevel(staff.GetDesiredSalaryDifference()),
				PayRiseSlider = 0f
			});
		}

		public void RebuildStaffList()
		{
			_staff.Clear();
			foreach (Staff staffMember in _characterManager.StaffMembers)
			{
				if ((_staffFilter == StaffDefinition.Type.None || staffMember.Definition._type == _staffFilter) && !staffMember.HasBeenFired() && !staffMember.HasResigned())
				{
					AddStaff(staffMember);
				}
			}
			_staff.Sort(_defaultStaffOrderComparer);
			RefreshRowAssignment();
			if (_table != null)
			{
				_table.Refresh();
			}
		}

		public void RefreshRowAssignment()
		{
			foreach (KeyValuePair<int, StaffMenuRowBase> item in new Dictionary<int, StaffMenuRowBase>(_rowsInUse))
			{
				int key = item.Key;
				StaffMenuRowBase value = item.Value;
				if (key < _staff.Count)
				{
					UpdateRow(key, value);
				}
				else
				{
					ReleaseRow(key);
				}
			}
		}

		public void RefreshRowJobs()
		{
			foreach (StaffMenuRowBase value in _rowsInUse.Values)
			{
				StaffMenuJobAssignRow staffMenuJobAssignRow = value as StaffMenuJobAssignRow;
				if (staffMenuJobAssignRow != null)
				{
					staffMenuJobAssignRow.RefreshJobs(_jobs[(int)staffMenuJobAssignRow.Staff.Definition._type]);
				}
			}
		}

		public bool AreAllStaffAtMaximumPay()
		{
			for (int i = 0; i < NumOfRows; i++)
			{
				Staff staff = _staff[i].Staff;
				if (staff != null)
				{
					int num = (int)((float)staff.GetDesiredSalary() * (1f + GameAlgorithms.Config.MaxDesiredSalary));
					if (staff.GetSalary() < num)
					{
						return false;
					}
				}
			}
			return true;
		}

		public void UpdateSatisfyCost(out int satisfyCost, out bool revertable, out bool satisfiable, int[] satisfactionCount)
		{
			satisfyCost = 0;
			revertable = false;
			satisfiable = false;
			for (int i = 0; i < _staff.Count; i++)
			{
				StaffEntry value = _staff[i];
				if (value.CanRevert)
				{
					revertable = true;
				}
				StaffDefinition.Satisfaction satisfaction = GameAlgorithms.CalculatePaySatisfactionLevel(value.Staff.GetDesiredSalaryDifference());
				bool flag = satisfaction switch
				{
					StaffDefinition.Satisfaction.VeryUnhappy => false, 
					StaffDefinition.Satisfaction.Unhappy => false, 
					StaffDefinition.Satisfaction.Satisfied => true, 
					StaffDefinition.Satisfaction.Happy => true, 
					StaffDefinition.Satisfaction.VeryHappy => true, 
					_ => false, 
				};
				if (!flag)
				{
					satisfiable = true;
					satisfyCost += Mathf.Max(0, value.Staff.GetDesiredSalary() - value.Staff.GetSalary());
				}
				satisfactionCount[(int)satisfaction]++;
				if (value.IsSatisfied != flag || value.PaySatisfaction != satisfaction)
				{
					value.IsSatisfied = flag;
					value.PaySatisfaction = satisfaction;
					_staff[i] = value;
				}
			}
		}

		public void SatisfyPayRequest()
		{
			for (int i = 0; i < _staff.Count; i++)
			{
				StaffEntry value = _staff[i];
				value.PayRiseSlider = 0f;
				if (StaffMenuPayReviewRow.SatisfyPayRequest(value.Staff) && value.Staff.GetSalary() != value.InitialSalary)
				{
					value.IsSatisfied = true;
					value.CanRevert = true;
				}
				_staff[i] = value;
			}
		}

		public void IncreaseAllPay(float percentage)
		{
			for (int i = 0; i < _staff.Count; i++)
			{
				StaffEntry value = _staff[i];
				StaffMenuPayReviewRow.IncreasePay(value.Staff, percentage);
				_staff[i] = value;
			}
		}

		public void AssignTable(Table table)
		{
			if (!(_table != table))
			{
				return;
			}
			foreach (StaffMenuRowBase value in _rowsInUse.Values)
			{
				UnityEngine.Object.Destroy(value.gameObject);
			}
			_rowsInUse.Clear();
			foreach (StaffMenuRowBase item in _rowsPool)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			_rowsPool.Clear();
			_table = table;
		}

		public void ReleaseRow(int i)
		{
			if (!_rowsInUse.TryGetValue(i, out var value))
			{
				return;
			}
			value.Setup(null, null, null);
			_rowsPool.Add(value);
			_rowsInUse.Remove(i);
			_cachedCanvasRendererList.Clear();
			value.GetComponentsInChildren(_cachedCanvasRendererList);
			foreach (CanvasRenderer cachedCanvasRenderer in _cachedCanvasRendererList)
			{
				cachedCanvasRenderer.cull = true;
			}
			_cachedCanvasRendererList.Clear();
		}

		private void UpdateRow(int index, StaffMenuRowBase row)
		{
			if (row.Staff != _staff[index].Staff)
			{
				int type = (int)_staff[index].Staff.Definition._type;
				row.Setup(_staff[index].Staff, _jobs[type], _staffMenu);
				if (_staff[index].Staff.Definition._staffTypeSpriteOverride != null)
				{
					row.SetTypeSprite(_staff[index].Staff.Definition._staffTypeSpriteOverride);
				}
				else
				{
					row.SetTypeSprite(_staffMenuSettings.TypeSprites[type]);
				}
				StaffMenuPayReviewRow staffMenuPayReviewRow = row as StaffMenuPayReviewRow;
				row.Refresh(instant: true);
				if (staffMenuPayReviewRow != null)
				{
					staffMenuPayReviewRow.SalarySliderValue = _staff[index].PayRiseSlider;
					staffMenuPayReviewRow.SetupPay(_staff[index].InitialSalary, _staff[index].CanRevert, _staff[index].IsSatisfied);
				}
				StaffMenuJobAssignRow staffMenuJobAssignRow = row as StaffMenuJobAssignRow;
				if (staffMenuJobAssignRow != null)
				{
					staffMenuJobAssignRow.ToggleChangedFunc = OnToggleChanged;
					staffMenuJobAssignRow.RefreshJobs(_jobs[type]);
				}
				row.SetRowBackground(index);
				if (row.Staff == _currentSelectedStaff)
				{
					row.ButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				}
				else
				{
					row.ButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				}
			}
		}

		public RectTransform GetRow(int i)
		{
			if (_rowsInUse.TryGetValue(i, out var row))
			{
				return row.GetComponent<RectTransform>();
			}
			_table.SetDirty();
			if (_rowsPool.Count == 0)
			{
				row = UnityEngine.Object.Instantiate(_rowPrefab).GetComponent<StaffMenuRowBase>();
				row.transform.SetParent(_table.Rows.transform, worldPositionStays: false);
				UpdateRow(i, row);
				row.Button.onPrimaryDown.AddListener(delegate
				{
					CurrentSelectedStaff = row.Staff;
				});
			}
			else
			{
				row = _rowsPool[_rowsPool.Count - 1];
				_rowsPool.RemoveAt(_rowsPool.Count - 1);
				UpdateRow(i, row);
				_cachedCanvasRendererList.Clear();
				row.GetComponentsInChildren(_cachedCanvasRendererList);
				foreach (CanvasRenderer cachedCanvasRenderer in _cachedCanvasRendererList)
				{
					cachedCanvasRenderer.cull = false;
					_cachedGraphicsList.Clear();
					cachedCanvasRenderer.GetComponents(_cachedGraphicsList);
					for (int num = 0; num < _cachedGraphicsList.Count; num++)
					{
						_cachedGraphicsList[num].SetVerticesDirty();
					}
					_cachedGraphicsList.Clear();
				}
				_cachedCanvasRendererList.Clear();
			}
			_rowsInUse.Add(i, row);
			return row.GetComponent<RectTransform>();
		}

		public void SortColumn(int columnIndex, Table.SortDirection sortDirection)
		{
			if (_rowPrefab.GetComponent<StaffMenuPayReviewRow>() != null)
			{
				switch (columnIndex)
				{
				case 1:
					_staff.Sort((sortDirection == Table.SortDirection.Ascending) ? _rankComparerAscending : _rankComparerDescending);
					break;
				case 2:
					_staff.Sort((sortDirection == Table.SortDirection.Ascending) ? _qualificationComparerAscending : _qualificationComparerDescending);
					break;
				case 3:
					_staff.Sort((sortDirection == Table.SortDirection.Ascending) ? _salaryComparerAscending : _salaryComparerDescending);
					break;
				case 4:
					_staff.Sort((sortDirection == Table.SortDirection.Ascending) ? _happinessComparerAscending : _happinessComparerDescending);
					break;
				}
			}
			else
			{
				switch (columnIndex)
				{
				case 2:
					_staff.Sort((sortDirection == Table.SortDirection.Ascending) ? _rankComparerAscending : _rankComparerDescending);
					break;
				case 3:
					_staff.Sort((sortDirection == Table.SortDirection.Ascending) ? _qualificationComparerAscending : _qualificationComparerDescending);
					break;
				case 4:
					_staff.Sort((sortDirection == Table.SortDirection.Ascending) ? _happinessComparerAscending : _happinessComparerDescending);
					break;
				case 5:
					_staff.Sort((sortDirection == Table.SortDirection.Ascending) ? _energyComparerAscending : _energyComparerDescending);
					break;
				}
			}
			RefreshRowAssignment();
		}

		public void SetRowsToOrginalOrder()
		{
			_staff.Sort(_defaultStaffOrderComparer);
			RefreshRowAssignment();
		}

		public void OnStaffHired(Staff staff)
		{
			if (!(_table == null) && _table.isActiveAndEnabled)
			{
				AddStaff(staff);
				RefreshRowAssignment();
				_table.Refresh();
			}
		}

		private void OnStaffDestroyed(Staff staff)
		{
			if (!(_table == null) && _table.isActiveAndEnabled)
			{
				if (_currentSelectedStaff != null && _currentSelectedStaff == staff)
				{
					_currentSelectedStaff = null;
				}
				if (_staff.RemoveAll((StaffEntry s) => s.Staff == staff) != 0)
				{
					RefreshRowAssignment();
					_table.Refresh();
				}
			}
		}

		public override void Destroy()
		{
			base.Destroy();
			foreach (StaffMenuRowBase value in _rowsInUse.Values)
			{
				UnityEngine.Object.Destroy(value.gameObject);
			}
			_rowsPool.ClearAndDestroy();
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffResigned, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents3.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
		}

		public void OnColumnPressed(JobDescription job)
		{
			bool flag = true;
			foreach (StaffMenuRowBase value in _rowsInUse.Values)
			{
				if (!value.Staff.JobExclusions.Contains(job))
				{
					flag = false;
					break;
				}
			}
			foreach (StaffMenuRowBase value2 in _rowsInUse.Values)
			{
				if (flag)
				{
					if (value2.Staff.JobExclusions.Contains(job))
					{
						value2.Staff.JobExclusions.Remove(job);
					}
				}
				else
				{
					value2.Staff.JobExclusions.AddUnique(job);
				}
			}
		}

		public void OnRowPressed(Staff staff)
		{
			if (staff.Definition._cantReassignJobs)
			{
				return;
			}
			List<JobDescription> list = _jobs[(int)_staffFilter];
			int num = 0;
			foreach (JobDescription item in list)
			{
				if (item.IsSuitable(staff))
				{
					num++;
				}
			}
			if (staff.JobExclusions.Count < num)
			{
				foreach (JobDescription item2 in list)
				{
					if (item2.IsSuitable(staff))
					{
						staff.JobExclusions.AddUnique(item2);
					}
				}
				return;
			}
			staff.JobExclusions.Clear();
		}

		private void OnToggleChanged(JobDescription job, Staff staff)
		{
			RefreshRowAssignment();
			foreach (StaffMenuRowBase value in _rowsInUse.Values)
			{
				if (value.Staff == staff)
				{
					StaffMenuJobAssignRow staffMenuJobAssignRow = value as StaffMenuJobAssignRow;
					if (!(staffMenuJobAssignRow == null))
					{
						staffMenuJobAssignRow.RefreshJobAssignmentCounter(_jobs[(int)_staffFilter]);
					}
				}
			}
			OnTogglePressed.InvokeSafe(job);
		}

		private void OnAlternativeTogglePressed(JobDescription job, Staff staff)
		{
			if (!staff.JobExclusions.Contains(job))
			{
				staff.JobExclusions.Clear();
			}
			else
			{
				foreach (JobDescription item in _jobs[(int)_staffFilter])
				{
					staff.JobExclusions.AddUnique(item);
				}
			}
			RefreshRowJobs();
		}
	}
}
