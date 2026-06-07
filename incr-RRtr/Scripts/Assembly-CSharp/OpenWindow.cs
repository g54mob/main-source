using UnityEngine;
using UnityEngine.EventSystems;

public class OpenWindow : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField]
	private GameObject window;

	[Header("Hover over")]
	[SerializeField]
	private Sprite normalSp;

	[SerializeField]
	private Sprite hoverOver;

	[SerializeField]
	private SpriteRenderer sr;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (window.activeSelf)
		{
			window.SetActive(value: false);
		}
		else
		{
			window.SetActive(value: true);
		}
		window.transform.SetAsLastSibling();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!(normalSp == null) && !(hoverOver == null) && !(sr == null))
		{
			sr.sprite = hoverOver;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!(normalSp == null) && !(hoverOver == null) && !(sr == null))
		{
			sr.sprite = normalSp;
		}
	}
}
