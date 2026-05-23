using UnityEngine;

namespace ThreeDISevenZeroR.UnityGifDecoder.Model
{
	public class GifImage
	{
		public bool userInput;

		public Color32[] colors;

		public int delay;

		public int DelayMs => 0;

		public float SafeDelayMs => 0f;

		public float DelaySeconds => 0f;

		public float SafeDelaySeconds => 0f;
	}
}
