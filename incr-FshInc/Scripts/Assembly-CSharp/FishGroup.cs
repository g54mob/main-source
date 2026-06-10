using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish Group", menuName = "Game/Fish Group")]
public class FishGroup : ScriptableObject
{
	public string groupName;

	public List<Fish> fishes;
}
