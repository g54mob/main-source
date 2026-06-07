using System.Collections.Generic;
using Aux;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectHighlighter : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	private Color highlightedColor = new Color(0.5882353f, 0.5882353f, 0.5882353f);

	private Color pressedColor = new Color(20f / 51f, 20f / 51f, 20f / 51f);

	private bool listenerAlive;

	public string tagToSearch = "Selectable";

	public string highlightedColorId;

	public string pressedColorId;

	public GameObject rootColoredObj;

	private RectTransform curRect;

	private bool inited;

	private List<Image> selectedImages = new List<Image>();

	private List<Text> selectedTexts = new List<Text>();

	private float _r;

	private float _g;

	private float _b;

	private float _a;

	private uint depth;

	public bool disableCheckOut;

	private void Init()
	{
		if (rootColoredObj == null)
		{
			rootColoredObj = base.gameObject;
		}
		curRect = base.gameObject.GetComponent<RectTransform>();
		if (Logic.staticDataLoaded)
		{
			highlightedColor = Logic.GetColorIfExists(highlightedColorId) ?? highlightedColor;
			pressedColor = Logic.GetColorIfExists(pressedColorId) ?? pressedColor;
			return;
		}
		depth = 0u;
		Logic.staticDataLoadedEvent.AddListener(InitColorsAfterStaticDataLoaded);
		listenerAlive = false;
		inited = true;
	}

	private void Start()
	{
		if (!inited)
		{
			Init();
		}
	}

	public void Clear()
	{
		depth = 0u;
		selectedImages.Clear();
		selectedTexts.Clear();
	}

	private void InitColorsAfterStaticDataLoaded()
	{
		highlightedColor = Logic.GetColorIfExists(highlightedColorId) ?? highlightedColor;
		pressedColor = Logic.GetColorIfExists(pressedColorId) ?? pressedColor;
		Logic.staticDataLoadedEvent.RemoveListener(InitColorsAfterStaticDataLoaded);
		listenerAlive = false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!inited)
		{
			Init();
		}
		if (depth == 0)
		{
			depth++;
			Image[] componentsInChildren = rootColoredObj.GetComponentsInChildren<Image>();
			foreach (Image image in componentsInChildren)
			{
				if (image.gameObject.tag == tagToSearch)
				{
					SetHighlightedColor(image);
					selectedImages.Add(image);
				}
			}
			Text[] componentsInChildren2 = rootColoredObj.GetComponentsInChildren<Text>();
			foreach (Text text in componentsInChildren2)
			{
				if (text.gameObject.tag == tagToSearch)
				{
					SetHighlightedColor(text);
					selectedTexts.Add(text);
				}
			}
		}
		else if (depth == 1)
		{
			selectedImages.ForEach(UnsetHighlightedColor);
			selectedTexts.ForEach(UnsetHighlightedColor);
			depth++;
			selectedImages.ForEach(SetHighlightedColor);
			selectedTexts.ForEach(SetHighlightedColor);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!inited)
		{
			Init();
		}
		if (depth == 0)
		{
			return;
		}
		List<Image> list = new List<Image>();
		foreach (Image selectedImage in selectedImages)
		{
			if (!list.Contains(selectedImage))
			{
				list.Add(selectedImage);
			}
		}
		list.ForEach(UnsetHighlightedColor);
		List<Text> list2 = new List<Text>();
		foreach (Text selectedText in selectedTexts)
		{
			if (!list2.Contains(selectedText))
			{
				list2.Add(selectedText);
			}
		}
		list2.ForEach(UnsetHighlightedColor);
		depth--;
		if (depth == 0)
		{
			selectedImages.Clear();
			selectedTexts.Clear();
		}
		else
		{
			selectedImages.ForEach(SetHighlightedColor);
		}
		selectedTexts.ForEach(SetHighlightedColor);
	}

	private void PickColor(Image image)
	{
		_r = image.color.r;
		_g = image.color.g;
		_b = image.color.b;
		_a = image.color.a;
	}

	private void PickColor(Text text)
	{
		_r = text.color.r;
		_g = text.color.g;
		_b = text.color.b;
		_a = text.color.a;
	}

	private Color? ChooseHighlightColor()
	{
		return depth switch
		{
			1u => highlightedColor, 
			2u => pressedColor, 
			_ => null, 
		};
	}

	private void SetHighlightedColor(Image image)
	{
		Color? color = ChooseHighlightColor();
		if (color.HasValue)
		{
			Color value = color.Value;
			image.color *= value;
		}
	}

	private void SetHighlightedColor(Text text)
	{
		Color? color = ChooseHighlightColor();
		if (color.HasValue)
		{
			Color value = color.Value;
			text.color *= value;
		}
	}

	private void UnsetHighlightedColor(Image image)
	{
		Color? color = ChooseHighlightColor();
		if (color.HasValue)
		{
			Color value = color.Value;
			PickColor(image);
			_r /= value.r;
			_g /= value.g;
			_b /= value.b;
			_a /= value.a;
			image.color = new Color(_r, _g, _b, _a);
		}
	}

	private void UnsetHighlightedColor(Text text)
	{
		Color? color = ChooseHighlightColor();
		if (color.HasValue)
		{
			Color value = color.Value;
			PickColor(text);
			_r /= value.r;
			_g /= value.g;
			_b /= value.b;
			_a /= value.a;
			text.color = new Color(_r, _g, _b, _a);
		}
	}

	private void Update()
	{
		if (depth == 0 || disableCheckOut || Helper.IsVector2InWorldRect(curRect, Logic.GetMouseInWorld()))
		{
			return;
		}
		List<Image> list = new List<Image>();
		foreach (Image selectedImage in selectedImages)
		{
			if (!list.Contains(selectedImage))
			{
				list.Add(selectedImage);
			}
		}
		list.ForEach(UnsetHighlightedColor);
		List<Text> list2 = new List<Text>();
		foreach (Text selectedText in selectedTexts)
		{
			if (!list2.Contains(selectedText))
			{
				list2.Add(selectedText);
			}
		}
		list2.ForEach(UnsetHighlightedColor);
		depth = 0u;
		Clear();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		selectedImages.ForEach(UnsetHighlightedColor);
		selectedTexts.ForEach(UnsetHighlightedColor);
		depth++;
		selectedImages.ForEach(SetHighlightedColor);
		selectedTexts.ForEach(SetHighlightedColor);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		OnPointerExit(eventData);
	}

	private void OnDestroy()
	{
		if (listenerAlive)
		{
			Logic.staticDataLoadedEvent.RemoveListener(InitColorsAfterStaticDataLoaded);
		}
	}
}
