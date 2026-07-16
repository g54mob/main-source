using UnityEngine;

public class FillPointer : MonoBehaviour
{
	private RectTransform rt;

	private Vector2 startPos;

	private Vector2 endPos;

	private void Awake()
	{
		rt = GetComponent<RectTransform>();
		startPos = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y);
		endPos = new Vector2(startPos.x * -1f, startPos.y);
	}

	public void SetValue(float value01)
	{
		rt.anchoredPosition = Vector2.Lerp(startPos, endPos, value01);
	}
}
