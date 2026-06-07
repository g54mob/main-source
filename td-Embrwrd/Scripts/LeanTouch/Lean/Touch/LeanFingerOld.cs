using System;
using Lean.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	[AddComponentMenu("Lean/Touch/Lean Finger Old")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanFingerOld")]
	public class LeanFingerOld : MonoBehaviour
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

		[SerializeField]
		private bool ignoreStartedOverGui;

		[SerializeField]
		private bool ignoreIsOverGui;

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

		public LeanFingerEvent OnFinger => null;

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

		private void HandleFingerOld(LeanFinger finger)
		{
		}
	}
}
