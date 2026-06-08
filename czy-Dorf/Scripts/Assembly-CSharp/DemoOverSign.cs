using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DemoOverSign : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private Transform signTransform;

	private MenuNavigator menuNavigator;

	private Tween scaleTween;

	private void Awake()
	{
		signTransform = base.transform.parent;
		menuNavigator = Object.FindObjectOfType<MenuNavigator>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Tween tween = scaleTween;
		if (tween != null)
		{
			TweenExtensions.Kill(tween, complete: true);
		}
		scaleTween = ShortcutExtensions.DOPunchScale(signTransform, Vector3.one * 0.2f, 0.5f, 7);
	}
}
