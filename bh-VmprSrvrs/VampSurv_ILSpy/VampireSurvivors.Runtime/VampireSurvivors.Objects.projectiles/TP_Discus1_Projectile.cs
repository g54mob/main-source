using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Discus1_Projectile : Projectile
{
	private enum ScreenEdge
	{
		None,
		Top,
		Bottom,
		Left,
		Right
	}

	private Vector3 _movement;

	private float _rotationInc;

	private float _flipSwitch;

	[NonSerialized]
	public float orbitRadius;

	[NonSerialized]
	public float orbitAngle;

	private MultiTargetTween _radiusTween;

	private MultiTargetTween _speedTween;

	private MultiTargetTween _scaleTween;

	private float _spinDuration;

	private bool _rotatingState;

	private bool _shootState;

	private bool _anticlockwiseSpin;

	private bool _hasStucktoWall;

	private Timer _explosionTimer;

	private ScreenEdge _screenEdge;

	private float2 _lastVelocity;

	protected virtual float SpeedFactor => 2f;

	protected virtual bool CanBounce => false;

	protected virtual string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A43B6]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_Discus03";
		}
	}

	protected override void Awake()
	{
		base.Awake();
		string frameName = FrameName;
		Sprite sprite = SpriteManager.GetSprite(frameName, "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_072d: Expected O, but got I4
		//IL_0751: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_006e: Expected I4, but got I8
		//IL_00fd: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected I4, but got Unknown
		//IL_07ad: Expected O, but got I4
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Expected O, but got Unknown
		//IL_00d0: Expected O, but got I4
		//IL_012b: Expected F4, but got I
		//IL_01e6: Expected I, but got O
		//IL_0245: Expected I, but got O
		//IL_025b: Invalid comparison between I4 and F4
		//IL_0370: Expected I, but got O
		//IL_04d7: Expected I, but got O
		//IL_053a: Expected O, but got I4
		//IL_06bb: Expected O, but got I4
		//IL_0638: Expected I, but got O
		//IL_067b: Expected I4, but got F4
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		setVelocity(0f, (float?)(object)0);
		float speedFactor = SpeedFactor;
		float speed = default(float);
		_speed = speed;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(20f, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		Vector3 movement = default(Vector3);
		_movement = movement;
		_ = 0;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		int num = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)((Equipment)weapon2)._003COwner_003Ek__BackingField < 0)
		{
			object obj = num - 1;
			object obj2 = obj | -2;
			num = obj2 + 1;
		}
		bool flag2;
		if (characterController._isFlipped)
		{
			object obj3 = num - 1;
			bool flag = obj3 == null;
			flag2 = !flag;
		}
		else
		{
			object obj4 = num - 1;
			bool flag3 = obj4 == null;
			flag2 = flag3;
		}
		ArcadeSprite arcadeSprite2 = setFlipX(flag2);
		_rotationInc = 0f;
		bool flag4 = base.flipX;
		object obj5 = (flag4 ? 1 : 0) ^ 1;
		object obj6 = obj5 * 2;
		float flipSwitch = (float)obj6 - 1f;
		_flipSwitch = flipSwitch;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Discus1_Projectile)+D4]");
		orbitAngle = 0f;
		orbitRadius = 0f;
		float num2 = _weapon.PSpeed();
		float speedFactor2 = SpeedFactor;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Discus1_Projectile)+D4]");
		float num3 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Discus1_Projectile)+D4]");
		float num4 = num3 * 0f;
		float spinDuration = 2000f / num4;
		_spinDuration = spinDuration;
		if (_radiusTween != null)
		{
			_radiusTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj7 = default(object);
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			nint num6 = (nint)weapon;
			float num7 = weapon.PArea();
			if (!(0f > num4))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			}
			float num8 = num4 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag5 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"orbitRadius", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.ease = Ease.OutExpo;
			tweenConfig.duration = _spinDuration;
			MultiTargetTween radiusTween = Tweens.Add(tweenConfig);
			_radiusTween = radiusTween;
			if (_speedTween != null)
			{
				_speedTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num9 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				float num10 = _flipSwitch * 5.2359877f;
				float num11 = num10 + orbitAngle;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value2 = default(object);
				bool flag6 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"orbitAngle", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary2;
				tweenConfig2.duration = _spinDuration;
				TweenCallback onComplete = shootDiscus;
				tweenConfig2.onComplete = onComplete;
				MultiTargetTween speedTween = Tweens.Add(tweenConfig2);
				_speedTween = speedTween;
				if (_scaleTween != null)
				{
					_scaleTween.Kill();
				}
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				nint num12 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig3.targets = array3;
					float num13 = weapon.PArea();
					tweenConfig3.scale = (float?)(object)1;
					float num14 = (tweenConfig3.duration = _spinDuration * 0.5f);
					MultiTargetTween scaleTween = Tweens.Add(tweenConfig3);
					_scaleTween = scaleTween;
					_rotatingState = true;
					_hasStucktoWall = false;
					float num17 = default(float);
					if (CanBounce)
					{
						Weapon weapon3 = _weapon;
						bool anticlockwiseSpin = ((Equipment)weapon3)._003COwner_003Ek__BackingField.flipX;
						_anticlockwiseSpin = anticlockwiseSpin;
						_screenEdge = ScreenEdge.None;
						if (_explosionTimer != null)
						{
							_explosionTimer.Cancel();
						}
						float num15 = _weapon.PDuration();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1593 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Discus1_Projectile>)+370]");
						Action onComplete2 = new Action(this, (IntPtr)0);
						nint num16 = (nint)this;
						float duration = num14 * 0.001f;
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer explosionTimer = Timers.Register(duration, onComplete2, null, isLooped: false, (byte)(int)num17 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_explosionTimer = explosionTimer;
						num17 = num17;
					}
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 0.7f;
					soundConfig.Volume = (float?)(object)1;
					float detune = (float)_indexInWeapon * -50f;
					soundConfig.Detune = detune;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Shuriken2, soundConfig, 200f, 10, num17);
					return;
				}
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	public void InitBouncing()
	{
		//IL_0085: Expected I, but got O
		Weapon weapon = _weapon;
		bool anticlockwiseSpin = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		_anticlockwiseSpin = anticlockwiseSpin;
		_screenEdge = ScreenEdge.None;
		if (_explosionTimer != null)
		{
			_explosionTimer.Cancel();
		}
		float num = _weapon.PDuration();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Discus1_Projectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num2 = (nint)this;
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer explosionTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_explosionTimer = explosionTimer;
	}

	public void shootDiscus()
	{
		//IL_0056: Expected O, but got I4
		_rotatingState = false;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1.2f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -75f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hasta, soundConfig, 200f, 10, time);
	}

	protected unsafe override void OnUpdate()
	{
		//IL_001b: Invalid comparison between F4 and I4
		//IL_00d6: Expected F4, but got O
		//IL_0419: Invalid comparison between O and F4
		//IL_044a: Invalid comparison between F4 and I
		//IL_046f: Expected O, but got Ref
		//IL_047c: Expected O, but got Ref
		//IL_0568->IL0568: Incompatible stack heights: 3 vs 0
		//IL_050d->IL0569: Incompatible stack heights: 3 vs 1
		CheckIfVisibleOnScreen();
		float pauseWallChecksTimer = base._pauseWallChecksTimer;
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer2 = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer2;
			pauseWallChecksTimer = deltaTime;
		}
		if (body == null)
		{
			return;
		}
		if (!CanBounce)
		{
			goto IL_0227;
		}
		float value = default(float);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					BaseBody baseBody = body;
					float num = (float)renderer.playArea;
					if (body != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rdx_v33 (BaseBody)+54]");
						object obj = default(object);
						BaseBody baseBody2;
						ScreenEdge screenEdge;
						BaseBody baseBody3;
						if ((nint)obj > 0 && _screenEdge != ScreenEdge.Bottom)
						{
							baseBody2 = body;
							baseBody3 = body;
							screenEdge = ScreenEdge.Bottom;
						}
						else
						{
							baseBody3 = body;
							baseBody2 = body;
							screenEdge = ScreenEdge.None;
						}
						object obj2 = baseBody3._size + baseBody2._position;
						pauseWallChecksTimer = (float)obj + num;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)pauseWallChecksTimer) && _screenEdge != ScreenEdge.Right)
						{
							screenEdge = ScreenEdge.Right;
						}
						ArcadeRect arcadeRect = (ArcadeRect)body;
						float num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r8_v12 (ArcadeRect)+50]");
						if (num2 > 0f && _screenEdge != ScreenEdge.Left)
						{
							screenEdge = ScreenEdge.Left;
						}
						else if (screenEdge == ScreenEdge.None)
						{
							if (_screenEdge == ScreenEdge.None)
							{
								goto IL_0227;
							}
							screenEdge = _screenEdge;
						}
						StickToScreenEdge(screenEdge, (ArcadeRect)(&value));
						baseBody3 = null;
						arcadeRect = (ArcadeRect)(&value);
						goto IL_0227;
					}
				}
			}
		}
		goto IL_0380;
		IL_0380:
		throw new NullReferenceException();
		IL_0227:
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				bool flag2 = !_rotatingState;
				float num3 = ret;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num4 = orbitAngle * orbitRadius;
					Transform cachedTransform = _cachedTransform;
					float num5 = num4 + 0.14f;
					object obj3 = default(object);
					num3 = num5 + (float)obj3;
					bool flag3 = (object)_cachedTransform == null;
					bool flag4 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
				}
				if (_shootState)
				{
					float projectileSpeed = base.ProjectileSpeed;
					float num6 = _flipSwitch * 1.2217305f;
					float rotation = num6 + orbitAngle;
					Vector2 vector = SetVelocityFromRotation(rotation, num3);
					BaseBody baseBody3 = null;
					float num = num3;
				}
				float deltaTime2 = PauseSystem.DeltaTime;
				float num7 = deltaTime2 * 1000f;
				float num8 = num7 * _flipSwitch;
				float rotationInc = num8 + _rotationInc;
				_rotationInc = rotationInc;
				Transform transform2 = base.transform;
				Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&value), out *(Quaternion*)(&ret));
				bool flag5 = (object)transform2 == null;
				bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Quaternion value2 = default(Quaternion);
				Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
				return;
			}
		}
		goto IL_0380;
	}

	private unsafe void HandleScreenEdges()
	{
		//IL_01f3: Expected O, but got Ref
		//IL_015b: Expected O, but got Ref
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v3 (BaseBody)+54]");
		object obj = default(object);
		BaseBody baseBody2;
		BaseBody baseBody3;
		ScreenEdge screenEdge;
		if ((nint)obj > 0 && _screenEdge != ScreenEdge.Bottom)
		{
			baseBody2 = body;
			baseBody3 = body;
			screenEdge = ScreenEdge.Bottom;
		}
		else
		{
			baseBody3 = baseBody;
			baseBody2 = baseBody;
			screenEdge = ScreenEdge.None;
		}
		object obj2 = baseBody3._size + baseBody2._position;
		object obj3 = obj + (object)renderer.playArea;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) && _screenEdge != ScreenEdge.Right)
		{
			screenEdge = ScreenEdge.Right;
		}
		BaseBody baseBody4 = body;
		ArcadeRect playArea = renderer.playArea;
		float2 obj4 = baseBody4._position;
		ArcadeRect arcadeRect = default(ArcadeRect);
		if (System.Runtime.CompilerServices.Unsafe.As<ArcadeRect, UIntPtr>(ref playArea) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref obj4) && _screenEdge != ScreenEdge.Left)
		{
			screenEdge = ScreenEdge.Left;
		}
		else if (screenEdge == ScreenEdge.None)
		{
			if (_screenEdge != ScreenEdge.None)
			{
				StickToScreenEdge(_screenEdge, (ArcadeRect)(&arcadeRect));
			}
			return;
		}
		StickToScreenEdge(screenEdge, (ArcadeRect)(&arcadeRect));
	}

	private void StickToScreenEdge(ScreenEdge nextEdge, ArcadeRect playArea)
	{
		//IL_000e: Expected O, but got I4
		//IL_024d: Expected O, but got I
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_02e0: Expected O, but got F4
		//IL_0214: Expected O, but got F4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_018a: Expected O, but got F4
		object obj = nextEdge - 1;
		bool flag = nextEdge == ScreenEdge.Top;
		BaseBody baseBody;
		float num4;
		float2 normal;
		float2 float5 = default(float2);
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 == 1)
					{
						baseBody = body;
						object obj4 = baseBody._size + baseBody._position;
						float num = playArea.width + playArea.x;
						float num2 = (float)obj4 - num;
						float num3 = num2 * 0f;
						num4 = num2 * -1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v3 (BaseBody)+54]");
						float num5 = 0f + num3;
						normal = float5;
						goto IL_02bf;
					}
					return;
				}
				BaseBody baseBody2 = body;
				float num6 = playArea.x - (float)baseBody2._position;
				float num7 = num6 + (float)baseBody2._position;
				float num8 = num6 * 0f;
				float num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v6 (BaseBody)+54]");
				float num10 = num9 + 0f;
				baseBody2._position = (float2)num7;
				normal = float5;
			}
			else
			{
				BaseBody baseBody3 = body;
				float num11 = playArea.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v4 (BaseBody)+54]");
				float num12 = num11 - 0f;
				float num13 = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v4 (BaseBody)+54]");
				float num14 = num13 + 0f;
				float num15 = num12 * 0f;
				float num16 = num15 + (float)baseBody3._position;
				baseBody3._position = (float2)num16;
				normal = float5;
			}
			goto IL_02e5;
		}
		baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v3 (BaseBody)+5C]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v3 (BaseBody)+54]");
		object obj5 = num17 + 0;
		float num18 = playArea.height + playArea.y;
		float num19 = (float)obj5 - num18;
		float num20 = num19 * -1f;
		num4 = num19 * 0f;
		float num21 = num20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v3 (BaseBody)+54]");
		float num22 = num21 + 0f;
		normal = float5;
		goto IL_02bf;
		IL_02bf:
		float num23 = num4 + (float)baseBody._position;
		baseBody._position = (float2)num23;
		goto IL_02e5;
		IL_02e5:
		StickToWall(normal);
		_screenEdge = nextEdge;
	}

	private bool HitsTop(ArcadeRect playArea)
	{
		//IL_00c1: Expected I4, but got O
		//IL_0046: Expected O, but got I
		//IL_0067: Invalid comparison between O and F4
		//IL_0085: Invalid comparison between F4 and I4
		BaseBody baseBody = body;
		if (body != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (BaseBody)+5C]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (BaseBody)+54]");
			object obj = num + 0;
			float num2 = playArea.height + playArea.y;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2);
			float num3 = (float)obj - num2;
			bool flag2 = num3 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool HitsBottom(ArcadeRect playArea)
	{
		//IL_00a5: Expected I4, but got O
		//IL_003e: Invalid comparison between F4 and I
		//IL_0069: Invalid comparison between F4 and I4
		BaseBody baseBody = body;
		if (body != null)
		{
			float y = playArea.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+54]");
			bool flag = y < 0f;
			float num = playArea.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+54]");
			float num2 = num - 0f;
			bool flag2 = num2 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool HitsRight(ArcadeRect playArea)
	{
		//IL_00bb: Expected I4, but got O
		//IL_0061: Invalid comparison between O and F4
		//IL_007f: Invalid comparison between F4 and I4
		BaseBody baseBody = body;
		if (body != null)
		{
			object obj = baseBody._size + baseBody._position;
			float num = playArea.width + playArea.x;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num);
			float num2 = (float)obj - num;
			bool flag2 = num2 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool HitsLeft(ArcadeRect playArea)
	{
		//IL_009f: Expected I4, but got O
		//IL_003b: Invalid comparison between F4 and O
		//IL_0063: Invalid comparison between F4 and I4
		BaseBody baseBody = body;
		if (body != null)
		{
			float x = playArea.x;
			float2 obj = baseBody._position;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref obj);
			float num = playArea.x - (float)baseBody._position;
			bool flag2 = num == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void StickToWall(float2 normal)
	{
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0040: Expected O, but got F4
		//IL_017c: Expected O, but got F4
		//IL_019f: Expected O, but got I4
		bool flag = !_anticlockwiseSpin;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = normal ^ 0;
		float num = (flag ? 1f : (-1f));
		object obj2 = default(object);
		float num2 = (float)obj2 * num;
		float num3 = (float)obj * num;
		float projectileSpeed = base.ProjectileSpeed;
		ArcadeSprite sprite = _sprite;
		float num4 = num2 * num;
		float num5 = num3 * num;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num4;
		BaseBody baseBody2 = body;
		_lastVelocity = baseBody2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v11 (BaseBody)+74]");
		_ = 0;
		_rotatingState = false;
		if (!_hasStucktoWall)
		{
			_hasStucktoWall = true;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj3 = UnityEngine.Random.value;
			float num6 = (float)baseBody2._velocity - 0.5f;
			soundConfig.Volume = (float?)(object)1;
			float detune = num6 * 200f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Discus2, soundConfig, 200f, 1, time);
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0005: Expected I, but got O
		//IL_0068: Expected O, but got I
		nint num = (nint)this;
		if (!CanBounce)
		{
			return;
		}
		BaseBody baseBody = body;
		object obj = baseBody._velocity - _lastVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v4 (BaseBody)+74]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Discus1_Projectile)+120]");
		object obj2 = num2 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870D3220h\"");
		if (obj == null)
		{
			bool flag = obj2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870D3220h\"");
			if (flag)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186252410");
		float2 normal = default(float2);
		StickToWall(normal);
		if (_screenEdge != ScreenEdge.None)
		{
			if (_anticlockwiseSpin)
			{
			}
			float2 float5 = base.position;
			base.position = normal;
			_screenEdge = ScreenEdge.None;
		}
	}

	public override void Despawn()
	{
		_rotatingState = false;
		if (_radiusTween != null)
		{
			_radiusTween.Kill();
		}
		if (_speedTween != null)
		{
			_speedTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_explosionTimer != null)
		{
			_explosionTimer.Cancel();
		}
		base.Despawn();
	}
}
