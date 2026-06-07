using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Simulator
{
	[Settings("Application Settings/Controls", Scope.Project)]
	public class ControlsApplicationOptions : CustomApplicationOptions<ControlsApplicationOptions>
	{
		[SerializeField]
		private InputActionAsset m_inputActionAsset;

		[SerializeField]
		private PlayerPrefString m_inputActionBindingOverridesJson;

		private void Save()
		{
			m_inputActionBindingOverridesJson.Value = m_inputActionAsset.SaveBindingOverridesAsJson();
		}

		public override void Load()
		{
			m_inputActionBindingOverridesJson.Load();
			if (!string.IsNullOrWhiteSpace(m_inputActionBindingOverridesJson.Value))
			{
				m_inputActionAsset.LoadBindingOverridesFromJson(m_inputActionBindingOverridesJson.Value);
			}
			InputSystem.onActionChange += OnActionChange_Save;
		}

		public override void ResetSettings()
		{
			m_inputActionBindingOverridesJson.Reset();
			m_inputActionAsset.RemoveAllBindingOverrides();
		}

		private void OnActionChange_Save(object obj, InputActionChange change)
		{
			if (change == InputActionChange.BoundControlsChanged)
			{
				InputActionMap inputActionMap = (obj as InputAction)?.actionMap ?? (obj as InputActionMap);
				if (!((inputActionMap?.asset ? inputActionMap.asset : (obj as InputActionAsset)) != m_inputActionAsset))
				{
					Save();
				}
			}
		}
	}
}
