using System;
using UnityEngine;

[Serializable]
public class PDFRectTransform
{
	public Vector2 localPosition;

	public Vector2 referencePosition;

	public Vector2 sizeDelta;

	public Vector2 referencePointCanvas;

	public Vector2 referencePointObject;

	public Rect rect => default(Rect);
}
