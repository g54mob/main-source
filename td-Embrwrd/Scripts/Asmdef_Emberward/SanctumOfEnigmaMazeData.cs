using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/SanctumOfEnigmaMazeData", order = 1)]
public class SanctumOfEnigmaMazeData : ScriptableObject
{
	[SerializeField]
	private List<SquareMazeLayout> mazeLayouts;

	public int GetMazeLayoutCount()
	{
		return 0;
	}

	public SquareMazeLayout GetMazeLayoutAtIndex(int index)
	{
		return null;
	}
}
