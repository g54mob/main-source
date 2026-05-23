using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipOnUIText : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public int tooltipLocalisationUID;

	[SerializeField]
	private int differentXOffset;

	[SerializeField]
	private bool isInPauseMenu;

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnSelect()
	{
	}

	public void OnDeselect()
	{
	}

	private void ToolTip()
	{
	}
}
