using NaughtyAttributes;
using UnityEngine;

public class WindowMapper : MonoBehaviour
{
	public GameObject buildingObject;

	public GameObject debugWindow;

	public BuildingPreset preset;

	public Transform buildingModel;

	public Transform cableLinkingContainer;

	public Transform neonSideSignContainer;

	[Button(null, EButtonEnableMode.Always)]
	public void SpawnObjectsOnWindows()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GenerateCableLinkingPoints()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GenerateNeonSignSidePoints()
	{
	}
}
