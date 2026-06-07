using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	public string itemName;

	public float size;

	public Sprite icon;

	public bool isStackable;

	public GameObject prefab;

	public int price;

	public float weight;

	public float deprecation;

	public int itemDescriptionLocalisationID;

	public int unlockedFromXP;
}
