using UnityEngine;
using UnityEngine.EventSystems;

public class MiniGameMapUIAdapter : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Transform Player;

	[Header("Components")]
	public MiniGameMapUIController miniGameMapUIController;

	[Header("Data")]
	public Vector2Int position;

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
