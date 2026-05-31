using UnityEngine;
using UnityEngine.EventSystems;

public class SaveFileExplainerTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private TitleScreen titleScreenScript;

	[Space]
	[SerializeField]
	private string key;

	public void OnPointerEnter(PointerEventData eventData)
	{
		titleScreenScript.ShowExplainerBox(key);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		titleScreenScript.HideExplainerBox();
	}
}
