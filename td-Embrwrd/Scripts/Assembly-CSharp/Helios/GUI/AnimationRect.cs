using UnityEngine;

namespace Helios.GUI
{
	public class AnimationRect : MonoBehaviour
	{
		public float timeAnimScale;

		public float timeDelayScale;

		public float timeAnimRight;

		public float timeDelayRight;

		public float timeDelayRightNext;

		public float timeAnimLeft;

		public float timeDelayLeft;

		public float timeDelayLeftNext;

		public float timeAnimTop;

		public float timeDelayTop;

		public float timeDelayTopNext;

		public float timeAnimBot;

		public float timeDelayBot;

		public float timeDelayBotNext;

		public RectTransform[] rectAnimScale;

		public RectTransform[] rectAnimRight;

		public RectTransform[] rectAnimLeft;

		public RectTransform[] rectAnimTop;

		public RectTransform[] rectAnimBot;

		private Vector3 scaleStart;

		private void OnEnable()
		{
		}
	}
}
