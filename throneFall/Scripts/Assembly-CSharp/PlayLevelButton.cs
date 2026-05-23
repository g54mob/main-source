using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayLevelButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private bool mouseIsOver;

	private Color colorBasic;

	private Image image;

	[SerializeField]
	private Color hoverColor;

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
		if (Input.GetMouseButtonDown(0) && mouseIsOver)
		{
			LevelSelectManager.instance.PlayButtonPressed();
		}
	}
}
