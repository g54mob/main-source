using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class AccessoryTP_FREESLOT_FOLLOWER : Accessory
{
	public VampireSurvivors.Objects.Characters.CharacterController FollowerCharacterController;

	public override void OnAccessoryAddedToEquipment()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		int maxAccessoryBonus = characterController._maxAccessoryBonus + 1;
		characterController._maxAccessoryBonus = maxAccessoryBonus;
	}

	public override void OnAccessoryRemovedFromEquipment()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		int maxAccessoryBonus = characterController._maxAccessoryBonus - 1;
		characterController._maxAccessoryBonus = maxAccessoryBonus;
	}

	protected override void MakeLevelOne()
	{
		//IL_000a: Expected I, but got O
		base.MakeLevelOne();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.AccessoryTP_FREESLOT_FOLLOWER>)+290]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.AccessoryTP_FREESLOT_FOLLOWER>)+290]");
		action._002Ector(this, (IntPtr)0);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected virtual void AddFollower()
	{
		//IL_0060: Expected O, but got I4
		//IL_00d0: Expected I4, but got F4
		WeaponData weaponData = base._003CCurrentAccessoryData_003Ek__BackingField;
		if (weaponData._003CfollowerType_003Ek__BackingField != CharacterType.VOID && weaponData._003CfollowerAI_003Ek__BackingField != AIType.None)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.5f;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
			WeaponData weaponData2 = base._003CCurrentAccessoryData_003Ek__BackingField;
			int everyXLevels = default(int);
			bool spawnWithoutAuthority = default(bool);
			VampireSurvivors.Objects.Characters.CharacterController followerCharacterController = GM.Core.AddFollower(weaponData2._003CfollowerType_003Ek__BackingField, ((Equipment)this)._003COwner_003Ek__BackingField, weaponData2._003CfollowerAI_003Ek__BackingField, (byte)(int)num != 0, everyXLevels, spawnWithoutAuthority);
			FollowerCharacterController = followerCharacterController;
			VampireSurvivors.Objects.Characters.CharacterController followerCharacterController2 = FollowerCharacterController;
			if ((object)FollowerCharacterController != null && ((UnityEngine.Object)followerCharacterController2).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController followerCharacterController3 = FollowerCharacterController;
				followerCharacterController3._003CTrackedByCamera_003Ek__BackingField = false;
				FollowerCharacterController.SetPermanentInvulnerability(on: true);
				VampireSurvivors.Objects.Characters.CharacterController followerCharacterController4 = FollowerCharacterController;
				followerCharacterController4._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
			}
		}
	}
}
