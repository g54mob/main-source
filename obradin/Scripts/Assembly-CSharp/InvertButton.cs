using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InvertButton : MonoBehaviour
{
	public Color normalTextColor = Color.cyan;

	public Color inverseTextColor = Color.black;

	public Sprite invertedSprite0;

	public Sprite invertedSprite1;

	public Sprite invertedSprite2;

	public Sprite invertedSprite3;

	public bool applyToImagesColor = true;

	private bool inverted;

	private Button button;

	private Image buttonImage;

	private Text[] subTexts;

	private List<Image> subImages = new List<Image>();

	private SpriteState maskedSpriteState;

	private SpriteState originalSpriteState;

	private void Start()
	{
		button = GetComponent<Button>();
		buttonImage = button.targetGraphic as Image;
		originalSpriteState = default(SpriteState);
		originalSpriteState.disabledSprite = button.spriteState.disabledSprite;
		originalSpriteState.highlightedSprite = button.spriteState.highlightedSprite;
		originalSpriteState.pressedSprite = button.spriteState.pressedSprite;
		maskedSpriteState = default(SpriteState);
		maskedSpriteState.disabledSprite = button.spriteState.disabledSprite;
		maskedSpriteState.highlightedSprite = button.spriteState.disabledSprite;
		maskedSpriteState.pressedSprite = button.spriteState.disabledSprite;
		subTexts = GetComponentsInChildren<Text>(true);
		Image[] componentsInChildren = GetComponentsInChildren<Image>(true);
		foreach (Image image in componentsInChildren)
		{
			if (image.gameObject != base.gameObject)
			{
				subImages.Add(image);
			}
		}
		Text[] array = subTexts;
		foreach (Text text in array)
		{
			text.color = new Color(normalTextColor.r, normalTextColor.g, normalTextColor.b, text.color.a);
		}
	}

	private void OnEnable()
	{
		Reset();
	}

	public void Reset()
	{
		if (subTexts != null)
		{
			Color color = normalTextColor;
			Text[] array = subTexts;
			foreach (Text text in array)
			{
				text.color = new Color(color.r, color.g, color.b, text.color.a);
			}
			if (applyToImagesColor)
			{
				foreach (Image subImage in subImages)
				{
					subImage.color = new Color(color.r, color.g, color.b, subImage.color.a);
				}
			}
		}
		if (button != null)
		{
			buttonImage.overrideSprite = null;
			buttonImage.sprite = maskedSpriteState.disabledSprite;
			button.spriteState = maskedSpriteState;
		}
		inverted = false;
	}

	private void Update()
	{
		bool flag = inverted;
		inverted = (invertedSprite0 != null && buttonImage.overrideSprite == invertedSprite0) || (invertedSprite1 != null && buttonImage.overrideSprite == invertedSprite1) || (invertedSprite2 != null && buttonImage.overrideSprite == invertedSprite2) || (invertedSprite3 != null && buttonImage.overrideSprite == invertedSprite3);
		if (button.spriteState.pressedSprite != originalSpriteState.pressedSprite)
		{
			button.spriteState = originalSpriteState;
		}
		if (flag == inverted)
		{
			return;
		}
		Color color = ((!inverted) ? normalTextColor : inverseTextColor);
		Text[] array = subTexts;
		foreach (Text text in array)
		{
			text.color = new Color(color.r, color.g, color.b, text.color.a);
		}
		if (!applyToImagesColor)
		{
			return;
		}
		foreach (Image subImage in subImages)
		{
			subImage.color = new Color(color.r, color.g, color.b, subImage.color.a);
		}
	}
}
