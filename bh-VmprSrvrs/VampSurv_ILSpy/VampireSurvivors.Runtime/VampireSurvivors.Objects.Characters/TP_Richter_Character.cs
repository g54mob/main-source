using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class TP_Richter_Character : TP_Character
{
	public override void AfterFullInitialization()
	{
		//IL_004c: Expected O, but got I
		//IL_00a6: Expected O, but got I
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 9;
		}
		GameManager core2 = GM.Core;
		core2._arcanaManager.TriggerArcana(ArcanaType.T09_DIVINE);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		int num2 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
		arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num2;
	}

	public override void OnMeleeAttackAnim()
	{
		//IL_0060: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5E88]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_meleeAnim != null && !((CharacterController)this)._isAnimForced && !(((CharacterController)this)._walked > 0f))
		{
			SpriteAnimation spriteAnimation = _spriteAnimation;
			((CharacterController)this)._isAnimForced = true;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			_spriteAnimation.SetAnimation("meleeA");
			_currentAnimation = CharAnimationType.melee;
		}
	}
}
