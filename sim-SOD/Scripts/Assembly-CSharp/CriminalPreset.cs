using UnityEngine;

[CreateAssetMenu(fileName = "criminal_data", menuName = "Database/Criminal")]
public class CriminalPreset : SoCustomComparison
{
	public enum CriminalType
	{
		serialKiller = 0
	}

	public CriminalType type;

	public bool canBeAgent;

	public bool canHaveJob;

	public int suggestedRank;

	public CriminalPreset boss;

	public int positionsMin;

	public int positionsMax;

	public float desiredCrimePerDay;
}
