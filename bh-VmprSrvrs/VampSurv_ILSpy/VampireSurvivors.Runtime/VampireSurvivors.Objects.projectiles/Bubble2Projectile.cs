using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Bubble2Projectile : Projectile
{
	private MultiTargetTween _speedTween;

	private MultiTargetTween _tween1;

	private float _saveVelX;

	private float _saveVelY;

	private bool _canBounce;

	private Vector2 _aimVec;

	public float _BombDeceleration = 1f;

	private List<Color> _colors;

	private int _colorIndex;

	private Timer _hitboxTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("circle8", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public void SetColor(uint color)
	{
		string[] array = new string[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		int num = random.Next(0, array.Length);
		Sprite sprite = SpriteManager.GetSprite(array[num], "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0a47: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0a6d: Expected O, but got F4
		//IL_0e57: Expected O, but got F4
		//IL_0aab: Expected O, but got F4
		//IL_00c7: Expected O, but got I
		//IL_00e7: Expected O, but got I
		//IL_00a3: Expected O, but got Ref
		//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Expected O, but got Unknown
		//IL_0121: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_01a3: Expected O, but got I4
		//IL_01cb: Expected F4, but got I4
		//IL_0af3: Expected F4, but got I4
		//IL_01fb: Expected O, but got I4
		//IL_0209: Expected O, but got I4
		//IL_0265: Expected I, but got O
		//IL_027b: Expected O, but got I
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_02f2: Expected I, but got O
		//IL_0b5a: Expected O, but got I4
		//IL_0b81: Expected I, but got I8
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_02db: Expected I, but got I8
		//IL_03cb: Expected O, but got I
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		//IL_0409: Invalid comparison between I4 and F4
		//IL_0be2: Invalid comparison between I4 and F4
		//IL_0c12: Invalid comparison between I4 and F4
		//IL_0c42: Invalid comparison between I4 and F4
		//IL_0cb0: Expected I4, but got O
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Expected F4, but got Unknown
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected Ref, but got Unknown
		//IL_056a: Expected O, but got F4
		//IL_05ce: Expected I, but got O
		//IL_0ced: Expected I, but got O
		//IL_0d03: Expected O, but got I
		//IL_0d0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d11: Expected O, but got Unknown
		//IL_0749: Expected I, but got O
		//IL_0d37: Expected O, but got I4
		//IL_0d4e: Expected I, but got I8
		//IL_0732: Expected I, but got I8
		//IL_07f4: Expected I, but got O
		//IL_0853: Expected O, but got I4
		//IL_087c: Expected O, but got I4
		//IL_0d6d: Expected I, but got O
		//IL_0d83: Expected O, but got I
		//IL_0d8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d91: Expected O, but got Unknown
		//IL_0906: Expected I, but got O
		//IL_0dc5: Expected I, but got I8
		//IL_0de4: Expected I, but got O
		//IL_0dfa: Expected O, but got I
		//IL_0e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e08: Expected O, but got Unknown
		//IL_08ef: Expected I, but got I8
		//IL_09a7: Expected I, but got O
		//IL_0e3c: Expected I, but got I8
		//IL_097a: Expected I, but got I8
		//IL_09e2: Expected O, but got I4
		//IL_09e2: Expected O, but got I4
		//IL_0817->IL0817: Incompatible stack heights: 3 vs 2
		base.InitProjectile(pool, weapon, index);
		_aimVec = (Vector2)0;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		List<Color> list = new List<Color>();
		list._002Ector();
		_colors = list;
		_colorIndex = 0;
		float? num = (float?)(object)0;
		float num3 = default(float);
		float num8 = default(float);
		do
		{
			List<Color> colors = _colors;
			object obj = UnityEngine.Random.value;
			object obj2 = UnityEngine.Random.value;
			float num2 = num3 * 128f;
			float num4 = num2 + 128f;
			float num5 = num4 / 255f;
			object obj3 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rdx_v19 (Il2CppMethodInfo)+18]");
			if (num7 >= 0)
			{
				colors.AddWithResize((Color)(&num8));
				num3 = num5;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
				object obj4 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rdi_v4 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
				object obj5 = (nint)0 + (nint)2;
				object obj6 = obj5 + obj5;
				num3 = num5;
			}
			num = (float?)(object)((_003F?)num + 1);
		}
		while ((nint)num < 20);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		BaseBody baseBody = base.body;
		BaseBody baseBody2 = base.body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody3 = base.body;
		baseBody3._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		ArcadeSprite arcadeSprite3 = setVisible(visible: true);
		ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
		Timer hitboxTimer = _hitboxTimer;
		bool flag = _hitboxTimer == null;
		float num9 = 1.0653532E+09f;
		if (!flag)
		{
			bool isDone = _hitboxTimer.IsDone;
			num9 = 1.0653532E+09f;
			if (!isDone)
			{
				float timeElapsed = _hitboxTimer.GetTimeElapsed();
				hitboxTimer._timeElapsedBeforeCancel = (float?)(object)1;
				hitboxTimer._timeElapsedBeforePause = (float?)(object)0;
				num9 = timeElapsed;
			}
		}
		WeaponData currentWeaponData = weapon._currentWeaponData;
		float num10 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num9);
		Action action = null;
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ r10_v9 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(Bubble2Projectile._003CInitProjectile_003Eb__12_0);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ r10_v9 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num12;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ r10_v9 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num12 = unchecked((nint)6447293664L);
				goto IL_0b51;
			}
		}
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		num12 = ((Delegate)action).method_ptr;
		goto IL_0b51;
		IL_0b51:
		object obj9 = 24;
		float duration = num10 * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer2 = Timers.Register(duration, action, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer2;
		List<Color> colors2 = _colors;
		int colorIndex = _colorIndex + 1;
		_colorIndex = colorIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj10 = (object)action >> 3;
		object obj11 = obj10 >> 31;
		object obj12 = obj10 + obj11;
		object obj13 = obj12 * 4;
		object obj14 = obj12 + obj13;
		object obj15 = obj14 << 2;
		object obj16 = _colorIndex - obj15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ r8_v23 (System.Collections.Generic.List`1<UnityEngine.Color>)+18]");
		bool flag2 = (nint)obj16 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ r8_v23 (System.Collections.Generic.List`1<UnityEngine.Color>)+10]");
		object obj17 = 0;
		object obj18 = obj16 + 2;
		object obj19 = obj18 + obj18;
		object obj20 = default(object);
		float num13 = (float)obj20 * 255f;
		if (0f > num13)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rdx,xmm0\"");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rdx_v28+v1619 @ rax_v70*8]");
		float num14 = 0f * 255f;
		if (0f > num14)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8,xmm0\"");
		}
		float num15 = (float)obj20 * 255f;
		if (0f > num15)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
		}
		float num16 = (float)obj20 * 255f;
		if (0f > num16)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm6\"");
		}
		object obj21 = obj17 << 8;
		object obj22 = obj21 | (object)colors2;
		object obj23 = obj22 << 8;
		object obj24 = obj23 | (object)typeof(ColorUtils);
		object obj25 = obj24 << 8;
		uint tint = (uint)(obj25 | obj19);
		ArcadeSprite arcadeSprite5 = setTint(tint);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num17 = height ^ 0;
		ArcadeSprite arcadeSprite6 = setDepth(num17);
		ref Vector2 forNearestEnemy = ref *(Vector2*)(this + 236);
		_isCullable = true;
		_saveVelX = 1f;
		_saveVelY = 1f;
		Transform transform = SetForNearestEnemy(ref forNearestEnemy);
		float num18 = weapon.PSpeed();
		float num19 = weapon.PSpeed();
		float num20 = num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Bubble2Projectile)+F0]");
		float num21 = num20 * 0f;
		float num22 = num15 * (float)_aimVec;
		BaseBody baseBody4 = base.body;
		baseBody4._velocity = (float2)num22;
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		_BombDeceleration = 1f;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num23 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj26 = default(object);
		bool flag3 = obj26 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_BombDeceleration", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		float num24 = weapon.PDuration();
		float num25 = (tweenConfig.delay = num21 * 0.25f);
		float num26 = weapon.PDuration();
		float duration2 = num25 * 0.75f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.duration = duration2;
		TweenCallback tweenCallback = null;
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ r10_v10 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(Bubble2Projectile._003CInitProjectile_003Eb__12_1);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ r10_v10 (Il2CppMethodInfo)+4C]");
		object obj27 = (nint)0 >> 4;
		object obj28 = obj27 & 1;
		nint num28;
		if (obj28 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ r10_v10 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num28 = unchecked((nint)6447293664L);
				goto IL_0d2e;
			}
		}
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		num28 = ((Delegate)tweenCallback).method_ptr;
		goto IL_0d2e;
		IL_0d2e:
		object obj29 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		tweenConfig.onComplete = tweenCallback;
		MultiTargetTween speedTween = Tweens.Add(tweenConfig);
		_speedTween = speedTween;
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num29 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj30 = default(object);
			bool flag5 = obj30 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		float num30 = weapon.PArea();
		tweenConfig2.scaleX = (float?)(object)1;
		float num31 = weapon.PArea();
		tweenConfig2.duration = 250f;
		tweenConfig2.scaleY = (float?)(object)1;
		TweenCallback tweenCallback2 = null;
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2318 @ r10_v11 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback2).method = (nint)__ldftn(Bubble2Projectile._003CInitProjectile_003Eb__12_2);
		((Delegate)tweenCallback2).m_target = this;
		((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2318 @ r10_v11 (Il2CppMethodInfo)+4C]");
		object obj31 = (nint)0 >> 4;
		object obj32 = obj31 & 1;
		nint num33;
		if (obj32 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2318 @ r10_v11 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num33 = unchecked((nint)6447293664L);
				goto IL_0dae;
			}
		}
		((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
		num33 = ((Delegate)tweenCallback2).method_ptr;
		goto IL_0dae;
		IL_0e25:
		TweenCallback tweenCallback3;
		((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
		tweenConfig2.onComplete = tweenCallback3;
		MultiTargetTween tween = Tweens.Add(tweenConfig2);
		_tween1 = tween;
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
		BaseBody baseBody5 = base.body;
		baseBody5._onWorldBounds = true;
		return;
		IL_0dae:
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		tweenConfig2.onStart = tweenCallback2;
		tweenCallback3 = null;
		nint num34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ r10_v12 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback3).method = (nint)__ldftn(Bubble2Projectile._003CInitProjectile_003Eb__12_3);
		((Delegate)tweenCallback3).m_target = this;
		((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ r10_v12 (Il2CppMethodInfo)+4C]");
		object obj33 = (nint)0 >> 4;
		object obj34 = obj33 & 1;
		nint num35;
		if (obj34 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ r10_v12 (Il2CppMethodInfo)+52]");
			bool flag6 = (nint)0 == 0;
			num35 = unchecked((nint)6447293664L);
			if (flag6)
			{
				goto IL_0e25;
			}
		}
		num35 = ((Delegate)tweenCallback3).method_ptr;
		((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
		goto IL_0e25;
	}

	public void FadeOut()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_renderer != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
	{
	}

	public void Decelerate()
	{
		_saveVelX = 0f;
	}

	private void JustBounce()
	{
		if (_canBounce)
		{
			float saveVelX = _saveVelX * -1f;
			_saveVelX = saveVelX;
			float saveVelY = _saveVelY * -1f;
			_saveVelY = saveVelY;
		}
	}

	public override void InternalUpdate()
	{
		//IL_0027: Expected O, but got I4
		float xVel = (float)_aimVec * _saveVelX;
		setVelocity(xVel, (float?)(object)1);
	}

	public override void Despawn()
	{
		//IL_006c: Expected O, but got I4
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		_speedTween = null;
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		_tween1 = null;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		base.Despawn();
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		_saveVelX = 0f;
	}

	public Bubble2Projectile()
	{
		List<Color> colors = new List<Color>();
		_colors = colors;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__12_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__12_1()
	{
		FadeOut();
	}

	private void _003CInitProjectile_003Eb__12_2()
	{
		//IL_003f: Expected O, but got I4
		ArcadeSprite arcadeSprite = setAlpha(0.65f);
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)1);
		_canBounce = false;
	}

	private void _003CInitProjectile_003Eb__12_3()
	{
		_canBounce = true;
	}

	private void _003CFadeOut_003Eb__13_0()
	{
		Despawn();
	}
}
