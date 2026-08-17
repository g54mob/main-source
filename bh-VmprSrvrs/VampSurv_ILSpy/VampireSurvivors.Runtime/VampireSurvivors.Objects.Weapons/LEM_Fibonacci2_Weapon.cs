using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Fibonacci2_Weapon : LEM_Fibonacci1_Weapon
{
	private Transform FlushVFX;

	private int _003CFireCounter_003Ek__BackingField;

	private MultiTargetTween _scaleTween;

	public int FireCounter
	{
		get
		{
			return _003CFireCounter_003Ek__BackingField;
		}
		private set
		{
			_003CFireCounter_003Ek__BackingField = value;
		}
	}

	public override float StartingAngle
	{
		get
		{
			//IL_0006: Expected F4, but got I4
			return 0f;
		}
	}

	protected override float WeaponTriggerChance
	{
		get
		{
			float weaponTriggerLuckBonus = base.WeaponTriggerLuckBonus;
			object obj = default(object);
			return (float)obj + 0.55f;
		}
	}

	protected override int NumWeaponsToTrigger
	{
		get
		{
			//IL_0088: Expected O, but got F4
			//IL_0091: Invalid comparison between F4 and O
			//IL_0031: Invalid comparison between F4 and O
			//IL_0054: Invalid comparison between O and F4
			//IL_000e: Invalid comparison between F4 and O
			object obj = UnityEngine.Random.value;
			object obj2 = default(object);
			int result;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.3f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					return 2;
				}
			}
			else
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
				{
					return 5;
				}
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f);
				result = 3;
				if (flag)
				{
					goto IL_00a8;
				}
			}
			result = 1;
			goto IL_00a8;
			IL_00a8:
			return result;
		}
	}

	public float PAreaMax => 5f;

	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(5f > num2);
		float result = 5f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public override float PInterval()
	{
		float num = base.PInterval();
		bool flag = !(1000f < num);
		float result = 1000f;
		if (!flag)
		{
			result = num;
		}
		return result;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		((Weapon)this).InitWeapon(characterController, weaponType);
		CreateFibonacciSequence();
		CreateFibonnaciOffsets();
		AddOuterSaboteur();
		_003CFireCounter_003Ek__BackingField = 0;
		ScaleInFlush();
		AddInnerSaboteur();
	}

	public void ScaleInFlush()
	{
		//IL_0275: Expected I, but got O
		//IL_00bc: Expected I, but got O
		//IL_015f: Expected O, but got I4
		//IL_01c6: Expected O, but got I4
		//IL_02f1: Expected O, but got I4
		//IL_00df->IL00df: Incompatible stack heights: 3 vs 2
		//IL_0211->IL0244: Incompatible stack heights: 9 vs 0
		Transform flushVFX = FlushVFX;
		if ((object)FlushVFX != null && ((UnityEngine.Object)flushVFX).m_CachedPtr != (IntPtr)0)
		{
			TweenConfig flushVFX2 = (TweenConfig)(object)FlushVFX;
			bool flag = flushVFX2.targets == null;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)flushVFX2.targets, ref value);
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			bool flag2 = array == null;
			if ((object)FlushVFX != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				bool flag3 = obj == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			bool flag4 = tweenConfig == null;
			tweenConfig.targets = array;
			bool flag5 = (object)GM.Core == null;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			bool flag6 = ArcadePhysics.s_scene == null;
			bool flag7 = s_scene._renderer == null;
			tweenConfig.scaleX = (float?)(object)1;
			bool flag8 = (object)GM.Core == null;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			bool flag9 = ArcadePhysics.s_scene == null;
			bool flag10 = s_scene2._renderer == null;
			tweenConfig.duration = 500f;
			tweenConfig.ease = Ease.OutBack;
			tweenConfig.scaleY = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_fibonacci_flush, new SoundManager.SoundConfig
			{
				Volume = (float?)(object)1,
				Rate = 1f
			}, 1000f, 1, time);
		}
	}

	private void PlayFlushSfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_fibonacci_flush, soundConfig, 1000f, 1, time);
	}

	protected override void MakeLevelOne()
	{
		//IL_000a: Expected I, but got O
		base.MakeLevelOne();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Fibonacci2_Weapon>)+4C0]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Fibonacci2_Weapon>)+4C0]");
		action._002Ector(this, (IntPtr)0);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		int num = _003CFireCounter_003Ek__BackingField + 1;
		_003CFireCounter_003Ek__BackingField = num;
		return base.FireOneProjectile(pos, index, target, pool);
	}

	private int GetNumWeaponsToTrigger()
	{
		//IL_0088: Expected O, but got F4
		//IL_0091: Invalid comparison between F4 and O
		//IL_0031: Invalid comparison between F4 and O
		//IL_0054: Invalid comparison between O and F4
		//IL_000e: Invalid comparison between F4 and O
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		int result;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.3f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				return 2;
			}
		}
		else
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				return 5;
			}
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f);
			result = 3;
			if (flag)
			{
				goto IL_00a8;
			}
		}
		result = 1;
		goto IL_00a8;
		IL_00a8:
		return result;
	}

	public override void SetVisible(bool visible)
	{
		//IL_0038: Expected O, but got I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		_isVisible = visible;
		if (!visible)
		{
			List<Projectile> spawnedProjectiles = _spawnedProjectiles;
			bool flag = (nint)_spawnedProjectiles < 0;
			object obj = spawnedProjectiles._size - 1;
			if (!flag)
			{
				Projectile[] items;
				do
				{
					List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
					if ((nint)obj < spawnedProjectiles2._size)
					{
						items = spawnedProjectiles2._items;
						items[obj].Despawn();
						obj--;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				while ((nint)items[obj] >= 0);
			}
		}
		GameObject gameObject = FlushVFX.gameObject;
		gameObject.SetActive(visible);
	}

	public override void Cleanup()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Cleanup();
	}
}
