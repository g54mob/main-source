using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BloodLancetProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int radIndex;

		public BloodLancetProjectile _003C_003E4__this;

		internal float _003COverrideWeaponData_003Eb__4()
		{
			BloodLancetProjectile bloodLancetProjectile = _003C_003E4__this;
			List<Radi> radii = bloodLancetProjectile._radii;
			int num = radIndex;
			if (radIndex < radii._size)
			{
				Radi[] items = radii._items;
				Radi radi = items[num];
				return radi.Radius;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			float result = default(float);
			return result;
		}

		internal void _003COverrideWeaponData_003Eb__5(float x)
		{
			BloodLancetProjectile bloodLancetProjectile = _003C_003E4__this;
			List<Radi> radii = bloodLancetProjectile._radii;
			int num = radIndex;
			if (radIndex < radii._size)
			{
				Radi[] items = radii._items;
				Radi radi = items[num];
				radi.Radius = x;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}

		internal void _003COverrideWeaponData_003Eb__6()
		{
			BloodLancetProjectile bloodLancetProjectile = _003C_003E4__this;
			List<Radi> radii = bloodLancetProjectile._radii;
			int num = radIndex;
			if (radIndex < radii._size)
			{
				Radi[] items = radii._items;
				Radi radi = items[num];
				radi.Radius = 10f;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private Transform _NumbersParent;

	private List<PhaserSprite> _Numbers;

	private Timer _expireTimer;

	private BloodAstronomiaWeapon _trueWeapon;

	public List<Radi> _radii;

	private float _amount;

	private float _slowPower;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _imageTween;

	private MultiTargetTween _angleTween;

	private MultiTargetTween _alphaTween;

	private List<Tweener> _radiusTween;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		bool flag = (object)weapon == null;
		Weapon trueWeapon = null;
		if (flag)
		{
			goto IL_011b;
		}
		nint num = (nint)typeof(BloodAstronomiaWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.BloodAstronomiaWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v18+FFFFFFF8+v63 @ rax_v14*8]");
			if (0 == (nint)typeof(BloodAstronomiaWeapon))
			{
				obj3 = 1;
				goto IL_012a;
			}
		}
		obj3 = 0;
		goto IL_012a;
		IL_011b:
		_trueWeapon = (BloodAstronomiaWeapon)trueWeapon;
		ArcadeSprite arcadeSprite2 = setTint(16711680u);
		InitNumbers();
		return;
		IL_012a:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = weapon;
		}
		goto IL_011b;
	}

	public unsafe void OverrideWeaponData(Weapon weapon)
	{
		//IL_0076: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0153: Expected O, but got I4
		//IL_0178: Expected F4, but got I4
		//IL_0295: Expected I4, but got I8
		//IL_02a3: Expected O, but got I4
		//IL_03d7: Expected I, but got O
		//IL_042d: Expected O, but got I4
		//IL_043f: Expected I4, but got I8
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Expected O, but got Unknown
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Expected O, but got Unknown
		//IL_064b: Expected I, but got O
		//IL_06a1: Expected O, but got I4
		//IL_072e: Expected O, but got I4
		//IL_073b: Expected O, but got I8
		//IL_0744: Expected O, but got I4
		//IL_0753: Expected O, but got I4
		//IL_0782: Expected I4, but got O
		//IL_082b: Expected O, but got I
		//IL_0834: Unknown result type (might be due to invalid IL or missing references)
		//IL_0839: Expected O, but got Unknown
		//IL_08ad: Expected O, but got I
		//IL_0e4c: Expected O, but got I4
		//IL_08cd: Expected O, but got I
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08db: Expected O, but got Unknown
		//IL_094f: Expected O, but got I
		//IL_088b: Expected O, but got I8
		//IL_0e9a: Expected O, but got I
		//IL_0964: Expected O, but got I
		//IL_0979: Expected O, but got I
		//IL_092d: Expected O, but got I8
		//IL_0993: Expected F4, but got I
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Expected O, but got Unknown
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Expected O, but got Unknown
		//IL_0ed6: Expected I, but got O
		//IL_0eec: Expected O, but got I
		//IL_0ef5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efa: Expected O, but got Unknown
		//IL_0bfe: Expected I, but got O
		//IL_0f20: Expected O, but got I4
		//IL_0f37: Expected I, but got I8
		//IL_0be7: Expected I, but got I8
		//IL_0d0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d14: Expected O, but got Unknown
		//IL_0cd2: Expected I4, but got O
		//IL_0d38: Expected O, but got I8
		BaseBody baseBody = body;
		baseBody._enable = true;
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		BaseBody baseBody2 = body.setCircle(64f, (float?)(object)0, (float?)(object)0);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setAlpha(0.5f);
		float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		float num3;
		if (!(num2 > 10f))
		{
			object obj = 10f & -2147483649L;
			bool flag = (nint)obj <= 2139095040;
			num3 = num2;
			if (flag)
			{
				goto IL_0d97;
			}
		}
		num3 = 10f;
		goto IL_0d97;
		IL_0da9:
		float num4;
		bool flag2 = 1f > num4;
		float duration = 1f;
		if (!flag2)
		{
			duration = num4;
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 300f;
		tweenConfig.ease = Ease.Linear;
		TweenCallback onStart = delegate
		{
			//IL_0010: Expected O, but got I4
			ArcadeSprite arcadeSprite5 = setScale(0f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		List<Tweener>.Enumerator enumerator = default(List<Tweener>.Enumerator);
		while (enumerator.MoveNext())
		{
		}
		List<Radi> radii = _radii;
		float? num6 = (float?)(object)0;
		object obj3 = 6447969936L;
		float? num7 = (float?)(object)0;
		int num8 = 0;
		float? num9 = (float?)(object)0;
		float num16 = default(float);
		float num17;
		float num18;
		float num19;
		while (true)
		{
			_003C_003Ec__DisplayClass13_0 obj4;
			DOGetter<float> getter;
			if ((nint)num9 < radii._size)
			{
				obj4 = new _003C_003Ec__DisplayClass13_0();
				obj4._003C_003E4__this = this;
				obj4.radIndex = (int)num7;
				List<Radi> radii2 = _radii;
				if ((nint)num7 >= radii2._size)
				{
					break;
				}
				Radi[] items = radii2._items;
				Radi radi = items[(object)num7];
				radi.Radius = 10f;
				getter = null;
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2343 @ r9_v14 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2343 @ r9_v14 (Il2CppMethodInfo)+4C]");
				object obj5 = (nint)0 >> 4;
				object obj6 = obj5 & 1;
				object obj7;
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2343 @ r9_v14 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						obj7 = 6447965120L;
						goto IL_0e43;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2342 @ rax_v101 (DG.Tweening.Core.DOGetter`1<System.Single>)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2342 @ rax_v101 (DG.Tweening.Core.DOGetter`1<System.Single>)+10]");
				obj7 = 0;
				goto IL_0e43;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
			ArcadeSprite arcadeSprite3 = setDepth(num8);
			return;
			IL_0e43:
			object obj8 = 24;
			DOSetter<float> setter = null;
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r9_v15 (Il2CppMethodInfo)+8]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r9_v15 (Il2CppMethodInfo)+4C]");
			object obj9 = (nint)0 >> 4;
			object obj10 = obj9 & 1;
			object obj11;
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r9_v15 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 1)
				{
					obj11 = 6447299152L;
					goto IL_0e7b;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2460 @ rax_v107 (DG.Tweening.Core.DOSetter`1<System.Single>)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2460 @ rax_v107 (DG.Tweening.Core.DOSetter`1<System.Single>)+10]");
			obj11 = 0;
			goto IL_0e7b;
			IL_0f17:
			object obj12 = 24;
			TweenCallback tweenCallback;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			TweenerCore<float, float, FloatOptions> tweenerCore;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2756 @ rax_v124 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenExtensions.Play(tweenerCore);
			List<object> radiusTween = (List<object>)(object)_radiusTween;
			int version = radiusTween._version + 1;
			radiusTween._version = version;
			object[] items2 = radiusTween._items;
			num8 = radiusTween._size;
			if (radiusTween._size >= items2.Length)
			{
				radiusTween.AddWithResize((object)tweenerCore);
				num8 = (int)tweenerCore;
			}
			else
			{
				int num12 = radiusTween._size + 1;
				radiusTween._size = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num7 = (float?)(object)((_003F?)num6 + 1);
			radii = _radii;
			num6 = num7;
			obj3 = 6447969936L;
			num9 = num7;
			continue;
			IL_0a6f:
			float num13;
			TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter, setter, num13, duration);
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v122 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v122 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v122 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2679 @ rax_v122 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
			}
			float delay = (float)obj4.radIndex * 0.05f;
			tweenerCore = TweenSettingsExtensions.SetDelay(tweenerCore3, delay);
			tweenCallback = null;
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass13_0._003COverrideWeaponData_003Eb__6);
			((Delegate)tweenCallback).m_target = obj4;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj13 = (nint)0 >> 4;
			object obj14 = obj13 & 1;
			nint num15;
			if (obj14 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num15 = unchecked((nint)6447293664L);
					goto IL_0f17;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num15 = ((Delegate)tweenCallback).method_ptr;
			goto IL_0f17;
			IL_0e7b:
			_ = 6449796912L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2572 @ stack_10+58]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v677 @ rax_v113+248]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rax_v114+70]");
			object obj17 = 0;
			float value = num16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r15_v10+14]");
			EggFloat eggFloat = new EggFloat(value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r15_v10+10]");
			num16 = 0f - 12f;
			num13 = eggFloat._eggVal + eggFloat._val;
			object obj18 = num13 & -2147483649L;
			if ((nint)obj18 != 2139095040)
			{
				object obj19 = num13 & -2147483649L;
				if ((nint)obj19 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF2BF2h\"");
					if (num13 == num17)
					{
						num13 = num18;
					}
					goto IL_0a6f;
				}
			}
			num13 = num19;
			goto IL_0a6f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0dcf:
		num18 = -3.4028235E+38f;
		goto IL_0da9;
		IL_0d97:
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float num20 = (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
		float amount = num20 * num20;
		_amount = amount;
		ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
		WeaponData currentWeaponData2 = weapon._currentWeaponData;
		_slowPower = currentWeaponData2._003Camount_003Ek__BackingField;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num21 = weapon.PDuration();
		Action onComplete = delegate
		{
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			FadeOut();
		};
		float duration2 = (float)currentWeaponData2._003Camount_003Ek__BackingField * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		if (_imageTween != null)
		{
			_imageTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		PhaserSprite[] targets = _Numbers.ToArray();
		tweenConfig2.targets = targets;
		tweenConfig2.repeat = -1;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeatDelay = 100f;
		StaggerConfig staggerConfig = new StaggerConfig();
		staggerConfig.ease = Ease.Linear;
		staggerConfig.start = 1000f;
		Func<int, float> staggerDuration = Tweens.Stagger(20f, staggerConfig);
		tweenConfig2.staggerDuration = staggerDuration;
		tweenConfig2.ease = Ease.Linear;
		TweenCallback onStart2 = delegate
		{
			//IL_0102: Expected O, but got I4
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0155->IL01ba: Incompatible stack heights: 8 vs 2
			Transform cachedTransform = _cachedTransform;
			bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Quaternion value2 = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value2);
			List<PhaserSprite> numbers = _Numbers;
			bool flag4 = _Numbers == null;
			Transform transform = null;
			Transform transform2 = null;
			List<PhaserSprite> numbers2 = _Numbers;
			while ((nint)transform < numbers._size)
			{
				bool flag5 = numbers2 == null;
				bool flag6 = (nint)transform2 >= numbers2._size;
				PhaserSprite[] items3 = numbers2._items;
				bool flag7 = numbers2._items == null;
				bool flag8 = (nint)transform2 >= items3.Length;
				bool flag9 = (object)items3[(object)transform2] == null;
				PhaserSprite phaserSprite = items3[(object)transform2].setAlpha(0.5f);
				PhaserSprite phaserSprite2 = items3[(object)transform2].setScale(1f, (float?)(object)1);
				numbers2 = _Numbers;
				transform2 = (Transform)(transform2 + 1);
				bool flag10 = _Numbers == null;
				transform = transform2;
				numbers = _Numbers;
			}
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween imageTween = Tweens.Add(tweenConfig2);
		_imageTween = imageTween;
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num22 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj20 = default(object);
			if (obj20 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array2;
		tweenConfig3.angle = (float?)(object)1;
		tweenConfig3.repeat = -1;
		tweenConfig3.duration = 4000f;
		tweenConfig3.ease = Ease.Linear;
		TweenCallback onStart3 = delegate
		{
			Transform cachedTransform = _cachedTransform;
			bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Quaternion value2 = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value2);
		};
		tweenConfig3.onStart = onStart3;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig3);
		_angleTween = angleTween;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		MagnetZone magnet = characterController._magnet;
		EggFloat eggFloat2 = magnet.Radius / 64f;
		num4 = eggFloat2._val + eggFloat2._eggVal;
		object obj21 = num4 & -2147483649L;
		if ((nint)obj21 != 2139095040)
		{
			object obj22 = num4 & -2147483649L;
			if ((nint)obj22 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186FF2562h\"");
				if (num4 == -1f / 0f)
				{
					num19 = 3.4028235E+38f;
					num18 = -3.4028235E+38f;
					num17 = -1f / 0f;
					num4 = -3.4028235E+38f;
					goto IL_0da9;
				}
				num19 = 3.4028235E+38f;
				num17 = -1f / 0f;
				goto IL_0dcf;
			}
		}
		num19 = 3.4028235E+38f;
		num17 = -1f / 0f;
		num4 = 3.4028235E+38f;
		goto IL_0dcf;
	}

	public override void Despawn()
	{
		base.Despawn();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
	}

	public override bool CanExplode()
	{
		return true;
	}

	public override void Explode(Vector2? position = null)
	{
		//IL_0025: Invalid comparison between I4 and F4
		if (!(0f < --_amount))
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
			FadeOut();
		}
	}

	public override void InternalUpdate()
	{
		//IL_0072: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_0296: Expected O, but got I4
		List<PhaserSprite> numbers = _Numbers;
		float num = (float)Math.PI * 2f / (float)numbers._size;
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		float num2 = cachedTrans.localEulerAngles.z * ((float)Math.PI / 180f);
		float2 float5 = base.position;
		List<PhaserSprite> numbers2 = _Numbers;
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		object obj4 = default(object);
		while (true)
		{
			if ((nint)obj3 < numbers2._size)
			{
				List<PhaserSprite> numbers3 = _Numbers;
				if ((nint)obj >= numbers3._size)
				{
					break;
				}
				PhaserSprite[] items = numbers3._items;
				List<Radi> radii = _radii;
				if ((nint)obj >= radii._size)
				{
					break;
				}
				Radi[] items2 = radii._items;
				Radi radi = items2[obj];
				float num3 = (float)obj * num;
				float num4 = num3 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num5 = radi.Radius * 0.01f;
				float num6 = num4 * num5;
				float x = num6 + (float)float5;
				items[obj].X = x;
				List<Radi> radii2 = _radii;
				if ((nint)obj >= radii2._size)
				{
					break;
				}
				Radi[] items3 = radii2._items;
				Radi radi2 = items3[obj];
				float num7 = (float)obj * num;
				float num8 = num7 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num9 = radi2.Radius * 0.01f;
				float num10 = num8 * num9;
				float y = num10 + (float)obj4;
				items[obj].Y = y;
				numbers2 = _Numbers;
				obj++;
				obj2 = 0;
				obj3 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void InitNumbers()
	{
		//IL_017f: Expected I4, but got O
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_0212: Expected I4, but got O
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		List<Radi> radii = _radii;
		if (_radii != null)
		{
			int version = radii._version + 1;
			radii._version = version;
			radii._size = 0;
			if (radii._size > 0)
			{
				Array.Clear(radii._items, 0, radii._size);
			}
			List<PhaserSprite> numbers = _Numbers;
			if (_Numbers != null)
			{
				object obj = null;
				object obj2 = null;
				Quaternion value = default(Quaternion);
				while (true)
				{
					if ((nint)obj2 < numbers._size)
					{
						List<PhaserSprite> numbers2 = _Numbers;
						if (_Numbers == null)
						{
							break;
						}
						if ((nint)obj < numbers2._size)
						{
							PhaserSprite[] items = numbers2._items;
							if (numbers2._items == null)
							{
								break;
							}
							if ((nint)obj < items.Length)
							{
								if ((object)GM.Core == null)
								{
									break;
								}
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene == null)
								{
									break;
								}
								int num = (int)s_scene._renderer;
								if (s_scene._renderer == null || (object)items[obj] == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v17 (System.Int32)+14]");
								object obj3 = 0 ^ -0f;
								float num2 = (float)obj3 * 0.5f;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
								PhaserSprite phaserSprite = items[obj].setDepth((int)s_scene._renderer);
								List<object> radii2 = (List<object>)(object)_radii;
								Radi radi = new Radi();
								radi.Radius = 10f;
								if (_radii == null)
								{
									break;
								}
								int version2 = radii2._version + 1;
								radii2._version = version2;
								object[] items2 = radii2._items;
								if (radii2._items == null)
								{
									break;
								}
								if (radii2._size >= items2.Length)
								{
									((List<object>)(object)_radii).AddWithResize((object)radi);
								}
								else
								{
									int num3 = radii2._size + 1;
									radii2._size = num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								numbers = _Numbers;
								obj++;
								if (_Numbers == null)
								{
									break;
								}
								obj2 = obj;
								continue;
							}
						}
						else
						{
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						}
						throw new IndexOutOfRangeException();
					}
					object numbersParent = _NumbersParent;
					if ((object)_NumbersParent == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rbx_v10 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_NumbersParent);
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rbx_v10 (System.Object)+10]");
					Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
					object numbersParent2 = _NumbersParent;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rbx_v11 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rbx_v11 (System.Object)+10]");
					Transform.set_localRotation_Injected((IntPtr)0, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void FadeOut()
	{
		//IL_00ed: Expected O, but got I4
		//IL_0116: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_imageTween != null)
		{
			_imageTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		if (_Numbers != null)
		{
			PhaserSprite[] targets = _Numbers.ToArray();
			if (tweenConfig != null)
			{
				tweenConfig.targets = targets;
				tweenConfig.alpha = (float?)(object)1;
				tweenConfig.duration = 500f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BloodLancetProjectile>)+370]");
				TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
				nint num = (nint)this;
				tweenConfig.onComplete = onComplete;
				MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
				_alphaTween = alphaTween;
				if (_radiusTween != null)
				{
					List<Tweener>.Enumerator enumerator = default(List<Tweener>.Enumerator);
					while (enumerator.MoveNext())
					{
					}
					List<Tweener> radiusTween = new List<Tweener>();
					_radiusTween = radiusTween;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_008a: Invalid comparison between O and F4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00c7: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			object obj2 = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			bool flag2 = !flag;
			object obj3 = (_003F?)component._003CResDebuffs_003Ek__BackingField & flag2;
			bool flag3 = obj3 == null;
			object obj4 = !flag3;
			if (obj4 == null && component._003CSlow_003Ek__BackingField > 0.2f)
			{
				float num = _slowPower * 0.01f;
				float num2 = component._003CSlow_003Ek__BackingField - num;
				component._003CSlow_003Ek__BackingField = num2;
			}
		}
	}

	public BloodLancetProjectile()
	{
		List<Radi> radii = new List<Radi>();
		_radii = radii;
		_radiusTween = new List<Tweener>();
		base._002Ector();
	}

	private void _003COverrideWeaponData_003Eb__13_0()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		FadeOut();
	}

	private void _003COverrideWeaponData_003Eb__13_1()
	{
		//IL_0102: Expected O, but got I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0155->IL01ba: Incompatible stack heights: 8 vs 2
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		List<PhaserSprite> numbers = _Numbers;
		bool flag2 = _Numbers == null;
		Transform transform = null;
		Transform transform2 = null;
		List<PhaserSprite> numbers2 = _Numbers;
		while ((nint)transform < numbers._size)
		{
			bool flag3 = numbers2 == null;
			bool flag4 = (nint)transform2 >= numbers2._size;
			PhaserSprite[] items = numbers2._items;
			bool flag5 = numbers2._items == null;
			bool flag6 = (nint)transform2 >= items.Length;
			bool flag7 = (object)items[(object)transform2] == null;
			PhaserSprite phaserSprite = items[(object)transform2].setAlpha(0.5f);
			PhaserSprite phaserSprite2 = items[(object)transform2].setScale(1f, (float?)(object)1);
			numbers2 = _Numbers;
			transform2 = (Transform)(transform2 + 1);
			bool flag8 = _Numbers == null;
			transform = transform2;
			numbers = _Numbers;
		}
	}

	private void _003COverrideWeaponData_003Eb__13_2()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private void _003COverrideWeaponData_003Eb__13_3()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}
}
