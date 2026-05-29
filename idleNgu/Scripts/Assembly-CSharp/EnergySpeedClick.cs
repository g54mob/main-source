using UnityEngine;
using UnityEngine.EventSystems;

public class EnergySpeedClick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public EnergyPurchases purchase;

	public void OnPointerDown(PointerEventData eventData)
	{
		purchase.energySpeed10();
	}
}
