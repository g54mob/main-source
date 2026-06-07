using System;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public struct TransformOffset
	{
		[Tooltip("Local Position")]
		public Vector3 Position;

		[Tooltip("Local rotation Euler")]
		public Vector3 Rotation;

		[Tooltip("Local Scale")]
		public Vector3 Scale;

		public TransformOffset(int _)
		{
			Position = Vector3.zero;
			Rotation = Vector3.zero;
			Scale = Vector3.one;
		}

		public TransformOffset(Transform def)
		{
			Position = def.localPosition;
			Rotation = def.localEulerAngles;
			Scale = def.localScale;
		}

		public readonly void RestoreTransform(Transform def)
		{
			def.localPosition = Position;
			def.localEulerAngles = Rotation;
			def.localScale = Scale;
		}

		public readonly void SetOffset(Transform t)
		{
			t.localPosition = Position;
			t.localEulerAngles = Rotation;
			t.localScale = Scale;
		}
	}
}
