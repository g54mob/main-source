using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input.InputSystem.Processors
{
	public class VariableDeadzoneProcessor : InputProcessor<float>
	{
		[Tooltip("The action map index with the input which will control this deadzone")]
		public int ActionMap = -1;

		[Tooltip("The input index which will control this deadzone")]
		public int InputAction = -1;

		[Tooltip("Maximum deadzone, reached when abs(ControlInput) is at 1")]
		public float Max = 0.5f;

		[Tooltip("Minimum deadzone, reached when ControlInput is zero")]
		public float Min = 0.05f;

		private InputAction _controlInput;

		private float _currentDeadzone = 0.05f;

		public override float Process(float value, InputControl control)
		{
			if (_controlInput == null)
			{
				_controlInput = PlayerInput.all[0].actions.actionMaps[ActionMap].actions[InputAction];
				_controlInput.performed += OnControlInputPerformed;
			}
			if (!(Mathf.Abs(value) > _currentDeadzone))
			{
				return 0f;
			}
			return value - _currentDeadzone * Mathf.Sign(value);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			UnityEngine.InputSystem.InputSystem.RegisterProcessor<VariableDeadzoneProcessor>();
		}

		private void OnControlInputPerformed(InputAction.CallbackContext obj)
		{
			UpdateDeadzone(obj.ReadValue<float>());
		}

		private void UpdateDeadzone(float input)
		{
			_currentDeadzone = Mathf.Lerp(Min, Max, Mathf.Abs(input));
		}
	}
}
