using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect Input", fileName = "DetectInput", order = 4)]
	public class DetectInputSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private InputActionReference _inputActionReference;

		private bool _initialized;

		private bool _actionWasPerformed;

		public override bool IsValid()
		{
			if (!_initialized)
			{
				_inputActionReference.action.performed += HandleActionPerformed;
				_initialized = true;
				_actionWasPerformed = false;
				return false;
			}
			if (_actionWasPerformed)
			{
				_actionWasPerformed = false;
				_initialized = false;
				return true;
			}
			return false;
		}

		private void HandleActionPerformed(InputAction.CallbackContext obj)
		{
			_inputActionReference.action.performed -= HandleActionPerformed;
			_actionWasPerformed = true;
		}

		[Button(null, EButtonEnableMode.Always)]
		public override void Reset()
		{
			_actionWasPerformed = false;
			_initialized = false;
			if (_inputActionReference != null)
			{
				_inputActionReference.action.performed -= HandleActionPerformed;
			}
		}
	}
}
