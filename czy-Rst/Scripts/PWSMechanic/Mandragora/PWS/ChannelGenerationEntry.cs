using System;
using UnityEngine;

namespace Mandragora.PWS
{
	[Serializable]
	public struct ChannelGenerationEntry
	{
		public float NoiseScale;

		[Range(0f, 1f)]
		public float MinColorValueClamp;

		[Range(0f, 1f)]
		public float MaxColorValueClamp;

		[Range(0f, 1f)]
		public float MinEdgeSmoothStepValue;

		[Range(0f, 1f)]
		public float MaxEdgeSmoothStepValue;
	}
}
