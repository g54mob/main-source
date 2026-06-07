using UnityEngine;
using UnityEngine.EventSystems;

public class Func_TooltipOnPointerEnter : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private string localization_Name_Table;

	[SerializeField]
	private string localization_Name_Key;

	[SerializeField]
	private string localization_Description_Table;

	[SerializeField]
	private string localization_Description_Key;

	[SerializeField]
	private Vector3 offset;

	[SerializeField]
	private bool isBattleModeOnly;

	private bool isTooltipOn;

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
