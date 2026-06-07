using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LvlSelectTabButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public int tabNumber;

	private bool mouseIsOver;

	private Color colorBasic;

	private Image image;

	[SerializeField]
	private Color hoverColor;

	[SerializeField]
	private Color selectedColor;

	public bool selected;

	private void Start()
	{
		image = GetComponent<Image>();
		colorBasic = image.color;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		mouseIsOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		mouseIsOver = false;
	}

	private void Update()
	{
		image.color = (mouseIsOver ? hoverColor : colorBasic);
		if (selected)
		{
			image.color = selectedColor;
		}
		if (Input.GetMouseButtonDown(0))
		{
			_ = mouseIsOver;
		}
	}
}
