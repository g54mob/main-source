using UnityEngine;

public class CUI_MoveHeartbeat : MonoBehaviour
{
	public float speed;

	public bool wrapAroundParent = true;

	private RectTransform rectie;

	private RectTransform parentRectie;

	private void Start()
	{
		rectie = base.transform as RectTransform;
		parentRectie = base.transform.parent as RectTransform;
	}

	private void Update()
	{
		rectie.anchoredPosition = new Vector2(rectie.anchoredPosition.x - speed * Time.deltaTime, rectie.anchoredPosition.y);
		if (wrapAroundParent && rectie.anchoredPosition.x + rectie.rect.width < 0f)
		{
			rectie.anchoredPosition = new Vector2(parentRectie.rect.width, rectie.anchoredPosition.y);
		}
	}
}
