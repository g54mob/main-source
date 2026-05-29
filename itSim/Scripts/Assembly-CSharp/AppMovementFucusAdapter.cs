using UnityEngine;
using UnityEngine.EventSystems;

public class AppMovementFucusAdapter : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public AppMovement appMovement;

	public AppMovementFucusAdapter(AppMovement appMovement)
	{
	}

	public void Initialized(AppMovement appMovement)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
