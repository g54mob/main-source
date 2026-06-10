using DG.Tweening;
using UnityEngine;

public class AmbientCritter : MonoBehaviour
{
	[Header("Movement")]
	public float moveDistance = 2f;

	public float moveSpeed = 1f;

	[Header("Timing")]
	public float minIdleTime = 1f;

	public float maxIdleTime = 3f;

	public float startDelay;

	[Header("References")]
	public Animator animator;

	public SpriteRenderer spriteRenderer;

	private Vector3 _startPosition;

	private Tween _moveTween;

	private void Start()
	{
		_startPosition = base.transform.position;
		if (animator == null)
		{
			animator = GetComponent<Animator>();
		}
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		Invoke("IdleThenMove", startDelay + Random.Range(minIdleTime, maxIdleTime));
	}

	private void IdleThenMove()
	{
		if (animator != null)
		{
			animator.SetBool("isMoving", value: true);
		}
		float num = ((Random.value > 0.5f) ? 1f : (-1f));
		float num2 = Random.Range(moveDistance * 0.5f, moveDistance);
		Vector3 endValue = base.transform.position + Vector3.right * num * num2;
		if (spriteRenderer != null)
		{
			spriteRenderer.flipX = num < 0f;
		}
		float duration = num2 / moveSpeed;
		_moveTween = base.transform.DOMove(endValue, duration).SetEase(Ease.Linear).OnComplete(delegate
		{
			if (animator != null)
			{
				animator.SetBool("isMoving", value: false);
			}
			float time = Random.Range(minIdleTime, maxIdleTime);
			Invoke("IdleThenMove", time);
		});
	}

	private void OnDisable()
	{
		_moveTween?.Kill();
		CancelInvoke();
	}
}
