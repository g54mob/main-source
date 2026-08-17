using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerMiang : CharacterController
{
	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
	}

	public override void RecoverHp(float value, bool showRecovery = false, bool mulByRegen = false)
	{
		//IL_0421->IL0300: Incompatible stack heights: 1 vs 0
		//IL_0300->IL0329: Incompatible stack heights: 1 vs 0
		if (base._isDead || base.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		float num = base.PRegen();
		float num3 = default(float);
		float num2 = num3 + 1f;
		float num5 = default(float);
		float num4 = num2 * num5;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			ArcanaManager arcanaManager = core._arcanaManager;
			if (core._arcanaManager != null && arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
				object obj = default(object);
				if (obj != null)
				{
					num3 = num4 + num4;
					num4 = num3;
				}
				GameManager gameManager = _gameManager;
				if ((object)_gameManager != null && gameManager._arcanaManager != null)
				{
					gameManager._arcanaManager.OnPlayerHPRecovery(this, num4);
					Action<float, float> onHpRecoveryCallback = base._onHpRecoveryCallback;
					if (base._onHpRecoveryCallback != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v504 @ rax_v19 (System.Action`2<System.Single, System.Single>)+18] (should have been resolved before IL gen)");
						num5 = num4;
					}
					float num6 = (base._currentHp = num4 + base._currentHp);
					float num7 = base.MaxHp();
					if (!(num6 > num3))
					{
						goto IL_0426;
					}
					float num8 = base.MaxHp();
					PlayerModifierStats playerStats = _playerStats;
					base._currentHp = num3;
					if (_playerStats != null)
					{
						EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
						if (playerStats._003CMaxHp_003Ek__BackingField != null)
						{
							float value2 = default(float);
							EggFloat maxHp = new EggFloat(value2, eggFloat._eggVal);
							value2 = eggFloat._val + 0.2f;
							_playerStats.MaxHp = maxHp;
							num5 = value2;
							goto IL_0426;
						}
					}
				}
			}
		}
		goto IL_0300;
		IL_0426:
		bool flag = !(9000f > num4);
		float num9 = 9000f;
		if (!flag)
		{
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null && core2._playerOptions != null)
			{
				PlayerOptionsData config = core2._playerOptions.Config;
				if (config != null)
				{
					num9 = num4 + config._003CLifetimeHeal_003Ek__BackingField;
					config._003CLifetimeHeal_003Ek__BackingField = num9;
					goto IL_03b9;
				}
			}
			goto IL_0300;
		}
		goto IL_03b9;
		IL_03b9:
		if (!showRecovery)
		{
			return;
		}
		object cachedTransform = base._cachedTransform;
		if ((object)base._cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rbx_v8 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rbx_v8 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			if ((object)GM.Core != null)
			{
				Vector2 pos = default(Vector2);
				GM.Core.ShowRecoveryAt(pos, num4);
				return;
			}
		}
		goto IL_0300;
		IL_0300:
		throw new NullReferenceException();
	}
}
