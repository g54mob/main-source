using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	public class InputControllerInputPartModifierWrapper : IInputControllerInput
	{
		private bool _initialized;

		private IInputControllerInput _input;

		private string _modifierId;

		private string _partId;

		public bool Enabled
		{
			get
			{
				if (_input != null)
				{
					return _input.Enabled;
				}
				return false;
			}
		}

		public IInputControllerInput Input => _input;

		public string ModifierId => _modifierId;

		public string PartId => _partId;

		public float Value => _input.Value;

		public InputControllerInputPartModifierWrapper(string partId, string modifierId)
		{
			_partId = partId;
			_modifierId = modifierId;
			_initialized = false;
			_input = null;
		}

		public void RefreshInput(IPartScript partScript)
		{
			PartModifierScript modifier = _input as PartModifierScript;
			if (!InputControllerInput.IsValidInput(modifier, partScript))
			{
				modifier = InputControllerInput.FindTargetModifier(partScript, _partId, _modifierId)?.GetScript();
				if (modifier is IInputControllerInput && InputControllerInput.IsValidInput(modifier, partScript))
				{
					_input = (IInputControllerInput)modifier;
				}
				else
				{
					_input = null;
				}
			}
			if (!_initialized)
			{
				_initialized = true;
				if (_input == null)
				{
					Debug.LogWarning($"Could not find part modifier input '{_partId ?? string.Empty}.{_modifierId}' for part '{partScript.Data.Id}'.");
				}
			}
		}
	}
}
