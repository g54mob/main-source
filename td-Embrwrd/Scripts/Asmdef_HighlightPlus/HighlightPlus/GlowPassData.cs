using System;
using UnityEngine;

namespace HighlightPlus
{
	[Serializable]
	public struct GlowPassData
	{
		public float offset;

		public float alpha;

		[ColorUsage(true, true)]
		public Color color;
	}
}
