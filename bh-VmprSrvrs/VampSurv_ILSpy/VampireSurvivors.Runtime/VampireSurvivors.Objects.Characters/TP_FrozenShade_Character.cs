using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_FrozenShade_Character : TP_Character
{
	private TP_SoulSteal_Weapon soulStealWeapon;

	private Timer animTimer;

	private float OverhealTriggerValue = 32f;

	public override void AfterFullInitialization()
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected I4, but got O
		//IL_00c7: Expected O, but got I4
		//IL_00c7: Expected I4, but got O
		base.AfterFullInitialization();
		Vector2 pivot = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_FrozenShade_a", 1, 9, pivot, text, num, flag);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_FrozenShade_a", 10, 12, pivot, text, num, flag);
		Action action = PlayAnimLoop;
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("ConeOfCold", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		_spriteAnimation.AddAnimation("ConeOfColdLoop", animationFrames2, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, b);
		bool flag2 = (object)obj == null;
		Action<float, float> onHpRecoveryCallback = null;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<float, float> action2 = default(Action<float, float>);
			bool flag3 = action2 == null;
			onHpRecoveryCallback = action2;
			if (flag3)
			{
				throw new InvalidCastException();
			}
		}
		((CharacterController)this)._onHpRecoveryCallback = onHpRecoveryCallback;
		base.SetBloodColor(8947967u);
	}

	private void PlayAnimLoop()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5E23]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_spriteAnimation.SetAnimation("ConeOfColdLoop");
	}

	protected override void OnStop()
	{
	}

	private void ConeOfCold(float value, float rawValue)
	{
		//IL_0144: Expected I, but got O
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		float num = rawValue - value;
		if (num < OverhealTriggerValue)
		{
			return;
		}
		float num2 = base.PDuration();
		float num3 = 0f * 10000f;
		Weapon weaponByType = ((CharacterController)this)._weaponsManager.GetWeaponByType(WeaponType.CONEOFCOLD, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			float num4 = weaponByType._003CTotalTime_003Ek__BackingField - 10000f;
			bool flag = -60000f > num4;
			float num5 = -60000f;
			if (!flag)
			{
				num5 = num4;
			}
			weaponByType._003CTotalTime_003Ek__BackingField = num5;
			float num6 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj = num6 & 0;
			num3 += (float)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD570");
		}
		((CharacterController)this)._isAnimForced = true;
		_spriteAnimation.SetAnimation("ConeOfCold");
		if (animTimer != null)
		{
			animTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_FrozenShade_Character>)+6D0]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num7 = (nint)this;
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		animTimer = timer;
	}

	public override void ClearFromSpecialAnims()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5E25]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((CharacterController)this)._isAnimForced = false;
		if (!_hasIdleAnimation)
		{
			_spriteAnimation.SetAnimation("walk");
			_currentAnimation = CharAnimationType.walk;
		}
		else
		{
			_spriteAnimation.SetAnimation("idle");
			_currentAnimation = CharAnimationType.idle;
		}
	}
}
