using UnityEngine;
using UnityEngine.EventSystems;

public class TransferUIClickToGameObject : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[Header("將點擊此物件的訊號轉給指定的物件 (例如按鈕)")]
	[SerializeField]
	private GameObject target;

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
