using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSampleSaveFileText : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public Text output;

	private string _data;

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	private void Start()
	{
	}

	public void OnClick()
	{
	}
}
