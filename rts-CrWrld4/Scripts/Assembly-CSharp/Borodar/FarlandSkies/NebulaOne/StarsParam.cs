using System;
using Borodar.FarlandSkies.Core.DotParams;
using UnityEngine;

namespace Borodar.FarlandSkies.NebulaOne
{
	[Serializable]
	public class StarsParam : DotParam
	{
		public Color Tint;

		public float BrightnessMin;

		public float BrightnessMax;
	}
}
