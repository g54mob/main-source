using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;

public class JoystickInfoPanel : SettingsPanel
{
	[Header("Joystick Info Panel")]
	[SerializeField]
	private TextMeshProUGUI _nameField;

	[SerializeField]
	private TextMeshProUGUI _guidField;

	[SerializeField]
	private TextMeshProUGUI _templateField;

	[SerializeField]
	private TextMeshProUGUI _identifierField;

	public override void ActivatePanel()
	{
		base.ActivatePanel();
		IList<Joystick> joysticks = FlotsamInputManager.RewiredPlayer.controllers.Joysticks;
		if (0 < joysticks.Count)
		{
			Joystick joystick = joysticks[0];
			_nameField.text = joystick.name;
			_guidField.text = joystick.hardwareTypeGuid.ToString();
			_identifierField.text = joystick.hardwareIdentifier;
			if (0 < joystick.Templates.Count)
			{
				_templateField.text = joystick.Templates[0].name;
			}
			else
			{
				_templateField.text = "None";
			}
		}
	}

	public override void ApplyChanges()
	{
	}

	public override bool HasChanges()
	{
		return false;
	}

	public override void Load(Settings settingsData)
	{
	}

	protected override void Reset()
	{
	}
}
