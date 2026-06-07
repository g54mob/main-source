using DG.Tweening;
using UnityEngine;

public class ApplyTween : MonoBehaviour
{
	private RectTransform rect;

	[SerializeField]
	private bool upAndDown;

	[SerializeField]
	private float height = 4f;

	[SerializeField]
	private float duration = 1f;

	private void Start()
	{
		rect = GetComponent<RectTransform>();
		rect.DOAnchorPosY(rect.anchoredPosition.y + height, duration, snapping: true).SetLoops(-1, LoopType.Yoyo);
	}
}
