using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_SpecialUnlock : EnemyController
{
	protected List<WeaponType> WeaponsToHitWith;

	protected virtual void OnKilledBySelectedWeapon()
	{
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_02bf: Invalid comparison between F4 and I4
		//IL_0344: Invalid comparison between F4 and I4
		//IL_018b: Invalid comparison between I4 and F4
		//IL_0236: Expected I, but got O
		//IL_0103: Expected I, but got O
		//IL_0068->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_008c->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_03ad->IL0285: Incompatible stack heights: 1 vs 0
		//IL_0334->IL0285: Incompatible stack heights: 1 vs 0
		//IL_0145->IL0145: Incompatible stack heights: 1 vs 0
		//IL_0276->IL0276: Incompatible stack heights: 1 vs 0
		bool flag = !(_damageWeakness > 1f);
		float num = value;
		if (!flag)
		{
			num = value * _damageWeakness;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj = default(object);
		bool flag2 = obj == null;
		HitVfxType hitVfxType = showHitVfx;
		if (!flag2)
		{
			WeaponType[] fireDamageTypes = EnemyController.FireDamageTypes;
			bool flag3 = EnemyController.FireDamageTypes == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507A40");
			object obj2 = default(object);
			bool flag4 = (nint)obj2 <= -1;
			hitVfxType = HitVfxType.None;
			if (!flag4)
			{
				num *= base._003CWeakFire_003Ek__BackingField;
				hitVfxType = HitVfxType.None;
			}
		}
		if (!(num > 0f))
		{
			goto IL_0145;
		}
		Vector3 ret;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				if (!config._003CDamageNumbersEnabled_003Ek__BackingField)
				{
					goto IL_0145;
				}
				nint num2 = (nint)_cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdi_v12 (Il2CppMethodInfo)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdi_v12 (Il2CppMethodInfo)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if (_signalBus != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2990");
						goto IL_0145;
					}
				}
			}
		}
		goto IL_0285;
		IL_0145:
		if (!base._003CIsDead_003Ek__BackingField && !(0f < (_hp -= num)))
		{
			base.Die();
		}
		if (!(_hp > 0f))
		{
			if (WeaponsToHitWith == null)
			{
				goto IL_0285;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj3 = default(object);
			if (obj3 != null)
			{
				OnKilledBySelectedWeapon();
			}
		}
		else
		{
			_damageKb = damageKb;
		}
		EnemyController.PlayHitSfx();
		if (showHitVfx == HitVfxType.None)
		{
			goto IL_0276;
		}
		nint num3 = (nint)_cachedTransform;
		if ((object)_cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdi_v11 (Il2CppMethodInfo)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdi_v11 (Il2CppMethodInfo)+10]");
			Transform.get_position_Injected((IntPtr)0, out ret);
			if ((object)_gameManager != null)
			{
				Vector2 worldPos = default(Vector2);
				VFXManager.SpawnImpactVFX(showHitVfx, worldPos);
				goto IL_0276;
			}
		}
		goto IL_0285;
		IL_0276:
		bool hasKb2 = default(bool);
		base.OnGetDamaged(showHitVfx, hasKb2);
		return;
		IL_0285:
		throw new NullReferenceException();
	}

	public Enemy_TP_SpecialUnlock()
	{
		List<WeaponType> weaponsToHitWith = new List<WeaponType>();
		WeaponsToHitWith = weaponsToHitWith;
		base._002Ector();
	}
}
