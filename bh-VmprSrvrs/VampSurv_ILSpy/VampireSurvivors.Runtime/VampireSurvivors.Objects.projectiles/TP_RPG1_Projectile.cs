using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_RPG1_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public TP_RPG1_Projectile _003C_003E4__this;

		public Weapon weapon;

		public float rollDuration;

		public float2 targetPos;

		internal void _003CInitProjectile_003Eb__0()
		{
			//IL_00a7: Expected I, but got O
			//IL_011e: Expected O, but got I4
			//IL_01c7: Expected I, but got O
			//IL_021d: Expected O, but got I4
			//IL_02c7: Expected O, but got F4
			//IL_02f7: Expected O, but got I4
			_003C_003E4__this.DoTintCycle();
			TP_RPG1_Projectile tP_RPG1_Projectile = _003C_003E4__this;
			if (tP_RPG1_Projectile._scaleGrenadeTween != null)
			{
				tP_RPG1_Projectile._scaleGrenadeTween.Kill();
			}
			TP_RPG1_Projectile tP_RPG1_Projectile2 = _003C_003E4__this;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_003C_003E4__this != null)
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
			Weapon weapon = this.weapon;
			float num2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PArea();
			tweenConfig.scale = (float?)(object)1;
			float duration = rollDuration * 0.5f;
			tweenConfig.yoyo = true;
			tweenConfig.duration = duration;
			MultiTargetTween scaleGrenadeTween = Tweens.Add(tweenConfig);
			tP_RPG1_Projectile2._scaleGrenadeTween = scaleGrenadeTween;
			TP_RPG1_Projectile tP_RPG1_Projectile3 = _003C_003E4__this;
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_003C_003E4__this != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.x = (float?)(object)1;
			tweenConfig2.duration = rollDuration;
			tweenConfig2.ease = Ease.OutSine;
			MultiTargetTween moveXTween = Tweens.Add(tweenConfig2);
			tP_RPG1_Projectile3._moveXTween = moveXTween;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.9f;
			object obj3 = UnityEngine.Random.value;
			float num4 = (float)targetPos - 0.5f;
			float detune = num4 * 500f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Grenade1, soundConfig, 200f, 10, time);
		}

		internal void _003CInitProjectile_003Eb__1()
		{
			//IL_008d: Expected I, but got O
			//IL_00e3: Expected O, but got I4
			TP_RPG1_Projectile tP_RPG1_Projectile = _003C_003E4__this;
			if (tP_RPG1_Projectile._moveYTween2 != null)
			{
				tP_RPG1_Projectile._moveYTween2.Kill();
			}
			TP_RPG1_Projectile tP_RPG1_Projectile2 = _003C_003E4__this;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_003C_003E4__this != null)
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
			tweenConfig.y = (float?)(object)1;
			tweenConfig.duration = rollDuration;
			tweenConfig.ease = Ease.Linear;
			MultiTargetTween moveYTween = Tweens.Add(tweenConfig);
			tP_RPG1_Projectile2._moveYTween2 = moveYTween;
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public TP_RPG1_Projectile _003C_003E4__this;

		public float millis;

		public Action _003C_003E9__1;

		internal void _003CDoTintCycle_003Eb__0()
		{
			ArcadeSprite arcadeSprite = _003C_003E4__this.setTint(16711680u);
			TP_RPG1_Projectile tP_RPG1_Projectile = _003C_003E4__this;
			if (tP_RPG1_Projectile._tintTimer != null)
			{
				tP_RPG1_Projectile._tintTimer.Cancel();
			}
			Action onComplete = _003C_003E9__1;
			TP_RPG1_Projectile tP_RPG1_Projectile2 = _003C_003E4__this;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					_003C_003E4__this.DoTintCycle();
				});
			}
			float duration = millis * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer tintTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			tP_RPG1_Projectile2._tintTimer = tintTimer;
		}

		internal void _003CDoTintCycle_003Eb__1()
		{
			_003C_003E4__this.DoTintCycle();
		}
	}

	private Tween _angleTween;

	private MultiTargetTween _moveXTween;

	private MultiTargetTween _moveYTween;

	private MultiTargetTween _moveYTween2;

	private MultiTargetTween _scaleGrenadeTween;

	private TP_RPG1_Weapon _rpgWeapon;

	private Timer _tintTimer;

	private const uint Red = 16711680u;

	private const uint White = 16777215u;

	private float _explosionDelay = 250f;

	private Timer _explosionTimer;

	private float _throwSpeed = 800f;

	private float _rollSpeed = 1500f;

	private float _landToTargetPosRatio = 0.85f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_BOMB00", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b0: Expected O, but got I4
		//IL_0105: Expected I, but got O
		//IL_011d: Expected O, but got I
		//IL_019d: Expected O, but got I4
		//IL_00e9: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0df2: Expected O, but got I4
		//IL_0159: Expected O, but got I
		//IL_018f: Expected O, but got I4
		//IL_0e09: Expected O, but got F4
		//IL_0269: Expected I, but got O
		//IL_114e: Expected O, but got F4
		//IL_0e47: Expected O, but got F4
		//IL_03a5: Expected O, but got F4
		//IL_0ed2: Expected O, but got I4
		//IL_04d1: Expected O, but got I4
		//IL_0562: Invalid comparison between F4 and I4
		//IL_057e: Expected O, but got I4
		//IL_05e2: Expected O, but got F4
		//IL_05f2: Expected O, but got I4
		//IL_102f: Invalid comparison between F4 and O
		//IL_1178: Expected O, but got I
		//IL_11a2: Expected O, but got I
		//IL_1069: Expected O, but got I
		//IL_0774: Expected I4, but got I8
		//IL_11c4: Expected I4, but got O
		//IL_07ae: Expected O, but got I8
		//IL_07e8: Expected O, but got I8
		//IL_10e8: Expected O, but got Ref
		//IL_0842: Expected O, but got Ref
		//IL_0815: Expected O, but got I4
		//IL_0b52: Expected O, but got I4
		//IL_0c99: Expected O, but got I4
		//IL_0d78: Expected I4, but got F4
		//IL_0fe7->IL0d8c: Incompatible stack heights: 1 vs 0
		//IL_0729->IL0d8c: Incompatible stack heights: 1 vs 0
		//IL_0758->IL0d8c: Incompatible stack heights: 1 vs 0
		//IL_07b3->IL104f: Incompatible stack heights: 3 vs 2
		//IL_07ed->IL11b0: Incompatible stack heights: 3 vs 2
		//IL_095b->IL0d8c: Incompatible stack heights: 4 vs 0
		//IL_09ad->IL0d8c: Incompatible stack heights: 5 vs 0
		//IL_09e1->IL0d8c: Incompatible stack heights: 5 vs 0
		//IL_0a03->IL0d8c: Incompatible stack heights: 5 vs 0
		//IL_0ac0->IL0d8c: Incompatible stack heights: 5 vs 0
		//IL_0b17->IL0d8c: Incompatible stack heights: 6 vs 0
		//IL_0c02->IL0d8c: Incompatible stack heights: 6 vs 0
		//IL_0c59->IL0d8c: Incompatible stack heights: 7 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals27 = new _003C_003Ec__DisplayClass15_0();
		float num2 = default(float);
		float? rpgWeapon;
		object obj6;
		if (CS_0024_003C_003E8__locals27 != null)
		{
			CS_0024_003C_003E8__locals27._003C_003E4__this = this;
			CS_0024_003C_003E8__locals27.weapon = weapon;
			base.InitProjectile(pool, CS_0024_003C_003E8__locals27.weapon, index);
			_isCullable = false;
			Weapon weapon2 = CS_0024_003C_003E8__locals27.weapon;
			if ((object)CS_0024_003C_003E8__locals27.weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				float num = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PArea();
				ArcadeSprite arcadeSprite = setScale(num2, (float?)(object)0);
				float? weapon3 = (float?)_weapon;
				object obj3;
				if ((object)_weapon == null)
				{
					obj3 = 0;
					rpgWeapon = (float?)(object)0;
					goto IL_0dcb;
				}
				nint num3 = (nint)typeof(TP_RPG1_Weapon);
				obj3 = weapon3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rdx_v117 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ r9_v20+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rdx_v117 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_RPG1_Weapon>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ r9_v20+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ rax_v244+FFFFFFF8+v925 @ rax_v239*8]");
					if (0 == (nint)typeof(TP_RPG1_Weapon))
					{
						obj6 = 1;
						goto IL_0dda;
					}
				}
				obj6 = 0;
				goto IL_0dda;
			}
		}
		goto IL_0d8c;
		IL_0dda:
		bool flag = obj6 == null;
		rpgWeapon = (float?)(object)0;
		if (!flag)
		{
			rpgWeapon = (float?)_weapon;
		}
		goto IL_0dcb;
		IL_0dcb:
		_rpgWeapon = (TP_RPG1_Weapon)rpgWeapon;
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = false;
			ArcadeSprite arcadeSprite2 = setTint(16777215u);
			ArcadeSprite arcadeSprite3 = setAlpha(1f);
			ArcadeSprite arcadeSprite4 = setVisible(visible: true);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.5f;
			object obj7 = UnityEngine.Random.value;
			float num5 = num2 - 0.5f;
			_ = 1;
			float num6 = num5 * 200f;
			float num7 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Spinning, soundConfig, 200f, 10, num7);
			nint num8 = (nint)typeof(float2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1325 @ rax_v69 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
			nint num9 = 0;
			CS_0024_003C_003E8__locals27.targetPos = float2.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1326 @ rcx_v59 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
			_ = 0;
			Camera main = Camera.main;
			Bounds bounds = CameraExtensions.OrthographicBounds(main);
			float num11 = default(float);
			float num10 = num11 * 2f;
			Camera main2 = Camera.main;
			Bounds bounds2 = CameraExtensions.OrthographicBounds(main2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1479 @ rax_v74 (UnityEngine.Bounds)+10]");
			_ = 0;
			_ = bounds2.m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1479 @ rax_v74 (UnityEngine.Bounds)+10]");
			float num12 = 0f * 2f;
			if (!(num12 > num10))
			{
				num10 = num12;
			}
			object obj8 = UnityEngine.Random.value;
			float num13 = (float)bounds2.m_Center * ((float)Math.PI * 2f);
			object obj9 = UnityEngine.Random.value;
			Weapon weapon4 = _weapon;
			float num14 = num10 * 0.2f;
			float num15 = num10 * 0.2f;
			float num16 = (float)bounds2.m_Center * num14;
			float num17 = num16 + num15;
			if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
			{
				float2 float5 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num18 = num13 * num17;
				float num19 = num18 + (float)float5;
				CS_0024_003C_003E8__locals27.targetPos = (float2)num19;
				Weapon weapon5 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
				{
					float2 float6 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num20 = num13 * num17;
					float num21 = num20 + 1.0653532E+09f;
					Weapon weapon6 = _weapon;
					if ((object)_weapon != null && (object)weapon6._gameMan != null)
					{
						Transform transform = weapon6._gameMan.FindClosestEnemyToPlayer(((Equipment)weapon6)._003COwner_003Ek__BackingField);
						bool flag2 = (object)transform == null;
						object obj10 = 0;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1804 @ rax_v85 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							obj10 = 0;
							if (!flag3)
							{
								Vector3 vector = transform.position;
								Weapon weapon7 = _weapon;
								if ((object)_weapon == null || (object)((Equipment)weapon7)._003COwner_003Ek__BackingField == null)
								{
									goto IL_0d8c;
								}
								float2 float7 = ((Equipment)weapon7)._003COwner_003Ek__BackingField.position;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
								bool flag4 = !(2f > 1.0653532E+09f);
								num14 = num11;
								obj10 = 0;
								if (!flag4)
								{
									Transform transform2 = transform.transform;
									if ((object)transform2 == null)
									{
										goto IL_0d8c;
									}
									Vector3 vector2 = transform2.position;
									num14 = vector2.x;
									CS_0024_003C_003E8__locals27.targetPos = (float2)vector2.x;
									obj10 = 0;
								}
							}
						}
						Weapon weapon8 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon8)._003COwner_003Ek__BackingField != null)
						{
							float2 float8 = ((Equipment)weapon8)._003COwner_003Ek__BackingField.position;
							Weapon weapon9 = _weapon;
							if ((object)_weapon != null && (object)((Equipment)weapon9)._003COwner_003Ek__BackingField != null)
							{
								float2 float9 = ((Equipment)weapon9)._003COwner_003Ek__BackingField.position;
								Weapon weapon10 = _weapon;
								if ((object)_weapon != null && (object)((Equipment)weapon10)._003COwner_003Ek__BackingField != null)
								{
									Transform transform3 = ((Equipment)weapon10)._003COwner_003Ek__BackingField.transform;
									if ((object)transform3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v94 (UnityEngine.Transform)+10]");
										bool flag5 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v94 (UnityEngine.Transform)+10]");
										float euler;
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&euler));
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
										float num22 = _throwSpeed * num11;
										float projectileSpeed = base.ProjectileSpeed;
										float num23 = num22 / num11;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
										float projectileSpeed2 = base.ProjectileSpeed;
										float num24 = _rollSpeed * num11;
										float num25 = (CS_0024_003C_003E8__locals27.rollDuration = num24 / num11) + num23;
										Weapon weapon11 = _weapon;
										if ((object)_weapon != null && (object)((Equipment)weapon11)._003COwner_003Ek__BackingField != null)
										{
											Transform transform4 = ((Equipment)weapon11)._003COwner_003Ek__BackingField.transform;
											if ((object)transform4 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v106 (UnityEngine.Transform)+10]");
												bool flag6 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v106 (UnityEngine.Transform)+10]");
												Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&euler));
												float num26 = euler;
												float2 targetPos = CS_0024_003C_003E8__locals27.targetPos;
												bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num26) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref targetPos);
												int num27 = 1;
												if (!flag7)
												{
													num27 = -1;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
												object obj11 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
												bool flag8 = (nint)0 != 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v106 (UnityEngine.Transform)+10]");
												object obj12 = 0;
												if (!flag8)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													bool flag9 = obj11 == null;
													obj12 = 6573110936L;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2491 @ rax_v114 (should have been resolved before IL gen)");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
												object obj13 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													bool flag10 = obj13 == null;
													obj12 = 6573110936L;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2518 @ rax_v117 (should have been resolved before IL gen)");
												int num28 = (int)_cachedTransform;
												Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion _);
												bool flag11 = (object)_cachedTransform == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1552 @ rdi_v26 (System.Int32)+10]");
												bool flag12 = (nint)0 == 0;
												object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1552 @ rdi_v26 (System.Int32)+10]");
												Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)obj14);
												if (_angleTween != null)
												{
													DG.Tweening.TweenExtensions.Kill(_angleTween);
													obj10 = 0;
												}
												float duration = num25 * 0.001f;
												TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&euler), duration, RotateMode.FastBeyond360);
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
												Tween tween = default(Tween);
												if (tween != null && tween._003Cactive_003Ek__BackingField && !tween.creationLocked && !tween.isFrom && !tween.isBlendable)
												{
													tween._003CisRelative_003Ek__BackingField = true;
												}
												_angleTween = tween;
												if (_scaleGrenadeTween != null)
												{
													_scaleGrenadeTween.Kill();
												}
												TweenConfig tweenConfig = new TweenConfig();
												object[] array = new object[1];
												if (array != null)
												{
													object obj15 = array;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj16 = default(object);
													bool flag13 = obj16 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														Weapon weapon12 = CS_0024_003C_003E8__locals27.weapon;
														if ((object)CS_0024_003C_003E8__locals27.weapon != null && (object)((Equipment)weapon12)._003COwner_003Ek__BackingField != null)
														{
															float num29 = ((Equipment)weapon12)._003COwner_003Ek__BackingField.PArea();
															_ = 1;
															float num30 = num23 * 0.5f;
															_ = 1;
															MultiTargetTween scaleGrenadeTween = Tweens.Add(tweenConfig);
															_scaleGrenadeTween = scaleGrenadeTween;
															if (_moveXTween != null)
															{
																_moveXTween.Kill();
															}
															TweenConfig tweenConfig2 = new TweenConfig();
															object[] array2 = new object[1];
															if (array2 != null)
															{
																int value = ((int*)(&array2))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj17 = default(object);
																bool flag14 = obj17 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig2 != null)
																{
																	tweenConfig2.targets = array2;
																	tweenConfig2.duration = num23;
																	tweenConfig2.ease = Ease.Linear;
																	tweenConfig2.x = (float?)(object)1;
																	TweenCallback onComplete = delegate
																	{
																		//IL_00a7: Expected I, but got O
																		//IL_011e: Expected O, but got I4
																		//IL_01c7: Expected I, but got O
																		//IL_021d: Expected O, but got I4
																		//IL_02c7: Expected O, but got F4
																		//IL_02f7: Expected O, but got I4
																		CS_0024_003C_003E8__locals27._003C_003E4__this.DoTintCycle();
																		TP_RPG1_Projectile tP_RPG1_Projectile = CS_0024_003C_003E8__locals27._003C_003E4__this;
																		if (tP_RPG1_Projectile._scaleGrenadeTween != null)
																		{
																			tP_RPG1_Projectile._scaleGrenadeTween.Kill();
																		}
																		TP_RPG1_Projectile tP_RPG1_Projectile2 = CS_0024_003C_003E8__locals27._003C_003E4__this;
																		TweenConfig tweenConfig4 = new TweenConfig();
																		object[] array4 = new object[1];
																		if ((object)CS_0024_003C_003E8__locals27._003C_003E4__this != null)
																		{
																			nint num32 = (nint)array4;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj19 = default(object);
																			if (obj19 == null)
																			{
																				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																				throw ex;
																			}
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		tweenConfig4.targets = array4;
																		Weapon weapon13 = CS_0024_003C_003E8__locals27.weapon;
																		float num33 = ((Equipment)weapon13)._003COwner_003Ek__BackingField.PArea();
																		tweenConfig4.scale = (float?)(object)1;
																		float duration3 = CS_0024_003C_003E8__locals27.rollDuration * 0.5f;
																		tweenConfig4.yoyo = true;
																		tweenConfig4.duration = duration3;
																		MultiTargetTween scaleGrenadeTween2 = Tweens.Add(tweenConfig4);
																		tP_RPG1_Projectile2._scaleGrenadeTween = scaleGrenadeTween2;
																		TP_RPG1_Projectile tP_RPG1_Projectile3 = CS_0024_003C_003E8__locals27._003C_003E4__this;
																		TweenConfig tweenConfig5 = new TweenConfig();
																		object[] array5 = new object[1];
																		if ((object)CS_0024_003C_003E8__locals27._003C_003E4__this != null)
																		{
																			nint num34 = (nint)array5;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj20 = default(object);
																			if (obj20 == null)
																			{
																				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
																				throw ex2;
																			}
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		tweenConfig5.targets = array5;
																		tweenConfig5.x = (float?)(object)1;
																		tweenConfig5.duration = CS_0024_003C_003E8__locals27.rollDuration;
																		tweenConfig5.ease = Ease.OutSine;
																		MultiTargetTween moveXTween2 = Tweens.Add(tweenConfig5);
																		tP_RPG1_Projectile3._moveXTween = moveXTween2;
																		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
																		soundConfig2.Rate = 0.9f;
																		object obj21 = UnityEngine.Random.value;
																		float num35 = (float)CS_0024_003C_003E8__locals27.targetPos - 0.5f;
																		float detune = num35 * 500f;
																		soundConfig2.Volume = (float?)(object)1;
																		soundConfig2.Detune = detune;
																		float time = default(float);
																		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Grenade1, soundConfig2, 200f, 10, time);
																	};
																	tweenConfig2.onComplete = onComplete;
																	MultiTargetTween moveXTween = Tweens.Add(tweenConfig2);
																	_moveXTween = moveXTween;
																	if (_moveYTween != null)
																	{
																		_moveYTween.Kill();
																	}
																	TweenConfig tweenConfig3 = new TweenConfig();
																	object[] array3 = new object[1];
																	if (array3 != null)
																	{
																		int value2 = ((int*)(&array3))->m_value;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																		object obj18 = default(object);
																		bool flag15 = obj18 == null;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		if (tweenConfig3 != null)
																		{
																			tweenConfig3.targets = array3;
																			tweenConfig3.duration = num23;
																			tweenConfig3.ease = Ease.Linear;
																			tweenConfig3.y = (float?)(object)1;
																			TweenCallback onComplete2 = delegate
																			{
																				//IL_008d: Expected I, but got O
																				//IL_00e3: Expected O, but got I4
																				TP_RPG1_Projectile tP_RPG1_Projectile = CS_0024_003C_003E8__locals27._003C_003E4__this;
																				if (tP_RPG1_Projectile._moveYTween2 != null)
																				{
																					tP_RPG1_Projectile._moveYTween2.Kill();
																				}
																				TP_RPG1_Projectile tP_RPG1_Projectile2 = CS_0024_003C_003E8__locals27._003C_003E4__this;
																				TweenConfig tweenConfig4 = new TweenConfig();
																				object[] array4 = new object[1];
																				if ((object)CS_0024_003C_003E8__locals27._003C_003E4__this != null)
																				{
																					nint num32 = (nint)array4;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																					object obj19 = default(object);
																					if (obj19 == null)
																					{
																						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
																						throw ex;
																					}
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				tweenConfig4.targets = array4;
																				tweenConfig4.y = (float?)(object)1;
																				tweenConfig4.duration = CS_0024_003C_003E8__locals27.rollDuration;
																				tweenConfig4.ease = Ease.Linear;
																				MultiTargetTween moveYTween2 = Tweens.Add(tweenConfig4);
																				tP_RPG1_Projectile2._moveYTween2 = moveYTween2;
																			};
																			tweenConfig3.onComplete = onComplete2;
																			MultiTargetTween moveYTween = Tweens.Add(tweenConfig3);
																			_moveYTween = moveYTween;
																			if (_explosionTimer != null)
																			{
																				_explosionTimer.Cancel();
																			}
																			Action onComplete3 = Explode;
																			float num31 = _explosionDelay + num23;
																			float duration2 = num31 * 0.001f;
																			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																			int repeat = default(int);
																			TimerType type = default(TimerType);
																			Timer explosionTimer = Timers.Register(duration2, onComplete3, null, isLooped: false, (byte)(int)num7 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																			_explosionTimer = explosionTimer;
																			return;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0d8c;
		IL_0d8c:
		throw new NullReferenceException();
	}

	private void DoTintCycle()
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		CS_0024_003C_003E8__locals11.millis = 50f;
		ArcadeSprite arcadeSprite = setTint(16777215u);
		if (_tintTimer != null)
		{
			_tintTimer.Cancel();
		}
		Action onComplete = delegate
		{
			ArcadeSprite arcadeSprite2 = CS_0024_003C_003E8__locals11._003C_003E4__this.setTint(16711680u);
			TP_RPG1_Projectile tP_RPG1_Projectile = CS_0024_003C_003E8__locals11._003C_003E4__this;
			if (tP_RPG1_Projectile._tintTimer != null)
			{
				tP_RPG1_Projectile._tintTimer.Cancel();
			}
			Action onComplete2 = CS_0024_003C_003E8__locals11._003C_003E9__1;
			TP_RPG1_Projectile tP_RPG1_Projectile2 = CS_0024_003C_003E8__locals11._003C_003E4__this;
			if (CS_0024_003C_003E8__locals11._003C_003E9__1 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals11._003C_003E9__1 = delegate
				{
					CS_0024_003C_003E8__locals11._003C_003E4__this.DoTintCycle();
				});
			}
			float duration2 = CS_0024_003C_003E8__locals11.millis * 0.001f;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer tintTimer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			tP_RPG1_Projectile2._tintTimer = tintTimer2;
		};
		float duration = CS_0024_003C_003E8__locals11.millis * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer tintTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_tintTimer = tintTimer;
	}

	protected void Explode()
	{
		//IL_007e: Expected O, but got F4
		//IL_00ac: Expected O, but got I4
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Grenade2, soundConfig, 200f, 3, time);
		float2 pos = base.position;
		_rpgWeapon.SpawnExplosionClustersAt(pos);
		Despawn();
	}

	public override void Despawn()
	{
		DG.Tweening.TweenExtensions.Kill(_angleTween);
		if (_moveXTween != null)
		{
			_moveXTween.Kill();
		}
		if (_moveYTween != null)
		{
			_moveYTween.Kill();
		}
		if (_moveYTween2 != null)
		{
			_moveYTween2.Kill();
		}
		if (_scaleGrenadeTween != null)
		{
			_scaleGrenadeTween.Kill();
		}
		if (_explosionTimer != null)
		{
			_explosionTimer.Cancel();
		}
		if (_tintTimer != null)
		{
			_tintTimer.Cancel();
		}
		base.Despawn();
	}
}
