using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrifterDutiesRow : MonoBehaviour
{
	[SerializeField]
	private ChildBehaviourCache<AssignmentBox> _assignmentBoxCache;

	[SerializeField]
	private Transition _transition;

	private AssignmentBox _selectedBox;

	private int _selectedBoxIndex = -1;

	public Agent Drifter { get; private set; }

	public void Initialize(Agent drifter, List<AssignmentType> assignments)
	{
		Drifter = drifter;
		_assignmentBoxCache.Reset();
		foreach (AssignmentType assignment in assignments)
		{
			_assignmentBoxCache.Get().Initialize(drifter, ReturnAssignment(drifter, assignment));
		}
		_assignmentBoxCache.Trim();
	}

	public int Select(int index)
	{
		SelectBox(index);
		_transition.SetSelected();
		return _selectedBoxIndex;
	}

	public int SelectLeft(int index)
	{
		return SelectBox(index - 1);
	}

	public int SelectRight(int index)
	{
		return SelectBox(index + 1);
	}

	public void Deselect()
	{
		_selectedBox.OnDeselect();
		_selectedBox = null;
		_selectedBoxIndex = -1;
		_transition.SetNormal();
	}

	public void IncreaseSelected()
	{
		if ((bool)_selectedBox)
		{
			_selectedBox.UpdatePriority(increase: true, refresh: true);
		}
	}

	public void DecreaseSelected()
	{
		if ((bool)_selectedBox)
		{
			_selectedBox.UpdatePriority(increase: false, refresh: true);
		}
	}

	private int SelectBox(int index)
	{
		index = Mathf.Clamp(index, 0, _assignmentBoxCache.Instances.Count - 1);
		if (index == _selectedBoxIndex)
		{
			return index;
		}
		AssignmentBox assignmentBox = _assignmentBoxCache.Instances[index];
		if (assignmentBox == null)
		{
			return _selectedBoxIndex;
		}
		if ((bool)_selectedBox)
		{
			_selectedBox.OnDeselect();
		}
		_selectedBoxIndex = index;
		_selectedBox = assignmentBox;
		_selectedBox.OnSelect();
		return index;
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		AgentEvent.Dispatch(GameEventType.AgentFullscreenPanelRefresh, Drifter);
	}

	private Assignment ReturnAssignment(Agent drifter, AssignmentType assignmentType)
	{
		foreach (Assignment assignment in drifter.Assignments)
		{
			if (assignment.Type == assignmentType)
			{
				return assignment;
			}
		}
		return null;
	}
}
