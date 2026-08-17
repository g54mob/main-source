using System;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class TP_Jonhathan_And_Charlotte_Character : TP_Jonhathan_Character
{
	private bool _spawnFollowerNextFrame;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		_spawnFollowerNextFrame = true;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (_spawnFollowerNextFrame)
		{
			_spawnFollowerNextFrame = false;
			bool manualLevelups = default(bool);
			int everyXLevels = default(int);
			bool spawnWithoutAuthority = default(bool);
			CharacterController characterController = GM.Core.AddFollower(CharacterType.TP_CHARLOTTE, this, AIType.Defensive, manualLevelups, everyXLevels, spawnWithoutAuthority);
			if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				characterController._003CTrackedByCamera_003Ek__BackingField = true;
				characterController.SetPermanentInvulnerability(on: true);
				characterController._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
				int maxWeaponCount = ((CharacterController)this)._maxWeaponBonus + ((CharacterController)this)._maxWeaponCount;
				characterController._maxWeaponCount = maxWeaponCount;
				HealthBar healthBar = RenderingExtensions.SetScale(characterController._healthBar, 0.00125f);
			}
		}
	}
}
