using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class MinMaxSliderNest1
	{
		[MinMaxSlider(0f, 1f)]
		public Vector2 minMaxSlider1 = new Vector2(0.25f, 0.75f);

		public MinMaxSliderNest2 nest2;
	}
}
