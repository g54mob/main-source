using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class PhaserWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public float2 target;

		public PhaserWeapon _003C_003E4__this;

		public double projectilesPerBlast;

		public Action _003C_003E9__0;

		internal void _003COnBeatFire_003Eb__0()
		{
			float2 float5 = _003C_003E4__this.PickRandomEnemyOnScreenRect();
			target = float5;
			Vector2 pos = default(Vector2);
			Projectile projectile = _003C_003E4__this.FireOneProjectile(pos, 0);
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals1;

		public Action _003C_003E9__2;

		internal void _003COnBeatFire_003Eb__1()
		{
			//IL_02e6: Expected O, but got I4
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Expected O, but got Unknown
			//IL_015e: Expected O, but got I4
			//IL_0268: Expected F4, but got I4
			object obj = (object)CS_0024_003C_003E8__locals1 ^ (object)CS_0024_003C_003E8__locals1;
			object obj2 = (object)CS_0024_003C_003E8__locals1 & obj;
			bool flag = (nint)obj2 < 0;
			bool flag2 = (nint)CS_0024_003C_003E8__locals1 < 0;
			bool flag3 = CS_0024_003C_003E8__locals1 == null;
			bool flag4 = false;
			bool flag6 = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
				bool flag5 = flag2 == flag;
				object obj3 = !flag5;
				object obj4 = obj3 | flag3;
				if (obj4 != null)
				{
					break;
				}
				Action onComplete = _003C_003E9__2;
				if (_003C_003E9__2 == null)
				{
					onComplete = (_003C_003E9__2 = delegate
					{
						_003C_003Ec__DisplayClass16_0 obj11 = CS_0024_003C_003E8__locals1;
						float2 target = obj11._003C_003E4__this.PickRandomEnemyOnScreenRect();
						obj11.target = target;
						_003C_003Ec__DisplayClass16_0 obj12 = CS_0024_003C_003E8__locals1;
						Vector2 pos = default(Vector2);
						Projectile projectile = obj12._003C_003E4__this.FireOneProjectile(pos, localIndex);
					});
				}
				float num = (float)(flag4 ? 1 : 0) * 21.25f;
				float duration = num * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag6, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag4 = (byte)((flag4 ? 1u : 0u) + 1u) != 0;
				object obj5 = (object)CS_0024_003C_003E8__locals1 ^ (object)CS_0024_003C_003E8__locals1;
				object obj6 = (object)CS_0024_003C_003E8__locals1 & obj5;
				flag = (nint)obj6 < 0;
				flag2 = (nint)CS_0024_003C_003E8__locals1 < 0;
				flag3 = CS_0024_003C_003E8__locals1 == null;
			}
			_003C_003Ec__DisplayClass16_0 obj7 = CS_0024_003C_003E8__locals1;
			PhaserWeapon phaserWeapon = obj7._003C_003E4__this;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			_003C_003Ec__DisplayClass16_0 obj8 = CS_0024_003C_003E8__locals1;
			PhaserWeapon phaserWeapon2 = obj8._003C_003E4__this;
			_003C_003Ec__DisplayClass16_0 obj9 = CS_0024_003C_003E8__locals1;
			float[] detuneValues = phaserWeapon2._detuneValues;
			PhaserWeapon phaserWeapon3 = obj9._003C_003E4__this;
			int sfxIndex = phaserWeapon3._sfxIndex + 1;
			phaserWeapon3._sfxIndex = sfxIndex;
			_003C_003Ec__DisplayClass16_0 obj10 = CS_0024_003C_003E8__locals1;
			PhaserWeapon phaserWeapon4 = obj10._003C_003E4__this;
			float[] detuneValues2 = phaserWeapon4._detuneValues;
			int num2 = phaserWeapon3._sfxIndex % detuneValues2.Length;
			float detune = detuneValues[num2] * 100f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(phaserWeapon._soundEffect, soundConfig, 0f, 10, flag6 ? 1 : 0);
		}

		internal void _003COnBeatFire_003Eb__2()
		{
			_003C_003Ec__DisplayClass16_0 obj = CS_0024_003C_003E8__locals1;
			float2 target = obj._003C_003E4__this.PickRandomEnemyOnScreenRect();
			obj.target = target;
			_003C_003Ec__DisplayClass16_0 obj2 = CS_0024_003C_003E8__locals1;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj2._003C_003E4__this.FireOneProjectile(pos, localIndex);
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public float2 target;

		public PhaserWeapon _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal void _003COnBeatFireAlt_003Eb__0()
		{
			_003C_003Ec__DisplayClass17_0 obj = CS_0024_003C_003E8__locals1;
			float2 target = obj._003C_003E4__this.PickRandomEnemyOnScreenRect();
			obj.target = target;
			_003C_003Ec__DisplayClass17_0 obj2 = CS_0024_003C_003E8__locals1;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj2._003C_003E4__this.FireOneProjectile(pos, localIndex);
		}
	}

	protected List<BaseBody> bodies;

	protected int _accumulatedActivations;

	private int _sfxIndex;

	public float[] _detuneValues = new float[64]
	{
		0f, 12f, 0f, 12f, -5f, 7f, -2f, 10f, 0f, 12f,
		0f, 12f, -5f, 7f, -2f, 10f, 3f, 15f, 3f, 15f,
		-2f, 10f, 1f, 13f, 3f, 15f, 3f, 15f, -2f, 10f,
		1f, 13f, 5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f,
		5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f, 7f, 19f,
		7f, 19f, 2f, 14f, 5f, 17f, 7f, 19f, 7f, 19f,
		2f, 14f, 5f, 17f
	};

	private Timer _testBeatTimer;

	protected SfxType _soundEffect;

	protected float _soundVolume = 1f;

	protected float _musicBeatInterval = 425f;

	protected float _timeUnit = 53.125f;

	protected float _camOffsetPerc = 0.125f;

	protected float _camSizePerc = 0.75f;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		Setuppo();
		List<BaseBody> list = new List<BaseBody>();
		bodies = list;
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
		_soundEffect = SfxType.Bumper2;
		_musicBeatInterval = 425f;
		_timeUnit = 53.125f;
		_camOffsetPerc = 0.125f;
		_camSizePerc = 0.75f;
	}

	protected virtual float GetProjectilesAmount()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		float num = base.PAmount();
		object obj2 = default(object);
		object obj = _accumulatedActivations * obj2;
		return (float)obj * 4f;
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
		//IL_005b: Expected I, but got O
		//IL_0073: Expected I, but got O
		//IL_0178: Expected O, but got Ref
		//IL_0215: Expected O, but got I4
		//IL_0736: Expected O, but got I4
		//IL_073e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Expected O, but got Unknown
		//IL_0369: Expected O, but got I4
		//IL_03dc: Expected I, but got O
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_03fe: Expected F4, but got I4
		//IL_04af: Expected I, but got O
		//IL_04c5: Expected O, but got I
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Expected O, but got Unknown
		//IL_053c: Expected I, but got O
		//IL_075a: Expected O, but got I4
		//IL_0771: Expected I, but got I8
		//IL_07e0: Expected O, but got I
		//IL_07f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Expected O, but got Unknown
		//IL_0581: Expected O, but got I4
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Expected O, but got Unknown
		//IL_059e: Expected I4, but got F4
		//IL_0525: Expected I, but got I8
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals16._003C_003E4__this = this;
		if (_accumulatedActivations == 0 || PauseSystem._paused)
		{
			return;
		}
		float timeUnit = GetTimeUnit();
		float timeUnit2 = default(float);
		_timeUnit = timeUnit2;
		float projectilesAmount = GetProjectilesAmount();
		nint num = (nint)this;
		float num2 = base.PInterval();
		nint num3 = (nint)typeof(Math);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		double num4 = Math.Floor(0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm0,xmm10\"");
		double projectilesPerBlast = Math.Floor(0.0);
		CS_0024_003C_003E8__locals16.projectilesPerBlast = projectilesPerBlast;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F870");
		_accumulatedActivations = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018753A00Bh\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ rcx_v15 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 == 0)
		{
			CS_0024_003C_003E8__locals16.projectilesPerBlast = 1.0;
		}
		GameManager core = GM.Core;
		Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
		{
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
			throw new NullReferenceException();
		}
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		object obj = default(object);
		EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
		BaseBody body;
		if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
		{
			body = enemyController.body;
		}
		else
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			body = characterController.body;
		}
		object obj2 = (object)body ^ (object)body;
		object obj3 = (object)body & obj2;
		bool flag = (nint)obj3 < 0;
		bool flag2 = (nint)body < 0;
		bool flag3 = body == null;
		Vector2 vector = default(Vector2);
		CS_0024_003C_003E8__locals16.target = vector;
		Projectile projectile = base.FireOneProjectile(vector, 0);
		float? num5 = (float?)(object)1;
		bool flag5 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rbp+20h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
			bool flag4 = flag2 == flag;
			object obj4 = !flag4;
			object obj5 = obj4 | flag3;
			if (obj5 != null)
			{
				break;
			}
			Action onComplete = CS_0024_003C_003E8__locals16._003C_003E9__0;
			object obj6 = (object)CS_0024_003C_003E8__locals16._003C_003E9__0 ^ (object)CS_0024_003C_003E8__locals16._003C_003E9__0;
			object obj7 = (object)CS_0024_003C_003E8__locals16._003C_003E9__0 & obj6;
			flag = (nint)obj7 < 0;
			flag2 = (nint)CS_0024_003C_003E8__locals16._003C_003E9__0 < 0;
			flag3 = CS_0024_003C_003E8__locals16._003C_003E9__0 == null;
			if (CS_0024_003C_003E8__locals16._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals16._003C_003E9__0 = delegate
				{
					float2 target = CS_0024_003C_003E8__locals16._003C_003E4__this.PickRandomEnemyOnScreenRect();
					CS_0024_003C_003E8__locals16.target = target;
					Vector2 pos = default(Vector2);
					Projectile projectile2 = CS_0024_003C_003E8__locals16._003C_003E4__this.FireOneProjectile(pos, 0);
				});
			}
			float num6 = (float)num5 * 21.25f;
			float duration = num6 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			num5 = (float?)(object)((_003F?)num5 + 1);
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float[] detuneValues = _detuneValues;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		int num7 = _sfxIndex % detuneValues.Length;
		float num8 = (soundConfig.Detune = detuneValues[num7] * 100f);
		nint num9 = (nint)typeof(SoundManager);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(_soundEffect, soundConfig, 0f, 10, flag5 ? 1 : 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm10,qword ptr [188A10758h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rcx_v33 (Il2CppClass<VampireSurvivors.Framework.SoundManager>)+E4]");
		if ((nint)0 > (nint)0)
		{
			int num10 = 1;
			object obj15;
			do
			{
				_003C_003Ec__DisplayClass16_1 obj8 = new _003C_003Ec__DisplayClass16_1();
				obj8.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals16;
				obj8.localIndex = num10;
				Action action = null;
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ r10_v8 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_1._003COnBeatFire_003Eb__1);
				((Delegate)action).m_target = obj8;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ r10_v8 (Il2CppMethodInfo)+4C]");
				object obj9 = (nint)0 >> 4;
				object obj10 = obj9 & 1;
				nint num12;
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ r10_v8 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num12 = unchecked((nint)6447293664L);
						goto IL_0751;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num12 = ((Delegate)action).method_ptr;
				goto IL_0751;
				IL_0751:
				object obj11 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				float num13 = (float)num10 * _timeUnit;
				float duration2 = num13 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration2, action, null, isLooped: false, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				object obj12 = num14 ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				object obj13 = 0 & obj12;
				bool flag6 = (nint)obj13 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag7 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag8 = (nint)0 == 0;
				_lastShotTimer = lastShotTimer;
				float num15 = (float)num10 + 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm10,xmm0\"");
				bool flag9 = flag7 == flag6;
				object obj14 = !flag8;
				obj15 = flag9 & obj14;
				num8 = num15;
				num10 = (int)num15;
			}
			while (obj15 != null);
		}
		float num16 = base.PInterval();
		bool flag10 = _lastFiringInterval == num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018753A5A7h\"");
		if (!flag10)
		{
			float num17 = base.PInterval();
			_lastFiringInterval = num8;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public unsafe void OnBeatFireAlt(bool skipTriggers = false)
	{
		//IL_0055: Invalid comparison between F4 and I4
		//IL_03d1: Expected O, but got F4
		//IL_0422: Expected O, but got I4
		//IL_00d8: Expected O, but got Ref
		//IL_022a: Expected I, but got O
		//IL_0240: Expected O, but got I
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_02b7: Expected I, but got O
		//IL_04af: Expected O, but got I4
		//IL_04c6: Expected I, but got I8
		//IL_0503: Expected I4, but got F4
		//IL_0305: Expected I4, but got F4
		//IL_02a0: Expected I, but got I8
		_003C_003Ec__DisplayClass17_0 obj = new _003C_003Ec__DisplayClass17_0();
		obj._003C_003E4__this = this;
		if (PauseSystem._paused)
		{
			return;
		}
		float timeUnit = GetTimeUnit();
		float num = default(float);
		_timeUnit = num;
		float projectilesAmount = GetProjectilesAmount();
		_accumulatedActivations = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018753A96Bh\"");
		float2 target;
		Vector2 vector = default(Vector2);
		if (num != 0f)
		{
			GameManager core = GM.Core;
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				throw new NullReferenceException();
			}
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			object obj2 = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj2), excludeDead: true);
			if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
			}
			target = vector;
		}
		else
		{
			Camera main = Camera.main;
			Bounds bounds = CameraExtensions.OrthographicBounds(main);
			object obj3 = UnityEngine.Random.value;
			target = vector;
		}
		obj.target = target;
		Projectile projectile = base.FireOneProjectile(vector, 0);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float[] detuneValues = _detuneValues;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		int num2 = _sfxIndex % detuneValues.Length;
		float num3 = (soundConfig.Detune = detuneValues[num2] * 100f);
		float num4 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(_soundEffect, soundConfig, 0f, 10, num4);
		if (num > 1f)
		{
			int num5 = 1;
			int num6 = 10;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag;
			do
			{
				_003C_003Ec__DisplayClass17_1 obj4 = new _003C_003Ec__DisplayClass17_1();
				obj4.CS_0024_003C_003E8__locals1 = obj;
				obj4.localIndex = num5;
				Action action = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1116 @ r10_v9 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass17_1._003COnBeatFireAlt_003Eb__0);
				((Delegate)action).m_target = obj4;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1116 @ r10_v9 (Il2CppMethodInfo)+4C]");
				object obj5 = (nint)0 >> 4;
				object obj6 = obj5 & 1;
				nint num8;
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1116 @ r10_v9 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num8 = unchecked((nint)6447293664L);
						goto IL_04a6;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num8 = ((Delegate)action).method_ptr;
				goto IL_04a6;
				IL_04a6:
				object obj7 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				float duration = (float)num6 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, action, null, isLooped: false, (byte)(int)num4 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
				float num9 = (float)num5 + 1f;
				num6 += 10;
				flag = num > num9;
				num3 = num9;
				num5 = (int)num9;
			}
			while (flag);
		}
		float num10 = base.PInterval();
		bool flag2 = _lastFiringInterval == num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018753AE36h\"");
		if (!flag2)
		{
			float num11 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
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

	public unsafe virtual float2 PickRandomEnemyOnScreenRect()
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected Ref, but got Unknown
		//IL_035b: Expected O, but got F4
		//IL_03df: Expected O, but got I4
		//IL_030d->IL033d: Incompatible stack heights: 1 vs 0
		//IL_0333->IL033d: Incompatible stack heights: 1 vs 0
		//IL_028e->IL038e: Incompatible stack heights: 0 vs 1
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		float2 float5 = default(float2);
		float num = (float)float5 * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		float num3 = (float)float5 * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num4 = 0f * 2f;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			object obj = (object)bounds.m_Center - (object)float5;
			float num5 = num3 * _camOffsetPerc;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v5 (UnityEngine.Bounds)+10]");
			object obj2 = float5 - 0;
			float num6 = num4 * _camOffsetPerc;
			float width = num * _camSizePerc;
			float height = num2 * _camSizePerc;
			Rectangle rectangle = new Rectangle();
			float x = (float)obj + num5;
			float y = (float)obj2 + num6;
			rectangle._width = width;
			rectangle._height = height;
			rectangle._x = x;
			rectangle._y = y;
			if ((object)core._stage != null)
			{
				core._stage.GetEnemyBodiesInRect(rectangle, ref *(List<BaseBody>*)(this + 344));
				List<BaseBody> list = bodies;
				if (bodies != null)
				{
					bool num7;
					if (list._size > 0)
					{
						if (bodies != null)
						{
							object obj3 = UnityEngine.Random.RandomRangeInt(0, list._size);
							bool flag = (nint)obj3 >= list._size;
							num7 = flag;
							BaseBody[] items = list._items;
							if (list._items != null && items[obj3] != null)
							{
								goto IL_03ff;
							}
						}
					}
					else
					{
						object obj4 = UnityEngine.Random.value;
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && characterController2.body != null)
							{
								return float5;
							}
						}
						else
						{
							Transform transform = base.transform;
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								num7 = flag2;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								goto IL_03ff;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_03ff:
		return float5;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_testBeatTimer != null)
		{
			_testBeatTimer.Cancel();
		}
	}

	private void _003CInitWeapon_003Eb__11_0()
	{
		OnBeatFire();
	}
}
