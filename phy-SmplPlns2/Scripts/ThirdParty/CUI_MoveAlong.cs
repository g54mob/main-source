using UnityEngine;

public class CUI_MoveAlong : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		(base.transform as RectTransform).anchoredPosition = new Vector2((base.transform as RectTransform).anchoredPosition.x + (base.transform as RectTransform).anchoredPosition.x / 100f, (base.transform as RectTransform).anchoredPosition.y);
		if ((base.transform as RectTransform).anchoredPosition.x > (base.transform.parent as RectTransform).rect.width)
		{
			(base.transform as RectTransform).anchoredPosition = new Vector2(20f, (base.transform as RectTransform).anchoredPosition.y);
		}
	}
}
