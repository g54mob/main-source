using UnityEngine;

public class RectEvent : MonoBehaviour
{
	private RectTransform rect;

	private void Start()
	{
		rect = GetComponent<RectTransform>();
	}

	public void MoveY(float units)
	{
		rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + units);
	}

	public void MoveX(float units)
	{
		rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + units, rect.anchoredPosition.y);
	}
}
