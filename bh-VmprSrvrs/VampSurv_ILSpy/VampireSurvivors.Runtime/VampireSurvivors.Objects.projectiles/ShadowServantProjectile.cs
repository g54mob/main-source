using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class ShadowServantProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public ShadowServantProjectile _003C_003E4__this;

		public bool isVisible;

		internal void _003CExplode_003Eb__0()
		{
			//IL_0015: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this.setScale(0f, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = _003C_003E4__this.setVisible(isVisible);
		}

		internal void _003CExplode_003Eb__1()
		{
			ArcadeSprite arcadeSprite = _003C_003E4__this.setVisible(visible: false);
			ShadowServantProjectile shadowServantProjectile = _003C_003E4__this;
			BaseBody body = shadowServantProjectile.body;
			body._enable = false;
		}

		internal void _003CExplode_003Eb__2()
		{
			//IL_0024: Expected O, but got I
			//IL_0059: Expected I4, but got I8
			//IL_0059: Expected O, but got I
			if (isVisible)
			{
				ArcadeSprite arcadeSprite = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (ArcadeSprite)+F0]");
				object obj = 0;
				float2 position = arcadeSprite.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4+188]");
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt((ParticleSystem)0, pos, -1);
			}
		}

		internal unsafe void _003CExplode_003Eb__3()
		{
			//IL_00ca: Expected O, but got I
			//IL_01b0->IL0136: Incompatible stack heights: 1 vs 0
			ShadowServantProjectile shadowServantProjectile = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				ShadowServantProjectile trailFollower = (ShadowServantProjectile)(object)shadowServantProjectile._trailFollower;
				if ((object)shadowServantProjectile._trailFollower != null)
				{
					bool flag = ((UnityEngine.Object)trailFollower).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)trailFollower).m_CachedPtr, out Vector3 _);
					if ((object)_003C_003E4__this != null)
					{
						float2 position = _003C_003E4__this.position;
						object obj = _003C_003E4__this;
						bool flag2 = (object)_003C_003E4__this == null;
						object obj2 = default(object);
						float num = (float)obj2 * 100f;
						float num2 = num * 0.1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						bool flag3 = (object)_003C_003E4__this == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rdi_v9 (System.Object)+F8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rdi_v9 (System.Object)+F8]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rdi_v10 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rdi_v10 (System.Object)+10]");
						float value = default(float);
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
						ShadowServantProjectile shadowServantProjectile2 = _003C_003E4__this;
						bool flag6 = (object)_003C_003E4__this == null;
						float num3 = shadowServantProjectile2._trailFollowerCounter * 0.55f;
						float alpha = num3 + 0.1f;
						TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(shadowServantProjectile2._trail, alpha);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CExplode_003Eb__4()
		{
			//IL_017d->IL0120: Incompatible stack heights: 1 vs 0
			//IL_00dd->IL0120: Incompatible stack heights: 1 vs 0
			//IL_010f->IL0120: Incompatible stack heights: 1 vs 0
			ShadowServantProjectile shadowServantProjectile = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)shadowServantProjectile._trail != null)
			{
				shadowServantProjectile._trail.emitting = false;
				ShadowServantProjectile shadowServantProjectile2 = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					object trail = shadowServantProjectile2._trail;
					if ((object)shadowServantProjectile2._trail != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v5 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v5 (System.Object)+10]");
						TrailRenderer.Clear_Injected((IntPtr)0);
						ShadowServantProjectile shadowServantProjectile3 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null && (object)shadowServantProjectile3._trail != null)
						{
							shadowServantProjectile3._trail.enabled = false;
							if ((object)_003C_003E4__this != null)
							{
								_003C_003E4__this.Despawn();
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private TrailRenderer _trail;

	private PhaserSprite _displaySprite;

	private MultiTargetTween _explosionTween;

	private bool _isExploding;

	private ShadowServantWeapon _trueWeapon;

	private Transform _trailFollower;

	public float _trailFollowerCounter;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("bubbleSphere2", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		_speed = 0.5f;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_081e: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_027f: Expected O, but got I4
		//IL_027f: Expected I4, but got O
		//IL_03a9: Expected O, but got I4
		//IL_03a9: Expected I4, but got O
		//IL_0563: Expected O, but got I4
		//IL_0587: Expected O, but got I4
		//IL_0587: Expected O, but got I4
		//IL_06ab: Expected O, but got Ref
		//IL_08e3: Expected O, but got F4
		//IL_093a: Expected O, but got F4
		//IL_091f: Expected O, but got I4
		//IL_07b9: Expected F4, but got O
		//IL_060b->IL07be: Incompatible stack heights: 1 vs 0
		//IL_0641->IL07be: Incompatible stack heights: 1 vs 0
		//IL_066d->IL07be: Incompatible stack heights: 1 vs 0
		//IL_0699->IL07be: Incompatible stack heights: 1 vs 0
		//IL_06c5->IL07be: Incompatible stack heights: 1 vs 0
		//IL_0702->IL07be: Incompatible stack heights: 1 vs 0
		//IL_0724->IL07be: Incompatible stack heights: 1 vs 0
		//IL_097c->IL07be: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_07f7;
		}
		nint num = (nint)typeof(ShadowServantWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShadowServantWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v51 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShadowServantWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v51 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v151+FFFFFFF8+v69 @ rax_v146*8]");
			if (0 == (nint)typeof(ShadowServantWeapon))
			{
				obj3 = 1;
				goto IL_0806;
			}
		}
		obj3 = 0;
		goto IL_0806;
		IL_0806:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_07f7;
		IL_07f7:
		_trueWeapon = (ShadowServantWeapon)trueWeapon;
		ShadowServantWeapon trueWeapon2 = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			Sprite sprite = SpriteManager.GetSprite(trueWeapon2.BaseSpriteName, "vfx");
			ArcadeSprite arcadeSprite = setFrame(sprite);
			Weapon displaySprite = (Weapon)(object)_displaySprite;
			Vector2 vector = default(Vector2);
			if ((object)_displaySprite == null || ((UnityEngine.Object)displaySprite).m_CachedPtr == (IntPtr)0)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene == null)
				{
					goto IL_07be;
				}
				float2 float5 = base.position;
				PhaserSprite displaySprite2 = RenderingExtensions.sprite(s_scene.add, vector, "vfx", "snakeW_i01");
				_displaySprite = displaySprite2;
			}
			ShadowServantWeapon trueWeapon3 = _trueWeapon;
			if ((object)_trueWeapon != null)
			{
				string text = default(string);
				int num4 = default(int);
				bool flag2 = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(trueWeapon3.SnakeSpriteName, 1, 6, vector, text, num4, flag2);
				PhaserSprite displaySprite3 = _displaySprite;
				if ((object)_displaySprite != null && (object)displaySprite3._spriteAnimation != null)
				{
					bool autoSetAnimation = default(bool);
					displaySprite3._spriteAnimation.AddAnimation("idle", animationFrames, 12, (byte)(int)text != 0, (byte)num4 != 0, (Action)flag2, autoSetAnimation);
					PhaserSprite displaySprite4 = _displaySprite;
					if ((object)_displaySprite != null && (object)displaySprite4._spriteAnimation != null)
					{
						displaySprite4._spriteAnimation.SetAnimation("idle");
						ShadowServantWeapon trueWeapon4 = _trueWeapon;
						if ((object)_trueWeapon != null)
						{
							List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(trueWeapon4.SnakeDieSpriteName, 0, 11, vector, text, num4, flag2);
							PhaserSprite displaySprite5 = _displaySprite;
							if ((object)_displaySprite != null && (object)displaySprite5._spriteAnimation != null)
							{
								displaySprite5._spriteAnimation.AddAnimation("die", animationFrames2, 16, (byte)(int)text != 0, (byte)num4 != 0, (Action)flag2, autoSetAnimation);
								Transform trailFollower = _trailFollower;
								if ((object)_trailFollower == null || ((UnityEngine.Object)trailFollower).m_CachedPtr == (IntPtr)0)
								{
									GameObject gameObject = new GameObject();
									GameObject.Internal_CreateGameObject(gameObject, "ShadowServantProjectile - TrailFollower");
									if ((object)gameObject == null)
									{
										goto IL_07be;
									}
									Transform trailFollower2 = gameObject.transform;
									_trailFollower = trailFollower2;
								}
								Weapon trailFollower3 = (Weapon)(object)_trailFollower;
								float2 float6 = base.position;
								float2 float7 = base.position;
								bool flag3 = ((UnityEngine.Object)trailFollower3).m_CachedPtr == (IntPtr)0;
								Vector2 value = default(Vector2);
								Transform.set_position_Injected(((UnityEngine.Object)trailFollower3).m_CachedPtr, ref *(Vector3*)(&value));
								Transform transform = _trail.transform;
								transform.SetParent(_trailFollower, worldPositionStays: false);
								ShadowServantWeapon trueWeapon5 = _trueWeapon;
								_trailFollowerCounter = 1f;
								RenderingExtensions.SetMaterialToPackedSpriteInternal(sprite: SpriteManager.GetSprite(trueWeapon5.TrailSpriteName, "vfx"), trailRenderer: (Renderer)_trail, additive: false);
								TrailRenderer trailRenderer = RenderingExtensions.SetScale(_trail, 1f);
								int sortingOrder = base.depth;
								_trail.sortingOrder = sortingOrder;
								_trail.emitting = false;
								TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
								ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
								BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
								BaseBody baseBody2 = body;
								baseBody2._enable = true;
								ArcadeSprite arcadeSprite3 = setVisible(visible: false);
								_trail.emitting = false;
								_isExploding = false;
								_trailFollowerCounter = 1f;
								float2 float8 = base.position;
								if ((object)_displaySprite != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
									Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
									if ((object)cachedTrans != null)
									{
										Vector3 localEulerAngles = cachedTrans.localEulerAngles;
										if ((object)_displaySprite != null)
										{
											Transform transform2 = _displaySprite.transform;
											if ((object)transform2 != null)
											{
												transform2.localEulerAngles = (Vector3)(&value);
												if ((object)_displaySprite != null)
												{
													PhaserSprite phaserSprite = _displaySprite.setVisible(visible: true);
													PhaserSprite displaySprite6 = _displaySprite;
													if ((object)_displaySprite != null && (object)displaySprite6._spriteAnimation != null)
													{
														displaySprite6._spriteAnimation.SetAnimation("idle");
														float2 float9 = base.position;
														object obj4 = UnityEngine.Random.value;
														object obj5 = UnityEngine.Random.value;
														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rdi+70h]\"");
														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,esi\"");
														base.position = vector;
														Weapon weapon2 = _weapon;
														if ((object)_weapon != null)
														{
															if (!weapon2.IsHoming)
															{
																Transform transform3 = base.AimForRandomEnemy();
															}
															else
															{
																Transform transform4 = base.AimForNearestEnemy();
															}
															SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
															{
																Rate = 1f
															};
															float detune = (float)_indexInWeapon * -100f;
															soundConfig.Volume = (float?)(object)1;
															soundConfig.Detune = detune;
															PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 3, (float)text);
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
		goto IL_07be;
		IL_07be:
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		//IL_003d: Expected I, but got O
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_00d5: Expected O, but got I4
		//IL_0091: Expected O, but got I
		//IL_00c7: Expected O, but got I4
		//IL_01ae: Invalid comparison between I and F4
		//IL_0124: Invalid comparison between O and F4
		//IL_014a: Expected O, but got I
		//IL_0164: Expected O, but got I4
		//IL_0242: Invalid comparison between F4 and I
		Explode();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)target;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v4 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v4 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v33+FFFFFFF8+v176 @ rax_v7*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj4 = 1;
				goto IL_0287;
			}
		}
		obj4 = 0;
		goto IL_0287;
		IL_0287:
		bool flag = obj4 == null;
		IDamageable damageable = null;
		if (!flag)
		{
			damageable = target;
		}
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v5 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0)
			{
				object obj5 = default(object);
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
				bool flag3 = !flag2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v5 (VampireSurvivors.Interfaces.IDamageable)+214]");
				object obj6 = (nint)0 & (nint)(flag3 ? 1 : 0);
				bool flag4 = obj6 == null;
				object obj7 = !flag4;
				if (obj7 != null)
				{
					return;
				}
			}
		}
		if (!(UnityEngine.Object)damageable)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v5 (VampireSurvivors.Interfaces.IDamageable)+238]");
		if (0f > 0.2f)
		{
			float chanceFromArray = _trueWeapon.GetChanceFromArray();
			ShadowServantWeapon trueWeapon = _trueWeapon;
			WeaponData currentWeaponData = ((Weapon)trueWeapon)._currentWeaponData;
			ShadowServantWeapon trueWeapon2 = _trueWeapon;
			float num4 = ((Equipment)trueWeapon2)._003COwner_003Ek__BackingField.PLuck();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v5 (VampireSurvivors.Interfaces.IDamageable)+238]");
			float num5 = 0f * currentWeaponData._003Cchance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v5 (VampireSurvivors.Interfaces.IDamageable)+238]");
			if (num5 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v5 (VampireSurvivors.Interfaces.IDamageable)+238]");
				float num6 = 0f - 0.05f;
			}
		}
	}

	public unsafe void Explode()
	{
		//IL_0139: Expected O, but got I4
		//IL_01b6: Expected I, but got O
		//IL_026f: Expected O, but got I4
		//IL_03ac: Expected I, but got O
		//IL_049f: Expected I, but got O
		//IL_0517: Expected O, but got I4
		//IL_04c2->IL04c2: Incompatible stack heights: 3 vs 2
		//IL_057f->IL057f: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals28 = new _003C_003Ec__DisplayClass10_0();
		if (CS_0024_003C_003E8__locals28 != null)
		{
			CS_0024_003C_003E8__locals28._003C_003E4__this = this;
			if (_isExploding)
			{
				return;
			}
			PhaserSprite displaySprite = _displaySprite;
			_isExploding = true;
			if ((object)_displaySprite != null && (object)displaySprite._spriteAnimation != null)
			{
				displaySprite._spriteAnimation.SetAnimation("die");
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._playerOptions != null)
				{
					PlayerOptionsData config = core._playerOptions.Config;
					if (config != null)
					{
						CS_0024_003C_003E8__locals28.isVisible = config._003CFlashingVFXEnabled_003Ek__BackingField;
						ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
						ArcadeSprite arcadeSprite2 = setVisible(CS_0024_003C_003E8__locals28.isVisible);
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							if ((object)_cachedTransform != null)
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
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								if ((object)_weapon != null)
								{
									float num2 = _weapon.PArea();
									tweenConfig.duration = 120f;
									tweenConfig.yoyo = true;
									tweenConfig.scale = (float?)(object)1;
									TweenCallback onStart = delegate
									{
										//IL_0015: Expected O, but got I4
										ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals28._003C_003E4__this.setScale(0f, (float?)(object)0);
										ArcadeSprite arcadeSprite4 = CS_0024_003C_003E8__locals28._003C_003E4__this.setVisible(CS_0024_003C_003E8__locals28.isVisible);
									};
									tweenConfig.onStart = onStart;
									TweenCallback onComplete = delegate
									{
										ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals28._003C_003E4__this.setVisible(visible: false);
										ShadowServantProjectile shadowServantProjectile = CS_0024_003C_003E8__locals28._003C_003E4__this;
										BaseBody baseBody = shadowServantProjectile.body;
										baseBody._enable = false;
									};
									tweenConfig.onComplete = onComplete;
									TweenCallback onUpdate = delegate
									{
										//IL_0024: Expected O, but got I
										//IL_0059: Expected I4, but got I8
										//IL_0059: Expected O, but got I
										if (CS_0024_003C_003E8__locals28.isVisible)
										{
											ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals28._003C_003E4__this;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (ArcadeSprite)+F0]");
											object obj4 = 0;
											float2 float7 = arcadeSprite3.position;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4+188]");
											Vector2 pos = default(Vector2);
											RenderingExtensions.EmitParticleAt((ParticleSystem)0, pos, -1);
										}
									};
									tweenConfig.onUpdate = onUpdate;
									MultiTargetTween explosionTween = Tweens.Add(tweenConfig);
									_explosionTween = explosionTween;
									object trailFollower = _trailFollower;
									float2 float5 = base.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdi_v14 (System.Object)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdi_v14 (System.Object)+10]");
									Vector3 value = default(Vector3);
									Transform.set_position_Injected((IntPtr)0, ref value);
									_trail.Clear();
									_trail.enabled = true;
									_trail.emitting = true;
									TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 0.65f);
									TweenConfig tweenConfig2 = new TweenConfig();
									object[] array2 = new object[1];
									nint num3 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj2 = default(object);
									bool flag2 = obj2 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig2.targets = array2;
									Dictionary<string, object> dictionary = new Dictionary<string, object>();
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									object value2 = default(object);
									bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_trailFollowerCounter", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									tweenConfig2.custom = dictionary;
									tweenConfig2.duration = 300f;
									MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
									TweenConfig tweenConfig3 = new TweenConfig();
									object[] array3 = new object[1];
									if ((object)_trailFollower != null)
									{
										nint num4 = (nint)array3;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj3 = default(object);
										bool flag4 = obj3 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig3.targets = array3;
									float2 float6 = base.position;
									tweenConfig3.duration = 300f;
									tweenConfig3.ease = Ease.InOutSine;
									tweenConfig3.y = (float?)(object)1;
									TweenCallback onUpdate2 = delegate
									{
										//IL_00ca: Expected O, but got I
										//IL_01b0->IL0136: Incompatible stack heights: 1 vs 0
										ShadowServantProjectile shadowServantProjectile = CS_0024_003C_003E8__locals28._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
										{
											ShadowServantProjectile trailFollower2 = (ShadowServantProjectile)(object)shadowServantProjectile._trailFollower;
											if ((object)shadowServantProjectile._trailFollower != null)
											{
												bool flag5 = ((UnityEngine.Object)trailFollower2).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)trailFollower2).m_CachedPtr, out Vector3 _);
												if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
												{
													float2 float7 = CS_0024_003C_003E8__locals28._003C_003E4__this.position;
													object obj4 = CS_0024_003C_003E8__locals28._003C_003E4__this;
													bool flag6 = (object)CS_0024_003C_003E8__locals28._003C_003E4__this == null;
													object obj5 = default(object);
													float num5 = (float)obj5 * 100f;
													float num6 = num5 * 0.1f;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
													bool flag7 = (object)CS_0024_003C_003E8__locals28._003C_003E4__this == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rdi_v9 (System.Object)+F8]");
													object obj6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rdi_v9 (System.Object)+F8]");
													bool flag8 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rdi_v10 (System.Object)+10]");
													bool flag9 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rdi_v10 (System.Object)+10]");
													float value3 = default(float);
													Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value3));
													ShadowServantProjectile shadowServantProjectile2 = CS_0024_003C_003E8__locals28._003C_003E4__this;
													bool flag10 = (object)CS_0024_003C_003E8__locals28._003C_003E4__this == null;
													float num7 = shadowServantProjectile2._trailFollowerCounter * 0.55f;
													float alpha = num7 + 0.1f;
													TrailRenderer trailRenderer2 = RenderingExtensions.SetAlpha(shadowServantProjectile2._trail, alpha);
													return;
												}
											}
										}
										throw new NullReferenceException();
									};
									tweenConfig3.onUpdate = onUpdate2;
									TweenCallback onComplete2 = delegate
									{
										//IL_017d->IL0120: Incompatible stack heights: 1 vs 0
										//IL_00dd->IL0120: Incompatible stack heights: 1 vs 0
										//IL_010f->IL0120: Incompatible stack heights: 1 vs 0
										ShadowServantProjectile shadowServantProjectile = CS_0024_003C_003E8__locals28._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null && (object)shadowServantProjectile._trail != null)
										{
											shadowServantProjectile._trail.emitting = false;
											ShadowServantProjectile shadowServantProjectile2 = CS_0024_003C_003E8__locals28._003C_003E4__this;
											if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
											{
												object trail = shadowServantProjectile2._trail;
												if ((object)shadowServantProjectile2._trail != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v5 (System.Object)+10]");
													bool flag5 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v5 (System.Object)+10]");
													TrailRenderer.Clear_Injected((IntPtr)0);
													ShadowServantProjectile shadowServantProjectile3 = CS_0024_003C_003E8__locals28._003C_003E4__this;
													if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null && (object)shadowServantProjectile3._trail != null)
													{
														shadowServantProjectile3._trail.enabled = false;
														if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
														{
															CS_0024_003C_003E8__locals28._003C_003E4__this.Despawn();
															return;
														}
													}
												}
											}
										}
										throw new NullReferenceException();
									};
									tweenConfig3.onComplete = onComplete2;
									MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig3);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0051: Expected O, but got Ref
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected F4, but got Unknown
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		Transform transform = _displaySprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num = height ^ 0;
		PhaserSprite phaserSprite = _displaySprite.setDepth(num);
	}

	private void Disable()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	public override void Despawn()
	{
		if ((object)_displaySprite != null)
		{
			PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
			if ((object)_trail != null)
			{
				_trail.emitting = false;
				TrailRenderer trail = _trail;
				if ((object)_trail != null)
				{
					bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
					TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
					base.Despawn();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void LogTrailPositions()
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00da: Expected native int or pointer, but got O
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0153: Expected O, but got I4
		//IL_015c: Expected O, but got I4
		//IL_0286: Expected O, but got I4
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02f3: Expected I4, but got O
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_034e: Expected native int or pointer, but got O
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_02a0->IL024f: Incompatible stack heights: 1 vs 0
		//IL_01b2->IL0215: Incompatible stack heights: 1 vs 0
		//IL_0201->IL0215: Incompatible stack heights: 2 vs 0
		//IL_0215->IL0395: Incompatible stack heights: 2 vs 0
		TrailRenderer trail = _trail;
		if ((object)_trail == null || ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ShadowServantWeapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null && (object)((Equipment)trueWeapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.position;
			object obj2 = default(object);
			object obj = obj2 + 32;
			object arg = (float2)obj;
			System.ParamsArray paramsArray = (System.ParamsArray)(obj2 - 64);
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
			System.ParamsArray args = (System.ParamsArray)(obj2 - 32);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
			_ = 0;
			string message = string.FormatHelper((IFormatProvider)null, "[SSP] OwnerPos: {0}", args);
			Debug.Log(message);
			object trail2 = _trail;
			bool flag = (object)_trail == null;
			object obj3 = 0;
			object obj4 = 0;
			if (!flag)
			{
				object arg3 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v12 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v12 (System.Object)+10]");
					object obj5 = TrailRenderer.get_positionCount_Injected((IntPtr)0);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
					{
						object obj6 = obj2 + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						TrailRenderer trail3 = _trail;
						if ((object)_trail == null)
						{
							break;
						}
						_ = 0;
						_ = 0;
						bool flag3 = ((UnityEngine.Object)trail3).m_CachedPtr == (IntPtr)0;
						object obj7 = obj2 - 96;
						TrailRenderer.GetPosition_Injected(((UnityEngine.Object)trail3).m_CachedPtr, (int)obj4, out *(Vector3*)obj7);
						object obj8 = obj2 - 80;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-60]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-58]");
						_ = 0;
						object arg2 = (Vector3)obj8;
						System.ParamsArray paramsArray2 = (System.ParamsArray)(obj2 - 64);
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg3, arg2));
						args = (System.ParamsArray)(obj2 - 32);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
						_ = 0;
						string message2 = string.FormatHelper((IFormatProvider)null, "[SSP] TrailPos {0}: {1}", args);
						Debug.Log(message2);
						trail2 = _trail;
						obj4++;
						if ((object)_trail == null)
						{
							break;
						}
						obj3 = obj4;
						continue;
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
