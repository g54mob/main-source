using DG.Tweening;
using UnityEngine;

namespace CTS
{
	public class UIPermanentRotation : MonoBehaviour
	{
		private RectTransform _rectTransform;

		[SerializeField]
		[Range(0.1f, 10f)]
		private float _duration;

		[SerializeField]
		private Ease _ease;

		[SerializeField]
		private bool _useUnscaledTime = true;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
		}

		private void Start()
		{
			_rectTransform.DORotate(new Vector3(0f, 0f, 360f), _duration, RotateMode.FastBeyond360).SetUpdate(_useUnscaledTime).SetEase(_ease)
				.SetLoops(-1, LoopType.Incremental);
		}

		private void OnValidate()
		{
			if (Application.isPlaying && (bool)_rectTransform)
			{
				_rectTransform.DOKill();
				_rectTransform.rotation = Quaternion.identity;
				_rectTransform.DORotate(new Vector3(0f, 0f, 360f), _duration, RotateMode.FastBeyond360).SetUpdate(_useUnscaledTime).SetEase(_ease)
					.SetLoops(-1, LoopType.Incremental);
			}
		}
	}
}
