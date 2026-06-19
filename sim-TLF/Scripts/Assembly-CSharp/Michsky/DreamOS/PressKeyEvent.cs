using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Events/Press Key Event")]
	public class PressKeyEvent : MonoBehaviour
	{
		[SerializeField]
		private InputAction hotkey;

		public UnityEvent pressAction;

		private void Start()
		{
			hotkey.Enable();
		}

		private void Update()
		{
			if (hotkey.triggered)
			{
				pressAction.Invoke();
			}
		}
	}
}
