using DG.Tweening;
using UnityEngine;

public class HoverExpand : MonoBehaviour
{
	private Vector3 _originalScale;

	private Tween _expandTween;

	private bool _isPause;

	private void Start()
	{
		_originalScale = base.transform.localScale;
	}

	public void Pause()
	{
		_isPause = true;
	}

	public void UnPause()
	{
		_isPause = false;
	}

	public void OnMouseEnter()
	{
		_expandTween?.Kill();
		if (!_isPause)
		{
			_expandTween = base.transform.DOScale(_originalScale * 1.2f, 0.2f).SetEase(Ease.OutBack);
		}
	}

	public void OnMouseExit()
	{
		_expandTween?.Kill();
		if (!_isPause)
		{
			_expandTween = base.transform.DOScale(_originalScale, 0.2f).SetEase(Ease.InBack);
		}
	}
}
