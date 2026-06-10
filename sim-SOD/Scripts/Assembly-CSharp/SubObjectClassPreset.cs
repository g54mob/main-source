using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "subobject_data", menuName = "Database/Sub Object Class")]
public class SubObjectClassPreset : SoCustomComparison
{
	public enum PlacementTypeLimit
	{
		all = 0,
		companyOnly = 1,
		homeOnly = 2,
		indoorsOnly = 3,
		outdoorsOnly = 4
	}

	[Header("Spawning")]
	public bool limitCountPerObject;

	[EnableIf("limitCountPerObject")]
	[Tooltip("If true only one of these types will be spawned per object")]
	public int maxPerObject;

	[Tooltip("The chance of spawning here on a per-object basis")]
	[Range(0f, 1f)]
	public float perObjectSpawnChance;

	[Tooltip("The chance of spawning here on a per-instance basis")]
	[Range(0f, 1f)]
	public float perInstanceSpawnChance;

	[Tooltip("Added to the perInstanceSpawnChance as modifiers, uses test type found on the furniture preset")]
	[ReorderableList]
	public List<CharacterTrait.TraitPickRule> perInstanceModifiers;

	public PlacementTypeLimit typeLimit;
}
