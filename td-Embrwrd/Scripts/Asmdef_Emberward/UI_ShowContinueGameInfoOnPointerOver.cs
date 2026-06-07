using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ShowContinueGameInfoOnPointerOver : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Vector3 offset;

	[SerializeField]
	private Button button;

	private bool isTooltipOn;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private string GetContinueInfo()
	{
		return null;
	}
}
