using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class CrafterFuelByproduct : MonoBehaviour
{
	[SerializeField]
	private CrafterFueler _crafterFueler;

	[SerializeField]
	private float _chance;

	[SerializeField]
	private Transform _generatePoint;

	[SerializeField]
	private float _generationDist;

	public List<ItemType> FuelTypes;

	public ItemType Biproduct;

	public EventReference GenerateBiproductSound;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnSpendFuel(ItemType type)
	{
	}

	public void AddChance(float chance)
	{
	}
}
