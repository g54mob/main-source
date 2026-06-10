using System;
using UnityEngine;

public class Citizen : Human
{
	[Header("Citizen Attributes")]
	public bool alwaysPassDialogSuccess;

	[NonSerialized]
	public float customSort;

	public override void SetupEvidence()
	{
	}

	public void BirthdayCheck()
	{
	}

	public override void RecieveDamage(float amount, Actor fromWho, Vector3 damagePosition, Vector3 damageDirection, SpatterPatternPreset forwardSpatter, SpatterPatternPreset backSpatter, SpatterSimulation.EraseMode spatterErase = SpatterSimulation.EraseMode.onceExecutedAndOutOfAddressPlusDespawnTime, bool alertSurrounding = true, bool forceRagdoll = false, float forcedRagdollDuration = 0f, float shockMP = 1f, bool enableKill = false, bool allowRecoil = true, float ragdollForceMP = 1f)
	{
	}

	public override void SetCombatSkill(float newSkill)
	{
	}

	public void CreateWoundClosestToPoint(Vector3 point, Vector3 normal, InteractablePreset woundPreset, MurderWeaponPreset weapon)
	{
	}
}
