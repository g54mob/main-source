using UnityEngine;

[CreateAssetMenu(fileName = "Bas Boule Player", menuName = "Database/Base Boule/Bas Boule Player")]
public class BaseboulePlayer : ScriptableObject
{
	public enum Experience
	{
		Rookie = 0,
		Experienced = 1,
		Veteran = 2,
		AllStar = 3
	}

	public enum Position
	{
		Rouleur = 0,
		Fielder = 1,
		Tireur = 2
	}

	public string firstName;

	public string surName;

	[Range(1f, 100f)]
	public int playerSkill;

	public string funFact;
}
