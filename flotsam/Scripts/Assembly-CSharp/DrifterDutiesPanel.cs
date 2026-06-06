using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrifterDutiesPanel : DrifterPanelBase
{
	[SerializeField]
	private ChildBehaviourCache<DrifterDutiesRow> _drifterDutiesRowCache;

	[SerializeField]
	private ChildBehaviourCache<AssignmentIcon> _assignmentIconCache;

	[SerializeField]
	private DrifterDutiesRow _templateDutiesRow;

	[SerializeField]
	private RewiredAction _increaseAction;

	[SerializeField]
	private RewiredAction _decreaseAction;

	[SerializeField]
	private DrifterFieldInfo _drifterFieldInfo;

	private List<AssignmentType> _displayedAssignments;

	private List<DrifterDutiesRow> _drifterDutiesRows;

	private DrifterDutiesRow _selectedDutiesRow;

	private int _selectedDutyIndex;

	private void OnEnable()
	{
		_increaseAction.ActivateWait();
		_decreaseAction.ActivateWait();
	}

	private void LateUpdate()
	{
		if (_increaseAction.GetButtonDown())
		{
			IncreaseSelected();
		}
		if (_decreaseAction.GetButtonDown())
		{
			DecreaseSelected();
		}
	}

	private void OnDisable()
	{
		_assignmentIconCache.DeactivateParent();
		if ((bool)_templateDutiesRow)
		{
			_templateDutiesRow.gameObject.SetActive(value: false);
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (!base.Open(id, context))
		{
			return false;
		}
		_drifterFieldInfo.Initialize();
		if (_displayedAssignments == null)
		{
			_displayedAssignments = new List<AssignmentType>(GameManager.Settings.ProjectSettings.AssignmentSettings.Count);
		}
		else
		{
			_displayedAssignments.Clear();
		}
		_assignmentIconCache.Reset();
		foreach (AssignmentSetting assignmentSetting in GameManager.Settings.ProjectSettings.AssignmentSettings)
		{
			if (assignmentSetting.Type != AssignmentType.None && !assignmentSetting.HideInDutiesPanel)
			{
				_assignmentIconCache.Get().Initialize(null, assignmentSetting);
				_displayedAssignments.Add(assignmentSetting.Type);
			}
		}
		_assignmentIconCache.Trim();
		RewiredAction.AddToActionInfoBar(_increaseAction, _decreaseAction);
		return true;
	}

	public override void Close()
	{
		RewiredAction.RemoveFromActionInfoBar(_increaseAction, _decreaseAction);
		base.Close();
	}

	public override void UpdateDrifters(List<Agent> drifters)
	{
		if (_drifterDutiesRows == null)
		{
			_drifterDutiesRows = new List<DrifterDutiesRow>(drifters.Count);
		}
		else
		{
			_drifterDutiesRows.Clear();
		}
		_drifterDutiesRowCache.Reset();
		foreach (Agent drifter in drifters)
		{
			_drifterDutiesRowCache.Get().Initialize(drifter, _displayedAssignments);
		}
		_drifterDutiesRowCache.Trim();
	}

	public override void SetSelectedDrifter(Agent drifter)
	{
		foreach (DrifterDutiesRow instance in _drifterDutiesRowCache.Instances)
		{
			if (instance.Drifter == drifter && instance.gameObject.activeInHierarchy)
			{
				if ((bool)_selectedDutiesRow)
				{
					_selectedDutiesRow.Deselect();
				}
				_selectedDutiesRow = instance;
				_selectedDutyIndex = _selectedDutiesRow.Select(_selectedDutyIndex);
			}
		}
	}

	public override void OnMove(AxisEventData axisEventData)
	{
		switch (axisEventData.moveDir)
		{
		case MoveDirection.Left:
			_selectedDutyIndex = _selectedDutiesRow.SelectLeft(_selectedDutyIndex);
			break;
		case MoveDirection.Right:
			_selectedDutyIndex = _selectedDutiesRow.SelectRight(_selectedDutyIndex);
			break;
		}
	}

	public void IncreaseSelected()
	{
		_selectedDutiesRow.IncreaseSelected();
	}

	public void DecreaseSelected()
	{
		_selectedDutiesRow.DecreaseSelected();
	}
}
