using DG.Tweening;
using UnityEngine;

namespace Minigames
{
	public class AppearSystem : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _progressFastener;

		[SerializeField]
		private RectTransform _fastener;

		[Header("Animation Settings")]
		[SerializeField]
		private float _progressFastenerDuration = 1.2f;

		[SerializeField]
		private float _progressFastenerOffsetY = 500f;

		[SerializeField]
		private float _progressFastenerRotation = 360f;

		[SerializeField]
		private Ease _progressFastenerEase = Ease.OutBack;

		[SerializeField]
		private float _fastenerDuration = 0.6f;

		[SerializeField]
		private float _fastenerDelay = 0.4f;

		[SerializeField]
		private float _fastenerRotation = 720f;

		[SerializeField]
		private Ease _fastenerEase = Ease.OutElastic;

		private Vector2 _progressFastenerTargetPosition;

		private Vector3 _fastenerTargetRotation;

		public void PlayAppearAnimation()
		{
			_progressFastenerTargetPosition = _progressFastener.anchoredPosition;
			_fastenerTargetRotation = _fastener.localEulerAngles;
			Sequence sequence = DOTween.Sequence();
			Vector2 anchoredPosition = _progressFastenerTargetPosition + Vector2.up * _progressFastenerOffsetY;
			_progressFastener.anchoredPosition = anchoredPosition;
			sequence.Append(_progressFastener.DOAnchorPos(_progressFastenerTargetPosition, _progressFastenerDuration).SetEase(_progressFastenerEase));
			sequence.Join(_progressFastener.DORotate(new Vector3(0f, 0f, _progressFastenerRotation), _progressFastenerDuration, RotateMode.LocalAxisAdd).SetEase(Ease.OutCubic));
			_fastener.localScale = Vector3.zero;
			sequence.Insert(_fastenerDelay, _fastener.DOScale(1f, _fastenerDuration).SetEase(_fastenerEase));
			sequence.Insert(_fastenerDelay, _fastener.DOLocalRotate(_fastenerTargetRotation + new Vector3(0f, 0f, _fastenerRotation), _fastenerDuration, RotateMode.FastBeyond360).SetEase(_fastenerEase));
			sequence.OnComplete(delegate
			{
				_fastener.localEulerAngles = _fastenerTargetRotation;
			});
		}

		private void OnDestroy()
		{
			DOTween.Kill(_progressFastener);
			DOTween.Kill(_fastener);
		}
	}
}
