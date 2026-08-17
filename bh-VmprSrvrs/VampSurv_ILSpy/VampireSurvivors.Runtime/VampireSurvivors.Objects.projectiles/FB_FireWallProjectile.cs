using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_FireWallProjectile : Projectile
{
	private const float Radius = 0.25f;

	private float _spacer = 0.4f;

	private float _timer;

	private int _counter;

	private Timer _flameTimerEvent;

	private Timer _completeTimerEvent;

	private float2 _originalPos;

	private float2 _direction;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_01b7: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0031: Expected I, but got O
		//IL_004d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		_timer = 0f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		nint num = (nint)weapon;
		float num2 = weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		float2 originalPos = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		_originalPos = originalPos;
		_ = 3238002688L;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		float2 direction = default(float2);
		_direction = direction;
		_ = 3238002688L;
		Action onComplete = delegate
		{
			//IL_0013: Expected I, but got O
			//IL_001b: Expected I, but got O
			//IL_002b: Expected O, but got I
			//IL_0067: Expected O, but got I
			//IL_00a4: Expected O, but got I
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Expected O, but got Unknown
			Weapon weapon2 = _weapon;
			float2 pos = base.position;
			nint num4 = (nint)typeof(FB_FireWallWeapon);
			nint num5 = (nint)weapon2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_FireWallWeapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_FireWallWeapon>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v6+FFFFFFF8+v48 @ rax_v5*8]");
				if (0 == (nint)typeof(FB_FireWallWeapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_FireWallWeapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v6+FFFFFFF8+v90 @ rcx_v5*8]");
					object obj4 = 0 - typeof(FB_FireWallWeapon);
					bool flag = obj4 == null;
					bool flag2 = !flag;
					FB_FireWallWeapon fB_FireWallWeapon = null;
					if (!flag2)
					{
						fB_FireWallWeapon = (FB_FireWallWeapon)weapon2;
					}
					fB_FireWallWeapon.addFlameSprite(pos);
					return;
				}
			}
			throw new NullReferenceException();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer flameTimerEvent = Timers.Register(0.05f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_flameTimerEvent = flameTimerEvent;
		float num3 = _weapon.PDuration();
		Action onComplete2 = delegate
		{
			_flameTimerEvent.Cancel();
			Despawn();
		};
		float duration = 0.05f * 0.001f;
		Timer completeTimerEvent = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_completeTimerEvent = completeTimerEvent;
	}

	private void updateFlamePos()
	{
		//IL_0017: Expected I, but got O
		//IL_0053: Invalid comparison between F4 and I
		//IL_00c4: Invalid comparison between F4 and I4
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0083: Expected F4, but got I
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		float num2 = weapon.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num3 = _weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile)+FC]");
		bool flag = !(4.5f > 0f);
		float num4 = 4.5f;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile)+FC]");
			num4 = 0f;
		}
		object obj = default(object);
		float num5 = (float)obj - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187064E5Ch\"");
		if (num4 == 0f)
		{
			num4 = 0.0001f;
		}
		float num6 = num5 * 0.5f;
		float num7 = num6 * _spacer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = num7 ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm9,dword ptr [rbx+70h]\"");
		float num8 = num4 * 0.25f;
		object obj3 = 0 * _spacer;
		float num9 = _timer * _timer;
		object obj4 = obj3 + obj2;
		float num10 = num9 + 1f;
		float num11 = (float)obj4 * 57.29578f;
		float num12 = num10 * num8;
		float num13 = num11 / 360f;
		float num14 = num8 * ((float)Math.PI * 2f);
		float num15 = num12 * ((float)Math.PI * 2f);
		float num16 = num13 * num14;
		float num17 = num16 * 360f;
		float num18 = num17 / num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		float num19 = num18 * ((float)Math.PI / 180f);
		float num20 = num12 - 0.25f;
		float num21 = num19;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile)+FC]");
		float num22 = num21 + 0f;
		object obj5 = default(object);
		float num23 = (float)obj5 * num20;
		object obj6 = default(object);
		float num24 = (float)obj6 * num20;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 float5 = default(float2);
		base.position = float5;
	}

	public override void InternalUpdate()
	{
		//IL_00fc: Expected O, but got F4
		float deltaTime = PauseSystem.DeltaTime;
		float num = _weapon.PSpeed();
		float num2 = deltaTime * deltaTime;
		float timer = num2 + _timer;
		_timer = timer;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num3 = (float)_direction * deltaTime2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile)+FC]");
		float num4 = 0f * deltaTime2;
		float num5 = _weapon.PSpeed();
		float num6 = num3 * deltaTime2;
		float num7 = num4 * deltaTime2;
		float num8 = num6 * 0.5f;
		float num9 = num7 * 0.5f;
		float num10 = num8 + (float)_originalPos;
		float num11 = num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_FireWallProjectile)+F4]");
		float num12 = num11 + 0f;
		_originalPos = (float2)num10;
		updateFlamePos();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	public void manuallySetDirection(float2 direction)
	{
		_direction = direction;
	}

	public void manuallySetOriginalPos(float2 originalPos)
	{
		_originalPos = originalPos;
	}

	public override void Despawn()
	{
		if (_flameTimerEvent != null)
		{
			_flameTimerEvent.Cancel();
		}
		if (_completeTimerEvent != null)
		{
			_completeTimerEvent.Cancel();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		Weapon weapon = _weapon;
		float2 pos = base.position;
		nint num = (nint)typeof(FB_FireWallWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_FireWallWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_FireWallWeapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v6+FFFFFFF8+v48 @ rax_v5*8]");
			if (0 == (nint)typeof(FB_FireWallWeapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_FireWallWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v6+FFFFFFF8+v90 @ rcx_v5*8]");
				object obj4 = 0 - typeof(FB_FireWallWeapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				FB_FireWallWeapon fB_FireWallWeapon = null;
				if (!flag2)
				{
					fB_FireWallWeapon = (FB_FireWallWeapon)weapon;
				}
				fB_FireWallWeapon.addFlameSprite(pos);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__9_1()
	{
		_flameTimerEvent.Cancel();
		Despawn();
	}
}
