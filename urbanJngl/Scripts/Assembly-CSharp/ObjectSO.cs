using System;
using System.Collections.Generic;
using Data.Enums;
using UnityEngine;

[CreateAssetMenu]
public class ObjectSO : ScriptableObject
{
	public PlantName objectName;

	public string objectNameLocalization;

	public string plantTipLocalization;

	public int ID;

	[ScriptableObjectID]
	public string GUID;

	public Vector2Int size;

	public Transform prefab;

	public List<Variant> variantsList;

	public Sprite sprite;

	public Sprite journalSprite;

	public int score;

	public int price;

	public EnvironmentSunlight.Sunlight sunlight;

	public EnvironmentHumidity.Humidity humidity;

	[Space]
	[Header("Friend Plant")]
	public int addPoints;

	public List<PlantName> friendPlant;

	public PlantSize friendSize;

	[Space]
	[Header("Enemy Plant")]
	public int deductPoints;

	public List<PlantName> enemyPlant;

	public PlantSize enemySize;

	public void AddVariant()
	{
		Variant variant = new Variant();
		variant.GUID = Guid.NewGuid().ToString();
		variantsList.Add(variant);
	}
}
