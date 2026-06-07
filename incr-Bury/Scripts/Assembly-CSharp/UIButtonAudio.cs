using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonAudio : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerClickHandler, ISelectHandler, ISubmitHandler
{
	public void OnPointerEnter(PointerEventData eventData)
	{
		AudioManager.Singleton.PlayUiSFX_ButtonOver();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		AudioManager.Singleton.PlayUiSFX_Click();
	}

	public void OnSelect(BaseEventData eventData)
	{
		AudioManager.Singleton.PlayUiSFX_ButtonOver();
	}

	public void OnSubmit(BaseEventData eventData)
	{
		AudioManager.Singleton.PlayUiSFX_Click();
	}
}
