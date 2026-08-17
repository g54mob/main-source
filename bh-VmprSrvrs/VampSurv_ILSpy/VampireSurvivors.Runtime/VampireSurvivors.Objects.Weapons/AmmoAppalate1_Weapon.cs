using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class AmmoAppalate1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public AmmoAppalate1_Weapon _003C_003E4__this;

		public float2 target;

		public double projectilesPerBlast;
	}

	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public int i;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

		internal void _003COnBeatFire_003Eb__0()
		{
			_003C_003Ec__DisplayClass21_0 obj = CS_0024_003C_003E8__locals1;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj._003C_003E4__this.FireOneProjectile(pos, i);
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_2
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals2;

		internal unsafe void _003COnBeatFire_003Eb__1()
		{
			//IL_017c: Expected O, but got I4
			//IL_00a1: Expected I, but got O
			//IL_00b7: Expected O, but got I
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			//IL_012e: Expected I, but got O
			//IL_028a: Expected O, but got I4
			//IL_02a1: Expected I, but got I8
			//IL_0117: Expected I, but got I8
			//IL_026e: Expected F4, but got I4
			_003C_003Ec__DisplayClass21_3 obj = new _003C_003Ec__DisplayClass21_3();
			obj.CS_0024_003C_003E8__locals3 = this;
			obj.i = 0;
			_003C_003Ec__DisplayClass21_0 obj2;
			bool flag = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				obj2 = CS_0024_003C_003E8__locals2;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
				if ((nint)CS_0024_003C_003E8__locals2 <= 0)
				{
					break;
				}
				Action action = null;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v4 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass21_3._003COnBeatFire_003Eb__2);
				((Delegate)action).m_target = obj;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v4 (Il2CppMethodInfo)+4C]");
				object obj3 = (nint)0 >> 4;
				object obj4 = obj3 & 1;
				nint num2;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v4 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num2 = unchecked((nint)6447293664L);
						goto IL_0281;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num2 = ((Delegate)action).method_ptr;
				goto IL_0281;
				IL_0281:
				object obj5 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				float num3 = (float)obj.i * 16f;
				float duration = num3 * 0.001f;
				Timer timer = Timers.Register(duration, action, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				int i = obj.i + 1;
				obj.i = i;
			}
			AmmoAppalate1_Weapon ammoAppalate1_Weapon = obj2._003C_003E4__this;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			_003C_003Ec__DisplayClass21_0 obj6 = CS_0024_003C_003E8__locals2;
			AmmoAppalate1_Weapon ammoAppalate1_Weapon2 = obj6._003C_003E4__this;
			AmmoAppalate1_Weapon ammoAppalate1_Weapon3 = obj6._003C_003E4__this;
			float[] detuneValues = ammoAppalate1_Weapon2._detuneValues;
			int sfxIndex = ammoAppalate1_Weapon3._sfxIndex + 1;
			ammoAppalate1_Weapon3._sfxIndex = sfxIndex;
			_003C_003Ec__DisplayClass21_0 obj7 = CS_0024_003C_003E8__locals2;
			AmmoAppalate1_Weapon ammoAppalate1_Weapon4 = obj7._003C_003E4__this;
			float[] detuneValues2 = ammoAppalate1_Weapon4._detuneValues;
			int num4 = ammoAppalate1_Weapon3._sfxIndex % detuneValues2.Length;
			float detune = detuneValues[num4] * 100f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(ammoAppalate1_Weapon._soundEffect, soundConfig, 100f, 6, flag ? 1 : 0);
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_3
	{
		public int i;

		public _003C_003Ec__DisplayClass21_2 CS_0024_003C_003E8__locals3;

		internal void _003COnBeatFire_003Eb__2()
		{
			_003C_003Ec__DisplayClass21_2 obj = CS_0024_003C_003E8__locals3;
			_003C_003Ec__DisplayClass21_0 obj2 = obj.CS_0024_003C_003E8__locals2;
			int index = obj.localIndex + i;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj2._003C_003E4__this.FireOneProjectile(pos, index);
		}
	}

	protected int _accumulatedActivations;

	private int _sfxIndex;

	private const WeaponType _counterWeaponType = WeaponType.EX_AMMO1_COUNTER;

	private Weapon _counterWeapon;

	public float[] _detuneValues = new float[27]
	{
		1f, 2f, 3f, 1f, 2f, 3f, 1f, 2f, 3f, 4f,
		5f, 6f, 1f, 2f, 3f, 1f, 2f, 3f, 1f, 2f,
		3f, -1f, -2f, -3f, 1f, 2f, 3f
	};

	private Timer _testBeatTimer;

	protected SfxType _soundEffect;

	protected float _soundVolume = 1f;

	protected float _musicBeatInterval = 333f;

	protected float _timeUnit = 41.625f;

	protected float _camOffsetPerc = 0.125f;

	protected float _camSizePerc = 0.75f;

	protected virtual bool _isMirrored => false;

	public virtual bool FireInTheFacedDirection => true;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_explosionType = WeaponType.FIREEXPLOSION;
		Setuppo();
		_accumulatedActivations = 0;
		if (_testBeatTimer != null)
		{
			_testBeatTimer.Cancel();
		}
		Action onComplete = delegate
		{
			OnBeatFire();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer testBeatTimer = TimerHelper.RegisterMillisUI(_musicBeatInterval, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat);
		_testBeatTimer = testBeatTimer;
	}

	protected virtual void Setuppo()
	{
		_soundEffect = SfxType.ExploSoft;
		_musicBeatInterval = 333f;
		_timeUnit = 41.625f;
		_camOffsetPerc = 0.125f;
		_camSizePerc = 0.75f;
	}

	protected virtual float GetProjectilesAmount()
	{
		float num = base.PAmount();
		object obj = default(object);
		return (float)_accumulatedActivations * (float)obj;
	}

	protected virtual float GetTimeUnit()
	{
		float num = (float)((Equipment)this)._003CLevel_003Ek__BackingField * 0.5f;
		return _musicBeatInterval / num;
	}

	public override void Fire(bool skipTriggers = false)
	{
		int accumulatedActivations = _accumulatedActivations + 1;
		_accumulatedActivations = accumulatedActivations;
	}

	public unsafe void OnBeatFire(bool skipTriggers = false)
	{
		//IL_013f: Expected O, but got Ref
		//IL_00d3: Expected O, but got Ref
		//IL_01e2: Expected F4, but got O
		//IL_01f1: Expected I, but got O
		//IL_0209: Expected I, but got O
		//IL_043e: Expected O, but got I4
		//IL_04b1: Expected I, but got O
		//IL_037a: Expected I, but got O
		//IL_0390: Expected O, but got I
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected I4, but got Unknown
		//IL_04d3: Expected F4, but got I4
		//IL_0407: Expected I, but got O
		//IL_0749: Expected O, but got I4
		//IL_0760: Expected I, but got I8
		//IL_08f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fd: Expected O, but got Unknown
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0914: Expected O, but got Unknown
		//IL_0924: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Expected F4, but got Unknown
		//IL_03f0: Expected I, but got I8
		//IL_057f: Expected I, but got O
		//IL_0595: Expected O, but got I
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected O, but got Unknown
		//IL_060c: Expected I, but got O
		//IL_07e3: Expected O, but got I4
		//IL_07fa: Expected I, but got I8
		//IL_0868: Expected O, but got I
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_087d: Expected O, but got Unknown
		//IL_064f: Expected O, but got I4
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Expected O, but got Unknown
		//IL_0664: Expected F4, but got I4
		//IL_05f5: Expected I, but got I8
		_003C_003Ec__DisplayClass21_0 obj = new _003C_003Ec__DisplayClass21_0();
		obj._003C_003E4__this = this;
		if (_accumulatedActivations == 0 || PauseSystem._paused)
		{
			return;
		}
		GameManager core = GM.Core;
		object obj2 = default(object);
		EnemyController enemyController;
		object obj3 = default(object);
		bool flag = default(bool);
		bool flag2;
		if (!IsHoming)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float num = base.PArea();
			if (FireInTheFacedDirection)
			{
			}
			float num2 = (float)obj2 * 1.6f;
			enemyController = core._stage.FindClosestLateralEnemy((Vector3)(&obj3), excludeDead: true, num2, flag);
			float num3 = num2;
			flag2 = false;
			bool flag3 = true;
		}
		else
		{
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float num4 = base.PArea();
			float num5 = (float)obj2 * 1.6f;
			enemyController = core._stage.FindClosestEnemy((Vector3)(&obj3), excludeDead: true, num5);
			float num3 = num5;
			flag2 = false;
			bool flag3 = true;
		}
		if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		BaseBody body = enemyController.body;
		obj.target = body._position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v19 (BaseBody)+54]");
		_ = 0;
		float timeUnit = GetTimeUnit();
		_timeUnit = (float)body._position;
		float projectilesAmount = GetProjectilesAmount();
		nint num6 = (nint)this;
		float num7 = base.PInterval();
		nint num8 = (nint)typeof(Math);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		double num9 = Math.Floor(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm0,xmm8\"");
		double projectilesPerBlast = Math.Floor(0.0);
		obj.projectilesPerBlast = projectilesPerBlast;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F870");
		_accumulatedActivations = (flag2 ? 1 : 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018738512Fh\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v972 @ rcx_v19 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 == 0)
		{
			obj.projectilesPerBlast = 1.0;
		}
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, 0);
		_003C_003Ec__DisplayClass21_1 obj4 = new _003C_003Ec__DisplayClass21_1();
		obj4.CS_0024_003C_003E8__locals1 = obj;
		obj4.i = 1;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rax+20h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
			if ((nint)obj4.CS_0024_003C_003E8__locals1 <= 0)
			{
				break;
			}
			Action action = null;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r10_v9 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass21_1._003COnBeatFire_003Eb__0);
			((Delegate)action).m_target = obj4;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r10_v9 (Il2CppMethodInfo)+4C]");
			object obj5 = (nint)0 >> 4;
			nint num11;
			if ((1 & obj5) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r10_v9 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num11 = unchecked((nint)6447293664L);
					goto IL_0740;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num11 = ((Delegate)action).method_ptr;
			goto IL_0740;
			IL_0740:
			object obj6 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num12 = (float)obj4.i * 16f;
			float duration = num12 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag2);
			int i = obj4.i + 1;
			obj4.i = i;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float[] detuneValues = _detuneValues;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		int num13 = _sfxIndex % detuneValues.Length;
		float num14 = (soundConfig.Detune = detuneValues[num13] * 100f);
		nint num15 = (nint)typeof(SoundManager);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(_soundEffect, soundConfig, 100f, 6, flag ? 1 : 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm8,qword ptr [188A10758h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rcx_v27 (Il2CppClass<VampireSurvivors.Framework.SoundManager>)+E4]");
		bool flag4 = (nint)0 <= (nint)0;
		int num16 = 1;
		if (!flag4)
		{
			object obj14;
			do
			{
				_003C_003Ec__DisplayClass21_2 obj7 = new _003C_003Ec__DisplayClass21_2();
				obj7.CS_0024_003C_003E8__locals2 = obj;
				obj7.localIndex = num16;
				Action action2 = null;
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ r10_v7 (Il2CppMethodInfo)+8]");
				((Delegate)action2).method_ptr = (IntPtr)0;
				((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass21_2._003COnBeatFire_003Eb__1);
				((Delegate)action2).m_target = obj7;
				((Delegate)action2).method_code = (IntPtr)action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ r10_v7 (Il2CppMethodInfo)+4C]");
				object obj8 = (nint)0 >> 4;
				object obj9 = obj8 & 1;
				nint num18;
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ r10_v7 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num18 = unchecked((nint)6447293664L);
						goto IL_07da;
					}
				}
				((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
				num18 = ((Delegate)action2).method_ptr;
				goto IL_07da;
				IL_07da:
				object obj10 = 24;
				((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
				float num19 = (float)num16 * _timeUnit;
				float duration2 = num19 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration2, action2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				object obj11 = num20 ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				object obj12 = 0 & obj11;
				bool flag5 = (nint)obj12 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag6 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag7 = (nint)0 == 0;
				_lastShotTimer = lastShotTimer;
				num16++;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm8,xmm0\"");
				bool flag8 = flag6 == flag5;
				object obj13 = !flag7;
				obj14 = flag8 & obj13;
				num14 = num16;
			}
			while (obj14 != null);
		}
		float num21 = base.PInterval();
		float num22 = num14 - _lastFiringInterval;
		float num23 = num14;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj15 = num23 & 0;
		float lastFiringInterval = _lastFiringInterval;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj16 = lastFiringInterval & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		float num24 = num22 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
		{
			obj16 = obj15;
		}
		float num25 = (float)obj16 * 1E-06f;
		float num26 = Mathf.Epsilon * 8f;
		if (!(num25 > num26))
		{
			num25 = num26;
		}
		if (!(num25 > num24))
		{
			float num27 = base.PInterval();
			_lastFiringInterval = num24;
			base.ResetFiringTimer();
		}
		bool flag9 = default(bool);
		if (!flag9)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public float2 RandomPos()
	{
		//IL_0033: Expected O, but got F4
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj = UnityEngine.Random.value;
		float2 result = default(float2);
		return result;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_testBeatTimer != null)
		{
			_testBeatTimer.Cancel();
		}
	}

	protected unsafe override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_02be: Expected I4, but got O
		//IL_0379: Expected O, but got I4
		//IL_024e: Expected O, but got Ref
		float num2 = default(float);
		if (!base._003CCanCrit_003Ek__BackingField)
		{
			if (first != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null)
				{
					EnemyController component = gameObject.GetComponent<EnemyController>();
					if ((object)component != null)
					{
						if (component._003CIsDead_003Ek__BackingField)
						{
							goto IL_02e0;
						}
						if (second != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							GameObject gameObject2 = default(GameObject);
							if ((object)gameObject2 != null)
							{
								Projectile component2 = gameObject2.GetComponent<Projectile>();
								if ((object)component2 != null)
								{
									if (component2.HasAlreadyHitObject(component))
									{
										goto IL_02e0;
									}
									float num = base.PPower();
									if (!(1f > num2))
									{
										WeaponData currentWeaponData = _currentWeaponData;
										HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
										float knockback = base.Knockback;
										component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
										goto IL_030c;
									}
									float2 position = component.position;
									float num3 = UnityEngine.Random.Range(-0.1f, 0.1f);
									float num4 = UnityEngine.Random.Range(0f, 0.1f);
									if (_playerOptions != null)
									{
										PlayerOptionsData config = _playerOptions.Config;
										if (config != null)
										{
											if (config._003CDamageNumbersEnabled_003Ek__BackingField)
											{
												float2 position2 = component.position;
												if ((object)GameManager.DamageNumberManager == null)
												{
													goto IL_02b0;
												}
												object obj = default(object);
												GameManager.DamageNumberManager.AddBob_Number1((Vector3)(&obj));
											}
											WeaponData currentWeaponData2 = _currentWeaponData;
											HitVfxType showHitVfx2 = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData2._003ChitVFX_003Ek__BackingField);
											float knockback2 = base.Knockback;
											component.GetDamagedSpecial(num2, showHitVfx2, knockback2, WeaponType.VOID, hasKb: false, (Vector3?)(object)0);
											goto IL_030c;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_02b0;
		}
		base.StandardCritical(second, first);
		return false;
		IL_02b0:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_02e0:
		return false;
		IL_030c:
		float num5 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
		base._003CStatsInflictedDamage_003Ek__BackingField = num5;
		goto IL_02e0;
	}

	public override void CheckArcanas()
	{
		//IL_02dc: Expected I, but got O
		//IL_02ea: Expected I, but got O
		//IL_02fa: Expected O, but got I
		//IL_037a: Expected O, but got I4
		//IL_0336: Expected O, but got I
		//IL_036c: Expected O, but got I4
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected I4, but got Unknown
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected I4, but got Unknown
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_03b7: Expected O, but got I4
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan3._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				GameManager gameMan4 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan4._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager4 = core._arcanaManager;
		List<ArcanaType> list4 = arcanaManager4._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj4 = default(object);
		if ((nint)obj4 <= -1)
		{
			goto IL_03da;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(WeaponType.EX_AMMO1_COUNTER, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(WeaponType.EX_AMMO1_COUNTER, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		Weapon counterWeapon;
		if ((object)weapon == null)
		{
			counterWeapon = null;
			goto IL_0417;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(AmmoAppalate1_Weapon_Counter);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v752 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.AmmoAppalate1_Weapon_Counter>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v752 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.AmmoAppalate1_Weapon_Counter>)+130]");
		object obj7;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v50+FFFFFFF8+v753 @ rax_v45*8]");
			if (0 == (nint)typeof(AmmoAppalate1_Weapon_Counter))
			{
				obj7 = 1;
				goto IL_0426;
			}
		}
		obj7 = 0;
		goto IL_0426;
		IL_0426:
		bool flag = obj7 == null;
		counterWeapon = null;
		if (!flag)
		{
			counterWeapon = weapon;
		}
		goto IL_0417;
		IL_03da:
		CheckBeginningArcana();
		return;
		IL_0417:
		_counterWeapon = counterWeapon;
		while (true)
		{
			Weapon weapon2 = (((object)_counterWeapon == null) ? null : ((Weapon)1));
			object obj8 = (object)weapon2 >> 32;
			object obj9 = obj8 - ((Equipment)this)._003CLevel_003Ek__BackingField;
			int num4 = obj8 ^ ((Equipment)this)._003CLevel_003Ek__BackingField;
			object obj10 = obj8 ^ obj9;
			int num5 = num4 & obj10;
			bool flag2 = num5 < 0;
			bool flag3 = (nint)obj9 < 0;
			bool flag4 = flag3 != flag2;
			object obj11 = weapon2 & flag4;
			if (obj11 == null)
			{
				break;
			}
			bool flag5 = _counterWeapon.LevelUp();
		}
		goto IL_03da;
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	private void _003CInitWeapon_003Eb__16_0()
	{
		OnBeatFire();
	}
}
