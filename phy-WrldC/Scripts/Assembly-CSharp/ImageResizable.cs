using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageResizable : MonoBehaviour
{
	[SerializeField]
	private bool isInUse;

	[Range(0.05f, 2f)]
	[SerializeField]
	private float relativeSize = 1f;

	private RectTransform rectTransform;

	private Image image;

	private LayoutElement layoutElement;

	private bool isAlreadyInitialized;

	private void Awake()
	{
		Initialize();
		if (isInUse)
		{
			RefreshSize();
		}
	}

	private void OnValidate()
	{
		if (!isAlreadyInitialized)
		{
			Initialize();
		}
		if (isInUse)
		{
			RefreshSize();
		}
	}

	private void Initialize()
	{
		rectTransform = base.transform as RectTransform;
		image = GetComponent<Image>();
		layoutElement = GetComponent<LayoutElement>();
		isAlreadyInitialized = true;
	}

	private void RefreshSize()
	{
		if (!(image == null) && !(image.sprite == null))
		{
			float width = image.sprite.rect.width;
			float height = image.sprite.rect.height;
			if (layoutElement == null || !layoutElement.enabled)
			{
				rectTransform.sizeDelta = new Vector2(width * relativeSize, height * relativeSize);
				return;
			}
			layoutElement.minWidth = width * relativeSize;
			layoutElement.minHeight = height * relativeSize;
		}
	}
}
