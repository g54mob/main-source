using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class MinMaxSliderTest : MonoBehaviour
	{
		[MinMaxSlider(0f, 1f)]
		public Vector2 minMaxSlider0;

		public MinMaxSliderNest1 nest1;
	}
}
