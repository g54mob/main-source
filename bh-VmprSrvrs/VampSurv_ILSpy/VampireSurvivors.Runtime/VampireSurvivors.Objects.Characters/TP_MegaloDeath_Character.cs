using System;
using System.Runtime.CompilerServices;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class TP_MegaloDeath_Character : TP_Death_Character
{
	private bool firstUpdateDone;

	protected override void OnUpdate()
	{
		//IL_005c: Invalid comparison between F4 and O
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		OnUpdate();
		if (!((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
			float num = core._003CSurvivedSeconds_003Ek__BackingField;
			object obj = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			bool flag2 = !flag;
			object obj2 = (_003F?)stageModifiers._003CTimeLimit_003Ek__BackingField & flag2;
			if (obj2 != null)
			{
				PlayerModifierStats playerStats = _playerStats;
				playerStats._003CRevivals_003Ek__BackingField.Val = 0.0;
				TakeDamage(((CharacterController)this)._currentHp);
			}
		}
		if (base._isMorphed)
		{
			UpdateMegaloDeathParts();
		}
		if (!firstUpdateDone && _isInitialized)
		{
			firstUpdateDone = true;
			Morph(addBonusStats: false);
		}
	}
}
