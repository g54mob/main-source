using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class MinMaxSliderNest2
	{
		[MinMaxSlider(1f, 11f)]
		public Vector2Int minMaxSlider2 = new Vector2Int(6, 11);
	}
}
