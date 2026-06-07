using DG.Tweening;
using UnityEngine;

public class DirectionalMover : MonoBehaviour
{
	[SerializeField]
	private Vector3 direction = Vector3.zero;

	[SerializeField]
	private Space space;

	[SerializeField]
	private float length = 1f;

	[SerializeField]
	[Tooltip("The time it takes to move forward and backwards")]
	private float time = 1f;

	[SerializeField]
	private bool loop = true;

	[SerializeField]
	private Ease ease = Ease.Linear;

	[SerializeField]
	private bool lateUpdate;

	private Tween tween;

	private void Start()
	{
		if (space == Space.Self)
		{
			if (loop)
			{
				tween = base.transform.DOLocalMove(base.transform.localPosition + base.transform.localRotation * direction * length, time * 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(ease)
					.SetUpdate(lateUpdate ? UpdateType.Late : UpdateType.Normal);
			}
			else
			{
				tween = base.transform.DOLocalMove(base.transform.localPosition + base.transform.localRotation * direction * length, time * 0.5f).SetEase(ease).SetUpdate(lateUpdate ? UpdateType.Late : UpdateType.Normal);
			}
		}
		else if (loop)
		{
			tween = base.transform.DOMove(base.transform.position + direction.normalized * length, time * 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(ease)
				.SetUpdate(lateUpdate ? UpdateType.Late : UpdateType.Normal);
		}
		else
		{
			tween = base.transform.DOMove(base.transform.position + direction.normalized * length, time * 0.5f).SetEase(ease).SetUpdate(lateUpdate ? UpdateType.Late : UpdateType.Normal);
		}
	}

	private void OnDestroy()
	{
		if (tween != null)
		{
			tween.Kill();
		}
	}
}
