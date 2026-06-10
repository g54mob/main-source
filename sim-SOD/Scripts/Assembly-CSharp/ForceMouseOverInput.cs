using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForceMouseOverInput : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public int cursorType;

	public bool mouseOver;

	private TMP_InputField _inputField;

	private bool _isMultiline;

	private void Awake()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	private void OnEnable()
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
