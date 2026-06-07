using UnityEngine;
using UnityEngine.EventSystems;

public class HoverShowPanel : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject PanelToShow;

	private void Start()
	{
		PanelToShow.SetActive(value: false);
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
		PanelToShow.SetActive(value: false);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		PanelToShow.SetActive(value: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		PanelToShow.SetActive(value: false);
	}
}
