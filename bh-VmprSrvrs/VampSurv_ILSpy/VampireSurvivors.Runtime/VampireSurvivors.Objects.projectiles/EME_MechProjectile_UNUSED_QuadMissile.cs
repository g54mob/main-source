using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MechProjectile_UNUSED_QuadMissile : EME_MechProjectile_BallisticMissile
{
	protected override float Radius => 16f;

	protected override float2 SpawnOffset
	{
		get
		{
			float2 result = default(float2);
			return result;
		}
	}

	protected override List<float> SpawnAngles
	{
		get
		{
			//IL_0028: Expected O, but got I
			//IL_0082: Expected O, but got I
			//IL_02b7: Expected O, but got I
			//IL_0116: Expected O, but got I
			//IL_02ed: Expected O, but got I
			//IL_01ae: Expected O, but got I
			//IL_0315: Expected O, but got I
			//IL_0246: Expected O, but got I
			List<float> list = new List<float>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v4+18]");
			if (num >= 0)
			{
				list.AddWithResize(45f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj2 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v4+18]");
				if (num2 >= 0)
				{
					goto IL_02bc;
				}
				_ = 1110704128;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v5+18]");
			if (num3 >= 0)
			{
				list.AddWithResize(-45f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj4 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v5+18]");
				if (num4 >= 0)
				{
					goto IL_02bc;
				}
				_ = 3258187776L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
			if (num5 >= 0)
			{
				list.AddWithResize(-135f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj6 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
				if (num6 >= 0)
				{
					goto IL_02bc;
				}
				_ = 3272015872L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v7+18]");
			if (num7 >= 0)
			{
				list.AddWithResize(135f);
				return list;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v7+18]");
			if (num8 < 0)
			{
				_ = 1124532224;
				return list;
			}
			goto IL_02bc;
			IL_02bc:
			return (List<float>)(object)new IndexOutOfRangeException();
		}
	}

	protected override float TurnSpeed => 410f;

	protected override float TurnDuration => 500f;

	protected override float TurnDelay
	{
		get
		{
			//IL_0006: Expected F4, but got I4
			return 0f;
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
	}

	protected override void SetMovementPattern()
	{
		base._isTurning = true;
		float turnDuration = TurnDuration;
		Action onComplete = delegate
		{
			base._isDecelerating = false;
			base._isAccelerating = true;
			Action onComplete2 = delegate
			{
				Despawn();
			};
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer expireTimer = Timers.Register(1f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
		};
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer movementTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_movementTimer = movementTimer;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
	}

	private void _003CSetMovementPattern_003Eb__13_0()
	{
		base._isDecelerating = false;
		base._isAccelerating = true;
		Action onComplete = delegate
		{
			Despawn();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private void _003CSetMovementPattern_003Eb__13_1()
	{
		Despawn();
	}
}
