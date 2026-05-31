using UnityEngine;
using UnityEngine.EventSystems;

public class Bar1Click : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public EnergyPurchases purchase;

	public void OnPointerDown(PointerEventData eventData)
	{
		purchase.energyBar1();
	}
}
