using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class InventoryItemAuthoring : MonoBehaviour
{
	[Serializable]
	public struct CraftingObject
	{
		[PickStringFromEnum(typeof(ObjectID))]
		public string objectName;

		public int amount;
	}

	public int sellValue = -1;

	public float buyValueMultiplier = 1f;

	public Sprite icon;

	public Vector2 iconOffset;

	public Sprite smallIcon;

	public bool isStackable;

	[Header("Crafting")]
	public List<CraftingObject> requiredObjectsToCraft;

	public float craftingTime;
}
