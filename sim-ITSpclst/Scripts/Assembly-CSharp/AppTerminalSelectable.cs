using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AppTerminalSelectable : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public DetectionInputField detectionInputField;

	public bool Select;

	public bool mouseInArea;

	private Image image;

	private void Awake()
	{
	}

	public void Update()
	{
	}

	public void SelectImage()
	{
	}

	public void Deselect()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
