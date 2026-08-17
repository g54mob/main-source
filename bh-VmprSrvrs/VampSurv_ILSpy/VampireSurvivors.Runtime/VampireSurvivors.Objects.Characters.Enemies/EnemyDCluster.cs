using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDCluster : EnemyDMask
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Pickup> _003C_003E9__6_1;

		public static Action<Pickup> _003C_003E9__6_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CGetDamaged_003Eb__6_1(Pickup c)
		{
			if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
			{
				c.Time = 1f;
				c.GoToPlayer = true;
				c._003CValue_003Ek__BackingField = 1f;
				c._003CFeverMS_003Ek__BackingField = 10f;
			}
		}

		internal void _003CGetDamaged_003Eb__6_2(Pickup c)
		{
			if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
			{
				c.Time = 1f;
				c.GoToPlayer = true;
				c._003CValue_003Ek__BackingField = 3f;
			}
		}
	}

	private bool _canEmitParticles = true;

	private MultiTargetTween _onEnterTween;

	private ParticleSystem _pfxEmitter;

	private Timer _particlesTimer;

	private float _particlesDelay = 1500f;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0113: Expected O, but got I4
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		base.InitEnemy(enemyType, asRemote);
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween onEnterTween = Tweens.Add(tweenConfig);
		_onEnterTween = onEnterTween;
		GenerateParticleSystems();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0127: Expected I4, but got I8
		//IL_01ab: Expected O, but got I4
		//IL_0333->IL0389: Incompatible stack heights: 1 vs 0
		//IL_0202->IL0281: Incompatible stack heights: 1 vs 0
		//IL_0221->IL0389: Incompatible stack heights: 1 vs 0
		//IL_0368->IL0389: Incompatible stack heights: 2 vs 0
		//IL_0258->IL0389: Incompatible stack heights: 1 vs 0
		//IL_0389->IL0281: Incompatible stack heights: 2 vs 0
		//IL_0281->IL0281: Incompatible stack heights: 1 vs 0
		GameObject owner = _owner;
		if ((object)_owner != null && ((UnityEngine.Object)owner).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_owner == null)
			{
				goto IL_0389;
			}
			IDamageable component = _owner.GetComponent<IDamageable>();
			if (component != null)
			{
				IDamageable component2 = _owner.GetComponent<IDamageable>();
			}
		}
		if (_isInvul)
		{
			return;
		}
		if (!_canEmitParticles)
		{
			goto IL_0281;
		}
		Transform cachedTransform = _cachedTransform;
		WeaponType weaponType = default(WeaponType);
		bool flag2 = default(bool);
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, -1);
			if (_particlesTimer != null)
			{
				_particlesTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canEmitParticles = true;
			};
			float duration = _particlesDelay * 0.001f;
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer particlesTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)weaponType != 0, (MonoBehaviour)flag2, repeat, type, isOnlineTimer: false, canPause: false);
			_particlesTimer = particlesTimer;
			if (_enemyType != EnemyType.D_CLUSTER_COINS)
			{
				bool flag3 = _enemyType != EnemyType.D_CLUSTER_GEMS;
				weaponType = weaponType;
				if (flag3)
				{
					goto IL_0281;
				}
				if ((object)_cachedTransform != null)
				{
					Vector3 vector = _cachedTransform.position;
					Action<Pickup> callback = _003C_003Ec._003C_003E9__6_2;
					if (_003C_003Ec._003C_003E9__6_2 == null)
					{
						callback = (_003C_003Ec._003C_003E9__6_2 = delegate(Pickup c)
						{
							if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
							{
								c.Time = 1f;
								c.GoToPlayer = true;
								c._003CValue_003Ek__BackingField = 3f;
							}
						});
					}
					if ((object)GM.Core != null)
					{
						GM.Core.MakeGem(pos, 1f, callback);
						weaponType = weaponType;
						goto IL_0281;
					}
				}
			}
			else
			{
				GameObject cachedTransform2 = (GameObject)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					weaponType = weaponType;
					bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out ret);
					Action<Pickup> callback2 = _003C_003Ec._003C_003E9__6_1;
					if (_003C_003Ec._003C_003E9__6_1 == null)
					{
						callback2 = (_003C_003Ec._003C_003E9__6_1 = delegate(Pickup c)
						{
							if ((object)c != null && ((UnityEngine.Object)c).m_CachedPtr != (IntPtr)0)
							{
								c.Time = 1f;
								c.GoToPlayer = true;
								c._003CValue_003Ek__BackingField = 1f;
								c._003CFeverMS_003Ek__BackingField = 10f;
							}
						});
					}
					if ((object)GM.Core != null)
					{
						GM.Core.MakeCoin(pos, 1f, callback2);
						goto IL_0281;
					}
				}
			}
		}
		goto IL_0389;
		IL_0281:
		if (!_isInvul)
		{
			if (base._canBreak && !base._alreadyBroken)
			{
				BreakMask();
			}
			((EnemyController)this).GetDamaged(value, showHitVfx, damageKb, weaponType, flag2);
		}
		return;
		IL_0389:
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0123: Expected O, but got I
		//IL_013f: Expected O, but got I4
		//IL_0158: Expected O, but got Ref
		//IL_0167: Expected O, but got I4
		//IL_0175: Expected native int or pointer, but got O
		//IL_0387: Expected O, but got I4
		//IL_018d: Expected O, but got Ref
		//IL_01a7: Expected native int or pointer, but got O
		//IL_01c1: Expected O, but got I
		//IL_01e1: Expected O, but got Ref
		//IL_01fb: Expected native int or pointer, but got O
		//IL_03a4: Expected O, but got I4
		//IL_022d: Expected O, but got Ref
		//IL_0247: Expected native int or pointer, but got O
		//IL_03de: Expected O, but got I
		//IL_028d: Expected O, but got I4
		//IL_0418: Expected O, but got I
		//IL_02d8: Expected O, but got I
		//IL_02f3: Expected O, but got I
		//IL_030e: Expected O, but got I
		//IL_0329: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = _enemyType == EnemyType.D_CLUSTER_COINS;
		object item = "CoinGold";
		if (!flag)
		{
			bool flag2 = _enemyType != EnemyType.D_CLUSTER_GEMS;
			item = "CoinGold";
			if (!flag2)
			{
				item = "GemBlue";
			}
		}
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize(item);
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		_ = 0;
		_ = 10;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(255f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(112f, 275f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.2f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		particleSystemConfig._collideTop = (bool?)(object)0;
		_ = 257;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		particleSystemConfig._collideBottom = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		particleSystemConfig._collideLeft = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		particleSystemConfig._collideRight = (bool?)(object)0;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter;
	}

	private void _003CGetDamaged_003Eb__6_0()
	{
		_canEmitParticles = true;
	}
}
