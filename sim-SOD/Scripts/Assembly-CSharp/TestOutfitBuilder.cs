using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class TestOutfitBuilder : MonoBehaviour
{
	public bool hasFacialHair;

	public bool hasHat;

	public bool hasGlasses;

	public List<Mesh> Beards;

	public List<Mesh> Feet;

	public List<Mesh> Glasses;

	public List<Mesh> Hair;

	public List<Mesh> Hands;

	public List<Mesh> Hats;

	public List<Mesh> Heads;

	public List<Mesh> LowerArms;

	public List<Mesh> LowerLegs;

	public List<Mesh> LowerTorsos;

	public List<Mesh> Midriffs;

	public List<Mesh> UpperArms;

	public List<Mesh> UpperLegs;

	public List<Mesh> UpperTorsos;

	public Citizen citizenToSpawn;

	public float citizenAmount;

	private float _xOffset;

	private float _zOffset;

	[Button(null, EButtonEnableMode.Always)]
	public void SpawnAndClotheCitizens()
	{
	}

	public void RollRandomClothing(CitizenOutfitController controller)
	{
	}

	public bool CoinFlip()
	{
		return false;
	}
}
