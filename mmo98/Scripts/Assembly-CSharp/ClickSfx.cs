using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSfx : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private AudioDataType type;

	public void OnPointerClick(PointerEventData eventData)
	{
		Audio.PlaySfx(type);
	}
}
