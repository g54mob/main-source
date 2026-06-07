using System;
using UnityEngine;

namespace Coherence.Interpolation
{
	[Serializable]
	public struct SmoothingSettings
	{
		public static readonly SmoothingSettings Default;

		public static readonly SmoothingSettings Empty;

		[Tooltip("Seconds to remain behind the current interpolation point. Applied using Mathf.SmoothDamp (or Mathf.SmoothDampAngle for Quaternions).")]
		[Range(0f, 1f)]
		public float smoothTime;

		[Tooltip("Maximum SmoothDamp speed allowed. Zero means no maximum is imposed.")]
		public float maxSpeed;
	}
}
