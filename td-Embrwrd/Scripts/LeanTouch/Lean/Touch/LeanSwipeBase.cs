using System;
using UnityEngine;
using UnityEngine.Events;

namespace Lean.Touch
{
	public abstract class LeanSwipeBase : MonoBehaviour
	{
		public enum ModifyType
		{
			None = 0,
			Normalize = 1,
			Normalize4 = 2
		}

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
		private float requiredAngle;

		[SerializeField]
		private float requiredArc;

		[SerializeField]
		public LeanFingerEvent onFinger;

		[SerializeField]
		private ModifyType modify;

		[SerializeField]
		private CoordinateType coordinate;

		[SerializeField]
		private float multiplier;

		[SerializeField]
		public Vector2Event onDelta;

		[SerializeField]
		public FloatEvent onDistance;

		public LeanScreenDepth ScreenDepth;

		[SerializeField]
		public Vector3Event onWorldFrom;

		[SerializeField]
		public Vector3Event onWorldTo;

		[SerializeField]
		public Vector3Event onWorldDelta;

		[SerializeField]
		public Vector3Vector3Event onWorldFromTo;

		public float RequiredAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RequiredArc
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public LeanFingerEvent OnFinger => null;

		public ModifyType Modify
		{
			get
			{
				return default(ModifyType);
			}
			set
			{
			}
		}

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

		protected bool AngleIsValid(Vector2 vector)
		{
			return false;
		}

		protected void HandleFingerSwipe(LeanFinger finger, Vector2 screenFrom, Vector2 screenTo)
		{
		}
	}
}
