using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Obj_UI_MapSceneTowerCard : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private UI_CardFace cardFace;

	[SerializeField]
	private GameObject node_Locked;

	private AItemSettingData currentData;

	private Tweener cardMouseOverTweener;

	private int index;

	public void SetIsLocked(bool isLocked)
	{
	}

	public void SetContent(eItemType itemType, int index)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public bool IsHaveCardData()
	{
		return false;
	}
}
