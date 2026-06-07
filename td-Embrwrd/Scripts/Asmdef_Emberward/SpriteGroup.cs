using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteGroup : MonoBehaviour
{
	[Tooltip("To create a new group of sprites that can be edited simultaneously, click the arrow and type the number of groups of sprites you want to create into the field.")]
	public List<SpriteGroupInfo> spriteGroups;

	public void SetColour(int spriteGroupsIndex, Color colour)
	{
	}

	public void SetSortingLayer(int spriteGroupsIndex, string sortingLayer)
	{
	}

	public void SetSortingOrder(int spriteGroupsIndex, int sortingOrder)
	{
	}
}
