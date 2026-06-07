using CurvedUI;
using UnityEngine;

public class CUI_touchpad : MonoBehaviour
{
	private RectTransform container;

	[SerializeField]
	private RectTransform dot;

	private void Awake()
	{
		container = base.transform as RectTransform;
	}

	private void MoveDotOnTouchpadAxisChanged(object o, ViveInputArgs args)
	{
		dot.anchoredPosition = new Vector2(args.touchpadAxis.x * container.rect.width * 0.5f, args.touchpadAxis.y * container.rect.width * 0.5f);
	}
}
