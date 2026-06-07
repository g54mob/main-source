using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TerrainTexturePicker : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
{
	public delegate void TextureSelectedCallback(short val);

	private const float delta = 25f;

	private TextureSelectedCallback callback;

	public RectTransform selection0;

	public RectTransform selection1;

	public RawImage preview;

	public Text previewText;

	private short _currentTexture;

	public short currentTexture
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void Show(TextureSelectedCallback callback)
	{
	}

	private void Update()
	{
	}

	public void OnPointerDown(PointerEventData ped)
	{
	}

	public void OnPointerUp(PointerEventData ped)
	{
	}

	public void OnPointerClick(PointerEventData ped)
	{
	}

	public void SetCurrentTexture(short val)
	{
	}

	private Vector2 GetTexturePosFromMouse(Vector2 mousePos)
	{
		return default(Vector2);
	}

	private short GetTexureNumber(Vector2 mousePos)
	{
		return 0;
	}

	private Vector2 GetPosFromTexture(int t)
	{
		return default(Vector2);
	}
}
