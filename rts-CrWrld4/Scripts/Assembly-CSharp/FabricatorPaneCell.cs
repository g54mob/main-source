using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FabricatorPaneCell : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public RawImage image;

	public GameObject nameCanvas;

	public Text nameText;

	public void SetWare(int num)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
