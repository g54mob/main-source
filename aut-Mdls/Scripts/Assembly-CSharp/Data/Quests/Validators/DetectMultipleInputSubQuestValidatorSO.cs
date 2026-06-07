using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect Multiple Inputs", fileName = "DetectMultipleInputs", order = 5)]
	public class DetectMultipleInputSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private List<InputActionReference> _inputActionReferences;

		private bool _initialized;

		private bool _actionWasPerformed;

		private int _performedCount;

		public override bool IsValid()
		{
			if (!_initialized)
			{
				foreach (InputActionReference inputActionReference in _inputActionReferences)
				{
					inputActionReference.action.performed += HandleActionPerformed;
				}
				_initialized = true;
				_actionWasPerformed = false;
				_performedCount = 0;
				return false;
			}
			if (_actionWasPerformed)
			{
				_initialized = false;
				_actionWasPerformed = false;
				_performedCount = 0;
				return true;
			}
			return false;
		}

		private void HandleActionPerformed(InputAction.CallbackContext obj)
		{
			obj.action.performed -= HandleActionPerformed;
			_performedCount++;
			if (_performedCount == _inputActionReferences.Count)
			{
				_actionWasPerformed = true;
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public override void Reset()
		{
			_actionWasPerformed = false;
			_initialized = false;
			_performedCount = 0;
			foreach (InputActionReference inputActionReference in _inputActionReferences)
			{
				inputActionReference.action.performed -= HandleActionPerformed;
			}
		}
	}
}
