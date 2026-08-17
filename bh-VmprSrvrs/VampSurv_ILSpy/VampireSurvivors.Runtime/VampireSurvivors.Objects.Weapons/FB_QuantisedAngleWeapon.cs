using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class FB_QuantisedAngleWeapon : Weapon
{
	protected float _firingAngleDegrees;

	public virtual float SecondsToRotateAim360 => 0.9f;

	public virtual float QuantisationStep => 45f;

	public override void InternalUpdate()
	{
		//IL_0024: Expected I, but got O
		//IL_00c8: Invalid comparison between I4 and F4
		//IL_0113: Expected O, but got F4
		base.InternalUpdate();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		float num2 = 0f * 57.29578f;
		float quantisationStep = QuantisationStep;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		float num4 = num3 / 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		float quantisationStep2 = QuantisationStep;
		float num5 = num4 * num4;
		float num6 = Mathf.DeltaAngle(_firingAngleDegrees, num5);
		float secondsToRotateAim = SecondsToRotateAim360;
		if (!(num6 > 170f) && 0f < num6)
		{
			float secondsToRotateAim2 = SecondsToRotateAim360;
			float num7 = 360f / num6;
			object obj = Time.deltaTime;
			float maxDelta = num6 * num7;
			float firingAngleDegrees = Mathf.MoveTowardsAngle(_firingAngleDegrees, num5, maxDelta);
			_firingAngleDegrees = firingAngleDegrees;
		}
		else
		{
			_firingAngleDegrees = num5;
		}
	}

	public override float2 GetFiringVector()
	{
		float num = _firingAngleDegrees * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float2 result = default(float2);
		return result;
	}
}
