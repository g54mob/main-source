using System;
using TMPro;
using UnityEngine;

[Serializable]
public class UILabelFieldProperties
{
	public bool useFontColor;

	public Color color = Color.white;

	public bool useFontSize;

	public float fontSize = 16f;

	public bool useFontStyle;

	public FontStyles fontStyle;

	public bool useFontAlignment;

	public TextAlignmentOptions alignmentOptions;
}
