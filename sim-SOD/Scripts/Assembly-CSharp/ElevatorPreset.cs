using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "elevator_data", menuName = "Database/Elevator Preset")]
public class ElevatorPreset : SoCustomComparison
{
	public List<GameObject> stairWellPrefabs;

	public List<GameObject> stairsPrefabs;

	public float rotationOffset;

	public Material bottomMaterial;

	public Material topMaterial;
}
