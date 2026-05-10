using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIFocusScroller : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	private ScrollRect m_ScrollRect;

	[SerializeField]
	private RectTransform m_ReferenceRect;

	[SerializeField]
	private float m_Padding;

	private void Awake()
	{
	}

	public void OnSelect(BaseEventData eventData)
	{
	}
}
