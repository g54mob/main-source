using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollContentMouse : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	private RectTransform TransRef;

	private ScrollRect ScrollRef;

	private RectTransform ContentRef;

	[SerializeField]
	private float ScrollSpeed = 100f;

	private float MinScroll;

	private float MaxScroll;

	private void Start()
	{
		TransRef = GetComponent<RectTransform>();
		ScrollRef = GetComponent<ScrollRect>();
		ContentRef = ScrollRef.content;
		MaxScroll = ContentRef.rect.height - TransRef.rect.height;
	}

	public void OnScroll(PointerEventData eventData)
	{
		Debug.Log("scroll");
		Vector2 scrollDelta = eventData.scrollDelta;
		ContentRef.anchoredPosition += new Vector2(0f, (0f - scrollDelta.y) * ScrollSpeed);
		if (ContentRef.anchoredPosition.y < MinScroll)
		{
			ContentRef.anchoredPosition = new Vector2(0f, MinScroll);
		}
		else if (ContentRef.anchoredPosition.y > MaxScroll)
		{
			ContentRef.anchoredPosition = new Vector2(0f, MaxScroll);
		}
	}
}
