using System;
using Data.Enums;
using UnityEngine;

[Serializable]
public class Variant
{
	[ScriptableObjectID]
	public string GUID;

	public Vector2Int size;

	public Transform prefab;

	public Sprite variantSprite;

	public Sprite variantSpriteBW;

	public int price;

	public PlantRareLevel rareLevel;

	public bool isStartingSkin;
}
