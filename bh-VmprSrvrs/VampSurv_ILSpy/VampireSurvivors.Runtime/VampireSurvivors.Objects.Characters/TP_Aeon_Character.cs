using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Aeon_Character : TP_Character
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public Weapon weapon;

		internal void _003CAfterFullInitialization_003Eb__0()
		{
			weapon.Fire();
		}
	}

	private float cooldownBonus = -0.33f;

	private float moveBonus = 1f;

	private bool _previousTimeStopState;

	public override float LootMult_Orologion => 2f;

	public override float PCooldown()
	{
		//IL_003f: Expected F4, but got I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		GameManager core = GM.Core;
		float num = ((!core._003CIsTimeStopped_003Ek__BackingField) ? 0f : cooldownBonus);
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num;
		float num2 = eggFloat2._eggVal + eggFloat2._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875E1F13h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				return num2;
			}
		}
		return 3.4028235E+38f;
	}

	public override float PMoveSpeed()
	{
		//IL_003f: Expected F4, but got I4
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		GameManager core = GM.Core;
		float num = ((!core._003CIsTimeStopped_003Ek__BackingField) ? 0f : moveBonus);
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CMoveSpeed_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num;
		float eggValue = default(float);
		float value2 = default(float);
		EggFloat eggFloat3 = new EggFloat(value2, eggValue);
		eggValue = eggFloat2._eggVal * MoveSpeedMultiplier;
		value2 = eggFloat2._val * MoveSpeedMultiplier;
		float num2 = eggFloat3._eggVal + eggFloat3._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875E20C5h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_01a8;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_01a8;
		IL_01a8:
		return num2;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		GameManager core3;
		if (!((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			GameManager core = GM.Core;
			if (_previousTimeStopState != core._003CIsTimeStopped_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				if (!core2._003CIsTimeStopped_003Ek__BackingField)
				{
					((CharacterController)this)._spriteTrail.ResetGhostValues();
				}
				else
				{
					OnTimeStopStart();
				}
			}
			core3 = GM.Core;
		}
		else
		{
			core3 = GM.Core;
		}
		_previousTimeStopState = core3._003CIsTimeStopped_003Ek__BackingField;
	}

	private unsafe void OnTimeStopStart()
	{
		//IL_0076: Expected O, but got I4
		//IL_007e: Expected O, but got Ref
		SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
		spriteTrail._MaxHistory = 30;
		spriteTrail.InitialiseGhosts(expandExisting: true);
		SpriteTrail spriteTrail2 = ((CharacterController)this)._spriteTrail;
		spriteTrail2._DefaultGhostAlpha = 1f;
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		bool flag = false;
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void OnTimeStopEnd()
	{
		((CharacterController)this)._spriteTrail.ResetGhostValues();
	}

	public override void AfterFullInitialization()
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass10_0();
		base.AfterFullInitialization();
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.TP_SWORD_BROTHERS);
		CS_0024_003C_003E8__locals4.weapon = weaponByType;
		Weapon weapon = CS_0024_003C_003E8__locals4.weapon;
		if ((object)CS_0024_003C_003E8__locals4.weapon != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0)
		{
			Action onComplete = delegate
			{
				CS_0024_003C_003E8__locals4.weapon.Fire();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(4f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}
}
