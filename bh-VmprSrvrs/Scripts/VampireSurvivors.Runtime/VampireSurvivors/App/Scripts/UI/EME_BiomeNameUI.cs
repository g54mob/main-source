using TMPro;
using UnityEngine;

namespace VampireSurvivors.App.Scripts.UI
{
	public class EME_BiomeNameUI : MonoBehaviour
	{
		private enum ShowState
		{
			Hidden = 0,
			FadeIn = 1,
			Showing = 2,
			FadeOut = 3
		}

		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private TMP_Text _biomeNameText;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private float _fadeInDuration;

		[SerializeField]
		private AnimationCurve _fadeInCurve;

		[SerializeField]
		private float _showDuration;

		[SerializeField]
		private float _fadeOutDuration;

		[SerializeField]
		private AnimationCurve _fadeOutCurve;

		private ShowState _currentState;

		private float _stateTimer;

		public RectTransform GetRectTransform => null;

		public void Show(string biomeName)
		{
		}

		public void HideImmediate()
		{
		}

		private void SetState(ShowState newState)
		{
		}

		public void UpdateNameUi(float deltaTime)
		{
		}
	}
}
