using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.LevelTransition
{
	public class IntroDisplayManager : MonoBehaviour
	{
		public static IntroDisplayManager Instance;

		public TweenPosition Tween;

		public UILabel TitleLabel;

		public UILabel TextLabel;

		private bool _doHide;

		public void Awake()
		{
			Instance = this;
		}

		public void Show(string title, string subtext, float time = 1f)
		{
			RuntimeGlobals.TimeScale = 0.1f;
			TitleLabel.text = title;
			TextLabel.text = subtext;
			Tween.Play(true);
			StartCoroutine(Hide(time * RuntimeGlobals.TimeScale));
			_doHide = true;
		}

		public IEnumerator Hide(float time)
		{
			yield return new WaitForSeconds(time);
			if (_doHide)
			{
				RuntimeGlobals.TimeScale = 1f;
				Tween.Play(!_doHide);
			}
			_doHide = false;
		}
	}
}
