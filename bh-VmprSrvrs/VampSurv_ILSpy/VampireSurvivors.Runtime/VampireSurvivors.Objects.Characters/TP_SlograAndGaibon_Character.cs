using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class TP_SlograAndGaibon_Character : TP_Character
{
	private bool _spawnFollowerNextFrame;

	private bool isSlogra;

	private CharacterController follower;

	private bool isEnraged;

	public bool IsSlogra => isSlogra;

	public override bool ShouldCollideWithWalls()
	{
		return !isSlogra;
	}

	protected override void OnStop()
	{
		if (isSlogra)
		{
			base.OnStop();
			return;
		}
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		CharacterData currentCharacterData = _currentCharacterData;
		_spawnFollowerNextFrame = true;
		bool flag = currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.DEFAULT;
		isSlogra = flag;
		bool flag2 = currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.DEFAULT;
		WeaponType weaponType = WeaponType.TP_CHAUVE1;
		if (!flag2)
		{
			weaponType = WeaponType.FIREBALL;
		}
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(weaponType);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			WeaponData currentWeaponData = weaponByType._currentWeaponData;
			weaponByType.IsAdept = true;
			float num = currentWeaponData._003Cinterval_003Ek__BackingField * 0.5f;
			currentWeaponData._003Cinterval_003Ek__BackingField = num;
		}
	}

	protected override void OnUpdate()
	{
		//IL_018b: Expected O, but got I4
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected I4, but got Unknown
		//IL_0120: Expected O, but got I4
		base.OnUpdate();
		CharacterController characterController = follower;
		bool flag = default(bool);
		int num = default(int);
		bool flag2 = default(bool);
		if ((object)follower != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			CharacterController characterController2 = follower;
			if (characterController2._isDead || characterController2.IsDisconnectedFromOnlinePlay)
			{
				if (isEnraged)
				{
					return;
				}
				isEnraged = true;
				((CharacterController)this)._classSupport.AddActiveRapidFire(-0.9f, 0f, 20000f);
				Action onComplete = delegate
				{
					isEnraged = false;
				};
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(21.000002f, onComplete, null, isLooped: false, flag, (MonoBehaviour)num, flag2 ? 1 : 0, type, isOnlineTimer: false, canPause: false);
			}
		}
		if (_spawnFollowerNextFrame)
		{
			_spawnFollowerNextFrame = false;
			if (_coherenceSync.HasStateAuthority)
			{
				object obj = 0 - (isSlogra ? 1 : 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb edx,edx\"");
				CharacterType characterType = (CharacterType)(obj + 329);
				CharacterController characterController3 = GM.Core.AddFollower(characterType, this, AIType.Defensive, flag, num, flag2);
				follower = characterController3;
				CharacterController characterController4 = follower;
				characterController4._003CTrackedByCamera_003Ek__BackingField = true;
				CharacterController characterController5 = follower;
				characterController5._permanentInvulnerability = false;
				characterController5.IsInvul = false;
				characterController5._invincibilityTimer = 0f;
				CharacterController characterController6 = follower;
				characterController6._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
				CharacterController characterController7 = follower;
				characterController7.IsFollowerSharingPassives = true;
				CharacterController characterController8 = follower;
				int maxWeaponCount = ((CharacterController)this)._maxWeaponBonus + ((CharacterController)this)._maxWeaponCount;
				characterController8._maxWeaponCount = maxWeaponCount;
				CharacterController characterController9 = follower;
				HealthBar healthBar = RenderingExtensions.SetScale(characterController9._healthBar, 0.00125f);
			}
		}
	}

	private void _003COnUpdate_003Eb__9_0()
	{
		isEnraged = false;
	}
}
