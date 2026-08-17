using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class HeavenSwordProjectile : Projectile
{
	private SpriteTrail _Trail;

	private Tween _angleTween;

	private Tween _accelTween;

	private Tween _backwardsTween;

	private Timer _cullingTimer;

	private float _acceleration;

	private Vector2 _velocity;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00d2: Expected O, but got I8
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_07f6: Expected O, but got I4
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		//IL_080b: Expected O, but got Unknown
		//IL_0288: Expected I4, but got O
		//IL_0843: Expected O, but got F4
		//IL_06c4: Expected O, but got F4
		//IL_0714: Expected I, but got O
		//IL_034a: Expected O, but got I4
		//IL_03d9: Expected O, but got I4
		//IL_0416: Expected I4, but got O
		//IL_05f4: Expected O, but got I4
		//IL_05f4: Expected O, but got I4
		//IL_050f: Expected O, but got I4
		//IL_050f: Expected O, but got I4
		//IL_0747->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_076e->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_03bd->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_0402->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_0430->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_0463->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_07b4->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_04e6->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_07e3->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_0538->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_0567->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_0586->IL05fa: Incompatible stack heights: 5 vs 0
		//IL_05c7->IL05fa: Incompatible stack heights: 5 vs 0
		base.InitProjectile(pool, weapon, index);
		TweenerCore<float, float, FloatOptions> tweenerCore;
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(12f, (float?)(object)0, (float?)(object)0);
			SetScaleToArea();
			_acceleration = 2f;
			_isCullable = false;
			if (_accelTween != null)
			{
				TweenExtensions.Kill(_accelTween);
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((HeavenSwordProjectile)(object)dOSetter)._003CInitProjectile_003Eb__7_1(1f);
			tweenerCore = DOTween.To(getter, dOSetter, 0f, 0.5f);
			object obj = 6603577472L;
			TweenCallback tweenCallback2;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag = (nint)0 == 0;
					_ = 0;
					if (!flag)
					{
						object obj2 = tweenerCore + 184;
						object obj3 = obj2 >> 12;
						object obj4 = obj3 & 0x1FFFFF;
						object obj5 = obj4 >> 6;
						object obj6 = obj4 & 0x3F;
						nint num2;
						do
						{
							object obj7 = 1 << (int)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r14_v10+462E0+v715 @ rdx_v61*8]");
							object obj8 = 0 | obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r14_v10+462E0+v715 @ rdx_v61*8]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r14_v10+462E0+v715 @ rdx_v61*8]");
							if (num == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r14_v10+462E0+v715 @ rdx_v61*8]");
							num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r14_v10+462E0+v715 @ rdx_v61*8]");
						}
						while (num2 != 0);
						TweenCallback tweenCallback = GoBackwards;
						tweenCallback2 = tweenCallback;
						goto IL_01fe;
					}
				}
			}
			TweenCallback tweenCallback3 = GoBackwards;
			bool flag2 = tweenerCore == null;
			tweenCallback2 = tweenCallback3;
			if (!flag2)
			{
				goto IL_01fe;
			}
			goto IL_0231;
		}
		goto IL_05fa;
		IL_05df:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		return;
		IL_0773:
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_05df;
		IL_0231:
		_accelTween = tweenerCore;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_accelTween != null)
		{
			int num3 = (int)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rsi_v13 (System.Int32)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rsi_v13 (System.Int32)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				object obj9 = UnityEngine.Random.value;
				bool flag4 = (object)_weapon == null;
				float num4 = _weapon.PArea();
				object obj10 = UnityEngine.Random.value;
				bool flag5 = (object)_weapon == null;
				float num5 = _weapon.PArea();
				Weapon cachedTransform = (Weapon)(object)_cachedTransform;
				bool flag6 = (object)_cachedTransform == null;
				bool flag7 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
				nint num6 = (nint)this;
				Transform transform = base.AimForNearestEnemy();
				BaseBody baseBody2 = base.body;
				if (base.body != null)
				{
					_velocity = baseBody2._velocity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v59 (BaseBody)+74]");
					_ = 0;
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
					{
						Rate = 1f,
						Volume = (float?)(object)1
					};
					float detune = (float)_indexInWeapon * -100f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							object obj11 = renderer.pixelHeight + renderer.pixelHeight;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
							if ((object)_renderer != null)
							{
								Weapon weapon2 = default(Weapon);
								_renderer.sortingOrder = (int)weapon2;
								if ((object)_Trail != null)
								{
									SpriteTrail spriteTrail = _Trail.setVisible(b: true);
									if ((object)_weapon != null)
									{
										int num7 = _weapon.PBounces();
										if (num7 <= 0)
										{
											goto IL_0773;
										}
										if (_bounceActivated)
										{
											goto IL_05df;
										}
										_bounceActivated = true;
										PhaserScene s_scene2 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null && (object)s_scene2.physics != null)
										{
											WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
											if (ArcadePhysics.s_world != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
												setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
												Weapon weapon3 = _weapon;
												if ((object)_weapon != null)
												{
													VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
													if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null && base.body != null)
													{
														Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
														BaseBody baseBody3 = base.body;
														if (base.body != null)
														{
															baseBody3._onWorldBounds = true;
															goto IL_0773;
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
		goto IL_05fa;
		IL_05fa:
		throw new NullReferenceException();
		IL_01fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0231;
	}

	public override void InternalUpdate()
	{
		//IL_005a: Expected O, but got F4
		float num = (float)_velocity * _acceleration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HeavenSwordProjectile)+100]");
		float num2 = 0f * _acceleration;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num;
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		//IL_0075: Expected O, but got F4
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		if (body == b)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			float num = (float)_velocity * -1f;
			int bounces = _bounces - 1;
			_bounces = bounces;
			_velocity = (Vector2)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HeavenSwordProjectile)+100]");
			float num2 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_01c2: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_00c8: Expected I, but got O
		//IL_00a7: Expected O, but got I4
		//IL_0147: Expected O, but got F4
		//IL_010b: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		BaseBody baseBody = body;
		BaseBody baseBody2;
		if (body == null)
		{
			baseBody2 = null;
			goto IL_01d5;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r9_v1 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r9_v1 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v15+FFFFFFF8+v47 @ rax_v11*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_01a5;
			}
		}
		obj3 = 0;
		goto IL_01a5;
		IL_01a5:
		bool flag = obj3 == null;
		nint num4 = (nint)typeof(Body);
		baseBody2 = null;
		if (!flag)
		{
			num4 = (nint)typeof(Body);
			baseBody2 = body;
		}
		goto IL_01d5;
		IL_01d5:
		if (body == baseBody2)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			float num5 = (float)_velocity * -1f;
			int bounces = _bounces - 1;
			_bounces = bounces;
			_velocity = (Vector2)num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.HeavenSwordProjectile)+100]");
			float num6 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private unsafe void GoBackwards()
	{
		//IL_0033: Expected O, but got Ref
		//IL_0044: Expected O, but got I8
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		//IL_0568: Expected O, but got I4
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Expected O, but got Unknown
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&obj), 1f, RotateMode.FastBeyond360);
		object obj2 = 6603577472L;
		bool flag = tweenerCore == null;
		RotateMode rotateMode = RotateMode.FastBeyond360;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			bool flag2 = (nint)0 == 0;
			rotateMode = RotateMode.FastBeyond360;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				bool flag3 = (nint)0 == 0;
				rotateMode = RotateMode.FastBeyond360;
				if (!flag3)
				{
					_ = 1;
					_ = 0;
					rotateMode = RotateMode.FastBeyond360;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		_angleTween = tweenerCore;
		Tween angleTween = _angleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		angleTween.stringId = "DefaultGameTweenId";
		if (_backwardsTween != null)
		{
			TweenExtensions.Kill(_backwardsTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((HeavenSwordProjectile)(object)dOSetter)._003CGoBackwards_003Eb__11_1(0f);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, -2f, 0.5f);
		TweenCallback tweenCallback2;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag4 = (nint)0 == 0;
				_ = 0;
				if (!flag4)
				{
					object obj3 = tweenerCore2 + 184;
					object obj4 = obj3 >> 12;
					object obj5 = obj4 & 0x1FFFFF;
					object obj6 = obj5 >> 6;
					object obj7 = obj5 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v1+462E0+v678 @ rdx_v29*8]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v1+462E0+v678 @ rdx_v29*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v1+462E0+v678 @ rdx_v29*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v1+462E0+v678 @ rdx_v29*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbp_v1+462E0+v678 @ rdx_v29*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = GoBackwards;
					tweenCallback2 = tweenCallback;
					goto IL_03bb;
				}
			}
		}
		TweenCallback tweenCallback3 = GoBackwards;
		bool flag5 = tweenerCore2 == null;
		tweenCallback2 = tweenCallback3;
		if (!flag5)
		{
			goto IL_03bb;
		}
		goto IL_03ea;
		IL_03bb:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_03ea;
		IL_03ea:
		_backwardsTween = tweenerCore2;
		Tween backwardsTween = _backwardsTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		backwardsTween.stringId = "DefaultGameTweenId";
		Action onComplete = delegate
		{
			_isCullable = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer cullingTimer = Timers.Register(0.75000006f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_cullingTimer = cullingTimer;
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_cullingTimer != null)
		{
			_cullingTimer.Cancel();
		}
		Tween accelTween = _accelTween;
		if (_accelTween != null && accelTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_accelTween);
		}
		Tween angleTween = _angleTween;
		if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_angleTween);
		}
		Tween backwardsTween = _backwardsTween;
		if (_backwardsTween != null && backwardsTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_backwardsTween);
		}
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
	}

	public HeavenSwordProjectile()
	{
		//IL_002a: Expected I, but got O
		_acceleration = 1f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		base._002Ector();
	}

	private float _003CInitProjectile_003Eb__7_0()
	{
		return _acceleration;
	}

	private void _003CInitProjectile_003Eb__7_1(float x)
	{
		_acceleration = x;
	}

	private float _003CGoBackwards_003Eb__11_0()
	{
		return _acceleration;
	}

	private void _003CGoBackwards_003Eb__11_1(float val)
	{
		_acceleration = val;
	}

	private void _003CGoBackwards_003Eb__11_2()
	{
		_isCullable = true;
	}
}
