using DG.Tweening;
using UnityEngine;

public class ArrowBump : MonoBehaviour
{
	[SerializeField]
	private RectTransform targetRectTransform;

	[SerializeField]
	private float bounceDistance = 30f;

	[SerializeField]
	private float bounceDuration = 0.5f;

	private Sequence _bounceSequence;

	private void Start()
	{
		if (targetRectTransform == null)
		{
			targetRectTransform = GetComponent<RectTransform>();
		}
		StartBounce();
	}

	private void OnDisable()
	{
		_bounceSequence?.Kill();
	}

	private void StartBounce()
	{
		if (!(targetRectTransform == null))
		{
			Vector3 vector = targetRectTransform.anchoredPosition;
			_bounceSequence = DOTween.Sequence();
			float endValue = vector.y + bounceDistance;
			float y = vector.y;
			_bounceSequence.Append(targetRectTransform.DOAnchorPosY(endValue, bounceDuration).SetEase(Ease.OutQuad));
			_bounceSequence.Append(targetRectTransform.DOAnchorPosY(y, bounceDuration).SetEase(Ease.InQuad));
			_bounceSequence.SetLoops(-1, LoopType.Restart);
		}
	}
}
