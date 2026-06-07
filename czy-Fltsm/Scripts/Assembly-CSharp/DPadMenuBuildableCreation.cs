using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BuildableCreation))]
public class DPadMenuBuildableCreation : DPadMenu
{
	[SerializeField]
	private BuildableCreation _buildableCreation;

	private bool _initialized;

	public override void Enable(int triggerAction, bool handleInput)
	{
		if (!_initialized)
		{
			_buildableCreation.Initialize();
			base.SelectableGroup.Initialize();
			_initialized = true;
		}
		base.Enable(triggerAction, handleInput);
	}

	public override void Trigger()
	{
		if ((bool)EventSystem.current.currentSelectedGameObject && EventSystem.current.currentSelectedGameObject.TryGetComponent<BuildableToggle>(out var component))
		{
			component.Trigger();
		}
		base.Trigger();
	}
}
