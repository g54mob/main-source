using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class EX_Ammo2Projectile_Gunastrophe : Projectile
{
	private Timer _fadeOutTimer;

	private Timer _despawnTimer;

	private Bounds _cameraBounds;

	private Tween _damageOnlyTimer;

	private MultiTargetTween _scaleTween;

	private const int _fps = 60;

	private const double _frameTime = 1.0 / 60.0;

	private const double _frameTimeMS = 16.666666666666668;

	private double _elapsed;

	private bool _aftershockDamageMovement;

	private Ex_Ammo2Weapon _ammo2Weapon;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_cameraBounds = (Bounds)CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v8 (UnityEngine.Bounds)+10]");
		_ = 0;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_05cc: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_01f8: Expected I, but got O
		//IL_0266: Expected F4, but got I
		//IL_0693: Expected I4, but got O
		//IL_0501: Expected O, but got I4
		//IL_055d: Expected F4, but got I4
		//IL_0652->IL0567: Incompatible stack heights: 1 vs 0
		//IL_03e0->IL0567: Incompatible stack heights: 1 vs 0
		//IL_0529->IL0567: Incompatible stack heights: 6 vs 0
		base.InitProjectile(pool, weapon, index);
		float? ammo2Weapon;
		if ((object)weapon == null)
		{
			ammo2Weapon = (float?)(object)0;
			goto IL_05a5;
		}
		nint num = (nint)typeof(Ex_Ammo2Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v46 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v46 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v121+FFFFFFF8+v71 @ rax_v116*8]");
			if (0 == (nint)typeof(Ex_Ammo2Weapon))
			{
				obj3 = 1;
				goto IL_05b4;
			}
		}
		obj3 = 0;
		goto IL_05b4;
		IL_02e7:
		Weapon weapon2 = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				if (!characterController._isFlipped)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Ammo2Projectile_Gunastrophe)+EC]");
					float num4 = 0f * 2f;
				}
				if ((object)_weapon != null)
				{
					Transform transform = _weapon.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						if ((object)_weapon != null)
						{
							Transform transform2 = _weapon.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
								int num5 = (int)_cachedTransform;
								bool flag3 = (object)_cachedTransform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rbp_v14 (System.Int32)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rbp_v14 (System.Int32)+10]");
								Transform.set_position_Injected((IntPtr)0, ref ret);
								bool flag5 = (object)_ammo2Weapon == null;
								_ammo2Weapon.EmitParticles(15);
								if (_fadeOutTimer != null)
								{
									_fadeOutTimer.Cancel();
								}
								bool flag6 = (object)_weapon == null;
								float num6 = _weapon.PDuration();
								Action onComplete = delegate
								{
									BaseBody baseBody2 = body;
									baseBody2._enable = false;
									Despawn();
								};
								object obj4 = default(object);
								float num7 = (float)obj4 * 0.001f;
								bool flag7 = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer fadeOutTimer = Timers.Register(num7, onComplete, null, isLooped: false, flag7, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								_fadeOutTimer = fadeOutTimer;
								if (_indexInWeapon != 0)
								{
									return;
								}
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
								{
									Volume = (float?)(object)1,
									Rate = 1f
								};
								if ((object)_weapon != null)
								{
									float num8 = _weapon.PDuration();
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.EX_Ammo2_Gunastrophe_SFX, soundConfig, num7, 1, flag7 ? 1 : 0);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0567;
		IL_05a5:
		_ammo2Weapon = (Ex_Ammo2Weapon)ammo2Weapon;
		if ((object)_renderer != null)
		{
			_renderer.enabled = false;
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
			BaseBody baseBody = body;
			if (body != null)
			{
				baseBody._enable = true;
				_isCullable = false;
				_aftershockDamageMovement = false;
				if (_scaleTween != null)
				{
					_scaleTween.Restart();
					goto IL_02e7;
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if (array != null)
				{
					if ((object)_cachedTransform != null)
					{
						nint num9 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj5 = default(object);
						if (obj5 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Ammo2Projectile_Gunastrophe)+EC]");
						float num4 = 0f;
						_ = 1140457472;
						_ = 1;
						TweenCallback tweenCallback = HandleAftershockDamage;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						if (multiTargetTween != null)
						{
							MultiTargetTween scaleTween = multiTargetTween.SetAutoKill(autoKill: false);
							_scaleTween = scaleTween;
							goto IL_02e7;
						}
					}
				}
			}
		}
		goto IL_0567;
		IL_05b4:
		bool flag8 = obj3 == null;
		ammo2Weapon = (float?)(object)0;
		if (!flag8)
		{
			ammo2Weapon = (float?)weapon;
		}
		goto IL_05a5;
		IL_0567:
		throw new NullReferenceException();
	}

	private void HandleAftershockDamage()
	{
		//IL_0010: Expected O, but got I4
		object obj = _indexInWeapon + 1;
		float num = _weapon.PAmount();
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		}
		else
		{
			_aftershockDamageMovement = true;
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0560: Expected I, but got O
		//IL_0580: Expected O, but got I
		//IL_01e5: Expected I, but got I8
		//IL_05da: Expected O, but got Ref
		//IL_020e: Expected O, but got I
		//IL_061f: Expected O, but got I4
		//IL_03f8: Expected O, but got Ref
		//IL_0288: Expected I4, but got I8
		//IL_0288: Expected O, but got I
		//IL_0288: Expected O, but got I
		//IL_029c: Expected O, but got I
		//IL_0654: Expected O, but got I4
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02fd: Expected F4, but got I
		//IL_0689: Expected O, but got I
		//IL_0461: Expected O, but got Ref
		//IL_0322: Expected O, but got I
		//IL_0506: Expected O, but got Ref
		//IL_0519: Expected O, but got I
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Expected O, but got Unknown
		//IL_06b4: Expected O, but got F4
		//IL_0704: Expected O, but got I4
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0711: Expected O, but got Unknown
		//IL_0152: Expected O, but got I
		//IL_016b: Expected O, but got I
		//IL_01ea->IL071f: Incompatible stack heights: 1 vs 0
		//IL_022e->IL0378: Incompatible stack heights: 1 vs 0
		//IL_0258->IL0378: Incompatible stack heights: 2 vs 0
		//IL_0424->IL0378: Incompatible stack heights: 1 vs 0
		//IL_0674->IL0378: Incompatible stack heights: 2 vs 0
		//IL_012d->IL0378: Incompatible stack heights: 1 vs 0
		//IL_0178->IL04f8: Incompatible stack heights: 4 vs 5
		//IL_071f->IL035a: Incompatible stack heights: 5 vs 6
		//IL_0378->IL06aa: Incompatible stack heights: 6 vs 5
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float num7 = default(float);
		if (!_aftershockDamageMovement)
		{
			Weapon weapon = _weapon;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					bool flag = !characterController._isFlipped;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Ammo2Projectile_Gunastrophe)+F4]");
					_ = 0;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Ammo2Projectile_Gunastrophe)+EC]");
						_ = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Ammo2Projectile_Gunastrophe)+EC]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Ammo2Projectile_Gunastrophe)+EC]");
						float num = 0f * 2f;
					}
					if ((object)_weapon != null)
					{
						Transform transform = _weapon.transform;
						if ((object)transform != null)
						{
							_ = 0;
							_ = 0;
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
							if ((object)_weapon != null)
							{
								Transform transform2 = _weapon.transform;
								if ((object)transform2 != null)
								{
									_ = 0;
									_ = 0;
									bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
									Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj4);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Ammo2Projectile_Gunastrophe)+F0]");
									float num2 = 0f * 2f;
									float num3 = num2 * -0.5f;
									object cachedTransform = _cachedTransform;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B]");
									float num4 = 0f - num3;
									bool flag4 = (object)_cachedTransform == null;
									_ = 1f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rsi_v28 (System.Object)+10]");
									bool flag5 = (nint)0 == 0;
									object obj5 = 0;
									float num5 = 1f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rsi_v28 (System.Object)+10]");
									object obj6 = 0;
									float num6 = num7;
									goto IL_04f8;
								}
							}
						}
					}
				}
			}
		}
		else if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			Transform cachedTransform2 = _cachedTransform;
			nint num8 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rax_v58 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj7 = 0;
			_ = Vector3.oneVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag6 = obj7 == null;
				num9 = unchecked((nint)6573110936L);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v348 @ rax_v60 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B]");
			float num4 = 0f * 75f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v52 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num10 = 0f * 75f;
			bool flag7 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Vector3*)obj8);
			Transform ammo2Weapon = (Transform)(object)_ammo2Weapon;
			object cachedTransform3 = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v24 (UnityEngine.Transform)+168]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v24 (UnityEngine.Transform)+168]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r14_v23+18]");
				object obj10 = UnityEngine.Random.RandomRangeInt(0, 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r14_v23+18]");
				bool flag8 = (nint)obj10 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r14_v23+20+v973 @ rax_v68*8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r14_v23+20+v973 @ rax_v68*8]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v24 (UnityEngine.Transform)+180]");
					int particles = ((ParticleSystem)num11).GetParticles((ParticleSystem.Particle[])0, -1, 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v24 (UnityEngine.Transform)+180]");
					Transform transform3 = (Transform)0;
					object obj11 = UnityEngine.Random.RandomRangeInt(0, particles);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdi_v24 (UnityEngine.Transform)+180]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v25 (UnityEngine.Transform)+18]");
						bool flag9 = (nint)obj11 >= 0;
						object obj12 = obj11 * 132;
						bool flag10 = (object)_cachedTransform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v75+20+v127 @ rdi_v25 (UnityEngine.Transform)]");
						float num6 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v75+20+v127 @ rdi_v25 (UnityEngine.Transform)]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v75+28+v127 @ rdi_v25 (UnityEngine.Transform)]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rsi_v25 (System.Object)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rsi_v25 (System.Object)+10]");
						bool flag11 = (nint)0 == 0;
						object obj5 = 0;
						bool flag12 = (nint)0 != 0;
						float num5 = num7;
						if (!flag12)
						{
							bool flag13 = (nint)0 == 0;
							goto IL_035a;
						}
						goto IL_04f8;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_035a:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm0\"");
		_elapsed = 0.0;
		return;
		IL_04f8:
		object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1470 @ rax_v41 (should have been resolved before IL gen)");
		object obj14 = (nint)0 ^ (nint)0;
		object obj15 = 0 & obj14;
		bool flag14 = (nint)obj15 < 0;
		bool flag15 = (nint)0 < (nint)0;
		bool flag16 = (nint)0 == 0;
		object obj16 = Time.deltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A109F8h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		_elapsed = 0.0;
		bool flag17 = flag15 == flag14;
		object obj17 = !flag16;
		object obj18 = flag17 & obj17;
		if (obj18 != null)
		{
			return;
		}
		goto IL_035a;
	}

	public override void Despawn()
	{
		_aftershockDamageMovement = false;
		_isCullable = true;
		if (_scaleTween != null)
		{
			_scaleTween.Pause();
		}
		base.Despawn();
	}

	private void Shoot()
	{
		_ammo2Weapon.EmitParticles(15);
		if (_fadeOutTimer != null)
		{
			_fadeOutTimer.Cancel();
		}
		float num = _weapon.PDuration();
		Action onComplete = delegate
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
			Despawn();
		};
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer fadeOutTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_fadeOutTimer = fadeOutTimer;
	}

	private void _003CShoot_003Eb__16_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		Despawn();
	}
}
