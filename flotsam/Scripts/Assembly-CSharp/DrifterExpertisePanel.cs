using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrifterExpertisePanel : DrifterPanelBase
{
	[SerializeField]
	private List<DrifterAttributes.AttributeType> _displayedAttributes;

	[SerializeField]
	private ChildBehaviourCache<DrifterExpertiseRow> _drifterExpertiseRowCache;

	[SerializeField]
	private ChildBehaviourCache<DrifterExpertiseIconContainer> _expertiseIconCache;

	[SerializeField]
	private GameObject _header;

	[SerializeField]
	private RewiredAction _increaseAction;

	[SerializeField]
	private RewiredAction _decreaseAction;

	[SerializeField]
	private DrifterFieldInfo _drifterFieldInfo;

	private List<DrifterExpertiseRow> _drifterExpertiseRows;

	private DrifterExpertiseRow _selectedExpertiseRow;

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
		if ((bool)_header)
		{
			_header.SetActive(value: false);
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (!base.Open(id, context))
		{
			return false;
		}
		_drifterFieldInfo.Initialize();
		_expertiseIconCache.Reset();
		foreach (DrifterAttributes.AttributeType displayedAttribute in _displayedAttributes)
		{
			_expertiseIconCache.Get(active: true).Initialize(displayedAttribute);
		}
		_expertiseIconCache.Trim();
		if ((bool)_header)
		{
			_header.SetActive(value: true);
		}
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
		if (_drifterExpertiseRows == null)
		{
			_drifterExpertiseRows = new List<DrifterExpertiseRow>(drifters.Count);
		}
		else
		{
			_drifterExpertiseRows.Clear();
		}
		_drifterExpertiseRowCache.Reset();
		foreach (Agent drifter in drifters)
		{
			_drifterExpertiseRowCache.Get(active: true).Initialize(drifter, _displayedAttributes);
		}
		_drifterExpertiseRowCache.Trim();
	}

	public override void SetSelectedDrifter(Agent drifter)
	{
		foreach (DrifterExpertiseRow instance in _drifterExpertiseRowCache.Instances)
		{
			if (instance.AgentReference == drifter && instance.gameObject.activeInHierarchy)
			{
				if ((bool)_selectedExpertiseRow)
				{
					_selectedExpertiseRow.Deselect();
				}
				_selectedExpertiseRow = instance;
				_selectedDutyIndex = _selectedExpertiseRow.Select(_selectedDutyIndex);
			}
		}
	}

	public override void OnMove(AxisEventData axisEventData)
	{
		switch (axisEventData.moveDir)
		{
		case MoveDirection.Left:
			_selectedDutyIndex = _selectedExpertiseRow.SelectLeft(_selectedDutyIndex);
			break;
		case MoveDirection.Right:
			_selectedDutyIndex = _selectedExpertiseRow.SelectRight(_selectedDutyIndex);
			break;
		}
	}

	public void IncreaseSelected()
	{
		_selectedExpertiseRow.IncreaseSelected();
	}

	public void DecreaseSelected()
	{
		_selectedExpertiseRow.DecreaseSelected();
	}
}
