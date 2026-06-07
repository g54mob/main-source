using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class SelectionStates : MonoBehaviour
{
	[SerializeField]
	private ColorBlock _colorBlock;

	private SelectionStateManager _manager;

	private Graphic _target;

	private void Awake()
	{
		_manager = GetComponentInParent<SelectionStateManager>();
		if (_manager == null)
		{
			Debug.LogWarning("SelectionStates component is not nested under a SelectionStateManager!");
			return;
		}
		_manager.SelectionStateChangedEvent.AddListener(OnSelectionStateChanged);
		_target = GetComponent<Graphic>();
	}

	private void OnDestroy()
	{
		if ((bool)_manager)
		{
			_manager.SelectionStateChangedEvent.RemoveListener(OnSelectionStateChanged);
		}
	}

	private void OnSelectionStateChanged(SelectionStateManager.SelectionState selectionState)
	{
		switch (selectionState)
		{
		case SelectionStateManager.SelectionState.Normal:
			_target.color = _colorBlock.normalColor;
			break;
		case SelectionStateManager.SelectionState.Highlighted:
			_target.color = _colorBlock.highlightedColor;
			break;
		case SelectionStateManager.SelectionState.Pressed:
			_target.color = _colorBlock.pressedColor;
			break;
		case SelectionStateManager.SelectionState.Selected:
			_target.color = _colorBlock.selectedColor;
			break;
		case SelectionStateManager.SelectionState.Disabled:
			_target.color = _colorBlock.disabledColor;
			break;
		}
	}

	public void SetSelectionState(SelectionStateManager.SelectionState selectionState)
	{
	}
}
