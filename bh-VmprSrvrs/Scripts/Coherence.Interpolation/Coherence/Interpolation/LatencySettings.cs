using System;
using UnityEngine;

namespace Coherence.Interpolation
{
	[Serializable]
	public struct LatencySettings
	{
		public static readonly LatencySettings Default;

		public static readonly LatencySettings Empty;

		[Tooltip("Network latency delay scale factor")]
		[Range(1f, 10f)]
		public float networkLatencyFactor;

		[Tooltip("Additional fixed latency (seconds)")]
		[Range(0f, 10f)]
		public float additionalLatency;
	}
}
