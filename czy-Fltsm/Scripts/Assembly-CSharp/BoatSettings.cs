using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/Boat Settings")]
public class BoatSettings : ScriptableObject
{
	public Boat[] Boats;

	public NameGenerator[] NameGenerators;

	[Min(1f)]
	[Tooltip("When a LandmarkMooringPoint does not have the required clearance for a boat to moor, this value indicates the range in which its MooringTarget can moved to be over a node with the required clearance")]
	public float MooringTargetClearanceSearchRange = 10f;

	public string ReturnRandomName()
	{
		return FlotsamGame.Random(NameGenerators).ReturnName();
	}

	public Boat ReturnBoatPrefab(BoatType boatType)
	{
		_ = Boats.Length;
		for (int i = 0; i < Boats.Length; i++)
		{
			Boat boat = Boats[i];
			if (boat.Type == boatType)
			{
				return boat;
			}
		}
		throw new NotSupportedException("Boat of type " + boatType.ToString() + " has not been set on the BoatSettings!");
	}
}
