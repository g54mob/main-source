using DG.Tweening;
using I18n;
using UnityEngine;

namespace Gh
{
	public class ErrorNotifierUIView : SingletonMonoBehaviour<ErrorNotifierUIView>
	{
		[SerializeField]
		private TextMeshProUGUII18n _messageText;

		private float _fadeTime;

		private float _holdTime;

		private float _holdTimeRemaining;

		private Tween _fadeInTween;

		private Tween _fadeOutTween;

		public override void Awake()
		{
		}

		private Tween CreateAlphaTween(float endValue)
		{
			return null;
		}

		public void Notify(string message)
		{
		}

		public void Clear()
		{
		}

		private void Update()
		{
		}
	}
}
