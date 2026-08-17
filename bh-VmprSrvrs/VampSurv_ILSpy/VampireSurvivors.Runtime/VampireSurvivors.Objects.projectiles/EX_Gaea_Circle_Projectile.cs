using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EX_Gaea_Circle_Projectile : Projectile
{
	private Timer expireTimer;

	private bool _isDespawning;

	private Vector2 _collisionPos;

	private Vector2 _spritePos;

	private Transform _cachedSpriteTransform;

	private Material material;

	private static readonly int _matColor;

	private static readonly int _matAlpha;

	private static readonly int _matCutout;

	private Tween angleTween;

	private MultiTargetTween _tween1;

	private Timer hitboxTimer;

	private Tween cutoutTween;

	private List<Vector3> colors;

	protected override void Awake()
	{
		base.Awake();
		_renderer.enabled = false;
		Material material = ((Renderer)_renderer).GetMaterial();
		this.material = material;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0034: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_088b: Expected I4, but got I8
		//IL_08c0: Expected I4, but got O
		//IL_08c4: Expected O, but got I4
		//IL_09bb: Expected I, but got O
		//IL_09de: Expected O, but got I4
		//IL_0117: Expected O, but got I
		//IL_0120: Expected O, but got I4
		//IL_0189: Expected O, but got Ref
		//IL_06aa: Expected O, but got I
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected O, but got Unknown
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0430: Expected I, but got O
		//IL_04cb: Expected O, but got I4
		//IL_0528: Expected I, but got O
		//IL_0589: Expected O, but got I4
		//IL_0929: Expected O, but got F4
		//IL_071b: Expected O, but got Ref
		//IL_0799: Expected F4, but got I4
		//IL_07b5: Expected F4, but got I4
		//IL_07eb: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float num = _weapon.PArea();
		BaseBody baseBody = body.setCircle(64f, (float?)(object)0, (float?)(object)0);
		float num2 = default(float);
		ArcadeSprite arcadeSprite = setScale(num2, (float?)(object)0);
		_renderer.enabled = true;
		object renderer = _renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdi_v8 (System.Object)+10]");
		if ((nint)0 == 0)
		{
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(renderer);
			throw new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdi_v8 (System.Object)+10]");
		Renderer.set_sortingOrder_Injected((IntPtr)0, -1998);
		float value;
		if (_indexInWeapon == 0)
		{
			float num3 = num2;
			value = 0.5f;
		}
		else
		{
			num2 = (float)_indexInWeapon * 0.5f;
			float num3 = 0.4f - num2;
			bool flag = 0.1f > num3;
			value = 0.1f;
			if (!flag)
			{
				value = num3;
			}
		}
		nint num4 = 0;
		List<Vector3> list = colors;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rdi_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = UnityEngine.Random.RandomRangeInt(0, (int)obj2);
		nint num5 = (nint)list;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1073 @ r10_v6 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.Vector3>>)+12E]");
		bool flag2 = (nint)0 >= (nint)0;
		object obj3 = 0;
		if (flag2)
		{
			goto IL_0157;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1073 @ r10_v6 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.Vector3>>)+B0]");
		obj3 = 0;
		float? num6 = (float?)(object)0;
		while (true)
		{
			object obj4 = (object?)num6 + (object?)num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ r9_v26+v1090 @ rax_v168*8]");
			if ((nint)0 == 0)
			{
				break;
			}
			num6 = (float?)(object)((_003F?)num6 + 1);
			float? num7 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1073 @ r10_v6 (Il2CppClass<System.Collections.Generic.List`1<UnityEngine.Vector3>>)+12E]");
			if ((nint)num7 < 0)
			{
				continue;
			}
			goto IL_0157;
		}
		object obj5 = (object?)num6 + (object?)num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ r9_v26+8+v1147 @ rcx_v130*8]");
		object obj6 = (nint)0 << 4;
		object obj7 = obj6 + 312;
		object obj8 = obj7 + num5;
		goto IL_0166;
		IL_0157:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
		goto IL_0166;
		IL_0166:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1144 @ rax_v41] (should have been resolved before IL gen)");
		object obj9 = default(object);
		material.SetVector(_matColor, (Vector4)(&obj9));
		material.SetFloatImpl(_matAlpha, value);
		material.SetFloatImpl(_matCutout, 0.75f);
		float num8 = weapon.PDuration();
		object obj10 = default(object);
		float delay = (float)obj10 * 0.001f;
		float hitBoxDelay = weapon.HitBoxDelay;
		Tween tween = cutoutTween;
		float num9 = hitBoxDelay * 0.001f;
		if (cutoutTween != null && tween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(cutoutTween);
		}
		float duration = num9 + num9;
		TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, -0.75f, _matCutout, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1223 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1223 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1223 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1223 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		cutoutTween = tweenerCore;
		TweenerCore<float, float, FloatOptions> tweenerCore2 = ShortcutExtensions.DOFloat(material, 0f, _matAlpha, num9);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1479 @ rax_v59 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		TweenerCore<float, float, FloatOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(tweenerCore2, delay);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Gaea_Circle_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num10 = (nint)this;
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1564 @ rax_v61 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num11 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj11 = default(object);
		bool flag3 = obj11 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		float num12 = _weapon.PArea();
		tweenConfig.scale = (float?)(object)1;
		float hitBoxDelay2 = weapon.HitBoxDelay;
		tweenConfig.duration = hitBoxDelay2;
		MultiTargetTween tween2 = Tweens.Add(tweenConfig);
		_tween1 = tween2;
		if (hitboxTimer != null)
		{
			hitboxTimer.Cancel();
		}
		float hitBoxDelay3 = weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num13 = hitBoxDelay3 * 0.001f;
		bool flag4 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(num13, onComplete, null, isLooped: true, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		hitboxTimer = timer;
		bool flag5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		object obj12 = UnityEngine.Random.value;
		float num14 = num13 * 360f;
		base.angle = num14;
		if (flag5)
		{
		}
		if (angleTween != null)
		{
			TweenExtensions.Kill(angleTween);
		}
		Transform target = base.transform;
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		object obj13 = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DORotate(target, (Vector3)(&obj13), num9);
		if (tweenerCore4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ rax_v96 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		bool flag6 = (nint)0 != 0;
		float time = (flag4 ? 1 : 0);
		if (!flag6)
		{
			_ = 1;
			time = (flag4 ? 1 : 0);
		}
		angleTween = tweenerCore4;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MoonFinisher, new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 4f
		}, 200f, 2, time);
	}

	public override void Despawn()
	{
		if (hitboxTimer != null)
		{
			hitboxTimer.Cancel();
		}
		if (angleTween != null)
		{
			TweenExtensions.Kill(angleTween);
		}
		_renderer.enabled = false;
		if (expireTimer != null)
		{
			expireTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00ef: Invalid comparison between O and F4
		//IL_0131: Invalid comparison between O and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		if (obj2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v6+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			EnemyController component = gameObject.GetComponent<EnemyController>();
			object obj3 = default(object);
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && ((object)component._003CResDebuffs_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)) && ((object)component._003CResDefang_003Ek__BackingField == null || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)))
			{
				bool flag = TryDefang(component);
			}
		}
	}

	public unsafe EX_Gaea_Circle_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0089: Expected O, but got I
		//IL_00a9: Expected O, but got I
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_0066: Expected O, but got Ref
		//IL_0429: Expected O, but got I
		//IL_012a: Expected O, but got I
		//IL_014a: Expected O, but got I
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0107: Expected O, but got Ref
		//IL_0451: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_01eb: Expected O, but got I
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_01a8: Expected O, but got Ref
		//IL_0479: Expected O, but got I
		//IL_026c: Expected O, but got I
		//IL_028c: Expected O, but got I
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_0249: Expected O, but got Ref
		//IL_04a1: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_032d: Expected O, but got I
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_02ea: Expected O, but got Ref
		//IL_04c9: Expected O, but got I
		//IL_03a6: Expected O, but got I
		//IL_03c6: Expected O, but got I
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_038b: Expected O, but got Ref
		List<Vector3> list = new List<Vector3>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v4+18]");
		object obj2 = default(object);
		object obj3 = default(object);
		if (num >= 0)
		{
			list.AddWithResize((Vector3)(&obj2));
			obj2 = obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj5 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj6 = 0 + obj5;
			_ = 1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize((Vector3)(&obj2));
			obj2 = obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj9 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj10 = 0 + obj9;
			_ = 1f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize((Vector3)(&obj2));
			obj2 = obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj12 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj13 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj14 = 0 + obj13;
			_ = 0.8f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize((Vector3)(&obj2));
			obj2 = obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj16 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj17 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj18 = 0 + obj17;
			_ = 0.9f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize((Vector3)(&obj2));
			obj2 = obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj20 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj21 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj22 = 0 + obj21;
			_ = 0.5f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list.AddWithResize((Vector3)(&obj2));
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj24 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj25 = (nint)0 * (nint)2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
			object obj26 = 0 + obj25;
			_ = 0.25f;
		}
		colors = list;
		base._002Ector();
	}

	static EX_Gaea_Circle_Projectile()
	{
		int matColor = Shader.PropertyToID("_InputColor");
		_matColor = matColor;
		int matAlpha = Shader.PropertyToID("_AlphaMul");
		_matAlpha = matAlpha;
		int matCutout = Shader.PropertyToID("_Cutout");
		_matCutout = matCutout;
	}

	private void _003CInitProjectile_003Eb__15_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
