using UnityEngine;
using UnityEngine.EventSystems;

public class OffenseClickRemove : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public OffenseTraining training;

	public void OnPointerDown(PointerEventData eventData)
	{
		training.removeEnergy();
	}
}
