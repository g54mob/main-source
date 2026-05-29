using UnityEngine;
using UnityEngine.EventSystems;

public class OffenseClickCap : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public OffenseTraining training;

	public void OnPointerDown(PointerEventData eventData)
	{
		training.cap();
	}
}
