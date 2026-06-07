using UnityEngine;
using UnityEngine.EventSystems;

public class Bar10Click : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public EnergyPurchases purchase;

	public void OnPointerDown(PointerEventData eventData)
	{
		purchase.energyBar10();
	}
}
