using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DarkRift2_Projectile : Projectile
{
	private SpriteTrail _Trail;

	private const float Radius = 16f;

	private Tween _angleTween;

	private PhaserSprite _scytheSprite;

	protected unsafe override void Awake()
	{
		//IL_0188: Expected O, but got I4
		//IL_03db->IL048f: Incompatible stack heights: 5 vs 0
		base.Awake();
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string text = "WhiteDot";
			Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
					if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A14C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						text = "TP_VFX_Death_Scythe_Big";
						GameObject gameObject = base.gameObject;
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Death_Scythe_Big");
						if ((object)phaserSprite != null)
						{
							PhaserSprite phaserSprite2 = phaserSprite.setScale(0.5f, (float?)(object)0);
							if ((object)phaserSprite2 != null)
							{
								GameObject gameObject2 = phaserSprite2.gameObject;
								if ((object)gameObject2 != null)
								{
									((UnityEngine.Object)gameObject2).SetName("_scytheSprite");
									_scytheSprite = phaserSprite2;
									float? trail = (float?)_Trail;
									if ((object)_Trail == null)
									{
										return;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rbx_v9 (System.Nullable`1<System.Single>)+10]");
									if ((nint)0 == 0)
									{
										return;
									}
									if ((object)_Trail != null)
									{
										Transform transform = _Trail.transform;
										PhaserSprite scytheSprite = _scytheSprite;
										if ((object)_scytheSprite != null && (object)scytheSprite._spriteRenderer != null)
										{
											Transform parent = scytheSprite._spriteRenderer.transform;
											if ((object)transform != null)
											{
												transform.SetParent(parent, worldPositionStays: true);
												if ((object)_Trail != null)
												{
													Transform transform2 = _Trail.transform;
													PhaserSprite scytheSprite2 = _scytheSprite;
													if ((object)_scytheSprite != null && (object)scytheSprite2._spriteRenderer != null)
													{
														Transform transform3 = scytheSprite2._spriteRenderer.transform;
														if ((object)transform3 != null)
														{
															bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
															Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
															bool flag2 = (object)transform2 == null;
															bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
															Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&text));
															PhaserSprite scytheSprite3 = _scytheSprite;
															SpriteTrail trail2 = _Trail;
															bool flag4 = (object)_scytheSprite == null;
															bool flag5 = (object)_Trail == null;
															trail2._MainSprite = scytheSprite3._spriteRenderer;
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
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002a: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_007f: Expected I, but got O
		//IL_01bf: Expected O, but got I4
		//IL_0133: Expected O, but got F4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		SetScaleToArea();
		Weapon weapon2 = _weapon;
		if (!weapon2.IsHoming)
		{
			float num = weapon2.PAmount();
			nint num2 = (nint)this;
			object obj = default(object);
			float num3 = -360f / (float)obj;
			float num4 = num3 * (float)_indexInWeapon;
			float projectileSpeed = base.ProjectileSpeed;
			float num5 = num4 + 90f;
			float num6 = num5 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num7 = num6 * (float)_indexInWeapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			ArcadeSprite sprite = _sprite;
			float num8 = num6 * (float)_indexInWeapon;
			BaseBody baseBody2 = sprite.body;
			baseBody2._velocity = (float2)num7;
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
		}
		InitRotation();
		InitBounce();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
	}

	private void InitVelocity()
	{
		//IL_0046: Expected I, but got O
		//IL_00fa: Expected O, but got F4
		Weapon weapon = _weapon;
		if (!weapon.IsHoming)
		{
			float num = weapon.PAmount();
			nint num2 = (nint)this;
			object obj = default(object);
			float num3 = -360f / (float)obj;
			float num4 = num3 * (float)_indexInWeapon;
			float projectileSpeed = base.ProjectileSpeed;
			float num5 = num4 + 90f;
			float num6 = num5 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num7 = num6 * (float)_indexInWeapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			ArcadeSprite sprite = _sprite;
			float num8 = num6 * (float)_indexInWeapon;
			BaseBody baseBody = sprite.body;
			baseBody._velocity = (float2)num7;
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
		}
	}

	private unsafe void InitRotation()
	{
		//IL_0040: Expected O, but got Ref
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		Transform target = _scytheSprite.transform;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj), 0.5f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
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
		_angleTween = tweenerCore;
	}

	private void InitBounce()
	{
		//IL_0121: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		int num = _weapon.PBounces();
		if (num > 0)
		{
			if (_bounceActivated)
			{
				goto IL_010c;
			}
			_bounceActivated = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if ((object)s_scene.physics == null)
			{
				throw new NullReferenceException();
			}
			WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
			BaseBody baseBody = base.body;
			baseBody._onWorldBounds = true;
		}
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_010c;
		IL_010c:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
	}

	public override void Despawn()
	{
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		base.Despawn();
	}

	private void Bounce(Body body, bool up, bool down, bool left, bool right)
	{
		//IL_0080: Expected O, but got F4
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		if (base.body == body)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			int bounces = _bounces - 1;
			_bounces = bounces;
			float num = (float)body._velocity * -2f;
			body._velocity = (float2)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+74]");
			float num2 = 0f * -2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_01cd: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_00c8: Expected I, but got O
		//IL_00a7: Expected O, but got I4
		//IL_0152: Expected O, but got F4
		//IL_010b: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		BaseBody baseBody = body;
		BaseBody baseBody2;
		if (body == null)
		{
			baseBody2 = null;
			goto IL_01e0;
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
				goto IL_01b0;
			}
		}
		obj3 = 0;
		goto IL_01b0;
		IL_01b0:
		bool flag = obj3 == null;
		nint num4 = (nint)typeof(Body);
		baseBody2 = null;
		if (!flag)
		{
			num4 = (nint)typeof(Body);
			baseBody2 = body;
		}
		goto IL_01e0;
		IL_01e0:
		if (body == baseBody2)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			int bounces = _bounces - 1;
			_bounces = bounces;
			float num5 = (float)baseBody2._velocity * -2f;
			baseBody2._velocity = (float2)num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v1 (BaseBody)+74]");
			float num6 = 0f * -2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
