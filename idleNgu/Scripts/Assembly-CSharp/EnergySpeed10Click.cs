using UnityEngine;
using UnityEngine.EventSystems;

public class EnergySpeed10Click : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public EnergyPurchases purchase;

	public void OnPointerDown(PointerEventData eventData)
	{
		purchase.energySpeed100();
	}
}
