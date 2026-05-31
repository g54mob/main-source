using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class ResetRebind : MonoBehaviour
	{
		[SerializeField]
		private InputActionAsset _inputActions;

		public void ResetAllBindings()
		{
			foreach (InputAction inputAction in _inputActions)
			{
				inputAction.RemoveAllBindingOverrides();
			}
		}
	}
}
