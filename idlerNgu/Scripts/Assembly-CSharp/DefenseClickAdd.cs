using UnityEngine;
using UnityEngine.EventSystems;

public class DefenseClickAdd : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public DefenseTraining training;

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
