using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColorOption
{
	public string propertyName;

	public Gradient possibleColors;

	public List<int> rendererIndices = new List<int> { 0 };
}
