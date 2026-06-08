using System;
using UnityEngine;

namespace BrewedInk.CRT
{
	[Serializable]
	public struct ColorScan
	{
		[Range(-0.5f, 0.5f)]
		public float greenChannelMultiplier;

		[Range(-0.5f, 0.5f)]
		public float redBlueChannelMultiplier;

		[Range(0f, 10f)]
		public float sizeMultiplier;
	}
}
