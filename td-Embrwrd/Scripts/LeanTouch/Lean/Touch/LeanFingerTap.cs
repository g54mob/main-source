using System;
using Lean.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanFingerTap")]
	[AddComponentMenu("Lean/Touch/Lean Finger Tap")]
	public class LeanFingerTap : MonoBehaviour
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

		[Serializable]
		public class IntEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private bool ignoreStartedOverGui;

		[SerializeField]
		private bool ignoreIsOverGui;

		[SerializeField]
		private LeanSelectable requiredSelectable;

		[SerializeField]
		private int requiredTapCount;

		[SerializeField]
		private int requiredTapInterval;

		[SerializeField]
		private LeanFingerEvent onFinger;

		[SerializeField]
		private IntEvent onCount;

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

		public bool IgnoreIsOverGui
		{
			get
			{
				return false;
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

		public int RequiredTapCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int RequiredTapInterval
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public LeanFingerEvent OnFinger => null;

		public IntEvent OnCount => null;

		public Vector3Event OnWorld => null;

		public Vector2Event OnScreen => null;

		protected virtual void Start()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void HandleFingerTap(LeanFinger finger)
		{
		}
	}
}
