using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class MultitoolUIIntro : MonoBehaviour
	{
		public RectTransform logo;

		public Image background;

		public AnimationCurve aberrationAnimation;

		public Transform framesRoot;

		public float frameTime;

		public float logoFadeInTime;

		public float aberrationTime;

		public float logoMovementTime;

		public float finalFadeTime;

		public float jingleDelay;

		private Vector2Int finalLogoPosition;

		private bool init;

		private Action onComplete;

		private void Init()
		{
		}

		public void Show(float startDelay, Action onComplete)
		{
		}

		private IEnumerator IntroCoroutine(float startDelay)
		{
			return null;
		}
	}
}
