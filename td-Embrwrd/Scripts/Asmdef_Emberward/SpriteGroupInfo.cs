using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpriteGroupInfo
{
	[Tooltip("Set the colour for this sprite group.")]
	public Color colour;

	[Tooltip("Set the sorting layer for this sprite group.")]
	public string sortingLayer;

	[Tooltip("Set the sorting order for this sprite group.")]
	public int sortingOrder;

	[Tooltip("The sprite group: Drag game objects that have sprite renderers attached from the hierarchy into this list.")]
	public List<SpriteRenderer> spriteRendererList;

	[Tooltip("Do you want to update the colour of this sprite group?")]
	public bool updateColour;

	[Tooltip("Do you want to update the sorting layer of this sprite group?")]
	public bool updateSortingLayer;

	[Tooltip("Do you want to update the sorting order of this sprite group?")]
	public bool updateSortingOrder;
}
