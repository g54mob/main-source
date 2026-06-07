using System;
using Lean.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	[AddComponentMenu("Lean/Touch/Lean Finger Down")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanFingerDown")]
	public class LeanFingerDown : MonoBehaviour
	{
		[Serializable]
		public class LeanFingerEvent : UnityEvent<LeanFinger>
		{
		}

		[Serializable]
		public class Vector3Event : UnityEvent<Vector3>
		{
		}

		[Serializable]
		public class Vector2Event : UnityEvent<Vector2>
		{
		}

		[Flags]
		public enum ButtonTypes
		{
			LeftMouse = 1,
			RightMouse = 2,
			MiddleMouse = 4,
			Touch = 0x20
		}

		[SerializeField]
		private bool ignoreStartedOverGui;

		[SerializeField]
		private ButtonTypes requiredButtons;

		[SerializeField]
		private LeanSelectable requiredSelectable;

		[SerializeField]
		private LeanFingerEvent onFinger;

		public LeanScreenDepth ScreenDepth;

		[SerializeField]
		private Vector3Event onWorld;

		[SerializeField]
		private Vector2Event onScreen;

		public bool IgnoreStartedOverGui
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ButtonTypes RequiredButtons
		{
			get
			{
				return default(ButtonTypes);
			}
			set
			{
			}
		}

		public LeanSelectable RequiredSelectable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LeanFingerEvent OnFinger => null;

		public Vector3Event OnWorld => null;

		public Vector2Event OnScreen => null;

		protected virtual void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual bool UseFinger(LeanFinger finger)
		{
			return false;
		}

		protected void InvokeFinger(LeanFinger finger)
		{
		}

		protected virtual void HandleFingerDown(LeanFinger finger)
		{
		}

		private bool RequiredButtonPressed(LeanFinger finger)
		{
			return false;
		}
	}
}
