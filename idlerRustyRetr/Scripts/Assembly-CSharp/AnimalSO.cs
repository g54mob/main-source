using UnityEngine;

[CreateAssetMenu]
public class AnimalSO : ScriptableObject
{
	public string animalName;

	[Space]
	public int fossilCost;

	public float fossilCoef = 3f;

	public int fossilStartIncrease = 1;

	[Space]
	public int biofuelCost;

	public float biofuelCoef = 3f;

	public int biofuelStartIncrease = 1;

	[Space]
	public Sprite animalLogo;

	[Header("References")]
	public Animal basePrefab;

	public AnimatorOverrideController animatorController;

	[Header("Description")]
	public string animalDescription;

	public int animalIndexInList;
}
