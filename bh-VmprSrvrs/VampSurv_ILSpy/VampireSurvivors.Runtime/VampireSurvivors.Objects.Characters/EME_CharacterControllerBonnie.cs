using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerBonnie : EME_CharacterControllerShowstopper
{
	public bool spawnFollowerNextFrame;

	private float _techniquesCount;

	private float _bonusPower;

	public override float PPower()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + _bonusPower;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018764DCE6h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public override void OnGlimmeredTechniqueFired()
	{
		float bonusPower = ++_techniquesCount * 0.001f;
		_bonusPower = bonusPower;
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		CharacterData currentCharacterData = _currentCharacterData;
		spawnFollowerNextFrame = true;
		if (currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.SKIN_EME_SOLO_PUNCH || currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.SKIN_EME_SOLO_KICK)
		{
			spawnFollowerNextFrame = false;
		}
	}

	protected override void OnUpdate()
	{
		//IL_00a6: Expected I, but got O
		//IL_00ae: Expected I, but got O
		//IL_00be: Expected O, but got I
		//IL_00fa: Expected O, but got I
		base.OnUpdate();
		if (!spawnFollowerNextFrame)
		{
			return;
		}
		spawnFollowerNextFrame = false;
		if (!_coherenceSync.HasStateAuthority)
		{
			return;
		}
		bool manualLevelups = default(bool);
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		CharacterController characterController = GM.Core.AddFollower(CharacterType.EME_CANNONGUN, this, AIType.Defensive, manualLevelups, everyXLevels, spawnWithoutAuthority);
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		nint num = (nint)typeof(EME_CharacterControllerFormina);
		nint num2 = (nint)characterController;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.EME_CharacterControllerFormina>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.EME_CharacterControllerFormina>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v18+FFFFFFF8+v212 @ rax_v17*8]");
			if (0 == (nint)typeof(EME_CharacterControllerFormina))
			{
				_ = 0;
				characterController._003CTrackedByCamera_003Ek__BackingField = true;
				characterController.SetPermanentInvulnerability(on: true);
				characterController._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
				characterController.IsFollowerSharingPassives = true;
				int maxWeaponCount = ((CharacterController)this)._maxWeaponBonus + ((CharacterController)this)._maxWeaponCount;
				characterController._maxWeaponCount = maxWeaponCount;
				HealthBar healthBar = RenderingExtensions.SetScale(characterController._healthBar, 0.00125f);
				return;
			}
		}
		throw new InvalidCastException();
	}

	public EME_CharacterControllerBonnie()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
