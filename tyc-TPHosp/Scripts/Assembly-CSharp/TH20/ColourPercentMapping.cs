using System;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public struct ColourPercentMapping
	{
		public Color Colour;

		[Range(50f, 120f)]
		public float upToPercent;
	}
}
