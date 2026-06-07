using UnityEngine;
using UnityEngine.EventSystems;

public class UnlockTooltipDisplay : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public FruitController fruit;

	public void Start()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		fruit.unlockInfo();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		fruit.hideUnlockInfo();
	}
}
