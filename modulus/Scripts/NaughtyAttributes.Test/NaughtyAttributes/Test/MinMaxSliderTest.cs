using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class MinMaxSliderTest : MonoBehaviour
	{
		[MinMaxSlider(0f, 1f)]
		public Vector2 minMaxSlider0 = new Vector2(0.25f, 0.75f);

		public MinMaxSliderNest1 nest1;
	}
}
