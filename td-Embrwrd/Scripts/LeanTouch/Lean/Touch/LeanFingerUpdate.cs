using System;
using Lean.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanFingerUpdate")]
	[AddComponentMenu("Lean/Touch/Lean Finger Update")]
	public class LeanFingerUpdate : MonoBehaviour
	{
		public enum CoordinateType
		{
			ScaledPixels = 0,
			ScreenPixels = 1,
			ScreenPercentage = 2
		}

		[Serializable]
		public class LeanFingerEvent : UnityEvent<LeanFinger>
		{
		}

		[Serializable]
		public class FloatEvent : UnityEvent<float>
		{
		}

		[Serializable]
		public class Vector2Event : UnityEvent<Vector2>
		{
		}

		[Serializable]
		public class Vector3Event : UnityEvent<Vector3>
		{
		}

		[Serializable]
		public class Vector3Vector3Event : UnityEvent<Vector3, Vector3>
		{
		}

		[SerializeField]
		private bool ignoreStartedOverGui;

		[SerializeField]
		private bool ignoreIsOverGui;

		[SerializeField]
		private bool ignoreIfStatic;

		[SerializeField]
		private bool ignoreIfDown;

		[SerializeField]
		private bool ignoreIfUp;

		[SerializeField]
		private bool ignoreIfHover;

		[SerializeField]
		private LeanSelectable requiredSelectable;

		[SerializeField]
		private LeanFingerEvent onFinger;

		[SerializeField]
		private CoordinateType coordinate;

		[SerializeField]
		private float multiplier;

		[SerializeField]
		private Vector2Event onDelta;

		[SerializeField]
		private FloatEvent onDistance;

		public LeanScreenDepth ScreenDepth;

		[SerializeField]
		private Vector3Event onWorldFrom;

		[SerializeField]
		private Vector3Event onWorldTo;

		[SerializeField]
		private Vector3Event onWorldDelta;

		[SerializeField]
		private Vector3Vector3Event onWorldFromTo;

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

		public bool IgnoreIfStatic
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IgnoreIfDown
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IgnoreIfUp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IgnoreIfHover
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

		public CoordinateType Coordinate
		{
			get
			{
				return default(CoordinateType);
			}
			set
			{
			}
		}

		public float Multiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector2Event OnDelta => null;

		public FloatEvent OnDistance => null;

		public Vector3Event OnWorldFrom => null;

		public Vector3Event OnWorldTo => null;

		public Vector3Event OnWorldDelta => null;

		public Vector3Vector3Event OnWorldFromTo => null;

		protected virtual void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void HandleFingerUpdate(LeanFinger finger)
		{
		}
	}
}
