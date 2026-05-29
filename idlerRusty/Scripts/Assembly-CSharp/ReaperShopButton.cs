using UnityEngine;
using UnityEngine.EventSystems;

public class ReaperShopButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField]
	private ReaperAI reaperAI;

	[SerializeField]
	private GameObject selectedObj;

	private void Start()
	{
		selectedObj.SetActive(value: false);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (reaperAI.canOpenShop)
		{
			selectedObj.SetActive(value: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		selectedObj.SetActive(value: false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left && reaperAI.canOpenShop)
		{
			reaperAI.OpenReaperUI();
		}
	}
}
