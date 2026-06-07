using UnityEngine;

[CreateAssetMenu]
public class CropSO : ScriptableObject
{
	public string cropName;

	public CropType cropType;

	[Space]
	public int cropCost;

	public int cropBiofuelCost;

	public float growingDays = 1f;

	public int waterDemand = 4;

	public int biofuelYield = 1;

	public int harvestMultiplier = 1;

	public int earnings = 2;

	[Space]
	public Sprite cropSprite;

	public Sprite[] spriteList;

	[Space]
	public Sprite deadSprite;

	[Header("Unlock Requirements")]
	public CropSO requirement1;

	public int requirementAmount1;

	public CropSO requirement2;

	public int requirementAmount2;

	public CropSO requirement3;

	public int requirementAmount3;

	public CropSO requirement4;

	public int requirementAmount4;

	[Header("Description")]
	public string cropDescription;

	public int cropIndexInList;
}
