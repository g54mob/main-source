using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class BoxGroupTest : MonoBehaviour
	{
		[BoxGroup("Integers")]
		public int int0;

		[BoxGroup("Integers")]
		public int int1;

		[BoxGroup("Floats")]
		public float float0;

		[BoxGroup("Floats")]
		public float float1;

		[MinMaxSlider(0f, 1f)]
		[BoxGroup("Sliders")]
		public Vector2 slider0;

		[MinMaxSlider(0f, 1f)]
		[BoxGroup("Sliders")]
		public Vector2 slider1;

		public string str0;

		public string str1;

		[BoxGroup(null)]
		public Transform trans0;

		[BoxGroup(null)]
		public Transform trans1;
	}
}
