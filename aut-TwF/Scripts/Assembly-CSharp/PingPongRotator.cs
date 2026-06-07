using DG.Tweening;
using UnityEngine;

public class PingPongRotator : MonoBehaviour
{
	[SerializeField]
	private Vector3 angle;

	[SerializeField]
	private float duration = 1f;

	[SerializeField]
	private Space space;

	[SerializeField]
	private Ease ease = Ease.Linear;

	private void Start()
	{
		if (space == Space.World)
		{
			base.transform.DORotate(angle, duration, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
		}
		else
		{
			base.transform.DORotate(angle, duration, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
		}
	}
}
