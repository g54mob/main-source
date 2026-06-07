using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MB_MultiMaterialTexArray
{
	public Material combinedMaterial;

	[NonReorderable]
	public List<MB_TexArraySlice> slices;

	[NonReorderable]
	public List<MB_TexArrayForProperty> textureProperties;
}
