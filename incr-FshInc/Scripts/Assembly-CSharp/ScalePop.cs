using DG.Tweening;
using UnityEngine;

public class ScalePop : MonoBehaviour
{
	[Header("Pop Settings")]
	[Tooltip("Scale it overshoots to before settling.")]
	public float overshootScale = 1.3f;

	[Tooltip("Final resting scale.")]
	public float targetScale = 1f;

	[Tooltip("Time to reach overshoot.")]
	public float popInDuration = 0.15f;

	[Tooltip("Time to settle from overshoot to target.")]
	public float settleDuration = 0.2f;

	[Tooltip("Easing for the pop in.")]
	public Ease popEase = Ease.OutQuad;

	[Tooltip("Easing for the settle.")]
	public Ease settleEase = Ease.OutBounce;

	[Header("Options")]
	[Tooltip("Start hidden (scale 0) on enable.")]
	public bool startHidden = true;

	private Vector3 _originalScale;

	private Sequence _popSequence;

	private Animator _animator;

	private void Awake()
	{
		_originalScale = base.transform.localScale;
		_animator = GetComponent<Animator>();
	}

	private void Start()
	{
		if (startHidden)
		{
			base.transform.localScale = Vector3.zero;
		}
	}

	public void Pop()
	{
		Debug.Log($"[ScalePop] Pop() called on {base.gameObject.name}, originalScale={_originalScale}");
		if (_animator != null)
		{
			_animator.enabled = false;
		}
		_popSequence?.Kill();
		base.transform.localScale = Vector3.zero;
		_popSequence = DOTween.Sequence();
		_popSequence.Append(base.transform.DOScale(_originalScale * overshootScale, popInDuration).SetEase(popEase));
		_popSequence.Append(base.transform.DOScale(_originalScale * targetScale, settleDuration).SetEase(settleEase));
	}

	public void PopOut()
	{
		if (_animator != null)
		{
			_animator.enabled = false;
		}
		_popSequence?.Kill();
		_popSequence = DOTween.Sequence();
		_popSequence.Append(base.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack));
	}

	private void OnDisable()
	{
		_popSequence?.Kill();
		base.transform.localScale = _originalScale;
	}
}
