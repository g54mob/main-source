using UnityEngine;

namespace CurvedUI
{
	public class CUI_PerlinNoisePosition : MonoBehaviour
	{
		public float samplingSpeed = 1f;

		public Vector2 Range;

		private RectTransform rectie;

		private void Start()
		{
			rectie = base.transform as RectTransform;
		}

		private void Update()
		{
			rectie.anchoredPosition = new Vector2(Mathf.PerlinNoise(Time.time * samplingSpeed, Time.time * samplingSpeed).Remap(0f, 1f, 0f - Range.x, Range.x), Mathf.PerlinNoise(Time.time * samplingSpeed * 1.333f, Time.time * samplingSpeed * 0.888f).Remap(0f, 1f, 0f - Range.y, Range.y));
		}
	}
}
