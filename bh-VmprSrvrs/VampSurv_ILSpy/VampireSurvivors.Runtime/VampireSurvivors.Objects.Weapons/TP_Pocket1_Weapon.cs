using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Pocket1_Weapon : Weapon
{
	private const float BaseOffsetY = 0.16f;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0119: Expected F4, but got I4
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0157: Invalid comparison between O and F4
		//IL_002c: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		float num = base.PAmount();
		object obj = default(object);
		if ((nint)obj > 0)
		{
			object obj2 = 0;
			object obj3 = 0;
			bool flag;
			do
			{
				float num2 = (float)obj3 * 0.5f;
				double num3 = Math.Ceiling(num2);
				object obj4 = obj2 & 1;
				object obj5 = obj4 * 2;
				object obj6 = obj5 - 1;
				double num4 = num3 * 0.07999999821186066;
				float offsetPos = (float)obj6 * (float)num4;
				Vector2 projectilePosition = GetProjectilePosition(offsetPos);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				obj2++;
				float num5 = base.PAmount();
				flag = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref projectilePosition) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
				obj3 = obj2;
			}
			while (flag);
		}
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Culter, 200f, 10, 0f, volume, rate, detune, loop, 1f);
		float num6 = base.PInterval();
		float num7 = _lastFiringInterval - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj7 = num7 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num8 = base.PInterval();
			_lastFiringInterval = 1f;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private Vector2 GetProjectilePosition(float offsetPos)
	{
		//IL_0046: Expected O, but got I
		//IL_010c: Expected I, but got O
		//IL_0129: Expected O, but got I4
		//IL_00d6: Expected O, but got I8
		//IL_00c4: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Vector2 lastMovementDirection = characterController._lastMovementDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187456850h\"");
			if ((object)characterController._lastMovementDirection == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187456850h\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
				if ((nint)0 == 0)
				{
					lastMovementDirection = characterController._lastFacingDirection;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
					obj = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			nint num = (nint)this;
			float num2 = base.PArea();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			object obj2 = 1;
			if (!characterController._isFlipped)
			{
				obj2 = 4294967295L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Vector2 result = default(Vector2);
				return result;
			}
		}
		return (Vector2)new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
	}
}
