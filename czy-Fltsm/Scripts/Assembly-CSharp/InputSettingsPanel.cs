using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

public class InputSettingsPanel : SettingsPanel
{
	[Header("Specific Input Settings fields")]
	[Tooltip("Reference to the control mapper class.")]
	[SerializeField]
	private ControlMapper _controlMapper;

	[Tooltip("Reference to the control mapper canvas.")]
	[SerializeField]
	private Canvas _canvas;

	public override bool IsCurrentlySelected => true;

	public override void ActivatePanel()
	{
		base.ActivatePanel();
		_canvas.enabled = true;
	}

	public override void DeactivatePanel()
	{
		if (_canvas.enabled)
		{
			ApplyChanges();
			_canvas.enabled = false;
		}
		base.DeactivatePanel();
	}

	protected override void Reset()
	{
		_controlMapper.RestoreDefaultsNoPopup();
		ApplyChanges();
	}

	public override void ApplyChanges()
	{
		if (ReInput.userDataStore != null)
		{
			ReInput.userDataStore.Save();
		}
	}

	public override void Load(Settings settingsData)
	{
	}

	public override bool HasChanges()
	{
		return false;
	}
}
