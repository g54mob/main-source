using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModdedMurderWeapon
{
	[Tooltip("Copy all data from this pre-existing interactable; so we can quickly make versions of different objects etc.")]
	public string copyDataFrom;

	public string presetName;

	public string type;

	public List<string> ammunition;

	public string murderDifficultyModifier;

	[Tooltip("Local muzzle position relative to the pivot")]
	public string muzzleOffsetX;

	public string muzzleOffsetY;

	public string muzzleOffsetZ;

	[Tooltip("Local brass eject relative to the pivot")]
	public string brassEjectOffsetX;

	public string brassEjectOffsetY;

	public string brassEjectOffsetZ;

	public string itemRightOverride;

	public string itemRightLocalPosX;

	public string itemRightLocalPosY;

	public string itemRightLocalPosZ;

	public string itemRightLocalEulerX;

	public string itemRightLocalEulerY;

	public string itemRightLocalEulerZ;

	public string itemLeftOverride;

	public string itemLeftLocalPosX;

	public string itemLeftLocalPosY;

	public string itemLeftLocalPosZ;

	public string itemLeftLocalEulerX;

	public string itemLeftLocalEulerY;

	public string itemLeftLocalEulerZ;

	public string overideUsesCarryAnimation;

	public string overrideCarryAnimation;

	[Tooltip("If true, citizens may carry this about to defend themselves")]
	public string usedInPersonalDefence;

	public string disabled;

	public string basePriority;

	public string socialClassRangeMin;

	public string socialClassRangeMax;

	public string citizenSpawningWithScore;

	public List<string> personalDefenceTraitModifiers1;

	public List<string> personalDefenceTraitModifiers2;

	public List<string> personalDefenceTraitModifiers3;

	public List<string> jobModifierList;

	public string jobScoreModifier;

	[Tooltip("How this impacts nerve levels of a citizen if drawn")]
	public string drawnNerveModifier;

	[Tooltip("Chance of bark trigger")]
	public string barkTriggerChance;

	public string bark;

	[Tooltip("With this weapon, multiply incoming nerve damage by this")]
	public string incomingNerveDamageMultiplier;

	[Tooltip("At what point during the attack is the trigger executed? Normalized value")]
	public string attackTriggerPoint;

	[Tooltip("At what point during the attack is the trigger removed? Normalized value")]
	public string attackRemovePoint;

	[Tooltip("How many shots are fired?")]
	public string shots;

	[Tooltip("Weapon range")]
	public string weaponMaxRangeMin;

	public string weaponMaxRangeMax;

	public string minimumRange;

	public string maximumBulletRange;

	public string weaponRangeLerpSource;

	public string fireDelayMin;

	public string fireDelayMax;

	public string fireDelayLerpSource;

	[Tooltip("Attack accuracy")]
	public string attackAccuracyMin;

	public string attackAccuracyMax;

	public string attackAccuracyLerpSource;

	[Tooltip("Attack damage")]
	public string attackDamageMin;

	public string attackDamageMax;

	public string attackDamageLerpSource;

	public string applyPoison;

	public string shellCasing;

	public string ejectBrassSetting;

	public string bulletHole;

	public string glassBulletHole;

	public string entryWound;

	public string bulletRicochet;

	public string bulletImpactSpray;

	public string muzzleFlash;

	public string bloodPoolAmount;

	public string forwardSpatter;

	public string backSpatter;
}
