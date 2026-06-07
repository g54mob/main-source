using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class MinMaxSliderNest1
	{
		[MinMaxSlider(0f, 1f)]
		public Vector2 minMaxSlider1;

		public MinMaxSliderNest2 nest2;
	}
}
