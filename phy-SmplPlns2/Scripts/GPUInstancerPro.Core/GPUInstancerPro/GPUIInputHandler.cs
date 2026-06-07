using UnityEngine;
using UnityEngine.InputSystem;

namespace GPUInstancerPro
{
	public abstract class GPUIInputHandler : MonoBehaviour
	{
		private Mouse _mouse;

		private Keyboard _keyboard;

		public Vector3 MousePosition => Input.mousePosition;

		protected virtual void Start()
		{
			_mouse = Mouse.current;
			_keyboard = Keyboard.current;
		}

		public bool GetMouseButton(int button)
		{
			return Input.GetMouseButton(button);
		}

		public bool GetMouseButtonUp(int button)
		{
			return Input.GetMouseButtonUp(button);
		}

		public float GetAxis(string axisName)
		{
			if (string.IsNullOrEmpty(axisName))
			{
				return 0f;
			}
			return Input.GetAxis(axisName);
		}

		public bool GetKey(KeyCode key)
		{
			return Input.GetKey(key);
		}

		public bool GetKeyUp(KeyCode key)
		{
			return Input.GetKeyUp(key);
		}

		public bool GetKeyDown(KeyCode key)
		{
			return Input.GetKeyDown(key);
		}

		private string GetKeyString(KeyCode key)
		{
			switch (key)
			{
			case KeyCode.W:
				return "W";
			case KeyCode.S:
				return "S";
			case KeyCode.A:
				return "A";
			case KeyCode.D:
				return "D";
			case KeyCode.Q:
				return "Q";
			case KeyCode.E:
				return "E";
			case KeyCode.LeftShift:
				return "LeftShift";
			case KeyCode.Space:
				return "Space";
			case KeyCode.Alpha0:
				return "0";
			case KeyCode.Alpha1:
				return "1";
			case KeyCode.Alpha2:
				return "2";
			case KeyCode.Alpha3:
				return "3";
			default:
			{
				string text = key.ToString();
				if (text.StartsWith("Alpha"))
				{
					text = text.Substring(5);
				}
				return text;
			}
			}
		}
	}
}
