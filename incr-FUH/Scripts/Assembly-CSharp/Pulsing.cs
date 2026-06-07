using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pulsing : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool StopOnHover;

	public bool PulseMore;

	public bool PulseOnStart = true;

	private Tween _animation;

	private bool _alwaysStop;

	private void Start()
	{
		if (PulseOnStart)
		{
			StartAnimation();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		StopAnimation();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (PulseOnStart)
		{
			StartAnimation();
		}
	}

	public void OnDeselect(PointerEventData eventData)
	{
		if (PulseOnStart)
		{
			StartAnimation();
		}
	}

	public void StartAnimation()
	{
		if (!_alwaysStop && _animation == null)
		{
			if (PulseMore)
			{
				_animation = base.transform.DOScale(new Vector3(1.3f, 1.3f, 1f), 1f).SetLoops(-1, LoopType.Yoyo);
			}
			else
			{
				_animation = base.transform.DOScale(new Vector3(1.1f, 1.1f, 1f), 1f).SetLoops(-1, LoopType.Yoyo);
			}
		}
	}

	public void AlwaysStop()
	{
		StopAnimation();
		_alwaysStop = true;
	}

	private void StopAnimation()
	{
		if (StopOnHover && _animation != null)
		{
			_animation.Kill();
			_animation = null;
			base.transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}
}
