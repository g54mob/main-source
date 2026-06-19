using UnityEngine;
using UnityEngine.UI;

public class CursorGraphic : MonoBehaviour
{
	public enum CursorGraphicPositions
	{
		Center = 0,
		Pointer = 1
	}

	[SerializeField]
	private Image _image;

	[field: SerializeField]
	public RectTransform RectTransform { get; private set; }

	public void SetPositionStyle(CursorGraphicPositions position)
	{
	}

	public void SetImage(Sprite sprite)
	{
	}

	public void Disable()
	{
	}

	public void Enable()
	{
	}
}
