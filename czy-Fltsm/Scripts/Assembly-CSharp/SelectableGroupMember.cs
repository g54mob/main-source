using UnityEngine;

public class SelectableGroupMember : SceneBehaviour
{
	[SerializeField]
	private SelectableGroup _selectableGroup;

	private void OnEnable()
	{
		_selectableGroup.Activate();
	}

	private void OnDisable()
	{
		if (base.gameObject.scene.isLoaded)
		{
			_selectableGroup.Activate();
		}
	}
}
