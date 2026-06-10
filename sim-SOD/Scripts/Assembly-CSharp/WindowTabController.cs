using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowTabController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public RectTransform rect;

	public ButtonController tabButton;

	public WindowContentController content;

	public WindowTabPreset preset;

	public TextMeshProUGUI text;

	public int newItems;

	public PulsateController pulsateController;

	private void Awake()
	{
	}

	public void SetupButton()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void VisualUpdate()
	{
	}

	public void SetNewItems(int newItemCount)
	{
	}
}
