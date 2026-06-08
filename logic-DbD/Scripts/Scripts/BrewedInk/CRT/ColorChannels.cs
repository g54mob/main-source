using System;
using UnityEngine;

namespace BrewedInk.CRT
{
	[Serializable]
	public struct ColorChannels
	{
		[Range(0f, 255f)]
		public int red;

		[Range(0f, 255f)]
		public int green;

		[Range(0f, 255f)]
		public int blue;

		[Tooltip("A greyscale value of 1 will completely make the image grey. A value of 0 leaves the image untouched.")]
		[Range(0f, 1f)]
		public float greyScale;
	}
}
