using System.Collections;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class CursorManager : SingletonBehaviour<CursorManager>
	{
		public delegate Vector3 CursorPositionDelegate();

		private bool cursorUnlocked;

		private RequestSystem requestSystem = new RequestSystem(0f);

		private Vector2? mousePosition;

		private Coroutine coro;

		private CursorPositionDelegate PointerPositionOverride;

		public static bool Visible
		{
			get
			{
				if (SingletonBehaviour<CursorManager>.Instance.cursorUnlocked)
				{
					return Cursor.visible;
				}
				return false;
			}
		}

		public Vector3 PointerPosition
		{
			get
			{
				if (PointerPositionOverride == null)
				{
					return Input.mousePosition;
				}
				return PointerPositionOverride();
			}
		}

		public new static string AllowAutoCreate()
		{
			return "[CursorManager]";
		}

		protected override void Awake()
		{
			base.Awake();
			requestSystem.ValueChanged += OnValueChanged;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void OnValueChanged(float value)
		{
			bool flag = value > 0.5f;
			if (coro != null)
			{
				StopCoroutine(coro);
			}
			if (flag && (!Cursor.visible || Cursor.lockState != CursorLockMode.None))
			{
				Cursor.lockState = CursorLockMode.None;
				SetCursorPos(mousePosition);
				Cursor.visible = flag;
				coro = StartCoroutine(CheckCursor());
			}
			else if (!flag && (Cursor.visible || Cursor.lockState != CursorLockMode.Locked))
			{
				GetCursorPos(out mousePosition);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = flag;
			}
		}

		private IEnumerator CheckCursor()
		{
			cursorUnlocked = false;
			int frameCounter = 0;
			while (!cursorUnlocked && frameCounter < 10)
			{
				yield return WaitFor.EndOfFrame;
				frameCounter++;
				if (!(Mathf.Abs(Input.mousePosition.x - (float)Screen.width * 0.5f) <= 1f) && !(Mathf.Abs(Input.mousePosition.y - (float)Screen.height * 0.5f) <= 1f))
				{
					break;
				}
			}
			cursorUnlocked = true;
		}

		public void RequestCursor(object caller, bool visible, int priority = 0)
		{
			requestSystem.RequestValue(caller, visible ? 1f : 0f, priority);
		}

		public void RemoveRequest(object caller)
		{
			requestSystem.RemoveValue(caller);
		}

		public static void GetCursorPos(out Vector2? cursorPosition)
		{
			cursorPosition = Input.mousePosition;
		}

		public static void SetCursorPos(Vector2? cursorPosition)
		{
			if (cursorPosition.HasValue)
			{
				MousePositionHack.TryWarpCursorPosition(cursorPosition.Value);
			}
		}

		public void SetPointerPositionOverrideMethod(CursorPositionDelegate method)
		{
			PointerPositionOverride = method;
		}
	}
}
