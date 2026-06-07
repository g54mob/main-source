using DG.Tweening;
using UnityEngine;

public class DirectionalMoverUI : MonoBehaviour
{
	[SerializeField]
	private Vector2 direction = Vector2.zero;

	[SerializeField]
	private float length = 1f;

	[SerializeField]
	[Tooltip("The time it takes to move forward and backwards")]
	private float time = 1f;

	[SerializeField]
	private Ease ease = Ease.Linear;

	private void Start()
	{
		direction.Normalize();
		RectTransform component = GetComponent<RectTransform>();
		component.DOAnchorPos(component.anchoredPosition + direction * length, time * 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
	}
}
