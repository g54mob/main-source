using UnityEngine;
using UnityEngine.EventSystems;

public class OffenseClickAdd : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public OffenseTraining training;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.pointerId == -1)
		{
			training.addEnergy();
		}
		else if (eventData.pointerId == -2)
		{
			training.addSum();
		}
	}
}
