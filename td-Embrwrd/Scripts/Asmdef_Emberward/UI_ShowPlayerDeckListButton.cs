using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ShowPlayerDeckListButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField]
	private UI_PlayerDeck ui_PlayerDeck;

	private bool isBackpackVisible;

	private void Update()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
