using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_PlaneProjectile : Projectile
{
	[NonSerialized]
	public Timer timerEvent;

	[NonSerialized]
	public float angleOffset = 140f;

	private float _targetAngle;

	public float _dist;

	public float _width;

	public float2 drift;

	public Timer driftTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Flame1", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0033: Expected F4, but got I4
		//IL_007b: Expected I4, but got F4
		//IL_007b: Expected O, but got F4
		//IL_007b: Expected I4, but got O
		base.InitProjectile(pool, weapon, index);
		float num = _width * 0.5f;
		_isCullable = false;
		float num2 = 180f - num;
		object obj = index * _width;
		float targetAngle = num2 + (float)obj;
		_targetAngle = targetAngle;
		float? num3 = default(float?);
		float num4 = default(float);
		float num5 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_HomingShot, 100f, 12, 0f, num3, num4, num5, flag, 1f);
		Action onComplete = delegate
		{
			//IL_0010: Expected O, but got I
			//IL_00ec: Expected O, but got I
			//IL_0138: Expected O, but got F4
			//IL_0076: Expected O, but got I8
			//IL_00b4: Expected O, but got I8
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag2 = (nint)0 != 0;
			FB_PlaneProjectile fB_PlaneProjectile = this;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				fB_PlaneProjectile = (FB_PlaneProjectile)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46 @ rax_v5 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				fB_PlaneProjectile = (FB_PlaneProjectile)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v88 @ rax_v8 (should have been resolved before IL gen)");
			drift = (float2)(-0.099999994f);
			_ = -0.099999994f;
		};
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: true, (byte)(int)num3 != 0, (MonoBehaviour)num4, (int)num5, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		driftTimer = timer;
	}

	public override void InternalUpdate()
	{
		//IL_0198: Expected O, but got I4
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		setVelocity(0f, (float?)(object)1);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v5 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		float num = 0f * 57.29578f;
		float num2 = num + _targetAngle;
		float num3 = num2 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num4 = num2 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num5 = num + angleOffset;
		base.angle = num5;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		float2 float6 = base.position;
		float deltaTime = PauseSystem.DeltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9520");
		float2 float7 = default(float2);
		object obj = (object)bounds.m_Center - (object)float7;
		object obj2 = (object)float7 + (object)bounds.m_Center;
		object obj3 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v13 (UnityEngine.Bounds)+10]");
		object obj4 = float7 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v13 (UnityEngine.Bounds)+10]");
		object obj5 = 0 + float7;
		if ((nint)obj4 > 0 || 0 > (nint)obj5)
		{
		}
		base.position = float7;
	}

	public override void Despawn()
	{
		base.Despawn();
		if (timerEvent != null)
		{
			timerEvent.Cancel();
		}
		if (driftTimer != null)
		{
			driftTimer.Cancel();
		}
	}

	public FB_PlaneProjectile()
	{
		_ = 0;
		_targetAngle = 140f;
		_dist = 0.79999995f;
		_width = 60f;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__8_0()
	{
		//IL_0010: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0138: Expected O, but got F4
		//IL_0076: Expected O, but got I8
		//IL_00b4: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		FB_PlaneProjectile fB_PlaneProjectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			fB_PlaneProjectile = (FB_PlaneProjectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46 @ rax_v5 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			fB_PlaneProjectile = (FB_PlaneProjectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v88 @ rax_v8 (should have been resolved before IL gen)");
		drift = (float2)(-0.099999994f);
		_ = -0.099999994f;
	}
}
