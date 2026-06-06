using UnityEngine;
using UnityEngine.UI;

public class ToggleTrigger : MonoBehaviour
{
	[SerializeField]
	private Toggle _target;

	[SerializeField]
	private SelectableGroup _targetSelectableGroup;

	[SerializeField]
	private bool _withoutNotify = true;

	private void OnEnable()
	{
		if ((bool)_target)
		{
			if (_withoutNotify)
			{
				_target.SetIsOnWithoutNotify(value: true);
			}
			else
			{
				_target.isOn = true;
			}
			if ((bool)_targetSelectableGroup)
			{
				_targetSelectableGroup.TrySelect(_target);
			}
		}
	}
}
