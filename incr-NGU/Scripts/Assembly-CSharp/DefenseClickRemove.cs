using UnityEngine;
using UnityEngine.EventSystems;

public class DefenseClickRemove : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public DefenseTraining training;

	public void OnPointerDown(PointerEventData eventData)
	{
		training.removeEnergy();
	}
}
