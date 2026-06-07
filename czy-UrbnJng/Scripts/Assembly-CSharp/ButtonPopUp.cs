using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPopUp : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Transform animationTransform;

	private float scale;

	private void Start()
	{
		if (animationTransform == null)
		{
			scale = base.transform.localScale.x;
		}
		else
		{
			scale = animationTransform.localScale.x;
		}
		if (button != null)
		{
			button.onClick.AddListener(delegate
			{
				ButtonClick();
			});
		}
	}

	public void ButtonClick()
	{
		if (animationTransform == null)
		{
			if (button != null)
			{
				Animate(button.transform);
			}
		}
		else
		{
			Animate(animationTransform);
		}
	}

	private void Animate(Transform transformToAnimate)
	{
		transformToAnimate.DOScale(scale - 0.05f * scale, 0.05f).SetEase(Ease.InOutSine).OnComplete(delegate
		{
			transformToAnimate.DOScale(scale, 0.1f).SetEase(Ease.InOutSine);
		});
	}

	private void OnDestroy()
	{
		button.onClick.RemoveAllListeners();
	}
}
