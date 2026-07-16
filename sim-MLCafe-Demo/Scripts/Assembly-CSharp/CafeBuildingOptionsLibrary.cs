using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CafeBuildingOptionsLibrary", menuName = "Libraries/CafeBuildingOptionsLibrary")]
public class CafeBuildingOptionsLibrary : ScriptableObject
{
	[SerializeField]
	private List<CafeBuildingSet> buildingSets = new List<CafeBuildingSet>();

	public CafeBuildingSet GetBuildingSet(int set)
	{
		return buildingSets[set];
	}

	public List<CafeBuildingSet> GetAllSets()
	{
		return buildingSets;
	}
}
