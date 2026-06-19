using System;
using Pug.UnityExtensions;
using UnityEngine;

[Serializable]
public class PugTextStyle
{
	public enum Capitalization
	{
		normal = 0,
		lowercase = 1,
		uppercase = 2
	}

	public enum HorizontalAlignment
	{
		left = 0,
		center = 1,
		right = 2
	}

	public enum VerticalAlignment
	{
		top = 0,
		center = 1,
		bottom = 2
	}

	[Flags]
	public enum Outline
	{
		top = 1,
		bottom = 2,
		left = 4,
		right = 8
	}

	public TextManager.FontFace fontFace = TextManager.FontFace.boldLarge;

	[Header("String processing")]
	public Capitalization capitalization;

	[Header("Alignment")]
	public HorizontalAlignment horizontalAlignment = HorizontalAlignment.center;

	public VerticalAlignment verticalAlignment = VerticalAlignment.center;

	[Header("Spacing")]
	public int extraCharSpacing;

	public int extraSpaceWidth;

	public int extraLineSpacing;

	public int extraEmptyLineSpacing;

	public bool forceMonospace;

	[Header("Wrapping")]
	public bool wrapAtComma;

	[Header("Right To Left Languages")]
	public float rightToLeftXOffset;

	public bool invertHorizontalAlignment;

	[Header("SpriteRenderer options")]
	public Color color = Color.white;

	public Outline outline;

	public Color outlineColor;

	public bool supportColorTags;

	[SortingLayer]
	public int sortingLayer = int.MinValue;

	public int orderInLayer = 9999;

	public SpriteMaskInteraction maskInteraction;

	public bool UsesOutlines
	{
		get
		{
			if (outline != 0)
			{
				return outlineColor != Color.clear;
			}
			return false;
		}
	}

	public PugTextStyle GetCopy()
	{
		return new PugTextStyle
		{
			fontFace = fontFace,
			capitalization = capitalization,
			horizontalAlignment = horizontalAlignment,
			verticalAlignment = verticalAlignment,
			extraCharSpacing = extraCharSpacing,
			extraSpaceWidth = extraSpaceWidth,
			extraLineSpacing = extraLineSpacing,
			extraEmptyLineSpacing = extraEmptyLineSpacing,
			forceMonospace = forceMonospace,
			rightToLeftXOffset = rightToLeftXOffset,
			invertHorizontalAlignment = invertHorizontalAlignment,
			color = color,
			sortingLayer = sortingLayer,
			orderInLayer = orderInLayer,
			maskInteraction = maskInteraction
		};
	}
}
