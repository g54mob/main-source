using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TableEntry : MonoBehaviour
{
	[Serializable]
	public struct Style
	{
		public string ID;

		public TableEntry Prefab;

		public bool Equals(string id)
		{
			return ID.Equals(id, StringComparison.OrdinalIgnoreCase);
		}
	}

	[SerializeField]
	private TextMeshProUGUI _text;

	[SerializeField]
	private Image _image;

	public UnityEvent OnValueChanged = new UnityEvent();

	public Style EntryStyle { get; private set; }

	public void Initialize(Style style, string text, float width)
	{
		EntryStyle = style;
		if (_text != null)
		{
			_text.text = text;
			_text.enabled = true;
		}
		if (_image != null)
		{
			_image.enabled = false;
		}
		RectTransform rectTransform = base.transform as RectTransform;
		rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
		OnValueChanged.Invoke();
	}

	public void Initialize(Style style, Sprite sprite, Color spriteColor, float size)
	{
		EntryStyle = style;
		if (_image != null)
		{
			_image.sprite = sprite;
			_image.color = spriteColor;
			_image.enabled = true;
		}
		if (_text != null)
		{
			_text.enabled = false;
		}
		RectTransform rectTransform = base.transform as RectTransform;
		rectTransform.sizeDelta = new Vector2(size, rectTransform.sizeDelta.y);
		OnValueChanged.Invoke();
	}
}
