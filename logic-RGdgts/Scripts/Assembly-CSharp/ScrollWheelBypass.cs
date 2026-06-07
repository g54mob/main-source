using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollWheelBypass : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	private ScrollRect _scrollRect;

	private void Start()
	{
	}

	public void OnScroll(PointerEventData data)
	{
	}
}
