using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PointerHoverComponent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private UnityEvent OnStart = new UnityEvent();

	[SerializeField]
	private UnityEvent OnPointerEnter = new UnityEvent();

	[SerializeField]
	private UnityEvent OnPointerExit = new UnityEvent();

	private void Start()
	{
		OnStart.Invoke();
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		OnPointerEnter.Invoke();
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		OnPointerExit.Invoke();
	}
}
