using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "murderweapons_data", menuName = "Database/Murder Weapons Pool")]
public class MurderWeaponsPool : SoCustomComparison
{
	[Serializable]
	public class MurderWeaponPick
	{
		[Tooltip("The weapon itself")]
		public InteractablePreset weapon;

		[Range(0f, 1f)]
		[Tooltip("Chance of killer dropping this at scene")]
		public float chanceOfDroppingAtScene;

		[Space(7f)]
		public Vector2 randomScoreRange;

		public List<MurderPreset.MurdererModifierRule> traitModifiers;
	}

	[InfoBox("The killer will pick one of these to kill ALL their victims...", EInfoBoxType.Normal)]
	public List<MurderWeaponPick> murderWeaponPool;
}
