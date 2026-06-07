using Reactivity;
using UnityEngine;

namespace FractureField.UI
{
	public class KeyboardManager : MonoBehaviour
	{
		private bool IsHoldingShift => false;

		private bool IsHoldingCtrl => false;

		public static RString OnKeyPressed { get; }

		private void Update()
		{
		}

		private bool IsKeyDown(KeyCode key)
		{
			return false;
		}

		private bool IsShiftPlusKeyDown(KeyCode key)
		{
			return false;
		}

		private bool IsCtrlPlusKeyDown(KeyCode key)
		{
			return false;
		}

		private bool IsCtrlPlusShiftPlusKeyDown(KeyCode key)
		{
			return false;
		}

		private void SetKeyPressed(string key)
		{
		}

		private void HandleKeyPresses()
		{
		}

		private void CheckPopupKeys()
		{
		}
	}
}
