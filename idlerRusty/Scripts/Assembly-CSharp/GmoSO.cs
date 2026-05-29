using UnityEngine;

[CreateAssetMenu]
public class GmoSO : ScriptableObject
{
	public string gmoName;

	public CropType cropType;

	[Space]
	public int gmoCost;

	[Space]
	public float growingDays;

	public int waterDemand;

	public int biofuelYield;

	public int harvestMultiplier;

	public int earnings;

	[Header("Description")]
	public int gmoIndexInList;
}
