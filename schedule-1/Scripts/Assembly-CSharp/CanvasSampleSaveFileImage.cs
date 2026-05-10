using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSampleSaveFileImage : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public Text output;

	private byte[] _textureBytes;

	private void Awake()
	{
	}

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
