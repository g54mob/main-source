using System;
using UnityEngine;

namespace BrewedInk.CRT
{
	[Serializable]
	public struct ScreenDimensions
	{
		[Range(0f, 0.5f)]
		public float width;

		[Range(0f, 0.5f)]
		public float height;
	}
}
