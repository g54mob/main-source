using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Spite2_Projectile : Projectile
{
	private float _bodyRadius;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeInTrailTween;

	private List<TP_Spite1_Projectile> _damageBoxes;

	private PhaserSprite _animatedSprite;

	private PhaserSprite _animatedSprite2;

	private PhaserSprite _displaySprite;

	private float despawnCountdown;

	private bool isDespawning;

	private List<float> angles;

	private MultiTargetTween _scale1Tween;

	private MultiTargetTween _scale2Tween;

	private MultiTargetTween _scale3Tween;

	private float despawnTimer;

	private Vector2 direction;

	protected override void Awake()
	{
		//IL_01e8: Expected O, but got I4
		//IL_01e8: Expected I4, but got O
		//IL_0223: Expected O, but got I4
		//IL_0223: Expected I4, but got O
		//IL_025e: Expected O, but got I4
		//IL_025e: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Acerbatus14");
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("_displaySprite");
		_displaySprite = phaserSprite;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "ThosePeople", "TP_VFX_Acerbatus01");
		GameObject gameObject4 = phaserSprite2.gameObject;
		((UnityEngine.Object)gameObject4).SetName("_animatedSprite");
		_animatedSprite = phaserSprite2;
		GameObject gameObject5 = base.gameObject;
		PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject5, vector, "ThosePeople", "TP_VFX_Acerbatus01");
		GameObject gameObject6 = phaserSprite3.gameObject;
		((UnityEngine.Object)gameObject6).SetName("_animatedSprite2");
		_animatedSprite2 = phaserSprite3;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Acerbatus", 1, 10, vector, text, num, flag);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Acerbatus", 11, 22, vector, text, num, flag);
		PhaserSprite animatedSprite = _animatedSprite;
		Action action = StartPulse;
		bool autoSetAnimation = default(bool);
		animatedSprite._spriteAnimation.AddAnimation("start", animationFrames, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite2 = _animatedSprite;
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames2, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite2;
		animatedSprite3._spriteAnimation.AddAnimation("loop", animationFrames2, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
	}

	public void SetDamageBoxes(List<TP_Spite1_Projectile> boxes)
	{
		//IL_002b: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_00b5->IL0156: Incompatible stack heights: 1 vs 0
		//IL_00ec->IL0156: Incompatible stack heights: 1 vs 0
		//IL_01c7->IL0156: Incompatible stack heights: 2 vs 0
		//IL_0142->IL0156: Incompatible stack heights: 2 vs 0
		//IL_0155->IL01cc: Incompatible stack heights: 2 vs 0
		List<TP_Spite1_Projectile> damageBoxes = default(List<TP_Spite1_Projectile>);
		_damageBoxes = damageBoxes;
		List<TP_Spite1_Projectile> damageBoxes2 = _damageBoxes;
		bool flag = _damageBoxes == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				if ((nint)obj < damageBoxes2._size)
				{
					List<TP_Spite1_Projectile> damageBoxes3 = _damageBoxes;
					if (_damageBoxes == null)
					{
						break;
					}
					bool flag2 = (nint)obj2 >= damageBoxes3._size;
					TP_Spite1_Projectile[] items = damageBoxes3._items;
					if (damageBoxes3._items == null)
					{
						break;
					}
					object obj3 = items[obj2];
					if ((object)items[obj2] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v4 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v4 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					transform.SetParent(_cachedTransform, worldPositionStays: true);
					damageBoxes2 = _damageBoxes;
					obj2++;
					if (_damageBoxes == null)
					{
						break;
					}
					obj = obj2;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_034d: Expected O, but got I4
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected F4, but got Unknown
		//IL_002b: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0147: Expected O, but got Ref
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float bodyRadius = _bodyRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float xScale = bodyRadius ^ 0;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		_speed = 4f;
		_isCullable = false;
		despawnCountdown = 1000f;
		isDespawning = false;
		despawnTimer = 0f;
		setVelocity(0f, (float?)(object)0);
		if (_indexInWeapon != 0)
		{
			despawnCountdown = 3000f;
			PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
			PhaserSprite phaserSprite2 = _animatedSprite2.setVisible(visible: false);
			PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: false);
			Action onComplete = StartDespawn;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			object obj = default(object);
			ApplyPlayerFacingVelocity((Vector3)(&obj));
			return;
		}
		float num = weapon.PArea();
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
		PhaserSprite phaserSprite4 = _displaySprite.setVisible(visible: false);
		PhaserSprite phaserSprite5 = _animatedSprite2.setVisible(visible: false);
		PhaserSprite phaserSprite6 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("start");
		PhaserSprite phaserSprite7 = _animatedSprite.setAlpha(1f);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		direction = characterController._lastFacingDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v15 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
		_ = 0;
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		bool flag = 0 < (nint)direction;
		object obj2 = 0 - direction;
		bool flag2 = obj2 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		PhaserSprite phaserSprite8 = _displaySprite.setFlipX(flag5);
		PhaserSprite phaserSprite9 = _animatedSprite.setFlipX(flag5);
		PhaserSprite phaserSprite10 = _animatedSprite2.setFlipX(flag5);
		PhaserSprite phaserSprite11 = _displaySprite.setDepth(1000);
		PhaserSprite phaserSprite12 = _animatedSprite.setDepth(1001);
		PhaserSprite phaserSprite13 = _animatedSprite2.setDepth(1002);
	}

	private unsafe void StartPulse()
	{
		//IL_0021: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_003c: Expected I, but got O
		//IL_0052: Expected O, but got I
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00c9: Expected I, but got O
		//IL_024d: Expected I, but got I8
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_00b2: Expected I, but got I8
		//IL_0304: Expected I, but got O
		//IL_031a: Expected O, but got I
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_020a: Expected I, but got O
		//IL_035c: Expected I, but got I8
		//IL_01f3: Expected I, but got I8
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("loop");
		object obj = 24;
		object obj2 = 1;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(TP_Spite2_Projectile._003CStartPulse_003Eb__18_3);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num2;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_0236;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_0236;
			IL_0236:
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float duration = (float)obj2 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			obj2 += 300;
		}
		while ((nint)obj2 < 901);
		despawnCountdown = 1200f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((TP_Spite2_Projectile)(object)dOSetter)._003CStartPulse_003Eb__18_1(x);
		float duration2 = despawnCountdown * 0.0005f;
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, duration2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ r10_v4 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(TP_Spite2_Projectile._003CStartPulse_003Eb__18_2);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ r10_v4 (Il2CppMethodInfo)+4C]");
		object obj5 = (nint)0 >> 4;
		object obj6 = obj5 & 1;
		nint num4;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ r10_v4 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num4 = unchecked((nint)6447293664L);
				goto IL_0345;
			}
		}
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		num4 = ((Delegate)tweenCallback).method_ptr;
		goto IL_0345;
		IL_0345:
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
	}

	private void Pulse()
	{
		//IL_00aa: Expected I, but got O
		//IL_010e: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_045d: Expected I4, but got O
		//IL_0461: Expected O, but got I4
		//IL_0273: Expected I, but got O
		//IL_02c5: Expected O, but got I4
		//IL_02e1: Expected O, but got I4
		//IL_037a: Expected I, but got O
		//IL_03cc: Expected O, but got I4
		//IL_03f6: Expected O, but got I4
		//IL_0296->IL0296: Incompatible stack heights: 1 vs 0
		//IL_039d->IL039d: Incompatible stack heights: 1 vs 0
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _displaySprite.setAlpha(0.65f);
		if (_scale1Tween != null)
		{
			_scale1Tween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
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
		tweenConfig.duration = 300f;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween scale1Tween = Tweens.Add(tweenConfig);
		_scale1Tween = scale1Tween;
		PhaserSprite phaserSprite3 = _animatedSprite2.setVisible(visible: true);
		PhaserSprite phaserSprite4 = _animatedSprite2.setAlpha(0.65f);
		PhaserSprite animatedSprite = _animatedSprite2;
		animatedSprite._spriteAnimation.SetAnimation("loop");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj3 = default(object);
		object obj2 = UnityEngine.Random.RandomRangeInt(0, (int)obj3);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F6620");
		float num3 = default(float);
		_animatedSprite2.angle = num3;
		if (_scale2Tween != null)
		{
			_scale2Tween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_animatedSprite2 != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.duration = 150f;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween scale2Tween = Tweens.Add(tweenConfig2);
		_scale2Tween = scale2Tween;
		if (_scale3Tween != null)
		{
			_scale3Tween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_animatedSprite2 != null)
		{
			nint num5 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			bool flag2 = obj5 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.scale = (float?)(object)1;
		tweenConfig3.duration = 150f;
		tweenConfig3.delay = 150f;
		tweenConfig3.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			Transform transform = _animatedSprite2.transform;
			float num6 = transform.localEulerAngles.z + 90f;
			_animatedSprite2.angle = num6;
		};
		tweenConfig3.onStart = onStart;
		MultiTargetTween scale3Tween = Tweens.Add(tweenConfig3);
		_scale3Tween = scale3Tween;
	}

	private void StartDespawn()
	{
		//IL_0088: Expected I, but got O
		//IL_00ec: Expected O, but got I4
		//IL_0107: Expected I, but got O
		if (isDespawning)
		{
			return;
		}
		isDespawning = true;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite != null)
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
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Spite2_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	protected override void OnUpdate()
	{
		//IL_0011: Invalid comparison between F4 and I4
		CheckIfVisibleOnScreen();
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
		float deltaTime2 = PauseSystem.DeltaTime;
		float num = deltaTime2 * 1000f;
		if (!((despawnTimer = num + despawnTimer) < despawnCountdown))
		{
			StartDespawn();
		}
	}

	public override void Despawn()
	{
		//IL_02b8: Expected O, but got I4
		//IL_02c1: Expected O, but got I4
		//IL_036d: Expected I, but got O
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_009c->IL028d: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL028d: Incompatible stack heights: 1 vs 0
		//IL_032a->IL028d: Incompatible stack heights: 2 vs 0
		//IL_03a9->IL028d: Incompatible stack heights: 3 vs 0
		//IL_00fe->IL0005: Incompatible stack heights: 3 vs 0
		List<TP_Spite1_Projectile> damageBoxes = _damageBoxes;
		bool flag = _damageBoxes == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				if ((nint)obj2 < damageBoxes._size)
				{
					List<TP_Spite1_Projectile> damageBoxes2 = _damageBoxes;
					if (_damageBoxes == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= damageBoxes2._size;
					TP_Spite1_Projectile[] items = damageBoxes2._items;
					if (damageBoxes2._items == null)
					{
						break;
					}
					object obj3 = items[obj];
					if ((object)items[obj] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdi_v10 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdi_v10 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					if ((object)transform == null)
					{
						break;
					}
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
					nint num = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v624 @ rax_v45 (Il2CppClass<System.Object>)+368] (should have been resolved before IL gen)");
					damageBoxes = _damageBoxes;
					obj++;
					if (_damageBoxes == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				if (_scaleTween != null)
				{
					_scaleTween.Kill();
				}
				if (_fadeInTrailTween != null)
				{
					_fadeInTrailTween.Kill();
				}
				if (_scale1Tween != null)
				{
					_scale1Tween.Kill();
				}
				if (_scale2Tween != null)
				{
					_scale2Tween.Kill();
				}
				if (_scale3Tween != null)
				{
					_scale3Tween.Kill();
				}
				List<TP_Spite1_Projectile> damageBoxes3 = _damageBoxes;
				if (_damageBoxes == null)
				{
					break;
				}
				int version = damageBoxes3._version + 1;
				damageBoxes3._version = version;
				damageBoxes3._size = 0;
				if (damageBoxes3._size > 0)
				{
					Array.Clear(damageBoxes3._items, 0, damageBoxes3._size);
				}
				base.Despawn();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public TP_Spite2_Projectile()
	{
		//IL_0037: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_0237: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_025f: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_0287: Expected O, but got I
		//IL_01cf: Expected O, but got I
		_bodyRadius = 36f;
		List<TP_Spite1_Projectile> damageBoxes = new List<TP_Spite1_Projectile>();
		_damageBoxes = damageBoxes;
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(90f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1119092736;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(180f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1127481344;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v9+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(270f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1132920832;
		}
		angles = list;
		base._002Ector();
	}

	private void _003CStartPulse_003Eb__18_3()
	{
		Pulse();
	}

	private float _003CStartPulse_003Eb__18_0()
	{
		return _speed;
	}

	private void _003CStartPulse_003Eb__18_1(float x)
	{
		_speed = x;
	}

	private void _003CStartPulse_003Eb__18_2()
	{
		//IL_002f: Expected O, but got I4
		float projectileSpeed = base.ProjectileSpeed;
		object obj = default(object);
		float xVel = (float)obj * (float)direction;
		setVelocity(xVel, (float?)(object)1);
	}

	private void _003CPulse_003Eb__19_0()
	{
		Transform transform = _animatedSprite2.transform;
		float num = transform.localEulerAngles.z + 90f;
		_animatedSprite2.angle = num;
	}
}
