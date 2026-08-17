using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TriaceWeapon : Weapon
{
	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		_explodeOnExpire = false;
		base.InitWeapon(characterController, weaponType);
	}

	public override void ParadoxFire()
	{
		Fire(skipTriggers: true);
		Action onComplete = delegate
		{
			Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Fire(skipTriggers: true);
		};
		Timer timer2 = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				base._003CFreezeChance_003Ek__BackingField = 0.25f;
			}
		}
		WeaponData currentWeaponData = _currentWeaponData;
		if (currentWeaponData._003CbulletType_003Ek__BackingField != WeaponType.TRIASSO1 && HasActiveArcanaOfType(ArcanaType.T02_TWILIGHT))
		{
			_explodeOnExpire = true;
		}
		WeaponData currentWeaponData2 = _currentWeaponData;
		if (currentWeaponData2._003CbulletType_003Ek__BackingField == WeaponType.TRIASSO3 && HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			GameManager gameMan3 = _gameMan;
			float heartOfFirePower = base.HeartOfFirePower;
			float newWeaponPower = default(float);
			gameMan3._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
		}
		CheckBeginningArcana();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0087: Expected O, but got Ref
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Ref, but got Unknown
		//IL_0138: Expected O, but got I4
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Ref, but got Unknown
		if (!IsHoming)
		{
			GameManager gameMan = _gameMan;
			ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
			Transform targetTransform = gameMan._stage.PickRandomEnemy(ref rng);
			_targetTransform = targetTransform;
		}
		else
		{
			GameManager core = GM.Core;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				Transform targetTransform2 = enemyController.transform;
				_targetTransform = targetTransform2;
			}
			else
			{
				GameManager gameMan2 = _gameMan;
				ref Unity.Mathematics.Random rng2 = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
				Transform targetTransform3 = gameMan2._stage.PickRandomEnemy(ref rng2);
				_targetTransform = targetTransform3;
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 10, time);
		base.Fire(skipTriggers);
	}

	private void _003CParadoxFire_003Eb__1_0()
	{
		Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__1_1()
	{
		Fire(skipTriggers: true);
	}
}
