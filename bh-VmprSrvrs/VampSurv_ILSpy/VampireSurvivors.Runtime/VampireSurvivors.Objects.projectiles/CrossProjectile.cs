using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class CrossProjectile : Projectile
{
	private float _acceleration;

	private Vector2 _velocity;

	private Tween _angleTween;

	private Tween _accelTween;

	protected override void Awake()
	{
		base.Awake();
		_bounceActivated = false;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_091d: Expected O, but got F4
		//IL_07dd: Expected O, but got F4
		//IL_011e: Expected O, but got Ref
		//IL_0456: Expected I, but got O
		//IL_04cf: Expected O, but got I4
		//IL_055e: Expected O, but got I4
		//IL_059b: Expected I4, but got O
		//IL_0746: Expected O, but got I4
		//IL_0746: Expected O, but got I4
		//IL_0661: Expected O, but got I4
		//IL_0661: Expected O, but got I4
		//IL_0489->IL078e: Incompatible stack heights: 1 vs 0
		//IL_089a->IL078e: Incompatible stack heights: 1 vs 0
		//IL_0542->IL078e: Incompatible stack heights: 1 vs 0
		//IL_0587->IL078e: Incompatible stack heights: 1 vs 0
		//IL_05b5->IL078e: Incompatible stack heights: 1 vs 0
		//IL_08e0->IL078e: Incompatible stack heights: 1 vs 0
		//IL_0638->IL078e: Incompatible stack heights: 1 vs 0
		//IL_090f->IL078e: Incompatible stack heights: 1 vs 0
		//IL_068a->IL078e: Incompatible stack heights: 1 vs 0
		//IL_06b9->IL078e: Incompatible stack heights: 1 vs 0
		//IL_06d8->IL078e: Incompatible stack heights: 1 vs 0
		//IL_0719->IL078e: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(12f, (float?)(object)0, (float?)(object)0);
			SetScaleToArea();
			object cachedTransform = _cachedTransform;
			float num = (float)_indexInWeapon * 0.1f;
			float acceleration = num + 1.5f;
			_acceleration = acceleration;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rsi_v9 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rsi_v9 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
					object obj = UnityEngine.Random.value;
					Weapon weapon2 = _weapon;
					float num2 = weapon2.PArea();
					object obj2 = UnityEngine.Random.value;
					float num3 = _weapon.PArea();
					Weapon cachedTransform2 = (Weapon)(object)_cachedTransform;
					bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
					Tween angleTween = _angleTween;
					if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_angleTween);
					}
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&ret), 0.5f, RotateMode.FastBeyond360);
					bool flag2 = tweenerCore == null;
					RotateMode rotateMode = RotateMode.FastBeyond360;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						bool flag3 = (nint)0 == 0;
						rotateMode = RotateMode.FastBeyond360;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							bool flag4 = (nint)0 == 0;
							rotateMode = RotateMode.FastBeyond360;
							if (!flag4)
							{
								_ = 1;
								_ = 0;
								rotateMode = RotateMode.FastBeyond360;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 4294967295L;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
								if ((nint)0 == 0)
								{
									_ = 2139095040;
								}
							}
						}
					}
					_angleTween = tweenerCore;
					Tween angleTween2 = _angleTween;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					angleTween2.stringId = "DefaultGameTweenId";
					Tween accelTween = _accelTween;
					if (_accelTween != null && accelTween._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_accelTween);
					}
					DOGetter<float> getter = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
					DOSetter<float> dOSetter = null;
					((CrossProjectile)(object)dOSetter)._003CInitProjectile_003Eb__5_1(-360f);
					TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, -2f, 1f);
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1499 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 1;
							_ = 0;
						}
					}
					_accelTween = tweenerCore2;
					Tween accelTween2 = _accelTween;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					accelTween2.stringId = "DefaultGameTweenId";
					nint num4 = (nint)this;
					Transform transform = base.AimForNearestEnemy();
					BaseBody baseBody2 = base.body;
					if (base.body != null)
					{
						_velocity = baseBody2._velocity;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v65 (BaseBody)+74]");
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
								object obj3 = renderer.pixelHeight + renderer.pixelHeight;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
								if ((object)_renderer != null)
								{
									Weapon weapon3 = default(Weapon);
									_renderer.sortingOrder = (int)weapon3;
									if ((object)_weapon != null)
									{
										int num5 = _weapon.PBounces();
										if (num5 <= 0)
										{
											goto IL_089f;
										}
										if (_bounceActivated)
										{
											goto IL_0731;
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
												Weapon weapon4 = _weapon;
												if ((object)_weapon != null)
												{
													VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon4)._003COwner_003Ek__BackingField;
													if ((object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null && base.body != null)
													{
														Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
														BaseBody baseBody3 = base.body;
														if (base.body != null)
														{
															baseBody3._onWorldBounds = true;
															goto IL_089f;
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
				else
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
				}
			}
		}
		throw new NullReferenceException();
		IL_089f:
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_0731;
		IL_0731:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
	}

	public override void InternalUpdate()
	{
		//IL_005a: Expected O, but got F4
		float num = (float)_velocity * _acceleration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CrossProjectile)+D8]");
		float num2 = 0f * _acceleration;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num;
	}

	public override void Despawn()
	{
		Tween angleTween = _angleTween;
		if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_angleTween);
		}
		_angleTween = null;
		Tween accelTween = _accelTween;
		if (_accelTween != null && accelTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_accelTween);
		}
		_accelTween = null;
		base.Despawn();
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		//IL_0075: Expected O, but got F4
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		if (b == body)
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CrossProjectile)+D8]");
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
		if (baseBody2 == body)
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.CrossProjectile)+D8]");
			float num6 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public CrossProjectile()
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

	private float _003CInitProjectile_003Eb__5_0()
	{
		return _acceleration;
	}

	private void _003CInitProjectile_003Eb__5_1(float val)
	{
		_acceleration = val;
	}
}
