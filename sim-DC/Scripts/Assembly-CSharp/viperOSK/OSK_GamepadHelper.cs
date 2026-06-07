using UnityEngine;
using UnityEngine.Events;

namespace viperOSK
{
	public class OSK_GamepadHelper : MonoBehaviour
	{
		public OSK_Keyboard keyboard;

		public OSK_Receiver receiver;

		public GameObject selectionMarker;

		public int gamepadNum;

		private Vector2 joy;

		public bool allowRepeatButton;

		public bool invertY;

		protected OSK_Key selectedKey;

		public float inputReactiveness;

		private float t;

		private float tBtn;

		private bool aBtnPressed;

		private bool bBtnPressed;

		private bool active;

		private bool connected;

		public UnityEvent onActivate;

		public UnityEvent onDeactivate;

		public void GamepadPrep()
		{
		}

		public OSK_Key GetSelectedKey()
		{
			return null;
		}

		public void SetSelectedKey(OSK_Key k)
		{
		}

		public void SetSelectedKey(string k)
		{
		}

		public void Activate()
		{
		}

		public void DeActivate()
		{
		}

		private void Start()
		{
		}

		private Vector2 JoystickInput()
		{
			return default(Vector2);
		}

		private bool JoystickButtonA()
		{
			return false;
		}

		private bool JoystickButtonB()
		{
			return false;
		}

		private void FixedUpdate()
		{
		}

		private void Update()
		{
		}
	}
}
