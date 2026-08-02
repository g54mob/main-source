using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FillImageData
{
	public Image image;

	[Tooltip("X: Başlangıç değeri (0-1), Y: Bitiş değeri (0-1)")]
	public Vector2 totalFillData;
}
