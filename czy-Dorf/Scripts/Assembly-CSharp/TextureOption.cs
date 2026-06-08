using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TextureOption
{
	public string propertyName;

	public List<Texture2D> possibleTextures;

	public List<int> rendererIndices = new List<int> { 0 };
}
