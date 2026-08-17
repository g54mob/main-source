using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class SantaJavelinCounterWeapon : SantaJavelinWeapon
{
	public Transform PublicTarget => _targetTransform;

	public override float PitchCorrection => 200f;

	public override void CheckArcanas()
	{
		GM.Core.SetSeenWeapon(WeaponType.SANTAJAVELINCOUNTER);
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_cooldownAffectedByMovement = true;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			_explodeOnExpire = true;
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
	}

	public unsafe override void ForcedFire(bool hasTarget, Vector3 position, bool skipTriggers = false)
	{
		//IL_0011: Expected O, but got Ref
		bool flag = default(bool);
		Vector3 vector = base.Fire_FireProjectiles(hasTarget: true, (Vector3)(&flag));
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}
}
