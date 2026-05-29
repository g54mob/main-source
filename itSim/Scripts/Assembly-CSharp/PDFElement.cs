using System;
using TMPro;
using UnityEngine;

[Serializable]
public class PDFElement
{
	public bool active;

	public string name;

	public string type;

	public PDFRectTransform rectTransform;

	public string content;

	public string textID;

	public string fount;

	public string size_fount;

	public string color_fount;

	public FontStyles fontStyles;

	public TextAlignmentOptions alignment;

	public Sprite lastSprite;

	public Sprite sprite;

	public string colorSprite;
}
