using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DPadMenu : DPadMenuBase, ISelectableGroupFirstSelectedProvider
{
	[Header("D-Pad Menu")]
	[SerializeField]
	private SelectableGroup _selectableGroup;

	[SerializeField]
	private List<ActionTrigger> _actionTriggers;

	[SerializeField]
	private ActionBase[] _actions;

	[SerializeField]
	private ActionTrigger _actionTriggerPrefab;

	[SerializeField]
	private TextMeshProUGUI _titleField;

	[SerializeField]
	private TextMeshProUGUI _descriptionField;

	protected SelectableGroup SelectableGroup => _selectableGroup;

	protected override void Awake()
	{
		if (_selectableGroup == null)
		{
			_selectableGroup = GetComponent<SelectableGroup>();
		}
		if (_actions.Length != 0)
		{
			for (int i = 0; i < _actions.Length; i++)
			{
				ActionTrigger actionTrigger = Object.Instantiate(_actionTriggerPrefab, base.transform);
				actionTrigger.Initialize(_actions[i]);
				actionTrigger.OnSelected.AddListener(OnActionTriggerSelected);
				_actionTriggers.Add(actionTrigger);
			}
		}
		base.Awake();
	}

	private void OnDestroy()
	{
		foreach (ActionTrigger actionTrigger in _actionTriggers)
		{
			actionTrigger.OnSelected.RemoveListener(OnActionTriggerSelected);
		}
	}

	public override void Enable(int triggerAction, bool handleInput)
	{
		base.Enable(triggerAction, handleInput);
		base.transform.parent.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: true);
	}

	public override void Trigger()
	{
		Disable();
		if (_selectableGroup.Selected is ActionTrigger actionTrigger)
		{
			actionTrigger.Trigger();
		}
	}

	public override void Disable()
	{
		base.Disable();
		base.gameObject.SetActive(value: false);
		base.transform.parent.gameObject.SetActive(value: false);
	}

	private void OnActionTriggerSelected(ActionTrigger actionTrigger)
	{
		if ((bool)_titleField)
		{
			_titleField.text = actionTrigger.Action.GetLabel();
		}
		if ((bool)_descriptionField)
		{
			_descriptionField.text = actionTrigger.Action.GetDescription();
		}
	}

	public bool TryGetFirstSelected(out Selectable selectable)
	{
		foreach (ActionTrigger actionTrigger in _actionTriggers)
		{
			if (actionTrigger.Action.IsSelected)
			{
				selectable = actionTrigger;
				return true;
			}
		}
		selectable = null;
		return false;
	}
}
