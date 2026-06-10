using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowRenameTitleController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public InfoWindow window;

	public TMP_InputField inputField;

	private float lastLeftClick;

	private float lastRightClick;

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}

	private void OnDestroy()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public virtual void OnLeftClick()
	{
	}

	public virtual void OnRightClick()
	{
	}

	public virtual void OnLeftDoubleClick()
	{
	}

	public virtual void OnRightDoubleClick()
	{
	}
}
